using CapaDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVistas.Forms_Menu
{
    public partial class frmAdministrarRoles : Form
    {
        cls_RolDTO rol;
        public frmAdministrarRoles()
        {
            InitializeComponent();
            rol= new cls_RolDTO();
        }

        private void CargarRolesEnDataGridView()
        {
            try
            {
                //List<cls_RolDTO> listaEmpleados = _logicaEmpleado.ObtenerEmpleados();
                //dgvVerUser.DataSource = listaEmpleados;

                //dgvVerUser.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                //dgvVerUser.ReadOnly = true;
                //dgvVerUser.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //dgvVerUser.AllowUserToAddRows = false;
                //dgvVerUser.Columns["id_sexo"].Visible = false;
                //dgvVerUser.Columns["id_tipo_dni"].Visible = false;
                //dgvVerUser.Columns["id_localidad"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los empleados en la vista: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAdministrarRoles_Load(object sender, EventArgs e)
        {

        }
    }
}
