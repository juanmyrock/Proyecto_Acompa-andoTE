using System;
using System.Collections.Generic;
using System.Data;
using System.Transactions;
using CapaDTO.SistemaDTO;
using CapaDatos;
using System.Data.SqlClient;

namespace CapaDatos.ABM
{
    public class cls_PacientesQ  // Nombre descriptivo para la clase
    {
        private readonly cls_EjecutarQ _ejecutar = new cls_EjecutarQ();

        public cls_PacienteDTO ActualizarPaciente(cls_PacienteDTO paciente)
        {
            using (var transaction = new TransactionScope())
            {
                try
                {
                    // 1. Verificación de concurrencia
                    string sqlVerificar = @"
                        SELECT UltimaModificacion 
                        FROM Pacientes 
                        WHERE IdPaciente = @Id AND UltimaModificacion = @UltimaMod";

                    var parametrosVerificar = new List<SqlParameter>
                    {
                        new SqlParameter("@Id", paciente.IdPaciente),
                        new SqlParameter("@UltimaMod", paciente.UltimaModificacion)
                    };

                    DataTable dt = _ejecutar.ConsultaRead(sqlVerificar, parametrosVerificar);
                    if (dt.Rows.Count == 0)
                        throw new Exception("El paciente fue modificado por otro usuario. Recargue los datos.");

                    // 2. Actualización
                    string sqlActualizar = @"
                        UPDATE Pacientes 
                        SET 
                            Nombre = @Nombre,
                            Apellido = @Apellido,
                            FechaNacimiento = @FechaNac,
                            IdObraSocial = @IdObraSocial,
                            UltimaModificacion = GETDATE()
                        WHERE IdPaciente = @Id";

                    var parametrosActualizar = new List<SqlParameter>
                    {
                        new SqlParameter("@Id", paciente.IdPaciente),
                        new SqlParameter("@Nombre", paciente.Nombre),
                        new SqlParameter("@Apellido", paciente.Apellido),
                        new SqlParameter("@FechaNac", paciente.FechaNacimiento),
                        new SqlParameter("@IdObraSocial", paciente.IdObraSocial)
                    };

                    _ejecutar.ConsultaWrite(sqlActualizar, parametrosActualizar);

                    // 3. Obtener datos actualizados
                    string sqlObtener = "SELECT * FROM Pacientes WHERE IdPaciente = @Id";
                    DataTable dtActualizado = _ejecutar.ConsultaRead(sqlObtener,
                        new List<SqlParameter> { new SqlParameter("@Id", paciente.IdPaciente) });

                    transaction.Complete();

                    // Mapear a DTO y retornar
                    if (dt.Rows.Count == 0) return null;

                    DataRow row = dt.Rows[0];
                    return new cls_PacienteDTO
                    {
                        IdPaciente = Convert.ToInt32(row["IdPaciente"]),
                        Nombre = row["Nombre"].ToString(),
                        Apellido = row["Apellido"].ToString(),
                        FechaNacimiento = Convert.ToDateTime(row["FechaNacimiento"]),
                        IdObraSocial = row["IdObraSocial"] != DBNull.Value ? Convert.ToInt32(row["IdObraSocial"]) : (int?)null,
                        UltimaModificacion = Convert.ToDateTime(row["UltimaModificacion"])
                    };
                }
                catch (Exception ex)
                {
                    // TransactionScope hará rollback automático
                    throw new Exception("Error al actualizar paciente: " + ex.Message);
                }
            }
        }
    }
}