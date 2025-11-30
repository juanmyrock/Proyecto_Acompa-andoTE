using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace CapaDatos
{
    public abstract class cls_ConexionBD
    {
        private readonly string conexion;

        public cls_ConexionBD()
        {
            conexion = ObtenerCadenaConexionAutomatica();
        }

        protected SqlConnection GetConexion()
        {
            return new SqlConnection(conexion);
        }

        private string ObtenerCadenaConexionAutomatica()
        {
            string[] servidoresProbables = {
                ".",                          
                "localhost",                 
                "(local)",                   
                @".\SQLEXPRESS",            
                "localhost\\SQLEXPRESS"      
            };

            string baseDeDatos = "ProyectoAT";

            foreach (string servidor in servidoresProbables)
            {
                string cadenaPrueba = $"Server={servidor}; Database={baseDeDatos}; Integrated Security=True;";

                if (ProbarConexion(cadenaPrueba))
                {
                    return cadenaPrueba;
                }
            }

            string instanciaEncontrada = BuscarInstanciasSQL();
            if (!string.IsNullOrEmpty(instanciaEncontrada))
            {
                return $"Server={instanciaEncontrada}; Database={baseDeDatos}; Integrated Security=True;";
            }

            throw new Exception("No se pudo encontrar una instancia de SQL Server disponible.");
        }

        private bool ProbarConexion(string cadenaConexion)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private string BuscarInstanciasSQL()
        {
            try
            {
                DataTable instancias = SqlDataSourceEnumerator.Instance.GetDataSources();

                foreach (DataRow row in instancias.Rows)
                {
                    string nombreServidor = row["ServerName"].ToString();
                    string nombreInstancia = row["InstanceName"].ToString();

                    if (string.IsNullOrEmpty(nombreInstancia))
                    {

                        return nombreServidor;
                    }
                    else
                    {
                        return $"{nombreServidor}\\{nombreInstancia}";
                    }
                }
            }
            catch
            {
            }

            return null;
        }
    }
}
