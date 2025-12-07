namespace CapaVistas.Forms_Menu // O tu namespace
{
    partial class frmGestionReportes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTopBar = new System.Windows.Forms.Panel();
            this.lblTituloForm = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.btnGenerarReporte = new System.Windows.Forms.Button();
            this.pnlFiltroFecha = new System.Windows.Forms.Panel();
            this.lblFechaHasta = new System.Windows.Forms.Label();
            this.dateHasta = new System.Windows.Forms.DateTimePicker();
            this.lblFechaDesde = new System.Windows.Forms.Label();
            this.dateDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpMesInforme = new System.Windows.Forms.DateTimePicker();
            this.pnlFiltroPaciente = new System.Windows.Forms.Panel();
            this.btnBuscarPaciente = new System.Windows.Forms.Button();
            this.txtBuscarPaciente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTipoReporte = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTituloReporte = new System.Windows.Forms.Label();
            this.dgvReporte = new System.Windows.Forms.DataGridView();
            this.btnExportarPDF = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.txtInforme = new System.Windows.Forms.TextBox();
            this.panelTopBar.SuspendLayout();
            this.gbFiltros.SuspendLayout();
            this.pnlFiltroFecha.SuspendLayout();
            this.pnlFiltroPaciente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).BeginInit();
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
            this.lblTituloForm.Size = new System.Drawing.Size(123, 16);
            this.lblTituloForm.TabIndex = 1;
            this.lblTituloForm.Text = "Gestión de Reportes";
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
            this.lblClose.Visible = false;
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.btnGenerarReporte);
            this.gbFiltros.Controls.Add(this.pnlFiltroFecha);
            this.gbFiltros.Controls.Add(this.pnlFiltroPaciente);
            this.gbFiltros.Controls.Add(this.cmbTipoReporte);
            this.gbFiltros.Controls.Add(this.label1);
            this.gbFiltros.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFiltros.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.gbFiltros.Location = new System.Drawing.Point(25, 50);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(280, 530);
            this.gbFiltros.TabIndex = 3;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "Filtros y Consultas";
            // 
            // btnGenerarReporte
            // 
            this.btnGenerarReporte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerarReporte.FlatAppearance.BorderColor = System.Drawing.Color.Aqua;
            this.btnGenerarReporte.FlatAppearance.BorderSize = 2;
            this.btnGenerarReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarReporte.Font = new System.Drawing.Font("Sans Serif Collection", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarReporte.Location = new System.Drawing.Point(40, 460);
            this.btnGenerarReporte.Name = "btnGenerarReporte";
            this.btnGenerarReporte.Size = new System.Drawing.Size(200, 50);
            this.btnGenerarReporte.TabIndex = 4;
            this.btnGenerarReporte.Text = "Generar Reporte";
            this.btnGenerarReporte.UseVisualStyleBackColor = true;
            this.btnGenerarReporte.Click += new System.EventHandler(this.btnGenerarReporte_Click);
            // 
            // pnlFiltroFecha
            // 
            this.pnlFiltroFecha.Controls.Add(this.lblFechaHasta);
            this.pnlFiltroFecha.Controls.Add(this.dateHasta);
            this.pnlFiltroFecha.Controls.Add(this.lblFechaDesde);
            this.pnlFiltroFecha.Controls.Add(this.dateDesde);
            this.pnlFiltroFecha.Controls.Add(this.dtpMesInforme);
            this.pnlFiltroFecha.Location = new System.Drawing.Point(10, 200);
            this.pnlFiltroFecha.Name = "pnlFiltroFecha";
            this.pnlFiltroFecha.Size = new System.Drawing.Size(260, 120);
            this.pnlFiltroFecha.TabIndex = 3;
            this.pnlFiltroFecha.Visible = false;
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Location = new System.Drawing.Point(10, 65);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(75, 14);
            this.lblFechaHasta.TabIndex = 3;
            this.lblFechaHasta.Text = "Fecha Hasta:";
            // 
            // dateHasta
            // 
            this.dateHasta.Location = new System.Drawing.Point(10, 85);
            this.dateHasta.Name = "dateHasta";
            this.dateHasta.Size = new System.Drawing.Size(240, 22);
            this.dateHasta.TabIndex = 2;
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.Location = new System.Drawing.Point(10, 10);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(77, 14);
            this.lblFechaDesde.TabIndex = 1;
            this.lblFechaDesde.Text = "Fecha Desde:";
            // 
            // dateDesde
            // 
            this.dateDesde.Location = new System.Drawing.Point(10, 33);
            this.dateDesde.Name = "dateDesde";
            this.dateDesde.Size = new System.Drawing.Size(240, 22);
            this.dateDesde.TabIndex = 0;
            // 
            // dtpMesInforme
            // 
            this.dtpMesInforme.Location = new System.Drawing.Point(10, 33);
            this.dtpMesInforme.Name = "dtpMesInforme";
            this.dtpMesInforme.Size = new System.Drawing.Size(240, 22);
            this.dtpMesInforme.TabIndex = 6;
            this.dtpMesInforme.Visible = false;
            // 
            // pnlFiltroPaciente
            // 
            this.pnlFiltroPaciente.Controls.Add(this.btnBuscarPaciente);
            this.pnlFiltroPaciente.Controls.Add(this.txtBuscarPaciente);
            this.pnlFiltroPaciente.Controls.Add(this.label2);
            this.pnlFiltroPaciente.Location = new System.Drawing.Point(10, 90);
            this.pnlFiltroPaciente.Name = "pnlFiltroPaciente";
            this.pnlFiltroPaciente.Size = new System.Drawing.Size(260, 100);
            this.pnlFiltroPaciente.TabIndex = 2;
            this.pnlFiltroPaciente.Visible = false;
            // 
            // btnBuscarPaciente
            // 
            this.btnBuscarPaciente.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnBuscarPaciente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarPaciente.Location = new System.Drawing.Point(175, 55);
            this.btnBuscarPaciente.Name = "btnBuscarPaciente";
            this.btnBuscarPaciente.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarPaciente.TabIndex = 2;
            this.btnBuscarPaciente.Text = "Buscar";
            this.btnBuscarPaciente.UseVisualStyleBackColor = true;
            this.btnBuscarPaciente.Click += new System.EventHandler(this.btnBuscarPaciente_Click);
            // 
            // txtBuscarPaciente
            // 
            this.txtBuscarPaciente.Location = new System.Drawing.Point(10, 30);
            this.txtBuscarPaciente.Name = "txtBuscarPaciente";
            this.txtBuscarPaciente.Size = new System.Drawing.Size(240, 22);
            this.txtBuscarPaciente.TabIndex = 1;
            this.txtBuscarPaciente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscarPaciente_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "Buscar Paciente (DNI o Apellido):";
            // 
            // cmbTipoReporte
            // 
            this.cmbTipoReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoReporte.FormattingEnabled = true;
            this.cmbTipoReporte.Items.AddRange(new object[] {
            "Log de Auditoría",
            "Informes por Paciente",
            "Trámites por Paciente",
            "Pagos por Paciente"});
            this.cmbTipoReporte.Location = new System.Drawing.Point(20, 50);
            this.cmbTipoReporte.Name = "cmbTipoReporte";
            this.cmbTipoReporte.Size = new System.Drawing.Size(240, 22);
            this.cmbTipoReporte.TabIndex = 1;
            this.cmbTipoReporte.SelectedIndexChanged += new System.EventHandler(this.cmbTipoReporte_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione un Reporte:";
            // 
            // lblTituloReporte
            // 
            this.lblTituloReporte.AutoSize = true;
            this.lblTituloReporte.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloReporte.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTituloReporte.Location = new System.Drawing.Point(325, 50);
            this.lblTituloReporte.Name = "lblTituloReporte";
            this.lblTituloReporte.Size = new System.Drawing.Size(284, 23);
            this.lblTituloReporte.TabIndex = 4;
            this.lblTituloReporte.Text = "Visor de Reportes: Sin Selección";
            // 
            // dgvReporte
            // 
            this.dgvReporte.AllowUserToAddRows = false;
            this.dgvReporte.AllowUserToDeleteRows = false;
            this.dgvReporte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReporte.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.dgvReporte.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReporte.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Bahnschrift", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReporte.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReporte.EnableHeadersVisualStyles = false;
            this.dgvReporte.GridColor = System.Drawing.Color.Teal;
            this.dgvReporte.Location = new System.Drawing.Point(325, 80);
            this.dgvReporte.Name = "dgvReporte";
            this.dgvReporte.ReadOnly = true;
            this.dgvReporte.RowHeadersVisible = false;
            this.dgvReporte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReporte.Size = new System.Drawing.Size(715, 450);
            this.dgvReporte.TabIndex = 5;
            // 
            // btnExportarPDF
            // 
            this.btnExportarPDF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportarPDF.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnExportarPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarPDF.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarPDF.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnExportarPDF.Location = new System.Drawing.Point(880, 545);
            this.btnExportarPDF.Name = "btnExportarPDF";
            this.btnExportarPDF.Size = new System.Drawing.Size(160, 35);
            this.btnExportarPDF.TabIndex = 6;
            this.btnExportarPDF.Text = "Exportar a PDF";
            this.btnExportarPDF.UseVisualStyleBackColor = true;
            this.btnExportarPDF.Click += new System.EventHandler(this.btnExportarPDF_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnImprimir.Location = new System.Drawing.Point(880, 545);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(160, 35);
            this.btnImprimir.TabIndex = 7;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // txtInforme
            // 
            this.txtInforme.Enabled = false;
            this.txtInforme.Location = new System.Drawing.Point(325, 80);
            this.txtInforme.Multiline = true;
            this.txtInforme.Name = "txtInforme";
            this.txtInforme.Size = new System.Drawing.Size(715, 450);
            this.txtInforme.TabIndex = 8;
            this.txtInforme.Visible = false;
            // 
            // frmGestionReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1063, 605);
            this.Controls.Add(this.btnExportarPDF);
            this.Controls.Add(this.dgvReporte);
            this.Controls.Add(this.lblTituloReporte);
            this.Controls.Add(this.gbFiltros);
            this.Controls.Add(this.panelTopBar);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.txtInforme);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmGestionReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Reportes";
            this.panelTopBar.ResumeLayout(false);
            this.panelTopBar.PerformLayout();
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.pnlFiltroFecha.ResumeLayout(false);
            this.pnlFiltroFecha.PerformLayout();
            this.pnlFiltroPaciente.ResumeLayout(false);
            this.pnlFiltroPaciente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTopBar;
        private System.Windows.Forms.Label lblTituloForm;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.GroupBox gbFiltros;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTipoReporte;
        private System.Windows.Forms.Panel pnlFiltroPaciente;
        private System.Windows.Forms.Button btnBuscarPaciente;
        private System.Windows.Forms.TextBox txtBuscarPaciente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlFiltroFecha;
        private System.Windows.Forms.Label lblFechaHasta;
        private System.Windows.Forms.DateTimePicker dateHasta;
        private System.Windows.Forms.Label lblFechaDesde;
        private System.Windows.Forms.DateTimePicker dateDesde;
        private System.Windows.Forms.Button btnGenerarReporte;
        private System.Windows.Forms.Label lblTituloReporte;
        private System.Windows.Forms.DataGridView dgvReporte;
        private System.Windows.Forms.Button btnExportarPDF;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.TextBox txtInforme;
        private System.Windows.Forms.DateTimePicker dtpMesInforme;
    }
}