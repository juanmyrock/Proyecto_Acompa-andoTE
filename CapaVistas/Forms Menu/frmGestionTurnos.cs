using CapaDTO.SistemaDTO;
using CapaLogica.LlenarCombos;
using CapaLogica.Negocio;
using CapaLogica.SistemaLogica;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CapaVistas.Forms_Menu
{
    public partial class frmGestionTurnos : Form
    {
        private cls_LogicaGestionarProfesionales _logicaProfesional;
        private cls_LogicaTurnos _logicaTurnos;
        private cls_LogicaGestionarPacientes _logicaPacientes; // Nuevo - para buscar pacientes
        private cls_LlenarCombos _rellenador;
        private List<CapaDTO.cls_EspecialidadesDTO> _listaEspecialidades;
        private List<cls_ProfesionalDTO> _listaProfesionales;
        private List<cls_TurnosDTO> _turnosActuales; // Guardar turnos actuales para referencia
        private int _idUsuarioActual = 1; // Esto debería venir de tu sistema de autenticación

        public frmGestionTurnos()
        {
            InitializeComponent();
            _rellenador = new cls_LlenarCombos();
            _logicaProfesional = new cls_LogicaGestionarProfesionales();
            _logicaTurnos = new cls_LogicaTurnos();
            _logicaPacientes = new cls_LogicaGestionarPacientes();
        }

        private void frmGestionTurnos_Load(object sender, EventArgs e)
        {
            CargarCombos();
            ConfigurarDataGridView();
        }

        private void CargarCombos()
        {
            var cargaEspecialidades = _rellenador.ObtenerEspecialidadesSinAcompaniante();

            try
            {
                if (cargaEspecialidades != null && cargaEspecialidades.Especialidades != null)
                {
                    _listaEspecialidades = cargaEspecialidades.Especialidades;

                    cmbEspecialidad.DataSource = _listaEspecialidades;
                    cmbEspecialidad.DisplayMember = "especialidad";
                    cmbEspecialidad.ValueMember = "id_especialidad";
                    cmbEspecialidad.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los ComboBoxes: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEspecialidad.SelectedIndex >= 0)
            {
                if (_listaEspecialidades != null && _listaEspecialidades.Count > cmbEspecialidad.SelectedIndex)
                {
                    int idEspecialidad = _listaEspecialidades[cmbEspecialidad.SelectedIndex].id_especialidad;
                    CargarProfesionalesPorEspecialidad(idEspecialidad);
                }
            }
        }

        private void CargarProfesionalesPorEspecialidad(int idEspecialidad)
        {
            cmbProfesional.Items.Clear();
            cmbProfesional.Text = "";
            _listaProfesionales = null; // Limpiar la lista anterior

            try
            {
                List<cls_ProfesionalDTO> listaProfesionales =
                    _logicaProfesional.ObtenerProfesionalesActivosPorEspecialidad(idEspecialidad);

                if (listaProfesionales != null && listaProfesionales.Count > 0)
                {
                    _listaProfesionales = listaProfesionales; // Guardar la lista

                    foreach (var profesional in listaProfesionales)
                    {
                        cmbProfesional.Items.Add(profesional.nombre + " " + profesional.apellido);
                    }

                    if (listaProfesionales.Count == 1)
                    {
                        cmbProfesional.SelectedIndex = 0;
                    }
                }
                else
                {
                    cmbProfesional.Items.Add("No hay profesionales disponibles");
                    cmbProfesional.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar profesionales: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarAgenda()
        {
            if (cmbProfesional.SelectedIndex < 0) return;
            if (cmbProfesional.SelectedItem?.ToString() == "No hay profesionales disponibles") return;

            int idProfesional = ObtenerIdProfesionalSeleccionado();
            if (idProfesional <= 0) return;

            DateTime fechaSeleccionada = monthCalendar.SelectionStart;

            try
            {
                // Buscar turnos
                _turnosActuales = _logicaTurnos.BuscarTurnos(idProfesional, fechaSeleccionada);

                // Limpiar controles
                dgvAgenda.Rows.Clear();
                cmbHorarios.Items.Clear();
                txtObservaciones.Clear(); // Limpiar TextBox también

                // Verificar que el DataGridView tiene columnas
                if (dgvAgenda.Columns.Count == 0)
                {
                    ConfigurarDataGridView();
                }

                // Generar horarios
                DateTime horaInicio = fechaSeleccionada.Date.AddHours(8);
                DateTime horaFin = fechaSeleccionada.Date.AddHours(18);

                for (DateTime hora = horaInicio; hora < horaFin; hora = hora.AddMinutes(30))
                {
                    string horaStr = hora.ToString("HH:mm");
                    bool horarioOcupado = false;

                    // Verificar si hay turno en este horario
                    if (_turnosActuales != null)
                    {
                        foreach (var turno in _turnosActuales)
                        {
                            if (turno.id_estado_turno != 3 &&
                                turno.fecha_hora_inicio.ToString("HH:mm") == horaStr)
                            {
                                // Usar el nombre del paciente que viene en la consulta
                                string nombrePaciente = turno.nombre_paciente;
                                if (string.IsNullOrEmpty(nombrePaciente))
                                {
                                    nombrePaciente = ObtenerNombrePaciente(turno.id_paciente);
                                }

                                // Agregar fila con observaciones
                                int rowIndex = dgvAgenda.Rows.Add();

                                dgvAgenda.Rows[rowIndex].Cells["colHora"].Value = horaStr;
                                dgvAgenda.Rows[rowIndex].Cells["colPaciente"].Value = nombrePaciente;
                                dgvAgenda.Rows[rowIndex].Cells["colEstado"].Value = "Ocupado";
                                dgvAgenda.Rows[rowIndex].Cells["colObservaciones"].Value = turno.observaciones; // OBSERVACIONES
                                dgvAgenda.Rows[rowIndex].Cells["colIdTurno"].Value = turno.id_turno;
                                dgvAgenda.Rows[rowIndex].Cells["colIdPaciente"].Value = turno.id_paciente;

                                // Colorear
                                dgvAgenda.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightCoral;

                                horarioOcupado = true;
                                break;
                            }
                        }
                    }

                    if (!horarioOcupado)
                    {
                        int rowIndex = dgvAgenda.Rows.Add();

                        dgvAgenda.Rows[rowIndex].Cells["colHora"].Value = horaStr;
                        dgvAgenda.Rows[rowIndex].Cells["colPaciente"].Value = "";
                        dgvAgenda.Rows[rowIndex].Cells["colEstado"].Value = "Disponible";
                        dgvAgenda.Rows[rowIndex].Cells["colObservaciones"].Value = ""; // Vacío para turnos disponibles
                        dgvAgenda.Rows[rowIndex].Cells["colIdTurno"].Value = 0;
                        dgvAgenda.Rows[rowIndex].Cells["colIdPaciente"].Value = 0;

                        dgvAgenda.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                        cmbHorarios.Items.Add(horaStr);
                    }
                }

                // Actualizar título
                lblAgenda.Text = $"Agenda - {cmbProfesional.SelectedItem} - {fechaSeleccionada:dd/MM/yyyy}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar agenda: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarDataGridView()
        {
            // Limpiar columnas existentes
            dgvAgenda.Columns.Clear();

            dgvAgenda.Columns.Add("colHora", "Hora");
            dgvAgenda.Columns.Add("colPaciente", "Paciente");
            dgvAgenda.Columns.Add("colEstado", "Estado");
            dgvAgenda.Columns.Add("colObservaciones", "Observaciones");
            dgvAgenda.Columns.Add("colIdTurno", "ID Turno");
            dgvAgenda.Columns.Add("colIdPaciente", "ID Paciente");

            dgvAgenda.Columns["colHora"].Width = 70;
            dgvAgenda.Columns["colPaciente"].Width = 150;
            dgvAgenda.Columns["colEstado"].Width = 80;
            dgvAgenda.Columns["colObservaciones"].Width = 200; 

            dgvAgenda.Columns["colIdTurno"].Visible = false;
            dgvAgenda.Columns["colIdPaciente"].Visible = false;

            dgvAgenda.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAgenda.AllowUserToAddRows = false;
            dgvAgenda.ReadOnly = true;
            dgvAgenda.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDniPaciente.Text))
            {
                MessageBox.Show("Por favor, ingrese un DNI.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Buscar paciente por DNI
                var paciente = _logicaPacientes.BuscarPorDNI(txtDniPaciente.Text.Trim());

                if (paciente != null)
                {
                    lblNombrePaciente.Text = $"{paciente.Nombre} {paciente.Apellido}";
                    // Guardar ID del paciente en el Tag del label o en una variable
                    lblNombrePaciente.Tag = paciente.id_paciente;
                }
                else
                {
                    lblNombrePaciente.Text = "Paciente no encontrado";
                    lblNombrePaciente.Tag = null;
                    MessageBox.Show("No se encontró ningún paciente con ese DNI.",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar paciente: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfirmarTurno_Click(object sender, EventArgs e)
        {
            // Validaciones básicas
            if (cmbProfesional.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un profesional.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbHorarios.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un horario disponible.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lblNombrePaciente.Tag == null || Convert.ToInt32(lblNombrePaciente.Tag) <= 0)
            {
                MessageBox.Show("Debe buscar y seleccionar un paciente válido.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idProfesional = ObtenerIdProfesionalSeleccionado();
                DateTime fecha = monthCalendar.SelectionStart;
                string hora = cmbHorarios.SelectedItem.ToString();
                DateTime fechaHoraTurno = fecha.Date + TimeSpan.Parse(hora);

                // Crear objeto turno
                var nuevoTurno = new cls_TurnosDTO
                {
                    id_paciente = Convert.ToInt32(lblNombrePaciente.Tag),
                    id_profesional = idProfesional,
                    fecha_hora_inicio = fechaHoraTurno,
                    fecha_hora_fin = fechaHoraTurno.AddMinutes(30), // Duración fija de 30 min
                    id_estado_turno = 1, // 1 = Confirmado
                    id_usuario_creador = _idUsuarioActual,
                    fecha_creacion = DateTime.Now,
                    observaciones = txtObservaciones.Text.Trim()
                };

                // Mostrar confirmación
                string mensaje = $"¿Confirma el siguiente turno?\n\n" +
                               $"• Paciente: {lblNombrePaciente.Text}\n" +
                               $"• Médico: {cmbProfesional.SelectedItem}\n" +
                               $"• Fecha: {fecha:dd/MM/yyyy}\n" +
                               $"• Hora: {hora}\n" +
                               $"• Duración: 30 minutos";

                if (MessageBox.Show(mensaje, "Confirmar Turno",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Crear turno usando la lógica
                    var respuesta = _logicaTurnos.CrearTurno(nuevoTurno);

                    if (respuesta.EsExitoso)
                    {
                        MessageBox.Show(respuesta.Mensaje, "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Recargar agenda y limpiar campos
                        CargarAgenda();
                        LimpiarCamposTurno();
                    }
                    else
                    {
                        MessageBox.Show(respuesta.Mensaje, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al confirmar turno: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarTurno_Click(object sender, EventArgs e)
        {
            if (dgvAgenda.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un turno para cancelar.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow filaSeleccionada = dgvAgenda.SelectedRows[0];
            string estado = filaSeleccionada.Cells["colEstado"].Value?.ToString();
            int idTurno = Convert.ToInt32(filaSeleccionada.Cells["colIdTurno"].Value);

            if (estado != "Ocupado" || idTurno <= 0)
            {
                MessageBox.Show("Seleccione un turno 'Ocupado' para cancelar.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hora = filaSeleccionada.Cells["colHora"].Value?.ToString();
            string paciente = filaSeleccionada.Cells["colPaciente"].Value?.ToString();

            string mensaje = $"¿Está seguro que desea cancelar el turno?\n\n" +
                           $"• Paciente: {paciente}\n" +
                           $"• Hora: {hora}\n\n" +
                           $"Esta acción no se puede deshacer.";

            if (MessageBox.Show(mensaje, "Confirmar Cancelación",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    // Cancelar turno usando la lógica
                    var respuesta = _logicaTurnos.CancelarTurno(idTurno, _idUsuarioActual);

                    if (respuesta.EsExitoso)
                    {
                        MessageBox.Show(respuesta.Mensaje, "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Recargar la agenda
                        CargarAgenda();
                    }
                    else
                    {
                        MessageBox.Show(respuesta.Mensaje, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cancelar turno: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string ObtenerNombrePaciente(int idPaciente)
        {
            try
            {
                // Implementar método en _logicaPacientes para obtener paciente por ID
                var paciente = _logicaPacientes.ObtenerPacientePorId(idPaciente);
                if (paciente != null)
                {
                    return $"{paciente.Nombre} {paciente.Apellido}";
                }
                return $"Paciente ID: {idPaciente}";
            }
            catch
            {
                return "Paciente no encontrado";
            }
        }

        private void LimpiarCamposTurno()
        {
            txtDniPaciente.Clear();
            lblNombrePaciente.Text = "(No seleccionado)...";
            lblNombrePaciente.Tag = null;
            txtObservaciones.Clear();
            cmbHorarios.SelectedIndex = -1;
            txtObservaciones.Clear();
        }

        // Método auxiliar para obtener ID del profesional
        private int ObtenerIdProfesionalSeleccionado()
        {
            if (cmbProfesional.SelectedIndex < 0) return 0;

            if (_listaProfesionales != null && _listaProfesionales.Count > cmbProfesional.SelectedIndex)
            {
                return _listaProfesionales[cmbProfesional.SelectedIndex].id_profesional;
            }

            return 0;
        }

        private void cmbProfesional_SelectedIndexChanged(object sender, EventArgs e) => CargarAgenda();
        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e) => CargarAgenda();


        private void dgvAgenda_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                // Habilitar/deshabilitar botón cancelar
                if (dgvAgenda.SelectedRows.Count > 0)
                {
                    string estado = dgvAgenda.SelectedRows[0].Cells["colEstado"].Value?.ToString() ?? "";
                    btnCancelarTurno.Enabled = (estado == "Ocupado");
                }
                else
                {
                    btnCancelarTurno.Enabled = false;
                }

                // Mostrar observaciones en el TextBox cuando se selecciona una fila
                if (dgvAgenda.SelectedRows.Count > 0 && dgvAgenda.CurrentRow != null)
                {
                    var observaciones = dgvAgenda.CurrentRow.Cells["colObservaciones"].Value?.ToString() ?? "";
                    txtObservaciones.Text = observaciones.ToString();

                    // También puedes mostrar más información
                    var paciente = dgvAgenda.CurrentRow.Cells["colPaciente"].Value?.ToString() ?? "";
                    var hora = dgvAgenda.CurrentRow.Cells["colHora"].Value?.ToString() ?? "";

                    if (!string.IsNullOrEmpty(paciente))
                    {
                        lblInfoSeleccion.Text = $"Turno de {paciente} a las {hora}";
                    }
                    else
                    {
                        lblInfoSeleccion.Text = $"Horario disponible: {hora}";
                    }
                }
                else
                {
                    txtObservaciones.Clear();
                    lblInfoSeleccion.Text = "Seleccione un turno";
                }
            }
            catch (Exception ex)
            {
                // Manejo silencioso para no interrumpir la experiencia
                Console.WriteLine($"Error en SelectionChanged: {ex.Message}");
            }
        }
    }
}