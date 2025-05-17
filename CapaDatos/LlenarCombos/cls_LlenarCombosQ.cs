using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos.Llenar_Combos
{
    public class cls_LlenarCombosQ : cls_EjecutarQ
    {
        #region Atributos
        private string tabla;
        private string campoid;
        private string campodescrip;
        private string condicion;
        #endregion

        #region Properties
        public string Tabla
        {
            set { tabla = value; }
        }
        public string CampoId
        {
            set { campoid = value; }
        }
        public string CampoDescrip
        {
            set { campodescrip = value; }
        }
        public string Condicion
        {
            set { condicion = value; }
        }
        #endregion

        public DataTable CargarCMB()
        {
            string sSql;
            if (string.IsNullOrEmpty(condicion))
            {
                sSql = $"SELECT {campoid}, {campodescrip} FROM {tabla} ORDER BY {campodescrip}";
            }
            else
            {
                sSql = $"SELECT {campoid}, {campodescrip} FROM {tabla} WHERE {condicion} ORDER BY {campodescrip}";
            }

            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>(); // Lista para los parámetros de consulta (si es necesario)
                return ConsultaRead(sSql, parametros); // Llama al método ConsultaRead de cls_EjecutarQ
            }
            catch (Exception ex)
            {
                // Manejo de errores específico de esta consulta
                Console.WriteLine($"Error al cargar ComboBox: {ex.Message}");
                return null; // Devuelve null en caso de error
            }
        }
    }
}
