using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapaVistas.Forms_Menu // O tu namespace
{
    public partial class frmAsignacionAT : Form
    {
        // Variables para poder arrastrar el formulario sin borde
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        // ID del paciente seleccionado
        private int _idPaciente = 0;

        public frmAsignacionAT()
        {
            InitializeComponent();
        }

        private void frmAsignarAT_Load(object sender, EventArgs e)
        {
            ConfigurarControles();
            CargarCombos();
        }

        private void ConfigurarControles()
        {
            // Configurar TimePickers
            timeInicio.Format = DateTimePickerFormat.Custom;
            timeInicio.CustomFormat = "HH:mm";
            timeInicio.ShowUpDown = true;
            timeInicio.Value = DateTime.Today.AddHours(9); // Default 09:00

            timeFin.Format = DateTimePickerFormat.Custom;
            timeFin.CustomFormat = "HH:mm";
            timeFin.ShowUpDown = true;
            timeFin.Value = DateTime.Today.AddHours(10); // Default 10:00

            // Configurar Grilla
            dgvHorarios.Columns.Clear();
            dgvHorarios.Columns.Add("colDia", "Día");
            dgvHorarios.Columns.Add("colInicio", "Hora Inicio");
            dgvHorarios.Columns.Add("colFin", "Hora Fin");

            // Damos formato a las columnas de hora
            dgvHorarios.Columns["colInicio"].DefaultCellStyle.Format = "HH:mm";
            dgvHorarios.Columns["colFin"].DefaultCellStyle.Format = "HH:mm";
        }

        private void CargarCombos()
        {
            // Cargar Ámbitos (simulación)
            cmbAmbito.Items.Add("Hogar");
            cmbAmbito.Items.Add("Escuela");
            cmbAmbito.Items.Add("Consultorio");
            cmbAmbito.Items.Add("Otro");

            // Cargar Profesionales A.T. (simulación)
            // AQUÍ: Deberías hacer un SELECT a tu tabla Profesionales filtrando por la especialidad "Acompañante Terapéutico"
            cmbProfesional.Items.Add("Lic. Pérez, Ana (AT)");
            cmbProfesional.Items.Add("Lic. Gómez, Juan (AT)");
            cmbProfesional.Items.Add("Lic. Martínez, Carla (AT)");

            // Cargar Días de la semana
            cmbDiaSemana.Items.Add("Lunes");
            cmbDiaSemana.Items.Add("Martes");
            cmbDiaSemana.Items.Add("Miércoles");
            cmbDiaSemana.Items.Add("Jueves");
            cmbDiaSemana.Items.Add("Viernes");
            cmbDiaSemana.Items.Add("Sábado");
            cmbDiaSemana.Items.Add("Domingo");
            cmbDiaSemana.SelectedIndex = 0;
        }

        // --- LÓGICA PARA ARRASTRAR EL FORMULARIO ---
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscarPaciente.Text))
            {
                MessageBox.Show("Ingrese un DNI o Apellido para buscar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // AQUÍ: Lógica de búsqueda en tu DB

            // --- Simulación de éxito ---
            _idPaciente = 123; // Guardamos el ID del paciente encontrado
            lblPacienteSeleccionado.Text = "GONZÁLEZ, LUCAS (DNI: 40.123.456)";
            MessageBox.Show("Paciente encontrado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAgregarHorario_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (timeInicio.Value >= timeFin.Value)
            {
                MessageBox.Show("La hora de inicio no puede ser mayor o igual a la hora de fin.", "Error de Horario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string dia = cmbDiaSemana.SelectedItem.ToString();
            DateTime inicio = timeInicio.Value;
            DateTime fin = timeFin.Value;

            // Agregamos a la grilla (temporalmente)
            dgvHorarios.Rows.Add(dia, inicio, fin);
        }

        private void btnEliminarHorario_Click(object sender, EventArgs e)
        {
            if (dgvHorarios.SelectedRows.Count > 0)
            {
                dgvHorarios.Rows.Remove(dgvHorarios.SelectedRows[0]);
            }
            else
            {
                MessageBox.Show("Seleccione una fila de la grilla para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGuardarAsignacion_Click(object sender, EventArgs e)
        {
            // Validaciones finales
            if (_idPaciente == 0)
            {
                MessageBox.Show("Debe seleccionar un paciente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbAmbito.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un ámbito.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbProfesional.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un profesional.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dgvHorarios.Rows.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un rango horario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // AQUÍ: LÓGICA DE GUARDADO EN BASE DE DATOS
            // 1. Obtener ID del profesional (del combo)
            // 2. Obtener ID del paciente (de _idPaciente)
            // 3. Obtener Ámbito (del combo)
            // 4. Iniciar una transacción
            // 5. INSERT en la tabla "Asignaciones_AT" (o como se llame) con (id_paciente, id_profesional, ambito)
            // 6. Obtener el ID de la asignación recién creada (SCOPE_IDENTITY())
            // 7. Recorrer la grilla (dgvHorarios.Rows)
            // 8. Por cada fila: INSERT en "Asignaciones_AT_Horarios" con (id_asignacion, dia, hora_inicio, hora_fin)
            // 9. COMMIT de la transacción

            MessageBox.Show("¡Asignación guardada con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            _idPaciente = 0;
            lblPacienteSeleccionado.Text = "Busque un paciente...";
            txtBuscarPaciente.Clear();
            cmbAmbito.SelectedIndex = -1;
            cmbProfesional.SelectedIndex = -1;
            cmbDiaSemana.SelectedIndex = 0;
            dgvHorarios.Rows.Clear();
        }

        private void btnAmbito_Click(object sender, EventArgs e)
        {
            // 1. Creamos una instancia del formulario de ABM
            frmABMAmbitos formAmbitos = new frmABMAmbitos();

            // 2. Lo mostramos como un diálogo.
            // El código se detendrá aquí hasta que el usuario cierre la ventana de ámbitos.
            DialogResult resultado = formAmbitos.ShowDialog();

            // 3. Verificamos si el usuario guardó cambios (OK = agregó, modificó o eliminó algo)
            if (resultado == DialogResult.OK)
            {
                // 4. Si hubo cambios, volvemos a cargar el ComboBox de ámbitos
                //    para que muestre los nuevos datos.
                CargarComboAmbitos();
            }

        }
        private void CargarComboAmbitos()
        {
            // Guardamos la selección actual para que el usuario no la pierda
            object seleccionActual = cmbAmbito.SelectedItem;

            cmbAmbito.Items.Clear();

            // AQUÍ: Hacés tu consulta a la base de datos para traer los ámbitos
            // SELECT Nombre FROM Ambitos

            // --- Simulación ---
            cmbAmbito.Items.Add("Hogar");
            cmbAmbito.Items.Add("Escuela");
            cmbAmbito.Items.Add("Consultorio");
            cmbAmbito.Items.Add("Externo");
            // --- Fin Simulación ---

            // Intentamos volver a seleccionar lo que el usuario tenía
            if (seleccionActual != null && cmbAmbito.Items.Contains(seleccionActual))
            {
                cmbAmbito.SelectedItem = seleccionActual;
            }
        }
    }
}