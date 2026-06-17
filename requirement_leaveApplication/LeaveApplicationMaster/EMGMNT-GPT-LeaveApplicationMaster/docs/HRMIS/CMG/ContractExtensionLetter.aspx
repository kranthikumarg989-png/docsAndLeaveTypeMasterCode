<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ContractExtensionLetter.aspx.vb" Inherits="E_Management.ContractExtensionLetter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Contract Extension Letter</title>
</head>
<body>
    <form id="form1" runat="server">
   <table width="612" border="0" cellspacing="0">
      <tr>
        <td colspan="4" class="style2"><div align="center"></div></td>
      </tr>
      <tr class="style2">
        <td colspan="4"><table width="610" border="0" cellspacing="0">
            <tr>
              <td width="45">&nbsp;</td>
              <td width="375"><a href="emp_main.asp"><img src="../../images/maruwaAnimLogo.gif" width="161" height="42" border="0"></a></td>
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
              <td width="63">Ref. No.:</td>
              <td width="119"><%--<%=refno%>--%>
                  <asp:Label ID="refno" runat="server"></asp:Label></td>
            </tr>
        </table></td>
      </tr>
      <tr class="style2">
        <td colspan="4"><table width="609" border="0" cellspacing="0">
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td width="43">
                    &nbsp;</td>
                <td colspan="2">
                    <span class="style6">Name :
                        <asp:Label ID="name" runat="server"></asp:Label><%--<%=request.form("empname")%>--%></span></td>
                <td width="168">
                    <span class="style6">Date : 
                        <asp:Label ID="ltdate" runat="server"></asp:Label><%--<%=newdate%>--%></span></td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td colspan="2">
                    <span class="style6">Emp. No. :
                        <asp:Label ID="empcode" runat="server"></asp:Label><%--<%=request.form("empcode")%>--%></span></td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td height="21">
                    &nbsp;</td>
                <td colspan="2">
                    Department : 
                    <asp:Label ID="dept" runat="server"></asp:Label><%--<%=olddept%>--%></td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td height="22">
                    &nbsp;</td>
                <td colspan="2">
                    Designation :  
                    <asp:Label ID="desig" runat="server"></asp:Label><%--<%=olddesig%>--%></td>
                <td>
                    &nbsp;</td>
            </tr>
        </table></td>
      </tr>
      <tr class="style2">
        <td colspan="4"><table width="609" border="0" cellspacing="0">
            <tr>
              <td width="45">&nbsp;</td>
              <td width="175">&nbsp;</td>
              <td width="179">&nbsp;</td>
              <td width="182">&nbsp;</td>
            </tr>
            <tr>
              <td colspan="4"><div align="center">
                  <p><strong> <u>Ref : LETTER OF EXTENSION CONTRACT EMPLOYMENT </u></strong></p>
              </div></td>
            </tr>
            <tr>
              <td>&nbsp;</td>
              <td>&nbsp;</td>
              <td>&nbsp;</td>
              <td>&nbsp;</td>
            </tr>
            <tr>
              <td>&nbsp;</td>
              <td colspan="3"><p align="justify"> We are pleased to inform that your CONTRACT EMPLOYMENT is extended for &nbsp;<strong><%--<%=request.form("contractperiod")%>--%><asp:Label
                      ID="months" runat="server"></asp:Label>&nbsp;Month(s) </strong>effective from<%-- <%=request.form("date4")%>--%><strong>
                      </strong>
                  <asp:Label ID="efffrom" runat="server" Font-Bold="True"></asp:Label><strong> to </strong>
                  <asp:Label ID="effto" runat="server" Font-Bold="True"></asp:Label>.<strong><span class="style6"><%--<%=request.form("date5")%>--%>&nbsp;</span></strong></p></td>
            </tr>
            <tr>
              <td>&nbsp;</td>
              <td colspan="3"><div align="center"></div></td>
            </tr>
			<%--<%if request.form("adjustment")="adjust" and request.form("adjustmentposition")="adjust" then%>--%>
			 <tr>
              <td>&nbsp;</td>
              <td colspan="3"><p align="justify"> With effect from the date of this letter, your basic salary will be adjusted from RM 
                  <asp:Label ID="oldbsa" runat="server"></asp:Label>
                  <%--<%=request.form("previous")%> --%> to RM 
                  <asp:Label ID="newbsa" runat="server"></asp:Label>
                  <%--<%=request.form("basicadjustment1")%> --%>and  position allowance will also be adjusted from RM 
                  <asp:Label ID="oldnpa" runat="server"></asp:Label>
                  <%--<%=request.form("preposition")%>--%>
                  to RM
                  <asp:Label ID="newnpa" runat="server"></asp:Label><%-- <%=request.form("curposition")%>--%>
                  per month. </p></td>
            </tr>
			<%--<%elseif request.form("adjustment")="adjust" then%>--%>
            <tr>
              <td>&nbsp;</td>
              <td colspan="3"><p align="justify"> With effect from the date of this letter, your basic salary will also be adjusted from RM 
                  <asp:Label ID="oldbsa1" runat="server"></asp:Label>
                  <%--<%=request.form("previous")%>--%>  to RM 
                  <asp:Label ID="newbsa1" runat="server"></asp:Label>
                  <%--<%=request.form("basicadjustment1")%>--%>  per month. </p></td>
            </tr>
			<%--<%elseif request.form("adjustmentposition")="adjust" then%>--%>
            <tr>
              <td>&nbsp;</td>
              <td colspan="3"><p align="justify"> With effect from the date of this letter, your position allowance will also be adjusted from RM
                  <asp:Label ID="oldnpa1" runat="server"></asp:Label>
                  <%--<%=request.form("preposition")%>--%>
                  to RM
                  <asp:Label ID="newnpa1" runat="server"></asp:Label>
                  <%--<%=request.form("curposition")%> --%> per month. </p></td>
            </tr>
			<%--<%end if%>--%>
            <tr>
              <td>&nbsp;</td>
              <td colspan="3">&nbsp;</td>
            </tr>
            <tr>
              <td>&nbsp;</td>
              <td colspan="3"><p align="justify"> All terms and conditions of service as conveyed to you in your formal letter of appointment will continue to be effective. </p></td>
            </tr>
            <tr>
              <td>&nbsp;</td>
              <td colspan="3">&nbsp;</td>
            </tr>
            <tr>
              <td>&nbsp;</td>
              <td colspan="3"><p align="justify"> We trust that you will continue to grow in your career towards the progress of Maruwa (Malaysia) Sdn Bhd and mutually benefit in years to come. </p></td>
            </tr>
            <tr>
              <td>&nbsp;</td>
              <td colspan="3">&nbsp;</td>
            </tr>
            <tr>
              <td height="19">&nbsp;</td>
              <td colspan="3">Our heartiest congratulations.</td>
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
              <td>&nbsp;</td>
              <td colspan="3">________________________________</td>
            </tr>
            <tr>
              <td style="height: 21px">&nbsp;</td>
              <td colspan="3" style="height: 21px"><strong>Seenivasalu A/L VN Venugopal</strong></td>
            </tr>
            <tr>
              <td>&nbsp;</td>
              <td colspan="3">
                  <strong>Plant Manager</strong></td>
            </tr>
        </table></td>
      </tr>
      <tr class="style2">
        <td colspan="4">&nbsp;</td>
      </tr>
      <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td width="455">&nbsp;</td>
        <td width="455">&nbsp;</td>
      </tr>
  </table>
    </form>
</body>
</html>
