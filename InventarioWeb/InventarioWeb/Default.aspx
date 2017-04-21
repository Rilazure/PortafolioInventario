<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="InventarioWeb.Default" %>

<%@ Register Src="~/menu.ascx" TagPrefix="uc1" TagName="menu" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <form id="form1" runat="server">
<uc1:menu runat="server" ID="menu" />
        <div>
            <div>
                <asp:Button runat="server" text="SALIR" ID="BtnSalir" OnClick="BtnSalir_Click" />

            </div>


        </div>
    </form>
</body>
</html>
