namespace CapaDTO
{
    public class cls_ParamContraseñaDTO
    {
        public int IdParametro { get; set; }
        public int? LongitudMinima { get; set; }
        public bool? RequiereMayuscula { get; set; }
        public bool? RequiereMinuscula { get; set; }
        public bool? RequiereNumero { get; set; }
        public bool? RequiereCaracterEspecial { get; set; }
        public int? CantidadPreguntasSeguridad { get; set; }
        public int? DiasValidezPassword { get; set; }
        public int? Cantidad_Intentos { get; set; }
    }
}
