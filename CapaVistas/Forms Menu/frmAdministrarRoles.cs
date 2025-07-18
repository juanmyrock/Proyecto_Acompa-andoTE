using CapaDTO;
using System;
using System.Collections.Generic;
using CapaLogica.ABM;
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
       
        cls_Rol _rol;
        public frmAdministrarRoles()
        {
            InitializeComponent();
            _rol= new cls_Rol();
        }

        private void CargarRolesEnDataGridView()
        {
            try
            {
                List<cls_RolDTO> listaRoles = _rol.;
                dgvVerRoles.DataSource = listaRoles;

                dgvVerRoles.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                dgvVerRoles.ReadOnly = true;
                dgvVerRoles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvVerRoles.AllowUserToAddRows = false;
                dgvVerRoles.Columns["id_rol"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los empleados en la vista: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAdministrarRoles_Load(object sender, EventArgs e)
        {

        }

        private void btnCrear_Click(object sender, EventArgs e)
        {

        }
    }
}
