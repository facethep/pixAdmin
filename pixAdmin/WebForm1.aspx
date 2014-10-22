<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="pixAdmin.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <script language="javascript">

        function getPath()
        {

            return strDomain.value + '/r/' + strProvider.value + strPage.value + txt5.value;
        }

        function updateDiv(obj) {
            
           
            switch (obj.value) {

                case '1003':
                    txt5.value = "/?affid=34&tranid=134";
                    break;
                case '1000':
                    txt5.value = "/?tid=myretval&rid=macit";
                    break;

                default:
                    txt5.value = "/?tid=myretval&rid=macit";
                    break;



            }
         /*   if (obj.value == '1003') {
                txt5.value = "/?affid=34&tranid=134";
            }
            else {
                txt5.value = "/?tid=myretval&rid=macit";

            }*/
            fullurl.innerHTML = getPath();
        }


    </script>
</head>
<body>
    <form id="form1" runat="server">
  <br />
   <table border="1" cellspacing="0" cellpadding="4" >
        <tr><td colspan="3">Domain: 
            <select name="strDomain" id ="strDomain"  onchange="updateDiv();">
               
                <option value="http://localhost:49273/api">http://localhost:49273/api</option>
                <option value="http://www.myloopme.com/api">http://www.myloopme.com/api</option>
                </select> 

                &nbspProvider &nbsp:<asp:DropDownList ID="drpProviders" runat="server" DataTextField="name" DataValueField="id" Width="150px">
            </asp:DropDownList>
&nbsp;
                 &nbsp; Page &nbsp: 
            <asp:DropDownList ID="drpPages" runat="server" DataTextField="name" DataValueField="id" Width="150px">
            </asp:DropDownList>
&nbsp;&nbsp;Params: <input type="text" id ="txt5" name="txt5" value="/?affid=34&tranid=134" style="width: 159px"  onchange="updateDiv();" />
            <input type="button" value="go" onclick="window.open(getPath(), '', 'width=600, height=400');" /><br />
&nbsp;&nbsp;</td>

        </tr>    
            <tr>
                <td >Request to landing page</td>
                <td>Good: 
                    <input type="text" id ="txt1" name="txt1" value="/r/10031005/?affid=34&tranid=134" style="width: 359px"/>
                <input type="button" value="go" onclick="window.open(strDomain.value + txt1.value, '', 'width=600, height=400');" />
                </td>
               
            </tr>
            <tr>
                <td class="auto-style1">Response from DLM</td>
                <td>Good
                     <input type="text" id ="txt3" name="txt3" value="/s?uid=PUT_UID"  style="width: 359px"/>
                    <input type="button" value="go" onclick="window.open(strDomain.value+txt3.value, '', 'width=600, height=400');" /></td>
                
            </tr>
       <tr>
           <td> GUID Test</td>
           <td> <asp:TextBox ID="txtGUID" runat="server" Width="342px"></asp:TextBox>&nbsp;
               <asp:Button ID="btnIsGUID" runat="server" OnClick="btnIsGUID_Click" Text="Go" />
&nbsp;<asp:Label ID="lblIsGuid" runat="server" Text="Label"></asp:Label>
           </td>
       </tr>
        </table>
        <hr>

    
     
    </form>
</body>
</html>
