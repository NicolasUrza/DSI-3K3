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
    }
}
