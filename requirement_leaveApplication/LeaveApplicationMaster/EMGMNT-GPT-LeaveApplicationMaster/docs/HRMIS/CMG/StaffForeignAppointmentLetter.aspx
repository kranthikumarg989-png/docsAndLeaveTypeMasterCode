<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="StaffForeignAppointmentLetter.aspx.vb" Inherits="E_Management.StaffForeignAppointmentLetter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Appointment Letter For Foreign Staff</title>
</head>
<body>
    <form id="form1" runat="server">
    <table width="612" border="0" cellspacing="0">
           <tr>
             <td class="style2"><div align="center"></div></td>
           </tr>
           <tr class="style2">
             <td><table width="610" border="0" cellspacing="0">
                 <tr>
                   <td width="44">&nbsp;</td>
                   <td width="215"><a href="emp_main.asp"><img src="../../images/maruwaAnimLogo.gif" width="161" height="42" border="0"></a></td>
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
                   <td width="222"><div align="right">Ref. No.:</div></td>
                   <td width="101"><%--<%=refno%>--%>
                       <asp:Label ID="refno" runat="server"></asp:Label></td>
                 </tr>
             </table></td>
           </tr>
           <tr class="style2">
             <td><table width="609" border="0" cellspacing="0">
                 <tr>
                   <td>&nbsp;</td>
                   <td width="116">&nbsp;</td>
                   <td width="324">&nbsp;</td>
                   <td>&nbsp;</td>
                 </tr>
                 <tr>
                   <td>&nbsp;</td>
                   <td>&nbsp;</td>
                   <td>&nbsp;</td>
                   <td>&nbsp;</td>
                 </tr>
                 <tr>
                   <td width="43">&nbsp;</td>
                   <td colspan="2"><span class="style6">Name : 
                       <asp:Label ID="empname1" runat="server"></asp:Label><%--<%=name%>--%></span></td>
                   <td width="98"><span class="style6"> </span></td>
                 </tr>
                 <tr>
                   <td>&nbsp;</td>
                   <td colspan="2"><strong>Age :  
                       <asp:Label ID="age" runat="server" Font-Bold="False"></asp:Label><%--<%=age%>--%></strong></td>
                   <td>&nbsp;</td>
                 </tr>
                 <tr>
                   <td>&nbsp;</td>
                   <td colspan="2"><span class="style6">Date: 
                       <asp:Label ID="ldate" runat="server" Font-Bold="False"></asp:Label><%--<%=newdate%>--%></span></td>
                   <td>&nbsp;</td>
                 </tr>
                 <tr>
                   <td colspan="3">&nbsp; </td>
                   <td>&nbsp;</td>
                 </tr>
             </table></td>
           </tr>
           <tr class="style2">
             <td><table width="609" border="0" cellspacing="0">
                 <tr>
                   <td colspan="5">&nbsp;</td>
                 </tr>
                 <tr>
                   <td colspan="5"><div align="center"><strong>
                     <u>Ref : LETTER OF APPOINTMENT</u>
                   </strong></div></td>
                 </tr>
                 <tr>
                   <td colspan="5">&nbsp;</td>
                 </tr>
                 <tr>
                   <td colspan="5"><p align="justify">We are pleased to offer you the position as 
                       <asp:Label ID="desig" runat="server"></asp:Label><span class="style6"><%--<%=desig%>--%></span>, 
                       <asp:Label ID="deptname" runat="server"></asp:Label>
                       Dept<span class="style6"> <%--<%=newname%>--%></span>.<strong></strong>on a 
                       <asp:Label ID="prob" runat="server"></asp:Label>
                       <%--<%=contract%>--%> Month(s) contract basis on the following terms and conditions of employment. </p></td>
                 </tr>
                 <tr>
                   <td colspan="5"><p>&nbsp; </p></td>
                 </tr>
                 <tr>
                   <td colspan="5"><div align="left">1) Date of Commencement : 
                       <asp:Label ID="doc" runat="server"></asp:Label><%--<%=dateofjoin%>--%></div></td>
                 </tr>
                 <tr>
                   <td colspan="5" style="height: 21px"><p>&nbsp; </p></td>
                 </tr>
                 <tr>
                   <td width="157"><div align="left">2) Salary : </div></td>
                   <td width="129">&nbsp;</td>
                   <td width="22" align="right">&nbsp;</td>
                   <td width="91">&nbsp;</td>
                   <td width="200">&nbsp;</td>
                 </tr>
                 <tr>
                   <td>&nbsp;</td>
                   <td>Basic Salary :
                   </td>
                   <td><div align="right" style="text-align: right">RM.</div></td>
                   <td><div align="right" style="text-align: left">
                       <asp:Label ID="bsa" runat="server"></asp:Label><%--<%=request.form("basic1")%>--%></div></td>
                   <td>&nbsp;</td>
                 </tr>
                 <tr>
                   <td><p>&nbsp; </p></td>
                   <td>
                       <asp:Label ID="allow" runat="server"></asp:Label></td>
                   <td><div align="right" style="text-align: right">
                       <asp:Label ID="curr" runat="server"></asp:Label>&nbsp;</div></td>
                   <td><div align="right" style="text-align: left">
                       <asp:Label ID="pall" runat="server"></asp:Label><%--<%=request.form("position1")%>--%></div></td>
                   <td>&nbsp;</td>
                 </tr>
                 <tr>
                   <td>&nbsp;</td>
                   <td>&nbsp;</td>
                   <td colspan="2"><div align="right"><hr></hr></div></td>
                   <td>&nbsp;</td>
                 </tr>
                 <tr>
                   <td><p>&nbsp; </p></td>
                   <td>&nbsp;</td>
                   <td><div align="right">RM.</div></td>
                   <td><div align="right" style="text-align: left">
                       <asp:Label ID="tot" runat="server"></asp:Label><%--<%=request.form("total1")%>--%></div></td>
                   <td>&nbsp;</td>
                 </tr>
                 <tr>
                   <td><p>&nbsp; </p></td>
                   <td>&nbsp;</td>
                   <td colspan="2"><div align="right">
                     <hr>
                   </div></td>
                   <td>&nbsp;</td>
                 </tr>
                 <tr>
                   <td colspan="5">&nbsp;</td>
                 </tr>
                 <tr>
                   <td colspan="5"><p> 3) Working Hours </p></td>
                 </tr>
                 <tr>
                   <td colspan="5"><p align="justify"> Shall be briefed to you on your first day of work and not more than 48 hours per week. </p></td>
                 </tr>
                 <tr>
                   <td colspan="5"><div align="justify">&nbsp;</div></td>
                 </tr>
                 <tr>
                   <td colspan="5"><div align="justify">4) You are required to report to our Managing Director on your first day of work or any other person designated by him. </div></td>
                 </tr>
                 <tr>
                   <td colspan="5"><div align="justify">&nbsp;</div></td>
                 </tr>
                 <tr>
                   <td colspan="5"><div align="justify">5) Department Head or any person designated by him shall brief his or her Job Specification(JS) outlining the roles and responsibilities of the job. </div></td>
                 </tr>
                 <tr>
                   <td colspan="5"><div align="justify">&nbsp;</div></td>
                 </tr>
                 <tr>
                   <td colspan="5"><div align="justify">6) Confirmation</div></td>
                 </tr>
                 <tr>
                   <td colspan="5"><p align="justify"> Upon successful completion of your temporary contract period , you will be assessed on your performance of your job tasks on a month ly basis . Your superior may recommend you for permanent employment under the following criteria :- </p>
                       <p align="justify">a) In order to be confirmed in your position, you must achieve 
                           <asp:Label ID="targ" runat="server"></asp:Label>
                           &gt; <%--<%=request.form("target1")%>--%> rating (Above Target) as per the Performance Appraisal Rating. </p>
                       <p align="justify"> Upon successful completion of the contract period, a letter of confirmation for extension of contract period (renewal) yearly or a letter of confirmation for permanent employment shall be given. The final decision to change from contract staff to normal employment staff is at the discretion of the management. </p></td>
                 </tr>
                 <tr>
                   <td colspan="5"><div align="justify">&nbsp;</div></td>
                 </tr>
                 <tr>
                   <td colspan="5"><div align="justify">7) Notice Period of Termination Service</div></td>
                 </tr>
                 <tr>
                   <td colspan="5"><p align="justify">During your temporary contract period, if your performance is found unsatisfactory, the Company reserves the right to terminate your service by giving 2-week notice. The termination notice from either party shall be in writing. </p>
                   </td>
                 </tr>
                 <tr>
                   <td colspan="5"><div align="justify">&nbsp;</div></td>
                 </tr>
                 <tr>
                   <td colspan="5"><div align="justify">8) The Company&rsquo;s rules and regulations are strictly to be adhered to and any breaches would render the employees to disciplinary action that may result in dismissal. </div></td>
                 </tr>
                 <tr>
                   <td colspan="5"><div align="justify">&nbsp;</div></td>
                 </tr>
                 <tr>
                   <td colspan="5"><div align="justify">9) You shall not at anytime during the term of your employment or thereafter reveal or disclose the affairs in relations to our business, any correspondences or activities of the company to any person, companies, firms and corporation on any matters whatsoever without prior written approval from the Company. </div></td>
                 </tr>
                 <tr>
                   <td colspan="5"><div align="justify">&nbsp;</div></td>
                 </tr>
                 <tr>
                   <td colspan="5"><div align="justify">10) Any employee who is in the employment with the Company whom has been convicted for any offence both criminal and civil are required to inform the Management of such offences at the earliest possible date. Failure to comply may result in termination of employment. </div></td>
                 </tr>
                 <tr>
                   <td colspan="5"><div align="justify">&nbsp;</div></td>
                 </tr>
                 <tr>
                   <td colspan="5"><div align="justify">11) Employees who have left the Company can be called upon to assist the Company on any matters involving the employer. </div></td>
                 </tr>
                 <tr>
                   <td colspan="5"><div align="justify">&nbsp;</div></td>
                 </tr>
                 <tr>
                   <td colspan="5"><div align="justify">12) Public Holiday</div></td>
                 </tr>
                 <tr>
                   <td colspan="5"><p align="justify"> You shall be entitled to all the Company Public Holidays. A Company Calendar will be given to you on your first day of work. </p></td>
                 </tr>
                 <tr>
                   <td colspan="5"><div align="justify">&nbsp;</div></td>
                 </tr>
                 <tr>
                   <td colspan="5"><div align="justify">13) Insurance </div></td>
                 </tr>
                 <tr>
                   <td colspan="5"><p align="justify"> A Group Personal Accident is applicable to employees who are not covered by the SOCSO Scheme. Contribution for this cause will be borne by the Company. </p></td>
                 </tr>
                 <tr>
                   <td colspan="5"><div align="justify">&nbsp;</div></td>
                 </tr>
                 <tr>
                   <td colspan="5"><div align="justify">14) In House Clinic</div></td>
                 </tr>
                 <tr>
                   <td colspan="5"><p align="justify"> You are entitled for In House Clinic medical treatment based on the identified list of clinic by the Company or any government hospitals. </p></td>
                 </tr>
                 <tr>
                   <td colspan="5"><div align="justify">&nbsp;</div></td>
                 </tr>
                 <tr>
                   <td colspan="5"><div align="justify">15) All other terms and benefits shall be as stipulated in the Employment Act &amp; Regulation 1955. 
                   If you agree to the above terms and conditions of employment, kindly indicate your acceptance by signing and returning the duplicate copy of this letter. </div></td>
                 </tr>
                 <tr>
                   <td colspan="5"><div align="justify">&nbsp;</div></td>
                 </tr>
                 <tr>
                   <td colspan="5"><div align="justify">16) Accomodation</div></td>
                 </tr>
                 <tr>
                   <td colspan="5"><div align="justify">You will be provided with place to stay complete with basic furniture, utensils and appliances. All these with electrical, water bills and maintenance cost shall be borne by the company. </div></td>
                 </tr>
                 <tr>
                   <td colspan="5"><div align="justify">&nbsp;</div></td>
                 </tr>
                 <tr>
                   <td colspan="5"><div align="justify">17) Foreign Worker Insurance </div></td>
                 </tr>
                 <tr>
                   <td colspan="5"><div align="justify">In addition to the Group Personal Accident you are also shall be covered with Foreign Worker Insurance which also include the responsibility to send back the deceased body to their own country. </div></td>
                 </tr>
                 <tr>
                   <td colspan="5"><div align="justify">&nbsp;</div></td>
                 </tr>
                 <tr>
                   <td colspan="5"><div align="justify">18) Air Ticket &amp; Transportation </div></td>
                 </tr>
                 <tr>
                   <td colspan="5"><div align="justify">The company shall bear the cost of air ticket and to provide transportation whenever you are in any business trip approved by the management. </div></td>
                 </tr>
                 <tr>
                   <td colspan="5"><div align="justify">&nbsp;</div></td>
                 </tr>
                 <tr>
                   <td colspan="5"><p align="justify"> We look forward to your contribution to the Company. </p></td>
                 </tr>
                 <tr>
                   <td colspan="5"><div align="justify">&nbsp;</div></td>
                 </tr>
                 <tr>
                   <td colspan="5"><div align="justify">&nbsp;</div></td>
                 </tr>
                 <tr>
                   <td colspan="5"><p align="justify"> Thank you. </p></td>
                 </tr>
                 <tr>
                   <td colspan="5">&nbsp;</td>
                 </tr>
                 <tr>
                   <td colspan="5"><p> Yours faithfully, </p>
                       <p>&nbsp;</p></td>
                 </tr>
                 <tr>
                   <td colspan="5">&nbsp;</td>
                 </tr>
                 <tr>
                   <td colspan="5" style="height: 21px">________________________________</td>
                 </tr>
                 <tr>
                   <td colspan="5"><p><strong> DATUK MANIMARAN ANTHONY </strong></p>
                       <p> CHIEF EXECUTIVE OFFICER </p></td>
                 </tr>
                 <tr>
                   <td colspan="5"><hr></td>
                 </tr>
                 <tr>
                   <td colspan="5">&nbsp;</td>
                 </tr>
                 <tr>
                   <td colspan="5"><p> I hereby accept the offer and confirm that I fully understand the terms and conditions of employment. </p></td>
                 </tr>
                 <tr>
                   <td colspan="5">&nbsp;</td>
                 </tr>
                 <tr>
                   <td colspan="5" style="height: 21px">&nbsp;</td>
                 </tr>
                 <tr>
                   <td colspan="5" style="height: 21px"><p> Signature : _______________________________ </p></td>
                 </tr>
                 <tr>
                   <td colspan="5">&nbsp;</td>
                 </tr>
                 <tr>
                   <td colspan="5" style="height: 21px"><p> Name :<strong> 
                       <asp:Label ID="empname" runat="server" Font-Bold="False"></asp:Label><%--<%=name%>--%></strong></p></td>
                 </tr>
                 <tr>
                   <td colspan="5">&nbsp;</td>
                 </tr>
                 <tr>
                   <td colspan="5">NRIC /Passport No :<strong> 
                       <asp:Label ID="nric" runat="server" Font-Bold="False"></asp:Label><%--<%=nric%>--%></strong></td>
                 </tr>
                 <tr>
                   <td colspan="5">&nbsp;</td>
                 </tr>
                 <tr>
                   <td colspan="5"><p> Date : ______________________________ </p></td>
                 </tr>
             </table></td>
           </tr>
           <tr class="style2">
             <td>&nbsp;</td>
           </tr>
         </table>
    </form>
</body>
</html>
