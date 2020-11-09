<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="AbmUsuario.aspx.cs" Inherits="TPC_RodriguezLeandro.AbmUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button Class="btn btn-primary" ID="btnAltausuario" Text="Agregar usuario" runat="server" OnClick="btnAltausuario_Click" />
    <table class="table">
        <thead>
            <tr>
                <th scope="col">#</th>
                <th scope="col">Usuario</th>
                <th scope="col">Nombre/s y apellido/s</th>
                <th scope="col">Tipo de usuario</th>
                <th scope="col">Estado</th>
                <th scope="col">Funcion</th>
                <th scope="col">Funcion</th>
            </tr>
        </thead>
        <tbody>
            <%foreach (var item in listas)
                {%>
            <tr>
                <th scope="row"><% = item.ID %></th>
                <td><% = item.NombreUsuario %></td>
                <td><% = item.Nombres + " " + item.Apellidos %></td>
                <td><% = item.Tipo %></td>
                <td><% = item.Estado %></td>
                <td>
                    <a href="ModificarUsuario.aspx?idu=<%=item.ID %>">Modificar</a>
                </td>
                <td>
                    <a href="EliminarUsuario.aspx?idu=<%=item.ID %>">Inactivar</a>
                </td>
            </tr>
            <%} %>
        </tbody>
    </table>
    
</asp:Content>
