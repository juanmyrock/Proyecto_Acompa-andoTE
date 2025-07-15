using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaUtilidades
{
    public static class cls_LlenarCombos
    {
        // Carga un control ComboBox con una lista de datos (DTOs).

        // <typeparam name="T">El tipo de los objetos en la lista (ej: cls_PreguntaDTO).</typeparam>
        // <param name="cmb">El control ComboBox que se va a llenar.</param>
        // <param name="dataSource">La lista de datos (DTOs) para cargar.</param>
        // <param name="displayMember">El nombre de la propiedad del DTO que se mostrará al usuario.</param>
        // <param name="valueMember">El nombre de la propiedad del DTO que se usará como valor interno (el ID).</param>
        public static void Cargar<T>(ComboBox cmb, List<T> dataSource, string displayMember, string valueMember)
        {
            if (dataSource != null && dataSource.Count > 0)
            {
                cmb.DataSource = dataSource;
                cmb.DisplayMember = displayMember;
                cmb.ValueMember = valueMember;

                // Deselecciona cualquier item por defecto para que el usuario deba elegir.
                cmb.SelectedIndex = -1;
                // Opcional: si quieres que aparezca un texto por defecto
                cmb.Text = "Seleccione una opción...";
            }
            else
            {
                // Si no hay datos, limpia el ComboBox para evitar que muestre datos viejos.
                cmb.DataSource = null;
                cmb.Items.Clear();
                cmb.Text = "No hay opciones disponibles";
            }
        }
    }
}
