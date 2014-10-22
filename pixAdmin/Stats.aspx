<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Stats.aspx.cs" Inherits="pixAdmin.Stats" %>

<%@ Register src="UC/Menu.ascx" tagname="Menu" tagprefix="uc1" %>

<%@ Register src="UC/ucProviders.ascx" tagname="ucProviders" tagprefix="uc2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

     <link rel="stylesheet" href="//code.jquery.com/ui/1.11.1/themes/smoothness/jquery-ui.css">
  <script src="//code.jquery.com/jquery-1.10.2.js"></script>
  <script src="//code.jquery.com/ui/1.11.1/jquery-ui.js"></script>
  <link rel="stylesheet" href="/resources/demos/style.css">

      <script language="javascript">
        $(function () {
            $("[id$=txtStartDate]").datepicker();
        });

        $(function () {
            $("[id$=txtEndDate]").datepicker();
        });
          </script>
          
    <style type="text/css">
        .auto-style1 {
            width: 130px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <uc1:Menu ID="Menu2" runat="server" />
        <table style="width:100%;">
            <tr>
                <td class="auto-style1" colspan="3">
                   
                  
                </td>
               
            </tr>
            <tr>
                <td class="auto-style1">ProviderID</td>
                <td>
                    <asp:DropDownList ID="drpProviders" runat="server" DataTextField="name" DataValueField="id">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Date</td>
                <td>&nbsp;&nbsp;&nbsp;
                    <asp:CheckBox ID="chkDate" runat="server" />
&nbsp;&nbsp;&nbsp; Start:
                    <asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox>
&nbsp;
                    <input id="Button1" type="button" value="&gt;" />&nbsp;&nbsp;&nbsp; End:
                    <asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>
                &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Daily</td>
                <td>
                    <asp:CheckBox ID="chkDaily" runat="server" OnCheckedChanged="chkDaily_CheckedChanged" Text="Daily report" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="conversion per provider" Height="26px" />
&nbsp;<asp:Button ID="btnStatsPerCountryCode" runat="server" OnClick="btnStatsPerCountryCode_Click" Text="conversion per CoutryCode" />
                &nbsp;<asp:Button ID="btnResponseError" runat="server" Text="Response Error" OnClick="btnResponseError_Click" style="margin-bottom: 0px" />
                &nbsp;<asp:Button ID="btnByTier" runat="server" OnClick="btnByTier_Click" Text="Stats by tier" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
        &nbsp;<table style="width:90%;">
             <tr>
                <td>
                    <asp:Label ID="lblTable1" runat="server"></asp:Label>
                 </td>
                <td>
                    <asp:Label ID="lblTable2" runat="server"></asp:Label>
                 </td>
                <td>
                    <asp:Label ID="lblTable3" runat="server"></asp:Label>
                 </td>
            </tr>
            <tr>
                <td  valign="top" style="width:30%;">
        <asp:GridView ID="grdTotalConv" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" ShowFooter="True" OnRowDataBound="grdTotalConv_RowDataBound">
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
                <td  valign="top" style="width:30%;">
                    <asp:GridView ID="grdTotalCountry" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" ShowFooter="True" OnRowDataBound="grdTotalCountry_RowDataBound" >
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
                <td  valign="top" style="width:40%;">
                    <asp:GridView ID="grdTiers" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" ShowFooter="True" OnRowDataBound="grdTiers_RowDataBound">
                        <AlternatingRowStyle BackColor="PaleGoldenrod" />
                        <FooterStyle BackColor="Tan" />
                        <HeaderStyle BackColor="Tan" Font-Bold="True" />
                        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                        <SortedAscendingCellStyle BackColor="#FAFAE7" />
                        <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                        <SortedDescendingCellStyle BackColor="#E1DB9C" />
                        <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                    </asp:GridView>
                </td>
            </tr>
           
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
           
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
           
            <tr>
                <td valign="top">
                    <div>Total installs</div>
                     <asp:GridView ID="grdTotalInstalls" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" ShowFooter="True" onrowdatabound="grdTotalInstalls_RowDataBound">
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
                <td valign="top">
                    <div>Response Error</div>
                    <asp:GridView ID="grdErrorResponses" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" ShowFooter="True" onrowdatabound="grdErrorResponses_RowDataBound" >
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                   
                </td>
              
                <td valign="top">
                    &nbsp;</td>
              
            </tr>
        </table>
    </form>
</body>
</html>
