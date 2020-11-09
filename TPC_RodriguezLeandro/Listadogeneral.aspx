<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Listadogeneral.aspx.cs" Inherits="TPC_RodriguezLeandro.Listadogeneral" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <a href="ListadodeAdm.aspx" id="btnListadoAdm" style="margin-top:10px; margin-left:10px; margin-bottom:10px" class="btn btn-primary">Listar administradores</a>
    <a href="ListadodeSupervisor.aspx" id="btnListadoSup" style="margin-top:10px; margin-left:10px; margin-bottom:10px" class="btn btn-primary">Listar supervisores</a>
    <a href="ListadodeOperador.aspx" id="btnListadoOpe" style="margin-top:10px; margin-left:10px; margin-bottom:10px" class="btn btn-primary">Listar operadores</a>
    
</asp:Content>
