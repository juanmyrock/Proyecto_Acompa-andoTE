// CapaVistas/Forms_Menu/frmABMUsuarios.cs
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CapaDTO.SistemaDTO;
using CapaLogica;
using CapaLogica.SistemaLogica;
using CapaUtilidades; // Si utilizas alguna utilidad aquí


namespace CapaVistas.Forms_Menu
{
    public partial class frmABMUsuarios : Form
    {
        private cls_Empleado _logicaEmpleado;
        private cls_TipoDNILogica _logicaTipoDNI;
        private cls_LocalidadLogica _logicaLocalidad;
        private cls_SexoLogica _logicaSexo;
        public frmABMUsuarios()
        {
            InitializeComponent();
            _logicaEmpleado = new cls_Empleado();
            _logicaEmpleado = new cls_Empleado();
            _logicaTipoDNI = new cls_TipoDNILogica();
            _logicaLocalidad = new cls_LocalidadLogica();
            _logicaSexo = new cls_SexoLogica();
        }
        

        
        private void CargarEmpleadosEnDataGridView()
        {
            try
            {
                List<cls_EmpleadoDTO> listaEmpleados = _logicaEmpleado.ObtenerEmpleados(); // Obtiene la lista.
                dgvVerUser.DataSource = listaEmpleados; // Asigna al DataGridView.

                dgvVerUser.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                dgvVerUser.ReadOnly = true;
                dgvVerUser.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvVerUser.AllowUserToAddRows = false;

                // Aquí puedes ocultar columnas si lo deseas
                // dgvVerUser.Columns["id_empleado"].Visible = false;
                // dgvVerUser.Columns["id_sexo"].Visible = false; 
            }
            catch (Exception ex)
            {
                // Este MessageBox.Show debería mostrarte cualquier error que surja desde las capas inferiores
                MessageBox.Show("Error al cargar los empleados en la vista: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCombos()
        {
            try
            {
                // Cargar cmbTipoDNI
                List<cls_TipoDNIDTO> tiposDni = _logicaTipoDNI.ObtenerTiposDNI();
                cmbTipoDNI.DataSource = tiposDni;
                cmbTipoDNI.DisplayMember = "descripcion"; // Propiedad del DTO a mostrar en el ComboBox
                cmbTipoDNI.ValueMember = "id_tipo_dni";   // Propiedad del DTO que será el valor real

                // Cargar cmbLocalidad
                List<cls_LocalidadDTO> localidades = _logicaLocalidad.ObtenerLocalidades();
                cmbLocalidad.DataSource = localidades;
                cmbLocalidad.DisplayMember = "nombre_localidad"; // Propiedad del DTO a mostrar
                cmbLocalidad.ValueMember = "id_localidad";       // Propiedad del DTO que será el valor real

                // Cargar cmbSexo
                List<cls_SexoDTO> sexos = _logicaSexo.ObtenerSexos();
                cmbSexo.DataSource = sexos;
                cmbSexo.DisplayMember = "descripcion"; // Propiedad del DTO a mostrar
                cmbSexo.ValueMember = "id_sexo";       // Propiedad del DTO que será el valor real
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los ComboBoxes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmABMUsuarios_Load(object sender, EventArgs e)
        {
            CargarEmpleadosEnDataGridView(); 
            CargarCombos();
  

        }

        private void dgvVerUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow filaSeleccionada = dgvVerUser.Rows[e.RowIndex];
                    cls_EmpleadoDTO empleadoSeleccionado = (cls_EmpleadoDTO)filaSeleccionada.DataBoundItem;

                    txtNombre.Text = empleadoSeleccionado.nombre;
                    txtApellido.Text = empleadoSeleccionado.apellido;
                    txtDNI.Text = empleadoSeleccionado.dni.ToString();
                    txtCalle.Text = empleadoSeleccionado.domicilio;
                    txtEmail.Text = empleadoSeleccionado.email;
                    txtCelular.Text = empleadoSeleccionado.telefono;
                    txtNumCalle.Text = empleadoSeleccionado.num_domicilio.ToString();
                    cmbTipoDNI.SelectedValue = empleadoSeleccionado.id_tipo_dni;
                    cmbLocalidad.SelectedValue = empleadoSeleccionado.id_localidad;
                    cmbSexo.SelectedValue = empleadoSeleccionado.id_sexo;
                    dateNacimiento.Value = empleadoSeleccionado.fecha_nac;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al seleccionar empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}