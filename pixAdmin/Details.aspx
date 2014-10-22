<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="pixAdmin.Details" %>

<%@ Register src="UC/Menu.ascx" tagname="Menu" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:Menu ID="Menu2" runat="server" />
        
    <h2>Detaile per provider</h2>
        <table>
       <tr>
           <td>Select Provider: <asp:DropDownList ID="drpProviders" runat="server" DataTextField="name" DataValueField="id" Height="25px">
               </asp:DropDownList>&nbsp;&nbsp;<asp:Button ID="btnShowRequests" runat="server" OnClick="Button1_Click" Text="Show Requests" />
&nbsp;<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Show Responses" />
&nbsp;&nbsp;

           </td>
           <td>
               
               
           </td>
       </tr>

            <tr>
                <td><b>&nbsp; Requests </b></td>
                <td><b>&nbsp;Responses</b></td>

            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server">
                    </asp:GridView>
                </td>
                <td>
                    <asp:GridView ID="GridView2" runat="server">
                    </asp:GridView>
                </td>

            </tr>
        </table>
    </div>
    </form>
</body>
</html>
