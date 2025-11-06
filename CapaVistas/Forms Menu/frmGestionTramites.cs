using CapaDTO;           // Para EstadoTramiteDTO y cls_TramiteResumenDTO
using CapaDTO.SistemaDTO; // Para cls_HistorialDTO
using CapaLogica.CapaLogica.Tramites;
using CapaSesion.Login;
using CapaUtilidades; // Para cls_LlenarCombos
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices; // Para arrastrar la ventana (si usas panelTopBar)

namespace CapaVistas.Forms_Menu
{
    public partial class frmGestionTramites : Form
    {
        // --- Conexión a la lógica refactorizada ---
        private readonly cls_TramitesLogica _logicaTramites = new cls_TramitesLogica();

        // --- DTOs y Sesión ---
        private List<cls_TramiteResumenDTO> _tramitesCargados = new List<cls_TramiteResumenDTO>();
        private SesionUsuario _usuariologeado = SesionUsuario.Instancia;

        // --- Variables de estado del formulario ---
        private cls_TramiteResumenDTO _tramiteSeleccionado = null;
        private cls_PacienteSimpleDTO _pacienteEncontrado = null; // Para el botón "Gestionar Trámite"
        private string _dniPacienteBuscado = null;

        public frmGestionTramites()
        {
            InitializeComponent();
            CargarComboEstados(); // Carga el combo de estados (nuevo nombre)
            mthFechas.Visible = false;
            mthFechas.SelectionStart = DateTime.Today.AddMonths(-1);
            mthFechas.SelectionEnd = DateTime.Today;
        }

        #region --- Eventos Visuales  ---


        private void btnFechas_Click(object sender, EventArgs e)
        {
            mthFechas.Visible = !mthFechas.Visible;
        }

        private void mthFechas_MouseLeave(object sender, EventArgs e)
        {
            mthFechas.Visible = false;
        }

        private void mthFechas_DateSelected(object sender, DateRangeEventArgs e)
        {
            // Opcional: Ocultar al seleccionar
            // mthFechas.Visible = false;
            // O actualizar un label con el rango
        }

        #endregion

