using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Solicitud
    {
        public long ID { get; set; }
        public Cliente Cliente { get; set; }
        public Sintomas Sintoma { get; set; }
        public Usuario Usuario { get; set; }
        public string Titulo { get; set; }
        public string Desc { get; set; }
        public Estados Estado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public Solicitud() 
        {
            this.Cliente = new Cliente();
            this.Sintoma = new Sintomas();
            this.Usuario = new Usuario();
            this.Estado = new Estados();
        }

    }
}
