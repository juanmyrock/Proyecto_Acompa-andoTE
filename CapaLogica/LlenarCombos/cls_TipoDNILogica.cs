using System;
using System.Collections.Generic;
using System.Data;
using CapaDatos;
using CapaDTO.SistemaDTO;

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
                return new List<cls_TipoDNIDTO>();
            }
            return listaTiposDNI;
        }
    }
}