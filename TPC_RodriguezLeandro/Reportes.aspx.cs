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
        public List<Solicitud> listaSolicitudes { get; set; }
        Solicitud solicitud;
        AccesoaDatos datos = new AccesoaDatos();
        public int Cant { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {
                    ProblematicasNegocio problematicasNegocio = new ProblematicasNegocio();
                    ddlProblemas.DataSource = problematicasNegocio.listar();
                    ddlProblemas.DataValueField = "ID";
                    ddlProblemas.DataTextField = "Nombre";
                    ddlProblemas.DataBind();

                    PrioridadNegocio prioridadNegocio = new PrioridadNegocio();
                    ddlPrioridad.DataSource = prioridadNegocio.listar();
                    ddlPrioridad.DataValueField = "ID";
                    ddlPrioridad.DataTextField = "Nombre";
                    ddlPrioridad.DataBind();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            SolicitudNegocio negocio = new SolicitudNegocio();
            listaSolicitudes = negocio.ListarTodo();
            Cant = 0;
            foreach ( var item in listaSolicitudes)
            {
                if ( (Convert.ToInt32(ddlProblemas.SelectedValue) == item.Problematica.ID) && (Convert.ToInt32(ddlPrioridad.SelectedValue) == item.Prioridad.ID) )
                {
                    Cant++;
                }

            }

            
        }
    }
}