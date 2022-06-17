using AplicacionRecursosTecnologicos.Models;
using AplicacionRecursosTecnologicos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionRecursosTecnologicos.Servicios
{
    public class CambioEstadoTurnoServicio
    {
        private CambioEstadoTurnoRepositorio cambioEstadoTurnoRepositorio;
        public CambioEstadoTurnoServicio()
        {
            cambioEstadoTurnoRepositorio = new CambioEstadoTurnoRepositorio();
        }
        public void Finalizar(CambioEstadoTurno cet, int numeroRT, DateTime fechaHoraInicioTurno)
        {
            cambioEstadoTurnoRepositorio.Finalizar(cet, numeroRT, fechaHoraInicioTurno);
        }
        public void Crear(CambioEstadoTurno cet, int numeroRT, DateTime fechaHoraInicioTurno, Estado e)
        {
            cambioEstadoTurnoRepositorio.Crear(cet, numeroRT, fechaHoraInicioTurno, e);
        }
    }
}
