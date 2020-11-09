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
        public List<Usuario> listas { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuariosNegocio negocio = new UsuariosNegocio();
            listas = negocio.ListarTODO();
            
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