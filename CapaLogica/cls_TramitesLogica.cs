using CapaDatos; 
using CapaDatos.Negocio;
using System;
using CapaDTO.SistemaDTO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{


    namespace CapaLogica.Tramites
    {
        public class cls_TramitesLogica
        {
            private readonly cls_TramitesQ _tramitesQ = new cls_TramitesQ();

           
            private readonly cls_EjecutarQ _ejecutarQ = new cls_EjecutarQ(); // Lo llamamos para indicar su función

            public List<cls_Tramite_PacienteDTO> BuscarTramites(string busquedaPaciente, DateTime? fechaInicio, DateTime? fechaFin)
            {
 
                return _tramitesQ.BuscarTramites(busquedaPaciente, fechaInicio, fechaFin);
            }

            public List<cls_HistorialDTO> ObtenerHistorialTramite(int idTramite)
            {
                if (idTramite <= 0)
                {

                    return new List<cls_HistorialDTO>();
                }

                return _tramitesQ.ObtenerHistorialTramite(idTramite);
            }


            public bool RegistrarComentario(int id_tramite, int id_usuario, string comentario)
            {
                if (string.IsNullOrWhiteSpace(comentario) || id_tramite <= 0 || id_usuario <= 0)
                {
                    return false;
                }

                int id_paciente = _tramitesQ.ObtenerIdPacientePorIdTp(id_tramite);

                if (id_paciente <= 0)
                {
                    return false;
                }

                return _tramitesQ.RegistrarComentario(id_tramite, id_usuario, comentario, id_paciente);
            }

            public bool RegistrarCambioEstado(int idTramite, int idUsuario, int idNuevoEstado)
            {
                if (idTramite <= 0 || idUsuario <= 0 || idNuevoEstado <= 0)
                {
                    return false;
                }

                int idPaciente = _tramitesQ.ObtenerIdPacientePorIdTp(idTramite);

                if (idPaciente <= 0)
                {
                    return false;
                }
          
                return _tramitesQ.RegistrarCambioEstado(idTramite, idUsuario, idNuevoEstado, idPaciente);

            }


        }
    }
}
