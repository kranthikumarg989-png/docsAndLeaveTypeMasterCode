<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PassportInfo.aspx.vb" Inherits="E_Management.PassportInfo" MasterPageFile="~/ems.Master" title=" " %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">

        <table cellpadding="5" cellspacing="0" border="0" width="100%">
            <tr>
                <td align="center">
                    <h1>Passport Information</h1>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="lblMsg" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td align="center">
            <asp:GridView ID="gv" runat="server" AutoGenerateColumns="false" HorizontalAlign="Center" CellPadding="5" DataKeyNames="rno" AllowPaging="true" PageSize="25" CssClass="grid">
                  <Columns>
                    <asp:BoundField DataField="Barcode" HeaderText="Barcode" />
                    <asp:BoundField DataField="EmpCode" HeaderText="Emp Code" />
                    <asp:BoundField DataField="EmpName" HeaderText="Emp Name" />
                    <asp:BoundField DataField="Department" HeaderText="Department" />
                    <asp:BoundField DataField="Section" HeaderText="Section" />
                    <asp:BoundField DataField="PassportNo" HeaderText="Passport No" />
                    <asp:BoundField DataField="ppexpirydate" HeaderText="Passport Expiry Date" DataFormatString="{0:dd-MM-yyyy}" />
                    <asp:BoundField DataField="DateofHire" HeaderText="Date of Hire" DataFormatString="{0:dd-MM-yyyy}" />
                    <asp:BoundField DataField="ContractExpiry" HeaderText="Contract Expiry" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="Permitexpiry" HeaderText="Workpermit Expiry" DataFormatString="{0:dd/MM/yyyy}" />
                  </Columns>
                  </asp:GridView>
            </tr>
        </table> 
</asp:Content>
