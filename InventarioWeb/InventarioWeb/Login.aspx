<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="InventarioWeb.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:Label runat="server">Nombre</asp:Label>
                <asp:TextBox id="TxtNombre" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label runat="server">Password</asp:Label>
                <asp:TextBox id="TxtPassword" runat="server"></asp:TextBox>
            </div>
            <asp:Button Text="Guardar"  id="BtnGuardar" runat="server" OnClick="BtnGuardar_Click"/>
            <asp:Button ID="Button1" runat="server" Text="Button" />
            <asp:Label ID="Mensajes" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
