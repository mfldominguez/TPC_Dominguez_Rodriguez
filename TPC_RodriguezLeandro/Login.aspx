﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Session.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPC_RodriguezLeandro.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div style="text-align:center" class="container">
        <div class="row">
            <div class="col">
                <h1>Login</h1>
            </div>
        </div>
        <div class="row">
            <div class=" col">
                <div class="form-group">
                    <label style="margin-left:20px">Usuario</label>
                    <asp:TextBox cssclass="align-content-lg-center" style="width:25%" ID="txtUsuario" runat="server" />
                </div>
                <div class="form-group">
                    <label>Contraseña</label>
                    <asp:TextBox cssclass="align-content-lg-center" style="width:25%" ID="txtPassword" TextMode="Password" runat="server" />
                </div>
                <%--<asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary" runat="server" OnClick="btnAceptar_Click" />--%>
                <asp:ImageButton style="background-position:left" ID="btnTilde" runat="server" ImageUrl="http://pre10.deviantart.net/f046/th/pre/i/2012/218/d/b/tilde_by_miikita-d5a2zce.png" Height="65px" Width="65px" OnClick="btnTilde_Click" />
            </div>
        </div>
    </div>
    <div class="modal fade" id="modal1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">
                        <asp:Label ID="lblModalTitle" runat="server" Text="">Logeo</asp:Label>
                    </h4>
                </div>
                <div class="modal-body">
                    <asp:Label ID="lblModalBody" runat="server" Text="">Datos correctos</asp:Label>
                </div>
                <div class="modal-footer">
                    <a href="Inicio.aspx" class="btn btn-info">Inicio</a>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="modal2" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">
                        <asp:Label ID="Label1" runat="server" Text="">Logeo</asp:Label>
                    </h4>
                </div>
                <div class="modal-body">
                    <asp:Label ID="Label2" runat="server" Text="">Datos incorrectos</asp:Label>
                </div>
                <div class="modal-footer">
                    <a href="Login.aspx" class="btn btn-info">Volver</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
