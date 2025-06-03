using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaDTO;

namespace CapaDatos.Login
{
    public class cls_SesionActivaQ
    {
        private readonly cls_EjecutarQ _ejecutar = new cls_EjecutarQ();

        /// <summary>
        /// Verifica si el usuario ya tiene una sesión activa.
        /// </summary>
        public bool TieneSesionActiva(int usuarioId)
        {
            string sql = @"
                SELECT COUNT(*) 
                FROM SesionesActivas 
                WHERE UsuarioId = @UsuarioId";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@UsuarioId", usuarioId)
            };

            DataTable resultado = _ejecutar.ConsultaRead(sql, parametros);

            if (resultado.Rows.Count == 0)
                return false;

            int cantidad = Convert.ToInt32(resultado.Rows[0][0]);
            return cantidad > 0;
        }

        /// <summary>
        /// Registra una nueva sesión activa.
        /// </summary>
        public void RegistrarSesion(cls_SesionActivaDTO sesion)
        {
            string sql = @"
                INSERT INTO SesionesActivas (UsuarioId, IP, FechaInicio)
                VALUES (@UsuarioId, @IP, @FechaInicio)";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@UsuarioId", sesion.UsuarioId),
                new SqlParameter("@IP", sesion.IP),
                new SqlParameter("@FechaInicio", sesion.FechaInicio),
            };

            _ejecutar.ConsultaWrite(sql, parametros);
        }

        /// <summary>
        /// Elimina la sesión activa del usuario indicado.
        /// </summary>
        public void CerrarSesion(int usuarioId)
        {
            string sql = @"
                DELETE FROM SesionesActivas 
                WHERE UsuarioId = @UsuarioId";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@UsuarioId", usuarioId)
            };

            _ejecutar.ConsultaWrite(sql, parametros);
        }

        /// <summary>
        /// Obtiene la sesión activa de un usuario, si existe.
        /// </summary>
        public cls_SesionActivaDTO ObtenerSesionActiva(int usuarioId)
        {
            string sql = @"
                SELECT UsuarioId, IP, FechaInicio
                FROM SesionesActivas
                WHERE UsuarioId = @UsuarioId";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@UsuarioId", usuarioId)
            };

            DataTable tabla = _ejecutar.ConsultaRead(sql, parametros);

            if (tabla.Rows.Count == 0)
                return null;

            DataRow row = tabla.Rows[0];

            return new cls_SesionActivaDTO
            {
                UsuarioId = Convert.ToInt32(row["UsuarioId"]),
                IP = row["IP"].ToString(),
                FechaInicio = row["FechaInicio"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["FechaInicio"])
            };
        }
    }
}
