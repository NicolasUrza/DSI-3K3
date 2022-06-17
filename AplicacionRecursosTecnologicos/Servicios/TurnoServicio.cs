using AplicacionRecursosTecnologicos.Models;
using AplicacionRecursosTecnologicos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionRecursosTecnologicos.Servicios
{
    public class TurnoServicio
    {
        private TurnoRepositorio turnoRepositorio;
        public TurnoServicio()
        {
            turnoRepositorio = new TurnoRepositorio();
        }
        public List<CambioEstadoTurno> GetCambiosDelTurno(Turno t, int numeroRT)
        {
            return turnoRepositorio.GetCambiosDelTurno(t, numeroRT);
        }
    }
}
