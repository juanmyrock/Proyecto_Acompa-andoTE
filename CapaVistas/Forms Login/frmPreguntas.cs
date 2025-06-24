using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaVistas.Forms_Login
{
    public partial class frmPreguntas : Form
    {
        public frmPreguntas()
        {
            InitializeComponent();
        }

        // Método para configurar los labels con las preguntas
        public void SetPreguntas(List<string> preguntas)
        {
            if (preguntas.Count > 0) lblPregunta1.Text = preguntas[0];
            if (preguntas.Count > 1) lblPregunta2.Text = preguntas[1];
            if (preguntas.Count > 2) lblPregunta3.Text = preguntas[2];
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            frmRecuperarPass recuperar = new frmRecuperarPass();
            this.Dispose();
            recuperar.ShowDialog();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            frmRecuperarPass recuperar = new frmRecuperarPass();
            this.Dispose();
            recuperar.ShowDialog();
        }
    }
}
