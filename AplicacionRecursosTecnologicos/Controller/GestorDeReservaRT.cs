﻿using AplicacionRecursosTecnologicos.Models;
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
        private List<TipoRecursoTecnologico> tiposSeleccionados;
        private PersonalCientifico PersonalCientificoActivo;
        private RecursoTecnologico recursoSeleccionado;
        private Turno turnoSeleccionado;
        private Estado estadoReservadoTurno;
        // borrar y cambiar por parametro
        private CambioEstadoTurno cambioEstadoTurnoActual;
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

        public void TipoRecursoSeleccionado(List<TipoRecursoTecnologico> tiposSelec)
        {
            this.tiposSeleccionados = tiposSelec;
            BuscarRecursoNoEnBaja();
        }
        public void BuscarRecursoNoEnBaja()
        {
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
            var turnosOrdenados = turnosDisponibles.OrderBy(x => Convert.ToDateTime(x[0])).ThenBy(x=> x[2]).ToList();

            PantallaRegistrar.solicitarSeleccionTurnos(turnosOrdenados);
        }

        public void TurnoSeleccionado(Turno t)
        {
            var turnoServicio = new TurnoServicio();
            t.cambioEstadoTurnos = turnoServicio.GetCambiosDelTurno(t, recursoSeleccionado.numeroRT);
            this.turnoSeleccionado = t;
            this.cambioEstadoTurnoActual = t.CambioEstadoActual();
            PresentarFormasNotificacion();
        }

        public void PresentarFormasNotificacion()
        {
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
            PantallaRegistrar.SolicitarConfirmacionDeReserva(informacion);
        }

        public void ReservaConfirmada(bool mailSeleccionado, bool wppSeleccionado)
        {
            ObtenerEstadoReservado();
            CambiarEstadoTurnoXReservado();
            if (mailSeleccionado)
            {
                var mails = BuscarMail();
                GenerarNotificacion(mails);

            }
            if (wppSeleccionado)
            {

            }
            FinCasoUso();

        }

        public void ObtenerEstadoReservado()
        {
            var estadoServ = new EstadoServicio();
            var estados = estadoServ.ObtenerEstado(); 
            foreach(var estado in estados)
            {
                if (estado.EsAmbitoturno())
                    if (estado.EsReservado())
                        this.estadoReservadoTurno = estado;
            }

        }

        public void CambiarEstadoTurnoXReservado()
        {
            // finalizamos el cambioEstadoActual
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
            return new string[] { PersonalCientificoActivo.correoElectronicoPersonal, PersonalCientificoActivo.correoElectronicoInstitucional };
        }

        public void GenerarNotificacion(String[] mails)
        {
            var DiaSemana = new String[] { "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado", "Domingo" };
            var contenidoMail = $"{PersonalCientificoActivo.nombre} notificacion sobre su reserva del turno: " +
                $"Recurso seleccionado: \n numeroRT: {recursoSeleccionado.numeroRT} " +
                $"\n Tipo: {recursoSeleccionado.tipoRecursoTecnologico.nombre} " +
                $" Estado: {recursoSeleccionado.getEstadoActual().nombre}" +
                $"\n Turno Seleccionado:" +
                $"\n Fecha: {turnoSeleccionado.fechaHoraInicio.ToString("d")} " +
                $" Dia De La Semana: {DiaSemana[turnoSeleccionado.diaSemana - 1]} " +
                $"\n Desde: {turnoSeleccionado.fechaHoraInicio.ToString("HH:mm")} " +
                $" Hasta: {turnoSeleccionado.fechaHoraFin.ToString("HH:MM")}";
            foreach (var mail in mails)
            {
                    try {
                    var mailSender = new MailKit();
                    mailSender.EnviarCorreo(mail, contenidoMail);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un problema al mandar las notificaciones", "advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }

        }
        public void FinCasoUso()
        {
            PantallaRegistrar.FinCasoUso();
        }
    }
}
