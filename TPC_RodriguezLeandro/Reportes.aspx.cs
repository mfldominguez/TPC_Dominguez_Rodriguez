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
    public partial class Reportes : System.Web.UI.Page
    {
        List<Solicitud> lista = new List<Solicitud>();
        Solicitud solicitud;
        AccesoaDatos datos = new AccesoaDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }
    }
}