using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public long ID { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public bool Estado { get; set; }
        public TipoUsuarios Tipo { get; set; }

        public Usuario()
        {
            this.Tipo = new TipoUsuarios();
        }
    }
}
