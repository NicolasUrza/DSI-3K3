using AplicacionRecursosTecnologicos.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicacionRecursosTecnologicos.Views
{
    public partial class dgvRecursos : Form
    {
        public dgvRecursos()
        {
            InitializeComponent();
        }

        public void MostrarRecursos(List<String[]> lrt)
        {
            this.dgvRT.Rows.Clear();
            var i = 0;

            foreach (var recurso in lrt)
            {

                this.dgvRT.Rows.Add(recurso);
                //coloreamos los estados de acuerdo al nombre
                if (recurso[3] == "Disponible")
                    this.dgvRT.Rows[i].Cells[3].Style.BackColor = Color.Blue;
                else if (recurso[3] == "En Mantenimiento")
                    this.dgvRT.Rows[i].Cells[3].Style.BackColor = Color.Green;
                else if (recurso[3] == "Con Inicio En Mantenimiento Correctivo")
                    this.dgvRT.Rows[i].Cells[3].Style.BackColor = Color.Gray;
                i ++;
            }
        }
        public bool verificarSeleccion()
        {
            return this.dgvRT.SelectedRows.Count == 1 && this.dgvRT.SelectedRows[0].Cells[3].Value.ToString() == "Disponible";
        }

        public RecursoTecnologico GetRTSeleccionado()
        {
            var RT = new RecursoTecnologico();
            RT.numeroRT = Convert.ToInt32(this.dgvRT.SelectedRows[0].Cells[0].Value.ToString());
            return RT;
        }
    }
}
