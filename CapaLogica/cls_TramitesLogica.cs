using CapaDatos.Negocio;
using CapaDTO;
using CapaDTO.SistemaDTO;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace CapaLogica.CapaLogica.Tramites
{
    public class cls_TramitesLogica
    {
        private readonly cls_TramitesQ _tramitesQ = new cls_TramitesQ();

        public List<cls_TramiteResumenDTO> BuscarTramites(string busquedaPaciente, DateTime? fechaInicio, DateTime? fechaFin)
        {
            if (string.IsNullOrWhiteSpace(busquedaPaciente))
                throw new Exception("Se requiere un DNI de paciente para la búsqueda.");
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

        public bool RegistrarEventoDeTipo(int id_tp, int id_usuario, int id_tipo_tramite)
        {
            if (id_tp <= 0 || id_usuario <= 0 || id_tipo_tramite <= 0)
                return false;

            try
            {
                return _tramitesQ.RegistrarEventoDeTipo(id_tp, id_usuario, id_tipo_tramite);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<cls_TiposTramitesDTO> ObtenerTiposTramite()
        {
            return _tramitesQ.ObtenerTiposTramite();
        }

        public bool CrearNuevoTramite(cls_TramiteCreacionDTO dto)
        {
            if (dto.id_paciente <= 0 || dto.id_usuario_creador <= 0 || dto.id_estado_actual <= 0)
                return false;
            if (string.IsNullOrWhiteSpace(dto.titulo_inicial))
                return false;

            try
            {
                int nuevoIdTp = _tramitesQ.InsertarTramiteMaestro(dto);

                return (nuevoIdTp > 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EstadoTramiteDTO> ObtenerEstadosPosibles()
        {
            return _tramitesQ.ObtenerEstadosPosibles();
        }




    }

}