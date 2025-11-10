using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaDTO.SistemaDTO;
using CapaDatos;

namespace CapaDatos
{
    public class cls_ObraSocialQ
    {
        private cls_EjecutarQ _ejecutor;

        public cls_ObraSocialQ()
        {
            _ejecutor = new cls_EjecutarQ();
        }


        public List<cls_ObraSocialDTO> ObtenerOSActivas()
        {
            string query = "SELECT * FROM Obra_Social WHERE estado = 1";

            try
            {
                DataTable tabla = _ejecutor.ConsultaRead(query);
                var listaObrasSociales = new List<cls_ObraSocialDTO>();

                foreach (DataRow row in tabla.Rows)
                {
                    listaObrasSociales.Add(new cls_ObraSocialDTO
                    {
                        id_obra_social = Convert.ToInt32(row["id_obra_social"]),
                        nombre_os = row["nombre_os"] != DBNull.Value ? row["nombre_os"].ToString() : string.Empty,
                        codigo = row["codigo"] != DBNull.Value ? Convert.ToInt32(row["codigo"]) : 0,
                        cuit = row["cuit"] != DBNull.Value ? Convert.ToInt64(row["cuit"]) : 0,
                        domicilio = row["domicilio"] != DBNull.Value ? row["domicilio"].ToString() : string.Empty,
                        num_domicilio = row["num_domicilio"] != DBNull.Value ? Convert.ToInt32(row["num_domicilio"]) : 0,
                        telefono = row["telefono"] != DBNull.Value ? row["telefono"].ToString() : string.Empty,
                        estado = row["estado"] != DBNull.Value ? Convert.ToBoolean(row["estado"]) : false,
                        fecha_alta = row["fecha_alta"] != DBNull.Value ? Convert.ToDateTime(row["fecha_alta"]) : DateTime.MinValue,
                        fecha_baja = row["fecha_baja"] != DBNull.Value ? Convert.ToDateTime(row["fecha_baja"]) : DateTime.MinValue,
                        id_provincia = row["id_provincia"] != DBNull.Value ? Convert.ToInt32(row["id_provincia"]) : 0,
                        id_localidad =row["id_localidad"] != DBNull.Value ? Convert.ToInt32(row["id_localidad"]) : 0
                    });
                }
                return listaObrasSociales;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener y mapear Obras Sociales {ex.Message}");
                throw;
            }
        }

        public List<cls_ObraSocialDTO> ObtenerTodasLasOS()
        {
            string query = "SELECT * FROM Obra_Social";

            try
            {
                DataTable tabla = _ejecutor.ConsultaRead(query);
                var listaObrasSociales = new List<cls_ObraSocialDTO>();

                foreach (DataRow row in tabla.Rows)
                {
                    listaObrasSociales.Add(new cls_ObraSocialDTO
                    {
                        id_obra_social = Convert.ToInt32(row["id_obra_social"]),
                        nombre_os = row["nombre_os"] != DBNull.Value ? row["nombre_os"].ToString() : string.Empty,
                        codigo = row["codigo"] != DBNull.Value ? Convert.ToInt32(row["codigo"]) : 0,
                        cuit = row["cuit"] != DBNull.Value ? Convert.ToInt64(row["cuit"]) : 0,
                        domicilio = row["domicilio"] != DBNull.Value ? row["domicilio"].ToString() : string.Empty,
                        num_domicilio = row["num_domicilio"] != DBNull.Value ? Convert.ToInt32(row["num_domicilio"]) : 0,
                        telefono = row["telefono"] != DBNull.Value ? row["telefono"].ToString() : string.Empty,
                        estado = row["estado"] != DBNull.Value ? Convert.ToBoolean(row["estado"]) : false,
                        fecha_alta = row["fecha_alta"] != DBNull.Value ? Convert.ToDateTime(row["fecha_alta"]) : DateTime.MinValue,
                        fecha_baja = row["fecha_baja"] != DBNull.Value ? Convert.ToDateTime(row["fecha_baja"]) : DateTime.MinValue,
                        id_provincia = row["id_provincia"] != DBNull.Value ? Convert.ToInt32(row["id_provincia"]) : 0,
                        id_localidad = row["id_localidad"] != DBNull.Value ? Convert.ToInt32(row["id_localidad"]) : 0
                    });
                }
                return listaObrasSociales;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener y mapear Obras Sociales {ex.Message}");
                throw;
            }
        }

        public List<cls_ObraSocialDTO> ObtenerOSInactivas()
        {
            string query = "SELECT * FROM Obra_Social WHERE estado = 0";

            try
            {
                DataTable tabla = _ejecutor.ConsultaRead(query);
                var listaObrasSociales = new List<cls_ObraSocialDTO>();

                foreach (DataRow row in tabla.Rows)
                {
                    listaObrasSociales.Add(new cls_ObraSocialDTO
                    {
                        id_obra_social = Convert.ToInt32(row["id_obra_social"]),
                        nombre_os = row["nombre_os"] != DBNull.Value ? row["nombre_os"].ToString() : string.Empty,
                        codigo = row["codigo"] != DBNull.Value ? Convert.ToInt32(row["codigo"]) : 0,
                        cuit = row["cuit"] != DBNull.Value ? Convert.ToInt64(row["cuit"]) : 0,
                        domicilio = row["domicilio"] != DBNull.Value ? row["domicilio"].ToString() : string.Empty,
                        num_domicilio = row["num_domicilio"] != DBNull.Value ? Convert.ToInt32(row["num_domicilio"]) : 0,
                        telefono = row["telefono"] != DBNull.Value ? row["telefono"].ToString() : string.Empty,
                        estado = row["estado"] != DBNull.Value ? Convert.ToBoolean(row["estado"]) : false,
                        fecha_alta = row["fecha_alta"] != DBNull.Value ? Convert.ToDateTime(row["fecha_alta"]) : DateTime.MinValue,
                        fecha_baja = row["fecha_baja"] != DBNull.Value ? Convert.ToDateTime(row["fecha_baja"]) : DateTime.MinValue,
                        id_provincia = row["id_provincia"] != DBNull.Value ? Convert.ToInt32(row["id_provincia"]) : 0,
                        id_localidad = row["id_localidad"] != DBNull.Value ? Convert.ToInt32(row["id_localidad"]) : 0
                    });
                }
                return listaObrasSociales;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener y mapear Obras Sociales {ex.Message}");
                throw;
            }
        }

