using CapaDatos;
using CapaUtilidades;
using CapaDTO;
using CapaSesion.Login;
using System;

namespace CapaLogica.Login
{
    public class cls_LogicaLogin
    {
        private readonly cls_ConectarUserQ _userDatos = new cls_ConectarUserQ();
        private readonly cls_ContraseñasQ _passDatos = new cls_ContraseñasQ();
        private readonly cls_SeguridadPass _seguridad = new cls_SeguridadPass();

        int intentosMaximosPermitidos = 5; // Lo reemplazarás con el valor parametrizado real



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
            if (usuario.FechaBloqueo.HasValue && usuario.FechaBloqueo > DateTime.Now)
                throw new Exception("El usuario está bloqueado");

            // 4. Obtener contraseña activa
            cls_ContraseñaDTO contraseña = _passDatos.ObtenerContraseñaActiva(usuario.IdUsuario);
            if (contraseña == null)
                throw new Exception("No hay contraseña activa para este usuario");

            // 5. Validar hash
            if (!_seguridad.VerificarHashSHA256(credenciales.Password, contraseña.HashContraseña))
            {
                _userDatos.RegistrarIntentoFallido(usuario.IdUsuario); // Incrementa el contador
                throw new Exception("Contraseña incorrecta");
            }

            // 6. Validar expiración
            if (contraseña.FechaExpiracion.HasValue && contraseña.FechaExpiracion < DateTime.Now)
            {
                throw new Exception("Contraseña expirada. Debe cambiarla");
            }

            // 7. Resetear intentos fallidos y registrar ingreso
            _userDatos.ResetearIntentosFallidos(usuario.IdUsuario);
            _userDatos.RegistrarIngreso(usuario.IdUsuario);

            // 8. Iniciar sesión (singleton)
            SesionUsuario.Instancia(usuario);

            return true;
        }
    }
}
