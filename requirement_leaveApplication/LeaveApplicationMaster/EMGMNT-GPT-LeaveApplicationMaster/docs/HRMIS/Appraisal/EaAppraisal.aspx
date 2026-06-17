<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="EaAppraisal.aspx.vb" Inherits="E_Management.EaAppraisal" 
    title="EA Appraisal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<table cellpadding=0 cellspacing=0>
                    <tr>
                        <td style="width: 16px; height: 16px">
                            <IMG height="16" src="../../images/top_lef.gif" width="16"></td>
                        <td background="../../images/top_mid.gif" style="height: 16px; width: 650px;">
                            <IMG height="16" src="../../images/top_mid.gif"width="16"></td>
                        <td style="width: 25px; height: 16px;">
                            <IMG height="16" src="../../images/top_rig.gif" width="24"></td>
                    </tr>
                    <tr>
                        <td background="../../images/cen_lef.gif" style="width: 16px; height: 248px;">
                        <IMG height="11" src="../../images/cen_lef.gif" width="16"></td>
                        <td vAlign="top" bgColor="#ffffff" style="width: 650px">
                         <table>
                                <tr>
                                    <td align="center" class="td_head" colspan="3" style="height: 17px" valign="middle">
                                        Employee's Appraisal form (Staff Level)</td>
                                        <td align="right">
                                            </td>
                                </tr>
                                <tr>
                                    <td style="height: 17px; background-color: beige; width: 80px;">
                                        EmpCode</td>
                                    <td style="width: 196px; background-color: beige;">
                                        <asp:TextBox ID="txtempcode" runat="server" AutoPostBack="True" Width="81px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtempcode"
                                            ErrorMessage="!"></asp:RequiredFieldValidator></td>
                                    <td style="background-color: beige; ">
                                        EmpName</td>
                                    <td style="background-color: beige; width: 196px;">
                                        <asp:Label ID="lblename" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="background-color: beige; width: 80px; height: 21px;">
                                        Department</td>
                                    <td style="background-color: beige; width: 196px; height: 21px;">
                                        <asp:Label ID="lbldept" runat="server"></asp:Label></td>
                                    <td style="background-color: beige; height: 21px;">
                                        Section</td>
                                    <td style="background-color: beige; width: 196px; height: 21px;">
                                        <asp:Label ID="lblsect" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="background-color: beige; width: 120px; height: 21px;">
                                        Designation</td>
                                    <td style="background-color: beige; width: 196px; height: 21px;">
                                        <asp:Label ID="lbldesig" runat="server"></asp:Label></td>
                                    <td style="background-color: beige; width: 120px; height: 21px;">
                                        Employee Status
                                    </td>
                                    <td style="background-color: beige; width: 196px; height: 21px;">
                                        <asp:Label ID="lblstatus" runat="server"></asp:Label></td>
                                </tr>
                             <tr>
                                 <td style="width: 80px; height: 21px; background-color: beige">
                                     Reviewer/Supervisor</td>
                                 <td  style="height: 21px; background-color: beige">
                                        <asp:Label ID="lblempcode" runat="server"></asp:Label>-<asp:Label ID="lblempname"
                                         runat="server"></asp:Label></td>
                                         <td style="height: 21px; background-color: beige">
                                             Appraisal Date</td>
                                         <td style="height: 21px; background-color: beige">
                                            <asp:Label ID="Label1" runat="server" ForeColor="#C04000"></asp:Label></td>
                             </tr>
                             <tr>
                                 <td class="td_head" colspan="4" style="height: 21px">
                                     Employee History
                                     
                                     
                                     
                                     </td>
                                  
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: beige">
                                      
                                     <table style="width: 100%">
                                         
                                                              
                                  <tr>
                                 <td style=" background-color: beige; width: 177px;">
                                     Medical Leave &nbsp;:<asp:Label ID="lblmedical" runat="server"></asp:Label></td>
                                 <td style=" background-color: beige">
                                     Explanation &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp; :<asp:Label ID="lblexpl" runat="server"></asp:Label></td>
                                  <td style=" background-color: beige">
                                      Final Warning &nbsp; &nbsp;:<asp:Label ID="lblfinw" runat="server"></asp:Label></td>
                             </tr>
                             <tr>
                                 <td style="background-color: beige; width: 177px;">
                                     Absent &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;:<asp:Label ID="lblabs" runat="server"></asp:Label></td>
                                 <td style="background-color: beige">
                                     Verbal Warning &nbsp; &nbsp;&nbsp; &nbsp;:<asp:Label ID="lblvw" runat="server"></asp:Label></td>
                                 <td style="background-color: beige">
                                     Suspension &nbsp; &nbsp; &nbsp;&nbsp; :<asp:Label ID="lblsus" runat="server"></asp:Label></td>
                             </tr>
                             <tr>
                                 <td style="background-color: beige; width: 177px;">
                                     Late &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;:<asp:Label
                                         ID="lbllate" runat="server"></asp:Label></td>
                                 <td style=" background-color: beige">
                                     Written Warning &nbsp; &nbsp;&nbsp; :<asp:Label ID="lblww" runat="server"></asp:Label></td>
                                 <td style="background-color: beige">
                                     Showcase &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; :<asp:Label ID="lblsc" runat="server"></asp:Label></td>
                             </tr>
                             <tr>
                                 <td style="background-color: beige; width: 177px;">
                                     Misconduct Counselling:<asp:Label ID="lblcoun" runat="server"></asp:Label></td>
                                 <td style=" background-color: beige">
                                     First Warning &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; :<asp:Label ID="lblfw" runat="server"></asp:Label></td>
                                 <td style="background-color: beige">
                                     Misconduct Rpt :<asp:Label ID="lblrpt" runat="server"></asp:Label></td>
                             </tr>
                             <tr>
                                 <tr>
                                 <td class="td_head" colspan="4" style="height: 21px">
                                     Monthly Appraisal Data</td>
                              
                             </tr>
                                         <tr>
                                             <td colspan="4" style="height: 21px">
                                                 <table>
                                                     <tr>
                                                         <td style="vertical-align: middle; width: 100px; background-color: tan; text-align: center">
                                                             JAN</td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: tan; text-align: center">
                                                             FEB</td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: tan; text-align: center">
                                                             MAR</td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: tan; text-align: center">
                                                             APR</td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: tan; text-align: center">
                                                             MAY</td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: tan; text-align: center">
                                                             JUNE</td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: tan; text-align: center">
                                                             Avg</td>
                                                     </tr>
                                                     <tr>
                                                         <td style="vertical-align: middle; width: 100px; background-color: lightgoldenrodyellow;
                                                             text-align: center">
                                                             <asp:Label ID="lbl1" runat="server"></asp:Label>-<asp:Label ID="Label13" runat="server"></asp:Label></td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: lightgoldenrodyellow;
                                                             text-align: center">
                                                             <asp:Label ID="Label2" runat="server"></asp:Label>-<asp:Label ID="Label14" runat="server"></asp:Label></td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: lightgoldenrodyellow;
                                                             text-align: center">
                                                             <asp:Label ID="Label3" runat="server"></asp:Label>-<asp:Label ID="Label15" runat="server"></asp:Label></td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: lightgoldenrodyellow;
                                                             text-align: center">
                                                             <asp:Label ID="Label4" runat="server"></asp:Label>-<asp:Label ID="Label16" runat="server"></asp:Label></td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: lightgoldenrodyellow;
                                                             text-align: center">
                                                             <asp:Label ID="Label5" runat="server"></asp:Label>-<asp:Label ID="Label17" runat="server"></asp:Label></td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: lightgoldenrodyellow;
                                                             text-align: center">
                                                             <asp:Label ID="Label6" runat="server"></asp:Label>-<asp:Label ID="Label18" runat="server"></asp:Label></td>
                                                         <td rowspan="3" style="vertical-align: middle; width: 100px; background-color: lightgoldenrodyellow;
                                                             text-align: center">
                                                             <asp:Label ID="lblavg" runat="server" Text="Label"></asp:Label>
                                                             -<asp:Label ID="lblgrd" runat="server" Text="Label"></asp:Label></td>
                                                     </tr>
                                                     <tr>
                                                         <td style="vertical-align: middle; width: 100px; background-color: tan; text-align: center">
                                                             JULY</td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: tan; text-align: center">
                                                             AUG</td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: tan; text-align: center">
                                                             SEP</td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: tan; text-align: center">
                                                             OCT</td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: tan; text-align: center">
                                                             NOV
                                                         </td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: tan; text-align: center">
                                                             DEC</td>
                                                     </tr>
                                                     <tr>
                                                         <td style="vertical-align: middle; width: 100px; background-color: lightgoldenrodyellow;
                                                             text-align: center">
                                                             <asp:Label ID="Label7" runat="server"></asp:Label>-<asp:Label ID="Label19" runat="server"></asp:Label></td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: lightgoldenrodyellow;
                                                             text-align: center">
                                                             <asp:Label ID="Label8" runat="server"></asp:Label>-<asp:Label ID="Label20" runat="server"></asp:Label></td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: lightgoldenrodyellow;
                                                             text-align: center">
                                                             <asp:Label ID="Label9" runat="server"></asp:Label>-<asp:Label ID="Label21" runat="server"></asp:Label></td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: lightgoldenrodyellow;
                                                             text-align: center">
                                                             <asp:Label ID="Label10" runat="server"></asp:Label>-<asp:Label ID="Label22" runat="server"></asp:Label></td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: lightgoldenrodyellow;
                                                             text-align: center">
                                                             <asp:Label ID="Label11" runat="server"></asp:Label>-<asp:Label ID="Label23" runat="server"></asp:Label></td>
                                                         <td style="vertical-align: middle; width: 100px; background-color: lightgoldenrodyellow;
                                                             text-align: center">
                                                             <asp:Label ID="Label12" runat="server"></asp:Label>-<asp:Label ID="Label24" runat="server"></asp:Label></td>
                                                     </tr>
                                                 </table>
                                             </td>
                                         </tr>
                                     </table>
                                     
                        
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: beige">
                                     Purpose Of Appraisal</td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: beige">
                                     <asp:RadioButtonList ID="rdpurpose" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                                         <asp:ListItem Value="EP">End of Probation Period </asp:ListItem>
                                         <asp:ListItem Value="EC ">Extend Contract</asp:ListItem>
                                         <asp:ListItem Value="1/2 Yearly">1/2 Yearly Appraisal</asp:ListItem>
                                     </asp:RadioButtonList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="rdpurpose"
                                         ErrorMessage="Please Select appraisal Purpose"></asp:RequiredFieldValidator>
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: beige">
                                     <asp:Label ID="lblapp" runat="server" Text="Yearly appraisal :" Visible="False"></asp:Label>&nbsp;<asp:DropDownList ID="ddlhalf" runat="server" Visible="False">
                                         <asp:ListItem>1st Half</asp:ListItem>
                                         <asp:ListItem>2nd Half</asp:ListItem>
                                         <asp:ListItem Selected="True" Value="-">-Select-</asp:ListItem>
                                     </asp:DropDownList>
                                     <asp:Label ID="lblhalf" runat="server" Visible="False">-</asp:Label>
                                     </td>
                             </tr>
                             <tr>
                                 <td class="td_head" colspan="4" style="height: 21px">
                                     Performance Rating Indicator(PRI)</td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: beige">
                                     <div style="text-align: left">
                                         <table border="1" cellpadding="1" cellspacing="1" style="width: 100%">
                                             <caption>
                                             </caption>
                                             <tr style=" background-color :aquamarine">
                                                 <td >
                                                     A(100%~100%)</td>
                                                 <td style="width: 105px" >
                                                     Significantly exceed required standards (SES)
                                                 </td>
                                                 <td style="width: 269px" >
                                                     Regularly performs duties far better than expected in terms of quality, quantity
                                                     of work and within the specified period of time.
                                                 </td>
                                             </tr>
                                              <tr style=" background-color :aquamarine">
                                                 <td >
                                                     B(80%~99%)</td>
                                                 <td style="width: 105px" >
                                                     Exeeds the required standard (ERS)</td>
                                                 <td style="width: 269px" >
                                                     Regularly performs duties better than the required standards for such position in
                                                     terms of quality, quantity of work and achieves within the specified period of time.</td>
                                             </tr>
                                              <tr style=" background-color :aquamarine">
                                                 <td >
                                                     C(60%~79%)</td>
                                                 <td style="width: 105px" >
                                                     Meets required standards / target (MRS)</td>
                                                 <td style="width: 269px" >
                                                     Able to perform duties to meet the required standards regularly and sometimes above
                                                     the required standards in terms of quality, quantity of work and achieves within
                                                     the specified period of time</td>
                                             </tr>
                                             <tr style=" background-color :aquamarine">
                                                 <td>
                                                     D(40%~59%)</td>
                                                 <td style="width: 105px">
                                                     Partially meets the required standards (Monitoring)
                                                 </td>
                                                 <td style="width: 269px">
                                                     Perform duties in accordance with goals and and objectives occasionally but improvemenments
                                                     are required for quality, quantity of work and achieves within the specified period
                                                     of time in order to completer the work. Frequent supervision from a supervisor may
                                                     be required for the tasks. An employee who has just be placed in the position may
                                                     be at this level.
                                                 </td>
                                             </tr>
                                             <tr style=" background-color :aquamarine">
                                                 <td style="width: 50px; background-color: aquamarine">
                                                     E(39% &amp; Below)</td>
                                                 <td style="width: 105px; background-color: aquamarine">
                                                     Below standards (PIP)
                                                 </td>
                                                 <td style="width: 269px; background-color: aquamarine">
                                                     Unable to perform duties to meet the required standards and expectations within
                                                     the agreed time as assigned. An employee who is rated at this level shall be required
                                                     to participate in the process for work performance improvement.
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td style="width: 40px; height: 23px; background-color: aquamarine">
                                                     NP</td>
                                                 <td style="width: 105px; height: 23px; background-color: aquamarine">
                                                     Not Applicable (NP)
                                                 </td>
                                                 <td style="width: 269px; height: 23px; background-color: aquamarine">
                                                     Agreed that job goals set are no longer applicable due to unforeseen circumstances
                                                     and/or change of business direction/environment.
                                                 </td>
                                             </tr>
                                         </table>
                                     </div>
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: beige">
                                     <table style="border-right: navy 1px solid; border-top: navy 1px solid; border-left: navy 1px solid; width: 100%; border-bottom: navy 1px solid" border="1" cellpadding="1" cellspacing="1">
                                         <tr>
                                             <th >
                                                 Position</th>
                                             <th >
                                                 Section 1</th>
                                             <th >
                                                 Section 2</th>
                                         </tr>
                                         <tr>
                                             <td >
                                                 Exec. and above</td>
                                             <td >
                                                 80% Performance
                                             </td>
                                             <td >
                                                 20% Characteristics</td>
                                         </tr>
                                         <tr>
                                             <td >
                                                 Sup. and above
                                             </td>
                                             <td >
                                                 80% Performance
                                             </td>
                                             <td >
                                                 20% Characteristics</td>
                                         </tr>
                                         <tr>
                                             <td >
                                                 L.L. and above</td>
                                             <td >
                                                 80% Performance
                                             </td>
                                             <td >
                                                 20% Characteristics</td>
                                         </tr>
                                     </table>
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" class="td_head">
                                     <div align="center">
                                         <span class="style67">Section 1 : Review Job Goals Status ( Key Result Area) </span>
                                     </div>
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: beige">
                                     <div align="center">
                                         All Accomplishments(Action plan) must be supported with documentry evidence on a
                                         monthly basis
                                     </div>
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: beige">
                                     <asp:GridView ID="grdJg" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow"
                                         BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataSourceID="Sqljs" ForeColor="Black"
                                         GridLines="Vertical" ShowFooter="True" Visible="False" Width="100%">
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
                                                         Width="41px"></asp:TextBox>%
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
                                             <asp:TemplateField HeaderText="Refer (PRI) above and Grade">
                                                 <ItemTemplate>
                                                     <asp:RadioButtonList ID="rdprating" runat="server" AutoPostBack="True" OnSelectedIndexChanged="chkDynamic_CheckedChanged"
                                                         RepeatDirection="Horizontal">
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
                                         <FooterStyle BackColor="Tan" />
                                         <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                         <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                         <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                         <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                     </asp:GridView>
                                     &nbsp;<asp:Label ID="lbljskey" runat="server" Visible="False">0</asp:Label>
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" class="td_head">
                                     <div align="center">
                                         <span>Section 2 : Peformance Characteristics and behaviorable measurement </span>
                                     </div>
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: beige">
                                     <div align="center">
                                         These important core values and competencies that are required to excel in their
                                         respective area of job
                                     </div>
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="background-color: beige" align="left" valign="top">
                                     &nbsp;&nbsp;<br />
                                     <asp:GridView ID="GrdPerformance" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow"
                                         BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataSourceID="sqlperformance"
                                         ForeColor="Black" ShowFooter="True" Width="100%">
                                         <Columns>
                                             <asp:BoundField DataField="sno" HeaderText="sno" SortExpression="sno" />
                                             <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" Visible="False" />
                                             <asp:BoundField DataField="per" HeaderText="Behaviour" SortExpression="per">
                                                 <ItemStyle Width="200px" />
                                             </asp:BoundField>
                                             <asp:TemplateField HeaderText="Review">
                                                 <ItemTemplate>
                                                     Strength<br />
                                                     <asp:TextBox ID="txtstrength" runat="server" Rows="3" TextMode="MultiLine"></asp:TextBox><br />
                                                     Improvement<br />
                                                     <asp:TextBox ID="txtimpt" runat="server" Rows="3" TextMode="MultiLine"></asp:TextBox>
                                                 </ItemTemplate>
                                                 <FooterTemplate>
                                                     <asp:Label ID="Lblmanb" runat="server" Text="Total"></asp:Label>
                                                 </FooterTemplate>
                                             </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Weightage">
                                                 <ItemTemplate>
                                                     <asp:TextBox ID="txtbweit" runat="server" AutoPostBack="true" OnTextChanged="Calculatetotal2"
                                                         Width="41px"></asp:TextBox>%
                                                 </ItemTemplate>
                                                 <FooterTemplate>
                                                     <asp:Label ID="Lblbweit" runat="server" Text="0"></asp:Label>%
                                                 </FooterTemplate>
                                             </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Points">
                                                 <ItemTemplate>
                                                     <asp:Label ID="lblbpoints" runat="server" Text="0"></asp:Label>
                                                 </ItemTemplate>
                                                 <FooterTemplate>
                                                     <asp:Label ID="Lblbpts" runat="server" Text="0"></asp:Label>%
                                                 </FooterTemplate>
                                             </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Indicate Grade">
                                                 <ItemTemplate>
                                                     <asp:RadioButtonList ID="rdbutton" runat="server" AutoPostBack="True" OnSelectedIndexChanged="chkDynamic2_CheckedChanged">
                                                         <asp:ListItem Value="5">A</asp:ListItem>
                                                         <asp:ListItem Value="4">B</asp:ListItem>
                                                         <asp:ListItem Value="3">C</asp:ListItem>
                                                         <asp:ListItem Value="2">D</asp:ListItem>
                                                         <asp:ListItem Value="1">E</asp:ListItem>
                                                     </asp:RadioButtonList>
                                                 </ItemTemplate>
                                                 <FooterTemplate>
                                                     <asp:Label ID="Lblbmarks" runat="server" Text="0"></asp:Label>
                                                 </FooterTemplate>
                                             </asp:TemplateField>
                                         </Columns>
                                         <FooterStyle BackColor="Tan" />
                                         <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                         <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                         <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                         <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                     </asp:GridView>
                                     <br />
                                 </td>
                             </tr>
                             <tr>
                                 <td class="td_head" colspan="4">
                                     <div align="center">
                                         Section 3 : Result Overview(To be filled by Immediate Superior with the appraisee)
                                     </div>
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: Tan">
                                     Performance Initiatives/ Challenges :
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: beige">
                                     <table width = 100%>
                                         <tr>
                                             <td colspan="2">
                                                 (Identify up to three areas where strengths have been demonstrated over the past
                                                 year. Please include examples) Strengths can include behaviour/ attitude and competencies
                                                 or skill level - reference to be made to employee role description as currently
                                                 assessed.</td>
                                         </tr>
                                         <tr>
                                             <td style="width: 20px">
                                                 <strong>Comments : </strong>
                                             </td>
                                             <td style="width: 100px">
                                                 <asp:TextBox ID="txtperformance" runat="server" TextMode="MultiLine" Width="434px"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtperformance"
                                                     ErrorMessage="!" SetFocusOnError="True">!</asp:RequiredFieldValidator></td>
                                         </tr>
                                     </table>
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: tan">
                                     Target missing in Current Year :
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: beige">
                                     <table width = 100%>
                                         <tr>
                                             <td colspan="2">
                                                 (Identify key areas in which development would lead to improved performance. Please
                                                 include examples). Improvement can include behaviour / attitude and competencies
                                                 or skill level aspect - reference to be made to employee role description as currently
                                                 assessed.</td>
                                         </tr>
                                         <tr>
                                             <td style="width: 20px">
                                                 <strong>Comments : </strong>
                                             </td>
                                             <td style="width: 100px">
                                                 <asp:TextBox ID="txttarget" runat="server" TextMode="MultiLine" Width="434px"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txttarget"
                                                     ErrorMessage="!" SetFocusOnError="True">!</asp:RequiredFieldValidator></td>
                                         </tr>
                                     </table>
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: tan">
                                     Areas Needs Improvement (Development in Career / development Plan)
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: beige">
                                     <table width = 100%>
                                         <tr>
                                             <td style="width: 20px">
                                                 <strong>Comments : </strong>
                                             </td>
                                             <td style="width: 100px">
                                                 <asp:TextBox ID="txtarea" runat="server" TextMode="MultiLine" Width="434px"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtarea"
                                                     ErrorMessage="!" SetFocusOnError="True">!</asp:RequiredFieldValidator></td>
                                         </tr>
                                     </table>
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" class="td_head">
                                     <div align="center" class="whitetext">
                                         Over all Final Rating Summary (Section 1 &amp; 2 of the employee)
                                     </div>
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: beige">
                                     <table>
                                         <tr>
                                             <td style="width: 100px">
                                                 Final Points</td>
                                             <td style="width: 100px">
                                                 <asp:Label ID="lblfinpoints" runat="server" ForeColor="Maroon"></asp:Label></td>
                                             <td style="width: 100px">
                                                 Final Weightage</td>
                                             <td style="width: 100px">
                                                 <asp:Label ID="lblfinalweit" runat="server" ForeColor="Maroon" Text="100"></asp:Label></td>
                                             <td style="width: 100px">
                                                 Final Grade</td>
                                             <td style="width: 100px">
                                                 <asp:Label ID="lblfingrade" runat="server" ForeColor="Maroon"></asp:Label></td>
                                         </tr>
                                     </table>
                                 </td>
                             </tr>
                             <tr>
                                 <td char="td_head" colspan="4">
                                       <div align="center" class="whitetext">
                                       Recommendation / Remarks by Department Head </div>
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: beige">
                                     <asp:Label ID="La" runat="server" Font-Bold="True" Text="Recommended Grade By Department Head :"></asp:Label>
                                     <asp:Label ID="lbldhgrade" runat="server" ForeColor="Maroon"></asp:Label></td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: beige">
                                     <table style="width: 100%" border="1" cellpadding="1" cellspacing="1">
                                         <tr>
                                             <td style="width: 100px; height: 49px;">
                                                 Employement status</td>
                                             <td colspan="2" style="height: 49px">
                                                 <asp:RadioButtonList ID="rdconfirm" runat="server" RepeatDirection="Horizontal">
                                                     <asp:ListItem Value="C">Confirmation</asp:ListItem>
                                                     <asp:ListItem Value="E">Extend Probation (1 Mth)</asp:ListItem>
                                                     <asp:ListItem Value="EC">Extend contract</asp:ListItem>
                                                 </asp:RadioButtonList></td>
                                         </tr>
                                     </table>
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" style="height: 21px; background-color: tan" align="left">
                                     To be filled by EA</td>
                             </tr>
                             <tr>
                                 <td align="left" colspan="4" style="background-color: lavender">
                                     <table width = 100%>
                                         <tr>
                                             <td style="width: 20px">
                                                 <strong>Comments : </strong>
                                             </td>
                                             <td style="width: 100px">
                                                 <asp:TextBox ID="txtEA" runat="server" TextMode="MultiLine" Width="434px"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEA"
                                                     ErrorMessage="!" SetFocusOnError="True">!</asp:RequiredFieldValidator></td>
                                         </tr>
                                         <tr>
                                             <td style="width: 20px">
                                                 Grade By EA</td>
                                             <td style="width: 100px">
                                                 <asp:RadioButtonList ID="rdEarating" runat="server" RepeatDirection="Horizontal">
                                                     <asp:ListItem>A</asp:ListItem>
                                                     <asp:ListItem>B</asp:ListItem>
                                                     <asp:ListItem>C</asp:ListItem>
                                                     <asp:ListItem>D</asp:ListItem>
                                                     <asp:ListItem>E</asp:ListItem>
                                                 </asp:RadioButtonList></td>
                                         </tr>
                                         <tr>
                                             <td style="width: 20px">
                                                 Points By EA</td>
                                             <td style="width: 100px">
                                                 <asp:TextBox ID="eapoints" runat="server" Width="45px"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="eapoints"
                                                     ErrorMessage="!" SetFocusOnError="True">!</asp:RequiredFieldValidator></td>
                                         </tr>
                                     </table>
                                 </td>
                             </tr>
                             <tr>
                                 <td align="center" colspan="4" style="height: 21px; background-color: ivory">
                                     <asp:Label ID="Lab3" runat="server"  Text="FOR OFFICE USE ONLY"
                                         Width="152px" Font-Underline="True"></asp:Label></td>
                             </tr>
                             <tr>
                                 <td align="left" colspan="4" style="height: 21px; background-color: ivory">
                                     <table border="1" cellpadding="1" cellspacing="1" width="100%">
                                         <tr>
                                             <td style="width: 100px">
                                                 <asp:Label ID="Labl4" runat="server"  Text="PROMOTED TO"
                                                     Width="106px"></asp:Label></td>
                                             <td style="width: 100px">
                                                 <asp:DropDownList ID="DDLDESIG" runat="server" DataSourceID="SqlDataSource1"
                                                     DataTextField="designationname" DataValueField="designationname">
                                                     <asp:ListItem Selected="True" Value="-1">--select--</asp:ListItem>
                                                 </asp:DropDownList>
                                             </td>
                                         </tr>
                                         <tr>
                                             <td style="width: 100px; height: 34px">
                                                 <asp:Label ID="Labela" runat="server" Text="REMARKS"
                                                     Width="75px"></asp:Label></td>
                                             <td style="width: 100px; height: 34px">
                                                 <asp:TextBox ID="offremarks" runat="server" TextMode="MultiLine" Width="434px" Height="41px"></asp:TextBox></td>
                                         </tr>
                                     </table>
                                 </td>
                             </tr>
                             <tr>
                                 <td align="right" colspan="4" style="height: 21px; background-color: beige">
                                     &nbsp;<asp:Button ID="txtbutton" runat="server" Text="SAVE" /></td>
                             </tr>
                                </table>
                                  <asp:SqlDataSource ID="Sqljs" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                         SelectCommand="SELECT DISTINCT top 5 [man_keyresult], [sno] FROM [man_keygoal] WHERE (([empcode] = @empcode) AND ([recordno] = @recordno)) ORDER BY [sno]">
                                         <SelectParameters>
                                             <asp:ControlParameter ControlID="txtempcode" Name="empcode" PropertyName="Text" Type="String" DefaultValue=""  />
                                             <asp:ControlParameter ControlID="lbljskey" Name="recordno" PropertyName="Text" Type="Int32"  />
                                         </SelectParameters>
                                     </asp:SqlDataSource>
                                     <asp:SqlDataSource ID="sqlperformance" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                         SelectCommand="SELECT [sno], [per] FROM [app_charsettingtemp] ORDER BY [sno]">
                                     </asp:SqlDataSource>
                                     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                                         SelectCommand="SELECT [designationname] FROM [designation] ORDER BY [designationname]">
                                     </asp:SqlDataSource>
                                  </td>
                    <td background="../../images/cen_rig.gif" style="width: 25px; height: 248px;">
                        <IMG height="11" src="../../images/cen_rig.gif" width="24"></td>
                </tr>
                <tr>
                    <td width="16" height="16">
                        <IMG height="16" src="../../images/bot_lef.gif" width="16"></td>
                    <td background="../../images/bot_mid.gif" height="16" style="width: 650px">
                        <IMG height="16" src="../../images/bot_mid.gif" width="16"></td>
                    <td height="16" style="width: 25px">
                        <IMG height="16" src="../../images/bot_rig.gif" width="24"></td>
                </tr>
            </table>
</asp:Content>
