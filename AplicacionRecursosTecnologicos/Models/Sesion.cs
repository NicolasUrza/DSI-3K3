using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionRecursosTecnologicos.Models
{
    public class Sesion
    {
        public DateTime fechaHoraInicio { get; set; }
        public DateTime fechaHoraFin { get; set; }
        public Usuario usuario { get; set; }

        public PersonalCientifico buscarUsuario()
        {
            return this.usuario.getPersonalCientificoActivo();
        }
    }
}
