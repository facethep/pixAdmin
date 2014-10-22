<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="X-ByPageAndGeo.aspx.cs" Inherits="pixAdmin.X_ByPageAndGeo" %>

<%@ Register src="UC/Menu.ascx" tagname="Menu" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 122px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Menu ID="Menu1" runat="server" />
    
      <h2>X By Geo/ Page</h2>
    
        <asp:GridView ID="grdpagesX" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" 

             AutoGenerateColumns="False" 
            OnSelectedIndexChanged="grdpagesX_SelectedIndexChanged" 
            onrowediting="grdpagesX_RowEditing"  
            OnRowCancelingEdit="grdpagesX_RowCancelingEdit" 
            OnRowDeleting ="grdpagesX_RowDeleting"
            OnRowUpdating="updateX">



            <AlternatingRowStyle BackColor="White" />
             <Columns>
                 <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" id="EditButton" text="Edit"  CommandName="Edit"   />
                    </ItemTemplate>
                     <EditItemTemplate>
                         <asp:LinkButton runat="server" id="LinkButton1"  text="update"  CommandName="Update"   OnClientClick="if (!window.confirm('Are you sure you want to UPDATE this item?')) return false;" />
                         <asp:LinkButton runat="server" id="LinkButton3" text="Delete"  CommandName="Delete"  OnClientClick="if (!window.confirm('Confiirm DELETE ?')) return false;"  />
                        <asp:LinkButton runat="server" id="LinkButton2" text="Cancel"  CommandName="Cancel"   />
                     </EditItemTemplate>

                </asp:TemplateField>  
               
                 <asp:BoundField DataField="id"                  HeaderText="id" ReadOnly="true" />
                 <asp:BoundField DataField="providerid"          HeaderText="providerid" />
                 <asp:BoundField DataField="pageid"            HeaderText="pageid"/>
                 <asp:BoundField DataField="countryCode"         HeaderText="countryCode"  />
                 <asp:BoundField DataField="sendResponseEvery_x"              HeaderText="X"  />

        </Columns>




            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
        <br />
          <div>Add new mapping for X</div><br />
              <table style="width:100%;">
                  <tr>
                      <td class="auto-style1">provider id</td>
                      <td>
                          <asp:TextBox ID="txtProviderID" runat="server" EnableViewState="False"></asp:TextBox>
                      </td>
                  </tr>
                  <tr>
                      <td class="auto-style1">page id</td>
                      <td>
                          <asp:TextBox ID="txtPageID" runat="server" EnableViewState="False"></asp:TextBox>
                      </td>
                  </tr>
                  <tr>
                      <td class="auto-style1">country Code</td>
                      <td>
                          <asp:TextBox ID="txtCountryCode" runat="server" EnableViewState="False"></asp:TextBox>
                      </td>
                  </tr>
                  <tr>
                      <td class="auto-style1">x</td>
                      <td>
                          <asp:TextBox ID="txt_X" runat="server" EnableViewState="False"></asp:TextBox>
                      </td>
                  </tr>
                  <tr>
                      <td class="auto-style1">&nbsp;</td>
                      <td>
                          <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                      </td>
                  </tr>
              </table>
        </div>

    </form>
</body>
</html>
