﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaDTO.SistemaDTO;

namespace CapaDatos
{
    public class cls_EmpleadosQ // Anteriormente cls_EmpleadosQ
    {
        // Instancia de cls_EjecutarQ para manejar las operaciones de DB
        private cls_EjecutarQ _ejecutor;

        public cls_EmpleadosQ()
        {
            _ejecutor = new cls_EjecutarQ(); // Inicializa el ejecutor de consultas
        }

        public bool InsertarEmpleado(cls_EmpleadoDTO empleado)
        { 
        string query = "INSERT INTO Empleados (puesto, nombre, apellido, id_sexo, id_tipo_dni, dni, fecha_nac, id_localidad, domicilio, num_domicilio, carga_hs, email, telefono) " +
                           "VALUES (@puesto, @nombre, @apellido, @id_sexo, @id_tipo_dni, @dni, @fecha_nac, @id_localidad, @domicilio, @num_domicilio, @carga_hs, @email, @telefono)";

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
                _ejecutor.ConsultaWrite(query, parametros);
                return true; // Si no hay excepción, la inserción fue exitosa
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar empleado en cls_EmpleadosQ: {ex.Message}");
                throw; // *** CAMBIO CLAVE: Re-lanza la excepción para que llegue a la capa lógica y luego a la UI ***
            }
        }

        public DataTable ObtenerEmpleados()
        {
            string query = "SELECT id_empleado, puesto, nombre, apellido, id_sexo, id_tipo_dni, dni, fecha_nac, id_localidad, domicilio, num_domicilio, carga_hs, email, telefono FROM Empleados";

            try
            {
                // Usa el método ConsultaRead de cls_EjecutarQ
                return _ejecutor.ConsultaRead(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener empleados usando cls_EjecutarQ: {ex.Message}");
                return new DataTable(); // Devuelve un DataTable vacío en caso de error
            }
        }

        public bool ActualizarEmpleado(cls_EmpleadoDTO empleado)
        {
            string query = "UPDATE Empleados SET puesto = @puesto, nombre = @nombre, apellido = @apellido, " +
                           "id_sexo = @id_sexo, id_tipo_dni = @id_tipo_dni, dni = @dni, fecha_nac = @fecha_nac, " +
                           "id_localidad = @id_localidad, domicilio = @domicilio, num_domicilio = @num_domicilio, " +
                           "carga_hs = @carga_hs, email = @email, telefono = @telefono WHERE id_empleado = @id_empleado";

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
                _ejecutor.ConsultaWrite(query, parametros); // Llama a ConsultaWrite de cls_EjecutarQ
                return true; // Asumimos éxito si no hay excepción
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar empleado usando cls_EjecutarQ: {ex.Message}");
                return false;
            }
        }

        public bool EliminarEmpleado(int id_empleado)
        {
            string query = "DELETE FROM Empleados WHERE id_empleado = @id_empleado";
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@id_empleado", id_empleado)
            };

            try
            {
                _ejecutor.ConsultaWrite(query, parametros); // Llama a ConsultaWrite de cls_EjecutarQ
                return true; // Asumimos éxito si no hay excepción
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar empleado usando cls_EjecutarQ: {ex.Message}");
                return false;
            }
        }
    }
}