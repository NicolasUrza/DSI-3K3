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
    public partial class dgvTipoRecurso : Form
    {
        public dgvTipoRecurso()
        {
            InitializeComponent();
        }

        private void dgvTipoRecurso_Load(object sender, EventArgs e)
        {

        }
        public void mostrarDatosTipoRecurso(List<TipoRecursoTecnologico> tipos)
        {
            this.dgvTiposRecurso.Rows.Clear();
            foreach (TipoRecursoTecnologico tipo in tipos)
            {
                var fila = new string[]
                    {
                        tipo.id_tipo_recurso.ToString(),
                        tipo.nombre,
                        tipo.descripcion

                    };
                this.dgvTiposRecurso.Rows.Add(fila);


            }

            //dgvTipoRecurso.Rows[0].DefaultCellStyle.BackColor = Color.Red;
        }
        public void SeleccionarTodosLosTipos()
        {
            this.dgvTiposRecurso.SelectAll();
        }

        public bool verificarSeleccion()
        {
            return this.dgvTiposRecurso.SelectedRows.Count > 0;
        }
        public List<int> getTiposSeleccionados()
        {
            var lista = new List<int>();

            for (int i=0; i < dgvTiposRecurso.SelectedRows.Count; i++)
            {
                var tipo = dgvTiposRecurso.SelectedRows[i].Cells[0].Value;
                lista.Add(Convert.ToInt32(tipo));
            }
            return lista;
        }
    }
}
