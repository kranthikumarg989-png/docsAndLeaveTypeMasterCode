<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ExpiryDetails.aspx.vb" Inherits="E_Management.ExpiryDetails"  MasterPageFile="~/ems.Master" title="WorkPermit Expiry Summary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">

<table cellpadding="5" cellspacing="0" border="0" width="100%">
          <tr>
              <td align="center">
                  <h1>WorkPermit Expiry Summary</h1>
              </td>
          </tr>
          <tr>
              <td align="center" style="text-align: right">
                  <asp:Label ID="lblMsg" runat="server"></asp:Label><br />
                  <a href="RequestByEmpCode.aspx">Request Passport (Individual)</a> </td>
          </tr>
          <tr>
              <td align="center">
                  <asp:GridView ID="gv" runat="server" AutoGenerateColumns="false" HorizontalAlign="Center" CellPadding="5" CssClass="grid">
                  <Columns>
                    <asp:BoundField DataField="Month" HeaderText="Month - Year" />
                    <asp:TemplateField HeaderText="Count">
                        <ItemTemplate>
                            <a href="javascript:void(0);" onclick="window.open('ExpiryPopup.aspx?&id=<%# Eval("Month") %>','Popup','width=1200px,height=700px,scrollbars=yes')"><%# Eval("Count") %></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                  </Columns>
                  </asp:GridView>
              </td>
          </tr>
      </table>
</asp:Content>