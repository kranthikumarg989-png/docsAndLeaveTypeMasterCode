<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="NewJS.aspx.vb" Inherits="E_Management.NewJS" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@Import Namespace="System" %>
<%@Import Namespace="System.Data" %>
<%@Import Namespace="System.Data.Common" %>
<%@Import Namespace="System.Diagnostics" %>
<%@import Namespace="System.Data.SqlClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<table cellpadding=0 cellspacing=0>
                    <tr>
                        <td style="width: 16px; height: 16px">
                            <IMG height="16" src="../../images/top_lef.gif" width="16"></td>
                        <td background="../../images/top_mid.gif" style="height: 16px; width: 650px;">
                            <IMG height="16" src="../../images/top_mid.gif"width="16"></td>
                        <td style="width: 24px; height: 16px;">
                            <IMG height="16" src="../../images/top_rig.gif" width="24"></td>
                    </tr>
                    <tr>
                        <td background="../../images/cen_lef.gif" style="width: 16px; height: 248px;">
                        <IMG height="11" src="../../images/cen_lef.gif" width="16"></td>
                        <td vAlign="top" bgColor="#ffffff" style="width: 650px">
                            <table>
                                <tr>
                                    <td align="center" class="td_head" colspan="4" style="height: 17px" valign="middle">
                                        JOB PURPOSE ASSIGNMENT</td>
                                </tr>
                                <tr>
                                    <td style="height: 17px; background-color: beige; width: 80px;">
                                        EmpCode</td>
                                    <td style="width: 196px; background-color: beige;">
                                        <asp:Label ID="lblempcode" runat="server"></asp:Label>&nbsp;</td>
                                    <td style="background-color: beige; width: 86px;">
                                        EmpName</td>
                                    <td style="background-color: beige; width: 349px;">
                                        <asp:Label ID="lblename" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="background-color: beige; width: 80px;">
                                        Department</td>
                                    <td style="background-color: beige; width: 196px;">
                                        <asp:Label ID="lbldept" runat="server"></asp:Label></td>
                                    <td style="background-color: beige; width: 86px;">
                                        Section</td>
                                    <td style="background-color: beige; width: 349px;">
                                        <asp:Label ID="lblsect" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="background-color: beige; width: 80px;">
                                        Designation</td>
                                    <td style="background-color: beige; width: 196px;">
                                        <asp:Label ID="lbldesig" runat="server"></asp:Label></td>
                                    <td style="background-color: beige; width: 86px;">
                                        JobCode</td>
                                    <td style="background-color: beige; width: 349px;">
                                        <asp:Label ID="lblcode" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 80px; height: 17px; background-color: beige">
                                        Job Purpose</td>
                                    <td colspan="3" style="width: 66px; background-color: beige">
                                        <asp:Label ID="lblpurpose" runat="server" Width="512px"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="td_head" style="height: 14px">JS TIME LINE &amp; KEY RESULT</td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="height: 14px">
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="fs" />
                                    </td>
                                </tr>
                                <tr                                >
                                    <td  style="height: 16px; background-color: beige; width: 80px;">
                                        Revision No:</td>
                                    <td  style="height: 16px; background-color: beige; width: 196px;">
                                        <asp:Label ID="txtrevno" runat="server"></asp:Label>
                                    </td>
                                    <td  style="height: 16px; background-color: beige; width: 86px;">Time Period</td>
                                    <td  style="height: 16px; background-color: beige; width: 349px;">
                                           <asp:TextBox ID="txtfrom" runat="server"  Width="62px"></asp:TextBox>  
                                            <asp:RequiredFieldValidator ID="df" runat="server" ControlToValidate="txtfrom"
                                            ErrorMessage="Select Date" ValidationGroup="fs">*</asp:RequiredFieldValidator>~
                                           <asp:TextBox ID="txtto" runat="server"  Width="65px"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="dff" runat="server" ControlToValidate="txtto"
                                            ErrorMessage="Select Date" ValidationGroup="fs">*</asp:RequiredFieldValidator></td>
                                           <cc1:CalendarExtender ID="ccelt"  runat="server"
                                             TargetControlID="txtfrom" Format = "dd/MM/yy"           
                                             CssClass="cal_Theme1"  
                                             PopupButtonID="txtfrom" />
                                           <cc1:CalendarExtender ID="ccelf"  runat="server"
                                             TargetControlID="txtto" Format = "dd/MM/yy"           
                                             CssClass="cal_Theme1"  
                                             PopupButtonID="txtto" />
                                       
                                </tr>
                                <tr>
                                    <td style="width: 80px; height: 16px; background-color: beige">
                                        Item Pending/Handover</td>
                                    <td colspan="3" style="height: 16px; background-color: beige">
                                        <asp:TextBox ID="txtitem" runat="server" TextMode="MultiLine" Width="281px"></asp:TextBox><br />
                                        (use comma as seperator for each Item)</td>
                                </tr>
                                <tr>
                                    <td colspan="1" style="height: 16px; background-color: beige; width: 80px;">
                                        &nbsp;Key Result</td>
                                        <td colspan="3" style="height: 16px; background-color: beige">
                                        <asp:TextBox ID="txtkey" runat="server" TextMode="MultiLine" Width="279px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtkey"
                                                ErrorMessage="Enter Key Result" ValidationGroup="ks"></asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="height: 16px; background-color: beige" align="right">
                                    <asp:Button ID="Button1" runat="server" SkinID="buttonskin1" Text="Add Key Result" Width="195px" ValidationGroup="ks" /></td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="height: 10px; background-color: beige">
                                        Key Results</td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="height: 16px; background-color: beige">
                                        <asp:ListBox ID="lstgoal" runat="server" DataSourceID="SqlDataSource1" DataTextField="man_keyresult"
                                            DataValueField="rno" Rows="5" Width="639px"></asp:ListBox></td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="height: 15px; background-color: beige">
                                        <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" ImageUrl="~/images/del.jpg"
                                            Width="26px" Height="16px" />
                                        Select a Key result and Click here to Delete.</td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="4" style="height: 17px" class="td_head">
                                        &nbsp;GOAL ALLIGNMENT</td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="4" style="height: 17px">
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                            DataSourceID="sqlgoal" ForeColor="#333333" GridLines="None" ShowHeader="False">
                                            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                            <Columns>
                                               <asp:BoundField DataField="sno" SortExpression="sno" />
                                                <asp:BoundField DataField="goalalign" SortExpression="goalalign" />
                                              
                                            </Columns>
                                            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
                                        <asp:SqlDataSource ID="sqlgoal" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                            SelectCommand="SELECT [goalalign],sno FROM [man_goalalign] WHERE ([curyear] = @curyear) order by sno">
                                            <SelectParameters>
                                                <asp:Parameter DefaultValue="Y" Name="curyear" Type="String" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="4" style="height: 17px" class="td_head">
                                        TECHNICAL SKILLS
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="4" style="height: 17px; background-color: beige">
                                        <asp:CheckBoxList ID="cbtechnical" runat="server" DataSourceID="sqltechnical" DataTextField="skill"
                                            DataValueField="skill" AppendDataBoundItems="false" RepeatColumns="3" RepeatDirection="Horizontal">
                                        </asp:CheckBoxList><asp:SqlDataSource ID="sqltechnical" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                            SelectCommand="SELECT [skill] FROM [man_skillmatch] WHERE (([skilltitle] = @skilltitle) AND ([jobcode] = @jobcode))">
                                            <SelectParameters>
                                                <asp:Parameter DefaultValue="Technical Skill" Name="skilltitle" Type="String" />
                                                <asp:ControlParameter ControlID="lblcode" Name="jobcode" PropertyName="Text" Type="String" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="td_head" colspan="4" style="height: 17px">
                                        BEHAVIOUR</td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="4" style="height: 17px; background-color: beige;">
                                        <asp:CheckBoxList ID="cbbehavior" runat="server" DataSourceID="SQLBEHAVIOUR" DataTextField="skill"
                                            DataValueField="skill" RepeatColumns="3" RepeatDirection="Horizontal">
                                        </asp:CheckBoxList><asp:SqlDataSource ID="SQLBEHAVIOUR" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                            SelectCommand="SELECT [skill] FROM [man_skillmatch] WHERE (([jobcode] = @jobcode) AND ([skilltitle] = @skilltitle))">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="lblcode" Name="jobcode" PropertyName="Text" Type="String" />
                                                <asp:Parameter DefaultValue="Behavior" Name="skilltitle" Type="String" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="4" style="height: 17px">
                                        <asp:Button ID="btnsave" runat="server" SkinID="buttonskin1" Text="Save" ValidationGroup="fs" /></td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="4" style="height: 17px">
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                            SelectCommand="SELECT * FROM [man_temp_keygoal] WHERE ([empcode] = @empcode)">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="lblempcode" Name="empcode" PropertyName="Text" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                    </td>
                                </tr>
                            </table>
                      
                      
                        </td>
                    <td background="../../images/cen_rig.gif" style="width: 25px; height: 248px;">
                        <IMG height="11" src="../../images/cen_rig.gif" width="24"></td>
                </tr>
                <tr>
                    <td width="16" height="16">
                        <IMG height="16" src="../../images/bot_lef.gif" width="16"></td>
                    <td background="../../images/bot_mid.gif" height="16" style="width: 650px">
                        <IMG height="16" src="../../images/bot_mid.gif" width="16"></td>
                    <td height="16" style="width: 25px">
                        <IMG height="16" src="../../images/bot_rig.gif" width="24"></td>
                </tr>
            </table>
</asp:Content>
