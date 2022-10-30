using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionRecursosTecnologicos.Models
{
    public class TipoRecursoTecnologico
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }

        public string[] MostrarTiposRescursos()
        {
            var datos = new string[] { this.nombre, this.descripcion };
            return datos;
        }
    }
}
