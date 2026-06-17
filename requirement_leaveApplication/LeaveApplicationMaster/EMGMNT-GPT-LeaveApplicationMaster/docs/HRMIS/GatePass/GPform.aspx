<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/NewEMS.Master" CodeBehind="GPform.aspx.vb" Inherits="E_Management.GPform" 
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
    <table width="100%" border="1" cellpadding="0" cellspacing="0">
        <tr>
            <td  class="bg-primary" colspan="2" style="text-align: center" >
                  <span style="font-size: 12pt">GATEPASS APPLICATION</span></td>
            <asp:ValidationSummary ID="ValidationSummary2" runat="server" DisplayMode="BulletList"
                EnableClientScript="true" HeaderText="You must enter a value in the following fields:" />
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblmsg" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 129px" bgcolor="#b9d1ea">
                <asp:Label ID="Label13" runat="server" BackColor="#B9D1EA" CssClass="form-control"
                    Width="175px" Height="20px">GatePass Num</asp:Label></td>
            <td>
                <asp:Label ID="gppassnum" runat="server" BackColor="ActiveCaption" Font-Size="11pt" CssClass="form-control" Width="200px" Font-Bold="True" ForeColor="Black" Height="20px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 129px" bgcolor="#b9d1ea">
                <asp:Label ID="Label12" runat="server" BackColor="#B9D1EA" CssClass="form-control"
                    Width="175px" Height="20px">GatePass Type</asp:Label></td>
            <td>
                 <asp:DropDownList ID="ddltype" runat="server" AutoPostBack="True" CssClass="form-control" Width="200px" Height="20px">
                    <asp:ListItem Value="PERSONAL">Personal</asp:ListItem>
                    <asp:ListItem Value="OFFICIAL">Official</asp:ListItem>
                    <asp:ListItem Value="Prayers">Islamic Prayers</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 129px" bgcolor="#b9d1ea">
                <asp:Label ID="Label11" runat="server" BackColor="#B9D1EA" CssClass="form-control"
                    Width="175px" Height="20px">Purpose</asp:Label></td>
            <td>
                <asp:TextBox ID="txtpurpose" runat="server" Height="35px" Rows="5" Width="200px" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtpurpose"
                    ErrorMessage="Enter the Purpose of gatepass!!" Text="*"></asp:RequiredFieldValidator></td>
        </tr>
        <tr style="color: #000000">
            <td class="bg-primary" colspan="2" style="height: 23px; text-align: center;">
                <span style="font-size: 12pt">Contact Details</span></td>
        </tr>
        <tr>
            <td style="width: 129px" bgcolor="#b9d1ea">
                <asp:Label ID="Label10" runat="server" BackColor="#B9D1EA" CssClass="form-control"
                    Width="175px" Height="20px">Location</asp:Label></td>
            <td>
                <asp:TextBox ID="txtlocation" runat="server" CssClass="form-control" Width="200px" Height="20px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 129px; height: 21px" bgcolor="#b9d1ea">
                <asp:Label ID="Label9" runat="server" BackColor="#B9D1EA" CssClass="form-control"
                    Width="175px" Height="20px">Phone Number</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtph" runat="server" CssClass="form-control" Width="200px" Height="20px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 129px" bgcolor="#b9d1ea">
                <asp:Label ID="Label7" runat="server" BackColor="#B9D1EA" CssClass="form-control"
                    Width="175px" Height="20px">Vehicle Number</asp:Label></td>
            <td>
                <asp:DropDownList ID="txtvehicle" runat="server" DataSourceID="SqlDataSource1" DataTextField="tvehicleno"
                    DataValueField="tvehicleno" AppendDataBoundItems="True" AutoPostBack="True" CssClass="form-control" Width="200px" Height="20px">
                    <asp:ListItem Selected="True" Value="-1">--Select--</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 129px" bgcolor="#b9d1ea">
                <asp:Label ID="Label6" runat="server" BackColor="#B9D1EA" CssClass="form-control"
                    Width="175px" Height="35px">Key in vehicle number(if doesnot exist above)</asp:Label></td>
            <td>
                <asp:TextBox ID="txtvehicle2" runat="server" CssClass="form-control" Width="200px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="bg-primary" colspan="2" style="height: 18px; text-align: center;">
              <span style="font-size: 12pt">Out and IN Details</span> </td>
        </tr>
        <tr>
            <td bgcolor="#b9d1ea" style="height: 53px">
                <asp:Label ID="Label4" runat="server" BackColor="#B9D1EA" CssClass="form-control"
                    Width="175px" Height="20px">Date Out</asp:Label></td>
            <td style="height: 53px">
                <table>
                    <tr>
                        <td style="width: 100px">
                <asp:TextBox ID="dategp" runat="server" CssClass="form-control" Height="20px" Width="100px"></asp:TextBox></td>
                        <td style="width: 100px">
                <asp:Image ID="imgcal" runat="server" ImageUrl="/images/Calender.png" /></td>
                        <td style="width: 100px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="dategp"
                    ErrorMessage="Enter GatePass Date!!" Text="*" Width="12px"></asp:RequiredFieldValidator></td>
                    </tr>
                </table>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 129px" bgcolor="#b9d1ea">
                <asp:Label ID="Label3" runat="server" BackColor="#B9D1EA" CssClass="form-control"
                    Width="175px" Height="20px">Time Out (hrs:min)</asp:Label></td>
            <td>
                <table>
                    <tr>
                        <td style="width: 100px">
                <asp:DropDownList ID="ddlohr" runat="server" CssClass="form-control" Height="20px">
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
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlohr"
                    ErrorMessage="Select Time Out" InitialValue="-" CssClass="form-control" Height="20px" Width="30px">!</asp:RequiredFieldValidator></td>
                        <td style="width: 100px">
                            <asp:DropDownList ID="ddlomin" runat="server" CssClass="form-control" Height="20px">
                    <asp:ListItem>00</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>45</asp:ListItem>
                    <asp:ListItem Selected="True">-</asp:ListItem>
                </asp:DropDownList>
                            <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlomin" ErrorMessage="Select Time Out"
                        InitialValue="-" CssClass="form-control" Height="20px" Width="30px">!</asp:RequiredFieldValidator></td>
                        <td style="width: 100px">
                <asp:DropDownList ID="ddout" runat="server" CssClass="form-control" Height="20px">
                    <asp:ListItem Value="AM">am</asp:ListItem>
                    <asp:ListItem Value="PM">pm</asp:ListItem>
                </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddout"
                                CssClass="form-control" ErrorMessage="AM/PM ?" Height="20px" InitialValue="-"
                                Width="30px">!</asp:RequiredFieldValidator></td>
                    </tr>
                </table>
                &nbsp; &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 129px" bgcolor="#b9d1ea">
                <asp:Label ID="Label5" runat="server" BackColor="#B9D1EA" CssClass="form-control"
                    Text="Time In(hrs:min)&#13;&#10;" Width="175px" Height="20px"></asp:Label></td>
            <td>
                <table>
                    <tr>
                        <td style="width: 100px">
                <asp:DropDownList ID="ddlihr" runat="server" CssClass="form-control" Height="20px">
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
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlihr"
                    ErrorMessage="Select Time In" InitialValue="-" CssClass="form-control" Height="20px" Width="20px">!</asp:RequiredFieldValidator></td>
                        <td style="width: 100px">
                            <asp:DropDownList ID="ddlimin" runat="server" CssClass="form-control" Height="20px">
                    <asp:ListItem>00</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>45</asp:ListItem>
                    <asp:ListItem Selected="True">-</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlimin" ErrorMessage="Select Time In"
                        InitialValue="-" CssClass="form-control" Height="20px" Width="20px">!</asp:RequiredFieldValidator></td>
                        <td style="width: 100px">
                            <asp:DropDownList ID="ddin" runat="server" CssClass="form-control" Height="20px">
                    <asp:ListItem Value="AM">am</asp:ListItem>
                    <asp:ListItem Value="PM">pm</asp:ListItem>
                </asp:DropDownList>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator8"
                                runat="server" ControlToValidate="ddin" CssClass="form-control" ErrorMessage="AM/PM ?"
                                Height="20px" InitialValue="-" Width="20px">!</asp:RequiredFieldValidator></td>
                    </tr>
                </table>
                &nbsp; &nbsp; &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" style="vertical-align: middle; text-align: center" valign="middle">
                &nbsp;<table>
                    <tr>
                        <td style="width: 100px">
                <asp:Button ID="btnupdategp" runat="server" SkinID="buttonskin1" Text="UPDATE" CssClass="form-control" Width="150px" Height="35px" /></td>
                        <td style="width: 100px">
                <asp:Button ID="txtsavegp" runat="server" SkinID="buttonskin1" Text="SAVE" CssClass="form-control" Width="150px" Height="35px" /></td>
                    </tr>
                </table>
                &nbsp; &nbsp;
                &nbsp; &nbsp;
            </td>
        </tr>
    </table>
                &nbsp;&nbsp;
            </td>
            <td style="vertical-align: top; text-align: left">
                <table width="100%">
                    <tr>
                        <td class="bg-primary" style="text-align: center" >
             <span style="font-size: 12pt">MY GATEPASS HISTORY</span>
                <%--<asp:Label ID="Label2" runat="server" Font-Underline="True" ForeColor="#C00000" Text="MY GATEPASS HISTORY"></asp:Label>--%></td>
                    </tr>
                </table>
                <br />
                <asp:GridView CellSpacing=5 ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CellPadding="5" DataSourceID="sqlgatepass" ForeColor="#333333"
                    GridLines="None" CssClass="form-control" Font-Size="9pt">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Passno" HeaderText="Passno" SortExpression="Passno" />
                        <asp:BoundField DataField="date1" DataFormatString="{0:dd/MM/yy}" HeaderText="Applied on"  HtmlEncode="False" 
                            SortExpression="date1" />
                        <asp:BoundField DataField="purpose" HeaderText="Purpose" SortExpression="purpose" />
                        <asp:BoundField DataField="outdate" DataFormatString="{0:dd/MM/yy}" HeaderText="OutDate"  HtmlEncode="False" 
                            SortExpression="outdate" />
                        <asp:BoundField DataField="outtime" DataFormatString="{0:t}" HeaderText="Time out"  HtmlEncode="False" 
                            SortExpression="outtime" />
                        <asp:BoundField DataField="intime" DataFormatString="{0:t}" HeaderText="Time In"  HtmlEncode="False" 
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
