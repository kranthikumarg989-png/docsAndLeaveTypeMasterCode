<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="OperatorKPI.aspx.vb" Inherits="E_Management.OperatorKPI" 
    title="Operator KPI" %>
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
                &nbsp;<table>
                    <tr>
                        <td style="width: 100px">
                <asp:Panel ID="Panel1" runat="server" GroupingText="Key in Empcode">
                 <table style="width: 586px">
                                
                                <tr>
                                    <td style="height: 17px; background-color: beige; width: 80px;">
                                        EmpCode</td>
                                    <td style="width: 196px; background-color: beige;">
                                        <asp:TextBox ID="txtempcode" runat="server" AutoPostBack="True" Width="81px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtempcode"
                                            ErrorMessage="!"></asp:RequiredFieldValidator></td>
                                    <td style="background-color: beige; width: 120px;">
                                        EmpName</td>
                                    <td style="background-color: beige; width: 196px;">
                                        <asp:Label ID="lblename" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="background-color: beige; width: 80px;">
                                        Department</td>
                                    <td style="background-color: beige; width: 196px;">
                                        <asp:Label ID="lbldept" runat="server"></asp:Label></td>
                                    <td style="background-color: beige; width: 120px;">
                                        Section</td>
                                    <td style="background-color: beige; width: 196px;">
                                        <asp:Label ID="lblsect" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="background-color: beige; width: 120px;">
                                        Year</td>
                                    <td style="background-color: beige; width: 196px;">
                                        <asp:DropDownList ID="ddlyr" runat="server" AutoPostBack="True">
                                            <asp:ListItem>2011-2012</asp:ListItem>
                                            <asp:ListItem>2012-2013</asp:ListItem>
                                            <asp:ListItem>2013-2014</asp:ListItem>
                                            <asp:ListItem>2014-2015</asp:ListItem>
                                            <asp:ListItem>2015-2016</asp:ListItem>
                                            <asp:ListItem>2016-2017</asp:ListItem>
                                            <asp:ListItem>2017-2018</asp:ListItem>
                                            <asp:ListItem>2018-2019</asp:ListItem>
                                            <asp:ListItem>2019-2020</asp:ListItem>
                                            <asp:ListItem Selected="True" Value="-1">--Select--</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlyr"
                                            ErrorMessage="!" InitialValue="-1"></asp:RequiredFieldValidator></td>
                                    <td style="background-color: beige; width: 120px;">
                                        Options</td>
                                    <td style="background-color: beige; width: 196px;">
                                        <asp:DropDownList ID="ddlmon" runat="server" AutoPostBack="True">
                                            <asp:ListItem>1stHalf</asp:ListItem>
                                            <asp:ListItem>2ndHalf</asp:ListItem>
                                            <asp:ListItem Selected="True" Value="-1">--Select--</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlmon"
                                            ErrorMessage="!" InitialValue="-1"></asp:RequiredFieldValidator></td>
                                </tr>
                             <tr>
                             </table>
                    <asp:Label ID="lblmsg" runat="server"></asp:Label></asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; height: 139px">
                            <asp:Panel ID="Panel2" runat="server" GroupingText="1st Half">
                                <table style="width: 544px; border-right: dimgray 1px solid; border-top: dimgray 1px solid; border-left: dimgray 1px solid; border-bottom: dimgray 1px solid;">
                                    <tr>
                                        <td style="width: 100px; height: 26px; background-color: dimgray; color: #ffffff;">
                                        </td>
                                        <td style="width: 100px; color: #ffffff; height: 28px; background-color: dimgray">
                                            April</td>
                                        <td style="width: 100px; color: #ffffff; height: 28px; background-color: dimgray">
                                            May</td>
                                        <td style="width: 100px; color: #ffffff; height: 28px; background-color: dimgray">
                                            June</td>
                                        <td style="width: 100px; color: #ffffff; height: 28px; background-color: dimgray">
                                            July</td>
                                        <td style="width: 100px; color: #ffffff; height: 28px; background-color: dimgray">
                                            Aug</td>
                                        <td style="width: 100px; color: #ffffff; height: 28px; background-color: dimgray">
                                            Sep</td>
                                        <td style="width: 100px; color: #ffffff; height: 28px; background-color: dimgray">
                                            Average</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; color: #ffffff; height: 26px; background-color: dimgray">
                                            Points</td>
                                        <td style="width: 100px; height: 26px">
                                            <asp:TextBox ID="papril" runat="server" AutoPostBack="True" MaxLength="3" Width="45px" OnTextChanged="Calculatetotal1" Enabled="False">0</asp:TextBox></td>
                                        <td style="width: 100px; height: 26px">
                                            <asp:TextBox ID="pmay" runat="server" AutoPostBack="True" MaxLength="3" Width="45px" OnTextChanged="Calculatetotal2" Enabled="False">0</asp:TextBox></td>
                                        <td style="width: 100px; height: 26px">
                                            <asp:TextBox ID="pjune" runat="server" AutoPostBack="True" MaxLength="3" Width="45px" OnTextChanged="Calculatetotal3" Enabled="False">0</asp:TextBox></td>
                                        <td style="width: 100px; height: 26px">
                                            <asp:TextBox ID="pjuly" runat="server" AutoPostBack="True" MaxLength="3" Width="45px" OnTextChanged="Calculatetotal4" Enabled="False">0</asp:TextBox></td>
                                        <td style="width: 100px; height: 26px">
                                            <asp:TextBox ID="paug" runat="server" AutoPostBack="True" MaxLength="3" Width="45px" OnTextChanged="Calculatetotal5" Enabled="False">0</asp:TextBox></td>
                                        <td style="width: 100px; height: 26px">
                                            <asp:TextBox ID="psep" runat="server" AutoPostBack="True" MaxLength="3" Width="45px" OnTextChanged="Calculatetotal6" Enabled="False">0</asp:TextBox></td>
                                        <td style="width: 100px; height: 26px">
                                            <asp:Label ID="pavg1" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; color: #ffffff; height: 26px; background-color: dimgray">
                                            Grade</td>
                                        <td style="width: 100px">
                                            <asp:Label ID="Gapril" runat="server"></asp:Label></td>
                                        <td style="width: 100px">
                                            <asp:Label ID="gmay" runat="server"></asp:Label></td>
                                        <td style="width: 100px">
                                            <asp:Label ID="Gjune" runat="server"></asp:Label></td>
                                        <td style="width: 100px">
                                            <asp:Label ID="Gjuly" runat="server"></asp:Label></td>
                                        <td style="width: 100px">
                                            <asp:Label ID="Gaug" runat="server"></asp:Label></td>
                                        <td style="width: 100px">
                                            <asp:Label ID="Gsep" runat="server"></asp:Label></td>
                                        <td style="width: 100px">
                                            <asp:Label ID="gavg1" runat="server"></asp:Label></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            <asp:Panel ID="Panel3" runat="server" GroupingText="2nd Half">
                                <table style="width: 544px; border-right: dimgray 1px solid; border-top: dimgray 1px solid; border-left: dimgray 1px solid; border-bottom: dimgray 1px solid;">
                                    <tr>
                                        <td style="width: 100px; height: 28px; background-color: #333333">
                                        </td>
                                        <td style="width: 100px; color: #ffffff; height: 28px; background-color: #333333">
                                            Oct</td>
                                        <td style="width: 100px; color: #ffffff; height: 28px; background-color: #333333">
                                            Nov</td>
                                        <td style="width: 100px; color: #ffffff; height: 28px; background-color: #333333">
                                            Dec</td>
                                        <td style="width: 100px; color: #ffffff; height: 28px; background-color: #333333">
                                            Jan</td>
                                        <td style="width: 100px; color: #ffffff; height: 28px; background-color: #333333">
                                            Feb</td>
                                        <td style="width: 100px; color: #ffffff; height: 28px; background-color: #333333">
                                            Mar</td>
                                        <td style="width: 100px; color: #ffffff; height: 28px; background-color: #333333">
                                            Average</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; color: #ffffff; height: 26px; background-color: #333333">
                                            Points</td>
                                        <td style="width: 100px; height: 26px">
                                            <asp:TextBox ID="poct" runat="server" AutoPostBack="True" MaxLength="3" Width="45px" OnTextChanged="Calculatetotal7" Enabled="False">0</asp:TextBox></td>
                                        <td style="width: 100px; height: 26px">
                                            <asp:TextBox ID="pnov" runat="server" AutoPostBack="True" MaxLength="3" Width="45px" OnTextChanged="Calculatetotal8" Enabled="False">0</asp:TextBox></td>
                                        <td style="width: 100px; height: 26px">
                                            <asp:TextBox ID="pdec" runat="server" AutoPostBack="True" MaxLength="3" Width="45px" OnTextChanged="Calculatetotal9" Enabled="False">0</asp:TextBox></td>
                                        <td style="width: 100px; height: 26px">
                                            <asp:TextBox ID="pjan" runat="server" AutoPostBack="True" MaxLength="3" Width="45px" OnTextChanged="Calculatetotal10" Enabled="False">0</asp:TextBox></td>
                                        <td style="width: 100px; height: 26px">
                                            <asp:TextBox ID="pfeb" runat="server" AutoPostBack="True" MaxLength="3" Width="45px" OnTextChanged="Calculatetotal11" Enabled="False">0</asp:TextBox></td>
                                        <td style="width: 100px; height: 26px">
                                            <asp:TextBox ID="pmar" runat="server" AutoPostBack="True" MaxLength="3" Width="45px" OnTextChanged="Calculatetotal12" Enabled="False">0</asp:TextBox></td>
                                        <td style="width: 100px; height: 26px">
                                            <asp:Label ID="pavg2" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; color: #ffffff; height: 26px; background-color: #333333">
                                            Grade</td>
                                        <td style="width: 100px">
                                            <asp:Label ID="Goct" runat="server"></asp:Label></td>
                                        <td style="width: 100px">
                                            <asp:Label ID="gnov" runat="server"></asp:Label></td>
                                        <td style="width: 100px">
                                            <asp:Label ID="gdec" runat="server"></asp:Label></td>
                                        <td style="width: 100px">
                                            <asp:Label ID="gjan" runat="server"></asp:Label></td>
                                        <td style="width: 100px">
                                            <asp:Label ID="gfeb" runat="server"></asp:Label></td>
                                        <td style="width: 100px">
                                            <asp:Label ID="gmar" runat="server"></asp:Label></td>
                                        <td style="width: 100px">
                                            <asp:Label ID="gavg2" runat="server"></asp:Label></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 100px">
                            <asp:Button ID="btnsave" runat="server" Text="SAVE" /></td>
                    </tr>
                </table>
            
            
      
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
