using CapaDatos;
using CapaDatos.Utilidades;
using CapaDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaLogica.LlenarCombos
{
    public class cls_LlenarCombos
    {
        private cls_LlenarCombosQ _llenador;
        private cls_EjecutarQ _ejecutarQ = new cls_EjecutarQ();

        public cls_LlenarCombos()
        {
            _llenador = new cls_LlenarCombosQ();
        }

        public LlenarCombosResponseDTO ObtenerLocalidades()
        {
            try
            {
                return _llenador.ObtenerLocalidades();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener localidades: {ex.Message}");
                return null;
            }
        }

        public LlenarCombosResponseDTO ObtenerProvincias()
        {
            try
            {
                return _llenador.ObtenerProvincias();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener provincias: {ex.Message}");
                return null;
            }
        }

        public LlenarCombosResponseDTO ObtenerSexos()
        {
            try
            {
                return _llenador.ObtenerSexos();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener sexos: {ex.Message}");
                return null;
            }
        }

        public LlenarCombosResponseDTO ObtenerTiposDocumento()
        {
            try
            {
                return _llenador.ObtenerTiposDocumento();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener tipos de documento: {ex.Message}");
                return null;
            }
        }

        public LlenarCombosResponseDTO ObtenerEspecialidades()
        {
            try { return _llenador.ObtenerEspecialidades(); }
            catch(Exception ex)
            {
                Console.WriteLine($"Error al obtener especialidades: {ex.Message}");
                return null;
            }
        }

        public LlenarCombosResponseDTO ObtenerRoles()
        {
            try
            {
                return _llenador.ObtenerRoles();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener roles: {ex.Message}");
                return null;
            }
        }

        public LlenarCombosResponseDTO ObtenerObrasSociales()
        {
            try
            {
                return _llenador.ObtenerObrasSociales();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener obras sociales: {ex.Message}");
                return null;
            }
        }

        public LlenarCombosResponseDTO ObtenerProfesionales()
        {
            try
            {
                return _llenador.ObtenerProfesionales();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener acompañantes: {ex.Message}");
                return null;
            }
        }

        public LlenarCombosResponseDTO ObtenerTramites()
        {
            try
            {
                return _llenador.ObtenerTramites();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener tramites: {ex.Message}");
                return null;
            }
        }
    }
}
