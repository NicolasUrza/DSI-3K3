using AplicacionRecursosTecnologicos.Models;
using PatioOlmosApp.Repositorio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionRecursosTecnologicos.Repositorios
{
    public class TurnoRepositorio
    {
        public CambioEstadoTurno MapearCambioEstadoTurno(DataRow fila)
        {
            var cambio = new CambioEstadoTurno();
            if (!String.IsNullOrEmpty(fila["fechaHoraDesde"].ToString()))
                cambio.fechaHoraDesde = Convert.ToDateTime(fila["fechaHoraDesde"]);
            if (!String.IsNullOrEmpty(fila["fechaHoraHasta"].ToString()))
                cambio.fechaHoraHasta = Convert.ToDateTime(fila["fechaHoraHasta"]);
            var estado = new Estado();
            estado.nombre = fila["nombreEstado"].ToString();
            estado.descripcion = fila["descripcion"].ToString();
            estado.esReservable = Convert.ToBoolean(fila["esReservable"]);
            estado.esCancelable = Convert.ToBoolean(fila["esCancelable"]);
            estado.ambito = fila["ambito"].ToString();
            cambio.estado = estado;
            return cambio;
        }
        public List<CambioEstadoTurno> GetCambiosDelTurno(Turno t, int numeroRT)
        {
            var sentenciaSQL = $"SELECT c.*, e.nombre as nombreEstado, e.ambito as ambito,e.descripcion as descripcion,e.esCancelable as esCancelable,e.esReservable as esReservable from CambioEstadoTurno c " +
                $"join estado e on e.nombre=c.nombre and e.ambito = c.ambito " +
                $"where c.fechaHoraInicioTurno = CONVERT(datetime,'{t.fechaHoraInicio.ToString()}',103) " +
                $"and c.numeroRT = {numeroRT}";
            var tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSQL);
            var cambios = new List<CambioEstadoTurno>();
            foreach (DataRow fila in tablaResultado.Rows)
            {
                var cambio = MapearCambioEstadoTurno(fila);
                cambios.Add(cambio);
            }

            return cambios;
        }
    }
}
