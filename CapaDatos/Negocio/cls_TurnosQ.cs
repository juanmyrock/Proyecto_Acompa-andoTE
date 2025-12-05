using CapaDatos;
using CapaDTO.SistemaDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaLogica.Negocio
{
    public class cls_TurnosQ
    {
        private cls_EjecutarQ _ejecutarQ;

        public cls_TurnosQ()
        {
            _ejecutarQ = new cls_EjecutarQ();
        }

        // Buscar turnos por profesional y fecha
        public List<cls_TurnosDTO> BuscarTurnos(int idProfesional, DateTime fecha)
        {
            try
            {
                DateTime fechaInicio = fecha.Date;
                DateTime fechaFin = fecha.Date.AddDays(1);

                string query = @"
                    SELECT 
                        T.id_turno,
                        T.id_paciente,
                        T.id_profesional,
                        T.fecha_hora_inicio,
                        T.fecha_hora_fin,
                        T.id_estado_turno,
                        T.id_usuario_creador,
                        T.fecha_creacion,
                        T.observaciones,
                        P.nombre + ' ' + P.apellido AS nombre_paciente
                    FROM Turnos T
                    LEFT JOIN Pacientes P ON T.id_paciente = P.id_paciente
                    WHERE T.id_profesional = @id_profesional
                        AND T.fecha_hora_inicio >= @fecha_inicio
                        AND T.fecha_hora_inicio < @fecha_fin
                        AND T.id_estado_turno != 3 -- Excluir cancelados (3)
                    ORDER BY T.fecha_hora_inicio";

                var parametros = new List<SqlParameter>
                {
                    new SqlParameter("@id_profesional", idProfesional),
                    new SqlParameter("@fecha_inicio", fechaInicio),
                    new SqlParameter("@fecha_fin", fechaFin)
                };

                DataTable dt = _ejecutarQ.ConsultaRead(query, parametros);

                if (dt != null && dt.Rows.Count > 0)
                {
                    return ConvertirDataTableALista(dt);
                }

                return new List<cls_TurnosDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en BuscarTurnos: {ex.Message}");
                throw;
            }
        }

        // Crear nuevo turno
        public bool CrearTurno(cls_TurnosDTO nuevoTurno)
        {
            try
            {
                string query = @"
                    INSERT INTO Turnos (
                        id_paciente,
                        id_profesional,
                        fecha_hora_inicio,
                        fecha_hora_fin,
                        id_estado_turno,
                        id_usuario_creador,
                        fecha_creacion,
                        observaciones
                    ) VALUES (
                        @id_paciente,
                        @id_profesional,
                        @fecha_hora_inicio,
                        @fecha_hora_fin,
                        @id_estado_turno,
                        @id_usuario_creador,
                        @fecha_creacion,
                        @observaciones
                    )";

                var parametros = new List<SqlParameter>
                {
                    new SqlParameter("@id_paciente", nuevoTurno.id_paciente),
                    new SqlParameter("@id_profesional", nuevoTurno.id_profesional),
                    new SqlParameter("@fecha_hora_inicio", nuevoTurno.fecha_hora_inicio),
                    new SqlParameter("@fecha_hora_fin", nuevoTurno.fecha_hora_fin),
                    new SqlParameter("@id_estado_turno", nuevoTurno.id_estado_turno),
                    new SqlParameter("@id_usuario_creador", nuevoTurno.id_usuario_creador),
                    new SqlParameter("@fecha_creacion", nuevoTurno.fecha_creacion),
                    new SqlParameter("@observaciones", string.IsNullOrEmpty(nuevoTurno.observaciones) ?
                        DBNull.Value : (object)nuevoTurno.observaciones)
                };

                int resultado = _ejecutarQ.ConsultaCUD(query, parametros);
                return resultado > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en CrearTurno: {ex.Message}");
                throw;
            }
        }

        // Cancelar turno (cambiar estado a Cancelado)
        public bool CancelarTurno(int idTurno, int idUsuarioCancela)
        {
            try
            {
                string query = @"
                    UPDATE Turnos 
                    SET id_estado_turno = 3, -- 3 = Cancelado
                        observaciones = ISNULL(observaciones, '') + 
                            ' | Cancelado por usuario ID: ' + CAST(@id_usuario_cancela AS VARCHAR(10)) + 
                            ' el ' + CONVERT(VARCHAR(20), GETDATE(), 103)
                    WHERE id_turno = @id_turno";

                var parametros = new List<SqlParameter>
                {
                    new SqlParameter("@id_turno", idTurno),
                    new SqlParameter("@id_usuario_cancela", idUsuarioCancela)
                };

                int resultado = _ejecutarQ.ConsultaCUD(query, parametros);
                return resultado > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en CancelarTurno: {ex.Message}");
                throw;
            }
        }

        // Obtener turno por ID
        public cls_TurnosDTO ObtenerTurnoPorId(int idTurno)
        {
            try
            {
                string query = @"
                    SELECT 
                        id_turno,
                        id_paciente,
                        id_profesional,
                        fecha_hora_inicio,
                        fecha_hora_fin,
                        id_estado_turno,
                        id_usuario_creador,
                        fecha_creacion,
                        observaciones
                    FROM Turnos 
                    WHERE id_turno = @id_turno";

                var parametros = new List<SqlParameter>
                {
                    new SqlParameter("@id_turno", idTurno)
                };

                DataTable dt = _ejecutarQ.ConsultaRead(query, parametros);

                if (dt != null && dt.Rows.Count > 0)
                {
                    return ConvertirDataRowATurno(dt.Rows[0]);
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en ObtenerTurnoPorId: {ex.Message}");
                throw;
            }
        }

        // Verificar si hay turno solapado
        public bool VerificarTurnoSolapado(int idProfesional, DateTime fechaHoraInicio, DateTime fechaHoraFin, int? idTurnoExcluir = null)
        {
            try
            {
                string query = @"
                    SELECT COUNT(*) 
                    FROM Turnos 
                    WHERE id_profesional = @id_profesional
                        AND id_estado_turno != 3 -- Excluir cancelados
                        AND (
                            (@fecha_hora_inicio >= fecha_hora_inicio AND @fecha_hora_inicio < fecha_hora_fin) OR
                            (@fecha_hora_fin > fecha_hora_inicio AND @fecha_hora_fin <= fecha_hora_fin) OR
                            (@fecha_hora_inicio <= fecha_hora_inicio AND @fecha_hora_fin >= fecha_hora_fin)
                        )";

                var parametros = new List<SqlParameter>
                {
                    new SqlParameter("@id_profesional", idProfesional),
                    new SqlParameter("@fecha_hora_inicio", fechaHoraInicio),
                    new SqlParameter("@fecha_hora_fin", fechaHoraFin)
                };

                if (idTurnoExcluir.HasValue)
                {
                    query += " AND id_turno != @id_turno_excluir";
                    parametros.Add(new SqlParameter("@id_turno_excluir", idTurnoExcluir.Value));
                }

                int count = Convert.ToInt32(_ejecutarQ.ExecuteScalar(query, parametros));
                return count > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en VerificarTurnoSolapado: {ex.Message}");
                throw;
            }
        }

        // Métodos de conversión
        private List<cls_TurnosDTO> ConvertirDataTableALista(DataTable dt)
        {
            var listaTurnos = new List<cls_TurnosDTO>();

            foreach (DataRow row in dt.Rows)
            {
                listaTurnos.Add(ConvertirDataRowATurno(row));
            }

            return listaTurnos;
        }

        private cls_TurnosDTO ConvertirDataRowATurno(DataRow row)
        {
            return new cls_TurnosDTO
            {
                id_turno = row["id_turno"] != DBNull.Value ? Convert.ToInt32(row["id_turno"]) : 0,
                id_paciente = row["id_paciente"] != DBNull.Value ? Convert.ToInt32(row["id_paciente"]) : 0,
                id_profesional = row["id_profesional"] != DBNull.Value ? Convert.ToInt32(row["id_profesional"]) : 0,
                fecha_hora_inicio = row["fecha_hora_inicio"] != DBNull.Value ? Convert.ToDateTime(row["fecha_hora_inicio"]) : DateTime.MinValue,
                fecha_hora_fin = row["fecha_hora_fin"] != DBNull.Value ? Convert.ToDateTime(row["fecha_hora_fin"]) : DateTime.MinValue,
                id_estado_turno = row["id_estado_turno"] != DBNull.Value ? Convert.ToInt32(row["id_estado_turno"]) : 0,
                id_usuario_creador = row["id_usuario_creador"] != DBNull.Value ? Convert.ToInt32(row["id_usuario_creador"]) : 0,
                fecha_creacion = row["fecha_creacion"] != DBNull.Value ? Convert.ToDateTime(row["fecha_creacion"]) : DateTime.MinValue,
                observaciones = row["observaciones"]?.ToString() ?? string.Empty,
                nombre_paciente = row["nombre_paciente"]?.ToString() ?? string.Empty // Nueva propiedad
            };
        }
    }
}