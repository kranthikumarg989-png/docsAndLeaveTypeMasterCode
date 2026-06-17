<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Report.aspx.vb" Inherits="E_Management.Report"MasterPageFile="~/ems.Master" title=" " %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">

    <table cellpadding="5" cellspacing="0" border="0" width="100%">
          <tr>
              <td align="center">
                  <h1>Report By Department</h1>
              </td>
          </tr>
          <tr>
              <td align="center">
                  <asp:Label ID="lblMsg" runat="server"></asp:Label></td>
          </tr>
        <tr>
            <td align="center">
                <table cellpadding="3" cellspacing="0">
                    <tr>
                        <td>Department</td><td><asp:DropDownList ID="ddlDepartment" runat="server" CssClass= "form-control" AutoPostBack="true" ></asp:DropDownList></td><td><asp:ImageButton ID="btnExcel" runat="server" AlternateText="Export to Excel" ImageUrl="../../images/Excel-icon.png" width="45px" /></td>
                    </tr>
                </table>
            </td>
        </tr>
          <tr>
              <td align="center">
                  <asp:GridView ID="gv" runat="server" AutoGenerateColumns="false" HorizontalAlign="Center" CellPadding="5" DataKeyNames="rno" CssClass="grid">
                  <Columns>
                    <%--<asp:BoundField DataField="Month" HeaderText="Month - Year" />--%>
                    <asp:BoundField DataField="Barcode" HeaderText="Barcode" />
                    <asp:BoundField DataField="EmpCode" HeaderText="EmpCode" />
                    <asp:BoundField DataField="EmpName" HeaderText="EmpName" />
                    <asp:BoundField DataField="Department" HeaderText="Department" />
                    <asp:BoundField DataField="Section" HeaderText="Section" />
                    <asp:BoundField DataField="Designation" HeaderText="Position" />
                    <asp:BoundField DataField="DateofHire" HeaderText="Date of Hire" DataFormatString="{0:dd-MM-yyyy}" />
                      <asp:BoundField DataField="ContractRenewed" HeaderText="Contract Renewed" DataFormatString="{0:dd-MM-yyyy}" />
                    <asp:BoundField DataField="Permitexpiry" HeaderText="Permit Expiry" DataFormatString="{0:dd-MM-yyyy}" />
                    <asp:BoundField DataField="Yrs" HeaderText="Yrs" />
                    <asp:BoundField DataField="arriveddate" HeaderText="Arrival Date" DataFormatString="{0:dd-MM-yyyy}" />
                    <asp:BoundField DataField="workpermitno" HeaderText="Work Permit No" />
                    <asp:BoundField DataField="KDRefNo" HeaderText="KDN Ref No" />
                    <asp:BoundField DataField="ReceiptNo" HeaderText="Receipt No" />
                    <asp:BoundField DataField="MonthofExpiry" HeaderText="Month of Expiry" />
                    <asp:BoundField DataField="passportno" HeaderText="Passport No" />
                    <asp:BoundField DataField="ppexpirydate" HeaderText="Passport Expiry Date" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="Address1" HeaderText="Home Address" />
                    <asp:BoundField DataField="FatherName" HeaderText="Father Name" />
                    <asp:BoundField DataField="MotherName" HeaderText="Mother Name" />
                    <asp:BoundField DataField="ContactNo" HeaderText="Contact No" />
                    <asp:BoundField DataField="dateofbirth" HeaderText="DOB" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="Age" HeaderText="Age" />
                    <asp:BoundField DataField="Agent" HeaderText="Agent" />
                    <asp:BoundField DataField="Sex" HeaderText="Gender" />
                    <asp:BoundField DataField="Nationality" HeaderText="Nationality" />
                    <asp:BoundField DataField="KDNApproval" HeaderText="KDN Approval" />
                  </Columns>
                  </asp:GridView>
              </td>
          </tr>
      </table>

  </asp:Content>