using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaDTO;
using CapaDTO.SistemaDTO;

namespace CapaDatos.Negocio
{
    public class cls_TramitesQ
    {
        private readonly cls_EjecutarQ _ejecutar = new cls_EjecutarQ();

        // Este método está CORRECTO como estaba.
        public List<cls_TramiteResumenDTO> BuscarTramites(string dniPaciente, DateTime? fechaInicio, DateTime? fechaFin)
        {
            // 1. Buscamos al paciente
            string sqlPaciente = "SELECT id_paciente FROM Pacientes WHERE dni_paciente = @dni";
            var paramPaciente = new List<SqlParameter> { new SqlParameter("@dni", dniPaciente) };
            DataTable tablaPaciente = _ejecutar.ConsultaRead(sqlPaciente, paramPaciente);

            if (tablaPaciente.Rows.Count == 0)
                throw new Exception("Paciente no encontrado con ese DNI.");
            int id_paciente = Convert.ToInt32(tablaPaciente.Rows[0]["id_paciente"]);

            // 2. Buscamos los trámites (Cabecera)
            string sql = @"
                SELECT 
                    t.id_tp, t.titulo_inicial, t.fecha_creacion,
                    et.estado_descripcion AS estado_actual
                FROM Tramites t
                INNER JOIN Estado_Tramite et ON t.id_estado_actual = et.id_estado_tramite
                WHERE t.id_paciente = @id_paciente";

            var parametros = new List<SqlParameter> { new SqlParameter("@id_paciente", id_paciente) };

            if (fechaInicio.HasValue && fechaFin.HasValue)
            {
                sql += " AND t.fecha_creacion BETWEEN @fechaInicio AND @fechaFin";
                parametros.Add(new SqlParameter("@fechaInicio", fechaInicio.Value));
                parametros.Add(new SqlParameter("@fechaFin", fechaFin.Value));
            }
            sql += " ORDER BY t.fecha_creacion DESC";

            DataTable tabla = _ejecutar.ConsultaRead(sql, parametros);
            var lista = new List<cls_TramiteResumenDTO>();

            foreach (DataRow row in tabla.Rows)
            {
                lista.Add(new cls_TramiteResumenDTO
                {
                    id_tp = Convert.ToInt32(row["id_tp"]),
                    titulo_inicial = row["titulo_inicial"].ToString(),
                    fecha_creacion = Convert.ToDateTime(row["fecha_creacion"]),
                    estado_actual = row["estado_actual"].ToString()
                });
            }
            return lista;
        }

        // Este método está CORREGIDO para unirse a Tipos_Tramite
        public List<cls_HistorialDTO> ObtenerHistorialTramite(int id_tp)
        {
            string sql = @"
                SELECT 
                    h.fecha_hora,
                    u.username AS nombre_usuario, 
                    h.comentario,
                    h.es_comentario,
                    tt.descripcion AS descripcion_tipo_tramite
                FROM Tramites_Historial h
                INNER JOIN Usuarios u ON h.id_usuario = u.id_usuario
                INNER JOIN Tipos_Tramite tt ON h.id_tipo_tramite = tt.id_tipo_tramite
                WHERE h.id_tp = @id_tp
                ORDER BY h.fecha_hora ASC";

            var parametros = new List<SqlParameter> { new SqlParameter("@id_tp", id_tp) };
            DataTable tabla = _ejecutar.ConsultaRead(sql, parametros);
            var lista = new List<cls_HistorialDTO>();

            foreach (DataRow row in tabla.Rows)
            {
                lista.Add(new cls_HistorialDTO
                {
                    fecha_hora = Convert.ToDateTime(row["fecha_hora"]),
                    nombre_usuario = row["nombre_usuario"].ToString(),
                    comentario = row["comentario"].ToString(),
                    es_comentario = Convert.ToBoolean(row["es_comentario"]),
                    descripcion_tipo_tramite = row["descripcion_tipo_tramite"].ToString()
                });
            }
            return lista;
        }

        // Inserta un nuevo comentario en el historial.
        public bool RegistrarComentario(int id_tp, int id_usuario, string comentario)
        {
            // Asumimos que "Comentario de Usuario" es un tipo de trámite
            int idTipoComentario = 1; // DEBERÍAS BUSCARLO DINÁMICAMENTE (ver nota abajo)

            string sql = @"
                INSERT INTO Tramites_Historial (id_tp, fecha_hora, id_usuario, id_tipo_tramite, comentario, es_comentario) 
                VALUES (@id_tp, GETDATE(), @id_usuario, @id_tipo_tramite, @comentario, 1)"; // es_comentario = 1 (true)

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@id_tp", id_tp),
                new SqlParameter("@id_usuario", id_usuario),
                new SqlParameter("@id_tipo_tramite", idTipoComentario),
                new SqlParameter("@comentario", comentario)
            };

            _ejecutar.ConsultaWrite(sql, parametros);
            return true;
        }

        // CORREGIDO: Ya no actualiza la tabla maestra. Solo inserta un evento.
        public bool RegistrarEventoDeTipo(int id_tp, int id_usuario, int id_tipo_tramite)
        {
            string sql = @"
                INSERT INTO Tramites_Historial (id_tp, fecha_hora, id_usuario, id_tipo_tramite, comentario, es_comentario) 
                VALUES (@id_tp, GETDATE(), @id_usuario, @id_tipo_tramite, NULL, 0)"; // es_comentario = 0 (false)

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@id_tp", id_tp),
                new SqlParameter("@id_usuario", id_usuario),
                new SqlParameter("@id_tipo_tramite", id_tipo_tramite)
            };

