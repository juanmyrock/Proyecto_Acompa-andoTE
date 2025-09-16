using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapaVistas.Forms_Menu // O tu namespace
{
    public partial class frmGestionReportes : Form
    {
        // Variables para poder arrastrar el formulario
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public frmGestionReportes()
        {
            InitializeComponent();
        }

        // --- LÓGICA PARA ARRASTRAR Y CERRAR EL FORMULARIO ---
        private void panelTopBar_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void panelTopBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private void panelTopBar_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // --- LÓGICA DE LA APLICACIÓN ---

        private void cmbTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seleccion = cmbTipoReporte.SelectedItem.ToString();

            // Ocultamos todos los paneles de filtros
            pnlFiltroPaciente.Visible = false;
            pnlFiltroFecha.Visible = false;

            // Limpiamos la grilla
            dgvReporte.DataSource = null;
            dgvReporte.Rows.Clear();
            dgvReporte.Columns.Clear();

            // Mostramos el panel de filtros correspondiente a la selección
            switch (seleccion)
            {
                case "Log de Auditoría":
                    pnlFiltroFecha.Visible = true;
                    break;
                case "Informes por Paciente":
                case "Trámites por Paciente":
                case "Pagos por Paciente":
                    pnlFiltroPaciente.Visible = true;
                    break;
            }
            lblTituloReporte.Text = $"Visor de Reportes: {seleccion}";
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            if (cmbTipoReporte.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un tipo de reporte.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string reporte = cmbTipoReporte.SelectedItem.ToString();

            switch (reporte)
            {
                case "Log de Auditoría":
                    GenerarReporteAuditLog();
                    break;
                case "Informes por Paciente":
                    GenerarReporteInformesPaciente();
                    break;
                case "Trámites por Paciente":
                    GenerarReporteTramitesPaciente();
                    break;
                case "Pagos por Paciente":
                    GenerarReportePagosPaciente();
                    break;
            }
        }

        // --- MÉTODOS DE GENERACIÓN DE REPORTES (CON DATOS DE SIMULACIÓN) ---

        private void GenerarReporteAuditLog()
        {
            // AQUÍ: Consultarías tu tabla de auditoría en la DB filtrando por fecha
            dgvReporte.Columns.Clear();
            dgvReporte.Rows.Clear();

            // Definimos las columnas para este reporte
            dgvReporte.Columns.Add("colFecha", "Fecha y Hora");
            dgvReporte.Columns.Add("colUsuario", "Usuario");
            dgvReporte.Columns.Add("colAccion", "Acción");
            dgvReporte.Columns.Add("colDetalle", "Detalle");

            // Agregamos filas de ejemplo
            dgvReporte.Rows.Add("14/09/2025 10:05:12", "admin", "INICIO DE SESIÓN", "Inicio de sesión exitoso.");
            dgvReporte.Rows.Add("14/09/2025 10:06:45", "admin", "ALTA DE TURNO", "Se asignó turno al paciente DNI 12345678.");
            dgvReporte.Rows.Add("14/09/2025 10:08:21", "recepcion", "MODIFICACIÓN TRÁMITE", "Cambio de estado del trámite TR-2025-00123.");
        }

        private void GenerarReporteInformesPaciente()
        {
            // AQUÍ: Buscarías los informes médicos del paciente en la DB
            dgvReporte.Columns.Clear();
            dgvReporte.Rows.Clear();

            dgvReporte.Columns.Add("colFecha", "Fecha");
            dgvReporte.Columns.Add("colProfesional", "Profesional");
            dgvReporte.Columns.Add("colEspecialidad", "Especialidad");
            dgvReporte.Columns.Add("colInforme", "Resumen del Informe");

            dgvReporte.Rows.Add("10/08/2025", "Dr. Favaloro", "Cardiología", "Paciente presenta buena evolución post-operatoria...");
            dgvReporte.Rows.Add("05/09/2025", "Dra. García", "Clínica Médica", "Se solicitan estudios de laboratorio de rutina.");
        }

        private void GenerarReporteTramitesPaciente()
        {
            dgvReporte.Columns.Clear();
            dgvReporte.Rows.Clear();

            dgvReporte.Columns.Add("colID", "ID Trámite");
            dgvReporte.Columns.Add("colInicio", "Fecha Inicio");
            dgvReporte.Columns.Add("colTipo", "Tipo");
            dgvReporte.Columns.Add("colEstado", "Estado Actual");

            dgvReporte.Rows.Add("TR-2025-00123", "30/08/2025", "Cardiología", "Autorizacion O.S pendiente");
            dgvReporte.Rows.Add("TR-2025-00250", "10/09/2025", "Dermatología", "Pendiente a profesional");
        }

        private void GenerarReportePagosPaciente()
        {
            dgvReporte.Columns.Clear();
            dgvReporte.Rows.Clear();

            dgvReporte.Columns.Add("colFecha", "Fecha de Pago");
            dgvReporte.Columns.Add("colConcepto", "Concepto");
            dgvReporte.Columns.Add("colMonto", "Monto");
            dgvReporte.Columns.Add("colEstado", "Estado");

            dgvReporte.Rows.Add("01/08/2025", "Consulta Cardiología", "$ 15,000.00", "Pagado");
            dgvReporte.Rows.Add("01/09/2025", "Práctica Dermatológica", "$ 25,000.00", "Pagado");
            dgvReporte.Rows.Add("01/10/2025", "Consulta Clínica", "$ 12,500.00", "Pendiente");
        }

        // --- Lógica para botones de exportación (placeholders) ---
        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad para exportar a PDF no implementada.", "En desarrollo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad para imprimir no implementada.", "En desarrollo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}