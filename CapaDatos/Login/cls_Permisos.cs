using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaSesion;


namespace CapaDatos.Query_Login
{
    public class cls_Permisos : cls_EjecutarQ
    {
        public bool ObtenerPermisos(int idUsuario)
        {
            // Define la consulta SQL
            string consultaSql =@"SELECT FR.id_rol, R.rol
                                  FROM Usuario_Familia UF
                                  INNER JOIN Familias F ON UF.id_familia = F.id_familia
                                  INNER JOIN Familia_Rol FR ON F.id_familia = FR.id_familia
                                  INNER JOIN Roles R ON FR.id_rol = R.id_rol
                                  WHERE UF.id_usuario = @idUsuario";

            // Define el parámetro para evitar inyección SQL
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@idUsuario", idUsuario)
            };

            try
            {
                // Ejecuta la consulta
                DataTable dt = ConsultaRead(consultaSql, parametros);

                // Verifica si se obtuvieron resultados
                if (dt.Rows.Count > 0)
                {
                    cls_UserCache.PermisosUsuario.Clear(); // Limpiar la lista antes de agregar nuevos permisos
                    foreach (DataRow row in dt.Rows)
                    {
                        cls_UserCache.PermisosUsuario.Add(row["rol"].ToString());
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario (por ejemplo, registrarla o lanzarla nuevamente)
                Console.WriteLine($"Error al obtener permisos: {ex.Message}");
                return false;
            }
        }
    }
}
