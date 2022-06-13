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
    public class RecursoTecnologicoRepositorio
    {
        public RecursoTecnologico mapearRecurso(DataRow fila)
        {
            var rt = new RecursoTecnologico();
            var tipo = new TipoRecursoTecnologico();
            tipo.id_tipo_recurso = Convert.ToInt32(fila["id_tipo_recurso"].ToString());
            tipo.nombre = fila["nombreTipo"].ToString();
            tipo.descripcion = fila["descripcionTipo"].ToString();

            rt.tipoRecursoTecnologico= tipo;
            rt.numeroRT = Convert.ToInt32(fila["numeroRT"]);
            var modelo = new Modelo();
            modelo.nombre = fila["nombreModelo"].ToString();
            modelo.Id = Convert.ToInt32(fila["id_modelo"]);
            rt.modelo = modelo;
            rt.cambiosEstado = cambioEstadoRT(rt.numeroRT);
            return rt;
        }
        public List<RecursoTecnologico> buscarRecursoTeconologico()
        {
            var sentenciaSQL = "Select rt.*, t.nombre as nombreTipo, t.descripcion as descripcionTipo, m.nombre as nombreModelo " +
                                "FROM RecursoTecnologico rt Left join TipoRecursoTecnologico t on t.id_tipo_recurso = rt.id_tipo_recurso " +
                                "Left join Modelo m on m.id_modelo=rt.id_modelo";
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
                $"Left join Estado e on e.id_estado = c.id_estado " +
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
    }
}
