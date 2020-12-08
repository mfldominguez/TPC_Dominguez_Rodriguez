<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="TPC_RodriguezLeandro.Reportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    
        <div class="form-group">
        <label style="margin-left: 10px" for="exampleFormControlSelect2">Problema</label>
        <asp:DropDownList ID="ddlProblemas" CssClass="form-control" runat="server">
        </asp:DropDownList>
    </div>
    <div class="form-group">
        <label style="margin-left: 10px" for="exampleFormControlSelect2">Prioridad</label>
        <asp:DropDownList ID="ddlPrioridad" CssClass="form-control" runat="server">
        </asp:DropDownList>
    </div>


    <asp:Button class="btn btn-outline-primary" ID="btnBuscar" Text="Buscar" runat="server" OnClick="btnBuscar_Click" />

    <p>Hay <% = Cant %> Solicitudes </p>

</div>
</asp:Content>
