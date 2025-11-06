using System;

namespace CapaDTO.SistemaDTO
{
    public class cls_HistorialDTO
    {
        public DateTime fecha_hora { get; set; }
        public string nombre_usuario { get; set; } //quien modifica el historial
        public string comentario { get; set; }
        public bool es_comentario { get; set; } // true si es un comentario, false si es un cambio de estado
        public string descripcion_tipo_tramite { get; set; } // Ej: "Comentario", "Evento"
    }
}