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
    public partial class UserControlDays : UserControl
    {
        private int day;
        private Calendario calendario;
        private bool tieneTurnos;
        public UserControlDays(Calendario c, int dia, bool turno=false)
        {
            InitializeComponent();
            this.calendario = c;
            this.day = dia;
            this.tieneTurnos = turno;
        }

        private void UserControlDays_Load(object sender, EventArgs e)
        {
            if (tieneTurnos)
            {
                this.button1.BackColor = Color.Blue;
            }
            else
                this.button1.BackColor=Color.Red;

            button1.Text = day.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(tieneTurnos)
                calendario.DiaSeleccionado(day);
            else
                MessageBox.Show("Debe seleccionar una fecha Disponible", "informacion", MessageBoxButtons.OK);
        }
    }
}
