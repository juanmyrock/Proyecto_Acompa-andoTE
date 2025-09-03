namespace CapaVistas.Forms_Menu
{
    partial class frmGestionarUsuario
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblNombreEmpleado = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbRoles = new System.Windows.Forms.ComboBox();
            this.btnGuardarRol = new System.Windows.Forms.Button();
            this.groupAccionesAdmin = new System.Windows.Forms.GroupBox();
            this.lblEstadoActual = new System.Windows.Forms.Label();
            this.btnActivarDesactivar = new System.Windows.Forms.Button();
            this.btnDesbloquear = new System.Windows.Forms.Button();
            this.btnResetearPass = new System.Windows.Forms.Button();
            this.btnGestionPermisos = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAcceptAdmin = new System.Windows.Forms.Button();
            this.groupAccionesAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(22, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(197, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Gestionar Usuario:";
            // 
            // lblNombreEmpleado
            // 
            this.lblNombreEmpleado.AutoSize = true;
            this.lblNombreEmpleado.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreEmpleado.ForeColor = System.Drawing.Color.Turquoise;
            this.lblNombreEmpleado.Location = new System.Drawing.Point(229, 10);
            this.lblNombreEmpleado.Name = "lblNombreEmpleado";
            this.lblNombreEmpleado.Size = new System.Drawing.Size(222, 24);
            this.lblNombreEmpleado.TabIndex = 1;
            this.lblNombreEmpleado.Text = "[Nombre Empleado]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(23, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre de Usuario:";
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(187, 64);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(259, 27);
            this.txtUsername.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(144, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Rol:";
            // 
            // cmbRoles
            // 
            this.cmbRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoles.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRoles.FormattingEnabled = true;
            this.cmbRoles.Location = new System.Drawing.Point(187, 109);
            this.cmbRoles.Name = "cmbRoles";
            this.cmbRoles.Size = new System.Drawing.Size(259, 29);
            this.cmbRoles.TabIndex = 5;
            // 
            // btnGuardarRol
            // 
            this.btnGuardarRol.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarRol.Location = new System.Drawing.Point(321, 155);
            this.btnGuardarRol.Name = "btnGuardarRol";
            this.btnGuardarRol.Size = new System.Drawing.Size(125, 35);
            this.btnGuardarRol.TabIndex = 6;
            this.btnGuardarRol.Text = "Guardar Rol";
            this.btnGuardarRol.UseVisualStyleBackColor = true;
            this.btnGuardarRol.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // groupAccionesAdmin
            // 
            this.groupAccionesAdmin.Controls.Add(this.lblEstadoActual);
            this.groupAccionesAdmin.Controls.Add(this.btnActivarDesactivar);
            this.groupAccionesAdmin.Controls.Add(this.btnDesbloquear);
            this.groupAccionesAdmin.Controls.Add(this.btnResetearPass);
            this.groupAccionesAdmin.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupAccionesAdmin.ForeColor = System.Drawing.Color.White;
            this.groupAccionesAdmin.Location = new System.Drawing.Point(27, 214);
            this.groupAccionesAdmin.Name = "groupAccionesAdmin";
            this.groupAccionesAdmin.Size = new System.Drawing.Size(419, 185);
            this.groupAccionesAdmin.TabIndex = 7;
            this.groupAccionesAdmin.TabStop = false;
            this.groupAccionesAdmin.Text = "Acciones Administrativas";
            // 
            // lblEstadoActual
            // 
            this.lblEstadoActual.AutoSize = true;
            this.lblEstadoActual.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadoActual.Location = new System.Drawing.Point(21, 40);
            this.lblEstadoActual.Name = "lblEstadoActual";
            this.lblEstadoActual.Size = new System.Drawing.Size(93, 23);
            this.lblEstadoActual.TabIndex = 3;
            this.lblEstadoActual.Text = "[ESTADO]";
            // 
            // btnActivarDesactivar
            // 
            this.btnActivarDesactivar.ForeColor = System.Drawing.Color.Black;
            this.btnActivarDesactivar.Location = new System.Drawing.Point(25, 77);
            this.btnActivarDesactivar.Name = "btnActivarDesactivar";
            this.btnActivarDesactivar.Size = new System.Drawing.Size(170, 35);
            this.btnActivarDesactivar.TabIndex = 2;
            this.btnActivarDesactivar.Text = "Activar/Desactivar";
            this.btnActivarDesactivar.UseVisualStyleBackColor = true;
            this.btnActivarDesactivar.Click += new System.EventHandler(this.btnActivarDesactivar_Click);
            // 
            // btnDesbloquear
            // 
            this.btnDesbloquear.ForeColor = System.Drawing.Color.Black;
            this.btnDesbloquear.Location = new System.Drawing.Point(224, 77);
            this.btnDesbloquear.Name = "btnDesbloquear";
            this.btnDesbloquear.Size = new System.Drawing.Size(170, 35);
            this.btnDesbloquear.TabIndex = 1;
            this.btnDesbloquear.Text = "Desbloquear";
            this.btnDesbloquear.UseVisualStyleBackColor = true;
            this.btnDesbloquear.Click += new System.EventHandler(this.btnDesbloquear_Click);
            // 
            // btnResetearPass
            // 
            this.btnResetearPass.BackColor = System.Drawing.Color.MistyRose;
            this.btnResetearPass.ForeColor = System.Drawing.Color.Black;
            this.btnResetearPass.Location = new System.Drawing.Point(25, 130);
            this.btnResetearPass.Name = "btnResetearPass";
            this.btnResetearPass.Size = new System.Drawing.Size(369, 35);
            this.btnResetearPass.TabIndex = 0;
            this.btnResetearPass.Text = "Resetear Contraseña (Enviar Email)";
            this.btnResetearPass.UseVisualStyleBackColor = false;
            this.btnResetearPass.Click += new System.EventHandler(this.btnResetearPass_Click);
            // 
            // btnGestionPermisos
            // 
            this.btnGestionPermisos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionPermisos.Location = new System.Drawing.Point(27, 155);
            this.btnGestionPermisos.Name = "btnGestionPermisos";
            this.btnGestionPermisos.Size = new System.Drawing.Size(180, 35);
            this.btnGestionPermisos.TabIndex = 8;
            this.btnGestionPermisos.Text = "Gestionar Permisos";
            this.btnGestionPermisos.UseVisualStyleBackColor = true;
            this.btnGestionPermisos.Click += new System.EventHandler(this.btnGestionPermisos_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnCancelar.FlatAppearance.BorderSize = 3;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancelar.Location = new System.Drawing.Point(281, 405);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(165, 39);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAcceptAdmin
            // 
            this.btnAcceptAdmin.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAcceptAdmin.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnAcceptAdmin.FlatAppearance.BorderSize = 3;
            this.btnAcceptAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcceptAdmin.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcceptAdmin.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAcceptAdmin.Location = new System.Drawing.Point(27, 405);
            this.btnAcceptAdmin.Name = "btnAcceptAdmin";
            this.btnAcceptAdmin.Size = new System.Drawing.Size(185, 39);
            this.btnAcceptAdmin.TabIndex = 16;
            this.btnAcceptAdmin.Text = "Aceptar";
            this.btnAcceptAdmin.UseVisualStyleBackColor = true;
            // 
            // frmGestionarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(20)))), ((int)(((byte)(88)))));
            this.ClientSize = new System.Drawing.Size(474, 455);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAcceptAdmin);
            this.Controls.Add(this.btnGestionPermisos);
            this.Controls.Add(this.groupAccionesAdmin);
            this.Controls.Add(this.btnGuardarRol);
            this.Controls.Add(this.cmbRoles);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNombreEmpleado);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmGestionarUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestión de Usuario";
            this.Load += new System.EventHandler(this.frmGestionarUsuario_Load);
            this.groupAccionesAdmin.ResumeLayout(false);
            this.groupAccionesAdmin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNombreEmpleado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbRoles;
        private System.Windows.Forms.Button btnGuardarRol;
        private System.Windows.Forms.GroupBox groupAccionesAdmin;
        private System.Windows.Forms.Button btnActivarDesactivar;
        private System.Windows.Forms.Button btnDesbloquear;
        private System.Windows.Forms.Button btnResetearPass;
        private System.Windows.Forms.Label lblEstadoActual;
        private System.Windows.Forms.Button btnGestionPermisos;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAcceptAdmin;
    }
}
