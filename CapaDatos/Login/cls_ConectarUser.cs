using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using CapaSesion;

namespace CapaDatos.Query_Login
{
    public class cls_ConectarUser : cls_EjecutarQ
    {
        public bool ValidarUsuario(string user, string pass)
        {
            try
            {
                string sSql = @"SELECT 1 
                                FROM dbo.Usuarios 
                                WHERE usuario = @usuario AND contraseña_actual = @password";

                // Convertir array de SqlParameter a lista de SqlParameter
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@usuario", user),
                    new SqlParameter("@password", pass)
                };

                DataTable DT = ConsultaRead(sSql, parametros);

                return DT.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw; // Relanza la excepción para manejarla en el nivel superior
            }
        }

        public bool CargarUsuario(string user, string pass)
        {
            try
            {
                string sSql = @"SELECT u.id_usuario, 
                                       u.id_empleado, 
                                       u.usuario, 
                                       u.contraseña_actual, 
                                       u.estado AS EstadoUsuario,
                                       u.fecha_alta AS FechaAlta,
                                       e.id_familia AS IdFamilia,
                                       emp.nombre AS NombreEmpleado,
                                       emp.apellido AS ApellidoEmpleado
                                FROM dbo.Usuarios u
                                INNER JOIN dbo.Empleados emp ON u.id_empleado = emp.id_empleado
                                INNER JOIN dbo.Usuario_Familia e ON u.id_usuario = e.id_usuario
                                WHERE u.usuario = @usuario AND u.contraseña_actual = @password";

                // Convertir array de SqlParameter a lista de SqlParameter
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@usuario", user),
                    new SqlParameter("@password", pass)
                };

                DataTable DT = ConsultaRead(sSql, parametros);

                if (DT.Rows.Count > 0)
                {
                    DataRow row = DT.Rows[0];

                    cls_UserCache.IdUsuario = Convert.ToInt32(row["id_usuario"]);
                    cls_UserCache.IdEmpleado = Convert.ToInt32(row["id_empleado"]);
                    cls_UserCache.NombreUsuario = Convert.ToString(row["usuario"]);
                    cls_UserCache.PasswordUsuario = Convert.ToString(row["contraseña_actual"]);
                    cls_UserCache.EstadoUsuario = Convert.ToBoolean(row["EstadoUsuario"]);
                    cls_UserCache.FechaAlta = Convert.ToDateTime(row["FechaAlta"]);
                    cls_UserCache.IdFamilia = Convert.ToInt32(row["IdFamilia"]);
                    cls_UserCache.NombreEmpleado = Convert.ToString(row["NombreEmpleado"]);
                    cls_UserCache.ApellidoEmpleado = Convert.ToString(row["ApellidoEmpleado"]);

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw; // Relanza la excepción para manejarla en el nivel superior
            }
        }
    }
}
