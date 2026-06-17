<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ContractTermination.aspx.vb" Inherits="E_Management.ContractTermination" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Contract Termination</title>
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
               <td width="45">&nbsp;</td>
               <td width="311"><a href="emp_main.asp"><img src="../../images/maruwaAnimLogo.gif" width="161" height="42" border="0"></a></td>
              <%-- <% 
          'dim dd,mm,yyyy,newtime
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
               <td width="88"><div align="right">Ref. No.:</div></td>
               <td width="158"><%--<%=refno%>--%>
                   <asp:Label ID="refno" runat="server"></asp:Label></td>
             </tr>
         </table></td>
       </tr>
       <tr class="style2">
         <td><table width="609" border="0" cellspacing="0">
             <tr>
               <td>&nbsp;</td>
               <td width="120">&nbsp;</td>
               <td width="275">&nbsp;</td>
               <td>&nbsp;</td>
             </tr>
             <tr>
                 <td width="44">
                     &nbsp;</td>
                 <td colspan="2">
                     <span class="style6">Name : 
                         <asp:Label ID="name" runat="server"></asp:Label><%--<%=request.form("empname")%>--%></span></td>
                 <td width="159">
                     <span class="style6">Date : 
                         <asp:Label ID="ltdate" runat="server"></asp:Label><%--<%=newdate%>--%></span></td>
             </tr>
             <tr>
                 <td>
                     &nbsp;</td>
                 <td colspan="2">
                     <span class="style6">Emp. No. : 
                         <asp:Label ID="empno" runat="server"></asp:Label><%--<%=request.form("empcode")%>--%></span></td>
                 <td>
                     &nbsp;</td>
             </tr>
             <tr>
                 <td height="23">
                     &nbsp;</td>
                 <td colspan="2">
                     Department : 
                     <asp:Label ID="dept" runat="server"></asp:Label><%--<%=olddept%>--%&gt;</TD><TD 
__designer:dtid="1407439308062747"> </TD></TR><TR 
__designer:dtid="1407439308062748"><TD 
__designer:dtid="1407439308062749"> </TD><TD colSpan=2 
__designer:dtid="1407439308062750">Designation : <asp:Label id="desig" __designer:dtid="1407439308062751" runat="server" Font-Bold="False"></asp:Label><%--<%=olddesig%>--%></td>
                 <td>
                     &nbsp;</td>
             </tr>
             <tr>
               <td>&nbsp;</td>
               <td colspan="2"><span class="style6">Designation : 
                   <asp:Label ID="desig" runat="server"></asp:Label><%--<%=desig%>--%></span></td>
               <td>&nbsp;</td>
             </tr>
         </table></td>
       </tr>
       <tr class="style2">
         <td><table width="609" border="0" cellspacing="0">
             <tr>
               <td width="45" height="24">&nbsp;</td>
               <td width="175">&nbsp;</td>
               <td width="179">&nbsp;</td>
               <td width="182">&nbsp;</td>
             </tr>
             <tr>
               <td height="22" colspan="4"><div align="center">
                   <p><strong>Ref : Termination of Contract due to Medically unfit </strong></p>
               </div></td>
             </tr>
             <tr>
               <td height="23">&nbsp;</td>
               <td>&nbsp;</td>
               <td>&nbsp;</td>
               <td>&nbsp;</td>
             </tr>
             <tr>
               <td height="81">&nbsp;</td>
               <td colspan="3"><p align="justify"> The management has decided to terminate your contract effective from
                   <asp:Label ID="efffrom" runat="server"></asp:Label><span class="style6">
                      <%-- <%=request.form("date50")%>--%></span> because you were found by our panel doctor to be medically unfit for employment due to your serious health conditions which was not declared before by you. Your last day of work is on <span class="style6"> <%=request.form("date51")%></span> and all dues will be paid accordingly as per our terms and condition of Employment.</p></td>
             </tr>
             <tr>
               <td height="21">&nbsp;</td>
               <td colspan="3"><div align="center"></div></td>
             </tr>
             <tr>
               <td height="44">&nbsp;</td>
               <td colspan="3"><p align="justify"> The management would like to thank you for your service at Maruwa (M) Sdn Bhd and wish you the best wishes in your future undertaking.</p></td>
             </tr>
             <tr>
               <td>&nbsp;</td>
               <td colspan="3">&nbsp;</td>
             </tr>
             <tr>
               <td>&nbsp;</td>
               <td colspan="3"><p>&nbsp; </p></td>
             </tr>
             <tr>
               <td>&nbsp;</td>
               <td colspan="3">Thank You </td>
             </tr>
             <tr>
               <td>&nbsp;</td>
               <td colspan="3"><p>&nbsp; </p></td>
             </tr>
             <tr>
               <td>&nbsp;</td>
               <td colspan="3"><p>&nbsp; </p></td>
             </tr>
             <tr>
               <td>&nbsp;</td>
               <td colspan="3">_______________________________</td>
             </tr>
             <tr>
               <td style="height: 21px">&nbsp;</td>
               <td colspan="3" style="height: 21px">
                   <strong>Datuk</strong> <strong>Manimaran Anthony</strong></td>
             </tr>
             <tr>
               <td>&nbsp;</td>
               <td colspan="3">Executive Advisor</td>
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
