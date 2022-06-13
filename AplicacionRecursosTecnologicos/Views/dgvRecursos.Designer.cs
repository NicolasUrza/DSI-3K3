namespace AplicacionRecursosTecnologicos.Views
{
    partial class dgvRecursos
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
            this.dgvRT = new System.Windows.Forms.DataGridView();
            this.nroRT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sigla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRT)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRT
            // 
            this.dgvRT.AllowUserToAddRows = false;
            this.dgvRT.AllowUserToDeleteRows = false;
            this.dgvRT.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvRT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRT.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvRT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nroRT,
            this.Marca,
            this.Modelo,
            this.Estado,
            this.CI,
            this.Sigla});
            this.dgvRT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRT.Location = new System.Drawing.Point(0, 0);
            this.dgvRT.MultiSelect = false;
            this.dgvRT.Name = "dgvRT";
            this.dgvRT.ReadOnly = true;
            this.dgvRT.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvRT.RowTemplate.Height = 25;
            this.dgvRT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRT.ShowEditingIcon = false;
            this.dgvRT.Size = new System.Drawing.Size(800, 450);
            this.dgvRT.TabIndex = 2;
            // 
            // nroRT
            // 
            this.nroRT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.nroRT.HeaderText = "N° RT";
            this.nroRT.MinimumWidth = 30;
            this.nroRT.Name = "nroRT";
            this.nroRT.ReadOnly = true;
            this.nroRT.Width = 30;
            // 
            // Marca
            // 
            this.Marca.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Marca.HeaderText = "Marca";
            this.Marca.Name = "Marca";
            this.Marca.ReadOnly = true;
            // 
            // Modelo
            // 
            this.Modelo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Modelo.HeaderText = "Modelo";
            this.Modelo.Name = "Modelo";
            this.Modelo.ReadOnly = true;
            // 
            // Estado
            // 
            this.Estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            // 
            // CI
            // 
            this.CI.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CI.HeaderText = "Centro De Investigacion";
            this.CI.Name = "CI";
            this.CI.ReadOnly = true;
            // 
            // Sigla
            // 
            this.Sigla.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Sigla.HeaderText = "Sigla";
            this.Sigla.Name = "Sigla";
            this.Sigla.ReadOnly = true;
            // 
            // dgvRecursos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvRT);
            this.Name = "dgvRecursos";
            this.Text = "dgvRecursos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgvRT;
        private DataGridViewTextBoxColumn nroRT;
        private DataGridViewTextBoxColumn Marca;
        private DataGridViewTextBoxColumn Modelo;
        private DataGridViewTextBoxColumn Estado;
        private DataGridViewTextBoxColumn CI;
        private DataGridViewTextBoxColumn Sigla;
    }
}