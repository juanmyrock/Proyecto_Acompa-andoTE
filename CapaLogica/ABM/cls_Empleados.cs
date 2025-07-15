using System;
using System.Collections.Generic;
using System.Data; // Puede que sea necesario si cls_EmpleadosQ maneja DataTables o DataReaders
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDTO.SistemaDTO; // Referencia a tu DTO
using CapaDatos; // Asumiendo que tu CapaDatos se llama CapaDatos y contiene cls_EmpleadosQ

namespace CapaLogica.SistemaLogica
{
    public class cls_Empleado
    {
        // Instancia de la clase de la Capa de Datos para interactuar con la DB
        private cls_EmpleadosQ _empleadosQ;

        public cls_Empleado()
        {
            _empleadosQ = new cls_EmpleadosQ(); // Inicializa la instancia de tu clase de acceso a datos
        }

        /// <summary>
        /// Inserta un nuevo empleado en la base de datos.
        /// </summary>
        /// <param name="empleado">Objeto cls_EmpleadoDTO con los datos del empleado a insertar.</param>
        /// <returns>True si la inserción fue exitosa, false en caso contrario.</returns>
        public bool InsertarEmpleado(cls_EmpleadoDTO empleado)
        {
            try
            {
                // *** Aquí puedes añadir validaciones de negocio ***
                // Ejemplo:
                // if (string.IsNullOrEmpty(empleado.nombre) || string.IsNullOrEmpty(empleado.apellido))
                // {
                //     throw new ArgumentException("El nombre y apellido del empleado son obligatorios.");
                // }
                // if (empleado.dni <= 0)
                // {
                //     throw new ArgumentException("El DNI debe ser un número válido.");
                // }
                // Puedes llamar a un método en cls_EmpleadosQ para verificar si el DNI ya existe si es necesario:
                // if (_empleadosQ.ExisteDNI(empleado.dni))
                // {
                //     throw new InvalidOperationException("Ya existe un empleado con este DNI.");
                // }


                // Llama al método de la capa de datos para realizar la inserción
                return _empleadosQ.InsertarEmpleado(empleado);
            }
            catch (Exception ex)
            {
                // Manejo de errores: loggear la excepción, mostrar un mensaje, etc.
                Console.WriteLine($"Error en la capa lógica al insertar empleado: {ex.Message}");
                // Podrías lanzar una excepción personalizada aquí si quieres que la capa superior la maneje
                // throw new ApplicationException("No se pudo registrar el empleado.", ex);
                return false;
            }
        }

        /// <summary>
        /// Obtiene una lista de todos los empleados.
        /// </summary>
        /// <returns>Una lista de objetos cls_EmpleadoDTO.</returns>
        public List<cls_EmpleadoDTO> ObtenerEmpleados()
        {
            List<cls_EmpleadoDTO> listaEmpleados = new List<cls_EmpleadoDTO>();
            try
            {
                DataTable dtEmpleados = _empleadosQ.ObtenerEmpleados(); // Obtiene el DataTable desde CapaDatos

                // Itera sobre las filas del DataTable y mapea a DTOs
                foreach (DataRow row in dtEmpleados.Rows)
                {
                    listaEmpleados.Add(new cls_EmpleadoDTO
                    {
                        // Asegúrate de que los nombres de las columnas ("...") coincidan EXACTAMENTE con las columnas de tu DB
                        id_empleado = Convert.ToInt32(row["id_empleado"]),
                        puesto = row["puesto"].ToString(),
                        nombre = row["nombre"].ToString(),
                        apellido = row["apellido"].ToString(),
                        id_sexo = Convert.ToInt32(row["id_sexo"]),
                        id_tipo_dni = Convert.ToInt32(row["id_tipo_dni"]), // <<--- ¡MUY IMPORTANTE! VERIFICA ESTE NOMBRE
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
                // Puedes añadir un MessageBox.Show para depurar visualmente
                //MessageBox.Show("Error en la lógica al cargar empleados: " + ex.Message, "Error Lógica", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Si ocurre un error, devuelve una lista vacía para evitar que el DGV se caiga.
                return new List<cls_EmpleadoDTO>();
            }
            return listaEmpleados;
        }

        /// <summary>
        /// Actualiza los datos de un empleado existente.
        /// </summary>
        /// <param name="empleado">Objeto cls_EmpleadoDTO con los datos actualizados del empleado.</param>
        /// <returns>True si la actualización fue exitosa, false en caso contrario.</returns>
        public bool ActualizarEmpleado(cls_EmpleadoDTO empleado)
        {
            try
            {
                // *** Aquí puedes añadir validaciones de negocio ***
                // Ejemplo:
                // if (empleado.id_empleado == 0)
                // {
                //     throw new ArgumentException("El ID del empleado es necesario para actualizar.");
                // }
                // if (!_empleadosQ.ExisteEmpleado(empleado.id_empleado))
                // {
                //     throw new InvalidOperationException("El empleado a actualizar no existe.");
                // }


                // Llama al método de la capa de datos para realizar la actualización
                return _empleadosQ.ActualizarEmpleado(empleado);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la capa lógica al actualizar empleado: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Elimina un empleado de la base de datos por su ID.
        /// </summary>
        /// <param name="id_empleado">ID del empleado a eliminar.</param>
        /// <returns>True si la eliminación fue exitosa, false en caso contrario.</returns>
        public bool EliminarEmpleado(int id_empleado)
        {
            try
            {
                // *** Aquí puedes añadir validaciones de negocio ***
                // Ejemplo:
                // if (!_empleadosQ.PuedeEliminarEmpleado(id_empleado))
                // {
                //     throw new InvalidOperationException("No se puede eliminar el empleado porque tiene registros asociados.");
                // }

                // Llama al método de la capa de datos para realizar la eliminación
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