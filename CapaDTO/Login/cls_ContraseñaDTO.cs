using System;

namespace CapaDTO
{
    public class cls_ContraseñaDTO
    {
        public int IdPassword { get; set; }
        public int IdUsuario { get; set; }
        public string HashContraseña { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaExpiracion { get; set; }
        public bool EsActiva { get; set; }
    }
}
