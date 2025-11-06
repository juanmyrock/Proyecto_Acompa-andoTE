using System;

namespace CapaDTO
{
    public class cls_TramiteResumenDTO
    {
        public int id_tp { get; set; } // El ID único del trámite
        public string titulo_inicial { get; set; }
        public string estado_actual { get; set; }
        public DateTime fecha_creacion { get; set; }

        // Propiedad formateada para mostrar en el ListBox
        public string DescripcionLista
        {
            get { return $"{fecha_creacion:dd/MM/yy} - {titulo_inicial}: ({estado_actual})"; }
        }
    }
}