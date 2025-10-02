using CapaLogica.LlenarCombos;
using CapaLogica.CapaLogica;
using System;
using CapaDTO.SistemaDTO;
using System.Collections.Generic; // Necesario para usar List
using System.Drawing;
using System.Windows.Forms;
using CapaLogica.CapaLogica.Tramites;

namespace CapaVistas.Forms_Menu // O el namespace que estés usando
{
    public partial class frmGestionTramites : Form
    {
        private cls_LlenarCombos _rellenador;
        private cls_TramitesLogica _logicaTramites = new cls_TramitesLogica();
        private List<cls_Tramite_PacienteDTO> _tramitesCargados = new List<cls_Tramite_PacienteDTO>();
        private cls_PacienteDTO _paciente = new cls_PacienteDTO();
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;


        public frmGestionTramites()
        {
            InitializeComponent();
            
            CargarCombos();
            mthFechas.Visible = false;
            mthFechas.SelectionStart = DateTime.Today.AddMonths(-1);
            mthFechas.SelectionEnd = DateTime.Today;


        }

        // --- LÓGICA PARA ARRASTRAR EL FORMULARIO ---
        private void panelTopBar_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void panelTopBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private void panelTopBar_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // --- LÓGICA DE LA APLICACIÓN ---

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = txtBuscarPaciente.Text.Trim();
            if (string.IsNullOrWhiteSpace(busqueda) && !mthFechas.Visible)
            {
                MessageBox.Show("Debe ingresar un DNI/apellido o seleccionar un rango de fechas.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ocultar el MonthCalendar
            mthFechas.Visible = false;

            // Obtener el rango de fechas
            DateTime? fechaInicio = mthFechas.SelectionStart.Date;
            DateTime? fechaFin = mthFechas.SelectionEnd.Date.AddDays(1).AddSeconds(-1); // Fin del día

            try
            {
                // ** Llama a la lógica para buscar trámites reales **
                _tramitesCargados = _logicaTramites.BuscarTramites(busqueda, fechaInicio, fechaFin);

                lbTramites.Items.Clear();
                pnlChat.Controls.Clear();
                lblEstadoActual.Text = "Seleccione un trámite...";
                lblEstadoActual.BackColor = Color.Gray;

                if (_tramitesCargados != null && _tramitesCargados.Count > 0)
                {
                    foreach (var tramite in _tramitesCargados)
                    {
                        // Agregamos una descripción útil al ListBox
                        lbTramites.Items.Add(tramite.Descripcion);
                    }
                    // Opcional: Seleccionar el primer elemento automáticamente
                    // lbTramites.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("No se encontraron trámites para los criterios de búsqueda.", "Búsqueda Sin Resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar la búsqueda: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbTramites_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbTramites.SelectedIndex < 0 || _tramitesCargados == null || _tramitesCargados.Count == 0) return;

            // Obtenemos el DTO del trámite seleccionado
            var tramiteSeleccionadoDTO = _tramitesCargados[lbTramites.SelectedIndex];

            // Usamos el ID del trámite real
            int idTramiteSeleccionado = tramiteSeleccionadoDTO.IdTramite;
            string descripcionTramite = tramiteSeleccionadoDTO.Descripcion;

            lblTramiteSeleccionado.Text = $"Historial del Trámite: {descripcionTramite}";
            pnlChat.Controls.Clear(); // Limpiamos el chat anterior

            try
            {
                // ** Llama a la lógica para obtener el historial real **
                var historial = _logicaTramites.ObtenerHistorialTramite(idTramiteSeleccionado);

                // Actualizar el estado actual y color (usando el último estado del historial, o el que viene en el DTO)
                string estadoActual = tramiteSeleccionadoDTO.EstadoActual; // O puedes obtenerlo del último registro del historial

                lblEstadoActual.Text = estadoActual;
                AsignarColorEstado(estadoActual);

                foreach (var evento in historial)
                {
                    string tipo = evento.EsCambioDeEstado ? "Estado" : "Comentario";
                    string texto = evento.EsCambioDeEstado ? $"El estado cambió a: \"{evento.NuevoEstado}\"" : evento.Comentario;

                    AgregarMensaje(evento.FechaHora.ToString("dd/MM/yyyy HH:mm"), evento.Usuario, tipo, texto, false);
                }
                // Scroll al final al cargar
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
            if (lbTramites.SelectedIndex < 0 || _tramitesCargados == null || _tramitesCargados.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un trámite primero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string mensaje = txtMensaje.Text.Trim();
            if (string.IsNullOrWhiteSpace(mensaje)) return;

            int idTramite = _tramitesCargados[lbTramites.SelectedIndex].IdTramite;
            // Debes obtener el ID del usuario actual de alguna manera (p.ej. una sesión)
            int idUsuarioActual = 1; // ** REEMPLAZAR CON EL ID DE USUARIO REAL **
            string nombreUsuario = "UsuarioActual"; // ** REEMPLAZAR CON EL NOMBRE DE USUARIO REAL **

            try
            {
                // ** Llama a la lógica para guardar el comentario real **
                if (_logicaTramites.RegistrarComentario(idTramite, idUsuarioActual, mensaje))
                {
                    AgregarMensaje(DateTime.Now.ToString("dd/MM/yyyy HH:mm"), nombreUsuario, "Comentario", mensaje);
                    txtMensaje.Clear();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el comentario.", "Error de DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar el comentario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            if (lbTramites.SelectedIndex < 0 || _tramitesCargados == null || _tramitesCargados.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un trámite primero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbNuevoEstado.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un nuevo estado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Asumimos que el cmbNuevoEstado está cargado con un objeto que tiene el ID y la descripción
            // Si usas CapaUtilidades.cls_LlenarCombos.Cargar, el SelectedValue es el id_tramite
            int idNuevoEstado = (int)cmbNuevoEstado.SelectedValue;
            string nuevoEstadoDescripcion = cmbNuevoEstado.Text;
            int idTramite = _tramitesCargados[lbTramites.SelectedIndex].IdTramite;
            int idUsuarioActual = 1; // ** REEMPLAZAR CON EL ID DE USUARIO REAL **
            string nombreUsuario = _paciente.Nombre; 

            try
            {
                // ** Llama a la lógica para actualizar el estado real **
                if (_logicaTramites.RegistrarCambioEstado(idTramite, idUsuarioActual, idNuevoEstado)) // La lógica debería guardar el ID
                {
                    // Se registra el cambio en la tabla Tramite_Paciente
                    string mensajeEstado = $"El estado cambió a: \"{nuevoEstadoDescripcion}\"";
                    AgregarMensaje(DateTime.Now.ToString("dd/MM/yyyy HH:mm"), nombreUsuario, "Estado", mensajeEstado);

                    lblEstadoActual.Text = nuevoEstadoDescripcion;
                    AsignarColorEstado(nuevoEstadoDescripcion);

                    // Actualizar el DTO en memoria para reflejar el cambio
                    _tramitesCargados[lbTramites.SelectedIndex].EstadoActual = nuevoEstadoDescripcion;
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el cambio de estado.", "Error de DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cambiar el estado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AsignarColorEstado(string estado)
        {
            string e = estado.ToLower();
            if (e.Contains("vencido") || e.Contains("rechazado") || e.Contains("perdido"))
                lblEstadoActual.BackColor = Color.Crimson;
            else if (e.Contains("autorizado") || e.Contains("al dia") || e.Contains("finalizado"))
                lblEstadoActual.BackColor = Color.SeaGreen;
            else if (e.Contains("pendiente") || e.Contains("espera"))
                lblEstadoActual.BackColor = Color.Orange;
            else
                lblEstadoActual.BackColor = Color.DarkGray; // Estado por defecto
        }

        private void AgregarMensaje(string fecha, string usuario, string tipo, string texto, bool scroll = true)
        {
            // Panel contenedor para cada mensaje
            Panel pnlMensaje = new Panel
            {
                Width = pnlChat.ClientSize.Width - 25,
                Padding = new Padding(5),
                Margin = new Padding(10, 5, 10, 5)
            };

            // Etiqueta para el encabezado (Usuario y Fecha)
            Label lblHeader = new Label
            {
                Text = $"{usuario.ToUpper()} - {fecha}",
                ForeColor = Color.Aqua,
                Font = new Font("Bahnschrift", 8, FontStyle.Bold),
                Dock = DockStyle.Top
            };

            // Etiqueta para el cuerpo del mensaje
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
            // Ajustar altura después de que AutoSize=true calcule el alto de lblBody
            pnlMensaje.Height = lblBody.Height + lblHeader.Height + 10;

            // Estilo visual según el tipo de mensaje
            if (tipo == "Estado")
            {
                pnlMensaje.BackColor = Color.FromArgb(10, 90, 90);
            }
            else
            {
                pnlMensaje.BackColor = Color.FromArgb(0, 70, 70);
            }

            // Ubicación del nuevo mensaje en la parte inferior del panel
            pnlMensaje.Top = pnlChat.Controls.Count > 0
                ? pnlChat.Controls[pnlChat.Controls.Count - 1].Bottom + 5
                : 10;

            pnlChat.Controls.Add(pnlMensaje);

            // Hacer scroll automático al último mensaje
            if (scroll)
            {
                pnlChat.ScrollControlIntoView(pnlMensaje);
            }
        }

        private void CargarCombos()
        {
            _rellenador = new cls_LlenarCombos();
            // Asumiendo que ObtenerTramites() obtiene los posibles ESTADOS de trámite de la tabla Tramites
            var cargaTramites = _rellenador.ObtenerTramites();

            try
            {
                // Usamos el id_tramite como valor real y la descripcion para mostrar
                CapaUtilidades.cls_LlenarCombos.Cargar(cmbNuevoEstado, cargaTramites.Tramites, "descripcion", "id_tramite");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los ComboBoxes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- LÓGICA DE CALENDARIO (Se mantiene) ---

        private void btnFechas_Click(object sender, EventArgs e)
        {
            mthFechas.Visible = !mthFechas.Visible;
        }

        private void mthFechas_MouseLeave(object sender, EventArgs e)
        {
            // Solo ocultar si el mouse se va del control
            mthFechas.Visible = false;
        }

        // Opcional: Cerrar al seleccionar un rango
        private void mthFechas_DateSelected(object sender, DateRangeEventArgs e)
        {
            // Puedes actualizar una etiqueta con el rango y ocultarlo
            // lblRangoFechas.Text = $"{e.Start.ToShortDateString()} - {e.End.ToShortDateString()}";
            // mthFechas.Visible = false;
        }
    }
}