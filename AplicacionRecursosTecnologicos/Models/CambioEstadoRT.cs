using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionRecursosTecnologicos.Models
{
    public class CambioEstadoRT
    {
        public int id_cambio_estado { get; set; }
        public DateTime fechaHoraDesde { get; set; }
        public DateTime fechaHoraHasta { get; set; }

        public Estado estado { get; set; }

        public bool esActual()
        {
            // la fechaHoraHasta por defecto tiene el año igual a 1
            // es activo si no se le asigno una fechaHasta diferente a la que viene por defecto en el programa 
            return fechaHoraHasta.Year == 1;
        }
        public bool esEstadoActualReservable()
        {
            return estado.esReservable;
        }

    }
}
