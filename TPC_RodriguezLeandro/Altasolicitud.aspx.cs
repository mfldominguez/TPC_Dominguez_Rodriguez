﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace TPC_RodriguezLeandro
{
    public partial class Altasolicitud : System.Web.UI.Page
    {

        public Cliente cliente { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!IsPostBack)
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
            ClienteNegocio negocio = new ClienteNegocio();
            List<Cliente> listacliente = new List<Cliente>();
            listacliente = negocio.listar();
            var idcliente = Convert.ToInt32(Request.QueryString["idc"].ToString());
            cliente = listacliente.Find(J => J.ID == idcliente);

        }

        protected void btnCrearSolicitud_Click(object sender, EventArgs e)
        {

            SolicitudNegocio solinegocio = new SolicitudNegocio();
            Solicitud nuevasoli = new Solicitud();
            Usuario usuario = new Usuario();
            usuario = (Usuario)Session[Session.SessionID + "usuario"];
            try
            {
                nuevasoli.Titulo = txtTitulo.Text.ToString();
                nuevasoli.Cliente.ID = cliente.ID;
                nuevasoli.Usuario.ID = usuario.ID;
                nuevasoli.Desc = txtDescripcion.Text.ToString();
                nuevasoli.FechaInicio = DateTime.Today;
                nuevasoli.Estado.ID = 1;
                nuevasoli.Problematica.ID = Convert.ToInt32(ddlProblemas.SelectedValue);
                nuevasoli.Problematica.Nombre = ddlProblemas.Text;
                nuevasoli.Prioridad.ID = Convert.ToInt32(ddlPrioridad.SelectedValue);
                nuevasoli.Prioridad.Nombre = ddlPrioridad.Text;
                nuevasoli.FechaFin = DateTime.Today;
                
                 
                solinegocio.Alta(nuevasoli);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalAltaSolicitud", "$('#modalAltaSolicitud').modal();", true);
            }
            catch (Exception ex)
            {

                throw ex;

            }
        }
    }
}