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
            _ejecutar.ConsultaWrite(sql, parametros);
        }
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
    }
}
