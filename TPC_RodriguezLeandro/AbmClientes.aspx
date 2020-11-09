<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="AbmClientes.aspx.cs" Inherits="TPC_RodriguezLeandro.AbmClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button Class="btn btn-primary" ID="btnAltaClientes" Text="Agregar cliente" runat="server" OnClick="btnAltausuario_Click" />
    <table class="table">
        <thead>
            <tr>
                <th scope="col">#</th>
                <th scope="col">Nombre/s y apellido/s</th>
                <th scope="col">Direccion</th>
                <th scope="col">Contacto</th>
                <th scope="col">Fecha de registracion</th>
                <th scope="col">Estado</th>
                <th scope="col">Funcion</th>
                <th scope="col">Funcion</th>
            </tr>
        </thead>
        <tbody>
            <%foreach (var item in lista)
                {%>
            <tr>
                <th scope="row"><% = item.ID %></th>
                <td><% = item.Nombres + " " + item.Apellidos %></td>
                <td><% = item.Direccion %></td>
                <td><% = item.Telefono %></td>
                <td><% = item.FechaReg.ToShortDateString() %></td>
                <td><% = item.Estado %></td>
                <td>
                    <a href="ModificarCliente.aspx?idc=<%=item.ID %>">Modificar</a>
                </td>
                <td>
                    <a href="EliminarCliente.aspx?idc=<%=item.ID %>">Inactivar</a>
                </td>

            </tr>
            <%} %>
        </tbody>
    </table>
    <a ID="link" class="nav-link disabled" href="#" tabindex="-1" aria-disabled="true">Disabled</a>
</asp:Content>
