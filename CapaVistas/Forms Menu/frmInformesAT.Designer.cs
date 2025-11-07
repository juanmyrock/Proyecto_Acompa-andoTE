namespace CapaVistas.Forms_Menu
{
    partial class frmInformesAT
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtAcompaniante = new System.Windows.Forms.TextBox();
            this.txtBusquedaPaciente = new System.Windows.Forms.TextBox();
            this.lblAcompañante = new System.Windows.Forms.Label();
            this.lblDNI = new System.Windows.Forms.Label();
            this.dtpMesInforme = new System.Windows.Forms.DateTimePicker();
            this.lblMes = new System.Windows.Forms.Label();
            this.txtInforme = new System.Windows.Forms.TextBox();
            this.lblInforme = new System.Windows.Forms.Label();
            this.btnGuardarInforme = new System.Windows.Forms.Button();
            this.lblApeNom = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblHorasAsignadas = new System.Windows.Forms.Label();
            this.lblHoras = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.lblEdad = new System.Windows.Forms.Label();
            this.lblFechaDeNacimiento = new System.Windows.Forms.Label();
            this.lblDiagnostico = new System.Windows.Forms.Label();
            this.lblPrestador = new System.Windows.Forms.Label();
            this.lblPrestacion = new System.Windows.Forms.Label();
            this.lblFechaDeNacimientoEscrito = new System.Windows.Forms.Label();
            this.lblEdadEscrita = new System.Windows.Forms.Label();
            this.lblDiagnosticoEscrito = new System.Windows.Forms.Label();
            this.lblPrestadorEscrito = new System.Windows.Forms.Label();
            this.lblPrestacionEscrita = new System.Windows.Forms.Label();
            this.btnLimpiarCampos = new System.Windows.Forms.Button();
            this.btnExportarPDF = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtAcompaniante
            // 
            this.txtAcompaniante.Location = new System.Drawing.Point(13, 393);
            this.txtAcompaniante.Name = "txtAcompaniante";
            this.txtAcompaniante.Size = new System.Drawing.Size(179, 20);
            this.txtAcompaniante.TabIndex = 0;
            // 
            // txtBusquedaPaciente
            // 
            this.txtBusquedaPaciente.Location = new System.Drawing.Point(13, 31);
            this.txtBusquedaPaciente.Name = "txtBusquedaPaciente";
            this.txtBusquedaPaciente.Size = new System.Drawing.Size(179, 20);
            this.txtBusquedaPaciente.TabIndex = 0;
            this.txtBusquedaPaciente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBusquedaPaciente_KeyPress);
            // 
            // lblAcompañante
            // 
            this.lblAcompañante.AutoSize = true;
            this.lblAcompañante.Font = new System.Drawing.Font("Bahnschrift", 9.75F);
            this.lblAcompañante.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblAcompañante.Location = new System.Drawing.Point(10, 373);
            this.lblAcompañante.Name = "lblAcompañante";
            this.lblAcompañante.Size = new System.Drawing.Size(88, 16);
            this.lblAcompañante.TabIndex = 3;
            this.lblAcompañante.Text = "Acompañante:";
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Font = new System.Drawing.Font("Bahnschrift", 9.75F);
            this.lblDNI.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblDNI.Location = new System.Drawing.Point(11, 12);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(84, 16);
            this.lblDNI.TabIndex = 4;
            this.lblDNI.Text = "DNI Paciente:";
            // 
            // dtpMesInforme
            // 
            this.dtpMesInforme.Location = new System.Drawing.Point(13, 81);
            this.dtpMesInforme.Name = "dtpMesInforme";
            this.dtpMesInforme.Size = new System.Drawing.Size(179, 20);
            this.dtpMesInforme.TabIndex = 5;
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Font = new System.Drawing.Font("Bahnschrift", 9.75F);
            this.lblMes.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblMes.Location = new System.Drawing.Point(10, 62);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(104, 16);
            this.lblMes.TabIndex = 6;
            this.lblMes.Text = "Mes del Informe:";
            // 
            // txtInforme
            // 
            this.txtInforme.Location = new System.Drawing.Point(424, 31);
            this.txtInforme.Multiline = true;
            this.txtInforme.Name = "txtInforme";
            this.txtInforme.Size = new System.Drawing.Size(539, 513);
            this.txtInforme.TabIndex = 7;
            // 
            // lblInforme
            // 
            this.lblInforme.AutoSize = true;
            this.lblInforme.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInforme.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblInforme.Location = new System.Drawing.Point(420, 5);
            this.lblInforme.Name = "lblInforme";
            this.lblInforme.Size = new System.Drawing.Size(214, 23);
            this.lblInforme.TabIndex = 8;
            this.lblInforme.Text = "Informe de seguimiento:";
            // 
            // btnGuardarInforme
            // 
            this.btnGuardarInforme.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarInforme.FlatAppearance.BorderColor = System.Drawing.Color.LawnGreen;
            this.btnGuardarInforme.FlatAppearance.BorderSize = 2;
            this.btnGuardarInforme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarInforme.Font = new System.Drawing.Font("Sans Serif Collection", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarInforme.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnGuardarInforme.Location = new System.Drawing.Point(93, 442);
            this.btnGuardarInforme.Name = "btnGuardarInforme";
            this.btnGuardarInforme.Size = new System.Drawing.Size(210, 41);
            this.btnGuardarInforme.TabIndex = 2;
            this.btnGuardarInforme.Text = "Guardar Informe";
            this.btnGuardarInforme.UseVisualStyleBackColor = true;
            this.btnGuardarInforme.Click += new System.EventHandler(this.btnGuardarInforme_Click);
            // 
            // lblApeNom
            // 
            this.lblApeNom.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApeNom.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblApeNom.Location = new System.Drawing.Point(12, 104);
            this.lblApeNom.Name = "lblApeNom";
            this.lblApeNom.Size = new System.Drawing.Size(377, 23);
            this.lblApeNom.TabIndex = 11;
            this.lblApeNom.Text = "Nombre Paciente:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(198, 30);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(106, 23);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar Paciente";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblHorasAsignadas
            // 
            this.lblHorasAsignadas.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHorasAsignadas.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblHorasAsignadas.Location = new System.Drawing.Point(12, 137);
            this.lblHorasAsignadas.Name = "lblHorasAsignadas";
            this.lblHorasAsignadas.Size = new System.Drawing.Size(139, 23);
            this.lblHorasAsignadas.TabIndex = 13;
            this.lblHorasAsignadas.Text = "Horas Asignadas:";
            // 
            // lblHoras
            // 
            this.lblHoras.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoras.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblHoras.Location = new System.Drawing.Point(147, 137);
            this.lblHoras.Name = "lblHoras";
            this.lblHoras.Size = new System.Drawing.Size(126, 23);
            this.lblHoras.TabIndex = 14;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderColor = System.Drawing.Color.LawnGreen;
            this.btnActualizar.FlatAppearance.BorderSize = 2;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Sans Serif Collection", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnActualizar.Location = new System.Drawing.Point(93, 442);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(210, 41);
            this.btnActualizar.TabIndex = 3;
            this.btnActualizar.Text = "Actualizar Informe";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Visible = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // lblEdad
            // 
            this.lblEdad.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEdad.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblEdad.Location = new System.Drawing.Point(12, 198);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(139, 23);
            this.lblEdad.TabIndex = 15;
            this.lblEdad.Text = "Edad:";
            // 
            // lblFechaDeNacimiento
            // 
            this.lblFechaDeNacimiento.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaDeNacimiento.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblFechaDeNacimiento.Location = new System.Drawing.Point(11, 170);
            this.lblFechaDeNacimiento.Name = "lblFechaDeNacimiento";
            this.lblFechaDeNacimiento.Size = new System.Drawing.Size(167, 23);
            this.lblFechaDeNacimiento.TabIndex = 16;
            this.lblFechaDeNacimiento.Text = "Fecha de Nacimiento: ";
            // 
            // lblDiagnostico
            // 
            this.lblDiagnostico.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiagnostico.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblDiagnostico.Location = new System.Drawing.Point(12, 276);
            this.lblDiagnostico.Name = "lblDiagnostico";
            this.lblDiagnostico.Size = new System.Drawing.Size(139, 23);
            this.lblDiagnostico.TabIndex = 17;
            this.lblDiagnostico.Text = "Diagnostico: ";
            // 
            // lblPrestador
            // 
            this.lblPrestador.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrestador.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblPrestador.Location = new System.Drawing.Point(12, 222);
            this.lblPrestador.Name = "lblPrestador";
            this.lblPrestador.Size = new System.Drawing.Size(139, 23);
            this.lblPrestador.TabIndex = 18;
            this.lblPrestador.Text = "Prestador: ";
            // 
            // lblPrestacion
            // 
            this.lblPrestacion.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrestacion.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblPrestacion.Location = new System.Drawing.Point(12, 247);
            this.lblPrestacion.Name = "lblPrestacion";
            this.lblPrestacion.Size = new System.Drawing.Size(139, 23);
            this.lblPrestacion.TabIndex = 19;
            this.lblPrestacion.Text = "Prestación: ";
            // 
            // lblFechaDeNacimientoEscrito
            // 
            this.lblFechaDeNacimientoEscrito.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaDeNacimientoEscrito.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblFechaDeNacimientoEscrito.Location = new System.Drawing.Point(177, 170);
            this.lblFechaDeNacimientoEscrito.Name = "lblFechaDeNacimientoEscrito";
            this.lblFechaDeNacimientoEscrito.Size = new System.Drawing.Size(126, 23);
            this.lblFechaDeNacimientoEscrito.TabIndex = 20;
            // 
            // lblEdadEscrita
            // 
            this.lblEdadEscrita.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEdadEscrita.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblEdadEscrita.Location = new System.Drawing.Point(65, 198);
            this.lblEdadEscrita.Name = "lblEdadEscrita";
            this.lblEdadEscrita.Size = new System.Drawing.Size(126, 23);
            this.lblEdadEscrita.TabIndex = 21;
            // 
            // lblDiagnosticoEscrito
            // 
            this.lblDiagnosticoEscrito.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiagnosticoEscrito.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblDiagnosticoEscrito.Location = new System.Drawing.Point(109, 276);
            this.lblDiagnosticoEscrito.Name = "lblDiagnosticoEscrito";
            this.lblDiagnosticoEscrito.Size = new System.Drawing.Size(309, 96);
            this.lblDiagnosticoEscrito.TabIndex = 22;
            // 
            // lblPrestadorEscrito
            // 
            this.lblPrestadorEscrito.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrestadorEscrito.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblPrestadorEscrito.Location = new System.Drawing.Point(109, 219);
            this.lblPrestadorEscrito.Name = "lblPrestadorEscrito";
            this.lblPrestadorEscrito.Size = new System.Drawing.Size(309, 23);
            this.lblPrestadorEscrito.TabIndex = 23;
            // 
            // lblPrestacionEscrita
            // 
            this.lblPrestacionEscrita.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrestacionEscrita.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblPrestacionEscrita.Location = new System.Drawing.Point(108, 247);
            this.lblPrestacionEscrita.Name = "lblPrestacionEscrita";
            this.lblPrestacionEscrita.Size = new System.Drawing.Size(310, 23);
            this.lblPrestacionEscrita.TabIndex = 24;
            // 
            // btnLimpiarCampos
            // 
            this.btnLimpiarCampos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiarCampos.FlatAppearance.BorderColor = System.Drawing.Color.LawnGreen;
            this.btnLimpiarCampos.FlatAppearance.BorderSize = 2;
            this.btnLimpiarCampos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarCampos.Font = new System.Drawing.Font("Sans Serif Collection", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarCampos.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnLimpiarCampos.Location = new System.Drawing.Point(12, 503);
            this.btnLimpiarCampos.Name = "btnLimpiarCampos";
            this.btnLimpiarCampos.Size = new System.Drawing.Size(139, 41);
            this.btnLimpiarCampos.TabIndex = 25;
            this.btnLimpiarCampos.Text = "Limpiar Campos";
            this.btnLimpiarCampos.UseVisualStyleBackColor = true;
            this.btnLimpiarCampos.Click += new System.EventHandler(this.btnLimpiarCampos_Click);
            // 
            // btnExportarPDF
            // 
            this.btnExportarPDF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportarPDF.FlatAppearance.BorderColor = System.Drawing.Color.LawnGreen;
            this.btnExportarPDF.FlatAppearance.BorderSize = 2;
            this.btnExportarPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarPDF.Font = new System.Drawing.Font("Sans Serif Collection", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarPDF.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnExportarPDF.Location = new System.Drawing.Point(250, 503);
            this.btnExportarPDF.Name = "btnExportarPDF";
            this.btnExportarPDF.Size = new System.Drawing.Size(139, 41);
            this.btnExportarPDF.TabIndex = 26;
            this.btnExportarPDF.Text = "Exportar PDF";
            this.btnExportarPDF.UseVisualStyleBackColor = true;
            this.btnExportarPDF.Click += new System.EventHandler(this.btnExportarPDF_Click);
            // 
            // frmInformesAT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1047, 566);
            this.Controls.Add(this.btnExportarPDF);
            this.Controls.Add(this.btnLimpiarCampos);
            this.Controls.Add(this.lblPrestacionEscrita);
            this.Controls.Add(this.lblPrestadorEscrito);
            this.Controls.Add(this.lblDiagnosticoEscrito);
            this.Controls.Add(this.lblEdadEscrita);
            this.Controls.Add(this.lblFechaDeNacimientoEscrito);
            this.Controls.Add(this.lblPrestacion);
            this.Controls.Add(this.lblPrestador);
            this.Controls.Add(this.lblDiagnostico);
            this.Controls.Add(this.lblFechaDeNacimiento);
            this.Controls.Add(this.lblEdad);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.lblHoras);
            this.Controls.Add(this.lblHorasAsignadas);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblApeNom);
            this.Controls.Add(this.btnGuardarInforme);
            this.Controls.Add(this.lblInforme);
            this.Controls.Add(this.txtInforme);
            this.Controls.Add(this.lblMes);
            this.Controls.Add(this.dtpMesInforme);
            this.Controls.Add(this.lblDNI);
            this.Controls.Add(this.lblAcompañante);
            this.Controls.Add(this.txtBusquedaPaciente);
            this.Controls.Add(this.txtAcompaniante);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmInformesAT";
            this.Text = "frmInformesAT";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAcompaniante;
        private System.Windows.Forms.TextBox txtBusquedaPaciente;
        private System.Windows.Forms.Label lblAcompañante;
        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.DateTimePicker dtpMesInforme;
        private System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.TextBox txtInforme;
        private System.Windows.Forms.Label lblInforme;
        private System.Windows.Forms.Button btnGuardarInforme;
        private System.Windows.Forms.Label lblApeNom;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblHorasAsignadas;
        private System.Windows.Forms.Label lblHoras;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.Label lblFechaDeNacimiento;
        private System.Windows.Forms.Label lblDiagnostico;
        private System.Windows.Forms.Label lblPrestador;
        private System.Windows.Forms.Label lblPrestacion;
        private System.Windows.Forms.Label lblFechaDeNacimientoEscrito;
        private System.Windows.Forms.Label lblEdadEscrita;
        private System.Windows.Forms.Label lblDiagnosticoEscrito;
        private System.Windows.Forms.Label lblPrestadorEscrito;
        private System.Windows.Forms.Label lblPrestacionEscrita;
        private System.Windows.Forms.Button btnLimpiarCampos;
        private System.Windows.Forms.Button btnExportarPDF;
    }
}