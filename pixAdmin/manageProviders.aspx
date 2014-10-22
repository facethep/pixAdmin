<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manageProviders.aspx.cs" Inherits="pixAdmin.manageProviders" %>

<%@ Register src="UC/Menu.ascx" tagname="Menu" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 177px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Menu ID="Menu2" runat="server" />
        <h2>Manage Providers</h2>
        <div>Select: 
            <asp:DropDownList ID="drpPCMAC" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true" ViewStateMode="Enabled">
                <asp:ListItem Selected="True">ALL</asp:ListItem>
                <asp:ListItem>MAC</asp:ListItem>
                <asp:ListItem>PC</asp:ListItem>
            </asp:DropDownList>
        </div>
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" onrowediting="GridView1_RowEditing"  OnRowUpdating="updateProvider" Height="200px" Width="70%" AutoGenerateColumns="False" OnRowCancelingEdit="GridView1_RowCancelingEdit"  >
            <AlternatingRowStyle BackColor="White" />
              <Columns>
                 <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" id="EditButton" text="Edit"  CommandName="Edit"   />
                    </ItemTemplate>
                     <EditItemTemplate>
                         <asp:LinkButton runat="server" id="LinkButton1"  text="update"  CommandName="Update"   
                            OnClientClick="if (!window.confirm('Are you sure you want to UPDATE this item?')) return false;" />
                        <asp:LinkButton runat="server" id="LinkButton2" text="Cancel"  CommandName="Cancel"   />
                     </EditItemTemplate>
                </asp:TemplateField>  
       
                 <asp:BoundField DataField="id"          HeaderText="ID" ReadOnly="true" />
                 <asp:BoundField DataField="name"        HeaderText="Name"  />
                   <asp:BoundField DataField="pcmac"        HeaderText="PC/MAC"  />
               
                <asp:TemplateField HeaderText="Pixel URL">
                       <ItemTemplate >
                          <asp:Label runat="server" Text='<%# Eval("pixel_url") %>' ></asp:Label>
                       </ItemTemplate>
                       <EditItemTemplate >
                           <asp:TextBox ID="TextBox1" width="500" runat="server" Text='<%# Eval("pixel_url")%>'  ></asp:TextBox>
                       </EditItemTemplate>
               </asp:TemplateField>


                 <asp:BoundField DataField="param1"      HeaderText="param1"  />
                  <asp:BoundField DataField="param2"     HeaderText="param2"   />
                  <asp:BoundField DataField="param3"     HeaderText="param3"  />
                  <asp:BoundField DataField="sendResponseEvery"  HeaderText="sendResponseEvery (X)"  ItemStyle-HorizontalAlign="Center" />
                  <asp:BoundField DataField="pixel_url_Text2Replace"  HeaderText="Text to Replace"    />
                
                 
        </Columns>
      
            
            <EditRowStyle BackColor="#FFCC99" BorderStyle="Dotted" />
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
        <br />
    <div>Partner page link:<b> http://www.myloopme.com/api/r/PROVIDERID1005/?tid=[RETURNVALUE] </b></div>
       <h2>Add new Provider</h2>

        <table style="width:100%;">
            <tr>
                <td class="auto-style1">Provide unique ID</td>
                <td>
                    <asp:TextBox ID="txtProviderID" runat="server" Width="50px"></asp:TextBox>&nbsp;&nbsp;Provider name: <asp:TextBox ID="txtProviderName" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;PC/MAC: <asp:TextBox ID="txtpcmac" runat="server"></asp:TextBox>
                </td>
            </tr>
           
            <tr>
                <td class="auto-style1">pixel url</td>
                <td>
                    <asp:TextBox ID="txtProviderPixelURL" runat="server" Width="407px"></asp:TextBox>
                &nbsp;The paramer here should be the same as the &#39;pixel url 2 replace&#39;</td>
            </tr>
            <tr>
                <td class="auto-style1"></td>
                <td>
                    param1: <asp:TextBox ID="txtProviderParam1" runat="server" Width="41px"></asp:TextBox> &nbsp; param2:  <asp:TextBox ID="txtProviderParam2" runat="server" Width="41px"></asp:TextBox> &nbsp;&nbsp;param3: <asp:TextBox ID="txtProviderParam3" runat="server" Width="41px"></asp:TextBox>
                </td>
            </tr>
           
            <tr>
                <td class="auto-style1">send response every</td>
                <td>
                    <asp:TextBox ID="txtProviderSendResponseEvery" runat="server" Width="45px">1</asp:TextBox>
                &nbsp;default is 1</td>
            </tr>
            <tr>
                <td class="auto-style1">pixel url text 2 replace</td>
                <td>
                    <asp:TextBox ID="txtProviderURLtext2Replace" runat="server" Height="22px" Width="139px"></asp:TextBox>
                &nbsp;the value here should be the same as in the pixel url, we suuprt several parameters with &quot;,&quot;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>
&nbsp;<asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Add new provider" />
                &nbsp;<asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Load new provider to memory" />
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </td>
            </tr>
        </table>

    </form>
</body>
</html>
