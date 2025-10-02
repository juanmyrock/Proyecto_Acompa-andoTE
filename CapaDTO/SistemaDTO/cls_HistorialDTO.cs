using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDTO.SistemaDTO
{
    public class cls_HistorialDTO
    {
        public DateTime FechaHora { get; set; }
        public string Usuario { get; set; } 
        public string Comentario { get; set; } 
        public bool EsCambioDeEstado { get; set; }
        public string NuevoEstado { get; set; } 
    }
}
