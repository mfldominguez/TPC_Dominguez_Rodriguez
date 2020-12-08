<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="PerfilCliente.aspx.cs" Inherits="TPC_RodriguezLeandro.PerfilCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div></div>
    <h3 style="margin-left: 15px"> Perfil del Cliente</h3>
    <a style="margin-left: 15px" href="Altasolicitud.aspx?idc=<% = cliente.ID%>">
        <asp:Label ID="txtSolicitud" Text="Nueva solicitud" runat="server" />
    </a>
    <div style="margin-top:30px; margin-bottom:30px">
        <div class="card; border-dark;" style="width: 25%">
            <div class="card-body; text-center">
                <h6 class="card-title">Nombres/s: <% = cliente.Nombres %></h6>
                <p class="card-text">Apellido/s: <% = cliente.Apellidos %></p>
                <p class="card-text">Direccion: <% = cliente.Direccion %></p>
                <p class="card-text">Telefono: <% = cliente.Telefono %></p>

            </div>

        </div>
    </div>
    <h5 style="margin-left: 15px">Solicitudes abiertas</h5>
    <table class="table">
        <thead>
            <tr>
                <th scope="col">#</th>
                <th scope="col">Titulo</th>
                <th scope="col">Problematica</th>
                <th scope="col">Estado</th>
                <th scope="col">Prioridad</th>
                <th scope="col">Fecha Inicio</th>
                <th scope="col">Fecha Ultima Modificacion</th>
            </tr>
        </thead>
        <tbody>
            <%foreach (var item in listasolicitudabiertas)
                {%>
            <tr>
                <th scope="row"><% = item.ID %></th>
                <td><% = item.Titulo %></td>
                <td><% = item.Problematica.Nombre %></td>
                <td><% = item.Estado.Nombre %></td>
                <td><% = item.Prioridad.Nombre %></td>
                <td><% = item.FechaInicio.ToShortDateString() %></td>
                <td><% = item.FechaFin.ToShortDateString()  %></td>
                <td>
                    <a href="Solicitudinterna.aspx?ids=<%=item.ID %>">Ver solicitud</a>
                </td>
            </tr>
            <%} %>
        </tbody>
    </table>
    <h5 style="margin-left: 15px">Solicitudes cerradas</h5>
    <table class="table">
        <thead>
            <tr>
                <th scope="col">#</th>
                <th scope="col">Titulo</th>
                <th scope="col">Problematica</th>
                <th scope="col">Estado</th>
                <th scope="col">Fecha Fin</th>

            </tr>
        </thead>
        <tbody>
            <%foreach (var item in listasolicitudcerradas)
                {%>
            <tr>
                <th scope="row"><% = item.ID %></th>
                <td><% = item.Titulo %></td>
                <td><% = item.Problematica.Nombre %></td>
                <td><% = item.Estado.Nombre %></td>
                <td><% = item.FechaFin.ToShortDateString() %></td>
                <td>
                    <a href="Solicitudinterna.aspx?ids=<%=item.ID %>">Ver solicitud</a>
                </td>

            </tr>
            <%} %>
        </tbody>

    </table>
</div>
</asp:Content>
