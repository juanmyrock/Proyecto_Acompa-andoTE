using CapaLogica.Login;
using CapaLogica;
using System;
using System.Windows.Forms;

namespace CapaVistas.Forms_Login
{
    public partial class frmNuevaContraseña : Form
    {
        private readonly int _idUsuario;

        public frmNuevaContraseña(int idUsuario)
        {
            InitializeComponent();
            _idUsuario = idUsuario;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            lblErrorMsg.Visible = false;

            if (!ValidarCamposBasicos())
            {
                return;
            }

            try
            {
                var logicaContraseña = new cls_LogicaContraseña();

                // Este método ahora contiene toda la validación (complejidad, historial)
                // y la lógica de guardado.
                logicaContraseña.EstablecerNuevaContraseña(_idUsuario, txtNuevaContraseña.Text);

                // Después de establecer la contraseña, finalizamos la configuración del usuario.
                // Esta llamada sigue perteneciendo a la lógica de login.
                var logicaLogin = new cls_LogicaLogin();
                logicaLogin.FinalizarConfiguracionInicial(_idUsuario);

                MessageBox.Show("Contraseña actualizada y cuenta configurada con éxito.", "Proceso Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                // El nuevo método nos dará errores de validación muy específicos y claros.
                MsgError(ex.Message);
            }
        }

        private bool ValidarCamposBasicos()
        {
            if (string.IsNullOrWhiteSpace(txtNuevaContraseña.Text))
            {
                MsgError("La contraseña no puede estar vacía.");
                return false;
            }
            if (txtNuevaContraseña.Text != txtRepetirContraseña.Text)
            {
                MsgError("Las contraseñas no coinciden.");
                return false;
            }
            return true;
        }

        private void MsgError(string msg)
        {
            lblErrorMsg.Text = "      " + msg;
            lblErrorMsg.Visible = true;
            // picError.Visible = true; // Descomentar si tienes este control
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
