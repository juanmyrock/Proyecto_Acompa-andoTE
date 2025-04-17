using System;
using CapaDatos.Query_Login;
using CapaDatos.Querys_Login;
using CapaSesion;
using CapaServicios;

namespace CapaLogicaNegocio.Logica_Login
{
    public class cls_CambiarPass
    {
        cls_ConectarUser VerificaPass = new cls_ConectarUser();


        private bool existe;
        public bool CambioPass(string usuario, string passVieja, string passNueva, string passNueva2)
        {

            existe = VerificaPass.ValidarUsuario(usuario, passVieja);
            if (existe)
            {
                if (passNueva == passNueva2)
                {
                    cls_CambiarPassQ MP = new cls_CambiarPassQ();
                    MP.ModificaPass(idUser: cls_UserCache.IdUsuario, pass: cls_Encriptacion.SHA256(passNueva));
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
