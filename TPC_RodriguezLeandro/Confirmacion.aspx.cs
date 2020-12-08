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
    public partial class Confirmacion : System.Web.UI.Page
    {
        public long idsolicitud { get; set; }
        public long idcomentario { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Solicitud solicitud = new Solicitud();
            SolicitudNegocio negocio = new SolicitudNegocio();
            ComentarioNegocio negociocom = new ComentarioNegocio();
            try
            {
                idcomentario = Convert.ToInt64(Request.QueryString["idc"].ToString());
                idsolicitud = Convert.ToInt64(Request.QueryString["ids"].ToString());
                solicitud = negocio.mostrar_abiertas(idsolicitud);
                solicitud.FechaFin = DateTime.Today;
                negocio.solucionar(solicitud);
                negociocom.solucionar(idcomentario);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modal8", "$('#modal8').modal();", true);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {

            Response.Redirect("SolicitudInterna.aspx?ids=" + idsolicitud);
        }
    }
}