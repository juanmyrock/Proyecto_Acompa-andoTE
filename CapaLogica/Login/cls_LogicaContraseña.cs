using System;
using System.Collections.Generic;
using System.Linq;
using CapaDatos;
using CapaDTO;
using CapaSesion;
using CapaUtilidades;

namespace CapaLogica.Login
{
    public class cls_LogicaContraseña
    {
        private readonly cls_ContraseñasQ _contraseñasDatos = new cls_ContraseñasQ();
        private readonly cls_ParamContraseñaQ _paramDatos = new cls_ParamContraseñaQ();
        private readonly cls_ConectarUserQ _userDatos = new cls_ConectarUserQ();

        public cls_ParamContraseñaDTO ObtenerPoliticaContraseña()
        {
            var politica = _paramDatos.ObtenerParametro();
            if (politica == null)
            {
                throw new Exception("No se encontró la configuración de políticas de contraseña.");
            }
            return politica;
        }

        public List<string> ValidarComplejidad(string contraseña, cls_ParamContraseñaDTO politica)
        {
            var errores = new List<string>();

            if (contraseña.Length < politica.LongitudMinima.GetValueOrDefault(0))
                errores.Add($"Debe tener al menos {politica.LongitudMinima} caracteres.");
            if (politica.RequiereMayuscula.GetValueOrDefault(false) && !contraseña.Any(char.IsUpper))
                errores.Add("Debe contener al menos una mayúscula.");
            if (politica.RequiereMinuscula.GetValueOrDefault(false) && !contraseña.Any(char.IsLower))
                errores.Add("Debe contener al menos una minúscula.");
            if (politica.RequiereNumero.GetValueOrDefault(false) && !contraseña.Any(char.IsDigit))
                errores.Add("Debe contener al menos un número.");
            if (politica.RequiereCaracterEspecial.GetValueOrDefault(false) && !contraseña.Any(ch => !char.IsLetterOrDigit(ch)))
                errores.Add("Debe contener al menos un carácter especial.");

            return errores;
        }

        public void EstablecerNuevaContraseña(int idUsuario, string nuevaContraseña)
        {
            var politica = ObtenerPoliticaContraseña();

            var erroresComplejidad = ValidarComplejidad(nuevaContraseña, politica);
            if (erroresComplejidad.Any())
            {
                throw new Exception(string.Join("\n", erroresComplejidad));
            }

            int cantidadHistorial = _paramDatos.ObtenerCantidadHistorial();
            if (cantidadHistorial > 0)
            {
                List<string> hashesAnteriores = _contraseñasDatos.ObtenerHashesAnteriores(idUsuario, cantidadHistorial);
                string nuevoHash = cls_SeguridadPass.GenerarHashSHA256(nuevaContraseña);

                if (hashesAnteriores.Contains(nuevoHash))
                {
                    throw new Exception("No puede reutilizar una de sus contraseñas recientes.");
                }
            }

            string hashFinal = cls_SeguridadPass.GenerarHashSHA256(nuevaContraseña);
            _contraseñasDatos.DesactivarContraseñasAnteriores(idUsuario);
            _contraseñasDatos.InsertarNuevaContraseña(new cls_ContraseñaDTO
            {
                IdUsuario = idUsuario,
                HashContraseña = hashFinal,
                EsActiva = true,
                FechaExpiracion = politica.DiasValidezPassword.HasValue
                    ? (DateTime?)DateTime.Now.AddDays(politica.DiasValidezPassword.Value)
                    : null
            });
        }

        public void GenerarYEnviarContraseñaTemporal(int idUsuario, string emailDestino, string nombreUsuario)
        {
            string contraseñaTemporal = new Random().Next(100000, 999999).ToString();

            string hashTemporal = CapaUtilidades.cls_SeguridadPass.GenerarHashSHA256(contraseñaTemporal);

            _contraseñasDatos.DesactivarContraseñasAnteriores(idUsuario);

            _contraseñasDatos.InsertarNuevaContraseña(new cls_ContraseñaDTO
            {
                IdUsuario = idUsuario,
                HashContraseña = hashTemporal,
                EsActiva = true,
                FechaExpiracion = null
            });

            _userDatos.MarcarContraseñaComoRandom(idUsuario);

            ArmarMail.Preparar(emailDestino,"Contraseña Temporal", contraseñaTemporal, nombreUsuario);
            
        }
        



    }
}
