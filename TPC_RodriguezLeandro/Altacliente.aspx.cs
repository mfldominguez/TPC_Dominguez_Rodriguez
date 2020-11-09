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
    public partial class Altacliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            AccesoaDatos datos = new AccesoaDatos();
            ClienteNegocio negocio = new ClienteNegocio();
            Cliente cliente = new Cliente();
            try
            {
                cliente.Nombres = txtNombre.Text;
                cliente.Apellidos = txtApellidos.Text;
                cliente.Direccion = txtDireccion.Text;
                cliente.Telefono = txtTelefono.Text;
                cliente.Estado = true;
                negocio.alta(cliente);
                Response.Redirect("Abmcliente.aspx");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}