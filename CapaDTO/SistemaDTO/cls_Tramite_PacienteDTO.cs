using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDTO.SistemaDTO
{
    public class cls_Tramite_PacienteDTO
    {
        public int IdTramite { get; set; }
        public int IdPaciente { get; set; }
        public string Descripcion { get; set; } 
        public string EstadoActual { get; set; } 
        public string NombrePacienteCompleto { get; set; }
    }
}
