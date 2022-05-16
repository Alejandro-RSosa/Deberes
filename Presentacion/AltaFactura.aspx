<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AltaFactura.aspx.cs" Inherits="AltaFactura" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .style1
        {
            text-align: center;
        }
        .style2
        {
            color: #FF0000;
            font-weight: bold;
        }
    </style>
</head>
<body bgcolor="#ffe1c1">
    <form id="form1" runat="server">
    <div class="style1">
        <span class="style2">Alta de Factura</span><br />
        <br />
        <br />
        Cantidad de articulos <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
        <br />
        Codigo de articulo
        <asp:TextBox ID="txtCodArt" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnAgregar" runat="server"  
            Text="Agregar" OnClick="btnAgregar_Click" />
        <br />
        <br />
        <asp:Label ID="lblError" runat="server" ForeColor="Red" Width="386px"></asp:Label>
        <br />
        <br />
        <asp:LinkButton ID="lbtnVolver" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton>
    </div>
    </form>
</body>
</html>
