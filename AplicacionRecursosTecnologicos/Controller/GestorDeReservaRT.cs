using AplicacionRecursosTecnologicos.Models;
using AplicacionRecursosTecnologicos.Servicios;
using AplicacionRecursosTecnologicos.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionRecursosTecnologicos.Controller
{
    public class GestorDeReservaRT
    {
        private PantallaRegistrarReserva PantallaRegistrar;
        private List<int> tiposSeleccionados;
        public void reservar(PantallaRegistrarReserva prr)
        {
            PantallaRegistrar = prr;
            var tipoRecursoTecnologicoServicio = new TipoRecursoTecnologicoServicio();
            var tipoRecursos = mostrarTipoRecurso();
            PantallaRegistrar.mostrarDatosTipoRecurso(tipoRecursos);
            PantallaRegistrar.solicitarSeleccionTipoRecurso();
        }

        public List<TipoRecursoTecnologico> mostrarTipoRecurso()
        {
            var tipoRecursoTecnologicoServicio = new TipoRecursoTecnologicoServicio();
            return tipoRecursoTecnologicoServicio.mostrarDatos();

        }

        public void TipoRecursoSeleccionado(List<int> tiposSelec)
        {
            this.tiposSeleccionados = tiposSelec;
            BuscarRecursoNoEnBaja();
        }
        public void BuscarRecursoNoEnBaja()
        {
            var rtServicio = new RecursoTecnologicoServicio();
            var listaRT = rtServicio.buscarRecursoTeconologico();
            var listaMostrar = new List<(RecursoTecnologico, CentroDeInvestigacion, Marca)>();
            foreach(var rt in listaRT)
            {
                // preguntamos si el recurso es del tipo seleccionado
                if (!rt.sosTipoRecurso(tiposSeleccionados))
                    continue;
                // preguntamos si es reservable
                if (!rt.verificarActivo())
                    continue;
                //tomamos los datos para mostrar
                listaMostrar.Add((rt, rt.mostrarCI(), rt.MostrarMarcayModelo()));
            }
            AgruparPorCI(listaMostrar);
        }

        public void AgruparPorCI(List<(RecursoTecnologico, CentroDeInvestigacion, Marca)> listaMostrar)
        {
            var listaOrdenadaPorCi =  listaMostrar.OrderBy(x => x.Item2.nombre).ToList();
            this.PantallaRegistrar.MostrarRescursos(listaOrdenadaPorCi);
            this.PantallaRegistrar.SolicitarSeleccionRecurso();
        }

        public void TomarSeleccionRT((RecursoTecnologico, CentroDeInvestigacion ) RtyCI)
        {

        }

    }
}
