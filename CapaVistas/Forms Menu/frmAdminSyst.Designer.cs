namespace CapaVistas.Forms_Menu
{
    partial class frmAdminSyst
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
            this.lblPassCharVerification = new System.Windows.Forms.Label();
            this.lblAskUser = new System.Windows.Forms.Label();
            this.lblCombMayus = new System.Windows.Forms.Label();
            this.lblNum = new System.Windows.Forms.Label();
            this.lblSpecChar = new System.Windows.Forms.Label();
            this.lblRepeatPass = new System.Windows.Forms.Label();
            this.chkAskUser = new System.Windows.Forms.CheckBox();
            this.chkCombMayus = new System.Windows.Forms.CheckBox();
            this.chkNum = new System.Windows.Forms.CheckBox();
            this.chkSpecChar = new System.Windows.Forms.CheckBox();
            this.chkRepeatPass = new System.Windows.Forms.CheckBox();
            this.btnAcceptAdmin = new System.Windows.Forms.Button();
            this.numCaracteres = new System.Windows.Forms.NumericUpDown();
            this.numPreguntas = new System.Windows.Forms.NumericUpDown();
            this.chkCombMin = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkCantidadCaracteres = new System.Windows.Forms.CheckBox();
            this.numContrasAnteriores = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numCaracteres)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPreguntas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numContrasAnteriores)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPassCharVerification
            // 
            this.lblPassCharVerification.AutoSize = true;
            this.lblPassCharVerification.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassCharVerification.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblPassCharVerification.Location = new System.Drawing.Point(12, 47);
            this.lblPassCharVerification.Name = "lblPassCharVerification";
            this.lblPassCharVerification.Size = new System.Drawing.Size(279, 19);
            this.lblPassCharVerification.TabIndex = 0;
            this.lblPassCharVerification.Text = "Caracteres minimos de contraseña";
            // 
            // lblAskUser
            // 
            this.lblAskUser.AutoSize = true;
            this.lblAskUser.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAskUser.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblAskUser.Location = new System.Drawing.Point(13, 104);
            this.lblAskUser.Name = "lblAskUser";
            this.lblAskUser.Size = new System.Drawing.Size(337, 16);
            this.lblAskUser.TabIndex = 1;
            this.lblAskUser.Text = "Cantidad de preguntas a responder por el usuario";
            // 
            // lblCombMayus
            // 
            this.lblCombMayus.AutoSize = true;
            this.lblCombMayus.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lblCombMayus.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblCombMayus.Location = new System.Drawing.Point(12, 151);
            this.lblCombMayus.Name = "lblCombMayus";
            this.lblCombMayus.Size = new System.Drawing.Size(239, 19);
            this.lblCombMayus.TabIndex = 2;
            this.lblCombMayus.Text = "Combinacion de mayusculas";
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lblNum.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblNum.Location = new System.Drawing.Point(12, 232);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(150, 19);
            this.lblNum.TabIndex = 3;
            this.lblNum.Text = "Contiene números";
            // 
            // lblSpecChar
            // 
            this.lblSpecChar.AutoSize = true;
            this.lblSpecChar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lblSpecChar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblSpecChar.Location = new System.Drawing.Point(12, 278);
            this.lblSpecChar.Name = "lblSpecChar";
            this.lblSpecChar.Size = new System.Drawing.Size(318, 19);
            this.lblSpecChar.TabIndex = 4;
            this.lblSpecChar.Text = "Contiene al menos un caracter especial";
            // 
            // lblRepeatPass
            // 
            this.lblRepeatPass.AutoSize = true;
            this.lblRepeatPass.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lblRepeatPass.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblRepeatPass.Location = new System.Drawing.Point(12, 318);
            this.lblRepeatPass.Name = "lblRepeatPass";
            this.lblRepeatPass.Size = new System.Drawing.Size(296, 19);
            this.lblRepeatPass.TabIndex = 5;
            this.lblRepeatPass.Text = "Permite repetir contraseñas anteriores";
            // 
            // chkAskUser
            // 
            this.chkAskUser.AutoSize = true;
            this.chkAskUser.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAskUser.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.chkAskUser.Location = new System.Drawing.Point(356, 101);
            this.chkAskUser.Name = "chkAskUser";
            this.chkAskUser.Size = new System.Drawing.Size(61, 22);
            this.chkAskUser.TabIndex = 7;
            this.chkAskUser.Text = "si/no";
            this.chkAskUser.UseVisualStyleBackColor = true;
            this.chkAskUser.CheckedChanged += new System.EventHandler(this.chkAskUser_CheckedChanged);
            // 
            // chkCombMayus
            // 
            this.chkCombMayus.AutoSize = true;
            this.chkCombMayus.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCombMayus.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.chkCombMayus.Location = new System.Drawing.Point(355, 151);
            this.chkCombMayus.Name = "chkCombMayus";
            this.chkCombMayus.Size = new System.Drawing.Size(61, 22);
            this.chkCombMayus.TabIndex = 8;
            this.chkCombMayus.Text = "si/no";
            this.chkCombMayus.UseVisualStyleBackColor = true;
            // 
            // chkNum
            // 
            this.chkNum.AutoSize = true;
            this.chkNum.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNum.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.chkNum.Location = new System.Drawing.Point(355, 232);
            this.chkNum.Name = "chkNum";
            this.chkNum.Size = new System.Drawing.Size(61, 22);
            this.chkNum.TabIndex = 9;
            this.chkNum.Text = "si/no";
            this.chkNum.UseVisualStyleBackColor = true;
            // 
            // chkSpecChar
            // 
            this.chkSpecChar.AutoSize = true;
            this.chkSpecChar.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSpecChar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.chkSpecChar.Location = new System.Drawing.Point(355, 278);
            this.chkSpecChar.Name = "chkSpecChar";
            this.chkSpecChar.Size = new System.Drawing.Size(61, 22);
            this.chkSpecChar.TabIndex = 10;
            this.chkSpecChar.Text = "si/no";
            this.chkSpecChar.UseVisualStyleBackColor = true;
            // 
            // chkRepeatPass
            // 
            this.chkRepeatPass.AutoSize = true;
            this.chkRepeatPass.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRepeatPass.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.chkRepeatPass.Location = new System.Drawing.Point(355, 318);
            this.chkRepeatPass.Name = "chkRepeatPass";
            this.chkRepeatPass.Size = new System.Drawing.Size(61, 22);
            this.chkRepeatPass.TabIndex = 11;
            this.chkRepeatPass.Text = "si/no";
            this.chkRepeatPass.UseVisualStyleBackColor = true;
            this.chkRepeatPass.CheckedChanged += new System.EventHandler(this.chkRepeatPass_CheckedChanged);
            // 
            // btnAcceptAdmin
            // 
            this.btnAcceptAdmin.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnAcceptAdmin.FlatAppearance.BorderSize = 3;
            this.btnAcceptAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcceptAdmin.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcceptAdmin.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAcceptAdmin.Location = new System.Drawing.Point(355, 578);
            this.btnAcceptAdmin.Name = "btnAcceptAdmin";
            this.btnAcceptAdmin.Size = new System.Drawing.Size(302, 39);
            this.btnAcceptAdmin.TabIndex = 14;
            this.btnAcceptAdmin.Text = "Aceptar";
            this.btnAcceptAdmin.UseVisualStyleBackColor = true;
            // 
            // numCaracteres
            // 
            this.numCaracteres.Enabled = false;
            this.numCaracteres.Location = new System.Drawing.Point(434, 50);
            this.numCaracteres.Name = "numCaracteres";
            this.numCaracteres.Size = new System.Drawing.Size(120, 20);
            this.numCaracteres.TabIndex = 17;
            this.numCaracteres.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // numPreguntas
            // 
            this.numPreguntas.Enabled = false;
            this.numPreguntas.Location = new System.Drawing.Point(434, 100);
            this.numPreguntas.Name = "numPreguntas";
            this.numPreguntas.Size = new System.Drawing.Size(120, 20);
            this.numPreguntas.TabIndex = 18;
            this.numPreguntas.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // chkCombMin
            // 
            this.chkCombMin.AutoSize = true;
            this.chkCombMin.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCombMin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.chkCombMin.Location = new System.Drawing.Point(355, 191);
            this.chkCombMin.Name = "chkCombMin";
            this.chkCombMin.Size = new System.Drawing.Size(61, 22);
            this.chkCombMin.TabIndex = 20;
            this.chkCombMin.Text = "si/no";
            this.chkCombMin.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(12, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 19);
            this.label1.TabIndex = 19;
            this.label1.Text = "Combinacion de minusculas";
            // 
            // chkCantidadCaracteres
            // 
            this.chkCantidadCaracteres.AutoSize = true;
            this.chkCantidadCaracteres.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCantidadCaracteres.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.chkCantidadCaracteres.Location = new System.Drawing.Point(356, 51);
            this.chkCantidadCaracteres.Name = "chkCantidadCaracteres";
            this.chkCantidadCaracteres.Size = new System.Drawing.Size(61, 22);
            this.chkCantidadCaracteres.TabIndex = 6;
            this.chkCantidadCaracteres.Text = "si/no";
            this.chkCantidadCaracteres.UseVisualStyleBackColor = true;
            this.chkCantidadCaracteres.CheckedChanged += new System.EventHandler(this.chkPassCharVerification_CheckedChanged);
            // 
            // numContrasAnteriores
            // 
            this.numContrasAnteriores.Enabled = false;
            this.numContrasAnteriores.Location = new System.Drawing.Point(434, 317);
            this.numContrasAnteriores.Name = "numContrasAnteriores";
            this.numContrasAnteriores.Size = new System.Drawing.Size(120, 20);
            this.numContrasAnteriores.TabIndex = 21;
            this.numContrasAnteriores.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // frmAdminSyst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1047, 661);
            this.Controls.Add(this.numContrasAnteriores);
            this.Controls.Add(this.chkCombMin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numPreguntas);
            this.Controls.Add(this.numCaracteres);
            this.Controls.Add(this.btnAcceptAdmin);
            this.Controls.Add(this.chkRepeatPass);
            this.Controls.Add(this.chkSpecChar);
            this.Controls.Add(this.chkNum);
            this.Controls.Add(this.chkCombMayus);
            this.Controls.Add(this.chkAskUser);
            this.Controls.Add(this.chkCantidadCaracteres);
            this.Controls.Add(this.lblRepeatPass);
            this.Controls.Add(this.lblSpecChar);
            this.Controls.Add(this.lblNum);
            this.Controls.Add(this.lblCombMayus);
            this.Controls.Add(this.lblAskUser);
            this.Controls.Add(this.lblPassCharVerification);
            this.Name = "frmAdminSyst";
            this.Text = "AdminSyst";
            this.Load += new System.EventHandler(this.frmAdminSyst_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numCaracteres)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPreguntas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numContrasAnteriores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPassCharVerification;
        private System.Windows.Forms.Label lblAskUser;
        private System.Windows.Forms.Label lblCombMayus;
        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.Label lblSpecChar;
        private System.Windows.Forms.Label lblRepeatPass;
        private System.Windows.Forms.CheckBox chkAskUser;
        private System.Windows.Forms.CheckBox chkCombMayus;
        private System.Windows.Forms.CheckBox chkNum;
        private System.Windows.Forms.CheckBox chkSpecChar;
        private System.Windows.Forms.CheckBox chkRepeatPass;
        private System.Windows.Forms.Button btnAcceptAdmin;
        private System.Windows.Forms.NumericUpDown numCaracteres;
        private System.Windows.Forms.NumericUpDown numPreguntas;
        private System.Windows.Forms.CheckBox chkCombMin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkCantidadCaracteres;
        private System.Windows.Forms.NumericUpDown numContrasAnteriores;
    }
}