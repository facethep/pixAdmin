<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="pixAdmin.Main" %>

<%@ Register src="UC/Menu.ascx" tagname="Menu" tagprefix="uc1" %>

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
            $("[id$=txtFromDate]").datepicker({ showOn: 'button'});
        });

        $(function () {
            $("[id$=txtToDate]").datepicker({ showOn: 'button' });
        });

        function copyDate() {
            document.getElementById("txtToDate").value = document.getElementById("txtFromDate").value;
        }

        function checkProvider() {

            var retVal = true;
            if (drpProviders.value == -1) {
                alert("Please select provider!");
                retVal =  false;
            }
            return retVal;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Menu ID="Menu2" runat="server" />
        <br />
    Sum of Requests and Responses<br />

         From date (mm-dd-yyyy):
        <asp:TextBox ID="txtFromDate" runat="server" Width="74px"></asp:TextBox>
       

        &nbsp;<input id="Button4" type="button" value="&gt;" onclick="copyDate();" />&nbsp;To date:&nbsp;
        <asp:TextBox ID="txtToDate" runat="server" Width="74px"></asp:TextBox>
&nbsp;
         Provider: 
        <asp:DropDownList ID="drpProviders" runat="server" DataTextField="name" DataValueField="id" />
&nbsp;&nbsp; Page Name:          
          
     
         <asp:DropDownList ID="drpPage" runat="server" DataTextField="name" DataValueField="id">
        </asp:DropDownList>
          
     
         <br /> <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Show Sum per provider"  />
        &nbsp;&nbsp;<asp:Button ID="btnInstalls" runat="server" OnClick="btnInstalls_Click" Text="Show installs (Only)" />
&nbsp;<asp:Button ID="Button2" runat="server" Text="Show Sum provider Country" OnClick="Button2_Click" />
          &nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click"  Text="Installs per GEO (byDay)" />
        <asp:Button ID="btnInstallByGEO_SUM" runat="server" OnClick="btnInstallByGEO_SUM_Click" style="height: 26px" Text=" Installs per GEO (sum)" />
        <asp:Button ID="btnpageInstalls" runat="server" OnClick="btnpageInstalls_Click" Text="Show page installs" />
        <br />
        
    <br />

    <table style="width:90%;">
        <tr>
            <td><strong>Request to landing page</strong></td>
            <td><strong>Responses (Pixel notification)</strong></td>
           <td>Installs per Page</td>
           <td><strong>Installs Per GEO</strong></td>
        </tr>
        <tr>
            <td valign="top">
                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" >
                    <AlternatingRowStyle BackColor="#F7F7F7" />
                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <SortedAscendingCellStyle BackColor="#F4F4FD" />
                    <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                    <SortedDescendingCellStyle BackColor="#D8D8F0" />
                    <SortedDescendingHeaderStyle BackColor="#3E3277" />
                </asp:GridView>
            </td>
            <td  valign="top">
                <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
                    <AlternatingRowStyle BackColor="#F7F7F7" />
                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <SortedAscendingCellStyle BackColor="#F4F4FD" />
                    <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                    <SortedDescendingCellStyle BackColor="#D8D8F0" />
                    <SortedDescendingHeaderStyle BackColor="#3E3277" />
                </asp:GridView>
            </td>
            <td  valign="top">
                <asp:GridView ID="grdpageInstalls" runat="server">
                </asp:GridView>
            </td>
            <td  valign="top">
 <asp:GridView ID="GridView4" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
                <AlternatingRowStyle BackColor="White" />
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>
            </td>
        </tr>
<tr>
    <td>&nbsp;</td>
    <td>&nbsp;</td>

</tr>       
        <td>
            <asp:GridView ID="GridView3" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" ShowFooter="True" OnRowDataBound="GridView3_RowDataBound">
                <AlternatingRowStyle BackColor="White" />
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>
        </td>
        <td>
           
        </td>
    </table>
    </form>
</body>
</html>
