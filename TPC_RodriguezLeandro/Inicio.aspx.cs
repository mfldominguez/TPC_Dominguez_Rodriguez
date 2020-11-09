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
    public partial class Inicio : System.Web.UI.Page
    {
        public List<Cliente> listaclientes { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {
                ClienteNegocio negocio = new ClienteNegocio();
                listaclientes = negocio.listar();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
               

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}