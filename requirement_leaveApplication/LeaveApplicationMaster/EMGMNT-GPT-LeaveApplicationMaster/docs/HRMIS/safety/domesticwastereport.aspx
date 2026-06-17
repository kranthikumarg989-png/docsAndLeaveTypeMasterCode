<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="domesticwastereport.aspx.vb" Inherits="E_Management.domesticwastereport" 
    title="Schedule/ Domestic Waste Reports" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="16">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" height="16">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 24px">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif" style="height: 622px" width="16">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" style="height: 622px" valign="top">
                <table id="TABLE1" language="javascript" onclick="return TABLE1_onclick()">
                    <tr>
                        <td class="td_head" colspan="4" width="25%">
                            Schedule / Domestic Waste Consignment Reports</td>
                       
                    </tr>
                    <tr>
                    <td style="width: 17%; height: 26px" >
                        Select Date</td>
                    <td width="25%" style="height: 26px" >
                        <asp:TextBox ID="fromdate" runat="server" Width="102px" ForeColor="DimGray">From date</asp:TextBox>
                       ~<asp:TextBox ID="todate" runat="server" Width="105px" ForeColor="DimGray">To date</asp:TextBox></td>
                    <td width="25%" colspan="2" style="height: 26px" ></td>
                    </tr>
                    <tr>
                        <td style="width: 17%; height: 35px">
                            Report By</td>
                        <td colspan="3" style="height: 35px" valign="middle">
                            <asp:RadioButtonList ID="rb1" runat="server" RepeatDirection="Horizontal" AutoPostBack="True">
                                <asp:ListItem Value="1">Overall Department (Weight)</asp:ListItem>
                                <asp:ListItem Value="2">Supplier</asp:ListItem>
                                <asp:ListItem Value="3">Items</asp:ListItem>
                                <asp:ListItem Value="4" Selected="True">Overall</asp:ListItem>
                            </asp:RadioButtonList></td>
                    </tr>
                    <tr>
                        <td style="width: 17%" >
                            Disposal Details
                            By Items</td>
                        <td width="25%" colspan="3">
                            <asp:DropDownList ID="items" runat="server" DataSourceID="SqlDataSource1" DataTextField="Item" DataValueField="Item" AppendDataBoundItems="True" Width="225px">
                                <asp:ListItem Value="-1">Select Item</asp:ListItem>
                            </asp:DropDownList></td>
                       </tr>
                     <tr>
                        <td style="width: 17%" >
                            Disposal Details By Supplier</td>
                        <td width="25%" colspan="3">
                            <asp:DropDownList ID="supplier" runat="server" DataSourceID="SqlDataSource2" DataTextField="suppliername" DataValueField="suppliername" AppendDataBoundItems="True" Width="226px">
                                <asp:ListItem Value="-1">Select Supplier</asp:ListItem>
                            </asp:DropDownList></td>
                     </tr>
                    <tr>
                    <td width="25%" colspan="2"></td>
                    <td width="25%" colspan="2"><asp:Button ID="show" runat="server" Text="Show Report" BackColor="LightGray"/></td>
                   </tr>
                    <tr>
                 </tr>
                </table>
                <cc1:CalendarExtender ID="CalendarExtender1" TargetControlID="fromdate" cssclass="cal_Theme1" format="dd/MM/yy" runat="server"></cc1:CalendarExtender>
                <cc1:CalendarExtender ID="CalendarExtender2" TargetControlID="todate" cssclass="cal_Theme1" format="dd/MM/yy" runat="server"></cc1:CalendarExtender>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="select Description,Item from safety_schedulemaster order by Description">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="select suppliername from safety_supplier order by suppliername"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="select departmentcode+ '--' +departmentname,departmentcode from department order by departmentcode ">
                </asp:SqlDataSource>
            </td>
            <td background="../../images/cen_rig.gif" style="width: 24px">
                <img height="11" src="../../images/cen_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td height="16" width="16">
                <img height="16" src="../../images/bot_lef.gif" width="16" /></td>
            <td background="../../images/bot_mid.gif" height="16">
                <img height="16" src="../../images/bot_mid.gif" width="16" /></td>
            <td height="16" style="width: 24px">
                <img height="16" src="../../images/bot_rig.gif" width="24" /></td>
        </tr>
    
        
    </table>
    
</asp:Content>
