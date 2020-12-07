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
    public partial class Principal : System.Web.UI.MasterPage
    {
        public Usuario usuario { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //Usuario usuario = new Usuario();
            usuario = (Usuario)Session[Session.SessionID + "usuario"];

            if ( usuario.Tipo.ID == 1 )
            {
                btnAbmUsuarios.Visible = true;
                btnAbmClientes.Visible = true;
                btnReportes.Visible = true;
            }

            if ( usuario.Tipo.ID == 2 )
            {
                btnAbmClientes.Visible = true;
                btnReportes.Visible = true;
            }


        }

        protected void btnAbmUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("AbmUsuario.aspx");
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }

        protected void btnAbmClientes_Click(object sender, EventArgs e)
        {
            Response.Redirect("AbmClientes.aspx");
        }

        protected void btnReportes_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reportes.aspx");
        }

        //protected void btnLogOut_Click(object sender, EventArgs e)
        //{
        //    Session[Session.SessionID + "usuario"] = null;
        //    //Response.Redirect("Login.aspx");
        //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalAltaSolicitud", "$('#modalAltaSolicitud').modal();", true);
        //}

        protected void btnTilde_Click(object sender, ImageClickEventArgs e)
        {
            Session[Session.SessionID + "usuario"] = null;
            //Response.Redirect("Login.aspx");
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalAltaSolicitud", "$('#modalAltaSolicitud').modal();", true);
        }
    }
}