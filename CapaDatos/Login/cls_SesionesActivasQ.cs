using CapaDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos.Login
{
    public class cls_SesionesActivasQ
    {
        private readonly cls_EjecutarQ _ejecutar = new cls_EjecutarQ();

        public List<cls_SesionActivaDTO> ListarSesionesActivasPorUsuario(int usuarioId)
        {
            string query = @"SELECT UsuarioId, Token, IP, FechaInicio
                             FROM SesionesActivas
                             WHERE UsuarioId = @UsuarioId";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@UsuarioId", usuarioId)
            };

            DataTable tabla = _ejecutar.ConsultaRead(query, parametros);
            var sesiones = new List<cls_SesionActivaDTO>();

            foreach (DataRow row in tabla.Rows)
            {
                sesiones.Add(new cls_SesionActivaDTO
                {
                    UsuarioId = Convert.ToInt32(row["UsuarioId"]),
                    Token = row["Token"].ToString(),
                    IP = row["IP"].ToString(),
                    FechaInicio = Convert.ToDateTime(row["FechaInicio"])
                });
            }

            return sesiones;
        }

        public void RegistrarSesion(cls_SesionActivaDTO sesion)
        {
            string query = @"INSERT INTO SesionesActivas (UsuarioId, IP, FechaInicio, Token)
                             VALUES (@UsuarioId, @IP, @FechaInicio, @Token)";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@UsuarioId", sesion.UsuarioId),
                new SqlParameter("@IP", sesion.IP),
                new SqlParameter("@FechaInicio", sesion.FechaInicio),
                new SqlParameter("@Token", sesion.Token)
            };

            _ejecutar.ConsultaWrite(query, parametros);
        }

        public void CerrarSesion(int usuarioId)
        {
            string query = "DELETE FROM SesionesActivas WHERE UsuarioId = @UsuarioId";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@UsuarioId", usuarioId)
            };

            _ejecutar.ConsultaWrite(query, parametros);
        }
    }
}
