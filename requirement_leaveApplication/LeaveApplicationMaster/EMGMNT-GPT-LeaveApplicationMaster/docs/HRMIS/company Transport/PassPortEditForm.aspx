<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PassPortEditForm.aspx.vb"  Inherits="E_Management.PassPortEditForm"   MasterPageFile="~/ems.Master" %>

 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
 
    <table style="border-right: steelblue 1px solid; border-top: steelblue 1px solid; border-left: steelblue 1px solid; border-bottom: steelblue 1px solid">
        <tr>
            <td align="center" colspan="5" class="td_head">
              PASSPORT DETAILS EDIT/ UPDATE</td>
        </tr>
        <tr>
            <td align="center" colspan="5" class="td_head">
              <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 115px; height: 18px; background-color: beige">
                Employee No</td>
            <td style="height: 18px; width: 202px;">
                <asp:TextBox ID="tpeno" runat="server" AutoPostBack="True" Width="87px" BackColor="#FFFF80"></asp:TextBox>
                </td>
            <td style="height: 18px; background-color: beige">
                Gender</td>
            <td bgcolor="#ffffff" valign="top" style="height: 18px">
                <asp:Label ID="tpgender" runat="server" Width="160px" ForeColor="Maroon"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 115px; height: 17px; background-color: beige;">
                Employee Name</td>
            <td bgcolor="#ffffff" style="width: 202px; height: 17px;">
                <asp:Label ID="tpename" runat="server" Width="216px" ForeColor="Maroon"></asp:Label></td>
            <td style="height: 17px; background-color: beige;">
                Department Code</td>
            <td bgcolor="#ffffff" style="height: 17px">
                <asp:Label ID="tpdept" runat="server" Width="160px" ForeColor="Maroon"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 115px; height: 20px; background-color: beige;">
                Section Code</td>
            <td bgcolor="#ffffff" style="width: 202px; height: 20px">
                <asp:Label ID="tpsect" runat="server" Width="214px" ForeColor="Maroon"></asp:Label></td>
            <td style="height: 20px; background-color: beige;">
                Designation</td>
            <td bgcolor="#ffffff" style="height: 20px">
                <asp:Label ID="tpdesig" runat="server" Width="160px" ForeColor="Maroon"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 115px; height: 15px; background-color: beige;">
                Passport No <span style="color: Red; display: inline;">* </span></td>
            <td style="width: 202px; height: 15px;">
                <asp:TextBox ID="tppno" runat="server" Width="148px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator59" runat="server" ControlToValidate="tppno"
                    Display="Dynamic" ErrorMessage="!" SetFocusOnError="True"
                    ValidationGroup="vpassport">* </asp:RequiredFieldValidator></td>
            <td style="height: 15px; background-color: beige;">
                Passport Expiry Date <span style="color: Red; display: inline;">* </span></td>
            <td style="height: 15px">
                <asp:TextBox ID="tpedate" runat="server" Width="147px" ></asp:TextBox>&nbsp;
                   <cc1:calendarextender id="CalendarExtender1" runat="server" cssclass="cal_Theme1"
        format="dd/MM/yy" popupbuttonid="tpedate" targetcontrolid="tpedate"></cc1:calendarextender>
                
                <asp:RequiredFieldValidator ID="RequiredFieldValidator57" runat="server" ControlToValidate="tpedate"
                    Display="Dynamic" ErrorMessage="!" SetFocusOnError="True"
                    ValidationGroup="vpassport">* </asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 115px; height: 21px; background-color: beige;">
                Issued Country <span style="color: Red; display: inline;">* </span></td>
            <td style="width: 202px; height: 21px;">
                <asp:TextBox ID="tpissuedcountry" runat="server" Width="148px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator60" runat="server" ControlToValidate="tpissuedcountry"
                    Display="Dynamic" ErrorMessage="!" SetFocusOnError="True"
                    ValidationGroup="vpassport">* </asp:RequiredFieldValidator></td>
            <td style="height: 21px; background-color: beige;">
                Issued Place <span style="color: Red; display: inline;">* </span></td>
            <td style="height: 21px">
                <asp:TextBox ID="tpissuedplace" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator58" runat="server" ControlToValidate="tpissuedplace"
                    Display="Dynamic" ErrorMessage="RequiredFieldValidator" SetFocusOnError="True"
                    ValidationGroup="vpassport">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 115px; height: 32px; background-color: beige;">
                Address</td>
            <td style="width: 202px">
                <asp:TextBox ID="tpaddress" runat="server" Height="56px" TextMode="MultiLine" Width="192px"></asp:TextBox>
            </td>
            <td style="height: 26px; background-color: beige;">
                GroupCode</td>
            <td style="height: 32px">
                <asp:DropDownList ID="dpgrp" runat="server" DataSourceID="dppgrpcode" DataTextField="Column1"
                    DataValueField="groupcode" AppendDataBoundItems="True">
                    <asp:ListItem Selected="True" Value="-">--select--</asp:ListItem>
                </asp:DropDownList><asp:SqlDataSource ID="dppgrpcode" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT DISTINCT groupcode +'-' + groupname,groupcode FROM groupmaster ORDER BY groupcode"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td style="width: 115px; height: 14px; background-color: beige;">
                Country name <span style="color: Red; display: inline;">* </span></td>
            <td style="width: 202px; height: 14px">
                <asp:DropDownList ID="tpcountry" runat="server" AppendDataBoundItems="True" DataSourceID="country"
                    DataTextField="countryname" DataValueField="countryname" Width="160px" AutoPostBack="True">
                    <asp:ListItem Selected="True" Value="-">--Select a value--</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator61" runat="server" ControlToValidate="tpcountry"
                    Display="Dynamic" ErrorMessage="!" InitialValue="-"
                    SetFocusOnError="True" ValidationGroup="vpassport">* </asp:RequiredFieldValidator></td>
            <td style="height: 14px; background-color: beige;">
                Date Arrived <span style="color: Red; display: inline;">* </span></td>
            <td style="height: 14px">
                <asp:TextBox ID="tdatearrived" runat="server" Width="149px" ></asp:TextBox>
                    <cc1:calendarextender id="CalendarExtender2" runat="server" cssclass="cal_Theme1"
        format="dd/MM/yy" popupbuttonid="tdatearrived" targetcontrolid="tdatearrived"></cc1:calendarextender>
               
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tdatearrived"
                    Display="Dynamic" ErrorMessage="!" SetFocusOnError="True" ValidationGroup="vpassport">* </asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 115px; height: 14px; background-color: beige">
                KDN Ref No</td>
            <td style="width: 202px; height: 14px">
                <asp:DropDownList ID="CmbKdnRefNo" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource2" DataTextField="KDNRefNo"
                    DataValueField="KDNRefNo" Width="225px">
                    <asp:ListItem Selected="True" Value="-">--Select a value--</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT KDNRefNo FROM Tbl_KDNRefNo Order By CreatedOn Desc"></asp:SqlDataSource>
            </td>
            <td style="height: 14px; background-color: beige">
                KDN Approval</td>
            <td style="height: 14px">
                <asp:DropDownList ID="CmbKDNApproval" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource3"
                    DataTextField="KDNApproval" DataValueField="KDNApproval" Width="160px">
                    <asp:ListItem Selected="True" Value="-">--Select a value--</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT KDNApproval FROM Tbl_KDNApproval Order By CreatedOn Desc ">
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td style="width: 115px; height: 14px; background-color: beige">
                Agent</td>
            <td style="width: 202px; height: 14px">
                <asp:TextBox ID="TxtAgent" runat="server"></asp:TextBox>

            </td>
            <td style="height: 14px; background-color: beige">
                Contract Period</td>
            <td style="height: 14px">
                <asp:TextBox ID="TxtContractPeriod" runat="server" CssClass="numberonly"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td style="width: 115px; height: 14px; background-color: beige">
                Father Name</td>
            <td style="width: 202px; height: 14px">
                <asp:TextBox ID="TxtFatherName" runat="server"></asp:TextBox>

            </td>
            <td style="height: 14px; background-color: beige">
                Mother Name</td>
            <td style="height: 14px">
                <asp:TextBox ID="TxtMotherName" runat="server"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td style="width: 115px; height: 14px; background-color: beige">
                ContactNo</td>
            <td style="width: 202px; height: 14px">
                <asp:TextBox ID="TxtContactNo" runat="server"></asp:TextBox>

            </td>
            <td style="height: 14px; background-color: beige">
                Barcode</td>
            <td style="height: 14px">
                <asp:TextBox ID="TxtBarcode" runat="server" Height="56px" TextMode="MultiLine" Font-Names="IDAutomationHC39M"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td align="right" colspan="2" style="height: 28px">
                &nbsp;<asp:Button ID="bsave_passport" runat="server" Text="Save" ValidationGroup="vpassport" SkinID="buttonskin1" />
            </td>
             <td align="left" colspan="2" style="height: 28px">
                &nbsp;<asp:Button ID="Clear" runat="server" Text="Clear" SkinID="buttonskin1" />
            </td>
        </tr>
        
    </table>
    <asp:SqlDataSource ID="country" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT [countryname] FROM [countrymaster]"></asp:SqlDataSource>
 
    <script type="text/javascript" src="../../js/jquery.min.js"></script>
    <script src="../../js/jquery-ui.js" type="text/javascript"></script>
    <script>
        $("input:text").blur(function () {
            $(this).val($.trim($(this).val()));
        });

        $('textarea').keyup(function () {
            var limit = parseInt($(this).attr('maximumlength'));
            var text = $(this).val();
            var chars = text.length;

            if (chars > limit) {
                var new_text = text.substr(0, limit);
                $(this).val(new_text);
            }
        });

        $('.numberonly').keyup(function (e) {
            var rgx = /^\-?[0-9]*\.?[0-9]*$/;
            this.value = this.value.match(rgx);
        });


        $(function () {
            $(".datepicker").datepicker({
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true                
            });
        });

        
      $("#<%= bsave_passport.ClientID %>").click(function () {
            var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
            if($("#<%= tppno.ClientID%>").val()=="")
            {
                alert("Please enter the Passport No");
                $("#<%= tppno.ClientID%>").focus();
                return false;
            }
          if ($("#<%= tpedate.ClientID%>").val() == "") {
              alert("Please enter the Passport Expiry Date");
              $("#<%= tpedate.ClientID%>").focus();
              return false;
          }
            if ($("#<%= tpissuedcountry.ClientID%>").val() == "") {
                alert("Please enter the Passport Issued country");
                $("#<%= tpissuedcountry.ClientID%>").focus();
                return false;
            }
            if ($("#<%= tpissuedplace.ClientID%>").val() == "") {
                alert("Please enter the Issued Place ");
                $("#<%= tpissuedplace.ClientID%>").focus();
                return false;
            }
            if ($("#<%= tpcountry.ClientID%>").val() == "-") {
                alert("Please specify the Country");
                $("#<%= tpcountry.ClientID%>").focus();
                return false;
            }
            if ($("#<%= tpedate.ClientID%>").val() == "") {
                alert("Please specify the Date of PassportExpiry");
                $("#<%= tpedate.ClientID%>").focus();
                return false;
            }            

            if ($("#<%= tdatearrived.ClientID%>").val() == "") {
                alert("Please enter the Date of Arrived");
                $("#<%= tdatearrived.ClientID%>").focus();
                return false;
            }
        });
        </script>
</asp:Content>