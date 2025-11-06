using System;

namespace CapaDTO.SistemaDTO
{
    public class cls_InformeATDTO
    {
        public int id_paciente { get; set; }
        public string id_informe_at { get; set; }
        public int id_acompanamiento { get; set; }
        public DateTime fecha_periodo { get; set; }
        public int id_usuario_creador { get; set; }
        public DateTime fecha_creacion { get; set; }
        public string prestador { get; set; }
        public string prestacion { get; set; }
        public string cuerpo { get; set; }
        public string ruta { get; set; }
        public int dni_paciente {  get; set; }
        public string nombre_paciente { get; set; }
        public string apellido_paciente { get; set; }
        public decimal cargahoraria_at {  get; set; }


    }
}