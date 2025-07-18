using CapaDTO;
using CapaDTO.SistemaDTO;
using CapaLogica.ABM;
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
        public frmAdministrarRoles()
        {
            InitializeComponent();
            _rol = new cls_Rol();
        }
        private void frmAdministrarRoles_Load(object sender, EventArgs e)
        {
            _rol.CargarRolesEnDataGridView(dgvVerRoles);

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

                    // Aquí ya no necesitas el 'if' anidado, porque la validación ya se hizo antes
                    _rol.ActualizarRol(rolModificado);
                    MessageBox.Show("Rol modificado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _rol.CargarRolesEnDataGridView(dgvVerRoles);
                    txtNombreRol.Clear();
                    txtDescripcionRol.Clear();
                    _idRolSeleccionado = -1;
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
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow filaSeleccionada = dgvVerRoles.Rows[e.RowIndex];
                    cls_RolDTO RolSeleccionado = (cls_RolDTO)filaSeleccionada.DataBoundItem;

                    txtNombreRol.Text = RolSeleccionado.NombreRol;
                    txtDescripcionRol.Text = RolSeleccionado.Descripcion;


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al seleccionar Rol: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvVerRoles_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVerRoles.CurrentRow != null && dgvVerRoles.CurrentRow.Index >= 0)
            {
                try
                {
                    cls_RolDTO rolSeleccionado = (cls_RolDTO)dgvVerRoles.CurrentRow.DataBoundItem;

                    _idRolSeleccionado = rolSeleccionado.IdRol;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener la selección del empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _idRolSeleccionado = -1;
                }
            }
            else
            {
                _idRolSeleccionado = -1;
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
                    txtNombreRol.Clear();
                    txtDescripcionRol.Clear();
                    _idRolSeleccionado = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el rol: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
