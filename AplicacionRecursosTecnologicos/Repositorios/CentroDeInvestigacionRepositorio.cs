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
    public class CentroDeInvestigacionRepositorio
    {
        public CentroDeInvestigacion mapearCentro(DataRow fila)
        {
            var centro = new CentroDeInvestigacion();
            centro.nombre = fila["nombre"].ToString();
            centro.sigla = fila["sigla"].ToString();
            centro.tiempoAntelacionReserva = Convert.ToInt32(fila["tiempoAntelacionReserva"].ToString());
            var asignacionServicio = new AsignacionServicio();
            centro.asignacionCientificoDelCI = asignacionServicio.AsignacionesDeUnCI(fila["sigla"].ToString());

            return centro;
        }
        public CentroDeInvestigacion mostrarCI(RecursoTecnologico rt)
        {
            var sentenciaSql = $"select ci.* from CIxRT " +
                "left join CentroDeInvestigacion ci on CIxRT.sigla = ci.sigla " +
                $"where numeroRT = {rt.numeroRT}";
            var tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);

            return mapearCentro(tablaResultado.Rows[0]);
        }
    }
}
