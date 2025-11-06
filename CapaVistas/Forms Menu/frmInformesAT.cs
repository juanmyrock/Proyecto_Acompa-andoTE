using CapaDTO.SistemaDTO;
using CapaLogica.Negocio;
using CapaLogica.SistemaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVistas.Forms_Menu
{
    public partial class frmInformesAT : Form
    {
        private string rutaArchivoGuardado = @"C:\InformesAT";
        private string guidArchivo = string.Empty;
        private int _idAcompanamientoActual;
        cls_LogicaGestionarPacientes _logicaPaciente = new cls_LogicaGestionarPacientes();
        cls_LogicaInformes gestor;

        public frmInformesAT()
        {
            string clave = "MiClave123";
            InitializeComponent();
            dtpMesInforme.Format = DateTimePickerFormat.Custom;
            dtpMesInforme.CustomFormat = "MMMM yyyy";

            gestor = new cls_LogicaInformes(clave);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtBusquedaPaciente.Text, out int dniBuscado))
            {
                MessageBox.Show("Por favor, ingrese un número de DNI válido.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBusquedaPaciente.Clear();
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
                    // Mostrar datos del paciente
                    if (cumple.HasValue)
                    {
                        int añito = cumple.Value.Year;
                        lblEdadEscrita.Text = $"{fechaactual.Year - añito}";
                    }

                    lblApeNom.Text = $"{pacienteEncontrado.nombre_paciente} {pacienteEncontrado.apellido_paciente}";
                    lblHoras.Text = $"{pacienteEncontrado.cargahoraria_at}";
                    lblFechaDeNacimientoEscrito.Text = $"{paciente.fecha_nac}";
                    lblDiagnosticoEscrito.Text = $"{paciente.diagnostico}";
                    lblPrestadorEscrito.Text = "VincularAzul S.R.L.";
                    lblPrestacionEscrita.Text = "Acompañante Terapeutico/Externo";

                    

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
                        btnGuardarInforme.Visible = false;
                        btnActualizar.Visible = true;
                        txtAcompaniante.Visible = false;
                        lblAcompañante.Visible = false;

                        MessageBox.Show($"Se encontró un informe para {mesSeleccionado:MMMM yyyy}. Puede actualizarlo.", "Informe Existente",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // No hay informe en el mes seleccionado - Preparar para NUEVO informe
                        txtInforme.Clear();
                        guidArchivo = string.Empty; // Limpiar GUID para nuevo informe
                        Console.WriteLine($"DEBUG - No hay informes para {mesSeleccionado:MMMM yyyy}, GUID limpiado");

                        // Mostrar solo botón Guardar
                        btnGuardarInforme.Visible = true;
                        btnActualizar.Visible = false;

                        MessageBox.Show($"No hay informe para {mesSeleccionado:MMMM yyyy}. Puede crear uno nuevo.", "Nuevo Informe",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show($"No se encontró ningún paciente con DNI: {dniBuscado}.", "No Encontrado",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar el paciente: " + ex.Message, "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GuardarInforme()
        {
            try
            {
                // Validar que hay un mes seleccionado
                if (dtpMesInforme.Value == null)
                {
                    MessageBox.Show("Debe seleccionar un mes para el informe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que hay un paciente seleccionado
                if (_idAcompanamientoActual == 0)
                {
                    MessageBox.Show("Debe buscar un paciente primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Generar GUID para nuevo informe
                guidArchivo = Guid.NewGuid().ToString();

                // Construir ruta del archivo
                string ruta = Path.Combine(rutaArchivoGuardado, guidArchivo + ".dat");

                // 1. Guardar archivo físicamente
                gestor.GuardarArchivo(ruta, txtInforme.Text);

                // 2. Crear el DTO con los datos del informe - USAR EL MES SELECCIONADO
                var informe = new cls_InformeATDTO
                {
                    id_informe_at = guidArchivo,
                    id_acompanamiento = _idAcompanamientoActual,
                    fecha_periodo = new DateTime(dtpMesInforme.Value.Year, dtpMesInforme.Value.Month, 1), // Primer día del mes seleccionado
                    id_usuario_creador = 1,
                    fecha_creacion = DateTime.Now,
                    ruta = ruta,
                    dni_paciente = Convert.ToInt32(txtBusquedaPaciente.Text),
                    nombre_paciente = lblApeNom.Text.Split(' ')[0],
                    apellido_paciente = lblApeNom.Text.Split(' ').Length > 1 ? lblApeNom.Text.Split(' ')[1] : "",
                    cargahoraria_at = Convert.ToDecimal(lblHoras.Text)
                };

                // 3. Guardar en la base de datos
                bool guardadoExitoso = gestor.GuardarInforme(informe);

                if (guardadoExitoso)
                {
                    MessageBox.Show($"Informe para {dtpMesInforme.Value:MMMM yyyy} guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el informe en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el informe:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtBusquedaPaciente.Text = string.Empty;
            lblApeNom.Text = "Nombre Paciente: ";
            lblHoras.Text = string.Empty;
            txtInforme.Clear();
            rutaArchivoGuardado = string.Empty;
            guidArchivo = string.Empty;
            txtBusquedaPaciente.Focus();
            lblFechaDeNacimientoEscrito.Text = string.Empty;
            lblDiagnosticoEscrito.Text = string.Empty;
            lblPrestadorEscrito.Text = string.Empty;
            lblPrestacionEscrita.Text = string.Empty ;
            lblHoras.Text = string.Empty;
            lblAcompañante.Visible = true;
            txtAcompaniante.Visible = true;
            btnActualizar.Visible = false;
            btnGuardarInforme.Visible = true;
        }

        private void btnGuardarInforme_Click(object sender, EventArgs e)
        {
            try
            {
                // Construir el encabezado con la información de los controles
                string encabezado = ConstruirEncabezadoInforme();

                // Combinar el encabezado con el contenido actual del informe
                string contenidoCompleto = encabezado + "\n\n" + txtInforme.Text;

                // Asignar el contenido completo al textbox (opcional - si quieres que el usuario lo vea)
                txtInforme.Text = contenidoCompleto;

                // Luego proceder con el guardado normal
                GuardarInforme();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al preparar el informe: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que hay un mes seleccionado
                if (dtpMesInforme.Value == null)
                {
                    MessageBox.Show("Debe seleccionar un mes para el informe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception )
            {
                throw;
            }
                if (!int.TryParse(txtBusquedaPaciente.Text, out int dniBuscado))
            {
                MessageBox.Show("Por favor, ingrese un número de DNI válido.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBusquedaPaciente.Clear();
                return;
            }

            try
            {
                List<cls_InformeATDTO> informesEncontrados = gestor.ObtenerInformesPorDni(dniBuscado);
                // Validar que hay un paciente seleccionado
                if (_idAcompanamientoActual == 0)
                {
                    MessageBox.Show("Debe buscar un paciente primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que hay un GUID de informe existente
                if (string.IsNullOrEmpty(guidArchivo))
                {
                    MessageBox.Show("No hay un informe cargado para actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que hay contenido en el informe
                if (string.IsNullOrWhiteSpace(txtInforme.Text))
                {
                    MessageBox.Show("El informe no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear el DTO con los datos actualizados
                var informe = new cls_InformeATDTO
                {
                    id_informe_at = guidArchivo, // El GUID existente
                    id_acompanamiento = _idAcompanamientoActual,
                    fecha_periodo = DateTime.Now,
                    id_usuario_creador = 1, // O obtener del usuario logueado
                    fecha_creacion = DateTime.Now,
                    ruta = Path.Combine(rutaArchivoGuardado, guidArchivo + ".dat"),
                    dni_paciente = Convert.ToInt32(txtBusquedaPaciente.Text),
                    nombre_paciente = lblApeNom.Text.Split(' ')[0],
                    apellido_paciente = lblApeNom.Text.Split(' ').Length > 1 ? lblApeNom.Text.Split(' ')[1] : "",
                    cargahoraria_at = Convert.ToDecimal(lblHoras.Text)
                };

                // 1. Actualizar archivo físicamente
                gestor.GuardarArchivo(informe.ruta, txtInforme.Text);

                // 2. Actualizar en la base de datos
                bool actualizadoExitoso = gestor.ActualizarInforme(informe);

                if (actualizadoExitoso == true)
                {
                    MessageBox.Show("Informe actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    btnGuardarInforme.Visible = true;
                    btnActualizar.Visible = false;
                    lblAcompañante.Visible = true;
                    txtAcompaniante.Visible = true;
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el informe en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el informe:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private string ConstruirEncabezadoInforme()
        {
            StringBuilder encabezado = new StringBuilder();

            // Agregar información de los controles
            encabezado.AppendLine($"=== INFORME DE ACOMPAÑAMIENTO TERAPÉUTICO ===");
            encabezado.AppendLine($"Fecha: {DateTime.Now:dd/MM/yyyy}");

            if (!string.IsNullOrEmpty(lblApeNom.Text))
                encabezado.AppendLine($"Paciente: {lblApeNom.Text}");

            if (!string.IsNullOrEmpty(lblHoras.Text))
                encabezado.AppendLine($"Carga horaria: {lblHoras.Text} horas");
            // Agregar más controles si necesitas
            if (!string.IsNullOrEmpty(lblPrestadorEscrito.Text))
                encabezado.AppendLine($"Prestador: {lblPrestadorEscrito.Text}");

            if (!string.IsNullOrEmpty(lblPrestacionEscrita.Text))
                encabezado.AppendLine($"Prestación: {lblPrestacionEscrita.Text}");

            if (!string.IsNullOrEmpty(txtAcompaniante.Text))
                encabezado.AppendLine($"Acompañante: {txtAcompaniante.Text}");

            encabezado.AppendLine("".PadRight(50, '=')); // Línea separadora

            return encabezado.ToString();
        }

        private void txtBusquedaPaciente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
