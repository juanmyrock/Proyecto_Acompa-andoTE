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
            // -- Dispara el FLUJO B: RECUPERACIÓN DE CONTRASEÑA --
            using (var formValidar = new frmValidarUser())
            {
                // Abrimos el primer paso del flujo de recuperación
                formValidar.ShowDialog();
            }
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            lblErrorMsg.Visible = false;
            picError.Visible = false;

            if (!ValidarCampos()) return;

            var credenciales = new cls_CredencialesLoginDTO
            {
                Username = txtUsers.Text,
                Password = txtPass.Text
            };

            try
            {
                var logicaLogin = new cls_LogicaLogin();
                string ipCliente = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)?.ToString() ?? "127.0.0.1";

                ResultadoLoginDTO resultado = logicaLogin.ValidarLogin(credenciales, ipCliente);

                if (resultado.Exitoso)
                {
                    if (resultado.RequiereCambioContraseña || resultado.RequiereConfigurarPreguntas)
                    {
                        // -- Dispara el FLUJO A: PRIMER INGRESO --
                        this.Hide();

                        // Le pasamos el IdUsuario y le indicamos el modo "Configurar"
                        int idUsuarioLogueado = CapaSesion.Login.SesionUsuario.Instancia.IdUsuario;

                        // Primero, el usuario DEBE configurar sus preguntas si es necesario
                        if (resultado.RequiereConfigurarPreguntas)
                        {
                            using (var formPreguntas = new frmPreguntas(idUsuarioLogueado, "CONFIGURAR"))
                            {
                                formPreguntas.ShowDialog();
                            }
                        }

                        // Luego, si tiene contraseña random, DEBE cambiarla
                        if (resultado.RequiereCambioContraseña)
                        {
                            using (var formNuevaPass = new frmNuevaContraseña(idUsuarioLogueado))
                            {
                                formNuevaPass.ShowDialog();
                            }
                        }
                    }

                    this.DialogResult = DialogResult.OK; // Indica a Program.cs que continúe al menú
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MsgError(ex.Message);
            }
        }

        private void buttonGenerarHash_Click(object sender, EventArgs e)
        {
            // --- CAMBIO CLAVE: ---
            // Ahora tomamos la contraseña DIRECTAMENTE del TextBox del formulario,
            // que es la fuente de datos real.
            string contraseñaDePrueba = txtPass.Text;

            if (string.IsNullOrWhiteSpace(contraseñaDePrueba) || contraseñaDePrueba == "CONTRASEÑA")
            {
                MessageBox.Show("Por favor, escribe una contraseña en el campo correspondiente para generar su hash.");
                return;
            }

            // Usamos TU PROPIA clase de seguridad para generar el hash
            string hashGenerado = CapaUtilidades.cls_SeguridadPass.GenerarHashSHA256(contraseñaDePrueba);

            // Mostramos el hash en un cuadro de texto para poder copiarlo fácilmente
            using (Form prompt = new Form()
            {
                Width = 450,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Hash Generado por tu Aplicación",
                StartPosition = FormStartPosition.CenterScreen
            })
            {
                Label textLabel = new Label() { Left = 50, Top = 20, Text = $"Hash para '{contraseñaDePrueba}':", Width = 350 };
                TextBox txtCopiable = new TextBox { Text = hashGenerado, Left = 50, Top = 50, Width = 350 };
                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(txtCopiable);
                prompt.ShowDialog();
            }
        }
    }
}
