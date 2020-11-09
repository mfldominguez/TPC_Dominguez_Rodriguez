<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="PerfilCliente.aspx.cs" Inherits="TPC_RodriguezLeandro.PerfilCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Cliente</h2>
    <a href="Altasolicitud.aspx?idc=<% = cliente.ID%>">
        <asp:Label ID="txtSolicitud" Text="Nueva solicitud" runat="server" />
    </a>
    <div class="card" style="width: 25%">
        <div class="card-body">
            <h5 class="card-title"><% = cliente.Nombres %></h5>
            <p class="card-text"><% = cliente.Apellidos %></p>

            <p class="card-text"><% = cliente.Direccion %></p>
            <p class="card-text"><% = cliente.Telefono %></p>

        </div>

    </div>
    <h3>Solicitudes abiertas</h3>
    <table class="table">
        <thead>
            <tr>
                <th scope="col">#</th>
                <th scope="col">Titulo</th>
                <th scope="col">Problematica</th>
                <th scope="col">Estado</th>
                <th scope="col">Fecha Inicio</th>
            </tr>
        </thead>
        <tbody>
            <%foreach (var item in listasolicitudabiertas)
                {%>
            <tr>
                <th scope="row"><% = item.ID %></th>
                <td><% = item.Titulo %></td>
                <td><% = item.Sintoma.Nombre %></td>
                <td><% = item.Estado.Nombre %></td>
                <td><% = item.FechaInicio.ToShortDateString() %></td>
                <td>
                    <a href="Solicitudinterna.aspx?ids=<%=item.ID %>">Ver solicitud</a>
                </td>
            </tr>
            <%} %>
        </tbody>
    </table>
    <h3>Solicitudes cerradas</h3>
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
                <td><% = item.Sintoma.Nombre %></td>
                <td><% = item.Estado.Nombre %></td>
                <td><% = item.FechaFin %></td>
                <td>
                    <a href="Solicitudinterna.aspx?ids=<%=item.ID %>">Ver solicitud</a>
                </td>

            </tr>
            <%} %>
        </tbody>

    </table>
</asp:Content>
