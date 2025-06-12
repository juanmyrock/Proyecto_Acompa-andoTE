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
            this.lblCombMayusMin = new System.Windows.Forms.Label();
            this.lblNumyLet = new System.Windows.Forms.Label();
            this.lblSpecChar = new System.Windows.Forms.Label();
            this.lblRepeatPass = new System.Windows.Forms.Label();
            this.chkPassCharVerification = new System.Windows.Forms.CheckBox();
            this.chkAskUser = new System.Windows.Forms.CheckBox();
            this.chkCombMayusMin = new System.Windows.Forms.CheckBox();
            this.chkNumyLet = new System.Windows.Forms.CheckBox();
            this.chkSpecChar = new System.Windows.Forms.CheckBox();
            this.chkRepeatPass = new System.Windows.Forms.CheckBox();
            this.txtPassCharVerification = new System.Windows.Forms.TextBox();
            this.cmbAskUser = new System.Windows.Forms.ComboBox();
            this.btnAcceptAdmin = new System.Windows.Forms.Button();
            this.btnCancelAdmin = new System.Windows.Forms.Button();
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
            this.lblAskUser.Location = new System.Drawing.Point(13, 89);
            this.lblAskUser.Name = "lblAskUser";
            this.lblAskUser.Size = new System.Drawing.Size(337, 16);
            this.lblAskUser.TabIndex = 1;
            this.lblAskUser.Text = "Cantidad de preguntas a responder por el usuario";
            // 
            // lblCombMayusMin
            // 
            this.lblCombMayusMin.AutoSize = true;
            this.lblCombMayusMin.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lblCombMayusMin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblCombMayusMin.Location = new System.Drawing.Point(13, 127);
            this.lblCombMayusMin.Name = "lblCombMayusMin";
            this.lblCombMayusMin.Size = new System.Drawing.Size(344, 19);
            this.lblCombMayusMin.TabIndex = 2;
            this.lblCombMayusMin.Text = "Combinacion de mayusculas o minusculas";
            // 
            // lblNumyLet
            // 
            this.lblNumyLet.AutoSize = true;
            this.lblNumyLet.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lblNumyLet.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblNumyLet.Location = new System.Drawing.Point(13, 161);
            this.lblNumyLet.Name = "lblNumyLet";
            this.lblNumyLet.Size = new System.Drawing.Size(207, 19);
            this.lblNumyLet.TabIndex = 3;
            this.lblNumyLet.Text = "Contiene numeros y letras";
            // 
            // lblSpecChar
            // 
            this.lblSpecChar.AutoSize = true;
            this.lblSpecChar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lblSpecChar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblSpecChar.Location = new System.Drawing.Point(13, 194);
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
            this.lblRepeatPass.Location = new System.Drawing.Point(13, 228);
            this.lblRepeatPass.Name = "lblRepeatPass";
            this.lblRepeatPass.Size = new System.Drawing.Size(296, 19);
            this.lblRepeatPass.TabIndex = 5;
            this.lblRepeatPass.Text = "Permite repetir contraseñas anteriores";
            // 
            // chkPassCharVerification
            // 
            this.chkPassCharVerification.AutoSize = true;
            this.chkPassCharVerification.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.chkPassCharVerification.Location = new System.Drawing.Point(356, 51);
            this.chkPassCharVerification.Name = "chkPassCharVerification";
            this.chkPassCharVerification.Size = new System.Drawing.Size(50, 17);
            this.chkPassCharVerification.TabIndex = 6;
            this.chkPassCharVerification.Text = "si/no";
            this.chkPassCharVerification.UseVisualStyleBackColor = true;
            // 
            // chkAskUser
            // 
            this.chkAskUser.AutoSize = true;
            this.chkAskUser.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.chkAskUser.Location = new System.Drawing.Point(356, 90);
            this.chkAskUser.Name = "chkAskUser";
            this.chkAskUser.Size = new System.Drawing.Size(50, 17);
            this.chkAskUser.TabIndex = 7;
            this.chkAskUser.Text = "si/no";
            this.chkAskUser.UseVisualStyleBackColor = true;
            // 
            // chkCombMayusMin
            // 
            this.chkCombMayusMin.AutoSize = true;
            this.chkCombMayusMin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.chkCombMayusMin.Location = new System.Drawing.Point(356, 131);
            this.chkCombMayusMin.Name = "chkCombMayusMin";
            this.chkCombMayusMin.Size = new System.Drawing.Size(50, 17);
            this.chkCombMayusMin.TabIndex = 8;
            this.chkCombMayusMin.Text = "si/no";
            this.chkCombMayusMin.UseVisualStyleBackColor = true;
            // 
            // chkNumyLet
            // 
            this.chkNumyLet.AutoSize = true;
            this.chkNumyLet.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.chkNumyLet.Location = new System.Drawing.Point(356, 165);
            this.chkNumyLet.Name = "chkNumyLet";
            this.chkNumyLet.Size = new System.Drawing.Size(50, 17);
            this.chkNumyLet.TabIndex = 9;
            this.chkNumyLet.Text = "si/no";
            this.chkNumyLet.UseVisualStyleBackColor = true;
            // 
            // chkSpecChar
            // 
            this.chkSpecChar.AutoSize = true;
            this.chkSpecChar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.chkSpecChar.Location = new System.Drawing.Point(356, 198);
            this.chkSpecChar.Name = "chkSpecChar";
            this.chkSpecChar.Size = new System.Drawing.Size(50, 17);
            this.chkSpecChar.TabIndex = 10;
            this.chkSpecChar.Text = "si/no";
            this.chkSpecChar.UseVisualStyleBackColor = true;
            // 
            // chkRepeatPass
            // 
            this.chkRepeatPass.AutoSize = true;
            this.chkRepeatPass.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.chkRepeatPass.Location = new System.Drawing.Point(356, 232);
            this.chkRepeatPass.Name = "chkRepeatPass";
            this.chkRepeatPass.Size = new System.Drawing.Size(50, 17);
            this.chkRepeatPass.TabIndex = 11;
            this.chkRepeatPass.Text = "si/no";
            this.chkRepeatPass.UseVisualStyleBackColor = true;
            // 
            // txtPassCharVerification
            // 
            this.txtPassCharVerification.Enabled = false;
            this.txtPassCharVerification.Location = new System.Drawing.Point(433, 49);
            this.txtPassCharVerification.Name = "txtPassCharVerification";
            this.txtPassCharVerification.Size = new System.Drawing.Size(121, 20);
            this.txtPassCharVerification.TabIndex = 12;
            // 
            // cmbAskUser
            // 
            this.cmbAskUser.Enabled = false;
            this.cmbAskUser.FormattingEnabled = true;
            this.cmbAskUser.Location = new System.Drawing.Point(433, 88);
            this.cmbAskUser.Name = "cmbAskUser";
            this.cmbAskUser.Size = new System.Drawing.Size(121, 21);
            this.cmbAskUser.TabIndex = 13;
            // 
            // btnAcceptAdmin
            // 
            this.btnAcceptAdmin.Location = new System.Drawing.Point(372, 292);
            this.btnAcceptAdmin.Name = "btnAcceptAdmin";
            this.btnAcceptAdmin.Size = new System.Drawing.Size(75, 23);
            this.btnAcceptAdmin.TabIndex = 14;
            this.btnAcceptAdmin.Text = "Aceptar";
            this.btnAcceptAdmin.UseVisualStyleBackColor = true;
            // 
            // btnCancelAdmin
            // 
            this.btnCancelAdmin.Location = new System.Drawing.Point(479, 292);
            this.btnCancelAdmin.Name = "btnCancelAdmin";
            this.btnCancelAdmin.Size = new System.Drawing.Size(75, 23);
            this.btnCancelAdmin.TabIndex = 15;
            this.btnCancelAdmin.Text = "Cancelar";
            this.btnCancelAdmin.UseVisualStyleBackColor = true;
            // 
            // frmAdminSyst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(20)))), ((int)(((byte)(88)))));
            this.ClientSize = new System.Drawing.Size(576, 349);
            this.Controls.Add(this.btnCancelAdmin);
            this.Controls.Add(this.btnAcceptAdmin);
            this.Controls.Add(this.cmbAskUser);
            this.Controls.Add(this.txtPassCharVerification);
            this.Controls.Add(this.chkRepeatPass);
            this.Controls.Add(this.chkSpecChar);
            this.Controls.Add(this.chkNumyLet);
            this.Controls.Add(this.chkCombMayusMin);
            this.Controls.Add(this.chkAskUser);
            this.Controls.Add(this.chkPassCharVerification);
            this.Controls.Add(this.lblRepeatPass);
            this.Controls.Add(this.lblSpecChar);
            this.Controls.Add(this.lblNumyLet);
            this.Controls.Add(this.lblCombMayusMin);
            this.Controls.Add(this.lblAskUser);
            this.Controls.Add(this.lblPassCharVerification);
            this.Name = "frmAdminSyst";
            this.Text = "AdminSyst";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPassCharVerification;
        private System.Windows.Forms.Label lblAskUser;
        private System.Windows.Forms.Label lblCombMayusMin;
        private System.Windows.Forms.Label lblNumyLet;
        private System.Windows.Forms.Label lblSpecChar;
        private System.Windows.Forms.Label lblRepeatPass;
        private System.Windows.Forms.CheckBox chkPassCharVerification;
        private System.Windows.Forms.CheckBox chkAskUser;
        private System.Windows.Forms.CheckBox chkCombMayusMin;
        private System.Windows.Forms.CheckBox chkNumyLet;
        private System.Windows.Forms.CheckBox chkSpecChar;
        private System.Windows.Forms.CheckBox chkRepeatPass;
        private System.Windows.Forms.TextBox txtPassCharVerification;
        private System.Windows.Forms.ComboBox cmbAskUser;
        private System.Windows.Forms.Button btnAcceptAdmin;
        private System.Windows.Forms.Button btnCancelAdmin;
    }
}