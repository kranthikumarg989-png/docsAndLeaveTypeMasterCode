<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="NewConfirmationLetter.aspx.vb" Inherits="E_Management.NewConfirmationLetter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Confirmation Letter (New)</title>
</head>
<body>
    <form id="form1" runat="server">
   <table width="612" border="0" cellspacing="0">
      <tr>
        <td colspan="4" class="style2"><div align="center"></div></td>
      </tr>
      <tr class="style2">
        <td colspan="4" style="height: 65px"><table width="610" border="0" cellspacing="0">
            <tr>
              <td width="44">&nbsp;</td>
              <td width="369"><a href="emp_main.asp"><img src="../../images/maruwaAnimLogo.gif" width="161" height="42" border="0"></a></td>
             <%-- <% 
         
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
              <td width="72">Ref. No.:</td>
              <td width="97"><%--<%=refno%>--%>
                  <asp:Label ID="refno" runat="server"></asp:Label></td>
            </tr>
        </table></td>
      </tr>
      <tr class="style2">
        <td colspan="4" style="height: 152px"><table width="609" border="0" cellspacing="0">
            <tr>
              <td>&nbsp;</td>
              <td width="116">&nbsp;</td>
              <td width="254">&nbsp;</td>
              <td>&nbsp;</td>
            </tr>
            <tr>
              <td>&nbsp;</td>
              <td>&nbsp;</td>
              <td>&nbsp;</td>
              <td>&nbsp;</td>
            </tr>
            <tr>
              <td width="43" style="height: 21px">&nbsp;</td>
              <td colspan="2" style="height: 21px"><span class="style6">Name : 
                  <asp:Label ID="name" runat="server"></asp:Label><%--<%=request.form("empname")%>--%></span></td>
              <td width="168" style="height: 21px"><span class="style6">Date : 
                  <asp:Label ID="ltdate" runat="server"></asp:Label><%--<%=newdate%>--%></span></td>
            </tr>
            <tr>
              <td>&nbsp;</td>
              <td colspan="2"><span class="style6">Emp. No. : 
                  <asp:Label ID="empcode" runat="server"></asp:Label><%--<%=request.form("empcode")%>--%></span></td>
              <td>&nbsp;</td>
            </tr>
            <tr>
              <td height="21">&nbsp;</td>
              <td colspan="2">Department : 
                  <asp:Label ID="dept" runat="server"></asp:Label><%--<%=olddept%>--%></td>
              <td>&nbsp;</td>
            </tr>
            <tr>
              <td height="22">&nbsp;</td>
              <td colspan="2">Designation : 
                  <asp:Label ID="desig" runat="server"></asp:Label><%--<%=olddesig%>--%></td>
              <td>&nbsp;</td>
            </tr>
        </table></td>
      </tr>
      <tr class="style2">
        <td colspan="4"><table width="609" border="0" cellspacing="0">
            <tr>
              <td width="43">&nbsp;</td>
              <td width="169">&nbsp;</td>
              <td width="192">&nbsp;</td>
              <td width="197">&nbsp;</td>
            </tr>
            <tr>
              <td colspan="4"><div align="center"><strong><u>Ref : LETTER OF CONFIRMATION </u></strong></div></td>
            </tr>
            <tr>
              <td>&nbsp;</td>
              <td>&nbsp;</td>
              <td>&nbsp;</td>
              <td>&nbsp;</td>
            </tr>
            <tr>
              <td height="54">&nbsp;</td>
              <td colspan="3"><p align="justify"> We are pleased to inform that your appointment with us as a 
                  <asp:Label ID="desig1" runat="server"></asp:Label>
                  is now deemed confirmed with effective from
                  <asp:Label ID="effdt" runat="server"></asp:Label>.</p></td>
            </tr>
            <tr>
              <td>&nbsp;</td>
              <td colspan="3"><div align="center"></div></td>
            </tr>
            <tr>
              <td height="40">&nbsp;</td>
              <td colspan="3"><p align="justify"> All terms and conditions of service as conveyed to you in our formal letter   of appointment
                  will continue to be effective. </p></td>
            </tr>
            <tr>
              <td height="22">&nbsp;</td>
              <td colspan="3">&nbsp;</td>
            </tr>
            <tr>
              <td style="height: 40px">&nbsp;</td>
              <td colspan="3" style="height: 40px"><p align="justify"> We trust that you will continue to grow in your career towards the progress of Maruwa (Malaysia) Sdn Bhd and mutual benefit in years to come. </p></td>
            </tr>
            <tr>
              <td style="height: 30px">&nbsp;</td>
              <td colspan="3" style="height: 30px">&nbsp;</td>
            </tr>
            <tr>
              <td style="height: 21px">&nbsp;</td>
              <td colspan="3" style="height: 21px"><p> Our heartiest congratulations.
              </p></td>
            </tr>
            <tr>
              <td>&nbsp;</td>
              <td colspan="3">&nbsp;</td>
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
              <td colspan="3">Yours faithfully,</td>
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
              <td style="height: 21px">&nbsp;</td>
              <td colspan="3" style="height: 21px">&nbsp;</td>
            </tr>
            <tr>
              <td>&nbsp;</td>
              <td colspan="3">________________________________</td>
            </tr>
            <tr>
              <td>&nbsp;</td>
              <td colspan="3">
                  <strong>Seenivasalu A/L VN Venugopal</strong></td>
            </tr>
            <tr>
              <td style="height: 21px">&nbsp;</td>
              <td colspan="3" style="height: 21px">
                  General Manager (COO)</td>
            </tr>
        </table>
    </form>
</body>
</html>
