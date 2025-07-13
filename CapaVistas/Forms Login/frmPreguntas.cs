using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CapaLogica;
using CapaDTO;
using CapaUtilidades;

namespace CapaVistas.Forms_Login
{
    public partial class frmPreguntas : Form
    {
        private readonly int _idUsuario;
        private readonly string _modo;
        private int _preguntasRequeridas;
        private int _preguntaActualNro = 1;

        // Lista maestra de preguntas desde la BD
        private List<cls_PreguntaDTO> _listaMaestraPreguntas;

        // Diccionario para guardar temporalmente las respuestas del usuario
        private Dictionary<int, string> _respuestasTemporales = new Dictionary<int, string>();

        public frmPreguntas(int idUsuario, string modo)
        {
            InitializeComponent();
            _idUsuario = idUsuario;
            _modo = modo;

            // Ocultamos el mensaje de error al inicio
            lblErrorMsg.Visible = false;
            picError.Visible = false;

            // Adaptamos la UI según el modo de operación
            if (_modo == "CONFIGURAR")
            {
                InicializarModoConfigurar();
            }
            else if (_modo == "RESPONDER")
            {
                // La lógica para este modo se implementará más adelante
                this.Text = "Responder Pregunta de Seguridad";
                // ...
            }
        }

        private void InicializarModoConfigurar()
        {
            lblLogin.Text = "Configurar Preguntas de Seguridad";
            var logica = new cls_LogicaPreguntas();

            try
            {
                // Obtenemos la configuración una sola vez
                _preguntasRequeridas = logica.ObtenerCantidadPreguntasRequeridas();
                _listaMaestraPreguntas = logica.ObtenerPreguntasDisponibles();

                // Preparamos la UI para la primera pregunta
                CargarSiguientePregunta();
            }
            catch (Exception ex)
            {
                MsgError("Error al inicializar: " + ex.Message);
                btnAceptar.Enabled = false;
            }
        }

        // Actualiza la UI para mostrar la pregunta actual.
        private void CargarSiguientePregunta()
        {
            // Actualizamos el título y las etiquetas para guiar al usuario
            lblLogin.Text = $"Pregunta {_preguntaActualNro} de {_preguntasRequeridas}";
            lblPregunta.Text = "Seleccione una pregunta:";
            lblRespuesta.Text = "Escriba su respuesta:";

            // Filtramos la lista maestra, quitando las preguntas que ya fueron seleccionadas
            var preguntasParaMostrar = _listaMaestraPreguntas
                .Where(p => !_respuestasTemporales.ContainsKey(p.IdPregunta))
                .ToList();

            // cargar el ComboBox con las preguntas restantes
            cls_LlenarCombos.Cargar(cmbPregunta, preguntasParaMostrar, "TextoPregunta", "IdPregunta");

            // Limpiamos la respuesta anterior
            txtRespuesta.Clear();
            txtRespuesta.Focus();

            // Cambiamos el texto del botón si es la última pregunta
            if (_preguntaActualNro == _preguntasRequeridas)
            {
                btnAceptar.Text = "FINALIZAR";
            }
            else
            {
                btnAceptar.Text = "SIGUIENTE";
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (_modo != "CONFIGURAR") return;

            // 1. Validar la entrada actual
            if (cmbPregunta.SelectedValue == null || string.IsNullOrWhiteSpace(txtRespuesta.Text))
            {
                MsgError("Debe seleccionar una pregunta y escribir una respuesta.");
                return;
            }

            // 2. Guardar la respuesta actual en la memoria temporal
            int idPregunta = (int)cmbPregunta.SelectedValue;
            string respuesta = txtRespuesta.Text;
            _respuestasTemporales[idPregunta] = respuesta;

            // 3. Comprobar si hemos terminado
            if (_preguntaActualNro < _preguntasRequeridas)
            {
                // Si no hemos terminado, pasamos a la siguiente pregunta
                _preguntaActualNro++;
                CargarSiguientePregunta();
            }
            else
            {
                // Si era la última pregunta, guardamos todo en la BD
                try
                {
                    var logica = new cls_LogicaPreguntas();
                    logica.GuardarMultiplesRespuestas(_idUsuario, _respuestasTemporales);

                    MessageBox.Show("Preguntas de seguridad configuradas con éxito.", "Proceso Completado");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MsgError("Error al guardar las preguntas: " + ex.Message);
                }
            }
        }

        // --- Métodos de UI y Navegación ---
        private void MsgError(string msg)
        {
            lblErrorMsg.Visible = true;
            picError.Visible = true;
            lblErrorMsg.Text = "      " + msg;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
