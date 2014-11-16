<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="lpRename.aspx.cs" Inherits="pixAdmin.lpRename" %>

<%@ Register src="UC/Menu.ascx" tagname="Menu" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 80px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
         <uc1:Menu ID="Menu1" runat="server" />
    
         <h2>landing page batch rename</h2>
         <table style="width:100%;">
             <tr>
                 <td class="auto-style1">curent text</td>
                 <td>
                     <asp:TextBox ID="txtFromText" runat="server"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td class="auto-style1">new Text</td>
                 <td>
                     <asp:TextBox ID="txtToText" runat="server"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td class="auto-style1">password</td>
                 <td>
                     <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td class="auto-style1">&nbsp;</td>
                 <td>
                     <asp:Button ID="btnChange" runat="server" OnClick="btnChange_Click" Text="Change Text" />
&nbsp;<asp:Label ID="lblStatus" runat="server"></asp:Label>
                 </td>
             </tr>
         </table>
         <br />
        
    
       
    
    
    </form>
</body>
</html>
