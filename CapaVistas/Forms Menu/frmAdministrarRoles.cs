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
        cls_Rol _rol; // Para CRUD de roles y cargar el DataGridView
        private cls_Permisos _logicaPermisos; // Para la gestión de permisos y su relación con roles
        cls_LlenarCombos _rellenador; // Para cargar el ComboBox

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

            // Seleccionar el primer elemento en el DataGridView si existe
            if (dgvVerRoles.Rows.Count > 0)
            {
                dgvVerRoles.Rows[0].Selected = true;
                dgvVerRoles.CurrentCell = dgvVerRoles.Rows[0].Cells[0]; // Asegura que el evento SelectionChanged se dispare
            }
        }

        private void CargarCombos()
        {
            var cargaRoles = _rellenador.ObtenerRoles();
            try
            {
                // Limpiar cmbRol antes de cargar para evitar duplicados si se llama varias veces
                cmbRol.DataSource = null;
                cmbRol.Items.Clear();

                CapaUtilidades.cls_LlenarCombos.Cargar(cmbRol, cargaRoles.Roles, "NombreRol", "IdRol");

                // Configurar el ComboBox para que no seleccione nada por defecto
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
                        CargarCombos(); // Recarga el combo para incluir el nuevo rol
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
                    CargarCombos(); // Recarga el combo para reflejar el cambio de nombre/desc
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

        // El CellClick es redundante para la carga de permisos si SelectionChanged ya lo hace.
        // Lo eliminaré o lo dejaré vacío si no tiene otra función.
        private void dgvVerRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Puedes dejarlo vacío o eliminarlo si dgvVerRoles_SelectionChanged maneja todo lo necesario
            // Si necesitas alguna lógica específica al hacer click en una celda, ponla aquí.
        }

        private void dgvVerRoles_SelectionChanged(object sender, EventArgs e)
        {
            // Evita disparar el evento al limpiar la selección o cuando no hay fila actual
            if (dgvVerRoles.CurrentRow == null || dgvVerRoles.CurrentRow.Index < 0)
            {
                _idRolSeleccionado = -1;
                txtNombreRol.Clear();
                txtDescripcionRol.Clear();
                ltvPermisosAsignados.Items.Clear();
                ltvPermisosDisp.Items.Clear();
                // Opcional: Deseleccionar también el ComboBox si no hay rol seleccionado en el DGV
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

                // Sincronizar el ComboBox con el DataGridView
                // Encuentra el índice del rol seleccionado en el ComboBox
                int indexInComboBox = -1;
                for (int i = 0; i < cmbRol.Items.Count; i++)
                {
                    if (cmbRol.Items[i] is DataRowView drv) // Si el DataSource del combo es un DataTable
                    {
                        if (Convert.ToInt32(drv["IdRol"]) == _idRolSeleccionado)
                        {
                            indexInComboBox = i;
                            break;
                        }
                    }
                    else if (cmbRol.Items[i] is cls_RolDTO dto) // Si el DataSource es una List<cls_RolDTO>
                    {
                        if (dto.IdRol == _idRolSeleccionado)
                        {
                            indexInComboBox = i;
                            break;
                        }
                    }
                    // Si el DataSource de cmbRol es directamente una lista de cls_RolDTO,
                    // cmbRol.SelectedValue = _idRolSeleccionado; funcionaría directamente.
                    // Pero la carga con CapaUtilidades.cls_LlenarCombos.Cargar puede cambiar el tipo de los ítems.
                }

                if (cmbRol.SelectedIndex != indexInComboBox)
                {
                    // Previene que se dispare otro SelectionChanged si ya está seleccionado.
                    cmbRol.SelectedIndex = indexInComboBox;
                }

                // Llama al método de la lógica para cargar los permisos
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

        // Nuevo evento para el ComboBox
        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica si hay un ítem seleccionado y si el SelectedItem es del tipo esperado
            if (cmbRol.SelectedItem is cls_RolDTO selectedRolDTO) // Usa 'is' para una verificación y conversión segura
            {
                try
                {
                    int nuevoIdRol = selectedRolDTO.IdRol; // Accede directamente a la propiedad IdRol del DTO

                    // Evita bucles infinitos si este evento es disparado por la sincronización del DGV
                    if (nuevoIdRol == _idRolSeleccionado)
                    {
                        return; // Ya está seleccionado el mismo rol, no hacer nada
                    }

                    _idRolSeleccionado = nuevoIdRol;

                    // Opcional: Actualizar los TextBox si cmbRol es la fuente principal de selección
                    // (esto ya lo hace dgvVerRoles_SelectionChanged, pero si el usuario solo usa el combo, podrías necesitarlo)
                    txtNombreRol.Text = selectedRolDTO.NombreRol;
                    txtDescripcionRol.Text = selectedRolDTO.Descripcion;

                    // Llama al método de la lógica para cargar los permisos
                    _logicaPermisos.CargarPermisosParaRolSeleccionado(_idRolSeleccionado, ltvPermisosAsignados, ltvPermisosDisp);

                    // Sincronizar el DataGridView con el ComboBox
                    // Previene que el evento SelectionChanged del DGV se dispare cuando actualizamos.
                    // Es buena práctica quitar y volver a añadir el evento.
                    dgvVerRoles.SelectionChanged -= dgvVerRoles_SelectionChanged;
                    foreach (DataGridViewRow row in dgvVerRoles.Rows)
                    {
                        if (row.DataBoundItem is cls_RolDTO rolDto && rolDto.IdRol == _idRolSeleccionado)
                        {
                            row.Selected = true;
                            // Asegúrate de que CurrentCell no sea null antes de asignarle un valor
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
                // Si no se pudo obtener un cls_RolDTO válido (ej. al limpiar el combo o si SelectedItem es null)
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
                    CargarCombos(); // Recarga el combo después de eliminar
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

        // Métodos de asignación/desasignación de permisos (ya los tenías, solo cambié la llamada a _logicaPermisos)
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
    }
}