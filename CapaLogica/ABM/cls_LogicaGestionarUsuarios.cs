using CapaDatos;
using CapaDatos.ABM;
using CapaDTO;
using CapaUtilidades;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace CapaLogica.ABM
{
    public class cls_LogicaGestionarUsuarios
    {
        private readonly cls_ConectarUserQ conectarUser = new cls_ConectarUserQ();
        private readonly cls_UsuariosQ _userDatos = new cls_UsuariosQ();
        private readonly cls_ContraseñasQ _contraseñasDatos = new cls_ContraseñasQ();

        //obtiene los datos de un usuario para mostrarlos en el formulario de gestión
        public cls_UsuarioGestionDTO ObtenerUsuarioParaGestion(int idUsuario)
        {
            var usuario = _userDatos.ObtenerUsuarioParaGestion(idUsuario);
            if (usuario == null)
            {
                throw new Exception("No se pudo cargar la información del usuario seleccionado.");
            }
            return usuario;
        }

        //llama a la capa de datos para desbloquear a un usuario
        public void DesbloquearUsuario(int idUsuario)
        {
            _userDatos.DesbloquearUsuario(idUsuario);
        }

        //llama a la capa de datos para cambiar el estado (activo/inactivo) de un usuario
        public void CambiarEstadoUsuario(int idUsuario, bool nuevoEstado)
        {
            _userDatos.CambiarEstadoUsuario(idUsuario, nuevoEstado);
        }

        //llama a la capa de datos para actualizar el rol de un usuario
        public void ActualizarRolUsuario(int idUsuario, int idRol)
        {
            _userDatos.ActualizarRolUsuario(idUsuario, idRol);
        }

        /// Verifica si un empleado ya tiene una cuenta de usuario creada.
        /// </summary>
        public bool VerificarSiUsuarioExiste(int idEmpleado)
        {
            return _userDatos.ExisteUsuario(idEmpleado);
        }

        public void CrearUsuarioYEnviarContraseña(int idUsuario, string username, int idRol, string email, string nombreCompleto)
        {
            // 1. Validación de Pre-condiciones
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("El empleado no tiene un correo electrónico asignado. No se puede crear el usuario.");
            }
            // if (_userDatos.ExisteUsername(username)) throw new Exception("El nombre de usuario ya está en uso.");

            // 2. Generar la contraseña temporal ANTES de la transacción
            string contraseñaTemporal = new Random().Next(100000, 999999).ToString();
            string hashTemporal = cls_SeguridadPass.GenerarHashSHA256(contraseñaTemporal);

            // 3. Iniciar la transacción para las operaciones de base de datos
            using (var scope = new TransactionScope())
            {
                // 3a. Crear el registro del usuario.
                _userDatos.CrearNuevoUsuario(idUsuario, username, idRol);

                // 3b. Desactivar cualquier contraseña vieja (aunque no debería haber).
                _contraseñasDatos.DesactivarContraseñasAnteriores(idUsuario);

                // 3c. Insertar la nueva contraseña temporal como un NUEVO registro activo.
                _contraseñasDatos.InsertarNuevaContraseña(new cls_ContraseñaDTO
                {
                    IdUsuario = idUsuario,
                    HashContraseña = hashTemporal,
                    EsActiva = true,
                    FechaExpiracion = null
                });

                // 3d. Marcar al usuario para que deba cambiar la contraseña en el próximo login.
                conectarUser.MarcarContraseñaComoRandom(idUsuario);

                // 3e. Si todas las operaciones de BD fueron exitosas, completamos la transacción.
                scope.Complete();
            }

            // 4. Enviar el correo electrónico DESPUÉS de que la transacción fue exitosa.
            // Si esto falla, el usuario ya está creado en la BD, pero es un error menos crítico.
            try
            {
                //_servicioEmail.EnviarContraseñaTemporal(email, nombreCompleto, contraseñaTemporal);
            }
            catch (Exception ex)
            {
                // Lanzamos una excepción específica si el email falla, para que el admin sepa que el usuario fue creado pero el email no se pudo enviar.
                throw new Exception($"Usuario creado con éxito, pero falló el envío del correo: {ex.Message}");
            }
        }



    }
}