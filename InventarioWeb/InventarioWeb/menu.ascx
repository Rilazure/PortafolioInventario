<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="menu.ascx.cs" Inherits="InventarioWeb.menu" %>
<%--<asp:Menu ID="Menugest" runat="server" BackColor="#B5C7DE" 
    DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="Medium" 
    ForeColor="#284E98" Orientation="Horizontal" StaticSubMenuIndent="10px">
    <StaticSelectedStyle BackColor="#507CD1" />
    <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
    <DynamicHoverStyle BackColor="#284E98" ForeColor="White" />
    <DynamicMenuStyle BackColor="#B5C7DE" />
    <DynamicSelectedStyle BackColor="#507CD1" />
    <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
    <StaticHoverStyle BackColor="#284E98" ForeColor="White" />
</asp:Menu>--%>
   <%--<asp:Menu ID="menugest" runat="server" StaticPopOutImageUrl="~/Css2/Imagenes/flecha.png" DynamicPopOutImageUrl="~/Css2/Imagenes/flecha.png" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="Small" Orientation="Horizontal" StaticSubMenuIndent="10px" StaticMenuStyle-CssClass ="Menu" StaticMenuItemStyle-CssClass="Celdas" StaticHoverStyle-CssClass="Celdas-Hover" DynamicMenuItemStyle-CssClass="Celdas" DynamicMenuStyle-CssClass="Fondo_Trans_Hover" DynamicHoverStyle-CssClass="Celdas-Hover" DynamicSelectedStyle-CssClass="Fondo_Trans_Hover" SkipLinkText="">--%>
         <asp:Menu ID="Menu1" ForeColor="Black"   DisappearAfter="2000"  runat="server" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="Small" Orientation="Horizontal" StaticSubMenuIndent="10px" StaticMenuStyle-CssClass ="Menu" StaticMenuItemStyle-CssClass="Celdas" StaticHoverStyle-CssClass="Celdas-Hover" DynamicMenuItemStyle-CssClass="Celdas" DynamicMenuStyle-CssClass="Fondo_Trans_Hover" DynamicHoverStyle-CssClass="Celdas-Hover" DynamicSelectedStyle-CssClass="Fondo_Trans_Hover" SkipLinkText="">
           <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <DynamicMenuStyle BackColor="transparent"/>  

   <%-- <Items>
        <asp:MenuItem Text="Home" Value="Home" NavigateUrl="~/Login.aspx"></asp:MenuItem>
        <asp:MenuItem Text="Crear" Value="Crear" NavigateUrl="~/CrearAlmacenista.aspx" >
             <asp:MenuItem Text="Crear" Value="Crear" NavigateUrl="~/CrearAlmacenista.aspx" >
            </asp:MenuItem>

        </asp:MenuItem>
    </Items>--%>
</asp:Menu>
      <div class="Small-Title"><asp:Label runat="server" ID="Titulo_Formulario"></asp:Label></div>