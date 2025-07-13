using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaDTO;

namespace CapaDatos
{
    public class cls_ContraseñasQ
    {
        private readonly cls_EjecutarQ _ejecutar = new cls_EjecutarQ();

        public cls_ContraseñaDTO ObtenerContraseñaActiva(int idUsuario)
        {
            string sql = @"SELECT id_password, id_usuario, hash_contraseña, fecha_creacion, 
                                  fecha_expiracion, es_activa
                           FROM Contraseñas
                           WHERE id_usuario = @idUsuario AND es_activa = 1";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@idUsuario", idUsuario)
            };

            DataTable tabla = _ejecutar.ConsultaRead(sql, parametros);

            if (tabla.Rows.Count == 0)
                return null;

            DataRow row = tabla.Rows[0];

            return new cls_ContraseñaDTO
            {
                IdPassword = Convert.ToInt32(row["id_password"]),
                IdUsuario = Convert.ToInt32(row["id_usuario"]),
                HashContraseña = row["hash_contraseña"].ToString(),
                FechaCreacion = Convert.ToDateTime(row["fecha_creacion"]),
                FechaExpiracion = row["fecha_expiracion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["fecha_expiracion"]),
                EsActiva = Convert.ToBoolean(row["es_activa"])
            };
        }

        public void DesactivarContraseñasAnteriores(int idUsuario)
        {
            string sql = @"UPDATE Contraseñas
                           SET es_activa = 0
                           WHERE id_usuario = @idUsuario AND es_activa = 1";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@idUsuario", idUsuario)
            };

            _ejecutar.ConsultaWrite(sql, parametros);
        }

        public void InsertarNuevaContraseña(cls_ContraseñaDTO nuevaContraseña)
        {
            string sql = @"INSERT INTO Contraseñas (id_usuario, hash_contraseña, fecha_expiracion, es_activa)
                           VALUES (@idUsuario, @hash, @expiracion, @activa)";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@idUsuario", nuevaContraseña.IdUsuario),
                new SqlParameter("@hash", nuevaContraseña.HashContraseña),
                new SqlParameter("@expiracion", (object)nuevaContraseña.FechaExpiracion ?? DBNull.Value),
                new SqlParameter("@activa", nuevaContraseña.EsActiva)
            };

            _ejecutar.ConsultaWrite(sql, parametros);
        }

        public List<string> ObtenerHashesAnteriores(int idUsuario, int cantidad)
        {
            // Si la cantidad a verificar es 0 o menos, no hay nada que hacer.
            if (cantidad <= 0) return new List<string>();

            string sql = $@"
                         SELECT TOP {cantidad} hash_contraseña 
                         FROM Contraseñas 
                         WHERE id_usuario = @idUsuario 
                         ORDER BY fecha_creacion DESC";

            var parametros = new List<SqlParameter> { new SqlParameter("@idUsuario", idUsuario) };
            DataTable tabla = _ejecutar.ConsultaRead(sql, parametros);

            var hashes = new List<string>();
            foreach (DataRow row in tabla.Rows)
            {
                hashes.Add(row["hash_contraseña"].ToString());
            }
            return hashes;
        }
    }
}
