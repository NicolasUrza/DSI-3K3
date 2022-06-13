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
                        recurso.Item2.nombre.ToString()
                    };
                this.dgvRT.Rows.Add(fila);


            }
        }

    }
}
