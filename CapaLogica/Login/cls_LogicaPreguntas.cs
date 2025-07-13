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
        public int ObtenerCantidadPreguntasRequeridas()
        {
            return _preguntasDatos.ObtenerCantidadPreguntasRequeridas();
        }

        // Recibe un diccionario con todas las preguntas y respuestas configuradas por el usuario
        // y las guarda en la base de datos una por una.
        // </summary>
        // <param name="idUsuario">El ID del usuario que está guardando las preguntas.</param>
        // <param name="preguntasYRespuestas">Un diccionario donde la Key es el id_pregunta y el Value es la respuesta en texto plano.</param>
        public void GuardarMultiplesRespuestas(int idUsuario, Dictionary<int, string> preguntasYRespuestas)
        {
            // Opcional pero MUY RECOMENDADO:
            // Antes de insertar las nuevas respuestas, borramos cualquier respuesta
            // vieja que el usuario pudiera tener. Esto evita problemas si el usuario
            // reconfigura sus preguntas en el futuro.
            // Necesitarás añadir el método 'BorrarRespuestasDeUsuario' a tu 'cls_PreguntasQ'.
            _preguntasDatos.BorrarRespuestasDeUsuario(idUsuario);

            // Iteramos sobre cada par de pregunta/respuesta que el usuario configuró
            foreach (var par in preguntasYRespuestas)
            {
                // Reutilizamos el método que ya teníamos para guardar una sola respuesta.
                // Este método ya se encarga de validar que la respuesta no esté vacía y de hashearla.
                GuardarRespuestaDeSeguridad(idUsuario, par.Key, par.Value);
            }
        }

    }
}
