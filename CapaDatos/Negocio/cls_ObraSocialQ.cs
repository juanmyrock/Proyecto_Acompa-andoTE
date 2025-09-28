using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaDTO.SistemaDTO;
using CapaDatos;

namespace CapaDatos
{
    public class cls_ObraSocialQ
    {
        private cls_EjecutarQ _ejecutor;

        public cls_ObraSocialQ()
        {
            _ejecutor = new cls_EjecutarQ();
        }
    

    public List<cls_ObraSocialDTO> ObtenerObrasSociales()
        {
            string query = "SELECT * FROM Obra_Social";

            try
            {
                DataTable tabla = _ejecutor.ConsultaRead(query);
                var listaObrasSociales = new List<cls_ObraSocialDTO>();

                foreach (DataRow Row in tabla.Rows)
                {
                    listaObrasSociales.Add(new cls_ObraSocialDTO
                    {
                        id_obra_social = Convert.ToInt32(Row["id_obra_social"]),
                        nombre_os = Row["nombre_os"].ToString()
                    });
                }
                return listaObrasSociales;


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener y mapear empleados: {ex.Message}");
                throw;
            }

        }
    }
}

