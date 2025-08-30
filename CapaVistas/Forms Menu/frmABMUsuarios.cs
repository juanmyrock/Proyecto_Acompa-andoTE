using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CapaDTO;
using CapaDTO.SistemaDTO;
using CapaLogica;
using CapaLogica.ABM;
using CapaLogica.LlenarCombos;
using CapaLogica.SistemaLogica;


namespace CapaVistas.Forms_Menu
{
    public partial class frmABMUsuarios : Form
    {
        private cls_LogicaGestionEmpleados _logicaEmpleado;
        private cls_TipoDNILogica _logicaTipoDNI;
        private cls_LocalidadLogica _logicaLocalidad;
        private cls_SexoLogica _logicaSexo;
        private int _idEmpleadoSeleccionado = -1; // Variable para guardar el ID del empleado seleccionado
        private cls_Empleado _logicaEmpleado;
        private int _idEmpleadoSeleccionado = -1;
        private cls_LlenarCombos _rellenador;
        public frmABMUsuarios()
        {
            InitializeComponent();
            _logicaEmpleado = new cls_LogicaGestionEmpleados();
            _logicaTipoDNI = new cls_TipoDNILogica();
            _logicaLocalidad = new cls_LocalidadLogica();
            _logicaSexo = new cls_SexoLogica();
            _logicaEmpleado = new cls_Empleado();
            _rellenador = new cls_LlenarCombos();
        }
        

        
        private void CargarEmpleadosEnDataGridView()
        {
            try
            {
                List<cls_EmpleadoDTO> listaEmpleados = _logicaEmpleado.ObtenerEmpleados();
                dgvVerUser.DataSource = listaEmpleados;

                dgvVerUser.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                dgvVerUser.ReadOnly = true;
                dgvVerUser.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvVerUser.AllowUserToAddRows = false;
                dgvVerUser.Columns["id_sexo"].Visible = false;
                dgvVerUser.Columns["id_tipo_dni"].Visible = false;
                dgvVerUser.Columns["id_localidad"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los empleados en la vista: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCombos()
        {
            var cargaLocalidades = _rellenador.ObtenerLocalidades();
            var cargaSexos = _rellenador.ObtenerSexos();
            var cargaTiposDocumento = _rellenador.ObtenerTiposDocumento();
            try
            {
                
                CapaUtilidades.cls_LlenarCombos.Cargar(cmbTipoDNI, cargaTiposDocumento.TiposDocumento, "descripcion", "id_tipo_documento");
                CapaUtilidades.cls_LlenarCombos.Cargar(cmbLocalidad, cargaLocalidades.Localidades, "nombre_localidad", "id_localidad");
                CapaUtilidades.cls_LlenarCombos.Cargar(cmbSexo, cargaSexos.Sexos, "descripcion", "id_sexo");
                    
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
            if (e.RowIndex >= -1)
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
                    txtPuesto.Text = empleadoSeleccionado.puesto;
                    txtCargaHS.Text = empleadoSeleccionado.carga_hs.ToString();
                    // DateTimePicker
                    // Verifica si la fecha está dentro del rango permitido del DateTimePicker
                    if (empleadoSeleccionado.fecha_nac >= dateNacimiento.MinDate &&
                        empleadoSeleccionado.fecha_nac <= dateNacimiento.MaxDate)
                    {
                        dateNacimiento.Value = empleadoSeleccionado.fecha_nac;
                    }
                    else
                    {
                        // Si la fecha está fuera de rango, asigna una fecha válida, por ejemplo, la fecha actual
                        dateNacimiento.Value = DateTime.Now;
                        MessageBox.Show("La fecha de nacimiento del empleado está fuera del rango permitido y se ha establecido a la fecha actual.", "Advertencia de Fecha", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al seleccionar empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LimpiarCampos()
        {
            try
            {
                txtNombre.Clear();
                txtApellido.Clear();
                txtDNI.Clear();
                txtCalle.Clear();
                txtNumCalle.Clear();
                txtEmail.Clear();
                txtCelular.Clear();
                txtPuesto.Clear();
                txtCargaHS.Clear();
                if (cmbTipoDNI.Items.Count > 0) cmbTipoDNI.SelectedIndex = -1;
                if (cmbLocalidad.Items.Count > 0) cmbLocalidad.SelectedIndex = -1;
                if (cmbSexo.Items.Count > 0) cmbSexo.SelectedIndex = -1;
                dateNacimiento.Value = DateTime.Now;
            }
            catch (Exception) 
            {
                MessageBox.Show("No se pudieron borrar todos los campos");
            }     
            
        }
        #region Creación de Empleado
        private void btnCrear_Click(object sender, EventArgs e)
        {
            // 1. Validar los campos de entrada
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtDNI.Text) ||
                string.IsNullOrWhiteSpace(txtCalle.Text) ||
                string.IsNullOrWhiteSpace(txtNumCalle.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtCelular.Text) ||
                string.IsNullOrWhiteSpace(txtCargaHS.Text) ||
                cmbTipoDNI.SelectedValue == null ||
                cmbLocalidad.SelectedValue == null ||
                cmbSexo.SelectedValue == null ||
                dateNacimiento.Value == DateTime.Now)
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (!int.TryParse(txtDNI.Text, out int dni) || dni <= 0)
            {
                MessageBox.Show("El DNI debe ser un número válido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtNumCalle.Text, out int numDomicilio) || numDomicilio <= 0)
            {
                MessageBox.Show("El número de domicilio debe ser un número válido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(txtCargaHS.Text, out decimal cargaHs))
            {
                MessageBox.Show("La carga horaria debe ser un número válido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (cargaHs <= 0) 
            {
                MessageBox.Show("La carga horaria debe ser mayor a 0.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // 2. Crear un objeto DTO con los datos del formulario
            cls_EmpleadoDTO nuevoEmpleado = new cls_EmpleadoDTO
            {
                puesto = txtPuesto.Text, 
                nombre = txtNombre.Text,
                apellido = txtApellido.Text,
                id_sexo = Convert.ToInt32(cmbSexo.SelectedValue),
                id_tipo_dni = Convert.ToInt32(cmbTipoDNI.SelectedValue),
                dni = Convert.ToInt32(txtDNI.Text),
                fecha_nac = dateNacimiento.Value,
                id_localidad = Convert.ToInt32(cmbLocalidad.SelectedValue),
                domicilio = txtCalle.Text,
                num_domicilio = Convert.ToInt32(txtNumCalle.Text),
                carga_hs = cargaHs,
                email = txtEmail.Text,
                telefono = txtCelular.Text
            };

            // 3. Llamar al método de inserción de la capa lógica
            try
            {
                bool insertado = _logicaEmpleado.InsertarEmpleado(nuevoEmpleado);

                if (insertado)
                {
                    MessageBox.Show("Empleado creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarEmpleadosEnDataGridView();
                }
                else
                {
                    MessageBox.Show("No se pudo crear el empleado. Verifique los datos o la conexión.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado al intentar crear el empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
        #region Eliminar Empleado
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // 1. Verificar si hay un empleado seleccionado
            if (_idEmpleadoSeleccionado == -1)
            {
                MessageBox.Show("Por favor, seleccione un empleado de la lista para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Pedir confirmación al usuario
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de que desea eliminar al empleado seleccionado? Esta acción no se puede deshacer.",
                "Confirmar Eliminación",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    // 3. Llamar al método de eliminación de la capa lógica
                    bool eliminado = _logicaEmpleado.EliminarEmpleado(_idEmpleadoSeleccionado);

                    if (eliminado)
                    {
                        MessageBox.Show("Empleado eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _idEmpleadoSeleccionado = -1; 
                        LimpiarCampos(); 
                        CargarEmpleadosEnDataGridView(); 
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el empleado. Verifique los datos o la conexión.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al intentar eliminar el empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
        #region Modificar Empleado
        private void btnModificar_Click(object sender, EventArgs e)
        {
            // 1. Verificar si hay un empleado seleccionado para modificar
            if (_idEmpleadoSeleccionado == -1)
            {
                MessageBox.Show("Por favor, seleccione un empleado de la lista para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validar los campos de entrada
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtDNI.Text) ||
                string.IsNullOrWhiteSpace(txtCalle.Text) ||
                string.IsNullOrWhiteSpace(txtNumCalle.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtCelular.Text) ||
                string.IsNullOrWhiteSpace(txtPuesto.Text) ||
                string.IsNullOrWhiteSpace(txtCargaHS.Text) ||
                cmbTipoDNI.SelectedValue == null ||
                cmbLocalidad.SelectedValue == null ||
                cmbSexo.SelectedValue == null)
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtDNI.Text, out int dni) || dni <= 0)
            {
                MessageBox.Show("El DNI debe ser un número válido y positivo.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtNumCalle.Text, out int numDomicilio) || numDomicilio <= 0)
            {
                MessageBox.Show("El número de domicilio debe ser un número válido y positivo.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(txtCargaHS.Text, out decimal cargaHs))
            {
                MessageBox.Show("La carga horaria debe ser un número válido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cargaHs <= 0)
            {
                MessageBox.Show("La carga horaria debe ser mayor a 0.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult confirmacion = MessageBox.Show(
            "El ID del empleado seleccionado es: " + _idEmpleadoSeleccionado + "\n¿Seguro que desea modificarlo?", "Confirmar Modificación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (confirmacion == DialogResult.No)
            {
                return;
            }

            // 3. Crear un objeto DTO con los datos actualizados del formulario
            try
            {
                cls_EmpleadoDTO empleadoModificado = new cls_EmpleadoDTO
                {
                    id_empleado = _idEmpleadoSeleccionado,
                    puesto = txtPuesto.Text,
                    nombre = txtNombre.Text,
                    apellido = txtApellido.Text,
                    id_sexo = Convert.ToInt32(cmbSexo.SelectedValue),
                    id_tipo_dni = Convert.ToInt32(cmbTipoDNI.SelectedValue),
                    dni = Convert.ToInt32(txtDNI.Text),
                    fecha_nac = dateNacimiento.Value,
                    id_localidad = Convert.ToInt32(cmbLocalidad.SelectedValue),
                    domicilio = txtCalle.Text,
                    num_domicilio = Convert.ToInt32(txtNumCalle.Text),
                    carga_hs = cargaHs,
                    email = txtEmail.Text,
                    telefono = txtCelular.Text
                };

                // 4. Llamar al método de actualización de la capa lógica
                bool actualizado = _logicaEmpleado.ActualizarEmpleado(empleadoModificado);

                if (actualizado)
                {
                    MessageBox.Show("Empleado modificado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarEmpleadosEnDataGridView();
                }
                else
                {
                    MessageBox.Show("No se pudo modificar el empleado. Verifique los datos o la conexión.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show("Error de formato en los datos ingresados. Por favor, asegúrese de que todos los campos numéricos y de fecha son correctos: " + ex.Message, "Error de Conversión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado al intentar modificar el empleado: " + ex.Message, "Error General", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        private void dgvVerUser_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVerUser.CurrentRow != null && dgvVerUser.CurrentRow.Index >= 0)
            {
                try
                {
                    cls_EmpleadoDTO empleadoSeleccionado = (cls_EmpleadoDTO)dgvVerUser.CurrentRow.DataBoundItem;

                    _idEmpleadoSeleccionado = empleadoSeleccionado.id_empleado;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener la selección del empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _idEmpleadoSeleccionado = -1;
                }
            }
            else
            {
                _idEmpleadoSeleccionado = -1;
            }
        }

        private void dgvVerUser_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow filaSeleccionada = dgvVerUser.Rows[e.RowIndex];

                    cls_EmpleadoDTO empleadoSeleccionado = (cls_EmpleadoDTO)filaSeleccionada.DataBoundItem;

                    _idEmpleadoSeleccionado = empleadoSeleccionado.id_empleado;

                    txtNombre.Text = empleadoSeleccionado.nombre;
                    txtApellido.Text = empleadoSeleccionado.apellido;
                    txtDNI.Text = empleadoSeleccionado.dni.ToString();
                    txtCalle.Text = empleadoSeleccionado.domicilio;
                    txtEmail.Text = empleadoSeleccionado.email;
                    txtCelular.Text = empleadoSeleccionado.telefono;
                    txtNumCalle.Text = empleadoSeleccionado.num_domicilio.ToString();
                    txtPuesto.Text = empleadoSeleccionado.puesto;
                    txtCargaHS.Text = empleadoSeleccionado.carga_hs.ToString();

                    if (cmbTipoDNI.DataSource is List<cls_TipoDocumentoDTO> tiposDniList &&
                        tiposDniList.Exists(t => t.id_tipo_documento == empleadoSeleccionado.id_tipo_dni))
                    {
                        cmbTipoDNI.SelectedValue = empleadoSeleccionado.id_tipo_dni;
                    }
                    else
                    {
                        if (cmbTipoDNI.Items.Count > 0) cmbTipoDNI.SelectedIndex = 0;
                    }

                    if (cmbLocalidad.DataSource is List<cls_LocalidadDTO> localidadesList &&
                        localidadesList.Exists(l => l.id_localidad == empleadoSeleccionado.id_localidad))
                    {
                        cmbLocalidad.SelectedValue = empleadoSeleccionado.id_localidad;
                    }
                    else
                    {
                        if (cmbLocalidad.Items.Count > 0) cmbLocalidad.SelectedIndex = 0;
                    }

                    if (cmbSexo.DataSource is List<cls_SexoDTO> sexosList &&
                        sexosList.Exists(s => s.id_sexo == empleadoSeleccionado.id_sexo))
                    {
                        cmbSexo.SelectedValue = empleadoSeleccionado.id_sexo;
                    }
                    else
                    {
                        if (cmbSexo.Items.Count > 0) cmbSexo.SelectedIndex = 0;
                    }

                    if (empleadoSeleccionado.fecha_nac >= dateNacimiento.MinDate &&
                        empleadoSeleccionado.fecha_nac <= dateNacimiento.MaxDate)
                    {
                        dateNacimiento.Value = empleadoSeleccionado.fecha_nac;
                    }
                    else
                    {
                        dateNacimiento.Value = DateTime.Now;
                        MessageBox.Show("La fecha de nacimiento del empleado está fuera del rango permitido y se ha establecido a la fecha actual.", "Advertencia de Fecha", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos del empleado seleccionado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _idEmpleadoSeleccionado = -1; 
                }
            }
            else
            {
                _idEmpleadoSeleccionado = -1;
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CargarEmpleadosEnDataGridView();
        }

        private void btnGestionarUser_Click(object sender, EventArgs e)
        {
            if (dgvVerUser.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione un empleado de la lista.", "Selección Requerida");
                return;
            }

            // 1. Obtenemos el DTO completo del empleado seleccionado
            var empleadoSeleccionado = (cls_EmpleadoDTO)dgvVerUser.CurrentRow.DataBoundItem;

            try
            {
                var logicaGestion = new cls_LogicaGestionarUsuarios();
                bool usuarioExiste = logicaGestion.VerificarSiUsuarioExiste(empleadoSeleccionado.id_empleado);

                // 2. Creamos el DTO para el formulario hijo y nos aseguramos de pasarle el email.
                var datosParaGestion = new cls_DatosParaGestionUsuarioDTO
                {
                    IdEmpleado = empleadoSeleccionado.id_empleado,
                    NombreCompletoEmpleado = $"{empleadoSeleccionado.nombre} {empleadoSeleccionado.apellido}",
                    UsuarioYaExiste = usuarioExiste,
                    Email = empleadoSeleccionado.email
                };

                // 3. Abrimos el formulario de gestión, pasándole el DTO completo
                using (var formGestion = new frmGestionarUsuario(datosParaGestion))
                {
                    formGestion.ShowDialog();
                }

                // 4. Recargamos la grilla por si hubo cambios
                CargarEmpleadosEnDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al preparar la gestión de usuario: " + ex.Message, "Error");
            }
        }


    }   
}