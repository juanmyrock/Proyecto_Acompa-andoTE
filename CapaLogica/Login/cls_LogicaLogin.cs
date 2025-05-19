using System;
using CapaDatos.Login;
using CapaSesion.Login;
using CapaServicios;

namespace CapaLogica.Login
{
    public class cls_LogicaLogin
    {
        public bool LoginUser(string user, string pass)
        {
            try
            {
                cls_ConectarUserQ conexionUsuario = new cls_ConectarUserQ();
                cls_PermisosQ permisos = new cls_PermisosQ();
                

                if (conexionUsuario.ValidarUsuario(user, pass)) //(user, cls_Encriptacion.SHA256(pass)))
                {
                    permisos.ObtenerPermisos(cls_SesionUsuario.IdUsuario);
                    return conexionUsuario.CargarUsuario(user, pass); //(user, cls_Encriptacion.SHA256(pass));
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false; // O retorna false para indicar que hubo un problema en el proceso de login
            }
        }
    }
}
