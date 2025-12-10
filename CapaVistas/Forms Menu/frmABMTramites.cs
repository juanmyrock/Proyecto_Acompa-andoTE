using CapaDTO;
using CapaLogica.CapaLogica.Tramites;
using CapaSesion.Login;
using CapaUtilidades;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CapaVistas.Forms_Menu
{
    public partial class frmABMTramites : Form
    {
        // --- Variables ---
        private readonly cls_TramitesLogica _logica = new cls_TramitesLogica();

        // Variables de Estado
        private int _idPaciente = 0;       // Se usa solo al CREAR
        private string _nombrePaciente;    // Se usa solo al CREAR
        private int _idTramiteEdicion = 0; // 0 = MODO CREACIÓN, > 0 = MODO EDICIÓN

        // --- CONSTRUCTOR 1: Para CREAR NUEVO (Recibe Paciente) ---
        // Este lo usa el botón "Nuevo Trámite"
        public frmABMTramites(int idPaciente, string nombrePaciente)
        {
            InitializeComponent();
            _idPaciente = idPaciente;
            _nombrePaciente = nombrePaciente;
            _idTramiteEdicion = 0; // Bandera en 0 -> Vamos a CREAR
        }

        // --- CONSTRUCTOR 2: Para EDITAR (Recibe ID Trámite) ---
        // Este lo usa el Doble Click en la lista (¡ESTE ES EL QUE TE FALTABA!)
        public frmABMTramites(int idTramiteAEditar)
        {
            InitializeComponent();
            _idTramiteEdicion = idTramiteAEditar; // Bandera > 0 -> Vamos a EDITAR
            _idPaciente = 0; // No lo necesitamos, ya está en la BD
        }

        private void frmNuevoTramite_Load(object sender, EventArgs e)
        {
            dateCreacion.Enabled = false;

            try
            {
                // 1. Cargar Combo Estados
                var estados = _logica.ObtenerEstadosPosibles();
                cls_LlenarCombos.Cargar(cmbEstado, estados, "estado_descripcion", "id_estado_tramite");

                // 2. DECIDIR EL MODO
                if (_idTramiteEdicion == 0)
                {
                    // === MODO CREACIÓN ===
                    lblTituloForm.Text = "Crear Nuevo Trámite";
                    btnGuardar.Text = "Guardar Trámite";
                    lblPacienteNombre.Text = $"Para: {_nombrePaciente}";
                    dateCreacion.Value = DateTime.Now;

                    // Pre-seleccionar "Abierto"
                    var itemAbierto = estados.FirstOrDefault(i => i.estado_descripcion.ToLower() == "abierto");
                    if (itemAbierto != null) cmbEstado.SelectedValue = itemAbierto.id_estado_tramite;
                }
                else
                {
                    // === MODO EDICIÓN ===
                    lblTituloForm.Text = "Modificar Trámite";
                    btnGuardar.Text = "Guardar Cambios";

                    // Llamamos a la lógica para traer los datos de este trámite
                    var datos = _logica.ObtenerTramitePorId(_idTramiteEdicion);

                    if (datos != null)
                    {
                        txtTituloTramite.Text = datos.titulo_inicial;
                        cmbEstado.SelectedValue = datos.id_estado_actual;
                        lblPacienteNombre.Text = "Editando trámite existente";
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el trámite.", "Error");
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTituloTramite.Text) || cmbEstado.SelectedValue == null)
            {
                MessageBox.Show("Complete Título y Estado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool resultado = false;

                if (_idTramiteEdicion == 0)
                {
                    // --- CAMINO A: INSERTAR ---
                    var nuevoTramite = new cls_TramiteCreacionDTO
                    {
                        id_paciente = _idPaciente,
                        titulo_inicial = txtTituloTramite.Text.Trim(),
                        id_estado_actual = (int)cmbEstado.SelectedValue,
                        id_usuario_creador = SesionUsuario.Instancia.IdUsuario
                    };
                    resultado = _logica.CrearNuevoTramite(nuevoTramite);
                }
                else
                {
                    // --- CAMINO B: ACTUALIZAR ---
                    resultado = _logica.ActualizarTramite(_idTramiteEdicion, txtTituloTramite.Text.Trim(), (int)cmbEstado.SelectedValue);
                }

                if (resultado)
                {
                    string accion = _idTramiteEdicion == 0 ? "creado" : "actualizado";
                    MessageBox.Show($"Trámite {accion} con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; // Esto refresca la lista del padre
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo realizar la operación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error crítico: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- Controles de Ventana ---
        private void btnCancelar_Click(object sender, EventArgs e) { this.DialogResult = DialogResult.Cancel; this.Close(); }
        private void lblClose_Click(object sender, EventArgs e) { this.DialogResult = DialogResult.Cancel; this.Close(); }

        // Arrastre
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private void frm_MouseDown(object sender, MouseEventArgs e) { dragging = true; dragCursorPoint = Cursor.Position; dragFormPoint = this.Location; }
        private void frm_MouseMove(object sender, MouseEventArgs e) { if (dragging) { Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint)); this.Location = Point.Add(dragFormPoint, new Size(diff)); } }
        private void frm_MouseUp(object sender, MouseEventArgs e) { dragging = false; }
    }
}