<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ModificarUsuario.aspx.cs" Inherits="TPC_RodriguezLeandro.ModificarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h3>Modificar usuario:</h3>
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
            <div class="form-group">
                <label style="margin-left: 10px" for="exampleFormControlSelect2">Tipo de usuario</label>
                <asp:DropDownList ID="ddlTipoUsuario" CssClass="form-control" runat="server">
                </asp:DropDownList>
            </div>
            <div class="row">
                <div class="col">
                    <asp:Button Style="margin-top: 10px" ID="btnModificar" CssClass="btn btn-primary" Text="Modificar" runat="server" OnClick="btnModificar_Click" />
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="modal4" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">
                        <asp:Label ID="Label1" runat="server" Text="">Modificar</asp:Label>
                    </h4>
                </div>
                <div class="modal-body">
                    <asp:Label ID="Label2" runat="server" Text="">Datos de usuario modificados con exito</asp:Label>
                </div>
                <div class="modal-footer">
                    <a href="AbmUsuario.aspx" class="btn btn-info">Volver</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
