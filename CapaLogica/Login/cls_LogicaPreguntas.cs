using System.Collections.Generic;
using CapaDatos.Login;
using CapaUtilidades;
using CapaDTO; 

namespace CapaLogica
{
    public class cls_LogicaPreguntas
    {
        private readonly cls_PreguntasQ _preguntasDatos = new cls_PreguntasQ();

        public List<cls_PreguntaDTO> ObtenerPreguntasDisponibles()
        {
            return _preguntasDatos.ObtenerPreguntasDisponibles();
        }

        public void GuardarRespuestaDeSeguridad(int idUsuario, int idPregunta, string respuestaEnTextoPlano)
        {
            // 1. Validar la entrada (regla de negocio)
            if (string.IsNullOrWhiteSpace(respuestaEnTextoPlano))
            {
                throw new System.Exception("La respuesta no puede estar vacía.");
            }

            // 2. Hashear la respuesta (transformación de datos)
            string hashRespuesta = cls_SeguridadPass.GenerarHashSHA256(respuestaEnTextoPlano.Trim().ToLower());

            // 3. Pasar el hash a la capa de datos para que lo guarde
            _preguntasDatos.GuardarRespuestaDeSeguridad(idUsuario, idPregunta, hashRespuesta);
        }


    }
}
