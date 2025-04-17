using CapaDatos.Query_Login;
using CapaDatos.Querys_Login;


namespace CapaLogicaNegocio.Logica_Login
{
    public class cls_BloquearUser
    {
        public cls_BloquearUser(string usuario)
    {
        //cls_BloquearUserQ Bloquear = new cls_BloquearUserQ();
        Bloquear.BloquearUsuario(usuario);
    }
}
}
