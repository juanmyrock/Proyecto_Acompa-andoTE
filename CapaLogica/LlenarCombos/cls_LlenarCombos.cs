using CapaDatos.Utilidades;
using CapaDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaLogica.LlenarCombos
{
    public class cls_LlenarCombos
    {
        private cls_LlenarCombosQ _llenador;

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
    }
}
