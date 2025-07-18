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
            this.lblDiasContra = new System.Windows.Forms.Label();
            this.numDiasContra = new System.Windows.Forms.NumericUpDown();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblFallos = new System.Windows.Forms.Label();
            this.numFallos = new System.Windows.Forms.NumericUpDown();
            this.chkDiasContra = new System.Windows.Forms.CheckBox();
            this.chkFallos = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numCaracteres)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPreguntas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numContrasAnteriores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiasContra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFallos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPassCharVerification
            // 
            this.lblPassCharVerification.AutoSize = true;
            this.lblPassCharVerification.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassCharVerification.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblPassCharVerification.Location = new System.Drawing.Point(61, 47);
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
            this.lblAskUser.Location = new System.Drawing.Point(62, 104);
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
            this.lblCombMayus.Location = new System.Drawing.Point(61, 151);
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
            this.lblNum.Location = new System.Drawing.Point(61, 232);
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
            this.lblSpecChar.Location = new System.Drawing.Point(61, 278);
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
            this.lblRepeatPass.Location = new System.Drawing.Point(61, 321);
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
            this.chkAskUser.Location = new System.Drawing.Point(405, 101);
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
            this.chkCombMayus.Location = new System.Drawing.Point(404, 151);
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
            this.chkNum.Location = new System.Drawing.Point(404, 232);
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
            this.chkSpecChar.Location = new System.Drawing.Point(404, 278);
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
            this.chkRepeatPass.Location = new System.Drawing.Point(404, 318);
            this.chkRepeatPass.Name = "chkRepeatPass";
            this.chkRepeatPass.Size = new System.Drawing.Size(61, 22);
            this.chkRepeatPass.TabIndex = 11;
            this.chkRepeatPass.Text = "si/no";
            this.chkRepeatPass.UseVisualStyleBackColor = true;
            this.chkRepeatPass.CheckedChanged += new System.EventHandler(this.chkRepeatPass_CheckedChanged);
            // 
            // btnAcceptAdmin
            // 
            this.btnAcceptAdmin.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAcceptAdmin.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnAcceptAdmin.FlatAppearance.BorderSize = 3;
            this.btnAcceptAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcceptAdmin.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcceptAdmin.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAcceptAdmin.Location = new System.Drawing.Point(75, 519);
            this.btnAcceptAdmin.Name = "btnAcceptAdmin";
            this.btnAcceptAdmin.Size = new System.Drawing.Size(185, 39);
            this.btnAcceptAdmin.TabIndex = 14;
            this.btnAcceptAdmin.Text = "Aceptar";
            this.btnAcceptAdmin.UseVisualStyleBackColor = true;
            this.btnAcceptAdmin.Click += new System.EventHandler(this.btnAcceptAdmin_Click);
            // 
            // numCaracteres
            // 
            this.numCaracteres.Enabled = false;
            this.numCaracteres.Location = new System.Drawing.Point(483, 50);
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
            this.numPreguntas.Location = new System.Drawing.Point(483, 100);
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
            this.chkCombMin.Location = new System.Drawing.Point(404, 191);
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
            this.label1.Location = new System.Drawing.Point(61, 191);
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
            this.chkCantidadCaracteres.Location = new System.Drawing.Point(405, 51);
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
            this.numContrasAnteriores.Location = new System.Drawing.Point(483, 321);
            this.numContrasAnteriores.Name = "numContrasAnteriores";
            this.numContrasAnteriores.Size = new System.Drawing.Size(120, 20);
            this.numContrasAnteriores.TabIndex = 21;
            this.numContrasAnteriores.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // lblDiasContra
            // 
            this.lblDiasContra.AutoSize = true;
            this.lblDiasContra.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lblDiasContra.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDiasContra.Location = new System.Drawing.Point(61, 361);
            this.lblDiasContra.Name = "lblDiasContra";
            this.lblDiasContra.Size = new System.Drawing.Size(255, 19);
            this.lblDiasContra.TabIndex = 5;
            this.lblDiasContra.Text = "Dias de vigencia de contraseña";
            // 
            // numDiasContra
            // 
            this.numDiasContra.Enabled = false;
            this.numDiasContra.Location = new System.Drawing.Point(483, 364);
            this.numDiasContra.Name = "numDiasContra";
            this.numDiasContra.Size = new System.Drawing.Size(120, 20);
            this.numDiasContra.TabIndex = 21;
            this.numDiasContra.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnCancelar.FlatAppearance.BorderSize = 3;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancelar.Location = new System.Drawing.Point(404, 519);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(165, 39);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblFallos
            // 
            this.lblFallos.AutoSize = true;
            this.lblFallos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lblFallos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblFallos.Location = new System.Drawing.Point(61, 404);
            this.lblFallos.Name = "lblFallos";
            this.lblFallos.Size = new System.Drawing.Size(316, 19);
            this.lblFallos.TabIndex = 5;
            this.lblFallos.Text = "Cantidad de intentos fallidos aceptados";
            // 
            // numFallos
            // 
            this.numFallos.Enabled = false;
            this.numFallos.Location = new System.Drawing.Point(483, 403);
            this.numFallos.Name = "numFallos";
            this.numFallos.Size = new System.Drawing.Size(120, 20);
            this.numFallos.TabIndex = 21;
            this.numFallos.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // chkDiasContra
            // 
            this.chkDiasContra.AutoSize = true;
            this.chkDiasContra.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold);
            this.chkDiasContra.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.chkDiasContra.Location = new System.Drawing.Point(405, 362);
            this.chkDiasContra.Name = "chkDiasContra";
            this.chkDiasContra.Size = new System.Drawing.Size(61, 22);
            this.chkDiasContra.TabIndex = 22;
            this.chkDiasContra.Text = "si/no";
            this.chkDiasContra.UseVisualStyleBackColor = true;
            this.chkDiasContra.CheckedChanged += new System.EventHandler(this.chkDiasContra_CheckedChanged);
            // 
            // chkFallos
            // 
            this.chkFallos.AutoSize = true;
            this.chkFallos.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold);
            this.chkFallos.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.chkFallos.Location = new System.Drawing.Point(404, 401);
            this.chkFallos.Name = "chkFallos";
            this.chkFallos.Size = new System.Drawing.Size(61, 22);
            this.chkFallos.TabIndex = 23;
            this.chkFallos.Text = "si/no";
            this.chkFallos.UseVisualStyleBackColor = true;
            this.chkFallos.CheckedChanged += new System.EventHandler(this.chkFallos_CheckedChanged);
            // 
            // frmAdminSyst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(671, 579);
            this.Controls.Add(this.chkFallos);
            this.Controls.Add(this.chkDiasContra);
            this.Controls.Add(this.numDiasContra);
            this.Controls.Add(this.numFallos);
            this.Controls.Add(this.numContrasAnteriores);
            this.Controls.Add(this.chkCombMin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numPreguntas);
            this.Controls.Add(this.numCaracteres);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAcceptAdmin);
            this.Controls.Add(this.chkRepeatPass);
            this.Controls.Add(this.chkSpecChar);
            this.Controls.Add(this.chkNum);
            this.Controls.Add(this.chkCombMayus);
            this.Controls.Add(this.chkAskUser);
            this.Controls.Add(this.lblDiasContra);
            this.Controls.Add(this.lblFallos);
            this.Controls.Add(this.chkCantidadCaracteres);
            this.Controls.Add(this.lblRepeatPass);
            this.Controls.Add(this.lblSpecChar);
            this.Controls.Add(this.lblNum);
            this.Controls.Add(this.lblCombMayus);
            this.Controls.Add(this.lblAskUser);
            this.Controls.Add(this.lblPassCharVerification);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAdminSyst";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Administrar Sistema";
            this.Load += new System.EventHandler(this.frmAdminSyst_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numCaracteres)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPreguntas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numContrasAnteriores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiasContra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFallos)).EndInit();
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
        private System.Windows.Forms.Label lblDiasContra;
        private System.Windows.Forms.NumericUpDown numDiasContra;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblFallos;
        private System.Windows.Forms.NumericUpDown numFallos;
        private System.Windows.Forms.CheckBox chkDiasContra;
        private System.Windows.Forms.CheckBox chkFallos;
    }
}