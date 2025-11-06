using System.Collections.Generic;
namespace CapaDTO
{
    public class AcompanamientoDTO
    {
        public int id_acompanamiento { get; set; }
        public int id_paciente { get; set; }
        public int id_profesional { get; set; }
        public int id_ambito { get; set; }
        public int id_usuario_creador { get; set; }
        public int id_jornada { get; set; } // "Media Jornada"
        public int id_estado_acompanamiento { get; set; }

        // Esta lista contendrá las filas de la grilla
        public List<AcompanamientoHorarioDTO> horarios { get; set; }
    }
}