using CapaDTO.SistemaDTO;
using CapaLogica.Negocio;
using CapaLogica.SistemaLogica;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Threading.Tasks;

namespace CapaVistas.Forms_Menu // O tu namespace
{
    public partial class frmGestionReportes : Form
    {
        // Variables para poder arrastrar el formulario
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private string guidArchivo = string.Empty;
        private int _idAcompanamientoActual;
        cls_LogicaGestionarPacientes _logicaPaciente = new cls_LogicaGestionarPacientes();
        cls_LogicaInformes gestor;

        public frmGestionReportes()
        {
            InitializeComponent();
            string clave = "MiClave123";
            gestor = new cls_LogicaInformes(clave);
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
            pnlFiltroPaciente.Visible = false;
            pnlFiltroFecha.Visible = false;
            lblFechaDesde.Visible = false;
            lblFechaHasta.Visible = false;

            string seleccion = cmbTipoReporte.SelectedItem.ToString();
            try
            {
                if (cmbTipoReporte.Text == "Informes por Paciente")
                {
                    dtpMesInforme.Visible = true;
                    btnGenerarReporte.Visible = false;
                    pnlFiltroFecha.Visible = true;
                    pnlFiltroPaciente.Visible = true;
                    dateDesde.Visible = false;
                    dateHasta.Visible = false;
                    btnGenerarReporte.Visible=false;


                }
                else if (cmbTipoReporte.Text == "Log de Auditoría")
                {
                    pnlFiltroFecha.Visible = true;
                    lblFechaDesde.Visible = true;
                    lblFechaHasta.Visible = true;
                    dateDesde.Visible = true;
                    dateHasta.Visible = true;
                    dtpMesInforme.Visible = false;
                    
                }
                else if (cmbTipoReporte.Text == "Trámites por Paciente")
                {
                    pnlFiltroFecha.Visible = true;
                    lblFechaDesde.Visible = true;
                    lblFechaHasta.Visible = true;
                    pnlFiltroPaciente.Visible=true;
                    dateDesde.Visible = true;
                    dateHasta.Visible = true;
                    dtpMesInforme.Visible = false;
                    btnGenerarReporte.Visible = true;
                }
                else
                {
                    pnlFiltroPaciente.Visible = true;
                    btnGenerarReporte.Visible = true;
                }
            }
            catch (Exception)
            {

            }

            dgvReporte.DataSource = null;
            dgvReporte.Rows.Clear();
            dgvReporte.Columns.Clear();
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
            if(cmbTipoReporte.Text == "Informes por Paciente")
            {
                if (txtInforme.Text.Length == 0 || txtBuscarPaciente.Text.Length < 8)
                {
                    MessageBox.Show("No se puede generar un PDF de un informe vacío o sin un documento valido escrito.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (txtInforme.Text.Length > 0 && txtBuscarPaciente.Text.Length == 8)
                {

                    try
                    {
                        string titulo = "Informe Mensual";
                        string contenido = //$"Paciente: {lblApeNom.Text}\n" +
                                           // $"DNI: {txtBusquedaPaciente.Text}\n" +
                                           // $"Fecha: {dtpMesInforme.Value.ToString("dd/MM/yyyy")}\n\n" +
                                           // $"Prestador: {lblPrestadorEscrito.Text} \n" + 
                                           //$"Prestación: {lblPrestacionEscrita.Text} \n" + 
                                           //$"Diagnostico inicial: {lblDiagnosticoEscrito.Text}\n\n" +
                                          $"{txtInforme.Text}";

                        string contenidoAdicional = "Firmado por: VicularAzul S.R.L.";

                        string rutaPDF = CapaUtilidades.cls_CrearPDF.GenerarPDFConNumeracion(
                            titulo, contenido, contenidoAdicional);

                        MessageBox.Show($"PDF generado: {System.IO.Path.GetFileName(rutaPDF)}", "Éxito",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad para imprimir no implementada.", "En desarrollo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            if (cmbTipoReporte.Text == "Informes por Paciente")
            {
                dateDesde.Visible = false;
                dateHasta.Visible = false;
                if (!int.TryParse(txtBuscarPaciente.Text, out int dniBuscado))
                {
                    MessageBox.Show("Por favor, ingrese un número de DNI válido.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBuscarPaciente.Clear();
                    return;
                }
                
                // Validar que se seleccionó un mes
                if (dtpMesInforme.Value == null)
                {
                    MessageBox.Show("Por favor, seleccione un mes para el informe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    dgvReporte.Visible = false;
                    txtInforme.Visible = true;
                    
                    // Obtener el mes y año seleccionados
                    DateTime mesSeleccionado = dtpMesInforme.Value;
                    int mes = mesSeleccionado.Month;
                    int año = mesSeleccionado.Year;

                    List<cls_InformeATDTO> informesEncontrados = gestor.ObtenerInformesPorDni(dniBuscado);

                    Console.WriteLine($"DEBUG FORM - Cantidad de informes: {informesEncontrados?.Count ?? -1}");
                    Console.WriteLine($"DEBUG FORM - Mes seleccionado: {mes}/{año}");

                    if (informesEncontrados != null && informesEncontrados.Count > 0)
                    {
                        Console.WriteLine($"DEBUG FORM - Primer paciente: {informesEncontrados[0].nombre_paciente}");
                    }

                    if (informesEncontrados != null && informesEncontrados.Count > 0)
                    {
                        cls_InformeATDTO pacienteEncontrado = informesEncontrados[0];
                        cls_PacienteDTO paciente = _logicaPaciente.BuscarPacientePorDni(dniBuscado);
                        List<cls_PacienteDTO> resultado = new List<cls_PacienteDTO> { paciente };
                        DateTime fechaactual = DateTime.Today;
                        DateTime? cumple = paciente.fecha_nac;

                        // Guardar el id_acompanamiento
                        _idAcompanamientoActual = pacienteEncontrado.id_acompanamiento;

                        // BUSCAR INFORMES EXISTENTES EN EL MES SELECCIONADO
                        var informesDelMes = informesEncontrados.Where(i =>
                            !string.IsNullOrEmpty(i.id_informe_at) &&
                            i.fecha_periodo.Month == mes &&
                            i.fecha_periodo.Year == año
                        ).ToList();

                        Console.WriteLine($"DEBUG - Informes del mes {mes}/{año}: {informesDelMes.Count}");

                        if (informesDelMes.Count > 0)
                        {
                            // Hay informe en el mes seleccionado - Cargar para ACTUALIZAR
                            var informeDelMes = informesDelMes[0];

                            // Guardar el GUID del informe existente
                            guidArchivo = informeDelMes.id_informe_at;
                            Console.WriteLine($"DEBUG - GUID cargado: {guidArchivo}");

                            if (!string.IsNullOrEmpty(informeDelMes.ruta))
                            {
                                txtInforme.Text = gestor.CargarOCrearArchivo(informeDelMes.ruta);
                            }

                            // Mostrar solo botón Actualizar


                            MessageBox.Show($"Se encontró un informe para {mesSeleccionado:MMMM yyyy}.", "Informe Existente",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            // No hay informe en el mes seleccionado - Preparar para NUEVO informe
                            txtInforme.Clear();
                            guidArchivo = string.Empty; // Limpiar GUID para nuevo informe
                            Console.WriteLine($"DEBUG - No hay informes para {mesSeleccionado:MMMM yyyy}, GUID limpiado");


                            MessageBox.Show($"No hay informe para {mesSeleccionado:MMMM yyyy}.", "Falta Informe",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"No se encontró ningún paciente con DNI: {dniBuscado}.", "No Encontrado",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar el paciente: " + ex.Message, "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtBuscarPaciente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnBuscarPaciente.PerformClick();
        }
    }
}