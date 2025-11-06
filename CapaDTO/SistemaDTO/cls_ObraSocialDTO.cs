using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDTO.SistemaDTO
{
    public class cls_ObraSocialDTO
    {
        public int id_obra_social {  get; set; }
        public string nombre_os {  get; set; }

        public int? codigo {  get; set; }
        public long? cuit {  get; set; }

        public string domicilio { get; set; }
        public int? num_domicilio { get; set; }
        public string telefono { get; set; }
        public bool? estado { get; set; }
        public DateTime? fecha_alta { get; set; }
        public DateTime? fecha_baja {  get; set; }

    }
}
