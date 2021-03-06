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
    public partial class Solicitudinterna : System.Web.UI.Page
    {
        public Solicitud solicitud { get; set; }
        public List<Comentarios> lista { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            SolicitudNegocio negocio = new SolicitudNegocio();
            ComentarioNegocio negociocom = new ComentarioNegocio();
            try
            {
                var idsolicitud = Convert.ToInt64(Request.QueryString["ids"].ToString());
                solicitud = negocio.mostrar_abiertas(idsolicitud);
                lista = negociocom.listardesolicitud(idsolicitud);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void btnAltaComentario_Click(object sender, EventArgs e)
        {
            ComentarioNegocio comentarioNegocio = new ComentarioNegocio();
            Comentarios comentario = new Comentarios();
            Usuario usuario = new Usuario();
            usuario = (Usuario)Session[Session.SessionID + "usuario"];

            try
            {
                
                comentario.IDSolicitud = Convert.ToInt64(Request.QueryString["ids"].ToString());
                comentario.Usuario.ID = usuario.ID;
                comentario.FechaComentario = DateTime.Today;
                comentario.Comentario = txtComentario.Text;

                if ( txtComentario.Text == "")
                {
                    Response.Redirect("SolicitudInterna.aspx?ids=" + comentario.IDSolicitud);
                }

                comentarioNegocio.alta(comentario);

                SolicitudNegocio negocio = new SolicitudNegocio();
                solicitud.FechaFin = DateTime.Today;
                solicitud.Estado.ID = 2;
                negocio.comentar(solicitud);

                Response.Redirect("SolicitudInterna.aspx?ids=" + comentario.IDSolicitud);


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnSolucionar_Click(object sender, EventArgs e)
        {
            SolicitudNegocio negocio = new SolicitudNegocio();
            solicitud.FechaFin = DateTime.Today;
            negocio.solucionar(solicitud);

            Response.Redirect("SolicitudInterna.aspx?ids=" + solicitud.ID);
        }

        protected void btnCerrarSolicitud_Click(object sender, EventArgs e)
        {
            SolicitudNegocio negocio = new SolicitudNegocio();
            solicitud.FechaFin = DateTime.Today;
            negocio.cerrar(solicitud);

            //Response.Redirect("Inicio.aspx?");
            Response.Redirect("SolicitudInterna.aspx?ids=" + solicitud.ID);
        }

        protected void btnReabrir_Click(object sender, EventArgs e)
        {
            SolicitudNegocio negocio = new SolicitudNegocio();
            negocio.reabrir(solicitud);
            Response.Redirect("SolicitudInterna.aspx?ids=" + solicitud.ID);
        }

    }
}