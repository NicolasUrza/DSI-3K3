﻿using AplicacionRecursosTecnologicos.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionRecursosTecnologicos.Models
{
    public class Modelo
    {
        public string nombre { get; set; }

        public Marca GetMarcaDelModelo()
        {
            var marcaServicio = new MarcaServicio();
            return marcaServicio.GetMarcaDelModelo(this);
        }
    }
}
