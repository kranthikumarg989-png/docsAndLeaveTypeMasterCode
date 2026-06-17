<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="Spousechildrendetails.aspx.vb" Inherits="E_Management.Spousechildrendetails" 
 StylesheetTheme="buttonems" %>
 <%@Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@Import Namespace="System" %>
<%@Import Namespace="System.Data" %>
<%@Import Namespace="System.Data.Common" %>
<%@Import Namespace="System.Diagnostics" %>
<%@import Namespace="System.Data.SqlClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table style="width: 616px">
        <tr>
            <td class="td_head" colspan="4">
                SPOUSE / CHILDREN DETAILS</td>
        </tr>
        <tr>
            <td style="width: 100px">
                Empcode</td>
            <td style="width: 100px">
                <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" BackColor="#FFFF80"
                    Width="66px"></asp:TextBox></td>
            <td style="width: 100px">
                EmpName</td>
            <td style="width: 100px">
                <asp:Label ID="lblename" runat="server" ForeColor="Maroon"></asp:Label></td>
        </tr>
        <tr>
            <td class="td_head" colspan="4">
                ENTER RELATIONSHIP DETAIL</td>
        </tr>
        <tr>
            <td style="width: 100px">
                Name</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtname" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtname" ErrorMessage="*" ValidationGroup="a"></asp:RequiredFieldValidator></td>
            <td style="width: 100px">
                PassportNo</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtppno" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtppno" ErrorMessage="*" ValidationGroup="a"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 100px">
                Passport Expiry</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtppexp" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtppexp"
                    ErrorMessage="*" ValidationGroup="a"></asp:RequiredFieldValidator></td>
            <td style="width: 100px">
                Visa Expiry</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtvisaexp" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtvisaexp"
                    ErrorMessage="*" ValidationGroup="a"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 26px;">
                Relationship</td>
            <td style="width: 100px; height: 26px;">
                <asp:TextBox ID="txtrelation" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtrelation"
                    ErrorMessage="*" ValidationGroup="a"></asp:RequiredFieldValidator></td>
            <td style="width: 100px; height: 26px;">
                Country</td>
            <td style="width: 100px; height: 26px;">
                <asp:TextBox ID="txtcountry" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtcountry" ErrorMessage="*" ValidationGroup="a"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="left" colspan="4">
                <asp:Label ID="Label1" runat="server" ForeColor="#C00000"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" colspan="4">
                <asp:Button ID="Button1" runat="server" Text="SAVE" SkinID="buttonskin1" ValidationGroup="a" /></td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GridView1" DataKeyNames=rno runat="server" AutoGenerateColumns="False" CellPadding="4"
                    DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" AutoGenerateEditButton="True">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                    <asp:TemplateField ShowHeader="False">
     <ItemTemplate>
       <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                    OnClientClick='return confirm("Are you sure you want to delete this entry?");'
                    Text="Delete" forecolor="red"/>
     </ItemTemplate>
   </asp:TemplateField>
                        <asp:BoundField DataField="name1" HeaderText="Name" SortExpression="name1" />
                        <asp:BoundField DataField="relation1" HeaderText="Relationship" SortExpression="relation1" />
                        <asp:BoundField DataField="country1" HeaderText="Country" SortExpression="country1" />
                        <asp:BoundField DataField="passportno1" HeaderText="Passport No" SortExpression="passportno1"  />
                        <asp:TemplateField HeaderText="Passport Expiry" SortExpression="passportexpiry1">
                            <EditItemTemplate>
                                <asp:TextBox ID="t1temp" runat="server" Text='<%# Bind("passportexpiry1","{0:MMM/dd/yyyy}") %>' HtmlEncode="false"></asp:TextBox>
                                <cc1:CalendarExtender ID="c1" runat="server" CssClass="cal_Theme1" Format="MMM/dd/yyyy"
                                    PopupButtonID="t1temp" TargetControlID="t1temp">
                                </cc1:CalendarExtender>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("passportexpiry1","{0:dd/MM/yyyy}") %>' HtmlEncode="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Visa Expiry" SortExpression="visaexpiry1">
                            <EditItemTemplate>
                                <asp:TextBox ID="t2item" runat="server" Text='<%# Bind("visaexpiry1","{0:MMM/dd/yyyy}") %>' HtmlEncode="false"></asp:TextBox>
                                <cc1:CalendarExtender ID="c2" runat="server" CssClass="cal_Theme1" Format="MMM/dd/yyyy"
                                    PopupButtonID="t2item" TargetControlID="t2item">
                                </cc1:CalendarExtender>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("visaexpiry1","{0:dd/MM/yyyy}") %>' HtmlEncode="false"></asp:Label>
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
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT [name1], [passportno1], [passportexpiry1],rno, [relation1], [country1], [visaexpiry1] FROM [emcform] WHERE ([empcode] = @empcode) ORDER BY [rno] DESC"
                     DeleteCommand = "delete from emcform where rno=@rno"
                      UpdateCommand ="updSpousechildren" UpdateCommandType=StoredProcedure                     >
                    <SelectParameters>
                        <asp:ControlParameter ControlID="TextBox1" Name="empcode" PropertyName="Text" Type="String" />
                    </SelectParameters>
                    <UpdateParameters>
                            <asp:Parameter Name= name1 Type=string />
                            <asp:Parameter Name = passportno1 Type=string />
                            <asp:Parameter Name= passportexpiry1 Type=datetime />
                            <asp:Parameter Name = relation1 Type=string />
                            <asp:Parameter Name = country1 Type=string />
                            <asp:Parameter Name= visaexpiry1 Type=datetime />
                            <asp:Parameter Name=rno Type=int16 />
                    </UpdateParameters>
                </asp:SqlDataSource>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="cal_Theme1"
                    Format="dd/MM/yy" PopupButtonID="txtppexp" TargetControlID="txtppexp">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="cal_Theme1"
                    Format="dd/MM/yy" PopupButtonID="txtvisaexp" TargetControlID="txtvisaexp">
                </cc1:CalendarExtender>
            </td>
        </tr>
    </table>
</asp:Content>
