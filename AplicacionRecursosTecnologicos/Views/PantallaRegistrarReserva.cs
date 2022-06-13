using AplicacionRecursosTecnologicos.Controller;
using AplicacionRecursosTecnologicos.Models;
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
    public partial class PantallaRegistrarReserva : Form
    {
        private GestorDeReservaRT gestor;
        private dgvTipoRecurso dgvTipoRecurso;
        private Form formularioActivo = null;
        private dgvRecursos dgvRecursos;
        public PantallaRegistrarReserva()
        {
            InitializeComponent();
            gestor = new GestorDeReservaRT();
        }
        

        private void PantallaRegistrarReserva_Load(object sender, EventArgs e)
        {
            gestor.reservar(this);

        }
        public void mostrarDatosTipoRecurso(List<TipoRecursoTecnologico> tipos)
        {
            this.dgvTipoRecurso = new dgvTipoRecurso();
            this.dgvTipoRecurso.mostrarDatosTipoRecurso(tipos);
            Habilitar(dgvTipoRecurso);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
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
            pnDgv.Controls.Add(form);
            pnDgv.Tag = form;
            // lo traemos al frente para que tape al logo
            form.BringToFront();
            // ahora abrimos el formulario
            form.Show();
        }
        public void solicitarSeleccionTipoRecurso()
        {
            this.lblTexto.Text = "Seleccione uno o más Tipos de Recursos Tecnologicos";
            this.btnBuscar.Text = "Buscar recursos tecnologicos";
            this.dgvTipoRecurso.SeleccionarTodosLosTipos();
        }

        private void seleccionTipoRecurso(object sender, EventArgs e)
        {
            if(btnBuscar.Text == "Buscar recursos tecnologicos")
            {
                if (dgvTipoRecurso.verificarSeleccion())
                    this.gestor.TipoRecursoSeleccionado(dgvTipoRecurso.getTiposSeleccionados());
                else
                    MessageBox.Show("Debe Seleccionar al menos un Tipo", "informacion", MessageBoxButtons.OK);
            
            }
            else if(btnBuscar.Text == "Buscar Turnos Disponibles")
            {
                if (dgvRecursos.verificarSeleccion())
                    this.gestor.TomarSeleccionRT(dgvRecursos.GetRTSeleccionado());
                else
                    MessageBox.Show("Debe Seleccionar 1 Recurso Tecnologico", "informacion", MessageBoxButtons.OK);
            }

        }

        public void MostrarRescursos(List<(RecursoTecnologico, CentroDeInvestigacion, Marca)> lrt)
        {
            this.dgvRecursos = new dgvRecursos();
            Habilitar(dgvRecursos);
            this.dgvRecursos.MostrarRecursos(lrt);
        }

        public void SolicitarSeleccionRecurso()
        {
            this.lblTexto.Text = "Seleccione un Recurso Tecnologico";
            this.btnBuscar.Text = "Buscar Turnos Disponibles";
        }


    }
}
