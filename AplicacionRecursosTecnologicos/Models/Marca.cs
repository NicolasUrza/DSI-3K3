using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionRecursosTecnologicos.Models
{
    public class Marca
    {
        public string nombre { get; set; }
        public List<Modelo> modelos { get; set; }
    }
}
