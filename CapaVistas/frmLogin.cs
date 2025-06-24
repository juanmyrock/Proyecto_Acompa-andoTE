using System;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CapaLogica;
using CapaDTO;
using CapaVistas.Forms_Login;   

namespace CapaVistas
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            picShowPass.BringToFront(); //que inicie con el logo para habilitar la contraseña Show (que se vea)
        }



        #region MoverVentana  | Métodos para poder mover la ventana |
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void MoverForm() //Método para mover la ventana del formulario por la pantalla libremente
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void Form_Login_MouseDown(object sender, MouseEventArgs e) //Evento al mantener el click izquierdo del mouse y moverlo
        {
            MoverForm();
        }
        private void panelLogin_MouseDown(object sender, MouseEventArgs e)
        {
            MoverForm();
        }
        private void picBoxLogin_MouseDown(object sender, MouseEventArgs e) //Evento al mantener el click izquierdo del mouse y moverlo
        {
            MoverForm();
        }
        #endregion



        private void btnCerrarLogin_Click(object sender, EventArgs e) //Evento de cierre al logo de Cerrar
        {
            if (MessageBox.Show("¿Está seguro que desea salir?", "¡Alerta!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }



        #region Placeholders y Show/Hide  | Métodos para dar el efecto Placeholder a los campos de Usuario y Password y mostrar/ocultar Pass |
        private void txtBoxUsers_Enter(object sender, EventArgs e)
        {
            if (txtUsers.Text == "USUARIO")
            {
                txtUsers.Text = "";
                txtUsers.ForeColor = Color.White;
            }
        }
        private void txtBoxUsers_Leave(object sender, EventArgs e)
        {
            if (txtUsers.Text == "")
            {
                txtUsers.Text = "USUARIO";
                txtUsers.ForeColor = Color.Silver;
            }
        }

        private void txtBoxPassw_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "CONTRASEÑA")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.White;
                txtPass.UseSystemPasswordChar = true;
                if (txtPass.Text == "")
                {
                    picShowPass.BringToFront();
                }
            }
        }
        private void txtBoxPassw_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "CONTRASEÑA";
                txtPass.ForeColor = Color.Silver;
                txtPass.UseSystemPasswordChar = false;
            }
        }

        private void picShowPass_Click(object sender, EventArgs e)
        {
            picHidePass.BringToFront();
            txtPass.UseSystemPasswordChar = false;
        }
        private void picHidePass_Click(object sender, EventArgs e)
        {
            if (txtPass.Text != "CONTRASEÑA" || txtPass.Text == "")
            {
                picShowPass.BringToFront();
                txtPass.UseSystemPasswordChar = true;
            }
        }
        #endregion


        private bool ValidarCampos() //Método para validar los campos del Login
        {
            string usuario = txtUsers.Text;
            string contraseña = txtPass.Text;

            if (txtUsers.Text == "USUARIO" && txtPass.Text == "CONTRASEÑA")
            {
                MsgError("Complete los campos Usuario y Contraseña");
                return false;
            }
            else if (txtUsers.Text == "USUARIO")
            {
                MsgError("Complete el campo Usuario");
                return false;
            }
            else if (txtPass.Text == "CONTRASEÑA")
            {
                MsgError("Complete el campo Contraseña");
                return false;
            }

            return true;
        }
        private void MsgError(string msg) //Mensaje de error de validación de campos
        {
            lblErrorMsg.Text = msg;
            lblErrorMsg.Visible = true;
            picError.Visible = true;
        }


        //private void btnAcceder_Click(object sender, EventArgs e) //para saltear las validaciones del login mientras diseñamos los forms
        //{
        //    this.DialogResult = DialogResult.OK;
        //}

        private void lblForgotPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // La lógica para recuperar contraseña se mantiene
            using (var frmForgot = new Forms_Login.frmRecuperarPass())
            {
                frmForgot.ShowDialog();
            }
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            lblErrorMsg.Visible = false;
            picError.Visible = false;

            if (!ValidarCampos())
            {
                return;
            }

            var credenciales = new cls_CredencialesLoginDTO
            {
                Username = txtUsers.Text,
                Password = txtPass.Text
            };

            try
            {
                var logicaLogin = new cls_LogicaLogin();

                // Obtenemos la IP local para el registro de sesión
                string ipCliente = Dns.GetHostEntry(Dns.GetHostName())
                                      .AddressList.FirstOrDefault(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)?.ToString() ?? "127.0.0.1";

                ResultadoLoginDTO resultado = logicaLogin.ValidarLogin(credenciales, ipCliente);

                if (resultado.Exitoso)
                {
                    if (resultado.RequiereConfiguracionInicial)
                    {
                        // Si se requiere configuración, mostramos el form de configuración de forma modal.
                        // El flujo de la aplicación se detiene aquí hasta que se cierre.
                        MessageBox.Show("Es su primer inicio de sesión. Por favor, configure su cuenta.", "Configuración Requerida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        using (var formConfig = new frmPreguntas())
                        {
                            formConfig.ShowDialog();
                            // Aquí iría la lógica para verificar si la configuración fue exitosa
                            // antes de continuar. Por ahora, asumimos que sí.
                        }
                    }

                    // Si el login fue exitoso (y la configuración ya se completó si era necesaria),
                    // establecemos el resultado en OK para que Program.cs continúe.
                    this.DialogResult = DialogResult.OK;
                    this.Close(); // Cerramos el form de login
                }
            }
            catch (Exception ex)
            {
                // Mostramos cualquier error que la capa de lógica haya lanzado
                MsgError(ex.Message);
            }
        }

    }
}
