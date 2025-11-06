using System.Data.SqlClient;

namespace CapaDatos
{
    public abstract class cls_ConexionBD
    {
        private readonly string conexion;
        public cls_ConexionBD()
        {
            conexion = @"Server=DESKTOP-BS1413A; Database=ProyectoAT; User Id=DESKTOP-BS1413A\sebas; Integrated Security=True;";
        }

        protected SqlConnection GetConexion() 
        {
            return new SqlConnection(conexion);
        }

    }
}