            _ejecutar.ConsultaWrite(sql, parametros);
            return true;
        }

        // CORREGIDO: Ahora obtiene los Tipos de Trámite (para el combo)
        public List<cls_TiposTramitesDTO> ObtenerTiposTramite()
        {
            // No traemos "Comentario de Usuario" porque ese se maneja con el otro botón
            string sql = "SELECT id_tipo_tramite, descripcion FROM Tipos_Tramite WHERE descripcion <> 'Comentario de Usuario' ORDER BY descripcion";
            DataTable tabla = _ejecutar.ConsultaRead(sql, null);
            var lista = new List<cls_TiposTramitesDTO>();

            foreach (DataRow row in tabla.Rows)
            {
                lista.Add(new cls_TiposTramitesDTO
                {
                    id_tipo_tramite = Convert.ToInt32(row["id_tipo_tramite"]),
                    descripcion = row["descripcion"].ToString()
                });
            }
            return lista;
        }

        // Inserta el trámite principal (la cabecera) y devuelve el nuevo ID.
        public int InsertarTramiteMaestro(cls_TramiteCreacionDTO dto)
        {
            string sql = @"
        INSERT INTO Tramites (
            id_paciente, fecha_creacion, id_estado_actual, id_usuario_creador, titulo_inicial
        ) 
        VALUES (
            @id_paciente, GETDATE(), @id_estado_actual, @id_usuario_creador, @titulo_inicial
        );
        SELECT SCOPE_IDENTITY();"; // Devuelve el ID que se acaba de crear

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@id_paciente", dto.id_paciente),
                new SqlParameter("@id_estado_actual", dto.id_estado_actual),
                new SqlParameter("@id_usuario_creador", dto.id_usuario_creador),
                new SqlParameter("@titulo_inicial", dto.titulo_inicial)
            };

            // Usamos ConsultaRead para poder capturar el ID que devuelve SCOPE_IDENTITY
            DataTable tabla = _ejecutar.ConsultaRead(sql, parametros);
            return Convert.ToInt32(tabla.Rows[0][0]);
        }

        // Busca el ID de un Tipo de Trámite por su nombre exacto.
        public int ObtenerIdTipoTramitePorDescripcion(string descripcion)
        {
            string sql = "SELECT id_tipo_tramite FROM Tipos_Tramite WHERE descripcion = @descripcion";
            var parametros = new List<SqlParameter> { new SqlParameter("@descripcion", descripcion) };

            DataTable tabla = _ejecutar.ConsultaRead(sql, parametros);

            if (tabla.Rows.Count == 0)
            {
                // Lanzamos una excepción clara porque el sistema no puede funcionar sin este dato.
                throw new Exception($"Error fatal: No se encontró el 'Tipo_Tramite' llamado '{descripcion}' en la base de datos.");
            }

            // Devolvemos el int, no el DataTable
            return Convert.ToInt32(tabla.Rows[0]["id_tipo_tramite"]);
        }


        // Registra el evento de cambio de estado en el historial.
        public bool RegistrarEventoDeEstado(int id_tp, int id_usuario, int id_nuevo_estado)
        {
            // Asumimos que un cambio de estado tiene un 'id_tipo_tramite' = 2 (o el que corresponda)
            // DEBERÍAS verificar qué ID es "Cambio de Estado" en tu tabla Tipos_Tramite
            string sqlTipo = "SELECT id_tipo_tramite FROM Tipos_Tramite WHERE descripcion = 'Cambio de Estado'";
            DataTable tablaTipo = _ejecutar.ConsultaRead(sqlTipo, null);
            if (tablaTipo.Rows.Count == 0)
                throw new Exception("Error fatal: No se encontró el 'Tipo_Tramite' llamado 'Cambio de Estado' en la base de datos.");

            int idTipoCambioEstado = Convert.ToInt32(tablaTipo.Rows[0]["id_tipo_tramite"]);

            string sql = @"
                INSERT INTO Tramites_Historial (id_tp, fecha_hora, id_usuario, id_tipo_tramite, comentario, es_comentario) 
                VALUES (@id_tp, GETDATE(), @id_usuario, @id_tipo_tramite, NULL, 0)"; // es_comentario = 0 (false)

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@id_tp", id_tp),
                new SqlParameter("@id_usuario", id_usuario),
                new SqlParameter("@id_tipo_tramite", idTipoCambioEstado)
            };

            _ejecutar.ConsultaWrite(sql, parametros);
            return true;
        }

        // Obtiene los posibles estados MAESTROS para el ComboBox (Abierto, Cerrado, etc.)
        public List<EstadoTramiteDTO> ObtenerEstadosPosibles()
        {
            string sql = "SELECT id_estado_tramite, estado_descripcion FROM Estado_Tramite ORDER BY estado_descripcion";
            DataTable tabla = _ejecutar.ConsultaRead(sql, null);
            var lista = new List<EstadoTramiteDTO>();

            foreach (DataRow row in tabla.Rows)
            {
                lista.Add(new EstadoTramiteDTO
                {
                    id_estado_tramite = Convert.ToInt32(row["id_estado_tramite"]),
                    estado_descripcion = row["estado_descripcion"].ToString()
                });
            }
            return lista;
        }




    }
}