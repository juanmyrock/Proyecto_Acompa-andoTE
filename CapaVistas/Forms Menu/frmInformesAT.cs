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

            try
            {
                List<cls_InformeATDTO> informesEncontrados = gestor.ObtenerInformesPorDni(dniBuscado);

                // DEBUG EN EL FORMULARIO
                Console.WriteLine($"DEBUG FORM - Cantidad de informes: {informesEncontrados?.Count ?? -1}");
                if (informesEncontrados != null && informesEncontrados.Count > 0)
                {
                    Console.WriteLine($"DEBUG FORM - Primer paciente: {informesEncontrados[0].nombre_paciente}");
                }

                // CAMBIO: Verificar si se encontró el paciente (la lista no está vacía)
                if (informesEncontrados != null && informesEncontrados.Count > 0)
                {
                    // Tomar el primer registro (que contiene los datos del paciente)
                    cls_InformeATDTO pacienteEncontrado = informesEncontrados[0];

                    // Mostrar datos del paciente
                    lblApeNom.Text = $"{pacienteEncontrado.nombre_paciente} {pacienteEncontrado.apellido_paciente}";
                    lblHoras.Text = $"{pacienteEncontrado.cargahoraria_at}";

                    // Guardar el id_acompanamiento para cuando guardemos el informe
                    _idAcompanamientoActual = pacienteEncontrado.id_acompanamiento;

                    // Verificar si tiene informes existentes para cargar
                    var informesExistentes = informesEncontrados.Where(i => !string.IsNullOrEmpty(i.id_informe_at)).ToList();

                    if (informesExistentes.Count > 0)
                    {
                        // Cargar el primer informe existente
                        var primerInforme = informesExistentes[0];
                        if (!string.IsNullOrEmpty(primerInforme.ruta))
                        {
                            gestor.CargarInforme(txtInforme, primerInforme.ruta, gestor);
                        }
                        MessageBox.Show($"Se encontraron {informesExistentes.Count} informe(s) para el paciente.", "Informes Encontrados",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // No tiene informes - limpiar el textbox para nuevo informe
                        txtInforme.Clear();
                        MessageBox.Show("Paciente encontrado. Puede crear un nuevo informe.", "Nuevo Informe",
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

        #region Implementando codigo del prof


        private void GuardarInforme()
        {
            try
            {
                // Validar que hay un paciente seleccionado
                if (_idAcompanamientoActual == 0)
                {
                    MessageBox.Show("Debe buscar un paciente primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que hay contenido en el informe
                if (string.IsNullOrWhiteSpace(txtInforme.Text))
                {
                    MessageBox.Show("El informe no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Generar GUID si no existe
                if (string.IsNullOrWhiteSpace(guidArchivo))
                    guidArchivo = Guid.NewGuid().ToString();

                // Construir ruta del archivo
                string ruta = Path.Combine(rutaArchivoGuardado, guidArchivo + ".dat");

                // 1. Guardar archivo físicamente
                gestor.GuardarArchivo(ruta, txtInforme.Text);

                // 2. Crear el DTO con los datos del informe
                var informe = new cls_InformeATDTO
                {
                    // Si es nuevo informe, id_informe_at estará vacío
                    id_informe_at = string.Empty, // Esto hará que se inserte como nuevo
                    id_acompanamiento = _idAcompanamientoActual, // ← USA LA VARIABLE QUE YA GUARDASTE
                    fecha_periodo = DateTime.Now,
                    id_usuario_creador = 1, // Temporal - implementa ObtenerUsuarioLogueado()
                    fecha_creacion = DateTime.Now,
                    ruta = ruta, // Guardamos la ruta del archivo
                    dni_paciente = Convert.ToInt32(txtBusquedaPaciente.Text),
                    nombre_paciente = lblApeNom.Text.Split(' ')[0],
                    apellido_paciente = lblApeNom.Text.Split(' ').Length > 1 ? lblApeNom.Text.Split(' ')[1] : "",
                    cargahoraria_at = Convert.ToDecimal(lblHoras.Text)
                };

                // 3. Guardar en la base de datos usando el gestor
                bool guardadoExitoso = gestor.GuardarInforme(informe);

                if (guardadoExitoso)
                {
                    MessageBox.Show("Informe guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }
        #endregion

        private void btnGuardarInforme_Click(object sender, EventArgs e)
        {
            GuardarInforme();
        }
    }
}
