﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Solicitud
    {
        public long ID { get; set; }
        public Cliente Cliente { get; set; }
        public Problematicas Problematica { get; set; }
        public Usuario Usuario { get; set; }
        public string Titulo { get; set; }
        public string Desc { get; set; }
        public Estados Estado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public Prioridad Prioridad { get; set; }
        public Solicitud() 
        {
            this.Cliente = new Cliente();
            this.Problematica = new Problematicas();
            this.Usuario = new Usuario();
            this.Estado = new Estados();
            this.Prioridad = new Prioridad();
        }

    }
}
