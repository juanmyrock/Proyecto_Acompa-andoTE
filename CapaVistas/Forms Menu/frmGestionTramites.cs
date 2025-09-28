using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic; // Necesario para usar List

namespace CapaVistas.Forms_Menu // O el namespace que estés usando
{
    public partial class frmGestionTramites : Form
    {
        // Variables para poder arrastrar el formulario sin borde
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public frmGestionTramites()
        {
            InitializeComponent();
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
            // AQUÍ: Implementarías la búsqueda de pacientes en tu DB
            // SELECT id, nombre, apellido FROM Pacientes WHERE dni = '...' OR apellido LIKE '%...%'

            // --- SIMULACIÓN PARA EL PREVIEW ---
            lbTramites.Items.Clear();
            if (!string.IsNullOrWhiteSpace(txtBuscarPaciente.Text))
            {
                MessageBox.Show($"Paciente 'GONZALEZ, MARÍA LAURA' encontrado.", "Búsqueda Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbTramites.Items.Add("TR-2025-00123 (Cardiología)");
                lbTramites.Items.Add("TR-2025-00250 (Dermatología)");
            }
            else
            {
                MessageBox.Show("Debe ingresar un DNI o apellido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lbTramites_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbTramites.SelectedItem == null) return;

            // AQUÍ: Cargarías el historial del trámite seleccionado desde la DB
            string tramiteSeleccionado = lbTramites.SelectedItem.ToString();
            lblTramiteSeleccionado.Text = $"Historial del Trámite: {tramiteSeleccionado}";

            // --- SIMULACIÓN PARA EL PREVIEW ---
            pnlChat.Controls.Clear(); // Limpiamos el chat anterior
            lblEstadoActual.Text = "Autorizacion O.S pendiente";
            lblEstadoActual.BackColor = Color.Orange;

            // Simulación de carga de historial
            var historial = new List<Tuple<string, string, string, string>>
            {
                Tuple.Create("30/08/2025 15:28", "recepcion", "Estado", "El estado cambió a: \"Pendiente a profesional\""),
                Tuple.Create("30/08/2025 15:30", "recepcion", "Comentario", "Se recibió la documentación completa del paciente."),
                Tuple.Create("01/09/2025 10:05", "admin", "Estado", "El estado cambió a: \"Autorizacion O.S pendiente\"")
            };

            foreach (var evento in historial)
            {
                // Pasamos el tipo de evento ("Estado" o "Comentario")
                AgregarMensaje(evento.Item1, evento.Item2, evento.Item3, evento.Item4, false);
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (lbTramites.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un trámite primero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtMensaje.Text)) return;

            // AQUÍ: Guardarías el nuevo comentario en la DB asociado al trámite
            AgregarMensaje(DateTime.Now.ToString("dd/MM/yyyy HH:mm"), "UsuarioActual", "Comentario", txtMensaje.Text);
            txtMensaje.Clear();
        }

        private void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            if (lbTramites.SelectedItem == null || cmbNuevoEstado.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un trámite y un nuevo estado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nuevoEstado = cmbNuevoEstado.SelectedItem.ToString();
            // AQUÍ: Actualizarías el estado del trámite en la DB
            AgregarMensaje(DateTime.Now.ToString("dd/MM/yyyy HH:mm"), "UsuarioActual", "Estado", $"El estado cambió a: \"{nuevoEstado}\"");

            lblEstadoActual.Text = nuevoEstado;
            // Podrías agregar colores según el estado
            if (nuevoEstado.Contains("vencido") || nuevoEstado.Contains("perdido"))
                lblEstadoActual.BackColor = Color.Crimson;
            else if (nuevoEstado.Contains("autorizada") || nuevoEstado.Contains("al dia"))
                lblEstadoActual.BackColor = Color.SeaGreen;
            else
                lblEstadoActual.BackColor = Color.Orange;
        }

        /// <summary>
        /// Añade un control visual al panel de chat.
        /// </summary>
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
            int top = 10;
            foreach (Control c in pnlChat.Controls)
            {
                top += c.Height + c.Margin.Bottom;
            }
            pnlMensaje.Top = top;

            pnlChat.Controls.Add(pnlMensaje);

            // Hacer scroll automático al último mensaje
            if (scroll)
            {
                pnlChat.ScrollControlIntoView(pnlMensaje);
            }
        }
    }
}