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
    public partial class ListadodeAdm : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            UsuariosNegocio negocio = new UsuariosNegocio();
            dgvABM.DataSource = negocio.Listar();
            dgvABM.DataBind();
            

        }
    }
}