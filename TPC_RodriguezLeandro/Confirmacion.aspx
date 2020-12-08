<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Confirmacion.aspx.cs" Inherits="TPC_RodriguezLeandro.Confirmacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="modal fade" id="modal8" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">
                            <asp:Label ID="lblModalTitle" runat="server" Text="">Confirmacion</asp:Label>
                        </h4>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="lblModalBody" runat="server" Text="">Has solucionado la solicitud.</asp:Label>
                    </div>
                    <div class="modal-footer">
                        <a href="Inicio.aspx" class="btn btn-info">Inicio</a>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
