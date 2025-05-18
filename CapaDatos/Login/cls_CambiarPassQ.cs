using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Login
{
    public class cls_CambiarPassQ : cls_EjecutarQ
    {
        public void ModificaPass(int idUser, string pass)
        {
            string sSql = "UPDATE Usuarios SET contraseña_actual = @password WHERE id_usuario = @idUser";
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@password", pass),
                new SqlParameter("@idUser", idUser)
            };

            try
            {
                ConsultaWrite(sSql, parametros);
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine("Error al actualizar la contraseña: " + ex.Message);
                throw;
            }
        }
    }
}
