<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="providerPagesLinks.aspx.cs" Inherits="pixAdmin.providerPagesLinks" %>

<%@ Register src="UC/Menu.ascx" tagname="Menu" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Menu ID="Menu1" runat="server" />
    <h2>Provider Pages Links</h2>
        &nbsp;
        <asp:Button ID="btnPC" runat="server" BackColor="#33CCFF" OnClick="btnPC_Click" Text="PC" />
&nbsp;
        <asp:Button ID="btnMac" runat="server" BackColor="#00CC00" OnClick="btnMac_Click" Text="MAC" />
        <br />

        <table>
            <tr>
                <td valign="top"><asp:ListBox ID="lstProviders" runat="server" Height="259px" AutoPostBack="true" ViewStateMode="Enabled" OnSelectedIndexChanged="lstProviders_SelectedIndexChanged"></asp:ListBox></td>
                <td valign="top">
                     <asp:GridView ID="grdLinks" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>

                </td>
            </tr>

        </table>
        
       
    </form>
</body>
</html>
