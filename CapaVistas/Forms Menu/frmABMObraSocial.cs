using System;
using System.Data;
using System.Windows.Forms;

namespace CapaVistas.Forms_Menu // O tu namespace
{
    public partial class frmABMObraSocial : Form
    {
        public frmABMObraSocial()
        {
            InitializeComponent();
        }

        private void frmObrasSociales_Load(object sender, EventArgs e)
        {
            // Configuración inicial
            cmbOrden.SelectedIndex = 0; // "Activas" por defecto
            CargarGrilla();
            ConfigurarEstilosGrilla();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void cmbOrden_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Filtra la grilla cuando cambia la selección
            CargarGrilla();

            // Muestra el botón de reactivar si se eligen "Inactivas"
            btnReactivar.Visible = (cmbOrden.SelectedItem.ToString() == "Inactivas");
        }

        private void btnBuscarOS_Click(object sender, EventArgs e)
        {
            // AQUÍ: Lógica para buscar por Nombre o CUIT
            MessageBox.Show("Lógica de búsqueda no implementada.");
            CargarGrilla(); // Simula recarga
        }

        private void CargarGrilla()
        {
            // AQUÍ: Harías tu consulta a la DB
            // string filtroEstado = cmbOrden.SelectedItem.ToString();
            // SELECT id_obra_social, nombre_os, codigo, cuit, domicilio, num_domicilio, telefono, estado 
            // FROM Obras_Sociales WHERE estado = @filtroEstado ...

            // --- Simulación de datos ---
            DataTable dt = new DataTable();
            dt.Columns.Add("id_obra_social", typeof(int));
            dt.Columns.Add("nombre_os", typeof(string));
            dt.Columns.Add("codigo", typeof(int));
            dt.Columns.Add("cuit", typeof(long)); // Usamos long para CUIT
            dt.Columns.Add("domicilio", typeof(string));
            dt.Columns.Add("num_domicilio", typeof(int));
            dt.Columns.Add("telefono", typeof(string));
            dt.Columns.Add("estado", typeof(bool));

            // Añadir filas de ejemplo
            if (cmbOrden.SelectedItem.ToString() != "Inactivas")
            {
                dt.Rows.Add(1, "OSDE", 326, 30500090909, "Av. Corrientes", 450, "0810-555-6733", true);
                dt.Rows.Add(2, "Swiss Medical", 220, 30692138760, "Av. Santa Fe", 1200, "0810-444-7700", true);
            }
            if (cmbOrden.SelectedItem.ToString() != "Activas")
            {
                dt.Rows.Add(3, "Medicus (Baja)", 115, 30546633333, "Av. Callao", 900, "0800-333-6334", false);
            }
            // --- Fin Simulación ---

            dgvObrasSociales.DataSource = dt;
        }

        private void ConfigurarEstilosGrilla()
        {
            // Similar al estilo de frmProfesionales
            dgvObrasSociales.BackgroundColor = System.Drawing.Color.FromArgb(0, 50, 50);
            dgvObrasSociales.GridColor = System.Drawing.Color.Teal;
            dgvObrasSociales.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(0, 64, 64);
            dgvObrasSociales.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgvObrasSociales.DefaultCellStyle.Font = new System.Drawing.Font("Bahnschrift", 9F);
            dgvObrasSociales.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(0, 90, 90);
            dgvObrasSociales.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgvObrasSociales.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Bold);
            dgvObrasSociales.EnableHeadersVisualStyles = false;
            dgvObrasSociales.RowHeadersVisible = false;
            dgvObrasSociales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvObrasSociales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Ocultar columnas que no se deben editar manualmente
            dgvObrasSociales.Columns["id_obra_social"].Visible = false;
            dgvObrasSociales.Columns["estado"].Visible = false;
        }

