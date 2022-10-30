using AplicacionRecursosTecnologicos.Interfaces;
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
    public class GestorDeReservaRT: ISujetoRegistrarAtencion
    {
        private PantallaRegistrarReserva PantallaRegistrar;
        private List<TipoRecursoTecnologico> tiposSeleccionados;
        private PersonalCientifico PersonalCientificoActivo;
        private RecursoTecnologico recursoSeleccionado;
        private Turno turnoSeleccionado;
        private Estado estadoReservadoTurno;
        private String[] mails;
        private String[] telefonos;
        private CambioEstadoTurno cambioEstadoTurnoActual;

        public List<IObservador> obs { get ; set; }

        public void reservar(PantallaRegistrarReserva prr)
        {
            PantallaRegistrar = prr;
            var tipoRecursoTecnologicoServicio = new TipoRecursoTecnologicoServicio();
            // conseguimos los datos de los tipos de recursos
            var tipoRecursos = mostrarTipoRecurso();
            // mostramos los datos en la pantalla
            PantallaRegistrar.mostrarDatosTipoRecurso(tipoRecursos);
            // solicitamos la seleccion
            PantallaRegistrar.solicitarSeleccionTipoRecurso();
        }

        public List<String[]> mostrarTipoRecurso()
        {
            // buscamos los tipos de recursos en la base de datos
            var tipoRecursoTecnologicoServicio = new TipoRecursoTecnologicoServicio();
            var tipos =  tipoRecursoTecnologicoServicio.mostrarDatos();
            
            // dejamos los datos de los tipos en la lista de datosTipo
            var datosTipos = new List<String[]>();
            foreach (var tipo in tipos)
            {
                datosTipos.Add(tipo.MostrarTiposRescursos());
            }
            // devuelve los datos
            return datosTipos;
        }

        public void TipoRecursoSeleccionado(List<TipoRecursoTecnologico> tiposSelec)
        {
            this.tiposSeleccionados = tiposSelec;
            BuscarRecursoNoEnBaja();
        }
        public void BuscarRecursoNoEnBaja()
        {
            // buscamos en la base de datos todos los recursos tecnologicos
            var rtServicio = new RecursoTecnologicoServicio();
            var listaRT = rtServicio.buscarRecursoTeconologico();

            
            var listaMostrar = new List<String[]>();
            foreach(var rt in listaRT)
            {
                // preguntamos si el recurso es del tipo seleccionado
                if (!rt.sosTipoRecurso(tiposSeleccionados))
                    continue;
                // preguntamos si es reservable
                if (!rt.verificarActivo())
                    continue;
                //tomamos los datos para mostrar
                var recurso = new String[]{
                    rt.numeroRT.ToString(),
                        rt.MostrarMarcaDelModelo().nombre.ToString(),
                        rt.modelo.nombre.ToString(),
                        rt.getEstadoActual().nombre.ToString(),
                        rt.mostrarCI().nombre.ToString(),
                        rt.mostrarCI().sigla.ToString()
                };
                listaMostrar.Add(recurso);
            }
            AgruparPorCI(listaMostrar);
        }

        public void AgruparPorCI(List<String[]> listaMostrar)
        {
            var listaOrdenadaPorCi =  listaMostrar.OrderBy(x => x[4]).ToList();
            // mostramos los recursos
            this.PantallaRegistrar.MostrarRescursos(listaOrdenadaPorCi);
            //solicitamos la seleccion
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
                VerificarTurnosDisponibles(false);

        }
        public bool VerificarPertenenciaAlCI()
        {
            //busco el cientifico logueado en esta sesion
            PersonalCientificoActivo =  Program.sesionActual.buscarUsuario();
            // le preguntamos al recurso, si su centro de investigacion es el mismo que el del cientifico logueado
            return recursoSeleccionado.VerificarPertenenciaDelCientifico(PersonalCientificoActivo);
        }

        public void VerificarTurnosDisponibles(bool esCientificoDelCI)
        {
            var fechaHoraActual = new DateTime();
            if (esCientificoDelCI)
            {
                fechaHoraActual = DateTime.Now;

            }
            else
                fechaHoraActual = DateTime.Today.AddDays(recursoSeleccionado.mostrarCI().tiempoAntelacionReserva);
            var turnosDisponibles = recursoSeleccionado.misTurnosDisponibles(fechaHoraActual);
            AgruparOrdenarTurnos(turnosDisponibles);
        }

        public void AgruparOrdenarTurnos(List<String[]> turnosDisponibles)
        {
            // agrupamos por fecha y ordenamos por horaDesde
            var turnosOrdenados = turnosDisponibles.OrderBy(x => Convert.ToDateTime(x[0])).ThenBy(x=> x[2]).ToList();

            PantallaRegistrar.solicitarSeleccionTurnos(turnosOrdenados);
        }

        public void TurnoSeleccionado(Turno t)
        {
            // completamos la informacion del turno con la base de datos
            var turnoServicio = new TurnoServicio();
            t.cambioEstadoTurnos = turnoServicio.GetCambiosDelTurno(t, recursoSeleccionado.numeroRT);

            //guardamos el turno seleccionado
            this.turnoSeleccionado = t;
            this.cambioEstadoTurnoActual = t.CambioEstadoActual();
            PresentarFormasNotificacion();
        }

        public void PresentarFormasNotificacion()
        {
            // se crea la informacion del turno y el recurso
            var DiaSemana = new String[] { "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado", "Domingo" };
            var informacion = $"Recurso seleccionado: \n numeroRT: {recursoSeleccionado.numeroRT} " +
                $"\n Tipo: {recursoSeleccionado.tipoRecursoTecnologico.nombre} " +
                $" Estado: {recursoSeleccionado.getEstadoActual().nombre}" +
                $"\n Turno Seleccionado:" +
                $"\n Fecha: {turnoSeleccionado.fechaHoraInicio.ToString("d")} " +
                $" Dia De La Semana: {DiaSemana[turnoSeleccionado.diaSemana-1]} " +
                $"\n Desde: {turnoSeleccionado.fechaHoraInicio.ToString("HH:mm")} " +
                $" Hasta: {turnoSeleccionado.fechaHoraFin.ToString("HH:mm")}" +
                $"\n ¿Desea confirmar la Reserva?";
            // se muestra la informacion a la pantalla
            PantallaRegistrar.SolicitarConfirmacionDeReserva(informacion);
        }

        public void ReservaConfirmada(bool mailSeleccionado, bool wppSeleccionado)
        {
            // buscamos el estado reservado
            ObtenerEstadoReservado();
            //finalizamos el cambio anterior y creamo uno nuevo con el estado reservado
            CambiarEstadoTurnoXReservado();
            // mandamos notificaciones
            if (mailSeleccionado)
            {
                this.mails = BuscarMail();
                var oMail = new InterfazCorreoElectronico();
                this.suscribir(oMail);
            }
            if (wppSeleccionado)
            {
                this.telefonos = BuscarTelefono();
                var oWpp = new InterfazWhatsapp();
                this.suscribir(oWpp);

            }

            notificar();

            FinCasoUso();

        }

        public void ObtenerEstadoReservado()
        {
            // obtenemos todos los estados de la base de datos
            var estadoServ = new EstadoServicio();
            var estados = estadoServ.ObtenerEstado(); 
            // buscamos el estado reservado de ambito turno
            foreach(var estado in estados)
            {
                if (estado.EsAmbitoturno())
                    if (estado.EsReservado())
                    {
                        this.estadoReservadoTurno = estado;
                        break;
                    }
                        
            }

        }
        public string[] BuscarTelefono()
        {
            return new string[] { PersonalCientificoActivo.telefonoCelular };
        }

        public void CambiarEstadoTurnoXReservado()
        {
            // finalizamos el cambioEstadoActual (ingresamos fechaHasta)
            cambioEstadoTurnoActual.Finalizar();
            // actualizamos la base de datos 
            var cambioEstadoServicio = new CambioEstadoTurnoServicio();
            cambioEstadoServicio.Finalizar(cambioEstadoTurnoActual, recursoSeleccionado.numeroRT, turnoSeleccionado.fechaHoraInicio);

            // cambiamos el estado del turno a reservado
            turnoSeleccionado.Reservar(estadoReservadoTurno);

            //actualizamos la base de datos registrando el nuevo Cambio de estado
            cambioEstadoServicio.Crear(turnoSeleccionado.CambioEstadoActual(), recursoSeleccionado.numeroRT, turnoSeleccionado.fechaHoraInicio, this.estadoReservadoTurno);
        }

        public string[] BuscarMail()
        {
            // le pedimos al personalcientificoActivo el mail personal
            return new string[] { PersonalCientificoActivo.correoElectronicoPersonal, PersonalCientificoActivo.correoElectronicoInstitucional };
        }


        public void FinCasoUso()
        {
            PantallaRegistrar.FinCasoUso();
        }

        public void suscribir(IObservador o)
        {
            if (this.obs == null)
                this.obs = new List<IObservador>();
            obs.Add(o);
        }

        public void quitar(IObservador o)
        {
            obs.Remove(o);
        }

        public void notificar()
        {
            if (obs == null)
                return;
            if (obs.Count == 0)
                return;
            foreach(IObservador observador in obs)
            {
                if(observador is InterfazCorreoElectronico)
                {
                    observador.Actualizar(mails,recursoSeleccionado.numeroRT,turnoSeleccionado.fechaHoraInicio, turnoSeleccionado.fechaHoraFin);
                }
                 if(observador is InterfazWhatsapp)
                {
                    observador.Actualizar(telefonos, recursoSeleccionado.numeroRT, turnoSeleccionado.fechaHoraInicio, turnoSeleccionado.fechaHoraFin);
                }
            }
        }
    }
}
