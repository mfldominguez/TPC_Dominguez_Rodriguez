using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TPC_RodriguezLeandro
{
    public partial class AbmUsuario : System.Web.UI.Page
    {
        public Usuario usuario { get; set; }
        public List<Usuario> listas { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            usuario = (Usuario)Session[Session.SessionID + "usuario"];
            if (usuario.Tipo.ID == 3 || usuario.Tipo.ID == 2)
            {
                Response.Redirect("Inicio.aspx");
            }

            UsuariosNegocio negocio = new UsuariosNegocio();
            listas = negocio.ListarTODO();
            usuario = (Usuario)Session[Session.SessionID + "usuario"];
            try
            {


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnAltausuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("Altausuarios.aspx");
        }
    }
}