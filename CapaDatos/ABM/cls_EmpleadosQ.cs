using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaDTO.SistemaDTO;

namespace CapaDatos
{
    public class cls_EmpleadosQ
    {
        private cls_EjecutarQ _ejecutor;

        public cls_EmpleadosQ()
        {
            _ejecutor = new cls_EjecutarQ();
        }

        public bool InsertarEmpleado(cls_EmpleadoDTO empleado)
        { 
        string query = "[dbo].[InsertarEmpleado]";

        List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@puesto", empleado.puesto),
                new SqlParameter("@nombre", empleado.nombre),
                new SqlParameter("@apellido", empleado.apellido),
                new SqlParameter("@id_sexo", empleado.id_sexo),
                new SqlParameter("@id_tipo_dni", empleado.id_tipo_dni),
                new SqlParameter("@dni", empleado.dni),
                new SqlParameter("@fecha_nac", empleado.fecha_nac),
                new SqlParameter("@id_localidad", empleado.id_localidad),
                new SqlParameter("@domicilio", empleado.domicilio),
                new SqlParameter("@num_domicilio", empleado.num_domicilio),
                new SqlParameter("@carga_hs", empleado.carga_hs),
                new SqlParameter("@email", empleado.email),
                new SqlParameter("@telefono", empleado.telefono)
            };

            try
            {
                _ejecutor.ConsultaWriteSP(query, parametros);
                return true; // Si no hay excepción, la inserción fue exitosa
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar empleado en cls_EmpleadosQ: {ex.Message}");
                throw; // *** CAMBIO CLAVE: Re-lanza la excepción para que llegue a la capa lógica y luego a la UI ***
            }
        }

        public List<cls_EmpleadoDTO> ObtenerEmpleados()
        {
            string query = "[dbo].[ObtenerEmpleados]";

            try
            {
                DataTable tabla = _ejecutor.ConsultaReadSP(query);
                var listaEmpleados = new List<cls_EmpleadoDTO>();

                // Convertimos cada fila del DataTable en un objeto DTO, asegurándonos de mapear TODOS los campos
                foreach (DataRow row in tabla.Rows)
                {
                    listaEmpleados.Add(new cls_EmpleadoDTO
                    {
                        id_empleado = Convert.ToInt32(row["id_empleado"]),
                        puesto = row["puesto"].ToString(),
                        nombre = row["nombre"].ToString(),
                        apellido = row["apellido"].ToString(),
                        id_sexo = Convert.ToInt32(row["id_sexo"]),
                        id_tipo_dni = Convert.ToInt32(row["id_tipo_dni"]),
                        dni = Convert.ToInt32(row["dni"]),
                        fecha_nac = Convert.ToDateTime(row["fecha_nac"]),
                        id_localidad = Convert.ToInt32(row["id_localidad"]),
                        domicilio = row["domicilio"].ToString(),
                        num_domicilio = Convert.ToInt32(row["num_domicilio"]),
                        carga_hs = Convert.ToDecimal(row["carga_hs"]),
                        email = row["email"].ToString(), // Mapeo del email
                        telefono = row["telefono"].ToString(),
                        esActivo = Convert.ToBoolean(row["esActivo"])
                    });
                }

                return listaEmpleados;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener y mapear empleados: {ex.Message}");
                throw; // Re-lanzamos la excepción para que la capa de lógica la maneje.
            }
        }

        public bool ActualizarEmpleado(cls_EmpleadoDTO empleado)
        {
            string query = "[dbo].[ActualizarEmpleado]";

            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@puesto", empleado.puesto),
                new SqlParameter("@nombre", empleado.nombre),
                new SqlParameter("@apellido", empleado.apellido),
                new SqlParameter("@id_sexo", empleado.id_sexo),
                new SqlParameter("@id_tipo_dni", empleado.id_tipo_dni),
                new SqlParameter("@dni", empleado.dni),
                new SqlParameter("@fecha_nac", empleado.fecha_nac),
                new SqlParameter("@id_localidad", empleado.id_localidad),
                new SqlParameter("@domicilio", empleado.domicilio),
                new SqlParameter("@num_domicilio", empleado.num_domicilio),
                new SqlParameter("@carga_hs", empleado.carga_hs),
                new SqlParameter("@email", empleado.email),
                new SqlParameter("@telefono", empleado.telefono),
                new SqlParameter("@id_empleado", empleado.id_empleado)
            };

            try
            {
                _ejecutor.ConsultaWriteSP(query, parametros); 
                return true; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar empleado usando cls_EjecutarQ: {ex.Message}");
                return false;
            }
        }

        public bool EliminarEmpleado(int id_empleado)
        {
            string query = "[dbo].[EliminarEmpleado]";
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@id_empleado", id_empleado)
            };

            try
            {
                _ejecutor.ConsultaWriteSP(query, parametros); 
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar empleado usando cls_EjecutarQ: {ex.Message}");
                return false;
            }
        }
    }
}