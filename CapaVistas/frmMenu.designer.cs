using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVistas
{
    partial class frmMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.panelBarraClose = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTittle2 = new System.Windows.Forms.Label();
            this.lblTittle = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.btnOcultar = new System.Windows.Forms.PictureBox();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnLogOut = new System.Windows.Forms.PictureBox();
            this.lblUserLog = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.picReportes = new System.Windows.Forms.PictureBox();
            this.picFacturas = new System.Windows.Forms.PictureBox();
            this.picClientes = new System.Windows.Forms.PictureBox();
            this.picVentas = new System.Windows.Forms.PictureBox();
            this.picProductos = new System.Windows.Forms.PictureBox();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnTurnos = new System.Windows.Forms.Button();
            this.btnInformes = new System.Windows.Forms.Button();
            this.btnProfesionales = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPacientes = new System.Windows.Forms.Button();
            this.logoMenu = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.btnRoles = new System.Windows.Forms.Button();
            this.btnConfigSist = new System.Windows.Forms.PictureBox();
            this.btnAdministrar = new System.Windows.Forms.Button();
            this.btnCerrarForm = new System.Windows.Forms.PictureBox();
            this.panelChildFrm = new System.Windows.Forms.Panel();
            this.panelBarraClose.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOcultar)).BeginInit();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picReportes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFacturas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoMenu)).BeginInit();
            this.panelTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnConfigSist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrarForm)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBarraClose
            // 
            this.panelBarraClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelBarraClose.Controls.Add(this.pictureBox1);
            this.panelBarraClose.Controls.Add(this.lblTittle2);
            this.panelBarraClose.Controls.Add(this.lblTittle);
            this.panelBarraClose.Controls.Add(this.btnCerrar);
            this.panelBarraClose.Controls.Add(this.btnOcultar);
            this.panelBarraClose.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.panelBarraClose.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBarraClose.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.panelBarraClose.Location = new System.Drawing.Point(0, 0);
            this.panelBarraClose.Margin = new System.Windows.Forms.Padding(2);
            this.panelBarraClose.Name = "panelBarraClose";
            this.panelBarraClose.Size = new System.Drawing.Size(1280, 35);
            this.panelBarraClose.TabIndex = 0;
            this.panelBarraClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelBarraClose_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // lblTittle2
            // 
            this.lblTittle2.AutoSize = true;
            this.lblTittle2.BackColor = System.Drawing.Color.Transparent;
            this.lblTittle2.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTittle2.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblTittle2.Location = new System.Drawing.Point(671, 1);
            this.lblTittle2.Name = "lblTittle2";
            this.lblTittle2.Size = new System.Drawing.Size(35, 33);
            this.lblTittle2.TabIndex = 7;
            this.lblTittle2.Text = "TE";
            // 
            // lblTittle
            // 
            this.lblTittle.AutoSize = true;
            this.lblTittle.BackColor = System.Drawing.Color.Transparent;
            this.lblTittle.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTittle.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTittle.Location = new System.Drawing.Point(540, 1);
            this.lblTittle.Name = "lblTittle";
            this.lblTittle.Size = new System.Drawing.Size(140, 33);
            this.lblTittle.TabIndex = 6;
            this.lblTittle.Text = "Acompañando";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(1244, 4);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(25, 25);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnOcultar
            // 
            this.btnOcultar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOcultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOcultar.Image = ((System.Drawing.Image)(resources.GetObject("btnOcultar.Image")));
            this.btnOcultar.Location = new System.Drawing.Point(1211, 4);
            this.btnOcultar.Margin = new System.Windows.Forms.Padding(2);
            this.btnOcultar.Name = "btnOcultar";
            this.btnOcultar.Size = new System.Drawing.Size(25, 25);
            this.btnOcultar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnOcultar.TabIndex = 2;
            this.btnOcultar.TabStop = false;
            this.btnOcultar.Click += new System.EventHandler(this.btnOcultar_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(39)))), ((int)(((byte)(55)))));
            this.panelMenu.Controls.Add(this.btnLogOut);
            this.panelMenu.Controls.Add(this.lblUserLog);
            this.panelMenu.Controls.Add(this.panel8);
            this.panelMenu.Controls.Add(this.pictureBox2);
            this.panelMenu.Controls.Add(this.btnUsuarios);
            this.panelMenu.Controls.Add(this.panel7);
            this.panelMenu.Controls.Add(this.picReportes);
            this.panelMenu.Controls.Add(this.picFacturas);
            this.panelMenu.Controls.Add(this.picClientes);
            this.panelMenu.Controls.Add(this.picVentas);
            this.panelMenu.Controls.Add(this.picProductos);
            this.panelMenu.Controls.Add(this.btnReportes);
            this.panelMenu.Controls.Add(this.btnTurnos);
            this.panelMenu.Controls.Add(this.btnInformes);
            this.panelMenu.Controls.Add(this.btnProfesionales);
            this.panelMenu.Controls.Add(this.panel5);
            this.panelMenu.Controls.Add(this.panel4);
            this.panelMenu.Controls.Add(this.panel3);
            this.panelMenu.Controls.Add(this.panel2);
            this.panelMenu.Controls.Add(this.panel1);
            this.panelMenu.Controls.Add(this.btnPacientes);
            this.panelMenu.Controls.Add(this.logoMenu);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 35);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(2);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(217, 753);
            this.panelMenu.TabIndex = 3;
            // 
            // btnLogOut
            // 
            this.btnLogOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogOut.Image = ((System.Drawing.Image)(resources.GetObject("btnLogOut.Image")));
            this.btnLogOut.Location = new System.Drawing.Point(169, 205);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(45, 45);
            this.btnLogOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnLogOut.TabIndex = 20;
            this.btnLogOut.TabStop = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // lblUserLog
            // 
            this.lblUserLog.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserLog.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblUserLog.Location = new System.Drawing.Point(31, 203);
            this.lblUserLog.Name = "lblUserLog";
            this.lblUserLog.Size = new System.Drawing.Size(132, 60);
            this.lblUserLog.TabIndex = 0;
            this.lblUserLog.Text = "Don Pepito";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel8.Location = new System.Drawing.Point(0, 205);
            this.panel8.Margin = new System.Windows.Forms.Padding(2);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(10, 45);
            this.panel8.TabIndex = 3;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Enabled = false;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1, 648);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 26;
            this.pictureBox2.TabStop = false;
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsuarios.FlatAppearance.BorderSize = 0;
            this.btnUsuarios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarios.Font = new System.Drawing.Font("Century Gothic", 13.74545F);
            this.btnUsuarios.ForeColor = System.Drawing.Color.White;
            this.btnUsuarios.Location = new System.Drawing.Point(11, 648);
            this.btnUsuarios.Margin = new System.Windows.Forms.Padding(2);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(228, 40);
            this.btnUsuarios.TabIndex = 25;
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.UseVisualStyleBackColor = false;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel7.Location = new System.Drawing.Point(-1, 648);
            this.panel7.Margin = new System.Windows.Forms.Padding(2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(10, 40);
            this.panel7.TabIndex = 24;
            // 
            // picReportes
            // 
            this.picReportes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picReportes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picReportes.Enabled = false;
            this.picReportes.Image = ((System.Drawing.Image)(resources.GetObject("picReportes.Image")));
            this.picReportes.Location = new System.Drawing.Point(2, 575);
            this.picReportes.Margin = new System.Windows.Forms.Padding(2);
            this.picReportes.Name = "picReportes";
            this.picReportes.Size = new System.Drawing.Size(40, 40);
            this.picReportes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picReportes.TabIndex = 18;
            this.picReportes.TabStop = false;
            // 
            // picFacturas
            // 
            this.picFacturas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picFacturas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picFacturas.Enabled = false;
            this.picFacturas.Image = global::CapaVistas.Properties.Resources.Calendario1;
            this.picFacturas.Location = new System.Drawing.Point(2, 500);
            this.picFacturas.Margin = new System.Windows.Forms.Padding(2);
            this.picFacturas.Name = "picFacturas";
            this.picFacturas.Size = new System.Drawing.Size(40, 40);
            this.picFacturas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFacturas.TabIndex = 17;
            this.picFacturas.TabStop = false;
            // 
            // picClientes
            // 
            this.picClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picClientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClientes.Enabled = false;
            this.picClientes.Image = ((System.Drawing.Image)(resources.GetObject("picClientes.Image")));
            this.picClientes.Location = new System.Drawing.Point(2, 426);
            this.picClientes.Margin = new System.Windows.Forms.Padding(2);
            this.picClientes.Name = "picClientes";
            this.picClientes.Size = new System.Drawing.Size(40, 40);
            this.picClientes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picClientes.TabIndex = 16;
            this.picClientes.TabStop = false;
            // 
            // picVentas
            // 
            this.picVentas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picVentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picVentas.Enabled = false;
            this.picVentas.Image = global::CapaVistas.Properties.Resources.AT;
            this.picVentas.Location = new System.Drawing.Point(2, 354);
            this.picVentas.Margin = new System.Windows.Forms.Padding(2);
            this.picVentas.Name = "picVentas";
            this.picVentas.Size = new System.Drawing.Size(40, 40);
            this.picVentas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picVentas.TabIndex = 15;
            this.picVentas.TabStop = false;
            // 
            // picProductos
            // 
            this.picProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picProductos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picProductos.Enabled = false;
            this.picProductos.Image = global::CapaVistas.Properties.Resources.Pacientes_jpg;
            this.picProductos.Location = new System.Drawing.Point(2, 277);
            this.picProductos.Margin = new System.Windows.Forms.Padding(2);
            this.picProductos.Name = "picProductos";
            this.picProductos.Size = new System.Drawing.Size(40, 40);
            this.picProductos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picProductos.TabIndex = 4;
            this.picProductos.TabStop = false;
            // 
            // btnReportes
            // 
            this.btnReportes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnReportes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReportes.FlatAppearance.BorderSize = 0;
            this.btnReportes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportes.Font = new System.Drawing.Font("Century Gothic", 13.74545F);
            this.btnReportes.ForeColor = System.Drawing.Color.White;
            this.btnReportes.Location = new System.Drawing.Point(12, 575);
            this.btnReportes.Margin = new System.Windows.Forms.Padding(2);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(228, 40);
            this.btnReportes.TabIndex = 14;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.UseVisualStyleBackColor = false;
            // 
            // btnTurnos
            // 
            this.btnTurnos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnTurnos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTurnos.FlatAppearance.BorderSize = 0;
            this.btnTurnos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnTurnos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTurnos.Font = new System.Drawing.Font("Century Gothic", 13.74545F);
            this.btnTurnos.ForeColor = System.Drawing.Color.White;
            this.btnTurnos.Location = new System.Drawing.Point(12, 500);
            this.btnTurnos.Margin = new System.Windows.Forms.Padding(2);
            this.btnTurnos.Name = "btnTurnos";
            this.btnTurnos.Size = new System.Drawing.Size(228, 40);
            this.btnTurnos.TabIndex = 13;
            this.btnTurnos.Text = "Turnos";
            this.btnTurnos.UseVisualStyleBackColor = false;
            // 
            // btnInformes
            // 
            this.btnInformes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnInformes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInformes.FlatAppearance.BorderSize = 0;
            this.btnInformes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnInformes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInformes.Font = new System.Drawing.Font("Century Gothic", 13.74545F);
            this.btnInformes.ForeColor = System.Drawing.Color.White;
            this.btnInformes.Location = new System.Drawing.Point(12, 426);
            this.btnInformes.Margin = new System.Windows.Forms.Padding(2);
            this.btnInformes.Name = "btnInformes";
            this.btnInformes.Size = new System.Drawing.Size(228, 40);
            this.btnInformes.TabIndex = 12;
            this.btnInformes.Text = "Informes";
            this.btnInformes.UseVisualStyleBackColor = false;
            // 
            // btnProfesionales
            // 
            this.btnProfesionales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnProfesionales.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProfesionales.FlatAppearance.BorderSize = 0;
            this.btnProfesionales.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnProfesionales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfesionales.Font = new System.Drawing.Font("Century Gothic", 13.74545F);
            this.btnProfesionales.ForeColor = System.Drawing.Color.White;
            this.btnProfesionales.Location = new System.Drawing.Point(12, 354);
            this.btnProfesionales.Margin = new System.Windows.Forms.Padding(2);
            this.btnProfesionales.Name = "btnProfesionales";
            this.btnProfesionales.Size = new System.Drawing.Size(228, 40);
            this.btnProfesionales.TabIndex = 11;
            this.btnProfesionales.Text = "     Profesionales";
            this.btnProfesionales.UseVisualStyleBackColor = false;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel5.Location = new System.Drawing.Point(0, 575);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(10, 40);
            this.panel5.TabIndex = 10;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel4.Location = new System.Drawing.Point(0, 500);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 40);
            this.panel4.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel3.Location = new System.Drawing.Point(0, 426);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 40);
            this.panel3.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel2.Location = new System.Drawing.Point(0, 354);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 40);
            this.panel2.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel1.Location = new System.Drawing.Point(0, 277);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 40);
            this.panel1.TabIndex = 2;
            // 
            // btnPacientes
            // 
            this.btnPacientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnPacientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPacientes.FlatAppearance.BorderSize = 0;
            this.btnPacientes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnPacientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPacientes.Font = new System.Drawing.Font("Century Gothic", 13.74545F);
            this.btnPacientes.ForeColor = System.Drawing.Color.White;
            this.btnPacientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPacientes.Location = new System.Drawing.Point(12, 277);
            this.btnPacientes.Margin = new System.Windows.Forms.Padding(2);
            this.btnPacientes.Name = "btnPacientes";
            this.btnPacientes.Size = new System.Drawing.Size(228, 40);
            this.btnPacientes.TabIndex = 1;
            this.btnPacientes.Text = "Pacientes";
            this.btnPacientes.UseVisualStyleBackColor = false;
            this.btnPacientes.Click += new System.EventHandler(this.btnPacientes_Click);
            // 
            // logoMenu
            // 
            this.logoMenu.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.logoMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoMenu.Image = global::CapaVistas.Properties.Resources.AcompanandoTe_sin_texto;
            this.logoMenu.Location = new System.Drawing.Point(0, 0);
            this.logoMenu.Margin = new System.Windows.Forms.Padding(2);
            this.logoMenu.Name = "logoMenu";
            this.logoMenu.Size = new System.Drawing.Size(217, 201);
            this.logoMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoMenu.TabIndex = 0;
            this.logoMenu.TabStop = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(39)))), ((int)(((byte)(55)))));
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.29091F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTitulo.Location = new System.Drawing.Point(16, 13);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(87, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Inicio";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelTitulo
            // 
            this.panelTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(39)))), ((int)(((byte)(55)))));
            this.panelTitulo.Controls.Add(this.btnRoles);
            this.panelTitulo.Controls.Add(this.btnConfigSist);
            this.panelTitulo.Controls.Add(this.btnAdministrar);
            this.panelTitulo.Controls.Add(this.btnCerrarForm);
            this.panelTitulo.Controls.Add(this.lblTitulo);
            this.panelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo.Location = new System.Drawing.Point(217, 35);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(1063, 60);
            this.panelTitulo.TabIndex = 3;
            // 
            // btnRoles
            // 
            this.btnRoles.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnRoles.FlatAppearance.BorderSize = 2;
            this.btnRoles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoles.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoles.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRoles.Location = new System.Drawing.Point(710, 5);
            this.btnRoles.Name = "btnRoles";
            this.btnRoles.Size = new System.Drawing.Size(104, 49);
            this.btnRoles.TabIndex = 31;
            this.btnRoles.Text = "Roles";
            this.btnRoles.UseVisualStyleBackColor = true;
            this.btnRoles.Click += new System.EventHandler(this.btnRoles_Click);
            // 
            // btnConfigSist
            // 
            this.btnConfigSist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfigSist.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnConfigSist.Image = ((System.Drawing.Image)(resources.GetObject("btnConfigSist.Image")));
            this.btnConfigSist.Location = new System.Drawing.Point(944, 5);
            this.btnConfigSist.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfigSist.Name = "btnConfigSist";
            this.btnConfigSist.Size = new System.Drawing.Size(36, 50);
            this.btnConfigSist.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnConfigSist.TabIndex = 29;
            this.btnConfigSist.TabStop = false;
            // 
            // btnAdministrar
            // 
            this.btnAdministrar.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnAdministrar.FlatAppearance.BorderSize = 2;
            this.btnAdministrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdministrar.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdministrar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAdministrar.Location = new System.Drawing.Point(838, 5);
            this.btnAdministrar.Name = "btnAdministrar";
            this.btnAdministrar.Size = new System.Drawing.Size(104, 49);
            this.btnAdministrar.TabIndex = 30;
            this.btnAdministrar.Text = "Parametros Contraseña";
            this.btnAdministrar.UseVisualStyleBackColor = true;
            this.btnAdministrar.Click += new System.EventHandler(this.btnAdministrar_Click);
            // 
            // btnCerrarForm
            // 
            this.btnCerrarForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarForm.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrarForm.Image")));
            this.btnCerrarForm.Location = new System.Drawing.Point(1017, 13);
            this.btnCerrarForm.Name = "btnCerrarForm";
            this.btnCerrarForm.Size = new System.Drawing.Size(35, 35);
            this.btnCerrarForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrarForm.TabIndex = 29;
            this.btnCerrarForm.TabStop = false;
            this.btnCerrarForm.Visible = false;
            this.btnCerrarForm.Click += new System.EventHandler(this.btnCerrarForm_Click);
            // 
            // panelChildFrm
            // 
            this.panelChildFrm.AutoScroll = true;
            this.panelChildFrm.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panelChildFrm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChildFrm.Location = new System.Drawing.Point(217, 95);
            this.panelChildFrm.Name = "panelChildFrm";
            this.panelChildFrm.Size = new System.Drawing.Size(1063, 693);
            this.panelChildFrm.TabIndex = 4;
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1280, 788);
            this.Controls.Add(this.panelChildFrm);
            this.Controls.Add(this.panelTitulo);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelBarraClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmMenu";
            this.Text = "frmMenu";
            this.panelBarraClose.ResumeLayout(false);
            this.panelBarraClose.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOcultar)).EndInit();
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnLogOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picReportes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFacturas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoMenu)).EndInit();
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnConfigSist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrarForm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelBarraClose;
        private PictureBox btnOcultar;
        private PictureBox btnCerrar;
        private Panel panelMenu;
        private PictureBox picReportes;
        private PictureBox picFacturas;
        private PictureBox picClientes;
        private PictureBox picVentas;
        private PictureBox picProductos;
        private Button btnReportes;
        private Button btnTurnos;
        private Button btnInformes;
        private Button btnProfesionales;
        private Panel panel5;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
        private Button btnPacientes;
        private PictureBox logoMenu;
        private PictureBox btnLogOut;
        private PictureBox pictureBox2;
        private Button btnUsuarios;
        private Panel panel7;
        private Panel panel8;
        private Panel panelTitulo;
        private Label lblTitulo;
        private PictureBox btnCerrarForm;
        private PictureBox btnConfigSist;
        private Button btnAdministrar;
        private Label lblTittle2;
        private Label lblTittle;
        private PictureBox pictureBox1;
        private Panel panelChildFrm;
        private Label lblUserLog;
        private Button btnRoles;
    }
}