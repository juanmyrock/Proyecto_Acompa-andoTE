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
                cls_UsuarioDTO usuario = logicaLogin.ObtenerDatosParaRecuperacion(txtUsuario.Text);

                this.Hide();
                using (var formPreguntas = new frmPreguntas(usuario.IdUsuario, "RESPONDER"))
                {
                    if (formPreguntas.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("Se ha enviado una contraseña temporal a su correo electrónico.\nRevise sus correos y proceda con la contraseña otorgada.", "Proceso Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MsgError("Respuesta incorrecta. Por favor, inténtelo nuevamente.");
                    }
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