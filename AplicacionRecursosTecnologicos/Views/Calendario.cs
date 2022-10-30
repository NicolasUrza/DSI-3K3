using AplicacionRecursosTecnologicos.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicacionRecursosTecnologicos.Views
{
    public partial class Calendario : Form
    {
        public List<String[]> Fechas;
        private int mesActual, añoActual;
        private List<DateTime> fechasDisponibles;
        private PantallaRegistrarReserva pantallaRegistrar;
        public Calendario(List<String[]> listaFechas, PantallaRegistrarReserva p)
        {
            InitializeComponent();
            this.Fechas = listaFechas;
            this.pantallaRegistrar = p;
            calcularFechasDisponibles();
            Utils.CrearAlgo();
            
        }

        public void calcularFechasDisponibles()
        {
            var f = new List<DateTime>();
            foreach(var fecha in Fechas)
            {
                if(fecha[4] == "Disponible")
                    f.Add(Convert.ToDateTime(fecha[0]));
            }
            fechasDisponibles = f;
        }

        private void Calendario_Load(object sender, EventArgs e)
        {
            DisplayDays();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (mesActual < 12)
                mesActual++;
            else
            {
                mesActual = 1;
                añoActual++;
            }
            paneldias.Controls.Clear();
            Dias();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (mesActual > 1)
                mesActual--;
            else
            {
                mesActual = 12;
                añoActual--;
            }
            paneldias.Controls.Clear();
            Dias();
        }

        private void DisplayDays()
        {
            //fecha de hoy
            DateTime now = DateTime.Now;
            mesActual = now.Month;
            añoActual = now.Year;
            Dias();

        }
        public void Dias()
        {
            string nombreMes = DateTimeFormatInfo.CurrentInfo.GetMonthName(mesActual);
            this.lblMes.Text = $"Mes: {nombreMes}";
            this.lblAño.Text = $"Año: {añoActual}";
            DateTime startOfTheMonth = new DateTime(añoActual, mesActual, 1);

            int days = DateTime.DaysInMonth(añoActual, mesActual);

            int daysOfWeek = Convert.ToInt32(startOfTheMonth.DayOfWeek.ToString("d"));

            for (int i = 1; i < daysOfWeek; i++)
            {
                UserControl ucBlanck = new UserControlCalendario();
                paneldias.Controls.Add(ucBlanck);
            }
            for (int i = 1; i <= days; i++)
            {
                var dia = Convert.ToDateTime($"{i}/{mesActual}/{añoActual}");
                if (EsDisponible(dia))
                {
                    UserControl ucDays = new UserControlDays(this, i, true);
                    paneldias.Controls.Add(ucDays);
                }
                else
                {
                    UserControl ucDays = new UserControlDays(this, i);
                    paneldias.Controls.Add(ucDays);
                }
                
            }

        }
        public bool EsDisponible(DateTime dia)
        {
            return fechasDisponibles.Contains(dia);
        }

        public void DiaSeleccionado(int d)
        {
            var diaSeleccionado = Convert.ToDateTime($"{d}/{mesActual}/{añoActual}");
            var fechasDisponibles = new List<String[]>();
            foreach(var fecha in Fechas)
            {
                if(Convert.ToDateTime(fecha[0]) == diaSeleccionado)
                {
                    fechasDisponibles.Add(fecha);
                }
            }
            pantallaRegistrar.MostrarTurnos(fechasDisponibles);
        }
    }
}
