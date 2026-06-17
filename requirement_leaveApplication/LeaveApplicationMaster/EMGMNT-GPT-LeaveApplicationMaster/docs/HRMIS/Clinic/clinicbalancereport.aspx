<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="clinicbalancereport.aspx.vb" Inherits="E_Management.clinicbalancereport" 
    title="Untitled Page" %>
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
                <table id="TABLE2" language="javascript" onclick="return TABLE1_onclick()">
                    <tr>
                        <td class="td_head" colspan="2" >
                            CLINIC BALANCE REPORT</td>                      
                    </tr>
                    <tr>
                    <td bgcolor="beige">
                      Employee No :</td>
                    <td >
                        <asp:TextBox ID="empcode" runat="server" Width="70px"></asp:TextBox>
                        <asp:CheckBox ID="cb1" runat="server" AutoPostBack="True" Text="By EmpNo" /></td>
                    </tr>
                    <tr>
                        <td bgcolor="beige">
                        Select by :</td>
                        <td>
                            <asp:RadioButtonList ID="rb1" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                                <asp:ListItem Value="D" Selected="True">Department</asp:ListItem>
                                <asp:ListItem Value="S">Section</asp:ListItem>
                                <asp:ListItem Value="C">Category</asp:ListItem>
                            </asp:RadioButtonList></td>
                    </tr>
                    <tr>
                        <td bgcolor="beige">
                            Department :</td>
                        <td>
                            <asp:DropDownList ID="dept" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource1" DataTextField="Column1" DataValueField="departmentcode">
                                <asp:ListItem Value="-1">Select Department</asp:ListItem>
                            </asp:DropDownList>&nbsp;
                            <asp:CheckBox ID="cb2" runat="server" AutoPostBack="True" Text="All Department" /></td>
                    </tr>
                    <tr>
                        <td bgcolor="beige">
                            Section :</td>
                        <td>
                            <asp:DropDownList ID="sec" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource2" DataTextField="Column1" DataValueField="sectioncode">
                                <asp:ListItem Value="-1">Select Section</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td bgcolor="beige" >
                            Category :</td>
                        <td >
                            <asp:DropDownList ID="cat" runat="server">
                                <asp:ListItem Value="-1">Select Category</asp:ListItem>
                                <asp:ListItem Value="GL">Local</asp:ListItem>
                                <asp:ListItem Value="GF">Foreigners</asp:ListItem>
                                <asp:ListItem Value="LO">Local Operators</asp:ListItem>
                                <asp:ListItem Value="FO">Foreign Operators</asp:ListItem>
                                <asp:ListItem Value="ST">Staff</asp:ListItem>
                            </asp:DropDownList></td>                               
                    </tr>
                  <tr>
                  <td bgcolor="beige" >
                      </td>
                  <td >
                      <asp:Button ID="save" runat="server" BackColor="LightSteelBlue" Text="Save" /></td>
                      <tr>
                          <td colspan="2" align="right">
                              </td>
                      </tr>
                      </table>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="select departmentcode +'--'+ departmentname,departmentcode from department order by departmentcode">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="select sectioncode +'--'+ sectionname,sectioncode from sectionmaster order by sectioncode">
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
