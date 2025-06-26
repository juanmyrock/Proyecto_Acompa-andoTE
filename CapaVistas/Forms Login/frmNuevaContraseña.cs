using CapaLogica;
using CapaServicios;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaVistas.Forms_Login
{
    public partial class frmNuevaContraseña : Form
    {
        private readonly int _idUsuario;

        // El constructor ahora recibe el ID del usuario al que se le cambiará la contraseña.
        // He eliminado el campo txtUsuario que parecía ser de otro formulario.
        public frmNuevaContraseña(int idUsuario)
        {
            InitializeComponent();
            _idUsuario = idUsuario;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            lblErrorMsg.Visible = false;

            // 1. Validar campos
            if (!ValidarCampos())
            {
                return;
            }

            // 2. Llamar a la capa de lógica para restablecer la contraseña
            try
            {
                var logica = new cls_LogicaLogin();
                // Usamos el ID de usuario que recibimos en el constructor.
                logica.RestablecerContraseña(_idUsuario, txtNuevaContraseña.Text); // Asumo que el textbox se llama así

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MsgError("Error al guardar la contraseña: " + ex.Message);
            }
        }

        // --- Métodos de UI y Navegación ---
        private bool ValidarCampos()
        {
            // Asumo que tienes dos TextBox: txtNuevaContraseña y txtRepetirContraseña
            if (string.IsNullOrWhiteSpace(txtNuevaContraseña.Text))
            {
                MsgError("La contraseña no puede estar vacía.");
                return false;
            }
            if (txtNuevaContraseña.Text != txtRepetirContraseña.Text)
            {
                MsgError("Las contraseñas no coinciden.");
                return false;
            }
            // TODO: Aquí podrías añadir validaciones de complejidad de la contraseña
            // (ej: debe tener al menos 8 caracteres, una mayúscula, etc.)
            return true;
        }

        private void MsgError(string msg)
        {
            lblErrorMsg.Text = "      " + msg;
            lblErrorMsg.Visible = true;
            // picError.Visible = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
