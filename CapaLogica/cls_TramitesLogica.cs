using CapaDatos.Negocio;
using CapaDatos;
using System;
using CapaDTO.SistemaDTO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica.CapaLogica.Tramites
{
    public class cls_TramitesLogica
    {
        private readonly cls_TramitesQ _tramitesQ = new cls_TramitesQ();

        public List<cls_Tramite_PacienteDTO> BuscarTramites(string busquedaPaciente, DateTime? fechaInicio, DateTime? fechaFin)
        {
            return _tramitesQ.BuscarTramites(busquedaPaciente, fechaInicio, fechaFin);
        }

        public List<cls_HistorialDTO> ObtenerHistorialTramite(int idTramitePrincipal)
        {
            if (idTramitePrincipal <= 0)
                return new List<cls_HistorialDTO>();

            return _tramitesQ.ObtenerHistorialTramite(idTramitePrincipal);
        }

        public bool RegistrarComentario(int id_tp, int id_usuario, string comentario)
        {
            if (string.IsNullOrWhiteSpace(comentario) || id_tp <= 0 || id_usuario <= 0)
                return false;

            return _tramitesQ.RegistrarComentario(id_tp, id_usuario, comentario);
        }

        public bool RegistrarCambioEstado(int id_tp, int id_usuario, int id_nuevo_estado)
        {
            if (id_tp <= 0 || id_usuario <= 0 || id_nuevo_estado <= 0)
                return false;

            return _tramitesQ.RegistrarCambioEstado(id_tp, id_usuario, id_nuevo_estado);
        }

        // NUEVO: Método para crear trámites No lo use todavia mepa, no se donde usarlo va jeje por eso les preguntaba
        public int CrearNuevoTramite(int id_paciente, int id_tramite, int id_usuario_creador, string comentario_inicial = null)
        {
            if (id_paciente <= 0 || id_tramite <= 0 || id_usuario_creador <= 0)
                return 0;

            return _tramitesQ.CrearNuevoTramite(id_paciente, id_tramite, id_usuario_creador, comentario_inicial);
        }

    }
}