        private void dgvObrasSociales_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvObrasSociales.SelectedRows.Count > 0)
            {
                CargarCamposDesdeGrilla();
            }
        }

        private void CargarCamposDesdeGrilla()
        {
            DataGridViewRow fila = dgvObrasSociales.SelectedRows[0];
            txtNombreOS.Text = fila.Cells["nombre_os"].Value.ToString();
            txtCodigo.Text = fila.Cells["codigo"].Value.ToString();
            txtCuit.Text = fila.Cells["cuit"].Value.ToString();
            txtDomicilio.Text = fila.Cells["domicilio"].Value.ToString();
            txtNumDomicilio.Text = fila.Cells["num_domicilio"].Value.ToString();
            txtTelefono.Text = fila.Cells["telefono"].Value.ToString();
        }

        private void LimpiarCampos()
        {
            txtNombreOS.Clear();
            txtCodigo.Clear();
            txtCuit.Clear();
            txtDomicilio.Clear();
            txtNumDomicilio.Clear();
            txtTelefono.Clear();
            dgvObrasSociales.ClearSelection();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            // AQUÍ: Validar campos
            if (string.IsNullOrWhiteSpace(txtNombreOS.Text))
            {
                MessageBox.Show("El campo 'Nombre O.S.' es obligatorio.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // AQUÍ: Lógica para INSERT en la DB
            // INSERT INTO Obras_Sociales (nombre_os, codigo, cuit, domicilio, num_domicilio, telefono, estado, fecha_alta)
            // VALUES (@nombre, @codigo, @cuit, @domicilio, @num, @tel, 1, GETDATE())

            MessageBox.Show("Obra Social creada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarGrilla();
            LimpiarCampos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvObrasSociales.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una obra social de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idSeleccionado = Convert.ToInt32(dgvObrasSociales.SelectedRows[0].Cells["id_obra_social"].Value);

            // AQUÍ: Lógica para UPDATE en la DB
            // UPDATE Obras_Sociales SET nombre_os = @nombre, codigo = @codigo, cuit = @cuit, 
            // domicilio = @domicilio, num_domicilio = @num, telefono = @tel
            // WHERE id_obra_social = @idSeleccionado

            MessageBox.Show("Obra Social modificada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarGrilla();
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvObrasSociales.SelectedRows.Count == 0 || cmbOrden.SelectedItem.ToString() == "Inactivas")
            {
                MessageBox.Show("Debe seleccionar una obra social 'Activa' para dar de baja.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idSeleccionado = Convert.ToInt32(dgvObrasSociales.SelectedRows[0].Cells["id_obra_social"].Value);
            string nombre = dgvObrasSociales.SelectedRows[0].Cells["nombre_os"].Value.ToString();

            if (MessageBox.Show($"¿Está seguro que desea dar de baja la obra social '{nombre}'?", "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // AQUÍ: Lógica para BAJA (lógica, no física)
                // UPDATE Obras_Sociales SET estado = 0, fecha_baja = GETDATE()
                // WHERE id_obra_social = @idSeleccionado

                MessageBox.Show("Obra Social dada de baja con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrilla();
                LimpiarCampos();
            }
        }

        private void btnReactivar_Click(object sender, EventArgs e)
        {
            if (dgvObrasSociales.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una obra social 'Inactiva' para reactivar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idSeleccionado = Convert.ToInt32(dgvObrasSociales.SelectedRows[0].Cells["id_obra_social"].Value);
            string nombre = dgvObrasSociales.SelectedRows[0].Cells["nombre_os"].Value.ToString();

            if (MessageBox.Show($"¿Está seguro que desea reactivar la obra social '{nombre}'?", "Confirmar Reactivación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // AQUÍ: Lógica para REACTIVAR
                // UPDATE Obras_Sociales SET estado = 1, fecha_baja = NULL
                // WHERE id_obra_social = @idSeleccionado

                MessageBox.Show("Obra Social reactivada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrilla();
                LimpiarCampos();
            }
        }
    }
}