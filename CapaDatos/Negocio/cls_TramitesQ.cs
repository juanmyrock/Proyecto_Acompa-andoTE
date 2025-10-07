using CapaDTO.SistemaDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
            string sql = @"
                SELECT 
                    TP.id_tp AS IdTramite,
                    TP.id_tramite, 
                    P.id_paciente,
                    P.nombre,
                    P.apellido, 
                    T.descripcion AS TipoTramite,
                    T_ESTADO.descripcion AS EstadoActual,
                    TP.fecha_creacion,
                    TP.comentario_inicial
                FROM Tramites TP
                INNER JOIN Pacientes P ON P.id_paciente = TP.id_paciente
                INNER JOIN Tipos_Tramite T ON T.id_tramite = TP.id_tramite
                INNER JOIN Tipos_Tramite T_ESTADO ON T_ESTADO.id_tramite = TP.estado_actual
                WHERE 
                    (P.dni_paciente = @Busqueda OR P.apellido LIKE '%' + @Busqueda + '%')
                    AND (@FechaInicio IS NULL OR TP.fecha_creacion >= @FechaInicio)
                    AND (@FechaFin IS NULL OR TP.fecha_creacion <= @FechaFin)
                ORDER BY 
                    P.apellido, P.nombre, TP.fecha_creacion DESC";

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
                    id_tp = Convert.ToInt32(row["IdTramite"]),  // Usar el alias correcto
                    id_paciente = Convert.ToInt32(row["id_paciente"]),
                    id_tramite = Convert.ToInt32(row["id_tramite"]),
                    NombrePacienteCompleto = $"{row["apellido"]}, {row["nombre"]}",
                    Descripcion = $"TR-{Convert.ToInt32(row["IdTramite"]):0000} ({row["TipoTramite"]}) - {row["apellido"]}",
                    EstadoActual = row["EstadoActual"].ToString(),
                    fecha_creacion = Convert.ToDateTime(row["fecha_creacion"]),
                    comentario_inicial = row["comentario_inicial"] != DBNull.Value ? row["comentario_inicial"].ToString() : string.Empty
                });
            }
            return lista;
        }

        public List<cls_HistorialDTO> ObtenerHistorialTramite(int idTramitePrincipal)
        {
            string sql = @"
                SELECT 
                    TH.fecha_hora,
                    U.username,
                    TH.comentario,
                    T.descripcion AS NuevoEstado,
                    TH.tipo_accion
                FROM Tramites_Historial TH
                LEFT JOIN Usuarios U ON U.id_usuario = TH.id_usuario
                LEFT JOIN Tipos_Tramite T ON T.id_tramite = TH.id_tramite_nuevo
                WHERE TH.id_tp = @IdTramitePrincipal
                ORDER BY TH.fecha_hora ASC";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@IdTramitePrincipal", idTramitePrincipal)
            };

            DataTable tb = _ejecutarQ.ConsultaRead(sql, parameters);
            List<cls_HistorialDTO> historial = new List<cls_HistorialDTO>();

            foreach (DataRow row in tb.Rows)
            {
                string tipoAccion = row["tipo_accion"].ToString();
                bool esCambioDeEstado = tipoAccion == "CAMBIO_ESTADO";

                historial.Add(new cls_HistorialDTO
                {
                    FechaHora = Convert.ToDateTime(row["fecha_hora"]),
                    Usuario = row["username"] != DBNull.Value ? row["username"].ToString() : "Sistema",
                    Comentario = row["comentario"] != DBNull.Value ? row["comentario"].ToString() : string.Empty,
                    EsCambioDeEstado = esCambioDeEstado,
                    NuevoEstado = esCambioDeEstado ? row["NuevoEstado"].ToString() : string.Empty,
                    TipoAccion = tipoAccion
                });
            }
            return historial;
        }

        public bool RegistrarComentario(int id_tp, int id_usuario, string comentario)
        {
            string sql = @"
                INSERT INTO Tramites_Historial 
                (id_tp, fecha_hora, id_usuario, comentario, tipo_accion) 
                VALUES (
                    @id_tp,
                    GETDATE(),
                    @id_usuario,
                    @comentario,
                    'COMENTARIO'
                )";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@id_tp", id_tp),
                new SqlParameter("@id_usuario", id_usuario),
                new SqlParameter("@comentario", comentario)
            };

            return _ejecutarQ.ConsultaCUD(sql, parameters) > 0;
        }

        // Método para obtener el id_tramite por id_tp
        //private int ObtenerIdTramitePorIdTp(int id_tp)
        //{
        //    string sql = @"
        //        SELECT TOP 1 id_tramite 
        //        FROM Tramite_Paciente 
        //        WHERE id_tp = @id_tp
        //        ORDER BY fecha_hora ASC";

        //    SqlParameter[] parameters = new SqlParameter[]
        //    {
        //        new SqlParameter("@id_tp", id_tp)
        //    };

        //    DataTable tb = _ejecutarQ.ConsultaRead(sql, parameters.ToList());

        //    if (tb != null && tb.Rows.Count > 0)
        //    {
        //        DataRow row = tb.Rows[0];
        //        if (row["id_tramite"] != DBNull.Value)
        //        {
        //            return Convert.ToInt32(row["id_tramite"]);
        //        }
        //    }
        //    return 0;
        //}

        public int ObtenerIdPacientePorIdTp(int id_tp)
        {
           
            string sql = @"
                SELECT TOP 1 id_paciente 
                FROM Tramite_Paciente 
                WHERE id_tp = @id_tp
                ORDER BY fecha_hora ASC"; 

                    SqlParameter[] parameters = new SqlParameter[]
                    {
                         new SqlParameter("@id_tp", id_tp)
                    };

            DataTable tb = _ejecutarQ.ConsultaRead(sql, parameters.ToList());

            if (tb != null && tb.Rows.Count > 0)
            {
                DataRow row = tb.Rows[0];
                if (row["id_paciente"] != DBNull.Value)
                {
                    return Convert.ToInt32(row["id_paciente"]);
                }
            }
            return 0;
        }

        public bool RegistrarCambioEstado(int id_tp, int id_usuario, int id_nuevo_estado)
        {
            try
            {
                // 1. Actualizar el estado actual en la tabla principal
                string sqlUpdate = @"
                    UPDATE Tramites
                    SET estado_actual = @id_nuevo_estado
                    WHERE id_tp = @id_tp";

                var parametersUpdate = new List<SqlParameter>
                {
                    new SqlParameter("@id_tp", id_tp),
                    new SqlParameter("@id_nuevo_estado", id_nuevo_estado)
                };

                int filasActualizadas = _ejecutarQ.ConsultaCUD(sqlUpdate, parametersUpdate);

                if (filasActualizadas <= 0)
                {
                    LogToFile("ERROR: No se pudo actualizar el estado en Tramites_Principal");
                    return false;
                }

                // 2. Registrar en el historial
                string sqlInsert = @"
                    INSERT INTO Tramites_Historial 
                    (id_tp, fecha_hora, id_usuario, id_tramite_nuevo, tipo_accion) 
                    VALUES (
                        @id_tp,
                        GETDATE(),
                        @id_usuario,
                        @id_tramite_nuevo,
                        'CAMBIO_ESTADO'
                    )";

                var parametersInsert = new List<SqlParameter>
                {
                    new SqlParameter("@id_tp", id_tp),
                    new SqlParameter("@id_usuario", id_usuario),
                    new SqlParameter("@id_tramite_nuevo", id_nuevo_estado)
                };

                int filasInsertadas = _ejecutarQ.ConsultaCUD(sqlInsert, parametersInsert);

                bool exito = filasInsertadas > 0;
                LogToFile($"RegistrarCambioEstado - Update: {filasActualizadas}, Insert: {filasInsertadas}, Éxito: {exito}");

                return exito;
            }
            catch (Exception ex)
            {
                LogToFile($"EXCEPCIÓN en RegistrarCambioEstado: {ex.Message}");
                return false;
            }
        }

        public int CrearNuevoTramite(int id_paciente, int id_tramite, int id_usuario_creador, string comentario_inicial = null)
        {
            string sql = @"
                INSERT INTO Tramites
                (id_paciente, id_tramite, fecha_creacion, estado_actual, id_usuario_creador, comentario_inicial) 
                VALUES (
                    @id_paciente,
                    @id_tramite,
                    GETDATE(),
                    @id_tramite,  -- Estado inicial igual al tipo de trámite
                    @id_usuario_creador,
                    @comentario_inicial
                );
                SELECT SCOPE_IDENTITY();";  // Retorna el id_tp generado

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@id_paciente", id_paciente),
                new SqlParameter("@id_tramite", id_tramite),
                new SqlParameter("@id_usuario_creador", id_usuario_creador),
                new SqlParameter("@comentario_inicial", string.IsNullOrEmpty(comentario_inicial) ? (object)DBNull.Value : comentario_inicial)
            };

            DataTable tb = _ejecutarQ.ConsultaRead(sql, parameters);

            if (tb != null && tb.Rows.Count > 0)
            {
                int id_tp_generado = Convert.ToInt32(tb.Rows[0][0]);
                LogToFile($"Nuevo trámite creado - id_tp: {id_tp_generado}");
                return id_tp_generado;
            }

            LogToFile("ERROR: No se pudo crear el nuevo trámite");
            return 0;
        }

        private void LogToFile(string message)
        {
            try
            {
                string path = @"C:\temp\tramites_debug.txt";
                string directory = Path.GetDirectoryName(path);

                // Crear directorio si no existe
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                File.AppendAllText(path, $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}: {message}\n");
            }
            catch (Exception ex)
            {
                // Si falla el logging, no hacer nada para no complicar el debug
            }
        }

    }
}
