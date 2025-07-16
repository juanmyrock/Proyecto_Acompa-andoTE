using CapaDTO;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class cls_ParamContraseñaQ
    {
        private readonly cls_EjecutarQ _ejecutar = new cls_EjecutarQ();

        public cls_ParamContraseñaDTO ObtenerParametro()
        {
            string sql = @"
                SELECT TOP 1 
                    id_parametro, longitud_minima, requiere_mayuscula, requiere_minuscula, 
                    requiere_numero, requiere_caracter_especial, cantidad_preguntas_seguridad, cantidad_intentos, 
                    dias_validez_password, cantidad_historial_password
                FROM Parametros_Contraseña";

            DataTable tabla = _ejecutar.ConsultaRead(sql);

            if (tabla.Rows.Count == 0)
                return null;

            DataRow row = tabla.Rows[0];

            return new cls_ParamContraseñaDTO
            {
                IdParametro = Convert.ToInt32(row["id_parametro"]),
                LongitudMinima = row["longitud_minima"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["longitud_minima"]),
                RequiereMayuscula = row["requiere_mayuscula"] == DBNull.Value ? (bool?)null : Convert.ToBoolean(row["requiere_mayuscula"]),
                RequiereMinuscula = row["requiere_minuscula"] == DBNull.Value ? (bool?)null : Convert.ToBoolean(row["requiere_minuscula"]),
                RequiereNumero = row["requiere_numero"] == DBNull.Value ? (bool?)null : Convert.ToBoolean(row["requiere_numero"]),
                RequiereCaracterEspecial = row["requiere_caracter_especial"] == DBNull.Value ? (bool?)null : Convert.ToBoolean(row["requiere_caracter_especial"]),
                CantidadPreguntasSeguridad = row["cantidad_preguntas_seguridad"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["cantidad_preguntas_seguridad"]),
                Cantidad_Intentos = row["cantidad_intentos"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["cantidad_intentos"]),
                DiasValidezPassword = row["dias_validez_password"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["dias_validez_password"]),
                Contras_Anteriores = row["cantidad_historial_password"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["cantidad_historial_password"])
            };
        }
        public bool ModificarParametros(cls_ParamContraseñaDTO parametros) // bool para indicar si falla
        {
            string sql = @"
                UPDATE Parametros_Contraseña
                SET
                    longitud_minima = @LongitudMinima,
                    requiere_mayuscula = @RequiereMayuscula,
                    requiere_minuscula = @RequiereMinuscula,
                    requiere_numero = @RequiereNumero,
                    requiere_caracter_especial = @RequiereCaracterEspecial,
                    cantidad_preguntas_seguridad = @CantidadPreguntasSeguridad,
                    cantidad_intentos = @CantidadIntentos,
                    dias_validez_password = @DiasValidezPassword,
                    cantidad_historial_password = @Contras_Anteriores";


            // Lista de parámetros SQL para la consulta
            List<SqlParameter> parametrosSql = new List<SqlParameter>
            {
                new SqlParameter("@LongitudMinima", parametros.LongitudMinima ?? (object)DBNull.Value),
                new SqlParameter("@RequiereMayuscula", parametros.RequiereMayuscula ?? (object)DBNull.Value),
                new SqlParameter("@RequiereMinuscula", parametros.RequiereMinuscula ?? (object)DBNull.Value),
                new SqlParameter("@RequiereNumero", parametros.RequiereNumero ?? (object)DBNull.Value),
                new SqlParameter("@RequiereCaracterEspecial", parametros.RequiereCaracterEspecial ?? (object)DBNull.Value),
                new SqlParameter("@CantidadPreguntasSeguridad", parametros.CantidadPreguntasSeguridad ?? (object)DBNull.Value),
                new SqlParameter("@CantidadIntentos", parametros.Cantidad_Intentos ?? (object)DBNull.Value),
                new SqlParameter("@DiasValidezPassword", parametros.DiasValidezPassword ?? (object)DBNull.Value),
                new SqlParameter("@Contras_Anteriores", parametros.Contras_Anteriores ?? (object)DBNull.Value)
            };

            try
            {
                _ejecutar.ConsultaWrite(sql, parametrosSql);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la capa de datos al modificar parámetros de contraseña: {ex.Message}");
                return false;
            }
        }
    }
}
