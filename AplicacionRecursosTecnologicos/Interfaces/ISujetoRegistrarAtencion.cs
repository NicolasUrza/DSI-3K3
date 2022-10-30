using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionRecursosTecnologicos.Interfaces
{
    public interface ISujetoRegistrarAtencion
    {
        public List<IObservador> obs { get; set; }
        void suscribir(IObservador o);
        void quitar(IObservador o);
        void notificar( );

    }
}
