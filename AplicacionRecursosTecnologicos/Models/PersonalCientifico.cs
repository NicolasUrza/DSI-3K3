using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionRecursosTecnologicos.Models
{
    public class PersonalCientifico
    {
        public int Legajo { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int numeroDocumento { get; set; }
        public string correoElectronicoInstitucional { get; set; }
        public string correoElectronicoPersonal { get; set; }
        public string telefonoCelular { get; set; }

    }
}
