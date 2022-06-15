using AplicacionRecursosTecnologicos.Models;
using AplicacionRecursosTecnologicos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionRecursosTecnologicos.Servicios
{
    public class PersonalCientificoServicio
    {
        private PersonalCientificoRepositorio personalCientificoRepositorio;

        public PersonalCientificoServicio()
        {
            personalCientificoRepositorio = new PersonalCientificoRepositorio();
        }

        public PersonalCientifico GetPersonalCientifico(Usuario u)
        {
            //retorna el personal cientifico que tiene asignado ese usuario
            return personalCientificoRepositorio.GetPersonalCientifico(u);
        }

        public PersonalCientifico GetByLegajo(int legajo)
        {
            return personalCientificoRepositorio.GetByLegajo(legajo);
        }
    }
}
