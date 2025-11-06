using System;
using System.Collections.Generic;
using System.Linq;
using CapaDTO.SistemaDTO;
using CapaDatos;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica.ABM
{
    public class cls_LogicaGestionarOS
    {
        private cls_ObraSocialQ _obraSocialQ;

        public cls_LogicaGestionarOS()
        {
            _obraSocialQ = new cls_ObraSocialQ();
        }

        public List<cls_ObraSocialDTO> ObtenerOSActivas()
        {
            try
            {
                return _obraSocialQ.ObtenerOSActivas();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la capa lógica al obtener Obras sociales: {ex.Message}");
                return new List<cls_ObraSocialDTO>();
            }
        }

        public List<cls_ObraSocialDTO> ObtenerTodasLasOS()
        {
            try
            {
                return _obraSocialQ.ObtenerTodasLasOS();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la capa lógica al obtener Obras sociales: {ex.Message}");
                return new List<cls_ObraSocialDTO>();
            }
        }

        public List<cls_ObraSocialDTO> ObtenerOSInactivas()
        {
            try
            {
                return _obraSocialQ.ObtenerOSInactivas();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la capa lógica al obtener Obras sociales: {ex.Message}");
                return new List<cls_ObraSocialDTO>();
            }
        }

        public bool AgregarObraSocial(cls_ObraSocialDTO nuevaOS)
        {
            try
            {
                if (string.IsNullOrEmpty(nuevaOS.nombre_os) ||
                    string.IsNullOrEmpty(nuevaOS.cuit.ToString()) ||
                    string.IsNullOrEmpty(nuevaOS.codigo.ToString()) ||
                    string.IsNullOrEmpty(nuevaOS.domicilio))
                {
                    return false;
                }

                if (nuevaOS.cuit <= 1000000000)
                {
                    return false;
                }


                _obraSocialQ.AgregarObraSocial(nuevaOS);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la capa lógica al insertar obra social: {ex.Message}");
                return false;
            }
        }

        public bool ModificarObraSocial(cls_ObraSocialDTO obraSocialModificada)
        {
            try
            {
                if (string.IsNullOrEmpty(obraSocialModificada.nombre_os) ||
                    string.IsNullOrEmpty(obraSocialModificada.cuit.ToString()) ||
                    string.IsNullOrEmpty(obraSocialModificada.codigo.ToString()) ||
                    string.IsNullOrEmpty(obraSocialModificada.domicilio))
                {
                    return false;
                }

                if (obraSocialModificada.cuit <= 1000000000)
                {
                    return false;
                }

                if (obraSocialModificada.id_obra_social <= 0)
                {
                    throw new ArgumentException("El ID de la obra social no es válido.");
                }

                _obraSocialQ.ModificarObraSocial(obraSocialModificada);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la capa lógica al modificar obra social: {ex.Message}");
                return false;
            }
        }


        public bool EliminarObraSocial(int id_obra_social)
        {
            try
            {
                _obraSocialQ.EliminarObraSocial(id_obra_social);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la capa lógica al eliminar obra social: {ex.Message}");
                return false;
            }
        }

        public bool ReactivarObraSocial(int idObraSocial)
        {
            try
            {
                if (idObraSocial <= 0)
                {
                    throw new ArgumentException("El ID de la obra social no es válido.");
                }

                _obraSocialQ.ReactivarObraSocial(idObraSocial);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la capa lógica al reactivar obra social: {ex.Message}");
                return false;
            }
        }
    }
}
