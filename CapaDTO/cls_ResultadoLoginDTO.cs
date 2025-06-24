namespace CapaDTO
{
    public class ResultadoLoginDTO
    {
        public bool Exitoso { get; set; }

        /// <summary>
        /// Indica si el usuario tiene una contraseña temporal y DEBE cambiarla.
        /// </summary>
        public bool RequiereCambioContraseña { get; set; }

        /// <summary>
        /// Indica si es el primer ingreso del usuario y DEBE configurar
        /// sus preguntas de seguridad.
        /// </summary>
        public bool RequiereConfigurarPreguntas { get; set; }
    }
}