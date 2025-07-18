﻿using System;
using System.Collections.Generic;
using CapaDatos.ABM; 
using CapaDTO;

namespace CapaLogica.ABM
{
    /// Contiene toda la lógica de negocio para la administración de usuarios
    /// (desbloquear, cambiar estado, actualizar rol, etc.).
    public class cls_LogicaGestionarUsuarios
    {
        private readonly cls_UsuariosQ _userDatos = new cls_UsuariosQ();

        /// Obtiene los datos de un usuario para mostrarlos en el formulario de gestión.
        public cls_UsuarioGestionDTO ObtenerUsuarioParaGestion(int idUsuario)
        {
            var usuario = _userDatos.ObtenerUsuarioParaGestion(idUsuario);
            if (usuario == null)
            {
                throw new Exception("No se pudo cargar la información del usuario seleccionado.");
            }
            return usuario;
        }

        /// Llama a la capa de datos para desbloquear a un usuario.
        public void DesbloquearUsuario(int idUsuario)
        {
            _userDatos.DesbloquearUsuario(idUsuario);
        }

        /// Llama a la capa de datos para cambiar el estado (activo/inactivo) de un usuario.
        public void CambiarEstadoUsuario(int idUsuario, bool nuevoEstado)
        {
            _userDatos.CambiarEstadoUsuario(idUsuario, nuevoEstado);
        }

        /// Llama a la capa de datos para actualizar el rol de un usuario.
        public void ActualizarRolUsuario(int idUsuario, int idRol)
        {
            _userDatos.ActualizarRolUsuario(idUsuario, idRol);
        }
    }
}