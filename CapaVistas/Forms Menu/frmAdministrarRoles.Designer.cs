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
            this.lblNombreRol = new System.Windows.Forms.Label();
            this.lblIdRol = new System.Windows.Forms.Label();
            this.dgvVerRoles = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnCrear = new System.Windows.Forms.Button();
            this.txtIdRol = new System.Windows.Forms.TextBox();
            this.txtNombreRol = new System.Windows.Forms.TextBox();
            this.txtDescripcionRol = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVerRoles)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombreRol
            // 
            this.lblNombreRol.AutoSize = true;
            this.lblNombreRol.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreRol.ForeColor = System.Drawing.Color.White;
            this.lblNombreRol.Location = new System.Drawing.Point(62, 361);
            this.lblNombreRol.Name = "lblNombreRol";
            this.lblNombreRol.Size = new System.Drawing.Size(104, 21);
            this.lblNombreRol.TabIndex = 8;
            this.lblNombreRol.Text = "Nombre Rol:";
            // 
            // lblIdRol
            // 
            this.lblIdRol.AutoSize = true;
            this.lblIdRol.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdRol.ForeColor = System.Drawing.Color.White;
            this.lblIdRol.Location = new System.Drawing.Point(62, 328);
            this.lblIdRol.Name = "lblIdRol";
            this.lblIdRol.Size = new System.Drawing.Size(58, 21);
            this.lblIdRol.TabIndex = 6;
            this.lblIdRol.Text = "ID Rol:";
            // 
            // dgvVerRoles
            // 
            this.dgvVerRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVerRoles.Location = new System.Drawing.Point(46, 48);
            this.dgvVerRoles.Name = "dgvVerRoles";
            this.dgvVerRoles.Size = new System.Drawing.Size(530, 205);
            this.dgvVerRoles.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(45, 24);
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
            this.btnEliminar.Location = new System.Drawing.Point(457, 259);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(119, 50);
            this.btnEliminar.TabIndex = 13;
            this.btnEliminar.Text = "Eliminar Rol";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            this.btnModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificar.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnModificar.FlatAppearance.BorderSize = 3;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Sans Serif Collection", 9.749998F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnModificar.Location = new System.Drawing.Point(250, 259);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(125, 50);
            this.btnModificar.TabIndex = 12;
            this.btnModificar.Text = "Modificar Rol";
            this.btnModificar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnCrear
            // 
            this.btnCrear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCrear.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnCrear.FlatAppearance.BorderSize = 3;
            this.btnCrear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrear.Font = new System.Drawing.Font("Sans Serif Collection", 9.749998F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrear.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnCrear.Location = new System.Drawing.Point(49, 259);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(117, 50);
            this.btnCrear.TabIndex = 11;
            this.btnCrear.Text = "Crear Rol";
            this.btnCrear.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCrear.UseVisualStyleBackColor = true;
            // 
            // txtIdRol
            // 
            this.txtIdRol.Location = new System.Drawing.Point(131, 328);
            this.txtIdRol.Name = "txtIdRol";
            this.txtIdRol.Size = new System.Drawing.Size(157, 20);
            this.txtIdRol.TabIndex = 14;
            // 
            // txtNombreRol
            // 
            this.txtNombreRol.Location = new System.Drawing.Point(172, 364);
            this.txtNombreRol.Name = "txtNombreRol";
            this.txtNombreRol.Size = new System.Drawing.Size(157, 20);
            this.txtNombreRol.TabIndex = 14;
            // 
            // txtDescripcionRol
            // 
            this.txtDescripcionRol.Location = new System.Drawing.Point(231, 400);
            this.txtDescripcionRol.Name = "txtDescripcionRol";
            this.txtDescripcionRol.Size = new System.Drawing.Size(157, 20);
            this.txtDescripcionRol.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(62, 400);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 21);
            this.label2.TabIndex = 8;
            this.label2.Text = "Descripción del Rol:";
            // 
            // frmAdministrarRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(20)))), ((int)(((byte)(88)))));
            this.ClientSize = new System.Drawing.Size(617, 452);
            this.Controls.Add(this.txtDescripcionRol);
            this.Controls.Add(this.txtNombreRol);
            this.Controls.Add(this.txtIdRol);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.dgvVerRoles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNombreRol);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblIdRol);
            this.Name = "frmAdministrarRoles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Administrar Roles";
            this.Load += new System.EventHandler(this.frmAdministrarRoles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVerRoles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblNombreRol;
        private System.Windows.Forms.Label lblIdRol;
        private System.Windows.Forms.DataGridView dgvVerRoles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.TextBox txtIdRol;
        private System.Windows.Forms.TextBox txtNombreRol;
        private System.Windows.Forms.TextBox txtDescripcionRol;
        private System.Windows.Forms.Label label2;
    }
}