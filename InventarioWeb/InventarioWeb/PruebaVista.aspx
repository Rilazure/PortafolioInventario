<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PruebaVista.aspx.cs" Inherits="InventarioWeb.PruebaVista" %>

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
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="Ddrl_Dato1" runat="server"></asp:DropDownList>
            <asp:DropDownList ID="Drl_Dato2" runat="server"></asp:DropDownList>
            <asp:GridView ID="Gv_Datos" runat="server"></asp:GridView>
            <asp:LinkButton CssClass="btn-danger" runat="server">
                <span class="glyphicon-arrow-down"></span>Prueba
            </asp:LinkButton>
        </div>
        <div class="text-center Subtitulos">Filtros de Consulta</div>
        <div class="Cell-Form">
            <div class="input-group">
                <div class="input-group-addon">Código</div>
                <asp:TextBox ID="TxtCodigoFiltro" TabIndex="1" CssClass="form-control" runat="server" MaxLength="6"></asp:TextBox>
            </div>
              <div class="input-group">
                                        <div class="input-group-addon">Fecha Registro</div>
                                        <asp:TextBox ID="TxtFechaInicio" TabIndex="3" MaxLength="10" Placeholder="DD/MM/YYYY" CssClass="form-control Fecha" runat="server"></asp:TextBox>
                                        <div class="input-group-addon">-</div>
                                        <asp:TextBox ID="TxtFechaFiltroFinal" TabIndex="4" MaxLength="10" Placeholder="DD/MM/YYYY" CssClass="form-control Fecha" runat="server"></asp:TextBox>
                                    </div>

                                    <asp:LinkButton ID="Btn_Filtrar" TabIndex="5" Font-Strikeout="false" CssClass="btn btn-primary" runat="server">
                                            <span class="glyphicon glyphicon-search"></span> Filtrar
                                        </asp:LinkButton>
                                </div>
         <div class="Space-Form"></div>
                                <div class="Cell-Form">
                                    <div class="input-group">
                                        <div class="input-group-addon">Prioridad</div>
                                        <asp:DropDownList ID="Drl_PrioridadGestion" TabIndex="2" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>                                 
                                </div>
    </form>
</body>
</html>
