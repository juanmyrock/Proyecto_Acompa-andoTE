namespace CapaVistas.Forms_Menu // O tu namespace
{
    partial class frmGestionTramites
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
            this.gbBusqueda = new System.Windows.Forms.GroupBox();
            this.lbTramites = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscarPaciente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlChat = new System.Windows.Forms.Panel();
            this.pnlEnviarMensaje = new System.Windows.Forms.Panel();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.txtMensaje = new System.Windows.Forms.TextBox();
            this.gbEstado = new System.Windows.Forms.GroupBox();
            this.btnCambiarEstado = new System.Windows.Forms.Button();
            this.cmbNuevoEstado = new System.Windows.Forms.ComboBox();
            this.lblEstadoActual = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTramiteSeleccionado = new System.Windows.Forms.Label();
            this.gbBusqueda.SuspendLayout();
            this.pnlEnviarMensaje.SuspendLayout();
            this.gbEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbBusqueda
            // 
            this.gbBusqueda.Controls.Add(this.lbTramites);
            this.gbBusqueda.Controls.Add(this.label2);
            this.gbBusqueda.Controls.Add(this.btnBuscar);
            this.gbBusqueda.Controls.Add(this.txtBuscarPaciente);
            this.gbBusqueda.Controls.Add(this.label1);
            this.gbBusqueda.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbBusqueda.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.gbBusqueda.Location = new System.Drawing.Point(25, 50);
            this.gbBusqueda.Name = "gbBusqueda";
            this.gbBusqueda.Size = new System.Drawing.Size(320, 250);
            this.gbBusqueda.TabIndex = 2;
            this.gbBusqueda.TabStop = false;
            this.gbBusqueda.Text = "Búsqueda";
            // 
            // lbTramites
            // 
            this.lbTramites.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lbTramites.ForeColor = System.Drawing.Color.White;
            this.lbTramites.FormattingEnabled = true;
            this.lbTramites.ItemHeight = 14;
            this.lbTramites.Location = new System.Drawing.Point(20, 115);
            this.lbTramites.Name = "lbTramites";
            this.lbTramites.Size = new System.Drawing.Size(280, 116);
            this.lbTramites.TabIndex = 4;
            this.lbTramites.SelectedIndexChanged += new System.EventHandler(this.lbTramites_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "Trámites del Paciente:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Location = new System.Drawing.Point(225, 50);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBuscarPaciente
            // 
            this.txtBuscarPaciente.Location = new System.Drawing.Point(20, 50);
            this.txtBuscarPaciente.Name = "txtBuscarPaciente";
            this.txtBuscarPaciente.Size = new System.Drawing.Size(200, 22);
            this.txtBuscarPaciente.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar Paciente (DNI o Apellido):";
            // 
            // pnlChat
            // 
            this.pnlChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlChat.AutoScroll = true;
            this.pnlChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.pnlChat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlChat.Location = new System.Drawing.Point(365, 75);
            this.pnlChat.Name = "pnlChat";
            this.pnlChat.Size = new System.Drawing.Size(673, 444);
            this.pnlChat.TabIndex = 3;
            // 
            // pnlEnviarMensaje
            // 
            this.pnlEnviarMensaje.Controls.Add(this.btnEnviar);
            this.pnlEnviarMensaje.Controls.Add(this.txtMensaje);
            this.pnlEnviarMensaje.Location = new System.Drawing.Point(365, 535);
            this.pnlEnviarMensaje.Name = "pnlEnviarMensaje";
            this.pnlEnviarMensaje.Size = new System.Drawing.Size(673, 50);
            this.pnlEnviarMensaje.TabIndex = 4;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnviar.FlatAppearance.BorderColor = System.Drawing.Color.Aqua;
            this.btnEnviar.FlatAppearance.BorderSize = 2;
            this.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviar.Font = new System.Drawing.Font("Sans Serif Collection", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnEnviar.Location = new System.Drawing.Point(555, 5);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(115, 40);
            this.btnEnviar.TabIndex = 1;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // txtMensaje
            // 
            this.txtMensaje.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMensaje.Location = new System.Drawing.Point(5, 5);
            this.txtMensaje.Multiline = true;
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Size = new System.Drawing.Size(540, 40);
            this.txtMensaje.TabIndex = 0;
            // 
            // gbEstado
            // 
            this.gbEstado.Controls.Add(this.btnCambiarEstado);
            this.gbEstado.Controls.Add(this.cmbNuevoEstado);
            this.gbEstado.Controls.Add(this.lblEstadoActual);
            this.gbEstado.Controls.Add(this.label4);
            this.gbEstado.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbEstado.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.gbEstado.Location = new System.Drawing.Point(25, 315);
            this.gbEstado.Name = "gbEstado";
            this.gbEstado.Size = new System.Drawing.Size(320, 204);
            this.gbEstado.TabIndex = 5;
            this.gbEstado.TabStop = false;
            this.gbEstado.Text = "Estado del Trámite";
            // 
            // btnCambiarEstado
            // 
            this.btnCambiarEstado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCambiarEstado.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnCambiarEstado.FlatAppearance.BorderSize = 2;
            this.btnCambiarEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiarEstado.Font = new System.Drawing.Font("Sans Serif Collection", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiarEstado.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnCambiarEstado.Location = new System.Drawing.Point(64, 150);
            this.btnCambiarEstado.Name = "btnCambiarEstado";
            this.btnCambiarEstado.Size = new System.Drawing.Size(200, 40);
            this.btnCambiarEstado.TabIndex = 5;
            this.btnCambiarEstado.Text = "Cambiar Estado";
            this.btnCambiarEstado.UseVisualStyleBackColor = true;
            this.btnCambiarEstado.Click += new System.EventHandler(this.btnCambiarEstado_Click);
            // 
            // cmbNuevoEstado
            // 
            this.cmbNuevoEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNuevoEstado.FormattingEnabled = true;
            this.cmbNuevoEstado.Items.AddRange(new object[] {
            "Pago vencido",
            "Pago al dia",
            "Pendiente a profesional",
            "Profesional asignado",
            "Autorizacion O.S pendiente",
            "O.S autorizada",
            "Turno asignado",
            "Turno cancelado",
            "Turno perdido",
            "Asistió turno"});
            this.cmbNuevoEstado.Location = new System.Drawing.Point(20, 115);
            this.cmbNuevoEstado.Name = "cmbNuevoEstado";
            this.cmbNuevoEstado.Size = new System.Drawing.Size(280, 22);
            this.cmbNuevoEstado.TabIndex = 2;
            // 
            // lblEstadoActual
            // 
            this.lblEstadoActual.BackColor = System.Drawing.Color.DimGray;
            this.lblEstadoActual.Font = new System.Drawing.Font("Sans Serif Collection", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadoActual.Location = new System.Drawing.Point(20, 50);
            this.lblEstadoActual.Name = "lblEstadoActual";
            this.lblEstadoActual.Size = new System.Drawing.Size(280, 40);
            this.lblEstadoActual.TabIndex = 1;
            this.lblEstadoActual.Text = "Seleccione un trámite...";
            this.lblEstadoActual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "Estado Actual:";
            // 
            // lblTramiteSeleccionado
            // 
            this.lblTramiteSeleccionado.AutoSize = true;
            this.lblTramiteSeleccionado.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTramiteSeleccionado.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTramiteSeleccionado.Location = new System.Drawing.Point(365, 45);
            this.lblTramiteSeleccionado.Name = "lblTramiteSeleccionado";
            this.lblTramiteSeleccionado.Size = new System.Drawing.Size(271, 23);
            this.lblTramiteSeleccionado.TabIndex = 6;
            this.lblTramiteSeleccionado.Text = "Seleccione un trámite para ver";
            // 
            // frmGestionTramites
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1063, 605);
            this.Controls.Add(this.lblTramiteSeleccionado);
            this.Controls.Add(this.gbEstado);
            this.Controls.Add(this.pnlEnviarMensaje);
            this.Controls.Add(this.pnlChat);
            this.Controls.Add(this.gbBusqueda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmGestionTramites";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmGestionTramitesChat";
            this.gbBusqueda.ResumeLayout(false);
            this.gbBusqueda.PerformLayout();
            this.pnlEnviarMensaje.ResumeLayout(false);
            this.pnlEnviarMensaje.PerformLayout();
            this.gbEstado.ResumeLayout(false);
            this.gbEstado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox gbBusqueda;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBuscarPaciente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbTramites;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlChat;
        private System.Windows.Forms.Panel pnlEnviarMensaje;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.TextBox txtMensaje;
        private System.Windows.Forms.GroupBox gbEstado;
        private System.Windows.Forms.Label lblEstadoActual;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCambiarEstado;
        private System.Windows.Forms.ComboBox cmbNuevoEstado;
        private System.Windows.Forms.Label lblTramiteSeleccionado;
    }
}