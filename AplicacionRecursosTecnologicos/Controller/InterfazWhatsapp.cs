﻿using AplicacionRecursosTecnologicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
namespace AplicacionRecursosTecnologicos.Controller
{
    public class InterfazWhatsapp : IObservador
    {
        public void Actualizar(string[] contactos, int nroRT, DateTime fechaHoraInicio, DateTime fechaHoraFin)
        {
            var contenidoWpp = "*Usted Ha Reservado un nuevo Turno*\n" +
                    "El recurso tecnologico con nro: " + nroRT + " ha sido reservado con exito para la fecha " + fechaHoraInicio.ToString("dd/MM/yyyy") +
                    " con horario desde las " + fechaHoraInicio.ToString("HH:mm") + "hs hasta las " + fechaHoraFin.ToString("HH:mm")+"hs";

            foreach (string contacto in contactos) {
                var accountSid = "";
                var authToken = "";
                TwilioClient.Init(accountSid, authToken);

                var messageOptions = new CreateMessageOptions(
                    new PhoneNumber("whatsapp:" + contacto));
                messageOptions.From = new PhoneNumber("whatsapp:+14155238886");
                messageOptions.Body = contenidoWpp;

                var message = MessageResource.Create(messageOptions);

            }
        }
    

    }
}