        public bool AgregarObraSocial(cls_ObraSocialDTO obraSocial)
        {
            string query = @"
        INSERT INTO Obra_Social 
        (nombre_os, codigo, cuit, domicilio, num_domicilio, telefono, estado, fecha_alta, id_localidad, id_provincia)
        VALUES 
        (@NombreOS, @Codigo, @Cuit, @Domicilio, @NumDomicilio, @Telefono, @Estado, @FechaAlta @id_localidad, @id_provincia)";

            try
            {
                var parametros = new List<SqlParameter>
            {
                new SqlParameter("@NombreOS", obraSocial.nombre_os ?? (object)DBNull.Value),
                new SqlParameter("@Codigo", obraSocial.codigo ?? (object)DBNull.Value),
                new SqlParameter("@Cuit", obraSocial.cuit ?? (object)DBNull.Value),
                new SqlParameter("@Domicilio", obraSocial.domicilio ?? (object)DBNull.Value),
                new SqlParameter("@NumDomicilio", obraSocial.num_domicilio ?? (object)DBNull.Value),
                new SqlParameter("@Telefono", obraSocial.telefono ?? (object)DBNull.Value),
                new SqlParameter("@Estado", obraSocial.estado ?? true),
                new SqlParameter("@FechaAlta", obraSocial.fecha_alta ?? DateTime.Now),
                new SqlParameter("@id_localidad", obraSocial.id_localidad ?? (object)DBNull.Value),
                new SqlParameter("@id_provincia", obraSocial.id_provincia ?? (object)DBNull.Value)


            };

                int filasAfectadas = _ejecutor.ConsultaCUD(query, parametros);
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar obra social: {ex.Message}");
                throw;
            }
        }

        public bool ModificarObraSocial(cls_ObraSocialDTO obraSocial)
        {
            string query = @"
            UPDATE Obra_Social 
            SET nombre_os = @NombreOS,
                codigo = @Codigo,
                cuit = @Cuit,
                domicilio = @Domicilio,
                num_domicilio = @NumDomicilio,
                telefono = @Telefono,
                estado = @Estado,
                fecha_baja = @FechaBaja,
                id_localidad = @id_localidad,
                id_provincia = @id_provincia
            WHERE id_obra_social = @IdObraSocial";

            try
            {
                var parametros = new List<SqlParameter>
            {
                new SqlParameter("@IdObraSocial", obraSocial.id_obra_social),
                new SqlParameter("@NombreOS", obraSocial.nombre_os ?? (object)DBNull.Value),
                new SqlParameter("@Codigo", obraSocial.codigo ?? (object)DBNull.Value),
                new SqlParameter("@Cuit", obraSocial.cuit ?? (object)DBNull.Value),
                new SqlParameter("@Domicilio", obraSocial.domicilio ?? (object)DBNull.Value),
                new SqlParameter("@NumDomicilio", obraSocial.num_domicilio ?? (object)DBNull.Value),
                new SqlParameter("@Telefono", obraSocial.telefono ?? (object)DBNull.Value),
                new SqlParameter("@Estado", obraSocial.estado ?? true),
                new SqlParameter("@FechaBaja", obraSocial.fecha_baja ?? (object)DBNull.Value),
                new SqlParameter("@id_localidad", obraSocial.id_localidad ?? (object)DBNull.Value),
                new SqlParameter("@id_provincia", obraSocial.id_provincia ?? (object)DBNull.Value)
            };

                int filasAfectadas = _ejecutor.ConsultaCUD(query, parametros);
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al modificar obra social: {ex.Message}");
                throw;
            }
        }

        public bool EliminarObraSocial(int idObraSocial)
        {
            string query = @"
            UPDATE Obra_Social 
            SET estado = 0, 
                fecha_baja = @FechaBaja
            WHERE id_obra_social = @IdObraSocial";

            try
            {
                var parametros = new List<SqlParameter>
            {
                new SqlParameter("@IdObraSocial", idObraSocial),
                new SqlParameter("@FechaBaja", DateTime.Now)
            };

                int filasAfectadas = _ejecutor.ConsultaCUD(query, parametros);
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar obra social: {ex.Message}");
                throw;
            }
        }

        public bool ReactivarObraSocial(int idObraSocial)
        {
            string query = @"
    UPDATE Obra_Social 
    SET estado = 1, 
        fecha_baja = NULL
    WHERE id_obra_social = @IdObraSocial";

            try
            {
                var parametros = new List<SqlParameter>
        {
            new SqlParameter("@IdObraSocial", idObraSocial)
        };

                int filasAfectadas = _ejecutor.ConsultaCUD(query, parametros);
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al reactivar obra social: {ex.Message}");
                throw;
            }
        }
    }
}

