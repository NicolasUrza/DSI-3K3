using AplicacionRecursosTecnologicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionRecursosTecnologicos.Controller
{
    public class InterfazCorreoElectronico: IObservador
    {
        public void Actualizar(string[] contactos, int nroRT, DateTime fechaHoraInicio, DateTime fechaHoraFin)
        {
            foreach (string contacto in contactos)
            {
                var contenidoMail = "<html><body><h3>Usted Ha Reservado un nuevo Turno</h3>" +
                    "<p>El recurso tecnologico con nro: " + nroRT + " ha sido reservado con exito para la fecha " + fechaHoraInicio.ToString("dd/MM/yyyy") + 
                    " con horario desde las "+ fechaHoraInicio.ToString("HH:mm")+ "hs hasta las " + fechaHoraFin.ToString("HH:mm") + "hs </p></body></html>";
                try
                {
                    var mailSender = new MailKit();
                    mailSender.EnviarCorreo(contacto, contenidoMail);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un problema al mandar las notificaciones", "advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

    }
}
