using CapaDTO.SistemaDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using CapaLogica.ABM;

namespace CapaVistas.Forms_Menu // O tu namespace
{
    public partial class frmABMObraSocial : Form
    {
        cls_LogicaGestionarOS _obraSocial;
        private int _idObraSocialSeleccionada = -1;
        public frmABMObraSocial()
        {
            
            InitializeComponent();
            _obraSocial = new cls_LogicaGestionarOS();
            cmbOrden.SelectedIndex = 0;
           
        }

        private void frmObrasSociales_Load(object sender, EventArgs e)
        {
            CargarGrilla();
            ConfigurarEstilosGrilla();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CargarGrilla();
            LimpiarCampos();
        }

        private void cmbOrden_SelectedIndexChanged(object sender, EventArgs e)
        {

            string filtroSeleccionado = cmbOrden.SelectedItem.ToString();
            CargarTodosLosPacientesEnDataGridView(filtroSeleccionado);
        }

        private void btnBuscarOS_Click(object sender, EventArgs e)
        {

        }

        private void CargarGrilla()
        {

            try
            {
                List<cls_ObraSocialDTO> listaObraSocial = _obraSocial.ObtenerOSActivas();
                dgvObrasSociales.DataSource = listaObraSocial;
                dgvObrasSociales.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                dgvObrasSociales.ReadOnly = true;
                dgvObrasSociales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvObrasSociales.AllowUserToAddRows = false;

                dgvObrasSociales.Columns["fecha_baja"].Visible = false;
                dgvObrasSociales.Columns["fecha_alta"].Visible = false;
                dgvObrasSociales.Columns["estado"].Visible = false;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los pacientes en la vista: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            if (dgvObrasSociales.CurrentRow != null && dgvObrasSociales.CurrentRow.Index >= 0)
            {
                try
                {
                    cls_ObraSocialDTO osSeleccionada = (cls_ObraSocialDTO)dgvObrasSociales.CurrentRow.DataBoundItem;

                    _idObraSocialSeleccionada = osSeleccionada.id_obra_social;
                    if (_idObraSocialSeleccionada != 0 && osSeleccionada.estado == false)
                    {
                        btnReactivar.Visible = true;
                    }
                    else if (_idObraSocialSeleccionada != 0 && osSeleccionada.estado == true)
                    {
                        btnReactivar.Visible = false;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener la selección de la obra social: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _idObraSocialSeleccionada = -1;
                }
            }
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
            cmbOrden.SelectedIndex = 0;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            cls_ObraSocialDTO nuevaObraSocial = new cls_ObraSocialDTO
            {
                nombre_os = txtNombreOS.Text,
                codigo = Convert.ToInt32(txtCodigo.Text),
                cuit = Convert.ToInt64(txtCuit.Text),
                domicilio = txtDomicilio.Text,
                num_domicilio = Convert.ToInt32(txtNumDomicilio.Text),
                telefono = txtTelefono.Text,
                estado = Convert.ToBoolean(1),
                fecha_alta = DateTime.Now

            };

            if (_obraSocial.AgregarObraSocial(nuevaObraSocial))
            {
                MessageBox.Show("Obra Social creada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrilla();
                LimpiarCampos();
                cmbOrden.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("No se pudo crear la obra social. Verifique los datos o la conexión.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (_idObraSocialSeleccionada <= 0)
            {
                MessageBox.Show("Debe seleccionar una obra social para modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(txtNombreOS.Text) ||
                string.IsNullOrWhiteSpace(txtCodigo.Text) ||
                string.IsNullOrWhiteSpace(txtCuit.Text))
            {
                MessageBox.Show("Los campos Nombre, Código y CUIT son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                cls_ObraSocialDTO obraSocialModificada = new cls_ObraSocialDTO
                {
                    id_obra_social = _idObraSocialSeleccionada,
                    nombre_os = txtNombreOS.Text.Trim(),
                    codigo = Convert.ToInt32(txtCodigo.Text.Trim()),
                    cuit = Convert.ToInt64(txtCuit.Text.Trim()),
                    domicilio = txtDomicilio.Text.Trim(),
                    num_domicilio = string.IsNullOrWhiteSpace(txtNumDomicilio.Text) ? 0 : Convert.ToInt32(txtNumDomicilio.Text.Trim()),
                    telefono = txtTelefono.Text.Trim(),
                    estado = true,
                    fecha_alta = DateTime.Now
                };

                if (_obraSocial.ModificarObraSocial(obraSocialModificada))
                {
                    MessageBox.Show("Obra Social modificada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrilla();
                    LimpiarCampos();
                    _idObraSocialSeleccionada = -1; // Resetear el ID
                }
                else
                {
                    MessageBox.Show("No se pudo modificar la obra social.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Verifique que los campos numéricos contengan valores válidos.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar la obra social: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvObrasSociales.SelectedRows.Count == 0 || cmbOrden.SelectedItem.ToString() == "Inactivas")
            {
                MessageBox.Show("Debe seleccionar una obra social 'Activa' para dar de baja.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_idObraSocialSeleccionada == -1)
            {
                MessageBox.Show("Por favor, seleccione una obra social de la lista para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de que desea eliminar la obra social seleccionada? Esta la inactivará del sistema.",
                "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                if (_obraSocial.EliminarObraSocial(_idObraSocialSeleccionada))
                {
                    MessageBox.Show("Obra Social eliminada desactivada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarGrilla();
                    cmbOrden.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar la obra social. Verifique los datos o la conexión.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void CargarTodosLosPacientesEnDataGridView(string filtro)
        {
            try
            {
                List<cls_ObraSocialDTO> listaObraSocial = new List<cls_ObraSocialDTO>();
                if (filtro == "Activas")
                {
                    listaObraSocial = _obraSocial.ObtenerOSActivas();
                }
                else if (filtro == "Inactivas")
                {
                    listaObraSocial = _obraSocial.ObtenerOSInactivas();
                }
                else if (filtro == "Todas")
                {
                    listaObraSocial = _obraSocial.ObtenerTodasLasOS();
                }

                dgvObrasSociales.DataSource = listaObraSocial;
                dgvObrasSociales.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                dgvObrasSociales.ReadOnly = true;
                dgvObrasSociales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvObrasSociales.AllowUserToAddRows = false;

                dgvObrasSociales.Columns["fecha_baja"].Visible = false;
                dgvObrasSociales.Columns["fecha_alta"].Visible = false;
                dgvObrasSociales.Columns["estado"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los pacientes en la vista: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvObrasSociales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow filaSeleccionada = dgvObrasSociales.Rows[e.RowIndex];
                    cls_ObraSocialDTO osSeleccionada = (cls_ObraSocialDTO)filaSeleccionada.DataBoundItem;

                    _idObraSocialSeleccionada = osSeleccionada.id_obra_social;

                    txtNombreOS.Text = osSeleccionada.nombre_os;
                    txtCodigo.Text = osSeleccionada.codigo.ToString();
                    txtCuit.Text = osSeleccionada.cuit.ToString();
                    txtDomicilio.Text = osSeleccionada.domicilio;
                    txtNumDomicilio.Text = osSeleccionada.num_domicilio.ToString();
                    txtTelefono.Text = osSeleccionada.telefono.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al seleccionar Obra Social: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _idObraSocialSeleccionada = -1;
                  
                }
            }
        }

        private void dgvObrasSociales_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= -1)
            {
                try
                {
                    DataGridViewRow filaSeleccionada = dgvObrasSociales.Rows[e.RowIndex];
                    cls_ObraSocialDTO osSeleccionada = (cls_ObraSocialDTO)filaSeleccionada.DataBoundItem;

                    _idObraSocialSeleccionada = osSeleccionada.id_obra_social;

                    txtNombreOS.Text = osSeleccionada.nombre_os;
                    txtCodigo.Text = osSeleccionada.codigo.ToString();
                    txtCuit.Text = osSeleccionada.cuit.ToString();
                    txtDomicilio.Text = osSeleccionada.domicilio;
                    txtNumDomicilio.Text = osSeleccionada.num_domicilio.ToString();
                    txtTelefono.Text = osSeleccionada.telefono.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al seleccionar Obra Social: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _idObraSocialSeleccionada = -1;

                }
            }
        }
    }
}