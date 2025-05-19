using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaDTO;

namespace CapaDatos
{
    public class cls_ConectarUserQ
    {
        private readonly cls_EjecutarQ ejecutar = new cls_EjecutarQ();

        public cls_UsuarioDTO ObtenerUsuarioConEmpleado(string username)
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

            DataTable tabla = ejecutar.ConsultaRead(sql, parametros);

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
    }
}
