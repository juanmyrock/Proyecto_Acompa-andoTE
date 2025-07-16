// CapaDatos/cls_SexoQ.cs
using System;
using System.Data;

namespace CapaDatos
{
    public class cls_SexoQ
    {
        private cls_EjecutarQ _ejecutor;

        public cls_SexoQ()
        {
            _ejecutor = new cls_EjecutarQ();
        }

        public DataTable ObtenerSexos()
        {
            string query = "SELECT id_sexo, descripcion FROM Sexos"; // *** Ajusta "Sexos" y los nombres de las columnas a tu DB ***
            try
            {
                return _ejecutor.ConsultaRead(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en cls_SexoQ al obtener sexos: {ex.Message}");
                // MessageBox.Show($"Error en CapaDatos (Sexos): {ex.Message}", "Error DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }
    }
}
