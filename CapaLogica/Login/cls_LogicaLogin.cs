using System;
using System.Collections.Generic;
using System.Linq;
using CapaDatos;
using CapaDTO;
using CapaSesion.Login;
using CapaUtilidades;

namespace CapaLogica
{
    public class cls_LogicaLogin
    {
        private readonly cls_ConectarUserQ _userDatos = new cls_ConectarUserQ();
        private readonly cls_ContraseñasQ _passDatos = new cls_ContraseñasQ();
        private readonly cls_PermisosQ _permisos = new cls_PermisosQ();
        private const int intentosMaximosPermitidos = 3;

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

            // 7. Resetear intentos fallidos y registrar ingreso
            _userDatos.ResetearIntentosFallidos(usuario.IdUsuario);
            _userDatos.RegistrarIngreso(usuario.IdUsuario);

            // 8. Obtener permisos y preparar lista de nombres
            List<cls_PermisoDTO> permisos = _permisos.ObtenerPermisosEfectivosPorUsuario(usuario.IdUsuario);
            List<string> nombresPermisos = permisos.Select(p => p.NombrePermiso).ToList();

            // 9. Iniciar sesión (singleton)
            SesionUsuario.Instancia.IniciarSesion(usuario, nombresPermisos);

            return true;
        }
    }
}

//Cuando tenga el resto lo implemento
//// 4. Generar token único
//string token = Guid.NewGuid().ToString("N");

//// 5. Verificar sesión única
//if (_sesiones.ValidarSesionUnica(usuario.IdUsuario, token))
//    throw new ApplicationException("El usuario ya tiene una sesión activa");

//// 6. Registrar sesión
//_sesiones.RegistrarSesion(usuario.IdUsuario, token, ipCliente);

//// 7. Iniciar sesión local
//SesionUsuario.Instancia.IniciarSesion(usuario, token);

//return true;
//        }

//        public void CerrarSesion()
//{
//    if (SesionUsuario.Instancia.Usuario != null)
//    {
//        _sesiones.CerrarSesion(SesionUsuario.Instancia.Usuario.IdUsuario);
//        SesionUsuario.Instancia.CerrarSesion();
//    }
//}