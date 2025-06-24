using System;
using System.Windows.Forms;
using CapaLogica;
using CapaDTO;
using CapaVistas.Forms_Login;

namespace CapaVistas.Forms_Login
{
    public partial class frmValidarUser : Form
    {
        public frmValidarUser()
        {
            InitializeComponent();
        }

        // --- Evento principal para el botón Aceptar/Continuar ---
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            lblErrorMsg.Visible = false;

            if (!ValidarCampos())
            {
                return;
            }

            try
            {
                var logica = new cls_LogicaLogin();
                // Llama al nuevo método en la capa de lógica para verificar el usuario.
                cls_UsuarioDTO usuario = logica.ObtenerDatosParaRecuperacion(txtUsuario.Text);

                // Si el usuario es válido, se abre el siguiente paso del flujo.
                this.Hide();
                using (var formPreguntas = new frmPreguntas(usuario.IdUsuario, "RESPONDER"))
                {
                    // Si el usuario responde correctamente las preguntas...
                    if (formPreguntas.ShowDialog() == DialogResult.OK)
                    {
                        // ...abrimos el formulario para establecer la nueva contraseña.
                        using (var formNuevaPass = new frmNuevaContraseña(usuario.IdUsuario))
                        {
                            if (formNuevaPass.ShowDialog() == DialogResult.OK)
                            {
                                MessageBox.Show("Contraseña restablecida con éxito.", "Proceso Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                // Una vez terminado todo el flujo, se cierra este formulario.
                this.Close();
            }
            catch (Exception ex)
            {
                MsgError(ex.Message);
            }
        }

        // --- Métodos de UI y Navegación ---
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || txtUsuario.Text == "USUARIO")
            {
                MsgError("Por favor, complete el campo Usuario.");
                return false;
            }
            return true;
        }

        private void MsgError(string msg)
        {
            lblErrorMsg.Text = "      " + msg;
            lblErrorMsg.Visible = true;
            picError.Visible = true; // Asumo que tienes un PictureBox llamado picError
        }

        // Cierra este formulario para volver a la pantalla de Login
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
