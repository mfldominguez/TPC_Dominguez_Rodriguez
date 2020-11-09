<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Altasolicitud.aspx.cs" Inherits="TPC_RodriguezLeandro.Altasolicitud" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <div class="form-group">
            <label style="margin-left: 10px" for="exampleFormControlInput1">Titulo</label>
            <asp:TextBox ID="txtTitulo" runat="server" Width="370px" Style="margin-left: 10px" />
        </div>
        <div class="form-group">
            <label style="margin-left: 10px" for="exampleFormControlSelect2">Problema</label>
            <asp:DropDownList ID="ddlProblemas" CssClass="form-control" runat="server">
            </asp:DropDownList>
        </div>
        <label style="margin-left: 10px; margin-top: 10px; height: 24px; width: 111px;" for="exampleFormControlTextarea1">Descripcion</label>
        <div class="form-group">

            <asp:TextBox Style="margin-left: 10px; margin-top: 10px" ID="txtDescripcion" runat="server" TextMode="MultiLine" Width="551px" Height="146px" />
        </div>
        <asp:Button Style="margin-left: 10px; margin-top: 10px" ID="btnCrearSolicitud" Text="Crear" runat="server" OnClick="btnCrearSolicitud_Click" Width="55px" />
    
    <div class="modal fade" id="modalAltaSolicitud" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">
                                <asp:Label ID="lblModalTitle" runat="server" Text="">Alta solicitud</asp:Label>
                            </h4>
                        </div>
                        <div class="modal-body">
                            <asp:Label ID="lblModalBody" runat="server" Text="">Volver a la pagina principal</asp:Label>
                        </div>
                        <div class="modal-footer">
                            <a href="Inicio.aspx" class="btn btn-info">Inicio</a>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
