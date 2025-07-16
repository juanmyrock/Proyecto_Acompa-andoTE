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
    public class cls_Empleado
    {
        // Instancia de la clase de la Capa de Datos para interactuar con la DB
        private cls_EmpleadosQ _empleadosQ;

        public cls_Empleado()
        {
            _empleadosQ = new cls_EmpleadosQ();
        }

 
        public bool InsertarEmpleado(cls_EmpleadoDTO empleado)
        {
            try
            {
                return _empleadosQ.InsertarEmpleado(empleado);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la capa lógica al insertar empleado: {ex.Message}");
                return false;
            }
        }
        public List<cls_EmpleadoDTO> ObtenerEmpleados()
        {
            List<cls_EmpleadoDTO> listaEmpleados = new List<cls_EmpleadoDTO>();
            try
            {
                DataTable dtEmpleados = _empleadosQ.ObtenerEmpleados();

                // Itera sobre las filas del DataTable y mapea a DTOs
                foreach (DataRow row in dtEmpleados.Rows)
                {
                    listaEmpleados.Add(new cls_EmpleadoDTO
                    {
                        id_empleado = Convert.ToInt32(row["id_empleado"]),
                        puesto = row["puesto"].ToString(),
                        nombre = row["nombre"].ToString(),
                        apellido = row["apellido"].ToString(),
                        id_sexo = Convert.ToInt32(row["id_sexo"]),
                        id_tipo_dni = Convert.ToInt32(row["id_tipo_dni"]),
                        dni = Convert.ToInt32(row["dni"]),
                        fecha_nac = Convert.ToDateTime(row["fecha_nac"]),
                        id_localidad = Convert.ToInt32(row["id_localidad"]),
                        domicilio = row["domicilio"].ToString(),
                        num_domicilio = Convert.ToInt32(row["num_domicilio"]),
                        carga_hs = Convert.ToDecimal(row["carga_hs"]),
                        email = row["email"].ToString(),
                        telefono = row["telefono"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la capa lógica al mapear empleados: {ex.Message}");
                return new List<cls_EmpleadoDTO>();
            }
            return listaEmpleados;
        }

        public bool ActualizarEmpleado(cls_EmpleadoDTO empleado)
        {
            try
            {
                return _empleadosQ.ActualizarEmpleado(empleado);
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