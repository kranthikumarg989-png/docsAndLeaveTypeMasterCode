<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="CalendarMaster.aspx.vb" Inherits="E_Management.CalendarMaster" 
 StylesheetTheme="buttonems" %>
<%@Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@Import Namespace="System" %>
<%@Import Namespace="System.Data" %>
<%@Import Namespace="System.Data.Common" %>
<%@Import Namespace="System.Diagnostics" %>
<%@import Namespace="System.Data.SqlClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table style="width: 555px">
        <tr>
            <td style="vertical-align: top; text-align: left;">
                <asp:Panel ID="Panel1" runat="server" GroupingText="CALENDER SETTING" Width="336px">
                    <table style="width: 331px">
                        <tr>
                            <td style="width: 49px; height: 21px">
                                GroupCode</td>
                            <td style="width: 100px; height: 21px">
                                <asp:DropDownList ID="ddlgroup" runat="server" DataSourceID="SqlDataSource1" DataTextField="trans_groupcode"
                                    DataValueField="trans_groupcode">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 49px; height: 27px;">
                                FromDate</td>
                            <td style="width: 100px; height: 27px;">
                                <asp:TextBox ID="txtfrom" runat="server" Height="17px" Width="97px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 49px">
                                ToDate</td>
                            <td style="width: 100px">
                                <asp:TextBox ID="txtto" runat="server" Height="16px" Width="98px"></asp:TextBox></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td rowspan="2" style="vertical-align: top; text-align: left">
                <asp:Panel ID="Panel3" runat="server" GroupingText="Verify Code and Date">
                <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                    BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px"
                    CellPadding="3" DataSourceID="SqlDataSource3" GridLines="Horizontal" Height="271px" AllowPaging="True" ShowFooter="True" PageSize="25">
                    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                    <Columns>
                        <asp:BoundField DataField="shiftdate" HeaderText="Shift Date" SortExpression="shiftdate" DataFormatString="{0:dd MMM yy}" HtmlEncode="false" >
                            <ItemStyle ForeColor="Brown" />
                        </asp:BoundField>
                        <asp:BoundField DataField="groupcode" HeaderText="Group Code" SortExpression="groupcode" />
                        <asp:TemplateField HeaderText="Shift Code" SortExpression="shiftcode">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("shiftcode") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("shiftcode") %>'></asp:Label>
                            </ItemTemplate>
                                 <FooterTemplate>
                          <asp:Button ID="Button1" SkinID ="buttonskin1" runat="server" UseSubmitBehavior=false  Text="SUBMIT" onclick="InsertShiftDetails"  />
                         </FooterTemplate> 
                            
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <AlternatingRowStyle BackColor="#F7F7F7" />
                </asp:GridView>
                </asp:Panel>
                <asp:Label ID="lblmsg" runat="server" Font-Size="Medium" ForeColor="#C00000"></asp:Label></td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left;" align="left">
                <asp:Panel ID="Panel2" runat="server" GroupingText="SHIFT ALLOTMENT" >
                    <table style="width: 185px">
                        <tr>
                            <td class="td_head" style="width: 100px">
                                S.No</td>
                            <td class="td_head" style="width: 373px">
                                Days</td>
                            <td class="td_head" style="width: 100px">
                                Shift</td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                                1</td>
                            <td style="width: 373px">
                                <asp:TextBox ID="txtd1" runat="server" Width="36px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtd1"
                                    ErrorMessage="only Numbers!" ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$"
                                    Width="117px"></asp:RegularExpressionValidator></td>
                            <td style="width: 100px">
                                <asp:DropDownList ID="ddls1" runat="server" DataSourceID="SqlDataSource2" DataTextField="trans_shiftcode"
                                    DataValueField="trans_shiftcode">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                                2</td>
                            <td style="width: 373px">
                                <asp:TextBox ID="txtd2" runat="server" Width="36px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtd2"
                                    ErrorMessage="only Numbers!" ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$"
                                    Width="117px"></asp:RegularExpressionValidator></td>
                            <td style="width: 100px">
                                <asp:DropDownList ID="ddls2" runat="server" DataSourceID="SqlDataSource2" DataTextField="trans_shiftcode"
                                    DataValueField="trans_shiftcode">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 100px; height: 26px">
                                3</td>
                            <td style="width: 373px; height: 26px">
                                <asp:TextBox ID="txtd3" runat="server" Width="36px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtd3"
                                    ErrorMessage="only Numbers!" ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$"
                                    Width="117px"></asp:RegularExpressionValidator></td>
                            <td style="width: 100px; height: 26px">
                                <asp:DropDownList ID="ddls3" runat="server" DataSourceID="SqlDataSource2" DataTextField="trans_shiftcode"
                                    DataValueField="trans_shiftcode">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                                4</td>
                            <td style="width: 373px">
                                <asp:TextBox ID="txtd4" runat="server" Width="36px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtd4"
                                    ErrorMessage="only Numbers!" ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$"
                                    Width="117px"></asp:RegularExpressionValidator></td>
                            <td style="width: 100px">
                                <asp:DropDownList ID="ddls4" runat="server" DataSourceID="SqlDataSource2" DataTextField="trans_shiftcode"
                                    DataValueField="trans_shiftcode">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                                5</td>
                            <td style="width: 373px">
                                <asp:TextBox ID="txtd5" runat="server" Width="36px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtd5"
                                    ErrorMessage="only Numbers!" ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$"
                                    Width="117px"></asp:RegularExpressionValidator></td>
                            <td style="width: 100px">
                                <asp:DropDownList ID="ddls5" runat="server" DataSourceID="SqlDataSource2" DataTextField="trans_shiftcode"
                                    DataValueField="trans_shiftcode">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 100px; height: 26px">
                                6</td>
                            <td style="width: 373px; height: 26px">
                                <asp:TextBox ID="txtd6" runat="server" Width="36px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtd6"
                                    ErrorMessage="only Numbers!" ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$"
                                    Width="117px"></asp:RegularExpressionValidator></td>
                            <td style="width: 100px; height: 26px">
                                <asp:DropDownList ID="ddls6" runat="server" DataSourceID="SqlDataSource2" DataTextField="trans_shiftcode"
                                    DataValueField="trans_shiftcode">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 100px; height: 26px">
                                7</td>
                            <td style="width: 373px; height: 26px">
                                <asp:TextBox ID="txtd7" runat="server" Width="36px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtd7"
                                    ErrorMessage="only Numbers!" ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$"
                                    Width="117px"></asp:RegularExpressionValidator></td>
                            <td style="width: 100px; height: 26px">
                                <asp:DropDownList ID="ddls7" runat="server" DataSourceID="SqlDataSource2" DataTextField="trans_shiftcode"
                                    DataValueField="trans_shiftcode">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 100px; height: 26px">
                                8</td>
                            <td style="width: 373px; height: 26px">
                                <asp:TextBox ID="txtd8" runat="server" Width="36px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtd8"
                                    ErrorMessage="only Numbers!" ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$"
                                    Width="117px"></asp:RegularExpressionValidator></td>
                            <td style="width: 100px; height: 26px">
                                <asp:DropDownList ID="ddls8" runat="server" DataSourceID="SqlDataSource2" DataTextField="trans_shiftcode"
                                    DataValueField="trans_shiftcode">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 100px; height: 26px">
                                9</td>
                            <td style="width: 373px; height: 26px">
                                <asp:TextBox ID="txtd9" runat="server" Width="36px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtd9"
                                    ErrorMessage="only Numbers!" ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$"
                                    Width="117px"></asp:RegularExpressionValidator>
                                &nbsp;&nbsp;
                            </td>
                            <td style="width: 100px; height: 26px">
                                <asp:DropDownList ID="ddls9" runat="server" DataSourceID="SqlDataSource2" DataTextField="trans_shiftcode"
                                    DataValueField="trans_shiftcode">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 100px; height: 26px">
                                10</td>
                            <td style="width: 373px; height: 26px">
                                <asp:TextBox ID="txtd10" runat="server" Width="36px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="txtd10"
                                    ErrorMessage="only Numbers!" ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$"
                                    Width="117px"></asp:RegularExpressionValidator>
                                &nbsp;&nbsp;
                            </td>
                            <td style="width: 100px; height: 26px">
                                <asp:DropDownList ID="ddls10" runat="server" DataSourceID="SqlDataSource2" DataTextField="trans_shiftcode"
                                    DataValueField="trans_shiftcode">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td align="right" colspan="3" style="height: 26px">
                                <asp:Button ID="BTNSHOW" runat="server" SkinID="buttonskin1" Text="SHOW" /></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT [trans_groupcode] FROM [trans_groupmaster] ORDER BY [trans_groupcode]">
    </asp:SqlDataSource>
    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="cal_Theme1"
        Format="dd/MM/yy" PopupButtonID="txtfrom" TargetControlID="txtfrom">
    </cc1:CalendarExtender>
    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="cal_Theme1"
        Format="dd/MM/yy" PopupButtonID="txtto" TargetControlID="txtto">
    </cc1:CalendarExtender>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT [trans_shiftcode] FROM [trans_shifttime] ORDER BY [trans_shiftcode]">
    </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT * FROM [trans_shiftfinaltemp] ORDER BY [shiftdate]"></asp:SqlDataSource>

</asp:Content>
 