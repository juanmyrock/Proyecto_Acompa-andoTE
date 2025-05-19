using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaDTO;

namespace CapaDatos
{
    public class cls_PermisosQ
    {
        private readonly cls_EjecutarQ ejecutor = new cls_EjecutarQ();

        public List<cls_PermisoDTO> ObtenerPermisosEfectivosPorUsuario(int idUsuario)
        {
            string sql = @"
                -- Permisos por ROL
                SELECT p.id_permiso, p.nombre_permiso, p.descripcion, 'Rol' AS origen
                FROM Usuarios u
                INNER JOIN Rol_Permiso rp ON u.id_rol = rp.id_rol
                INNER JOIN Permisos p ON rp.id_permiso = p.id_permiso
                WHERE u.id_usuario = @idUsuario

                UNION

                -- Permisos individuales activos por USUARIO
                SELECT p.id_permiso, p.nombre_permiso, p.descripcion, 'Usuario' AS origen
                FROM Permiso_Usuario pu
                INNER JOIN Permisos p ON pu.id_permiso = p.id_permiso
                WHERE pu.id_usuario = @idUsuario
                  AND (
                      pu.es_permanente = 1
                      OR (pu.fecha_inicio <= GETDATE() AND (pu.fecha_fin IS NULL OR pu.fecha_fin >= GETDATE()))
                  )";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@idUsuario", idUsuario)
            };

            DataTable tabla = ejecutor.ConsultaRead(sql, parametros);

            var lista = new List<cls_PermisoDTO>();
            foreach (DataRow row in tabla.Rows)
            {
                lista.Add(new cls_PermisoDTO
                {
                    IdPermiso = Convert.ToInt32(row["id_permiso"]),
                    NombrePermiso = row["nombre_permiso"].ToString(),
                    Descripcion = row["descripcion"]?.ToString(),
                    Origen = row["origen"].ToString()
                });
            }

            return lista;
        }
    }
}
