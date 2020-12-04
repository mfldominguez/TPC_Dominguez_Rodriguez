﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_RodriguezLeandro
{
    public partial class ModificarCliente : System.Web.UI.Page
    {
        public int idcliente { get; set; }
        public Cliente cliente { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ClienteNegocio negocio = new ClienteNegocio();
            List<Cliente> lista = new List<Cliente>();
           
            lista = negocio.listar();
            
            try
            {
                idcliente = Convert.ToInt32(Request.QueryString["idc"].ToString());
                cliente = lista.Find(J => J.ID == idcliente);

                if(!IsPostBack)
                {

                txtNombre.Text = cliente.Nombres;
                txtApellidos.Text = cliente.Apellidos;
                txtDireccion.Text = cliente.Direccion;
                txtTelefono.Text = cliente.Telefono;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            AccesoaDatos datos = new AccesoaDatos();
            ClienteNegocio negocio = new ClienteNegocio();
            try
            {
                cliente.ID = idcliente;
                cliente.Nombres = txtNombre.Text;
                cliente.Apellidos = txtApellidos.Text;
                cliente.Direccion = txtDireccion.Text;
                cliente.Telefono = txtTelefono.Text;
                cliente.Estado = true;
                negocio.modificar(cliente);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modal3", "$('#modal3').modal();", true);
                //Response.Redirect("AbmUsuario.aspx");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}