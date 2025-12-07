using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace CapaDatos
{
    public abstract class cls_ConexionBD
    {
        private static string _cadenaConexionCacheada = null;
        private const string ARCHIVO_CONFIG = "conexion_server.cfg";
        private const string NOMBRE_BD = "ProyectoAT";

        public cls_ConexionBD()
        {
            if (_cadenaConexionCacheada == null)
            {
                _cadenaConexionCacheada = ObtenerCadenaDeConexion();
            }
        }

        protected SqlConnection GetConexion()
        {
            return new SqlConnection(_cadenaConexionCacheada);
        }

        private string ObtenerCadenaDeConexion()
        {
            string rutaBase = AppDomain.CurrentDomain.BaseDirectory;
            string rutaArchivo = Path.Combine(rutaBase, ARCHIVO_CONFIG);

            if (File.Exists(rutaArchivo))
            {
                try
                {
                    string cadenaGuardada = File.ReadAllText(rutaArchivo).Trim();
                    if (ProbarConexion(cadenaGuardada)) return cadenaGuardada;
                }
                catch { }
            }


            // no escanea la red
            string[] servidoresComunes = {
                @".\SQLEXPRESS",         
                ".",                       
                @"(localdb)\MSSQLLocalDB", 
                "localhost",
                @"localhost\SQLEXPRESS"
            };

            foreach (string servidor in servidoresComunes)
            {
                string cadenaPrueba = $"Server={servidor}; Database={NOMBRE_BD}; Integrated Security=True;";
                if (ProbarConexion(cadenaPrueba))
                {
                    GuardarConfiguracion(rutaArchivo, cadenaPrueba);
                    return cadenaPrueba;
                }
            }
            return $"Server=.\\SQLEXPRESS; Database={NOMBRE_BD}; Integrated Security=True;";
        }

        private bool ProbarConexion(string cadena)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cadena))
                {
                    // pongo timeout de 2 segs para que la prueba sea rapida
                    string cadenaTest = cadena + ";Connection Timeout=2";
                    con.ConnectionString = cadenaTest;
                    con.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private void GuardarConfiguracion(string ruta, string cadena)
        {
            try { File.WriteAllText(ruta, cadena); } catch { }
        }
    }
}