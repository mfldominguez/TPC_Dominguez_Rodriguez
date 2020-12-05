<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="TPC_RodriguezLeandro.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h3 style="margin-top:10px">Buscador de clientes:</h3>
        <asp:TextBox ID="txtBuscar" CssClass="form-control mr-sm-2" Style="width: 25%" placeholder="Buscar por cliente" runat="server" />
        <asp:Button class="btn btn-outline-info" Style="margin-top: 10px" ID="btnBuscar" Text="Buscar" runat="server" OnClick="btnBuscar_Click" />
        <table class="table">
            <thead>
                <tr>
                    <th scope="col">#</th>
                    <th scope="col">Cliente</th>
                    <th scope="col">Perfil</th>
                </tr>
            </thead>
            <tbody>
                <%foreach (var item in listaclientes)
                    {%>
                <tr>
                    <th scope="row"><% = item.ID %></th>
                    <td><% = item.Nombres %></td>
                    <td>
                        <a href="PerfilCliente.aspx?idc=<% = item.ID.ToString() %>">
                            <svg width="1em" height="1em" viewBox="0 0 16 16" class="bi bi-person-circle" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                                <path d="M13.468 12.37C12.758 11.226 11.195 10 8 10s-4.757 1.225-5.468 2.37A6.987 6.987 0 0 0 8 15a6.987 6.987 0 0 0 5.468-2.63z" />
                                <path fill-rule="evenodd" d="M8 9a3 3 0 1 0 0-6 3 3 0 0 0 0 6z" />
                                <path fill-rule="evenodd" d="M8 1a7 7 0 1 0 0 14A7 7 0 0 0 8 1zM0 8a8 8 0 1 1 16 0A8 8 0 0 1 0 8z" />
                            </svg>
                        </a>
                    </td>

                </tr>
                <%} %>
            </tbody>

        </table>
    </div>
</asp:Content>
