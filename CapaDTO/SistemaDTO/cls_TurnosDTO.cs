using System;

namespace CapaDTO.SistemaDTO
{
    public class cls_TurnosDTO
    {
        public int id_turno { get; set; }
        public int id_paciente { get; set; }
        public int id_profesional { get; set; }
        public DateTime fecha_hora_inicio { get; set; }
        public DateTime fecha_hora_fin { get; set; }
        public int id_estado_turno { get; set; }
        public int id_usuario_creador { get; set; }
        public DateTime fecha_creacion { get; set; }
        public string observaciones { get; set; } // Ya la tienes
        public string nombre_paciente { get; set; } // Agregar esta propiedad
    }
}