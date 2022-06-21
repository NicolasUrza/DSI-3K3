namespace AplicacionRecursosTecnologicos.Views
{
    partial class dgvTipoRecurso
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
            this.dgvTiposRecurso = new System.Windows.Forms.DataGridView();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTiposRecurso)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTiposRecurso
            // 
            this.dgvTiposRecurso.AllowUserToAddRows = false;
            this.dgvTiposRecurso.AllowUserToDeleteRows = false;
            this.dgvTiposRecurso.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvTiposRecurso.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTiposRecurso.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTiposRecurso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTiposRecurso.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombre,
            this.descripcion});
            this.dgvTiposRecurso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTiposRecurso.Location = new System.Drawing.Point(0, 0);
            this.dgvTiposRecurso.Name = "dgvTiposRecurso";
            this.dgvTiposRecurso.ReadOnly = true;
            this.dgvTiposRecurso.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTiposRecurso.RowTemplate.Height = 25;
            this.dgvTiposRecurso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTiposRecurso.ShowEditingIcon = false;
            this.dgvTiposRecurso.Size = new System.Drawing.Size(800, 450);
            this.dgvTiposRecurso.TabIndex = 1;
            // 
            // nombre
            // 
            this.nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // descripcion
            // 
            this.descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descripcion.HeaderText = "Descripcion";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            // 
            // dgvTipoRecurso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvTiposRecurso);
            this.Name = "dgvTipoRecurso";
            this.Text = "dgvTipoRecurso";
            this.Load += new System.EventHandler(this.dgvTipoRecurso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTiposRecurso)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgvTiposRecurso;
        private DataGridViewTextBoxColumn nombre;
        private DataGridViewTextBoxColumn descripcion;
    }
}