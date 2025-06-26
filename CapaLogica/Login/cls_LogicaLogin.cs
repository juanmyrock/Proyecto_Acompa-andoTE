using System;
using System.Collections.Generic;
using System.Linq;
using CapaDatos;
using CapaDatos.Login;
using CapaDTO;
using CapaSesion.Login;
using CapaUtilidades;

namespace CapaLogica
{
    public class cls_LogicaLogin
    {
        private readonly cls_ConectarUserQ _userDatos;
        private readonly cls_ContraseñasQ _passDatos;
        private readonly cls_PermisosQ _permisos;
        private readonly cls_SesionActivaQ _sesiones;
        private readonly int intentosMaximosPermitidos;


        // Constructor
        public cls_LogicaLogin()
        {
            _userDatos = new cls_ConectarUserQ();
            _passDatos = new cls_ContraseñasQ();
            _permisos = new cls_PermisosQ();
            _sesiones = new cls_SesionActivaQ();
            intentosMaximosPermitidos = _userDatos.ObtenerCantidadIntentosMaximos();
        }

        // --- CAMBIO #1: El método ahora devuelve 'ResultadoLoginDTO' en lugar de 'bool' ---
        // --- y acepta la IP del cliente como parámetro para el registro de sesión ---
        public ResultadoLoginDTO ValidarLogin(cls_CredencialesLoginDTO credenciales, string ipCliente)
        {
            // 1. Verificar usuario
            cls_UsuarioDTO usuario = _userDatos.ObtenerUsuarioEmpleado(credenciales.Username);
            if (usuario == null)
                throw new Exception("Usuario no registrado");

            // 2. Verificar si está activo
            if (usuario.EsActivo != true || usuario.FechaBaja.HasValue)
                throw new Exception("Usuario inactivo o dado de baja");

            // 3. Verificar si está bloqueado
            if ((usuario.FechaBloqueo.HasValue) && usuario.EsActivo != true)
                throw new Exception("El usuario está bloqueado");

            // 4. Obtener contraseña activa
            cls_ContraseñaDTO contraseña = _passDatos.ObtenerContraseñaActiva(usuario.IdUsuario);
            if (contraseña == null)
                throw new Exception("No hay contraseña activa para este usuario");

            // 5. Validar hash
            if (!cls_SeguridadPass.VerificarHashSHA256(credenciales.Password, contraseña.HashContraseña))
            {
                _userDatos.RegistrarIntentoFallido(usuario.IdUsuario, intentosMaximosPermitidos);
                throw new Exception("Contraseña incorrecta");
            }
            bool necesitaCambioPass = usuario.EsRandomPass == true;
            bool necesitaPreguntas = usuario.EsPrimerIngreso == true;

            // 6. Validar expiración (solo si no se requiere un cambio forzado)
            if (!necesitaCambioPass && contraseña.FechaExpiracion.HasValue && contraseña.FechaExpiracion < DateTime.Now)
            {
                throw new Exception("Contraseña expirada. Debe cambiarla");
            }


            // 7. Verificar sesión única
            if (_sesiones.TieneSesionActiva(usuario.IdUsuario))
            {
                // Podrías mostrar un diálogo para forzar el cierre de la otra sesión
                throw new Exception("El usuario ya tiene una sesión activa en otro dispositivo");
            }

            // 8. Registrar nueva sesión en BD
            _sesiones.RegistrarSesion(new cls_SesionActivaDTO
            {
                UsuarioId = usuario.IdUsuario,
                IP = ipCliente,
                FechaInicio = DateTime.Now
            });

            // 9. Resetear intentos fallidos y registrar ingreso
            _userDatos.ResetearIntentosFallidos(usuario.IdUsuario);
            _userDatos.RegistrarIngreso(usuario.IdUsuario);

            // 10. Obtener permisos
            List<cls_PermisoDTO> permisos = _permisos.ObtenerPermisosEfectivosPorUsuario(usuario.IdUsuario);
            List<string> nombresPermisos = permisos.Select(p => p.NombrePermiso).ToList();

            // 11. Iniciar sesión local (Singleton)
            SesionUsuario.Instancia.IniciarSesion(usuario, nombresPermisos);

            // --- CAMBIO #3: Devolver el objeto DTO con el resultado completo ---
            return new ResultadoLoginDTO
            {
                Exitoso = true,
                RequiereCambioContraseña = necesitaCambioPass,
                RequiereConfigurarPreguntas = necesitaPreguntas
            };

        }

