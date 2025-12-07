using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            cls_UsuarioDTO usuario = _userDatos.ObtenerUsuarioEmpleado(credenciales.Username);
            if (usuario == null)
                throw new Exception("Usuario no registrado");

            if ((usuario.FechaBloqueo.HasValue))
                throw new Exception("Usuario está bloqueado, contacte al administrador");

            if (usuario.EsActivo != true || usuario.FechaBaja.HasValue)
                throw new Exception("Usuario inactivo o dado de baja");
            
            cls_ContraseñaDTO contraseña = _passDatos.ObtenerContraseñaActiva(usuario.IdUsuario);
            if (contraseña == null)
                throw new Exception("No hay contraseña activa para este usuario");

            if (!cls_SeguridadPass.VerificarHashSHA256(credenciales.Password, contraseña.HashContraseña))
            {
                _userDatos.RegistrarIntentoFallido(usuario.IdUsuario, intentosMaximosPermitidos);
                throw new Exception("Contraseña incorrecta");
            }
            bool necesitaCambioPass = usuario.EsRandomPass == true;
            bool necesitaPreguntas = usuario.EsPrimerIngreso == true;

            if (!necesitaCambioPass && contraseña.FechaExpiracion.HasValue && contraseña.FechaExpiracion < DateTime.Now)
            {
                throw new Exception("Contraseña expirada. Debe cambiarla");
            }

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

            _sesiones.RegistrarSesion(new cls_SesionActivaDTO
            {
                UsuarioId = usuario.IdUsuario,
                IP = ipCliente,
                FechaInicio = DateTime.Now
            });

            _userDatos.ResetearIntentosFallidos(usuario.IdUsuario);
            _userDatos.RegistrarIngreso(usuario.IdUsuario);

            List<cls_PermisoDTO> permisos = _permisos.ObtenerPermisosEfectivosPorUsuario(usuario.IdUsuario);
            List<string> nombresPermisos = permisos.Select(p => p.NombrePermiso).ToList();

            SesionUsuario.Instancia.IniciarSesion(usuario, nombresPermisos);

            return new ResultadoLoginDTO
            {
                Exitoso = true,
                RequiereCambioContraseña = necesitaCambioPass,
                RequiereConfigurarPreguntas = necesitaPreguntas
            };

        }

        public void CerrarSesion()
        {
            if (SesionUsuario.Instancia.EstaSesionIniciada)
            {
                try
                {
                    _sesiones.CerrarSesion(SesionUsuario.Instancia.IdUsuario);
                }
                finally
                {
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
        #region Validar Credenciales
        public string ValidarCredenciales(string usuario, string contrasena)
        {

            if (string.IsNullOrWhiteSpace(usuario) && string.IsNullOrWhiteSpace(contrasena))
            {
                return "Complete los campos Usuario y Contraseña";
            }
            else if (string.IsNullOrWhiteSpace(usuario))
            {
                return "Complete el campo Usuario";
            }
            else if (string.IsNullOrWhiteSpace(contrasena))
            {
                return "Complete el campo Contraseña";
            }
            return null;
        }
        #endregion
    }
}
