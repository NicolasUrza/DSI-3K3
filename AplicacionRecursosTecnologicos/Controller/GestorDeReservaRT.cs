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
        private PersonalCientifico Activo;
        private RecursoTecnologico recursoSeleccionado;
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

        public void TomarSeleccionRT(RecursoTecnologico Rt)
        {
            var recursoServicio = new RecursoTecnologicoServicio();
            this.recursoSeleccionado = recursoServicio.GetRecursoBynumero(Rt.numeroRT);
            //verificamos si el centro de Investigacion del Recurso es el mismo que el del cientifico logueado
            if (VerificarPertenenciaAlCI())
                VerificarTurnosDisponibles(true);
            else
                MessageBox.Show("NO SOS DEL MISMO CI", "informacion", MessageBoxButtons.OK);

        }
        public bool VerificarPertenenciaAlCI()
        {
            //busco el cientifico logueado en esta sesion
            Activo =  Program.sesionActual.buscarUsuario();
            // le preguntamos al recurso, si su centro de investigacion es el mismo que el del cientifico logueado
            return recursoSeleccionado.VerificarPertenenciaDelCientifico(Activo);
        }

        public void VerificarTurnosDisponibles(bool esCientificoDelCI)
        {
            var fechaHoraActual = new DateTime();
            if (esCientificoDelCI)
            {
                fechaHoraActual = DateTime.Now;

            }
            var turnosDisponibles = recursoSeleccionado.misTurnosDisponibles(fechaHoraActual);
            AgruparOrdenarTurnos(turnosDisponibles);
        }

        public void AgruparOrdenarTurnos(List<String[]> turnosDisponibles)
        {
            var turnosOrdenados = turnosDisponibles.OrderBy(x => Convert.ToDateTime(x[0])).ThenBy(x=> x[2]).ToList();

            PantallaRegistrar.solicitarSeleccionTurnos(turnosOrdenados);
        }
    }
}
