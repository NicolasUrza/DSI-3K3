using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionRecursosTecnologicos.Models
{
    public class Turno
    {
        public DateTime fechaGeneracion { get; set; }
        public int diaSemana { get; set; }
        public DateTime fechaHoraInicio{ get; set; }
        public DateTime fechaHoraFin { get; set; }
        public List<CambioEstadoTurno> cambioEstadoTurnos { get; set; }

        public bool SosPosteriorAFechaActual(DateTime fecha)
        {
            return fechaHoraInicio > fecha;
        }

        public String[] MostrarTurno()
        {
            // devuelve un array de cadenas con informacion del turno
            var cambioActual = new CambioEstadoTurno();
            foreach(CambioEstadoTurno c in cambioEstadoTurnos)
            {
                if (c.esActual())
                    cambioActual = c;
            }

            var DiaSemana = new String[] { "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado", "Domingo" };
            var turno = new String[]
            {

                fechaHoraInicio.ToString("dd/MM/yyyy"),
                 DiaSemana[diaSemana-1].ToString(),
                 fechaHoraInicio.ToString("HH:mm"),
                 fechaHoraFin.ToString("HH:mm"),
                 cambioActual.estado.nombre
             };
            return turno;


        }
    }
}
