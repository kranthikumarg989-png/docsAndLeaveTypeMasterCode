<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="MajorKPI.aspx.vb" Inherits="E_Management.MajorKPI" 
    title="Major KPI settings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
 <table cellpadding="0" cellspacing="0">
        <tr>
            <td style="width: 16px; height: 16px">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" style="width: 617px; height: 16px">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 25px; height: 16px">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif" style="width: 16px; height: 352px">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" style="width: 617px; height: 352px;" valign="top">
                         
                            <asp:Panel ID="Panel1" runat="server" GroupingText="Major KPI Settings" Width="100%">
                <table>
                    <tr>
                        <td colspan="3" style="height: 21px">
                            <asp:Label ID="lblmsg" runat="server" Font-Size="Medium" ForeColor="Maroon"></asp:Label></td>
                    </tr>
                    <tr style="color: #000000">
                        <td style="background-color: beige">
                            Setting Major KPI for Self?</td>
                        <td colspan="2">
                            <asp:RadioButtonList ID="rdoptions" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                                <asp:ListItem Value="yes">Yes</asp:ListItem>
                                <asp:ListItem Value="no">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: beige">
                            <asp:Label ID="lbl1" runat="server" Text="Select" Visible="False"></asp:Label></td>
                        <td colspan="2">
                            <asp:DropDownList ID="ddldept" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1"
                                DataTextField="dept" DataValueField="departmentcode" Visible="False" Width="300px" AppendDataBoundItems="True">
                                <asp:ListItem Selected="True" Value="-1">--Select--</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td style="background-color: beige">
                            <asp:Label ID="lbl2" runat="server" Text="Key in Major KPI" Visible="False"></asp:Label></td>
                        <td colspan="2">
                            <asp:TextBox ID="txtmajorKPI" runat="server" Rows="5" TextMode="MultiLine" Width="206px" Visible="False"></asp:TextBox>-<asp:TextBox ID="KPIpercent" runat="server" Width="31px" ></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server"
                                ControlToValidate="KPIpercent" ErrorMessage="only Numbers!" ValidationExpression="^([0-9]*|\d*\.\d{1}?\d*)$"
                                Width="117px"></asp:RegularExpressionValidator>
                            <asp:Label ID="lbl3" runat="server" Text="%" Visible="False"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="background-color: beige">
                            <asp:Label ID="Label3" runat="server" Text="Update By" Visible="False"></asp:Label></td>
                        <td colspan="2">
                            <asp:RadioButtonList ID="Rbupdate" runat="server" RepeatDirection="Horizontal" Visible="False">
                                <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
                                <asp:ListItem Value="D">Daily</asp:ListItem>
                                <asp:ListItem Value="W">Weekly</asp:ListItem>
                                <asp:ListItem Value="M">Monthly</asp:ListItem>
                            </asp:RadioButtonList></td>
                    </tr>
                    <tr>
                        <td align="right" colspan="3">
                            <asp:Label ID="lblrno" runat="server" Text="0" Visible="False"></asp:Label>
                            <asp:Label ID="lbldept" runat="server" Visible="False"></asp:Label>
                            <asp:Button ID="BtnSave" runat="server" Text="SAVE" /></td>
                    </tr>
                </table>
                </asp:Panel>
                <br />
                <asp:Label ID="Label2" runat="server" Font-Underline="True" ForeColor="Maroon" Text="Major KPI"></asp:Label><br />
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="Sqlkpi" ForeColor="#333333" GridLines="Vertical" PageSize="15" Width="100%" AllowPaging="True">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:TemplateField HeaderText="Sno" InsertVisible="False" SortExpression="Major_KPINO">
                            <EditItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Major_KPINO") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                           <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("Major_KPINO", "{0}") %>'
                                    ForeColor="#0000C0" Font-Underline=true  OnCommand="EDITKpi" Text='<%# Eval("Major_KPINO") %>' CausesValidation=False ></asp:LinkButton>
                                   </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Major_kpidetails" HeaderText="Major KPI" SortExpression="Major_kpidetails" />
                        <asp:BoundField DataField="Weightage" HeaderText="%" SortExpression="Weightage" />
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                <asp:SqlDataSource ID="Sqlkpi" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT [Major_KPINO], [Major_kpidetails], [Weightage] FROM [KPI_MajorSetting] WHERE ([Department_Code] = @Department_Code) ORDER BY [Major_KPINO] DESC">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="lbldept" Name="Department_Code" PropertyName="Text"
                            Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <br />
                <br />
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="select departmentcode +'-' +departmentname as dept,departmentcode from department order by departmentcode">
                </asp:SqlDataSource>
                   </td>
                    <td background="../../images/cen_rig.gif" style="width: 25px; height: 352px;">
                        <IMG height="11" src="../../images/cen_rig.gif" width="24"></td>
                </tr>
                <tr>
                    <td width="16" height="16">
                        <IMG height="16" src="../../images/bot_lef.gif" width="16"></td>
                    <td background="../../images/bot_mid.gif" height="16" style="width: 617px">
                        <IMG height="16" src="../../images/bot_mid.gif" width="16"></td>
                    <td height="16" style="width: 25px">
                        <IMG height="16" src="../../images/bot_rig.gif" width="24"></td>
                </tr>
            </table>
</asp:Content>
