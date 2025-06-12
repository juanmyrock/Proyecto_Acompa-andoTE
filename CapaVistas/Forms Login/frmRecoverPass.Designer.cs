namespace CapaVistas.Forms_Login
{
    partial class frmRecoverPass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecoverPass));
            this.lblRecover = new System.Windows.Forms.Label();
            this.lblInsertUser = new System.Windows.Forms.Label();
            this.txtRecoUser = new System.Windows.Forms.TextBox();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.picError = new System.Windows.Forms.PictureBox();
            this.lblErrorMsg = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRecover
            // 
            this.lblRecover.AutoSize = true;
            this.lblRecover.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecover.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblRecover.Location = new System.Drawing.Point(239, 33);
            this.lblRecover.Name = "lblRecover";
            this.lblRecover.Size = new System.Drawing.Size(288, 25);
            this.lblRecover.TabIndex = 0;
            this.lblRecover.Text = "Recuperación de contraseña";
            // 
            // lblInsertUser
            // 
            this.lblInsertUser.AutoSize = true;
            this.lblInsertUser.BackColor = System.Drawing.Color.Transparent;
            this.lblInsertUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertUser.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblInsertUser.Location = new System.Drawing.Point(150, 104);
            this.lblInsertUser.Name = "lblInsertUser";
            this.lblInsertUser.Size = new System.Drawing.Size(127, 20);
            this.lblInsertUser.TabIndex = 1;
            this.lblInsertUser.Text = "Ingresar Usuario";
            // 
            // txtRecoUser
            // 
            this.txtRecoUser.Location = new System.Drawing.Point(154, 127);
            this.txtRecoUser.Name = "txtRecoUser";
            this.txtRecoUser.Size = new System.Drawing.Size(415, 20);
            this.txtRecoUser.TabIndex = 2;
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestion.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblQuestion.Location = new System.Drawing.Point(150, 245);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(424, 20);
            this.lblQuestion.TabIndex = 3;
            this.lblQuestion.Text = "Pregunta de seguridad (Dios sabe que vamos a poner acá)";
            // 
            // txtAnswer
            // 
            this.txtAnswer.Location = new System.Drawing.Point(154, 277);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(415, 20);
            this.txtAnswer.TabIndex = 4;
            this.txtAnswer.Text = "Respuesta";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(534, 394);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(104, 23);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "Enviar Email";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(659, 394);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(104, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // picError
            // 
            this.picError.Image = ((System.Drawing.Image)(resources.GetObject("picError.Image")));
            this.picError.Location = new System.Drawing.Point(146, 325);
            this.picError.Name = "picError";
            this.picError.Size = new System.Drawing.Size(24, 27);
            this.picError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picError.TabIndex = 29;
            this.picError.TabStop = false;
            this.picError.Visible = false;
            // 
            // lblErrorMsg
            // 
            this.lblErrorMsg.AutoSize = true;
            this.lblErrorMsg.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.818182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorMsg.ForeColor = System.Drawing.Color.White;
            this.lblErrorMsg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblErrorMsg.Location = new System.Drawing.Point(168, 328);
            this.lblErrorMsg.Name = "lblErrorMsg";
            this.lblErrorMsg.Size = new System.Drawing.Size(109, 18);
            this.lblErrorMsg.TabIndex = 28;
            this.lblErrorMsg.Text = "Error Message";
            this.lblErrorMsg.Visible = false;
            // 
            // frmRecoverPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(20)))), ((int)(((byte)(88)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.picError);
            this.Controls.Add(this.lblErrorMsg);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtAnswer);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.txtRecoUser);
            this.Controls.Add(this.lblInsertUser);
            this.Controls.Add(this.lblRecover);
            this.Name = "frmRecoverPass";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRecover;
        private System.Windows.Forms.Label lblInsertUser;
        private System.Windows.Forms.TextBox txtRecoUser;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox picError;
        private System.Windows.Forms.Label lblErrorMsg;
    }
}