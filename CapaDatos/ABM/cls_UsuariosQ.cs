using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos.Entidades
{
    public class cls_UsuariosQ : cls_EjecutarQ
    {
        // Propiedades del usuario
        public int Id_Usuario { get; set; }
        public int Id_Empleado { get; set; }
        public DateTime Fecha_Alta { get; set; }
        public DateTime Fecha_Baja { get; set; }
        public bool Estado { get; set; }
        public string Usuario { get; set; }
        public string Contraseña_Actual { get; set; }
        public DateTime Fecha_Ult_Ingreso { get; set; }
        public string Contraseña_Aleatoria { get; set; }
        public int Id_Pregunta { get; set; }

        // Métodos CRUD
        public DataTable ReadUser(string datos)
        {
            DataTable resultado = null;
            try
            {
                string sSQL;
                List<SqlParameter> listaParametros = new List<SqlParameter>();
                if (string.IsNullOrEmpty(datos))
                {
                    sSQL = "SELECT * FROM Usuarios";
                }
                else
                {
                    sSQL = "SELECT * FROM Usuarios WHERE usuario LIKE @datos";
                    listaParametros.Add(new SqlParameter("@datos", "%" + datos.Trim() + "%"));
                }
                resultado = ConsultaRead(sSQL, listaParametros);
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error de SQL: {ex.Message}");
                throw new Exception("Error al buscar usuarios", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw new Exception("Error general al buscar usuarios", ex);
            }
            return resultado;
        }

        public void CreateUser()
        {
            try
            {
                string sSQL = "INSERT INTO Usuarios (id_empleado, fecha_alta, fecha_baja, estado, usuario, contraseña_actual, fecha_ult_ingreso, contraseña_aleatoria, id_pregunta) " +
                              "VALUES (@id_empleado, @fecha_alta, @fecha_baja, @estado, @usuario, @contraseña_actual, @fecha_ult_ingreso, @contraseña_aleatoria, @id_pregunta)";
                List<SqlParameter> listaParametros = new List<SqlParameter>
                {
                    new SqlParameter("@id_empleado", Id_Empleado),
                    new SqlParameter("@fecha_alta", Fecha_Alta),
                    new SqlParameter("@fecha_baja", Fecha_Baja),
                    new SqlParameter("@estado", Estado),
                    new SqlParameter("@usuario", Usuario),
                    new SqlParameter("@contraseña_actual", Contraseña_Actual),
                    new SqlParameter("@fecha_ult_ingreso", Fecha_Ult_Ingreso),
                    new SqlParameter("@contraseña_aleatoria", Contraseña_Aleatoria),
                    new SqlParameter("@id_pregunta", Id_Pregunta)
                };
                ConsultaWrite(sSQL, listaParametros);
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error de SQL: {ex.Message}");
                throw new Exception("Error al agregar usuario", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw new Exception("Error general al agregar usuario", ex);
            }
        }

        public void UpdateUser()
        {
            try
            {
                string sSQL = "UPDATE Usuarios SET id_empleado = @id_empleado, fecha_alta = @fecha_alta, fecha_baja = @fecha_baja, " +
                              "estado = @estado, usuario = @usuario, contraseña_actual = @contraseña_actual, " +
                              "fecha_ult_ingreso = @fecha_ult_ingreso, contraseña_aleatoria = @contraseña_aleatoria, id_pregunta = @id_pregunta " +
                              "WHERE id_usuario = @id_usuario";

                List<SqlParameter> listaParametros = new List<SqlParameter>
                {
                    new SqlParameter("@id_usuario", Id_Usuario),
                    new SqlParameter("@id_empleado", Id_Empleado),
                    new SqlParameter("@fecha_alta", Fecha_Alta),
                    new SqlParameter("@fecha_baja", Fecha_Baja),
                    new SqlParameter("@estado", Estado),
                    new SqlParameter("@usuario", Usuario),
                    new SqlParameter("@contraseña_actual", Contraseña_Actual),
                    new SqlParameter("@fecha_ult_ingreso", Fecha_Ult_Ingreso),
                    new SqlParameter("@contraseña_aleatoria", Contraseña_Aleatoria),
                    new SqlParameter("@id_pregunta", Id_Pregunta)
                };

                ConsultaWrite(sSQL, listaParametros);
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error de SQL: {ex.Message}");
                throw new Exception("Error al modificar usuario", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw new Exception("Error general al modificar usuario", ex);
            }
        }

        public void DeleteUser(int idUsuario)
        {
            try
            {
                string sSQL = "DELETE FROM Usuarios WHERE id_usuario = @id_usuario";

                List<SqlParameter> listaParametros = new List<SqlParameter>
                {
                    new SqlParameter("@id_usuario", idUsuario)
                };

                ConsultaWrite(sSQL, listaParametros);
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error de SQL: {ex.Message}");
                throw new Exception("Error al eliminar usuario", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw new Exception("Error general al eliminar usuario", ex);
            }
        }
    }
}
