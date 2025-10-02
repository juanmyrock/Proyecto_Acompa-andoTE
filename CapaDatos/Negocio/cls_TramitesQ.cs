using CapaDTO.SistemaDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Negocio
{
    public class cls_TramitesQ
    {   private readonly cls_EjecutarQ _ejecutarQ = new cls_EjecutarQ();
        

        public List<cls_TramitesDTO> ObtenerTramites()
        {
           

            string sp = "SELECT * FROM Tramites";

            DataTable tb = _ejecutarQ.ConsultaRead(sp, null);

            List<cls_TramitesDTO> listaTramites = new List<cls_TramitesDTO>();

            foreach (DataRow row in tb.Rows)
            {
                listaTramites.Add(new cls_TramitesDTO
                {
                    id_tramite = Convert.ToInt32(row["id_tramite"]),

                    descripcion = row["descripcion"].ToString(),

                });

            }
            return listaTramites;
        }

        public List<cls_Tramite_PacienteDTO> BuscarTramites(string busquedaPaciente, DateTime? fechaInicio, DateTime? fechaFin)
        {
            // La consulta es compleja. Busca pacientes por DNI o Apellido,
            // y trae el último estado del trámite de ese paciente.
            string sql = @"
                SELECT 
                    TP1.id_tp AS IdTramite, 
                    P.id_paciente, 
                    P.nombre, 
                    P.apellido, 
                    T.descripcion AS TipoTramite,
                    ULTIMO_ESTADO.descripcion AS EstadoActual
                FROM Pacientes P
                INNER JOIN Tramite_Paciente TP1 ON P.id_paciente = TP1.id_paciente
                INNER JOIN Tramites T ON T.id_tramite = TP1.id_tramite
                LEFT JOIN (
                    -- Subconsulta para encontrar el último estado de CADA trámite
                    SELECT 
                        TP_INNER.id_tp, 
                        TR.descripcion
                    FROM Tramite_Paciente TP_INNER
                    INNER JOIN Tramites TR ON TR.id_tramite = TP_INNER.id_tramite
                    WHERE TP_INNER.id_tp IN (
                        SELECT TOP 1 id_tp
                        FROM Tramite_Paciente TP_MAX
                        WHERE TP_MAX.id_paciente = TP_INNER.id_paciente
                        ORDER BY TP_MAX.fecha_hora DESC
                    )
                ) AS ULTIMO_ESTADO ON ULTIMO_ESTADO.id_tp = TP1.id_tp
                WHERE 
                    (P.dni_paciente = @Busqueda OR P.apellido LIKE '%' + @Busqueda + '%')
                    AND (@FechaInicio IS NULL OR TP1.fecha_hora >= @FechaInicio)
                    AND (@FechaFin IS NULL OR TP1.fecha_hora <= @FechaFin)
                GROUP BY 
                    TP1.id_tp, P.id_paciente, P.nombre, P.apellido, T.descripcion, ULTIMO_ESTADO.descripcion
                ORDER BY 
                    P.apellido, P.nombre, TP1.id_tp DESC;";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@Busqueda", string.IsNullOrEmpty(busquedaPaciente) ? (object)DBNull.Value : busquedaPaciente),
                new SqlParameter("@FechaInicio", fechaInicio.HasValue ? (object)fechaInicio.Value : DBNull.Value),
                new SqlParameter("@FechaFin", fechaFin.HasValue ? (object)fechaFin.Value : DBNull.Value)
            };

            DataTable tb = _ejecutarQ.ConsultaRead(sql, parameters);
            List<cls_Tramite_PacienteDTO> lista = new List<cls_Tramite_PacienteDTO>();

            foreach (DataRow row in tb.Rows)
            {
                lista.Add(new cls_Tramite_PacienteDTO
                {
                    IdTramite = Convert.ToInt32(row["IdTramite"]),
                    IdPaciente = Convert.ToInt32(row["id_paciente"]),
                    NombrePacienteCompleto = $"{row["apellido"]}, {row["nombre"]}",
                    Descripcion = $"TR-{Convert.ToInt32(row["IdTramite"]):0000} ({row["TipoTramite"]}) - {row["apellido"]}",
                    EstadoActual = row["EstadoActual"].ToString()
                });
            }
            return lista;
        }

        public List<cls_HistorialDTO> ObtenerHistorialTramite(int idTramite)
        {
            // Trae todos los registros de la tabla Tramite_Paciente para un id_tp específico.
            string sql = @"
                SELECT 
                    TP.fecha_hora, 
                    U.nombre_usuario, -- Asumo que tienes una tabla Usuarios con nombre_usuario
                    TP.comentario, 
                    T.descripcion
                FROM Tramite_Paciente TP
                LEFT JOIN Usuarios U ON U.id_usuario = TP.id_usuario
                LEFT JOIN Tramites T ON T.id_tramite = TP.id_tramite -- Si T.id_tramite está seteado es un cambio de estado
                WHERE TP.id_tp = @IdTramite
                ORDER BY TP.fecha_hora ASC";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@IdTramite", idTramite)
            };

            DataTable tb = _ejecutarQ.ConsultaRead(sql, parameters);
            List<cls_HistorialDTO> historial = new List<cls_HistorialDTO>();

            foreach (DataRow row in tb.Rows)
            {
                bool esEstado = row["descripcion"] != DBNull.Value;

                historial.Add(new cls_HistorialDTO
                {
                    FechaHora = Convert.ToDateTime(row["fecha_hora"]),
                    Usuario = row["nombre_usuario"] != DBNull.Value ? row["nombre_usuario"].ToString() : "Sistema",
                    Comentario = row["comentario"] != DBNull.Value ? row["comentario"].ToString() : string.Empty,
                    EsCambioDeEstado = esEstado,
                    NuevoEstado = esEstado ? row["descripcion"].ToString() : string.Empty
                });
            }
            return historial;
        }

        public bool RegistrarComentario(int idTp, int idUsuario, string comentario)
        {
            // Insertar solo comentario. id_tramite (estado) es NULL.
            string sql = @"
                INSERT INTO Tramite_Paciente 
                (id_tp, id_paciente, fecha_hora, id_usuario, comentario)
                VALUES (@IdTp, 
                        (SELECT id_paciente FROM Tramite_Paciente WHERE id_tp = @IdTp LIMIT 1), -- Asumiendo MySQL/PostgreSQL o usar subconsulta para obtener id_paciente
                        GETDATE(), @IdUsuario, @Comentario)"; // Usar GETDATE() para SQL Server

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@IdTp", idTp),
                new SqlParameter("@IdUsuario", idUsuario),
                new SqlParameter("@Comentario", comentario)
            };

            return _ejecutarQ.ConsultaCUD(sql, parameters) > 0;
        }

        public bool RegistrarCambioEstado(int idTp, int idUsuario, int idNuevoEstado)
        {
            // Solo listamos las columnas a las que se les da un valor no-NULL. 
            // SQL Server asignará NULL automáticamente al campo 'comentario'.
            string sql = @"
            INSERT INTO Tramite_Paciente 
            (id_tp, id_paciente, fecha_hora, id_usuario, id_tramite)
            VALUES (@id_tp, 
                    (SELECT TOP 1 id_paciente FROM Tramite_Paciente WHERE id_tp = @id_tp),
                    GETDATE(), @id_usuario, @IdNuevoEstado)";
            // NOTA: Se elimina ORDER BY fecha_hora DESC de la subconsulta si id_tp ya es el ID único del trámite.

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@id_tp", idTp),
                new SqlParameter("@id_usuario", idUsuario),
                new SqlParameter("@IdNuevoEstado", idNuevoEstado)
            };

            return _ejecutarQ.ConsultaCUD(sql, parameters) > 0;
        }



    }
}
