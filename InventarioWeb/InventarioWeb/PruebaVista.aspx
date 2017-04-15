<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PruebaVista.aspx.cs" Inherits="InventarioWeb.PruebaVista" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="Ddrl_Dato1" runat="server"></asp:DropDownList>
             <asp:DropDownList ID="Drl_Dato2" runat="server"></asp:DropDownList>
            <asp:GridView ID="Gv_Datos" runat="server"></asp:GridView>

            
        </div>
    </form>
</body>
</html>
