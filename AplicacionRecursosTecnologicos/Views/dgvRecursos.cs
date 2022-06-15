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

        public void MostrarRecursos(List<(RecursoTecnologico, CentroDeInvestigacion, Marca)> lrt)
        {
            this.dgvRT.Rows.Clear();
            var i = 0;

            foreach (var recurso in lrt)
            {

                var fila = new string[]
                    {
                        recurso.Item1.numeroRT.ToString(),
                        recurso.Item3.nombre.ToString(),
                        recurso.Item1.modelo.nombre.ToString(),
                        recurso.Item1.getEstadoActual().nombre.ToString(),
                        recurso.Item2.nombre.ToString(),
                        recurso.Item2.sigla.ToString()
                    };
                this.dgvRT.Rows.Add(fila);
                //coloreamos los estados de acuerdo al nombre
                if (recurso.Item1.getEstadoActual().nombre == "Disponible")
                    this.dgvRT.Rows[i].Cells[3].Style.BackColor = Color.Blue;
                else if (recurso.Item1.getEstadoActual().nombre == "En Mantenimiento")
                    this.dgvRT.Rows[i].Cells[3].Style.BackColor = Color.Green;
                else if (recurso.Item1.getEstadoActual().nombre == "Con Inicio En Mantenimiento Correctivo")
                    this.dgvRT.Rows[i].Cells[3].Style.BackColor = Color.Gray;

                i ++;
            }
        }
        public bool verificarSeleccion()
        {
            return this.dgvRT.SelectedRows.Count == 1;
        }

        public RecursoTecnologico GetRTSeleccionado()
        {
            var RT = new RecursoTecnologico();
            RT.numeroRT = Convert.ToInt32(this.dgvRT.SelectedRows[0].Cells[0].Value.ToString());
            return RT;
        }
    }
}
