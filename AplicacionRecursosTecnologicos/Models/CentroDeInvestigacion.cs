using AplicacionRecursosTecnologicos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionRecursosTecnologicos
{
    public class CentroDeInvestigacion
    {
        public string nombre { get; set; }
        public string sigla { get; set; }
        public string direccion { get; set; }
        public string edificio { get; set; }
        public string piso { get; set; }
        public string coordenadas { get; set; }
        public string telefonosContacto { get; set; }
        public string correoElectronico {get; set; }
        public int numeroResolucionCreacion { get; set; }
        public DateTime fechaResolucionCreacion { get; set; }
        public string reglamento { get; set; }
        public string caracteristicasGenerales { get; set; }
        public DateTime fechaAlta { get; set; }
        public string tiempoAntelacionReserva { get; set; }
        public DateTime fechaBaja { get; set; }
        public string motivoBaja { get; set; }
        


    }
}
