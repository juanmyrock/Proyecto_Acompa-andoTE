using System;
using System.Data;
using System.Windows.Forms;
using CapaLogica.Entidades;
using CapaUtilidades;

namespace CapaVistas.Form_Menu
{
    public partial class frmUsuarios : Form
    {

        private cls_Usuarios usuario = new cls_Usuarios();
        //private int UserSeleccionadoId;


        public frmUsuarios()
        {
            InitializeComponent();
            //LlenarCombos();
        }

        //private void LlenarCombos()  //Método que llena los combos de Empleados
        //{
        //    // Llenar ComboBox de Sexos
        //    cls_LlenarCombos CMBSexo = new cls_LlenarCombos(cmbSexo, "Sexos", "id_sexos", "sexo");

        //    // Llenar ComboBox de Tipos de DNI
        //    cls_LlenarCombos CMBTipoDNI = new cls_LlenarCombos(cmbTipoDNI, "TiposDocumentos", "id_tipodni", "tipodni");

        //    // Llenar ComboBox de Localidades
        //    cls_LlenarCombos CMBLocalidad = new cls_LlenarCombos(cmbLocalidad, "Localidades", "id_localidad", "localidad");

        //    // Llenar ComboBox de Cargos
        //    cls_LlenarCombos CMBCargo = new cls_LlenarCombos(cmbCargo, "Cargos", "id_cargos", "cargos");

        //    cls_LlenarCombos CMBSexoModif = new cls_LlenarCombos(cmbSexoModif, "Sexos", "id_sexos", "sexo");
        //    cls_LlenarCombos CMBTipoDNIModif = new cls_LlenarCombos(cmbTipoDNIModif, "TiposDocumentos", "id_tipodni", "tipodni");
        //    cls_LlenarCombos CMBLocalidadModif = new cls_LlenarCombos(cmbLocalidadModif, "Localidades", "id_localidad", "localidad");
        //    cls_LlenarCombos CMBCargoModif = new cls_LlenarCombos(cmbCargoModif, "Cargos", "id_cargos", "cargos");

        //    cls_LlenarCombos CMBSexoBaja = new cls_LlenarCombos(cmbSexoBaja, "Sexos", "id_sexos", "sexo");
        //    cls_LlenarCombos CMBTipoDNIBaja = new cls_LlenarCombos(cmbTipoDNIBaja, "TiposDocumentos", "id_tipodni", "tipodni");
        //    cls_LlenarCombos CMBLocalidadBaja = new cls_LlenarCombos(cmbLocalidadBaja, "Localidades", "id_localidad", "localidad");
        //    cls_LlenarCombos CMBCargoBaja = new cls_LlenarCombos(cmbCargoBaja, "Cargos", "id_cargos", "cargos");
        //}


        //#region Método para validar todos los campos completos de Alta
        //public bool ValidarCamposAlta(out string mensaje)
        //{
        //    mensaje = string.Empty;

        //    if (string.IsNullOrEmpty(txtNombre.Text))
        //    {
        //        mensaje = "El campo Nombre es obligatorio.";
        //        return false;
        //    }

        //    if (string.IsNullOrEmpty(txtApellido.Text))
        //    {
        //        mensaje = "El campo Apellido es obligatorio.";
        //        return false;
        //    }

        //    if (cmbSexo.SelectedIndex == -1)
        //    {
        //        mensaje = "Debe seleccionar un Sexo válido.";
        //        return false;
        //    }

        //    if (cmbTipoDNI.SelectedIndex == -1)
        //    {
        //        mensaje = "Debe seleccionar un Tipo de DNI válido.";
        //        return false;
        //    }

        //    if (!EsNumero(txtDNI.Text))
        //    {
        //        mensaje = "El campo DNI debe ser numérico.";
        //        return false;
        //    }

        //    if (dateNacimiento.Value == default)
        //    {
        //        mensaje = "Debe seleccionar una Fecha de Nacimiento válida.";
        //        return false;
        //    }

        //    if (string.IsNullOrEmpty(txtEmail.Text))
        //    {
        //        mensaje = "El campo Email es obligatorio.";
        //        return false;
        //    }
        //    if (!EsNumero(txtCelularAlta.Text))
        //    {
        //        mensaje = "El campo Celular debe ser numérico.";
        //        return false;
        //    }

