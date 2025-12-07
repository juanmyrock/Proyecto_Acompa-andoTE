using CapaDTO;
using CapaDTO.SistemaDTO;
using CapaLogica.ABM;
using CapaLogica.LlenarCombos;
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
        private int _idRolSeleccionado = -1;
        cls_Rol _rol;
        private cls_Permisos _logicaPermisos;
        cls_LlenarCombos _rellenador;

        public frmAdministrarRoles()
        {
            InitializeComponent();
            _rellenador = new cls_LlenarCombos();
            _rol = new cls_Rol();
            _logicaPermisos = new cls_Permisos();
        }

        private void frmAdministrarRoles_Load(object sender, EventArgs e)
        {
            _rol.CargarRolesEnDataGridView(dgvVerRoles);
            CargarCombos();

            ltvPermisosDisp.View = View.Details;
            ltvPermisosDisp.Columns.Add("Permiso", 150);
            ltvPermisosDisp.Columns.Add("Descripción", 250);

            ltvPermisosAsignados.View = View.Details;
            ltvPermisosAsignados.Columns.Add("Permiso", 150);
            ltvPermisosAsignados.Columns.Add("Descripción", 250);

            if (dgvVerRoles.Rows.Count > 0)
            {
                dgvVerRoles.Rows[0].Selected = true;
                dgvVerRoles.CurrentCell = dgvVerRoles.Rows[0].Cells[0];
            }
        }

        private void CargarCombos()
        {
            var cargaRoles = _rellenador.ObtenerRoles();
            try
            {
                cmbRol.DataSource = null;
                cmbRol.Items.Clear();

                CapaUtilidades.cls_LlenarCombos.Cargar(cmbRol, cargaRoles.Roles, "NombreRol", "IdRol");

                cmbRol.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los roles en el ComboBox: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Crear Rol
        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreRol.Text) || string.IsNullOrWhiteSpace(txtDescripcionRol.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            cls_RolDTO nuevoRol = new cls_RolDTO
            {
                NombreRol = txtNombreRol.Text.Trim(),
                Descripcion = txtDescripcionRol.Text.Trim()
            };
            var dialog = MessageBox.Show("¿Está seguro de que desea crear el rol '" + nuevoRol.NombreRol + "'?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    if (txtNombreRol.Text.Length < 4 || txtDescripcionRol.Text.Length < 10)
                    {
                        MessageBox.Show("El nombre del rol no puede tener menos de 4 caracteres. \n La descripción no puede tener menos de 10 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        _rol.InsertarRol(nuevoRol);
                        MessageBox.Show("Rol creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _rol.CargarRolesEnDataGridView(dgvVerRoles);
                        CargarCombos();
                        txtNombreRol.Clear();
                        txtDescripcionRol.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al crear el rol: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Modificar Rol
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (_idRolSeleccionado == -1)
            {
                MessageBox.Show("Por favor, seleccione un rol para modificar.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombreRol.Text) || string.IsNullOrWhiteSpace(txtDescripcionRol.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtNombreRol.Text.Trim().Length < 4 || txtDescripcionRol.Text.Trim().Length < 10)
            {
                MessageBox.Show("El nombre del rol no puede tener menos de 4 caracteres. \n La descripción no puede tener menos de 10 caracteres", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var dialog = MessageBox.Show($"¿Está seguro de que desea modificar el rol seleccionado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    cls_RolDTO rolModificado = new cls_RolDTO
                    {
                        IdRol = _idRolSeleccionado,
                        NombreRol = txtNombreRol.Text.Trim(),
                        Descripcion = txtDescripcionRol.Text.Trim()
                    };

                    _rol.ActualizarRol(rolModificado);
                    MessageBox.Show("Rol modificado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _rol.CargarRolesEnDataGridView(dgvVerRoles);
                    CargarCombos();
                    txtNombreRol.Clear();
                    txtDescripcionRol.Clear();
                    _idRolSeleccionado = -1;
                    ltvPermisosAsignados.Items.Clear();
                    ltvPermisosDisp.Items.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al modificar el rol: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
        private void dgvVerRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvVerRoles_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVerRoles.CurrentRow == null || dgvVerRoles.CurrentRow.Index < 0)
            {
                _idRolSeleccionado = -1;
                txtNombreRol.Clear();
                txtDescripcionRol.Clear();
                ltvPermisosAsignados.Items.Clear();
                ltvPermisosDisp.Items.Clear();
                if (cmbRol.SelectedIndex != -1)
                {
                    cmbRol.SelectedIndex = -1;
                }
                return;
            }

            try
            {
                cls_RolDTO rolSeleccionado = (cls_RolDTO)dgvVerRoles.CurrentRow.DataBoundItem;

                _idRolSeleccionado = rolSeleccionado.IdRol;
                txtNombreRol.Text = rolSeleccionado.NombreRol;
                txtDescripcionRol.Text = rolSeleccionado.Descripcion;
                int indexInComboBox = -1;
                for (int i = 0; i < cmbRol.Items.Count; i++)
                {
                    if (cmbRol.Items[i] is DataRowView drv) 
                    {
                        if (Convert.ToInt32(drv["IdRol"]) == _idRolSeleccionado)
                        {
                            indexInComboBox = i;
                            break;
                        }
                    }
                    else if (cmbRol.Items[i] is cls_RolDTO dto)
                    {
                        if (dto.IdRol == _idRolSeleccionado)
                        {
                            indexInComboBox = i;
                            break;
                        }
                    }
                }

                if (cmbRol.SelectedIndex != indexInComboBox)
                {
                    cmbRol.SelectedIndex = indexInComboBox;
                }

                _logicaPermisos.CargarPermisosParaRolSeleccionado(_idRolSeleccionado, ltvPermisosAsignados, ltvPermisosDisp);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener la selección del rol: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _idRolSeleccionado = -1;
                txtNombreRol.Clear();
                txtDescripcionRol.Clear();
                ltvPermisosAsignados.Items.Clear();
                ltvPermisosDisp.Items.Clear();
                if (cmbRol.SelectedIndex != -1)
                {
                    cmbRol.SelectedIndex = -1;
                }
            }
        }

        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRol.SelectedItem is cls_RolDTO selectedRolDTO)
            {
                try
                {
                    int nuevoIdRol = selectedRolDTO.IdRol;

                    if (nuevoIdRol == _idRolSeleccionado)
                    {
                        return;
                    }

                    _idRolSeleccionado = nuevoIdRol;
                    txtNombreRol.Text = selectedRolDTO.NombreRol;
                    txtDescripcionRol.Text = selectedRolDTO.Descripcion;

                    _logicaPermisos.CargarPermisosParaRolSeleccionado(_idRolSeleccionado, ltvPermisosAsignados, ltvPermisosDisp);
                    dgvVerRoles.SelectionChanged -= dgvVerRoles_SelectionChanged;
                    foreach (DataGridViewRow row in dgvVerRoles.Rows)
                    {
                        if (row.DataBoundItem is cls_RolDTO rolDto && rolDto.IdRol == _idRolSeleccionado)
                        {
                            row.Selected = true;
                            if (row.Cells.Count > 0)
                            {
                                dgvVerRoles.CurrentCell = row.Cells[0];
                            }
                            break;
                        }
                    }
                    dgvVerRoles.SelectionChanged += dgvVerRoles_SelectionChanged;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al seleccionar rol desde ComboBox: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _idRolSeleccionado = -1;
                    txtNombreRol.Clear();
                    txtDescripcionRol.Clear();
                    ltvPermisosAsignados.Items.Clear();
                    ltvPermisosDisp.Items.Clear();
                }
            }
            else
            {
                _idRolSeleccionado = -1;
                txtNombreRol.Clear();
                txtDescripcionRol.Clear();
                ltvPermisosAsignados.Items.Clear();
                ltvPermisosDisp.Items.Clear();
            }
        }


        #region Eliminar Rol
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_idRolSeleccionado == -1)
                {
                    MessageBox.Show("Por favor, seleccione un rol para eliminar.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var dialog = MessageBox.Show("¿Está seguro de que desea eliminar el rol seleccionado?\n Esta acción no puede deshacerse de ninguna manera", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialog == DialogResult.Yes)
                {
                    _rol.EliminarRol(_idRolSeleccionado);
                    MessageBox.Show("Rol eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _rol.CargarRolesEnDataGridView(dgvVerRoles);
                    CargarCombos();
                    txtNombreRol.Clear();
                    txtDescripcionRol.Clear();
                    _idRolSeleccionado = -1;
                    ltvPermisosAsignados.Items.Clear();
                    ltvPermisosDisp.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el rol: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        private void btnQuitarPermiso_Click(object sender, EventArgs e)
        {
            if (_idRolSeleccionado == -1)
            {
                MessageBox.Show("Por favor, seleccione un rol primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ltvPermisosAsignados.SelectedItems.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione al menos un permiso asignado para quitar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<ListViewItem> itemsToMove = new List<ListViewItem>();
            foreach (ListViewItem selectedItem in ltvPermisosAsignados.SelectedItems)
            {
                itemsToMove.Add(selectedItem);
            }

            foreach (ListViewItem selectedItem in itemsToMove)
            {
                try
                {
                    int idPermiso = (int)selectedItem.Tag;
                    _logicaPermisos.DesasignarPermisoDeRol(_idRolSeleccionado, idPermiso);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al quitar el permiso '" + selectedItem.Text + "': " + ex.Message, "Error al Quitar Permiso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            _logicaPermisos.CargarPermisosParaRolSeleccionado(_idRolSeleccionado, ltvPermisosAsignados, ltvPermisosDisp);
        }

        private void btnQuitarTodos_Click(object sender, EventArgs e)
        {
            if (_idRolSeleccionado == -1)
            {
                MessageBox.Show("Por favor, seleccione un rol primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ltvPermisosAsignados.Items.Count == 0)
            {
                MessageBox.Show("No hay permisos asignados para quitar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirmResult = MessageBox.Show("¿Está seguro de que desea quitar TODOS los permisos asignados a este rol?", "Confirmar Desasignación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                List<ListViewItem> itemsToMove = new List<ListViewItem>();
                foreach (ListViewItem item in ltvPermisosAsignados.Items)
                {
                    itemsToMove.Add(item);
                }

                foreach (ListViewItem item in itemsToMove)
                {
                    try
                    {
                        int idPermiso = (int)item.Tag;
                        _logicaPermisos.DesasignarPermisoDeRol(_idRolSeleccionado, idPermiso);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al quitar el permiso '" + item.Text + "': " + ex.Message, "Error al Quitar Permiso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                _logicaPermisos.CargarPermisosParaRolSeleccionado(_idRolSeleccionado, ltvPermisosAsignados, ltvPermisosDisp);
            }
        }

        private void btnAsignarTodos_Click(object sender, EventArgs e)
        {
            if (_idRolSeleccionado == -1)
            {
                MessageBox.Show("Por favor, seleccione un rol primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ltvPermisosDisp.Items.Count == 0)
            {
                MessageBox.Show("No hay permisos disponibles para asignar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirmResult = MessageBox.Show("¿Está seguro de que desea asignar TODOS los permisos disponibles a este rol?", "Confirmar Asignación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                List<ListViewItem> itemsToMove = new List<ListViewItem>();
                foreach (ListViewItem item in ltvPermisosDisp.Items)
                {
                    itemsToMove.Add(item);
                }

                foreach (ListViewItem item in itemsToMove)
                {
                    try
                    {
                        int idPermiso = (int)item.Tag;
                        _logicaPermisos.AsignarPermisoARol(_idRolSeleccionado, idPermiso);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al asignar el permiso '" + item.Text + "': " + ex.Message, "Error de Asignación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                _logicaPermisos.CargarPermisosParaRolSeleccionado(_idRolSeleccionado, ltvPermisosAsignados, ltvPermisosDisp);
            }
        }

        private void btnAsignarPermiso_Click(object sender, EventArgs e)
        {
            if (_idRolSeleccionado == -1)
            {
                MessageBox.Show("Por favor, seleccione un rol primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ltvPermisosDisp.SelectedItems.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione al menos un permiso disponible para asignar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<ListViewItem> itemsToMove = new List<ListViewItem>();
            foreach (ListViewItem selectedItem in ltvPermisosDisp.SelectedItems)
            {
                itemsToMove.Add(selectedItem);
            }

            foreach (ListViewItem selectedItem in itemsToMove)
            {
                try
                {
                    int idPermiso = (int)selectedItem.Tag;
                    _logicaPermisos.AsignarPermisoARol(_idRolSeleccionado, idPermiso);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al asignar el permiso '" + selectedItem.Text + "': " + ex.Message, "Error de Asignación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            _logicaPermisos.CargarPermisosParaRolSeleccionado(_idRolSeleccionado, ltvPermisosAsignados, ltvPermisosDisp);
        }

        private void btnCerrarForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}