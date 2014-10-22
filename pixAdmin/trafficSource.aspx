<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="trafficSource.aspx.cs" Inherits="pixAdmin.trafficSource" %>

<%@ Register src="UC/Menu.ascx" tagname="Menu" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <uc1:Menu ID="Menu1" runat="server" />
 
    <h2>Traffic Sources</h2>
       

         <table style="width:43%;">
            

             <tr>
                 <td>Show Traffic in the past Days</td>
                 <td>
                     <asp:DropDownList ID="drpDays" runat="server" style="margin-left: 0px" Height="17px" Width="81px">
                         <asp:ListItem Value="0.125">3 Hours</asp:ListItem>
                         <asp:ListItem Value="0.25">6 Hours</asp:ListItem>
                         <asp:ListItem Value="0.5">12 Hours</asp:ListItem>
                         <asp:ListItem Value="1">1 Day</asp:ListItem>
                         <asp:ListItem Value="2">2 Days</asp:ListItem>
                         <asp:ListItem Value="3">3 Days</asp:ListItem>
                     </asp:DropDownList>
                 </td>
                 <td>
                     <asp:Button ID="btnPC" runat="server" Text="PC" BackColor="#33CCFF" OnClick="btnPC_Click" /> &nbsp;&nbsp;
                     <asp:Button ID="btnMac" runat="server" BackColor="#00CC00" Text="MAC" OnClick="btnMac_Click" />&nbsp;&nbsp;
                     <asp:Button ID="btnAll" runat="server" BackColor="#FF9933" Text="ALL" OnClick="btnAll_Click" />
                 </td>
             </tr>
             <tr>
                 <td>Second Time Frame</td>
                 <td>
                     <asp:DropDownList ID="drpDays2" runat="server">
                          <asp:ListItem Value="-1">-None-</asp:ListItem>
                          <asp:ListItem Value="0.125">3 Hours</asp:ListItem>
                         <asp:ListItem Value="0.25">6 Hours</asp:ListItem>
                         <asp:ListItem Value="0.5">12 Hours</asp:ListItem>
                         <asp:ListItem Value="1">1 Day</asp:ListItem>
                         <asp:ListItem Value="2">2 Days</asp:ListItem>
                         <asp:ListItem Value="3">3 Days</asp:ListItem>
                     </asp:DropDownList>
                 </td>
                 <td>&nbsp;</td>
             </tr>
             <tr>
                 <td>&nbsp;</td>
                 <td>&nbsp;</td>
                 <td>&nbsp;</td>
             </tr>
         </table>
        <table>
             <tr>
                 <td><b><asp:Label ID="lblTime1" runat="server"></asp:Label></b>
                 </td>
                 <td><b><asp:Label ID="lblTime2" runat="server"></asp:Label></b>
                 </td>
             </tr>
            <tr>
                <td valign="top">
                     <asp:GridView ID="grdTraffic" runat="server" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                         <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                         <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                         <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                         <RowStyle BackColor="White" ForeColor="#330099" />
                         <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                         <SortedAscendingCellStyle BackColor="#FEFCEB" />
                         <SortedAscendingHeaderStyle BackColor="#AF0101" />
                         <SortedDescendingCellStyle BackColor="#F6F0C0" />
                         <SortedDescendingHeaderStyle BackColor="#7E0000" />
                     </asp:GridView>

                </td>
                <td  valign="top">
                     <asp:GridView ID="grdTraffic2" runat="server" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                         <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                         <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                         <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                         <RowStyle BackColor="White" ForeColor="#330099" />
                         <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                         <SortedAscendingCellStyle BackColor="#FEFCEB" />
                         <SortedAscendingHeaderStyle BackColor="#AF0101" />
                         <SortedDescendingCellStyle BackColor="#F6F0C0" />
                         <SortedDescendingHeaderStyle BackColor="#7E0000" />
                     </asp:GridView>

                </td>

            </tr>

        </table>
        
        
    </form>
</body>
</html>
