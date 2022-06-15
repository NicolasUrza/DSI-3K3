namespace AplicacionRecursosTecnologicos.Views
{
    partial class dgvTurno
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
            this.dgvTurnos = new System.Windows.Forms.DataGridView();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diaDeLaSemana = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoraDesde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoraHasta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTurnos
            // 
            this.dgvTurnos.AllowUserToAddRows = false;
            this.dgvTurnos.AllowUserToDeleteRows = false;
            this.dgvTurnos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvTurnos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTurnos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTurnos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fecha,
            this.diaDeLaSemana,
            this.HoraDesde,
            this.HoraHasta,
            this.Estado});
            this.dgvTurnos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTurnos.Location = new System.Drawing.Point(0, 0);
            this.dgvTurnos.Name = "dgvTurnos";
            this.dgvTurnos.ReadOnly = true;
            this.dgvTurnos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTurnos.RowTemplate.Height = 25;
            this.dgvTurnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTurnos.ShowEditingIcon = false;
            this.dgvTurnos.Size = new System.Drawing.Size(800, 450);
            this.dgvTurnos.TabIndex = 2;
            // 
            // fecha
            // 
            this.fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fecha.HeaderText = "Fecha";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            // 
            // diaDeLaSemana
            // 
            this.diaDeLaSemana.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.diaDeLaSemana.HeaderText = "Dia De La Semana";
            this.diaDeLaSemana.Name = "diaDeLaSemana";
            this.diaDeLaSemana.ReadOnly = true;
            // 
            // HoraDesde
            // 
            this.HoraDesde.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.HoraDesde.HeaderText = "Hora Desde";
            this.HoraDesde.Name = "HoraDesde";
            this.HoraDesde.ReadOnly = true;
            // 
            // HoraHasta
            // 
            this.HoraHasta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.HoraHasta.HeaderText = "Hora Hasta";
            this.HoraHasta.Name = "HoraHasta";
            this.HoraHasta.ReadOnly = true;
            // 
            // Estado
            // 
            this.Estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            // 
            // dgvTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvTurnos);
            this.Name = "dgvTurno";
            this.Text = "dgvTurno";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgvTurnos;
        private DataGridViewTextBoxColumn fecha;
        private DataGridViewTextBoxColumn diaDeLaSemana;
        private DataGridViewTextBoxColumn HoraDesde;
        private DataGridViewTextBoxColumn HoraHasta;
        private DataGridViewTextBoxColumn Estado;
    }
}