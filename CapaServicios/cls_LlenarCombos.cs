using CapaDatos.LlenarCombos;
using System.Data;
using System;
using System.Windows.Forms;

namespace CapaServicios.Llenar_Combos
{
    public class cls_LlenarCombos
    {
        private cls_LlenarCombosQ llenar = new cls_LlenarCombosQ();

        public cls_LlenarCombos(ComboBox CMB, string NombreTabla, string CampoID, string CampoDescrip, string Condicion = "")
        {
            llenar.Tabla = NombreTabla;
            llenar.CampoId = CampoID;
            llenar.CampoDescrip = CampoDescrip;
            llenar.Condicion = Condicion;

            DataTable datos = llenar.CargarCMB(); // Obtener datos del método CargarCMB de cls_LlenarCombosQ

            if (datos != null && datos.Rows.Count > 0)
            {
                CMB.DataSource = datos;
                CMB.DisplayMember = CampoDescrip;
                CMB.ValueMember = CampoID;
                CMB.SelectedIndex = -1;
            }
            else
            {
                // Manejo de caso en que no se obtienen datos
                Console.WriteLine("No se encontraron datos para llenar el ComboBox.");
            }
        }
    }
}
