namespace CapaDTO
{
    public class ResultadoLoginDTO
    {
        public bool Exitoso { get; set; }

        public bool RequiereCambioContraseña { get; set; }
        public bool RequiereConfigurarPreguntas { get; set; }
    }
}