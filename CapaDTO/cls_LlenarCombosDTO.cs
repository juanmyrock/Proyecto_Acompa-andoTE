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

    public class cls_ObraSocialDTO
    {
        public int id_obra_social { get; set; }
        public string descripcion { get; set; }
    }

    public class cls_AcompañantesDTO
    {
        public int id_profesional {  get; set; }
        public string NomApe { get; set; }
        
    }

    public class cls_TramitesDTO
    {
        public int id_tramite { get; set; }
        public string descripcion { get; set; }
    }
    public class cls_EspecialidadesDTO
    {
        public int id_especialidad { get; set; }
        public string especialidad { get; set; }
    }
    public class AmbitoDTO
    {
        public int id_ambito { get; set; }
        public string descripcion { get; set; }
    }
    public class ProfesionalSimpleDTO
    {
        public int id_profesional { get; set; }
        public string ApeNom { get; set; }
    }
    public class cls_ProvinciasDTO
    {
        public int id { get; set; }
        public string provincia { get; set; }
    }
    public class JornadaATDTO
    {
        public int id_jornada { get; set; }
        public string descripcion { get; set; }
    }

    public class LlenarCombosResponseDTO
    {
        public List<cls_LocalidadDTO> Localidades { get; set; }
        public List<cls_SexoDTO> Sexos { get; set; }
        public List<cls_TipoDocumentoDTO> TiposDocumento { get; set; }
        public List<cls_RolDTO> Roles { get; set; }
        public List<cls_AcompañantesDTO> Acompañantes { get; set; }
        public List<cls_ObraSocialDTO> ObraSocial { get; set; }

        public List<cls_TramitesDTO> Tramites { get; set; }

        public List<cls_EspecialidadesDTO> Especialidades { get; set; }
        public List<cls_ProvinciasDTO> Provincias { get; set; }

    }


}
