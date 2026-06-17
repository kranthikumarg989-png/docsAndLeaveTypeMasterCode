<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="Leaveabsentism.aspx.vb" Inherits="E_Management.Leaveabsentism" 
    title="Absent/ Abscond/ Return Late/ Late Coming/ Over Night/ Other Misconduct Entry " %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
  <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="16" style="height: 16px">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" style="height: 16px; width: 1262px;">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 24px; height: 16px;">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif" style="height: 622px" width="16">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" style="height: 622px; width: 1262px;" valign="top">

<table id="TABLE2">
    <tr>
        <td colspan="1" class="td_head" style="width: 617px">
                        <asp:Label ID="Label1" runat="server" Font-Underline="False" ForeColor="White" Text="Absent/ Abscond/ Return Late/ Late Coming/ Over Night/ Other Misconduct Entry" Font-Bold="True"></asp:Label></td>
    </tr>
        <tr>
            <td style="width: 617px; height: 227px; text-align: center;" valign="top" align="center">
                <table id="TABLE1" onclick="return TABLE1_onclick()" border="1" cellpadding="1" cellspacing="1"><tr>
                    <td style="width: 77px; background-color: beige; height: 26px;" valign="top" align="left">
                        <asp:Label ID="Label2" runat="server" Text="Employee No."></asp:Label></td>
                    <td style="width: 214px; height: 26px;" valign="top" align="left">
                        <asp:TextBox ID="empcode" runat="server" Width="173px" AutoPostBack="True"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="V1" runat="server" ControlToValidate="empcode"
                            ErrorMessage="Code !" InitialValue="-1" ValidationGroup="b"></asp:RequiredFieldValidator></td>
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
                                Text="Details of the Problem"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="4" rowspan="" style="height: 39px; background-color: beige; text-align: center;" title=" "><table id="Table3" onclick="return TABLE1_onclick()" cellpadding="1" cellspacing="1">
                            <tr>
                                <td style="width: 84px; background-color: beige; height: 11px;" valign="middle" align="left">
                                    <asp:Label ID="Label5" runat="server" Text="Problem Type" Width="71px"></asp:Label></td>
                                <td style="width: 310px; height: 11px;" valign="middle" align="left">
                                    &nbsp;<asp:DropDownList ID="ptype" runat="server" Width="175px" AppendDataBoundItems="True" AutoPostBack="True">
                                        <asp:ListItem Value="-1">---Select---</asp:ListItem>
                                        <asp:ListItem>Absent</asp:ListItem>
                                        <asp:ListItem>Abscond</asp:ListItem>
                                        <asp:ListItem>LateComing</asp:ListItem>
                                        <asp:ListItem>MisConduct</asp:ListItem>
                                        <asp:ListItem>OverNight</asp:ListItem>
                                        <asp:ListItem>LateReturn</asp:ListItem>
                                        <asp:ListItem>RanAway</asp:ListItem>
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
                <asp:Panel ID="absentpanel" runat="server">
                    <table border="1" style="width: 619px">
                        <tr>
                            <td colspan="2" style="height: 30px; background-color: beige">
                                ABSENT</td>
                        </tr>
                        <tr>
                            <td style="width: 89px; height: 34px; background-color: beige; text-align: left;">
                                <asp:Label ID="Label26" runat="server" Font-Bold="False" Text="Select Date" Width="89px"></asp:Label></td>
                            <td align="left" style="width: 1380px; background-color: beige; height: 34px;">
                                <asp:TextBox ID="txtfrom" runat="server" Width="115px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                                    ID="R1" runat="server" ControlToValidate="txtfrom" ErrorMessage=" !"
                                    ValidationGroup="a"></asp:RequiredFieldValidator><%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtfrom"
                                            SetFocusOnError="True">*</asp:RequiredFieldValidator>--%>
                                ~
                                <asp:TextBox ID="txtto" runat="server" Height="14px" Width="115px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                                    ID="R2" runat="server" ControlToValidate="txtto" ErrorMessage=" !"
                                    ValidationGroup="a"></asp:RequiredFieldValidator>&nbsp;<%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtto">*</asp:RequiredFieldValidator>--%>
                                &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 89px; height: 26px; background-color: beige">
                                <asp:Label ID="Label6" runat="server" Font-Bold="False" Text="Reason" Width="89px"></asp:Label></td>
                            <td align="left" style="width: 1380px; background-color: beige">
                                <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Width="267px"></asp:TextBox>&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 26px; background-color: beige">
                                <asp:Button ID="saveabsent" runat="server" Text="SAVE" ValidationGroup="a" />&nbsp;
                                <asp:RequiredFieldValidator ID="R15" runat="server" ControlToValidate="empcode" ForeColor="Beige"
                                    ValidationGroup="a">Please enter Employee No. !</asp:RequiredFieldValidator></td>
                        </tr>
                    </table>
                    &nbsp;
                </asp:Panel>
                <asp:Panel ID="abscondpanel" runat="server">
                
                <table id="Table4" border="1" style="width: 619px">
                    <tr>
                        <td colspan="2" style="height: 30px; background-color: beige">
                            ABSCOND</td>
                    </tr>
                    <tr>
                        <td style="width: 89px; height: 34px; background-color: beige">
                            <asp:Label ID="Label9" runat="server" Font-Bold="False" Text="Verified Dates" Width="89px"></asp:Label></td>
                        <td align="left" style="width: 1380px; background-color: beige; height: 34px;">
                            <asp:TextBox ID="TextBox5" runat="server" Width="115px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                                ID="R3" runat="server" ControlToValidate="TextBox5" ErrorMessage=" !"
                                ValidationGroup="b"></asp:RequiredFieldValidator><%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtfrom"
                                            SetFocusOnError="True">*</asp:RequiredFieldValidator>--%>
                            ~
                            <asp:TextBox ID="TextBox6" runat="server" Height="14px" Width="115px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                                ID="R4" runat="server" ControlToValidate="TextBox6" ErrorMessage=" !"
                                ValidationGroup="b"></asp:RequiredFieldValidator>&nbsp;<%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtto">*</asp:RequiredFieldValidator>--%>
                            &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 89px; height: 26px; background-color: beige">
                            <asp:Label ID="Label12" runat="server" Font-Bold="False" Text="Reason" Width="89px"></asp:Label></td>
                        <td align="left" style="width: 1380px; background-color: beige">
                            <asp:TextBox ID="TextBox7" runat="server" TextMode="MultiLine" Width="267px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 26px; background-color: beige">
                            <asp:Button ID="saveabscond" runat="server" Text="SAVE" ValidationGroup="b" />&nbsp;
                            <asp:RequiredFieldValidator ID="R20" runat="server" ControlToValidate="empcode" ForeColor="Beige"
                                ValidationGroup="b">Please enter Employee No. !</asp:RequiredFieldValidator></td>
                    </tr>
                </table>
                </asp:Panel>
                <asp:Panel ID="lcpanel" runat="server">
                    <table id="Table7" border="1" style="width: 619px">
                        <tr>
                            <td colspan="2" style="height: 30px; background-color: beige">
                                LATE COMING</td>
                        </tr>
                        <tr>
                            <td style="width: 89px; height: 30px; background-color: beige">
                                <asp:Label ID="Label16" runat="server" Font-Bold="False" Text="Late on Date" Width="89px"></asp:Label></td>
                            <td align="left" style="width: 1380px; background-color: beige">
                                <asp:TextBox ID="TextBox8" runat="server" Width="115px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                                    ID="R5" runat="server" ControlToValidate="TextBox8" ErrorMessage=" !"
                                    ValidationGroup="c"></asp:RequiredFieldValidator>
                                </td>
                        </tr>
                        <tr>
                            <td style="width: 89px; height: 30px; background-color: beige">
                                <asp:Label ID="Label17" runat="server" Font-Bold="False" Text="Late Hours" Width="89px"></asp:Label></td>
                            <td align="left" style="width: 1380px; background-color: beige">
                                <asp:TextBox ID="TextBox9" runat="server" Width="53px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                                    ID="R6" runat="server" ControlToValidate="TextBox9" ErrorMessage=" !"
                                    ValidationGroup="c"></asp:RequiredFieldValidator>
                                &nbsp;
                                &nbsp;&nbsp;
                                <asp:Label ID="Label20" runat="server" Text="Late Mins." Width="108px"></asp:Label>
                                &nbsp;&nbsp;<asp:TextBox ID="TextBox11" runat="server" Width="53px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="R7" runat="server" ControlToValidate="TextBox11"
                                    ErrorMessage=" !" ValidationGroup="c"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 89px; height: 30px; background-color: beige">
                                <asp:Label ID="Label7" runat="server" Font-Bold="False" Text="Time From/ To" Width="89px"></asp:Label></td>
                            <td align="left" style="width: 1380px; background-color: beige">
                                <asp:TextBox ID="TextBox2" runat="server" Width="115px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                                    ID="R8" runat="server" ControlToValidate="TextBox2" ErrorMessage=" !"
                                    ValidationGroup="c"></asp:RequiredFieldValidator><%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtfrom"
                                            SetFocusOnError="True">*</asp:RequiredFieldValidator>--%>
                                ~
                                <asp:TextBox ID="TextBox3" runat="server" Height="14px" Width="115px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                                    ID="R9" runat="server" ControlToValidate="TextBox3" ErrorMessage=" !"
                                    ValidationGroup="c"></asp:RequiredFieldValidator><%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtto">*</asp:RequiredFieldValidator>--%>
                                &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 89px; height: 26px; background-color: beige">
                                <asp:Label ID="Label8" runat="server" Font-Bold="False" Text="Reason" Width="89px"></asp:Label></td>
                            <td align="left" style="width: 1380px; background-color: beige">
                                <asp:TextBox ID="TextBox4" runat="server" TextMode="MultiLine" Width="267px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 26px; background-color: beige">
                                <asp:Button ID="savelc" runat="server" Text="SAVE" ValidationGroup="c" />&nbsp;
                                <asp:RequiredFieldValidator ID="R21" runat="server" ControlToValidate="empcode" ForeColor="Beige"
                                    ValidationGroup="c">Please enter Employee No. !</asp:RequiredFieldValidator></td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="mcpanel" runat="server">
                    <table border="1" style="width: 619px">
                        <tr>
                            <td colspan="2" style="height: 30px; background-color: beige">
                                MISCONDUCT</td>
                        </tr>
                        <tr>
                            <td style="width: 89px; height: 30px; background-color: beige">
                                Date of Misconduct</td>
                            <td align="left" style="width: 1380px; background-color: beige">
                                <asp:TextBox ID="TextBox10" runat="server" Width="115px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="R10" runat="server" ControlToValidate="TextBox10"
                                    ErrorMessage=" !" ValidationGroup="d"></asp:RequiredFieldValidator>
                                &nbsp; &nbsp;
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 89px; height: 26px; background-color: beige">
                                <asp:Label ID="Label19" runat="server" Font-Bold="False" Text="Description" Width="89px"></asp:Label></td>
                            <td align="left" style="width: 1380px; background-color: beige">
                                <asp:TextBox ID="TextBox12" runat="server" TextMode="MultiLine" Width="267px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 26px; background-color: beige">
                                <asp:Button ID="savems" runat="server" Text="SAVE" ValidationGroup="d" />&nbsp;
                                <asp:RequiredFieldValidator ID="R22" runat="server" ControlToValidate="empcode" ForeColor="Beige"
                                    ValidationGroup="d">Please enter Employee No. !</asp:RequiredFieldValidator></td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="ovpanel" runat="server">
                    <table id="Table5" border="1" style="width: 619px">
                        <tr>
                            <td colspan="2" style="height: 30px; background-color: beige">
                                OVERNIGHT</td>
                        </tr>
                        <tr>
                            <td style="width: 89px; height: 30px; background-color: beige">
                                <asp:Label ID="Label25" runat="server" Font-Bold="False" Text="Date" Width="89px"></asp:Label></td>
                            <td align="left" style="width: 1380px; background-color: beige">
                                <asp:TextBox ID="TextBox21" runat="server" Width="115px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                                    ID="R11" runat="server" ControlToValidate="TextBox21" ErrorMessage=" !" InitialValue="-1"
                                    ValidationGroup="e"></asp:RequiredFieldValidator><%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtfrom"
                                            SetFocusOnError="True">*</asp:RequiredFieldValidator>--%>
                                &nbsp;<%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtto">*</asp:RequiredFieldValidator>--%>
                                &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 89px; height: 26px; background-color: beige">
                                <asp:Label ID="Label30" runat="server" Font-Bold="False" Text="Details" Width="89px"></asp:Label></td>
                            <td align="left" style="width: 1380px; background-color: beige">
                                <asp:TextBox ID="TextBox14" runat="server" TextMode="MultiLine" Width="267px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 26px; background-color: beige">
                                <asp:Button ID="saveon" runat="server" Text="SAVE" ValidationGroup="e" />&nbsp;
                                <asp:RequiredFieldValidator ID="R23" runat="server" ControlToValidate="empcode" ForeColor="Beige"
                                    ValidationGroup="e">Please enter Employee No. !</asp:RequiredFieldValidator></td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="lrpanel" runat="server">
                    <table id="Table6" border="1" style="width: 619px">
                        <tr>
                            <td colspan="2" style="height: 30px; background-color: beige">
                                LATE RETURN</td>
                        </tr>
                        <tr>
                            <td style="width: 89px; height: 30px; background-color: beige">
                                <asp:Label ID="Label52" runat="server" Font-Bold="False" Text="Date" Width="89px"></asp:Label></td>
                            <td align="left" style="width: 1380px; background-color: beige">
                                <asp:TextBox ID="TextBox31" runat="server" Width="115px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                                    ID="R12" runat="server" ControlToValidate="TextBox31" ErrorMessage=" !"
                                    ValidationGroup="f"></asp:RequiredFieldValidator><%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtfrom"
                                            SetFocusOnError="True">*</asp:RequiredFieldValidator>--%>
                                &nbsp;<%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtto">*</asp:RequiredFieldValidator>--%>
                                &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 89px; height: 26px; background-color: beige">
                                <asp:Label ID="Label51" runat="server" Font-Bold="False" Text="Details" Width="89px"></asp:Label></td>
                            <td align="left" style="width: 1380px; background-color: beige">
                                <asp:TextBox ID="TextBox13" runat="server" TextMode="MultiLine" Width="267px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 26px; background-color: beige">
                                <asp:Button ID="savelr" runat="server" Text="SAVE" ValidationGroup="f" />&nbsp;
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="empcode"
                                    ForeColor="Beige" ValidationGroup="f">Please enter Employee No. !</asp:RequiredFieldValidator></td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="rapanel" runat="server">
                    <table id="Table8" border="1" style="width: 619px">
                        <tr>
                            <td colspan="2" style="height: 30px; background-color: beige">
                                RAN AWAY</td>
                        </tr>
                        <tr>
                            <td style="width: 89px; height: 30px; background-color: beige">
                                <asp:Label ID="Label53" runat="server" Font-Bold="False" Text="Date" Width="89px"></asp:Label></td>
                            <td align="left" style="width: 1380px; background-color: beige">
                                <asp:TextBox ID="TextBox41" runat="server" Width="115px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                                    ID="R13" runat="server" ControlToValidate="TextBox41" ErrorMessage=" !"
                                    ValidationGroup="g"></asp:RequiredFieldValidator><%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtfrom"
                                            SetFocusOnError="True">*</asp:RequiredFieldValidator>--%>
                                &nbsp;<%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtto">*</asp:RequiredFieldValidator>--%>
                                &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 89px; height: 26px; background-color: beige">
                                <asp:Label ID="Label54" runat="server" Font-Bold="False" Text="Details" Width="89px"></asp:Label></td>
                            <td align="left" style="width: 1380px; background-color: beige">
                                <asp:TextBox ID="TextBox15" runat="server" TextMode="MultiLine" Width="267px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 26px; background-color: beige">
                                <asp:Button ID="savera" runat="server" Text="SAVE" ValidationGroup="g" />&nbsp;
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="empcode"
                                    ForeColor="Beige" ValidationGroup="g">Please enter Employee No. !</asp:RequiredFieldValidator></td>
                        </tr>
                    </table>
                </asp:Panel>
                &nbsp;<br />
                &nbsp;
                            <br />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<br />
                <br />
                &nbsp;<br />
                &nbsp; &nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp;
                &nbsp;
                &nbsp;&nbsp;
                </td>
        </tr>
    </table>
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
                    PopupButtonID="txtfrom" TargetControlID="txtfrom">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="cceto" runat="server" CssClass="cal_Theme1" Format="dd/MM/yyyy"
                    PopupButtonID="txtto" TargetControlID="txtto">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="abscfrm" runat="server" CssClass="cal_Theme1" Format="dd/MM/yyyy"
                    PopupButtonID="TextBox5" TargetControlID="TextBox5">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="abscto" runat="server" CssClass="cal_Theme1" Format="dd/MM/yyyy"
                    PopupButtonID="TextBox6" TargetControlID="TextBox6">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="latedt" runat="server" CssClass="cal_Theme1" Format="dd/MM/yyyy"
                    PopupButtonID="TextBox8" TargetControlID="TextBox8">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="mcdate" runat="server" CssClass="cal_Theme1" Format="dd/MM/yyyy"
                    PopupButtonID="TextBox10" TargetControlID="TextBox10">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="ovdate" runat="server" CssClass="cal_Theme1" Format="dd/MM/yyyy"
                    PopupButtonID="TextBox21" TargetControlID="TextBox21">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="lrdate" runat="server" CssClass="cal_Theme1" Format="dd/MM/yyyy"
                    PopupButtonID="TextBox31" TargetControlID="TextBox31">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="radate" runat="server" CssClass="cal_Theme1" Format="dd/MM/yyyy"
                    PopupButtonID="TextBox41" TargetControlID="TextBox41">
                </cc1:CalendarExtender>
                
    
       </td>
            <td background="../../images/cen_rig.gif" style="width: 24px">
                <img height="11" src="../../images/cen_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td height="16" width="16">
                <img height="16" src="../../images/bot_lef.gif" width="16" /></td>
            <td background="../../images/bot_mid.gif" height="16" style="width: 1262px">
                <img height="16" src="../../images/bot_mid.gif" width="16" /></td>
            <td height="16" style="width: 24px">
                <img height="16" src="../../images/bot_rig.gif" width="24" /></td>
        </tr>
    </table>
   
</asp:Content>
