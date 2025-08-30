using System.Data.SqlClient;

namespace CapaDatos
{
    public abstract class cls_ConexionBD
    {
        private readonly string conexion;         
        public cls_ConexionBD()
        {
            conexion = @"Server=SEBASTIANGONFLO; Database=ProyectoAT; User Id=SEBASTIANGONFLO\sebas; Integrated Security=True;";
        }

        protected SqlConnection GetConexion() 
        {
            return new SqlConnection(conexion);
        }

    }
}
