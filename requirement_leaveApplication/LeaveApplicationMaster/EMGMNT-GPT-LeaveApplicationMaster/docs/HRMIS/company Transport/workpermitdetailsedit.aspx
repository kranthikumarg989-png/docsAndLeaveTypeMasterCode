<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="workpermitdetailsedit.aspx.vb" Inherits="E_Management.workpermitdetailsedit" 
%>
    <%@Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@Import Namespace="System" %>
<%@Import Namespace="System.Data" %>
<%@Import Namespace="System.Data.Common" %>
<%@Import Namespace="System.Diagnostics" %>
<%@import Namespace="System.Data.SqlClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table style="width: 664px">
        <tr>
            <td class="td_head" colspan="4" style="height: 17px">
                WORK PERMIT DETAILS</td>
        </tr>
        <tr>
            <td style="width: 100px">
                Empno</td>
            <td >
                <asp:TextBox ID="TextBox1" runat="server" BackColor="#FFFF80" Width="74px" AutoPostBack="True"></asp:TextBox></td>
                <td>                Selected Record No</td>
                <td>
                    <asp:Label ID="lblrno" runat="server" Font-Size="Small" ForeColor="Maroon" Visible="False"></asp:Label></td>

        </tr>
        <tr>
            <td colspan="4">
                 <asp:Label ID="lblinfo" runat="server" Visible=false  Font-Size="Small" ForeColor="DarkRed" Text="Label"></asp:Label>
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CellPadding="2" ForeColor="Black" Width="471px" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px">
                    <Columns>
                        <asp:TemplateField HeaderText="rno" InsertVisible="False" SortExpression="rno">
                            <EditItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("rno") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" Font-Underline="True" ForeColor="SteelBlue" Text='<%# Eval("rno") %>'
                                 CommandArgument= '<%# Eval("rno", "{0}") %>'  OnCommand = "Getdetails"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="passportno" HeaderText="passportno" SortExpression="passportno" />
                        <asp:BoundField DataField="visavalidfrom" HeaderText="visavalidfrom" SortExpression="visavalidfrom" DataFormatString="{0:dd/MM/yy}" HtmlEncode="false"/>
                        <asp:BoundField DataField="visavalidto" HeaderText="visavalidto" SortExpression="visavalidto" DataFormatString="{0:dd/MM/yy}" HtmlEncode="false"  />
                        <asp:BoundField DataField="visareferenceno" HeaderText="visareferenceno" SortExpression="visareferenceno" />
                    </Columns>
                    <FooterStyle BackColor="Tan" />
                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                    <HeaderStyle BackColor="Tan" Font-Bold="True" />
                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT [passportno], [visavalidfrom], [visavalidto], [visareferenceno], [rno] FROM [workpermitdetails] WHERE ([empcode] = @empcode)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="TextBox1" Name="empcode" PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
               </td>
        </tr>
        <tr>
            <td style="width: 100px">
                Visa Type</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtvtype" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtvtype"
                    ErrorMessage="*" ValidationGroup="a"></asp:RequiredFieldValidator></td>
            <td style="width: 100px">
                Work Permit No</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtpermit" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtpermit"
                    ErrorMessage="*" ValidationGroup="a"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 100px">
                Visa valid From
            </td>
            <td style="width: 100px">
                <asp:TextBox ID="txtvfrom" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtvfrom"
                    ErrorMessage="*" ValidationGroup="a"></asp:RequiredFieldValidator></td>
            <td style="width: 100px">
                Visa Valid Till</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtvto" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtvto"
                    ErrorMessage="*" ValidationGroup="a"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 100px">
                No.Of yrs</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtyrs" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtyrs"
                    ErrorMessage="*" ValidationGroup="a"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtyrs"
                    ErrorMessage="!" ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$" ValidationGroup="a">Only Numbers </asp:RegularExpressionValidator></td>
            <td style="width: 100px">
                Ref.No</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtrefno" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtrefno"
                    ErrorMessage="*" ValidationGroup="a"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 100px">
                Date of Issue</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtdoi" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtdoi" ErrorMessage="*" ValidationGroup="a"></asp:RequiredFieldValidator></td>
            <td style="width: 100px">
                Place of Issue</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtpoi" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtpoi"
                    ErrorMessage="*" ValidationGroup="a"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 100px">
                Receipt No.</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtreceipt" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtreceipt"
                    ErrorMessage="*" ValidationGroup="a"></asp:RequiredFieldValidator></td>
            <td style="width: 100px">
                Contract Renewed</td>
            <td style="width: 100px">
                <asp:TextBox ID="TxtContractRenewed" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="TxtContractRenewed"
                    ErrorMessage="*" ValidationGroup="a"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td class="td_head" colspan="4" style="height: 17px">
                FEE PAID DETAILS</td>
        </tr>
        <tr>
            <td style="width: 100px">
                Pass</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtpass" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtpass"
                    ErrorMessage="*" ValidationGroup="a"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtpass"
                    ErrorMessage="!" ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$" ValidationGroup="a">Only Numbers </asp:RegularExpressionValidator></td>
            <td style="width: 100px">
                Levy</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtlevy" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtlevy"
                    ErrorMessage="*" ValidationGroup="a"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtlevy"
                    ErrorMessage="!" ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$" ValidationGroup="a">Only Numbers </asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 41px;">
                Visa</td>
            <td style="width: 100px; height: 41px;">
                <asp:TextBox ID="txtvisa" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtvisa"
                    ErrorMessage="*" ValidationGroup="a"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtvisa"
                    ErrorMessage="!" ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$" ValidationGroup="a">Only Numbers </asp:RegularExpressionValidator></td>
            <td style="width: 100px; height: 41px;">
                Process</td>
            <td style="width: 100px; height: 41px;">
                <asp:TextBox ID="txtprocess" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtprocess" ErrorMessage="*" ValidationGroup="a"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtprocess"
                    ErrorMessage="!" ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$" ValidationGroup="a">Only Numbers </asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td class="td_head" colspan="4">
                BANK GUARANTEE</td>
        </tr>
        <tr>
            <td style="width: 100px">
                Bank Guarantee SerialNo.</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtbgno" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtbgno"
                    ErrorMessage="*" ValidationGroup="a"></asp:RequiredFieldValidator></td>
            <td style="width: 100px">
                Bank Guarantee Expiry Date</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtbgdate" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtbgdate"
                    ErrorMessage="*" ValidationGroup="a"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 100px">
                Bank Guarantee Amount</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtbgamt" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtbgamt" ErrorMessage="*" ValidationGroup="a"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtbgamt"
                    ErrorMessage="!" ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$" ValidationGroup="a">Only Numbers </asp:RegularExpressionValidator></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td class="td_head" colspan="4">
                INSURANCE</td>
        </tr>
        <tr>
            <td style="width: 100px">
                Insurance Policy No.</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtino" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtino"
                    ErrorMessage="*" ValidationGroup="a"></asp:RequiredFieldValidator></td>
            <td style="width: 100px">
                Insurance Expiry Date</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtidate" runat="server" Width="150px"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtidate" ErrorMessage="*" ValidationGroup="a"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="right" colspan="4">
                <asp:Button ID="Button1" runat="server" Text="SAVE" SkinID="buttonskin1" ValidationGroup="a" /></td>
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
        </tr>
    </table>
    <br />
    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="cal_Theme1"
        Format="dd/MM/yy" PopupButtonID="txtvfrom" TargetControlID="txtvfrom">
    </cc1:CalendarExtender>
    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="cal_Theme1"
        Format="dd/MM/yy" PopupButtonID="txtvto" TargetControlID="txtvto">
    </cc1:CalendarExtender>
    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" CssClass="cal_Theme1"
        Format="dd/MM/yy" PopupButtonID="txtdoi" TargetControlID="txtdoi">
    </cc1:CalendarExtender>
    <cc1:CalendarExtender ID="CalendarExtender4" runat="server" CssClass="cal_Theme1"
        Format="dd/MM/yy" PopupButtonID="txtbgdate" TargetControlID="txtbgdate">
    </cc1:CalendarExtender>
    <cc1:CalendarExtender ID="CalendarExtender5" runat="server" CssClass="cal_Theme1"
        Format="dd/MM/yy" PopupButtonID="txtidate" TargetControlID="txtidate">
    </cc1:CalendarExtender>

    <cc1:CalendarExtender ID="CalendarExtender6" runat="server" CssClass="cal_Theme1"
        Format="dd/MM/yy" PopupButtonID="TxtContractRenewed" TargetControlID="TxtContractRenewed">
    </cc1:CalendarExtender>

</asp:Content>

