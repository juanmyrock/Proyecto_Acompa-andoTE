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
        public ResultadoLoginDTO ValidarLogin(cls_CredencialesLoginDTO credenciales, string ipCliente, bool forzarCierre = false)
        {
            // 1. Verificar usuario
            cls_UsuarioDTO usuario = _userDatos.ObtenerUsuarioEmpleado(credenciales.Username);
            if (usuario == null)
                throw new Exception("Usuario no registrado");

            // 2. Verificar si está bloqueado
            if ((usuario.FechaBloqueo.HasValue))
                throw new Exception("Usuario está bloqueado, contacte al administrador");

            // 3. Verificar si está activo
            if (usuario.EsActivo != true || usuario.FechaBaja.HasValue)
                throw new Exception("Usuario inactivo o dado de baja");
            
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
                if (forzarCierre)
                {
                    _sesiones.CerrarSesion(usuario.IdUsuario);
                }
                else
                {
                    throw new Exception("SESION_ACTIVA");
                }
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

            return new ResultadoLoginDTO
            {
                Exitoso = true,
                RequiereCambioContraseña = necesitaCambioPass,
                RequiereConfigurarPreguntas = necesitaPreguntas
            };

        }

        // Cierra la sesión activa, tanto en la base de datos como en la sesión local.
        public void CerrarSesion()
        {
            if (SesionUsuario.Instancia.EstaSesionIniciada)
            {
                try
                {
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
            return usuario;
        }



        public void FinalizarConfiguracionInicial(int idUsuario)
        {

            _userDatos.FinalizarConfiguracionInicial(idUsuario);
        }

        public cls_UsuarioDTO ObtenerDatosParaRecuperacionPorId(int idUsuario)
        {
            var usuario = _userDatos.ObtenerUsuarioEmpleadoPorId(idUsuario);
            if (usuario == null)
            {
                throw new Exception("No se pudieron encontrar los datos del usuario para enviar el correo.");
            }
            return usuario;
        }

    }
}