        /// <summary>
        /// Cierra la sesión activa, tanto en la base de datos como en la sesión local.
        /// </summary>
        public void CerrarSesion()
        {
            if (SesionUsuario.Instancia.EstaSesionIniciada)
            {
                try
                {
                    // Cerrar sesión en BD
                    _sesiones.CerrarSesion(SesionUsuario.Instancia.IdUsuario);

                    // Registrar en bitácora
                    //_userDatos.RegistrarSalida(SesionUsuario.Instancia.IdUsuario);
                }
                finally
                {
                    // Cerrar sesión local siempre
                    SesionUsuario.Instancia.CerrarSesion();
                }
            }
        }

        /// <summary>
        /// Verifica si un nombre de usuario existe y devuelve sus datos básicos si es así.
        /// Usado en el primer paso de "Olvidé mi contraseña".
        /// </summary>
        public cls_UsuarioDTO ObtenerDatosParaRecuperacion(string username)
        {
            cls_UsuarioDTO usuario = _userDatos.ObtenerUsuarioEmpleado(username);
            if (usuario == null)
            {
                throw new Exception("El nombre de usuario ingresado no existe.");
            }
            if (usuario.EsActivo != true)
            {
                throw new Exception("El usuario no se encuentra activo.");
            }
            // Si todo está bien, devuelve los datos del usuario.
            return usuario;
        }

        /// <summary>
        /// Valida la respuesta a una pregunta de seguridad.
        /// (Necesitarás crear un método en CapaDatos para esto)
        /// </summary>
        public bool ValidarRespuestaDeSeguridad(int idUsuario, int idPregunta, string respuesta)
        {
            // TODO: Debes crear un método en tu CapaDatos que:
            // 1. Obtenga la respuesta correcta (hasheada) de la base de datos.
            // 2. Compare el hash de la 'respuesta' proporcionada con el hash de la BD.
            // Ejemplo: return _userDatos.ValidarRespuesta(idUsuario, idPregunta, respuesta);

            // Por ahora, simulamos que la validación es exitosa para poder avanzar.
            Console.WriteLine($"Simulando validación para Usuario: {idUsuario}, Pregunta: {idPregunta}, Respuesta: {respuesta}");
            return true;
        }

        /// <summary>
        /// Establece la nueva contraseña para un usuario.
        /// (Necesitarás un método en CapaDatos que desactive la vieja y cree la nueva)
        /// </summary>
        public void RestablecerContraseña(int idUsuario, string nuevaContraseña)
        {
            // 1. Hashear la nueva contraseña
            string hash = CapaUtilidades.cls_SeguridadPass.GenerarHashSHA256(nuevaContraseña);

            // 2. Desactivar las contraseñas anteriores para ese usuario
            _passDatos.DesactivarContraseñasAnteriores(idUsuario);

            // 3. Crear el nuevo DTO de contraseña
            var passDTO = new cls_ContraseñaDTO
            {
                IdUsuario = idUsuario,
                HashContraseña = hash,
                EsActiva = true,
                FechaExpiracion = null // O establecer una nueva fecha de expiración según tus reglas
            };

            // 4. Insertar la nueva contraseña en la base de datos
            _passDatos.InsertarNuevaContraseña(passDTO);

            // 5. IMPORTANTE: Actualizar el estado del usuario en la BD para que ya no tenga
            // una contraseña random y no sea su primer ingreso.
            // TODO: Debes crear este método en tu CapaDatos.
            // _userDatos.ActualizarEstadoPostConfiguracion(idUsuario);
            Console.WriteLine($"Contraseña restablecida para el usuario {idUsuario}.");
        }


    }
}
