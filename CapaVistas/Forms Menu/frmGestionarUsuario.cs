using System;
using System.Windows.Forms;
using CapaLogica.ABM;
using CapaLogica.Login;
using CapaDTO;

namespace CapaVistas.Forms_Menu
{
    public partial class frmGestionarUsuario : Form
    {
        private readonly int _idUsuario;
        private readonly cls_LogicaGestionarUsuarios _logicaGestion = new cls_LogicaGestionarUsuarios();
        private readonly cls_LogicaContraseña _logicaContraseña = new cls_LogicaContraseña();
        private cls_UsuarioGestionDTO _usuarioActual;

        public frmGestionarUsuario(int idUsuario)
        {
            InitializeComponent();
            _idUsuario = idUsuario;
        }

        private void frmGestionarUsuario_Load(object sender, EventArgs e)
        {
            CargarDatosUsuario();
            CargarRoles();
        }

        private void CargarDatosUsuario()
        {
            try
            {
                _usuarioActual = _logicaGestion.ObtenerUsuarioParaGestion(_idUsuario);

                if (_usuarioActual == null)
                {
                    MessageBox.Show("No se pudo cargar la información del usuario.", "Error");
                    this.Close();
                    return;
                }

                lblNombreEmpleado.Text = _usuarioActual.NombreCompletoEmpleado;
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
                MessageBox.Show("Error al cargar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarRoles()
        {
            try
            {
                // TODO: Necesitarás crear una cls_LogicaRoles y un método ObtenerTodos()
                // que devuelva una List<cls_RolDTO>.
                // var roles = new cls_LogicaRoles().ObtenerTodos();
                // CapaUtilidades.cls_ComboBoxHelper.Cargar(cmbRoles, roles, "NombreRol", "IdRol");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los roles: " + ex.Message, "Error");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbRoles.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione un rol.", "Dato Requerido");
                return;
            }

            try
            {
                int nuevoIdRol = Convert.ToInt32(cmbRoles.SelectedValue);
                _logicaGestion.ActualizarRolUsuario(_idUsuario, nuevoIdRol);
                MessageBox.Show("Rol actualizado correctamente.", "Éxito");
                CargarDatosUsuario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el rol: " + ex.Message, "Error");
            }
        }

        private void btnDesbloquear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de que desea desbloquear a este usuario?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _logicaGestion.DesbloquearUsuario(_idUsuario);
                MessageBox.Show("Usuario desbloqueado.", "Éxito");
                CargarDatosUsuario();
            }
        }

        private void btnActivarDesactivar_Click(object sender, EventArgs e)
        {
            bool nuevoEstado = !_usuarioActual.EsActivo;
            string accion = nuevoEstado ? "activar" : "desactivar";
            if (MessageBox.Show($"¿Está seguro de que desea {accion} a este usuario?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _logicaGestion.CambiarEstadoUsuario(_idUsuario, nuevoEstado);
                MessageBox.Show($"Usuario {accion} con éxito.", "Éxito");
                CargarDatosUsuario();
            }
        }

        private void btnResetearPass_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Se enviará una contraseña temporal al correo del usuario. ¿Continuar?", "Resetear Contraseña", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    _logicaContraseña.GenerarYEnviarContraseñaTemporal(_usuarioActual.IdUsuario, _usuarioActual.Email, _usuarioActual.Username);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al resetear la contraseña: " + ex.Message);
                }
            }
        }
    }
}
