namespace CapaVistas.Forms_Menu
{
    partial class frmProfesionales
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
            this.btnBuscarDNI = new System.Windows.Forms.Button();
            this.lblBusquedaDNI = new System.Windows.Forms.Label();
            this.txtBusquedaProfesional = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnReactivar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbOrden = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtNumDomicilio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbEspecialidad = new System.Windows.Forms.ComboBox();
            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.txtNumMatricula = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblNumMatricula = new System.Windows.Forms.Label();
            this.dateFechaNac = new System.Windows.Forms.DateTimePicker();
            this.label29 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.txtDomicilio = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
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
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnCrear = new System.Windows.Forms.Button();
            this.dgvVerProfesionales = new System.Windows.Forms.DataGridView();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbOrdenEspecialidad = new System.Windows.Forms.ComboBox();
            this.btnEspecialidadMedica = new System.Windows.Forms.Button();
            this.btnHorariosProf = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVerProfesionales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscarDNI
            // 
            this.btnBuscarDNI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscarDNI.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnBuscarDNI.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarDNI.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btnBuscarDNI.Location = new System.Drawing.Point(680, 13);
            this.btnBuscarDNI.Name = "btnBuscarDNI";
            this.btnBuscarDNI.Size = new System.Drawing.Size(94, 20);
            this.btnBuscarDNI.TabIndex = 2;
            this.btnBuscarDNI.Text = "Buscar";
            this.btnBuscarDNI.UseVisualStyleBackColor = true;
            this.btnBuscarDNI.Click += new System.EventHandler(this.btnBuscarDNI_Click);
            // 
            // lblBusquedaDNI
            // 
            this.lblBusquedaDNI.AutoSize = true;
            this.lblBusquedaDNI.Font = new System.Drawing.Font("Bahnschrift", 12F);
            this.lblBusquedaDNI.ForeColor = System.Drawing.SystemColors.Control;
            this.lblBusquedaDNI.Location = new System.Drawing.Point(374, 13);
            this.lblBusquedaDNI.Name = "lblBusquedaDNI";
            this.lblBusquedaDNI.Size = new System.Drawing.Size(144, 19);
            this.lblBusquedaDNI.TabIndex = 96;
            this.lblBusquedaDNI.Text = "Busqueda por DNI:";
            // 
            // txtBusquedaProfesional
            // 
            this.txtBusquedaProfesional.Location = new System.Drawing.Point(524, 13);
            this.txtBusquedaProfesional.Name = "txtBusquedaProfesional";
            this.txtBusquedaProfesional.Size = new System.Drawing.Size(150, 20);
            this.txtBusquedaProfesional.TabIndex = 1;
            this.txtBusquedaProfesional.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBusquedaProfesional_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.label8.Location = new System.Drawing.Point(339, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 16);
            this.label8.TabIndex = 94;
            // 
            // btnReactivar
            // 
            this.btnReactivar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReactivar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnReactivar.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReactivar.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btnReactivar.Location = new System.Drawing.Point(779, 3);
            this.btnReactivar.Name = "btnReactivar";
            this.btnReactivar.Size = new System.Drawing.Size(169, 40);
            this.btnReactivar.TabIndex = 95;
            this.btnReactivar.Text = "Reactivar Profesional";
            this.btnReactivar.UseVisualStyleBackColor = true;
            this.btnReactivar.Visible = false;
            this.btnReactivar.Click += new System.EventHandler(this.btnReactivar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bahnschrift", 12F);
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(9, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 19);
            this.label7.TabIndex = 92;
            this.label7.Text = "Filtrar por estado:";
            // 
            // cmbOrden
            // 
            this.cmbOrden.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbOrden.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbOrden.FormattingEnabled = true;
            this.cmbOrden.Items.AddRange(new object[] {
            "Profesionales Activos",
            "Profesionales Inactivos",
            "Todos"});
            this.cmbOrden.Location = new System.Drawing.Point(156, 13);
            this.cmbOrden.Name = "cmbOrden";
            this.cmbOrden.Size = new System.Drawing.Size(121, 21);
            this.cmbOrden.TabIndex = 0;
            this.cmbOrden.SelectedIndexChanged += new System.EventHandler(this.cmbOrden_SelectedIndexChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Bahnschrift Condensed", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRefresh.Location = new System.Drawing.Point(962, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 40);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Cargar";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtNumDomicilio);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cmbEspecialidad);
            this.groupBox2.Controls.Add(this.lblEspecialidad);
            this.groupBox2.Controls.Add(this.txtNumMatricula);
            this.groupBox2.Controls.Add(this.txtTelefono);
            this.groupBox2.Controls.Add(this.lblNumMatricula);
            this.groupBox2.Controls.Add(this.dateFechaNac);
            this.groupBox2.Controls.Add(this.label29);
            this.groupBox2.Controls.Add(this.label39);
            this.groupBox2.Controls.Add(this.txtDomicilio);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtEmail);
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Controls.Add(this.txtDni);
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
            this.groupBox2.Location = new System.Drawing.Point(57, 351);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(952, 216);
            this.groupBox2.TabIndex = 89;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos del Profesional";
            // 
            // txtNumDomicilio
            // 
            this.txtNumDomicilio.Location = new System.Drawing.Point(783, 152);
            this.txtNumDomicilio.Name = "txtNumDomicilio";
            this.txtNumDomicilio.Size = new System.Drawing.Size(151, 22);
            this.txtNumDomicilio.TabIndex = 19;
            this.txtNumDomicilio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumDomicilio_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(717, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 28);
            this.label5.TabIndex = 77;
            this.label5.Text = "Num \r\nDomicilio:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbEspecialidad
            // 
            this.cmbEspecialidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbEspecialidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbEspecialidad.FormattingEnabled = true;
            this.cmbEspecialidad.Location = new System.Drawing.Point(134, 155);
            this.cmbEspecialidad.Name = "cmbEspecialidad";
            this.cmbEspecialidad.Size = new System.Drawing.Size(121, 22);
            this.cmbEspecialidad.TabIndex = 16;
            // 
            // lblEspecialidad
            // 
            this.lblEspecialidad.AutoSize = true;
            this.lblEspecialidad.Location = new System.Drawing.Point(60, 158);
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Size = new System.Drawing.Size(75, 14);
            this.lblEspecialidad.TabIndex = 66;
            this.lblEspecialidad.Text = "Especialidad:";
            // 
            // txtNumMatricula
            // 
            this.txtNumMatricula.Font = new System.Drawing.Font("Bahnschrift", 12F);
            this.txtNumMatricula.Location = new System.Drawing.Point(383, 43);
            this.txtNumMatricula.Name = "txtNumMatricula";
            this.txtNumMatricula.Size = new System.Drawing.Size(206, 27);
            this.txtNumMatricula.TabIndex = 7;
            this.txtNumMatricula.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(783, 118);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(151, 22);
            this.txtTelefono.TabIndex = 15;
            // 
            // lblNumMatricula
            // 
            this.lblNumMatricula.AutoSize = true;
            this.lblNumMatricula.Font = new System.Drawing.Font("Bahnschrift", 12F);
            this.lblNumMatricula.Location = new System.Drawing.Point(427, 17);
            this.lblNumMatricula.Name = "lblNumMatricula";
            this.lblNumMatricula.Size = new System.Drawing.Size(119, 19);
            this.lblNumMatricula.TabIndex = 64;
            this.lblNumMatricula.Text = "Num Matricula:";
            // 
            // dateFechaNac
            // 
            this.dateFechaNac.CustomFormat = "00/00/0000";
            this.dateFechaNac.Location = new System.Drawing.Point(561, 116);
            this.dateFechaNac.MaxDate = new System.DateTime(2025, 12, 31, 0, 0, 0, 0);
            this.dateFechaNac.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dateFechaNac.Name = "dateFechaNac";
            this.dateFechaNac.Size = new System.Drawing.Size(151, 22);
            this.dateFechaNac.TabIndex = 14;
            this.dateFechaNac.Value = new System.DateTime(2024, 6, 24, 0, 0, 0, 0);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(488, 113);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(70, 28);
            this.label29.TabIndex = 51;
            this.label29.Text = "Fecha de \r\nNacimiento:";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(731, 118);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(46, 14);
            this.label39.TabIndex = 64;
            this.label39.Text = "Celular:";
            // 
            // txtDomicilio
            // 
            this.txtDomicilio.Location = new System.Drawing.Point(561, 153);
            this.txtDomicilio.Name = "txtDomicilio";
            this.txtDomicilio.Size = new System.Drawing.Size(150, 22);
            this.txtDomicilio.TabIndex = 18;
            this.txtDomicilio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDomicilio_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(501, 156);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 14);
            this.label14.TabIndex = 55;
            this.label14.Text = "Domicilio:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(783, 83);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(151, 22);
            this.txtEmail.TabIndex = 11;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(738, 86);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(39, 14);
            this.label28.TabIndex = 53;
            this.label28.Text = "Email:";
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(346, 118);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(121, 22);
            this.txtDni.TabIndex = 13;
            this.txtDni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDni_KeyPress);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(266, 119);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(81, 14);
            this.label30.TabIndex = 49;
            this.label30.Text = "Identificación:";
            this.label30.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(523, 87);
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
            this.cmbSexo.ItemHeight = 14;
            this.cmbSexo.Location = new System.Drawing.Point(562, 83);
            this.cmbSexo.Name = "cmbSexo";
            this.cmbSexo.Size = new System.Drawing.Size(150, 22);
            this.cmbSexo.TabIndex = 10;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(346, 84);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(121, 22);
            this.txtApellido.TabIndex = 9;
            this.txtApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellido_KeyPress);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(293, 87);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(53, 14);
            this.label32.TabIndex = 45;
            this.label32.Text = "Apellido:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(134, 84);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(121, 22);
            this.txtNombre.TabIndex = 8;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // lblNombrePac
            // 
            this.lblNombrePac.AutoSize = true;
            this.lblNombrePac.Location = new System.Drawing.Point(81, 87);
            this.lblNombrePac.Name = "lblNombrePac";
            this.lblNombrePac.Size = new System.Drawing.Size(53, 14);
            this.lblNombrePac.TabIndex = 43;
            this.lblNombrePac.Text = "Nombre:";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(283, 157);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(60, 14);
            this.label34.TabIndex = 42;
            this.label34.Text = "Localidad:";
            // 
            // lblDniPac
            // 
            this.lblDniPac.AutoSize = true;
            this.lblDniPac.Location = new System.Drawing.Point(25, 122);
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
            this.cmbLocalidad.Location = new System.Drawing.Point(345, 153);
            this.cmbLocalidad.Name = "cmbLocalidad";
            this.cmbLocalidad.Size = new System.Drawing.Size(122, 22);
            this.cmbLocalidad.TabIndex = 17;
            // 
            // cmbTipoDNI
            // 
            this.cmbTipoDNI.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTipoDNI.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTipoDNI.FormattingEnabled = true;
            this.cmbTipoDNI.Location = new System.Drawing.Point(134, 119);
            this.cmbTipoDNI.Name = "cmbTipoDNI";
            this.cmbTipoDNI.Size = new System.Drawing.Size(121, 22);
            this.cmbTipoDNI.TabIndex = 12;
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
            this.btnEliminar.Location = new System.Drawing.Point(811, 301);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(168, 44);
            this.btnEliminar.TabIndex = 6;
            this.btnEliminar.Text = "Eliminar Profesional";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
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
            this.btnModificar.Location = new System.Drawing.Point(460, 301);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(179, 44);
            this.btnModificar.TabIndex = 5;
            this.btnModificar.Text = "Modificar Profesional";
            this.btnModificar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnCrear
            // 
            this.btnCrear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCrear.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnCrear.FlatAppearance.BorderSize = 3;
            this.btnCrear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrear.Font = new System.Drawing.Font("Sans Serif Collection", 9.749998F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrear.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnCrear.Location = new System.Drawing.Point(120, 301);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(168, 44);
            this.btnCrear.TabIndex = 4;
            this.btnCrear.Text = "Cargar Profesional";
            this.btnCrear.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // dgvVerProfesionales
            // 
            this.dgvVerProfesionales.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVerProfesionales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVerProfesionales.Location = new System.Drawing.Point(97, 77);
            this.dgvVerProfesionales.MultiSelect = false;
            this.dgvVerProfesionales.Name = "dgvVerProfesionales";
            this.dgvVerProfesionales.ReadOnly = true;
            this.dgvVerProfesionales.RowHeadersVisible = false;
            this.dgvVerProfesionales.RowHeadersWidth = 47;
            this.dgvVerProfesionales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVerProfesionales.Size = new System.Drawing.Size(851, 218);
            this.dgvVerProfesionales.TabIndex = 20;
            this.dgvVerProfesionales.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVerProfesionales_CellClick);
            this.dgvVerProfesionales.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVerProfesionales_RowEnter);
            this.dgvVerProfesionales.SelectionChanged += new System.EventHandler(this.dgvVerProfesionales_SelectionChanged);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.Image = global::CapaVistas.Properties.Resources.eliminar_logo1;
            this.pictureBox3.ImageLocation = "";
            this.pictureBox3.Location = new System.Drawing.Point(758, 301);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(53, 44);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 86;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox2.Image = global::CapaVistas.Properties.Resources.logo_editar;
            this.pictureBox2.ImageLocation = "";
            this.pictureBox2.Location = new System.Drawing.Point(403, 301);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(53, 44);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 87;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CapaVistas.Properties.Resources.check_logo;
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(73, 301);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 88;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 12F);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(9, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 19);
            this.label1.TabIndex = 97;
            this.label1.Text = "Filtrar por especialidad:";
            // 
            // cmbOrdenEspecialidad
            // 
            this.cmbOrdenEspecialidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbOrdenEspecialidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbOrdenEspecialidad.FormattingEnabled = true;
            this.cmbOrdenEspecialidad.Items.AddRange(new object[] {
            "Profesionales Activos",
            "Profesionales Inactivos",
            "Todos"});
            this.cmbOrdenEspecialidad.Location = new System.Drawing.Point(199, 43);
            this.cmbOrdenEspecialidad.Name = "cmbOrdenEspecialidad";
            this.cmbOrdenEspecialidad.Size = new System.Drawing.Size(140, 21);
            this.cmbOrdenEspecialidad.TabIndex = 98;
            this.cmbOrdenEspecialidad.SelectedIndexChanged += new System.EventHandler(this.cmbOrdenEspecialidad_SelectedIndexChanged);
            // 
            // btnEspecialidadMedica
            // 
            this.btnEspecialidadMedica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEspecialidadMedica.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEspecialidadMedica.Font = new System.Drawing.Font("Bahnschrift Condensed", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEspecialidadMedica.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEspecialidadMedica.Location = new System.Drawing.Point(962, 92);
            this.btnEspecialidadMedica.Name = "btnEspecialidadMedica";
            this.btnEspecialidadMedica.Size = new System.Drawing.Size(89, 46);
            this.btnEspecialidadMedica.TabIndex = 99;
            this.btnEspecialidadMedica.Text = "Especialidades Médicas";
            this.btnEspecialidadMedica.UseVisualStyleBackColor = true;
            this.btnEspecialidadMedica.Click += new System.EventHandler(this.btnEspecialidadMedica_Click);
            // 
            // btnHorariosProf
            // 
            this.btnHorariosProf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHorariosProf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHorariosProf.Font = new System.Drawing.Font("Bahnschrift Condensed", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHorariosProf.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnHorariosProf.Location = new System.Drawing.Point(962, 167);
            this.btnHorariosProf.Name = "btnHorariosProf";
            this.btnHorariosProf.Size = new System.Drawing.Size(89, 49);
            this.btnHorariosProf.TabIndex = 100;
            this.btnHorariosProf.Text = "Gestionar Horarios";
            this.btnHorariosProf.UseVisualStyleBackColor = true;
            this.btnHorariosProf.Click += new System.EventHandler(this.btnHorariosProf_Click);
            // 
            // frmProfesionales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1063, 605);
            this.Controls.Add(this.btnHorariosProf);
            this.Controls.Add(this.btnEspecialidadMedica);
            this.Controls.Add(this.cmbOrdenEspecialidad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBuscarDNI);
            this.Controls.Add(this.lblBusquedaDNI);
            this.Controls.Add(this.txtBusquedaProfesional);
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
            this.Controls.Add(this.dgvVerProfesionales);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmProfesionales";
            this.Text = "Lista de Profesionales";
            this.Load += new System.EventHandler(this.frmProfesionales_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVerProfesionales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscarDNI;
        private System.Windows.Forms.Label lblBusquedaDNI;
        private System.Windows.Forms.TextBox txtBusquedaProfesional;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnReactivar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbOrden;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtNumDomicilio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbEspecialidad;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.TextBox txtNumMatricula;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblNumMatricula;
        private System.Windows.Forms.DateTimePicker dateFechaNac;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox txtDomicilio;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtDni;
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
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.DataGridView dgvVerProfesionales;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbOrdenEspecialidad;
        private System.Windows.Forms.Button btnEspecialidadMedica;
        private System.Windows.Forms.Button btnHorariosProf;
    }
}