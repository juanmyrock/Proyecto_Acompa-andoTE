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
        private void MoverForm() //Método para mover la ventana del formulario por la pantalla libremente
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
        //private bool ValidarCampos() //Método para validar los campos del Login
        //{
        //    string usuario = txtUsers.Text;
        //    string contraseña = txtPass.Text;

        //    if (txtUsers.Text == "USUARIO" && txtPass.Text == "CONTRASEÑA")
        //    {
        //        MsgError("Complete los campos Usuario y Contraseña");
        //        return false;
        //    }
        //    else if (txtUsers.Text == "USUARIO")
        //    {
        //        MsgError("Complete el campo Usuario");
        //        return false;
        //    }
        //    else if (txtPass.Text == "CONTRASEÑA")
        //    {
        //        MsgError("Complete el campo Contraseña");
        //        return false;
        //    }

        //    return true;
        //}
        private void MsgError(string msg) //Mensaje de error de validación de campos
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

        // MÉTODO PRINCIPAL DEL BOTÓN ACCEDER
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
                // 1. PRIMER INTENTO DE LOGIN: Llama a la lógica sin forzar el cierre.
                RealizarIntentoDeLogin(credenciales, false);
            }
            catch (Exception ex)
            {
                // 2. MANEJO DE ERRORES: Comprueba si el error es por una sesión activa.
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
                            // 3. SEGUNDO INTENTO: Si el usuario confirma, vuelve a llamar a la lógica,
                            // y fuerza el ciere de la anterior
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
                    // 4. Si es cualquier otro error (pass incorrecta, usuario no existe), lo muestra.
                    MsgError(ex.Message);
                }
            }
        }

        // Llama a la capa de lógica
        private void RealizarIntentoDeLogin(cls_CredencialesLoginDTO credenciales, bool forzarCierre)
        {
            var logicaLogin = new cls_LogicaLogin();
            string ipCliente = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)?.ToString() ?? "127.0.0.1";

            // Llama a la lógica y obtiene el resultado, además en forzarCierre se ve si ya existe una sesion activa o huérfana
            ResultadoLoginDTO resultado = logicaLogin.ValidarLogin(credenciales, ipCliente, forzarCierre);

            // Pasa el resultado al siguiente método para procesarlo
            ProcesarLoginExitoso(resultado);
        }

        //  Procesa el resultado de un login exitoso
        private void ProcesarLoginExitoso(ResultadoLoginDTO resultado)
        {
            if (!resultado.Exitoso) return; // doble check pa mas security

            // Verifica si se requiere alguna configuración inicial
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

                // --- Flujo de Cambio de Contraseña ---
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

            // si llegamos hasta acá, significa que el login fue exitoso y que toda la
            // configuración requerida se completó correctamente. Le indica a Program.cs que puede continuar al menu.
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
