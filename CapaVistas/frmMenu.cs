using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using CapaDTO;
using CapaDTO.SistemaDTO;
using CapaLogica.Login;
using CapaVistas.Forms_Menu;
using CapaSesion.Login;

namespace CapaVistas
{
    public partial class frmMenu : Form
    {
        private Form activeForm = null;



        public frmMenu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            lblUserLog.Text = CapaSesion.Login.SesionUsuario.Instancia.NombreEmpleado + " " + CapaSesion.Login.SesionUsuario.Instancia.ApellidoEmpleado;

        }

        #region MoverVentana  | M�todos para poder mover la ventana |
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void MoverForm() //M�todo para mover la ventana del formulario por la pantalla libremente
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void panelBarraClose_MouseDown(object sender, MouseEventArgs e)
        {
            MoverForm();
        }
        #endregion

        #region Botones de la Barra
        private void btnCerrar_Click(object sender, EventArgs e) //para cerrar la aplicaci�n
        {
            var confirmacion = MessageBox.Show(
                "�Est� seguro que desea salir?", "�Alerta!",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    // 1. Instanciar la capa de l�gica
                    var logicaLogin = new CapaLogica.cls_LogicaLogin();

                    // 2. Llamar al m�todo que cierra la sesi�n en la BD y en el Singleton
                    logicaLogin.CerrarSesion();

                    // 
                    // 2. Application.Exit() cierra la instancia actual.
                    // Es la forma m�s segura de garantizar que no queden datos en memoria.
                    Application.Exit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurri� un error al intentar cerrar la sesi�n: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private void btnMinimize_Click(object sender, EventArgs e) //para minimizar a modo ventana
        {
            this.WindowState = FormWindowState.Normal;
            //btnMinimize.Visible = false;
            //btnMaximize.Visible = true;
        }

        private void btnOcultar_Click(object sender, EventArgs e) //para ocultar/minimizar la aplicaci�n
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, EventArgs e) //para maximizar la ventana a pantalla completa
        {
            this.WindowState = FormWindowState.Maximized;
            //btnMinimize.Visible = true;
            //btnMaximize.Visible = false;
        }
        #endregion

        #region Config y Estilos Botones Men�

        private void btnLogOut_Click(object sender, EventArgs e) //Bot�n de deslogueo
        {
            // Preguntar al usuario para confirmar la acci�n
            var confirmacion = MessageBox.Show(
                "�Est� seguro de que desea cerrar la sesi�n?",
                "Confirmar Cierre de Sesi�n",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    // 1. Instanciar la capa de l�gica
                    var logicaLogin = new CapaLogica.cls_LogicaLogin();

                    // 2. Llamar al m�todo que cierra la sesi�n en la BD y en el Singleton
                    logicaLogin.CerrarSesion();

                    // 3. Reiniciar la aplicaci�n para volver a la pantalla de login de forma limpia
                    // Application.Restart() cierra la instancia actual y lanza una nueva.
                    // Es la forma m�s segura de garantizar que no queden datos en memoria.
                    Application.Restart();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurri� un error al intentar cerrar la sesi�n: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        private void OpenChildForm(Form childForm, object btnSender) //M�todo para llamar un formulario hijo dentro del contenedor PanelChildFrm
        {
            if (activeForm != null)
            { 
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelChildFrm.Controls.Add(childForm);
            this.panelChildFrm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitulo.Text = childForm.Text;
            btnCerrarForm.Visible = true;
        }
        private void btnCerrarForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                btnCerrarForm.Visible = false;
                lblTitulo.Text = "Inicio";
            }
        }


        #region Botones del Men� y sus Forms

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new CapaVistas.Form_Menu.frmEmpleados(), sender);
        }
        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CapaVistas.Forms_Menu.frmABMUsuarios(), sender);
        }




        #endregion

        private void btnAdministrar_Click(object sender, EventArgs e)
        {
            var frmAdminSyst = new frmAdminSyst();
            
            frmAdminSyst.ShowDialog();
                
            
                

            //try
            //{
            //    cls_ParamContrase�aDTO parametrosContra = new cls_ParamContrase�aDTO();
            //    parametrosContra.CantidadPreguntasSeguridad = 
            //    cls_ParamContrase�aDTO TraerDatos()
            //    {
                    
            //    }
            //}
            //catch 
            //{
            
            //}
           
        }
    }




}