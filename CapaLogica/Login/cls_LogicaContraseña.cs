using System;
using System.Collections.Generic;
using System.Linq;
using CapaDatos; // Necesitamos acceso a las clases Q
using CapaDTO;
using CapaUtilidades;

namespace CapaLogica.Login
{
    public class cls_LogicaContraseña
    {
        private readonly cls_ContraseñasQ _contraseñasDatos = new cls_ContraseñasQ();
        private readonly cls_ParamContraseñaQ _paramDatos = new cls_ParamContraseñaQ();
        private readonly cls_ConectarUserQ _userDatos = new cls_ConectarUserQ();

        // Obtiene las políticas de contraseña actuales desde la base de datos.
        public cls_ParamContraseñaDTO ObtenerPoliticaContraseña()
        {
            var politica = _paramDatos.ObtenerParametro();
            if (politica == null)
            {
                // Si no hay políticas en la BD, devuelve un objeto por defecto para no romper la aplicación.
                throw new Exception("No se encontró la configuración de políticas de contraseña.");
            }
            return politica;
        }

        // Valida una contraseña contra las políticas de seguridad actuales.
        // <returns>Una lista de mensajes de error. Si la lista está vacía, la contraseña es válida.</returns>
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

        // Establece una nueva contraseña para un usuario, realizando todas las validaciones.
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
            // 1. Generar una contraseña aleatoria simple.
            string contraseñaTemporal = new Random().Next(10000000, 99999999).ToString(); // Contraseña de 8 dígitos

            // 2. Hashear la contraseña temporal.
            string hashTemporal = CapaUtilidades.cls_SeguridadPass.GenerarHashSHA256(contraseñaTemporal);

            // 3. Actualizar la contraseña activa en la BD con el nuevo hash.
            // Esto NO añade al historial, solo reemplaza la activa.
            _contraseñasDatos.ActualizarContraseñaActiva(idUsuario, hashTemporal);

            // 4. Marcar al usuario para que deba cambiar la contraseña.
            _userDatos.MarcarContraseñaComoRandom(idUsuario);

            // 5. Enviar el correo electrónico con la contraseña en texto plano.
            var servicioEmail = new cls_ServicioEmail();
            servicioEmail.EnviarContraseñaTemporal(emailDestino, nombreUsuario, contraseñaTemporal);
        }



    }
}
