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
    public partial class Altausuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TipoUsuariosNegocio negocio = new TipoUsuariosNegocio();
                ddlTipoUsuario.DataSource = negocio.listar();
                ddlTipoUsuario.DataValueField = "ID";
                ddlTipoUsuario.DataTextField = "Nombre";
                ddlTipoUsuario.DataBind();


            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            AccesoaDatos datos = new AccesoaDatos();
            UsuariosNegocio negocio = new UsuariosNegocio();
            TipoUsuariosNegocio negocio1 = new TipoUsuariosNegocio();
            Usuario usuario = new Usuario();
            try
            {
                usuario.Tipo.ID = Convert.ToInt32(ddlTipoUsuario.SelectedValue);
                usuario.Tipo.Nombre = ddlTipoUsuario.Text;
                usuario.NombreUsuario = txtUsuario.Text;
                usuario.Contraseña = txtContraseña.Text;
                usuario.Nombres = txtNombre.Text;
                usuario.Apellidos = txtApellidos.Text;
                usuario.Estado = true;
                negocio.Alta(usuario);
                Response.Redirect("AbmUsuario.aspx");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}