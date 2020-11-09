<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Altausuarios.aspx.cs" Inherits="TPC_RodriguezLeandro.Altausuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h3>Alta de usuario:</h3>
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
                    <asp:Label Text="Usuario" runat="server" />
                    <asp:TextBox class="col" ID="txtUsuario" runat="server" />
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <asp:Label Text="Contraseña" runat="server" />
                    <asp:TextBox class="col" TextMode="Password" ID="txtContraseña" runat="server" />
                </div>
            </div>
            <div class="row">
                <div class="col" style="margin-top: 10px">
                    <asp:Label Text="Tipo de usuario" runat="server" />
                    <asp:TextBox class="col" ID="txtTipo" runat="server" />
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <asp:Button Style="margin-top: 10px" ID="btnAgregar" CssClass="btn btn-primary" Text="Agregar" runat="server" OnClick="btnAgregar_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
