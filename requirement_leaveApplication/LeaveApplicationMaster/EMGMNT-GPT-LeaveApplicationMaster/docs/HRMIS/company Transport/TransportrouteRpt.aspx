<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="TransportrouteRpt.aspx.vb" Inherits="E_Management.TransportrouteRpt" 
%>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    &nbsp;<table style="width: 494px; border-right: 1px solid; border-top: 1px solid; border-left: 1px solid; border-bottom: 1px solid;">
        <tr>
            <td class="td_head">
                ROUTE AND AREA REPORTS</td>
        </tr>
        <tr>
            <td>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True">
                    <asp:ListItem Value="R">Route List</asp:ListItem>
                    <asp:ListItem Value="RA">List Area by Route</asp:ListItem>
                    <asp:ListItem Value="ER">Employee List By Route</asp:ListItem>
                    <asp:ListItem Value="ERA">Emp List By Route and Area</asp:ListItem>
                    <asp:ListItem Selected="True">None</asp:ListItem>
                </asp:RadioButtonList>&nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;<asp:Label ID="Label2" runat="server" Text="Route" Visible="False"></asp:Label>
                <asp:DropDownList ID="ddlroute" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource1"
                    DataTextField="route" DataValueField="route" Visible="False">
                    <asp:ListItem Selected="True" Value="-1">--Select Route--</asp:ListItem>
                    <asp:ListItem Value="OA">--OVERALL--</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td>
                &nbsp;<asp:Label ID="Label1" runat="server" Text="Area" Visible="False"></asp:Label>
                &nbsp;<asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True"
                    DataSourceID="SqlDataSource2" DataTextField="area" DataValueField="area" Visible="False">
                    <asp:ListItem Selected="True" Value="-1">--Select area--</asp:ListItem>
                    <asp:ListItem Value="OA">--OVERALL--</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="td_head" style="height: 17px">
                SUPPLIER AND PICK UP TIME REPORTS</td>
        </tr>
        <tr>
            <td>
                <asp:RadioButtonList ID="RadioButtonList2" runat="server" AutoPostBack="True">
                    <asp:ListItem Value="S">Supplier Details</asp:ListItem>
                    <asp:ListItem Value="SR">Supplier By Route</asp:ListItem>
                    <asp:ListItem Value="PT">Pickup Time </asp:ListItem>
                    <asp:ListItem Value="BV">Bus/Van Cost </asp:ListItem>
                    <asp:ListItem Selected="True">None</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td class="td_head">
                EMPLOYEE OWN VEHICLE REPORTS</td>
        </tr>
        <tr>
            <td style="height: 115px">
                <asp:RadioButtonList ID="RadioButtonList3" runat="server" AutoPostBack="True">
                    <asp:ListItem Value="D">By Dept</asp:ListItem>
                    <asp:ListItem Value="S">By Sect</asp:ListItem>
                    <asp:ListItem Value="E">By Emp</asp:ListItem>
                    <asp:ListItem Value="O">All</asp:ListItem>
                    <asp:ListItem Selected="True">None</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbldept" runat="server" Text="Dept :" Visible="False"></asp:Label>&nbsp;
                <asp:DropDownList ID="ddldept" runat="server" DataSourceID="Sqldept" DataTextField="dept"
                    DataValueField="departmentcode" Visible="False">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblsect" runat="server" Text="Sect :" Visible="False"></asp:Label>
                &nbsp;
                <asp:DropDownList ID="ddlsect" runat="server" DataSourceID="SqlSect" DataTextField="section"
                    DataValueField="sectioncode" Visible="False">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblemp" runat="server" Text="Emp  :" Visible="False"></asp:Label>&nbsp;
                &nbsp;<asp:TextBox ID="txtemp" runat="server" Visible="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right" style="border-top: 1px solid">
                <asp:Button ID="Button1" runat="server" SkinID="buttonskin1" Text="Generate" /></td>
        </tr>
    </table>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT [route] FROM [trans_routemaster] ORDER BY [route]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="SELECT [area] FROM [trans_areamaster] ORDER BY [area]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="Sqldept" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="select departmentcode +'-'+ departmentname as dept,departmentcode from department order by dept">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlSect" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="select sectioncode + '-' + sectionname as section,sectioncode from sectionmaster order by section">
    </asp:SqlDataSource>

</asp:Content>
