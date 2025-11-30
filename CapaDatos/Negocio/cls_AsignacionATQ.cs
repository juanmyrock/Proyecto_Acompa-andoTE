using CapaDTO;
using CapaDTO.SistemaDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class cls_AsignacionATQ
    {
        private readonly cls_EjecutarQ _ejecutar = new cls_EjecutarQ();


        public List<AmbitoDTO> ObtenerAmbitos()
        {
            string sql = "SELECT id_ambito, descripcion FROM Ambitos ORDER BY descripcion";
            DataTable tabla = _ejecutar.ConsultaRead(sql, null);

            var lista = new List<AmbitoDTO>();
            foreach (DataRow row in tabla.Rows)
            {
                lista.Add(new AmbitoDTO
                {
                    id_ambito = Convert.ToInt32(row["id_ambito"]),
                    descripcion = row["descripcion"].ToString()
                });
            }
            return lista;
        }
        public List<JornadaATDTO> ObtenerJornadas()
        {
            string sql = "SELECT id_jornada, descripcion FROM Jornadas_AT ORDER BY id_jornada";
            DataTable tabla = _ejecutar.ConsultaRead(sql, null);

            var lista = new List<JornadaATDTO>();
            foreach (DataRow row in tabla.Rows)
            {
                lista.Add(new JornadaATDTO
                {
                    id_jornada = Convert.ToInt32(row["id_jornada"]),
                    descripcion = row["descripcion"].ToString()
                });
            }
            return lista;
        }

        public List<ProfesionalSimpleDTO> ObtenerAcompanantes()
        {
            string sql = @"
                SELECT p.id_profesional, p.apellido + ', ' + p.nombre AS ApeNom 
                FROM Profesionales p
                INNER JOIN Especialidad e ON p.id_especialidad = e.id_especialidad
                WHERE e.especialidad = @nombreEspecialidad AND p.es_activo = 1
                ORDER BY p.apellido, p.nombre";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@nombreEspecialidad", "Acompañante Terapeutico")
            };

            DataTable tabla = _ejecutar.ConsultaRead(sql, parametros);

            var lista = new List<ProfesionalSimpleDTO>();
            foreach (DataRow row in tabla.Rows)
            {
                lista.Add(new ProfesionalSimpleDTO
                {
                    id_profesional = Convert.ToInt32(row["id_profesional"]),
                    ApeNom = row["ApeNom"].ToString()
                });
            }
            return lista;
        }


        // Busca pacientes por DNI (1 resultado) o Apellido (múltiples resultados).
        public List<cls_PacienteSimpleDTO> BuscarPaciente(string busqueda)
        {
            string sql;
            var parametros = new List<SqlParameter>();

            var listaPacientes = new List<cls_PacienteSimpleDTO>();

            if (Int64.TryParse(busqueda, out long dni))
            {
                // SI ES DNI: Busca 1 solo
                sql = @"
                    SELECT id_paciente, apellido + ', ' + nombre AS nombre_completo, dni_paciente 
                    FROM Pacientes 
                    WHERE dni_paciente = @dni AND esActivo = 1";

                parametros.Add(new SqlParameter("@dni", dni));
            }
            else
            {
                // SI ES APELLIDO: Busca TODOS los que coincidan (quitamos TOP 1)
                sql = @"
                    SELECT id_paciente, apellido + ', ' + nombre AS nombre_completo, dni_paciente 
                    FROM Pacientes 
                    WHERE apellido LIKE @apellido AND esActivo = 1
                    ORDER BY apellido, nombre";

                parametros.Add(new SqlParameter("@apellido", busqueda + "%"));
            }

            DataTable tabla = _ejecutar.ConsultaRead(sql, parametros);

            foreach (DataRow row in tabla.Rows)
            {
                // Creamos un objeto Paciente Simple por CADA fila
                var paciente = new cls_PacienteSimpleDTO
                {
                    id_paciente = Convert.ToInt32(row["id_paciente"]),
                    nombre_completo = row["nombre_completo"].ToString(),
                    dni_paciente = row["dni_paciente"].ToString()
                };

                // Agregamos el paciente a la lista
                listaPacientes.Add(paciente);
            }

            // Devolvemos la lista (puede tener 0, 1 o muchos pacientes)
            return listaPacientes;
        }



        // Busca las asignaciones existentes de un paciente para el ListBox.
        public List<AcompanamientoResumenDTO> ObtenerAsignacionesPorPaciente(int id_paciente)
        {
            string sql = @"
                SELECT 
                    a.id_acompanamiento, 
                    am.descripcion as descripcion_ambito, 
                    p.apellido + ', ' + p.nombre as nombre_profesional, 
                    p.num_matricula as matricula_profesional
                FROM Acompanamientos a
                INNER JOIN Profesionales p ON a.id_profesional = p.id_profesional
                INNER JOIN Ambitos am ON a.id_ambito = am.id_ambito
                WHERE a.id_paciente = @id_paciente AND a.fecha_fin IS NULL"; // Traemos solo los activos

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@id_paciente", id_paciente)
            };

            DataTable tabla = _ejecutar.ConsultaRead(sql, parametros);
            var lista = new List<AcompanamientoResumenDTO>();

            foreach (DataRow row in tabla.Rows)
            {
                lista.Add(new AcompanamientoResumenDTO
                {
                    id_acompanamiento = Convert.ToInt32(row["id_acompanamiento"]),
                    descripcion_ambito = row["descripcion_ambito"].ToString(),
                    nombre_profesional = row["nombre_profesional"].ToString(),
                    matricula_profesional = row["matricula_profesional"].ToString()
                });
            }
            return lista;
        }

        // Obtiene los datos de una asignación específica para autocompletar los combos.
        public AcompanamientoDTO ObtenerAcompanamientoPorId(int id_acompanamiento)
        {
            string sql = @"
                SELECT id_acompanamiento, id_profesional, id_ambito, id_jornada, id_estado_acompanamiento 
                FROM Acompanamientos 
                WHERE id_acompanamiento = @id_acompanamiento";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@id_acompanamiento", id_acompanamiento)
            };

            DataTable tabla = _ejecutar.ConsultaRead(sql, parametros);

            if (tabla.Rows.Count == 0) return null;

            DataRow row = tabla.Rows[0];
            return new AcompanamientoDTO
            {
                id_acompanamiento = Convert.ToInt32(row["id_acompanamiento"]),
                id_profesional = Convert.ToInt32(row["id_profesional"]),
                id_ambito = Convert.ToInt32(row["id_ambito"]),
                id_jornada = Convert.ToInt32(row["id_jornada"]),
                id_estado_acompanamiento = Convert.ToInt32(row["id_estado_acompanamiento"])
            };
        }

        // Obtiene los horarios de una asignación para poblar la grilla (dgvHorarios).
        public List<AcompanamientoHorarioDTO> ObtenerHorariosPorAsignacion(int id_acompanamiento)
        {
            string sql = @"
                SELECT id_horario, dia_semana, hora_inicio, hora_fin 
                FROM Acompanamiento_Horarios 
                WHERE id_acompanamiento = @id_acompanamiento
                ORDER BY CASE 
                    WHEN dia_semana = 'Lunes' THEN 1
                    WHEN dia_semana = 'Martes' THEN 2
                    WHEN dia_semana = 'Miércoles' THEN 3
                    WHEN dia_semana = 'Jueves' THEN 4
                    WHEN dia_semana = 'Viernes' THEN 5
                    WHEN dia_semana = 'Sábado' THEN 6
                    WHEN dia_semana = 'Domingo' THEN 7
                    ELSE 8 END,
                hora_inicio";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@id_acompanamiento", id_acompanamiento)
            };

            DataTable tabla = _ejecutar.ConsultaRead(sql, parametros);
            var lista = new List<AcompanamientoHorarioDTO>();

            foreach (DataRow row in tabla.Rows)
            {
                lista.Add(new AcompanamientoHorarioDTO
                {
                    id_horario = Convert.ToInt32(row["id_horario"]),
                    dia_semana = row["dia_semana"].ToString(),
                    hora_inicio = (TimeSpan)row["hora_inicio"],
                    hora_fin = (TimeSpan)row["hora_fin"]
                });
            }
            return lista;
        }


        // --- MÉTODOS DE ESCRITURA

        // Inserta el registro principal en Acompañamientos y devuelve el nuevo ID.
        public int InsertarAcompanamiento(AcompanamientoDTO dto)
        {
            // Usamos 'GETDATE()' para la fecha de inicio y creación.
            // Usamos 'SCOPE_IDENTITY()' para obtener el ID recién creado.
            string sql = @"
                INSERT INTO Acompanamientos (
                    id_paciente, id_profesional, id_ambito, id_jornada, 
                    id_estado_acompanamiento, fecha_inicio, id_usuario_creador, fecha_creacion
                ) 
                VALUES (
                    @id_paciente, @id_profesional, @id_ambito, @id_jornada, 
                    @id_estado_acompanamiento, GETDATE(), @id_usuario_creador, GETDATE()
                );
                SELECT SCOPE_IDENTITY();"; // Devuelve el último ID insertado

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@id_paciente", dto.id_paciente),
                new SqlParameter("@id_profesional", dto.id_profesional),
                new SqlParameter("@id_ambito", dto.id_ambito),
                new SqlParameter("@id_jornada", dto.id_jornada),
                new SqlParameter("@id_estado_acompanamiento", dto.id_estado_acompanamiento),
                new SqlParameter("@id_usuario_creador", dto.id_usuario_creador)
            };

            DataTable tabla = _ejecutar.ConsultaRead(sql, parametros);

            // El nuevo ID estará en la primera fila, primera columna
            return Convert.ToInt32(tabla.Rows[0][0]);
        }

        // Inserta un registro de horario para un acompañamiento.
        public void InsertarHorario(int idAcompanamiento, AcompanamientoHorarioDTO horario)
        {
            string sql = @"
                INSERT INTO Acompanamiento_Horarios (
                    id_acompanamiento, dia_semana, hora_inicio, hora_fin
                ) 
                VALUES (
                    @id_acompanamiento, @dia_semana, @hora_inicio, @hora_fin
                )";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@id_acompanamiento", idAcompanamiento),
                new SqlParameter("@dia_semana", horario.dia_semana),
                new SqlParameter("@hora_inicio", horario.hora_inicio),
                new SqlParameter("@hora_fin", horario.hora_fin)
            };
            _ejecutar.ConsultaWrite(sql, parametros);
        }

        // Actualiza un horario específico en la base de datos.
        public void ActualizarHorario(AcompanamientoHorarioDTO horario)
        {
            string sql = @"
                UPDATE Acompanamiento_Horarios
                SET 
                    dia_semana = @dia_semana,
                    hora_inicio = @hora_inicio,
                    hora_fin = @hora_fin
                WHERE 
                    id_horario = @id_horario";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@id_horario", horario.id_horario),
                new SqlParameter("@dia_semana", horario.dia_semana),
                new SqlParameter("@hora_inicio", horario.hora_inicio),
                new SqlParameter("@hora_fin", horario.hora_fin)
            };

            _ejecutar.ConsultaWrite(sql, parametros);
        }
    }
}