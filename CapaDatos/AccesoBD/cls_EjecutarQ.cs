using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class cls_EjecutarQ : cls_ConexionBD
    {
        // Método para ejecutar una consulta SQL que devuelve datos (como SELECT)
        public DataTable ConsultaRead(string consultaSql, List<SqlParameter> parametros = null) 
        {
            DataTable datosTabla = new DataTable();
            try
            {
                using (SqlConnection conexion = GetConexion()) 
                {
                    conexion.Open(); 
                    using (SqlCommand comando = new SqlCommand(consultaSql, conexion))
                    {
                        if (parametros != null)
                        {
                            comando.Parameters.AddRange(parametros.ToArray());
                        }

                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            datosTabla.Load(lector);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error de SQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return datosTabla;
        }

        // Método para ejecutar una consulta SQL que no devuelve datos (como INSERT, UPDATE, DELETE)
        public void ConsultaWrite(string comandoSql, List<SqlParameter> parametros = null)
        {
            try
            {
                using (SqlConnection conexion = GetConexion())
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(comandoSql, conexion))
                    {
                        if (parametros != null)
                        {
                            comando.Parameters.AddRange(parametros.ToArray());
                        }

                        comando.ExecuteNonQuery(); // Ejecuta el comando SQL
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error de SQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
