using System;

namespace CapaDTO.SistemaDTO
{
    public class cls_HistorialDTO
    {
        public DateTime fecha_hora { get; set; }
        public string nombre_usuario { get; set; }
        public string comentario { get; set; }
        public bool es_comentario { get; set; } 
        public string descripcion_tipo_tramite { get; set; }
    }
}