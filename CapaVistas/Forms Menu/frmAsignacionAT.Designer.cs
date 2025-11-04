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
            this.panelTopBar = new System.Windows.Forms.Panel();
            this.lblTituloForm = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.gbBuscarPaciente = new System.Windows.Forms.GroupBox();
            this.lblPacienteSeleccionado = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscarPaciente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbDetalles = new System.Windows.Forms.GroupBox();
            this.cmbProfesional = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbAmbito = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbDefinirHorario = new System.Windows.Forms.GroupBox();
            this.btnAgregarHorario = new System.Windows.Forms.Button();
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
            this.btnAmbito = new System.Windows.Forms.Button();
            this.panelTopBar.SuspendLayout();
            this.gbBuscarPaciente.SuspendLayout();
            this.gbDetalles.SuspendLayout();
            this.gbDefinirHorario.SuspendLayout();
            this.gbHorariosAsignados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorarios)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTopBar
            // 
            this.panelTopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.panelTopBar.Controls.Add(this.lblTituloForm);
            this.panelTopBar.Controls.Add(this.lblClose);
            this.panelTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopBar.Location = new System.Drawing.Point(0, 0);
            this.panelTopBar.Name = "panelTopBar";
            this.panelTopBar.Size = new System.Drawing.Size(1063, 30);
            this.panelTopBar.TabIndex = 2;
            this.panelTopBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTopBar_MouseDown);
            this.panelTopBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTopBar_MouseMove);
            this.panelTopBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelTopBar_MouseUp);
            // 
            // lblTituloForm
            // 
            this.lblTituloForm.AutoSize = true;
            this.lblTituloForm.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloForm.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblTituloForm.Location = new System.Drawing.Point(12, 7);
            this.lblTituloForm.Name = "lblTituloForm";
            this.lblTituloForm.Size = new System.Drawing.Size(202, 16);
            this.lblTituloForm.TabIndex = 1;
            this.lblTituloForm.Text = "Asignar Acompañante Terapéutico";
            // 
            // lblClose
            // 
            this.lblClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClose.AutoSize = true;
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClose.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClose.ForeColor = System.Drawing.Color.White;
            this.lblClose.Location = new System.Drawing.Point(1035, 6);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(20, 19);
            this.lblClose.TabIndex = 0;
            this.lblClose.Text = "X";
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // gbBuscarPaciente
            // 
            this.gbBuscarPaciente.Controls.Add(this.lblPacienteSeleccionado);
            this.gbBuscarPaciente.Controls.Add(this.btnBuscar);
            this.gbBuscarPaciente.Controls.Add(this.txtBuscarPaciente);
            this.gbBuscarPaciente.Controls.Add(this.label1);
            this.gbBuscarPaciente.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbBuscarPaciente.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.gbBuscarPaciente.Location = new System.Drawing.Point(25, 50);
            this.gbBuscarPaciente.Name = "gbBuscarPaciente";
            this.gbBuscarPaciente.Size = new System.Drawing.Size(390, 130);
            this.gbBuscarPaciente.TabIndex = 3;
            this.gbBuscarPaciente.TabStop = false;
            this.gbBuscarPaciente.Text = "1. Buscar Paciente";
            // 
            // lblPacienteSeleccionado
            // 
            this.lblPacienteSeleccionado.AutoSize = true;
            this.lblPacienteSeleccionado.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPacienteSeleccionado.ForeColor = System.Drawing.Color.Turquoise;
            this.lblPacienteSeleccionado.Location = new System.Drawing.Point(20, 90);
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
            // gbDetalles
            // 
            this.gbDetalles.Controls.Add(this.cmbProfesional);
            this.gbDetalles.Controls.Add(this.label3);
            this.gbDetalles.Controls.Add(this.cmbAmbito);
            this.gbDetalles.Controls.Add(this.label2);
            this.gbDetalles.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDetalles.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.gbDetalles.Location = new System.Drawing.Point(25, 190);
            this.gbDetalles.Name = "gbDetalles";
            this.gbDetalles.Size = new System.Drawing.Size(390, 130);
            this.gbDetalles.TabIndex = 4;
            this.gbDetalles.TabStop = false;
            this.gbDetalles.Text = "2. Detalles de Asignación";
            // 
            // cmbProfesional
            // 
            this.cmbProfesional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProfesional.FormattingEnabled = true;
            this.cmbProfesional.Location = new System.Drawing.Point(20, 95);
            this.cmbProfesional.Name = "cmbProfesional";
            this.cmbProfesional.Size = new System.Drawing.Size(350, 22);
            this.cmbProfesional.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(221, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Seleccionar Profesional (Acompañante):";
            // 
            // cmbAmbito
            // 
            this.cmbAmbito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAmbito.FormattingEnabled = true;
            this.cmbAmbito.Location = new System.Drawing.Point(20, 45);
            this.cmbAmbito.Name = "cmbAmbito";
            this.cmbAmbito.Size = new System.Drawing.Size(350, 22);
            this.cmbAmbito.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ámbito:";
            // 
            // gbDefinirHorario
            // 
            this.gbDefinirHorario.Controls.Add(this.btnAgregarHorario);
            this.gbDefinirHorario.Controls.Add(this.label6);
            this.gbDefinirHorario.Controls.Add(this.timeFin);
            this.gbDefinirHorario.Controls.Add(this.label5);
            this.gbDefinirHorario.Controls.Add(this.timeInicio);
            this.gbDefinirHorario.Controls.Add(this.cmbDiaSemana);
            this.gbDefinirHorario.Controls.Add(this.label4);
            this.gbDefinirHorario.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDefinirHorario.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.gbDefinirHorario.Location = new System.Drawing.Point(25, 330);
            this.gbDefinirHorario.Name = "gbDefinirHorario";
            this.gbDefinirHorario.Size = new System.Drawing.Size(390, 180);
            this.gbDefinirHorario.TabIndex = 5;
            this.gbDefinirHorario.TabStop = false;
            this.gbDefinirHorario.Text = "3. Definir Horario";
            // 
            // btnAgregarHorario
            // 
            this.btnAgregarHorario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarHorario.FlatAppearance.BorderColor = System.Drawing.Color.Aqua;
            this.btnAgregarHorario.FlatAppearance.BorderSize = 2;
            this.btnAgregarHorario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarHorario.Font = new System.Drawing.Font("Sans Serif Collection", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarHorario.Location = new System.Drawing.Point(23, 125);
            this.btnAgregarHorario.Name = "btnAgregarHorario";
            this.btnAgregarHorario.Size = new System.Drawing.Size(347, 40);
            this.btnAgregarHorario.TabIndex = 6;
            this.btnAgregarHorario.Text = "Agregar Horario a la Grilla >>";
            this.btnAgregarHorario.UseVisualStyleBackColor = true;
            this.btnAgregarHorario.Click += new System.EventHandler(this.btnAgregarHorario_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(220, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 14);
            this.label6.TabIndex = 5;
            this.label6.Text = "Hora Fin:";
            // 
            // timeFin
            // 
            this.timeFin.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeFin.Location = new System.Drawing.Point(280, 75);
            this.timeFin.Name = "timeFin";
            this.timeFin.Size = new System.Drawing.Size(90, 22);
            this.timeFin.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 14);
            this.label5.TabIndex = 3;
            this.label5.Text = "Hora Inicio:";
            // 
            // timeInicio
            // 
            this.timeInicio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeInicio.Location = new System.Drawing.Point(92, 75);
            this.timeInicio.Name = "timeInicio";
            this.timeInicio.Size = new System.Drawing.Size(90, 22);
            this.timeInicio.TabIndex = 2;
            // 
            // cmbDiaSemana
            // 
            this.cmbDiaSemana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDiaSemana.FormattingEnabled = true;
            this.cmbDiaSemana.Location = new System.Drawing.Point(92, 35);
            this.cmbDiaSemana.Name = "cmbDiaSemana";
            this.cmbDiaSemana.Size = new System.Drawing.Size(278, 22);
            this.cmbDiaSemana.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 38);
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
            this.gbHorariosAsignados.Location = new System.Drawing.Point(435, 50);
            this.gbHorariosAsignados.Name = "gbHorariosAsignados";
            this.gbHorariosAsignados.Size = new System.Drawing.Size(603, 460);
            this.gbHorariosAsignados.TabIndex = 6;
            this.gbHorariosAsignados.TabStop = false;
            this.gbHorariosAsignados.Text = "4. Horarios Asignados";
            // 
            // btnEliminarHorario
            // 
            this.btnEliminarHorario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarHorario.FlatAppearance.BorderColor = System.Drawing.Color.Tomato;
            this.btnEliminarHorario.FlatAppearance.BorderSize = 2;
            this.btnEliminarHorario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarHorario.Font = new System.Drawing.Font("Sans Serif Collection", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarHorario.Location = new System.Drawing.Point(417, 410);
            this.btnEliminarHorario.Name = "btnEliminarHorario";
            this.btnEliminarHorario.Size = new System.Drawing.Size(170, 40);
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
            this.dgvHorarios.Size = new System.Drawing.Size(567, 370);
            this.dgvHorarios.TabIndex = 0;
            // 
            // btnGuardarAsignacion
            // 
            this.btnGuardarAsignacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarAsignacion.FlatAppearance.BorderColor = System.Drawing.Color.LawnGreen;
            this.btnGuardarAsignacion.FlatAppearance.BorderSize = 3;
            this.btnGuardarAsignacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarAsignacion.Font = new System.Drawing.Font("Sans Serif Collection", 9.749998F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarAsignacion.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnGuardarAsignacion.Location = new System.Drawing.Point(642, 530);
            this.btnGuardarAsignacion.Name = "btnGuardarAsignacion";
            this.btnGuardarAsignacion.Size = new System.Drawing.Size(396, 50);
            this.btnGuardarAsignacion.TabIndex = 8;
            this.btnGuardarAsignacion.Text = "Guardar Asignación Completa";
            this.btnGuardarAsignacion.UseVisualStyleBackColor = true;
            this.btnGuardarAsignacion.Click += new System.EventHandler(this.btnGuardarAsignacion_Click);
            // 
            // btnAmbito
            // 
            this.btnAmbito.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnAmbito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAmbito.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAmbito.Location = new System.Drawing.Point(25, 530);
            this.btnAmbito.Name = "btnAmbito";
            this.btnAmbito.Size = new System.Drawing.Size(110, 50);
            this.btnAmbito.TabIndex = 9;
            this.btnAmbito.Text = "Gestionar Ámbitos";
            this.btnAmbito.UseVisualStyleBackColor = true;
            this.btnAmbito.Click += new System.EventHandler(this.btnAmbito_Click);
            // 
            // frmAsignacionAT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1063, 605);
            this.Controls.Add(this.btnAmbito);
            this.Controls.Add(this.btnGuardarAsignacion);
            this.Controls.Add(this.gbHorariosAsignados);
            this.Controls.Add(this.gbDefinirHorario);
            this.Controls.Add(this.gbDetalles);
            this.Controls.Add(this.gbBuscarPaciente);
            this.Controls.Add(this.panelTopBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAsignacionAT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAsignarAT";
            this.Load += new System.EventHandler(this.frmAsignarAT_Load);
            this.panelTopBar.ResumeLayout(false);
            this.panelTopBar.PerformLayout();
            this.gbBuscarPaciente.ResumeLayout(false);
            this.gbBuscarPaciente.PerformLayout();
            this.gbDetalles.ResumeLayout(false);
            this.gbDetalles.PerformLayout();
            this.gbDefinirHorario.ResumeLayout(false);
            this.gbDefinirHorario.PerformLayout();
            this.gbHorariosAsignados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTopBar;
        private System.Windows.Forms.Label lblTituloForm;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.GroupBox gbBuscarPaciente;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBuscarPaciente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPacienteSeleccionado;
        private System.Windows.Forms.GroupBox gbDetalles;
        private System.Windows.Forms.ComboBox cmbAmbito;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbProfesional;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbDefinirHorario;
        private System.Windows.Forms.ComboBox cmbDiaSemana;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker timeInicio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker timeFin;
        private System.Windows.Forms.Button btnAgregarHorario;
        private System.Windows.Forms.GroupBox gbHorariosAsignados;
        private System.Windows.Forms.DataGridView dgvHorarios;
        private System.Windows.Forms.Button btnEliminarHorario;
        private System.Windows.Forms.Button btnGuardarAsignacion;
        private System.Windows.Forms.Button btnAmbito;
    }
}