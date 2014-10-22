<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProviderRevenu.aspx.cs" Inherits="pixAdmin.ProviderRevenu" %>

<%@ Register src="UC/Menu.ascx" tagname="Menu" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Menu ID="Menu1" runat="server" />
    
          <h2>Manage Providers revenu by Tier</h2>

         <div>Add new revenu</div>
        <table>
            <tr>
                <td>Provider</td>
                <td>
                    <asp:DropDownList ID="drpProviders" runat="server" DataTextField="name" DataValueField="id" EnableViewState="true">
                    </asp:DropDownList>
                </td>
                <td>
                    Tier</td>
                <td>
                    <asp:DropDownList ID="drpTiers" runat="server">
                        <asp:ListItem Value="Tier0">-Select-</asp:ListItem>
                        <asp:ListItem>Tier1</asp:ListItem>
                        <asp:ListItem>Tier2</asp:ListItem>
                        <asp:ListItem>Tier3</asp:ListItem>
                        <asp:ListItem>Tier4</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    Country Code</td>
                <td>
                    <asp:TextBox ID="txtCountryCode" runat="server" Width="54px" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    Revenu</td>
                <td>
                    <asp:TextBox ID="txtRevenu" runat="server" Width="74px"></asp:TextBox>
                </td>
                <td>
                    Cost</td>
                <td>
                    <asp:TextBox ID="txtCost" runat="server" Width="54px"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnAdd" runat="server" Text="Add Line" OnClick="btnAdd_Click" />
                 </td>
            </tr>
        </table>
        <br />
        <asp:GridView ID="grdProviderRevenu" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" 
            AutoGenerateColumns="False" 
            OnSelectedIndexChanged="grdProviderRevenu_SelectedIndexChanged" 
            onrowediting="grdProviderRevenu_RowEditing"  
            OnRowCancelingEdit="grdProviderRevenu_RowCancelingEdit" 
            OnRowDeleting ="grdProviderRevenu_RowDeleting"
            OnRowUpdating="updateRevenu">
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
                 <asp:BoundField DataField="providerid"          HeaderText="providerid" ReadOnly="true" />
                 <asp:BoundField DataField="providerName"        HeaderText="Provider Name" ReadOnly="true" />
                 <asp:BoundField DataField="TierName"            HeaderText="TierName"/>
                 <asp:BoundField DataField="countryCode"         HeaderText="countryCode"  />
                 <asp:BoundField DataField="revenu"              HeaderText="revenu"  />
                                 <asp:BoundField DataField="cost"              HeaderText="cost"  />


        </Columns>
            
            
            
             <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>

        <br />
       
        
    </form>
    <p>
        &nbsp;</p>
</body>
</html>
