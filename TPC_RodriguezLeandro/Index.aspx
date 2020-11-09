<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TPC_RodriguezLeandro.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Hola!</h1>
    <a href="Listadogeneral.aspx" id="btnListadoGeneral" style="margin-top:10px; margin-left:10px; margin-bottom:10px" class="btn btn-primary">Listado general</a>
    <asp:Label Text="Usuario a dar de baja" runat="server" />
    <asp:TextBox ID="txtBaja" runat="server" />
    <asp:Button Text="Baja" runat="server" OnClick="Unnamed2_Click" />
    
</asp:Content>

