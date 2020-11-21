using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace TPC_RodriguezLeandro
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            UsuariosNegocio negocio = new UsuariosNegocio();
            Usuario usuario = new Usuario();
            usuario = negocio.validarUsuario(txtUsuario.Text, txtPassword.Text);

            if( usuario.ID == 0)
            {
                Response.Redirect("Login.aspx");
            }

            Session[Session.SessionID + "usuario"] = usuario;
            Response.Redirect("Inicio.aspx");
        }
    }
}