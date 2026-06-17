<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RequestByEmpCode.aspx.vb" Inherits="E_Management.RequestByEmpCode" 
 MasterPageFile="~/ems.Master" title=" " %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">

      <table cellpadding="5" cellspacing="0" border="0" width="100%">
          <tr>
              <td align="center">
                  <h1>Passport Request By Employee Code</h1>
              </td>
          </tr>
          <tr>
              <td align="center">
                  <asp:Label ID="lblMsg" runat="server"></asp:Label></td>
          </tr>
          
          <tr>
              <td align="center">Employee Code :
                  <asp:TextBox ID="txtEmp" runat="server" CssClass="form-control" AutoPostBack="true"></asp:TextBox></td>
          </tr>
          <tr>
              <td align="center">
                  <asp:GridView ID="gv" runat="server" AutoGenerateColumns="false" HorizontalAlign="Center" CellPadding="5" DataKeyNames="rno" ShowFooter="true" CssClass="grid">
                  <Columns>
                    <asp:BoundField DataField="Month" HeaderText="Month - Year" />
                    <asp:BoundField DataField="Barcode" HeaderText="Barcode" />
                    <asp:BoundField DataField="EmpCode" HeaderText="EmpCode" />
                    <asp:BoundField DataField="EmpName" HeaderText="EmpName" />
                    <asp:BoundField DataField="Department" HeaderText="Department" />
                    <asp:BoundField DataField="Section" HeaderText="Section" />
                    <asp:BoundField DataField="DateofHire" HeaderText="Date of Hire" DataFormatString="{0:dd-MM-yyyy}" />
                    <asp:BoundField DataField="Permitexpiry" HeaderText="Permit Expiry" DataFormatString="{0:dd-MM-yyyy}" />
                    <asp:BoundField DataField="Yrs" HeaderText="Yrs" />
                    <asp:BoundField DataField="arriveddate" HeaderText="Arrival Date" DataFormatString="{0:dd-MM-yyyy}" />
                    <asp:BoundField DataField="workpermitno" HeaderText="Work Permit No" />
                    <asp:BoundField DataField="KDRefNo" HeaderText="KDN Ref No" />
                    <asp:BoundField DataField="MonthofExpiry" HeaderText="Month of Expiry" />
                    <asp:BoundField DataField="passportno" HeaderText="Passport No" />
                    <asp:BoundField DataField="ppexpirydate" HeaderText="Passport Expiry Date" DataFormatString="{0:dd-MM-yyyy}" />
                    <asp:BoundField DataField="KDNApproval" HeaderText="KDN Approval" />
                  </Columns>
                  </asp:GridView>
              </td>
          </tr>

          <tr>
              <td align="center">
                  <asp:Button runat="server" CssClass="btn btn-primary" Text="Submit" ID="btnSubmit" />
              </td>
          </tr>
      </table> 
      
      
</asp:Content>
