using CapaDTO;
using CapaDTO.SistemaDTO;
using CapaLogica; // O CapaLogica.Negocio, tu namespace
using CapaLogica.Negocio;
using CapaSesion.Login;
using CapaUtilidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CapaVistas.Forms_Menu
{
    public partial class frmAsignacionAT : Form
    {

        private readonly cls_LogicaAsignacionAT _logica;
        private cls_PacienteSimpleDTO _pacienteSeleccionado;
        private AcompanamientoDTO _asignacionSeleccionada;

      
        private List<AcompanamientoHorarioDTO> _horariosNuevosParaGuardar;


        private List<AcompanamientoHorarioDTO> _horariosExistentes;

        private enum ModoFormulario
        {
            Inicial,
            PacienteEncontrado,
            ModoCreacion,
            ModoEdicion
        }
        private ModoFormulario _modoActual;

        public frmAsignacionAT()
        {
            InitializeComponent();
            _logica = new cls_LogicaAsignacionAT();
            _horariosNuevosParaGuardar = new List<AcompanamientoHorarioDTO>();
        }

        private void frmAsignarAT_Load(object sender, EventArgs e)
        {
            ConfigurarControlesVisuales();
            CargarCombosIniciales();
            SetearModoFormulario(ModoFormulario.Inicial);
        }

        #region --- 1. Configuración Inicial y Carga de Combos ---

        private void ConfigurarControlesVisuales()
        {
            // ... (tu código de timeInicio y timeFin) ...
            timeInicio.Format = DateTimePickerFormat.Custom; timeInicio.CustomFormat = "HH:mm";
            timeInicio.ShowUpDown = true; timeInicio.Value = DateTime.Today.AddHours(9);
            timeFin.Format = DateTimePickerFormat.Custom; timeFin.CustomFormat = "HH:mm";
            timeFin.ShowUpDown = true; timeFin.Value = DateTime.Today.AddHours(10);

            dgvHorarios.AutoGenerateColumns = false;
            dgvHorarios.Columns.Clear();
            dgvHorarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "dia_semana", HeaderText = "Día" });
            dgvHorarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "HoraInicioStr", HeaderText = "Hora Inicio" });
            dgvHorarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "HoraFinStr", HeaderText = "Hora Fin" });

            lbResultadosBusqueda.Visible = false;
            lbAsignacionesExistentes.Visible = false;
        }

        private void CargarCombosIniciales()
        {
            try
            {
                cls_LlenarCombos.Cargar(cmbAmbito, _logica.ObtenerAmbitos(), "descripcion", "id_ambito");
                cls_LlenarCombos.Cargar(cmbProfesional, _logica.ObtenerAcompanantes(), "ApeNom", "id_profesional");
                cls_LlenarCombos.Cargar(cmbJornada, _logica.ObtenerJornadas(), "descripcion", "id_jornada");
                cmbDiaSemana.Items.AddRange(new object[] { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo" });
                cmbDiaSemana.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos iniciales: " + ex.Message, "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetearModoFormulario(ModoFormulario modo)
        {
            _modoActual = modo;

            // Apagamos todo por defecto
            gbBuscarAsignacion.Enabled = false;
            btnNuevaAsignacion.Enabled = false; 
            gbDetalles.Enabled = false;
            gbDefinirHorario.Enabled = false;
            gbHorariosAsignados.Enabled = false;
            btnGuardarAsignacion.Enabled = false;
            lbAsignacionesExistentes.Visible = false;

            // Botones de horario
            btnAgregarHorario.Enabled = false;
            btnActualizarHorario.Enabled = false;

            switch (modo)
            {
                case ModoFormulario.Inicial:
                    break;
                case ModoFormulario.PacienteEncontrado:
                    gbBuscarAsignacion.Enabled = true;
                    btnNuevaAsignacion.Enabled = true; 
                    break;
                case ModoFormulario.ModoCreacion:
                    gbDetalles.Enabled = true;
                    gbDefinirHorario.Enabled = true;
                    gbHorariosAsignados.Enabled = true;
                    btnGuardarAsignacion.Enabled = true;
                    btnAgregarHorario.Enabled = true; 
                    break;
                case ModoFormulario.ModoEdicion:
                    gbDetalles.Enabled = true; 
                    gbDefinirHorario.Enabled = true;
                    gbHorariosAsignados.Enabled = true;
                    btnAgregarHorario.Enabled = true; 
                    break;
            }
        }

        #endregion

        #region --- 2. Flujo Principal: Buscar-o-Crear ---

        // PASO 1: Buscar Paciente
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = txtBuscarPaciente.Text.Trim();
            if (string.IsNullOrWhiteSpace(busqueda)) return;

            LimpiarFormulario(false);
            SetearModoFormulario(ModoFormulario.Inicial);

            try
            {
                List<cls_PacienteSimpleDTO> listaPacientes = _logica.BuscarPaciente(busqueda);

                if (listaPacientes == null || listaPacientes.Count == 0)
                {
                    lblPacienteSeleccionado.Text = "Busque un paciente...";
                    MessageBox.Show("Paciente no encontrado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (listaPacientes.Count == 1)
                {
                    SeleccionarPaciente(listaPacientes[0]);
                }
                else
                {
                    lblPacienteSeleccionado.Text = "¡Se encontraron varios! Seleccione uno de la lista:";
                    lbResultadosBusqueda.DataSource = listaPacientes;
                    lbResultadosBusqueda.DisplayMember = "nombre_completo";
                    lbResultadosBusqueda.ValueMember = "id_paciente";
                    lbResultadosBusqueda.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar el paciente: " + ex.Message, "Error de Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbResultadosBusqueda_Click(object sender, EventArgs e)
        {
            if (lbResultadosBusqueda.SelectedItem == null) return;
            var paciente = (cls_PacienteSimpleDTO)lbResultadosBusqueda.SelectedItem;
            SeleccionarPaciente(paciente);
        }

        private void SeleccionarPaciente(cls_PacienteSimpleDTO paciente)
        {
            _pacienteSeleccionado = paciente;
            lblPacienteSeleccionado.Text = $"{_pacienteSeleccionado.nombre_completo} (DNI: {_pacienteSeleccionado.dni_paciente})";
            lbResultadosBusqueda.Visible = false;
            SetearModoFormulario(ModoFormulario.PacienteEncontrado);
        }

        // PASO 1.5: Botón para "Crear Nueva" (Soluciona tu Problema 1)
        private void btnNuevaAsignacion_Click(object sender, EventArgs e)
        {
            // Limpia la parte de asignación y entra en Modo Creación
            LimpiarSeccionAsignacion();
            SetearModoFormulario(ModoFormulario.ModoCreacion);
        }

        // PASO 2: Buscar Asignaciones Existentes
        private void btnBuscarAsignacion_Click(object sender, EventArgs e)
        {
            if (_pacienteSeleccionado == null)
            {
                MessageBox.Show("Primero debe seleccionar un paciente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                List<AcompanamientoResumenDTO> asignaciones = _logica.ObtenerAsignacionesPorPaciente(_pacienteSeleccionado.id_paciente);

                if (asignaciones == null || asignaciones.Count == 0)
                {
                    MessageBox.Show("El paciente no tiene asignaciones activas. Puede crear una nueva.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarSeccionAsignacion(); // Limpia por si acaso
                    SetearModoFormulario(ModoFormulario.ModoCreacion);
                }
                else
                {
                    lbAsignacionesExistentes.DataSource = asignaciones;
                    lbAsignacionesExistentes.DisplayMember = "InfoCompleta";
                    lbAsignacionesExistentes.ValueMember = "id_acompanamiento";
                    lbAsignacionesExistentes.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar asignaciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // PASO 3: Seleccionar Asignación Existente
        private void lbAsignacionesExistentes_Click(object sender, EventArgs e)
        {
            if (lbAsignacionesExistentes.SelectedItem == null) return;
            var resumen = (AcompanamientoResumenDTO)lbAsignacionesExistentes.SelectedItem;

            try
            {
                _asignacionSeleccionada = _logica.ObtenerAcompanamientoPorId(resumen.id_acompanamiento);
                _horariosExistentes = _logica.ObtenerHorariosPorAsignacion(resumen.id_acompanamiento);

                // Autocompletar campos
                cmbAmbito.SelectedValue = _asignacionSeleccionada.id_ambito;
                cmbProfesional.SelectedValue = _asignacionSeleccionada.id_profesional;
                cmbJornada.SelectedValue = _asignacionSeleccionada.id_jornada;

                // Cargar Grilla
                dgvHorarios.DataSource = _horariosExistentes;

                SetearModoFormulario(ModoFormulario.ModoEdicion);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el detalle: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region --- 3. Lógica de Horarios (Crear y Editar) ---

        // PASO 4: Carga Inversa (Seleccionar Fila para Editar)
        private void dgvHorarios_SelectionChanged(object sender, EventArgs e)
        {
            if (_modoActual == ModoFormulario.ModoEdicion && dgvHorarios.SelectedRows.Count > 0)
            {
                var horarioDTO = (AcompanamientoHorarioDTO)dgvHorarios.SelectedRows[0].DataBoundItem;
                if (horarioDTO == null) return;

                // Carga inversa
                cmbDiaSemana.SelectedItem = horarioDTO.dia_semana;
                timeInicio.Value = DateTime.Today.Add(horarioDTO.hora_inicio);
                timeFin.Value = DateTime.Today.Add(horarioDTO.hora_fin);

                // Habilitamos el botón de actualizar
                btnActualizarHorario.Enabled = true;
            }
            else if (_modoActual == ModoFormulario.ModoEdicion)
            {
                // Si no hay fila seleccionada, deshabilitamos el botón
                btnActualizarHorario.Enabled = false;
            }
        }

        // Botón 1: Agregar Horario
        private void btnAgregarHorario_Click(object sender, EventArgs e)
        {
            if (timeInicio.Value >= timeFin.Value)
            {
                MessageBox.Show("La hora de inicio no puede ser mayor o igual a la hora de fin.", "Error de Horario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var nuevoHorario = new AcompanamientoHorarioDTO
            {
                dia_semana = cmbDiaSemana.SelectedItem.ToString(),
                hora_inicio = timeInicio.Value.TimeOfDay,
                hora_fin = timeFin.Value.TimeOfDay
            };

            if (_modoActual == ModoFormulario.ModoCreacion)
            {
                _horariosNuevosParaGuardar.Add(nuevoHorario);
                dgvHorarios.Rows.Add(nuevoHorario.dia_semana, nuevoHorario.HoraInicioStr, nuevoHorario.HoraFinStr);
            }
            else if (_modoActual == ModoFormulario.ModoEdicion)
            {
                try
                {
                    _logica.AgregarNuevoHorario(_asignacionSeleccionada.id_acompanamiento, nuevoHorario);

                    dgvHorarios.DataSource = null;
                    _horariosExistentes = _logica.ObtenerHorariosPorAsignacion(_asignacionSeleccionada.id_acompanamiento);
                    dgvHorarios.DataSource = _horariosExistentes;
                    MessageBox.Show("Nuevo horario agregado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar el nuevo horario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Botón 2: Actualizar Horario
        private void btnActualizarHorario_Click(object sender, EventArgs e)
        {
            if (_modoActual != ModoFormulario.ModoEdicion || dgvHorarios.SelectedRows.Count == 0) return;

            if (timeInicio.Value >= timeFin.Value)
            {
                MessageBox.Show("La hora de inicio no puede ser mayor o igual a la hora de fin.", "Error de Horario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var horarioDTO = (AcompanamientoHorarioDTO)dgvHorarios.SelectedRows[0].DataBoundItem;

                horarioDTO.dia_semana = cmbDiaSemana.SelectedItem.ToString();
                horarioDTO.hora_inicio = timeInicio.Value.TimeOfDay;
                horarioDTO.hora_fin = timeFin.Value.TimeOfDay;

                _logica.ActualizarHorario(horarioDTO);

                dgvHorarios.Refresh(); // Refresca la grilla para mostrar el cambio
                MessageBox.Show("Horario actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el horario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarHorario_Click(object sender, EventArgs e)
        {
           
        }

        #endregion

        #region --- 4. Guardado y Cierre ---

        private void btnGuardarAsignacion_Click(object sender, EventArgs e)
        {
            if (_modoActual != ModoFormulario.ModoCreacion) return;

            if (_pacienteSeleccionado == null || cmbAmbito.SelectedValue == null ||
                cmbProfesional.SelectedValue == null || cmbJornada.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar Paciente, Ámbito, Profesional y Jornada.", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_horariosNuevosParaGuardar.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un rango horario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var dto = new AcompanamientoDTO
                {
                    id_paciente = _pacienteSeleccionado.id_paciente,
                    id_profesional = (int)cmbProfesional.SelectedValue,
                    id_ambito = (int)cmbAmbito.SelectedValue,
                    id_jornada = (int)cmbJornada.SelectedValue,
                    id_usuario_creador = SesionUsuario.Instancia.IdUsuario,
                    id_estado_acompanamiento = 1,
                    horarios = _horariosNuevosParaGuardar
                };

                if (_logica.GuardarAsignacionCompleta(dto))
                {
                    MessageBox.Show("¡Asignación guardada con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la asignación: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario(bool limpiarPaciente)
        {
            if (limpiarPaciente)
            {
                _pacienteSeleccionado = null;
                lblPacienteSeleccionado.Text = "Busque un paciente...";
                txtBuscarPaciente.Clear();
            }
            LimpiarSeccionAsignacion();
            SetearModoFormulario(ModoFormulario.Inicial);
        }

       
        private void LimpiarSeccionAsignacion()
        {
            _asignacionSeleccionada = null;
            lbAsignacionesExistentes.DataSource = null;
            lbAsignacionesExistentes.Visible = false;

            cmbAmbito.SelectedIndex = -1;
            cmbProfesional.SelectedIndex = -1;
            cmbJornada.SelectedIndex = -1;
            cmbDiaSemana.SelectedIndex = 0;

            dgvHorarios.DataSource = null;
            dgvHorarios.Rows.Clear();
            _horariosNuevosParaGuardar.Clear();
            _horariosExistentes = null;
        }

        private void btnAmbitos_Click(object sender, EventArgs e)
        {
            frmABMAmbitos formAmbitos = new frmABMAmbitos();
            DialogResult resultado = formAmbitos.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CargarComboAmbitos();
            }
        }
        private void CargarComboAmbitos()
        {
            object seleccionActual = cmbAmbito.SelectedItem;

            cmbAmbito.Items.Clear();

            cmbAmbito.Items.Add("Ámbito Clínico");
            cmbAmbito.Items.Add("Ámbito Comunitario");
            cmbAmbito.Items.Add("Ámbito Domiciliario");
            cmbAmbito.Items.Add("Ámbito Escolar");
            cmbAmbito.Items.Add("Ámbito Particular");


            if (seleccionActual != null && cmbAmbito.Items.Contains(seleccionActual))
            {
                cmbAmbito.SelectedItem = seleccionActual;
            }
        }

    }

    #endregion
}