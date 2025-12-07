using CapaDTO;
using CapaLogica.CapaLogica.Tramites;
using CapaSesion.Login;
using CapaUtilidades;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CapaVistas.Forms_Menu
{
    public partial class frmABMTramites : Form
    {
        private readonly int _idPaciente;
        private readonly string _nombrePaciente;
        private readonly cls_TramitesLogica _logica = new cls_TramitesLogica();

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

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
            dateCreacion.Enabled = false;
            try
            {
                var estados = _logica.ObtenerEstadosPosibles();

                cls_LlenarCombos.Cargar(cmbEstado, estados, "estado_descripcion", "id_estado_tramite");

                var itemAbierto = estados.FirstOrDefault(i => i.estado_descripcion.ToLower() == "abierto");
                if (itemAbierto != null)
                {
                    cmbEstado.SelectedValue = itemAbierto.id_estado_tramite;
                }
                else if (cmbEstado.Items.Count > 0)
                {
                    cmbEstado.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar estados: {ex.Message}", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
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
                var nuevoTramite = new cls_TramiteCreacionDTO
                {
                    id_paciente = _idPaciente,
                    titulo_inicial = txtTituloTramite.Text.Trim(),
                    id_estado_actual = (int)cmbEstado.SelectedValue,
                    id_usuario_creador = SesionUsuario.Instancia.IdUsuario
                };

                if (_logica.CrearNuevoTramite(nuevoTramite))
                {
                    MessageBox.Show("Trámite creado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
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