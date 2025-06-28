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

namespace CapaVistas.Forms_Menu
{
    public partial class frmAdminSyst : Form
    {
        cls_ParamContraseñaDTO parametrosContra;
        public frmAdminSyst()
        {
            InitializeComponent();
            parametrosContra = new cls_ParamContraseñaDTO();
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
            
            parametrosContra.RequiereMayuscula = chkCombMayus.Checked;
            parametrosContra.RequiereMinuscula = chkCombMin.Checked;
            parametrosContra.RequiereNumero = chkNum.Checked;
            parametrosContra.LongitudMinima = Convert.ToInt32(numCaracteres.Value);
            parametrosContra.CantidadPreguntasSeguridad = Convert.ToInt32(numPreguntas.Value);
            parametrosContra.RequiereNumero = chkNum.Checked;
            parametrosContra.RequiereCaracterEspecial = chkSpecChar.Checked;
            parametrosContra.Contras_Anteriores = Convert.ToInt32(numContrasAnteriores.Value);
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
    }
}
