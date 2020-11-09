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
    public partial class EliminarUsuario : System.Web.UI.Page
    {
        public Usuario usuario { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuariosNegocio negocio = new UsuariosNegocio();
            List<Usuario> lista = new List<Usuario>();
            lista = negocio.ListarTODO();
            try
            {
                var idusuario = Convert.ToInt64(Request.QueryString["idu"].ToString());
                usuario = lista.Find(J => J.ID == idusuario);
                negocio.inactivar(usuario.ID);
                Response.Redirect("AbmUsuario.aspx");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}