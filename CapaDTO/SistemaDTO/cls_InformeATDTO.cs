using System;

namespace CapaDTO.SistemaDTO
{
    public class cls_InformeATDTO
    {
        public int id_informe { get; set; }
        public int id_paciente { get; set; }
        public int id_profesional { get; set; }
        public DateTime fecha_informe { get; set; }
        public string periodo_mes { get; set; } // Ej: "2024-01" para Enero 2024
        public string contenido_informe { get; set; }
        public string observaciones { get; set; }
        public int horas_realizadas { get; set; }
        public string objetivos_cumplidos { get; set; }
        public string dificultades_encontradas { get; set; }
        public string propuestas_mejora { get; set; }
        public DateTime? fecha_creacion { get; set; }
        public DateTime? fecha_modificacion { get; set; }
        public int id_usuario_creador { get; set; }
        public string nombre_paciente { get; set; }
        public string apellido_paciente { get; set; }
        public string nombre_profesional { get; set; }
        public string apellido_profesional { get; set; }
        public string dni_paciente { get; set; }
        public string dni_profesional { get; set; }
    }
}