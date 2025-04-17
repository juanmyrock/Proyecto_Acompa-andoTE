using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class cls_EjecutarQ : cls_ConexionBD
    {
        public DataTable ConsultaRead(string consultaSql, List<SqlParameter> parametros = null) // Método para ejecutar una consulta SQL que devuelve datos (como SELECT)
        {
            DataTable datosTabla = new DataTable();   // DataTable para almacenar los resultados de la consulta
            try
            {
                using (SqlConnection conexion = GetConexion()) // La declaración using se usa para que los recursos se liberen después de usarse
                {
                    conexion.Open(); // Abre la conexión a la base de datos
                    using (SqlCommand comando = new SqlCommand(consultaSql, conexion))
                    {
                        if (parametros != null)
                        {
                            comando.Parameters.AddRange(parametros.ToArray());
                        }

                        using (SqlDataReader lector = comando.ExecuteReader()) // Ejecuta la consulta y obtiene un SqlDataReader
                        {
                            datosTabla.Load(lector); // Carga los datos del lector en el DataTable
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Manejo de errores específicos de SQL
                Console.WriteLine($"Error de SQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Manejo de errores generales
                Console.WriteLine($"Error: {ex.Message}");
            }
            return datosTabla; // Devuelve el DataTable con los resultados de la consulta
        }


        public void ConsultaWrite(string comandoSql, List<SqlParameter> parametros = null) // Método para ejecutar una consulta SQL que no devuelve datos (como INSERT, UPDATE, DELETE)
        {
            try
            {
                using (SqlConnection conexion = GetConexion())
                {
                    conexion.Open(); // Abre la conexión a la base de datos
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
                // Manejo de errores específicos de SQL
                Console.WriteLine($"Error de SQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Manejo de errores generales
                Console.WriteLine($"Error: {ex.Message}");
            }
        }




        //public DataTable ConsultaReadSP(string nombreProcedimiento, List<SqlParameter> parametros) //Método para ejecutar un procedimiento almacenado que devuelve datos
        //{
        //    DataTable datosTabla = new DataTable();

        //    try
        //    {
        //        using (SqlConnection conexion = GetConexion()) // La declaración using garantiza que los recursos se liberen después de usarse
        //        {
        //            conexion.Open(); // Abre la conexión a la base de datos

        //            using (SqlCommand comando = new SqlCommand(nombreProcedimiento, conexion))
        //            {
        //                comando.CommandType = CommandType.StoredProcedure; // Especifica que el comando es un procedimiento almacenado

        //                // Agregar parámetros al comando SQL
        //                if (parametros != null)
        //                {
        //                    comando.Parameters.AddRange(parametros.ToArray()); // Añade los parámetros al comando
        //                }

        //                using (SqlDataReader lector = comando.ExecuteReader()) // Ejecuta el comando y obtiene un SqlDataReader
        //                {
        //                    datosTabla.Load(lector); // Carga los datos del lector en el DataTable
        //                }
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        // Manejo de errores específicos de SQL
        //        Console.WriteLine($"Error de SQL: {ex.Message}");
        //    }
        //    catch (Exception ex)
        //    {
        //        // Manejo de errores generales
        //        Console.WriteLine($"Error: {ex.Message}");
        //    }
        //    return datosTabla; // Devuelve el DataTable con los resultados de la consulta
        //}


        //public void ConsultaWriteSP(string nombreProcedimiento, List<SqlParameter> parametros)  //Método para ejecutar un procedimiento almacenado que no devuelve datos
        //{
        //    try
        //    {
        //        using (SqlConnection conexion = GetConexion()) // La declaración using garantiza que los recursos se liberen después de usarse
        //        {
        //            conexion.Open(); // Abre la conexión a la base de datos

        //            using (SqlCommand comando = new SqlCommand(nombreProcedimiento, conexion))
        //            {
        //                comando.CommandType = CommandType.StoredProcedure; // Especifica que el comando es un procedimiento almacenado

        //                // Agregar parámetros al comando SQL
        //                if (parametros != null)
        //                {
        //                    comando.Parameters.AddRange(parametros.ToArray()); // Añade los parámetros al comando
        //                }

        //                comando.ExecuteNonQuery(); // Ejecuta el comando (sin devolver resultados)
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        // Manejo de errores específicos de SQL
        //        Console.WriteLine($"Error de SQL: {ex.Message}");
        //    }
        //    catch (Exception ex)
        //    {
        //        // Manejo de errores generales
        //        Console.WriteLine($"Error: {ex.Message}");
        //    }
        //}

    }
}
