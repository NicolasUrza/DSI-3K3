using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionRecursosTecnologicos.Models
{
    public class Estado
    {
        public int Id_estado { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string ambito { get; set; }
        public bool esReservable { get; set; }
        public bool esCancelable { get; set; }

        public bool EsAmbitoturno()
        {
            return ambito == "Turno";
        }

        public bool EsReservado()
        {
            return nombre == "Reservado";
        }
    }
}
