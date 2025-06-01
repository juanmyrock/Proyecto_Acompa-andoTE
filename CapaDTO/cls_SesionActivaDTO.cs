using System;

namespace CapaDTO
{
    public class cls_SesionActivaDTO
    {
        public int UsuarioId { get; set; }
        public string Token { get; set; }
        public string IP { get; set; }
        public DateTime FechaInicio { get; set; }
    }

}
