<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testSystem.aspx.cs" Inherits="pixAdmin.testSystem" %>

<%@ Register src="UC/Menu.ascx" tagname="Menu" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript">

        function loadITestframe() {
            var oIframe = document.getElementById("testIframe");

            oIframe.src = "http://www.myloopme.com/api/m/1/";
           // oIframe.src = "http://localhost:49273/api/m/1/";

        }

        function loadAppShowIframe() {
            var oIframe = document.getElementById("appVarIframe");

            oIframe.src = "http://myloopme.com/sys/cacheObjets.aspx";
            // oIframe.src = "http://localhost:49273/api/m/1/";

        }

        function loadAppDelIframe() {
            var oIframe = document.getElementById("testIframe");
            oIframe.src = "http://myloopme.com/api/cache/1/33197000/";
        }

        function loadAppPopIframe() {
            var oIframe = document.getElementById("testIframe");
            oIframe.src = "http://myloopme.com/api/cache/1/791975/";
        }
   
    </script>
    <style type="text/css">
        #testIframe {
            margin-top: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <uc1:Menu ID="Menu1" runat="server" />

    
   
            <h2>The system will do the following tests:</h2><br />
            <b>1. </b> All_OK_Relax,<br />
            <b>2. </b>Test database select : Database_Select_Error <br />
            <b>3. </b>Test database insert :  Database_Insert_Error<br />
            <b>4. </b>Test settings load : Settings_Error <br />
            <b>5. </b>Test HTTP page get: Http_Get_Error <br />

        </div>
        <input id="Button1" type="button" value="Test System" onclick="loadITestframe();" />&nbsp; &nbsp;
        <input id="Button1" type="button" value="Show Cache" onclick="loadAppShowIframe();" />&nbsp; &nbsp;
        <input id="Button1" type="button" value="Delete Cache" onclick="loadAppDelIframe();" />&nbsp; &nbsp;
        <input id="Button1" type="button" value="Populate Cache" onclick="loadAppPopIframe();" />&nbsp; &nbsp;


         &nbsp; &nbsp;
        

    </form>
    <table style="width:70%;">
        <tr>
            <td>System Status</td>
            <td>Application variables</td>
        </tr>
        <tr>
            <td> <iframe id="testIframe" src="" width="200px" height="100px"></iframe></td>
            <td> </td>
        </tr>
        
    </table>
    <br />

   <h2>All Cache Items</h2>
    <iframe id="appVarIframe" src="" width="100%" height="800px"></iframe>

   
</body>
</html>
