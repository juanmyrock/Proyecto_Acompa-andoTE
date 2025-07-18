using CapaDTO;
using CapaLogica;
using CapaLogica.Login;
using CapaSesion;
using System;
using System.Windows.Forms;

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
                var logicaContraseña = new cls_LogicaContraseña();

                this.DialogResult = DialogResult.OK;
                this.Close();
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
                        MessageBox.Show("Se ha enviado una contraseña temporal a su correo electrónico.", "Proceso Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Si el usuario no respondió correctamente, mostramos un mensaje de error.
                        MsgError("Respuesta incorrecta. Por favor, inténtelo nuevamente.");
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