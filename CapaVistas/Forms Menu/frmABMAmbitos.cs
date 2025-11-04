using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapaVistas.Forms_Menu // O tu namespace
{
    public partial class frmABMAmbitos : Form
    {
        // Variables para poder arrastrar el formulario sin borde
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public frmABMAmbitos()
        {
            InitializeComponent();
        }

        private void frmABMAmbitos_Load(object sender, EventArgs e)
        {
            CargarAmbitos();
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void CargarAmbitos()
        {
            // AQUÍ: Harías la consulta a tu base de datos
            // SELECT Nombre FROM Ambitos ORDER BY Nombre

            // --- Simulación de datos ---
            lbAmbitos.Items.Clear();
            lbAmbitos.Items.Add("Hogar");
            lbAmbitos.Items.Add("Escuela");
            lbAmbitos.Items.Add("Consultorio");
            lbAmbitos.Items.Add("Externo");
            // --- Fin Simulación ---

            txtNombreAmbito.Clear();
            lbAmbitos.ClearSelected();
        }

        private void lbAmbitos_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Al seleccionar un item de la lista, se carga en el TextBox
            if (lbAmbitos.SelectedItem != null)
            {
                txtNombreAmbito.Text = lbAmbitos.SelectedItem.ToString();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreAmbito.Text))
            {
                MessageBox.Show("Debe ingresar un nombre.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // AQUÍ: Harías el INSERT en tu DB
            // INSERT INTO Ambitos (Nombre) VALUES (@nombre)
            MessageBox.Show($"Ámbito '{txtNombreAmbito.Text}' agregado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CargarAmbitos(); // Recargamos la lista
            this.DialogResult = DialogResult.OK; // Avisa al form padre que hubo un cambio
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (lbAmbitos.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un ámbito de la lista para modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombreAmbito.Text))
            {
                MessageBox.Show("El nombre no puede estar vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombreViejo = lbAmbitos.SelectedItem.ToString();
            string nombreNuevo = txtNombreAmbito.Text;

            // AQUÍ: Harías el UPDATE en tu DB
            // UPDATE Ambitos SET Nombre = @nombreNuevo WHERE Nombre = @nombreViejo
            MessageBox.Show($"Ámbito '{nombreViejo}' actualizado a '{nombreNuevo}' con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CargarAmbitos(); // Recargamos la lista
            this.DialogResult = DialogResult.OK; // Avisa al form padre que hubo un cambio
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (lbAmbitos.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un ámbito de la lista para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ambitoEliminar = lbAmbitos.SelectedItem.ToString();

            if (MessageBox.Show($"¿Está seguro que desea eliminar el ámbito '{ambitoEliminar}'?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // AQUÍ: Harías el DELETE en tu DB
                // DELETE FROM Ambitos WHERE Nombre = @ambitoEliminar
                MessageBox.Show($"Ámbito '{ambitoEliminar}' eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarAmbitos(); // Recargamos la lista
                this.DialogResult = DialogResult.OK; // Avisa al form padre que hubo un cambio
            }
        }
    }
}