using AplicacionRecursosTecnologicos.Models;
using AplicacionRecursosTecnologicos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionRecursosTecnologicos.Servicios
{
    public class MarcaServicio
    {
        private MarcaRepositorio marcaRepositorio;
        public MarcaServicio()
        {
            marcaRepositorio = new MarcaRepositorio();
        }
        public Marca GetMarcaDelModelo(Modelo m)
        {
            return marcaRepositorio.MostrarMarcaDelModelo(m);
        }


    }
}
