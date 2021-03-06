﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pageRedirection.aspx.cs" Inherits="pixAdmin.pageRedirection" %>

<%@ Register src="UC/Menu.ascx" tagname="Menu" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 168px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

    
        <uc1:Menu ID="Menu1" runat="server" />
    

   

        <div><b>explanation: </b>if providerid = -1 it means that all <b>origin </b>pages will be redirected to <b>redirectTo</b> pages </div>
        <div><b>otherwise: </b>for only for the specific provider id there will be redirection</div>
        <br />

        <table>
<tr> <td valign="top">
     <h2>Page Redirection</h2>
        <asp:GridView ID="grdPageRedirect" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
              AutoGenerateColumns="False" 
            OnSelectedIndexChanged="grdPageRedirect_SelectedIndexChanged" 
            onrowediting="grdPageRedirect_RowEditing"  
            OnRowCancelingEdit="grdPageRedirect_RowCancelingEdit" 
            OnRowDeleting ="grdPageRedirect_RowDeleting"
            OnRowUpdating="updateRedirect">
            
            
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
                 <asp:BoundField DataField="pageid_origin"            HeaderText="Origin"/>
                 <asp:BoundField DataField="pageid_redirectTo"         HeaderText="Redirect To"  />




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

        </td>
        
        <td valign="top"> <iframe src="pageRedirectionByGEO.aspx" width="600px" height="600px" frameborder="0"></iframe></td>
        </tr>
            
        </table>
        <br />
        <div><h2>Add redirection</h2></div>
        <br />

    <table >
        <tr>
            <td class="auto-style1">Provider id</td>
            <td>
                <asp:TextBox ID="txtProviderID" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">origin page id</td>
            <td>
                <asp:TextBox ID="txtpageOrigin" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">destination page id </td>
            <td>
                <asp:TextBox ID="txtPageDestination" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>
                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" style="height: 26px" Text="Add" />
            </td>
        </tr>
    </table>

            </form>
</body>
</html>
