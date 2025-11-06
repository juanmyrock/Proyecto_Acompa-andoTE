using CapaDatos;
using CapaDTO.SistemaDTO;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace CapaDatos.ABM
{
    public class cls_PacientesQ
    {
        private readonly cls_EjecutarQ _ejecutar = new cls_EjecutarQ();

        public List<cls_PacienteDTO> ObtenerPacientesActivos()
        {
            string sql = "[dbo].[ObtenerPacientesActivos]";

            DataTable dt = _ejecutar.ConsultaReadSP(sql, null);
            List<cls_PacienteDTO> listaPacientes = new List<cls_PacienteDTO>();

            foreach (DataRow row in dt.Rows)
            {
                listaPacientes.Add(new cls_PacienteDTO
                {
                    id_paciente = Convert.ToInt32(row["id_paciente"]),
                    id_os = row["id_os"] as int?,
                    id_sexo = row["id_sexo"] as int?,
                    id_tipo_dni = row["id_tipo_dni"] as int?,
                    Nombre = row["nombre"].ToString(),
                    Apellido = row["apellido"].ToString(),
                    dni_titular = Convert.ToInt32(row["dni_titular"]),
                    num_afiliado = Convert.ToInt64(row["num_afiliado"]),
                    dni_paciente = Convert.ToInt32(row["dni_paciente"]),
                    fecha_nac = row["fecha_nac"] as DateTime?,
                    cud = row["cud"].ToString(),
                    diagnostico = row["diagnostico"].ToString(),
                    id_localidad = Convert.ToInt32(row["id_localidad"]),
                    domicilio = row["domicilio"].ToString(),
                    num_domicilio = Convert.ToInt32(row["num_domicilio"]),
                    cargahoraria_at = Convert.ToDecimal(row["cargahoraria_at"]),
                    telefono = Convert.ToInt32(row["telefono"]),
                    email = row["email"].ToString(),
                    esActivo = Convert.ToBoolean(row["esActivo"])
                });
            }
            return listaPacientes;
        }

        public List<cls_PacienteDTO> ObtenerPacientesInactivos()
        {
            string sql = "[dbo].[ObtenerPacientesInactivos]";

            DataTable dt = _ejecutar.ConsultaReadSP(sql, null);
            List<cls_PacienteDTO> listaPacientes = new List<cls_PacienteDTO>();

            foreach (DataRow row in dt.Rows)
            {
                listaPacientes.Add(new cls_PacienteDTO
                {
                    id_paciente = Convert.ToInt32(row["id_paciente"]),
                    id_os = row["id_os"] as int?,
                    id_sexo = row["id_sexo"] as int?,
                    id_tipo_dni = row["id_tipo_dni"] as int?,
                    Nombre = row["nombre"].ToString(),
                    Apellido = row["apellido"].ToString(),
                    dni_titular = Convert.ToInt32(row["dni_titular"]),
                    num_afiliado = Convert.ToInt64(row["num_afiliado"]),
                    dni_paciente = Convert.ToInt32(row["dni_paciente"]),
                    fecha_nac = row["fecha_nac"] as DateTime?,
                    cud = row["cud"].ToString(),
                    diagnostico = row["diagnostico"].ToString(),
                    id_localidad = Convert.ToInt32(row["id_localidad"]),
                    domicilio = row["domicilio"].ToString(),
                    num_domicilio = Convert.ToInt32(row["num_domicilio"]),
                    cargahoraria_at = Convert.ToDecimal(row["cargahoraria_at"]),
                    telefono = Convert.ToInt32(row["telefono"]),
                    email = row["email"].ToString(),
                    esActivo = Convert.ToBoolean(row["esActivo"])
                });
            }
            return listaPacientes;
        }
        public List<cls_PacienteDTO> ObtenerPacientes()
        {
            string sql = "[dbo].[ObtenerTodosLosPacientes]";

            DataTable dt = _ejecutar.ConsultaReadSP(sql, null);
            List<cls_PacienteDTO> listaPacientes = new List<cls_PacienteDTO>();

            foreach (DataRow row in dt.Rows)
            {
                listaPacientes.Add(new cls_PacienteDTO
                {
                    id_paciente = Convert.ToInt32(row["id_paciente"]),
                    id_os = row["id_os"] as int?,
                    id_sexo = row["id_sexo"] as int?,
                    id_tipo_dni = row["id_tipo_dni"] as int?,
                    Nombre = row["nombre"].ToString(),
                    Apellido = row["apellido"].ToString(),
                    dni_titular = Convert.ToInt32(row["dni_titular"]),
                    num_afiliado = Convert.ToInt64(row["num_afiliado"]),
                    dni_paciente = Convert.ToInt32(row["dni_paciente"]),
                    fecha_nac = row["fecha_nac"] as DateTime?,
                    cud = row["cud"].ToString(),
                    diagnostico = row["diagnostico"].ToString(),
                    id_localidad = Convert.ToInt32(row["id_localidad"]),
                    domicilio = row["domicilio"].ToString(),
                    num_domicilio = Convert.ToInt32(row["num_domicilio"]),
                    cargahoraria_at = Convert.ToDecimal(row["cargahoraria_at"]),
                    telefono = Convert.ToInt32(row["telefono"]),
                    email = row["email"].ToString(),
                    esActivo = Convert.ToBoolean(row["esActivo"])
                });
            }
            return listaPacientes;
        }

        public void AgregarPaciente(cls_PacienteDTO paciente)
        {
            string nombreStoredProcedure = "[dbo].[AgregarPaciente]";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@id_os", (object)paciente.id_os ?? DBNull.Value),
                new SqlParameter("@nombre", paciente.Nombre),
                new SqlParameter("@apellido", paciente.Apellido),
                new SqlParameter("@dni_titular", paciente.dni_titular),
                new SqlParameter("@num_afiliado", paciente.num_afiliado),
                new SqlParameter("@dni_paciente", paciente.dni_paciente),
                new SqlParameter("@fecha_nac", (object)paciente.fecha_nac ?? DBNull.Value),
                new SqlParameter("@cud", paciente.cud),
                new SqlParameter("@diagnostico", paciente.diagnostico),
                new SqlParameter("@id_localidad", paciente.id_localidad),
                new SqlParameter("@domicilio", paciente.domicilio),
                new SqlParameter("@num_domicilio", paciente.num_domicilio),
                new SqlParameter("@cargahoraria_at", paciente.cargahoraria_at),
                new SqlParameter("@telefono", paciente.telefono),
                new SqlParameter("@email", paciente.email),
                new SqlParameter("@id_tipo_dni", paciente.id_tipo_dni),
                new SqlParameter("@id_sexo", paciente.id_sexo)
            };

            _ejecutar.ConsultaWriteSP(nombreStoredProcedure, parametros);
        }
        public bool ModificarPaciente(cls_PacienteDTO paciente)
        {
            string sqlUpdate = "[dbo].[ModificarPaciente]";

                var parametros = new List<SqlParameter>
            {

                new SqlParameter("@id_os", (object)paciente.id_os ?? DBNull.Value),
                new SqlParameter("@nombre", paciente.Nombre),
                new SqlParameter("@apellido", paciente.Apellido),
                new SqlParameter("@dni_titular", paciente.dni_titular),
                new SqlParameter("@num_afiliado", paciente.num_afiliado),
                new SqlParameter("@dni_paciente", paciente.dni_paciente),
                new SqlParameter("@fecha_nac", (object)paciente.fecha_nac ?? DBNull.Value),
                new SqlParameter("@cud", paciente.cud),
                new SqlParameter("@diagnostico", paciente.diagnostico),
                new SqlParameter("@id_localidad", paciente.id_localidad),
                new SqlParameter("@domicilio", paciente.domicilio),
                new SqlParameter("@num_domicilio", paciente.num_domicilio),
                new SqlParameter("@cargahoraria_at", paciente.cargahoraria_at),
                new SqlParameter("@telefono", paciente.telefono),
                new SqlParameter("@email", paciente.email),
                new SqlParameter("@id_tipo_dni", paciente.id_tipo_dni),
                new SqlParameter("@id_sexo", paciente.id_sexo),
                new SqlParameter("@id_paciente", paciente.id_paciente)
            };
            try
            {
                _ejecutar.ConsultaWriteSP(sqlUpdate, parametros);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar Paciente usando cls_EjecutarQ: {ex.Message}");
                return false;
            }

        }

        public void EliminarPaciente(int idPaciente)
        {
            string sqlBajaLogica = "[dbo].[EliminarPaciente]";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@id_paciente", idPaciente)
            };

            _ejecutar.ConsultaWriteSP(sqlBajaLogica, parametros);
        }

        public void ReactivarPaciente(int idPaciente)
        {
            string sqlAltaLogica = "[dbo].[ReactivarPaciente]";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@id_paciente", idPaciente)
            };
            _ejecutar.ConsultaWriteSP(sqlAltaLogica, parametros);
        }

        public cls_PacienteDTO BuscarPacientePorDni(int dni)
        {
            string query = "[dbo].[BuscarPacientePorDni]";

            var parametros = new List<SqlParameter>
    {
        new SqlParameter("@dni_paciente", dni)
    };

            DataTable tabla = _ejecutar.ConsultaReadSP(query, parametros);

            if (tabla.Rows.Count > 0)
            {
                DataRow row = tabla.Rows[0];

                // Mapea la fila a un DTO (cls_PacienteDTO)
                var paciente = new cls_PacienteDTO
                {

                    id_paciente = Convert.ToInt32(row["id_paciente"]),
                    id_os = row["id_os"] as int?,
                    id_sexo = row["id_sexo"] as int?,
                    id_tipo_dni = row["id_tipo_dni"] as int?,
                    Nombre = row["nombre"].ToString(),
                    Apellido = row["apellido"].ToString(),
                    dni_titular = Convert.ToInt32(row["dni_titular"]),
                    num_afiliado = Convert.ToInt64(row["num_afiliado"]),
                    dni_paciente = Convert.ToInt32(row["dni_paciente"]),
                    fecha_nac = row["fecha_nac"] as DateTime?,
                    cud = row["cud"].ToString(),
                    diagnostico = row["diagnostico"].ToString(),
                    id_localidad = Convert.ToInt32(row["id_localidad"]),
                    domicilio = row["domicilio"].ToString(),
                    num_domicilio = Convert.ToInt32(row["num_domicilio"]),
                    cargahoraria_at = Convert.ToDecimal(row["cargahoraria_at"]),
                    telefono = Convert.ToInt32(row["telefono"]),
                    email = row["email"].ToString(),
                    esActivo = Convert.ToBoolean(row["esActivo"])
                };
                return paciente;
            }

            // Si no se encontró el paciente
            return null;
        }

        public bool VerificarDniExistente(int dni)
        {
            string query = "[dbo].[VerificarDniExistentePacientes]";

            var parametros = new List<SqlParameter>
        {
            new SqlParameter("@Dni", dni)
        };

            try
            {
                object resultado = _ejecutar.ExecuteScalarSP(query, parametros);
                int count = resultado != null && resultado != DBNull.Value ? Convert.ToInt32(resultado) : 0;
                return count > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en VerificarDniExistente: {ex.Message}");
                return false;
            }
        }
    }
}