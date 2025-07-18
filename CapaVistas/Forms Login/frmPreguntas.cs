﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CapaLogica;
using CapaDTO;
using CapaUtilidades;
using CapaLogica.Login;

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

        // Variable para el Modo Recuperación (RESPONDER)
        private cls_PreguntaDTO _preguntaParaResponder;

        public frmPreguntas(int idUsuario, string modo)
        {
            InitializeComponent();
            _idUsuario = idUsuario;
            _modo = modo;

            this.Load += new System.EventHandler(this.frmPreguntas_Load);
        }

        private void frmPreguntas_Load(object sender, EventArgs e)
        {
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
                InicializarModoResponder();
            }
        }

        #region MODO CONFIGURACION
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
        #endregion 

        #region MODO RESPONDER
        private void InicializarModoResponder()
        {
            this.Text = "Responder Pregunta de Seguridad";
            lblLogin.Text = "Verificación de Seguridad";
            cmbPregunta.Visible = false;

            try
            {
                var logica = new cls_LogicaPreguntas();
                _preguntaParaResponder = logica.ObtenerPreguntaRandomParaUsuario(_idUsuario);

                lblPregunta.Text = _preguntaParaResponder.TextoPregunta;
                lblRespuesta.Text = "Escriba su respuesta:";
                btnAceptar.Text = "VERIFICAR";
            }
            catch (Exception ex)
            {
                MsgError(ex.Message);
                btnAceptar.Enabled = false;
            }
        }
        #endregion



        private void btnAceptar_Click(object sender, EventArgs e)
        {
            lblErrorMsg.Visible = false;

            if (_modo == "CONFIGURAR")
            {
                if (cmbPregunta.SelectedValue == null || string.IsNullOrWhiteSpace(txtRespuesta.Text))
                {
                    MsgError("Debe seleccionar una pregunta y escribir una respuesta.");
                    return;
                }
                int idPregunta = (int)cmbPregunta.SelectedValue;
                _respuestasTemporales[idPregunta] = txtRespuesta.Text;

                if (_preguntaActualNro < _preguntasRequeridas)
                {
                    _preguntaActualNro++;
                    CargarSiguientePregunta();
                }
                else
                {
                    try
                    {
                        var logica = new cls_LogicaPreguntas();
                        logica.GuardarMultiplesRespuestas(_idUsuario, _respuestasTemporales);
                        MessageBox.Show("Preguntas de seguridad configuradas con éxito.", "Proceso Completado");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception ex) { MsgError("Error al guardar: " + ex.Message); }
                }
            }
            else if (_modo == "RESPONDER")
            {
                if (string.IsNullOrWhiteSpace(txtRespuesta.Text))
                {
                    MsgError("Debe ingresar una respuesta.");
                    return;
                }

                try
                {
                    var logicaPreguntas = new cls_LogicaPreguntas();
                    bool esCorrecta = logicaPreguntas.ValidarRespuesta(_idUsuario, _preguntaParaResponder.IdPregunta, txtRespuesta.Text);

                    if (esCorrecta)
                    {
                        // ¡Respuesta correcta! Ahora orquestamos el envío del email.
                        var logicaLogin = new cls_LogicaLogin();
                        var logicaContraseña = new cls_LogicaContraseña();

                        // Obtenemos los datos del usuario para el email
                        cls_UsuarioDTO usuario = logicaLogin.ObtenerDatosParaRecuperacionPorId(_idUsuario); // Necesitarás añadir este método

                        // Llamamos al método que genera, guarda y envía la contraseña temporal
                        logicaContraseña.GenerarYEnviarContraseñaTemporal(usuario.IdUsuario, usuario.Email, usuario.Username); // Necesitarás el email en tu DTO

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MsgError("La respuesta proporcionada es incorrecta.");
                    }
                }
                catch (Exception ex)
                {
                    MsgError("Ocurrió un error en el proceso: " + ex.Message);
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
