<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu.ascx.cs" Inherits="pixAdmin.UC.WebUserControl1" %>
        <asp:Menu ID="Menu1" runat="server" BackColor="#E3EAEB" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#666666" StaticSubMenuIndent="10px" Orientation="Horizontal" >
            <DynamicHoverStyle BackColor="#666666" ForeColor="White" />
            <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <DynamicMenuStyle BackColor="#E3EAEB" />
            <DynamicSelectedStyle BackColor="#1C5E55" />
            <Items>
                <asp:MenuItem NavigateUrl="~/Main.aspx" Text="Main" Value="Main"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/Stats.aspx" Text="Statistics" Value="Statistics"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/details.aspx" Text="Details Per Provider" Value="Details Per Provider"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/manageProviders.aspx" Text="Providers" Value="Providers"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/managePages.aspx" Text="Pages" Value="Pages">
                    <asp:MenuItem NavigateUrl="~/lpRename.aspx" Text="page link change" Value="page link change"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/PagesByGEO.aspx" Text="PagesByGeo" Value="PagesByGeo"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/ProviderRevenu.aspx" Text="ProviderRevenu" Value="ProviderRevenu"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/pageRedirection.aspx" Text="pageRedirection" Value="pageRedirection"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/X-ByPageAndGeo.aspx" Text="X-ByPageAndGeo" Value="X-ByPageAndGeo"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/testSystem.aspx" Text="System Status" Value="System Status"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/logic.aspx" Text="Logic" Value="logic"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/providerPagesLinks.aspx" Text="Provider Links" Value="Provider Links"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/trafficSource.aspx" Text="Traffic Source" Value="Traffic Source"></asp:MenuItem>
            </Items>
            <StaticHoverStyle BackColor="#666666" ForeColor="White" />
            <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <StaticSelectedStyle BackColor="#1C5E55" />
        </asp:Menu>
        
