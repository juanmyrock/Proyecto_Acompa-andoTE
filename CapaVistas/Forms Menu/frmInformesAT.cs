using CapaDTO.SistemaDTO;
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
        public frmInformesAT()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //if (!int.TryParse(txtBusquedaPaciente.Text, out int dniBuscado))
            //{
            //    MessageBox.Show("Por favor, ingrese un número de DNI válido.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtBusquedaPaciente.Clear();
            //    return;
            //}

            //try
            //{
            //    cls_PacienteDTO pacienteEncontrado = _logicaPaciente.BuscarPacientePorDni(dniBuscado);

            //    if (pacienteEncontrado != null)
            //    {

            //        List<cls_PacienteDTO> resultado = new List<cls_PacienteDTO> { pacienteEncontrado };

            //        dgvVerPacientes.DataSource = resultado;

            //        MessageBox.Show($"Paciente {pacienteEncontrado.Nombre} {pacienteEncontrado.Apellido} encontrado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else
            //    {

            //        MessageBox.Show($"No se encontró ningún paciente con DNI: {dniBuscado}.", "No Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //        CargarPacientesEnDataGridView();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error al buscar el paciente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    CargarPacientesEnDataGridView();
            //}
        }
    }
}
