using System;
using System.Windows.Forms;
using CapaLogica;
using CapaDTO;

namespace CapaVistas.Forms_Login
{
    public partial class frmValidarUser : Form
    {
        public frmValidarUser()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            lblErrorMsg.Visible = false;

            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || txtUsuario.Text == "USUARIO")
            {
                MsgError("Por favor, complete el campo Usuario.");
                return;
            }

            try
            {
                var logicaLogin = new cls_LogicaLogin();
                // 1. Verificamos que el usuario existe y está activo.
                cls_UsuarioDTO usuario = logicaLogin.ObtenerDatosParaRecuperacion(txtUsuario.Text);

                // 2. Si existe, abrimos el formulario de preguntas en modo "RESPONDER".
                this.Hide();
                using (var formPreguntas = new frmPreguntas(usuario.IdUsuario, "RESPONDER"))
                {
                    // 3. Esperamos el resultado.
                    if (formPreguntas.ShowDialog() == DialogResult.OK)
                    {
                        // Si el usuario respondió correctamente, el flujo de envío de email ya se ejecutó.
                        // Simplemente cerramos todo y el usuario puede ir a revisar su correo.
                        MessageBox.Show("Se ha enviado una contraseña temporal a su correo electrónico.", "Proceso Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    // Si el usuario cancela, no hacemos nada y simplemente cerramos.
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MsgError(ex.Message);
            }
        }

        private void MsgError(string msg)
        {
            lblErrorMsg.Text = "      " + msg;
            lblErrorMsg.Visible = true;
            picError.Visible = true; 
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}