<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucdate.ascx.cs" Inherits="pixAdmin.UC.ucdate" %>

 <link rel="stylesheet" href="//code.jquery.com/ui/1.11.1/themes/smoothness/jquery-ui.css">
  <script src="//code.jquery.com/jquery-1.10.2.js"></script>
  <script src="//code.jquery.com/ui/1.11.1/jquery-ui.js"></script>

<script language="javascript">
    $(function () {
        $("[id$=txtDate]").datepicker({ showOn: 'button' });
    });

</script>
<asp:TextBox ID="txtDate" runat="server"></asp:TextBox>

