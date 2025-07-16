using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDTO.SistemaDTO; 
using CapaDatos;

namespace CapaLogica.SistemaLogica
{
    public class cls_LogicaGestionEmpleados
    {

        private cls_EmpleadosQ _empleadosQ;

        public cls_LogicaGestionEmpleados()
        {
            _empleadosQ = new cls_EmpleadosQ();
        }

 
        public bool InsertarEmpleado(cls_EmpleadoDTO nuevoEmpleado)
        {
            try
            {
                return _empleadosQ.InsertarEmpleado(nuevoEmpleado);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la capa lógica al insertar empleado: {ex.Message}");
                return false;
            }
        }
        public List<cls_EmpleadoDTO> ObtenerEmpleados()
        {
            return _empleadosQ.ObtenerEmpleados();
        }

        public bool ActualizarEmpleado(cls_EmpleadoDTO empleadoModificado)
        {
            try
            {
                return _empleadosQ.ActualizarEmpleado(empleadoModificado);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la capa lógica al actualizar empleado: {ex.Message}");
                return false;
            }
        }

        public bool EliminarEmpleado(int id_empleado)
        {
            try
            {
                return _empleadosQ.EliminarEmpleado(id_empleado);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la capa lógica al eliminar empleado: {ex.Message}");
                return false;
            }
        }
    }
}