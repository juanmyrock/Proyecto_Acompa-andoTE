namespace CapaVistas.Forms_Menu
{
    partial class frmGestionTurnos
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.cmbMedico = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbEspecialidad = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvAgenda = new System.Windows.Forms.DataGridView();
            this.colHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblAgenda = new System.Windows.Forms.Label();
            this.gbNuevoTurno = new System.Windows.Forms.GroupBox();
            this.btnBuscarPaciente = new System.Windows.Forms.Button();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblNombrePaciente = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbHorarios = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDniPaciente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnConfirmarTurno = new System.Windows.Forms.Button();
            this.btnCancelarTurno = new System.Windows.Forms.Button();
            this.gbFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgenda)).BeginInit();
            this.gbNuevoTurno.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Bahnschrift", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitulo.Location = new System.Drawing.Point(26, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(181, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Gestión de Turnos";
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.monthCalendar);
            this.gbFiltros.Controls.Add(this.cmbMedico);
            this.gbFiltros.Controls.Add(this.label2);
            this.gbFiltros.Controls.Add(this.cmbEspecialidad);
            this.gbFiltros.Controls.Add(this.label1);
            this.gbFiltros.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFiltros.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.gbFiltros.Location = new System.Drawing.Point(31, 37);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(280, 310);
            this.gbFiltros.TabIndex = 1;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "Selección";
            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(26, 136);
            this.monthCalendar.MaxSelectionCount = 1;
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 4;
            this.monthCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateChanged);
            // 
            // cmbMedico
            // 
            this.cmbMedico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMedico.FormattingEnabled = true;
            this.cmbMedico.Location = new System.Drawing.Point(26, 95);
            this.cmbMedico.Name = "cmbMedico";
            this.cmbMedico.Size = new System.Drawing.Size(227, 24);
            this.cmbMedico.TabIndex = 3;
            this.cmbMedico.SelectedIndexChanged += new System.EventHandler(this.cmbMedico_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Seleccionar Médico:";
            // 
            // cmbEspecialidad
            // 
            this.cmbEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEspecialidad.FormattingEnabled = true;
            this.cmbEspecialidad.Location = new System.Drawing.Point(26, 45);
            this.cmbEspecialidad.Name = "cmbEspecialidad";
            this.cmbEspecialidad.Size = new System.Drawing.Size(227, 24);
            this.cmbEspecialidad.TabIndex = 1;
            this.cmbEspecialidad.SelectedIndexChanged += new System.EventHandler(this.cmbEspecialidad_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccionar Especialidad:";
            // 
            // dgvAgenda
            // 
            this.dgvAgenda.AllowUserToAddRows = false;
            this.dgvAgenda.AllowUserToDeleteRows = false;
            this.dgvAgenda.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAgenda.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.dgvAgenda.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAgenda.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAgenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAgenda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHora,
            this.colPaciente,
            this.colEstado});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Bahnschrift", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAgenda.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAgenda.Location = new System.Drawing.Point(337, 30);
            this.dgvAgenda.MultiSelect = false;
            this.dgvAgenda.Name = "dgvAgenda";
            this.dgvAgenda.ReadOnly = true;
            this.dgvAgenda.RowHeadersVisible = false;
            this.dgvAgenda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAgenda.Size = new System.Drawing.Size(655, 340);
            this.dgvAgenda.TabIndex = 2;
            this.dgvAgenda.SelectionChanged += new System.EventHandler(this.dgvAgenda_SelectionChanged);
            // 
            // colHora
            // 
            this.colHora.FillWeight = 40F;
            this.colHora.HeaderText = "Hora";
            this.colHora.Name = "colHora";
            this.colHora.ReadOnly = true;
            // 
            // colPaciente
            // 
            this.colPaciente.FillWeight = 120F;
            this.colPaciente.HeaderText = "Paciente";
            this.colPaciente.Name = "colPaciente";
            this.colPaciente.ReadOnly = true;
            // 
            // colEstado
            // 
            this.colEstado.FillWeight = 60F;
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            // 
            // lblAgenda
            // 
            this.lblAgenda.AutoSize = true;
            this.lblAgenda.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgenda.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblAgenda.Location = new System.Drawing.Point(333, 8);
            this.lblAgenda.Name = "lblAgenda";
            this.lblAgenda.Size = new System.Drawing.Size(227, 19);
            this.lblAgenda.TabIndex = 3;
            this.lblAgenda.Text = "Agenda del día: (Seleccione...)";
            // 
            // gbNuevoTurno
            // 
            this.gbNuevoTurno.Controls.Add(this.btnBuscarPaciente);
            this.gbNuevoTurno.Controls.Add(this.txtObservaciones);
            this.gbNuevoTurno.Controls.Add(this.label6);
            this.gbNuevoTurno.Controls.Add(this.lblNombrePaciente);
            this.gbNuevoTurno.Controls.Add(this.cmbHorarios);
            this.gbNuevoTurno.Controls.Add(this.label4);
            this.gbNuevoTurno.Controls.Add(this.label5);
            this.gbNuevoTurno.Controls.Add(this.txtDniPaciente);
            this.gbNuevoTurno.Controls.Add(this.label3);
            this.gbNuevoTurno.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbNuevoTurno.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.gbNuevoTurno.Location = new System.Drawing.Point(31, 376);
            this.gbNuevoTurno.Name = "gbNuevoTurno";
            this.gbNuevoTurno.Size = new System.Drawing.Size(960, 125);
            this.gbNuevoTurno.TabIndex = 4;
            this.gbNuevoTurno.TabStop = false;
            this.gbNuevoTurno.Text = "Asignar / Modificar Turno";
            // 
            // btnBuscarPaciente
            // 
            this.btnBuscarPaciente.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnBuscarPaciente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarPaciente.Font = new System.Drawing.Font("Bahnschrift", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarPaciente.Location = new System.Drawing.Point(206, 40);
            this.btnBuscarPaciente.Name = "btnBuscarPaciente";
            this.btnBuscarPaciente.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarPaciente.TabIndex = 8;
            this.btnBuscarPaciente.Text = "Buscar";
            this.btnBuscarPaciente.UseVisualStyleBackColor = true;
            this.btnBuscarPaciente.Click += new System.EventHandler(this.btnBuscarPaciente_Click);
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(399, 35);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(534, 80);
            this.txtObservaciones.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(396, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Observaciones:";
            // 
            // lblNombrePaciente
            // 
            this.lblNombrePaciente.AutoSize = true;
            this.lblNombrePaciente.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombrePaciente.Location = new System.Drawing.Point(253, 15);
            this.lblNombrePaciente.Name = "lblNombrePaciente";
            this.lblNombrePaciente.Size = new System.Drawing.Size(118, 16);
            this.lblNombrePaciente.TabIndex = 5;
            this.lblNombrePaciente.Text = "(No seleccionado)...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(188, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Paciente:";
            // 
            // cmbHorarios
            // 
            this.cmbHorarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHorarios.FormattingEnabled = true;
            this.cmbHorarios.Location = new System.Drawing.Point(15, 91);
            this.cmbHorarios.Name = "cmbHorarios";
            this.cmbHorarios.Size = new System.Drawing.Size(185, 24);
            this.cmbHorarios.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Horario disponible:";
            // 
            // txtDniPaciente
            // 
            this.txtDniPaciente.Location = new System.Drawing.Point(15, 41);
            this.txtDniPaciente.Name = "txtDniPaciente";
            this.txtDniPaciente.Size = new System.Drawing.Size(185, 23);
            this.txtDniPaciente.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "DNI del Paciente:";
            // 
            // btnConfirmarTurno
            // 
            this.btnConfirmarTurno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmarTurno.FlatAppearance.BorderColor = System.Drawing.Color.LawnGreen;
            this.btnConfirmarTurno.FlatAppearance.BorderSize = 2;
            this.btnConfirmarTurno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmarTurno.Font = new System.Drawing.Font("Sans Serif Collection", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmarTurno.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnConfirmarTurno.Location = new System.Drawing.Point(527, 507);
            this.btnConfirmarTurno.Name = "btnConfirmarTurno";
            this.btnConfirmarTurno.Size = new System.Drawing.Size(210, 41);
            this.btnConfirmarTurno.TabIndex = 5;
            this.btnConfirmarTurno.Text = "Confirmar Turno";
            this.btnConfirmarTurno.UseVisualStyleBackColor = true;
            this.btnConfirmarTurno.Click += new System.EventHandler(this.btnConfirmarTurno_Click);
            // 
            // btnCancelarTurno
            // 
            this.btnCancelarTurno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarTurno.FlatAppearance.BorderColor = System.Drawing.Color.Tomato;
            this.btnCancelarTurno.FlatAppearance.BorderSize = 2;
            this.btnCancelarTurno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarTurno.Font = new System.Drawing.Font("Sans Serif Collection", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarTurno.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnCancelarTurno.Location = new System.Drawing.Point(770, 507);
            this.btnCancelarTurno.Name = "btnCancelarTurno";
            this.btnCancelarTurno.Size = new System.Drawing.Size(210, 41);
            this.btnCancelarTurno.TabIndex = 6;
            this.btnCancelarTurno.Text = "Cancelar Turno";
            this.btnCancelarTurno.UseVisualStyleBackColor = true;
            this.btnCancelarTurno.Click += new System.EventHandler(this.btnCancelarTurno_Click);
            // 
            // frmGestionTurnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1022, 561);
            this.Controls.Add(this.btnCancelarTurno);
            this.Controls.Add(this.btnConfirmarTurno);
            this.Controls.Add(this.gbNuevoTurno);
            this.Controls.Add(this.lblAgenda);
            this.Controls.Add(this.dgvAgenda);
            this.Controls.Add(this.gbFiltros);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmGestionTurnos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Turnos Médicos";
            this.Load += new System.EventHandler(this.frmGestionTurnos_Load);
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgenda)).EndInit();
            this.gbNuevoTurno.ResumeLayout(false);
            this.gbNuevoTurno.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox gbFiltros;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbEspecialidad;
        private System.Windows.Forms.ComboBox cmbMedico;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.DataGridView dgvAgenda;
        private System.Windows.Forms.Label lblAgenda;
        private System.Windows.Forms.GroupBox gbNuevoTurno;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblNombrePaciente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbHorarios;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDniPaciente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnConfirmarTurno;
        private System.Windows.Forms.Button btnCancelarTurno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.Button btnBuscarPaciente;
    }
}