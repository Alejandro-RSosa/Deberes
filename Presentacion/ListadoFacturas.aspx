<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListadoFacturas.aspx.cs" Inherits="ListadoFacturas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <style type="text/css">
        .style1
        {
            color: #FF0000;
            font-weight: bold;
        }
        .style2
        {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div class="style2">
        <span class="style1">Listado Completo de Facturas<br />
        <br />
        </span><br />
    </div>
    <asp:GridView ID="gvListadoFac" runat="server" AutoGenerateColumns="False" 
        Height="197px"  
        style="text-align: center" Width="456px">
        <Columns>
            <asp:BoundField DataField="CodigoF" HeaderText="Codigo" />
            <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
            <asp:BoundField DataField="ArticuloF.Nombre" HeaderText="Articulo" />
        </Columns>
    </asp:GridView>
    <p>
        &nbsp;</p>
    <p style="text-align: center">
        <asp:Label ID="lblError" runat="server" ForeColor="Red" 
            style="text-align: center" Width="386px"></asp:Label>
    </p>
    <p style="text-align: center">
        <asp:LinkButton ID="lbtnVolver" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton>
    </p>
    </div>
    </form>
</body>
</html>
