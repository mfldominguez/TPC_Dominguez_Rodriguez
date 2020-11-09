using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_RodriguezLeandro
{
    public partial class ModificarUsuario : System.Web.UI.Page
    {
        public Usuario usuario { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuariosNegocio negocio = new UsuariosNegocio();
            List<Usuario> lista = new List<Usuario>();
            lista = negocio.Listar();
            try
            {
                var idusuario = Convert.ToInt64(Request.QueryString["idu"].ToString());
                usuario = lista.Find(J => J.ID == idusuario);
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            AccesoaDatos datos = new AccesoaDatos();
            UsuariosNegocio negocio = new UsuariosNegocio();
            try
            {
                usuario.Tipo = txtTipo.Text;
                usuario.NombreUsuario = txtUsuario.Text;
                usuario.Contraseña = txtContraseña.Text;
                usuario.Nombres = txtNombre.Text;
                usuario.Apellidos = txtApellidos.Text;
                usuario.Estado = true;
                negocio.modificar(usuario);
                Response.Redirect("AbmClientes.aspx");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}