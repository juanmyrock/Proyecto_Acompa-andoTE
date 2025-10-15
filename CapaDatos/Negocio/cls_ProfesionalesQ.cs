using CapaDTO.SistemaDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Negocio
{
    public class cls_ProfesionalesQ
    {
        private readonly cls_EjecutarQ _ejecutarQ = new cls_EjecutarQ();

        public List<cls_ProfesionalDTO> ObtenerProfesionalesActivos()
        {
            string sql = "[dbo].[ObtenerProfesionalesActivos]";

            DataTable dt = _ejecutarQ.ConsultaReadSP(sql, null);
            List<cls_ProfesionalDTO> listaProfesionales = new List<cls_ProfesionalDTO>();

            foreach (DataRow row in dt.Rows)
            {
                listaProfesionales.Add(new cls_ProfesionalDTO
                {
                    id_profesional = Convert.ToInt32(row["id_profesional"]),
                    id_tipo_dni = Convert.ToInt32(row["id_tipo_dni"]),
                    dni = Convert.ToInt32(row["dni"]),
                    nombre = row["nombre"].ToString(),
                    apellido = row["apellido"].ToString(),
                    id_sexo = Convert.ToInt32(row["id_sexo"]),
                    telefono = Convert.ToInt32(row["telefono"]),
                    num_matricula = row["num_matricula"].ToString(),
                    id_localidad = Convert.ToInt32(row["id_localidad"]),
                    domicilio = row["domicilio"].ToString(),
                    num_domicilio = Convert.ToInt32(row["num_domicilio"]),
                    fecha_nac = row["fecha_nac"] as DateTime?,
                    email = row["email"].ToString(),
                    id_especialidad = Convert.ToInt32(row["id_especialidad"]),
                    es_activo = Convert.ToBoolean(row ["es_activo"])
                });
            }
            return listaProfesionales;
        }

        public List<cls_ProfesionalDTO> ObtenerProfesionalesInactivos()
        {
            string sql = "[dbo].[ObtenerProfesionalesInactivos]";

            DataTable dt = _ejecutarQ.ConsultaReadSP(sql, null);
            List<cls_ProfesionalDTO> listaProfesionales = new List<cls_ProfesionalDTO>();

            foreach (DataRow row in dt.Rows)
            {
                listaProfesionales.Add(new cls_ProfesionalDTO
                {
                    id_profesional = Convert.ToInt32(row["id_profesional"]),
                    id_tipo_dni = Convert.ToInt32(row["id_tipo_dni"]),
                    dni = Convert.ToInt32(row["dni"]),
                    nombre = row["nombre"].ToString(),
                    apellido = row["apellido"].ToString(),
                    id_sexo = Convert.ToInt32(row["id_sexo"]),
                    telefono = Convert.ToInt32(row["telefono"]),
                    num_matricula = row["num_matricula"].ToString(),
                    id_localidad = Convert.ToInt32(row["id_localidad"]),
                    domicilio = row["domicilio"].ToString(),
                    num_domicilio = Convert.ToInt32(row["num_domicilio"]),
                    fecha_nac = row["fecha_nac"] as DateTime?,
                    email = row["email"].ToString(),
                    id_especialidad = Convert.ToInt32(row["id_especialidad"]),
                    es_activo = Convert.ToBoolean(row["es_activo"])
                });
            }
            return listaProfesionales;
        }

        public List<cls_ProfesionalDTO> ObtenerProfesionales()
        {
            string sql = "[dbo].[ObtenerTodosLosProfesionales]";

            DataTable dt = _ejecutarQ.ConsultaReadSP(sql, null);
            List<cls_ProfesionalDTO> listaProfesionales = new List<cls_ProfesionalDTO>();

            foreach (DataRow row in dt.Rows)
            {
                listaProfesionales.Add(new cls_ProfesionalDTO
                {
                    id_profesional = Convert.ToInt32(row["id_profesional"]),
                    id_tipo_dni = Convert.ToInt32(row["id_tipo_dni"]),
                    dni = Convert.ToInt32(row["dni"]),
                    nombre = row["nombre"].ToString(),
                    apellido = row["apellido"].ToString(),
                    id_sexo = Convert.ToInt32(row["id_sexo"]),
                    telefono = Convert.ToInt32(row["telefono"]),
                    num_matricula = row["num_matricula"].ToString(),
                    id_localidad = Convert.ToInt32(row["id_localidad"]),
                    domicilio = row["domicilio"].ToString(),
                    num_domicilio = Convert.ToInt32(row["num_domicilio"]),
                    fecha_nac = row["fecha_nac"] as DateTime?,
                    email = row["email"].ToString(),
                    id_especialidad = Convert.ToInt32(row["id_especialidad"]),
                    es_activo = Convert.ToBoolean(row["es_activo"])
                });
            }
            return listaProfesionales;
        }

        public void AgregarProfesional(cls_ProfesionalDTO profesional)
        {
            string nombreStoredProcedure = "[dbo].[AgregarProfesional]";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@id_tipo_dni", profesional.id_tipo_dni),
                new SqlParameter("@dni", profesional.dni),
                new SqlParameter("@nombre", profesional.nombre),
                new SqlParameter("@apellido", profesional.apellido),
                new SqlParameter("@id_sexo", profesional.id_sexo),
                new SqlParameter("@telefono", profesional.telefono),
                new SqlParameter("@num_matricula", profesional.num_matricula),
                new SqlParameter("@id_localidad", profesional.id_localidad),
                new SqlParameter("@domicilio", profesional.domicilio),
                new SqlParameter("@num_domicilio", profesional.num_domicilio),
                new SqlParameter("@fecha_nac", (object)profesional.fecha_nac ?? DBNull.Value),
                new SqlParameter("@email", profesional.email),
                new SqlParameter("@id_especialidad", profesional.id_especialidad)
            };

            _ejecutarQ.ConsultaWriteSP(nombreStoredProcedure, parametros);
        }

        public bool ModificarProfesional(cls_ProfesionalDTO profesional)
        {
            string sqlUpdate = "[dbo].[ModificarProfesional]";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@id_profesional", profesional.id_profesional),
                new SqlParameter("@id_tipo_dni", profesional.id_tipo_dni),
                new SqlParameter("@dni", profesional.dni),
                new SqlParameter("@nombre", profesional.nombre),
                new SqlParameter("@apellido", profesional.apellido),
                new SqlParameter("@id_sexo", profesional.id_sexo),
                new SqlParameter("@telefono", profesional.telefono),
                new SqlParameter("@num_matricula", profesional.num_matricula),
                new SqlParameter("@id_localidad", profesional.id_localidad),
                new SqlParameter("@domicilio", profesional.domicilio),
                new SqlParameter("@num_domicilio", profesional.num_domicilio),
                new SqlParameter("@fecha_nac", (object)profesional.fecha_nac ?? DBNull.Value),
                new SqlParameter("@email", profesional.email),
                new SqlParameter("@id_especialidad", profesional.id_especialidad),
                new SqlParameter("@es_activo", profesional.es_activo ?? true) // Si es null, usar true por defecto
    
        };

            try
            {
                _ejecutarQ.ConsultaWriteSP(sqlUpdate, parametros);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar Profesional usando cls_EjecutarQ: {ex.Message}");
                return false;
            }
        }

        public void EliminarProfesional(int idProfesional)
        {
            string sqlBajaLogica = "[dbo].[EliminarProfesional]";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@id_profesional", idProfesional)
            };

            _ejecutarQ.ConsultaWriteSP(sqlBajaLogica, parametros);
        }

        public void ReactivarProfesional(int idProfesional)
        {
            string sqlAltaLogica = "[dbo].[ReactivarProfesional]";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@id_profesional", idProfesional)
            };

            _ejecutarQ.ConsultaWriteSP(sqlAltaLogica, parametros);
        }

        public cls_ProfesionalDTO BuscarProfesionalPorDni(int dni)
        {
            string query = "[dbo].[BuscarProfesionalPorDni]";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@dni", dni)
            };

            DataTable tabla = _ejecutarQ.ConsultaReadSP(query, parametros);

            if (tabla.Rows.Count > 0)
            {
                DataRow row = tabla.Rows[0];

                var profesional = new cls_ProfesionalDTO
                {
                    id_profesional = Convert.ToInt32(row["id_profesional"]),
                    id_tipo_dni = Convert.ToInt32(row["id_tipo_dni"]),
                    dni = Convert.ToInt32(row["dni"]),
                    nombre = row["nombre"].ToString(),
                    apellido = row["apellido"].ToString(),
                    id_sexo = Convert.ToInt32(row["id_sexo"]),
                    telefono = Convert.ToInt32(row["telefono"]),
                    num_matricula = row["num_matricula"].ToString(),
                    id_localidad = Convert.ToInt32(row["id_localidad"]),
                    domicilio = row["domicilio"].ToString(),
                    num_domicilio = Convert.ToInt32(row["num_domicilio"]),
                    fecha_nac = row["fecha_nac"] as DateTime?,
                    email = row["email"].ToString(),
                    id_especialidad = Convert.ToInt32(row["id_especialidad"])
                };
                return profesional;
            }

            return null;
        }

        public List<cls_ProfesionalDTO> ObtenerProfesionalesActivosPorEspecialidad(int idEspecialidad)
        {
            string sql = "[dbo].[ObtenerProfesionalesActivosPorEspecialidad]";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter( "@id_especialidad", idEspecialidad)
            };

            DataTable dt = _ejecutarQ.ConsultaReadSP(sql, parametros);
            return ConvertirDataTableALista(dt);
        }

        public List<cls_ProfesionalDTO> ObtenerProfesionalesInactivosPorEspecialidad(int idEspecialidad)
        {
            string sql = "[dbo].[ObtenerProfesionalesInactivosPorEspecialidad]";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter( "@id_especialidad", idEspecialidad)
            };

            DataTable dt = _ejecutarQ.ConsultaReadSP(sql, parametros);
            return ConvertirDataTableALista(dt);
        }

        public List<cls_ProfesionalDTO> ObtenerTodosProfesionalesPorEspecialidad(int idEspecialidad)
        {
            string sql = "[dbo].[ObtenerTodosProfesionalesPorEspecialidad]";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@id_especialidad", idEspecialidad)
            };

            DataTable dt = _ejecutarQ.ConsultaReadSP(sql, parametros);
            return ConvertirDataTableALista(dt);
        }

        // Método auxiliar para evitar código duplicado
        private List<cls_ProfesionalDTO> ConvertirDataTableALista(DataTable dt)
        {
            List<cls_ProfesionalDTO> listaProfesionales = new List<cls_ProfesionalDTO>();

            foreach (DataRow row in dt.Rows)
            {
                listaProfesionales.Add(new cls_ProfesionalDTO
                {
                    id_profesional = Convert.ToInt32(row["id_profesional"]),
                    id_tipo_dni = Convert.ToInt32(row["id_tipo_dni"]),
                    dni = Convert.ToInt32(row["dni"]),
                    nombre = row["nombre"].ToString(),
                    apellido = row["apellido"].ToString(),
                    id_sexo = Convert.ToInt32(row["id_sexo"]),
                    telefono = Convert.ToInt32(row["telefono"]),
                    num_matricula = row["num_matricula"].ToString(),
                    id_localidad = Convert.ToInt32(row["id_localidad"]),
                    domicilio = row["domicilio"].ToString(),
                    num_domicilio = Convert.ToInt32(row["num_domicilio"]),
                    fecha_nac = row["fecha_nac"] as DateTime?,
                    email = row["email"].ToString(),
                    id_especialidad = Convert.ToInt32(row["id_especialidad"]),
                    es_activo = Convert.ToBoolean(row["es_activo"])
                });
            }
            return listaProfesionales;
        }
    }
}