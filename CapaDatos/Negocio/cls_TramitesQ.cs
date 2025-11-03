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
        

        public List<cls_Tramite_PacienteDTO> BuscarTramites(string busquedaPaciente, DateTime? fechaInicio, DateTime? fechaFin)
        {
            string sql = "[dbo].[BuscarTramites]";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@Busqueda", string.IsNullOrEmpty(busquedaPaciente) ? (object)DBNull.Value : busquedaPaciente),
                new SqlParameter("@FechaInicio", fechaInicio.HasValue ? (object)fechaInicio.Value : DBNull.Value),
                new SqlParameter("@FechaFin", fechaFin.HasValue ? (object)fechaFin.Value : DBNull.Value)
            };

            DataTable tb = _ejecutarQ.ConsultaReadSP(sql, parameters);
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
            string sql = "[dbo].[ObtenerHistorialTramite]";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@IdTramitePrincipal", idTramitePrincipal)
            };

            DataTable tb = _ejecutarQ.ConsultaReadSP(sql, parameters);
            List<cls_HistorialDTO> historial = new List<cls_HistorialDTO>();

            foreach (DataRow row in tb.Rows)
            {
                int tipoAccion = Convert.ToInt32(row["es_comentario"]);
                bool esCambioDeEstado = tipoAccion == 0;

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
            string sql = "[dbo].[RegistrarComentario]";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@id_tp", id_tp),
                new SqlParameter("@id_usuario", id_usuario),
                new SqlParameter("@comentario", comentario)
            };

            return _ejecutarQ.ConsultaCUDSP(sql, parameters) > 0;
        }

        public bool RegistrarCambioEstado(int id_tp, int id_usuario, int id_nuevo_estado)
        {
            try
            {
                string storedProcedure = "[dbo].[RegistrarCambioEstado]";

                var parameters = new List<SqlParameter>
        {
            new SqlParameter("@id_tp", id_tp),
            new SqlParameter("@id_usuario", id_usuario),
            new SqlParameter("@id_nuevo_estado", id_nuevo_estado)
        };

                _ejecutarQ.ConsultaWriteSP(storedProcedure, parameters);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en RegistrarCambioEstado: {ex.Message}");
                return false;
            }
        }

        public int CrearNuevoTramite(int id_paciente, int id_tramite, int id_usuario_creador, string comentario_inicial)
        {
            try
            {
                string storedProcedure = "[dbo].[CrearNuevoTramite]";

                var parameters = new List<SqlParameter>
        {
            new SqlParameter("@id_paciente", id_paciente),
            new SqlParameter("@id_tramite", id_tramite),
            new SqlParameter("@id_usuario_creador", id_usuario_creador),
            new SqlParameter("@comentario_inicial", comentario_inicial ?? (object)DBNull.Value)
        };

                DataTable dt = _ejecutarQ.ConsultaReadSP(storedProcedure, parameters);

                if (dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(dt.Rows[0]["id_tp_generado"]);
                }

                return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en CrearNuevoTramite: {ex.Message}");
                return -1;
            }
        }


    }
}
