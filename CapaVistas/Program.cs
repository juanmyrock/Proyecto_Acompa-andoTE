using System;
using System.Windows.Forms;
using CapaSesion.Login;

namespace CapaVistas
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmMenu());


            using (var loginForm = new frmLogin())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    if (SesionUsuario.Instancia.EstaSesionIniciada)
                    {
                        Application.Run(new frmMenu());
                    }
                    else
                    {
                        MessageBox.Show("Error al iniciar sesión. La aplicación se cerrará.");
                    }
                }
            }
        }
    }
}
