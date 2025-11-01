using CapaDTO.SistemaDTO;
using CapaLogica.SistemaLogica;
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
    public partial class frmInformesAT : Form
    {
        cls_LogicaGestionarPacientes _logicaPaciente = new cls_LogicaGestionarPacientes();
        public frmInformesAT()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtBusquedaPaciente.Text, out int dniBuscado))
            {
                MessageBox.Show("Por favor, ingrese un número de DNI válido.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBusquedaPaciente.Clear();
                return;
            }

            try
            {
                cls_PacienteDTO pacienteEncontrado = _logicaPaciente.BuscarPacientePorDni(dniBuscado);

                if (pacienteEncontrado != null)
                {

                    List<cls_PacienteDTO> resultado = new List<cls_PacienteDTO> { pacienteEncontrado };

                    lblApeNom.Text = pacienteEncontrado.Nombre + " " + pacienteEncontrado.Apellido;

                    lblHoras.Text = Convert.ToString(pacienteEncontrado.cargahoraria_at);

                    
                }
                else
                {

                    MessageBox.Show($"No se encontró ningún paciente con DNI: {dniBuscado}.", "No Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar el paciente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }
    }
}
