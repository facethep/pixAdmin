<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="managePages.aspx.cs" Inherits="pixAdmin.managePages" %>

<%@ Register src="UC/Menu.ascx" tagname="Menu" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Menu ID="Menu1" runat="server" />
    
         <h2>Manage pages</h2>
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"  Height="200px" Width="70%" 
            AutoGenerateColumns="False" 
            OnRowCancelingEdit="GridView1_RowCancelingEdit" 
            OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" 
            onrowediting="GridView1_RowEditing"  
            OnRowUpdating="updatepage">

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
                   <asp:BoundField DataField="advertizer"        HeaderText="advertizer"  />
                   <asp:BoundField DataField="pcmac"        HeaderText="pc/mac"  />
                  <asp:TemplateField HeaderText="URL">
                       <ItemTemplate >
                          <asp:Label runat="server" Text='<%# Eval("url") %>' ></asp:Label>
                       </ItemTemplate>
                       <EditItemTemplate >
                           <asp:TextBox ID="TextBox1" width="500" runat="server" Text='<%# Eval("url")%>'  ></asp:TextBox>
                       </EditItemTemplate>
               </asp:TemplateField>


                  
                
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
         <h2>Add new Page</h2>

        <table style="width:100%;">
            <tr>
                <td class="auto-style1">Page ID</td>
                <td>
                    <asp:TextBox ID="txtID" runat="server" Width="56px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Page Name</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" Width="129px"></asp:TextBox>
                </td>
            </tr>

             <tr>
                <td class="auto-style1">Advertiser</td>
                <td>
                    <asp:TextBox ID="txtAdv" runat="server" Width="132px"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td class="auto-style1">PC/MAC</td>
                <td>
                    <asp:TextBox ID="txtPCMAC" runat="server" Width="132px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Page URL</td>
                <td>
                    <asp:TextBox ID="txtURL" runat="server" Width="448px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:Button ID="btnAddPage" runat="server" OnClick="btnAddPage_Click" Text="Add Page" />
                </td>
            </tr>
        </table>

    </form>
</body>
</html>
