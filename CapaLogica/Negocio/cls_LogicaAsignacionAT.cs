using CapaDatos;
using CapaDTO;
using CapaDTO.SistemaDTO;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace CapaLogica.Negocio
{
    public class cls_LogicaAsignacionAT
    {
        // Instancia de la capa de datos
        private readonly cls_AsignacionATQ _datos;

        public cls_LogicaAsignacionAT()
        {
            _datos = new cls_AsignacionATQ();
        }

        // --- MÉTODOS DE LECTURA (Pasamanos) ---
        // Estos métodos simplemente llaman a la capa de datos.

        public List<AmbitoDTO> ObtenerAmbitos()
        {
            return _datos.ObtenerAmbitos();
        }

        public List<JornadaATDTO> ObtenerJornadas()
        {
            return _datos.ObtenerJornadas();
        }

        public List<ProfesionalSimpleDTO> ObtenerAcompanantes()
        {
            return _datos.ObtenerAcompanantes();
        }

        public List<cls_PacienteSimpleDTO> BuscarPaciente(string busqueda)
        {
            return _datos.BuscarPaciente(busqueda);
        }

        public List<AcompanamientoResumenDTO> ObtenerAsignacionesPorPaciente(int id_paciente)
        {
            return _datos.ObtenerAsignacionesPorPaciente(id_paciente);
        }

        public AcompanamientoDTO ObtenerAcompanamientoPorId(int id_acompanamiento)
        {
            return _datos.ObtenerAcompanamientoPorId(id_acompanamiento);
        }

        public List<AcompanamientoHorarioDTO> ObtenerHorariosPorAsignacion(int id_acompanamiento)
        {
            return _datos.ObtenerHorariosPorAsignacion(id_acompanamiento);
        }

        // --- MÉTODOS DE ESCRITURA (CON LÓGICA) ---

        // Guarda la asignación completa (encabezado y horarios) dentro de una transacción.
        public bool GuardarAsignacionCompleta(AcompanamientoDTO dto)
        {
            // 1. Validaciones de negocio
            if (dto.id_paciente <= 0 || dto.id_profesional <= 0 || dto.id_ambito <= 0 || dto.id_jornada <= 0 || dto.id_usuario_creador <= 0)
                throw new Exception("Los datos principales (Paciente, Profesional, Ámbito, Jornada) son obligatorios.");

            if (dto.horarios == null || dto.horarios.Count == 0)
                throw new Exception("Debe agregar al menos un rango horario.");

            // 2. Lógica Transaccional
            try
            {
                // Inicia el bloque transaccional.
                using (var scope = new TransactionScope())
                {
                    // 2.1. Inserta el encabezado y obtiene el nuevo ID
                    int nuevoAcompanamientoID = _datos.InsertarAcompanamiento(dto);

                    if (nuevoAcompanamientoID <= 0)
                    {
                        throw new Exception("No se pudo obtener el ID de la nueva asignación.");
                    }

                    // 2.2. Inserta cada uno de los horarios (detalle)
                    foreach (var horario in dto.horarios)
                    {
                        // Le pasamos el nuevo ID para vincular el horario
                        _datos.InsertarHorario(nuevoAcompanamientoID, horario);
                    }

                    // 2.3. Si llegamos aquí, todo salió bien.
                    // "Completamos" la transacción para confirmar los cambios.
                    scope.Complete();
                    return true;
                }
            }
            catch (Exception ex)
            {
                // Si algo falló (en el INSERT 1 o en CUALQUIER INSERT de los horarios),
                // TransactionScope automáticamente hará un Rollback (deshacer todo).
                throw new Exception("Error al guardar la asignación: " + ex.Message);
            }
        }

        // Actualiza un horario específico.
        public void ActualizarHorario(AcompanamientoHorarioDTO horario)
        {
            if (horario.id_horario <= 0)
            {
                throw new Exception("No se puede actualizar un horario sin un ID válido.");
            }
            // Aquí podrías agregar más validaciones (ej. que hora_fin > hora_inicio)

            _datos.ActualizarHorario(horario);
        }
        // Agrega un horario
        public AcompanamientoHorarioDTO AgregarNuevoHorario(int id_acompanamiento, AcompanamientoHorarioDTO nuevoHorario)
        {
            // 1. Validar (ej. que la hora no se superponga, si quieres)
            if (nuevoHorario.hora_fin <= nuevoHorario.hora_inicio)
            {
                throw new Exception("La hora de fin debe ser mayor a la hora de inicio.");
            }

            // 2. Insertar en la BD
            // Asumiremos que InsertarHorario ahora devuelve el ID del horario nuevo
            // O que podemos re-consultar. Por simplicidad, solo insertamos.
            _datos.InsertarHorario(id_acompanamiento, nuevoHorario);

            // 3. Devolvemos el DTO (en un caso real, lo re-consultaríamos para obtener el nuevo ID)
            // Por ahora, solo confirmamos la operación.
            return nuevoHorario;
        }


    }
}