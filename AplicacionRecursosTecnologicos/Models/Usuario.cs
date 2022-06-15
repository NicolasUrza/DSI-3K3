using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicacionRecursosTecnologicos.Servicios;

namespace AplicacionRecursosTecnologicos.Models
{
    public class Usuario
    {
        public string clave { get; set; }
        public int usuario { get; set; }
        public bool habilitado { get; set; }

        public PersonalCientifico getPersonalCientificoActivo()
        {
            var PersonalCientificoServicio = new PersonalCientificoServicio();
            return PersonalCientificoServicio.GetPersonalCientifico(this);
        }
    }
}
