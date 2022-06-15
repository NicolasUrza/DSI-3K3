using AplicacionRecursosTecnologicos.Models;

namespace AplicacionRecursosTecnologicos
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        
        public static Sesion sesionActual { get; set; }
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var s = new Sesion();
            s.fechaHoraInicio = DateTime.Now;

            var u = new Usuario();
            u.usuario = 86007;
            s.usuario = u;
            sesionActual = s;
            Application.Run(new Form1());

        }
    }
}