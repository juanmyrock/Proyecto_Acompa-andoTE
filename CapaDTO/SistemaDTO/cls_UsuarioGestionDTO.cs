namespace CapaDTO
{
    public class cls_UsuarioGestionDTO
    {
        public int IdUsuario { get; set; }
        public string Username { get; set; }
        public int? IdRol { get; set; }
        public string NombreRol { get; set; }
        public bool EsActivo { get; set; }
        public bool EstaBloqueado { get; set; }

        // datos del empleado para mostrar
        public string NombreCompletoEmpleado { get; set; }
        public string Email { get; set; }
    }



}