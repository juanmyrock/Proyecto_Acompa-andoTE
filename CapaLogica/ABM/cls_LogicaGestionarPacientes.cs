using CapaDatos.ABM;
using CapaDTO.SistemaDTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaLogica.SistemaLogica
{
    public class cls_LogicaGestionarPacientes
    {
        private cls_PacientesQ _pacientesQ;

        public cls_LogicaGestionarPacientes()
        {
            _pacientesQ = new cls_PacientesQ();
        }

        public List<cls_PacienteDTO> ObtenerPacientesActivos()
        {
            try
            {
                return _pacientesQ.ObtenerPacientesActivos();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la capa lógica al obtener pacientes: {ex.Message}");
                return new List<cls_PacienteDTO>();
            }
        }

        public List<cls_PacienteDTO> ObtenerPacientesInactivos()
        {
            try
            {
                return _pacientesQ.ObtenerPacientesInactivos();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la capa lógica al obtener pacientes: {ex.Message}");
                return new List<cls_PacienteDTO>();
            }
        }

        public List<cls_PacienteDTO> ObtenerPacientes()
        {
            try
            {
                return _pacientesQ.ObtenerPacientes();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la capa lógica al obtener pacientes: {ex.Message}");
                return new List<cls_PacienteDTO>();
            }
        }

        public bool InsertarPaciente(cls_PacienteDTO nuevoPaciente)
        {
            try
            {
                if (string.IsNullOrEmpty(nuevoPaciente.Nombre) ||
                    string.IsNullOrEmpty(nuevoPaciente.Apellido) ||
                    string.IsNullOrEmpty(nuevoPaciente.cud) ||
                    string.IsNullOrEmpty(nuevoPaciente.domicilio) ||
                    string.IsNullOrEmpty(nuevoPaciente.email))
                {
                    return false;
                }

                if (nuevoPaciente.dni_titular <= 1000000 ||
                    nuevoPaciente.num_afiliado <= 0 ||
                    nuevoPaciente.dni_paciente <= 1000000 ||
                    nuevoPaciente.num_domicilio <= 0 ||
                    nuevoPaciente.cargahoraria_at <= 0 ||
                    nuevoPaciente.telefono <= 10000000)
                {
                    return false;
                }

                if (nuevoPaciente.id_localidad <= 0)
                {
                    return false;
                }

                _pacientesQ.AgregarPaciente(nuevoPaciente);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la capa lógica al insertar paciente: {ex.Message}");
                return false;
            }
        }

        public bool ActualizarPaciente(cls_PacienteDTO pacienteModificado)
        {
            try
            {
                if (string.IsNullOrEmpty(pacienteModificado.Nombre) ||
                    string.IsNullOrEmpty(pacienteModificado.Apellido) ||
                    string.IsNullOrEmpty(pacienteModificado.cud) ||
                    string.IsNullOrEmpty(pacienteModificado.domicilio) ||
                    string.IsNullOrEmpty(pacienteModificado.email))
                {
                    return false;
                }

                if (pacienteModificado.dni_titular <= 1000000 ||
                    pacienteModificado.num_afiliado <= 0 ||
                    pacienteModificado.dni_paciente <= 1000000 ||
                    pacienteModificado.num_domicilio <= 0 ||
                    pacienteModificado.cargahoraria_at <= 0 ||
                    pacienteModificado.telefono <= 10000000)
                {
                    return false;
                }

                
                if (pacienteModificado.id_paciente <= 0)
                {
                     throw new ArgumentException("El ID del paciente no es válido.");
                }

                _pacientesQ.ModificarPaciente(pacienteModificado);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la capa lógica al actualizar paciente: {ex.Message}");
                return false;
            }
        }

        public bool EliminarPaciente(int id_paciente)
        {
            try
            {
                _pacientesQ.EliminarPaciente(id_paciente);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la capa lógica al eliminar paciente: {ex.Message}");
                return false;
            }
        }

        public bool ReactivarPaciente(int id_paciente)
        {
            try
            {
                _pacientesQ.ReactivarPaciente(id_paciente);
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error en la capa lógica al reactivar paciente: {ex.Message}");
                return false;
            }
        }

        public cls_PacienteDTO BuscarPacientePorDni(int dni)
        {
            return _pacientesQ.BuscarPacientePorDni(dni);
        }


        public bool VerificarDniExistente(int dni)
        {
            try
            {
                // Llama al método del DAO
                return _pacientesQ.VerificarDniExistente(dni);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al verificar DNI: {ex.Message}");
                return false;
            }
        }

        public cls_PacienteDTO BuscarPorDNI(string dni)
        {
            try
            {
                return _pacientesQ.BuscarPorDNI(dni);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar paciente por DNI: {ex.Message}", ex);
            }
        }

        public cls_PacienteDTO ObtenerPacientePorId(int idPaciente)
        {
            try
            {
                return _pacientesQ.ObtenerPorId(idPaciente);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener paciente por ID: {ex.Message}", ex);
            }
        }
    }
}
