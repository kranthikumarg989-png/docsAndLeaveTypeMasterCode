<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="SkillMatch.aspx.vb" Inherits="E_Management.SkillMatch" 
    title="Skill Match" %>
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

<table id="TABLE2">
    <tr>
        <td align="center" colspan="1" valign="top" style="width: 956px">
                        <asp:Label ID="Label1" runat="server" Font-Underline="True" ForeColor="Maroon" Text="MANPOWER SKILL MATCH"></asp:Label></td>
    </tr>
        <tr>
            <td style="width: 956px; height: 227px; text-align: left;" valign="top" align="center">
                <table id="TABLE1" onclick="return TABLE1_onclick()" cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left" colspan="6" style="height: 26px; background-color: beige" valign="top">
                            <asp:Label ID="Label4" runat="server" Font-Underline="True" ForeColor="Maroon" Text="Select Employee Details"></asp:Label></td>
                    </tr>
                    <tr>
                    <td style="height: 26px; width: 82px;" valign="top" align="right" rowspan="">
                        <asp:Label ID="Label2" runat="server" Text="Department" Width="83px"></asp:Label></td>
                    <td style="height: 26px; width: 175px;" valign="top" align="left" rowspan="">
                        <asp:DropDownList ID="DDL1" runat="server" Width="178px" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="departmentcode" DataValueField="departmentcode" AppendDataBoundItems="True">
                            <asp:ListItem Value="-1">---Select---</asp:ListItem>
                        </asp:DropDownList>&nbsp;&nbsp;<br />
                        </td>
                    <td style="height: 26px; width: 99px;" valign="top" align="right" rowspan="">
                        <asp:Label ID="Label14" runat="server" Text="Job Code" Width="69px"></asp:Label></td>
                    <td style="height: 26px; width: 183px;" valign="top" align="left" rowspan="">
                        <asp:DropDownList ID="DDL2" runat="server" Width="180px" DataSourceID="SqlDataSource2" DataTextField="jobcode" DataValueField="jobcode" AutoPostBack="True" >
                        </asp:DropDownList>&nbsp;
                        <asp:RequiredFieldValidator ID="V2" runat="server" ControlToValidate="DDL2" ErrorMessage="Job Code !"
                            InitialValue="-1"></asp:RequiredFieldValidator></td>
                    <td style="height: 26px; width: 110px;" valign="top" align="right" rowspan="">
                        <asp:Label ID="Label6" runat="server" Text="Designation" Width="89px"></asp:Label></td>
                    <td style="height: 26px; width: 74px;" valign="top" align="left" rowspan="">
                        <asp:Label ID="lbldesig" runat="server"></asp:Label><br />
                        </td>
                </tr>
                    <tr>
                        <td align="left" colspan="6" rowspan="" style="height: 26px; background-color: beige"
                            valign="top">
                            <asp:Label ID="Label5" runat="server" Font-Underline="True" ForeColor="Maroon" Text="Select Skill Requirements"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 82px; height: 11px;" valign="top" align="right" rowspan="">
                            <asp:Label ID="Label3" runat="server" Text="Skill Title" Width="65px"></asp:Label></td>
                        <td style="width: 175px; height: 11px;" valign="top" align="left" rowspan="">
                            <asp:DropDownList ID="DDL3" runat="server" Width="179px" AutoPostBack="True" DataSourceID="SqlDataSource3" DataTextField="td_skilltitle" DataValueField="td_skilltitle" AppendDataBoundItems="True">
                                <asp:ListItem Value="-1">---Select---</asp:ListItem>
                            </asp:DropDownList>&nbsp;&nbsp;<br />
                            <asp:RequiredFieldValidator ID="V3" runat="server" ControlToValidate="DDL4"
                                    ErrorMessage="Skill Title !" InitialValue="-1"></asp:RequiredFieldValidator></td>
                    <td align="right" style="width: 99px; height: 11px;" valign="top" rowspan="">
                        <asp:Label ID="Label7" runat="server" Text="Skill" Width="48px"></asp:Label></td>
                    <td align="left" style="height: 11px;" valign="top" colspan="3" rowspan="">
                        <asp:DropDownList ID="DDL4" runat="server" Width="177px" DataSourceID="SqlDataSource4" DataTextField="td_skill" DataValueField="td_skill" AppendDataBoundItems="True">
                            <asp:ListItem Value="-1">---Select---</asp:ListItem>
                        </asp:DropDownList>&nbsp;&nbsp;<br />
                        <asp:RequiredFieldValidator ID="V5" runat="server" ControlToValidate="DDL4"
                                    ErrorMessage="Skill !" InitialValue="-1"></asp:RequiredFieldValidator>&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left" colspan="6" rowspan="1" style="height: 38px"
                            valign="baseline">
                            <table id="Table3" onclick="return TABLE1_onclick()" cellpadding="1" cellspacing="1" style="width: 959px;">
                                <tr>
                                    <td align="left" colspan="1" rowspan="1" style="height: 26px; background-color: beige; width: 1152px;"
                                        valign="top">
                                        <asp:Label ID="Label9" runat="server" Font-Underline="True" ForeColor="Maroon" Text="Select For EA/ MD"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="height: 23px; width: 1152px; text-align: center;" valign="top" align="left" rowspan="">
                                        <br />
                                        &nbsp;<asp:DropDownList ID="rb1" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                            ValidationGroup="a" Width="197px">
                                            <asp:ListItem Value="-1">---Select---</asp:ListItem>
                                            <asp:ListItem>EA</asp:ListItem>
                                            <asp:ListItem>MD</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp; &nbsp; &nbsp; &nbsp;
                                        <br />
                                    </td>
                                </tr>
                            </table>
                            <asp:Label ID="lbld" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="left" colspan="6" style="height: 49px; text-align: center;" valign="middle">
                            <br />
                            <asp:Button ID="SAVESMA" runat="server" Text="SAVE" /><br />
                            <br />
                            <asp:Label ID="lblmsg1" runat="server" ForeColor="#004000"></asp:Label><br />
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource5" ForeColor="#333333"
                                GridLines="None" Height="281px" Width="959px">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns>
                                    <asp:BoundField DataField="jobcode" HeaderText="Job Code" SortExpression="jobcode" />
                                    <asp:BoundField DataField="skilltitle" HeaderText="Skill Title" SortExpression="skilltitle" />
                                    <asp:BoundField DataField="skill" HeaderText="Skill" SortExpression="skill" />
                                </Columns>
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECT [jobcode], [skill], [skilltitle] FROM [man_skillmatch] WHERE ([jobcode] = @jobcode) ORDER BY [skilltitle], [skill],[jobcode]">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="lbld" Name="jobcode" PropertyName="Text" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            &nbsp;<br />
                        </td>
                    </tr>
                </table>
                &nbsp;<asp:Label ID="lblmsg" runat="server" ForeColor="Green"></asp:Label><br />
                &nbsp; &nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;<asp:SqlDataSource ID="SqlDataSource1" runat="server"
                    ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>" SelectCommand="SELECT DISTINCT [departmentcode] FROM [department] ORDER BY [departmentcode]">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT DISTINCT [td_skill] FROM [td_skilllist] WHERE ([td_skilltitle] = @td_skilltitle2)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DDL3" Name="td_skilltitle2" PropertyName="SelectedValue"
                            Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT DISTINCT [jobcode] FROM [man_jobcode] WHERE ([departmentcode] = @departmentcode)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DDL1" Name="departmentcode" PropertyName="SelectedValue"
                            Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT DISTINCT [td_skilltitle] FROM [td_skillmaster] ORDER BY [td_skilltitle]">
                </asp:SqlDataSource>
                <br />
                &nbsp; &nbsp;
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
