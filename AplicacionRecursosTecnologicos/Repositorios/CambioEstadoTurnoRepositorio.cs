using AplicacionRecursosTecnologicos.Models;
using PatioOlmosApp.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionRecursosTecnologicos.Repositorios
{
    public class CambioEstadoTurnoRepositorio
    {
        public void Finalizar(CambioEstadoTurno cet, int numeroRT, DateTime fechaHoraInicioTurno)
        {
            var sentenciaSql = $"update CambioEstadoTurno set fechaHoraHasta = Convert(DateTime, '{cet.fechaHoraHasta}', 103) " +
                $" where numeroRT={numeroRT} and fechaHoraInicioTurno =Convert(DateTime, '{fechaHoraInicioTurno}', 103) " +
                $"and fechaHoraDesde = Convert(Date, '{cet.fechaHoraDesde.ToString("dd/MM/yyyy")}', 103)";
            DBHelper.GetDBHelper().EjecutarSQL(sentenciaSql);
        }
        public void Crear(CambioEstadoTurno cet, int numeroRT, DateTime fechaHoraInicioTurno, Estado e)
        {
            var sentenciaSql = $"Insert Into CambioEstadoTurno(fechaHoraDesde, fechaHoraInicioTurno, numeroRT, id_estado ) " +
                $"Values(Convert(DateTime, '{cet.fechaHoraDesde}', 103),  Convert(DateTime, '{fechaHoraInicioTurno}', 103), " +
                $"{numeroRT}, {e.Id_estado})";
            DBHelper.GetDBHelper().EjecutarSQL(sentenciaSql);
        }
    }
}
