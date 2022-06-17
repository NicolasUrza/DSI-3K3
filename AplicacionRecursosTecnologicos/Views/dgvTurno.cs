using AplicacionRecursosTecnologicos.Models;
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
    public partial class dgvTurno : Form
    {
        public dgvTurno()
        {
            InitializeComponent();
        }

        public void MostrarTurnos(List<string[]> turnos)
        {
            var i = 0;
            foreach (var turn in turnos)
            {

                this.dgvTurnos.Rows.Add(turn);
                if (turn[4] == "Disponible")
                    this.dgvTurnos.Rows[i].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                else if (turn[4] == "Con Reserva Pendiente De Confirmacion")
                    this.dgvTurnos.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                else if (turn[4] == "Reservado")
                    this.dgvTurnos.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                i++;
            }
                
        }
        public bool verificarSeleccion()
        {
            return this.dgvTurnos.SelectedRows.Count == 1 && this.dgvTurnos.SelectedRows[0].Cells[4].Value.ToString() == "Disponible";
        }

        public Turno GetTurnoSeleccionado()
        {
            var DiaSemana = new Dictionary<String, int>() { { "Lunes", 1}, { "Martes", 2 }, { "Miercoles", 2 }, { "Jueves",3 }, { "Viernes", 4 }, { "Sabado",5 }, { "Domingo", 6 } };
            var turno = new Turno();
            turno.fechaHoraInicio = DateTime.ParseExact(this.dgvTurnos.SelectedRows[0].Cells[0].Value.ToString() +" "+ this.dgvTurnos.SelectedRows[0].Cells[2].Value.ToString(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            turno.diaSemana = DiaSemana.GetValueOrDefault(this.dgvTurnos.SelectedRows[0].Cells[1].Value.ToString());
            turno.fechaHoraFin = DateTime.ParseExact(this.dgvTurnos.SelectedRows[0].Cells[0].Value.ToString() +" "+ this.dgvTurnos.SelectedRows[0].Cells[3].Value.ToString(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            return turno;
        }
    }
}
