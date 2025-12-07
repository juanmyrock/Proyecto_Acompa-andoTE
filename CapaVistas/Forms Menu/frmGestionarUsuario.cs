using System;
using System.Windows.Forms;
using CapaLogica.ABM;
using CapaLogica.Login;
using CapaDTO;
using System.Collections.Generic;

namespace CapaVistas.Forms_Menu
{
    public partial class frmGestionarUsuario : Form
    {
        private readonly cls_DatosParaGestionUsuarioDTO _datosIniciales;
        private readonly cls_LogicaGestionarUsuarios _logicaGestion = new cls_LogicaGestionarUsuarios();
        private readonly cls_LogicaContraseña _logicaContraseña = new cls_LogicaContraseña();
        private cls_UsuarioGestionDTO _usuarioActual;

        public frmGestionarUsuario(cls_DatosParaGestionUsuarioDTO datosParaGestion)
        {
            InitializeComponent();
            _datosIniciales = datosParaGestion;
        }

        private void frmGestionarUsuario_Load(object sender, EventArgs e)
        {
            lblNombreEmpleado.Text = _datosIniciales.NombreCompletoEmpleado;
            CargarRoles();
            if (_datosIniciales.UsuarioYaExiste)
            {
                this.Text = "Modificar Usuario Existente";
                btnGuardarRol.Text = "Actualizar Rol";
                CargarDatosUsuarioExistente();
            }
            else
            {
                this.Text = "Crear Nuevo Usuario";
                lblEstadoActual.Text = "NO CREADO";
                lblEstadoActual.ForeColor = System.Drawing.Color.DodgerBlue;
                txtUsername.ReadOnly = false;
                txtUsername.Text = "";
                btnGuardarRol.Text = "Crear Usuario y Enviar Email";
                groupAccionesAdmin.Enabled = false;
            }
        }
        private void CargarDatosUsuarioExistente()
        {
            try
            {
                _usuarioActual = _logicaGestion.ObtenerUsuarioParaGestion(_datosIniciales.IdEmpleado);

                if (_usuarioActual == null)
                {
                    MessageBox.Show("No se pudo cargar la información del usuario.", "Error");
                    this.Close();
                    return;
                }

                txtUsername.Text = _usuarioActual.Username;
                cmbRoles.SelectedValue = _usuarioActual.IdRol ?? -1;

                if (_usuarioActual.EstaBloqueado)
                {
                    lblEstadoActual.Text = "BLOQUEADO";
                    lblEstadoActual.ForeColor = System.Drawing.Color.OrangeRed;
                    btnDesbloquear.Enabled = true;
                    btnActivarDesactivar.Enabled = false;
                }
                else if (_usuarioActual.EsActivo)
                {
                    lblEstadoActual.Text = "ACTIVO";
                    lblEstadoActual.ForeColor = System.Drawing.Color.LimeGreen;
                    btnDesbloquear.Enabled = false;
                    btnActivarDesactivar.Enabled = true;
                    btnActivarDesactivar.Text = "Desactivar";
                }
                else
                {
                    lblEstadoActual.Text = "INACTIVO";
                    lblEstadoActual.ForeColor = System.Drawing.Color.Gray;
                    btnDesbloquear.Enabled = false;
                    btnActivarDesactivar.Enabled = true;
                    btnActivarDesactivar.Text = "Activar";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarRoles()
        {
            try
            {
                var logicaRoles = new CapaLogica.ABM.cls_Rol();
                List<cls_RolDTO> listaDeRoles = logicaRoles.ObtenerRoles();
                CapaUtilidades.cls_LlenarCombos.Cargar(cmbRoles, listaDeRoles, "NombreRol", "IdRol");

                if (_usuarioActual != null)
                {
                    cmbRoles.SelectedValue = _usuarioActual.IdRol ?? -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbRoles.Enabled = false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbRoles.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione un rol.", "Dato Requerido");
                return;
            }

            if (_datosIniciales.UsuarioYaExiste)
            {
                try
                {
                    int nuevoIdRol = Convert.ToInt32(cmbRoles.SelectedValue);
                    _logicaGestion.ActualizarRolUsuario(_datosIniciales.IdEmpleado, nuevoIdRol);
                    MessageBox.Show("Rol actualizado correctamente.", "Éxito");
                    CargarDatosUsuarioExistente();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el rol: " + ex.Message, "Error");
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtUsername.Text) || cmbRoles.SelectedValue == null)
                {
                    MessageBox.Show("Debe ingresar un nombre de usuario y seleccionar un rol.", "Datos Incompletos");
                    return;
                }

                try
                {
                    int idRol = Convert.ToInt32(cmbRoles.SelectedValue);
                    _logicaGestion.CrearUsuarioYEnviarContraseña(
                        _datosIniciales.IdEmpleado,
                        txtUsername.Text,
                        idRol,
                        _datosIniciales.Email,
                        _datosIniciales.NombreCompletoEmpleado);

                    MessageBox.Show("Usuario creado y contraseña temporal enviada con éxito.", "Éxito");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al crear el usuario: " + ex.Message, "Error");
                }
            }
        }

        private void btnDesbloquear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de que desea desbloquear a este usuario?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _logicaGestion.DesbloquearUsuario(_datosIniciales.IdEmpleado);
                MessageBox.Show("Usuario desbloqueado.", "Éxito");
                CargarDatosUsuarioExistente();
            }
        }

        private void btnActivarDesactivar_Click(object sender, EventArgs e)
        {
            bool nuevoEstado = !_usuarioActual.EsActivo;
            string accion = nuevoEstado ? "activar" : "desactivar";
            if (MessageBox.Show($"¿Está seguro de que desea {accion} a este usuario?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _logicaGestion.CambiarEstadoUsuario(_datosIniciales.IdEmpleado, nuevoEstado);
                MessageBox.Show($"Usuario {accion} con éxito.", "Éxito");
                CargarDatosUsuarioExistente();
            }
        }

        private void btnResetearPass_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Se enviará una contraseña temporal al correo del usuario. ¿Continuar?", "Resetear Contraseña", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    _logicaContraseña.GenerarYEnviarContraseñaTemporal(_usuarioActual.IdUsuario, _usuarioActual.Email, _usuarioActual.Username);
                    MessageBox.Show("Contraseña temporal enviada con éxito.", "Éxito");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al resetear la contraseña: " + ex.Message);
                }
            }
        }

        private void btnGestionPermisos_Click(object sender, EventArgs e)
        {
            int idUsuarioActual = 123;
            string nombreUsuarioActual = lblNombreEmpleado.Text;
            int idRolActual = 2;
            frmPermisos formPermisos = new frmPermisos(idUsuarioActual, nombreUsuarioActual, idRolActual);

            formPermisos.ShowDialog();
            if (formPermisos.DialogResult == DialogResult.OK)
            {

            }
        }
    }
}
