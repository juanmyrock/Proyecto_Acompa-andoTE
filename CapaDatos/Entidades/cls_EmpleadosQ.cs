using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos.Entidades
{
    public class cls_EmpleadosQ : cls_EjecutarQ
    {
        // Propiedades del empleado
        public int Id_Empleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Id_Sexo { get; set; }
        public int Id_Tipodni { get; set; }
        public int Dni { get; set; }
        public DateTime Fecha_Nac { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }
        public int Id_Localidad { get; set; }
        public string Calle { get; set; }
        public int Numero_Calle { get; set; }
        public int Id_Cargo { get; set; }
        public bool Estado { get; set; }

        // Métodos CRUD
        public DataTable ObtenerEmpleados(string datos)
        {
            DataTable resultado = null;
            try
            {
                string sSQL;
                List<SqlParameter> listaParametros = new List<SqlParameter>();
                if (string.IsNullOrEmpty(datos))
                {
                    sSQL = "SELECT * FROM Empleados";
                }
                else
                {
                    sSQL = "SELECT * FROM Empleados WHERE nombre + apellido LIKE @datos";
                    listaParametros.Add(new SqlParameter("@datos", "%" + datos.Trim() + "%"));
                }
                resultado = ConsultaRead(sSQL, listaParametros);
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error de SQL: {ex.Message}");
                throw new Exception("Error al buscar empleados", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw new Exception("Error general al buscar empleados", ex);
            }
            return resultado;
        }

        public void AgregarEmp()
        {
            try
            {
                string sSQL = "INSERT INTO Empleados (nombre, apellido, id_sexo, id_tipodni, dni, fecha_nac, email, telefono, id_localidad, calle, numero_calle, id_cargo, estado) " +
                              "VALUES (@nombre, @apellido, @id_sexo, @id_tipodni, @dni, @fecha_nac, @correo, @telefono, @id_localidad, @calle, @numero_calle, @id_cargo, @estado)";
                List<SqlParameter> listaParametros = new List<SqlParameter>
                {
                    new SqlParameter("@nombre", Nombre),
                    new SqlParameter("@apellido", Apellido),
                    new SqlParameter("@id_sexo", Id_Sexo),
                    new SqlParameter("@id_tipodni", Id_Tipodni),
                    new SqlParameter("@dni", Dni),
                    new SqlParameter("@fecha_nac", Fecha_Nac),
                    new SqlParameter("@correo", Email),
                    new SqlParameter("@telefono", Telefono),
                    new SqlParameter("@id_localidad", Id_Localidad),
                    new SqlParameter("@calle", Calle),
                    new SqlParameter("@numero_calle", Numero_Calle),
                    new SqlParameter("@id_cargo", Id_Cargo),
                    new SqlParameter("@estado", Estado)
                };
                ConsultaWrite(sSQL, listaParametros);
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error de SQL: {ex.Message}");
                throw new Exception("Error al agregar empleado", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw new Exception("Error general al agregar empleado", ex);
            }
        }
        public void ModificarEmp()
        {
            try
            {
                string sSQL = "UPDATE Empleados SET nombre = @nombre, apellido = @apellido, " +
                              "id_sexo = @id_sexo, id_tipodni = @id_tipodni, dni = @dni, " +
                              "fecha_nac = @fecha_nac, email = @correo, telefono = @telefono, id_localidad = @id_localidad, " +
                              "calle = @calle, numero_calle = @numero_calle, id_cargo = @id_cargo, estado = @estado " +
                              "WHERE id_empleado = @id_empleado";

                List<SqlParameter> listaParametros = new List<SqlParameter>
                {
                    new SqlParameter("@id_empleado", Id_Empleado),
                    new SqlParameter("@nombre", Nombre),
                    new SqlParameter("@apellido", Apellido),
                    new SqlParameter("@id_sexo", Id_Sexo),
                    new SqlParameter("@id_tipodni", Id_Tipodni),
                    new SqlParameter("@dni", Dni),
                    new SqlParameter("@fecha_nac", Fecha_Nac),
                    new SqlParameter("@correo", Email),
                    new SqlParameter("@telefono", Telefono),
                    new SqlParameter("@id_localidad", Id_Localidad),
                    new SqlParameter("@calle", Calle),
                    new SqlParameter("@numero_calle", Numero_Calle),
                    new SqlParameter("@id_cargo", Id_Cargo),
                    new SqlParameter("@estado", Estado)
                };

                    ConsultaWrite(sSQL, listaParametros);
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error de SQL: {ex.Message}");
                throw new Exception("Error al modificar empleado", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw new Exception("Error general al modificar empleado", ex);
            }
        }

        public void EliminarEmp(int idEmpleado)
        {
            try
            {
                string sSQL = "DELETE FROM Empleados WHERE id_empleado = @id_empleado";

                List<SqlParameter> listaParametros = new List<SqlParameter>
        {
            new SqlParameter("@id_empleado", idEmpleado)
        };

                ConsultaWrite(sSQL, listaParametros);
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error de SQL: {ex.Message}");
                throw new Exception("Error al eliminar empleado", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw new Exception("Error general al eliminar empleado", ex);
            }
        }


    }
}