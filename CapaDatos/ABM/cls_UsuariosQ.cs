using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaDTO;

namespace CapaDatos.ABM
{
    public class cls_UsuariosQ
    {
        private readonly cls_EjecutarQ _ejecutar = new cls_EjecutarQ();

        /// Obtiene los datos específicos para la gestión de un usuario.
        public cls_UsuarioGestionDTO ObtenerUsuarioParaGestion(int idUsuario)
        {
            string sql = "[dbo].[ObtenerUsuarioParaGestion]";

            var parametros = new List<SqlParameter> { new SqlParameter("@idUsuario", idUsuario) };
            DataTable tabla = _ejecutar.ConsultaReadSP(sql, parametros);

            if (tabla.Rows.Count == 0) return null;

            DataRow row = tabla.Rows[0];
            return new cls_UsuarioGestionDTO
            {
                IdUsuario = Convert.ToInt32(row["id_usuario"]),
                Username = row["username"].ToString(),
                IdRol = row["id_rol"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["id_rol"]),
                NombreRol = row["nombre_rol"]?.ToString(), // Usar '?' por si el rol es NULL
                EsActivo = Convert.ToBoolean(row["es_activo"]),
                EstaBloqueado = row["fecha_bloqueo"] != DBNull.Value,
                NombreCompletoEmpleado = row["nombre_completo"].ToString(),
                Email = row["email"].ToString()
            };
        }

        /// Desbloquea a un usuario, reseteando sus intentos fallidos y reactivándolo.
        public void DesbloquearUsuario(int idUsuario)
        {
            string sql = "[dbo].[DesbloquearUsuario]";

            var parametros = new List<SqlParameter> { new SqlParameter("@idUsuario", idUsuario) };
            _ejecutar.ConsultaWriteSP(sql, parametros);
        }
        // Cambia el estado de un usuario (activo/inactivo).
        public void CambiarEstadoUsuario(int idUsuario, bool nuevoEstado)
        {
            // Si se desactiva, se registra la fecha de baja. Si se reactiva, se limpia.
            string sql = "[dbo].[CambiarEstadoUsuario]";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@idUsuario", idUsuario),
                new SqlParameter("@esActivo", nuevoEstado)
            };
            _ejecutar.ConsultaWriteSP(sql, parametros);
        }

        // Actualiza el rol de un usuario específico.
        public void ActualizarRolUsuario(int idUsuario, int idRol)
        {
            string sql = "[dbo].[ActualizarRolUsuario]";
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@idUsuario", idUsuario),
                new SqlParameter("@idRol", idRol)
            };
            _ejecutar.ConsultaWriteSP(sql, parametros);
        }

        // Verifica si ya existe un registro en la tabla Usuarios para un id_usuario específico.
        // True si el usuario existe, de lo contrario False.
        public bool ExisteUsuario(int idUsuario)
        {
            string sql = "[dbo].[ExisteUsuario]";
            var parametros = new List<SqlParameter> { new SqlParameter("@idUsuario", idUsuario) };
            DataTable tabla = _ejecutar.ConsultaReadSP(sql, parametros);
            return Convert.ToInt32(tabla.Rows[0][0]) > 0;
        }

        // Crea un nuevo registro de Usuario asociado a un Empleado existente.
        public void CrearNuevoUsuario(int idUsuario, string username, int idRol)
        {
            // Al crear un usuario, siempre lo marcamos para que configure su cuenta en el primer login.
            string sql = "[dbo].[CrearNuevoUsuario]";

            var parametros = new List<SqlParameter>
    {
        new SqlParameter("@idUsuario", idUsuario),
        new SqlParameter("@username", username),
        new SqlParameter("@idRol", idRol)
    };
            _ejecutar.ConsultaWriteSP(sql, parametros);
        }
    }
}
