using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapaVistas.Forms_Menu // O tu namespace
{
    public partial class frmGestionHorarios : Form
    {
        // Variables para poder arrastrar el formulario sin borde
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        // ID del profesional que estamos editando
        private int idProfesional;

        // Constructor modificado
        public frmGestionHorarios(int idProfesional, string nombreProfesional)
        {
            InitializeComponent();
            this.idProfesional = idProfesional;
            lblNombreProfesional.Text = nombreProfesional;
        }

        private void frmGestionHorarios_Load(object sender, EventArgs e)
        {
            ConfigurarControles();
            CargarHorarios();
        }

        private void ConfigurarControles()
        {
            // Cargar ComboBox de días
            cmbDiaSemana.Items.Add("Lunes");
            cmbDiaSemana.Items.Add("Martes");
            cmbDiaSemana.Items.Add("Miércoles");
            cmbDiaSemana.Items.Add("Jueves");
            cmbDiaSemana.Items.Add("Viernes");
            cmbDiaSemana.Items.Add("Sábado");
            cmbDiaSemana.SelectedIndex = 0;

            // Configurar TimePickers
            timeInicio.Format = DateTimePickerFormat.Custom;
            timeInicio.CustomFormat = "HH:mm";
            timeInicio.ShowUpDown = true;
            timeInicio.Value = DateTime.Today.AddHours(9); // Default 09:00

            timeFin.Format = DateTimePickerFormat.Custom;
            timeFin.CustomFormat = "HH:mm";
            timeFin.ShowUpDown = true;
            timeFin.Value = DateTime.Today.AddHours(17); // Default 17:00

            // Configurar NumericUpDown
            numDuracion.Value = 30;
            numDuracion.Minimum = 10;
            numDuracion.Maximum = 120;
            numDuracion.Increment = 5;
        }

        private void CargarHorarios()
        {
            // AQUÍ: Harías la consulta a tu base de datos
            // SELECT id_hora_prof, dia_semana, hora_inicio, hora_fin, duracion_turno 
            // FROM Horarios_Profesional WHERE id_profesional = this.idProfesional

            // --- Simulación de datos ---
            dgvHorarios.DataSource = null;
            dgvHorarios.Rows.Clear();
            dgvHorarios.Columns.Clear();

            // Definir columnas
            dgvHorarios.Columns.Add("colIdHorario", "ID");
            dgvHorarios.Columns.Add("colDia", "Día");
            dgvHorarios.Columns.Add("colInicio", "Inicio");
            dgvHorarios.Columns.Add("colFin", "Fin");
            dgvHorarios.Columns.Add("colDuracion", "Duración (min)");

            // Ocultar el ID
            dgvHorarios.Columns["colIdHorario"].Visible = false;

            // Formatear columnas de hora
            dgvHorarios.Columns["colInicio"].DefaultCellStyle.Format = "HH:mm";
            dgvHorarios.Columns["colFin"].DefaultCellStyle.Format = "HH:mm";

            // Cargar filas de ejemplo
            dgvHorarios.Rows.Add(1, "Lunes", DateTime.Today.AddHours(9), DateTime.Today.AddHours(17), 30);
            dgvHorarios.Rows.Add(2, "Martes", DateTime.Today.AddHours(9), DateTime.Today.AddHours(13), 45);
            dgvHorarios.Rows.Add(3, "Jueves", DateTime.Today.AddHours(14), DateTime.Today.AddHours(18), 30);
            // --- Fin Simulación ---

            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            cmbDiaSemana.SelectedIndex = 0;
            timeInicio.Value = DateTime.Today.AddHours(9);
            timeFin.Value = DateTime.Today.AddHours(17);
            numDuracion.Value = 30;
            dgvHorarios.ClearSelection();
            btnAgregar.Text = "Agregar"; // Cambiamos el texto del botón a "Agregar"
        }

        // --- LÓGICA PARA ARRASTRAR EL FORMULARIO ---
        private void frm_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void frm_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private void frm_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        // --- LÓGICA DE CONTROLES ---
        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvHorarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHorarios.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvHorarios.SelectedRows[0];

                // Cargar datos en los controles para editar
                cmbDiaSemana.SelectedItem = row.Cells["colDia"].Value.ToString();
                timeInicio.Value = Convert.ToDateTime(row.Cells["colInicio"].Value);
                timeFin.Value = Convert.ToDateTime(row.Cells["colFin"].Value);
                numDuracion.Value = Convert.ToDecimal(row.Cells["colDuracion"].Value);

                btnAgregar.Text = "Modificar"; // Cambiamos el texto del botón
            }
            else
            {
                btnAgregar.Text = "Agregar";
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (timeInicio.Value >= timeFin.Value)
            {
                MessageBox.Show("La hora de inicio no puede ser mayor o igual a la hora de fin.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string dia = cmbDiaSemana.SelectedItem.ToString();
            TimeSpan horaInicio = timeInicio.Value.TimeOfDay;
            TimeSpan horaFin = timeFin.Value.TimeOfDay;
            int duracion = (int)numDuracion.Value;

            if (dgvHorarios.SelectedRows.Count > 0) // Modo Modificar
            {
                int idHorario = Convert.ToInt32(dgvHorarios.SelectedRows[0].Cells["colIdHorario"].Value);

                // AQUÍ: Harías el UPDATE en tu DB
                // UPDATE Horarios_Profesional SET dia_semana = @dia, hora_inicio = @horaInicio, 
                // hora_fin = @horaFin, duracion_turno = @duracion 
                // WHERE id_hora_prof = @idHorario

                MessageBox.Show($"Horario del día {dia} (ID: {idHorario}) modificado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else // Modo Agregar
            {
                // AQUÍ: Harías el INSERT en tu DB
                // INSERT INTO Horarios_Profesional (id_profesional, dia_semana, hora_inicio, hora_fin, duracion_turno) 
                // VALUES (@idProfesional, @dia, @horaInicio, @horaFin, @duracion)

                MessageBox.Show($"Nuevo horario para el {dia} agregado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            CargarHorarios(); // Recargamos la lista
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvHorarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un horario de la grilla para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idHorario = Convert.ToInt32(dgvHorarios.SelectedRows[0].Cells["colIdHorario"].Value);
            string dia = dgvHorarios.SelectedRows[0].Cells["colDia"].Value.ToString();

            if (MessageBox.Show($"¿Está seguro que desea eliminar el horario del día {dia}?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // AQUÍ: Harías el DELETE en tu DB
                // DELETE FROM Horarios_Profesional WHERE id_hora_prof = @idHorario

                MessageBox.Show($"Horario (ID: {idHorario}) eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarHorarios(); // Recargamos la lista
            }
        }
    }
}