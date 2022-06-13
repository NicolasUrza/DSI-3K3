using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionRecursosTecnologicos.Models
{
    public class AsignacionCientificoDelCI
    {
        public DateTime fechaDesde { get; set; }
        public DateTime fechaHasta { get; set; }
        public PersonalCientifico PersonalCientifico { get; set; }
    }
}
