using CapaDatos.Login;


namespace CapaLogica.Login
{
    public class cls_BloquearUser
    {
        public cls_BloquearUser(string usuario)
    {
        cls_BloquearUserQ Bloquear = new cls_BloquearUserQ();
        Bloquear.BloquearUsuario(usuario);
    }
}
}
