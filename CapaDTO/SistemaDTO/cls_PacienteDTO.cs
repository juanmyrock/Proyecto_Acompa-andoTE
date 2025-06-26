using System;

namespace CapaDTO.SistemaDTO
{
    public class cls_PacienteDTO
    {
        public int IdPaciente { get; set; }
        public int? IdObraSocial { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? UltimaModificacion { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public DateTime? FechaBloqueo { get; set; }
        public bool? EsActivo { get; set; }
        public bool? EsRandomPass { get; set; }
        public bool? EsPrimerIngreso { get; set; }
        public DateTime? FechaUltimoIngreso { get; set; }
        public int? IntentosFallidos { get; set; }
        public int? IdRol { get; set; }

    }
}
