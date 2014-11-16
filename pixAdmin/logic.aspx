<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="logic.aspx.cs" Inherits="pixAdmin.logic" %>

<%@ Register src="UC/Menu.ascx" tagname="Menu" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:Menu ID="Menu1" runat="server" />
    
   <h2>The Logic page</h2>
    <table border="1">
        <tr>
            <td>Providers</td>
            <td>Pages</td>
            <td>GEO</td>
        </tr>
        <tr>
            <td><asp:ListBox ID="lstProviders" runat="server" Height="205px"></asp:ListBox></td>
            <td><asp:ListBox ID="lstPages" runat="server" Height="205px" style="margin-top: 0px" OnSelectedIndexChanged="lstPages_SelectedIndexChanged" AutoPostBack="true" ViewStateMode="Enabled"></asp:ListBox></td>
            <td><asp:ListBox ID="lstCountryCode" runat="server" Height="205px" width="100px" style="margin-top: 0px" AutoPostBack="true" ViewStateMode="Enabled" OnSelectedIndexChanged="lstCountryCode_SelectedIndexChanged">

<asp:ListItem>BR</asp:ListItem>
<asp:ListItem>CA</asp:ListItem>
<asp:ListItem>DE</asp:ListItem>
<asp:ListItem>ES</asp:ListItem>
<asp:ListItem>FR</asp:ListItem>
<asp:ListItem>GB</asp:ListItem>
<asp:ListItem>IT</asp:ListItem>
<asp:ListItem>UK</asp:ListItem>
<asp:ListItem>US</asp:ListItem>
        </asp:ListBox></td>
        </tr>
        
    </table>
<br />

<table width="600px" border="1">
    <tr >
        <td width="150px">Real Page</td>
        <td width="350px">
            <asp:Label ID="lblRealPage" runat="server" Text="Label"></asp:Label>
        </td>
        <td width="100px">
            <asp:HyperLink ID="HyperLink1" runat="server" onclick="javascript:window.open(this.href, '','toolbar=no,resizable=yes,scrollbars=yes,height=600,width=600');
      return false;">Go</asp:HyperLink></td>
       
    </tr>
    <tr >
        <td width="150px">Page by Geo</td>
        <td width="350px">
            <asp:Label ID="lblPageByGeo" runat="server" Text="lblPageByGeo"></asp:Label>
        </td>
        <td width="100px">
            <asp:HyperLink ID="HyperLink2" runat="server" onclick="javascript:window.open(this.href, '','toolbar=no,resizable=yes,scrollbars=yes,height=600,width=600');
      return false;">Go</asp:HyperLink></td>
       
    </tr>
     <tr>
        <td>My X is </td>
        <td>
            <asp:Label ID="lblX" runat="server" Text="Label"></asp:Label>
         </td>
         <td>&nbsp;</td>
        
    </tr>
    <tr>
         <td>My GEO X</td>
        <td>
            <asp:Label ID="lblGEO_X" runat="server" Text="Label"></asp:Label>
         </td>
        <td>&nbsp;</td>
    </tr>


</table>

   </form>

</body>
</html>
