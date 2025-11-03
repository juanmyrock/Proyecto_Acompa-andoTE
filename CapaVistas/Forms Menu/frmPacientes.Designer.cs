namespace CapaVistas.Forms_Menu
{
    partial class frmPacientes  
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
            this.dgvVerPacientes = new System.Windows.Forms.DataGridView();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnCrear = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtNumDomicilio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDiagnostico = new System.Windows.Forms.TextBox();
            this.txtCargaHoraria = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumAfiliado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbObraSocial = new System.Windows.Forms.ComboBox();
            this.lbl = new System.Windows.Forms.Label();
            this.txtCud = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblCud = new System.Windows.Forms.Label();
            this.dateFechaNac = new System.Windows.Forms.DateTimePicker();
            this.label29 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.txtAmbito = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDomicilio = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txtDniPaciente = new System.Windows.Forms.TextBox();
            this.txtDniTitular = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.cmbSexo = new System.Windows.Forms.ComboBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombrePac = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.lblDniPac = new System.Windows.Forms.Label();
            this.cmbLocalidad = new System.Windows.Forms.ComboBox();
            this.cmbTipoDNI = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cmbOrden = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnReactivar = new System.Windows.Forms.Button();
            this.txtBusquedaPaciente = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnBuscarDNI = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVerPacientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvVerPacientes
            // 
            this.dgvVerPacientes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVerPacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVerPacientes.Location = new System.Drawing.Point(60, 51);
            this.dgvVerPacientes.MultiSelect = false;
            this.dgvVerPacientes.Name = "dgvVerPacientes";
            this.dgvVerPacientes.ReadOnly = true;
            this.dgvVerPacientes.RowHeadersVisible = false;
            this.dgvVerPacientes.RowHeadersWidth = 47;
            this.dgvVerPacientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVerPacientes.Size = new System.Drawing.Size(952, 218);
            this.dgvVerPacientes.TabIndex = 48;
            this.dgvVerPacientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVerPacientes_CellClick);
            this.dgvVerPacientes.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVerPacientes_RowEnter);
            this.dgvVerPacientes.SelectionChanged += new System.EventHandler(this.dgvVerPacientes_SelectionChanged);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.Image = global::CapaVistas.Properties.Resources.eliminar_logo1;
            this.pictureBox3.ImageLocation = "";
            this.pictureBox3.Location = new System.Drawing.Point(761, 275);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(53, 44);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 56;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox2.Image = global::CapaVistas.Properties.Resources.logo_editar;
            this.pictureBox2.ImageLocation = "";
            this.pictureBox2.Location = new System.Drawing.Point(406, 275);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(53, 44);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 57;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CapaVistas.Properties.Resources.check_logo;
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(76, 275);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 58;
            this.pictureBox1.TabStop = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnEliminar.FlatAppearance.BorderSize = 3;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Sans Serif Collection", 9.749998F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnEliminar.Location = new System.Drawing.Point(814, 275);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(168, 44);
            this.btnEliminar.TabIndex = 55;
            this.btnEliminar.Text = "Eliminar Paciente";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click_1);
            // 
            // btnModificar
            // 
            this.btnModificar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificar.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnModificar.FlatAppearance.BorderSize = 3;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Sans Serif Collection", 9.749998F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnModificar.Location = new System.Drawing.Point(463, 275);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(169, 44);
            this.btnModificar.TabIndex = 54;
            this.btnModificar.Text = "Modificar Paciente";
            this.btnModificar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click_1);
            // 
            // btnCrear
            // 
            this.btnCrear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCrear.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnCrear.FlatAppearance.BorderSize = 3;
            this.btnCrear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrear.Font = new System.Drawing.Font("Sans Serif Collection", 9.749998F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrear.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnCrear.Location = new System.Drawing.Point(123, 275);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(168, 44);
            this.btnCrear.TabIndex = 53;
            this.btnCrear.Text = "Crear Paciente";
            this.btnCrear.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.checkedListBox1);
            this.groupBox2.Controls.Add(this.txtNumDomicilio);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtDiagnostico);
            this.groupBox2.Controls.Add(this.txtCargaHoraria);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtNumAfiliado);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmbObraSocial);
            this.groupBox2.Controls.Add(this.lbl);
            this.groupBox2.Controls.Add(this.txtCud);
            this.groupBox2.Controls.Add(this.txtTelefono);
            this.groupBox2.Controls.Add(this.lblCud);
            this.groupBox2.Controls.Add(this.dateFechaNac);
            this.groupBox2.Controls.Add(this.label29);
            this.groupBox2.Controls.Add(this.label39);
            this.groupBox2.Controls.Add(this.txtAmbito);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtDomicilio);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtEmail);
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Controls.Add(this.txtDniPaciente);
            this.groupBox2.Controls.Add(this.txtDniTitular);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label30);
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Controls.Add(this.cmbSexo);
            this.groupBox2.Controls.Add(this.txtApellido);
            this.groupBox2.Controls.Add(this.label32);
            this.groupBox2.Controls.Add(this.txtNombre);
            this.groupBox2.Controls.Add(this.lblNombrePac);
            this.groupBox2.Controls.Add(this.label34);
            this.groupBox2.Controls.Add(this.lblDniPac);
            this.groupBox2.Controls.Add(this.cmbLocalidad);
            this.groupBox2.Controls.Add(this.cmbTipoDNI);
            this.groupBox2.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Location = new System.Drawing.Point(60, 325);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(952, 278);
            this.groupBox2.TabIndex = 59;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos del Paciente";
            // 
            // txtNumDomicilio
            // 
            this.txtNumDomicilio.Location = new System.Drawing.Point(562, 134);
            this.txtNumDomicilio.Name = "txtNumDomicilio";
            this.txtNumDomicilio.Size = new System.Drawing.Size(134, 22);
            this.txtNumDomicilio.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(498, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 28);
            this.label5.TabIndex = 77;
            this.label5.Text = "Num \r\nDomicilio:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(279, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 14);
            this.label2.TabIndex = 75;
            this.label2.Text = "Diagnostico:";
            // 
            // txtDiagnostico
            // 
            this.txtDiagnostico.Location = new System.Drawing.Point(358, 178);
            this.txtDiagnostico.Multiline = true;
            this.txtDiagnostico.Name = "txtDiagnostico";
            this.txtDiagnostico.Size = new System.Drawing.Size(576, 85);
            this.txtDiagnostico.TabIndex = 19;
            // 
            // txtCargaHoraria
            // 
            this.txtCargaHoraria.Location = new System.Drawing.Point(134, 170);
            this.txtCargaHoraria.Name = "txtCargaHoraria";
            this.txtCargaHoraria.Size = new System.Drawing.Size(121, 22);
            this.txtCargaHoraria.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 28);
            this.label4.TabIndex = 73;
            this.label4.Text = "Carga Horaria\r\n Designada:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtNumAfiliado
            // 
            this.txtNumAfiliado.Location = new System.Drawing.Point(346, 93);
            this.txtNumAfiliado.Name = "txtNumAfiliado";
            this.txtNumAfiliado.Size = new System.Drawing.Size(121, 22);
            this.txtNumAfiliado.TabIndex = 68;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(267, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 14);
            this.label1.TabIndex = 69;
            this.label1.Text = "Num Afiliado:";
            // 
            // cmbObraSocial
            // 
            this.cmbObraSocial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbObraSocial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbObraSocial.FormattingEnabled = true;
            this.cmbObraSocial.Location = new System.Drawing.Point(134, 93);
            this.cmbObraSocial.Name = "cmbObraSocial";
            this.cmbObraSocial.Size = new System.Drawing.Size(121, 22);
            this.cmbObraSocial.TabIndex = 67;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(60, 96);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(71, 14);
            this.lbl.TabIndex = 66;
            this.lbl.Text = "Obra Social:";
            // 
            // txtCud
            // 
            this.txtCud.Location = new System.Drawing.Point(562, 96);
            this.txtCud.Name = "txtCud";
            this.txtCud.Size = new System.Drawing.Size(134, 22);
            this.txtCud.TabIndex = 17;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(783, 58);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(151, 22);
            this.txtTelefono.TabIndex = 13;
            // 
            // lblCud
            // 
            this.lblCud.AutoSize = true;
            this.lblCud.Location = new System.Drawing.Point(523, 99);
            this.lblCud.Name = "lblCud";
            this.lblCud.Size = new System.Drawing.Size(33, 14);
            this.lblCud.TabIndex = 64;
            this.lblCud.Text = "CUD:";
            // 
            // dateFechaNac
            // 
            this.dateFechaNac.CustomFormat = "00/00/0000";
            this.dateFechaNac.Location = new System.Drawing.Point(783, 96);
            this.dateFechaNac.MaxDate = new System.DateTime(2025, 12, 31, 0, 0, 0, 0);
            this.dateFechaNac.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dateFechaNac.Name = "dateFechaNac";
            this.dateFechaNac.Size = new System.Drawing.Size(151, 22);
            this.dateFechaNac.TabIndex = 12;
            this.dateFechaNac.Value = new System.DateTime(2024, 6, 24, 0, 0, 0, 0);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(710, 93);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(70, 28);
            this.label29.TabIndex = 51;
            this.label29.Text = "Fecha de \r\nNacimiento:";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(731, 58);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(46, 14);
            this.label39.TabIndex = 64;
            this.label39.Text = "Celular:";
            // 
            // txtAmbito
            // 
            this.txtAmbito.Location = new System.Drawing.Point(783, 137);
            this.txtAmbito.Name = "txtAmbito";
            this.txtAmbito.Size = new System.Drawing.Size(151, 22);
            this.txtAmbito.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(730, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 14);
            this.label6.TabIndex = 57;
            this.label6.Text = "Ambito:";
            // 
            // txtDomicilio
            // 
            this.txtDomicilio.Location = new System.Drawing.Point(346, 134);
            this.txtDomicilio.Name = "txtDomicilio";
            this.txtDomicilio.Size = new System.Drawing.Size(121, 22);
            this.txtDomicilio.TabIndex = 15;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(282, 137);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 14);
            this.label14.TabIndex = 55;
            this.label14.Text = "Domicilio:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(783, 19);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(151, 22);
            this.txtEmail.TabIndex = 9;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(738, 22);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(39, 14);
            this.label28.TabIndex = 53;
            this.label28.Text = "Email:";
            // 
            // txtDniPaciente
            // 
            this.txtDniPaciente.Location = new System.Drawing.Point(562, 55);
            this.txtDniPaciente.Name = "txtDniPaciente";
            this.txtDniPaciente.Size = new System.Drawing.Size(134, 22);
            this.txtDniPaciente.TabIndex = 12;
            // 
            // txtDniTitular
            // 
            this.txtDniTitular.Location = new System.Drawing.Point(346, 55);
            this.txtDniTitular.Name = "txtDniTitular";
            this.txtDniTitular.Size = new System.Drawing.Size(121, 22);
            this.txtDniTitular.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(481, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 28);
            this.label3.TabIndex = 49;
            this.label3.Text = "Identificación\r\n Paciente:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(268, 55);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(78, 28);
            this.label30.TabIndex = 49;
            this.label30.Text = "Identificación\r\n Titular:";
            this.label30.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(523, 23);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(36, 14);
            this.label31.TabIndex = 48;
            this.label31.Text = "Sexo:";
            // 
            // cmbSexo
            // 
            this.cmbSexo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSexo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSexo.FormattingEnabled = true;
            this.cmbSexo.Location = new System.Drawing.Point(563, 19);
            this.cmbSexo.Name = "cmbSexo";
            this.cmbSexo.Size = new System.Drawing.Size(133, 22);
            this.cmbSexo.TabIndex = 8;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(346, 20);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(121, 22);
            this.txtApellido.TabIndex = 7;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(293, 23);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(53, 14);
            this.label32.TabIndex = 45;
            this.label32.Text = "Apellido:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(134, 20);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(121, 22);
            this.txtNombre.TabIndex = 6;
            // 
            // lblNombrePac
            // 
            this.lblNombrePac.AutoSize = true;
            this.lblNombrePac.Location = new System.Drawing.Point(81, 23);
            this.lblNombrePac.Name = "lblNombrePac";
            this.lblNombrePac.Size = new System.Drawing.Size(53, 14);
            this.lblNombrePac.TabIndex = 43;
            this.lblNombrePac.Text = "Nombre:";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(72, 137);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(60, 14);
            this.label34.TabIndex = 42;
            this.label34.Text = "Localidad:";
            // 
            // lblDniPac
            // 
            this.lblDniPac.AutoSize = true;
            this.lblDniPac.Location = new System.Drawing.Point(25, 58);
            this.lblDniPac.Name = "lblDniPac";
            this.lblDniPac.Size = new System.Drawing.Size(107, 14);
            this.lblDniPac.TabIndex = 41;
            this.lblDniPac.Text = "Tipo Identificación:";
            // 
            // cmbLocalidad
            // 
            this.cmbLocalidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbLocalidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbLocalidad.FormattingEnabled = true;
            this.cmbLocalidad.Location = new System.Drawing.Point(134, 134);
            this.cmbLocalidad.Name = "cmbLocalidad";
            this.cmbLocalidad.Size = new System.Drawing.Size(121, 22);
            this.cmbLocalidad.TabIndex = 13;
            // 
            // cmbTipoDNI
            // 
            this.cmbTipoDNI.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTipoDNI.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTipoDNI.FormattingEnabled = true;
            this.cmbTipoDNI.Location = new System.Drawing.Point(134, 55);
            this.cmbTipoDNI.Name = "cmbTipoDNI";
            this.cmbTipoDNI.Size = new System.Drawing.Size(121, 22);
            this.cmbTipoDNI.TabIndex = 10;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Font = new System.Drawing.Font("Bahnschrift Condensed", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRefresh.Location = new System.Drawing.Point(937, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 40);
            this.btnRefresh.TabIndex = 60;
            this.btnRefresh.Text = "Cargar";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click_1);
            // 
            // cmbOrden
            // 
            this.cmbOrden.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbOrden.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbOrden.FormattingEnabled = true;
            this.cmbOrden.Items.AddRange(new object[] {
            "Pacientes Activos",
            "Pacientes Inactivos",
            "Todos"});
            this.cmbOrden.Location = new System.Drawing.Point(144, 14);
            this.cmbOrden.Name = "cmbOrden";
            this.cmbOrden.Size = new System.Drawing.Size(121, 21);
            this.cmbOrden.TabIndex = 78;
            this.cmbOrden.SelectedIndexChanged += new System.EventHandler(this.cmbOrden_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bahnschrift", 12F);
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(56, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 19);
            this.label7.TabIndex = 78;
            this.label7.Text = "Filtrar por:";
            // 
            // btnReactivar
            // 
            this.btnReactivar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReactivar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnReactivar.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReactivar.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btnReactivar.Location = new System.Drawing.Point(719, 5);
            this.btnReactivar.Name = "btnReactivar";
            this.btnReactivar.Size = new System.Drawing.Size(169, 40);
            this.btnReactivar.TabIndex = 79;
            this.btnReactivar.Text = "Reactivar Paciente";
            this.btnReactivar.UseVisualStyleBackColor = true;
            this.btnReactivar.Visible = false;
            this.btnReactivar.Click += new System.EventHandler(this.btnReactivar_Click);
            // 
            // txtBusquedaPaciente
            // 
            this.txtBusquedaPaciente.Location = new System.Drawing.Point(462, 15);
            this.txtBusquedaPaciente.Name = "txtBusquedaPaciente";
            this.txtBusquedaPaciente.Size = new System.Drawing.Size(121, 20);
            this.txtBusquedaPaciente.TabIndex = 78;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.label8.Location = new System.Drawing.Point(342, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 16);
            this.label8.TabIndex = 79;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Bahnschrift", 12F);
            this.label9.ForeColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(315, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(144, 19);
            this.label9.TabIndex = 80;
            this.label9.Text = "Busqueda por DNI:";
            // 
            // btnBuscarDNI
            // 
            this.btnBuscarDNI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscarDNI.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnBuscarDNI.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarDNI.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btnBuscarDNI.Location = new System.Drawing.Point(589, 15);
            this.btnBuscarDNI.Name = "btnBuscarDNI";
            this.btnBuscarDNI.Size = new System.Drawing.Size(94, 20);
            this.btnBuscarDNI.TabIndex = 81;
            this.btnBuscarDNI.Text = "Buscar";
            this.btnBuscarDNI.UseVisualStyleBackColor = true;
            this.btnBuscarDNI.Click += new System.EventHandler(this.btnBuscarDNI_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(783, 137);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(151, 38);
            this.checkedListBox1.TabIndex = 78;
            // 
            // frmPacientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1063, 605);
            this.Controls.Add(this.btnBuscarDNI);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtBusquedaPaciente);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnReactivar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbOrden);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.dgvVerPacientes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPacientes";
            this.Text = "Lista de Pacientes";
            this.Load += new System.EventHandler(this.frmPacientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVerPacientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVerPacientes;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtCud;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblCud;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox txtAmbito;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDomicilio;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.DateTimePicker dateFechaNac;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtDniTitular;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.ComboBox cmbSexo;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombrePac;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label lblDniPac;
        private System.Windows.Forms.ComboBox cmbLocalidad;
        private System.Windows.Forms.ComboBox cmbTipoDNI;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.TextBox txtNumAfiliado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbObraSocial;
        private System.Windows.Forms.TextBox txtDniPaciente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCargaHoraria;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDiagnostico;
        private System.Windows.Forms.TextBox txtNumDomicilio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cmbOrden;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnReactivar;
        private System.Windows.Forms.TextBox txtBusquedaPaciente;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnBuscarDNI;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}