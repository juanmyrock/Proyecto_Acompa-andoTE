using CapaDatos.Login;
using CapaDTO; 
using CapaUtilidades;
using System.Collections.Generic;
using System;

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
        // <param name="idUsuario">El ID del usuario que está guardando las preguntas.</param>
        // <param name="preguntasYRespuestas">Un diccionario donde la Key es el id_pregunta y el Value es la respuesta en texto plano.</param>
        public void GuardarMultiplesRespuestas(int idUsuario, Dictionary<int, string> preguntasYRespuestas)
        {
            _preguntasDatos.BorrarRespuestasDeUsuario(idUsuario);

            // Iteramos sobre cada par de pregunta/respuesta que el usuario configuró
            foreach (var par in preguntasYRespuestas)
            {
                GuardarRespuestaDeSeguridad(idUsuario, par.Key, par.Value);
            }
        }

        // Valida la respuesta del usuario
        public bool ValidarRespuesta(int idUsuario, int idPregunta, string respuestaEnTextoPlano)
        {
            if (string.IsNullOrWhiteSpace(respuestaEnTextoPlano))
            {
                return false;
            }

            // 1. La lógica pide a la capa de datos el hash guardado.
            string hashCorrecto = _preguntasDatos.ObtenerHashRespuestaGuardada(idUsuario, idPregunta);

            // Si no hay un hash guardado, la validación falla.
            if (hashCorrecto == null)
            {
                return false;
            }

            // 2. La lógica hashea la respuesta que el usuario acaba de ingresar.
            string hashRespuestaIntento = cls_SeguridadPass.GenerarHashSHA256(respuestaEnTextoPlano.Trim().ToLower());

            // 3. La lógica realiza la comparación. Esta es la decisión de seguridad.
            return hashRespuestaIntento.Equals(hashCorrecto, StringComparison.OrdinalIgnoreCase);
        }

        // Obtiene una pregunta al azar para el proceso de recuperación.
        // <returns>Un DTO con los datos de la pregunta.</returns>
        public cls_PreguntaDTO ObtenerPreguntaRandomParaUsuario(int idUsuario)
        {
            // 1. Obtenemos TODAS las preguntas configuradas por el usuario.
            var preguntasConfiguradas = _preguntasDatos.ObtenerPreguntasConfiguradasPorUsuario(idUsuario);

            // 2. Verificamos si la lista está vacía.
            if (preguntasConfiguradas == null || preguntasConfiguradas.Count == 0)
            {
                throw new Exception("Este usuario no tiene preguntas de seguridad configuradas.");
            }

            // 3.Usamos la clase Random de C# para elegir una.
            var random = new Random();
            int indiceAleatorio = random.Next(0, preguntasConfiguradas.Count); // Genera un número entre 0 y el total de preguntas - 1

            // 4. Devolvemos la pregunta que se encuentra en esa posición aleatoria.
            return preguntasConfiguradas[indiceAleatorio];
        }
    }


}
