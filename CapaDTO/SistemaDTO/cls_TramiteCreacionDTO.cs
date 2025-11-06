namespace CapaDTO
{
    public class cls_TramiteCreacionDTO
    {
        public int id_paciente { get; set; }
        public string titulo_inicial { get; set; }
        public int id_estado_actual { get; set; } // El ID de "Abierto", "En espera", etc.
        public int id_usuario_creador { get; set; }
        public int id_tipo_tramite_historial { get; set; } // El ID de "Trámite Creado"
    }
}