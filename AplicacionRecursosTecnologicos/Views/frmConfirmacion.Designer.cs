namespace AplicacionRecursosTecnologicos.Views
{
    partial class frmConfirmacion
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
            this.lblInformacion = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cbMail = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbWpp = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblInformacion
            // 
            this.lblInformacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInformacion.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblInformacion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblInformacion.Location = new System.Drawing.Point(12, 7);
            this.lblInformacion.Name = "lblInformacion";
            this.lblInformacion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblInformacion.Size = new System.Drawing.Size(313, 175);
            this.lblInformacion.TabIndex = 6;
            this.lblInformacion.Text = "Informacion";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(250, 249);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmar.TabIndex = 7;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(12, 249);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cbMail
            // 
            this.cbMail.AutoSize = true;
            this.cbMail.Checked = true;
            this.cbMail.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMail.Location = new System.Drawing.Point(37, 211);
            this.cbMail.Name = "cbMail";
            this.cbMail.Size = new System.Drawing.Size(49, 19);
            this.cbMail.TabIndex = 9;
            this.cbMail.Text = "Mail";
            this.cbMail.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Notificar Via: ";
            // 
            // cbWpp
            // 
            this.cbWpp.AutoSize = true;
            this.cbWpp.Location = new System.Drawing.Point(199, 211);
            this.cbWpp.Name = "cbWpp";
            this.cbWpp.Size = new System.Drawing.Size(81, 19);
            this.cbWpp.TabIndex = 11;
            this.cbWpp.Text = "WhatsApp";
            this.cbWpp.UseVisualStyleBackColor = true;
            // 
            // frmConfirmacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 284);
            this.Controls.Add(this.cbWpp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbMail);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.lblInformacion);
            this.Name = "frmConfirmacion";
            this.Text = "frmConfirmacion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblInformacion;
        private Button btnConfirmar;
        private Button btnCancelar;
        private CheckBox cbMail;
        private Label label1;
        private CheckBox cbWpp;
    }
}