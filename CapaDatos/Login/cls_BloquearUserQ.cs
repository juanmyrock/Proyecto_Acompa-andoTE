using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Querys_Login
{
    public class cls_BloquearUserQ : cls_EjecutarQ
    {
        public void BloquearUsuario(string usuario)
        {
            string sSql = "UPDATE Usuarios SET estado = @estado WHERE usuario = @usuario";
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@estado", false),  // Asumiendo que "false" representa un usuario bloqueado
                new SqlParameter("@usuario", usuario)
            };

            try
            {
                ConsultaWrite(sSql, parametros);
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine("Error al bloquear el usuario: " + ex.Message);
                throw;
            }
        }
    }
}
