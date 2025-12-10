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

        // 1. BUSCAR (Modificado para aceptar filtro 'mostrarCerrados')
        public List<cls_TramiteResumenDTO> BuscarTramites(string dniPaciente, DateTime? fechaInicio, DateTime? fechaFin, bool mostrarCerrados)
        {
            // 1. Buscar ID Paciente
            string sqlPaciente = "SELECT id_paciente FROM Pacientes WHERE dni_paciente = @dni";
            var paramPaciente = new List<SqlParameter> { new SqlParameter("@dni", dniPaciente) };
            DataTable tablaPaciente = _ejecutar.ConsultaRead(sqlPaciente, paramPaciente);

            if (tablaPaciente.Rows.Count == 0)
                throw new Exception("Paciente no encontrado con ese DNI.");
            int id_paciente = Convert.ToInt32(tablaPaciente.Rows[0]["id_paciente"]);

            // 2. Query Base
            string sql = @"
                SELECT 
                    t.id_tp, t.titulo_inicial, t.fecha_creacion,
                    et.estado_descripcion AS estado_actual
                FROM Tramites t
                INNER JOIN Estado_Tramite et ON t.id_estado_actual = et.id_estado_tramite
                WHERE t.id_paciente = @id_paciente";

            var parametros = new List<SqlParameter> { new SqlParameter("@id_paciente", id_paciente) };

            // 3. Filtros Dinámicos

            // Fechas
            if (fechaInicio.HasValue && fechaFin.HasValue)
            {
                sql += " AND t.fecha_creacion BETWEEN @fechaInicio AND @fechaFin";
                parametros.Add(new SqlParameter("@fechaInicio", fechaInicio.Value));
                parametros.Add(new SqlParameter("@fechaFin", fechaFin.Value));
            }

            // --- NUEVO: Filtro de Cerrados ---
            if (!mostrarCerrados)
            {
                // Si NO queremos ver los cerrados, los excluimos
                sql += " AND et.estado_descripcion <> 'Cerrado'";
            }

            sql += " ORDER BY t.fecha_creacion DESC";

            // 4. Ejecución
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

        // 2. ACTUALIZAR (Nuevo método para editar título y estado)
        public bool ActualizarTramiteMaestro(int id_tp, string titulo, int id_estado)
        {
            string sql = @"
                UPDATE Tramites 
                SET titulo_inicial = @titulo, 
                    id_estado_actual = @id_estado
                WHERE id_tp = @id_tp";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@id_tp", id_tp),
                new SqlParameter("@titulo", titulo),
                new SqlParameter("@id_estado", id_estado)
            };

            _ejecutar.ConsultaWrite(sql, parametros);
            return true;
        }

        // 3. OBTENER POR ID (Nuevo método para llenar el popup de edición)
        public cls_TramiteCreacionDTO ObtenerTramitePorId(int id_tp)
        {
            // Nota: Aquí no necesitamos el ID de usuario creador ni paciente para editar,
            // pero reutilizamos el DTO de Creación para no crear uno nuevo.
            string sql = @"SELECT titulo_inicial, id_estado_actual FROM Tramites WHERE id_tp = @id_tp";
            var parametros = new List<SqlParameter> { new SqlParameter("@id_tp", id_tp) };

            DataTable dt = _ejecutar.ConsultaRead(sql, parametros);

            if (dt.Rows.Count > 0)
            {
                return new cls_TramiteCreacionDTO
                {
                    titulo_inicial = dt.Rows[0]["titulo_inicial"].ToString(),
                    id_estado_actual = Convert.ToInt32(dt.Rows[0]["id_estado_actual"]),
                    // Los demás campos quedan en 0/null porque no se usan para pintar el form
                };
            }
            return null;
        }

        // --- MÉTODOS EXISTENTES (Sin cambios) ---

        public List<cls_HistorialDTO> ObtenerHistorialTramite(int id_tp)
        {
            string sql = @"
                SELECT 
                    h.fecha_hora, u.username AS nombre_usuario, h.comentario, h.es_comentario,
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

        public bool RegistrarComentario(int id_tp, int id_usuario, string comentario)
        {
            string sqlTipo = "SELECT id_tipo_tramite FROM Tipos_Tramite WHERE descripcion = 'Comentario de Usuario'";
            DataTable tablaTipo = _ejecutar.ConsultaRead(sqlTipo, null);
            int idTipoComentario = (tablaTipo.Rows.Count > 0) ? Convert.ToInt32(tablaTipo.Rows[0]["id_tipo_tramite"]) : 1;

            string sql = @"
                INSERT INTO Tramites_Historial (id_tp, fecha_hora, id_usuario, id_tipo_tramite, comentario, es_comentario) 
                VALUES (@id_tp, GETDATE(), @id_usuario, @id_tipo_tramite, @comentario, 1)";

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

        public bool RegistrarEventoDeTipo(int id_tp, int id_usuario, int id_tipo_tramite)
        {
            string sql = @"
                INSERT INTO Tramites_Historial (id_tp, fecha_hora, id_usuario, id_tipo_tramite, comentario, es_comentario) 
                VALUES (@id_tp, GETDATE(), @id_usuario, @id_tipo_tramite, NULL, 0)";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@id_tp", id_tp),
                new SqlParameter("@id_usuario", id_usuario),
                new SqlParameter("@id_tipo_tramite", id_tipo_tramite)
            };
            _ejecutar.ConsultaWrite(sql, parametros);
            return true;
        }

        public List<cls_TiposTramitesDTO> ObtenerTiposTramite()
        {
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

        public int InsertarTramiteMaestro(cls_TramiteCreacionDTO dto)
        {
            string sql = @"
                INSERT INTO Tramites (id_paciente, fecha_creacion, id_estado_actual, id_usuario_creador, titulo_inicial) 
                VALUES (@id_paciente, GETDATE(), @id_estado_actual, @id_usuario_creador, @titulo_inicial);
                SELECT SCOPE_IDENTITY();";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@id_paciente", dto.id_paciente),
                new SqlParameter("@id_estado_actual", dto.id_estado_actual),
                new SqlParameter("@id_usuario_creador", dto.id_usuario_creador),
                new SqlParameter("@titulo_inicial", dto.titulo_inicial)
            };

            DataTable tabla = _ejecutar.ConsultaRead(sql, parametros);
            return Convert.ToInt32(tabla.Rows[0][0]);
        }

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