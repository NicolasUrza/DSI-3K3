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
    public class TipoRecursoTecnologicoRepositorio
    {
        public TipoRecursoTecnologico mapearTipoRecursoTecnologico( DataRow fila )
        {
            var tipo = new TipoRecursoTecnologico();
            tipo.id_tipo_recurso = Convert.ToInt32(fila["id_tipo_recurso"].ToString());
            tipo.nombre = fila["nombre"].ToString();
            tipo.descripcion = fila["descripcion"].ToString();
            return tipo;
        }
        public List<TipoRecursoTecnologico> getTipoRecursosTecnologicos()
        {
            var sentenciaSql = " Select * From TipoRecursoTecnologico";
            var filas = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            var tipos = new List<TipoRecursoTecnologico>();
            foreach (DataRow fila in filas.Rows)
            {
                var tipo = mapearTipoRecursoTecnologico(fila);
                tipos.Add(tipo);
            }
            return tipos;
        }


    }
}
