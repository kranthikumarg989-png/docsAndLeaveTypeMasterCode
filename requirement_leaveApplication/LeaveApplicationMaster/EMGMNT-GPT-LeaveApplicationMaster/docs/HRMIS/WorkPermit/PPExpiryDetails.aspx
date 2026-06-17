<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PPExpiryDetails.aspx.vb" Inherits="E_Management.PPExpiryDetails" MasterPageFile="~/ems.Master" title=" " %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">

<table cellpadding="5" cellspacing="0" border="0" width="100%">
          <tr>
              <td align="center">
                  <h1>Passport Expiry Summary</h1>
              </td>
          </tr>
          <tr>
              <td align="center">
                  <asp:Label ID="lblMsg" runat="server"></asp:Label></td>
          </tr>
          <tr>
              <td align="center">
                  <asp:GridView ID="gv" runat="server" AutoGenerateColumns="false" HorizontalAlign="Center" CellPadding="5" CssClass="grid">
                  <Columns>
                    <asp:BoundField DataField="Month" HeaderText="Month - Year" />
                    <asp:TemplateField HeaderText="Count">
                        <ItemTemplate>
                           <a href="javascript:void(0);" onclick="window.open('PassportExpiryPopup.aspx?&id=<%# Eval("Month") %>','Popup','width=1200px,height=700px,scrollbars=yes')"><%# Eval("Count") %></a>                             
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                  </Columns>
                  </asp:GridView>
              </td>
          </tr>
      </table> 
</asp:Content>