﻿namespace AplicacionRecursosTecnologicos
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pnHerramientas = new System.Windows.Forms.Panel();
            this.btnAviso = new System.Windows.Forms.Button();
            this.btnReservarTurno = new System.Windows.Forms.Button();
            this.pnContenido = new System.Windows.Forms.Panel();
            this.logoRemito = new System.Windows.Forms.PictureBox();
            this.logoUtn = new System.Windows.Forms.PictureBox();
            this.btnImagen = new System.Windows.Forms.Button();
            this.pnHerramientas.SuspendLayout();
            this.pnContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoRemito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoUtn)).BeginInit();
            this.SuspendLayout();
            // 
            // pnHerramientas
            // 
            this.pnHerramientas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.pnHerramientas.Controls.Add(this.btnImagen);
            this.pnHerramientas.Controls.Add(this.btnAviso);
            this.pnHerramientas.Controls.Add(this.btnReservarTurno);
            this.pnHerramientas.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHerramientas.Location = new System.Drawing.Point(0, 0);
            this.pnHerramientas.Name = "pnHerramientas";
            this.pnHerramientas.Size = new System.Drawing.Size(967, 80);
            this.pnHerramientas.TabIndex = 0;
            // 
            // btnAviso
            // 
            this.btnAviso.BackColor = System.Drawing.Color.Black;
            this.btnAviso.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAviso.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAviso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAviso.Location = new System.Drawing.Point(147, 0);
            this.btnAviso.Name = "btnAviso";
            this.btnAviso.Size = new System.Drawing.Size(147, 80);
            this.btnAviso.TabIndex = 1;
            this.btnAviso.Text = "Aviso";
            this.btnAviso.UseVisualStyleBackColor = false;
            this.btnAviso.Click += new System.EventHandler(this.btnAviso_Click);
            // 
            // btnReservarTurno
            // 
            this.btnReservarTurno.BackColor = System.Drawing.Color.Black;
            this.btnReservarTurno.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnReservarTurno.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnReservarTurno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReservarTurno.Location = new System.Drawing.Point(0, 0);
            this.btnReservarTurno.Name = "btnReservarTurno";
            this.btnReservarTurno.Size = new System.Drawing.Size(147, 80);
            this.btnReservarTurno.TabIndex = 0;
            this.btnReservarTurno.Text = "Reservar turno de recurso tecnologico";
            this.btnReservarTurno.UseVisualStyleBackColor = false;
            this.btnReservarTurno.Click += new System.EventHandler(this.opcReservarTurnoRT);
            // 
            // pnContenido
            // 
            this.pnContenido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnContenido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnContenido.Controls.Add(this.logoRemito);
            this.pnContenido.Controls.Add(this.logoUtn);
            this.pnContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContenido.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnContenido.Location = new System.Drawing.Point(0, 80);
            this.pnContenido.MinimumSize = new System.Drawing.Size(967, 495);
            this.pnContenido.Name = "pnContenido";
            this.pnContenido.Size = new System.Drawing.Size(967, 495);
            this.pnContenido.TabIndex = 1;
            // 
            // logoRemito
            // 
            this.logoRemito.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.logoRemito.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("logoRemito.BackgroundImage")));
            this.logoRemito.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.logoRemito.Location = new System.Drawing.Point(816, 405);
            this.logoRemito.Name = "logoRemito";
            this.logoRemito.Size = new System.Drawing.Size(151, 90);
            this.logoRemito.TabIndex = 1;
            this.logoRemito.TabStop = false;
            // 
            // logoUtn
            // 
            this.logoUtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.logoUtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("logoUtn.BackgroundImage")));
            this.logoUtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.logoUtn.Location = new System.Drawing.Point(185, 69);
            this.logoUtn.Name = "logoUtn";
            this.logoUtn.Size = new System.Drawing.Size(612, 305);
            this.logoUtn.TabIndex = 0;
            this.logoUtn.TabStop = false;
            // 
            // btnImagen
            // 
            this.btnImagen.BackColor = System.Drawing.Color.Black;
            this.btnImagen.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnImagen.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnImagen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImagen.Location = new System.Drawing.Point(294, 0);
            this.btnImagen.Name = "btnImagen";
            this.btnImagen.Size = new System.Drawing.Size(147, 80);
            this.btnImagen.TabIndex = 2;
            this.btnImagen.Text = "algo";
            this.btnImagen.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 575);
            this.Controls.Add(this.pnContenido);
            this.Controls.Add(this.pnHerramientas);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(983, 614);
            this.Name = "Form1";
            this.Text = "Recursos Tecnologicos";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnHerramientas.ResumeLayout(false);
            this.pnContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoRemito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoUtn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnHerramientas;
        private Button btnReservarTurno;
        private Panel pnContenido;
        private PictureBox logoRemito;
        private PictureBox logoUtn;
        private Button btnAviso;
        private Button btnImagen;
    }
}