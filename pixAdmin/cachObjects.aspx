<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cachObjects.aspx.cs" Inherits="pixAdmin.cachObjects" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1>All object in Cache</h1>
        </div>
        <br />

      
        <asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" Text="Show cache" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Delete Cache" />

      
    </form>
</body>
</html>