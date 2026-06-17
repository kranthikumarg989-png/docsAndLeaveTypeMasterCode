<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SplIncenctiveLetter.aspx.vb" Inherits="E_Management.SplIncenctiveLetter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Special Incentive Letter</title>
</head>
<body>
    <form id="form1" runat="server">
   <table width="642" border="0" cellspacing="0">
     <tr>
      <td colspan="4"><img src="../../images/maruwaAnimLogo.gif" width="158" height="39"></td>
      <td>&nbsp;</td>
      <td style="text-align: right">&nbsp;Ref. No :</td>
      <td>&nbsp;<asp:Label ID="refno" runat="server"></asp:Label></td>
    </tr>
     <tr>
       <td colspan="6">&nbsp;</td>
       <td>&nbsp;</td>
     </tr>
     <tr>
      <td colspan="4" style="height: 20px"><p align="justify"><strong>Name :</strong> 
          <asp:Label ID="name" runat="server"></asp:Label><span class="style2"><%--<%=request.Form("empname")%>--%></span></p></td>
      <td>&nbsp;</td>
      <td><div align="right"><span class="style12"><strong>Date</strong></span><strong>:</strong></div></td>
      <td><span class="style2">
          <asp:Label ID="ltdate" runat="server"></asp:Label><%--<%=request.Form("vdate")%>--%></span></td>
    </tr>
    <tr>
      <td colspan="7" style="height: 20px"><strong>Emp No : 
          <asp:Label ID="empno" runat="server" Font-Bold="False"></asp:Label></strong><span class="style2"><%--<%=request.form("empcode")%>--%></span></td>
    </tr>
    <tr>
      <td colspan="7" style="height: 20px"><strong>Department :</strong> 
          <asp:Label ID="dept" runat="server"></asp:Label><span class="style2"><%--<%=request.form("departmentcode")%>--%></span></td>
    </tr>
    <tr>
      <td colspan="7" style="height: 20px"><strong>Designation :</strong> 
          <asp:Label ID="desig" runat="server"></asp:Label><span class="style2"><%--<%=request.form("desig")%>--%></span></td>
    </tr>
    <tr>
      <td colspan="7">&nbsp;</td>
    </tr>
    <tr>
      <td colspan="7"><div align="center"><strong class="style2">SPECIAL INCENTIVE</strong></div></td>
    </tr>
    <tr>
      <td colspan="7">&nbsp;</td>
    </tr>
    
    <tr class="style2">
      <td colspan="7"><div align="justify"><span class="style2">The Management would like to extend its greatest appreciation to you for being a sincere and honorable staff throughout the year. </span></div></td>
    </tr>
    <tr class="style2">
      <td colspan="7">&nbsp;</td>
    </tr>
    <tr class="style2">
      <td colspan="7">Therefore, as an appreciation for your examplary performance and contribution towards the company, the management is pleased to award you with a special incentive effective from 
          <asp:Label ID="effdate" runat="server"></asp:Label>&nbsp;<%--<%=request.form("edate")%>--%></td>
    </tr>
    <tr>
      <td style="width: 37px">&nbsp;</td>
      <td width="93"><div align="left"></div></td>
      <td width="178">&nbsp;</td>
      <td style="width: 33px"><div align="right"></div></td>
      <td width="18" >&nbsp;</td>
     <%-- <% a = trim(request.form("currentbasicsalary"))%>--%>
      <td width="104" ><div align="right"></div></td>
      <td width="183"><div align="right"></div></td>
    </tr>
    <tr>
      <td style="width: 37px">&nbsp;</td>
      <td>&nbsp;</td>
      <td><strong>Basic Salary </strong></td>
      <td class="style2" style="width: 33px"><div align="right">
          <asp:Label ID="Label1" runat="server">RM</asp:Label>&nbsp;</div></td>
      <td class="style2">&nbsp;</td>
      <td class="style2"><div align="left"></div>
        <div align="left">
            <asp:Label ID="bsa" runat="server"></asp:Label><%--<%=request.form("currentbasicsalary")%>--%></div></td>
      <td>&nbsp;</td>
    </tr>
    <tr>
	 <%-- <%if request.form("oldpa")<>"" then%>--%>
      <td style="width: 37px; height: 21px;">&nbsp;</td>
      <td style="height: 21px">&nbsp;</td>
      <td style="height: 21px"><strong>
          <asp:Label ID="lpa" runat="server">Position Allowance</asp:Label></strong></td>
      <td class="style2" style="width: 33px; height: 21px;"><div align="right">
          <asp:Label ID="parm" runat="server">RM</asp:Label>&nbsp;</div></td>
      <td class="style2" style="height: 21px">&nbsp;</td>
      <td class="style2" style="height: 21px"><%--<%=request.form("oldpa")%>--%>
          <asp:Label ID="oldpall" runat="server"></asp:Label></td>
      <td style="height: 21px">&nbsp;</td>
	 <%-- <%end if%>--%>
    </tr>
    <tr>
      <td style="width: 37px; height: 21px">&nbsp;</td>
      <td style="height: 21px"><p>&nbsp; </p></td>
      <td style="height: 21px"><strong>
          <asp:Label ID="lsia" runat="server">Special Incentive Amount</asp:Label>
      </strong></td>
      <td class="style2" style="width: 33px; height: 21px;"><div align="right">
          <asp:Label ID="siarm" runat="server">RM</asp:Label>&nbsp;</div></td>
      <td class="style2" style="height: 21px">&nbsp;</td>
      <td class="style2" style="height: 21px"><div align="left"></div>
        <div align="left">
            <asp:Label ID="splinc" runat="server"></asp:Label><%--<%=request.form("incrementamt")%>--%></div></td>
      <td style="height: 21px">&nbsp;</td>
    </tr>
    
    <tr>
      <td style="width: 37px; height: 21px">&nbsp;</td>
      <td style="height: 21px">&nbsp;</td>
      <td style="height: 21px">&nbsp;</td>
      <td class="style2" style="width: 33px; height: 21px;">&nbsp;</td>
      <td class="style2" style="height: 21px">&nbsp;</td>
      <td class="style2" style="height: 21px">&nbsp;</td>
      <td style="height: 21px">&nbsp;</td>
    </tr>
    <tr>
      <td style="width: 37px">&nbsp;</td>
      <td>&nbsp;</td>
      <td><strong>New Basic Salary </strong></td>
      <td class="style2" style="width: 33px"><div align="right">
          <asp:Label ID="Label9" runat="server">RM</asp:Label>&nbsp;</div></td>
      <td class="style2">&nbsp;</td>
      <td class="style2"><div align="left"></div>
        <div align="left">
            <asp:Label ID="nbsa" runat="server"></asp:Label><%--<%= request.form("newbasicsalary")%>--%></div></td>
      <td>&nbsp;</td>
    </tr>
    
    <tr>
	<%--<%if request.form("positionallowance")<>"" then%>--%>
      <td style="width: 37px; height: 21px;">&nbsp;</td>
      <td style="height: 21px"><p>&nbsp; </p></td>
      <td style="height: 21px">
          <asp:Label ID="lnpa" runat="server" Font-Bold="True">New Position Allowance</asp:Label></td>
      <td class="style2" style="width: 33px; height: 21px;"><div align="right">
          <asp:Label ID="nparm" runat="server">RM</asp:Label>&nbsp;</div></td>
      <td class="style2" style="height: 21px">&nbsp;</td>
      <td class="style2" style="height: 21px"><div align="left"></div>
        <div align="left">
            <asp:Label ID="pall" runat="server"></asp:Label><%--<%= request.form("positionallowance")%>--%></div></td>
      <td style="height: 21px">&nbsp;</td>
	 <%-- <%end if%>--%>
    </tr>
    
    <tr>
		  <%--<%
	   if request.form("pfpallowance")<>"" then
	  %>--%>
      <td style="height: 21px; width: 37px;">&nbsp;</td>
      <td style="height: 21px">&nbsp;</td>

      <td style="height: 21px"><strong>
          <asp:Label ID="lpfp" runat="server">PFP Allowance</asp:Label></strong></td>
      <td style="width: 33px; height: 21px"> <div align="right">
          <asp:Label ID="pfprm" runat="server">RM</asp:Label>&nbsp;</div></td>
      <td style="height: 21px">&nbsp;</td>
      <td style="height: 21px"><div align="left"></div>
        <div align="left">
            <asp:Label ID="pfpall" runat="server"></asp:Label><%--<%= request.form("pfpallowance")%>--%></div></td>
	 
      <td style="height: 21px">&nbsp;</td>
	  <%-- <%end if%>--%>
    </tr>
    <tr>
      <td style="width: 37px">&nbsp;</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td style="width: 33px">&nbsp;</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
    </tr>
    <tr class="style2">
      <td colspan="7" style="height: 21px">&nbsp;</td>
    </tr>
    <tr class="style2">
      <td colspan="7">Your present position as <%--<%=request.form("newdesignation")%> --%>will remain unchanged. </td>
    </tr>
    <tr class="style2">
      <td colspan="7">&nbsp;</td>
    </tr>
    <tr class="style2">
      <td colspan="7"><div align="justify">We trust that you will continue to grow career towards the progress of Maruwa(M) SDN. BHD in the coming years. </div></td>
    </tr>
    <tr class="style2">
      <td colspan="7">&nbsp;</td>
    </tr>
    <tr class="style2">
      <td colspan="7">Our heartiest congratulations. </td>
    </tr>
    <tr class="style2">
      <td colspan="7">&nbsp;</td>
    </tr>
    <tr class="style2">
      <td colspan="7">&nbsp;</td>
    </tr>
    <tr class="style2">
      <td colspan="7"><p align="justify"> Thank you. </p></td>
    </tr>
    <tr class="style2">
      <td colspan="7">&nbsp;</td>
    </tr>
    <tr class="style2">
      <td colspan="7"><div align="justify"></div></td>
    </tr>
    <tr class="style2">
      <td colspan="7"><p align="justify"> Yours faithfully, </p>
          <p align="justify">MARUWA ( MALAYSIA ) SDN BHD </p></td>
    </tr>
    <tr>
      <td colspan="7"><div align="justify"></div></td>
    </tr>
    <tr>
      <td colspan="7">&nbsp;</td>
    </tr>
    <tr>
      <td colspan="7">&nbsp;</td>
    </tr>
    <tr>
      <td colspan="7">&nbsp;</td>
    </tr>
    <tr>
      <td colspan="7"><div align="justify"></div></td>
    </tr>
    <tr>
      <td colspan="7"><div align="justify"></div></td>
    </tr>
    <tr>
      <td height="113" colspan="3"><p align="justify">_________________________________</p>
          <p align="justify"><strong> <span class="style2">DATUK MANIMARAN ANTHONY </span></strong></p>
          <p align="justify">CHIEF EXECUTIVE OFFICER</p>
          <div align="right"></div></td>
      <td height="113" style="width: 33px">&nbsp;</td>
      <td>&nbsp;</td>
      <td height="113"><img src="../../images/stamp.jpg" width="84" height="78"></td>
      <td height="113">&nbsp;</td>
    </tr>
    
  </table>
    </form>
</body>
</html>
