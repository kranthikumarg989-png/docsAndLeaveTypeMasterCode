<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WPExpiryReport.aspx.vb" Inherits="E_Management.WPExpiryReport"  MasterPageFile="~/ems.Master" title=" " %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
      <table cellpadding="5" cellspacing="0" border="0" width="100%">
          <tr>
              <td align="center">
                  <h1>Workpermit Expiry Report By Month</h1>
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
                        <td>Month</td>
                        <td>
                            <asp:DropDownList ID="ddlMonth" runat="server" CssClass= "form-control" AutoPostBack="true" >
                                <asp:ListItem>January</asp:ListItem>
                                <asp:ListItem>February</asp:ListItem>
                                <asp:ListItem>March</asp:ListItem>
                                <asp:ListItem>April</asp:ListItem>
                                <asp:ListItem>May</asp:ListItem>
                                <asp:ListItem>June</asp:ListItem>
                                <asp:ListItem>July</asp:ListItem>
                                <asp:ListItem>August</asp:ListItem>
                                <asp:ListItem>September</asp:ListItem>
                                <asp:ListItem>October</asp:ListItem>
                                <asp:ListItem>November</asp:ListItem>
                                <asp:ListItem>December</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>&nbsp;</td>
                        <td>Year</td>
                        <td><asp:DropDownList ID="ddlYear" runat="server" CssClass= "form-control" AutoPostBack="true" ></asp:DropDownList></td>
                    </tr>
                </table>
            </td>
        </tr>
          <tr><td align="right"><asp:ImageButton ID="btnExcel" runat="server" AlternateText="Export to Excel" ImageUrl="../../images/Excel-icon.png" width="45px" /></td></tr>
          <tr>
              <td align="center">
                  <asp:GridView ID="gv" runat="server" AutoGenerateColumns="false" HorizontalAlign="Center" CellPadding="5" CssClass="grid">
                  <Columns>
                    <%--<asp:BoundField DataField="Month" HeaderText="Month - Year" />--%>
                    <asp:BoundField DataField="Barcode" HeaderText="Barcode" />
                    <asp:BoundField DataField="EmpCode" HeaderText="EmpCode" />
                    <asp:BoundField DataField="EmpName" HeaderText="EmpName" />
                    <asp:BoundField DataField="Department" HeaderText="Department" />
                    <asp:BoundField DataField="Section" HeaderText="Section" />
                    <asp:BoundField DataField="DateofHire" HeaderText="Hired date" DataFormatString="{0:dd-MM-yyyy}" />
                      <asp:BoundField DataField="ContractRenewed" HeaderText="Contract Renewed" DataFormatString="{0:dd-MM-yyyy}" />
                    <asp:BoundField DataField="Permitexpiry" HeaderText="Expiry Date" DataFormatString="{0:dd-MM-yyyy}" />
                    <asp:BoundField DataField="Yrs" HeaderText="Yrs" />
                    <asp:BoundField DataField="arriveddate" HeaderText="Arrival Date" DataFormatString="{0:dd-MM-yyyy}" />
                    <asp:BoundField DataField="Signature" HeaderText="Signature" DataFormatString="{0:dd-MM-yyyy}" />
                    
                  </Columns>
                  </asp:GridView>
              </td>
          </tr>
          <tr><td>&nbsp;</td></tr>
          <tr><td align="right"><asp:ImageButton ID="btnExcel2" runat="server" AlternateText="Export to Excel" ImageUrl="../../images/Excel-icon.png" width="45px" /></td></tr>
          <tr>
            <td align="center">
                <table id="tblDetails" runat="server" align="center">
                    <tr><td>Male</td></tr>
                    <tr>
                        <td align="center">
                        <asp:GridView ID="gvMale" runat="server" AutoGenerateColumns="false" HorizontalAlign="Center" CellPadding="5" CssClass="grid">
                          <Columns>
                            <%--<asp:BoundField DataField="Month" HeaderText="Month - Year" />--%>
                            <asp:BoundField DataField="Barcode" HeaderText="Barcode" />
                            <asp:BoundField DataField="EmpCode" HeaderText="EmpCode" />
                            <asp:BoundField DataField="EmpName" HeaderText="EmpName" />
                            <asp:BoundField DataField="Department" HeaderText="Department" />
                            <asp:BoundField DataField="Section" HeaderText="Section" />
                            <asp:BoundField DataField="DateofHire" HeaderText="Hired date" DataFormatString="{0:dd-MM-yyyy}" />
                              <asp:BoundField DataField="ContractRenewed" HeaderText="Contract Renewed" DataFormatString="{0:dd-MM-yyyy}" />
                            <asp:BoundField DataField="Permitexpiry" HeaderText="Expiry Date" DataFormatString="{0:dd-MM-yyyy}" />
                            <asp:BoundField DataField="Yrs" HeaderText="Yrs" />
                            <asp:BoundField DataField="arriveddate" HeaderText="Arrival Date" DataFormatString="{0:dd-MM-yyyy}" />
                            <asp:BoundField DataField="Signature" HeaderText="Signature" DataFormatString="{0:dd-MM-yyyy}" />
                            
                          </Columns>
                          </asp:GridView>
                        </td>
                    </tr>
                    <tr><td>Female</td></tr>
                    <tr>
                        <td align="center">
                        <asp:GridView ID="gvFemale" runat="server" AutoGenerateColumns="false" HorizontalAlign="Center" CellPadding="5" CssClass="grid">
                          <Columns>
                            <%--<asp:BoundField DataField="Month" HeaderText="Month - Year" />--%>
                            <asp:BoundField DataField="Barcode" HeaderText="Barcode" />
                            <asp:BoundField DataField="EmpCode" HeaderText="EmpCode" />
                            <asp:BoundField DataField="EmpName" HeaderText="EmpName" />
                            <asp:BoundField DataField="Department" HeaderText="Department" />
                            <asp:BoundField DataField="Section" HeaderText="Section" />
                            <asp:BoundField DataField="DateofHire" HeaderText="Hired date" DataFormatString="{0:dd-MM-yyyy}" />
                              <asp:BoundField DataField="ContractRenewed" HeaderText="Contract Renewed" DataFormatString="{0:dd-MM-yyyy}" />
                            <asp:BoundField DataField="Permitexpiry" HeaderText="Expiry Date" DataFormatString="{0:dd-MM-yyyy}" />
                            <asp:BoundField DataField="Yrs" HeaderText="Yrs" />
                            <asp:BoundField DataField="arriveddate" HeaderText="Arrival Date" DataFormatString="{0:dd-MM-yyyy}" />
                            <asp:BoundField DataField="Signature" HeaderText="Signature" DataFormatString="{0:dd-MM-yyyy}" />
                            
                          </Columns>
                          </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
          </tr>
      </table>   </asp:Content>

