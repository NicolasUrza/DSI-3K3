using AplicacionRecursosTecnologicos.Models;
using AplicacionRecursosTecnologicos.Servicios;
using PatioOlmosApp.Repositorio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionRecursosTecnologicos.Repositorios
{
    public class RecursoTecnologicoRepositorio
    {
        public RecursoTecnologico mapearRecurso(DataRow fila)
        {
            var rt = new RecursoTecnologico();
            var tipo = new TipoRecursoTecnologico();
            tipo.nombre = fila["nombreTipo"].ToString();
            tipo.descripcion = fila["descripcionTipo"].ToString();

            rt.tipoRecursoTecnologico= tipo;
            rt.numeroRT = Convert.ToInt32(fila["numeroRT"]);
            var modelo = new Modelo();
            modelo.nombre = fila["nombreModelo"].ToString();
            rt.modelo = modelo;

            // conseguimos todos los cambios de estado de este recurso
            rt.cambiosEstado = cambioEstadoRT(rt.numeroRT);

            //conseguimos todos los turnos
            rt.turnos = GetTurnosRT(rt.numeroRT);

            return rt;
        }
        public List<RecursoTecnologico> buscarRecursoTeconologico()
        {
            var sentenciaSQL = "Select rt.*, t.nombre as nombreTipo, t.descripcion as descripcionTipo, m.nombre as nombreModelo " +
                                "FROM RecursoTecnologico rt Left join TipoRecursoTecnologico t on t.nombre = rt.nombreTipo " +
                                "Left join Modelo m on m.nombre=rt.nombreModelo";
            var tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSQL);
            var listaRT = new List<RecursoTecnologico>();
            foreach (DataRow fila in tablaResultado.Rows)
            {
                var RT = mapearRecurso(fila);
                listaRT.Add(RT);
            }
            return listaRT;
        }
        public CambioEstadoRT mapearCambioEstado(DataRow fila)
        {
            var cambioEstado = new CambioEstadoRT();
            if(!String.IsNullOrEmpty(fila["fechaHoraHasta"].ToString()))
                cambioEstado.fechaHoraHasta = Convert.ToDateTime(fila["fechaHoraHasta"]);
            cambioEstado.fechaHoraDesde = Convert.ToDateTime(fila["fechaHoraDesde"]);
            var estado = new Estado();
            estado.nombre = fila["nombreEstado"].ToString();
            estado.descripcion = fila["descripcionEstado"].ToString();
            estado.ambito = fila["ambitoEstado"].ToString();
            estado.esReservable = Convert.ToBoolean(fila["esReservable"]);
            cambioEstado.estado = estado;
            return cambioEstado;
        }

        public List<CambioEstadoRT> cambioEstadoRT(int nroRT)
        {
            var sentenciaSQL = $"SELECT c.*, e.nombre as nombreEstado, e.descripcion as descripcionEstado, e.ambito as ambitoEstado, e.esReservable " +
                $"FROM CambioEstadoRT c " +
                $"Left join Estado e on e.nombre = c.nombre and e.ambito=c.ambito " +
                $"where c.numeroRT = {nroRT}";
            var tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSQL);
            var listaCambios = new List<CambioEstadoRT>();
            foreach (DataRow fila in tablaResultado.Rows)
            {
                var CE = mapearCambioEstado(fila);
                listaCambios.Add(CE);
            }
            return listaCambios;
        }
        public RecursoTecnologico GetRecursoByNumero(int numeroRT)
        {
            var sentenciaSQL = "Select rt.*, t.nombre as nombreTipo, t.descripcion as descripcionTipo, m.nombre as nombreModelo " +
                    "FROM RecursoTecnologico rt Left join TipoRecursoTecnologico t on t.nombre = rt.nombreTipo " +
                    "Left join Modelo m on m.nombre=rt.nombreModelo " +
                    $"where rt.numeroRT={numeroRT}";
            var tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSQL);

            return mapearRecurso(tablaResultado.Rows[0]);
        }
        public Turno MapearTurno(DataRow fila)
        {
            var turno = new Turno();
           
            if (!String.IsNullOrEmpty(fila["fechaGeneracion"].ToString()))
                turno.fechaGeneracion = Convert.ToDateTime(fila["fechaGeneracion"]);
            if (!String.IsNullOrEmpty(fila["diaSemana"].ToString()))
                turno.diaSemana = Convert.ToInt32(fila["diaSemana"]);
            if (!String.IsNullOrEmpty(fila["fechaHoraInicio"].ToString()))
                turno.fechaHoraInicio = Convert.ToDateTime(fila["fechaHoraInicio"]);
            if (!String.IsNullOrEmpty(fila["fechaHoraFin"].ToString()))
                turno.fechaHoraFin = Convert.ToDateTime(fila["fechaHoraFin"]);
            var cambios = GetCambiosDelTurno(turno, Convert.ToInt32(fila["numeroRT"]));
            turno.cambioEstadoTurnos = cambios;
            return turno;
        }
        public List<Turno> GetTurnosRT(int numeroRT)
        {
            var sentenciaSQL = $"SELECT t.* from turno t where t.numeroRT = {numeroRT}";
            var tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSQL);
            var turnos = new List<Turno>();
            foreach(DataRow fila in tablaResultado.Rows)
            {
                turnos.Add(MapearTurno(fila));
            }

            return turnos;
        }
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
