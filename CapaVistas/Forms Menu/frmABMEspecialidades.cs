using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapaVistas.Forms_Menu
{
    public partial class frmABMEspecialidades : Form
    {
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public frmABMEspecialidades()
        {
            InitializeComponent();
        }

        private void frmABMEspecialidades_Load(object sender, EventArgs e)
        {
            CargarEspecialidades();
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
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarEspecialidades()
        {

            lbEspecialidades.Items.Clear();
            lbEspecialidades.Items.Add("Cardiología");
            lbEspecialidades.Items.Add("Clínica Médica");
            lbEspecialidades.Items.Add("Dermatología");
            lbEspecialidades.Items.Add("Pediatría");
            lbEspecialidades.Items.Add("Traumatología");

            txtNombreEspecialidad.Clear();
            lbEspecialidades.ClearSelected();
        }

        private void lbEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbEspecialidades.SelectedItem != null)
            {
                txtNombreEspecialidad.Text = lbEspecialidades.SelectedItem.ToString();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreEspecialidad.Text))
            {
                MessageBox.Show("Debe ingresar un nombre.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show($"Especialidad '{txtNombreEspecialidad.Text}' agregada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CargarEspecialidades();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (lbEspecialidades.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una especialidad de la lista para modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombreEspecialidad.Text))
            {
                MessageBox.Show("El nombre no puede estar vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombreViejo = lbEspecialidades.SelectedItem.ToString();
            string nombreNuevo = txtNombreEspecialidad.Text;
            MessageBox.Show($"Especialidad '{nombreViejo}' actualizada a '{nombreNuevo}' con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CargarEspecialidades();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (lbEspecialidades.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una especialidad de la lista para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string especialidadEliminar = lbEspecialidades.SelectedItem.ToString();

            if (MessageBox.Show($"¿Está seguro que desea eliminar la especialidad '{especialidadEliminar}'?\nEsta acción no se puede deshacer.", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                MessageBox.Show($"Especialidad '{especialidadEliminar}' eliminada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarEspecialidades();
            }
        }
    }
}