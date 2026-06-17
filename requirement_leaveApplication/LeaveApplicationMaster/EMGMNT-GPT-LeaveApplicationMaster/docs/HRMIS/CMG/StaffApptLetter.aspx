<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="StaffApptLetter.aspx.vb" Inherits="E_Management.StaffApptLetter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Appointment Letter For Staff</title>
</head>
<body style="font-family: Times New Roman">
    <form id="form1" runat="server">
     <table width="612" border="0" cellspacing="0">
           <tr>
             <td class="style2"><div align="center"></div></td>
           </tr>
           <tr class="style2">
             <td><table width="610" border="0" cellspacing="0">
                 <tr>
                   <td width="44">&nbsp;</td>
                   <td width="379"><img src="../../images/maruwaAnimLogo.gif" width="161" height="42" border="0"></td>
                   <%--<% 
         
		  dd=day(date)
          if len(dd)=1 then
              dd="0"&dd
          end if
          mm=month(date)
          if len(mm)=1 then
                 mm="0"& mm
         end if
          yyyy=year(date)
		  newdate = dd & "/" & mm & "/" & yyyy
          %>--%>
                   <td width="63">Ref. No.:</td>
                   <td style="width: 88px"><%--<%=refno%>--%>
                       <asp:Label ID="refno" runat="server"></asp:Label></td>
                 </tr>
             </table></td>
           </tr>
           <tr class="style2">
             <td><table width="609" border="0" cellspacing="0">
                 <tr>
                   <td style="height: 21px">&nbsp;</td>
                   <td width="2" style="height: 21px">&nbsp;</td>
                   <td width="428" style="height: 21px">&nbsp;</td>
                   <td style="height: 21px">&nbsp;</td>
                 </tr>
                 <tr>
                   <td>&nbsp;</td>
                   <td>&nbsp;</td>
                   <td>&nbsp;</td>
                   <td>&nbsp;</td>
                 </tr>
                 <tr>
                   <td width="40">&nbsp;</td>
                   <td colspan="2"><span class="style6">Name &nbsp;: 
                       <asp:Label ID="empname1" runat="server"></asp:Label><%--<%=name%>--%></span></td>
                   <td width="160"><span class="style6"> </span></td>
                 </tr>
                 <tr>
                   <td>&nbsp;</td>
                   <td colspan="2">Age &nbsp; &nbsp; : 
                       <asp:Label ID="age" runat="server"></asp:Label><%--<%=age%>--%></td>
                   <td>&nbsp;</td>
                 </tr>
                 <tr>
                   <td style="height: 21px">&nbsp;</td>
                   <td colspan="2" style="height: 21px">IC No.: 
                       <asp:Label ID="icno" runat="server"></asp:Label><%--<%=nric%>--%></td>
                   <td style="height: 21px">&nbsp;</td>
                 </tr>
                 <tr>
                   <td style="height: 21px">&nbsp;</td>
                   <td colspan="2" style="height: 21px"><span class="style6">Date &nbsp;&nbsp; :
                       <asp:Label ID="ldate" runat="server"></asp:Label><%--<%=newdate%>--%></span></td>
                   <td style="height: 21px">&nbsp;</td>
                 </tr>
                 <tr>
                   <td>&nbsp;</td>
                   <td colspan="3"><table width="632" border="0" cellspacing="0">
                     <tr>
                       <td height="37" colspan="9">&nbsp;</td>
                     </tr>
                     <tr>
                       <td height="37" colspan="9">&nbsp;</td>
                     </tr>
                     <tr>
                       <td colspan="9"><div align="center"><strong>
                         <u>Ref : LETTER OF APPOINTMENT</u>
                       </strong></div></td>
                     </tr>
                     <tr>
                       <td height="36" colspan="9">&nbsp;</td>
                     </tr>
                     <tr>
                       <td colspan="9" style="height: 40px"><p align="justify">We are pleased to offer you the position as an 
                           <asp:Label ID="desig" runat="server"></asp:Label><span class="style6"><%--<%=desig%>--%></span>, of&nbsp;
                           <asp:Label ID="deptname" runat="server"></asp:Label>
                           <span class="style6"><%--<%=newname%>--%> </span><span class="style7">Dept for a Probation Period of&nbsp;
    <asp:Label ID="prob" runat="server"></asp:Label><%--<%=entitle%>--%>
                               Month(s) from
                               <asp:Label ID="doj" runat="server"></asp:Label>
                               <%--<%=dateofjoin%>--%></span>  under the following terms and conditions of employment.  </p></td>
                     </tr>
                     <tr>
                       <td height="29" colspan="9"><p>&nbsp; </p></td>
                     </tr>
                     <tr>
                       <td colspan="9"><div align="left">1)  The Probation period may be extended at the discretion of the company based on your performance and subject to that the extension shall not exceed 3 months. </div></td>
                     </tr>
                     <tr>
                       <td height="23" colspan="9"><p>&nbsp; </p></td>
                     </tr>
                 <!--    <tr>
                       <td height="47" colspan="9">2) Upon the successful completion of the  trial period the Company may renew the contract for 
                           <asp:Label ID="extprob" runat="server"></asp:Label><%--<%=contract%>--%>
                           Month(s).</td>
                     </tr> -->
                     <tr>
                       <td style="width: 334px; height: 21px;">2) Salary :</td>
                         <td style="width: 26px; height: 21px">
                         </td>
                       <td style="width: 67px; height: 21px">&nbsp;</td>
                         <td style="height: 21px">
                         </td>
                       <td style="width: 186px; height: 21px;">&nbsp;</td>
                         <td style="width: 347px; height: 21px">
                         </td>
                       <td style="width: 47px; height: 21px;">&nbsp;</td>
                       <td style="height: 21px" >&nbsp;</td>
                       <td style="height: 21px">&nbsp;</td>
                     </tr>
                     <tr>
                       <td style="width: 334px">&nbsp;</td>
                         <td style="width: 26px">
                         </td>
                       <td style="width: 67px"><div align="left"></div></td>
                         <td>
                         </td>
                       <td style="width: 186px">&nbsp;</td>
                         <td style="width: 347px">
                         </td>
                       <td style="width: 47px"><div align="right"></div>
                       </td>
                       <%--<% a = trim(request.form("basic"))%>--%>
                       <td width="18" ><div align="right"></div></td>
                       <td width="153"><div align="right"></div></td>
                     </tr>
                     <tr>
                       <td style="width: 334px; height: 21px; text-align: right;" align="center">
                           &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                           &nbsp; &nbsp;&nbsp; Basic Salary &nbsp;</td>
                         <td style="width: 26px; height: 21px">
                             :</td>
                       <td style="width: 67px; height: 21px">
                           RM</td>
                         <td style="height: 21px">
                             </td>
                         <td style="width: 186px; height: 21px">
                             <asp:Label ID="bsa" runat="server"></asp:Label></td>
                         <td style="width: 87px; height: 21px;">
                         </td>
                         <td style="width: 347px; height: 21px">
                         </td>
                       <td style="width: 47px; height: 21px;"><div align="right">
                           &nbsp;</div></td>
                       <td style="height: 21px"><div align="right"><%--<%=a%>--%></div></td>
                       <td style="height: 21px"></td>
                     </tr>
					 <%--<%
					 if request.form("position")<>"0" and request.form("position")<>"" then %>--%>
                     <tr>
                       <td style="width: 334px; height: 21px; text-align: right;" align="center">
                           &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Position Allowance &nbsp;</td>
                         <td style="width: 26px; height: 21px">
                             :</td>
                       <td style="width: 67px; height: 21px"><p> RM</p></td>
                         <td style="height: 21px">
                             </td>
                         <td style="width: 186px; height: 21px;"><asp:Label ID="pall" runat="server"></asp:Label></td>
                         <td style="width: 347px; height: 21px">
                         </td>
                       <td style="width: 47px; height: 21px;"><div align="right">
                           &nbsp;</div></td>
                       <td style="height: 21px"><div align="right"><%--<%=request.form("position")%>--%></div></td>
                       <td style="height: 21px"></td>
                     </tr>
					 <%--<%end if%>
					 <%if request.form("alltype1") <> "E" then %>--%>
                     <tr>
                       <td style="height: 23px; width: 334px; text-align: right;" valign="middle">&nbsp;<asp:Label ID="allow1" runat="server"></asp:Label></td>
                       <td style="height: 23px; width: 26px;" valign="middle">
                           <asp:Label ID="a1colon" runat="server" Width="1px"></asp:Label></td>
					   <td style="height: 23px; width: 67px;" valign="middle"><%--<%=request.form("alltype1") %> --%>
                           <%--<%end if%>
					 <%if request.form("alltype1") <> "E" then %>--%&gt; <TR 
              __designer:dtid="3940739868262513"><TD 
                style="WIDTH: 292px; HEIGHT: 21px; TEXT-ALIGN: right" 
                align=center __designer:dtid="3940739868262516"><%--<%=request.form("alltype1") %> --%>
                           <asp:Label ID="curr" runat="server"></asp:Label></td>
                       &nbsp;
                     <td style="height: 23px" valign="middle">
                         </td>
                     <td style="width: 186px; height: 23px" valign="middle">
                           <asp:Label ID="all1" runat="server"></asp:Label></td>
                     <td style="width: 87px; height: 23px">
                         </td>
                     <td style="width: 53px; height: 23px">
                           </td>
                     <td style="width: 347px; height: 23px">
                     </td>
                       <td style="width: 47px; height: 23px"><div align="right">
                           &nbsp;</div></td>
                       <td style="height: 23px"><div align="right"><%--<%= request.form("attn")%>--%></div></td>
                       <td style="height: 23px">
                           </td>
					 <%--<%end if%>--%>
					 <%--<%if request.form("alltype1") <>"E"  then%>
					 <%end if%>
					 <%if request.form("alltype2") <> "E" then%>--%>
                     <tr>
                       <td style="height: 21px; width: 334px; text-align: right;" align="center" valign="middle"><%--<%=request.form("alltype2")%> --%>
                           &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                           <asp:Label ID="allow2" runat="server"></asp:Label></td>
                         <td style="width: 26px; height: 21px" valign="middle">
                             <asp:Label ID="a2colon" runat="server"></asp:Label></td>
                       <td style="height: 21px; width: 67px;" valign="middle"><p>
                           <asp:Label ID="curr1" runat="server"></asp:Label>&nbsp;</p></td>
                         <td style="height: 21px" valign="middle">
                             </td>
                         <td style="height: 21px; width: 186px;" valign="middle">
                           <asp:Label ID="all2" runat="server"></asp:Label></td>
                         <td style="width: 347px; height: 21px">
                         </td>
                       <td style="height: 21px; width: 47px;"><div align="right">
                           &nbsp;</div></td>
                       <td style="height: 21px"><div align="right"><%--<%= request.form("food")%>--%></div></td>
                       <td style="height: 21px">
                           </td>
                     </tr>
					 <%--<%end if%>--%>
                     <tr>
                       <td style="height: 2px; width: 334px;" valign="bottom">&nbsp;</td>
                         <td style="width: 26px; height: 2px" valign="bottom">
                         </td>
                       <td style="height: 2px; width: 67px;" valign="bottom">&nbsp;</td>
                         <td style="height: 2px" valign="bottom">
                         </td>
                       <td style="height: 2px; width: 186px;" valign="bottom">
                           <span style="text-decoration: underline">_______</span></td>
                         <td style="width: 347px; height: 2px" valign="bottom">
                             &nbsp; &nbsp;</td>
                       <td style="height: 2px; width: 47px;" valign="bottom">&nbsp;</td>
                       <td colspan="2" style="height: 2px" valign="bottom"></td>
                     </tr>
                         <tr>
                             <td style="width: 334px; height: 2px">
                             </td>
                             <td style="width: 26px; height: 2px" valign="top">
                             </td>
                             <td style="width: 67px; height: 2px" valign="middle">
                                 RM</td>
                             <td style="height: 2px" valign="middle">
                             </td>
                             <td style="width: 186px; height: 2px" valign="middle">
                                 <asp:Label ID="tot" runat="server"></asp:Label></td>
                             <td style="width: 347px; height: 2px" valign="middle">
                             </td>
                             <td style="width: 47px; height: 2px">
                             </td>
                             <td style="height: 2px">
                             </td>
                             <td style="height: 2px">
                             </td>
                         </tr>
                     <tr><td style="height: 2px; width: 334px;" valign="bottom">
                         &nbsp;</td>
                         <td style="width: 26px; height: 2px" valign="bottom">
                         </td>
                         <td style="height: 2px; width: 67px;" valign="bottom">
                             &nbsp;</td>
                         <td style="height: 2px" valign="bottom">
                         </td>
                         <td style="height: 2px; width: 186px;" valign="bottom">
                             <span style="text-decoration: underline; font-size: 8pt;">__________</span></td>
                         <td style="width: 347px; height: 2px; font-size: 12pt;" valign="bottom">
                             &nbsp; &nbsp;</td>
                         <td style="height: 2px; width: 47px; font-size: 12pt;" valign="bottom">
                             &nbsp;</td>
                         <td colspan="2" style="height: 2px; font-size: 12pt;" valign="bottom">
                         </td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td colspan="9"><p> 3) Working Hours :</p></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td height="24" colspan="9"><p> Shall be briefed to you on your first day of work and not more than 48 hours per week. </p></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td colspan="9">&nbsp;</td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td height="37" colspan="9"><div align="justify">4) You are required to report to our General Manager on your first day of work or any other person designated by him. </div></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td colspan="9">&nbsp;</td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td height="40" colspan="9"><div align="justify">5) Department Head or any person designated by him shall brief his or her Job Specification(JS) outlining the roles and responsibilities of the job. </div></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td colspan="9"><div align="justify">&nbsp;</div></td>
                     </tr>
                    <tr style="font-size: 12pt">
                       <td height="149" colspan="9"><p align="justify">6) Status and Commencement Of Employment Upon successful completion of your probation period, you will be assessed on your performance of your job tasks. Your superior may recommend you for confirmation of employment under the following criteria
                           : - </p>
                           <p align="justify">You must achieve &gt; 
                               <asp:Label ID="targ" runat="server"></asp:Label>
                              <%-- <%=request.form("target")%>--%>  rating (above target) as per the performance appraisal. </p>
                          <!-- <p align="justify">b) From contract to permanent status, recommendation from Head Of Department and approval of the senior management must be obtained. </p> --></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td height="16" colspan="9"><div align="justify">&nbsp;</div></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td colspan="9"><p align="justify">7) As per the Minimum Retirement age act 2012, the minimum retirement age was 60 years. You have to end your Contract of Employment at age of 60 years. Any employment after age of 60, the employment will be under yearly contract basis.</p>
                          </td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td height="16" colspan="9"><div align="justify">&nbsp;</div></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td colspan="9"><p align="justify">8) Resignation and termination period</p>
                           <p align="justify"> Either party, may at any time give to the other party written notice of intention to terminate the contract of service. The notice by either party will be 2 weeks during the probation period and will be 1 month notice if confirmed employee. </p></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td height="16" colspan="9"><div align="justify">&nbsp;</div></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td height="47" colspan="9"><div align="justify">9) The Company&rsquo;s rules and regulations are strictly to be adhered to and any breaches would render the employees to disciplinary action that may result in dismissal. </div></td> 
                     </tr>
                     <tr style="font-size: 12pt">
                       <td height="57" colspan="9"><div align="justify">10) The company reserves the right to transfer an employee from one department to another within the company, or subsidiary or associated within the group. </div></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td height="16" colspan="9"><div align="justify">&nbsp;</div></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td height="70" colspan="9"><div align="justify">11) You shall not at anytime during the term of your employment or thereafter reveal or disclose the affairs in relations to our business, any correspondences or activities of the company to any person, companies, firms and corporation on any matters whatsoever without prior written approval from the Company. </div></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td height="16" colspan="9"><div align="justify">&nbsp;</div></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td colspan="9" style="height: 65px"><div align="justify">12) Any employee who is in the employment with the Company whom has been convicted for any offense both criminal and civil are required to inform the Management of such offenses at the earliest possible date. Failure to comply may result in termination of employment. </div></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td height="16" colspan="9"><div align="justify">&nbsp;</div></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td height="41" colspan="9"><div align="justify">13) Employees who have left the Company can be called upon to assist the Company on any matters involving the employer. </div></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td height="16" colspan="9"><div align="justify">&nbsp;</div></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td height="27" colspan="9"><div align="justify">14) Public Holiday </div></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td height="48" colspan="9"><div align="justify">You shall be entitled to all the Company Public Holidays. A Company Calendar will be given to you on your first day of work.</div></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td height="29" colspan="9"><div align="justify">15) EPF Contribution </div></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td height="34" colspan="9"><div align="justify">
                           <span style="color: black; mso-fareast-font-family: 'Times New Roman'; mso-bidi-font-family: 'Times New Roman';
                               mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                               Employees are entitiled for EPF contribution as per instructed by government.It
                               is subject to change from time to time based on EPF Act (1991)&nbsp;</span></div></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td height="27" colspan="9"><p align="justify">16) SOCSO &amp; Insurance </p>
                       </td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td colspan="9"><div align="justify">
                         <p align="justify">For accident benefits, you shall be covered by the SOCSO scheme. A contribution to this scheme will be made through salary deductions. </p>
                         <p align="justify"> A Group Personal Accident is applicable to all employees where the contribution for this will be borne by the Company. </p>
                         <p align="justify"> However after age 65 years, the employees are not entitled for any insurance claim from the company on any medical treatment or accident involved. </p>
                       </div></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td height="72" colspan="9"><div align="justify">
                           17) EIS –Employee Insurance System
                           <br />
                           All the Employees excluded foreign workers and expatriates are covered under EIS
                           regulation 2017.
                       </div>
                           </td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td height="72" colspan="9"><div align="justify">
                           18)Clinic</div>
                           <p align="justify"> You are entitled for free medical treatment at In House Clinic and Panel Clinic appointed by company with yearly budgeted amount that will be decided by company. </p></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td height="17" colspan="9"><div align="justify">&nbsp;</div></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td height="37" colspan="9"><div align="justify">19) Annual Leave - you shall be entitled after the successful completion of the  trial period  of services with our company. </div>
                       </td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td colspan="9">Sick Leave &ndash; you shall be entitled as stipulated in Employment Act 1955. </td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td height="201" colspan="9"><div align="justify">20) Bonus / Increment </div>
                           <p align="justify"> You may be entitled for company&rsquo;s bonus and increment after the successful completion of the  trial period </p>
                           <ul>
                             <ul>
                               <blockquote>
                                 <p align="justify">a) Operators level – 3 months </p>
                                   <p>
                                       b) Line Leaders till Technicians level – 3 months
                                   </p>
                                 <p align="justify"> c) Supervisors till Engineers level &ndash; 4 months </p>
                                 <p align="justify">
                                     d) Executive level and above &ndash; 6 months </p>
                               </blockquote>
                             </ul>
                         </ul></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td height="53" colspan="9"><div align="justify">Payment of bonus/increment will solely depends on the overall good performance of the Company and its capacity to pay. Final decision to pay bonus/increment lies with the management. </div></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td colspan="9"><div align="justify">&nbsp;</div></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td colspan="9"><div align="justify">21) All other terms and benefits shall be as stipulated in the Employment Act &amp; Regulation 1955.</div></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td height="19" colspan="9"><div align="justify">&nbsp;</div></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td colspan="9"><p align="justify">
                           22) If you agree to the above terms and conditions of employment, kindly indicate your acceptance by signing and returning the duplicate copy of this letter. </p>
                           <p align="justify"> We look forward to your contribution to the Company. </p></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td colspan="9"><div align="justify">&nbsp;</div></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td colspan="9"><p align="justify"> Thank you. </p></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td colspan="9"><div align="justify">&nbsp;</div></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td colspan="9" style="height: 59px"><p align="justify"> Yours faithfully, </p>
                           <p align="justify">MARUWA MALAYSIA SDN BHD </p></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td colspan="9"><div align="justify">&nbsp;</div></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td colspan="9"><div align="justify">&nbsp;</div></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td colspan="9"><div align="justify">&nbsp;</div></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td height="113" style="width: 334px"><p align="justify">_______________________________</p>
                           <p align="justify"><strong> DATUK MANIMARAN ANTHONY </strong></p>
                           <p align="justify"> CHIEF EXECUTIVE OFFICER </p></td>
                         <td height="113" style="width: 26px">
                         </td>
                       <td height="113" style="width: 67px">&nbsp;</td>
                         <td height="113">
                         </td>
                       <td height="113" style="width: 186px"><div align="right" style="position: static"><img src="../../images/stamp.jpg" width="78" height="84"></div></td>
                         <td height="113" style="width: 347px">
                         </td>
                       <td height="113" style="width: 47px">&nbsp;</td>
                       <td height="113">&nbsp;</td>
                       <td height="113">&nbsp;</td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td height="30" colspan="9"><div align="justify">____________________________________________________________________________</div></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td colspan="9"><div align="justify">&nbsp;</div></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td colspan="9"><p align="justify"> I hereby accept the offer and confirm that I fully understand the terms and conditions of employment. </p></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td height="61" colspan="9"><div align="justify">&nbsp;</div></td>
                     </tr>
                     <!--<tr style="font-size: 12pt">
                       <td colspan="9"><div align="justify">&nbsp;</div></td>
                     </tr> -->
                     <tr style="font-size: 12pt">
                       <td colspan="9"><p align="justify"> Signature : _______________________________ </p></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td height="23" colspan="9"><div align="justify">&nbsp;</div></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td colspan="9" style="height: 21px"><p align="justify"> Name &nbsp; &nbsp; &nbsp; : 
                           <asp:Label ID="empname" runat="server"></asp:Label><%--<%=name%>--%></p></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td height="22" colspan="9"><div align="justify">&nbsp;</div></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td colspan="9"><p align="justify"> NRIC No :<strong> 
                           <asp:Label ID="nric" runat="server" Font-Bold="False"></asp:Label><%--<%=nric%>--%></strong></p></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td height="24" colspan="9"><div align="justify">&nbsp;</div></td>
                     </tr>
                     <tr style="font-size: 12pt">
                       <td colspan="9"><p align="justify"> Date : ______________________________ </p></td>
                     </tr>
                   </table>
                   </td>
                     </tr>
                 </tr>
             
           <tr class="style2" style="font-size: 12pt">
             <td>&nbsp;</td>
           </tr>
           <tr class="style2" style="font-size: 12pt">
             <td>&nbsp;</td>
           </tr>
    </form>
</body>
</html>

