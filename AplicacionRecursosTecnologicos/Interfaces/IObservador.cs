using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionRecursosTecnologicos.Interfaces
{
    public interface IObservador
    {
        void Actualizar(string[] contactos, int nroRT, DateTime fechaHoraInicio, DateTime fechaHoraFin);

    }
}
