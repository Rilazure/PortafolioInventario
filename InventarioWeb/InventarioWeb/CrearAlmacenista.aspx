<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearAlmacenista.aspx.cs" Inherits="InventarioWeb.CrearAlmacenista" %>

<%@ Register Src="~/menu.ascx" TagPrefix="Control" TagName="menu" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="EstiloWeb/bootstrap.js"></script>
    <link href="EstiloWeb/bootstrap.css" rel="stylesheet" />
    <link href="EstiloWeb/bootstrap.min.css" rel="stylesheet" />
    <script src="EstiloWeb/jquery-1.10.2.js"></script>
    <link href="Style/CssInv.css" rel="stylesheet" />
</head>
<body>   
    <form id="form" runat="server">                     
        <%--  <asp:Menu ID="Menu1" ForeColor="Black" StaticDisplayLevels="1" DisappearAfter="2000"  runat="server">--%>             
   <%-- <Items>
        <asp:MenuItem Text="Home" Value="Home" NavigateUrl="~/Login.aspx"></asp:MenuItem>
        <asp:MenuItem Text="Crear" Value="Crear" NavigateUrl="~/CrearAlmacenista.aspx" >
             <asp:MenuItem Text="Crear" Value="Crear" NavigateUrl="~/CrearAlmacenista.aspx" >
            </asp:MenuItem>

        </asp:MenuItem>
    </Items>--%>
<%--</asp:Menu>--%>
        <asp:ScriptManager runat="server"></asp:ScriptManager>
            <Control:menu runat="server" id="menu" />
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:Label ID="LblDato" runat="server"></asp:Label>
                <asp:Button ID="BtnLista" runat="server" text="Listar" OnClick="BtnLista_Click" />    
                <asp:Button CssClass="btn btn-primary btn-lg active" ID="Registro" Text="Registrar Nuevo Almacenista" runat="server" OnClick="Registro_Click"  />                
                 <asp:Button CssClass="btn btn-primary btn-lg active" ID="Consulta" Text="Consultar Almacenista Creado" runat="server" OnClick="Consulta_Click" />               
            <asp:Label ID="Label1" runat="server" ></asp:Label>
                <asp:Panel runat="server"  ID="PnlRegistro">
                    <div class="form-horizontal" runat="server">
                        <div class="form-group">
                            <asp:Label CssClass="col-sm-2 control-label" runat="server" ID="LblNombre">Nombre</asp:Label>
                            <div class="col-sm-10">
                                <asp:TextBox CssClass="form-control" ValidationGroup="Dato" Width="50%" runat="server" ID="TxtNombre"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label CssClass="col-sm-2 control-label" runat="server" ID="LblCedula">Cedula</asp:Label>
                                <%--<asp:RangeValidator runat="server" Font-Size="10px"  Display="Dynamic" SetFocusOnError="true" ControlToValidate="TxtNombre"  ValidationExpression="((MT)?(MT)?)*([0-9]{4,4})*" >No</asp:RangeValidator>--%>
                        <asp:RegularExpressionValidator Font-Size="10px" runat="server" ControlToValidate="TxtNombre" Display="Dynamic" SetFocusOnError="True" ValidationExpression="((MT)?(MT)?)*([0-9]{4,4})*">Codigo mal escrito, Ejemplo(MT0000)</asp:RegularExpressionValidator> 
                            <div class="col-sm-10">
                            
                                <asp:TextBox CssClass="form-control" Width="50%" runat="server"   ValidationGroup="Dato" ID="TxtCedula"></asp:TextBox>
                                <asp:Button CssClass="btn btn-primary btn-lg active"  ValidationGroup="Dato" ID="GuardarAlmacenista" Text="Guardar" runat="server" OnClick="GuardarAlmacenista_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-8">
                    <asp:Label runat="server" CssClass="alert alert-danger" ID="lblEx"></asp:Label>
                        </div>
                </asp:Panel>
                    
                <asp:Panel ID="PnlConsultarAlmacenista" runat="server">                  
                    <div class="form-horizontal" runat="server">
                        <div class="input-group col-md-4">
                           <div class="input-group-addon">Número de Documento</div>                          
                            <asp:TextBox ID="TxtCedulaConsulta" Width="50%" runat="server" CssClass="form-control" ></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <asp:Button Id="BtnConsultarAlmacenista" CssClass="btn btn-primary btn-lg active" Text="Consultar"  runat="server" OnClick="BtnConsultarAlmacenista_Click" />
                        </div>
                    </div>
                      </section>
                    <asp:GridView ID="Gv_DatosAlmacenista" runat="server"></asp:GridView>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
