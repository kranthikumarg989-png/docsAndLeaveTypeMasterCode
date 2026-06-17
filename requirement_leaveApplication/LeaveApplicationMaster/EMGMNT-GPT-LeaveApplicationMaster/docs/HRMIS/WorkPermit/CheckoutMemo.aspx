<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CheckoutMemo.aspx.vb" Inherits="E_Management.Checkoutmemo"
 MasterPageFile="~/ems.Master" title=" " %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">

      <table cellpadding="5" cellspacing="0" border="0" width="100%">
          <tr>
              <td align="center">
                  <h1>Checkout Memo</h1>
              </td>
          </tr>
          <tr>
              <td align="center">
                  <asp:Label ID="lblMsg" runat="server"></asp:Label></td>
          </tr>
          <tr id="divCheckoutOn" runat="server"><td align="center">Checkout On : <asp:TextBox runat="server" CssClass="datepicker" ID="Datetext"></asp:TextBox></td></tr>
<%--          <tr id="divByMonth" runat="server">
              <td align="center">
                  <table cellpadding="3" cellspacing="0">
                      <tr>
                          <td>Month</td>
                          <td>Year</td>
                      </tr>
                      <tr>
                          <td>
                              <asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-control" AutoPostBack="true">
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
                          <td>
                              <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList></td>
                      </tr>
                  </table>
              </td>
          </tr>
          <tr id="divByEmp" runat="server">
              <td align="center">Employee Code :
                  <asp:TextBox ID="txtEmp" runat="server" CssClass="form-control" AutoPostBack="true"></asp:TextBox></td>
          </tr>--%>
          <tr>
              <td align="center">
                  <asp:GridView ID="gv" runat="server" AutoGenerateColumns="false" HorizontalAlign="Center" CellPadding="5" CssClass="grid" DataKeyNames="rno">
                      <Columns>
                          <%--<asp:BoundField DataField="Month" HeaderText="Month - Year" />--%>
                          <asp:TemplateField HeaderText="Request">
                              <HeaderTemplate>
                                  <input type="checkbox" id="checkall" />
                              </HeaderTemplate>
                              <ItemTemplate>
                                  <asp:CheckBox ID="chkDelete" runat="server" CssClass="chkDelete" onclick="changeChkAll(this)" />
                              </ItemTemplate>
                              <ItemStyle HorizontalAlign="Center" />
                          </asp:TemplateField>
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
                          <asp:TemplateField HeaderText="LastWorking Date">
                              <ItemTemplate>
                                  <asp:TextBox ID="txtLastworkingDay" CssClass="datepicker" Width="75px" runat="server"></asp:TextBox>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Salary Payment Date">
                              <ItemTemplate>
                                  <asp:TextBox ID="txtSalary" CssClass="datepicker" runat="server" Width="75px"></asp:TextBox>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Send Back Date">
                              <ItemTemplate>
                                  <asp:TextBox ID="txtSendBack" CssClass="datepicker" runat="server" Width="75px"></asp:TextBox>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Replacement">
                              <ItemTemplate>
                                  <asp:TextBox ID="txtReplacement" runat="server" MaxLength="150"></asp:TextBox>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="HR Purpose">
                              <ItemTemplate>
                                  <asp:TextBox ID="txtHRPurpose" runat="server" MaxLength="150"></asp:TextBox>
                              </ItemTemplate>
                          </asp:TemplateField>
                      </Columns>
                  </asp:GridView>
              </td>
          </tr>
          <tr>
              <td align="center">
                  
                  <asp:Button runat="server" CssClass="btn btn-primary" Text="Submit" ID="btnSubmit" OnClientClick="return validate()" />
                  <asp:HiddenField ID="hideType" Value="" runat="server" />
              </td>
          </tr>
      </table>
 
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $('.numberonly').keyup(function (e) {
            var rgx = /^\-?[0-9]*\.?[0-9]*$/;
            this.value =  this.value.match(rgx);
        });

    </script>
    <script src="../../js/jquery-ui.js" type="text/javascript"></script>
    <script type="text/javascript">
        $("input:text").blur(function() {
             $(this).val($.trim($(this).val()));
         });
         
        $(function() {
            $( ".datepicker" ).datepicker({ dateFormat: 'dd/mm/yy' });
        });
     
        //ChkAll Start
        $("#checkall").click(function() {
            if ($("#checkall").is(":checked")) {
               //Check/uncheck all checkboxes in list according to main checkbox
                $('#gv').find('tr').each(function () {
                    var row = $(this);
                    row.find('input[type="checkbox"]').prop('checked', true);
                });
            }
            else {
                $('#gv').find('tr').each(function () {
                    var row = $(this);
                    row.find('input[type="checkbox"]').prop('checked', false);
                });
            }
        });

        function changeChkAll(obj) {
            var chkDel = 0;
            if ($(obj).is(":checked")) {
                $('#gv').find('td').each(function () {
                    if(!$(this).find('input[type="checkbox"]').is(":checked"))
                        chkDel = 1;
                });
                if (chkDel == 0)
                    $("#checkall").prop('checked', true);
                else
                    $("#checkall").prop('checked', false);
            }
            else {
                $("#checkall").prop('checked', false);
            }
        }
        //ChkAll End 
        // delete details end
    function validate()
    {
        var chkDel = 0;
        var checked = 0;
        var  isError=false;
        $("#<%= gv.ClientID %> tr").each(function () {
            if($("#<%= hideType.ClientID %>").val() == "Employee" || (chkDel > 0 && $(this).find('input[type="checkbox"]').is(":checked")))
            {
                checked++;
                if($(this).find('input:text[id$="txtLastworkingDay"]').val()=="")
               {
                  alert("Please specify the Lastworking Day");
                  $(this).find('input:text[id$="txtLastworkingDay"]').focus();
                  isError=true;
                  return false;
               }
               if($(this).find('input:text[id$="txtSalary"]').val()=="")
               {
                  alert("Please specify the Salary Payment Date");
                  $(this).find('input:text[id$="txtSalary"]').focus();
                  isError=true;
                  return false;
               }
               if($(this).find('input:text[id$="txtSendBack"]').val()=="")
               {
                  alert("Please specify the Send Back Date");
                  $(this).find('input:text[id$="txtSendBack"]').focus();
                  isError=true;
                  return false;
               }
               if($(this).find('input:text[id$="txtReplacement"]').val()=="")
               {
                  alert("Please enter the Replacement");
                  $(this).find('input:text[id$="txtReplacement"]').focus();
                  isError=true;
                  return false;
               }
               if($(this).find('input:text[id$="txtHRPurpose"]').val()=="")
               {
                  alert("Please enter the HR Purpose");
                  $(this).find('input:text[id$="txtHRPurpose"]').focus();
                  isError=true;
                  return false;
               }
            }
            chkDel++;
        });
      if(checked == 0)
      {
        alert("Please any one of the Workpermit")
        return false
      }
      if(isError)
        return false
    }
    </script> 
    
</asp:Content>