        //    if (cmbLocalidad.SelectedIndex == -1)
        //    {
        //        mensaje = "Debe seleccionar una Localidad válida.";
        //        return false;
        //    }

        //    if (string.IsNullOrEmpty(txtCalle.Text))
        //    {
        //        mensaje = "El campo Calle es obligatorio.";
        //        return false;
        //    }

        //    if (!EsNumero(txtNumCalle.Text))
        //    {
        //        mensaje = "El campo Número de Calle debe ser numérico.";
        //        return false;
        //    }

        //    if (cmbCargo.SelectedIndex == -1)
        //    {
        //        mensaje = "Debe seleccionar un Cargo válido.";
        //        return false;
        //    }
        //    if (!chkEstadoAlta.Checked || chkEstadoAlta.CheckState == CheckState.Indeterminate)
        //    {
        //        mensaje = "Debe marcar el estado del empleado. (Activo o Inactivo";
        //        return false;
        //    }


        //    return true;
        //}
        //#endregion

        //#region Método para validar que los campos de Modificar Empleado esten completos
        //public bool ValidarCamposModif(out string mensaje)
        //{
        //    mensaje = string.Empty;

        //    if (string.IsNullOrEmpty(txtNombreModif.Text))
        //    {
        //        mensaje = "El campo Nombre es obligatorio.";
        //        return false;
        //    }

        //    if (string.IsNullOrEmpty(txtApellidoModif.Text))
        //    {
        //        mensaje = "El campo Apellido es obligatorio.";
        //        return false;
        //    }

        //    if (cmbSexoModif.SelectedIndex == -1)
        //    {
        //        mensaje = "Debe seleccionar un Sexo válido.";
        //        return false;
        //    }

        //    if (cmbTipoDNIModif.SelectedIndex == -1)
        //    {
        //        mensaje = "Debe seleccionar un Tipo de DNI válido.";
        //        return false;
        //    }

        //    if (!EsNumero(txtDNIModif.Text))
        //    {
        //        mensaje = "El campo DNI debe ser numérico.";
        //        return false;
        //    }

        //    if (dateNacimientoModif.Value == default)
        //    {
        //        mensaje = "Debe seleccionar una Fecha de Nacimiento válida.";
        //        return false;
        //    }

        //    if (string.IsNullOrEmpty(txtEmailModif.Text))
        //    {
        //        mensaje = "El campo Email es obligatorio.";
        //        return false;
        //    }
        //    if (!EsNumero(txtCelularModif.Text))
        //    {
        //        mensaje = "El campo Celular debe ser numérico.";
        //        return false;
        //    }

        //    if (cmbLocalidadModif.SelectedIndex == -1)
        //    {
        //        mensaje = "Debe seleccionar una Localidad válida.";
        //        return false;
        //    }

        //    if (string.IsNullOrEmpty(txtCalleModif.Text))
        //    {
        //        mensaje = "El campo Calle es obligatorio.";
        //        return false;
        //    }

        //    if (!EsNumero(txtNumCalleModif.Text))
        //    {
        //        mensaje = "El campo Número de Calle debe ser numérico.";
        //        return false;
        //    }

        //    if (cmbCargoModif.SelectedIndex == -1)
        //    {
        //        mensaje = "Debe seleccionar un Cargo válido.";
        //        return false;
        //    }


        //    return true;
        //}
        //#endregion
        //private bool EsNumero(string valor)
        //{
        //    return int.TryParse(valor, out _); // Intenta convertir el valor a un entero pero el resultado es un booleano
        //}




