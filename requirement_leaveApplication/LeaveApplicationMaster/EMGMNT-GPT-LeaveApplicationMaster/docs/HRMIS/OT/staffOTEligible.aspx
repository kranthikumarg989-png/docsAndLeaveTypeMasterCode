<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="staffOTEligible.aspx.vb" Inherits="E_Management.staffOTElligible" 
     title="OT Staff Eligibility" %>
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
                            <asp:Label ID="Otelig" runat="server" Text="Set OT Eligibility By"></asp:Label></td>
                        <td align="left" style="width: 869px;" valign="top" rowspan="">
                            &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;<asp:RadioButtonList ID="rb1" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                                Width="275px">
                                <asp:ListItem Value="Dept">By Dept.</asp:ListItem>
                                <asp:ListItem Value="sect">By Sect.</asp:ListItem>
                                <asp:ListItem Value="ecode">By Emp. Code</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="rb1"
                                ErrorMessage="Please Select Your Choice"></asp:RequiredFieldValidator>

                            </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 178px; height: 34px; background-color: beige" valign="top" rowspan="">
                            <asp:Label ID="depart" runat="server" Text="DEPARTMENT"></asp:Label></td>
                        <td align="left" style="width: 869px; height: 34px;" valign="top" rowspan="">
                            <asp:DropDownList ID="Deptddl" runat="server" DataSourceID="SqlDataSource1" DataTextField="NAME"
                                DataValueField="departmentCODE" Width="219px" AppendDataBoundItems="True" AutoPostBack="True"><asp:ListItem Selected="True" Value="-1">--Select--</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 178px; height: 30px; background-color: beige" valign="top" rowspan="">
                            <asp:Label ID="section" runat="server" Text="SECTION"></asp:Label></td>
                        <td align="left" style="width: 869px" valign="top" rowspan="">
                            <asp:DropDownList ID="Secddl" runat="server" DataSourceID="SqlDataSource4"
                                DataTextField="NAME" DataValueField="SECTIONCODE" Width="219px" AppendDataBoundItems="True" AutoPostBack="True"><asp:ListItem Selected="True" Value="-1">--Select--</asp:ListItem>
                                                       </asp:DropDownList>
                            </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 178px; height: 30px; background-color: beige" valign="top" rowspan="">
                            <asp:Label ID="ecode" runat="server" Text="EMP. CODE"></asp:Label></td>
                        <td align="left" style="width: 869px" valign="top" rowspan="">
                            <asp:TextBox ID="code" runat="server" MaxLength="10" Width="219px" AutoPostBack="True"></asp:TextBox>
                            </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center; height: 30px;" valign="top" rowspan="">
                            <asp:Label ID="lbledit" runat="server" Text="-" Visible="False" Width="32px"></asp:Label><asp:Button
                                ID="SubmitElig" runat="server" Text="SUBMIT" />&nbsp; &nbsp;<asp:Button ID="cancelElig"
                                    runat="server" Text="CANCEL" /></td>
                    </tr>
                    <tr>
                        <td colspan="2" rowspan="1" style="height: 30px; text-align: center" valign="top">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" ShowFooter="True" PageSize="25" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <Columns>
                        <asp:TemplateField HeaderText="Eligible">
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server"  Checked = '<%# Bind("Eligible") %>'>  </asp:CheckBox>
                            </ItemTemplate>
                                   <FooterTemplate>
                                <asp:Button ID="Button1" runat="server" OnClick="Hodapproval" Text="SUBMIT" />
                            </FooterTemplate>    
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Rno">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" text = '<%# Bind("Recno") %>' ></asp:Label>
                            </ItemTemplate>
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
                                SelectCommand="SELECT [departmentcode] + '-' + DEPARTMENTNAME AS NAME, [departmentCODE] FROM [department] order by departmentcode "></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT OT_ElligibleStaff.empcode, OT_ElligibleStaff.Elligible, empmaster.empname, empmaster.designation, empmaster.departmentcode, empmaster.empcode AS Expr1 FROM OT_ElligibleStaff INNER JOIN empmaster ON OT_ElligibleStaff.empcode = empmaster.empcode where ((departmentcode = @dept) or  (empmaster.empcode = @emp)) ">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="Deptddl" Name="dept" PropertyName="SelectedValue"   />
                                 <asp:ControlParameter ControlID="code" Name="emp" PropertyName="Text"/>
                    </SelectParameters>
       
                </asp:SqlDataSource>
                            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                SelectCommand="SELECT [sectioncode]+ '-' +SECTIONNAME AS NAME, [SECTIONCODE] FROM [SECTIONMASTER] order by sectioncode"></asp:SqlDataSource>
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