        #region --- Lógica Principal del Formulario (Refactorizada) ---

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string busquedaDNI = txtBuscarPaciente.Text.Trim();
            if (string.IsNullOrWhiteSpace(busquedaDNI))
            {
                MessageBox.Show("Debe ingresar un DNI de paciente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            mthFechas.Visible = false;
            DateTime? fechaInicio = mthFechas.SelectionStart.Date;
            DateTime? fechaFin = mthFechas.SelectionEnd.Date.AddDays(1).AddSeconds(-1);

            // Limpiamos todo antes de la búsqueda
            LimpiarSeleccion();
            _pacienteEncontrado = null; // ¡Importante!
            _dniPacienteBuscado = null;

            try
            {
                // --- PASO 1: BUSCAR Y VALIDAR EL PACIENTE ---
                // (Asumo que tienes una _logicaPacientes o puedes crearla, 
                // igual que en tu otro formulario)
                var _logicaPacientes = new CapaLogica.cls_PacienteLogica(); // O como se llame
                var pacienteEncontrado = _logicaPacientes.BuscarPaciente(busquedaDNI);

                if (pacienteEncontrado == null || pacienteEncontrado.Count == 0)
                {
                    MessageBox.Show("Paciente no encontrado con ese DNI.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // No seguimos si no hay paciente
                }

                // (Si encontrara más de uno, deberías poner un ListBox,
                // pero para trámites por DNI asumimos que es 1)
                _pacienteEncontrado = pacienteEncontrado[0];
                _dniPacienteBuscado = _pacienteEncontrado.dni_paciente; // Guardamos el DNI


                // --- PASO 2: BUSCAR LOS TRÁMITES (Sabiendo que el paciente existe) ---
                _tramitesCargados = _logicaTramites.BuscarTramites(busquedaDNI, fechaInicio, fechaFin);

                lbTramites.DataSource = _tramitesCargados;
                lbTramites.DisplayMember = "DescripcionLista";
                lbTramites.ValueMember = "id_tp";

                if (_tramitesCargados.Count == 0)
                {
                    MessageBox.Show("Paciente encontrado, pero no tiene trámites registrados.", "Búsqueda Sin Resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar la búsqueda: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _dniPacienteBuscado = null;
                _pacienteEncontrado = null;
            }
        }

        private void lbTramites_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbTramites.SelectedItem == null)
            {
                LimpiarSeleccion();
                return;
            }

            _tramiteSeleccionado = (cls_TramiteResumenDTO)lbTramites.SelectedItem;

            lblTramiteSeleccionado.Text = $"Historial: {_tramiteSeleccionado.titulo_inicial}";
            pnlChat.Controls.Clear();

            try
            {
                var historial = _logicaTramites.ObtenerHistorialTramite(_tramiteSeleccionado.id_tp);
                string estadoActual = _tramiteSeleccionado.estado_actual;
                lblEstadoActual.Text = estadoActual;
                AsignarColorEstado(estadoActual);

                foreach (var evento in historial)
                {
                    // AHORA USAMOS 'descripcion_tipo_tramite'
                    string tipo = evento.descripcion_tipo_tramite;

                    string texto = evento.es_comentario
                        ? evento.comentario
                        : tipo; // Muestra "Pago Vencido", "O.S. Autorizada"

                    AgregarMensaje(evento.fecha_hora.ToString("dd/MM/yyyy HH:mm"), evento.nombre_usuario, tipo, texto, false);
                }

                if (pnlChat.Controls.Count > 0)
                {
                    pnlChat.ScrollControlIntoView(pnlChat.Controls[pnlChat.Controls.Count - 1]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el historial del trámite: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (_tramiteSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un trámite primero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string mensaje = txtMensaje.Text.Trim();
            if (string.IsNullOrWhiteSpace(mensaje)) return;

            int id_tp = _tramiteSeleccionado.id_tp;
            int id_usuario = _usuariologeado.IdUsuario;
            string nombreUsuario = $"{_usuariologeado.NombreEmpleado} {_usuariologeado.ApellidoEmpleado}";

            try
            {
                if (_logicaTramites.RegistrarComentario(id_tp, id_usuario, mensaje))
                {
                    AgregarMensaje(DateTime.Now.ToString("dd/MM/yyyy HH:mm"), nombreUsuario, "Comentario de Usuario", mensaje);
                    txtMensaje.Clear();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el comentario.", "Error de Operación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar el comentario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            if (_tramiteSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un trámite primero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbNuevoEstado.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un tipo de evento.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idTipoTramite = (int)cmbNuevoEstado.SelectedValue;
            string descripcionEvento = cmbNuevoEstado.Text;
            int idTramiteMaestro = _tramiteSeleccionado.id_tp;
            int idUsuarioActual = _usuariologeado.IdUsuario;
            string nombreUsuario = $"{_usuariologeado.NombreEmpleado} {_usuariologeado.ApellidoEmpleado}";

            try
            {
                // Esta es la lógica nueva: SOLO registra un evento en el historial
                if (_logicaTramites.RegistrarEventoDeTipo(idTramiteMaestro, idUsuarioActual, idTipoTramite))
                {
                    AgregarMensaje(DateTime.Now.ToString("dd/MM/yyyy HH:mm"), nombreUsuario, descripcionEvento, descripcionEvento);
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el evento.", "Error de Operación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el evento: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGestionTramite_Click(object sender, EventArgs e)
        {
            // 1. Validamos contra el objeto DTO, no contra el string DNI
            if (_pacienteEncontrado == null)
            {
                MessageBox.Show("Debe buscar y encontrar un paciente (por DNI) para poder crear un trámite.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Preparamos los datos para el constructor del popup
            // (Los tomamos del DTO que guardamos al buscar)
            int idPaciente = _pacienteEncontrado.id_paciente;
            string nombrePaciente = _pacienteEncontrado.nombre_completo;

            // 3. Llamamos al formulario popup (frmABMTramites)
            // Usamos 'using' para que el formulario se destruya correctamente
            using (frmABMTramites formCrear = new frmABMTramites(idPaciente, nombrePaciente))
            {
                // 4. Lo mostramos como un diálogo (esto detiene la ejecución)
                DialogResult resultado = formCrear.ShowDialog();

                // 5. Si el usuario cerró el popup presionando "Guardar"...
                if (resultado == DialogResult.OK)
                {
                    // ...refrescamos la lista de trámites simulando
                    // un nuevo clic en el botón de búsqueda.
                    btnBuscar.PerformClick();
                }
            }
        }

        #endregion

        #region --- Métodos Auxiliares (Sin cambios de lógica) ---

        private void LimpiarSeleccion()
        {
            _tramiteSeleccionado = null;
            pnlChat.Controls.Clear();
            lblTramiteSeleccionado.Text = "Seleccione un trámite para ver";
            lblEstadoActual.Text = "Seleccione un trámite...";
            lblEstadoActual.BackColor = Color.DimGray;
        }

        private void AsignarColorEstado(string estado)
        {
            string e = estado.ToLower();
            if (e.Contains("vencido") || e.Contains("rechazado") || e.Contains("perdido") || e.Contains("cerrado"))
                lblEstadoActual.BackColor = Color.Crimson;
            else if (e.Contains("autorizado") || e.Contains("al dia") || e.Contains("finalizado") || e.Contains("asignado") || e.Contains("aprobado"))
                lblEstadoActual.BackColor = Color.SeaGreen;
            else if (e.Contains("pendiente") || e.Contains("espera") || e.Contains("abierto"))
                lblEstadoActual.BackColor = Color.Orange;
            else
                lblEstadoActual.BackColor = Color.DarkGray;
        }

        private void AgregarMensaje(string fecha, string usuario, string tipo, string texto, bool scroll = true)
        {
            Panel pnlMensaje = new Panel
            {
                Width = pnlChat.ClientSize.Width - 25,
                Padding = new Padding(5),
                Margin = new Padding(10, 5, 10, 5)
            };
            Label lblHeader = new Label
            {
                Text = $"{usuario.ToUpper()} - {fecha}",
                ForeColor = Color.Aqua,
                Font = new Font("Bahnschrift", 8, FontStyle.Bold),
                Dock = DockStyle.Top
            };
            Label lblBody = new Label
            {
                Text = texto,
                ForeColor = Color.White,
                Font = new Font("Bahnschrift", 9.5f),
                Dock = DockStyle.Fill,
                AutoSize = true,
                MaximumSize = new Size(pnlMensaje.Width - 20, 0)
            };
            pnlMensaje.Controls.Add(lblBody);
            pnlMensaje.Controls.Add(lblHeader);
            pnlMensaje.Height = lblBody.Height + lblHeader.Height + 10;

            // Lógica de color (como la tenías antes)
            if (tipo.ToLower().Contains("comentario"))
                pnlMensaje.BackColor = Color.FromArgb(0, 70, 70);
            else
                pnlMensaje.BackColor = Color.FromArgb(10, 90, 90);

            pnlMensaje.Top = pnlChat.Controls.Count > 0
                ? pnlChat.Controls[pnlChat.Controls.Count - 1].Bottom + 5
                : 10;

            pnlChat.Controls.Add(pnlMensaje);

            if (scroll)
            {
                pnlChat.ScrollControlIntoView(pnlMensaje);
            }
        }

        // CORREGIDO: Carga los Tipos de Trámite (los eventos del chat)
        private void CargarComboEstados()
        {
            try
            {
                cls_LlenarCombos.Cargar(cmbNuevoEstado, _logicaTramites.ObtenerTiposTramite(), "descripcion", "id_tipo_tramite");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los tipos de trámite: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}