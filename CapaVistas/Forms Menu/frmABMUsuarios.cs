// CapaVistas/Forms_Menu/frmABMUsuarios.cs
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CapaDTO.SistemaDTO;
using CapaLogica.Entidades; // Si tienes alguna entidad aquí
using CapaLogica.SistemaLogica;
using CapaUtilidades; // Si utilizas alguna utilidad aquí


namespace CapaVistas.Forms_Menu
{
    public partial class frmABMUsuarios : Form
    {
        private cls_Empleado _logicaEmpleado;
        public frmABMUsuarios()
        {
            InitializeComponent();
            _logicaEmpleado = new cls_Empleado();
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
            // Implementa esto cuando tengas la lógica para cargar tus ComboBoxes
            // Por ejemplo:
            // try
            // {
            //     // Suponiendo que tienes una lógica para localidades en cls_LocalidadLogica
            //     cls_LocalidadLogica logicaLocalidad = new cls_LocalidadLogica();
            //     List<cls_LocalidadDTO> localidades = logicaLocalidad.ObtenerLocalidades();
            //     cmbLocalidad.DataSource = localidades;
            //     cmbLocalidad.DisplayMember = "NombreLocalidad"; // O la propiedad que quieras mostrar
            //     cmbLocalidad.ValueMember = "IdLocalidad"; // O la propiedad que sea el ID

            //     // Similar para Sexo, TipoDNI, etc.
            // }
            // catch (Exception ex)
            // {
            //     MessageBox.Show("Error al cargar combos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            // }
        }

        private void frmABMUsuarios_Load(object sender, EventArgs e)
        {
            CargarEmpleadosEnDataGridView(); // Se llama al cargar el formulario
            CargarCombos();
            cls_LlenarCombos.Cargar(cmbLocalidad, )

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

                    // Si los combos están cargados, esto debería funcionar
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
        // ... otros métodos de tu formulario
    }
}