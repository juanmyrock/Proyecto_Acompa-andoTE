using System;
using System.Collections.Generic;
using System.Linq;
using CapaDatos;
using CapaDTO;
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

        // Valida una contraseña contra las políticas de seguridad actuales.
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
            // 1. Obtener las políticas actuales
            var politica = ObtenerPoliticaContraseña();

            // 2. Validar complejidad
            var erroresComplejidad = ValidarComplejidad(nuevaContraseña, politica);
            if (erroresComplejidad.Any())
            {
                throw new Exception(string.Join("\n", erroresComplejidad));
            }

            // 3. Validar historial de contraseñas
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

            // 4. Si todo es válido, procedemos a guardar
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
            // 1. Generar una contraseña aleatoria.
            string contraseñaTemporal = new Random().Next(1000000, 9999999).ToString();

            // 2. Hashear la contraseña temporal.
            string hashTemporal = CapaUtilidades.cls_SeguridadPass.GenerarHashSHA256(contraseñaTemporal);

            // 3. Desactivar la contraseña activa anterior del usuario.
            _contraseñasDatos.DesactivarContraseñasAnteriores(idUsuario);

            // 4. Insertar la nueva contraseña temporal como un NUEVO registro activo.
            _contraseñasDatos.InsertarNuevaContraseña(new cls_ContraseñaDTO
            {
                IdUsuario = idUsuario,
                HashContraseña = hashTemporal,
                EsActiva = true,
                FechaExpiracion = null
            });

            // 5. Marcar al usuario para que deba cambiar la contraseña en el próximo login.
            _userDatos.MarcarContraseñaComoRandom(idUsuario);

            // 6. Enviar el correo electrónico.
            var servicioEmail = new cls_ServicioEmail();
            servicioEmail.EnviarContraseñaTemporal(emailDestino, nombreUsuario, contraseñaTemporal);
        }



    }
}
