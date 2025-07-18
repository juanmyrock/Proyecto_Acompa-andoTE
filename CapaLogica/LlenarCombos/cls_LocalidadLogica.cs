﻿using System;
using System.Collections.Generic;
using System.Data;
using CapaDatos; // Necesario para cls_LocalidadQ
using CapaDTO.SistemaDTO; // Necesario para cls_LocalidadDTO

namespace CapaLogica.SistemaLogica
{
    public class cls_LocalidadLogica
    {
        private cls_LocalidadQ _localidadQ;

        public cls_LocalidadLogica()
        {
            _localidadQ = new cls_LocalidadQ();
        }

        public List<cls_LocalidadDTO> ObtenerLocalidades()
        {
            List<cls_LocalidadDTO> listaLocalidades = new List<cls_LocalidadDTO>();
            try
            {
                DataTable dtLocalidades = _localidadQ.ObtenerLocalidades();

                foreach (DataRow row in dtLocalidades.Rows)
                {
                    listaLocalidades.Add(new cls_LocalidadDTO
                    {
                        id_localidad = Convert.ToInt32(row["id_localidad"]),
                        nombre_localidad = row["localidad"].ToString() // *** Ajusta este nombre de columna ***
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la lógica al mapear localidades: {ex.Message}");
                // MessageBox.Show("Error en la lógica al cargar localidades: " + ex.Message, "Error Lógica", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<cls_LocalidadDTO>();
            }
            return listaLocalidades;
        }
    }
}