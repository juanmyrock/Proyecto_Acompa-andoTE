namespace CapaVistas.Forms_Menu
{
    partial class frmAdministrarRoles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdministrarRoles));
            this.lblNombreRol = new System.Windows.Forms.Label();
            this.dgvVerRoles = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnCrear = new System.Windows.Forms.Button();
            this.txtNombreRol = new System.Windows.Forms.TextBox();
            this.txtDescripcionRol = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.btnQuitarTodos = new System.Windows.Forms.Button();
            this.btnQuitarPermiso = new System.Windows.Forms.Button();
            this.btnAsignarTodos = new System.Windows.Forms.Button();
            this.btnAsignarPermiso = new System.Windows.Forms.Button();
            this.ltvPermisosDisp = new System.Windows.Forms.ListView();
            this.ltvPermisosAsignados = new System.Windows.Forms.ListView();
            this.cmbRol = new System.Windows.Forms.ComboBox();
            this.lblRol = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCerrarForm = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVerRoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrarForm)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombreRol
            // 
            this.lblNombreRol.AutoSize = true;
            this.lblNombreRol.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreRol.ForeColor = System.Drawing.Color.White;
            this.lblNombreRol.Location = new System.Drawing.Point(286, 331);
            this.lblNombreRol.Name = "lblNombreRol";
            this.lblNombreRol.Size = new System.Drawing.Size(104, 21);
            this.lblNombreRol.TabIndex = 8;
            this.lblNombreRol.Text = "Nombre Rol:";
            // 
            // dgvVerRoles
            // 
            this.dgvVerRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVerRoles.Location = new System.Drawing.Point(12, 33);
            this.dgvVerRoles.Name = "dgvVerRoles";
            this.dgvVerRoles.Size = new System.Drawing.Size(652, 205);
            this.dgvVerRoles.TabIndex = 5;
            this.dgvVerRoles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVerRoles_CellClick);
            this.dgvVerRoles.SelectionChanged += new System.EventHandler(this.dgvVerRoles_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "Ver Roles";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnEliminar.FlatAppearance.BorderSize = 3;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Sans Serif Collection", 9.749998F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnEliminar.Location = new System.Drawing.Point(550, 242);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(114, 50);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "Eliminar Rol";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificar.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnModificar.FlatAppearance.BorderSize = 3;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Sans Serif Collection", 9.749998F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnModificar.Location = new System.Drawing.Point(305, 244);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(129, 50);
            this.btnModificar.TabIndex = 1;
            this.btnModificar.Text = "Modificar Rol";
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
            this.btnCrear.Location = new System.Drawing.Point(65, 244);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(103, 50);
            this.btnCrear.TabIndex = 0;
            this.btnCrear.Text = "Crear Rol";
            this.btnCrear.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // txtNombreRol
            // 
            this.txtNombreRol.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreRol.Location = new System.Drawing.Point(227, 355);
            this.txtNombreRol.Name = "txtNombreRol";
            this.txtNombreRol.Size = new System.Drawing.Size(237, 27);
            this.txtNombreRol.TabIndex = 3;
            this.txtNombreRol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDescripcionRol
            // 
            this.txtDescripcionRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcionRol.Location = new System.Drawing.Point(65, 422);
            this.txtDescripcionRol.Multiline = true;
            this.txtDescripcionRol.Name = "txtDescripcionRol";
            this.txtDescripcionRol.Size = new System.Drawing.Size(550, 53);
            this.txtDescripcionRol.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(260, 398);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 21);
            this.label2.TabIndex = 8;
            this.label2.Text = "Descripción del Rol:";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::CapaVistas.Properties.Resources.eliminar_logo1;
            this.pictureBox3.ImageLocation = "";
            this.pictureBox3.Location = new System.Drawing.Point(497, 242);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(53, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 53;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CapaVistas.Properties.Resources.logo_editar;
            this.pictureBox2.ImageLocation = "";
            this.pictureBox2.Location = new System.Drawing.Point(252, 244);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(53, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 54;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CapaVistas.Properties.Resources.check_logo;
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(-202, 133);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 55;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::CapaVistas.Properties.Resources.check_logo;
            this.pictureBox4.ImageLocation = "";
            this.pictureBox4.Location = new System.Drawing.Point(12, 244);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(53, 50);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 56;
            this.pictureBox4.TabStop = false;
            // 
            // btnQuitarTodos
            // 
            this.btnQuitarTodos.Location = new System.Drawing.Point(943, 145);
            this.btnQuitarTodos.Name = "btnQuitarTodos";
            this.btnQuitarTodos.Size = new System.Drawing.Size(75, 23);
            this.btnQuitarTodos.TabIndex = 59;
            this.btnQuitarTodos.Text = ">>>>>>";
            this.btnQuitarTodos.UseVisualStyleBackColor = true;
            this.btnQuitarTodos.Click += new System.EventHandler(this.btnAsignarTodos_Click);
            // 
            // btnQuitarPermiso
            // 
            this.btnQuitarPermiso.Location = new System.Drawing.Point(943, 93);
            this.btnQuitarPermiso.Name = "btnQuitarPermiso";
            this.btnQuitarPermiso.Size = new System.Drawing.Size(75, 23);
            this.btnQuitarPermiso.TabIndex = 60;
            this.btnQuitarPermiso.Text = "-->";
            this.btnQuitarPermiso.UseVisualStyleBackColor = true;
            this.btnQuitarPermiso.Click += new System.EventHandler(this.btnAsignarPermiso_Click);
            // 
            // btnAsignarTodos
            // 
            this.btnAsignarTodos.Location = new System.Drawing.Point(943, 399);
            this.btnAsignarTodos.Name = "btnAsignarTodos";
            this.btnAsignarTodos.Size = new System.Drawing.Size(75, 23);
            this.btnAsignarTodos.TabIndex = 61;
            this.btnAsignarTodos.Text = "<<<<<<";
            this.btnAsignarTodos.UseVisualStyleBackColor = true;
            this.btnAsignarTodos.Click += new System.EventHandler(this.btnQuitarTodos_Click);
            // 
            // btnAsignarPermiso
            // 
            this.btnAsignarPermiso.Location = new System.Drawing.Point(943, 452);
            this.btnAsignarPermiso.Name = "btnAsignarPermiso";
            this.btnAsignarPermiso.Size = new System.Drawing.Size(75, 23);
            this.btnAsignarPermiso.TabIndex = 62;
            this.btnAsignarPermiso.Text = "<--";
            this.btnAsignarPermiso.UseVisualStyleBackColor = true;
            this.btnAsignarPermiso.Click += new System.EventHandler(this.btnQuitarPermiso_Click);
            // 
            // ltvPermisosDisp
            // 
            this.ltvPermisosDisp.GridLines = true;
            this.ltvPermisosDisp.HideSelection = false;
            this.ltvPermisosDisp.Location = new System.Drawing.Point(696, 68);
            this.ltvPermisosDisp.Name = "ltvPermisosDisp";
            this.ltvPermisosDisp.Size = new System.Drawing.Size(234, 407);
            this.ltvPermisosDisp.TabIndex = 57;
            this.ltvPermisosDisp.UseCompatibleStateImageBehavior = false;
            this.ltvPermisosDisp.View = System.Windows.Forms.View.Details;
            // 
            // ltvPermisosAsignados
            // 
            this.ltvPermisosAsignados.GridLines = true;
            this.ltvPermisosAsignados.HideSelection = false;
            this.ltvPermisosAsignados.Location = new System.Drawing.Point(1029, 68);
            this.ltvPermisosAsignados.Name = "ltvPermisosAsignados";
            this.ltvPermisosAsignados.Size = new System.Drawing.Size(234, 407);
            this.ltvPermisosAsignados.TabIndex = 58;
            this.ltvPermisosAsignados.UseCompatibleStateImageBehavior = false;
            this.ltvPermisosAsignados.View = System.Windows.Forms.View.Details;
            // 
            // cmbRol
            // 
            this.cmbRol.FormattingEnabled = true;
            this.cmbRol.Location = new System.Drawing.Point(916, 12);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(121, 21);
            this.cmbRol.TabIndex = 63;
            this.cmbRol.SelectedIndexChanged += new System.EventHandler(this.cmbRol_SelectedIndexChanged);
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.lblRol.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblRol.Location = new System.Drawing.Point(869, 12);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(37, 21);
            this.lblRol.TabIndex = 64;
            this.lblRol.Text = "Rol:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(692, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 21);
            this.label3.TabIndex = 65;
            this.label3.Text = "Disponibles:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(1025, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 21);
            this.label4.TabIndex = 66;
            this.label4.Text = "Asignados:";
            // 
            // btnCerrarForm
            // 
            this.btnCerrarForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarForm.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrarForm.Image")));
            this.btnCerrarForm.Location = new System.Drawing.Point(1243, 9);
            this.btnCerrarForm.Name = "btnCerrarForm";
            this.btnCerrarForm.Size = new System.Drawing.Size(35, 35);
            this.btnCerrarForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrarForm.TabIndex = 67;
            this.btnCerrarForm.TabStop = false;
            this.btnCerrarForm.Click += new System.EventHandler(this.btnCerrarForm_Click);
            // 
            // frmAdministrarRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(20)))), ((int)(((byte)(88)))));
            this.ClientSize = new System.Drawing.Size(1290, 507);
            this.Controls.Add(this.btnCerrarForm);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblRol);
            this.Controls.Add(this.cmbRol);
            this.Controls.Add(this.btnQuitarTodos);
            this.Controls.Add(this.btnQuitarPermiso);
            this.Controls.Add(this.btnAsignarTodos);
            this.Controls.Add(this.btnAsignarPermiso);
            this.Controls.Add(this.ltvPermisosDisp);
            this.Controls.Add(this.ltvPermisosAsignados);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtDescripcionRol);
            this.Controls.Add(this.txtNombreRol);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.dgvVerRoles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNombreRol);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAdministrarRoles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Administrar Roles";
            this.Load += new System.EventHandler(this.frmAdministrarRoles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVerRoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrarForm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblNombreRol;
        private System.Windows.Forms.DataGridView dgvVerRoles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.TextBox txtNombreRol;
        private System.Windows.Forms.TextBox txtDescripcionRol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button btnQuitarTodos;
        private System.Windows.Forms.Button btnQuitarPermiso;
        private System.Windows.Forms.Button btnAsignarTodos;
        private System.Windows.Forms.Button btnAsignarPermiso;
        private System.Windows.Forms.ListView ltvPermisosDisp;
        private System.Windows.Forms.ListView ltvPermisosAsignados;
        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox btnCerrarForm;
    }
}