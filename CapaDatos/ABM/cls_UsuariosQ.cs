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
            string sql = @"
                SELECT 
                    u.id_usuario, u.username, u.id_rol, u.es_activo, u.fecha_bloqueo,
                    r.nombre_rol,
                    e.nombre + ' ' + e.apellido AS nombre_completo,
                    e.email
                FROM Usuarios u
                LEFT JOIN Roles r ON u.id_rol = r.id_rol
                INNER JOIN Empleados e ON u.id_usuario = e.id_empleado
                WHERE u.id_usuario = @idUsuario";

            var parametros = new List<SqlParameter> { new SqlParameter("@idUsuario", idUsuario) };
            DataTable tabla = _ejecutar.ConsultaRead(sql, parametros);

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
            string sql = @"
                UPDATE Usuarios 
                SET 
                    intentos_fallidos = 0, 
                    fecha_bloqueo = NULL,
                    es_activo = 1
                WHERE id_usuario = @idUsuario";

            var parametros = new List<SqlParameter> { new SqlParameter("@idUsuario", idUsuario) };
            _ejecutar.ConsultaWrite(sql, parametros);
        }
        /// Cambia el estado de un usuario (activo/inactivo).
        /// </summary>
        public void CambiarEstadoUsuario(int idUsuario, bool nuevoEstado)
        {
            // Si se desactiva, se registra la fecha de baja. Si se reactiva, se limpia.
            string sql = @"
                UPDATE Usuarios 
                SET es_activo = @esActivo,
                    fecha_baja = CASE WHEN @esActivo = 0 THEN GETDATE() ELSE NULL END
                WHERE id_usuario = @idUsuario";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@idUsuario", idUsuario),
                new SqlParameter("@esActivo", nuevoEstado)
            };

        /// Actualiza el rol de un usuario específico.
        /// Actualiza el rol de un usuario específico.
        /// </summary>
        public void ActualizarRolUsuario(int idUsuario, int idRol)
        {
            string sql = "UPDATE Usuarios SET id_rol = @idRol WHERE id_usuario = @idUsuario";
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@idUsuario", idUsuario),
                new SqlParameter("@idRol", idRol)
            };
            _ejecutar.ConsultaWrite(sql, parametros);
        }

        /// Verifica si ya existe un registro en la tabla Usuarios para un id_usuario específico.
        /// <returns>True si el usuario existe, de lo contrario False.</returns>
        public bool ExisteUsuario(int idUsuario)
        {
            string sql = "SELECT COUNT(1) FROM Usuarios WHERE id_usuario = @idUsuario";
            var parametros = new List<SqlParameter> { new SqlParameter("@idUsuario", idUsuario) };
            DataTable tabla = _ejecutar.ConsultaRead(sql, parametros);
            return Convert.ToInt32(tabla.Rows[0][0]) > 0;
        }

        /// Crea un nuevo registro de Usuario asociado a un Empleado existente.
        public void CrearNuevoUsuario(int idUsuario, string username, int idRol)
        {
            // Al crear un usuario, siempre lo marcamos para que configure su cuenta en el primer login.
            string sql = @"
        INSERT INTO Usuarios (id_usuario, username, id_rol, es_activo, es_primer_ingreso, es_random_pass, fecha_alta) 
        VALUES (@idUsuario, @username, @idRol, 1, 1, 1, GETDATE())";

            var parametros = new List<SqlParameter>
    {
        new SqlParameter("@idUsuario", idUsuario),
        new SqlParameter("@username", username),
        new SqlParameter("@idRol", idRol)
    };
            _ejecutar.ConsultaWrite(sql, parametros);
        }
    }
}
