<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="CVPass.aspx.vb" Inherits="E_Management.CVPass" 
    title="CUSTOMER VISIT PASS" %>
       <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table style="width: 240px">
        <tr>
            <td style="width: 100px">
                <asp:Label ID="Label1" runat="server" Font-Underline="True" ForeColor="Maroon" Text="CUSTOMER VISIT PASS" Width="130px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 100px">
                <table width="100%">
                    <tr>
                        <td class="td_head" colspan="5" style="height: 21px">
                            Enter Supplier/Customer Pass
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="5">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="BulletList"
                                EnableClientScript="true" HeaderText="You must enter a value in the following fields:" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 26px; background-color: lightgoldenrodyellow">
                            <asp:Label ID="Label6" runat="server" Text="Visitor Type"></asp:Label></td>
                        <td style="width: 299px; height: 26px">
                            <asp:DropDownList ID="csddlvtype" runat="server">
                                <asp:ListItem Value="Customer">customer</asp:ListItem>
                                <asp:ListItem Value="Supplier">supplier</asp:ListItem>
                                <asp:ListItem Value="Visitor">visitor</asp:ListItem>
                                <asp:ListItem>Others</asp:ListItem>
                                <asp:ListItem Value="-1" Selected="True">-Select -</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="csddlvtype"
                                ErrorMessage="Select Visitor Type" InitialValue="-1">*</asp:RequiredFieldValidator></td>
                        <td style="height: 26px; background-color: lightgoldenrodyellow">
                            <asp:Label ID="Label7" runat="server" Text="Visitor Department(s)"></asp:Label></td>
                        <td style="width: 210px; height: 26px">
                            &nbsp;<asp:ListBox ID="cslstvdept" runat="server" DataSourceID="Sqldept" DataTextField="deptcode"
                                DataValueField="departmentcode" SelectionMode="Multiple">
                                <asp:ListItem Selected="True">select</asp:ListItem>
                            </asp:ListBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="cslstvdept"
                                ErrorMessage="Select Visitor Dept" InitialValue="">*</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="height: 26px; background-color: lightgoldenrodyellow">
                            <asp:Label ID="Label4" runat="server" Text="Person Incharge"></asp:Label></td>
                        <td style="width: 299px; height: 26px">
                            <asp:TextBox ID="cstxtpic" runat="server"></asp:TextBox></td>
                        <td style="height: 26px; background-color: lightgoldenrodyellow">
                            &nbsp;</td>
                        <td style="width: 210px; height: 26px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="height: 26px; background-color: lightgoldenrodyellow">
                            <asp:Label ID="Label8" runat="server" Text="company Name"></asp:Label></td>
                        <td style="width: 299px; height: 26px">
                            <asp:TextBox ID="cstxtcompname" runat="server"></asp:TextBox></td>
                        <td style="height: 26px; background-color: lightgoldenrodyellow">
                            <asp:Label ID="Label9" runat="server" Text="Visitor Name"></asp:Label></td>
                        <td style="width: 210px; height: 26px">
                            <asp:TextBox ID="cstxtvname" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="height: 26px; background-color: lightgoldenrodyellow">
                            <asp:Label ID="Label10" runat="server" Text="No. of Person (s)" Width="93px"></asp:Label></td>
                        <td style="width: 299px; height: 26px">
                            <asp:TextBox ID="cstxtnop" runat="server"></asp:TextBox>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="cstxtnop"
                                ErrorMessage="Enter No.Of Person">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="cstxtnop"
                                ErrorMessage="Enter only Numbers" ValidationExpression="[0-9]*"></asp:RegularExpressionValidator>
                        </td>
                        <td style="height: 26px; background-color: lightgoldenrodyellow">
                            <asp:Label ID="Label11" runat="server" Text="contact No."></asp:Label></td>
                        <td style="width: 210px; height: 26px">
                            <asp:TextBox ID="cstxtcontact" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="height: 26px; background-color: lightgoldenrodyellow">
                            <asp:Label ID="Label19" runat="server" Text="Arrival Date"></asp:Label></td>
                        <td style="width: 299px; height: 26px">
                            <asp:TextBox ID="cstxtarrival" runat="server" Width="126px"></asp:TextBox>
                            <asp:Image ID="Imgcal2" runat="server" ImageUrl="/images/Calender.png" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="cstxtarrival"
                                ErrorMessage="Enter arrival Date">*</asp:RequiredFieldValidator>
                            &nbsp;
                        </td>
                        <td style="height: 26px; background-color: lightgoldenrodyellow">
                            <asp:Label ID="Label20" runat="server" Text="Arrival Time" Width="80px"></asp:Label></td>
                        <td style="width: 210px; height: 26px">
                            <asp:DropDownList ID="csddlhr" runat="server">
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem>8</asp:ListItem>
                                <asp:ListItem>9</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>11</asp:ListItem>
                                <asp:ListItem>12</asp:ListItem>
                            </asp:DropDownList>:<asp:DropDownList ID="csddlmin" runat="server">
                                <asp:ListItem Value="00"></asp:ListItem>
                                <asp:ListItem>15</asp:ListItem>
                                <asp:ListItem>30</asp:ListItem>
                                <asp:ListItem>45</asp:ListItem>
                            </asp:DropDownList>&nbsp;<asp:DropDownList ID="csddlam" runat="server">
                                <asp:ListItem Value="AM">am</asp:ListItem>
                                <asp:ListItem Value="PM">pm</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td style="height: 26px; background-color: lightgoldenrodyellow">
                            <asp:Label ID="Label12" runat="server" Text="Purpose"></asp:Label></td>
                        <td style="width: 299px; height: 26px">
                            <asp:TextBox ID="cstxtpurpose" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                        <td style="height: 26px; background-color: lightgoldenrodyellow">
                            <asp:Label ID="Label13" runat="server" Text="Reception area"></asp:Label></td>
                        <td style="width: 210px; height: 26px">
                            <asp:TextBox ID="cstxtrecp" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="height: 26px; background-color: lightgoldenrodyellow">
                            <asp:Label ID="Label14" runat="server" Text="Taxi Booking"></asp:Label></td>
                        <td style="vertical-align: baseline; width: 299px; height: 13px; text-align: left">
                            <asp:RadioButtonList ID="csrdtaxi" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                            </asp:RadioButtonList></td>
                        <td style="height: 26px; background-color: lightgoldenrodyellow">
                            <asp:Label ID="Label16" runat="server" Text="Hotel Booking"></asp:Label></td>
                        <td style="vertical-align: baseline; width: 210px; height: 13px; text-align: left">
                            <asp:RadioButtonList ID="csrdhotel" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                            </asp:RadioButtonList></td>
                    </tr>
                    <tr>
                        <td style="height: 26px; background-color: lightgoldenrodyellow">
                            &nbsp;<asp:Label ID="lbltaxi" runat="server" Text="Taxi cost" Visible="False"></asp:Label></td>
                        <td style="width: 299px">
                            <asp:DropDownList ID="csddltaxi" runat="server" Visible="False">
                                <asp:ListItem Selected="True" Value="select">-select-</asp:ListItem>
                                <asp:ListItem>Company</asp:ListItem>
                                <asp:ListItem>Customer</asp:ListItem>
                            </asp:DropDownList></td>
                        <td style="height: 26px; background-color: lightgoldenrodyellow">
                            <asp:Label ID="lblhotel" runat="server" Text="Hotel cost" Visible="False"></asp:Label></td>
                        <td style="width: 210px; height: 26px">
                            <asp:DropDownList ID="ccddlhotel" runat="server" Visible="False">
                                <asp:ListItem>Company</asp:ListItem>
                                <asp:ListItem>Customer</asp:ListItem>
                                <asp:ListItem Selected="True" Value="select">-select-</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td style="height: 26px; background-color: lightgoldenrodyellow">
                            &nbsp;<asp:Label ID="cslblstatus" runat="server" Text="Status" Visible="False"></asp:Label></td>
                        <td style="width: 299px; height: 47px">
                            &nbsp;<asp:RadioButtonList ID="csrdstatus" runat="server" RepeatDirection="Horizontal"
                                Visible="False">
                                <asp:ListItem Value="S">Scheduled</asp:ListItem>
                                <asp:ListItem Value="CANCEL">Cancel</asp:ListItem>
                            </asp:RadioButtonList></td>
                        <td style="height: 26px; background-color: lightgoldenrodyellow">
                            <asp:Label ID="lblhotelname" runat="server" Text="Hotel Name" Visible="False"></asp:Label></td>
                        <td style="width: 210px; height: 47px">
                            <asp:TextBox ID="cstxthotel" runat="server" Visible="False"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="4" style="vertical-align: middle; height: 47px; text-align: center">
                            &nbsp;
                            <asp:Button ID="csbtnsave" runat="server" SkinID="buttonskin1" Text="SAVE" />
                            <asp:Button ID="csbtnupd" runat="server" SkinID="buttonskin1" Text="UPDATE" Visible="False" />
                            &nbsp;&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
                            <asp:HiddenField ID="hidrno" runat="server" Visible="False" />
                            <cc1:calendarextender id="cce2" runat="server" cssclass="cal_Theme1" format="dd/MM/yy"
                                popupbuttonid="cstxtarrival" targetcontrolid="cstxtarrival"></cc1:calendarextender>
                            <cc1:calendarextender id="CalendarExtender1" runat="server" cssclass="cal_Theme1"
                                format="dd/MM/yy" popupbuttonid="Imgcal2" targetcontrolid="cstxtarrival"></cc1:calendarextender>
                            <asp:SqlDataSource ID="Sqldept" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECT distinct [departmentcode] +' -' + [departmentname]  as deptcode ,departmentcode  FROM [department]">
                            </asp:SqlDataSource>
</asp:Content>
