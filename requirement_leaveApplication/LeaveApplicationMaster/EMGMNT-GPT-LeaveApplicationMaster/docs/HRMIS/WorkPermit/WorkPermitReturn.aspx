<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WorkPermitReturn.aspx.vb" Inherits="E_Management.WorkPermitReturn" MasterPageFile="~/ems.Master" title=" " %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">


      <table cellpadding="5" cellspacing="0" border="0" width="100%">
          <tr>
              <td align="center">
                  <h1>Passport Return</h1>
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
                        <td>Barcode</td><td><asp:TextBox ID="txtBarcode" runat="server" CssClass= "form-control" AutoPostBack="true"></asp:TextBox></td>
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
                    <asp:TemplateField HeaderText="Remove" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="../../images/delete1.png" AlternateText="Remove" CommandArgument='<%# eval("rno") %>' CommandName="Remove" Width="25px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                  </Columns>
                  </asp:GridView>
              </td>
          </tr>
          <tr>
              <td align="center">
                  <table cellpadding="3" cellspacing="0">
                      <tr>
                          <td style="text-align: left">Return On</td><td>:</td><td style="text-align: left"><asp:TextBox ID="txtReceivedDate" runat="server"  CssClass= "form-control"  ></asp:TextBox>  </td>
                      </tr>
                      <tr>
                          <td style="height: 26px; text-align: left">Return By</td><td style="height: 26px">:</td><td style="height: 26px; text-align: left"> <asp:DropDownList ID="ddlEmpCode" runat="server" CssClass= "form-control" ></asp:DropDownList></td>
                      </tr>
                      <tr>
                          <td style="text-align: left">Remarks</td><td>:</td><td style="text-align: left"><asp:TextBox ID="txtRemarks" runat="server"  CssClass= "form-control" TextMode="MultiLine"  ></asp:TextBox>     </td>
                      </tr>
                      <tr>
                          <td align="center" style="text-align: right">
                              <asp:HiddenField ID="hideCount" runat="server" />
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" />
                          </td>
                      </tr>
                  </table>
              </td>
          </tr>
      </table>
 
<script src="../../js/jquery.min.js" type="text/javascript"></script>
<script src="../../js/jquery-ui.js" type="text/javascript"></script>
    <script type="text/javascript">
        $("input:text").blur(function() {
             $(this).val($.trim($(this).val()));
         });
         
        $(function() {
        $( "#<%=txtReceivedDate.ClientID %>" ).datepicker({ dateFormat: 'dd/mm/yy' });
            var d = new Date();
            $( "#<%=txtReceivedDate.ClientID %>" ).val( d.getDate() + "/" + (d.getMonth()+1) + "/" + d.getFullYear() );
        });
        
        $("#<%= btnSubmit.ClientID %>").click(function() {  
         if (($("#<%=hideCount.ClientID %>").val()<=0)) {
             alert("Please specify the Workpermit");
             $("#<%=txtBarcode.ClientID %>").focus();
             return false;
         }
        if (($("#<%=ddlEmpCode.ClientID %>").val() == "Select")) {
            alert("Please specify the Return By");
            $("#<%=ddlEmpCode.ClientID %>").focus();
            return false;
        }
        });
    </script> 
    
</asp:Content>
