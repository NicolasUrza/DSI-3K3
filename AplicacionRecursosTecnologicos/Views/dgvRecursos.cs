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


            }
        }
        public bool verificarSeleccion()
        {
            return this.dgvRT.SelectedRows.Count == 1;
        }

        public (RecursoTecnologico, CentroDeInvestigacion) GetRTSeleccionado()
        {
            var RT = new RecursoTecnologico();
            RT.numeroRT = Convert.ToInt32(this.dgvRT.SelectedRows[0].Cells[0].Value.ToString());
            var CI = new CentroDeInvestigacion();
            CI.sigla = this.dgvRT.SelectedRows[0].Cells[5].Value.ToString();
            return (RT, CI);
        }
    }
}
