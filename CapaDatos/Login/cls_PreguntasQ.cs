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

        public int ObtenerCantidadPreguntasRequeridas()
        {
            // Usamos TOP 1 porque sabemos que solo hay una fila de configuración
            string sql = "SELECT TOP 1 cantidad_preguntas_seguridad FROM Parametros_Contraseña";
            DataTable tabla = _ejecutar.ConsultaRead(sql, null);

            if (tabla.Rows.Count == 0 || tabla.Rows[0]["cantidad_preguntas_seguridad"] == DBNull.Value)
            {
                return 1;
            }

            return Convert.ToInt32(tabla.Rows[0]["cantidad_preguntas_seguridad"]);
        }


        public void BorrarRespuestasDeUsuario(int idUsuario)
        {
            string sql = "DELETE FROM Respuestas WHERE id_usuario = @idUsuario";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@idUsuario", idUsuario)
            };

            _ejecutar.ConsultaWrite(sql, parametros);
        }

        public List<cls_PreguntaDTO> ObtenerPreguntasConfiguradasPorUsuario(int idUsuario)
        {
            string sql = @"SELECT P.id_pregunta, P.pregunta
                   FROM Respuestas R
                   INNER JOIN Preguntas P ON R.id_pregunta = P.id_pregunta
                   WHERE R.id_usuario = @idUsuario;";

            var parametros = new List<SqlParameter> { new SqlParameter("@idUsuario", idUsuario) };
            DataTable tabla = _ejecutar.ConsultaRead(sql, parametros);

            var listaPreguntas = new List<cls_PreguntaDTO>();
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

        // Obtiene el hash de la respuesta de seguridad que está guardado en la BD.
        public string ObtenerHashRespuestaGuardada(int idUsuario, int idPregunta)
        {
            string sql = "SELECT respuesta FROM Respuestas WHERE id_usuario = @idUsuario AND id_pregunta = @idPregunta";
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@idUsuario", idUsuario),
                new SqlParameter("@idPregunta", idPregunta)
            };

            DataTable tabla = _ejecutar.ConsultaRead(sql, parametros);

            if (tabla.Rows.Count == 0)
            {
                return null;
            }

            return tabla.Rows[0]["respuesta"].ToString();
        }


    }
}

