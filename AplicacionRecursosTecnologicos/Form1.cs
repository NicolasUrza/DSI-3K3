using AplicacionRecursosTecnologicos.Properties;
using AplicacionRecursosTecnologicos.Views;

namespace AplicacionRecursosTecnologicos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Form formularioActivo = null;
        private void Habilitar(Form form)
        {
            if (formularioActivo != null)
                formularioActivo.Close();
            formularioActivo = form;
            form.TopLevel = false;
            // quitamos el borde del formulario
            form.FormBorderStyle = FormBorderStyle.None;
            // para llenar todo el panel contenedor
            form.Dock = DockStyle.Fill;
            //agregamos el formulario al panel contenedor
            pnContenido.Controls.Add(form);
            pnContenido.Tag = form;
            // lo traemos al frente para que tape al logo
            form.BringToFront();
            // ahora abrimos el formulario
            form.Show();
        }

        private void opcReservarTurnoRT(object sender, EventArgs e)
        {
            Habilitar(new PantallaRegistrarReserva());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void btnAviso_Click(object sender, EventArgs e)
        {
            string texto = "El sistema de reservas de recursos tecnológicos se encuentra en mantenimiento. Por favor, intente más tarde. Muchas gracias por elegirnos sabemos que somos la mejor opcion disponible. por que somos el mejor equipo de personas. oviamente, como no nos vas a alegir? si no hay otra opcion";
            this.Hide();
            new Avisos(texto, this).Show();
        }
    }
}