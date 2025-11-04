using CapaDTO;
using CapaDTO.SistemaDTO;
using CapaLogica.CapaLogica;
using CapaLogica.CapaLogica.Tramites;
using CapaLogica.LlenarCombos;
using CapaSesion.Login;
using System;
using System.Collections.Generic; // Necesario para usar List
using System.Drawing;
using System.Windows.Forms;

namespace CapaVistas.Forms_Menu // O el namespace que estés usando
{
    public partial class frmGestionTramites : Form
    {
        private cls_LlenarCombos _rellenador;
        private cls_TramitesLogica _logicaTramites = new cls_TramitesLogica();
        private List<cls_Tramite_PacienteDTO> _tramitesCargados = new List<cls_Tramite_PacienteDTO>();
        private SesionUsuario _usuariologeado = SesionUsuario.Instancia;
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

            var tramiteSeleccionadoDTO = _tramitesCargados[lbTramites.SelectedIndex];

            
            int idTramiteSeleccionado = tramiteSeleccionadoDTO.id_tp;  
            string descripcionTramite = tramiteSeleccionadoDTO.Descripcion;

            lblTramiteSeleccionado.Text = $"Historial del Trámite: {descripcionTramite}";
            pnlChat.Controls.Clear();

            try
            {
                var historial = _logicaTramites.ObtenerHistorialTramite(idTramiteSeleccionado);

              
                string estadoActual = tramiteSeleccionadoDTO.EstadoActual; 
                lblEstadoActual.Text = estadoActual;
                
                AsignarColorEstado(estadoActual);

                foreach (var evento in historial)
                {
                    string tipo = evento.EsCambioDeEstado ? "Estado" : "Comentario";  // CAMBIAR ESTO
                    string texto = evento.EsCambioDeEstado ? $"El estado cambió a: \"{evento.NuevoEstado}\"" : evento.Comentario;

                    AgregarMensaje(evento.FechaHora.ToString("dd/MM/yyyy HH:mm"), evento.Usuario, tipo, texto, false);
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
            if (lbTramites.SelectedIndex < 0 || _tramitesCargados == null || _tramitesCargados.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un trámite primero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string mensaje = txtMensaje.Text.Trim();
            if (string.IsNullOrWhiteSpace(mensaje)) return;

            // CORREGIDO: Usar id_tp que es el identificador único
            int id_tp = _tramitesCargados[lbTramites.SelectedIndex].id_tp;
            int id_usuario = _usuariologeado.IdUsuario;
            string nombreUsuario = _usuariologeado.NombreEmpleado + " " + _usuariologeado.ApellidoEmpleado;

            // DEBUG TEMPORAL
            MessageBox.Show($"DEBUG Enviar: id_tp={id_tp}, id_usuario={id_usuario}, mensaje={mensaje}");

            try
            {
                if (_logicaTramites.RegistrarComentario(id_tp, id_usuario, mensaje))
                {
                    AgregarMensaje(DateTime.Now.ToString("dd/MM/yyyy HH:mm"), nombreUsuario, "Comentario", mensaje);
                    txtMensaje.Clear();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el comentario. Verifique el ID de Trámite y Usuario.", "Error de Operación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            int idNuevoEstado = (int)cmbNuevoEstado.SelectedValue;
            string nuevoEstadoDescripcion = cmbNuevoEstado.Text;

            int idTramiteMaestro = _tramitesCargados[lbTramites.SelectedIndex].id_tp;
            int idUsuarioActual = _usuariologeado.IdUsuario;
            string nombreUsuario = _usuariologeado.NombreEmpleado + " " + _usuariologeado.ApellidoEmpleado;

            try
            {
                if (_logicaTramites.RegistrarCambioEstado(idTramiteMaestro, idUsuarioActual, idNuevoEstado))
                {
                    string mensajeEstado = $"El estado cambió a: \"{nuevoEstadoDescripcion}\"";
                    AgregarMensaje(DateTime.Now.ToString("dd/MM/yyyy HH:mm"), nombreUsuario, "Estado", mensajeEstado);

                    lblEstadoActual.Text = nuevoEstadoDescripcion;
                    AsignarColorEstado(nuevoEstadoDescripcion);

                    _tramitesCargados[lbTramites.SelectedIndex].EstadoActual = nuevoEstadoDescripcion;
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el cambio de estado. Verifique el ID de Trámite y Usuario.", "Error de Operación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            else if (e.Contains("autorizado") || e.Contains("al dia") || e.Contains("finalizado") || e.Contains("asignado"))
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

        private void btnGestionTramite_Click(object sender, EventArgs e)
        {
            // 1. Primero, asegúrate de tener un paciente seleccionado
            // (Supongo que tienes estas variables después de buscar un paciente)
            int idPacienteSeleccionado = 123; // Reemplaza esto con el ID real
            string nombrePaciente = "González, Juan"; // Reemplaza esto con el nombre real

            if (idPacienteSeleccionado == 0)
            {
                MessageBox.Show("Debe seleccionar un paciente para poder crear un trámite.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Llamamos al nuevo formulario pasándole los datos
            frmABMTramites formCrear = new frmABMTramites(idPacienteSeleccionado, nombrePaciente);

            // 3. Lo mostramos como un diálogo
            // El programa se detiene aquí hasta que el usuario cierre el pop-up
            DialogResult resultado = formCrear.ShowDialog();

            // 4. (Opcional) Si el usuario presionó "Guardar" (DialogResult.OK),
            // refrescamos la lista de trámites
            if (resultado == DialogResult.OK)
            {
                // Vuelve a ejecutar la consulta que carga tu ListBox de trámites
                CargarListaDeTramites();
            }
        }

        private void CargarListaDeTramites()
        {
            // ... tu lógica para consultar la DB y llenar el ListBox ...
        }

    }
}