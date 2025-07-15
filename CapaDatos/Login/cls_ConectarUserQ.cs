using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaDTO;

namespace CapaDatos
{
    public class cls_ConectarUserQ
    {
        private readonly cls_EjecutarQ _ejecutar = new cls_EjecutarQ();

        public cls_UsuarioDTO ObtenerUsuarioEmpleado(string username)
        {
            string sql = @"
                SELECT u.id_usuario, u.username, u.fecha_alta, u.fecha_baja,
                       u.fecha_bloqueo, u.es_activo, u.es_random_pass, u.es_primer_ingreso,
                       u.fecha_ultimo_ingreso, u.intentos_fallidos, u.id_rol,
                       e.nombre AS nombre_empleado, e.apellido AS apellido_empleado
                FROM Usuarios u
                INNER JOIN Empleados e ON u.id_usuario = e.id_empleado
                WHERE u.username = @username";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@username", username)
            };

            DataTable tabla = _ejecutar.ConsultaRead(sql, parametros);

            if (tabla.Rows.Count == 0)
                return null;

            DataRow row = tabla.Rows[0];

            return new cls_UsuarioDTO
            {
                IdUsuario = Convert.ToInt32(row["id_usuario"]),
                Username = row["username"].ToString(),
                FechaAlta = row["fecha_alta"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["fecha_alta"]),
                FechaBaja = row["fecha_baja"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["fecha_baja"]),
                FechaBloqueo = row["fecha_bloqueo"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["fecha_bloqueo"]),
                EsActivo = row["es_activo"] == DBNull.Value ? (bool?)null : Convert.ToBoolean(row["es_activo"]),
                EsRandomPass = row["es_random_pass"] == DBNull.Value ? (bool?)null : Convert.ToBoolean(row["es_random_pass"]),
                EsPrimerIngreso = row["es_primer_ingreso"] == DBNull.Value ? (bool?)null : Convert.ToBoolean(row["es_primer_ingreso"]),
                FechaUltimoIngreso = row["fecha_ultimo_ingreso"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["fecha_ultimo_ingreso"]),
                IntentosFallidos = row["intentos_fallidos"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["intentos_fallidos"]),
                IdRol = row["id_rol"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["id_rol"]),
                NombreEmpleado = row["nombre_empleado"].ToString(),
                ApellidoEmpleado = row["apellido_empleado"].ToString()
            };
        }
        public int ObtenerCantidadIntentosMaximos()
        {
            string sql = "SELECT cantidad_intentos FROM Parametros_Contraseña";

            DataTable tabla = _ejecutar.ConsultaRead(sql, null);

            if (tabla.Rows.Count == 0)
                throw new Exception("No se encontró configuración en Parametros_Contraseña");

            return Convert.ToInt32(tabla.Rows[0]["cantidad_intentos"]);
        }

        public void RegistrarIntentoFallido(int idUsuario, int intentosMaximosPermitidos)
        {
            string sql = @"
                        UPDATE Usuarios
                        SET
                            intentos_fallidos = intentos_fallidos + 1,
                            fecha_bloqueo = CASE
                                WHEN intentos_fallidos +1 >= @maxIntentos THEN GETDATE()
                                ELSE fecha_bloqueo
                            END,
                            es_activo = CASE
                                WHEN intentos_fallidos +1 >= @maxIntentos THEN 0
                                ELSE es_activo
                            END
                        WHERE id_usuario = @idUsuario";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@idUsuario", idUsuario),
                new SqlParameter("@maxIntentos", intentosMaximosPermitidos)
            };

            _ejecutar.ConsultaWrite(sql, parametros);
        }

        public void ResetearIntentosFallidos(int idUsuario)
        {
            string sql = @"
                UPDATE Usuarios
                SET intentos_fallidos = 0
                WHERE id_usuario = @idUsuario";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@idUsuario", idUsuario)
            };

            _ejecutar.ConsultaWrite(sql, parametros);
        }

        public void RegistrarIngreso(int idUsuario)
        {
            string sql = @"
                UPDATE Usuarios
                SET fecha_ultimo_ingreso = GETDATE()
                WHERE id_usuario = @idUsuario";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@idUsuario", idUsuario)
            };

            _ejecutar.ConsultaWrite(sql, parametros);
        }

        // Actualiza el estado de un usuario después de que completa su configuración inicial.
        // Marca los flags de primer ingreso y contraseña random como falsos.
        // <param name="idUsuario">El ID del usuario que se va a actualizar.</param>
        public void FinalizarConfiguracionInicial(int idUsuario)
        {
            string sql = @"UPDATE Usuarios 
                   SET es_primer_ingreso = 0, es_random_pass = 0
                   WHERE id_usuario = @idUsuario";

            var parametros = new System.Collections.Generic.List<System.Data.SqlClient.SqlParameter>
            {
               new System.Data.SqlClient.SqlParameter("@idUsuario", idUsuario)
            };

            _ejecutar.ConsultaWrite(sql, parametros);
        }



    }


}
