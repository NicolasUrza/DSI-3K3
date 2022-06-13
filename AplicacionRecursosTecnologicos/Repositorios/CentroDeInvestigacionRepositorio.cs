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
    public class CentroDeInvestigacionRepositorio
    {
        public CentroDeInvestigacion mapearCentro(DataRow fila)
        {
            var centro = new CentroDeInvestigacion();
            centro.nombre = fila["nombre"].ToString();
            return centro;
        }
        public CentroDeInvestigacion mostrarCI(RecursoTecnologico rt)
        {
            var sentenciaSql = $"select ci.* from CIxRT " +
                "left join CentroDeInvestigacion ci on CIxRT.id_centro = ci.id_centro " +
                $"where numeroRT = {rt.numeroRT}";
            var tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);

            return mapearCentro(tablaResultado.Rows[0]);
        }
    }
}
