<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="shiftreport.aspx.vb" Inherits="E_Management.shiftreport" 
    title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <br />
    <table>
        <tr>
            <td align="left" valign="top">
<table border="1" bordercolor="#000099">
    <tr>
        <td colspan="2" class="td_head">
            <strong>SHIFT REPORT</strong></td>
        </tr>
<tr>
<td bgcolor="beige" style="width: 6px">
    Groupcode</td>
<td >
    <asp:DropDownList ID="grcde" runat="server" DataSourceID="SqlDataSource1" DataTextField="groupcode" DataValueField="groupcode" AppendDataBoundItems="True">
        <asp:ListItem Value="-1">Select</asp:ListItem>
    </asp:DropDownList></td>
</tr>
    <tr>
        <td bgcolor="beige" style="width: 6px">
            SelectDate</td>
        <td>
            <asp:TextBox ID="fdt" runat="server" Width="60px" ForeColor="DimGray">From date</asp:TextBox>~<asp:TextBox ID="tdt"
                runat="server" Width="60px" ForeColor="Gray">To date</asp:TextBox></td>
    </tr>
    <tr>
    <td colspan="2" align="right">
        <asp:Label ID="errmsg" runat="server" Font-Underline="True" ForeColor="Red"></asp:Label><asp:Button
            ID="search" runat="server" BackColor="LightSteelBlue" Text="Search" />
    </td>
    </tr>
</table>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderColor="Black"
                    CellPadding="4" ForeColor="#333333" AllowPaging="True" AllowSorting="True" BorderWidth="1px" PageSize="25">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                    <asp:TemplateField HeaderText="No">
                    <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="groupcode" HeaderText="Groupcode" SortExpression="groupcode"/>
                    <asp:BoundField DataField="shiftdate" HeaderText="ShiftDate" SortExpression="shiftdate" dataformatstring="{0:dd-MMM-yyy}" HtmlEncode=False />
                    <asp:BoundField DataField="shiftcode" HeaderText="ShiftCode" SortExpression="shiftcode"/>
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Underline="True" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="select distinct(groupcode) from trans_shiftfinal"></asp:SqlDataSource>
    <cc1:calendarextender id="ccefrom" runat="server" cssclass="cal_Theme1" format="dd/MM/yy" popupbuttonid="fdt" targetcontrolid="fdt"></cc1:calendarextender>
    <cc1:calendarextender id="cceto" runat="server" cssclass="cal_Theme1" format="dd/MM/yy" popupbuttonid="tdt" targetcontrolid="tdt"></cc1:calendarextender>
    <br />
</asp:Content>


