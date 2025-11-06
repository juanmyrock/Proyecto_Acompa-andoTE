using System;

namespace CapaDTO.SistemaDTO
{
    public class cls_PacienteDTO
    {
        public int id_paciente { get; set; }
        public int? id_os { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public int dni_titular { get; set; }

        public Int64 num_afiliado { get; set; }

        public int? id_tipo_dni { get; set; }

        public int dni_paciente { get; set; }
        public DateTime? fecha_nac { get; set; }

        public int? id_sexo { get; set; }
        public string cud {  get; set; }

        public string diagnostico { get; set; }

        public int id_localidad { get; set; }

        public string domicilio { get; set; }

        public int num_domicilio { get; set; }

        public decimal cargahoraria_at { get; set; }

        public int telefono { get; set; }
        public bool? esActivo { get; set; }
        public string email {  get; set; }

    }
}
