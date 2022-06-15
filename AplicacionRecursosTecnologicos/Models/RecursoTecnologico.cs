using AplicacionRecursosTecnologicos.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionRecursosTecnologicos.Models
{
    public class RecursoTecnologico
    {
        public int numeroRT { get; set; }
        public DateTime fechaAlta { get; set; }
        public string[] imagenes { get; set; }
        public int periodicidadMantenimientoPrev { get; set; }
        public int duracionMantenimientoPrev { get; set; }
        public decimal fraccionHorarioTurnos { get; set; }
        public TipoRecursoTecnologico tipoRecursoTecnologico { get; set; }
        public List<CambioEstadoRT> cambiosEstado { get; set; }
        public Modelo modelo { get; set; }

        public List<Turno> turnos { get; set; }
        public bool sosTipoRecurso(List<int> tprs)
        {
            return tprs.Contains(this.tipoRecursoTecnologico.id_tipo_recurso);
        }

        public bool verificarActivo()
        {
            // verifica si es activo
            foreach (var cambioEstado in cambiosEstado)
            {
                if (!cambioEstado.esActual())
                    continue;
                return cambioEstado.esEstadoActualReservable();
            }
            return false;
        }

        public CentroDeInvestigacion mostrarCI()
        {
            var  ciServicio = new CentroInvestigacionServicio();
            return ciServicio.mostrarCI(this);
        }
       
        public Marca MostrarMarcayModelo()
        {
            var marcaServicio = new MarcaServicio();
            return marcaServicio.GetMarcaDelModelo(this.modelo);
        }

        public Estado getEstadoActual()
        {
            var estadoActual = new Estado();
            foreach (var cambioEstado in cambiosEstado)
            {
                if (!cambioEstado.esActual())
                    continue;
                estadoActual = cambioEstado.estado;
                break;
            }
            return estadoActual;
        }

        public bool VerificarPertenenciaDelCientifico(PersonalCientifico cientifico)
        {
            return this.mostrarCI().esCientificoActivo(cientifico);
        }

        public List<String[]> misTurnosDisponibles(DateTime fechaDesde)
        {
            var turnosDisponibles = new List<String[]>();
            foreach(Turno turno in turnos)
            {
                if (turno.SosPosteriorAFechaActual(fechaDesde))
                    turnosDisponibles.Add(turno.MostrarTurno());
            }
            return turnosDisponibles;
        }
    }
}
