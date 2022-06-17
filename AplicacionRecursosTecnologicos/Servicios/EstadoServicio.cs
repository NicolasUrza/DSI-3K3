using AplicacionRecursosTecnologicos.Models;
using AplicacionRecursosTecnologicos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionRecursosTecnologicos.Servicios
{
    public class EstadoServicio
    {
        private EstadoRepositorio estadoRepositorio;
        public EstadoServicio()
        {
            this.estadoRepositorio = new EstadoRepositorio();
        }
        public List<Estado> ObtenerEstado()
        {
            return estadoRepositorio.ObtenerEstados();
        }
    }
}
