<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Solicitudinterna.aspx.cs" Inherits="TPC_RodriguezLeandro.Solicitudinterna" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card" style="width: 50%">
        <div class="card-body">
            <h5 class="card-title"><% = solicitud.ID %></h5>
            <p class="card-text"><% = solicitud.Titulo %></p>

            <p class="card-text"><% = solicitud.Usuario.Nombres + " " + solicitud.Usuario.Apellidos %></p>
            <p class="card-text"><% = solicitud.FechaInicio.ToShortDateString() %></p>
        </div>
    </div>
    <div class="card-columns" style="margin-left: 15px; margin-right: 5px;">
        <%       foreach (var item in lista)
            { %>
        <div class="card" style="width: 18rem;">
            <div class="card-body">
                <h5 class="card-title"><% = item.ID %></h5>
                <p class="card-text"><% = item.solicitud%></p>
                <p class="card-text"><% = item.Usuario.Nombres + " " + item.Usuario.Apellidos%></p>
                <p class="card-text"><% = item.Comentario%> </p>
            </div>
        </div>
        <% } %>
    </div>

    
</asp:Content>
