﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Comentarios
    {
        public long ID { get; set; }
        public Usuario Usuario { get; set; }
        public long IDSolicitud { get; set; }
        public DateTime FechaComentario { get; set; }
        public string Comentario { get; set; }
        public bool Solucion { get; set; }

        public Comentarios()
        {
            this.Usuario = new Usuario();
        }
    }
}
