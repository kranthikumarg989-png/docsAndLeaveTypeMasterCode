<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="StaffAppraisalFinalReport.aspx.vb" Inherits="E_Management.StaffAppraisalFinalReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Staff Appraisal Print</title>
      <link rel="stylesheet" type="text/css" href="~/css/style.css" /> 
            <link rel="stylesheet" type="text/css" href="~/css/stylesheet.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table cellpadding=0 cellspacing=0 class="for_normal" style="border-top-width: thin; border-left-width: thin; border-left-color: #000000; border-bottom-width: thin; border-bottom-color: #000000; border-top-color: #000000; border-right-width: thin; border-right-color: #000000">
        <tr>
            <td align="center" colspan="4" valign="middle">
                <strong>APPRAISAL REPORTS</strong></td>
        </tr>
                    <tr>
                        <td style="width: 16px; height: 16px">
                            <%--<IMG height="16" src="../../images/top_lef.gif" width="16">--%></td>
                    </tr>
                    <tr>
                        <%--<td background="../../images/cen_lef.gif" style="width: 16px; height: 248px;">
                        <IMG height="11" src="../../images/cen_lef.gif" width="16"></td>--%>
                        <td valign="top" bgColor="#ffffff" style="width: 687px; text-align: right; height: 2688px;">
                         <table style="text-align: left; border-top-width: thin; border-left-width: thin; border-left-color: #000000; border-bottom-width: thin; border-bottom-color: #000000; border-top-color: #000000; border-right-width: thin; border-right-color: #000000;">
                                <tr>
                                    <td align="center" colspan="4" style="height: 17px; border-right: black thin solid; padding-right: 1px; border-top: black thin solid; padding-left: 1px; padding-bottom: 1px; margin: 1px; border-left: black thin solid; padding-top: 1px; border-bottom: black thin solid; background-color: gainsboro;" valign="middle" class="for_header">
                                        <strong>EMPLOYEE'S APPRAISAL REPORT (STAFF LEVEL)</strong></td>
                                </tr>
                                <tr>
                                    <td style="height: 21px; background-color: white; width: 120px;">
                                        <strong>
                                        EmpCode</strong></td>
                                    <td style="width: 120px; background-color: white; height: 21px;">
                                        <asp:Label ID="txtempcode" runat="server"></asp:Label></td>
                                    <td style="background-color: white; width: 120px; height: 21px;">
                                        <strong>
                                        EmpName</strong></td>
                                    <td style="background-color: white; width: 120px; height: 21px;">
                                        <asp:Label ID="lblename" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="background-color: white; width: 120px; height: 21px;">
                                        <strong>Department</strong></td>
                                    <td style="background-color: white; width: 120px; height: 21px;">
                                        <asp:Label ID="lbldept" runat="server"></asp:Label></td>
                                    <td style="background-color: white; height: 21px; width: 120px;">
                                        <strong>Section</strong></td>
                                    <td style="background-color: white; width: 120px; height: 21px;">
                                        <asp:Label ID="lblsect" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="background-color: white; width: 120px; height: 21px;">
                                        <strong>
                                        Designation</strong></td>
                                    <td style="background-color: white; width: 120px; height: 21px;">
                                        <asp:Label ID="lbldesig" runat="server"></asp:Label></td>
                                    <td style="background-color: white; width: 120px; height: 21px;">
                                        <strong>Employee Status </strong>
                                    </td>
                                    <td style="background-color: white; width: 120px; height: 21px;">
                                        <asp:Label ID="lblstatus" runat="server"></asp:Label></td>
                                </tr>
                             <tr>
                                 <td style="width: 120px; height: 21px; background-color: white">
                                     <strong>
                                     Reviewer/Supervisor</strong></td>
                                 <td  style="height: 21px; background-color: white; width: 120px;">
                                        <asp:Label ID="lblempcode" runat="server"></asp:Label>-<asp:Label ID="lblempname"
                                         runat="server"></asp:Label></td>
                                         <td style="height: 21px; background-color: white; width: 120px;">
                                             <strong>
                                             Appraisal Date</strong></td>
                                         <td style="height: 21px; background-color: white; width: 120px;">
                                            <asp:Label ID="Label1" runat="server" ForeColor="#000000"></asp:Label></td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: white">
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 20px; border-right: black thin solid; border-top: black thin solid; margin: 1px; border-left: black thin solid; border-bottom: black thin solid; background-color: gainsboro; text-align: center;" class="for_header">
                                     <strong>
                                     Employee History </strong>
                                     
                                     
                                     
                                     </td>
                                  
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 20px; background-color: white">
                                      
                                     <table style="width: 100%">
                                         
                                                              
                                  <tr>
                                 <td style=" background-color: white;">
                                     Medical Leave &nbsp;:<asp:Label ID="lblmedical" runat="server"></asp:Label></td>
                                 <td style=" background-color: white">
                                     Explanation &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;:<asp:Label ID="lblexpl" runat="server"></asp:Label></td>
                                  <td style=" background-color: white">
                                      Final Warning &nbsp; &nbsp;:<asp:Label ID="lblfinw" runat="server"></asp:Label></td>
                             </tr>
                             <tr>
                                 <td style="background-color: white;">
                                     Absent &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;:<asp:Label ID="lblabs" runat="server"></asp:Label></td>
                                 <td style="background-color: white">
                                     Verbal Warning &nbsp; &nbsp;&nbsp; &nbsp;:<asp:Label ID="lblvw" runat="server"></asp:Label></td>
                                 <td style="background-color: white">
                                     Suspension &nbsp; &nbsp; &nbsp;&nbsp; :<asp:Label ID="lblsus" runat="server"></asp:Label></td>
                             </tr>
                             <tr>
                                 <td style="background-color: white;">
                                     Late &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;:<asp:Label
                                         ID="lbllate" runat="server"></asp:Label></td>
                                 <td style=" background-color: white">
                                     Written Warning &nbsp; &nbsp;&nbsp; :<asp:Label ID="lblww" runat="server"></asp:Label></td>
                                 <td style="background-color: white">
                                     Showcase &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; :<asp:Label ID="lblsc" runat="server"></asp:Label></td>
                             </tr>
                             <tr>
                                 <td style="background-color: white; height: 21px;">
                                     Misconduct Counselling:<asp:Label ID="lblcoun" runat="server"></asp:Label></td>
                                 <td style=" background-color: white; height: 21px;">
                                     First Warning &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; 
                                     :<asp:Label ID="lblfw" runat="server"></asp:Label></td>
                                 <td style="background-color: white; height: 21px;">
                                     Misconduct Rpt :<asp:Label ID="lblrpt" runat="server"></asp:Label></td>
                             </tr>
                                         <tr>
                                             <td colspan="3" style="height: 21px; background-color: white">
                                             </td>
                                         </tr>
                             <tr>
                                 <tr>
                                 <td colspan="4" style="height: 21px; border-right: #000000 thin solid; border-top: #000000 thin solid; margin: 1px; border-left: #000000 thin solid; border-bottom: #000000 thin solid; background-color: gainsboro; text-align: center;">
                                     <strong>
                                     Monthly Appraisal Data</strong></td>
                              
                             </tr>
                                         <tr>
                                             <td colspan="4" style="height: 21px; background-color: #ffffff;">
                                                 <table style="border-right: #000000 thin solid; border-top: #000000 thin solid; border-left: #000000 thin solid; border-bottom: #000000 thin solid; height: 131px;">
                                                     <tr>
                                                         <td style="vertical-align: middle; width: 100px; background-color: whitesmoke; text-align: center; border-right: #000000 thin solid; border-top: #000000 thin solid; border-left: #000000 thin solid; border-bottom: #000000 thin solid;">
                                                             JAN</td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: whitesmoke; text-align: center; border-right: #000000 thin solid; border-top: #000000 thin solid; border-left: #000000 thin solid; border-bottom: #000000 thin solid;">
                                                             FEB</td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: whitesmoke; text-align: center; border-right: #000000 thin solid; border-top: #000000 thin solid; border-left: #000000 thin solid; border-bottom: #000000 thin solid;">
                                                             MAR</td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: whitesmoke; text-align: center; border-right: #000000 thin solid; border-top: #000000 thin solid; border-left: #000000 thin solid; border-bottom: #000000 thin solid;">
                                                             APR</td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: whitesmoke; text-align: center; border-right: #000000 thin solid; border-top: #000000 thin solid; border-left: #000000 thin solid; border-bottom: #000000 thin solid;">
                                                             MAY</td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: whitesmoke; text-align: center; border-right: #000000 thin solid; border-top: #000000 thin solid; border-left: #000000 thin solid; border-bottom: #000000 thin solid;">
                                                             JUNE</td>
                                                         <td style="vertical-align: middle; width: 150px; background-color: whitesmoke; text-align: center; border-right: #000000 thin solid; border-top: #000000 thin solid; border-left: #000000 thin solid; border-bottom: #000000 thin solid;">
                                                             Avg</td>
                                                     </tr>
                                                     <tr>
                                                         <td style="vertical-align: middle; width: 100px; background-color: white;
                                                             text-align: center; border-right: #000000 thin solid; border-top: #000000 thin solid; border-left: #000000 thin solid; border-bottom: #000000 thin solid;">
                                                             <asp:Label ID="lbl1" runat="server"></asp:Label>-<asp:Label ID="Label13" runat="server"></asp:Label></td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: white;
                                                             text-align: center; border-right: #000000 thin solid; border-top: #000000 thin solid; border-left: #000000 thin solid; border-bottom: #000000 thin solid;">
                                                             <asp:Label ID="Label2" runat="server"></asp:Label>-<asp:Label ID="Label14" runat="server"></asp:Label></td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: white;
                                                             text-align: center; border-right: #000000 thin solid; border-top: #000000 thin solid; border-left: #000000 thin solid; border-bottom: #000000 thin solid;">
                                                             <asp:Label ID="Label3" runat="server"></asp:Label>-<asp:Label ID="Label15" runat="server"></asp:Label></td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: white;
                                                             text-align: center; border-right: #000000 thin solid; border-top: #000000 thin solid; border-left: #000000 thin solid; border-bottom: #000000 thin solid;">
                                                             <asp:Label ID="Label4" runat="server"></asp:Label>-<asp:Label ID="Label16" runat="server"></asp:Label></td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: white;
                                                             text-align: center; border-right: #000000 thin solid; border-top: #000000 thin solid; border-left: #000000 thin solid; border-bottom: #000000 thin solid;">
                                                             <asp:Label ID="Label5" runat="server"></asp:Label>-<asp:Label ID="Label17" runat="server"></asp:Label></td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: white;
                                                             text-align: center; border-right: #000000 thin solid; border-top: #000000 thin solid; border-left: #000000 thin solid; border-bottom: #000000 thin solid;">
                                                             <asp:Label ID="Label6" runat="server"></asp:Label>-<asp:Label ID="Label18" runat="server"></asp:Label></td>
                                                         <td rowspan="3" style="vertical-align: middle; width: 150px; background-color: white;
                                                             text-align: center; border-right: #000000 thin solid; border-top: #000000 thin solid; border-left: #000000 thin solid; border-bottom: #000000 thin solid;">
                                                             <asp:Label ID="lblavg" runat="server" Text="Label"></asp:Label>
                                                             -<asp:Label ID="lblgrd" runat="server" Text="Label"></asp:Label></td>
                                                     </tr>
                                                     <tr>
                                                         <td style="vertical-align: middle; width: 100px; background-color: white; text-align: center; border-right: #000000 thin solid; border-top: #000000 thin solid; border-left: #000000 thin solid; border-bottom: #000000 thin solid;">
                                                             JULY</td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: white; text-align: center; border-right: #000000 thin solid; border-top: #000000 thin solid; border-left: #000000 thin solid; border-bottom: #000000 thin solid;">
                                                             AUG</td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: white; text-align: center; border-right: #000000 thin solid; border-top: #000000 thin solid; border-left: #000000 thin solid; border-bottom: #000000 thin solid;">
                                                             SEP</td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: white; text-align: center; border-right: #000000 thin solid; border-top: #000000 thin solid; border-left: #000000 thin solid; border-bottom: #000000 thin solid;">
                                                             OCT</td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: white; text-align: center; border-right: #000000 thin solid; border-top: #000000 thin solid; border-left: #000000 thin solid; border-bottom: #000000 thin solid;">
                                                             NOV
                                                         </td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: white; text-align: center; border-right: #000000 thin solid; border-top: #000000 thin solid; border-left: #000000 thin solid; border-bottom: #000000 thin solid;">
                                                             DEC</td>
                                                     </tr>
                                                     <tr>
                                                         <td style="vertical-align: middle; width: 100px; background-color: white;
                                                             text-align: center; border-right: #000000 thin solid; border-top: #000000 thin solid; border-left: #000000 thin solid; border-bottom: #000000 thin solid;">
                                                             <asp:Label ID="Label7" runat="server"></asp:Label>-<asp:Label ID="Label19" runat="server"></asp:Label></td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: white;
                                                             text-align: center; border-right: #000000 thin solid; border-top: #000000 thin solid; border-left: #000000 thin solid; border-bottom: #000000 thin solid;">
                                                             <asp:Label ID="Label8" runat="server"></asp:Label>-<asp:Label ID="Label20" runat="server"></asp:Label></td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: white;
                                                             text-align: center; border-right: #000000 thin solid; border-top: #000000 thin solid; border-left: #000000 thin solid; border-bottom: #000000 thin solid;">
                                                             <asp:Label ID="Label9" runat="server"></asp:Label>-<asp:Label ID="Label21" runat="server"></asp:Label></td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: white;
                                                             text-align: center; border-right: #000000 thin solid; border-top: #000000 thin solid; border-left: #000000 thin solid; border-bottom: #000000 thin solid;">
                                                             <asp:Label ID="Label10" runat="server"></asp:Label>-<asp:Label ID="Label22" runat="server"></asp:Label></td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: white;
                                                             text-align: center; border-right: #000000 thin solid; border-top: #000000 thin solid; border-left: #000000 thin solid; border-bottom: #000000 thin solid;">
                                                             <asp:Label ID="Label11" runat="server"></asp:Label>-<asp:Label ID="Label23" runat="server"></asp:Label></td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: white;
                                                             text-align: center; border-right: #000000 thin solid; border-top: #000000 thin solid; border-left: #000000 thin solid; border-bottom: #000000 thin solid;">
                                                             <asp:Label ID="Label12" runat="server"></asp:Label>-<asp:Label ID="Label24" runat="server"></asp:Label></td>
                                                     </tr>
                                                 </table>
                                     <asp:Label ID="lblapp" runat="server" Text="Yearly appraisal :" Visible="False"></asp:Label><asp:DropDownList
                                         ID="ddlhalf" runat="server" Visible="False">
                                         <asp:ListItem>1st Half</asp:ListItem>
                                         <asp:ListItem>2nd Half</asp:ListItem>
                                         <asp:ListItem Selected="True" Value="-">-Select-</asp:ListItem>
                                     </asp:DropDownList><asp:Label ID="lblhalf" runat="server" Visible="False">-</asp:Label></td>
                                         </tr>
                                     </table>
                                     </td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: gainsboro; border-right: #000000 thin solid; border-top: #000000 thin solid; border-left: #000000 thin solid; border-bottom: #000000 thin solid; text-align: center;">
                                     <strong>
                                     Purpose Of Appraisal</strong></td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: white">
                                     <asp:RadioButtonList ID="rdpurpose" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" Width="642px" Enabled="False">
                                         <asp:ListItem Value="EP">End of Probation Period </asp:ListItem>
                                         <asp:ListItem Value="EC ">Extend Contract</asp:ListItem>
                                         <asp:ListItem Value="1/2 Yearly">1/2 Yearly Appraisal</asp:ListItem>
                                     </asp:RadioButtonList></td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; border-right: #000000 thin solid; border-top: #000000 thin solid; border-left: #000000 thin solid; border-bottom: #000000 thin solid; background-color: gainsboro; text-align: center;">
                                     <strong>Performance Rating Indicator ( PRI )</strong></td>
                             </tr>
                             <tr>
                                 <td colspan="4">
                                     <table border="1" cellpadding="1" cellspacing="1" style="width: 100%">
                                         <caption>
                                         </caption>
                                         <tr>
                                             <td align="center" style="width: 44px">
                                                 &nbsp;A<br />
                                                 (100~100%)</td>
                                             <td style="width: 105px">
                                                 Significantly exceed required standards (SES)
                                             </td>
                                             <td style="width: 269px">
                                                 Regularly performs duties far better than expected in terms of quality, quantity
                                                 of work and within the specified period of time.
                                             </td>
                                         </tr>
                                         <tr >
                                             <td align="center" style="width: 44px">
                                                 B<br />
                                                 (80 ~ 99%)</td>
                                             <td style="width: 105px">
                                                 Exeeds the required standard (ERS)</td>
                                             <td style="width: 269px">
                                                 Regularly performs duties better than the required standards for such position in
                                                 terms of quality, quantity of work and achieves within the specified period of time.</td>
                                         </tr>
                                         <tr>
                                             <td align="center" style="width: 44px">
                                                 C<br />
                                                 (60 ~ 79%)</td>
                                             <td style="width: 105px">
                                                 Meets required standards / target (MRS)</td>
                                             <td style="width: 269px">
                                                 Able to perform duties to meet the required standards regularly and sometimes above
                                                 the required standards in terms of quality, quantity of work and achieves within
                                                 the specified period of time</td>
                                         </tr>
                                         <tr>
                                             <td align="center" style="width: 44px">
                                                 D<br />
                                                 (40 ~ 59%)</td>
                                             <td style="width: 105px">
                                                 Partially meets the required standards (Monitoring)
                                             </td>
                                             <td style="width: 269px">
                                                 Perform duties in accordance with goals and objectives occasionally but improvemenments
                                                 are required for quality, quantity of work and achieves within the specified period
                                                 of time in order to completer the work. Frequent supervision from a supervisor may
                                                 be required for the tasks. An employee who has just be placed in the position may
                                                 be at this level.
                                             </td>
                                         </tr>
                                         <tr>
                                             <td align="center" style="width: 44px; height: 80px;">
                                                 E<br />
                                                 (39 &amp; Below)</td>
                                             <td style="width: 105px; height: 80px;">
                                                 Below standards (PIP)
                                             </td>
                                             <td style="width: 269px; height: 80px;">
                                                 Unable to perform duties to meet the required standards and expectations within
                                                 the agreed time as assigned. An employee who is rated at this level shall be required
                                                 to participate in the process for work performance improvement.
                                             </td>
                                         </tr>
                                         <tr>
                                             <td align="center" style="width: 44px; height: 23px;">
                                                 NP<br />
                                             </td>
                                             <td style="width: 105px; height: 23px;">
                                                 Not Applicable (NP)
                                             </td>
                                             <td style="width: 269px; height: 23px;">
                                                 Agreed that job goals set are no longer applicable due to unforeseen circumstances
                                                 and/or change of business direction/environment.
                                             </td>
                                         </tr>
                                     </table>
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: white">
                                     <table style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; width: 100%; border-bottom: black 1px solid; text-align: left;" cellpadding="1" cellspacing="1">
                                         <tr>
                                             <th style="background-color: whitesmoke" >
                                                 Position</th>
                                             <th style="background-color: whitesmoke" >
                                                 Section 1</th>
                                             <th style="background-color: whitesmoke" >
                                                 Section 2</th>
                                         </tr>
                                         <tr>
                                             <td style="background-color: white" >
                                                 Exec. and above</td>
                                             <td style="background-color: white" >
                                                 80% Performance
                                             </td>
                                             <td style="background-color: white" >
                                                 20% Characteristics</td>
                                         </tr>
                                         <tr>
                                             <td style="background-color: white" >
                                                 Sup. and above
                                             </td>
                                             <td style="background-color: white" >
                                                 80% Performance
                                             </td>
                                             <td style="background-color: white" >
                                                 20% Characteristics</td>
                                         </tr>
                                         <tr>
                                             <td style="background-color: white" >
                                                 L.L. and above</td>
                                             <td style="background-color: white" >
                                                 80% Performance
                                             </td>
                                             <td style="background-color: white" >
                                                 20% Characteristics</td>
                                         </tr>
                                     </table>
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: white">
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: white">
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; border-right: #000000 thin solid; border-top: #000000 thin solid; border-left: #000000 thin solid; border-bottom: #000000 thin solid; background-color: gainsboro; text-align: center;">
                                     <strong>
                                     <asp:Label ID="lbljskey" runat="server" Visible="False">0</asp:Label>Section 1 : Review Job Goals Status ( Key Result Area) 
                                     </strong></td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: white; text-align: left">
                                     All Accomplishments(Action plan) must be supported with documentary evidence on a
                                         monthly basis</td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: white; text-align: left">
                                     <asp:GridView ID="grdJg" runat="server" AutoGenerateColumns="False" BackColor="White"
                                         BorderColor="Black" BorderWidth="1px" DataSourceID="Sqljs" ShowFooter="True" Visible="False" Width="100%" BorderStyle="Solid">
                                         <Columns>
                                             <asp:BoundField DataField="sno" HeaderText="sno" SortExpression="sno" />
                                             <asp:TemplateField HeaderText="Job Goals" SortExpression="man_keyresult">
                                                 <ItemTemplate>
                                                     <asp:Label ID="Lblman" runat="server" Text='<%# Bind("man_keyresult") %>'></asp:Label>
                                                 </ItemTemplate>
                                                 <FooterTemplate>
                                                     <asp:Label ID="Lblmant" runat="server" Text="Total"></asp:Label>
                                                 </FooterTemplate>
                                             </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Weightage">
                                                 <ItemTemplate>
                                                     <asp:TextBox ID="pweight" runat="server" AutoPostBack="true" OnTextChanged="Calculatetotal"
                                                         Width="41px" Enabled="False" ReadOnly="True"></asp:TextBox>%
                                                 </ItemTemplate>
                                                 <FooterTemplate>
                                                     <asp:Label ID="Lblweit" runat="server" Text="0"></asp:Label>%
                                                 </FooterTemplate>
                                             </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Points">
                                                 <ItemTemplate>
                                                     <asp:Label ID="ppoint" runat="server">0</asp:Label>
                                                 </ItemTemplate>
                                                 <FooterTemplate>
                                                     <asp:Label ID="lblpts" runat="server" Text="0"></asp:Label>%
                                                 </FooterTemplate>
                                             </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Refer (PRI) and Grade below">
                                                 <ItemTemplate>
                                                     <asp:RadioButtonList ID="rdprating" runat="server" AutoPostBack="True" OnSelectedIndexChanged="chkDynamic_CheckedChanged"
                                                         RepeatDirection="Horizontal" Enabled="False">
                                                         <asp:ListItem Value="5">A</asp:ListItem>
                                                         <asp:ListItem Value="4">B</asp:ListItem>
                                                         <asp:ListItem Value="3">C</asp:ListItem>
                                                         <asp:ListItem Value="2">D</asp:ListItem>
                                                         <asp:ListItem Value="1">E</asp:ListItem>
                                                     </asp:RadioButtonList>
                                                 </ItemTemplate>
                                                 <FooterTemplate>
                                                     <asp:Label ID="Lblmarks" runat="server" Text="0"></asp:Label>
                                                 </FooterTemplate>
                                             </asp:TemplateField>
                                         </Columns>
                                         <HeaderStyle BackColor="#E0E0E0" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                         <RowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                         <EmptyDataRowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                         <EditRowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                     </asp:GridView>
                                     </td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="border-right: #000000 thin solid; border-top: #000000 thin solid;
                                     border-left: #000000 thin solid; border-bottom: #000000 thin solid; height: 21px;
                                     background-color: gainsboro; text-align: center">
                                     <span style="background-color: whitesmoke"><strong>Section 2 : Peformance Characteristics and behaviorable measurement 
                                         <br />
                                     </strong>
                                     </span>
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 3px; background-color: white; text-align: center">
                                     <span style="background-color: #f5f5f5">
                                         These important core values and competencies that are required to excel in their
                                         respective area of job<br />
                                     </span>
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: white">
                                     &nbsp;<asp:GridView ID="GrdPerformance" runat="server" AutoGenerateColumns="False"
                                         BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" DataSourceID="sqlperformance"
                                         ShowFooter="True" Width="100%">
                                         <RowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                         <EmptyDataRowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                         <Columns>
                                             <asp:BoundField DataField="sno" HeaderText="S No." SortExpression="sno" />
                                             <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" Visible="False" />
                                             <asp:BoundField DataField="per" HeaderText="Behaviour" SortExpression="per">
                                                 <ItemStyle Width="200px" />
                                             </asp:BoundField>
                                             <asp:TemplateField HeaderText="Review">
                                                 <FooterTemplate>
                                                     <asp:Label ID="Lblmanb" runat="server" Text="Total"></asp:Label>
                                                 </FooterTemplate>
                                                 <ItemTemplate>
                                                     Strength<br />
                                                     <asp:TextBox ID="txtstrength" runat="server" Rows="3" TextMode="MultiLine" Enabled="False" Height="35px" Width="217px"></asp:TextBox><br />
                                                     Improvement<br />
                                                     <asp:TextBox ID="txtimpt" runat="server" Rows="3" TextMode="MultiLine" Enabled="False" Height="35px" Width="216px"></asp:TextBox>
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Weightage">
                                                 <FooterTemplate>
                                                     <asp:Label ID="Lblbweit" runat="server" Text="0"></asp:Label>%
                                                 </FooterTemplate>
                                                 <ItemTemplate>
                                                     <asp:TextBox ID="txtbweit" runat="server" AutoPostBack="true" OnTextChanged="Calculatetotal2"
                                                         Width="41px" Enabled="False"></asp:TextBox>%
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Points">
                                                 <FooterTemplate>
                                                     <asp:Label ID="Lblbpts" runat="server" Text="0"></asp:Label>%
                                                 </FooterTemplate>
                                                 <ItemTemplate>
                                                     <asp:Label ID="lblbpoints" runat="server" Text="0"></asp:Label>
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Indicate Grade">
                                                 <FooterTemplate>
                                                     <asp:Label ID="Lblbmarks" runat="server" Text="0"></asp:Label>
                                                 </FooterTemplate>
                                                 <ItemTemplate>
                                                     <asp:RadioButtonList ID="rdbutton" runat="server" AutoPostBack="True" OnSelectedIndexChanged="chkDynamic2_CheckedChanged" Enabled="False">
                                                         <asp:ListItem Value="5">A</asp:ListItem>
                                                         <asp:ListItem Value="4">B</asp:ListItem>
                                                         <asp:ListItem Value="3">C</asp:ListItem>
                                                         <asp:ListItem Value="2">D</asp:ListItem>
                                                         <asp:ListItem Value="1">E</asp:ListItem>
                                                     </asp:RadioButtonList>
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                         </Columns>
                                         <SelectedRowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                         <HeaderStyle BackColor="#E0E0E0" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                         <EditRowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                         <AlternatingRowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                     </asp:GridView>
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: white">
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="border-right: #000000 thin solid; border-top: #000000 thin solid;
                                     border-left: #000000 thin solid; border-bottom: #000000 thin solid; height: 21px;
                                     background-color: whitesmoke; text-align: center">
                                     <strong>
                                         Section 3 : Result Overview
                                     </strong>
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: white">
                                     <strong>
                                     Performance Initiatives/ Challenges : </strong>
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: white">
                                                 (Identify up to three areas where strengths have been demonstrated over the past
                                                 year. Please include examples) Strengths can include behaviour/ attitude and competencies
                                                 or skill level - reference to be made to employee role description as currently
                                                 assessed.</td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: white">
                                     <table width = 100%>
                                         <tr>
                                             <td style="width: 138px; background-color: white; height: 37px;">
                                                 <strong>Comments : </strong>
                                             </td>
                                             <td style="width: 100px; background-color: white; height: 37px;">
                                                 &nbsp;<asp:Label ID="txtperformance" runat="server" Width="500px"></asp:Label></td>
                                         </tr>
                                     </table>
                                     <strong>
                                     Target missing in Current Year : </strong>
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: white">
                                                 (Identify key areas in which development would lead to improved performance. Please
                                                 include examples). Improvement can include behaviour / attitude and competencies
                                                 or skill level aspect - reference to be made to employee role description as currently
                                                 assessed.</td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: white">
                                     <table width = 100%>
                                         <tr>
                                             <td style="background-color: white; width: 150px;">
                                                 <strong>Comments : </strong>
                                             </td>
                                             <td style="background-color: white;">
                                                 &nbsp;<asp:Label ID="txttarget" runat="server" Width="500px"></asp:Label></td>
                                         </tr>
                                         <tr>
                                             <td colspan="2" style="background-color: white">
                                                 <strong>
                                     Areas Needs Improvement (Development in Career / development Plan) </strong>
                                             </td>
                                         </tr>
                                         <tr>
                                             <td style="width: 150px; background-color: white; height: 21px;">
                                                 <strong>Comments :</strong></td>
                                             <td style="background-color: white; height: 21px;">
                                                 &nbsp;<asp:Label ID="txtarea" runat="server" Width="500px"></asp:Label></td>
                                         </tr>
                                     </table>
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="border-right: #000000 thin solid; border-top: #000000 thin solid;
                                     border-left: #000000 thin solid; border-bottom: #000000 thin solid; height: 21px;
                                     background-color: whitesmoke; text-align: center">
                                     <strong>
                                         Over all Final Rating Summary (Section 1 &amp; 2 of the employee) </strong>
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: white">
                                     <table>
                                         <tr>
                                             <td style="width: 100px; background-color: white;">
                                                 Final Points</td>
                                             <td style="width: 100px; background-color: white;">
                                                 <asp:Label ID="lblfinpoints" runat="server" ForeColor="Black" Font-Bold="True"></asp:Label></td>
                                             <td style="width: 100px; background-color: white;">
                                                 Final Weightage</td>
                                             <td style="width: 100px; background-color: white;">
                                                 <asp:Label ID="lblfinalweit" runat="server" ForeColor="Black" Text="100" Font-Bold="True"></asp:Label></td>
                                             <td style="width: 100px; background-color: white;">
                                                 Final Grade</td>
                                             <td style="width: 100px; background-color: white;">
                                                 <asp:Label ID="lblfingrade" runat="server" ForeColor="Black" Font-Bold="True"></asp:Label></td>
                                         </tr>
                                     </table>
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="border-right: #000000 thin solid; border-top: #000000 thin solid;
                                     border-left: #000000 thin solid; border-bottom: #000000 thin solid; height: 21px;
                                     background-color: whitesmoke; text-align: center">
                                     <strong>
                                       Recommendation / Remarks by Department Head </strong>
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: white">
                                     <asp:Label ID="Label26" runat="server" Font-Bold="True" Text="Recommended Grade By Department Head :"></asp:Label>
                                     <asp:Label ID="lbldhgrade" runat="server" ForeColor="Black" Font-Bold="True"></asp:Label></td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: white">
                                     <table style="width: 100%">
                                         <tr>
                                             <td style="width: 141px; height: 25px; background-color: white;">
                                                 <strong>Employment status</strong></td>
                                             <td colspan="2" style="height: 25px; width: 100px; background-color: white;">
                                                 <asp:RadioButtonList ID="rdconfirm" runat="server" RepeatDirection="Horizontal" Width="439px" Enabled="False">
                                                     <asp:ListItem Value="C">Confirmation</asp:ListItem>
                                                     <asp:ListItem Value="E">Extend Probation (1 Mth)</asp:ListItem>
                                                     <asp:ListItem Value="EC">Extend contract</asp:ListItem>
                                                 </asp:RadioButtonList></td>
                                         </tr>
                                         <tr>
                                             <td colspan="3" style="height: 25px; background-color: white">
                                             </td>
                                         </tr>
                                         <tr>
                                 <td colspan="4" style="border-right: #000000 thin solid; border-top: #000000 thin solid;
                                     border-left: #000000 thin solid; border-bottom: #000000 thin solid; height: 21px;
                                     background-color: whitesmoke; text-align: center">
                                     <strong>
                                     To Be Filled By EA</strong></td>
                                         </tr>
                                         <tr>
                                             <td style="width: 141px; height: 25px; background-color: white">
                                                 <strong>Comments : </strong>
                                             </td>
                                             <td colspan="2" style="width: 100px; height: 25px; background-color: white">
                                                 <asp:Label ID="txtEA" runat="server" Width="500px"></asp:Label></td>
                                         </tr>
                                         <tr>
                                             <td style="width: 141px; height: 25px; background-color: white">
                                                 <strong>Grade By EA :</strong></td>
                                             <td colspan="2" style="width: 100px; height: 25px; background-color: white">
                                                 <asp:Label ID="rdEarating" runat="server" Width="122px"></asp:Label></td>
                                         </tr>
                                         <tr>
                                             <td style="width: 141px; height: 25px; background-color: white">
                                                 <strong>Points By EA :</strong></td>
                                             <td colspan="2" style="width: 100px; height: 25px; background-color: white">
                                                 <asp:Label ID="eapoints" runat="server" Width="120px"></asp:Label></td>
                                         </tr>
                                     </table>
                            <asp:Button ID="txtbutton" runat="server" Text="SAVE" Visible="False" /></td>
                             </tr>
                                </table>
                            &nbsp;
                            &nbsp;&nbsp;
                                  </td>
                </tr>
            </table>
                                  <asp:SqlDataSource ID="Sqljs" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                         SelectCommand="SELECT DISTINCT [man_keyresult], [sno] FROM [man_keygoal] WHERE (([empcode] = @empcode) AND ([recordno] = @recordno)) ORDER BY [sno]">
                                         <SelectParameters>
                                             <asp:ControlParameter ControlID="txtempcode" Name="empcode" PropertyName="Text" Type="String"  />
                                             <asp:ControlParameter ControlID="lbljskey" Name="recordno" PropertyName="Text" Type="Int32"  />
                                         </SelectParameters>
                                     </asp:SqlDataSource>
                                     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                         SelectCommand="SELECT [designationname] FROM [designation] ORDER BY [designationname]">
                                     </asp:SqlDataSource>
                                     <asp:SqlDataSource ID="sqlperformance" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                         SelectCommand="SELECT [sno], [per] FROM [app_charsettingtemp] ORDER BY [sno]">
                                     </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
