<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearAlmacenista.aspx.cs" Inherits="InventarioWeb.CrearAlmacenista" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="EstiloWeb/bootstrap.js"></script>
    <link href="EstiloWeb/bootstrap.css" rel="stylesheet" />
    <link href="EstiloWeb/bootstrap.min.css" rel="stylesheet" />
    <script src="EstiloWeb/jquery-1.10.2.js"></script>
</head>
<body>
    <form id="form" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:Button CssClass="btn btn-primary btn-lg active" ID="BtnVerPnlRegistro" Text="Registrar" runat="server" OnClick="BtnVerPnlRegistro_Click" />


                <asp:Panel runat="server" Visible="false" ID="PnlRegistro">
                    <div  class="form-horizontal" runat="server">
                        <div class="form-group">

                            <asp:Label CssClass="col-sm-2 control-label" runat="server" ID="LblNombre">Nombre</asp:Label>
                            <div class="col-sm-10">
                                <asp:TextBox CssClass="form-control" Width="50%" runat="server" ID="TxtNombre"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label CssClass="col-sm-2 control-label" runat="server" ID="LblCedula">Cedula</asp:Label>
                            <div class="col-sm-10">
                                <asp:TextBox CssClass="form-control" Width="50%" runat="server" ID="TxtCedula"></asp:TextBox>
                                <asp:Button CssClass="btn btn-primary btn-lg active" ID="GuardarAlmacenista" Text="Guardar" runat="server" />
                            </div>
                        </div>
                      </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
