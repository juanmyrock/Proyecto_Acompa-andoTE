using System;
using System.Collections.Generic;
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

        // El constructor tiene la lógica de inicialización.
        public frmPreguntas(int idUsuario, string modo)
        {
            InitializeComponent();
            _idUsuario = idUsuario;
            _modo = modo;

            // --- CAMBIO CLAVE: La lógica del evento Load se mueve aquí ---

            // Ocultamos el mensaje de error al inicio
            lblErrorMsg.Visible = false;
            picError.Visible = false;

            // Adaptamos la UI según el modo de operación
            if (_modo == "CONFIGURAR")
            {
                this.Text = "Configurar Pregunta de Seguridad";
                lblLogin.Text = "Configurar Pregunta";
                lblPregunta1.Text = "Seleccione una pregunta:";
                lblPregunta2.Text = "Escriba su respuesta:";

                cmbPregunta.Visible = true;
                CargarPreguntasDisponibles(); // Llamamos al método que carga el ComboBox
            }
            else if (_modo == "RESPONDER")
            {
                this.Text = "Responder Pregunta de Seguridad";
                lblLogin.Text = "Verificación de Seguridad";
                cmbPregunta.Visible = false;

                // TODO: Implementar la lógica para obtener una pregunta al azar
                lblPregunta1.Text = "¿Cuál era el nombre de su primera mascota?"; // Ejemplo
                lblPregunta2.Text = "Escriba su respuesta:";
            }
        }

        // Llama a la capa de lógica para obtener las preguntas disponibles
        // y usa el helper para cargar el ComboBox.
        private void CargarPreguntasDisponibles()
        {
            try
            {
                var logica = new cls_LogicaPreguntas();
                List<cls_PreguntaDTO> preguntas = logica.ObtenerPreguntasDisponibles();

                // --- LÍNEA DE DEPURACIÓN TEMPORAL ---
                // Esta línea nos dirá exactamente cuántas preguntas está recibiendo el formulario.
                MessageBox.Show($"Se encontraron {preguntas.Count} preguntas en la base de datos.");

                cls_LlenarCombos.Cargar(cmbPregunta, preguntas, "TextoPregunta", "IdPregunta");
            }
            catch (Exception ex)
            {
                MsgError("Error al cargar las preguntas: " + ex.Message);
                cmbPregunta.Enabled = false;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            lblErrorMsg.Visible = false;

            if (_modo == "CONFIGURAR")
            {
                if (cmbPregunta.SelectedValue == null)
                {
                    MsgError("Debe seleccionar una pregunta de la lista.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtRespuesta.Text))
                {
                    MsgError("La respuesta no puede estar vacía.");
                    return;
                }

                try
                {
                    int idPreguntaSeleccionada = Convert.ToInt32(cmbPregunta.SelectedValue);
                    string respuestaUsuario = txtRespuesta.Text;

                    var logica = new cls_LogicaPreguntas();
                    logica.GuardarRespuestaDeSeguridad(_idUsuario, idPreguntaSeleccionada, respuestaUsuario);

                    MessageBox.Show("Pregunta de seguridad configurada con éxito.", "Proceso Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MsgError("Ocurrió un error al guardar: " + ex.Message);
                }
            }
            // ... (la lógica para el modo RESPONDER se mantiene igual)
        }

        // --- Métodos de UI y Navegación (sin cambios) ---
        private void MsgError(string msg)
        {
            lblErrorMsg.Text = "      " + msg;
            lblErrorMsg.Visible = true;
            picError.Visible = true;
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
