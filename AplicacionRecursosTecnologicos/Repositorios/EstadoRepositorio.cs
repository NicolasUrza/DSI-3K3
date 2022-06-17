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
    public class EstadoRepositorio
    {
        public Estado MapearEstado(DataRow fila)
        {
            var estado = new Estado();
            estado.nombre = fila["nombre"].ToString();
            estado.descripcion = fila["descripcion"].ToString();
            estado.esCancelable = Convert.ToBoolean(fila["esCancelable"]);
            estado.esReservable = Convert.ToBoolean(fila["esReservable"]);
            estado.ambito = fila["ambito"].ToString();
            estado.Id_estado = Convert.ToInt32(fila["id_estado"]);
            return estado;
        }
        public List<Estado> ObtenerEstados()
        {
            var sentenciaSQL = "Select * FROM Estado";
            var tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSQL);
            var estados = new List<Estado>();
            foreach (DataRow row in tablaResultado.Rows)
            {
                var estado = MapearEstado(row);
                estados.Add(estado);
            }
            return estados;
        }
    }
}
