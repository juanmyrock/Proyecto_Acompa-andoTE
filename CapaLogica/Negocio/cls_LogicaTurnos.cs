using CapaDTO.SistemaDTO;
using CapaLogica.Negocio;
using System;
using System.Collections.Generic;

namespace CapaLogica.SistemaLogica
{
    public class cls_LogicaTurnos
    {
        private cls_TurnosQ _turnosQ;

        public cls_LogicaTurnos()
        {
            _turnosQ = new cls_TurnosQ();
        }

        // Buscar turnos
        public List<cls_TurnosDTO> BuscarTurnos(int idProfesional, DateTime fecha)
        {
            try
            {
                return _turnosQ.BuscarTurnos(idProfesional, fecha);
            }
            catch (Exception ex)
            {
                // Aquí puedes agregar logging, notificaciones, etc.
                throw new Exception($"Error en lógica al buscar turnos: {ex.Message}", ex);
            }
        }

        // Crear nuevo turno con validaciones
        public cls_ResponseDTO CrearTurno(cls_TurnosDTO turno)
        {
            var response = new cls_ResponseDTO();

            try
            {
                // Validaciones
                if (turno.id_profesional <= 0)
                {
                    response.EsExitoso = false;
                    response.Mensaje = "Debe seleccionar un profesional válido";
                    return response;
                }

                if (turno.id_paciente <= 0)
                {
                    response.EsExitoso = false;
                    response.Mensaje = "Debe seleccionar un paciente válido";
                    return response;
                }

                if (turno.fecha_hora_inicio >= turno.fecha_hora_fin)
                {
                    response.EsExitoso = false;
                    response.Mensaje = "La hora de inicio debe ser anterior a la hora de fin";
                    return response;
                }

                // Verificar si no hay turnos solapados
                bool existeSolapamiento = _turnosQ.VerificarTurnoSolapado(
                    turno.id_profesional,
                    turno.fecha_hora_inicio,
                    turno.fecha_hora_fin);

                if (existeSolapamiento)
                {
                    response.EsExitoso = false;
                    response.Mensaje = "Ya existe un turno en ese horario para este profesional";
                    return response;
                }

                // Asignar valores por defecto si no están establecidos
                if (turno.id_estado_turno == 0)
                    turno.id_estado_turno = 1; // 1 = Pendiente/Confirmado

                if (turno.fecha_creacion == DateTime.MinValue)
                    turno.fecha_creacion = DateTime.Now;

                // Crear el turno
                bool resultado = _turnosQ.CrearTurno(turno);

                if (resultado)
                {
                    response.EsExitoso = true;
                    response.Mensaje = "Turno creado exitosamente";
                }
                else
                {
                    response.EsExitoso = false;
                    response.Mensaje = "No se pudo crear el turno";
                }
            }
            catch (Exception ex)
            {
                response.EsExitoso = false;
                response.Mensaje = $"Error al crear turno: {ex.Message}";
            }

            return response;
        }

        // Cancelar turno
        public cls_ResponseDTO CancelarTurno(int idTurno, int idUsuarioCancela)
        {
            var response = new cls_ResponseDTO();

            try
            {
                // Obtener el turno primero para validar
                var turno = _turnosQ.ObtenerTurnoPorId(idTurno);

                if (turno == null)
                {
                    response.EsExitoso = false;
                    response.Mensaje = "El turno no existe";
                    return response;
                }

                if (turno.id_estado_turno == 3) // Ya está cancelado
                {
                    response.EsExitoso = false;
                    response.Mensaje = "El turno ya está cancelado";
                    return response;
                }

                // Verificar si no es muy tarde para cancelar (ej: menos de 24 horas antes)
                if (turno.fecha_hora_inicio.AddHours(-24) < DateTime.Now)
                {
                    // Aquí podrías agregar lógica para penalizaciones
                }

                bool resultado = _turnosQ.CancelarTurno(idTurno, idUsuarioCancela);

                if (resultado)
                {
                    response.EsExitoso = true;
                    response.Mensaje = "Turno cancelado exitosamente";
                }
                else
                {
                    response.EsExitoso = false;
                    response.Mensaje = "No se pudo cancelar el turno";
                }
            }
            catch (Exception ex)
            {
                response.EsExitoso = false;
                response.Mensaje = $"Error al cancelar turno: {ex.Message}";
            }

            return response;
        }

        // Obtener turno por ID
        public cls_TurnosDTO ObtenerTurnoPorId(int idTurno)
        {
            try
            {
                return _turnosQ.ObtenerTurnoPorId(idTurno);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en lógica al obtener turno: {ex.Message}", ex);
            }
        }

        // Clase para respuesta estandarizada
        public class cls_ResponseDTO
        {
            public bool EsExitoso { get; set; }
            public string Mensaje { get; set; }
            public object Data { get; set; }
        }
    }
}