using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaDTO;

namespace CapaDatos
{
    public class cls_ParamContraseñaQ
    {
        private readonly cls_EjecutarQ ejecutar = new cls_EjecutarQ();

        public cls_ParamContraseñaDTO ObtenerParametro()
        {
            string sql = @"
                SELECT TOP 1 
                    id_parametro, longitud_minima, requiere_mayuscula, requiere_minuscula, 
                    requiere_numero, requiere_caracter_especial, cantidad_preguntas_seguridad, 
                    dias_validez_password
                FROM Parametros_Contraseña";

            DataTable tabla = ejecutar.ConsultaRead(sql);

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
                DiasValidezPassword = row["dias_validez_password"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["dias_validez_password"])
            };
        }
    }
}
