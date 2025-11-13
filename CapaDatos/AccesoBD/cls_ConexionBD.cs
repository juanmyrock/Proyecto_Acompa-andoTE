using System.Data.SqlClient;

namespace CapaDatos
{
    public abstract class cls_ConexionBD
    {
        private readonly string conexion;
        public cls_ConexionBD()
        {
            conexion = @"Server=NTBK014\SQLEXPRESS; Database=ProyectoAT; User Id=NTBK014\Usuario; Integrated Security=True;";
        }

        protected SqlConnection GetConexion() 
        {
            return new SqlConnection(conexion);
        }

    }
}
