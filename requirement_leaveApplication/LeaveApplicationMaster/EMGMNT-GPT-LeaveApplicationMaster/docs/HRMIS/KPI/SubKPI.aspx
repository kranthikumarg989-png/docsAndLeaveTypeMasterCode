<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="SubKPI.aspx.vb" Inherits="E_Management.SubKPI" 
    title="Sub KPI Settings" %>
            <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@Import Namespace="System" %>
<%@Import Namespace="System.Data" %>
<%@Import Namespace="System.Data.Common" %>
<%@Import Namespace="System.Diagnostics" %>
<%@import Namespace="System.Data.SqlClient" %>
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
                <table>
                    <tr>
                        <td>
                            <asp:Panel ID="Panel1" runat="server" GroupingText="Select Major KPI and Quarter">
                                <table>
                                    <tr>
                                        <td style="border-right: silver 1px solid; border-top: silver 1px solid; border-left: silver 1px solid; border-bottom: silver 1px solid">
                                            Quarter</td>
                                        <td style="border-right: silver 1px solid; border-top: silver 1px solid; border-left: silver 1px solid; border-bottom: silver 1px solid;">
                                            <asp:CheckBox ID="Q1" runat="server" Text="Q1" />
                                            &nbsp; &nbsp; &nbsp;&nbsp;<asp:CheckBox ID="q2" runat="server" Text="Q2" />
                                            &nbsp; &nbsp; &nbsp;
                                            <asp:CheckBox ID="Q3" runat="server" Text="Q3" />
                                            &nbsp;&nbsp; &nbsp; &nbsp;
                                            <asp:CheckBox ID="Q4" runat="server" Text="Q4" /></td>
                                    </tr>
                                    <tr>
                                        <td style="border-right: silver 1px solid; border-top: silver 1px solid; border-left: silver 1px solid; border-bottom: silver 1px solid">
                                            Major KPI</td>
                                        <td>
                                            <asp:DropDownList ID="ddlmajor" runat="server" DataSourceID="SqlDataSource1"
                                                DataTextField="Major_kpidetails" DataValueField="Major_KPINO" AutoPostBack="True" Width="433px" AppendDataBoundItems="True">
                                                <asp:ListItem Selected="True" Value="-1">--Select--</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlmajor"
                                                ErrorMessage="!" InitialValue="-1"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                </table>
                                &nbsp;
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; height: 91px">
                            <asp:Panel ID="Panel2" runat="server" GroupingText="Enter Your Sub KPI">
                                <table>
                                    <tr>
                                        <td style="border-right: silver 1px solid; border-top: silver 1px solid; border-left: silver 1px solid;
                                            width: 100px; border-bottom: silver 1px solid">
                                            Sub KPI</td>
                                        <td colspan="3" style="border-right: silver 1px solid; border-top: silver 1px solid;
                                            border-left: silver 1px solid; width: 100px; border-bottom: silver 1px solid">
                                            <asp:TextBox ID="txtsubkpi" runat="server" TextMode="MultiLine" Height="53px" Width="189px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtsubkpi"
                                                ErrorMessage="!"></asp:RequiredFieldValidator></td>
                                        <td style="border-right: silver 1px solid; border-top: silver 1px solid; border-left: silver 1px solid;
                                            width: 100px; border-bottom: silver 1px solid">
                                            Update Basis</td>
                                        <td colspan="2" style="border-right: silver 1px solid; border-top: silver 1px solid;
                                            border-left: silver 1px solid; width: 100px; border-bottom: silver 1px solid">
                                            <asp:RadioButtonList ID="Rbupdate" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
                                                <asp:ListItem Value="D">Daily</asp:ListItem>
                                                <asp:ListItem Value="W">Weekly</asp:ListItem>
                                                <asp:ListItem Value="M">Monthly</asp:ListItem>
                                            </asp:RadioButtonList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Rbupdate"
                                                ErrorMessage="!" InitialValue="-1" Width="4px"></asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                        <td style="border-right: silver 1px solid; border-top: silver 1px solid; border-left: silver 1px solid;
                                            width: 100px; border-bottom: silver 1px solid">
                                            Settings</td>
                                        <td style="border-right: silver 1px solid; border-top: silver 1px solid; border-left: silver 1px solid;
                                            width: 100px; border-bottom: silver 1px solid">
                                            UOM</td>
                                        <td style="border-right: silver 1px solid; border-top: silver 1px solid; border-left: silver 1px solid;
                                            width: 100px; border-bottom: silver 1px solid">
                                            <asp:DropDownList ID="ddlUom" runat="server">
                                                <asp:ListItem>%</asp:ListItem>
                                                <asp:ListItem>NOs</asp:ListItem>
                                                <asp:ListItem>RM</asp:ListItem>
                                            </asp:DropDownList>&nbsp;</td>
                                        <td style="border-right: silver 1px solid; border-top: silver 1px solid; border-left: silver 1px solid;
                                            width: 100px; border-bottom: silver 1px solid">
                                            Current&nbsp;</td>
                                        <td style="border-right: silver 1px solid; border-top: silver 1px solid; border-left: silver 1px solid;
                                            width: 100px; border-bottom: silver 1px solid">
                                            <asp:TextBox ID="txtcurrent" runat="server" Width="47px" BackColor="#FFFF80"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtcurrent"
                                                ErrorMessage="!" Width="4px"></asp:RequiredFieldValidator>&nbsp;</td>
                                        <td style="border-right: silver 1px solid; border-top: silver 1px solid; border-left: silver 1px solid;
                                            width: 100px; border-bottom: silver 1px solid">
                                            Target&nbsp;</td>
                                        <td style="border-right: silver 1px solid; border-top: silver 1px solid; border-left: silver 1px solid;
                                            width: 100px; border-bottom: silver 1px solid">
                                            <asp:TextBox ID="txttarget" runat="server" Width="47px" BackColor="#FFFF80"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txttarget"
                                                ErrorMessage="!"></asp:RequiredFieldValidator>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px">
                                        </td>
                                        <td style="width: 100px">
                                        </td>
                                        <td style="width: 100px">
                                        </td>
                                        <td style="width: 100px">
                                        </td>
                                        <td style="width: 100px">
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server"
                                                ControlToValidate="txtcurrent" ErrorMessage="only Numbers!" ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$"
                                                Width="117px"></asp:RegularExpressionValidator></td>
                                        <td style="width: 100px">
                                        </td>
                                        <td style="width: 100px">
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txttarget"
                                                ErrorMessage="only Numbers!" ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$"
                                                Width="117px"></asp:RegularExpressionValidator></td>
                                    </tr>
                                </table>
                                <asp:Label ID="lblmsg" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label></asp:Panel>
                        </td>
                    </tr>
                    <tr>
                    <td align="right">
                        <asp:Label ID="lblinv" runat="server"></asp:Label>
                        <asp:Label ID="lblmjr" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="lblrno" runat="server"></asp:Label>
                        <asp:Button ID="SAVE" runat="server" Text="SAVE" /></td>
                    </tr>
                </table>
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    CellPadding="4" DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="Vertical"
                    PageSize="15" Width="100%">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="Sub_KPINO" HeaderText="Sno" SortExpression="Sub_KPINO" />
                       
                        <asp:BoundField DataField="MajorKPI_Details" HeaderText="Major KPI" SortExpression="MajorKPI_Details" />
                        <asp:BoundField DataField="SubKPI_Details" HeaderText="Sub KPI" SortExpression="SubKPI_Details" />
                        <asp:BoundField DataField="uom" HeaderText="Uom" SortExpression="uom" />
                        <asp:BoundField DataField="curent" HeaderText="Current" SortExpression="curent" />
                        <asp:BoundField DataField="target" HeaderText="Target" SortExpression="target" />
                        <asp:BoundField DataField="updbasis" HeaderText="Update On" SortExpression="updbasis" />
                        <asp:TemplateField HeaderText="Status" SortExpression="status">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("status") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" CommandArgument='<%# Eval("Sub_KPINO", "{0}") %>'
                                                Text='<%# Eval("status") %>'> </asp:Label>
                                         <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("Sub_KPINO", "{0}") %>'
                                    ForeColor="#0000C0" Font-Underline=true  OnCommand="EDITKpi" Text='<%# Eval("status") %>' CausesValidation=False ></asp:LinkButton>
                                     <asp:LinkButton ID="LinkButton5" runat="server" CausesValidation="false" CommandArgument='<%# Eval("Sub_KPINO", "{0}") %>'
                                                ForeColor="RED" OnCommand="KPIdelete" Text="DELETE"></asp:LinkButton>
                                            <cc1:confirmbuttonextender id="confirmgpcancel" runat="server" confirmonformsubmit="true"
                                                confirmtext="Are you sure you want to DELETE the SubKPI" targetcontrolid="LinkButton5">
                           </cc1:confirmbuttonextender>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT [Sub_KPINO], [SubKPI_Details], [MajorKPI_Details], [uom], [curent], [target],updbasis,status FROM [KPI_SubSetting] WHERE ([Department_Code] = @Department_Code)">
                    <SelectParameters>
                        <asp:SessionParameter Name="Department_Code" SessionField="_edept" Type="String" />
                      </SelectParameters>
                </asp:SqlDataSource>
                <br />
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT DISTINCT [Major_kpidetails], [Major_KPINO] FROM [KPI_MajorSetting] WHERE ([Department_Code] = @Department_Code) ORDER BY [Major_kpidetails]">
                    <SelectParameters>
                        <asp:SessionParameter Name="Department_Code" SessionField="_edept" Type="String" />
                      </SelectParameters>
                </asp:SqlDataSource>
                <asp:Label ID="lblyear" runat="server"></asp:Label></td>
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
