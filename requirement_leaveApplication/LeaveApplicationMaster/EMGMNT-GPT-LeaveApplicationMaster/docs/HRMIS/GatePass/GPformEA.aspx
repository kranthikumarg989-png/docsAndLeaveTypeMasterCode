<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="GPformEA.aspx.vb" Inherits="E_Management.GPformEA" 
    title="GATEPASS APPLICATION FORM" %>
    <%@Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
   <table cellpadding="0" cellspacing="0">
        <tr>
            <td width="16" style="height: 16px">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" style="height: 16px">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 24px; height: 16px;">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif" style="height: 622px" width="16">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" style="height: 622px" valign="top">
   <table>
        <tr>
            <td style="vertical-align: top; text-align: left">
    <table width="100%" border="1" cellpadding="1" cellspacing="1">
        <tr>
            <td class="td_head" colspan="2" style="border-bottom: 1px inset; height: 18px">
                Fill in all the required fields</td>
            <asp:ValidationSummary ID="ValidationSummary2" runat="server" DisplayMode="BulletList"
                EnableClientScript="true" HeaderText="You must enter a value in the following fields:" />
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblmsg" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 129px">
                GatePass Num</td>
            <td>
                <asp:Label ID="gppassnum" runat="server" BackColor="#FFFFC0" Font-Size="Medium"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 129px">
                <asp:Label ID="Label1" runat="server" Text="GatePass Type"></asp:Label>
            </td>
            <td>
                 <asp:DropDownList ID="ddltype" runat="server" AutoPostBack="True">
                    <asp:ListItem Value="OFFICIAL">Official</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 129px">
                Purpose</td>
            <td>
                <asp:TextBox ID="txtpurpose" runat="server" Height="67px" Rows="5" Width="205px" Enabled="False">To bring EA children from School</asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtpurpose"
                    ErrorMessage="Enter the Purpose of gatepass!!" Text="*"></asp:RequiredFieldValidator></td>
        </tr>
        <tr style="color: #000000">
            <td class="td_head" colspan="2">
                Contact Details</td>
        </tr>
        <tr>
            <td style="width: 129px">
                Location</td>
            <td>
                <asp:TextBox ID="txtlocation" runat="server">Melaka</asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 129px; height: 21px">
                Phone Number</td>
            <td>
                <asp:TextBox ID="txtph" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 129px">
                Vehicle Number</td>
            <td>
                <asp:DropDownList ID="txtvehicle" runat="server" DataSourceID="SqlDataSource1" DataTextField="tvehicleno"
                    DataValueField="tvehicleno" AppendDataBoundItems="True" AutoPostBack="True">
                    <asp:ListItem Selected="True" Value="-1">--Select--</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 129px">
                Key in vehicle number(if doesnot exist above)</td>
            <td>
                <asp:TextBox ID="txtvehicle2" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="td_head" colspan="2">
                Out and IN Details</td>
        </tr>
        <tr>
            <td>
                Date Out</td>
            <td>
                <asp:TextBox ID="dategp" runat="server"></asp:TextBox>
                <asp:Image ID="imgcal" runat="server" ImageUrl="/images/Calender.png" />&nbsp;&nbsp;&nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="dategp"
                    ErrorMessage="Enter GatePass Date!!" Text="*" Width="12px"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 129px">
                Time Out (hrs:min)</td>
            <td>
                <asp:DropDownList ID="ddlohr" runat="server">
                    <asp:ListItem>01</asp:ListItem>
                    <asp:ListItem>02</asp:ListItem>
                    <asp:ListItem>03</asp:ListItem>
                    <asp:ListItem>04</asp:ListItem>
                    <asp:ListItem>05</asp:ListItem>
                    <asp:ListItem>06</asp:ListItem>
                    <asp:ListItem>07</asp:ListItem>
                    <asp:ListItem>08</asp:ListItem>
                    <asp:ListItem>09</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                    <asp:ListItem Selected="True">-</asp:ListItem>
                </asp:DropDownList><asp:DropDownList ID="ddlomin" runat="server">
                    <asp:ListItem>00</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>45</asp:ListItem>
                    <asp:ListItem Selected="True">-</asp:ListItem>
                </asp:DropDownList>&nbsp;
                <asp:DropDownList ID="ddout" runat="server">
                    <asp:ListItem Value="AM">am</asp:ListItem>
                    <asp:ListItem Value="PM">pm</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlohr"
                    ErrorMessage="Select Time Out" InitialValue="-">!</asp:RequiredFieldValidator><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlomin" ErrorMessage="Select Time Out"
                        InitialValue="-">!</asp:RequiredFieldValidator>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 129px">
                Time In(hrs:min)</td>
            <td>
                <asp:DropDownList ID="ddlihr" runat="server">
                    <asp:ListItem>01</asp:ListItem>
                    <asp:ListItem>02</asp:ListItem>
                    <asp:ListItem>03</asp:ListItem>
                    <asp:ListItem>04</asp:ListItem>
                    <asp:ListItem>05</asp:ListItem>
                    <asp:ListItem>06</asp:ListItem>
                    <asp:ListItem>07</asp:ListItem>
                    <asp:ListItem>08</asp:ListItem>
                    <asp:ListItem>09</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                    <asp:ListItem Selected="True">-</asp:ListItem>
                </asp:DropDownList><asp:DropDownList ID="ddlimin" runat="server">
                    <asp:ListItem>00</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>45</asp:ListItem>
                    <asp:ListItem Selected="True">-</asp:ListItem>
                </asp:DropDownList>
                &nbsp;<asp:DropDownList ID="ddin" runat="server">
                    <asp:ListItem Value="AM">am</asp:ListItem>
                    <asp:ListItem Value="PM">pm</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlihr"
                    ErrorMessage="Select Time In" InitialValue="-">!</asp:RequiredFieldValidator><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlimin" ErrorMessage="Select Time In"
                        InitialValue="-">!</asp:RequiredFieldValidator>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" style="vertical-align: middle; text-align: center" valign="middle">
                <asp:Button ID="btnupdategp" runat="server" SkinID="buttonskin1" Text="UPDATE" />
                &nbsp;
                <asp:Button ID="txtsavegp" runat="server" SkinID="buttonskin1" Text="SAVE" />
                &nbsp; &nbsp;
            </td>
        </tr>
    </table>
                &nbsp;&nbsp;
            </td>
            <td style="vertical-align: top; text-align: left">
                <asp:Label ID="Label2" runat="server" Font-Underline="True" ForeColor="#C00000" Text="MY GATEPASS HISTORY"></asp:Label><br />
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CellPadding="4" DataSourceID="sqlgatepass" ForeColor="#333333"
                    GridLines="None">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Passno" HeaderText="Passno" SortExpression="Passno" />
                        <asp:BoundField DataField="date1" DataFormatString="{0:dd/MM/yy}" HeaderText="Applied on"  HtmlEncode="false" 
                            SortExpression="date1" />
                        <asp:BoundField DataField="purpose" HeaderText="Purpose" SortExpression="purpose" />
                        <asp:BoundField DataField="outdate" DataFormatString="{0:dd/MM/yy}" HeaderText="OutDate"  HtmlEncode="false" 
                            SortExpression="outdate" />
                        <asp:BoundField DataField="outtime" DataFormatString="{0:t}" HeaderText="Time out"  HtmlEncode="false" 
                            SortExpression="outtime" />
                        <asp:BoundField DataField="intime" DataFormatString="{0:t}" HeaderText="Time In"  HtmlEncode="false" 
                            SortExpression="intime" />
                        <asp:BoundField DataField="gatepasstype" HeaderText="Passtype" SortExpression="gatepasstype" />
                        <asp:TemplateField HeaderText="Status" SortExpression="status">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" CommandArgument='<%# Eval("passno", "{0}") %>'
                                    Text='<%# Eval("status") %>'> </asp:Label>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("passno", "{0}") %>'
                                    ForeColor="#0000C0" OnCommand="mpop" Text='<%# Eval("status") %>' CausesValidation=False ></asp:LinkButton>
                                <asp:LinkButton ID="LinkButton5" runat="server" CommandArgument='<%# Eval("passno", "{0}") %>'
                                    ForeColor="RED" OnCommand="gpcancel" Text="CANCEL" CausesValidation=False ></asp:LinkButton>
                                <cc1:ConfirmButtonExtender ID="confirmgpcancel" runat="server" ConfirmOnFormSubmit="true"
                                    ConfirmText="Are you sure you want to cancel the GatePass" TargetControlID="LinkButton5">
                                </cc1:ConfirmButtonExtender>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                &nbsp;
            </td>
        </tr>
    </table>
                <asp:SqlDataSource ID="sqlgatepass" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    OnSelecting="sqlgatepass_Selecting" SelectCommand="SELECT [passno], [date1], [purpose], [outdate], [outtime], [indate], [intime], [location], [gatepasstype] ,[status] FROM [staffgatepass] WHERE (([outdate] >= @outdate) AND ([outdate] <= @outdate2) AND ([empcode] = @empcode) and status <> 'CANCELLED')  order by passno desc">
                    <SelectParameters>
                        <asp:Parameter Name="empcode" />
                        <asp:Parameter Name="outdate" />
                        <asp:Parameter Name="outdate2" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <cc1:calendarextender id="CalendarExtender2" runat="server" cssclass="cal_Theme1"
                    format="dd/MM/yy" popupbuttonid="imgcal" targetcontrolid="dategp"></cc1:calendarextender>
                <cc1:calendarextender id="cce1" runat="server" cssclass="cal_Theme1" format="dd/MM/yy"
                    popupbuttonid="dategp" targetcontrolid="dategp"></cc1:calendarextender>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT [tvehicleno] FROM [trans_ownvehicle] WHERE ([tvehicleno] IS NOT NULL) ORDER BY [tvehicleno] DESC">
                </asp:SqlDataSource>
        <td background="../../images/cen_rig.gif" style="width: 24px">
                <img height="11" src="../../images/cen_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td height="16" width="16">
                <img height="16" src="../../images/bot_lef.gif" width="16" /></td>
            <td background="../../images/bot_mid.gif" height="16">
                <img height="16" src="../../images/bot_mid.gif" width="16" /></td>
            <td height="16" style="width: 24px">
                <img height="16" src="../../images/bot_rig.gif" width="24" /></td>
        </tr>
    </table>

</asp:Content>
