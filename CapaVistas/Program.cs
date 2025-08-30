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
                // Muestra el formulario de login como modal
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Validar que la sesión esté inicializada correctamente
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
