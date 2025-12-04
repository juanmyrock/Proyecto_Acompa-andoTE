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
        private const string NOMBRE_BD = "ProyectoAT"; // Tu base de datos

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

            // 1. PRIMER INTENTO: Leer del archivo (Si ya funcionó antes)
            if (File.Exists(rutaArchivo))
            {
                try
                {
                    string cadenaGuardada = File.ReadAllText(rutaArchivo).Trim();
                    if (ProbarConexion(cadenaGuardada)) return cadenaGuardada;
                }
                catch { /* Si el archivo está corrupto, seguimos */ }
            }

            // 2. SEGUNDO INTENTO: Probar lista de servidores comunes (Fuerza bruta local)
            // Esto es instantáneo, no escanea la red.
            string[] servidoresComunes = {
                @".\SQLEXPRESS",           // El más común para clientes
                ".",                       // Local default
                @"(localdb)\MSSQLLocalDB", // Visual Studio local
                "localhost",
                @"localhost\SQLEXPRESS"
            };

            foreach (string servidor in servidoresComunes)
            {
                string cadenaPrueba = $"Server={servidor}; Database={NOMBRE_BD}; Integrated Security=True;";
                if (ProbarConexion(cadenaPrueba))
                {
                    // ¡Encontrado! Lo guardamos para que la próxima sea directo.
                    GuardarConfiguracion(rutaArchivo, cadenaPrueba);
                    return cadenaPrueba;
                }
            }

            // 3. TERCER INTENTO (EL PLAN Z): Si nada funcionó, pedimos ayuda.
            // Si el servidor tiene un nombre raro (ej: "PC-JUAN\VENTAS"), no lo adivinamos.
            // Devolvemos un error o una cadena vacía para que la app la maneje.

            // Opción A: Tirar error y pedir que editen el archivo manual
            // throw new Exception($"No se encontró el servidor SQL. Por favor, cree el archivo '{ARCHIVO_CONFIG}' con la cadena de conexión correcta.");

            // Opción B (Mejor para desarrollo): Retornar una por defecto y que falle luego
            return $"Server=.\\SQLEXPRESS; Database={NOMBRE_BD}; Integrated Security=True;";
        }

        private bool ProbarConexion(string cadena)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cadena))
                {
                    // Timeout corto (2 seg) para que la prueba sea rápida
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