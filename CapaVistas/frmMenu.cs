using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CapaVistas
{
    public partial class frmMenu : Form
    {
        private Form activeForm = null;

        public frmMenu()
        {
            InitializeComponent();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
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
        private void panelBarraClose_MouseDown(object sender, MouseEventArgs e)
        {
            btnMinimize.Visible = false;
            btnMaximize.Visible = true;
            MoverForm();
        }
        #endregion

        #region Botones de la Barra
        private void btnCerrar_Click(object sender, EventArgs e) //para cerrar la aplicación
        {
            if (MessageBox.Show("¿Está seguro que desea salir?", "¡Alerta!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        
        private void btnMinimize_Click(object sender, EventArgs e) //para minimizar a modo ventana
        {
            this.WindowState = FormWindowState.Normal;
            btnMinimize.Visible = false;
            btnMaximize.Visible = true;
        }

        private void btnOcultar_Click(object sender, EventArgs e) //para ocultar/minimizar la aplicación
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, EventArgs e) //para maximizar la ventana a pantalla completa
        {
            this.WindowState = FormWindowState.Maximized;
            btnMinimize.Visible = true;
            btnMaximize.Visible = false;
        }
        #endregion

        #region Config y Estilos Botones Menú
        //private void btnSlide_Click(object sender, EventArgs e) //para minimizar el panel de menú y acomodar los íconos
        //{
        //    if (panelMenu.Width == 240)
        //    {
        //        panelMenu.Width = 72;
        //        picLogOut.Location = new Point(12, 146);

        //    }
        //    else
        //    {
        //        panelMenu.Width = 240;
        //        picLogOut.Location = new Point(195, 196);
        //    }
        //}

        private void picLogOut_Click(object sender, EventArgs e) //Botón de deslogueo
        {
            if (MessageBox.Show("¿Está seguro que desea cerrar sesión?", "¡Alerta!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Hide();
                CapaVistas.frmLogin frm = new CapaVistas.frmLogin();
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    this.Show();
                }

            }
        }
        private void btnConfigSist_MouseHover(object sender, EventArgs e)
        {
            btnConfigSist.Width = 65;
            btnConfigSist.Height = 65;
            btnConfigSist.Location = new Point(181, 704);
        }

        private void btnConfigSist_MouseLeave(object sender, EventArgs e)
        {
            btnConfigSist.Width = 45;
            btnConfigSist.Height = 45;
            btnConfigSist.Location = new Point(190, 715);
        }
        #endregion

        private void OpenChildForm(Form childForm, object btnSender) //Método para llamar un formulario hijo dentro del contenedor PanelChildFrm
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


        #region Botones del Menú y sus Forms

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CapaVistas.Form_Menu.frmEmpleados(), sender);
        }
        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CapaVistas.Form_Menu.frmUsuarios(), sender);
        }



        #endregion


    }




}