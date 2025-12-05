using CapaDTO.SistemaDTO;
using CapaLogica.LlenarCombos;
using CapaLogica.SistemaLogica;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CapaVistas.Forms_Menu // O el namespace que corresponda
{
    public partial class frmGestionTurnos : Form
    {
        // --- SIMULACIÓN DE DATOS (esto vendría de tu base de datos) ---
        private cls_LogicaGestionarProfesionales _logicaProfesional;
        private List<string> medicosPorEspecialidad = new List<string>();
        private List<Tuple<string, string>> turnosOcupados = new List<Tuple<string, string>>();
        private cls_LlenarCombos _rellenador;
        public frmGestionTurnos()
        {
            InitializeComponent();
            _rellenador = new cls_LlenarCombos();
            _logicaProfesional = new cls_LogicaGestionarProfesionales();

        }

        private void frmGestionTurnos_Load(object sender, EventArgs e)
        {
            // Simula la carga de datos iniciales
           // CargarDatosDePrueba();

            // 1. Cargar Especialidades desde la Base de Datos
            // Aquí harías: SELECT * FROM Especialidades
            //cmbEspecialidad.Items.Add("Cardiología");
            //cmbEspecialidad.Items.Add("Clínica Médica");
            //cmbEspecialidad.Items.Add("Pediatría");
            
            CargarCombos();
           

        }
        private List<CapaDTO.cls_EspecialidadesDTO> _listaEspecialidades; // Usa el namespace completo

        private void CargarCombos()
        {
            var cargaEspecialidades = _rellenador.ObtenerEspecialidadesSinAcompaniante();

            try
            {
                if (cargaEspecialidades != null && cargaEspecialidades.Especialidades != null)
                {
                    // Guardar la lista para usarla después
                    _listaEspecialidades = cargaEspecialidades.Especialidades;

                    // Configurar el ComboBox correctamente
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
               
                // Método alternativo: Usando la lista guardada
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

            try
            {
                List<cls_ProfesionalDTO> listaProfesionales =
                    _logicaProfesional.ObtenerProfesionalesActivosPorEspecialidad(idEspecialidad);

                if (listaProfesionales != null && listaProfesionales.Count > 0)
                {
                    foreach (var profesional in listaProfesionales)
                    {
                        cmbProfesional.Items.Add(profesional.nombre + " " + profesional.apellido);
                    }

                    // Opcional: seleccionar el primer médico si hay solo uno
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

        // Asegúrate de que el método en tu lógica acepte el ID correcto

        // Eventos que disparan la actualización de la agenda
        private void cmbMedico_SelectedIndexChanged(object sender, EventArgs e) => CargarAgenda();
        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e) => CargarAgenda();

        private void CargarAgenda()
        {
            if (cmbProfesional.SelectedItem == null) return;

            string medico = cmbProfesional.SelectedItem.ToString();
            DateTime fecha = monthCalendar.SelectionStart;
            lblAgenda.Text = $"Agenda de {medico} - {fecha:dd/MM/yyyy}";

            dgvAgenda.Rows.Clear();
            cmbHorarios.Items.Clear();

            // 3. Generar la grilla de horarios para el profesional en la fecha seleccionada
            // Aquí deberías consultar la tabla de turnos:
            // SELECT Hora, Paciente FROM Turnos WHERE IDMedico = ... AND Fecha = ...

            // Generamos horarios cada 30 minutos de 9 a 17 hs
            for (DateTime hora = fecha.Date.AddHours(9); hora < fecha.Date.AddHours(17); hora = hora.AddMinutes(30))
            {
                string horaStr = hora.ToString("HH:mm");

                // Verificamos si el turno está ocupado (simulación)
                var turnoOcupado = turnosOcupados.Find(t => t.Item1 == horaStr);

                if (turnoOcupado != null)
                {
                    // Turno Ocupado
                    dgvAgenda.Rows.Add(horaStr, turnoOcupado.Item2, "Ocupado");
                }
                else
                {
                    // Turno Disponible
                    dgvAgenda.Rows.Add(horaStr, "", "Disponible");
                    cmbHorarios.Items.Add(horaStr); // Agregamos la hora al combo de disponibles
                }
            }

            // Colorear las filas según el estado
            foreach (DataGridViewRow row in dgvAgenda.Rows)
            {
                if (row.Cells["colEstado"].Value.ToString() == "Ocupado")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 192); // Rojo claro
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 192); // Verde claro
                }
            }
        }

        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            // 4. Buscar paciente en la base de datos por DNI
            if (string.IsNullOrWhiteSpace(txtDniPaciente.Text))
            {
                MessageBox.Show("Por favor, ingrese un DNI.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Aquí harías: SELECT Nombre, Apellido FROM Pacientes WHERE DNI = ...
            // Simulación:
            if (txtDniPaciente.Text == "41148615")
            {
                lblNombrePaciente.Text = "Sebastian Gonzalez";
            }
            else
            {
                lblNombrePaciente.Text = "(Sebastian Gonzalez)";
            }
        }

        private void btnConfirmarTurno_Click(object sender, EventArgs e)
        {
            // 5. Validar y guardar el turno en la base de datos
            if (cmbProfesional.SelectedItem == null || cmbHorarios.SelectedItem == null || lblNombrePaciente.Text.Contains("Sebastian Gonzalez") || lblNombrePaciente.Text.Contains("..."))
            {
                MessageBox.Show("Turno registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }

            string medico = cmbProfesional.SelectedItem.ToString();
            string hora = cmbHorarios.SelectedItem.ToString();
            string paciente = lblNombrePaciente.Text;
            string fecha = monthCalendar.SelectionStart.ToShortDateString();

            string mensaje = $"¿Confirma el siguiente turno?\n\n- Paciente: {paciente}\n- Médico: {medico}\n- Fecha: {fecha}\n- Hora: {hora}";

            if (MessageBox.Show(mensaje, "Confirmar Turno", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Aquí harías: INSERT INTO Turnos (IDMedico, IDPaciente, Fecha, Hora, Observaciones) VALUES (...)

                // Simulación: agregamos el turno a nuestra lista de ocupados
                turnosOcupados.Add(new Tuple<string, string>(hora, paciente));

                MessageBox.Show("Turno registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargamos la agenda para ver el cambio
                CargarAgenda();
                LimpiarCamposTurno();
            }
        }

        private void btnCancelarTurno_Click(object sender, EventArgs e)
        {
            if (dgvAgenda.SelectedRows.Count == 0 || dgvAgenda.SelectedRows[0].Cells["colEstado"].Value.ToString() == "Disponible")
            {
                MessageBox.Show("Seleccione un turno 'Ocupado' para cancelar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hora = dgvAgenda.SelectedRows[0].Cells["colHora"].Value.ToString();
            string paciente = dgvAgenda.SelectedRows[0].Cells["colPaciente"].Value.ToString();

            if (MessageBox.Show($"¿Está seguro que desea cancelar el turno de {paciente} a las {hora} hs?", "Confirmar Cancelación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // 6. Aquí harías: DELETE FROM Turnos WHERE IDMedico = ... AND Fecha = ... AND Hora = ...
                // O un UPDATE para cambiar el estado a 'Cancelado'

                // Simulación:
                turnosOcupados.RemoveAll(t => t.Item1 == hora);

                MessageBox.Show("El turno ha sido cancelado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarAgenda(); // Recargamos
            }
        }

        private void dgvAgenda_SelectionChanged(object sender, EventArgs e)
        {
            // Habilitar o deshabilitar el botón de cancelar según si el turno está ocupado
            if (dgvAgenda.SelectedRows.Count > 0 && dgvAgenda.SelectedRows[0].Cells["colEstado"].Value.ToString() == "Ocupado")
            {
                btnCancelarTurno.Enabled = true;
            }
            else
            {
                btnCancelarTurno.Enabled = false;
            }
        }

        private void LimpiarCamposTurno()
        {
            txtDniPaciente.Clear();
            lblNombrePaciente.Text = "(No seleccionado)...";
            txtObservaciones.Clear();
        }

      
    }     
}