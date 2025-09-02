using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaUtilidades
{
    public static class cls_LlenarCombos
    {
        public static void Cargar<T>(ComboBox cmb, List<T> dataSource, string displayMember, string valueMember)
        {
            if (dataSource != null && dataSource.Count > 0)
            {
                cmb.DataSource = dataSource;
                cmb.DisplayMember = displayMember;
                cmb.ValueMember = valueMember;

                cmb.SelectedIndex = -1;
                cmb.Text = "Seleccione una opción...";
            }
            else
            {
                cmb.DataSource = null;
                cmb.Items.Clear();
                cmb.Text = "No hay opciones disponibles";
            }
        }
    }
}
