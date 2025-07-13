using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaDTO;

namespace CapaDatos.Login
{
    public class cls_PreguntasQ
    {
        private readonly cls_EjecutarQ _ejecutar = new cls_EjecutarQ();

        public List<cls_PreguntaDTO> ObtenerPreguntasDisponibles()
        {
            string sql = "SELECT id_pregunta, pregunta FROM Preguntas ORDER BY pregunta;";
            DataTable tabla = _ejecutar.ConsultaRead(sql, null);

            var listaPreguntas = new List<cls_PreguntaDTO>();

            // Convertimos cada fila del DataTable en un objeto DTO y lo añadimos a la lista.
            // Esto desacopla el resto de la aplicación de la estructura de la base de datos.
            foreach (DataRow row in tabla.Rows)
            {
                listaPreguntas.Add(new cls_PreguntaDTO
                {
                    IdPregunta = Convert.ToInt32(row["id_pregunta"]),
                    TextoPregunta = row["pregunta"].ToString()
                });
            }

            return listaPreguntas;
        }

        // Guarda el HASH de una respuesta de seguridad en la base de datos.
        // Este método espera recibir el hash ya procesado desde la capa de lógica.
        public void GuardarRespuestaDeSeguridad(int idUsuario, int idPregunta, string respuestaHash)
        {
            string sql = @"INSERT INTO Respuestas (id_usuario, id_pregunta, respuesta) 
                           VALUES (@idUsuario, @idPregunta, @respuestaHash)";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@idUsuario", idUsuario),
                new SqlParameter("@idPregunta", idPregunta),
                new SqlParameter("@respuestaHash", respuestaHash)
            };

            _ejecutar.ConsultaWrite(sql, parametros);
        }

    }
}
