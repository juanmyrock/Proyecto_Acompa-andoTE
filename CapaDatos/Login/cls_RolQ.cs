using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaDTO;

namespace CapaDatos
{
    public class cls_RolQ
    {
        private readonly cls_EjecutarQ _ejecutar = new cls_EjecutarQ();

        public List<cls_RolDTO> ObtenerTodosLosRoles()
        {
            string sql = "SELECT id_rol, nombre_rol, descripcion FROM Roles";
            DataTable tabla = _ejecutar.ConsultaRead(sql);

            var lista = new List<cls_RolDTO>();
            foreach (DataRow row in tabla.Rows)
            {
                lista.Add(new cls_RolDTO
                {
                    IdRol = Convert.ToInt32(row["id_rol"]),
                    NombreRol = row["nombre_rol"].ToString(),
                    Descripcion = row["descripcion"]?.ToString()
                });
            }

            return lista;
        }

        public cls_RolDTO ObtenerRolPorId(int idRol)
        {
            string sql = "SELECT id_rol, nombre_rol, descripcion FROM Roles WHERE id_rol = @idRol";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@idRol", idRol)
            };

            DataTable tabla = _ejecutar.ConsultaRead(sql, parametros);

            if (tabla.Rows.Count == 0)
                return null;

            DataRow row = tabla.Rows[0];
            return new cls_RolDTO
            {
                IdRol = Convert.ToInt32(row["id_rol"]),
                NombreRol = row["nombre_rol"].ToString(),
                Descripcion = row["descripcion"]?.ToString()
            };
        }

        public void InsertarRol(cls_RolDTO rol)
        {
            string sql = "INSERT INTO Roles (nombre_rol, descripcion) VALUES (@nombre, @descripcion)";
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@nombre", rol.NombreRol),
                new SqlParameter("@descripcion", (object)rol.Descripcion ?? DBNull.Value)
            };

            _ejecutar.ConsultaWrite(sql, parametros);
        }

        public void ActualizarRol(cls_RolDTO rol)
        {
            string sql = @"
                UPDATE Roles
                SET nombre_rol = @nombre,
                    descripcion = @descripcion
                WHERE id_rol = @idRol";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@idRol", rol.IdRol),
                new SqlParameter("@nombre", rol.NombreRol),
                new SqlParameter("@descripcion", (object)rol.Descripcion ?? DBNull.Value)
            };

            _ejecutar.ConsultaWrite(sql, parametros);
        }

        public void EliminarRol(int idRol)
        {
            string sql = "DELETE FROM Roles WHERE id_rol = @idRol";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@idRol", idRol)
            };

            _ejecutar.ConsultaWrite(sql, parametros);
        }
    }
}
