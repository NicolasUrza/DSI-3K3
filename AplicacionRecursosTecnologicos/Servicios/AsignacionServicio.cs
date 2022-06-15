using AplicacionRecursosTecnologicos.Models;
using AplicacionRecursosTecnologicos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionRecursosTecnologicos.Servicios
{
    public class AsignacionServicio
    {
        private AsignacionesRepositorio asignacionRepositorio;
        public AsignacionServicio()
        {
            asignacionRepositorio = new AsignacionesRepositorio();
        }
        public List<AsignacionCientificoDelCI> AsignacionesDeUnCI(string sigla)
        {
            return asignacionRepositorio.asignacionesDeUnCI(sigla);
        }
    }
}
