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
    public class PersonalCientificoRepositorio
    {
        public PersonalCientifico MapearPersonalCientifico(DataRow fila)
        {
            var perCI = new PersonalCientifico();
            perCI.Legajo = Convert.ToInt32(fila["legajo"]);
            if (!string.IsNullOrEmpty(fila["numeroDocumento"].ToString()))
                perCI.numeroDocumento = Convert.ToInt32(fila["numeroDocumento"]);
            if (!string.IsNullOrEmpty(fila["nombre"].ToString()))
                perCI.nombre = fila["nombre"].ToString();
            if (!string.IsNullOrEmpty(fila["apellido"].ToString()))
                perCI.apellido = fila["apellido"].ToString();
            if (!string.IsNullOrEmpty(fila["correoElectronicoPersonal"].ToString()))
                perCI.correoElectronicoPersonal = fila["correoElectronicoPersonal"].ToString();
            if (!string.IsNullOrEmpty(fila["correoElectronicoInstitucional"].ToString()))
                perCI.correoElectronicoInstitucional = fila["correoElectronicoInstitucional"].ToString();
            if (!string.IsNullOrEmpty(fila["telefonoCelular"].ToString()))
                perCI.telefonoCelular = fila["telefonoCelular"].ToString();
            var u = new Usuario();
            if (!string.IsNullOrEmpty(fila["usuario"].ToString()))
                u.usuario = Convert.ToInt32(fila["usuario"]);
            if (!string.IsNullOrEmpty(fila["clave"].ToString()))
                u.clave = fila["clave"].ToString();
            if (!string.IsNullOrEmpty(fila["numeroDocumento"].ToString()))
                u.habilitado = Convert.ToBoolean(fila["numeroDocumento"]);
            perCI.usuario = u;
            return perCI;
        }
        public PersonalCientifico GetPersonalCientifico(Usuario u)
        {
            var sentenciaSQL = "Select pc.*, u.* " +
                "from PersonalCientifico pc join Usuario u on pc.legajo=u.usuario " +
                $"where u.usuario = {u.usuario}";
            var tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSQL);
            var personalCI = MapearPersonalCientifico(tablaResultado.Rows[0]);
            return personalCI;
        }

        public PersonalCientifico GetByLegajo(int legajo)
        {
            var sentenciaSQL = "Select pc.*, u.* " +
                "from PersonalCientifico pc join Usuario u on pc.legajo=u.usuario " +
                $"where pc.legajo = {legajo}";
            var tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSQL);
            var personalCI = MapearPersonalCientifico(tablaResultado.Rows[0]);
            return personalCI;
        }
    }
}
