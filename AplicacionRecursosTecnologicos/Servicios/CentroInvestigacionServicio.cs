using AplicacionRecursosTecnologicos.Models;
using AplicacionRecursosTecnologicos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionRecursosTecnologicos.Servicios
{
    public class CentroInvestigacionServicio
    {
        private CentroDeInvestigacionRepositorio ciRepo;
        public CentroInvestigacionServicio()
        {
            ciRepo = new CentroDeInvestigacionRepositorio();
        }

        public CentroDeInvestigacion mostrarCI(RecursoTecnologico rt)
        {
            return ciRepo.mostrarCI(rt);
        }
    }
}
