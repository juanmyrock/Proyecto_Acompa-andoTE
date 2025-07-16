using System.Data.SqlClient;

namespace CapaDatos
{
    public abstract class cls_ConexionBD
    {
        private readonly string conexion;         //"conexion" solo es accesible dentro de esta clase que es donde se declara.
                                                  //Además una vez que se inicializa su valor no puede ser modificado,
                                                  //solo puede ser establecido adentro del constructor de la clase en este caso.
        public cls_ConexionBD()
        {
            conexion = @"Server=NTBK014\SQLEXPRESS; Database=ProyectoAT; User Id=NTBK014\Usuario; Integrated Security=True;"; // Si no usamos Integrated Security (por defecto de Windows)                                                                                                                                // y sí autenticación SQL, hay que incluir Password.
        }

        protected SqlConnection GetConexion()  //Property que devuelve la conexion
        {
            return new SqlConnection(conexion);  //Devuelve una nueva instancia de SqlConnection utilizando la cadena de conexión.
        }

    }
}
