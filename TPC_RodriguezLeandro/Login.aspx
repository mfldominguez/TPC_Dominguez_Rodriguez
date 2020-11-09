<%@ Page Title="" Language="C#" MasterPageFile="~/Session.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPC_RodriguezLeandro.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <div class="row">
            <div class="col">
                <h1>Login</h1>
            </div>
        </div>
        <div class="row">
            <div class=" col">
                <div class="form-group">
                    <label>Usuario</label>
                    <asp:TextBox ID="txtUsuario" CssClass="form-control" runat="server" />
                </div>
                <div class="form-group">
                    <label>Contraseña</label>
                    <asp:TextBox ID="txtPassword" CssClass="form-control" TextMode="Password" runat="server" />
                </div>
                <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary" runat="server" OnClick="btnAceptar_Click" />
            </div>
        </div>

    </div>
</asp:Content>
