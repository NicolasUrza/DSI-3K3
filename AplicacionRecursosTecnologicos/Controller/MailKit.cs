using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionRecursosTecnologicos.Controller
{
    public class MailKit
    {
        public void EnviarCorreo(string mail, string contenido)
        {
            var mailMessage = new MimeMessage();
            mailMessage.From.Add(new MailboxAddress("Aplicacion Rescursos Tecnologicos", "nicolasurza@gmail.com"));
            mailMessage.To.Add(new MailboxAddress("Cientifico", mail));
            mailMessage.Subject = "Reserva de Turno";
            mailMessage.Body = new TextPart("html")
            {
                Text = contenido
        };
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Connect("smtp.gmail.com", 465, true);
                smtpClient.Authenticate("nicolasurza@gmail.com", "zeyyozjpbaolmtby");
                smtpClient.Send(mailMessage);
                smtpClient.Disconnect(true);
            }
        }
    }
}
