namespace CapaDTO
{
    public class ResultadoLoginDTO
    {
        /// <summary>
        /// Indica si el proceso de login fue exitoso en general.
        /// </summary>
        public bool Exitoso { get; set; }

        /// <summary>
        /// Indica si el usuario debe ser redirigido a la pantalla de cambio
        /// de contraseña y configuración de preguntas de seguridad.
        /// </summary>
        public bool RequiereConfiguracionInicial { get; set; }
    }
}