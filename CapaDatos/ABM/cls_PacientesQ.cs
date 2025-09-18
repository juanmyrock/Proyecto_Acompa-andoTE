using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;
using CapaDTO.SistemaDTO;
using CapaDatos;
using System.Data.SqlClient;

namespace CapaDatos.ABM
{
    public class cls_PacientesQ
    {
        private readonly cls_EjecutarQ _ejecutar = new cls_EjecutarQ();

        public List<cls_PacienteDTO> ObtenerPacientesActivos()
        {
            string sql = "SELECT * FROM Pacientes WHERE esActivo = 1;";

            DataTable dt = _ejecutar.ConsultaRead(sql, null);
            List<cls_PacienteDTO> listaPacientes = new List<cls_PacienteDTO>();

            foreach (DataRow row in dt.Rows)
            {
                listaPacientes.Add(new cls_PacienteDTO
                {
                    id_paciente = Convert.ToInt32(row["id_paciente"]),
                    id_os = row["id_os"] as int?,
                    Nombre = row["nombre"].ToString(),
                    Apellido = row["apellido"].ToString(),
                    dni_titular = Convert.ToInt32(row["dni_titular"]),
                    num_afiliado = Convert.ToInt32(row["num_afiliado"]),
                    dni_paciente = Convert.ToInt32(row["dni_paciente"]),
                    fecha_nac = row["fecha_nac"] as DateTime?,
                    cud = row["cud"].ToString(),
                    //id_diagnostico = Convert.ToInt32(row["id_diagnostico"]),
                    id_localidad = Convert.ToInt32(row["id_localidad"]),
                    domicilio = row["domicilio"].ToString(),
                    num_domicilio = Convert.ToInt32(row["num_domicilio"]),
                    cargahoraria_at = Convert.ToInt32(row["cargahoraria_at"]),
                    ambito = row["ambito"].ToString(),
                    telefono = Convert.ToInt32(row["telefono"]),
                    email = row["email"].ToString(),
                    esActivo = Convert.ToBoolean(row["esActivo"])
                });
            }
            return listaPacientes;
        }

        public List<cls_PacienteDTO> ObtenerPacientes()
        {
            string sql = "SELECT * FROM Pacientes";

            DataTable dt = _ejecutar.ConsultaRead(sql, null);
            List<cls_PacienteDTO> listaPacientes = new List<cls_PacienteDTO>();

            foreach (DataRow row in dt.Rows)
            {
                listaPacientes.Add(new cls_PacienteDTO
                {
                    id_paciente = Convert.ToInt32(row["id_paciente"]),
                    id_os = row["id_os"] as int?,
                    Nombre = row["nombre"].ToString(),
                    Apellido = row["apellido"].ToString(),
                    dni_titular = Convert.ToInt32(row["dni_titular"]),
                    num_afiliado = Convert.ToInt32(row["num_afiliado"]),
                    dni_paciente = Convert.ToInt32(row["dni_paciente"]),
                    fecha_nac = row["fecha_nac"] as DateTime?,
                    cud = row["cud"].ToString(),
                    //id_diagnostico = Convert.ToInt32(row["id_diagnostico"]),
                    id_localidad = Convert.ToInt32(row["id_localidad"]),
                    domicilio = row["domicilio"].ToString(),
                    num_domicilio = Convert.ToInt32(row["num_domicilio"]),
                    cargahoraria_at = Convert.ToInt32(row["cargahoraria_at"]),
                    ambito = row["ambito"].ToString(),
                    telefono = Convert.ToInt32(row["telefono"]),
                    email = row["email"].ToString(),
                    esActivo = Convert.ToBoolean(row["esActivo"])
                });
            }
            return listaPacientes;
        }

        public void AgregarPaciente(cls_PacienteDTO paciente)
        {
            string sqlInsertar = @"
                INSERT INTO Pacientes (
                    id_os,
                    nombre,
                    apellido,
                    dni_titular,
                    num_afiliado,
                    dni_paciente,
                    fecha_nac,
                    cud,

                    id_localidad,
                    domicilio,
                    num_domicilio,
                    cargahoraria_at,
                    ambito,
                    telefono,
                    email,
                    esActivo
                ) VALUES (
                    @id_os,
                    @nombre,
                    @apellido,
                    @dni_titular,
                    @num_afiliado,
                    @dni_paciente,
                    @fecha_nac,
                    @cud,

                    @id_localidad,
                    @domicilio,
                    @num_domicilio,
                    @cargahoraria_at,
                    @ambito,
                    @telefono,
                    @email,
                    1
                );";

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
                //new SqlParameter("@id_diagnostico", paciente.id_diagnostico),
                new SqlParameter("@id_localidad", paciente.id_localidad),
                new SqlParameter("@domicilio", paciente.domicilio),
                new SqlParameter("@num_domicilio", paciente.num_domicilio),
                new SqlParameter("@cargahoraria_at", paciente.cargahoraria_at),
                new SqlParameter("@ambito", paciente.ambito),
                new SqlParameter("@telefono", paciente.telefono),
                new SqlParameter("@email", paciente.email)
            };

            _ejecutar.ConsultaWrite(sqlInsertar, parametros);
        }

        public void ModificarPaciente(cls_PacienteDTO paciente)
        {
            string sqlUpdate = @"
                UPDATE Pacientes
                SET
                    id_os = @id_os,
                    nombre = @nombre,
                    apellido = @apellido,
                    dni_titular = @dni_titular,
                    num_afiliado = @num_afiliado,
                    dni_paciente = @dni_paciente,
                    fecha_nac = @fecha_nac,
                    cud = @cud,
                    id_diagnostico = @id_diagnostico,
                    id_localidad = @id_localidad,
                    domicilio = @domicilio,
                    num_domicilio = @num_domicilio,
                    cargahoraria_at = @cargahoraria_at,
                    ambito = @ambito,
                    telefono = @telefono,
                    email = @email
                WHERE
                    id_paciente = @id_paciente;";

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
                //new SqlParameter("@id_diagnostico", paciente.id_diagnostico),
                new SqlParameter("@id_localidad", paciente.id_localidad),
                new SqlParameter("@domicilio", paciente.domicilio),
                new SqlParameter("@num_domicilio", paciente.num_domicilio),
                new SqlParameter("@cargahoraria_at", paciente.cargahoraria_at),
                new SqlParameter("@ambito", paciente.ambito),
                new SqlParameter("@telefono", paciente.telefono),
                new SqlParameter("@email", paciente.email),
                new SqlParameter("@id_paciente", paciente.id_paciente)

            };

            _ejecutar.ConsultaWrite(sqlUpdate, parametros);
        }

        public void EliminarPaciente(int idPaciente)
        {
            string sqlBajaLogica = @"
                UPDATE Pacientes
                SET
                    esActivo = 0
                WHERE
                    id_paciente = @id_paciente;";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@id_paciente", idPaciente)
            };

            _ejecutar.ConsultaWrite(sqlBajaLogica, parametros);
        }
    }
}