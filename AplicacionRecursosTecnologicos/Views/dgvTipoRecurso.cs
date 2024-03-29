﻿using AplicacionRecursosTecnologicos.Models;
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
        public void mostrarDatosTipoRecurso(List<String[]> tipos)
        {
            this.dgvTiposRecurso.Rows.Clear();
            foreach (var tipo in tipos)
            {
                
                this.dgvTiposRecurso.Rows.Add(tipo);


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
        public List<TipoRecursoTecnologico> getTiposSeleccionados()
        {
            var lista = new List<TipoRecursoTecnologico>();

            for (int i=0; i < dgvTiposRecurso.SelectedRows.Count; i++)
            {
                var tipo = new TipoRecursoTecnologico();
                tipo.nombre = dgvTiposRecurso.SelectedRows[i].Cells[0].Value.ToString();
                tipo.descripcion = dgvTiposRecurso.SelectedRows[i].Cells[1].Value.ToString();
                lista.Add(tipo);
            }
            return lista;
        }
    }
}
