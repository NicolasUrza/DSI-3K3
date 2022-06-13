using AplicacionRecursosTecnologicos.Models;
using AplicacionRecursosTecnologicos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionRecursosTecnologicos.Servicios
{
    public class TipoRecursoTecnologicoServicio
    {
        private TipoRecursoTecnologicoRepositorio tipoRecursoTecnologicoRepositorio;
        public TipoRecursoTecnologicoServicio()
        {
            tipoRecursoTecnologicoRepositorio = new TipoRecursoTecnologicoRepositorio();
        }
        public List<TipoRecursoTecnologico> mostrarDatos()
        {
            return tipoRecursoTecnologicoRepositorio.getTipoRecursosTecnologicos();
        }
    }
}
