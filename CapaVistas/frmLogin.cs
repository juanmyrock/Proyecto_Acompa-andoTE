using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CapaLogica.Login;
using CapaSesion;

namespace CapaVistas
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            picShowPass.BringToFront(); //que inicie con el logo para habilitar la contraseña Show (que se vea)
        }


        private int intentos = 0;
        private string usuario = "";



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
            CapaVistas.Forms_Login.frmRecuperarContraseña frmForgot = new CapaVistas.Forms_Login.frmRecuperarContraseña();
            frmForgot.ShowDialog();
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            //Validar que los campos estén llenos
            if (!ValidarCampos())
            {
                return; //Si no están llenos, salir del método 'Click'
            }

            cls_LogicaLogin BuscarUsuario = new cls_LogicaLogin();

            //Verificar las credenciales del usuario
            if (BuscarUsuario.LoginUser(txtUsers.Text, /*txtUsers.Text +*/ txtPass.Text) == false) //La condicion envía los dos parámetros del método LoginUser en cls_LogicaLogin que son (user, pass)
            {
                MessageBox.Show("Usuario o Contraseña Inexistentes");
                if (intentos < 3) //Bloquear al usuario si introdujo 3 intentos fallidos
                {
                    if (intentos == 0)
                    {
                        usuario = txtUsers.Text;
                        intentos = 1;
                    }
                    else
                    {
                        if (usuario == txtUsers.Text)
                        {
                            intentos++;
                        }
                    }
                }
                else
                {
                    cls_BloquearUser Block = new cls_BloquearUser(usuario);
                }

            }
            else
            {
                // Mostrar mensaje de ingreso exitoso y permisos del usuario
                string permisos = "";
                foreach (string elemento in cls_UserCache.PermisosUsuario)
                {
                    permisos += elemento + "\n";
                }
                MessageBox.Show($"¡Ingreso Exitoso!\n\n{cls_UserCache.ApellidoEmpleado} {cls_UserCache.NombreEmpleado}\n\nPERMISOS:\n{permisos}");
                // Aca va el registro en la bitácora 
                // clsBitacora Guardar = new clsBitacora("Ingreso al Sistema", "Ingreso Exitoso", "frmLoguin");

                this.DialogResult = DialogResult.OK; // Cerrar el formulario de inicio de sesión

                
            }
        }
    }
}
