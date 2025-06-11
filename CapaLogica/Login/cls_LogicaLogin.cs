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

        public bool ValidarLogin(cls_CredencialesLoginDTO credenciales)
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

            // 6. Validar expiración
            if (contraseña.FechaExpiracion.HasValue && contraseña.FechaExpiracion < DateTime.Now)
            {
                throw new Exception("Contraseña expirada. Debe cambiarla");
            }

            // 7. Verificar sesión única
            if (_sesiones.TieneSesionActiva(usuario.IdUsuario))
                throw new Exception("El usuario ya tiene una sesión activa en otro dispositivo");

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

            return true;

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

    }
}
