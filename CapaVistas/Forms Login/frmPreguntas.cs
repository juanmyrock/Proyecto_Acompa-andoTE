using System;
using System.Windows.Forms;
using CapaLogica;

namespace CapaVistas.Forms_Login
{
    public partial class frmPreguntas : Form
    {
        private readonly int _idUsuario;
        private readonly string _modo; // "CONFIGURAR" o "RESPONDER"

        // El constructor ahora recibe el ID del usuario y el modo de operación.
        public frmPreguntas(int idUsuario, string modo)
        {
            InitializeComponent();
            _idUsuario = idUsuario;
            _modo = modo;
        }

        private void frmPreguntas_Load(object sender, EventArgs e)
        {
            // Adaptar la UI según el modo
            if (_modo == "CONFIGURAR")
            {
                this.Text = "Configurar Preguntas de Seguridad";
                // TODO: Implementar la lógica para mostrar N controles para
                // que el usuario seleccione sus preguntas y escriba las respuestas.
                // Por ejemplo, hacer visibles varios paneles.
                lblPregunta1.Text = "Pregunta 1 a configurar:";
                // lblPregunta2.Visible = true;
                // txtRespuesta2.Visible = true;
            }
            else if (_modo == "RESPONDER")
            {
                this.Text = "Responder Pregunta de Seguridad";
                // TODO: Obtener una pregunta al azar de la BD para este usuario
                // y mostrarla en lblPregunta1. Ocultar los otros controles.
                // Ejemplo: var pregunta = new cls_LogicaLogin().ObtenerPreguntaRandom(_idUsuario);
                // lblPregunta1.Text = pregunta.TextoPregunta;
                lblPregunta1.Text = "¿Cuál era el nombre de su primera mascota?"; // Texto de ejemplo

                // Ocultar controles que no se usan en este modo
                // if(lblPregunta2 != null) lblPregunta2.Visible = false;
                // if(txtRespuesta2 != null) txtRespuesta2.Visible = false;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e) // Asumo que el botón principal se llama así
        {
            var logica = new cls_LogicaLogin();

            if (_modo == "CONFIGURAR")
            {
                // TODO: Implementar lógica para guardar las preguntas y respuestas.
                // Deberás recolectar los datos de tus ComboBox y TextBox.
                // logica.GuardarPreguntasDeSeguridad(_idUsuario, listaDePreguntasYRespuestas);
                MessageBox.Show("Preguntas configuradas con éxito.", "Éxito");
            }
            else if (_modo == "RESPONDER")
            {
                // TODO: Necesitas el ID de la pregunta que se mostró al usuario.
                int idPreguntaMostrada = 1; // Ejemplo

                // Validar la respuesta
                bool esCorrecta = logica.ValidarRespuestaDeSeguridad(_idUsuario, idPreguntaMostrada, txtRespuesta.Text);

                if (!esCorrecta)
                {
                    MessageBox.Show("La respuesta proporcionada es incorrecta.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // No continúa
                }
            }

            // Si la operación fue exitosa, establece el DialogResult en OK y cierra.
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // --- Navegación ---
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
