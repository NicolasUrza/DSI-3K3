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
    public partial class Avisos : Form
    {
        private Form formularioDeLlamada;
        public Avisos(String texto, Form fm1)
        {
            InitializeComponent();
            this.label1.Text = texto;
            formularioDeLlamada = fm1;
        }

        private void Avisos_Load(object sender, EventArgs e)
        {
            int tamaño = this.label1.Text.Length / 100; 
            for (int i = 0; i < tamaño; i++)
            {
                // el maximo de crecimiento es de 150
                    if (i > 3)
                    break;
                //si el tamaño del texto es mayor a 250 caracteres, se aumenta el tamaño de la ventana

                this.Width += 50;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formularioDeLlamada.Show();
            this.Dispose();
        }
    }
}
