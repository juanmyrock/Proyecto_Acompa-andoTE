using System;

namespace CapaDTO
{
    public class AcompanamientoHorarioDTO
    {
        public int id_horario { get; set; } 
        public string dia_semana { get; set; }
        public TimeSpan hora_inicio { get; set; }
        public TimeSpan hora_fin { get; set; }

        // Propiedades calculadas para la grilla
        public string HoraInicioStr
        {
            get { return hora_inicio.ToString(@"hh\:mm"); }
        }
        public string HoraFinStr
        {
            get { return hora_fin.ToString(@"hh\:mm"); }
        }
    }
}