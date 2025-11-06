namespace CapaVistas.Forms_Menu // O tu namespace
{
    partial class frmAsignacionAT
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbBuscarPaciente = new System.Windows.Forms.GroupBox();
            this.lblPacienteSeleccionado = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscarPaciente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbResultadosBusqueda = new System.Windows.Forms.ListBox();
            this.gbDetalles = new System.Windows.Forms.GroupBox();
            this.cmbJornada = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbProfesional = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbAmbito = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbDefinirHorario = new System.Windows.Forms.GroupBox();
            this.btnAgregarHorario = new System.Windows.Forms.Button();
            this.btnActualizarHorario = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.timeFin = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.timeInicio = new System.Windows.Forms.DateTimePicker();
            this.cmbDiaSemana = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gbHorariosAsignados = new System.Windows.Forms.GroupBox();
            this.btnEliminarHorario = new System.Windows.Forms.Button();
            this.dgvHorarios = new System.Windows.Forms.DataGridView();
            this.btnGuardarAsignacion = new System.Windows.Forms.Button();
            this.btnAmbitos = new System.Windows.Forms.Button();
            this.lbAsignacionesExistentes = new System.Windows.Forms.ListBox();
            this.gbBuscarAsignacion = new System.Windows.Forms.GroupBox();
            this.lblAsignaciones = new System.Windows.Forms.Label();
            this.btnBuscarAsignacion = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnNuevaAsignacion = new System.Windows.Forms.Button();
            this.gbBuscarPaciente.SuspendLayout();
            this.gbDetalles.SuspendLayout();
            this.gbDefinirHorario.SuspendLayout();
            this.gbHorariosAsignados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorarios)).BeginInit();
            this.gbBuscarAsignacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbBuscarPaciente
            // 
            this.gbBuscarPaciente.Controls.Add(this.lblPacienteSeleccionado);
            this.gbBuscarPaciente.Controls.Add(this.btnBuscar);
            this.gbBuscarPaciente.Controls.Add(this.txtBuscarPaciente);
            this.gbBuscarPaciente.Controls.Add(this.label1);
            this.gbBuscarPaciente.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbBuscarPaciente.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.gbBuscarPaciente.Location = new System.Drawing.Point(25, 12);
            this.gbBuscarPaciente.Name = "gbBuscarPaciente";
            this.gbBuscarPaciente.Size = new System.Drawing.Size(390, 107);
            this.gbBuscarPaciente.TabIndex = 3;
            this.gbBuscarPaciente.TabStop = false;
            this.gbBuscarPaciente.Text = "1. Buscar Paciente";
            // 
            // lblPacienteSeleccionado
            // 
            this.lblPacienteSeleccionado.AutoSize = true;
            this.lblPacienteSeleccionado.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPacienteSeleccionado.ForeColor = System.Drawing.Color.Turquoise;
            this.lblPacienteSeleccionado.Location = new System.Drawing.Point(20, 76);
            this.lblPacienteSeleccionado.Name = "lblPacienteSeleccionado";
            this.lblPacienteSeleccionado.Size = new System.Drawing.Size(163, 19);
            this.lblPacienteSeleccionado.TabIndex = 3;
            this.lblPacienteSeleccionado.Text = "Busque un paciente...";
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Location = new System.Drawing.Point(295, 45);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBuscarPaciente
            // 
            this.txtBuscarPaciente.Location = new System.Drawing.Point(20, 45);
            this.txtBuscarPaciente.Name = "txtBuscarPaciente";
            this.txtBuscarPaciente.Size = new System.Drawing.Size(270, 22);
            this.txtBuscarPaciente.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar Paciente (DNI o Apellido):";
            // 
            // lbResultadosBusqueda
            // 
            this.lbResultadosBusqueda.Font = new System.Drawing.Font("Bahnschrift", 9F);
            this.lbResultadosBusqueda.FormattingEnabled = true;
            this.lbResultadosBusqueda.ItemHeight = 14;
            this.lbResultadosBusqueda.Location = new System.Drawing.Point(45, 82);
            this.lbResultadosBusqueda.Name = "lbResultadosBusqueda";
            this.lbResultadosBusqueda.Size = new System.Drawing.Size(270, 74);
            this.lbResultadosBusqueda.TabIndex = 4;
            this.lbResultadosBusqueda.Visible = false;
            this.lbResultadosBusqueda.Click += new System.EventHandler(this.lbResultadosBusqueda_Click);
            // 
            // gbDetalles
            // 
            this.gbDetalles.Controls.Add(this.cmbJornada);
            this.gbDetalles.Controls.Add(this.label7);
            this.gbDetalles.Controls.Add(this.cmbProfesional);
            this.gbDetalles.Controls.Add(this.label3);
            this.gbDetalles.Controls.Add(this.cmbAmbito);
            this.gbDetalles.Controls.Add(this.label2);
            this.gbDetalles.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDetalles.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.gbDetalles.Location = new System.Drawing.Point(25, 250);
            this.gbDetalles.Name = "gbDetalles";
            this.gbDetalles.Size = new System.Drawing.Size(390, 177);
            this.gbDetalles.TabIndex = 4;
            this.gbDetalles.TabStop = false;
            this.gbDetalles.Text = "3. Detalles de Asignación";
            // 
            // cmbJornada
            // 
            this.cmbJornada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJornada.FormattingEnabled = true;
            this.cmbJornada.Location = new System.Drawing.Point(20, 137);
            this.cmbJornada.Name = "cmbJornada";
            this.cmbJornada.Size = new System.Drawing.Size(350, 22);
            this.cmbJornada.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 14);
            this.label7.TabIndex = 4;
            this.label7.Text = "Jornada:";
            // 
            // cmbProfesional
            // 
            this.cmbProfesional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProfesional.FormattingEnabled = true;
            this.cmbProfesional.Location = new System.Drawing.Point(20, 89);
            this.cmbProfesional.Name = "cmbProfesional";
            this.cmbProfesional.Size = new System.Drawing.Size(350, 22);
            this.cmbProfesional.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(221, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Seleccionar Profesional (Acompañante):";
            // 
            // cmbAmbito
            // 
            this.cmbAmbito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAmbito.FormattingEnabled = true;
            this.cmbAmbito.Location = new System.Drawing.Point(20, 39);
            this.cmbAmbito.Name = "cmbAmbito";
            this.cmbAmbito.Size = new System.Drawing.Size(350, 22);
            this.cmbAmbito.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ámbito:";
            // 
            // gbDefinirHorario
            // 
            this.gbDefinirHorario.Controls.Add(this.btnAgregarHorario);
            this.gbDefinirHorario.Controls.Add(this.btnActualizarHorario);
            this.gbDefinirHorario.Controls.Add(this.label6);
            this.gbDefinirHorario.Controls.Add(this.timeFin);
            this.gbDefinirHorario.Controls.Add(this.label5);
            this.gbDefinirHorario.Controls.Add(this.timeInicio);
            this.gbDefinirHorario.Controls.Add(this.cmbDiaSemana);
            this.gbDefinirHorario.Controls.Add(this.label4);
            this.gbDefinirHorario.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDefinirHorario.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.gbDefinirHorario.Location = new System.Drawing.Point(25, 437);
            this.gbDefinirHorario.Name = "gbDefinirHorario";
            this.gbDefinirHorario.Size = new System.Drawing.Size(390, 143);
            this.gbDefinirHorario.TabIndex = 5;
            this.gbDefinirHorario.TabStop = false;
            this.gbDefinirHorario.Text = "4. Definir Horario";
            // 
            // btnAgregarHorario
            // 
            this.btnAgregarHorario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarHorario.Enabled = false;
            this.btnAgregarHorario.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.btnAgregarHorario.FlatAppearance.BorderSize = 2;
            this.btnAgregarHorario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarHorario.Font = new System.Drawing.Font("Sans Serif Collection", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarHorario.Location = new System.Drawing.Point(209, 91);
            this.btnAgregarHorario.Name = "btnAgregarHorario";
            this.btnAgregarHorario.Size = new System.Drawing.Size(178, 46);
            this.btnAgregarHorario.TabIndex = 7;
            this.btnAgregarHorario.Text = "Nuevo Horario a la Grilla";
            this.btnAgregarHorario.UseVisualStyleBackColor = true;
            this.btnAgregarHorario.Click += new System.EventHandler(this.btnAgregarHorario_Click);
            // 
            // btnActualizarHorario
            // 
            this.btnActualizarHorario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizarHorario.Enabled = false;
            this.btnActualizarHorario.FlatAppearance.BorderColor = System.Drawing.Color.Aqua;
            this.btnActualizarHorario.FlatAppearance.BorderSize = 2;
            this.btnActualizarHorario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarHorario.Font = new System.Drawing.Font("Sans Serif Collection", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizarHorario.Location = new System.Drawing.Point(3, 91);
            this.btnActualizarHorario.Name = "btnActualizarHorario";
            this.btnActualizarHorario.Size = new System.Drawing.Size(200, 46);
            this.btnActualizarHorario.TabIndex = 6;
            this.btnActualizarHorario.Text = "Actualizar Horario de Grilla";
            this.btnActualizarHorario.UseVisualStyleBackColor = true;
            this.btnActualizarHorario.Click += new System.EventHandler(this.btnActualizarHorario_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(220, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 14);
            this.label6.TabIndex = 5;
            this.label6.Text = "Hora Fin:";
            // 
            // timeFin
            // 
            this.timeFin.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeFin.Location = new System.Drawing.Point(280, 62);
            this.timeFin.Name = "timeFin";
            this.timeFin.Size = new System.Drawing.Size(90, 22);
            this.timeFin.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 14);
            this.label5.TabIndex = 3;
            this.label5.Text = "Hora Inicio:";
            // 
            // timeInicio
            // 
            this.timeInicio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeInicio.Location = new System.Drawing.Point(92, 62);
            this.timeInicio.Name = "timeInicio";
            this.timeInicio.Size = new System.Drawing.Size(90, 22);
            this.timeInicio.TabIndex = 2;
            // 
            // cmbDiaSemana
            // 
            this.cmbDiaSemana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDiaSemana.FormattingEnabled = true;
            this.cmbDiaSemana.Location = new System.Drawing.Point(92, 22);
            this.cmbDiaSemana.Name = "cmbDiaSemana";
            this.cmbDiaSemana.Size = new System.Drawing.Size(278, 22);
            this.cmbDiaSemana.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "Día:";
            // 
            // gbHorariosAsignados
            // 
            this.gbHorariosAsignados.Controls.Add(this.btnEliminarHorario);
            this.gbHorariosAsignados.Controls.Add(this.dgvHorarios);
            this.gbHorariosAsignados.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbHorariosAsignados.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.gbHorariosAsignados.Location = new System.Drawing.Point(435, 12);
            this.gbHorariosAsignados.Name = "gbHorariosAsignados";
            this.gbHorariosAsignados.Size = new System.Drawing.Size(603, 506);
            this.gbHorariosAsignados.TabIndex = 6;
            this.gbHorariosAsignados.TabStop = false;
            this.gbHorariosAsignados.Text = "5. Horarios Asignados";
            // 
            // btnEliminarHorario
            // 
            this.btnEliminarHorario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarHorario.FlatAppearance.BorderColor = System.Drawing.Color.Tomato;
            this.btnEliminarHorario.FlatAppearance.BorderSize = 2;
            this.btnEliminarHorario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarHorario.Font = new System.Drawing.Font("Sans Serif Collection", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarHorario.Location = new System.Drawing.Point(416, 451);
            this.btnEliminarHorario.Name = "btnEliminarHorario";
            this.btnEliminarHorario.Size = new System.Drawing.Size(170, 39);
            this.btnEliminarHorario.TabIndex = 7;
            this.btnEliminarHorario.Text = "Eliminar Seleccionado";
            this.btnEliminarHorario.UseVisualStyleBackColor = true;
            this.btnEliminarHorario.Click += new System.EventHandler(this.btnEliminarHorario_Click);
            // 
            // dgvHorarios
            // 
            this.dgvHorarios.AllowUserToAddRows = false;
            this.dgvHorarios.AllowUserToDeleteRows = false;
            this.dgvHorarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHorarios.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.dgvHorarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHorarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHorarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHorarios.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHorarios.EnableHeadersVisualStyles = false;
            this.dgvHorarios.GridColor = System.Drawing.Color.Teal;
            this.dgvHorarios.Location = new System.Drawing.Point(20, 25);
            this.dgvHorarios.MultiSelect = false;
            this.dgvHorarios.Name = "dgvHorarios";
            this.dgvHorarios.ReadOnly = true;
            this.dgvHorarios.RowHeadersVisible = false;
            this.dgvHorarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHorarios.Size = new System.Drawing.Size(567, 418);
            this.dgvHorarios.TabIndex = 0;
            this.dgvHorarios.SelectionChanged += new System.EventHandler(this.dgvHorarios_SelectionChanged);
            // 
            // btnGuardarAsignacion
            // 
            this.btnGuardarAsignacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarAsignacion.FlatAppearance.BorderColor = System.Drawing.Color.LawnGreen;
            this.btnGuardarAsignacion.FlatAppearance.BorderSize = 3;
            this.btnGuardarAsignacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarAsignacion.Font = new System.Drawing.Font("Sans Serif Collection", 9.749998F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarAsignacion.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnGuardarAsignacion.Location = new System.Drawing.Point(703, 530);
            this.btnGuardarAsignacion.Name = "btnGuardarAsignacion";
            this.btnGuardarAsignacion.Size = new System.Drawing.Size(335, 50);
            this.btnGuardarAsignacion.TabIndex = 8;
            this.btnGuardarAsignacion.Text = "Guardar Asignación Completa";
            this.btnGuardarAsignacion.UseVisualStyleBackColor = true;
            this.btnGuardarAsignacion.Click += new System.EventHandler(this.btnGuardarAsignacion_Click);
            // 
            // btnAmbitos
            // 
            this.btnAmbitos.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnAmbitos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAmbitos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAmbitos.Location = new System.Drawing.Point(435, 530);
            this.btnAmbitos.Name = "btnAmbitos";
            this.btnAmbitos.Size = new System.Drawing.Size(94, 50);
            this.btnAmbitos.TabIndex = 9;
            this.btnAmbitos.Text = "Gestionar Ámbitos";
            this.btnAmbitos.UseVisualStyleBackColor = true;
            this.btnAmbitos.Click += new System.EventHandler(this.btnAmbitos_Click);
            // 
            // lbAsignacionesExistentes
            // 
            this.lbAsignacionesExistentes.Font = new System.Drawing.Font("Bahnschrift", 9F);
            this.lbAsignacionesExistentes.FormattingEnabled = true;
            this.lbAsignacionesExistentes.ItemHeight = 14;
            this.lbAsignacionesExistentes.Location = new System.Drawing.Point(45, 202);
            this.lbAsignacionesExistentes.Name = "lbAsignacionesExistentes";
            this.lbAsignacionesExistentes.Size = new System.Drawing.Size(270, 74);
            this.lbAsignacionesExistentes.TabIndex = 10;
            this.lbAsignacionesExistentes.Visible = false;
            this.lbAsignacionesExistentes.Click += new System.EventHandler(this.lbAsignacionesExistentes_Click);
            // 
            // gbBuscarAsignacion
            // 
            this.gbBuscarAsignacion.Controls.Add(this.lblAsignaciones);
            this.gbBuscarAsignacion.Controls.Add(this.btnBuscarAsignacion);
            this.gbBuscarAsignacion.Controls.Add(this.textBox1);
            this.gbBuscarAsignacion.Controls.Add(this.label9);
            this.gbBuscarAsignacion.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbBuscarAsignacion.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.gbBuscarAsignacion.Location = new System.Drawing.Point(25, 131);
            this.gbBuscarAsignacion.Name = "gbBuscarAsignacion";
            this.gbBuscarAsignacion.Size = new System.Drawing.Size(390, 109);
            this.gbBuscarAsignacion.TabIndex = 4;
            this.gbBuscarAsignacion.TabStop = false;
            this.gbBuscarAsignacion.Text = "2. Buscar Asignaciones Existentes:";
            // 
            // lblAsignaciones
            // 
            this.lblAsignaciones.AutoSize = true;
            this.lblAsignaciones.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAsignaciones.ForeColor = System.Drawing.Color.Turquoise;
            this.lblAsignaciones.Location = new System.Drawing.Point(20, 78);
            this.lblAsignaciones.Name = "lblAsignaciones";
            this.lblAsignaciones.Size = new System.Drawing.Size(180, 19);
            this.lblAsignaciones.TabIndex = 3;
            this.lblAsignaciones.Text = "Busque una asignación:";
            // 
            // btnBuscarAsignacion
            // 
            this.btnBuscarAsignacion.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnBuscarAsignacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarAsignacion.Location = new System.Drawing.Point(295, 44);
            this.btnBuscarAsignacion.Name = "btnBuscarAsignacion";
            this.btnBuscarAsignacion.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarAsignacion.TabIndex = 2;
            this.btnBuscarAsignacion.Text = "Buscar";
            this.btnBuscarAsignacion.UseVisualStyleBackColor = true;
            this.btnBuscarAsignacion.Click += new System.EventHandler(this.btnBuscarAsignacion_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(20, 45);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(270, 22);
            this.textBox1.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 14);
            this.label9.TabIndex = 0;
            this.label9.Text = "Realizar Búsqueda:";
            // 
            // btnNuevaAsignacion
            // 
            this.btnNuevaAsignacion.Enabled = false;
            this.btnNuevaAsignacion.FlatAppearance.BorderColor = System.Drawing.Color.SpringGreen;
            this.btnNuevaAsignacion.FlatAppearance.BorderSize = 3;
            this.btnNuevaAsignacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaAsignacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaAsignacion.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNuevaAsignacion.Location = new System.Drawing.Point(603, 530);
            this.btnNuevaAsignacion.Name = "btnNuevaAsignacion";
            this.btnNuevaAsignacion.Size = new System.Drawing.Size(94, 50);
            this.btnNuevaAsignacion.TabIndex = 11;
            this.btnNuevaAsignacion.Text = "NUEVA ASIGNACIÓN";
            this.btnNuevaAsignacion.UseVisualStyleBackColor = true;
            this.btnNuevaAsignacion.Click += new System.EventHandler(this.btnNuevaAsignacion_Click);
            // 
            // frmAsignacionAT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1063, 605);
            this.Controls.Add(this.btnNuevaAsignacion);
            this.Controls.Add(this.lbResultadosBusqueda);
            this.Controls.Add(this.lbAsignacionesExistentes);
            this.Controls.Add(this.gbBuscarAsignacion);
            this.Controls.Add(this.btnAmbitos);
            this.Controls.Add(this.btnGuardarAsignacion);
            this.Controls.Add(this.gbHorariosAsignados);
            this.Controls.Add(this.gbDefinirHorario);
            this.Controls.Add(this.gbDetalles);
            this.Controls.Add(this.gbBuscarPaciente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAsignacionAT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignaciones de A.T.";
            this.Load += new System.EventHandler(this.frmAsignarAT_Load);
            this.gbBuscarPaciente.ResumeLayout(false);
            this.gbBuscarPaciente.PerformLayout();
            this.gbDetalles.ResumeLayout(false);
            this.gbDetalles.PerformLayout();
            this.gbDefinirHorario.ResumeLayout(false);
            this.gbDefinirHorario.PerformLayout();
            this.gbHorariosAsignados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorarios)).EndInit();
            this.gbBuscarAsignacion.ResumeLayout(false);
            this.gbBuscarAsignacion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbBuscarPaciente;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBuscarPaciente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPacienteSeleccionado;
        private System.Windows.Forms.GroupBox gbDetalles;
        private System.Windows.Forms.ComboBox cmbProfesional;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbDefinirHorario;
        private System.Windows.Forms.ComboBox cmbDiaSemana;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker timeInicio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker timeFin;
        private System.Windows.Forms.Button btnActualizarHorario;
        private System.Windows.Forms.GroupBox gbHorariosAsignados;
        private System.Windows.Forms.DataGridView dgvHorarios;
        private System.Windows.Forms.Button btnEliminarHorario;
        private System.Windows.Forms.Button btnGuardarAsignacion;
        private System.Windows.Forms.Button btnAmbitos;
        private System.Windows.Forms.ListBox lbResultadosBusqueda;
        private System.Windows.Forms.ComboBox cmbJornada;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbAmbito;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbAsignacionesExistentes;
        private System.Windows.Forms.GroupBox gbBuscarAsignacion;
        private System.Windows.Forms.Label lblAsignaciones;
        private System.Windows.Forms.Button btnBuscarAsignacion;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnAgregarHorario;
        private System.Windows.Forms.Button btnNuevaAsignacion;
    }
}