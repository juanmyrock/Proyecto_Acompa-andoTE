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
        private cls_LogicaLogin _logicaLogin;
        public frmLogin()
        {
            InitializeComponent();
            picShowPass.BringToFront(); 
        }



        #region MoverVentana  | Métodos para poder mover la ventana |
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void MoverForm()
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void Form_Login_MouseDown(object sender, MouseEventArgs e) 
        {
            MoverForm();
        }
        private void panelLogin_MouseDown(object sender, MouseEventArgs e)
        {
            MoverForm();
        }
        private void picBoxLogin_MouseDown(object sender, MouseEventArgs e)
        {
            MoverForm();
        }
        #endregion



        private void btnCerrarLogin_Click(object sender, EventArgs e) 
        {
            if (MessageBox.Show("¿Está seguro que desea salir?", "¡Alerta!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

        private bool CamposValidados()
        {
            _logicaLogin = new cls_LogicaLogin();
            lblErrorMsg.Visible = false;
            picError.Visible = false;

            string mensajeError = _logicaLogin.ValidarCredenciales(txtUsers.Text, txtPass.Text);

            if (!string.IsNullOrEmpty(mensajeError))
            {
                MsgError(mensajeError);
                return false;
            }
            return true;
        }
        private void MsgError(string msg)
        {
            lblErrorMsg.Text = msg;
            lblErrorMsg.Visible = true;
            picError.Visible = true;
        }



        private void lblForgotPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var formValidar = new frmValidarUser())
            {

                formValidar.ShowDialog();
            }
        }
        private void btnAcceder_Click(object sender, EventArgs e)
        {
            lblErrorMsg.Visible = false;
            picError.Visible = false;

            if (!CamposValidados()) return;

            var credenciales = new cls_CredencialesLoginDTO
            {
                Username = txtUsers.Text,
                Password = txtPass.Text
            };

            try
            {
                RealizarIntentoDeLogin(credenciales, false);
            }
            catch (Exception ex)
            {
                if (ex.Message == "SESION_ACTIVA")
                {
                    var confirmacion = MessageBox.Show(
                        "El usuario ya tiene una sesión activa en otro dispositivo.\n\n¿Desea cerrar la sesión anterior y continuar?",
                        "Sesión Activa Detectada",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (confirmacion == DialogResult.Yes)
                    {
                        try
                        {
                            RealizarIntentoDeLogin(credenciales, true);
                        }
                        catch (Exception exFinal)
                        {
                            MsgError(exFinal.Message);
                        }
                    }
                }
                else
                {
                    MsgError(ex.Message);
                }
            }
        }
        private void RealizarIntentoDeLogin(cls_CredencialesLoginDTO credenciales, bool forzarCierre)
        {
            var logicaLogin = new cls_LogicaLogin();
            string ipCliente = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)?.ToString() ?? "127.0.0.1";
            ResultadoLoginDTO resultado = logicaLogin.ValidarLogin(credenciales, ipCliente, forzarCierre);
            ProcesarLoginExitoso(resultado);
        }
        private void ProcesarLoginExitoso(ResultadoLoginDTO resultado)
        {
            if (!resultado.Exitoso) return; // doble check pa mas security

            if (resultado.RequiereConfigurarPreguntas || resultado.RequiereCambioContraseña)
            {
                this.Hide();
                int idUsuarioLogueado = CapaSesion.Login.SesionUsuario.Instancia.IdUsuario;

                if (resultado.RequiereConfigurarPreguntas)
                {
                    using (var formPreguntas = new Forms_Login.frmPreguntas(idUsuarioLogueado, "CONFIGURAR"))
                    {
 
                        if (formPreguntas.ShowDialog() != DialogResult.OK)
                        {
                            MessageBox.Show("La configuración de preguntas es obligatoria.", "Proceso Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            new cls_LogicaLogin().CerrarSesion();
                            this.Show();
                            return; 
                        }
                    }
                }

                if (resultado.RequiereCambioContraseña)
                {
                    using (var formNuevaPass = new Forms_Login.frmNuevaContraseña(idUsuarioLogueado))
                    {
                        if (formNuevaPass.ShowDialog() != DialogResult.OK)
                        {
                            MessageBox.Show("El cambio de contraseña es obligatorio. La aplicación se cerrará.", "Proceso Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            new cls_LogicaLogin().CerrarSesion();
                            this.Show();
                            return; 
                        }
                    }
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnAcceder.PerformClick();
        }
    }
}
