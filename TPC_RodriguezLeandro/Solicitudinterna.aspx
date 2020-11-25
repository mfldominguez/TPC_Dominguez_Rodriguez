<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Solicitudinterna.aspx.cs" Inherits="TPC_RodriguezLeandro.Solicitudinterna" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card" style="width: 50%">
        <div class="card-body">
            <h5 class="card-title"><% = solicitud.ID %></h5>
            <p class="card-text"><% = solicitud.Titulo %></p>
            <p class="card-text"><% = solicitud.Desc %></p>

            <p class="card-text"><% = solicitud.Usuario.Nombres + " " + solicitud.Usuario.Apellidos %></p>
            <p class="card-text"><% = solicitud.FechaInicio.ToShortDateString() %></p>
        </div>
    </div>
                
    <asp:Label Text="Comentario" ID="lblComentario" runat="server" />
     <div class="form-group">

        <asp:TextBox Style="margin-left: 10px; margin-top: 10px" ID="txtComentario" runat="server" TextMode="MultiLine" Width="551px" Height="146px" />
      </div>
        <asp:Button Style="margin-left: 10px; margin-top: 10px" ID="btnAltaComentario" Text="Comentar" runat="server" Width="214px" OnClick="btnAltaComentario_Click" />
        <asp:Button Style="margin-left: 10px; margin-top: 10px" ID="Button1" Text="Solucionar" runat="server" Width="214px" OnClick="btnSolucionar_Click" />
        
            
    <div class="card-columns" style="margin-left: 15px; margin-right: 5px;">

        <%int NumeroComentario = 1;       
          foreach (var item in lista)
            {
                %>
        <div class="card" style="width: 18rem;">
            <div class="card-body">
                <h5 class="card-title"><% = NumeroComentario %></h5>
                <p class="card-text"><% = item.Usuario.Nombres + " " + item.Usuario.Apellidos%></p>
                <p class="card-text"><% = item.Comentario%> </p>
                <p class="card-text"><% = item.FechaComentario%> </p>
                <asp:Button Style="margin-left: 10px; margin-top: 10px" ID="btnSolucionar" Text="Solucionar" runat="server" Width="214px" OnClick="btnSolucionar_Click" />
                
            </div>
        </div>
        <% NumeroComentario = NumeroComentario + 1; } %>
    </div>

    
</asp:Content>
