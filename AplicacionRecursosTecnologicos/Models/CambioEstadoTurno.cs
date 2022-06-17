using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionRecursosTecnologicos.Models
{
    public class CambioEstadoTurno
    {
        public DateTime fechaHoraDesde { get; set; }
        public DateTime fechaHoraHasta { get; set; }
        public Estado estado { get; set; }
        public bool esActual()
        {
            return fechaHoraHasta.Year == 1;
        }
        public void Finalizar()
        {
            fechaHoraHasta = DateTime.Now;
        }
        public CambioEstadoTurno() { }
        public CambioEstadoTurno( Estado e)
        {
            fechaHoraDesde = DateTime.Now;
            estado = e;

        }
    }
}
