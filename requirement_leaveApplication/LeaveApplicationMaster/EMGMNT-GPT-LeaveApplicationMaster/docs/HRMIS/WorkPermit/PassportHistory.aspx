<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PassportHistory.aspx.vb" Inherits="E_Management.PassportHistory"  MasterPageFile="~/ems.Master" title=" " %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
  
    <table cellpadding="5" cellspacing="0" width="100%">
          <tr>
            <td align="center">
                <h1>Passport Transaction History</h1>
            </td>
          </tr>
          <tr>
              <td align="center"><asp:Label ID="lblMsg" runat="server"></asp:Label></td>
          </tr>
          <tr>
              <td align="center">
                  <table cellpadding="3" cellspacing="0">
                      <tr>
                          <td style="text-align: left">From</td><td>:</td><td style="text-align: left"><asp:TextBox CssClass= "DatePicker" id="txtFromdate" runat="server"></asp:TextBox></td>
                          <td style="text-align: left">To</td><td>:</td><td><asp:TextBox CssClass= "DatePicker" id="txtTodate" runat="server"></asp:TextBox></td>
                          <td rowspan="2" valign="middle"><asp:Button runat="server" CssClass="btn btn-primary" Text="Submit" id="btnSubmit" /><asp:Button runat="server" CssClass="btn btn-primary" Text="Clear" id="btnClear" /></td>
                      </tr>
                      <tr>
                          <td style="text-align: left">Passport No</td><td>:</td><td style="text-align: left"><asp:TextBox ID="txtPassportNo" runat="server"></asp:TextBox> </td>
                          <td style="text-align: left">Emp Code</td><td>:</td><td style="text-align: left"><asp:DropDownList ID="ddlEmpCode" runat="server"></asp:DropDownList></td>
                      </tr>
                  </table>
              </td>
          </tr>
          <tr>
                <td align="center">
                  <table cellpadding="3" cellspacing="0">
                      <tr>
                          <td align="center">
                              <asp:GridView ID="gv" runat="server" AutoGenerateColumns="false" HorizontalAlign="Center" CellPadding="5" AllowPaging="true" PageSize="25" CssClass="grid" RowStyle-HorizontalAlign="Center">
                                  <Columns>
                                      <asp:BoundField HeaderText="Emp Code" DataField="EmpCode" />
                                      <asp:BoundField HeaderText="Emp Name" DataField="Name" />
                                      <asp:BoundField HeaderText="Department" DataField="DepartmentCode" />
                                      <asp:BoundField HeaderText="Section" DataField="SectionCode" />
                                      <asp:BoundField HeaderText="Passport No" DataField="PassportNo" />
                                      <asp:BoundField HeaderText="Issued On" DataField="IssuedOn" DataFormatString="{0:dd-MM-yyyy}" />
                                      <asp:BoundField HeaderText="Received By" DataField="ReceivedBy" />
                                      <asp:BoundField HeaderText="Issue Remarks" DataField="IssueRemarks" />
                                      <asp:BoundField HeaderText="Status" DataField="Status" />
                                      <asp:BoundField HeaderText="Return On" DataField="ReturnOn" DataFormatString="{0:dd-MM-yyyy}" />
                                      <asp:BoundField HeaderText="Return By" DataField="ReturnBy" />
                                      <asp:BoundField HeaderText="Return Remarks" DataField="ReturnRemarks" />
                                  </Columns>
                              </asp:GridView>
                          </td>
                      </tr>
                  </table>
                </td>
        
      </table>    

      
          <!-- jQuery 2.1.4 -->
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">
    
    $(document).ready(function() {  
        $('.numberonly').keyup(function (e) {
            var rgx = /^[0-9]*\.?[0-9]*$/;
            this.value =  this.value.match(rgx);
        });
        $('textarea').keyup(function(){  
            var limit = parseInt($(this).attr('maxlength'));  
            var text = $(this).val();  
            var chars = text.length;  
            if(chars > limit){  
                var new_text = text.substr(0, limit);  
                $(this).val(new_text);  
            }  
        });  
      
    });  
    </script><script src="../../js/jquery-ui.js" type="text/javascript"></script>
    <script type="text/javascript">
    $(function() {
        $( ".DatePicker" ).datepicker({ dateFormat: 'dd/mm/yy' });
        $(".DatePicker").attr("AutoComplete","Off");
        $(".multiline").attr("maxlength","250");
        
        $(".DatePicker").on("click", function() {
	        var self;
	        if (navigator.userAgent.match(/msie/i)) {
		        var scrollTopValue = document.body.scrollTop || window.pageYOffset 
			    || (document.body.parentElement
			    ?document.body.parentElement.scrollTop:
			    $(window).scrollTop());
		        self = $(this);
		        $("#ui-datepicker-div").hide();
		        setTimeout(function(){
			    $("#ui-datepicker-div").css({
				    top: self.offset().top + scrollTopValue + 25
			    });
			        $("#ui-datepicker-div").show();
		        }, 0);
	        }
        });
    });
        </script>
        
        
</asp:Content>

