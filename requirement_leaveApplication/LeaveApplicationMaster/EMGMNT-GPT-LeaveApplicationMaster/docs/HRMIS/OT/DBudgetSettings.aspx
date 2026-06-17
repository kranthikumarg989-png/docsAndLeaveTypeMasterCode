<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="DBudgetSettings.aspx.vb" Inherits="E_Management.DBudgetSettings" 
    title="OT Budget Setting" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
  <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="16" style="height: 16px">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" style="height: 16px; width: 1262px;">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 24px; height: 16px;">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif" style="height: 622px" width="16">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" style="height: 622px; width: 1262px;" valign="top">

<table style="width: 1000px; height: 145px" id="TABLE2">
        <tr>
            <td style="width: 176px; height: 249px;" valign="top" align="center">
                <table id="TABLE1" onclick="return TABLE1_onclick()" style="width: 500px; height: 120px" border="1" cellpadding="1" cellspacing="1">
                    <tr>
                        <td colspan="2" style="height: 12px" valign="top" align="left">
                        <asp:Label ID="Label1" runat="server" Font-Underline="True" ForeColor="Maroon" Text="DAILY OT BUDGET SETTINGS"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 96px; background-color: beige; height: 26px;" valign="top" align="left">
                            <asp:Label ID="frmdt" runat="server" Text="Date"></asp:Label></td>
                        <td style="width: 382px;" valign="top" align="left">
                    
                        <asp:TextBox ID="txtfrom" runat="server" Width="180px"></asp:TextBox>&nbsp;
                        <cc1:calendarextender id="ccelt" runat="server" cssclass="cal_Theme1" format="dd/MM/yyyy"
                                            popupbuttonid="txtfrom" targetcontrolid="txtfrom"></cc1:calendarextender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtfrom"
                                    ErrorMessage="Please Select Start Date"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 96px; background-color: beige; height: 26px;" valign="top" align="left">
                            &nbsp;<asp:Label ID="todt" runat="server" Text="To" Visible="False"></asp:Label></td>
                        <td style="width: 382px;" valign="top" align="left">
                           
                        <asp:TextBox ID="txtto" runat="server"  Width="180px" Visible="False"></asp:TextBox>
                                        <cc1:calendarextender id="ccelf" runat="server" cssclass="cal_Theme1" format="dd/MM/yyyy"
                                            popupbuttonid="txtto" targetcontrolid="txtto"></cc1:calendarextender>
                            &nbsp; &nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 96px; background-color: beige; height: 26px;" valign="top" align="left">
                            <asp:Label ID="category" runat="server" Text="Category"></asp:Label></td>
                        <td style="width: 382px;" valign="top" align="left">
                            <asp:DropDownList ID="cat" runat="server" Width="185px">
                                <asp:ListItem Selected="True" Value="-1">--Select--</asp:ListItem>
                                <asp:ListItem>Staff</asp:ListItem>
                                <asp:ListItem>Operator</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="cat"
                                    ErrorMessage="Please Select Category" InitialValue="-1"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 96px; background-color: beige; height: 13px;" valign="top" align="left">
                            <asp:Label ID="sm" runat="server" Text="Section Master"></asp:Label></td>
                        <td style="width: 382px; height: 13px;" valign="top" align="left">
                        <asp:DropDownList ID="sec" runat="server" DataSourceID="SqlDataSource3"
                                DataTextField="section" DataValueField="sectioncode" Width="185px" AppendDataBoundItems="True">
                                <asp:ListItem Selected="True" Value="-1">--Select--</asp:ListItem>
                                </asp:DropDownList>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="sec"
                                    ErrorMessage="Please Select Section Master" InitialValue="-1"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 96px; background-color: beige; height: 26px;" valign="top" align="left">
                            <asp:Label ID="MH" runat="server" Text="Maximum Hours"></asp:Label></td>
                        <td style="width: 382px" valign="top" align="left">
                            <asp:TextBox ID="maxhrs" runat="server" MaxLength="6" Width="185px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="maxhrs"
                                    ErrorMessage="Please Mention Maximum OT Hours"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" Width="117px" 
                                    ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$" ErrorMessage="only Numbers!" 
                                    ControlToValidate="maxhrs"></asp:RegularExpressionValidator></td></tr>
                    <tr>
                        <td style="width: 96px" valign="top">
                            <asp:Label ID="lbledit" runat="server" Text="-" Visible="False" Width="32px"></asp:Label></td>
                        <td align="left" style="width: 382px" valign="top">
                <asp:Button ID="SubmitOT" runat="server" Text="SUBMIT" />&nbsp; &nbsp;<asp:Button ID="cancelOT" runat="server" Text="CANCEL" /></td>
                    </tr>
                </table>
                <br />
                <asp:Label ID="LblMsg" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Green"></asp:Label>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECT [sectioncode] + '-' + sectionname as section, sectioncode FROM [sectionmaster]"></asp:SqlDataSource>
                &nbsp;
                </td>
            <td style="width: 6100px; height: 249px;">
                <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource4" AutoGenerateColumns="False" DataKeyNames="id" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" PageSize="25">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id" />
                        <asp:BoundField DataField="OTdate" HeaderText="OTdate" SortExpression="OTdate" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
                        <asp:BoundField DataField="Cdate" HeaderText="creatddate" SortExpression="Cdate" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
                        <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
                        <asp:BoundField DataField="sect" HeaderText="sect" SortExpression="sect" />
                        <asp:BoundField DataField="MaxHours" HeaderText="MaxHours" SortExpression="MaxHours" />
                        <asp:TemplateField HeaderText="Status" SortExpression="status">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" CommandArgument='<%# Eval("id", "{0}") %>'
                                                Text='<%# Eval("status") %>'> </asp:Label>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandArgument='<%# Eval("id", "{0}") %>'
                                                ForeColor="#0000C0" OnCommand="getOTdata" Text='<%# Eval("status") %>'></asp:LinkButton>
                                                                                   </ItemTemplate>
                                    </asp:TemplateField>
                    </Columns>
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT tbl_MaxOTSettingDaily.id, tbl_MaxOTSettingDaily.OTdate, tbl_MaxOTSettingDaily.Cdate, tbl_MaxOTSettingDaily.Category, tbl_MaxOTSettingDaily.sect, tbl_MaxOTSettingDaily.MaxHours, tbl_MaxOTSettingDaily.status FROM tbl_MaxOTSettingDaily INNER JOIN sectionmaster ON tbl_MaxOTSettingDaily.sect = sectionmaster.sectioncode INNER JOIN department ON sectionmaster.departmentcode = department.departmentcode WHERE (tbl_MaxOTSettingDaily.status = 'S') ORDER BY tbl_MaxOTSettingDaily.id desc">
                </asp:SqlDataSource>
                <asp:AccessDataSource ID="DispCompForm" runat="server"></asp:AccessDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT [sectioncode] FROM [sectionmaster]"></asp:SqlDataSource>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
            </td>
        </tr>
    </table>
    
       </td>
            <td background="../../images/cen_rig.gif" style="width: 24px">
                <img height="11" src="../../images/cen_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td height="16" width="16">
                <img height="16" src="../../images/bot_lef.gif" width="16" /></td>
            <td background="../../images/bot_mid.gif" height="16" style="width: 1262px">
                <img height="16" src="../../images/bot_mid.gif" width="16" /></td>
            <td height="16" style="width: 24px">
                <img height="16" src="../../images/bot_rig.gif" width="24" /></td>
        </tr>
    </table>
   
</asp:Content>