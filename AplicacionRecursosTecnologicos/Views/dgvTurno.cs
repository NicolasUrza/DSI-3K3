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
    public partial class dgvTurno : Form
    {
        public dgvTurno()
        {
            InitializeComponent();
        }

        public void MostrarTurnos(List<string[]> turnos)
        {
            foreach (var turn in turnos)
            {

                this.dgvTurnos.Rows.Add(turn);
            }
                
        }
    }
}
