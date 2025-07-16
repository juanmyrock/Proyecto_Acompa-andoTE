using CapaDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica.Login;

namespace CapaVistas.Forms_Menu
{
    public partial class frmAdminSyst : Form
    {
        cls_ParametrosContraseña parametrosContraQ;
        public frmAdminSyst()
        {
            InitializeComponent();
            
            parametrosContraQ = new cls_ParametrosContraseña();


        }

        private void chkPassCharVerification_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCantidadCaracteres.Checked)
            {
                numCaracteres.Enabled = true;
            }
            else
            {
                numCaracteres.Enabled = false;
            }
            
        }

        private void chkAskUser_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAskUser.Checked) 
            {
                numPreguntas.Enabled = true;
            }
            else
            {
                numPreguntas.Enabled = false;
            }
        }

        private void frmAdminSyst_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Obtener los parámetros de contraseña desde la base de datos
                cls_ParamContraseñaDTO parametrosActuales = parametrosContraQ.ObtenerParametros();

                // 2. Verificar si se obtuvieron parámetros (puede ser null si la tabla está vacía)
                if (parametrosActuales != null)
                {
                    // 3. Asignar los valores del DTO a los controles del formulario


                    chkCombMayus.Checked = parametrosActuales.RequiereMayuscula ?? false;
                    chkCombMin.Checked = parametrosActuales.RequiereMinuscula ?? false;
                    chkNum.Checked = parametrosActuales.RequiereNumero ?? false;
                    chkSpecChar.Checked = parametrosActuales.RequiereCaracterEspecial ?? false;

                    numCaracteres.Value = parametrosActuales.LongitudMinima ?? 0;
                    numPreguntas.Value = parametrosActuales.CantidadPreguntasSeguridad ?? 0;
                    numContrasAnteriores.Value = parametrosActuales.Contras_Anteriores ?? 0;
                    numFallos.Value = parametrosActuales.Cantidad_Intentos ?? 0;
                    numDiasContra.Value = parametrosActuales.DiasValidezPassword ?? 0;

                }
                else
                {

                    MessageBox.Show("No se encontraron parámetros de contraseña en la base de datos. Se mostrarán valores por defecto.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los parámetros de contraseña: {ex.Message}", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void chkRepeatPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRepeatPass.Checked)
            {
                numContrasAnteriores.Enabled = true;
            }
            else 
            {
                numContrasAnteriores.Enabled = false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAcceptAdmin_Click(object sender, EventArgs e)
        {
            // 1. Crea una nueva instancia del DTO para almacenar los valores del formulario
            cls_ParamContraseñaDTO nuevosParametros = new cls_ParamContraseñaDTO();

            // 2. Asigna los valores de los controles del formulario al DTO
            try
            {
                nuevosParametros.RequiereMayuscula = chkCombMayus.Checked;
                nuevosParametros.RequiereMinuscula = chkCombMin.Checked;
                nuevosParametros.RequiereNumero = chkNum.Checked;
                nuevosParametros.RequiereCaracterEspecial = chkSpecChar.Checked;

                nuevosParametros.LongitudMinima = Convert.ToInt32(numCaracteres.Value);
                nuevosParametros.CantidadPreguntasSeguridad = Convert.ToInt32(numPreguntas.Value);
                nuevosParametros.Contras_Anteriores = Convert.ToInt32(numContrasAnteriores.Value);
                nuevosParametros.Cantidad_Intentos = Convert.ToInt32(numFallos.Value);
                nuevosParametros.DiasValidezPassword = Convert.ToInt32(numDiasContra.Value);

                // 3. Llama al método de la capa lógica para modificar los parámetros
                bool exito = parametrosContraQ.ModificarParametros(nuevosParametros);

                if (exito)
                {
                    MessageBox.Show("Parámetros de contraseña actualizados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("No se pudieron actualizar los parámetros de contraseña. Consulte la consola para más detalles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Error de formato en los datos numéricos. Asegúrese de que los campos tienen valores válidos: " + ex.Message, "Error de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado al intentar actualizar los parámetros: " + ex.Message, "Error General", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void chkDiasContra_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDiasContra.Checked)
            {
                numDiasContra.Enabled = true;
            }
            else
            {
                numDiasContra.Enabled = false;
            }
        }

        private void chkFallos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFallos.Checked)
            {
                numFallos.Enabled = true;
            }
            else
            {
                numFallos.Enabled = false;
            }
        }
    }
}
