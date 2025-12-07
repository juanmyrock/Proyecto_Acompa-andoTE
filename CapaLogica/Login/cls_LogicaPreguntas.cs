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
            if (string.IsNullOrWhiteSpace(respuestaEnTextoPlano))
            {
                throw new System.Exception("La respuesta no puede estar vacía.");
            }

            string hashRespuesta = cls_SeguridadPass.GenerarHashSHA256(respuestaEnTextoPlano.Trim().ToLower());

            _preguntasDatos.GuardarRespuestaDeSeguridad(idUsuario, idPregunta, hashRespuesta);
        }
        public int ObtenerCantidadPreguntasRequeridas()
        {
            return _preguntasDatos.ObtenerCantidadPreguntasRequeridas();
        }
        public void GuardarMultiplesRespuestas(int idUsuario, Dictionary<int, string> preguntasYRespuestas)
        {
            _preguntasDatos.BorrarRespuestasDeUsuario(idUsuario);

            foreach (var par in preguntasYRespuestas)
            {
                GuardarRespuestaDeSeguridad(idUsuario, par.Key, par.Value);
            }
        }

        public bool ValidarRespuesta(int idUsuario, int idPregunta, string respuestaEnTextoPlano)
        {
            if (string.IsNullOrWhiteSpace(respuestaEnTextoPlano))
            {
                return false;
            }
            string hashCorrecto = _preguntasDatos.ObtenerHashRespuestaGuardada(idUsuario, idPregunta);

            if (hashCorrecto == null)
            {
                return false;
            }

            string hashRespuestaIntento = cls_SeguridadPass.GenerarHashSHA256(respuestaEnTextoPlano.Trim().ToLower());

            return hashRespuestaIntento.Equals(hashCorrecto, StringComparison.OrdinalIgnoreCase);
        }


        public cls_PreguntaDTO ObtenerPreguntaRandomParaUsuario(int idUsuario)
        {
            var preguntasConfiguradas = _preguntasDatos.ObtenerPreguntasConfiguradasPorUsuario(idUsuario);

            if (preguntasConfiguradas == null || preguntasConfiguradas.Count == 0)
            {
                throw new Exception("Este usuario no tiene preguntas de seguridad configuradas.");
            }

            var random = new Random();
            int indiceAleatorio = random.Next(0, preguntasConfiguradas.Count);

            return preguntasConfiguradas[indiceAleatorio];
        }
    }


}
