<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="UpdatedKPIindividualScreen1.aspx.vb" Inherits="E_Management.UpdatedKPIindividualScreen1" 
    title="Updated KPI by Individual" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server"><table cellpadding="0" cellspacing="0">
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
                <asp:Panel ID="Panel1" runat="server" GroupingText="Select KPI Reports">
                    <table style="width: 239px">
                        <tr>
                            <td style="width: 280px">
                                Choose Year</td>
                            <td style="width: 563px; height: 21px">
                               <asp:DropDownList ID="yearddl" runat="server">
                                  
                                <asp:ListItem Value=2010>2010-2011</asp:ListItem>
                                <asp:ListItem Value=2011>2011-2012</asp:ListItem>
                                <asp:ListItem Value=2012>2012-2013</asp:ListItem>
                                <asp:ListItem value=2013>2013-2014</asp:ListItem>
                                <asp:ListItem value=2014>2014-2015</asp:ListItem>
                                <asp:ListItem Value=2015>2015-2016</asp:ListItem>
                                <asp:ListItem Value=2016>2016-2017</asp:ListItem>
                                <asp:ListItem Value=2017>2017-2018</asp:ListItem>
                                <asp:ListItem Value=2018>2018-2019</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="-1">--Select--</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="yearddl"
                                    ErrorMessage="!" InitialValue="-1"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 280px">
                                Choose Month</td>
                            <td style="width: 563px; height: 21px">
                                <asp:DropDownList ID="monthddl" runat="server">
                                    <asp:ListItem Value="-1">---Select---</asp:ListItem>
                                    <asp:ListItem Value="1">January</asp:ListItem>
                                    <asp:ListItem Value="2">February</asp:ListItem>
                                    <asp:ListItem Value="3">March</asp:ListItem>
                                    <asp:ListItem Value="4">April</asp:ListItem>
                                    <asp:ListItem Value="5">May</asp:ListItem>
                                    <asp:ListItem Value="6">June</asp:ListItem>
                                    <asp:ListItem Value="7">July</asp:ListItem>
                                    <asp:ListItem Value="8">August</asp:ListItem>
                                    <asp:ListItem Value="9">September</asp:ListItem>
                                    <asp:ListItem Value="10">October</asp:ListItem>
                                    <asp:ListItem Value="11">November</asp:ListItem>
                                    <asp:ListItem Value="12">December</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="monthddl"
                                    ErrorMessage="!" InitialValue="-1" Width="7px"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 280px">
                                Employee code</td>
                            <td style="width: 563px">
                                <asp:TextBox ID="txtempidr" runat="server" AutoPostBack="True" Width="83px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtempidr"
                                    ErrorMessage="!"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="text-align: center;" colspan="2">
                                <asp:Button ID="btnshow" runat="server" SkinID="buttonskin1" Text="SHOW" /></td>
                        </tr>
                    </table>
                </asp:Panel>
                &nbsp; &nbsp;&nbsp; &nbsp;<br />
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT DISTINCT [KPI_Year] FROM [KPI_MajorSetting] ORDER BY [KPI_Year]">
                </asp:SqlDataSource>
         
           </td>
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
