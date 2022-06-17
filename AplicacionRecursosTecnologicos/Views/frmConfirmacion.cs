using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicacionRecursosTecnologicos.Views
{
    public partial class frmConfirmacion : Form
    {
        private PantallaRegistrarReserva pantallaRegistrar;
        public frmConfirmacion(String informacion, PantallaRegistrarReserva pantalla)
        {
            InitializeComponent();
            this.lblInformacion.Text = informacion;
            this.pantallaRegistrar = pantalla;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            //si cliqueo en confirmar accionamos el ConfirmarReserva
            //mandandole las opciones de notificacion
            this.pantallaRegistrar.ConfirmarReserva(this.cbMail.Checked, this.cbWpp.Checked);
            this.Dispose();
        }
    }
}
