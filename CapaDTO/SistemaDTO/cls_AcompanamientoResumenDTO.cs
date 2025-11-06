namespace CapaDTO
{
    public class AcompanamientoResumenDTO
    {
        public int id_acompanamiento { get; set; }
        public string descripcion_ambito { get; set; }
        public string nombre_profesional { get; set; }
        public string matricula_profesional { get; set; }

        // Propiedad calculada para mostrar en el ListBox
        public string InfoCompleta
        {
            get
            {
                return $"Ámbito: {descripcion_ambito} (AT: {nombre_profesional} - Mat: {matricula_profesional})";
            }
        }
    }
}