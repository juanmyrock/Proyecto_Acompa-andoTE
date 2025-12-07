using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapaVistas.Forms_Menu
{
    public partial class frmABMAmbitos : Form
    {
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
            lbAmbitos.Items.Clear();
            lbAmbitos.Items.Add("Hogar");
            lbAmbitos.Items.Add("Escuela");
            lbAmbitos.Items.Add("Consultorio");
            lbAmbitos.Items.Add("Externo");

            txtNombreAmbito.Clear();
            lbAmbitos.ClearSelected();
        }

        private void lbAmbitos_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            MessageBox.Show($"Ámbito '{txtNombreAmbito.Text}' agregado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CargarAmbitos();
            this.DialogResult = DialogResult.OK;
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

            MessageBox.Show($"Ámbito '{nombreViejo}' actualizado a '{nombreNuevo}' con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CargarAmbitos();
            this.DialogResult = DialogResult.OK;
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
                MessageBox.Show($"Ámbito '{ambitoEliminar}' eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarAmbitos();
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}