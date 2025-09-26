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

        public DataTable ConsultaReadSP(string consultaSql, List<SqlParameter> parametros = null)
        {
            DataTable datosTabla = new DataTable();
            try
            {
                using (SqlConnection conexion = GetConexion())
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(consultaSql, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
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

        public void ConsultaWriteSP(string nombreStoredProcedure, List<SqlParameter> parametros = null)
        {
            try
            {
                using (SqlConnection conexion = GetConexion())
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(nombreStoredProcedure, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        if (parametros != null)
                        {
                            comando.Parameters.AddRange(parametros.ToArray());
                        }

                        comando.ExecuteNonQuery(); // Ejecuta el Stored Procedure
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

        public int ConsultaCUD(string sql, List<SqlParameter> parametros)
        {
            int filasAfectadas = 0;
            try
            {
                using (SqlConnection connection = GetConexion())
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        if (parametros != null)
                        {
                            // Agrega los parámetros a la colección de parámetros del comando
                            command.Parameters.AddRange(parametros.ToArray());
                        }

                        connection.Open(); // Abre la conexión a la base de datos
                        filasAfectadas = command.ExecuteNonQuery(); // Ejecuta la consulta y devuelve el número de filas afectadas
                    }
                }
                return filasAfectadas;
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error de SQL: {ex.Message}");
                return -1; // Indica un error en la ejecución
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return -1; // Indica un error en la ejecución
            }
        }
    }
}
