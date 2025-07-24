using System;
using System.Collections.Generic;
using CapaDTO;
using System.Text;
using System.Threading.Tasks;

namespace CapaDTO
{
        public class cls_LocalidadDTO
        {
            public int id_localidad { get; set; }
            public string nombre_localidad { get; set; }
        }

    public class cls_SexoDTO
        {
            public int id_sexo { get; set; }
            public string descripcion { get; set; }
        }

        public class cls_TipoDocumentoDTO
        {
            public int id_tipo_documento { get; set; }
            public string descripcion { get; set; }
        }
        public class LlenarCombosResponseDTO
        {
            public List<cls_LocalidadDTO> Localidades { get; set; }
            public List<cls_SexoDTO> Sexos { get; set; }
            public List<cls_TipoDocumentoDTO> TiposDocumento { get; set; }
            public List<cls_RolDTO> Roles { get; set; }
        }

}
