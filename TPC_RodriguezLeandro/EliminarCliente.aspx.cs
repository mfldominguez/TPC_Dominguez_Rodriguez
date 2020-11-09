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
    public partial class EliminarCliente : System.Web.UI.Page
    {
        public Cliente cliente { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ClienteNegocio negocio = new ClienteNegocio();
            List<Cliente> lista = new List<Cliente>();
            lista = negocio.listarTODO();
            try
            {
                var idcliente = Convert.ToInt32(Request.QueryString["idc"].ToString());
                cliente = lista.Find(J => J.ID == idcliente);
                negocio.inactivo(cliente.ID);
                Response.Redirect("AbmClientes.aspx");

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}