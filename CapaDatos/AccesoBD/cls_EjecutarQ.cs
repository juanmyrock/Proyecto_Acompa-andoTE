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
                            command.Parameters.AddRange(parametros.ToArray());

                            // DEBUG: Mostrar parámetros
                            Console.WriteLine("DEBUG - SQL: " + sql);
                            foreach (var param in parametros)
                            {
                                Console.WriteLine($"DEBUG - Parámetro: {param.ParameterName} = {param.Value}");
                            }
                        }

                        connection.Open();
                        filasAfectadas = command.ExecuteNonQuery();
                        Console.WriteLine($"DEBUG - Filas afectadas: {filasAfectadas}");
                    }
                }
                return filasAfectadas;
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"ERROR SQL: {ex.Message}");
                Console.WriteLine($"ERROR SQL Number: {ex.Number}");
                return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
                return -1;
            }
        }
    }
}
