using CapaDTO.SistemaDTO;
using CapaDatos.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica.SistemaLogica
{
    public class cls_LogicaGestionarProfesionales
    {
        private readonly cls_ProfesionalesQ _profesionalesQ = new cls_ProfesionalesQ();

        public List<cls_ProfesionalDTO> ObtenerProfesionalesActivos()
        {
            return _profesionalesQ.ObtenerProfesionalesActivos();
        }

        public List<cls_ProfesionalDTO> ObtenerProfesionalesInactivos()
        {
            return _profesionalesQ.ObtenerProfesionalesInactivos();
        }

        public List<cls_ProfesionalDTO> ObtenerProfesionales()
        {
            return _profesionalesQ.ObtenerProfesionales();
        }

        public bool InsertarProfesional(cls_ProfesionalDTO profesional)
        {
            try
            {
                _profesionalesQ.AgregarProfesional(profesional);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar profesional: {ex.Message}");
                return false;
            }
        }

        public bool ActualizarProfesional(cls_ProfesionalDTO profesional)
        {
            return _profesionalesQ.ModificarProfesional(profesional);
        }

        public bool EliminarProfesional(int idProfesional)
        {
            try
            {
                _profesionalesQ.EliminarProfesional(idProfesional);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar profesional: {ex.Message}");
                return false;
            }
        }

        public bool ReactivarProfesional(int idProfesional)
        {
            try
            {
                _profesionalesQ.ReactivarProfesional(idProfesional);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al reactivar profesional: {ex.Message}");
                return false;
            }
        }

        public cls_ProfesionalDTO BuscarProfesionalPorDni(int dni)
        {
            return _profesionalesQ.BuscarProfesionalPorDni(dni);
        }

        public List<cls_ProfesionalDTO> ObtenerProfesionalesActivosPorEspecialidad(int idEspecialidad)
        {
            return _profesionalesQ.ObtenerProfesionalesActivosPorEspecialidad(idEspecialidad);
        }

        public List<cls_ProfesionalDTO> ObtenerProfesionalesInactivosPorEspecialidad(int idEspecialidad)
        {
            return _profesionalesQ.ObtenerProfesionalesInactivosPorEspecialidad(idEspecialidad);
        }

        public List<cls_ProfesionalDTO> ObtenerTodosProfesionalesPorEspecialidad(int idEspecialidad)
        {
            return _profesionalesQ.ObtenerTodosProfesionalesPorEspecialidad(idEspecialidad);
        }
    }
}