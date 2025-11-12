using CapaDTO.SistemaDTO;
using CapaLogica.ABM;
using CapaLogica.LlenarCombos;
using CapaLogica.SistemaLogica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CapaVistas.Forms_Menu
{
    public partial class frmProfesionales : Form
    {
        private cls_LogicaGestionarProfesionales _logicaProfesional;
        private cls_LlenarCombos _rellenador;
        private int _idProfesionalSeleccionado = -1;

        public frmProfesionales()
        {
            InitializeComponent();
            _logicaProfesional = new cls_LogicaGestionarProfesionales();
            _rellenador = new cls_LlenarCombos();
            cmbOrden.SelectedIndex = 0;
        }

        private void frmProfesionales_Load(object sender, EventArgs e)
        {
            CargarProfesionalesEnDataGridView();
            CargarCombos();
        }

        private void CargarProfesionalesEnDataGridView()
        {
            try
            {
                List<cls_ProfesionalDTO> listaProfesionales = _logicaProfesional.ObtenerProfesionalesActivos();
                dgvVerProfesionales.DataSource = listaProfesionales;
                dgvVerProfesionales.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                dgvVerProfesionales.ReadOnly = true;
                dgvVerProfesionales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvVerProfesionales.AllowUserToAddRows = false;

                // Ocultar columnas que no se necesitan mostrar
                dgvVerProfesionales.Columns["id_localidad"].Visible = false;
                dgvVerProfesionales.Columns["id_sexo"].Visible = false;
                dgvVerProfesionales.Columns["id_tipo_dni"].Visible = false;
                dgvVerProfesionales.Columns["id_especialidad"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los profesionales en la vista: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CargarCombos()
        {
            var cargaLocalidades = _rellenador.ObtenerLocalidades();
            var cargaSexos = _rellenador.ObtenerSexos();
            var cargaTiposDocumento = _rellenador.ObtenerTiposDocumento();
            var cargaEspecialidades = _rellenador.ObtenerEspecialidades();

            try
            {
                // Cargar combos normales (estos parecen funcionar bien)
                CapaUtilidades.cls_LlenarCombos.Cargar(cmbTipoDNI, cargaTiposDocumento.TiposDocumento, "descripcion", "id_tipo_documento");
                CapaUtilidades.cls_LlenarCombos.Cargar(cmbLocalidad, cargaLocalidades.Localidades, "nombre_localidad", "id_localidad");
                CapaUtilidades.cls_LlenarCombos.Cargar(cmbSexo, cargaSexos.Sexos, "descripcion", "id_sexo");
                CapaUtilidades.cls_LlenarCombos.Cargar(cmbEspecialidad, cargaEspecialidades.Especialidades, "especialidad", "id_especialidad");

                // CORRECCIÓN COMPLETA PARA cmbOrdenEspecialidad
                CargarComboEspecialidadesFiltro(cargaEspecialidades.Especialidades);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los ComboBoxes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarComboEspecialidadesFiltro(dynamic especialidadesOriginales)
        {
            try
            {
                // Crear una DataTable para asegurar tipos correctos
                DataTable dtEspecialidades = new DataTable();
                dtEspecialidades.Columns.Add("id_especialidad", typeof(int));
                dtEspecialidades.Columns.Add("especialidad", typeof(string));

                // Agregar opción "Todas las Especialidades"
                dtEspecialidades.Rows.Add(0, "Todas las Especialidades");

                // Agregar las especialidades reales
                if (especialidadesOriginales != null)
                {
                    foreach (var esp in especialidadesOriginales)
                    {
                        // Acceder a las propiedades por reflexión para ser más seguro
                        int id = (int)esp.GetType().GetProperty("id_especialidad").GetValue(esp, null);
                        string nombre = (string)esp.GetType().GetProperty("especialidad").GetValue(esp, null);

                        dtEspecialidades.Rows.Add(id, nombre);
                    }
                }

                // Asignar directamente al ComboBox
                cmbOrdenEspecialidad.DataSource = dtEspecialidades;
                cmbOrdenEspecialidad.DisplayMember = "especialidad";
                cmbOrdenEspecialidad.ValueMember = "id_especialidad";

                // Establecer selección por defecto
                cmbOrdenEspecialidad.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar especialidades para filtro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarFiltrosCombinados()
        {
            try
            {
                List<cls_ProfesionalDTO> listaProfesionales;

                string estadoSeleccionado = cmbOrden.SelectedItem?.ToString() ?? "Profesionales Activos";
                int? idEspecialidad = ObtenerIdEspecialidadSeleccionada();

                // DEBUG: Ver qué valores estamos obteniendo
                Console.WriteLine($"Estado: {estadoSeleccionado}, Especialidad: {idEspecialidad}");

                // Si no hay especialidad seleccionada (o es "Todas"), usar solo el filtro de estado
                if (!idEspecialidad.HasValue)
                {
                    if (estadoSeleccionado == "Profesionales Activos")
                        listaProfesionales = _logicaProfesional.ObtenerProfesionalesActivos();
                    else if (estadoSeleccionado == "Profesionales Inactivos")
                        listaProfesionales = _logicaProfesional.ObtenerProfesionalesInactivos();
                    else
                        listaProfesionales = _logicaProfesional.ObtenerProfesionales();
                }
                else
                {
                    // Usar los métodos específicos que filtran en la base de datos
                    if (estadoSeleccionado == "Profesionales Activos")
                        listaProfesionales = _logicaProfesional.ObtenerProfesionalesActivosPorEspecialidad(idEspecialidad.Value);
                    else if (estadoSeleccionado == "Profesionales Inactivos")
                        listaProfesionales = _logicaProfesional.ObtenerProfesionalesInactivosPorEspecialidad(idEspecialidad.Value);
                    else
                        listaProfesionales = _logicaProfesional.ObtenerTodosProfesionalesPorEspecialidad(idEspecialidad.Value);
                }

                MostrarProfesionalesEnDataGridView(listaProfesionales);
            }
            catch (Exception)
            {
                
            }
        }

        private int? ObtenerIdEspecialidadSeleccionada()
        {
            try
            {
                if (cmbOrdenEspecialidad.SelectedItem != null &&
                    cmbOrdenEspecialidad.SelectedIndex > 0) // Index 0 es "Todas"
                {
                    // Obtener el valor directamente del DataRowView
                    DataRowView selectedRow = cmbOrdenEspecialidad.SelectedItem as DataRowView;
                    if (selectedRow != null)
                    {
                        int idEspecialidad = Convert.ToInt32(selectedRow["id_especialidad"]);
                        if (idEspecialidad > 0)
                        {
                            return idEspecialidad;
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                // Mensaje más informativo
                MessageBox.Show($"Error al obtener especialidad: {ex.Message}\nTipo: {cmbOrdenEspecialidad.SelectedItem?.GetType().Name}",
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        private void MostrarProfesionalesEnDataGridView(List<cls_ProfesionalDTO> profesionales)
        {
            dgvVerProfesionales.DataSource = profesionales;
            dgvVerProfesionales.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            // Configurar columnas
            dgvVerProfesionales.Columns["es_activo"].Visible = false;
            dgvVerProfesionales.Columns["id_localidad"].Visible = false;
            dgvVerProfesionales.Columns["id_sexo"].Visible = false;
            dgvVerProfesionales.Columns["id_tipo_dni"].Visible = false;
            dgvVerProfesionales.Columns["id_especialidad"].Visible = false;
            dgvVerProfesionales.SelectedRows.Clear();
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDni.Clear();
            txtNumMatricula.Clear();
            txtDomicilio.Clear();
            txtNumDomicilio.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtBusquedaProfesional.Clear();

            if (cmbLocalidad.Items.Count > 0) cmbLocalidad.SelectedIndex = -1;
            if (cmbSexo.Items.Count > 0) cmbSexo.SelectedIndex = -1;
            if (cmbTipoDNI.Items.Count > 0) cmbTipoDNI.SelectedIndex = -1;
            if (cmbEspecialidad.Items.Count > 0) cmbEspecialidad.SelectedIndex = -1;

            dateFechaNac.Value = DateTime.Now;
            _idProfesionalSeleccionado = -1;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtNumMatricula.Text) || string.IsNullOrWhiteSpace(txtDomicilio.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos de texto obligatorios.", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtDni.Text, out int dni) || dni <= 0)
            {
                MessageBox.Show("El DNI debe ser un número entero válido y positivo.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtNumDomicilio.Text, out int numDomicilio) || numDomicilio <= 0)
            {
                MessageBox.Show("El número de domicilio debe ser un número entero válido y positivo.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtTelefono.Text, out int telefono) || telefono <= 0)
            {
                MessageBox.Show("El teléfono debe ser un número entero válido y positivo.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            AplicarFiltrosCombinados();
            CargarCombos();
            cmbOrden.SelectedIndex = 0;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CargarProfesionalesEnDataGridView();
            CargarCombos();
            cmbOrden.SelectedIndex = 0;
        }
        private void dgvVerProfesionales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= -1)
            {
                try
                {
                    DataGridViewRow filaSeleccionada = dgvVerProfesionales.Rows[e.RowIndex];
                    cls_ProfesionalDTO profesionalSeleccionado = (cls_ProfesionalDTO)filaSeleccionada.DataBoundItem;

                    _idProfesionalSeleccionado = profesionalSeleccionado.id_profesional;

                    txtNombre.Text = profesionalSeleccionado.nombre;
                    txtApellido.Text = profesionalSeleccionado.apellido;
                    txtDni.Text = profesionalSeleccionado.dni.ToString();
                    txtNumMatricula.Text = profesionalSeleccionado.num_matricula;
                    txtDomicilio.Text = profesionalSeleccionado.domicilio;
                    txtNumDomicilio.Text = profesionalSeleccionado.num_domicilio.ToString();
                    txtTelefono.Text = profesionalSeleccionado.telefono.ToString();
                    txtEmail.Text = profesionalSeleccionado.email;

                    if (profesionalSeleccionado.id_tipo_dni > 0)
                    {
                        cmbTipoDNI.SelectedValue = profesionalSeleccionado.id_tipo_dni;
                    }
                    else
                    {
                        cmbTipoDNI.SelectedIndex = -1;
                    }

                    if (profesionalSeleccionado.id_sexo > 0)
                    {
                        cmbSexo.SelectedValue = profesionalSeleccionado.id_sexo;
                    }
                    else
                    {
                        cmbSexo.SelectedIndex = -1;
                    }

                    if (profesionalSeleccionado.id_localidad > 0)
                    {
                        cmbLocalidad.SelectedValue = profesionalSeleccionado.id_localidad;
                    }
                    else
                    {
                        cmbLocalidad.SelectedIndex = -1;
                    }

                    if (profesionalSeleccionado.id_especialidad > 0)
                    {
                        cmbEspecialidad.SelectedValue = profesionalSeleccionado.id_especialidad;
                    }
                    else
                    {
                        cmbEspecialidad.SelectedIndex = -1;
                    }

                    if (profesionalSeleccionado.fecha_nac.HasValue &&
                        profesionalSeleccionado.fecha_nac.Value >= dateFechaNac.MinDate &&
                        profesionalSeleccionado.fecha_nac.Value <= dateFechaNac.MaxDate)
                    {
                        dateFechaNac.Value = profesionalSeleccionado.fecha_nac.Value;
                    }
                    else
                    {
                        dateFechaNac.Value = DateTime.Now;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al seleccionar profesional: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _idProfesionalSeleccionado = -1;
                }
            }
        }



        private void dgvVerProfesionales_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVerProfesionales.CurrentRow != null && dgvVerProfesionales.CurrentRow.Index >= 0)
            {
                try
                {
                    cls_ProfesionalDTO profesionalSeleccionado = (cls_ProfesionalDTO)dgvVerProfesionales.CurrentRow.DataBoundItem;
                    _idProfesionalSeleccionado = profesionalSeleccionado.id_profesional;

                    // Manejar tanto bool? como bool
                    bool estaInactivo = profesionalSeleccionado.es_activo.HasValue ?
                                       !profesionalSeleccionado.es_activo.Value :
                                       false;

                    btnReactivar.Visible = (_idProfesionalSeleccionado > 0 && estaInactivo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener la selección del profesional: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _idProfesionalSeleccionado = -1;
                    btnReactivar.Visible = false;
                }
            }
        }
        private void dgvVerProfesionales_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow filaSeleccionada = dgvVerProfesionales.Rows[e.RowIndex];
                    cls_ProfesionalDTO profesionalSeleccionado = (cls_ProfesionalDTO)filaSeleccionada.DataBoundItem;

                    _idProfesionalSeleccionado = profesionalSeleccionado.id_profesional;

                    txtNombre.Text = profesionalSeleccionado.nombre;
                    txtApellido.Text = profesionalSeleccionado.apellido;
                    txtDni.Text = profesionalSeleccionado.dni.ToString();
                    txtNumMatricula.Text = profesionalSeleccionado.num_matricula;
                    txtDomicilio.Text = profesionalSeleccionado.domicilio;
                    txtNumDomicilio.Text = profesionalSeleccionado.num_domicilio.ToString();
                    txtTelefono.Text = profesionalSeleccionado.telefono.ToString();
                    txtEmail.Text = profesionalSeleccionado.email;

                    if (profesionalSeleccionado.id_tipo_dni > 0)
                    {
                        cmbTipoDNI.SelectedValue = profesionalSeleccionado.id_tipo_dni;
                    }
                    else
                    {
                        cmbTipoDNI.SelectedIndex = -1;
                    }

                    if (profesionalSeleccionado.id_sexo > 0)
                    {
                        cmbSexo.SelectedValue = profesionalSeleccionado.id_sexo;
                    }
                    else
                    {
                        cmbSexo.SelectedIndex = -1;
                    }

                    if (profesionalSeleccionado.id_localidad > 0)
                    {
                        cmbLocalidad.SelectedValue = profesionalSeleccionado.id_localidad;
                    }
                    else
                    {
                        cmbLocalidad.SelectedIndex = -1;
                    }

                    if (profesionalSeleccionado.id_especialidad > 0)
                    {
                        cmbEspecialidad.SelectedValue = profesionalSeleccionado.id_especialidad;
                    }
                    else
                    {
                        cmbEspecialidad.SelectedIndex = -1;
                    }

                    if (profesionalSeleccionado.fecha_nac.HasValue &&
                        profesionalSeleccionado.fecha_nac.Value >= dateFechaNac.MinDate &&
                        profesionalSeleccionado.fecha_nac.Value <= dateFechaNac.MaxDate)
                    {
                        dateFechaNac.Value = profesionalSeleccionado.fecha_nac.Value;
                    }
                    else
                    {
                        dateFechaNac.Value = DateTime.Now;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al seleccionar profesional: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _idProfesionalSeleccionado = -1;
                }
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            cls_ProfesionalDTO nuevoProfesional = new cls_ProfesionalDTO
            {
                nombre = txtNombre.Text,
                apellido = txtApellido.Text,
                dni = Convert.ToInt32(txtDni.Text),
                id_tipo_dni = Convert.ToInt32(cmbTipoDNI.SelectedValue),
                id_sexo = Convert.ToInt32(cmbSexo.SelectedValue),
                telefono = Convert.ToInt32(txtTelefono.Text),
                num_matricula = txtNumMatricula.Text,
                id_localidad = Convert.ToInt32(cmbLocalidad.SelectedValue),
                domicilio = txtDomicilio.Text,
                num_domicilio = Convert.ToInt32(txtNumDomicilio.Text),
                fecha_nac = dateFechaNac.Value,
                email = txtEmail.Text,
                id_especialidad = Convert.ToInt32(cmbEspecialidad.SelectedValue),
                es_activo = Convert.ToBoolean(1)
            };

            if (_logicaProfesional.InsertarProfesional(nuevoProfesional))
            {
                MessageBox.Show("Profesional creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarProfesionalesEnDataGridView();
                cmbOrden.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("No se pudo crear el profesional. Verifique los datos o la conexión.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (_idProfesionalSeleccionado == -1)
            {
                MessageBox.Show("Por favor, seleccione un profesional de la lista para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarCampos()) return;

            cls_ProfesionalDTO profesionalOriginal = _logicaProfesional.BuscarProfesionalPorDni(Convert.ToInt32(txtDni.Text));

            cls_ProfesionalDTO profesionalModificado = new cls_ProfesionalDTO
            {
                id_profesional = _idProfesionalSeleccionado,
                nombre = txtNombre.Text,
                apellido = txtApellido.Text,
                dni = Convert.ToInt32(txtDni.Text),
                id_tipo_dni = Convert.ToInt32(cmbTipoDNI.SelectedValue),
                id_sexo = Convert.ToInt32(cmbSexo.SelectedValue),
                telefono = Convert.ToInt32(txtTelefono.Text),
                num_matricula = txtNumMatricula.Text,
                id_localidad = Convert.ToInt32(cmbLocalidad.SelectedValue),
                domicilio = txtDomicilio.Text,
                num_domicilio = Convert.ToInt32(txtNumDomicilio.Text),
                fecha_nac = dateFechaNac.Value,
                email = txtEmail.Text,
                id_especialidad = Convert.ToInt32(cmbEspecialidad.SelectedValue),
                es_activo = profesionalOriginal?.es_activo ?? true
            };

            if (_logicaProfesional.ActualizarProfesional(profesionalModificado))
            {
                MessageBox.Show("Profesional modificado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                AplicarFiltrosCombinados();
            }
            else
            {
                MessageBox.Show("No se pudo modificar el profesional. Verifique los datos o la conexión.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_idProfesionalSeleccionado == -1)
            {
                MessageBox.Show("Por favor, seleccione un profesional de la lista para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de que desea eliminar al profesional seleccionado? Esto lo inactivará del sistema.",
                "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                if (_logicaProfesional.EliminarProfesional(_idProfesionalSeleccionado))
                {
                    MessageBox.Show("Profesional eliminado lógicamente (inactivado) exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarProfesionalesEnDataGridView();
                    cmbOrden.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el profesional. Verifique los datos o la conexión.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }





        private void btnBuscarDNI_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtBusquedaProfesional.Text, out int dniBuscado))
            {
                MessageBox.Show("Por favor, ingrese un número de DNI válido.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBusquedaProfesional.Clear();
                return;
            }

            try
            {
                cls_ProfesionalDTO profesionalEncontrado = _logicaProfesional.BuscarProfesionalPorDni(dniBuscado);

                if (profesionalEncontrado != null)
                {

                    List<cls_ProfesionalDTO> resultado = new List<cls_ProfesionalDTO> { profesionalEncontrado };

                    dgvVerProfesionales.DataSource = resultado;

                    MessageBox.Show($"Profesional {profesionalEncontrado.nombre} {profesionalEncontrado.apellido} encontrado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    MessageBox.Show($"No se encontró ningún profesional con DNI: {dniBuscado}.", "No Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarProfesionalesEnDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar el profesional: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CargarProfesionalesEnDataGridView();
            }
        }

        private void btnReactivar_Click(object sender, EventArgs e)
        {
            if (_idProfesionalSeleccionado == -1)
            {
                MessageBox.Show("Por favor, seleccione un profesional de la lista para Reactivar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de que desea REACTIVAR al profesional seleccionado? Esto lo reactivara en el sistema.",
                "Confirmar Reactivación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                if (_logicaProfesional.ReactivarProfesional(_idProfesionalSeleccionado))
                {
                    MessageBox.Show("Profesional Reactivado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarProfesionalesEnDataGridView();
                    cmbOrden.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("No se pudo reactivar el profesional. Verifique los datos o la conexión.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void cmbOrden_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarCampos();
            AplicarFiltrosCombinados();
            _idProfesionalSeleccionado = -1;
        }

        private void cmbOrdenEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {

                LimpiarCampos();
                AplicarFiltrosCombinados();
            _idProfesionalSeleccionado = -1;
        }

        private void btnEspecialidadMedica_Click(object sender, EventArgs e)
        {
            using (var frmEspecialidad = new frmABMEspecialidades())
            {
                frmEspecialidad.ShowDialog();
            }
        }

        private void btnHorariosProf_Click(object sender, EventArgs e)
        {
            // 1. Verificamos que el usuario haya seleccionado un profesional
            if (dgvVerProfesionales.SelectedRows.Count > 0)
            {
                // 2. Obtenemos los datos de la fila seleccionada
                DataGridViewRow filaSeleccionada = dgvVerProfesionales.SelectedRows[0];

                int idProfesionalSeleccionado = Convert.ToInt32(filaSeleccionada.Cells["id_profesional"].Value);
                string nombre = filaSeleccionada.Cells["nombre"].Value.ToString();
                string apellido = filaSeleccionada.Cells["apellido"].Value.ToString();
                string nombreCompleto = $"{apellido}, {nombre}";

                frmGestionHorarios formHorarios = new frmGestionHorarios(idProfesionalSeleccionado, nombreCompleto);

                formHorarios.ShowDialog();

            }
            else
            {
                MessageBox.Show("Por favor, seleccione un profesional de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtBusquedaProfesional_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnBuscarDNI.PerformClick(); 
        }
    }
}