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
            string query = "SELECT id_sexo, descripcion FROM Sexos";
            try
            {
                return _ejecutor.ConsultaRead(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en cls_SexoQ al obtener sexos: {ex.Message}");
                return new DataTable();
            }
        }
    }
}
