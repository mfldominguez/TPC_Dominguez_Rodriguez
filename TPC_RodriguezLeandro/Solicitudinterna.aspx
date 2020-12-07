<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Solicitudinterna.aspx.cs" Inherits="TPC_RodriguezLeandro.Solicitudinterna" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <% bool Solucionado = false;
        int Contador = 0;
        int NumeroComentarioSolucion = 0;
        foreach (var item in lista)
        {
            Contador = Contador + 1;
            if (item.Solucion == true)
            {
                Solucionado = true;
                NumeroComentarioSolucion = Contador;
            }
            if (solicitud.Estado.ID == 4)
            {
                Solucionado = true;
            }
        }
    %>

    <div class="card; border-danger" style="width: 50%">
        <div class="card-body">
            <h5 class="card-title"><% = solicitud.ID %></h5>
            <p class="card-text">Titulo: <% = solicitud.Titulo %></p>
            <p class="card-text">Descripcion: </p>
            <p class="card-text"> <% = solicitud.Desc %></p>
            <p class="card-text">Operador: <% = solicitud.Usuario.Nombres + " " + solicitud.Usuario.Apellidos %></p>
            <p class="card-text">Ocurrido: <% = solicitud.FechaInicio.ToShortDateString() %></p>
        </div>
    </div>

    <% if (Solucionado == false)
        {%>
    <asp:Button Text="Cerrar Solicitud" ID="btnCerrarSolicitud" runat="server" OnClick="btnCerrarSolicitud_Click" />
    <%} %>
    <% if (Solucionado == true)
        {%>
    <p><%= solicitud.Estado.Nombre%></p>
    <%    } %>



    <% if (Solucionado == false)
        {%>
    <asp:Label Text="Comentario" ID="lblComentario" runat="server" />
    <div class="form-group">
        <asp:TextBox Style="margin-left: 10px; margin-top: 10px" ID="txtComentario" runat="server" TextMode="MultiLine" Width="551px" Height="146px" />
    </div>
    <asp:Button Style="margin-left: 10px; margin-top: 10px" ID="btnAltaComentario" Text="Comentar" runat="server" Width="214px" OnClick="btnAltaComentario_Click" />
    <% } %>

    <div class="card-columns" style="margin-left: 15px; margin-right: 5px;">



        <%int NumeroComentario = 1;
            Contador = 0;
            foreach (var item in lista)
            {
                Contador = Contador + 1;
        %>
        <div class="card" style="width: 300px; top: 0px; left: 0px; height: 227px; margin-top: 16px;">
            <div class="card-body">
                <h5 class="card-title"><% = NumeroComentario %></h5>
                <p class="card-text"><% = item.Usuario.Nombres + " " + item.Usuario.Apellidos%></p>
                <p class="card-text"><% = item.Comentario%> </p>
                <p class="card-text"><% = item.FechaComentario.ToShortDateString()%> </p>

                <% if (NumeroComentarioSolucion == Contador)
                    {%>
                <p>Comentario solucion</p>
                <%} %>

                <% if (Solucionado == false)
                    {%>
                <a href="Confirmacion.aspx?idc=<%=item.ID %>&ids=<%=item.IDSolicitud %> ">Solucionar</a>
                <% }%>
            </div>
        </div>

        <% NumeroComentario = NumeroComentario + 1;
            } %>
    </div>


</asp:Content>
