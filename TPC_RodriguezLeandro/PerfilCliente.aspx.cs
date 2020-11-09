using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_RodriguezLeandro
{
    public partial class PerfilCliente : System.Web.UI.Page
    {
        public List<Solicitud> listasolicitudabiertas { get; set; }
        public List<Solicitud> listasolicitudcerradas { get; set; }
        public Cliente cliente { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ClienteNegocio negocio = new ClienteNegocio();
            SolicitudNegocio solinegocio = new SolicitudNegocio();
            List<Cliente> listacliente = new List<Cliente>();
            listacliente = negocio.listar();
            try
            {
                var idcliente = Convert.ToInt32(Request.QueryString["idc"].ToString());
                cliente = listacliente.Find(J => J.ID == idcliente);
                listasolicitudabiertas = solinegocio.Listar_en_perfil_abiertas(cliente.ID);
                listasolicitudcerradas = solinegocio.Listar_en_perfil_cerradas(cliente.ID);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}