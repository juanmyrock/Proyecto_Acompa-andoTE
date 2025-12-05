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
                        response.Localidades.Add(new cls_LocalidadDTO
                        {
                            id_localidad = Convert.ToInt32(row["id_localidad"]),
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

        #region Tabla Roles
        public LlenarCombosResponseDTO ObtenerRoles()
        {
            var response = new LlenarCombosResponseDTO();
            string query = "SELECT id_rol, nombre_rol, descripcion FROM Roles";
            try
            {
                DataTable tablaRoles = _ejecutar.ConsultaRead(query);
                if (tablaRoles.Rows.Count > 0)
                {
                    response.Roles = new List<cls_RolDTO>();
                    foreach (DataRow row in tablaRoles.Rows)
                    {
                        response.Roles.Add(new cls_RolDTO 
                        {
                            IdRol = Convert.ToInt32(row["id_rol"]),
                            NombreRol = row["nombre_rol"].ToString(),
                            Descripcion = row["descripcion"].ToString()
                        });
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en cls_RolQ al obtener roles: {ex.Message}");
                return null;
            }
        }

        #endregion

        #region Tabla Obras_Sociales
        public LlenarCombosResponseDTO ObtenerObrasSociales()
        {
            var response = new LlenarCombosResponseDTO();
            string query = "SELECT id_obra_social, nombre_os FROM Obra_Social";
            try
            {
                DataTable tablaObraSocial = _ejecutar.ConsultaRead(query);
                if (tablaObraSocial.Rows.Count > 0)
                {
                    response.ObraSocial = new List<cls_ObraSocialDTO>();
                    foreach (DataRow row in tablaObraSocial.Rows)
                    {
                        response.ObraSocial.Add(new cls_ObraSocialDTO
                        {
                            id_obra_social = Convert.ToInt32(row["id_obra_social"]),
                            descripcion = row["nombre_os"].ToString()
                        });
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en cls_ObraSocialQ al obtener obras sociales: {ex.Message}");
                return null;
            }
        }
        #endregion

        #region Tabla Profesionales
        public LlenarCombosResponseDTO ObtenerProfesionales()
        {
            var response = new LlenarCombosResponseDTO();
            string query = "SELECT id_profesional, nombre + ' ' + apellido as NomApe FROM Profesionales";
            try
            {
                DataTable tablaProfesionales = _ejecutar.ConsultaRead(query);
                if (tablaProfesionales.Rows.Count > 0)
                {
                    response.Acompañantes = new List<cls_AcompañantesDTO>();
                    foreach (DataRow row in tablaProfesionales.Rows)
                    {
                        response.Acompañantes.Add(new cls_AcompañantesDTO
                        {
                            id_profesional = Convert.ToInt32(row["id_profesional"]),
                            NomApe = row["NomApe"].ToString()
                            
                        });
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en cls_ObraSocialQ al obtener obras sociales: {ex.Message}");
                return null;
            }
        }
        #endregion

        #region Tabla Tramites
        public LlenarCombosResponseDTO ObtenerTramites()
        {
            
            var response = new LlenarCombosResponseDTO();
            string query = "SELECT id_tramite, descripcion FROM Tipos_Tramite";
            try
            {
                DataTable tablaTramites = _ejecutar.ConsultaRead(query);
                if (tablaTramites.Rows.Count > 0)
                {
                    response.Tramites = new List<cls_TramitesDTO>();
                    foreach (DataRow row in tablaTramites.Rows)
                    {
                        response.Tramites.Add(new cls_TramitesDTO
                        {
                            id_tramite = Convert.ToInt32(row["id_tramite"]),
                            descripcion = row["descripcion"].ToString()

                        });
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en cls_TramitesQ al obtener Tramites: {ex.Message}");
                return null;
            }
        }
        #endregion

        #region Tabla Especialidad
        public LlenarCombosResponseDTO ObtenerEspecialidades()
        {
            var response = new LlenarCombosResponseDTO();
            string query = "SELECT id_especialidad, especialidad FROM Especialidad";
            try
            {
                DataTable tablaEspecialidad = _ejecutar.ConsultaRead(query);
                if (tablaEspecialidad.Rows.Count > 0)
                {
                    response.Especialidades = new List< cls_EspecialidadesDTO>();
                    foreach (DataRow row in tablaEspecialidad.Rows)
                    {
                        response.Especialidades.Add(new cls_EspecialidadesDTO
                        {
                            id_especialidad = Convert.ToInt32(row["id_especialidad"]),
                            especialidad = row["especialidad"].ToString()

                        });
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en cls_EspecialidadesQ al obtener especialidades: {ex.Message}");
                return null;
            }
        }
        #endregion
        public LlenarCombosResponseDTO ObtenerEspecialidadesSinAcompaniante()
        {
            var response = new LlenarCombosResponseDTO();
            string query = "SELECT id_especialidad, especialidad FROM Especialidad Where id_especialidad > 1";
            try
            {
                DataTable tablaEspecialidad = _ejecutar.ConsultaRead(query);
                if (tablaEspecialidad.Rows.Count > 0)
                {
                    response.Especialidades = new List<cls_EspecialidadesDTO>();
                    foreach (DataRow row in tablaEspecialidad.Rows)
                    {
                        response.Especialidades.Add(new cls_EspecialidadesDTO
                        {
                            id_especialidad = Convert.ToInt32(row["id_especialidad"]),
                            especialidad = row["especialidad"].ToString()

                        });
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en cls_EspecialidadesQ al obtener especialidades: {ex.Message}");
                return null;
            }
        }
        #region Tabla Provincias
        public LlenarCombosResponseDTO ObtenerProvincias()
        {
            var response = new LlenarCombosResponseDTO();
            string query = "SELECT id, provincia FROM Provincias";
            try
            {
                DataTable tablaProvincia = _ejecutar.ConsultaRead(query);
                if (tablaProvincia.Rows.Count > 0)
                {
                    response.Provincias = new List<cls_ProvinciasDTO>();
                    foreach (DataRow row in tablaProvincia.Rows)
                    {
                        response.Provincias.Add(new cls_ProvinciasDTO
                        {
                            id = Convert.ToInt32(row["id"]),
                            provincia = row["provincia"].ToString()

                        });
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en cls_LlenarCombosQ al obtener Provincias: {ex.Message}");
                return null;
            }
        }
        #endregion
    }
}

