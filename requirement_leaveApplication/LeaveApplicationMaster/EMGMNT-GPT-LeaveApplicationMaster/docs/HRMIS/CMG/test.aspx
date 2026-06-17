<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="test.aspx.vb" Inherits="E_Management.test2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
        <link rel="stylesheet" type="text/css" href="~/css/style.css" /> 
            <link rel="stylesheet" type="text/css" href="~/css/stylesheet.css" />
                      
</head>
  
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
     <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="16" style="height: 16px">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" style="height: 16px; width: 1262px;">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 14px; height: 16px;">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif" style="height: 622px" width="16">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" style="height: 622px; width: 1262px;" valign="top">

<table id="TABLE2">
    <tr>
        <td colspan="1" class="td_head" style="width: 619px; height: 40px;">
                        <asp:Label ID="Label1" runat="server" Font-Underline="False" ForeColor="White" Text="Change Section, Department, Transfer, Promotion, Confirmation, Contract Extension, Contract Termination, Contract Extension (Malay)   " Font-Bold="True" Width="621px"></asp:Label></td>
    </tr>
        <tr>
            <td style="width: 619px; height: 227px; text-align: center;" valign="top" align="center">
                <table id="TABLE1" onclick="return TABLE1_onclick()" border="1" cellpadding="1" cellspacing="1"><tr>
                    <td style="width: 77px; background-color: beige; height: 26px;" valign="top" align="left">
                        <asp:Label ID="Label2" runat="server" Text="Employee No." Width="94px"></asp:Label></td>
                    <td style="width: 214px; height: 26px;" valign="top" align="left">
                        <asp:TextBox ID="empcode" runat="server" Width="173px" AutoPostBack="True"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="V1" runat="server" ControlToValidate="empcode"
                            ErrorMessage="Code !"></asp:RequiredFieldValidator>--%></td>
                    <td style="width: 125px; background-color: beige; height: 26px;" valign="top" align="left">
                        <asp:Label ID="Label14" runat="server" Text="Employee Name" Width="113px"></asp:Label></td>
                    <td style="width: 171px; height: 26px;" valign="top" align="left">
                        &nbsp;<asp:Label ID="Label11" runat="server" Width="170px"></asp:Label>
                    </td>
                </tr>
                    <tr>
                        <td style="width: 77px; background-color: beige; height: 11px;" valign="top" align="left">
                            <asp:Label ID="Label3" runat="server" Text="Department" Width="69px"></asp:Label></td>
                        <td style="width: 214px; height: 11px;" valign="top" align="left">
                            &nbsp;<asp:Label ID="Label13" runat="server" Width="175px"></asp:Label>
                        </td>
                    <td align="left" style="width: 125px; background-color: beige; height: 11px;" valign="top">
                        <asp:Label ID="Label15" runat="server" Text="Section" Width="122px" ForeColor="Black"></asp:Label></td>
                    <td align="left" style="width: 171px; height: 11px;" valign="top">
                        &nbsp;<asp:Label ID="Label10" runat="server" Width="172px"></asp:Label>
                    </td>
                    </tr>
                    <tr>
                        <td style="height: 20px;" class="td_head" colspan="4" rowspan="" title=" BACKGROUND-COLOR:lightgrey">
                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Underline="False" ForeColor="White"
                                Text="Options to Change"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="4" rowspan="" style="height: 39px; background-color: beige; text-align: center;" title=" "><table id="Table3" onclick="return TABLE1_onclick()" cellpadding="1" cellspacing="1">
                            <tr>
                                <td style="width: 98px; background-color: beige; height: 11px;" valign="middle" align="left">
                                    <asp:Label ID="Label5" runat="server" Text="Choose Option" Width="71px"></asp:Label></td>
                                <td style="width: 310px; height: 11px;" valign="middle" align="left">
                                    &nbsp;<asp:DropDownList ID="ptype" runat="server" Width="175px" AppendDataBoundItems="True" AutoPostBack="True">
                                        <asp:ListItem Value="-1">---Select---</asp:ListItem>
                                        <asp:ListItem>Transfer</asp:ListItem>
                                        <asp:ListItem>Promotion</asp:ListItem>
                                        <asp:ListItem>Contract Termination</asp:ListItem>
                                        <asp:ListItem>Contract Extension (Tempatan)</asp:ListItem>
                                        <asp:ListItem>Contract Extension (Warga Asing) </asp:ListItem>
                                        <asp:ListItem>Promotion - New Group PFP</asp:ListItem>
                                        <asp:ListItem>Confirmation</asp:ListItem>
                                        <asp:ListItem>Contract Extension</asp:ListItem>
                                        <asp:ListItem>Contract Extension on PFP</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td align="left" style="width: 206px; height: 11px" valign="middle">
                                    &nbsp; &nbsp; &nbsp;
                                </td>
                            </tr>
                        </table>
                        <asp:Label ID="lblmsg" runat="server" ForeColor="Green"></asp:Label>
                            &nbsp;
                            <asp:Label ID="lblcode" runat="server" Visible="False"></asp:Label></td>
                    </tr>
                </table>
                &nbsp;<br />
                <asp:Panel ID="trfrpanel" runat="server">
                    <table border="1" style="width: 619px">
                        <tr>
                            <td colspan="2" style="height: 30px; background-color: beige">
                                TRANSFER - Change Section/ Department Transfer</td>
                        </tr>
                        <tr>
                            <td style="width: 89px; height: 34px; background-color: beige; text-align: left">
                                New Dept.</td>
                            <td align="left" style="width: 1380px; height: 34px; background-color: beige">
                                <asp:DropDownList ID="newdept" runat="server" DataSourceID="SqlDataSource7"
                                    DataTextField="departmentcode" DataValueField="departmentcode" Width="216px" AppendDataBoundItems="True">
                                    <asp:ListItem Value="-1">--- Select ---</asp:ListItem>
                                </asp:DropDownList>&nbsp;
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="newdept"
                                    ErrorMessage="!" ValidationGroup="a"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 89px; height: 34px; background-color: beige; text-align: left">
                                New Sect.</td>
                            <td align="left" style="width: 1380px; height: 34px; background-color: beige">
                                <asp:DropDownList ID="newsect" runat="server" AppendDataBoundItems="True"
                                    DataSourceID="SqlDataSource8" DataTextField="sectioncode" DataValueField="sectioncode"
                                    Width="220px">
                                    <asp:ListItem Value="-1">--- Select ---</asp:ListItem>
                                </asp:DropDownList>&nbsp;
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="newsect"
                                    ErrorMessage="!" ValidationGroup="a"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 89px; height: 34px; background-color: beige; text-align: left;">
                                <asp:Label ID="Label26" runat="server" Font-Bold="False" Text="Date Effective From" Width="89px"></asp:Label></td>
                            <td align="left" style="width: 1380px; background-color: beige; height: 34px;">
                                <asp:TextBox ID="dtefffrom" runat="server" Width="115px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                                    ID="R1" runat="server" ControlToValidate="dtefffrom" ErrorMessage=" !"
                                    ValidationGroup="a"></asp:RequiredFieldValidator><%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtfrom"
                                            SetFocusOnError="True">*</asp:RequiredFieldValidator>--%>
                                &nbsp;&nbsp;<%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtto">*</asp:RequiredFieldValidator>--%>
                                &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 26px; background-color: beige">
                                <asp:Button ID="savetrfr" runat="server" Text="SAVE" ValidationGroup="a" />&nbsp;
                                <asp:RequiredFieldValidator ID="R15" runat="server" ControlToValidate="empcode"
                                    ValidationGroup="a" ForeColor="Beige">Please enter Employee No. !</asp:RequiredFieldValidator></td>
                        </tr>
                    </table>
                    &nbsp;
                </asp:Panel>
                <asp:Panel ID="promopanel" runat="server">
                
                <table id="Table4" border="1" style="width: 619px">
                    <tr>
                        <td colspan="2" style="height: 30px; background-color: beige">
                            PROMOTION</td>
                    </tr>
                    <tr>
                        <td style="width: 287px; height: 34px; background-color: beige; text-align: left">
                            Designation</td>
                        <td align="left" style="width: 1380px; height: 34px; background-color: beige">
                            <asp:Label ID="Labeldesig" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 287px; height: 34px; background-color: beige; text-align: left">
                            New Designation</td>
                        <td align="left" style="width: 1380px; height: 34px; background-color: beige">
                            <asp:DropDownList ID="pnewdesig" runat="server" AppendDataBoundItems="True"
                                DataSourceID="SqlDataSource6" DataTextField="designationname" DataValueField="designationname"
                                Width="234px">
                                <asp:ListItem Value="-1" Selected="True">--- Select ---</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="pnewdesig"
                                ErrorMessage="!" ValidationGroup="b"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 287px; height: 34px; background-color: beige; text-align: left;">
                                Date Effective From</td>
                        <td align="left" style="width: 1380px; background-color: beige; height: 34px;">
                            <asp:TextBox ID="prodteff" runat="server" Width="147px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                                ID="R3" runat="server" ControlToValidate="prodteff" ErrorMessage=" !"
                                ValidationGroup="b"></asp:RequiredFieldValidator><%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtfrom"
                                            SetFocusOnError="True">*</asp:RequiredFieldValidator>--%>
                            &nbsp;&nbsp;<%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtto">*</asp:RequiredFieldValidator>--%>
                            &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 287px; height: 42px; background-color: beige; text-align: left">
                            Old Basic Salary</td>
                        <td align="left" style="width: 1380px; height: 42px; background-color: beige">
                            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="TextBox3"
                                ErrorMessage="!" ValidationGroup="b"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 287px; height: 26px; background-color: beige; text-align: left">
                            Old Position Allowance</td>
                        <td align="left" style="width: 1380px; background-color: beige">
                            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ControlToValidate="TextBox5"
                                ErrorMessage="!" ValidationGroup="b"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 287px; height: 26px; background-color: beige; text-align: left">
                            PFP Allowance</td>
                        <td align="left" style="width: 1380px; background-color: beige">
                            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ControlToValidate="TextBox6"
                                ErrorMessage="!" ValidationGroup="b"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 287px; height: 26px; background-color: beige; text-align: left">
                            New Basic Salary</td>
                        <td align="left" style="width: 1380px; background-color: beige">
                            <asp:TextBox ID="nbs" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="nbs"
                                ErrorMessage="!" ValidationGroup="b"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 287px; height: 26px; background-color: beige; text-align: left">
                            New Position Allowance</td>
                        <td align="left" style="width: 1380px; background-color: beige">
                            <asp:TextBox ID="npa" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="npa"
                                ErrorMessage="!" ValidationGroup="b"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 287px; height: 26px; background-color: beige; text-align: left">
                            New PFP Allowance</td>
                        <td align="left" style="width: 1380px; background-color: beige">
                            <asp:TextBox ID="npfpall" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="npfpall"
                                ErrorMessage="!" ValidationGroup="b"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 287px; height: 26px; background-color: beige; text-align: left">
                            Total Salary</td>
                        <td align="left" style="width: 1380px; background-color: beige">
                            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ControlToValidate="TextBox7"
                                ErrorMessage="!" ValidationGroup="b"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 26px; background-color: beige">
                            <asp:Button ID="savepromo" runat="server" Text="SAVE" ValidationGroup="b" />&nbsp;
                            <asp:RequiredFieldValidator ID="R20" runat="server" ControlToValidate="empcode"
                                ValidationGroup="b" ForeColor="Beige">Please enter Employee No. !</asp:RequiredFieldValidator></td>
                    </tr>
                </table>
                </asp:Panel>
                <asp:Panel ID="promopfppanel" runat="server">
                    <table id="Table7" border="1" style="width: 619px">
                        <tr>
                            <td colspan="2" style="height: 30px; background-color: beige">
                                PROMOTION - For New Group PFP</td>
                        </tr>
                        <tr><td style="width: 170px; height: 34px; background-color: beige; text-align: left">
                            Designation</td>
                            <td align="left" style="width: 1380px; height: 34px; background-color: beige">
                                <asp:Label ID="pfplabeldesig" runat="server"></asp:Label></td>
                        </tr>
                        <tr><td style="width: 170px; height: 34px; background-color: beige; text-align: left">
                            New Designation</td>
                            <td align="left" style="width: 1380px; height: 34px; background-color: beige">
                                <asp:DropDownList ID="DDL4" runat="server" AppendDataBoundItems="True"
                                DataSourceID="SqlDataSource6" DataTextField="designationname" DataValueField="designationname"
                                Width="234px">
                                    <asp:ListItem Value="-1">--- Select ---</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="DDL4"
                                    ErrorMessage="!" ValidationGroup="c"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr><td style="width: 170px; height: 34px; background-color: beige; text-align: left;">
                            Date Effective From</td>
                            <td align="left" style="width: 1380px; background-color: beige; height: 34px;">
                                <asp:TextBox ID="TextBox1" runat="server" Width="151px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox1"
                                    ErrorMessage=" !" ValidationGroup="c"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 170px; height: 42px; background-color: beige; text-align: left">
                                Old Basic Salary</td>
                            <td align="left" style="width: 1380px; height: 42px; background-color: beige">
                                <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server" ControlToValidate="TextBox11"
                                    ErrorMessage="!" ValidationGroup="c"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 170px; height: 26px; background-color: beige; text-align: left">
                                Old Position Allowance</td>
                            <td align="left" style="width: 1380px; background-color: beige">
                                <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator40" runat="server" ControlToValidate="TextBox12"
                                    ErrorMessage="!" ValidationGroup="c"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr><td style="width: 170px; height: 26px; background-color: beige; text-align: left">
                            New Basic Salary</td>
                            <td align="left" style="width: 1380px; background-color: beige">
                                <asp:TextBox ID="pfpnbs" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="pfpnbs"
                                    ErrorMessage="!" ValidationGroup="c"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 170px; height: 26px; background-color: beige; text-align: left">
                                New Position Allowance</td>
                            <td align="left" style="width: 1380px; background-color: beige">
                                <asp:TextBox ID="pfpnpa" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="pfpnpa"
                                    ErrorMessage="!" ValidationGroup="c"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 170px; height: 26px; background-color: beige; text-align: left">
                                New PFP Allowance</td>
                            <td align="left" style="width: 1380px; background-color: beige">
                                <asp:TextBox ID="pfpnpfpall" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="pfpnpfpall"
                                    ErrorMessage="!" ValidationGroup="c"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 170px; height: 26px; background-color: beige; text-align: left">
                                Total Salary</td>
                            <td align="left" style="width: 1380px; background-color: beige">
                                <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server" ControlToValidate="TextBox13"
                                    ErrorMessage="!" ValidationGroup="c"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 26px; background-color: beige">
                                <asp:Button ID="savepromopfp" runat="server" Text="SAVE" ValidationGroup="c" />&nbsp;
                                <asp:RequiredFieldValidator ID="R21" runat="server" ControlToValidate="empcode"
                                    ValidationGroup="c" ForeColor="Beige">Please enter Employee No. !</asp:RequiredFieldValidator></td>
                                     
                                                             </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="ctmedpanel" runat="server">
                    <table border="1" style="width: 619px">
                        <tr>
                            <td colspan="2" style="height: 30px; background-color: beige">
                                CONTRACT TERMINATION - Medically Unfit</td>
                        </tr>
                        <tr>
                            <td style="width: 151px; height: 42px; background-color: beige; text-align: left;">
                                Effective From</td>
                            <td align="left" style="width: 1380px; background-color: beige; height: 42px;">
                                <asp:TextBox ID="ctefffrom" runat="server" Width="115px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="R10" runat="server" ControlToValidate="ctefffrom"
                                    ErrorMessage=" !" ValidationGroup="d"></asp:RequiredFieldValidator>
                                &nbsp; &nbsp;
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 151px; height: 30px; background-color: beige; text-align: left;">
                                Last Working Day</td>
                            <td align="left" style="width: 1380px; background-color: beige">
                                <asp:TextBox ID="cteffto1" runat="server" Width="115px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cteffto1"
                                    ErrorMessage=" !" ValidationGroup="d"></asp:RequiredFieldValidator>
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 26px; background-color: beige">
                                <asp:Button ID="savectmu" runat="server" Text="SAVE" ValidationGroup="d" />&nbsp;
                               <asp:RequiredFieldValidator ID="R22" runat="server" ControlToValidate="empcode"
                                    ValidationGroup="d" ForeColor="Beige">Please enter Employee No. !</asp:RequiredFieldValidator></td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="cetempatanpanel" runat="server">
                    <table id="Table5" border="1" style="width: 619px">
                        <tr>
                            <td colspan="2" style="height: 30px; background-color: beige">
                                CONTRACT EXTENSION (TEMPATAN) - For Operators in Malay</td>
                        </tr>
                        <tr>
                            <td style="width: 134px; height: 30px; background-color: beige; text-align: left;">
                                Effective From</td>
                            <td align="left" style="width: 1380px; background-color: beige">
                                <asp:TextBox ID="CETfrom" runat="server" Width="115px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                                    ID="R11" runat="server" ControlToValidate="CETfrom" ErrorMessage=" !" ValidationGroup="e"></asp:RequiredFieldValidator><%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtfrom"
                                            SetFocusOnError="True">*</asp:RequiredFieldValidator>--%>
                                &nbsp;<%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtto">*</asp:RequiredFieldValidator>--%>
                                &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 134px; height: 26px; background-color: beige; text-align: left;">
                                Effective To</td>
                            <td align="left" style="width: 1380px; background-color: beige">
                                <asp:TextBox ID="CETto" runat="server" Width="115px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="CETto"
                                    ErrorMessage=" !" ValidationGroup="e"></asp:RequiredFieldValidator><%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtfrom"
                                            SetFocusOnError="True">*</asp:RequiredFieldValidator>--%>
                                &nbsp;<%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtto">*</asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 134px; height: 26px; background-color: beige; text-align: left">
                                Probation Period</td>
                            <td align="left" style="width: 1380px; background-color: beige">
                                <asp:TextBox ID="ceprobperiod" runat="server" Width="115px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="V" runat="server" ControlToValidate="ceprobperiod"
                                    ErrorMessage=" !" ValidationGroup="e"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 26px; background-color: beige">
                                <asp:Button ID="savecet" runat="server" Text="SAVE" ValidationGroup="e" />&nbsp;
                                <asp:RequiredFieldValidator ID="R23" runat="server" ControlToValidate="empcode"
                                    ValidationGroup="e" ForeColor="Beige">Please enter Employee No. !</asp:RequiredFieldValidator></td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="cewargapanel" runat="server">
                    <table id="Table6" border="1" style="width: 619px">
                        <tr>
                            <td colspan="2" style="height: 30px; background-color: beige">
                                CONTRACT EXTENSION (WARGA ASING) - For Operators in Malay</td>
                        </tr>
                        <tr><td style="width: 128px; height: 30px; background-color: beige; text-align: left;">
                            Effective From</td>
                            <td align="left" style="width: 1380px; background-color: beige">
                                <asp:TextBox ID="CEOfrom" runat="server" Width="115px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="CEOfrom"
                                    ErrorMessage=" !" ValidationGroup="f"></asp:RequiredFieldValidator><%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtfrom"
                                            SetFocusOnError="True">*</asp:RequiredFieldValidator>--%>
                                &nbsp;<%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtto">*</asp:RequiredFieldValidator>--%>
                                &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</td>
                        </tr>
                        <tr><td style="width: 128px; height: 26px; background-color: beige; text-align: left;">
                            Effective To</td>
                            <td align="left" style="width: 1380px; background-color: beige">
                                <asp:TextBox ID="CEOto" runat="server" Width="115px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="CEOto"
                                    ErrorMessage=" !" ValidationGroup="f"></asp:RequiredFieldValidator><%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtfrom"
                                            SetFocusOnError="True">*</asp:RequiredFieldValidator>--%>
                                &nbsp;<%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtto">*</asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 128px; height: 26px; background-color: beige; text-align: left">
                                Extend Months</td>
                            <td align="left" style="width: 1380px; background-color: beige">
                                <asp:TextBox ID="probperiod" runat="server" Width="115px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="probperiod"
                                    ErrorMessage=" !" ValidationGroup="f"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 26px; background-color: beige">
                                <asp:Button ID="savecewa" runat="server" Text="SAVE" ValidationGroup="f" />&nbsp;
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="empcode" ValidationGroup="f" ForeColor="Beige">Please enter Employee No. !</asp:RequiredFieldValidator></td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="confpanel" runat="server">
                    <table id="Table8" border="1" style="width: 619px">
                        <tr>
                            <td colspan="2" style="height: 30px; background-color: beige">
                                CONFIRMATION</td>
                        </tr>
                        <tr>
                            <td style="width: 131px; height: 30px; background-color: beige; text-align: left;">
                                Probationary Period</td>
                            <td align="left" style="width: 1380px; background-color: beige">
                                <asp:TextBox ID="cprobperiod" runat="server" Width="115px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="cprobperiod"
                                    ErrorMessage=" !" ValidationGroup="g"></asp:RequiredFieldValidator><%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtfrom"
                                            SetFocusOnError="True">*</asp:RequiredFieldValidator>--%>
                                &nbsp;<%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtto">*</asp:RequiredFieldValidator>--%>
                                &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</td>
                        </tr>
                        <tr><td style="width: 131px; height: 26px; background-color: beige; text-align: left;">
                            Confirmation Effective From</td>
                            <td align="left" style="width: 1380px; background-color: beige">
                                <asp:TextBox ID="cefffrom" runat="server" Width="115px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="cefffrom"
                                    ErrorMessage=" !" ValidationGroup="g"></asp:RequiredFieldValidator><%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtfrom"
                                            SetFocusOnError="True">*</asp:RequiredFieldValidator>--%>
                                &nbsp;<%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtto">*</asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        <tr><td style="width: 131px; height: 42px; background-color: beige; text-align: left">
                            Basic Salary Adjustment</td>
                            <td align="left" style="width: 1380px; background-color: beige; height: 42px;">
                                <asp:TextBox ID="confbsa" runat="server" Width="115px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="confbsa"
                                    ErrorMessage=" !" ValidationGroup="g"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 26px; background-color: beige">
                                <asp:Button ID="saveconf" runat="server" Text="SAVE" ValidationGroup="g" />&nbsp;
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="empcode" ValidationGroup="g" ForeColor="Beige">Please enter Employee No. !</asp:RequiredFieldValidator></td>
                        </tr>
                    </table>
                </asp:Panel><asp:Panel ID="cepanel" runat="server">
                    <table id="Table9" border="1" style="width: 619px">
                        <tr>
                            <td colspan="2" style="height: 30px; background-color: beige">
                                CONTRACT EXTENSION</td>
                        </tr>
                        <tr>
                            <td style="width: 375px; height: 30px; background-color: beige; text-align: left">
                                Extend Contract Period</td>
                            <td align="left" style="width: 1380px; background-color: beige">
                                <asp:TextBox ID="CEcont" runat="server"></asp:TextBox>&nbsp;
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="CEcont"
                                    ErrorMessage=" !" ValidationGroup="h"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 375px; height: 34px; background-color: beige; text-align: left">
                                Effective From</td>
                            <td align="left" style="width: 1380px; height: 34px; background-color: beige">
                                <asp:TextBox ID="cefrom" runat="server"></asp:TextBox>&nbsp;
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="cefrom"
                                    ErrorMessage=" !" ValidationGroup="h"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 375px; height: 34px; background-color: beige; text-align: left">
                                Effective To</td>
                            <td align="left" style="width: 1380px; background-color: beige; height: 34px;">
                                <asp:TextBox ID="ceto" runat="server"></asp:TextBox>&nbsp;
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="ceto"
                                    ErrorMessage=" !" ValidationGroup="h"></asp:RequiredFieldValidator>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 375px; height: 30px; background-color: beige; text-align: left">
                                Basic Salary Adjustment</td>
                            <td align="left" style="width: 1380px; background-color: beige">
                                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>&nbsp;&nbsp;<asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator33" runat="server" ControlToValidate="TextBox2" ErrorMessage="!"
                                    ValidationGroup="h"></asp:RequiredFieldValidator>
                                <asp:CheckBox ID="CheckBox1" runat="server" Text="(Check if Basic Salary Adjustment)" /></td>
                        </tr>
                        <tr>
                            <td style="width: 375px; height: 30px; background-color: beige; text-align: left">
                                Previous Basic Salary</td>
                            <td align="left" style="width: 1380px; background-color: beige">
                                <asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>
                                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator42" runat="server" ControlToValidate="TextBox14"
                                    ErrorMessage="!" ValidationGroup="h" Width="1px"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 375px; height: 30px; background-color: beige; text-align: left">
                                Position Allowance Adjustment</td>
                            <td align="left" style="width: 1380px; background-color: beige">
                                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>&nbsp;&nbsp;<asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator34" runat="server" ControlToValidate="TextBox4" ErrorMessage="!"
                                    ValidationGroup="h"></asp:RequiredFieldValidator>
                                <asp:CheckBox ID="CheckBox2" runat="server" Text="(Check if Position Allowance Adjustment)" /></td>
                        </tr>
                        <tr>
                            <td style="width: 375px; height: 30px; background-color: beige; text-align: left;">
                                Previous Position Allowance</td>
                            <td align="left" style="width: 1380px; background-color: beige">
                                <asp:TextBox ID="TextBox15" runat="server"></asp:TextBox>&nbsp;
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator43" runat="server" ControlToValidate="TextBox15"
                                    ErrorMessage="!" ValidationGroup="h"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 26px; background-color: beige">
                                <asp:Button ID="savecext" runat="server" Text="SAVE" ValidationGroup="h" />&nbsp;
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="empcode"
                                    ValidationGroup="h" ForeColor="Beige">Please enter Employee No. !</asp:RequiredFieldValidator></td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="cepfppanel" runat="server">
                    <table id="Table10" border="1" style="width: 619px">
                        <tr>
                            <td colspan="2" style="height: 30px; background-color: beige">
                                CONTRACT EXTENSION - Contract Employment PFP</td>
                        </tr>
                        <tr>
                            <td style="width: 445px; height: 30px; background-color: beige; text-align: left">
                                Designation</td>
                            <td align="left" style="width: 1380px; background-color: beige">
                                <asp:Label ID="cepfpdesig" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 445px; height: 34px; background-color: beige; text-align: left">
                                Date Hired</td>
                            <td align="left" style="width: 1380px; height: 34px; background-color: beige">
                                <asp:Label ID="cepfpdoj" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 445px; height: 30px; background-color: beige; text-align: left">
                                New IC No.</td>
                            <td align="left" style="width: 1380px; background-color: beige">
                                <asp:Label ID="cepfpicno" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 445px; height: 30px; background-color: beige; text-align: left">
                                Extended Contract Period</td>
                            <td align="left" style="width: 1380px; background-color: beige">
                                <asp:TextBox ID="cepfpcontperiod" runat="server"></asp:TextBox>&nbsp;
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="cepfpcontperiod"
                                    ErrorMessage=" !" ValidationGroup="i"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 445px; height: 30px; background-color: beige; text-align: left">
                                Effective From</td>
                            <td align="left" style="width: 1380px; background-color: beige">
                                <asp:TextBox ID="cepfpefffrom" runat="server"></asp:TextBox>&nbsp;
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="cepfpefffrom"
                                    ErrorMessage=" !" ValidationGroup="i"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 445px; height: 30px; background-color: beige; text-align: left">
                                Effective To</td>
                            <td align="left" style="width: 1380px; background-color: beige">
                                <asp:TextBox ID="cepfpeffto" runat="server"></asp:TextBox>&nbsp;
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="cepfpeffto"
                                    ErrorMessage=" !" ValidationGroup="i"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 445px; height: 30px; background-color: beige; text-align: left">
                                Letter Date</td>
                            <td align="left" style="width: 1380px; background-color: beige">
                                <asp:TextBox ID="cepfpletdt" runat="server"></asp:TextBox>&nbsp;
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="cepfpletdt"
                                    ErrorMessage=" !" ValidationGroup="i"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 445px; height: 30px; background-color: beige; text-align: left">
                                Allowance Amount</td>
                            <td align="left" style="width: 1380px; background-color: beige">
                                <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator44" runat="server" ControlToValidate="TextBox8" ErrorMessage=" !"
                                    ValidationGroup="i"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 445px; height: 30px; background-color: beige; text-align: left">
                                Basic Salary</td>
                            <td align="left" style="width: 1380px; background-color: beige">
                                <asp:TextBox ID="TextBox16" runat="server"></asp:TextBox>&nbsp;
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator45" runat="server" ControlToValidate="TextBox16"
                                    ErrorMessage=" !" ValidationGroup="i"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 445px; height: 30px; background-color: beige; text-align: left">
                                Special Increment Amount</td>
                            <td align="left" style="width: 1380px; background-color: beige">
                                <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="TextBox9"
                                    ErrorMessage="!" ValidationGroup="i"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 445px; height: 30px; background-color: beige; text-align: left">
                                New Basic Salary</td>
                            <td align="left" style="width: 1380px; background-color: beige">
                                <asp:TextBox ID="TextBox17" runat="server"></asp:TextBox>&nbsp;
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator46" runat="server" ControlToValidate="TextBox17"
                                    ErrorMessage=" !" ValidationGroup="i"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 445px; height: 30px; background-color: beige; text-align: left;">
                                Position Allowance</td>
                            <td align="left" style="width: 1380px; background-color: beige">
                                <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="TextBox10"
                                    ErrorMessage="!" ValidationGroup="i"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 26px; background-color: beige">
                                <asp:Button ID="Button1" runat="server" Text="SAVE" ValidationGroup="i" />&nbsp;
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="empcode"
                                    ValidationGroup="i" ForeColor="Beige">Please enter Employee No. !</asp:RequiredFieldValidator></td>
                        </tr>
                    </table>
                </asp:Panel>
                </td>
        </tr>
    </table>
                <asp:SqlDataSource ID="SqlDataSource8" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT DISTINCT [sectioncode] FROM [sectionmaster] ORDER BY [sectioncode]">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT DISTINCT [departmentcode] FROM [department] ORDER BY [departmentcode]">
                </asp:SqlDataSource>
                &nbsp;<asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT [designationname] FROM [designation] ORDER BY [designationname]">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT DISTINCT [departmentname] FROM [department] ORDER BY [departmentname]">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT [sectionname] FROM [sectionmaster] ORDER BY [sectionname]">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT DISTINCT [td_programme] FROM [td_traininglist]">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT DISTINCT [td_title] FROM [td_traininglist] ORDER BY [td_title]">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT DISTINCT [empcode], [td_trainingattended], [td_programme], [td_remarks], [td_markscored], [td_dateattended], [td_hours], [trainingattachment] FROM [td_employeetraining] ORDER BY [empcode], [td_trainingattended], [td_dateattended]"
                    DeleteCommand = "delete DISTINCT from [td_employeetraining] WHERE [empcode] = @empcode AND [td_trainingattended]=@td_trainingattended AND [td_hours]=@td_hrs"
                    UpdateCommand = "update td_employeetraining set description=@description where categorycode=@categorycode">
                    <UpdateParameters>
                       <asp:Parameter Name="categorycode" Type="String" />
                        <asp:Parameter Name="description" Type="String" />       
                    </UpdateParameters>  
                    <DeleteParameters>
                       <asp:Parameter Name="empcode" Type="String" />
                        <asp:Parameter Name="td_trainingattended" Type="String" /> 
                         <asp:Parameter Name="td_hrs" Type="String" />      
                    </DeleteParameters>    
                </asp:SqlDataSource>
                <cc1:CalendarExtender ID="ccefrom" runat="server" CssClass="cal_Theme1" Format="dd/MM/yyyy"
                    PopupButtonID="dtefffrom" TargetControlID="dtefffrom">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="abscfrm" runat="server" CssClass="cal_Theme1" Format="dd/MM/yyyy"
                    PopupButtonID="prodteff" TargetControlID="prodteff">
                </cc1:CalendarExtender>
                &nbsp;
                <cc1:CalendarExtender ID="contterm" runat="server" CssClass="cal_Theme1" Format="dd/MM/yyyy"
                    PopupButtonID="ctefffrom" TargetControlID="ctefffrom">
                </cc1:CalendarExtender><cc1:CalendarExtender ID="conttermto" runat="server" CssClass="cal_Theme1" Format="dd/MM/yyyy"
                    PopupButtonID="cteffto1" TargetControlID="cteffto1">
                </cc1:CalendarExtender>
                <br />
                <cc1:CalendarExtender ID="CEOmalay" runat="server" CssClass="cal_Theme1" Format="dd/MM/yyyy"
                    PopupButtonID="CEOfrom" TargetControlID="CEOfrom">
                </cc1:CalendarExtender><cc1:CalendarExtender ID="CEOmalay2" runat="server" CssClass="cal_Theme1" Format="dd/MM/yyyy"
                    PopupButtonID="CEOto" TargetControlID="CEOto">
                </cc1:CalendarExtender>
                <br />
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="cal_Theme1" Format="dd/MM/yyyy"
                    PopupButtonID="CETfrom" TargetControlID="CETfrom">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="cal_Theme1" Format="dd/MM/yyyy"
                    PopupButtonID="CETto" TargetControlID="CETto">
                </cc1:CalendarExtender>
                <br />
                <br />
                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" CssClass="cal_Theme1" Format="dd/MM/yyyy"
                    PopupButtonID="cefffrom" TargetControlID="cefffrom">
                </cc1:CalendarExtender>
                <br />
                <cc1:CalendarExtender ID="CalendarExtender4" runat="server" CssClass="cal_Theme1" Format="dd/MM/yyyy"
                    PopupButtonID="ceto" TargetControlID="ceto">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="CalendarExtender5" runat="server" CssClass="cal_Theme1" Format="dd/MM/yyyy"
                    PopupButtonID="cefrom" TargetControlID="cefrom">
                </cc1:CalendarExtender>
                <br />
                <cc1:CalendarExtender ID="CalendarExtender6" runat="server" CssClass="cal_Theme1" Format="dd/MM/yyyy"
                    PopupButtonID="cepfpefffrom" TargetControlID="cepfpefffrom">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="CalendarExtender7" runat="server" CssClass="cal_Theme1" Format="dd/MM/yyyy"
                    PopupButtonID="cepfpeffto" TargetControlID="cepfpeffto">
                </cc1:CalendarExtender>
                <br />
                &nbsp;&nbsp;
                <cc1:CalendarExtender ID="CalendarExtender8" runat="server" CssClass="cal_Theme1" Format="dd/MM/yyyy"
                    PopupButtonID="cepfpletdt" TargetControlID="cepfpletdt">
                </cc1:CalendarExtender>
                <br />
                <cc1:CalendarExtender ID="CalendarExtender9" runat="server" CssClass="cal_Theme1" Format="dd/MM/yyyy"
                    PopupButtonID="TextBox1" TargetControlID="TextBox1">
                </cc1:CalendarExtender>
                
    
       </td>
            <td background="../../images/cen_rig.gif" style="width: 14px">
                </td>
        </tr>
        <tr>
            <td height="16" width="16">
                <img height="16" src="../../images/bot_lef.gif" width="16" /></td>
            <td background="../../images/bot_mid.gif" height="16" style="width: 1262px">
                <img height="16" src="../../images/bot_mid.gif" width="16" /></td>
            <td height="16" style="width: 14px">
                <img height="16" src="../../images/bot_rig.gif" width="24" /></td>
        </tr>
    </table>
    </form>
</body>
</html>
