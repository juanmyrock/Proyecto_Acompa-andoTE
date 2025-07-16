using System;
using System.Collections.Generic;
using System.Data;
using CapaDatos; // Necesario para cls_TipoDNISQ
using CapaDTO.SistemaDTO; // Necesario para cls_TipoDNIDTO

namespace CapaLogica.SistemaLogica
{
    public class cls_TipoDNILogica
    {
        private cls_TipoDNISQ _tipoDNISQ;

        public cls_TipoDNILogica()
        {
            _tipoDNISQ = new cls_TipoDNISQ();
        }

        public List<cls_TipoDNIDTO> ObtenerTiposDNI()
        {
            List<cls_TipoDNIDTO> listaTiposDNI = new List<cls_TipoDNIDTO>();
            try
            {
                DataTable dtTiposDNI = _tipoDNISQ.ObtenerTiposDNI();

                foreach (DataRow row in dtTiposDNI.Rows)
                {
                    listaTiposDNI.Add(new cls_TipoDNIDTO
                    {
                        id_tipo_dni = Convert.ToInt32(row["id_tipo_dni"]),
                        descripcion = row["descripcion"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la lógica al mapear tipos de DNI: {ex.Message}");
                // MessageBox.Show("Error en la lógica al cargar tipos de DNI: " + ex.Message, "Error Lógica", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<cls_TipoDNIDTO>();
            }
            return listaTiposDNI;
        }
    }
}