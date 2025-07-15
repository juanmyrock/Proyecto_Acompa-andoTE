using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDTO.SistemaDTO
{
    public class cls_EmpleadoDTO
    {
        public int id_empleado { get; set; }
        public string puesto { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int id_sexo { get; set; }
        public int id_tipo_dni { get; set; }
        public int dni { get; set; }
        public DateTime fecha_nac { get; set; }
        public int id_localidad { get; set; }
        public string domicilio { get; set; }
        public int num_domicilio { get; set; }
        public decimal carga_hs { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }

    }
}
