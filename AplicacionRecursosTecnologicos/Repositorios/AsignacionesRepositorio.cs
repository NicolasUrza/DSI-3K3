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
    public class AsignacionesRepositorio
    {
        public AsignacionCientificoDelCI MapearAsignacion(DataRow fila)
        {
            var asignacion = new AsignacionCientificoDelCI();
            if (!string.IsNullOrEmpty(fila["fechaDesde"].ToString()))
                asignacion.fechaDesde = Convert.ToDateTime(fila["fechaDesde"]);
            if (!string.IsNullOrEmpty(fila["fechaHasta"].ToString()))
                asignacion.fechaDesde = Convert.ToDateTime(fila["fechaDesde"]);
            var pcServicio = new PersonalCientificoServicio();
            asignacion.PersonalCientifico = pcServicio.GetByLegajo(Convert.ToInt32(fila["legajo"]));

            return asignacion;

        }
        public List<AsignacionCientificoDelCI> asignacionesDeUnCI(string sigla)
        {
            var sentenciaSQL = $"select a.* from AsignacionCientificoDelCI a where a.sigla = '{sigla}'";
            var tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSQL);
            var asignaciones = new List<AsignacionCientificoDelCI>();
            foreach(DataRow row in tablaResultado.Rows)
            {
                asignaciones.Add(MapearAsignacion(row));
            }
            return asignaciones;
        }
    }
}
