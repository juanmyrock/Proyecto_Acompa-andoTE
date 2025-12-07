using CapaDatos;
using CapaDatos.ABM;
using CapaDTO;
using CapaUtilidades;
using System;
using CapaSesion;
using System.Collections.Generic;
using System.Transactions;

namespace CapaLogica.ABM
{
    public class cls_LogicaGestionarUsuarios
    {
        private readonly cls_ConectarUserQ conectarUser = new cls_ConectarUserQ();
        private readonly cls_UsuariosQ _userDatos = new cls_UsuariosQ();
        private readonly cls_ContraseñasQ _contraseñasDatos = new cls_ContraseñasQ();
        
        public cls_UsuarioGestionDTO ObtenerUsuarioParaGestion(int idUsuario)
        {
            var usuario = _userDatos.ObtenerUsuarioParaGestion(idUsuario);
            if (usuario == null)
            {
                throw new Exception("No se pudo cargar la información del usuario seleccionado.");
            }
            return usuario;
        }

        public void DesbloquearUsuario(int idUsuario)
        {
            _userDatos.DesbloquearUsuario(idUsuario);
        }

        public void CambiarEstadoUsuario(int idUsuario, bool nuevoEstado)
        {
            _userDatos.CambiarEstadoUsuario(idUsuario, nuevoEstado);
        }

        public void ActualizarRolUsuario(int idUsuario, int idRol)
        {
            _userDatos.ActualizarRolUsuario(idUsuario, idRol);
        }

        public bool VerificarSiUsuarioExiste(int idEmpleado)
        {
            return _userDatos.ExisteUsuario(idEmpleado);
        }

        public void CrearUsuarioYEnviarContraseña(int idUsuario, string username, int idRol, string email, string nombreCompleto)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("El empleado no tiene un correo electrónico asignado. No se puede crear el usuario.");
            }

            
            string contraseñaTemporal = new Random().Next(100000, 999999).ToString();
            string hashTemporal = cls_SeguridadPass.GenerarHashSHA256(contraseñaTemporal);

            using (var scope = new TransactionScope())
            {
                _userDatos.CrearNuevoUsuario(idUsuario, username, idRol);

                _contraseñasDatos.DesactivarContraseñasAnteriores(idUsuario);

                _contraseñasDatos.InsertarNuevaContraseña(new cls_ContraseñaDTO
                {
                    IdUsuario = idUsuario,
                    HashContraseña = hashTemporal,
                    EsActiva = true,
                    FechaExpiracion = null
                });

                conectarUser.MarcarContraseñaComoRandom(idUsuario);

                scope.Complete();
            }

            try
            {
                ArmarMail.Preparar(email, "Contraseña Nueva", contraseñaTemporal, username);
            }
            catch (Exception ex)
            {

                throw new Exception($"Usuario creado con éxito, pero falló el envío del correo: {ex.Message}");
            }
        }



    }
}