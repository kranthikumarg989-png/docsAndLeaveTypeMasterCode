<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="Training Provider MasterIN.aspx.vb" Inherits="E_Management.Training_Provider_MasterIN" 
    title="Training Provider Master" %>
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
        <td align="center" colspan="1" valign="top" style="width: 1123px">
                        <asp:Label ID="Label1" runat="server" Font-Underline="True" ForeColor="Maroon" Text="TRAINING PROVIDER MASTER INTERNAL"></asp:Label></td>
    </tr>
        <tr>
            <td style="width: 1123px; height: 227px; text-align: left;" valign="top" align="center">
                <table id="TABLE1" onclick="return TABLE1_onclick()" border="1" cellpadding="1" cellspacing="1">
                    <tr>
                        <td align="left" style="width: 91px; height: 26px; background-color: beige" valign="top">
                            <asp:Label ID="Label4" runat="server" Text="Department" Width="130px"></asp:Label></td>
                        <td align="left" style="height: 26px" valign="top">
                            <asp:DropDownList ID="CmbDepartment" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource2"
                                DataTextField="departmentname" DataValueField="departmentcode" Width="300px">
                            </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SQLoledb241HRMIS %>"
                                ProviderName="<%$ ConnectionStrings:SQLoledb241HRMIS.ProviderName %>" SelectCommand="SELECT [departmentcode], [departmentname] FROM [department]">
                            </asp:SqlDataSource>
                        </td>
                        <td align="left" style="height: 26px; background-color: beige" valign="top">
                            <asp:Label ID="Label5" runat="server" Text="Section" Width="130px"></asp:Label></td>
                        <td align="left" style="height: 26px" valign="top">
                            <asp:DropDownList ID="CmbSection" runat="server" DataSourceID="SqlDataSource3" DataTextField="sectionname"
                                DataValueField="sectioncode" Width="300px">
                            </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:SQLoledb241HRMIS %>"
                                ProviderName="<%$ ConnectionStrings:SQLoledb241HRMIS.ProviderName %>" SelectCommand="SELECT [sectioncode], [sectionname] FROM [sectionmaster] WHERE ([departmentcode] = ?)">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="CmbDepartment" Name="departmentcode" PropertyName="SelectedValue"
                                        Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 91px; height: 26px; background-color: beige" valign="top">
                            <asp:Label ID="Label20" runat="server" Text="EmployeeName" Width="130px"></asp:Label></td>
                        <td align="left" style="height: 26px" valign="top">
                            <asp:DropDownList ID="CmbEmployee" runat="server" DataSourceID="SqlDataSource6" DataTextField="empname"
                                DataValueField="empcode" Width="300px">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:SQLoledb241HRMIS %>"
                                ProviderName="<%$ ConnectionStrings:SQLoledb241HRMIS.ProviderName %>" SelectCommand="SELECT empcode, empname FROM empmaster WHERE (resigned = 'n') ORDER BY empname">
                            </asp:SqlDataSource>
                        </td>
                        <td align="left" style="height: 26px; background-color: beige" valign="top">
                            <asp:Label ID="Label8" runat="server" Text="Programme" Width="130px"></asp:Label></td>
                        <td align="left" style="height: 26px" valign="top">
                            <asp:DropDownList ID="CmbProgramme" runat="server" Width="300px">
                                <asp:ListItem>SAFETY</asp:ListItem>
                                <asp:ListItem>QUALITY</asp:ListItem>
                                <asp:ListItem>7S</asp:ListItem>
                                <asp:ListItem>COMPANY POLICIES</asp:ListItem>
                                <asp:ListItem>WORK PROCESS</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 91px; height: 26px; background-color: beige" valign="top">
                            <asp:Label ID="Label6" runat="server" Text="Method" Width="130px"></asp:Label></td>
                        <td align="left" style="height: 26px" valign="top">
                            <asp:DropDownList ID="CmbMethod" runat="server" Width="300px">
                                <asp:ListItem>THEORY</asp:ListItem>
                                <asp:ListItem>PRACTICAL</asp:ListItem>
                            </asp:DropDownList></td>
                        <td align="left" style="height: 26px; background-color: beige" valign="top">
                            <asp:Label ID="Label7" runat="server" Text="Type" Width="130px"></asp:Label></td>
                        <td align="left" style="height: 26px" valign="top">
                            <asp:DropDownList ID="CmbType" runat="server" Width="300px">
                                <asp:ListItem>INTERNAL</asp:ListItem>
                                <asp:ListItem>EXTERNAL PROVIDER</asp:ListItem>
                                <asp:ListItem>PUBLIC TRAINING</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 91px; height: 26px; background-color: beige" valign="top">
                            <asp:Label ID="Label9" runat="server" Text="Training Department" Width="130px"></asp:Label></td>
                        <td align="left" style="height: 26px" valign="top">
                            <asp:DropDownList ID="CmbTrainingDEpartment" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource5"
                                DataTextField="departmentname" DataValueField="departmentcode" Width="300px">
                            </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:SQLoledb241HRMIS %>"
                                ProviderName="<%$ ConnectionStrings:SQLoledb241HRMIS.ProviderName %>" SelectCommand="SELECT [departmentcode], [departmentname] FROM [department]">
                            </asp:SqlDataSource>
                        </td>
                        <td align="left" style="height: 26px; background-color: beige" valign="top">
                            <asp:Label ID="Label10" runat="server" Text="Training Section" Width="130px"></asp:Label></td>
                        <td align="left" style="height: 26px" valign="top">
                            <asp:DropDownList ID="CmbTrainingSection" runat="server" DataSourceID="SqlDataSource4"
                                DataTextField="sectionname" DataValueField="sectioncode" Width="300px">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:SQLoledb241HRMIS %>"
                                ProviderName="<%$ ConnectionStrings:SQLoledb241HRMIS.ProviderName %>" SelectCommand="SELECT [sectioncode], [sectionname] FROM [sectionmaster] WHERE ([departmentcode] = ?)">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="CmbTrainingDEpartment" DefaultValue="n" Name="DepartmentCode"
                                        PropertyName="SelectedValue" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                    <td style="background-color: beige; height: 26px; width: 91px;" valign="top" align="left">
                        <asp:Label ID="Label2" runat="server" Text="Provider Code" Width="105px"></asp:Label></td>
                    <td style="height: 26px;" valign="top" align="left">
                        &nbsp;<asp:Label ID="lblcode" runat="server" Width="54px"></asp:Label></td>
                    <td style="background-color: beige; height: 26px;" valign="top" align="left">
                        </td>
                    <td style="height: 26px;" valign="top" align="left">
                        &nbsp;</td>
                </tr>
                    <tr>
                        <td align="left" colspan="4" style="height: 49px; text-align: center;" valign="middle">
                            <br />
                            <asp:Button ID="SAVEPM" runat="server" Text="SAVE" /><br />
                            <br />
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" AutoGenerateEditButton="false" CellPadding="4"
                                DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Width="802px">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns>
                                    <asp:BoundField DataField="code" HeaderText="code" SortExpression="code" />
                                    <asp:BoundField DataField="registrationno" HeaderText="registrationno" SortExpression="registrationno" />
                                    <asp:BoundField DataField="SectionCode" HeaderText="SectionCode" SortExpression="SectionCode" />
                                    <asp:BoundField DataField="SectionName" HeaderText="SectionName" SortExpression="SectionName" />
                                    <asp:BoundField DataField="TrainingDepartment" HeaderText="TrainingDepartment" SortExpression="TrainingDepartment" />
                                    <asp:BoundField DataField="TrainingDepartmentName" HeaderText="TrainingDepartmentName"
                                        SortExpression="TrainingDepartmentName" />
                                    <asp:BoundField DataField="TrainingSectionCode" HeaderText="TrainingSectionCode"
                                        SortExpression="TrainingSectionCode" />
                                    <asp:BoundField DataField="TrainingSectionName" HeaderText="TrainingSectionName"
                                        SortExpression="TrainingSectionName" />
                                    <asp:BoundField DataField="Programme" HeaderText="Programme" SortExpression="Programme" />
                                    <asp:BoundField DataField="Method" HeaderText="Method" SortExpression="Method" />
                                    <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                                </Columns>
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            </asp:GridView>
                            <br />
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SQLoledb241HRMIS %>"
                                SelectCommand="SELECT code, registrationno, SectionCode, SectionName, TrainingDepartment, TrainingDepartmentName, TrainingSectionCode, TrainingSectionName, Programme, Method, Type FROM td_ProvidedMasterIN ORDER BY code, name, registrationno"
                                DeleteCommand = "delete from [td_ProvidedMaster] where code = @code" ProviderName="<%$ ConnectionStrings:SQLoledb241HRMIS.ProviderName %>">
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                </table>
                &nbsp;<asp:Label ID="lblmsg" runat="server" ForeColor="Green"></asp:Label><br />
                &nbsp; &nbsp;
                &nbsp;&nbsp;<br />
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
