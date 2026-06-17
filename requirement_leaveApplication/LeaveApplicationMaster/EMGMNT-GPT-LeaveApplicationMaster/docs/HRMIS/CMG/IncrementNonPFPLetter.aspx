<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="IncrementNonPFPLetter.aspx.vb" Inherits="E_Management.IncrementNonPFPLetter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Increment Letter for Non PFP</title>
</head>
<body>
    <form id="form1" runat="server">
    <table width="642" border="0" cellspacing="0">
     <tr>
      <td colspan="4"><img src="../../images/maruwaAnimLogo.gif" width="158" height="39"></td>
      <td>&nbsp;</td>
         <td style="width: 109px; text-align: right">
             Ref. No.:</td>
         <td width="131">
             <%--<%=refno%>--%>
             <asp:Label ID="refno" runat="server"></asp:Label></td>
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
      <td colspan="7"><div align="center"><strong class="style2">INCREMENT </strong></div></td>
    </tr>
    <tr>
      <td colspan="7">&nbsp;</td>
    </tr>
    
    <tr class="style2">
      <td colspan="7"><div align="justify"><span class="style2">The Management would like to extend it's greatest appreciation to you for being an sincere and honorable staff throughout the year. </span></div></td>
    </tr>
    <tr class="style2">
      <td colspan="7">&nbsp;</td>
    </tr>
    <tr class="style2">
      <td height="23" colspan="7"><div align="justify">As staff of the company, you had shown examplary performance and having put continuous effort towards the growth of the company. </div></td>
    </tr>
    <tr class="style2">
      <td height="23" colspan="7"><p class="style2">&nbsp;</p></td>
    </tr>
    <tr class="style2">
      <td height="47" colspan="7"><div align="justify"><span class="style2">On behalf of the board, the management is pleased to award you an increment as follows effective
          from 
          <asp:Label ID="effdate" runat="server"></asp:Label><%--<%=request.form("edate")%>--%></span></div></td>
    </tr>
    <tr>
      <td width="31">&nbsp;</td>
      <td width="93"><div align="left"></div></td>
      <td style="width: 203px">&nbsp;</td>
      <td style="width: 34px"><div align="right"></div></td>
      <td width="18" >&nbsp;</td>
      <%--<% a = trim(request.form("currentbasicsalary"))%>--%>
      <td width="104" ><div align="right"></div></td>
      <td width="183"><div align="right"></div></td>
    </tr>
    <tr>
      <td style="height: 21px">&nbsp;</td>
      <td style="height: 21px">&nbsp;</td>
      <td style="width: 203px; height: 21px"><strong>
          <asp:Label ID="lblbasic" runat="server">Basic Salary</asp:Label></strong></td>
      <td class="style2" style="width: 34px; height: 21px">
          <asp:Label ID="lblrm" runat="server"> RM</asp:Label>&nbsp;</td>
      <td class="style2" style="height: 21px">&nbsp;</td>
      <td class="style2" style="height: 21px">
        <div align="left">
            <asp:Label ID="bsa" runat="server"></asp:Label><%--<%=request.form("currentbasicsalary")%>--%></div></td>
      <td style="height: 21px">&nbsp;</td>
    </tr>
    <tr>
      <td style="height: 21px">&nbsp;</td>
      <td style="height: 21px">&nbsp;</td>
      <td style="width: 203px; height: 21px"><strong>
          <asp:Label ID="lblpa" runat="server">Position Allowance</asp:Label></strong></td>
      <td class="style2" style="width: 34px; height: 21px">
          <asp:Label ID="parm" runat="server">RM</asp:Label>
      </td>
      <td class="style2" style="height: 21px">&nbsp;</td>
      <td class="style2" style="height: 21px">
          <div align="left">
              <asp:Label ID="pall" runat="server"></asp:Label><%--<%= request.form("positionallowance")%>--%>&nbsp;</div></td>
      <td style="height: 21px">&nbsp;</td>
    </tr>
        <tr>
            <td style="height: 12px">
            </td>
            <td style="height: 12px">
            </td>
            <td style="height: 12px">
            </td>
            <td class="style2" style="height: 12px">
            </td>
            <td class="style2" style="height: 12px">
            </td>
            <td class="style2" style="height: 12px">
            </td>
            <td style="height: 12px">
            </td>
        </tr>
    <tr>
      <td style="height: 21px">&nbsp;</td>
      <td style="height: 21px"><p>&nbsp;</td>
      <td style="width: 203px; height: 21px"><strong>
          <asp:Label ID="lblIA" runat="server">Increment Amount</asp:Label></strong></td>
      <td class="style2" style="width: 34px; height: 21px">
          <asp:Label ID="Iarm" runat="server">RM</asp:Label>
      </td>
      <td class="style2" style="height: 21px">&nbsp;</td>
      <td class="style2" style="height: 21px">
        <div align="left">
            <asp:Label ID="splinc" runat="server"></asp:Label><%--<%=request.form("incrementamt")%>--%></div></td>
      <td style="height: 21px">&nbsp;</td>
    </tr>
    
    <tr>
      <td style="height: 21px">&nbsp;</td>
      <td style="height: 21px">&nbsp;</td>
      <td style="width: 203px; height: 21px">&nbsp;</td>
      <td class="style2" style="width: 34px; height: 21px">&nbsp;</td>
      <td class="style2" style="height: 21px">&nbsp;</td>
      <td class="style2" style="height: 21px">&nbsp;</td>
      <td style="height: 21px">&nbsp;</td>
    </tr>
    <tr>
      <td style="height: 21px">&nbsp;</td>
      <td style="height: 21px">&nbsp;</td>
      <td style="width: 203px; height: 21px"><strong>
          <asp:Label ID="lblnba" runat="server">New Basic Salary</asp:Label></strong></td>
      <td class="style2" style="width: 34px; height: 21px">
          <asp:Label ID="nbarm" runat="server"> RM</asp:Label>&nbsp;</td>
      <td class="style2" style="height: 21px">&nbsp;</td>
      <td class="style2" style="height: 21px">
         <div align="left">
                    <asp:Label ID="nbsa" runat="server"></asp:Label><%--<%= request.form("newbasicsalary")%>--%></div></td>
      <td style="height: 21px">&nbsp;</td>
    </tr>
    
    <tr>
	<%--<%if request.form("positionallowance")<>"" then%>--%>
      <td style="height: 21px">&nbsp;</td>
      <td style="height: 21px">&nbsp;</td>
      <td style="width: 203px; height: 21px">
          <asp:Label ID="lblnpa" runat="server" Font-Bold="True">New Position Allowance</asp:Label></td>
      <td class="style2" style="width: 34px; height: 21px">
      <asp:Label ID="nparm" runat="server">RM</asp:Label></td>
      <td class="style2" style="height: 21px">&nbsp;</td>
      <td class="style2" style="height: 21px">
         <div align="left">
          <asp:Label ID="npall" runat="server"></asp:Label></div></td>
      <td style="height: 21px">&nbsp;</td>
	  <%--<%end if%>--%>
    </tr>
    <tr>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td style="width: 203px">&nbsp;</td>
      <td style="width: 34px">&nbsp;</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
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
      <td colspan="7"><p align="justify"> Thank you. </p></td>
    </tr>
    <tr class="style2">
      <td colspan="7"><div align="justify"></div></td>
    </tr>
    <tr class="style2">
      <td colspan="7"><p align="justify"> Yours faithfully, </p>
          <p align="justify">MARUWA ( MALAYSIA ) SDN BHD </p></td>
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
      <td colspan="7"><div align="justify"></div></td>
    </tr>
    <tr>
      <td height="15" colspan="3"><p align="justify">&nbsp;</p>
      </td>
      <td height="113" rowspan="7" style="width: 34px">&nbsp;</td>
      <td rowspan="7">&nbsp;</td>
      <td height="113" rowspan="7" valign="top"><img src="../../images/stamp.jpg" width="84" height="78"></td>
      <td height="113" rowspan="7">&nbsp;</td>
    </tr>
    <tr>
      <td height="15" colspan="3">&nbsp;</td>
    </tr>
    <tr>
      <td height="15" colspan="3">_______________________________________</td>
    </tr>
    <tr>
      <td height="15" colspan="3"><strong>DATUK MANIMARAN ANTHONY</strong></td>
    </tr>
    <tr>
      <td colspan="3" style="height: 15px">CHIEF EXECUTIVE OFFICER</td>
    </tr>
    <tr>
      <td height="15" colspan="3">&nbsp;</td>
    </tr>
    <tr>
      <td height="113" colspan="3">&nbsp;</td>
    </tr>
    
  </table>
    </form>
</body>
</html>
