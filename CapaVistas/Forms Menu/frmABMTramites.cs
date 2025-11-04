using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapaVistas.Forms_Menu // O tu namespace
{
    public partial class frmABMTramites : Form
    {
        // Variables para poder arrastrar el formulario sin borde
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        // Variables del trámite
        private int idPaciente;

        // Constructor: Le pasamos los datos del paciente
        public frmABMTramites(int idPaciente, string nombrePaciente)
        {
            InitializeComponent();
            this.idPaciente = idPaciente;
            lblPacienteNombre.Text = $"Para: {nombrePaciente}";
        }

        private void frmNuevoTramite_Load(object sender, EventArgs e)
        {
            // Configuramos los valores por defecto
            dateCreacion.Value = DateTime.Now;
            dateCreacion.Enabled = false; // El usuario no debe cambiarla
            cmbEstado.SelectedIndex = 0; // Por defecto "Abierto"
        }

        // --- LÓGICA PARA ARRASTRAR EL FORMULARIO ---
        private void frm_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void frm_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private void frm_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        // --- LÓGICA DE CONTROLES ---
        private void lblClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTituloTramite.Text))
            {
                MessageBox.Show("Debe ingresar un título para el trámite.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Obtenemos los datos
            string titulo = txtTituloTramite.Text;
            DateTime fecha = dateCreacion.Value;
            string estado = cmbEstado.SelectedItem.ToString();

            // 2. AQUÍ: Ejecutarías el INSERT en tu base de datos
            // INSERT INTO Tramites (id_paciente, titulo_tramite, fecha_creacion, estado) 
            // VALUES (this.idPaciente, @titulo, @fecha, @estado)
            //
            // (Asegúrate de que los nombres de las columnas coincidan con tu tabla)

            MessageBox.Show($"Trámite '{titulo}' creado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 3. Avisamos al formulario padre que se creó
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}