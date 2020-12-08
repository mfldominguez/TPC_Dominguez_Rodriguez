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
    public partial class AbmClientes : System.Web.UI.Page
    {
        public List<Cliente> lista { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario = (Usuario)Session[Session.SessionID + "usuario"];
            if ( usuario.Tipo.ID == 3 )
            {
                Response.Redirect("Inicio.aspx");
            }

            ClienteNegocio negocio = new ClienteNegocio();
            lista = negocio.listarTODO();
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
            Response.Redirect("Altacliente.aspx");
        }
    }
}