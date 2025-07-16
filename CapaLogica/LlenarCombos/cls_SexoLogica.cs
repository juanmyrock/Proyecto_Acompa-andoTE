using System;
using System.Collections.Generic;
using System.Data;
using CapaDatos; // Necesario para cls_SexoQ
using CapaDTO.SistemaDTO; // Necesario para cls_SexoDTO

namespace CapaLogica.SistemaLogica
{
    public class cls_SexoLogica
    {
        private cls_SexoQ _sexoQ;

        public cls_SexoLogica()
        {
            _sexoQ = new cls_SexoQ();
        }

        public List<cls_SexoDTO> ObtenerSexos()
        {
            List<cls_SexoDTO> listaSexos = new List<cls_SexoDTO>();
            try
            {
                DataTable dtSexos = _sexoQ.ObtenerSexos();

                foreach (DataRow row in dtSexos.Rows)
                {
                    listaSexos.Add(new cls_SexoDTO
                    {
                        id_sexo = Convert.ToInt32(row["id_sexo"]),
                        descripcion = row["descripcion"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la lógica al mapear sexos: {ex.Message}");
                // MessageBox.Show("Error en la lógica al cargar sexos: " + ex.Message, "Error Lógica", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<cls_SexoDTO>();
            }
            return listaSexos;
        }
    }
}