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

        // CORREGIDO: Se renombra y simplifica. Ya no hay transacción.
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

        // CORREGIDO: Se renombra el método
        public List<cls_TiposTramitesDTO> ObtenerTiposTramite()
        {
            return _tramitesQ.ObtenerTiposTramite();
        }

        /// <summary>
        /// Crea un nuevo trámite y su primer evento de historial en una transacción.
        /// </summary>
        public bool CrearNuevoTramite(cls_TramiteCreacionDTO dto)
        {
            // 1. Validaciones
            if (dto.id_paciente <= 0 || dto.id_usuario_creador <= 0 || dto.id_estado_actual <= 0)
                return false;
            if (string.IsNullOrWhiteSpace(dto.titulo_inicial))
                return false;

            try
            {
                // 2. Inicia la transacción
                using (var scope = new TransactionScope())
                {
                    // 3. Inserta el trámite maestro y obtiene el nuevo ID
                    int nuevoIdTp = _tramitesQ.InsertarTramiteMaestro(dto);
                    if (nuevoIdTp <= 0)
                    {
                        throw new Exception("La CapaDatos no pudo devolver un ID de trámite válido.");
                    }

                    // 4. Registra el primer evento en el historial
                    // ¡AQUÍ ESTÁ LA CORRECCIÓN!
                    // Ahora pasamos el ID del ESTADO INICIAL (que viene en el DTO),
                    // que es lo que el método de CapaDatos espera.
                    _tramitesQ.RegistrarEventoDeEstado(nuevoIdTp, dto.id_usuario_creador, dto.id_estado_actual);

                    // 5. Confirma la transacción
                    scope.Complete();
                    return true;
                }
            }
            catch (Exception ex)
            {
                // Si algo falla, la transacción hace rollback
                throw ex;
            }
        }

        /// <summary>
        /// Llama a la capa de datos para poblar el ComboBox de estados maestros (Abierto, Cerrado, etc.).
        /// </summary>
        public List<EstadoTramiteDTO> ObtenerEstadosPosibles()
        {
            // Simplemente llama al método de la capa de datos que ya existe
            return _tramitesQ.ObtenerEstadosPosibles();
        }




    }

}