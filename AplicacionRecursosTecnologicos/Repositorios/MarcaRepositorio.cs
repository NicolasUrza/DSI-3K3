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
    public class MarcaRepositorio
    {
        public Marca MapearMarca(DataRow fila)
        {
            var marca = new Marca();
            marca.nombre = fila["nombre"].ToString();
            return marca;
        }
        public Marca MostrarMarcaDelModelo(Modelo m)
        {
            var sentenciaSQL = "SELECT ma.* FROM Modelo mo " +
                "LEFT join Marcas ma on mo.id_marca=ma.id_marca " +
                $"where mo.id_modelo = {m.Id}";
            var tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSQL);
            var marca = MapearMarca(tablaResultado.Rows[0]);
            return marca;
        }

    }
}
