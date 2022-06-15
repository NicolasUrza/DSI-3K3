using AplicacionRecursosTecnologicos.Models;
using AplicacionRecursosTecnologicos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionRecursosTecnologicos.Servicios
{
    public class RecursoTecnologicoServicio
    {
        private RecursoTecnologicoRepositorio rtRepositorio;

        public RecursoTecnologicoServicio()
        {
            rtRepositorio = new RecursoTecnologicoRepositorio();
        }
        public List<RecursoTecnologico> buscarRecursoTeconologico()
        {
            return rtRepositorio.buscarRecursoTeconologico();
        }
        public RecursoTecnologico GetRecursoBynumero(int numeroRT)
        {
            return rtRepositorio.GetRecursoByNumero(numeroRT);
        }
    }
}
