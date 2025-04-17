using System;
using System.Windows.Forms;

namespace CapaVistas
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CapaVistas.frmLogin frm = new CapaVistas.frmLogin();
            frm.ShowDialog();

            //if (frm.DialogResult == DialogResult.OK)
                //Application.Run(new frmMenu());

        }
    }
}

