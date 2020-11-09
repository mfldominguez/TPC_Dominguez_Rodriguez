<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ListadodeAdm.aspx.cs" Inherits="TPC_RodriguezLeandro.ListadodeAdm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView CssClass="table" ID="dgvABM" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombres" />
            <asp:BoundField HeaderText="Apellidos" DataField="Apellidos" />
        </Columns>
    </asp:GridView>
    <h3>Filtrado de Administradores por usuario</h3>
    <asp:DropDownList ID="FiltrarAdm" Style="margin-left: 15px" runat="server">
        <asp:ListItem Text="" />
        <asp:ListItem Text="text2" />
    </asp:DropDownList>
</asp:Content>
