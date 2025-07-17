using CapaDTO;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos.Utilidades
{
    public class cls_LlenarCombosQ : cls_EjecutarQ
    {
        private cls_EjecutarQ _ejecutar;
        public cls_LlenarCombosQ()
        {
            _ejecutar = new cls_EjecutarQ();
        }

        #region Tabla Localidades
        public LlenarCombosResponseDTO ObtenerLocalidades()
        {
            var response = new LlenarCombosResponseDTO();
            string query = "SELECT id_localidad, localidad FROM Localidades ORDER BY localidad ASC";
            try
            {
                DataTable tablaLocalidades = _ejecutar.ConsultaRead(query);

                if (tablaLocalidades.Rows.Count > 0)
                {
                    response.Localidades = new List<cls_LocalidadDTO>(); // Inicializa la lista
                    foreach (DataRow row in tablaLocalidades.Rows)
                    {
                        response.Localidades.Add(new cls_LocalidadDTO // Usamos LocalidadDTO sin cls_ (según la recomendación anterior)
                        {
                            id_localidad = Convert.ToInt32(row["id_localidad"]), // PascalCase para propiedades
                            nombre_localidad = row["localidad"].ToString()
                        });
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en cls_LocalidadQ al obtener localidades: {ex.Message}");
                return null;
            }

        }
        #endregion

        #region Tabla Sexos
        public LlenarCombosResponseDTO ObtenerSexos()
        {
            var response = new LlenarCombosResponseDTO();
            string query = "SELECT id_sexo, descripcion FROM Sexos";
            try
            {
                DataTable tablaSexos = _ejecutar.ConsultaRead(query);
                if (tablaSexos.Rows.Count > 0)
                {
                    response.Sexos = new List<cls_SexoDTO>(); // Inicializa la lista
                    foreach (DataRow row in tablaSexos.Rows)
                    {
                        response.Sexos.Add(new cls_SexoDTO // Usamos LocalidadDTO sin cls_ (según la recomendación anterior)
                        {
                            id_sexo = Convert.ToInt32(row["id_sexo"]), // PascalCase para propiedades
                            descripcion = row["descripcion"].ToString()
                        });
                    }
                }
                return response;
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error en cls_SexoQ al obtener sexos: {ex.Message}");
                return null;
            }
        }
        #endregion

        #region Tabla Tipos_Dni
        public LlenarCombosResponseDTO ObtenerTiposDocumento()
        {
            var response = new LlenarCombosResponseDTO();
            string query = "SELECT id_tipo_dni, descripcion FROM Tipos_Dni";
            try
            {
                DataTable tablaDocumentos = _ejecutar.ConsultaRead(query);
                if (tablaDocumentos.Rows.Count > 0)
                {
                    response.TiposDocumento = new List<cls_TipoDocumentoDTO>(); // Inicializa la lista
                    foreach (DataRow row in tablaDocumentos.Rows)
                    {
                        response.TiposDocumento.Add(new cls_TipoDocumentoDTO // Usamos LocalidadDTO sin cls_ (según la recomendación anterior)
                        {
                            id_tipo_documento = Convert.ToInt32(row["id_tipo_dni"]), // PascalCase para propiedades
                            descripcion = row["descripcion"].ToString()
                        });
                    }
                }
                return response;
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error en cls_SexoQ al obtener sexos: {ex.Message}");
                return null;
            }
        }
        #endregion
    }
}

