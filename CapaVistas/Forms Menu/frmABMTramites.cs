using CapaDTO;
using CapaLogica.CapaLogica.Tramites;
using CapaSesion.Login;
using CapaUtilidades; // Para cls_LlenarCombos
using System;
using System.Drawing;
using System.Linq; // Para FirstOrDefault
using System.Windows.Forms;
using System.Runtime.InteropServices; // Para arrastrar

namespace CapaVistas.Forms_Menu
{
    public partial class frmABMTramites : Form
    {
        // --- Variables ---
        private readonly int _idPaciente;
        private readonly string _nombrePaciente;
        private readonly cls_TramitesLogica _logica = new cls_TramitesLogica();

        // --- Arrastrar Formulario ---
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        // --- Constructor ---
        public frmABMTramites(int idPaciente, string nombrePaciente)
        {
            InitializeComponent();
            _idPaciente = idPaciente;
            _nombrePaciente = nombrePaciente;
        }

        private void frmNuevoTramite_Load(object sender, EventArgs e)
        {
            lblPacienteNombre.Text = $"Para: {_nombrePaciente}";
            dateCreacion.Value = DateTime.Now;
            dateCreacion.Enabled = false; // El usuario no debe cambiarla

            // --- Lógica REAL ---
            // Cargar el combo de Estados (Abierto, Cerrado, etc.)
            try
            {
                // 1. Llama a la lógica para traer los estados maestros
                var estados = _logica.ObtenerEstadosPosibles();

                // 2. Carga el combo usando tu helper
                cls_LlenarCombos.Cargar(cmbEstado, estados, "estado_descripcion", "id_estado_tramite");

                // 3. Pre-seleccionar "Abierto" si existe
                var itemAbierto = estados.FirstOrDefault(i => i.estado_descripcion.ToLower() == "abierto");
                if (itemAbierto != null)
                {
                    cmbEstado.SelectedValue = itemAbierto.id_estado_tramite;
                }
                else if (cmbEstado.Items.Count > 0)
                {
                    cmbEstado.SelectedIndex = 0; // Selecciona el primero si no encuentra "Abierto"
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar estados: {ex.Message}", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close(); // Cierra el popup si no puede cargar los estados
            }
        }

        // --- LÓGICA DE GUARDADO ---
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // 1. Validaciones
            if (string.IsNullOrWhiteSpace(txtTituloTramite.Text))
            {
                MessageBox.Show("Debe ingresar un título para el trámite.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbEstado.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un estado inicial.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. Creamos el DTO con los datos del formulario
                var nuevoTramite = new cls_TramiteCreacionDTO
                {
                    id_paciente = _idPaciente,
                    titulo_inicial = txtTituloTramite.Text.Trim(),
                    id_estado_actual = (int)cmbEstado.SelectedValue,
                    id_usuario_creador = SesionUsuario.Instancia.IdUsuario
                };

                // 3. Llamamos a la lógica transaccional
                if (_logica.CrearNuevoTramite(nuevoTramite))
                {
                    MessageBox.Show("Trámite creado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; // 4. Avisamos al formulario padre
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo crear el trámite (Transacción revertida).", "Error de Guardado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- Controles de la Ventana (Sin cambios) ---
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frm_MouseDown(object sender, MouseEventArgs e) { dragging = true; dragCursorPoint = Cursor.Position; dragFormPoint = this.Location; }
        private void frm_MouseMove(object sender, MouseEventArgs e) { if (dragging) { Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint)); this.Location = Point.Add(dragFormPoint, new Size(diff)); } }
        private void frm_MouseUp(object sender, MouseEventArgs e) { dragging = false; }
    }
}