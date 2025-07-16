using System;

namespace CapaDTO
{
    public class cls_UsuarioDTO
    {
        public int IdUsuario { get; set; }
        public string Username { get; set; }
        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public DateTime? FechaBloqueo { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsRandomPass { get; set; }
        public bool? EsPrimerIngreso { get; set; }
        public DateTime? FechaUltimoIngreso { get; set; }
        public int? IntentosFallidos { get; set; }
        public int? IdRol { get; set; }

        // Datos del empleado asociados
        public string NombreEmpleado { get; set; }
        public string ApellidoEmpleado { get; set; }
        public string Email { get; set; }
    }
}