        #region Tab Ver Usuarios        
        private void TraerTodos(DataGridView dgv, string datos = null)
        {
            dgv.DataSource = null;
            dgv.DataSource = usuario.ObtenerUsuarios(datos);
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            TraerTodos(dgvVerUser);
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            if (dgvVerUser.DataSource != null)
            {
                dgvVerUser.DataSource = null;
                TraerTodos(dgvVerUser);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvVerUser.DataSource = null;
        }
        #endregion

        //#region Tab Alta Empleados
        //private void btnRefreshAlta_Click(object sender, EventArgs e)
        //{
        //    TraerTodos(dgvVerEmpAlta);
        //}
        //private void btnAgregarEmp_Click(object sender, EventArgs e)
        //{
        //    string mensaje;
        //    TraerTodos(dgvVerEmpAlta);

        //    // Llamar a ValidarCampos y verificar si la validación es exitosa
        //    if (!ValidarCamposAlta(out mensaje))
        //    {
        //        // Si la validación falla, mostrar el mensaje de error y salir del método
        //        MessageBox.Show(mensaje);
        //        return;
        //    }

        //    try
        //    {
        //        empleado.Nombre = txtNombre.Text;
        //        empleado.Apellido = txtApellido.Text;
        //        empleado.Id_Sexo = Convert.ToInt32(cmbSexo.SelectedValue);
        //        empleado.Id_Tipodni = Convert.ToInt32(cmbTipoDNI.SelectedValue);
        //        empleado.Dni = Convert.ToInt32(txtDNI.Text);
        //        empleado.Fecha_Nac = dateNacimiento.Value;
        //        empleado.Email = txtEmail.Text;
        //        empleado.Telefono = Convert.ToInt32(txtCelularAlta.Text);
        //        empleado.Id_Localidad = Convert.ToInt32(cmbLocalidad.SelectedValue);
        //        empleado.Calle = txtCalle.Text;
        //        empleado.Numero_Calle = Convert.ToInt32(txtNumCalle.Text);
        //        empleado.Id_Cargo = Convert.ToInt32(cmbCargo.SelectedValue);
        //        empleado.Estado = chkEstadoAlta.Checked;

        //        empleado.AgregarEmpleado();
        //        MessageBox.Show("Empleado Agregado Correctamente");
        //        TraerTodos(dgvVerEmpAlta);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Ocurrió un Error: {ex.Message}");
        //    }

        //}



        //#endregion

        //#region Tab Modificar Empleados
        //private void btnRefreshModif_Click(object sender, EventArgs e)
        //{
        //    if (dgvVerEmpModif.DataSource != null)
        //    {
        //        dgvVerEmpModif.DataSource = null;
        //        TraerTodos(dgvVerEmpModif);
        //    }
        //}
        //private void btnCargarListaModif_Click(object sender, EventArgs e)
        //{
        //    TraerTodos(dgvVerEmpModif);
        //}
        //private void btnModificarEmp_Click(object sender, EventArgs e)
        //{
        //    string mensaje;

        //    // Llamar a ValidarCampos y verificar si la validación es exitosa
        //    if (!ValidarCamposModif(out mensaje))
        //    {
        //        // Si la validación falla, mostrar el mensaje de error y salir del método
        //        MessageBox.Show(mensaje);
        //        return;
        //    }

        //    try
        //    {
        //        int selectedRowIndex = dgvVerEmpModif.CurrentCell.RowIndex;

        //        empleado.Id_Empleado = EmpleadoSeleccionadoId;
        //        empleado.Nombre = txtNombreModif.Text;
        //        empleado.Apellido = txtApellidoModif.Text;
        //        empleado.Id_Sexo = Convert.ToInt32(cmbSexoModif.SelectedValue);
        //        empleado.Id_Tipodni = Convert.ToInt32(cmbTipoDNIModif.SelectedValue);
        //        empleado.Dni = Convert.ToInt32(txtDNIModif.Text);
        //        empleado.Fecha_Nac = dateNacimientoModif.Value;
        //        empleado.Email = txtEmailModif.Text;
        //        empleado.Telefono = Convert.ToInt32(txtCelularModif.Text);
        //        empleado.Id_Localidad = Convert.ToInt32(cmbLocalidadModif.SelectedValue);
        //        empleado.Calle = txtCalleModif.Text;
        //        empleado.Numero_Calle = Convert.ToInt32(txtNumCalleModif.Text);
        //        empleado.Id_Cargo = Convert.ToInt32(cmbCargoModif.SelectedValue);
        //        empleado.Estado = chkEstadoModif.Checked;

        //        empleado.ModificarEmpleado();
        //        MessageBox.Show("Empleado Modificado Correctamente");
        //        TraerTodos(dgvVerEmpModif);

        //        dgvVerEmpModif.ClearSelection();
        //        if (selectedRowIndex >= 0 && selectedRowIndex < dgvVerEmpModif.Rows.Count)
        //        {
        //            dgvVerEmpModif.Rows[selectedRowIndex].Selected = true;
        //            dgvVerEmpModif.CurrentCell = dgvVerEmpModif.Rows[selectedRowIndex].Cells[0];
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Ocurrió un Error: {ex.Message}");
        //    }
        //}

        //private void dgvVerEmpModif_SelectionChanged(object sender, EventArgs e)
        //{
        //    if (dgvVerEmpModif.SelectedRows.Count > 0)
        //    {
        //        DataGridViewRow row = dgvVerEmpModif.SelectedRows[0];
        //        EmpleadoSeleccionadoId = Convert.ToInt32(row.Cells["id_empleado"].Value);

        //        // Asignar los datos de la fila seleccionada a los controles correspondientes
        //        txtNombreModif.Text = row.Cells["nombre"].Value.ToString();
        //        txtApellidoModif.Text = row.Cells["apellido"].Value.ToString();
        //        cmbSexoModif.SelectedValue = row.Cells["id_sexo"].Value;
        //        cmbTipoDNIModif.SelectedValue = row.Cells["id_tipodni"].Value;
        //        txtDNIModif.Text = row.Cells["dni"].Value.ToString();
        //        dateNacimientoModif.Value = Convert.ToDateTime(row.Cells["fecha_nac"].Value);
        //        txtEmailModif.Text = row.Cells["email"].Value.ToString();
        //        txtCelularModif.Text = row.Cells["telefono"].Value.ToString(); 
        //        cmbLocalidadModif.SelectedValue = row.Cells["id_localidad"].Value;
        //        txtCalleModif.Text = row.Cells["calle"].Value.ToString();
        //        txtNumCalleModif.Text = row.Cells["numero_calle"].Value.ToString();
        //        cmbCargoModif.SelectedValue = row.Cells["id_cargo"].Value;
        //        chkEstadoModif.Checked = Convert.ToBoolean(row.Cells["estado"].Value);
        //    }

        //}
        //#endregion

        //#region Tab Baja de Empleado
        //private void btnRefreshBaja_Click(object sender, EventArgs e)
        //{
        //    if (dgvVerEmpBaja.DataSource != null)
        //    {
        //        dgvVerEmpBaja.DataSource = null;
        //        TraerTodos(dgvVerEmpBaja);
        //    }
        //}
        //private void btnCargarEmpBaja_Click(object sender, EventArgs e)
        //{
        //    TraerTodos(dgvVerEmpBaja);
        //}




        //#endregion

        //private void dgvVerEmpBaja_SelectionChanged(object sender, EventArgs e)
        //{
        //    if (dgvVerEmpBaja.SelectedRows.Count > 0)
        //    {
        //        DataGridViewRow row = dgvVerEmpBaja.SelectedRows[0];
        //        EmpleadoSeleccionadoId = Convert.ToInt32(row.Cells["id_empleado"].Value);

        //        // Asignar los datos de la fila seleccionada a los controles correspondientes
        //        txtNombreBaja.Text = row.Cells["nombre"].Value.ToString();
        //        txtApellidoBaja.Text = row.Cells["apellido"].Value.ToString();
        //        cmbSexoBaja.SelectedValue = row.Cells["id_sexo"].Value;
        //        cmbTipoDNIBaja.SelectedValue = row.Cells["id_tipodni"].Value;
        //        txtDNIBaja.Text = row.Cells["dni"].Value.ToString();
        //        dateNacimientoBaja.Value = Convert.ToDateTime(row.Cells["fecha_nac"].Value);
        //        txtEmailBaja.Text = row.Cells["email"].Value.ToString();
        //        txtCelularBaja.Text = row.Cells["telefono"].Value.ToString();
        //        cmbLocalidadBaja.SelectedValue = row.Cells["id_localidad"].Value;
        //        txtCalleBaja.Text = row.Cells["calle"].Value.ToString();
        //        txtNumCalleBaja.Text = row.Cells["numero_calle"].Value.ToString();
        //        cmbCargoBaja.SelectedValue = row.Cells["id_cargo"].Value;
        //        chkEstadoBaja.Checked = Convert.ToBoolean(row.Cells["estado"].Value);
        //    }
        //}

        //private void btnEliminarEmp_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        empleado.EliminarEmpleado(EmpleadoSeleccionadoId);
        //        MessageBox.Show("Empleado Eliminado Correctamente");
        //        TraerTodos(dgvVerEmpBaja);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Ocurrió un Error: {ex.Message}");
        //    }
        //}
    }
}