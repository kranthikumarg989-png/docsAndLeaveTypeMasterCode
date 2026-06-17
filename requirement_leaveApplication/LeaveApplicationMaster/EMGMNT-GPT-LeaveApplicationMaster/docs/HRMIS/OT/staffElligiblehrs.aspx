<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="staffElligiblehrs.aspx.vb" Inherits="E_Management.staffElligiblehrs" 
   title="Staff Elligible OT hours For Month" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
  <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td style="height: 16px; width: 16px;">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" style="height: 16px; width: 713px;">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" style="width: 1262px; height: 16px">
            </td>
            <td style="width: 24px; height: 16px;">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif" style="height: 622px; width: 16px;">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" style="height: 622px; width: 713px;" valign="top" colspan="" rowspan="">
                <table id="TABLE1" border="1" style="width: 600px; height: 120px">
                    <tr>
                        <td align="left" colspan="2" rowspan="1" style="height: 30px; background-color: beige"
                            valign="top"><asp:Label ID="Label1" runat="server" Font-Underline="True" ForeColor="Maroon" Text="STAFF OT ELIGIBILITY"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 178px; height: 30px; background-color: beige" valign="top" rowspan="">
                            <asp:Label ID="Otelig" runat="server" Text="SELECT"></asp:Label></td>
                        <td align="left" style="width: 869px;" valign="top" rowspan="">
                            &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;<asp:RadioButtonList ID="rb1" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                                Width="275px">
                                <asp:ListItem Value="Dept">By Dept.</asp:ListItem>
                                <asp:ListItem Value="sect">By Sect.</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="rb1"
                                ErrorMessage="Please Select Your Choice"></asp:RequiredFieldValidator>

                            </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 178px; height: 30px; background-color: beige" valign="top" rowspan="">
                            <asp:Label ID="depart" runat="server" Text="DEPARTMENT"></asp:Label></td>
                        <td align="left" style="width: 869px;" valign="top" rowspan="">
                            <asp:DropDownList ID="Deptddl" runat="server" DataSourceID="SqlDataSource1" DataTextField="NAME"
                                DataValueField="departmentCODE" Width="219px" AutoPostBack="True"><asp:ListItem Selected="True" Value="-1">--Select--</asp:ListItem>
                            </asp:DropDownList>
                            <asp:CheckBox ID="cbdept" runat="server" Text="All" /></td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 178px; height: 30px; background-color: beige" valign="top" rowspan="">
                            <asp:Label ID="section" runat="server" Text="SECTION"></asp:Label></td>
                        <td align="left" style="width: 869px" valign="top" rowspan="">
                            <asp:DropDownList ID="Secddl" runat="server" DataSourceID="SqlDataSource4"
                                DataTextField="NAME" DataValueField="SECTIONCODE" Width="219px" AutoPostBack="True"><asp:ListItem Selected="True" Value="-1">--Select--</asp:ListItem>
                                                       </asp:DropDownList>
                            <asp:CheckBox ID="Cbsect" runat="server" Text="All" /></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center; height: 30px;" valign="top" rowspan="">
                            <asp:Label ID="lbledit" runat="server" Text="-" Visible="False" Width="32px"></asp:Label><asp:Button
                                ID="SubmitElig" runat="server" Text="SHOW" />&nbsp; &nbsp;&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2" rowspan="1" valign="top">
                <asp:GridView AllowSorting=true  ID="GridView1" runat="server" AllowPaging="True" ShowFooter="True" PageSize="25" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false" Visible="False">
                    <Columns>
                    <asp:BoundField DataField="empcode" HeaderText="Empcode" SortExpression="empcode" />
                        <asp:BoundField DataField="empname" HeaderText="Empname" SortExpression="empname" />
                        <asp:BoundField DataField="departmentcode" HeaderText="Dept" SortExpression="departmentcode" />
                        <asp:BoundField DataField="sectioncode" HeaderText="Section" SortExpression="sectioncode" />
                        <asp:TemplateField HeaderText="MaxHrs">
                            <ItemTemplate>
                                    <asp:textbox ID="txthrs" runat="server" text = '<%# Bind("maxhrs") %>' Width="30px" ></asp:textbox>
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txthrs"
                                    ErrorMessage="!"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server"
                                ControlToValidate="txthrs" ErrorMessage="only Numbers!" ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$"
                                Width="117px"></asp:RegularExpressionValidator>
                           </ItemTemplate>
                           
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Rno">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" text = '<%# Bind("Recno") %>' ></asp:Label>
                            </ItemTemplate>
                             <FooterTemplate>
                                <asp:Button ID="Button1" runat="server" OnClick="Hodapproval" Text="SUBMIT" />
                           </FooterTemplate>  
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" HorizontalAlign="Left" VerticalAlign="Middle" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource9" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECT empmaster.empname, empmaster.empcode, empmaster.sectioncode, empmaster.departmentcode, OT_ElligibleStaff.recno, OT_ElligibleStaff.Maxhrs FROM OT_ElligibleStaff INNER JOIN empmaster ON OT_ElligibleStaff.empcode = empmaster.empcode WHERE (OT_ElligibleStaff.Elligible = '-1') and empmaster.resigned='N'">
                            </asp:SqlDataSource>
                            &nbsp;
                            <asp:SqlDataSource ID="SqlDataSource8" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECT OT_ElligibleStaff.empcode, OT_ElligibleStaff.Elligible, empmaster.empcode AS Expr1, empmaster.empname, empmaster.designation, empmaster.sectioncode, empmaster.departmentcode FROM OT_ElligibleStaff INNER JOIN empmaster ON OT_ElligibleStaff.empcode = empmaster.empcode">
                            </asp:SqlDataSource>
                            <asp:SqlDataSource ID="SqlDataSource7" runat="server"></asp:SqlDataSource>
                            <br />
                            <asp:SqlDataSource ID="SqlDataSource6" runat="server"></asp:SqlDataSource>
                        </td>
                    </tr>
                    </table>
                &nbsp; &nbsp;&nbsp;
                    <asp:Label ID="LblMsg" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Green"></asp:Label>
                &nbsp;
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                        SelectCommand="SELECT [sectioncode] + '-' + sectionname as section, sectioncode FROM [sectionmaster]">
                    </asp:SqlDataSource>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECT [sectioncode]+ [sectionname] FROM [sectionmaster]"></asp:SqlDataSource>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECT [departmentcode] + '-' + DEPARTMENTNAME AS NAME, [departmentCODE] FROM [department]"></asp:SqlDataSource>
               
                            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECT [sectioncode]+ '-' +SECTIONNAME AS NAME, [SECTIONCODE] FROM [SECTIONMASTER]"></asp:SqlDataSource>
                            </td>
            <td bgcolor="#ffffff" colspan="1" rowspan="1" style="width: 1262px; height: 622px"
                valign="top">
                &nbsp;
            </td>
            <td background="../../images/cen_rig.gif" style="width: 24px">
                <img height="11" src="../../images/cen_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td height="16" style="width: 16px">
                <img height="16" src="../../images/bot_lef.gif" width="16" /></td>
            <td background="../../images/bot_mid.gif" height="16" style="width: 713px">
                <img height="16" src="../../images/bot_mid.gif" width="16" /></td>
            <td background="../../images/bot_mid.gif" height="16" style="width: 1262px">
            </td>
            <td height="16" style="width: 24px">
                <img height="16" src="../../images/bot_rig.gif" width="24" /></td>
        </tr>
    </table>
   
</asp:Content>