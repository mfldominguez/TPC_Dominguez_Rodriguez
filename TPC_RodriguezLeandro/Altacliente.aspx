<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Altacliente.aspx.cs" Inherits="TPC_RodriguezLeandro.Altacliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h3>Alta cliente:</h3>
        <div class="container">
            <div class="row">
                <div class="col">
                    <asp:Label Text="Nombre/s" runat="server" />
                    <asp:TextBox class="col" ID="txtNombre" runat="server" />
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <asp:Label Text="Apellido/s" runat="server" />
                    <asp:TextBox class="col" ID="txtApellidos" runat="server" />
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <asp:Label Text="Direccion" runat="server" />
                    <asp:TextBox class="col" ID="txtDireccion" runat="server" />
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <asp:Label Text="Telefono" runat="server" />
                    <asp:TextBox class="col" ID="txtTelefono" runat="server" />
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <asp:Button Style="margin-top: 10px" ID="btnAgregar" CssClass="btn btn-primary" Text="Agregar" runat="server" OnClick="btnModificar_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
