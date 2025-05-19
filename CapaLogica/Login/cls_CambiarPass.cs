using System;
using CapaDatos.Login;
using CapaSesion;
using CapaServicios;

namespace CapaLogicaNegocio.Logica_Login
{
    public class cls_CambiarPass
    {
        cls_ConectarUserQ VerificaPass = new cls_ConectarUserQ();


        private bool existe;
        public bool CambioPass(string usuario, string passVieja, string passNueva, string passNueva2)
        {

            existe = VerificaPass.ValidarUsuario(usuario, passVieja);
            if (existe)
            {
                if (passNueva == passNueva2)
                {
                    cls_ContraseñaQ MP = new cls_ContraseñaQ();
                    //MP.ModificaPass(idUser: cls_SesionUsuario.IdUsuario, pass: cls_Encriptacion.SHA256(passNueva));
                }
                else
                {
                    throw new Exception("Las nuevas contraseñas ingresadas no coinciden.");
                }
            }
            else
            {
                throw new Exception("La contraseña ingresada es incorrecta.");
            }
            return true;
        }
    }
}
