// CapaDatos/cls_TipoDNISQ.cs
using System;
using System.Data;

namespace CapaDatos
{
    public class cls_TipoDNISQ
    {
        private cls_EjecutarQ _ejecutor;

        public cls_TipoDNISQ()
        {
            _ejecutor = new cls_EjecutarQ();
        }

        public DataTable ObtenerTiposDNI()
        {
            string query = "SELECT id_tipo_dni, descripcion FROM Tipos_Dni";
            try
            {
                return _ejecutor.ConsultaRead(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en cls_TipoDNISQ al obtener tipos de DNI: {ex.Message}");
                return new DataTable();
            }
        }
    }
}