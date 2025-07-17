// CapaDatos/cls_LocalidadQ.cs
using System;
using System.Data;

namespace CapaDatos
{
    public class cls_LocalidadQ
    {
        private cls_EjecutarQ _ejecutor;

        public cls_LocalidadQ()
        {
            _ejecutor = new cls_EjecutarQ();
        }

        public DataTable ObtenerLocalidades()
        {
            string query = "SELECT id_localidad, localidad FROM Localidades ORDER BY localidad ASC"; 
            try
            {
                return _ejecutor.ConsultaRead(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en cls_LocalidadQ al obtener localidades: {ex.Message}");
                return new DataTable();
            }
        }
    }
}