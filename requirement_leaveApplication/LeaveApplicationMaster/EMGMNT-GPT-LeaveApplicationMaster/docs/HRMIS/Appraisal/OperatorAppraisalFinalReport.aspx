<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OperatorAppraisalFinalReport.aspx.vb" Inherits="E_Management.OperatorAppraisalFinalReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Operator Appraisal Report</title>
     <link rel="stylesheet" type="text/css" href="~/css/style.css" /> 
            <link rel="stylesheet" type="text/css" href="~/css/stylesheet.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table cellpadding=0 cellspacing=0 border="0" class="for_normal">
                    <tr>
                        <td style="width: 16px; height: 16px">
                            <%--<IMG height="16" src="../../images/top_lef.gif" width="16">--%></td>
                        <td style="height: 16px; width: 650px;">
                            <%--<IMG height="16" src="../../images/top_mid.gif"width="16">--%></td>
                        <td style="width: 25px; height: 16px;">
                            <%--<IMG height="16" src="../../images/top_rig.gif" width="24">--%></td>
                    </tr>
                    <tr>
                        <td style="width: 16px; height: 248px;">
                        <%--<IMG height="11" src="../../images/cen_lef.gif" width="16">--%></td>
                        <td vAlign="top" bgColor="#ffffff" style="width: 650px">
                         <table style="border-top-width: 1px; border-left-width: 1px; border-left-color: #000000; border-bottom-width: 1px; border-bottom-color: #000000; border-top-color: #000000; border-right-width: 1px; border-right-color: #000000;" border="0" cellpadding="0" cellspacing="0" class="for_normal">
                                <tr>
                                    <td align="center" class="td_head" colspan="4" style="height: 17px; border-right: #000000 1px solid; border-top: #000000 1px solid; border-left: #000000 1px solid; border-bottom: #000000 1px solid;" valign="middle">
                                        OPERATOR APPRAISAL</td>
                                </tr>
                                <tr>
                                    <td style="background-color: white; width: 196px; height: 21px;" class="for_normal" colspan="" rowspan="">
                                        EmpCode</td>
                                    <td style="width: 196px; background-color: white; height: 21px;" class="for_normal" colspan="" rowspan="">
                                        <asp:Label ID="lblemp" runat="server"></asp:Label></td>
                                    <td style="background-color: white; width: 196px; height: 21px;" class="for_normal" colspan="" rowspan="">
                                        EmpName</td>
                                    <td style="background-color: white; width: 196px; height: 21px;" class="for_normal" colspan="" rowspan="">
                                        <asp:Label ID="lblename" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="background-color: white; width: 196px;" class="for_normal" colspan="" rowspan="">
                                        Department</td>
                                    <td style="background-color: white; width: 196px;" class="for_normal" colspan="" rowspan="">
                                        <asp:Label ID="lbldept" runat="server"></asp:Label></td>
                                    <td style="background-color: white; width: 196px;" class="for_normal" colspan="" rowspan="">
                                        Section</td>
                                    <td style="background-color: white; width: 196px;" class="for_normal" colspan="" rowspan="">
                                        <asp:Label ID="lblsect" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="background-color: white; width: 196px;" class="for_normal" colspan="" rowspan="">
                                            Appraisal Date</td>
                                    <td style="background-color: white; width: 196px;" class="for_normal" colspan="" rowspan="">
                                            <asp:Label ID="Label1" runat="server" ForeColor="#000000"></asp:Label></td>
                                    <td style="background-color: white; width: 196px;" class="for_normal" colspan="" rowspan="">
                                        Employee Status
                                    </td>
                                    <td style="background-color: white; width: 196px;" class="for_normal" colspan="" rowspan="">
                                        <asp:Label ID="lblstatus" runat="server"></asp:Label></td>
                                </tr>
                             <tr>
                                 <td class="td_head" colspan="4" style="height: 21px; text-align: center; border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid;">
                                     EMPLOYEE HISTORY</td>
                                  
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: white">
                                      
                                     <table style="width: 100%">
                                         
                                                              
                                  <tr>
                                 <td style=" background-color: white; height: 21px;" class="for_normal">
                                     Medical Leave &nbsp;:<asp:Label ID="lblmedical" runat="server"></asp:Label></td>
                                 <td style=" background-color: white; height: 21px;" class="for_normal">
                                     Explanation &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                     &nbsp;:<asp:Label ID="lblexpl" runat="server"></asp:Label></td>
                                  <td style=" background-color: white; height: 21px;" class="for_normal">
                                      Final Warning &nbsp; &nbsp;:<asp:Label ID="lblfinw" runat="server"></asp:Label></td>
                             </tr>
                             <tr>
                                 <td style="background-color: white; height: 21px;" class="for_normal">
                                     Absent &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;:<asp:Label ID="lblabs" runat="server"></asp:Label></td>
                                 <td style="background-color: white; height: 21px;" class="for_normal">
                                     Verbal Warning &nbsp; &nbsp;&nbsp; &nbsp;:<asp:Label ID="lblvw" runat="server"></asp:Label></td>
                                 <td style="background-color: white; height: 21px;" class="for_normal">
                                     Suspension &nbsp; &nbsp; &nbsp;&nbsp; :<asp:Label ID="lblsus" runat="server"></asp:Label></td>
                             </tr>
                             <tr>
                                 <td style="background-color: white; height: 21px;" class="for_normal">
                                     Late &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;:<asp:Label
                                         ID="lbllate" runat="server"></asp:Label></td>
                                 <td style=" background-color: white; height: 21px;" class="for_normal">
                                     Written Warning &nbsp; &nbsp;&nbsp; :<asp:Label ID="lblww" runat="server"></asp:Label></td>
                                 <td style="background-color: white; height: 21px;" class="for_normal">
                                     Showcase &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; :<asp:Label ID="lblsc" runat="server"></asp:Label></td>
                             </tr>
                             <tr>
                                 <td style="background-color: white; height: 21px;" class="for_normal">
                                     Misconduct Counselling:<asp:Label ID="lblcoun" runat="server"></asp:Label></td>
                                 <td style=" background-color: white; height: 21px;" class="for_normal">
                                     First Warning &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;:<asp:Label ID="lblfw" runat="server"></asp:Label></td>
                                 <td style="background-color: white; height: 21px;" class="for_normal">
                                     Misconduct Rpt :<asp:Label ID="lblrpt" runat="server"></asp:Label></td>
                             </tr>
                                         <tr>
                                             <td class="td_head" colspan="3" style="border-right: #000000 1px solid; border-top: #000000 1px solid;
                                                 border-left: #000000 1px solid; border-bottom: #000000 1px solid; height: 17px">
                                     MONTHLY APPRAISAL DATA</td>
                                         </tr>
                                         <tr>
                                             <td colspan="4" style="height: 21px; background-color: white;">
                                                 <table style="border-right: black thin solid; border-top: black thin solid; border-left: black thin solid; border-bottom: black thin solid" cellpadding="0" cellspacing="0">
                                                     <tr>
                                                         <td style="vertical-align: middle; width: 100px; background-color: lightgrey; text-align: center">
                                                             JAN</td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: lightgrey; text-align: center">
                                                             FEB</td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: lightgrey; text-align: center">
                                                             MAR</td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: lightgrey; text-align: center">
                                                             APR</td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: lightgrey; text-align: center">
                                                             MAY</td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: lightgrey; text-align: center">
                                                             JUNE</td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: lightgrey; text-align: center">
                                                             Avg1-Grd1</td>
                                                     </tr>
                                                     <tr>
                                                         <td style="width: 100px; vertical-align: middle; background-color: white; text-align: center;">
                                                             <asp:Label ID="lbl1" runat="server"></asp:Label>-<asp:Label ID="Label13" runat="server"></asp:Label></td>
                                                         <td style="width: 100px; vertical-align: middle; background-color: white; text-align: center;">
                                                             <asp:Label ID="Label2" runat="server"></asp:Label>-<asp:Label ID="Label14" runat="server"></asp:Label></td>
                                                         <td style="width: 100px; vertical-align: middle; background-color: white; text-align: center;">
                                                             <asp:Label ID="Label3" runat="server"></asp:Label>-<asp:Label ID="Label15" runat="server"></asp:Label></td>
                                                         <td style="width: 100px; vertical-align: middle; background-color: white; text-align: center;">
                                                             <asp:Label ID="Label4" runat="server"></asp:Label>-<asp:Label ID="Label16" runat="server"></asp:Label></td>
                                                         <td style="width: 100px; vertical-align: middle; background-color: white; text-align: center;">
                                                             <asp:Label ID="Label5" runat="server"></asp:Label>-<asp:Label ID="Label17" runat="server"></asp:Label></td>
                                                         <td style="width: 100px; vertical-align: middle; background-color: white; text-align: center;">
                                                             <asp:Label ID="Label6" runat="server"></asp:Label>-<asp:Label ID="Label18" runat="server"></asp:Label></td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: white;
                                                             text-align: center">
                                                             <asp:Label ID="lbla1" runat="server"></asp:Label>-<asp:Label ID="lblg1" runat="server"></asp:Label></td>
                                                     </tr>
                                                     <tr>
                                                         <td style="vertical-align: middle; width: 100px; background-color: lightgrey; text-align: center">
                                                             JULY</td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: lightgrey; text-align: center">
                                                             AUG</td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: lightgrey; text-align: center">
                                                             SEP</td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: lightgrey; text-align: center">
                                                             OCT</td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: lightgrey; text-align: center">
                                                             NOV
                                                         </td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: lightgrey; text-align: center">
                                                             DEC</td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: lightgrey; text-align: center">
                                                             Avg2-Grd2</td>
                                                     </tr>
                                                     <tr>
                                                         <td style="width: 100px; vertical-align: middle; background-color: white; text-align: center;">
                                                             <asp:Label ID="Label7" runat="server"></asp:Label>-<asp:Label ID="Label19" runat="server"></asp:Label></td>
                                                         <td style="width: 100px; vertical-align: middle; background-color: white; text-align: center;">
                                                             <asp:Label ID="Label8" runat="server"></asp:Label>-<asp:Label ID="Label20" runat="server"></asp:Label></td>
                                                         <td style="width: 100px; vertical-align: middle; background-color: white; text-align: center;">
                                                             <asp:Label ID="Label9" runat="server"></asp:Label>-<asp:Label ID="Label21" runat="server"></asp:Label></td>
                                                         <td style="width: 100px; vertical-align: middle; background-color: white; text-align: center;">
                                                             <asp:Label ID="Label10" runat="server"></asp:Label>-<asp:Label ID="Label22" runat="server"></asp:Label></td>
                                                         <td style="width: 100px; vertical-align: middle; background-color: white; text-align: center;">
                                                             <asp:Label ID="Label11" runat="server"></asp:Label>-<asp:Label ID="Label23" runat="server"></asp:Label></td>
                                                         <td style="width: 100px; vertical-align: middle; background-color: white; text-align: center;">
                                                             <asp:Label ID="Label12" runat="server"></asp:Label>-<asp:Label ID="Label24" runat="server"></asp:Label></td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: white;
                                                             text-align: center">
                                                             <asp:Label ID="lbla2" runat="server"></asp:Label>-<asp:Label ID="lblg2" runat="server"></asp:Label></td>
                                                     </tr>
                                                 </table>
                                             </td>
                                         </tr>
                                     </table>
                                     
                        
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 17px; border-right: #000000 1px solid; border-top: #000000 1px solid; border-left: #000000 1px solid; border-bottom: #000000 1px solid;" class="td_head">
                                     PURPOSE OF APPRAISAL</td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: white">
                                     <asp:RadioButtonList ID="rdpurpose" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                                         <asp:ListItem Value="EP">End of Probation Period </asp:ListItem>
                                         <asp:ListItem Value="EC ">Extend Contract</asp:ListItem>
                                         <asp:ListItem Value="1/2 Yearly">1/2 Yearly Appraisal</asp:ListItem>
                                     </asp:RadioButtonList>&nbsp;
                                     <asp:Label ID="lblapp" runat="server" Text="Yearly appraisal :" Visible="False"></asp:Label>
                                     <asp:DropDownList ID="ddlhalf" runat="server" Visible="False">
                                         <asp:ListItem>1st Half</asp:ListItem>
                                         <asp:ListItem>2nd Half</asp:ListItem>
                                         <asp:ListItem Selected="True" Value="-">-Select-</asp:ListItem>
                                     </asp:DropDownList>
                                     <asp:Label ID="lblhalf" runat="server" Visible="False">-</asp:Label></td>
                             </tr>
                             <tr>
                                 <td class="td_head" colspan="4" style="height: 21px; text-align: center; border-right: #000000 1px solid; border-top: #000000 1px solid; border-left: #000000 1px solid; border-bottom: #000000 1px solid;">
                                     PERFORMANCE RATING INDICATOR (PRI)</td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; text-align: center;">
                                     <div style="text-align: left">
                                         <table style="text-align: center;" cellpadding="0" cellspacing="0">
                                             <tr>
                                                 <td style="width: 123px; height: 21px;" >
                                         A - Excellent</td>
                                                 <td style="width: 144px; height: 21px;">
                                         B - Good</td>
                                                 <td style="width: 143px; height: 21px;">
                                                     C-average</td>
                                                 <td style="width: 163px; height: 21px;">
                                                     D-Below average</td>
                                                 <td style="width: 181px; height: 21px;">
                                                     E-Poor</td>
                                             </tr>
                                             <tr>
                                                 <td style="width: 123px; height: 23px;">
                                                     45 - 50</td>
                                                 <td style="width: 144px; height: 23px;">
                                                     40 - 44</td>
                                                 <td style="width: 143px; height: 23px;">
                                                     35 - 39</td>
                                                 <td style="width: 163px; height: 23px;">
                                                     30 - 34</td>
                                                 <td style="width: 181px; height: 23px;">
                                                     29 &amp;&nbsp; Below</td>
                                             </tr>
                                         </table>
                                     </div>
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; text-align: center;" align="center" valign="middle">
                                     <asp:GridView ID="GrdOpt" runat="server" AutoGenerateColumns="False"
                                         DataSourceID="SqlDataSource1" ShowFooter="True" Width="647px">
                                         <Columns>
                                             <asp:BoundField DataField="sno" HeaderText="Sno" SortExpression="sno" />
                                             <asp:TemplateField HeaderText="Performance &amp; Scale " SortExpression="description">
                                                 <EditItemTemplate>
                                                     <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("description") %>'></asp:TextBox>
                                                 </EditItemTemplate>
                                                 <ItemTemplate>
                                                     <asp:Label ID="lbldesc" runat="server" Text='<%# Bind("description") %>'></asp:Label>
                                                 </ItemTemplate>
                                                      <FooterTemplate>
                                                  <asp:Label ID="Label2" runat="server" Text = "Total:" ></asp:Label>
                                                  <asp:Label ID="Lbltotal" runat="server" Text="0"></asp:Label>
                                                 </FooterTemplate>
                                             </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Grade">
                                                 <ItemTemplate>
                                                     <asp:RadioButtonList ID="rdprating" runat="server" RepeatDirection="Horizontal"
                                                         Width="420px" AutoPostBack="True" OnSelectedIndexChanged="chkDynamic_CheckedChanged">
                                                         <asp:ListItem Value="1">E</asp:ListItem>
                                                         <asp:ListItem Value="2">D</asp:ListItem>
                                                         <asp:ListItem Value="3">C</asp:ListItem>
                                                         <asp:ListItem Value="4">B</asp:ListItem>
                                                         <asp:ListItem Value="5">A</asp:ListItem>
                                                     </asp:RadioButtonList>
                                                     
                                                 </ItemTemplate>
                                                  <FooterTemplate>
                                                  <asp:Label ID="La" runat="server" Text=Grade: ></asp:Label>
                                                  <asp:Label ID="Lblgrade" runat="server" Text="0"></asp:Label>
                                                 </FooterTemplate>
                                             </asp:TemplateField>
                                         </Columns>
                                         <EditRowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                         <EmptyDataRowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                         <RowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                         <FooterStyle BorderColor="Black" BorderStyle="Solid" />
                                         <SelectedRowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                         <HeaderStyle BackColor="Silver" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                     </asp:GridView>
                                     &nbsp;
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="border-right: #000000 1px solid; border-top: #000000 1px solid; border-left: #000000 1px solid; border-bottom: #000000 1px solid" class="td_head">
                                       <div align="center" class="whitetext">
                                           RECOMMENDATION/ REMARKS BY DEPARTMENT HOD</div>
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px;" align="left" valign="top">
                                     <table border="0" cellpadding="0" cellspacing="0">
                                         <tr>
                                             <td style="width: 133px; background-color: white">
                                                 Employement status</td>
                                             <td style="width: 550px; background-color: white">
                                                 <asp:RadioButtonList ID="rdconfirm" runat="server" RepeatDirection="Horizontal">
                                                     <asp:ListItem Value="C">Confirm</asp:ListItem>
                                                     <asp:ListItem Value="N">Contract</asp:ListItem>
                                                     <asp:ListItem Value="E">Extend Probation (3 Mth)</asp:ListItem>
                                                 </asp:RadioButtonList></td>
                                         </tr>
                                         <tr>
                                             <td style="width: 133px; background-color: white;">
                                                 SH comment</td>
                                             <td style="width: 550px; background-color: white">
                                                 <asp:Label ID="lblcomment" runat="server"></asp:Label></td>
                                         </tr>
                                         <tr>
                                             <td style="width: 133px; background-color: white;">
                                                 DH comment</td>
                                             <td style="width: 550px; background-color: white">
                                                 <asp:Label ID="lblcommentdh" runat="server"></asp:Label></td>
                                         </tr>
                                         <tr>
                                             <td style="width: 133px; background-color: white; height: 19px;">
                                                 EA comments</td>
                                             <td style="width: 550px; background-color: white; height: 19px;">
                                                 <asp:Label ID="txtea" runat="server"></asp:Label></td>
                                         </tr>
                                     </table>
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px;" align="right">
                                     &nbsp;<asp:Button ID="txtbutton" runat="server" Text="SAVE" Visible="False" /></td>
                             </tr>
                                </table>
                            &nbsp;
                                     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                         SelectCommand="SELECT [description], [sno] FROM [optappraisal]"></asp:SqlDataSource>
                                  </td>
                    <td style="width: 25px; height: 248px;">
                        <%--<IMG height="11" src="../../images/cen_rig.gif" width="24">--%></td>
                </tr>
                <tr>
                    <td height="16" style="width: 16px">
                        <%--<IMG height="16" src="../../images/bot_lef.gif" width="16">--%></td>
                    <td height="16" style="width: 650px">
                        <%--<IMG height="16" src="../../images/bot_mid.gif" width="16">--%></td>
                    <td height="16" style="width: 25px">
                        <%--<IMG height="16" src="../../images/bot_rig.gif" width="24">--%></td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>
