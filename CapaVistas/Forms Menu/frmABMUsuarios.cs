using System;
using System.Windows.Forms;
using CapaLogica.Entidades;
using CapaServicios.Llenar_Combos;



namespace CapaVistas.Forms_Menu
{
    public partial class frmABMUsuarios : Form
    {
        private cls_Usuarios usuario = new cls_Usuarios();
        public frmABMUsuarios()
        {
            InitializeComponent();
        }
        #region Tab Ver Usuarios        
        private void TraerTodos(DataGridView dgv, string datos = null)
        {
            dgv.DataSource = null;
            dgv.DataSource = usuario.ObtenerUsuarios(datos);
        }
        #endregion



        #region Tab Modificar Empleados
        private void btnRefreshModif_Click(object sender, EventArgs e)
        {
            //if (dgvVerEmpModif.DataSource != null)
            //{
            //    dgvVerEmpModif.DataSource = null;
            //    TraerTodos(dgvVerEmpModif);
            //}
        }
        private void btnCargarListaModif_Click(object sender, EventArgs e)
        {
            //TraerTodos(dgvVerEmpModif);
        }
        private void btnModificarEmp_Click(object sender, EventArgs e)
        {
            //string mensaje;

            ////Llamar a ValidarCampos y verificar si la validación es exitosa
            //if (!ValidarCamposModif(out mensaje))
            //{
            ////Si la validación falla, mostrar el mensaje de error y salir del método
            //    MessageBox.Show(mensaje);
            //    return;
            //}

            
        }

        private void dgvVerEmpModif_SelectionChanged(object sender, EventArgs e)
        {
            //if (dgvVerEmpModif.SelectedRows.Count > 0)
            //{
            //    DataGridViewRow row = dgvVerEmpModif.SelectedRows[0];
            //    EmpleadoSeleccionadoId = Convert.ToInt32(row.Cells["id_empleado"].Value);

            //    Asignar los datos de la fila seleccionada a los controles correspondientes
            //    txtNombreModif.Text = row.Cells["nombre"].Value.ToString();
            //    txtApellidoModif.Text = row.Cells["apellido"].Value.ToString();
            //    cmbSexoModif.SelectedValue = row.Cells["id_sexo"].Value;
            //    cmbTipoDNIModif.SelectedValue = row.Cells["id_tipodni"].Value;
            //    txtDNIModif.Text = row.Cells["dni"].Value.ToString();
            //    dateNacimientoModif.Value = Convert.ToDateTime(row.Cells["fecha_nac"].Value);
            //    txtEmailModif.Text = row.Cells["email"].Value.ToString();
            //    txtCelularModif.Text = row.Cells["telefono"].Value.ToString();
            //    cmbLocalidadModif.SelectedValue = row.Cells["id_localidad"].Value;
            //    txtCalleModif.Text = row.Cells["calle"].Value.ToString();
            //    txtNumCalleModif.Text = row.Cells["numero_calle"].Value.ToString();
            //    cmbCargoModif.SelectedValue = row.Cells["id_cargo"].Value;
            //    chkEstadoModif.Checked = Convert.ToBoolean(row.Cells["estado"].Value);
            //}

        }
        #endregion
    }
}
