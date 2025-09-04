﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CapaDTO.SistemaDTO;
using CapaLogica.SistemaLogica;
using CapaLogica.LlenarCombos;

namespace CapaVistas.Forms_Menu
{
    public partial class frmPacientes : Form
    {
        private cls_LogicaGestionarPacientes _logicaPaciente;
        private cls_LlenarCombos _rellenador;
        private int _idPacienteSeleccionado = -1;

        public frmPacientes()
        {
            InitializeComponent();
            _logicaPaciente = new cls_LogicaGestionarPacientes();
            _rellenador = new cls_LlenarCombos();
        }

        private void frmPacientes_Load(object sender, EventArgs e)
        {
            CargarPacientesEnDataGridView();
            CargarCombos();
        }
        private void CargarPacientesEnDataGridView()
        {
            try
            {
                List<cls_PacienteDTO> listaPacientes = _logicaPaciente.ObtenerPacientes();
                dgvVerPacientes.DataSource = listaPacientes;
                dgvVerPacientes.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                dgvVerPacientes.ReadOnly = true;
                dgvVerPacientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvVerPacientes.AllowUserToAddRows = false;

                dgvVerPacientes.Columns["id_os"].Visible = false;
                dgvVerPacientes.Columns["id_diagnostico"].Visible = false;
                dgvVerPacientes.Columns["id_localidad"].Visible = false;
                dgvVerPacientes.Columns["esActivo"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los pacientes en la vista: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCombos()
        {
            var cargaLocalidades = _rellenador.ObtenerLocalidades();
            var cargaSexos = _rellenador.ObtenerSexos();
            var cargaTiposDocumento = _rellenador.ObtenerTiposDocumento();
            //var obrasSociales = _rellenador.ObtenerObrasSociales();
            try
            {
                //CapaUtilidades.cls_LlenarCombos.Cargar(cmbObraSocial, obrasSociales.ObrasSociales, "descripcion", "id_os");
                CapaUtilidades.cls_LlenarCombos.Cargar(cmbTipoDNI, cargaTiposDocumento.TiposDocumento, "descripcion", "id_tipo_documento");
                CapaUtilidades.cls_LlenarCombos.Cargar(cmbLocalidad, cargaLocalidades.Localidades, "nombre_localidad", "id_localidad");
                CapaUtilidades.cls_LlenarCombos.Cargar(cmbSexo, cargaSexos.Sexos, "descripcion", "id_sexo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los ComboBoxes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDniTitular.Clear();
            txtNumAfiliado.Clear();
            txtDniPaciente.Clear();
            txtCud.Clear();
            txtDomicilio.Clear();
            txtNumDomicilio.Clear();
            txtCargaHoraria.Clear();
            txtAmbito.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            //txtDiagnostico.Clear();
            if (cmbObraSocial.Items.Count > 0) cmbObraSocial.SelectedIndex = -1;

            if (cmbLocalidad.Items.Count > 0) cmbLocalidad.SelectedIndex = -1;
            dateFechaNac.Value = DateTime.Now;
            _idPacienteSeleccionado = -1;
        }


        private bool ValidarCampos()
        {

            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtCud.Text) || string.IsNullOrWhiteSpace(txtDomicilio.Text) ||
                string.IsNullOrWhiteSpace(txtAmbito.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos de texto obligatorios.", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtDniTitular.Text, out int dniTitular) || dniTitular <= 0)
            {
                MessageBox.Show("El DNI del titular debe ser un número entero válido y positivo.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!int.TryParse(txtNumAfiliado.Text, out int numAfiliado) || numAfiliado <= 0)
            {
                MessageBox.Show("El número de afiliado debe ser un número entero válido y positivo.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!int.TryParse(txtDniPaciente.Text, out int dniPaciente) || dniPaciente <= 0)
            {
                MessageBox.Show("El DNI del paciente debe ser un número entero válido y positivo.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (!decimal.TryParse(txtCargaHoraria.Text, out decimal cargaHoraria) || cargaHoraria <= 0)
            {
                MessageBox.Show("La carga horaria debe ser un número decimal válido y positivo.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //if (cmbObraSocial.SelectedValue == null || cmbLocalidad.SelectedValue == null)
            //{
            //    MessageBox.Show("Por favor, seleccione una opción en todos los campos desplegables.", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}

            return true;
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CargarPacientesEnDataGridView();
        }

        private void dgvVerPacientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow filaSeleccionada = dgvVerPacientes.Rows[e.RowIndex];
                    cls_PacienteDTO pacienteSeleccionado = (cls_PacienteDTO)filaSeleccionada.DataBoundItem;

                    _idPacienteSeleccionado = pacienteSeleccionado.id_paciente;

                    txtNombre.Text = pacienteSeleccionado.Nombre;
                    txtApellido.Text = pacienteSeleccionado.Apellido;
                    txtDniTitular.Text = pacienteSeleccionado.dni_titular.ToString();
                    txtNumAfiliado.Text = pacienteSeleccionado.num_afiliado.ToString();
                    txtDniPaciente.Text = pacienteSeleccionado.dni_paciente.ToString();
                    txtCud.Text = pacienteSeleccionado.cud;
                    txtDomicilio.Text = pacienteSeleccionado.domicilio;
                    txtNumDomicilio.Text = pacienteSeleccionado.num_domicilio.ToString();
                    txtCargaHoraria.Text = pacienteSeleccionado.cargahoraria_at.ToString();
                    txtAmbito.Text = pacienteSeleccionado.ambito;
                    txtTelefono.Text = pacienteSeleccionado.telefono.ToString();
                    txtEmail.Text = pacienteSeleccionado.email;

                    
                    /*if (pacienteSeleccionado.id_os.HasValue)
                    {
                        cmbObraSocial.SelectedValue = pacienteSeleccionado.id_os.Value;
                    }
                    else
                    {
                        cmbObraSocial.SelectedIndex = -1;
                    }*/

                    cmbLocalidad.SelectedValue = pacienteSeleccionado.id_localidad;

                    if (pacienteSeleccionado.fecha_nac.HasValue &&
                        pacienteSeleccionado.fecha_nac.Value >= dateFechaNac.MinDate &&
                        pacienteSeleccionado.fecha_nac.Value <= dateFechaNac.MaxDate)
                    {
                        dateFechaNac.Value = pacienteSeleccionado.fecha_nac.Value;
                    }
                    else
                    {
                        dateFechaNac.Value = DateTime.Now;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al seleccionar paciente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _idPacienteSeleccionado = -1;
                }
            }
        }

        private void btnCrear_Click_1(object sender, EventArgs e)
        {

            if (!ValidarCampos()) return;

            cls_PacienteDTO nuevoPaciente = new cls_PacienteDTO
            {
                id_os = Convert.ToInt32(cmbObraSocial.SelectedValue),
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                dni_titular = Convert.ToInt32(txtDniTitular.Text),
                num_afiliado = Convert.ToInt32(txtNumAfiliado.Text),
                dni_paciente = Convert.ToInt32(txtDniPaciente.Text),
                fecha_nac = dateFechaNac.Value,
                cud = txtCud.Text,
                id_localidad = Convert.ToInt32(cmbLocalidad.SelectedValue),
                domicilio = txtDomicilio.Text,
                num_domicilio = Convert.ToInt32(txtNumDomicilio.Text),
                cargahoraria_at = Convert.ToInt32(txtCargaHoraria.Text),
                ambito = txtAmbito.Text,
                telefono = Convert.ToInt32(txtTelefono.Text),
                email = txtEmail.Text
            };

            if (_logicaPaciente.InsertarPaciente(nuevoPaciente))
            {
                MessageBox.Show("Paciente creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarPacientesEnDataGridView();
            }
            else
            {
                MessageBox.Show("No se pudo crear el paciente. Verifique los datos o la conexión.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            if (_idPacienteSeleccionado == -1)
            {
                MessageBox.Show("Por favor, seleccione un paciente de la lista para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarCampos()) return;

            cls_PacienteDTO pacienteModificado = new cls_PacienteDTO
            {
                id_paciente = _idPacienteSeleccionado,
                id_os = Convert.ToInt32(cmbObraSocial.SelectedValue),
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                dni_titular = Convert.ToInt32(txtDniTitular.Text),
                num_afiliado = Convert.ToInt32(txtNumAfiliado.Text),
                dni_paciente = Convert.ToInt32(txtDniPaciente.Text),
                fecha_nac = dateFechaNac.Value,
                cud = txtCud.Text,
                id_localidad = Convert.ToInt32(cmbLocalidad.SelectedValue),
                domicilio = txtDomicilio.Text,
                num_domicilio = Convert.ToInt32(txtNumDomicilio.Text),
                cargahoraria_at = Convert.ToInt32(txtCargaHoraria.Text),
                ambito = txtAmbito.Text,
                telefono = Convert.ToInt32(txtTelefono.Text),
                email = txtEmail.Text
            };

            if (_logicaPaciente.ActualizarPaciente(pacienteModificado))
            {
                MessageBox.Show("Paciente modificado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarPacientesEnDataGridView();
            }
            else
            {
                MessageBox.Show("No se pudo modificar el paciente. Verifique los datos o la conexión.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (_idPacienteSeleccionado == -1)
            {
                MessageBox.Show("Por favor, seleccione un paciente de la lista para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de que desea eliminar al paciente seleccionado? Esto lo inactivará del sistema.",
                "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                if (_logicaPaciente.EliminarPaciente(_idPacienteSeleccionado))
                {
                    MessageBox.Show("Paciente eliminado lógicamente (inactivado) exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarPacientesEnDataGridView();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el paciente. Verifique los datos o la conexión.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
