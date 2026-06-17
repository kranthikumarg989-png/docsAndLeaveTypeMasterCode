<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="IncrementLetter.aspx.vb" Inherits="E_Management.IncrementLetter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Increment Letter</title>
</head>
<body>
    <form id="form1" runat="server">
     <table width="642" border="0" cellspacing="0">
     <tr>
      <td colspan="4"><img src="../../images/maruwaAnimLogo.gif" width="158" height="39"></td>
         <td style="width: 109px; text-align: right">
             Ref. No.:</td>
         <td width="131">
             <%--<%=refno%>--%>
             <asp:Label ID="refno" runat="server"></asp:Label></td>
    </tr>
     <tr>
       <td colspan="6">&nbsp;<table border="0" cellspacing="0" style="width: 639px">
               <tr>
                   <td>
                       &nbsp;</td>
                   <td width="120">
                       &nbsp;</td>
                   <td width="278">
                       &nbsp;</td>
                   <td>
                       &nbsp;</td>
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
                       <asp:Label ID="dept" runat="server"></asp:Label><%--<%=olddept%>--%&gt;</TD><TD __designer:dtid="1688914284773403"> </TD><TD __designer:dtid="1688914284773405"> </TD><TD colSpan=2 __designer:dtid="1688914284773406">Designation : <asp:Label id="desig" __designer:dtid="1688914284773407" runat="server" Font-Bold="False"></asp:Label><%--<%=olddesig%>--%></td>
                   <td>
                       &nbsp;</td>
               </tr>
               <tr>
                   <td height="23">
                   </td>
                   <td colspan="2">
                       Designation :
                       <asp:Label ID="desig" runat="server"></asp:Label></td>
                   <td>
                   </td>
               </tr>
           </table>
       </td>
     </tr>
    <tr>
      <td colspan="6"><div align="center"><strong class="style2">INCREMENT </strong></div></td>
    </tr>
    <tr>
      <td colspan="6">&nbsp;</td>
    </tr>
    
    <tr class="style2">
      <td colspan="6"><div align="justify"><span class="style2">The Management would like to extend it's greatest appreciation to you for being an sincere and honorable staff throughout the year. </span></div></td>
    </tr>
    <tr class="style2">
      <td colspan="6"><div align="left"><span class="style13"><span class="style16"><span class="style17"><span class="style16"><span class="style21"><span class="style24"><span class="style24"><span class="style16"><span class="style16"><span class="style28"><span class="style28"></span></span></span></span></span></span></span></span></span></span></span></div></td>
    </tr>
    <tr class="style2">
      <td height="23" colspan="6"><div align="justify">As staff of the company, you had shown examplary performance and having put continuous effort towards the growth of the company. </div></td>
    </tr>
    <tr class="style2">
      <td height="47" colspan="6"><div align="justify"><span class="style2">On behalf of the board, the management is pleased to award you an increment as follows effective
          from 
          <asp:Label ID="effdate" runat="server"></asp:Label>&nbsp;<%=request.form("edate")%></span></div></td>
    </tr>
    <tr>
      <td width="31">&nbsp;</td>
      <td width="93"><div align="left"></div></td>
      <td width="178">&nbsp;</td>
      <td style="width: 31px"><div align="right"></div></td>
      <td style="width: 109px" >&nbsp;</td>
     <%-- <% a = trim(request.form("currentbasicsalary"))%>--%>
      <td width="104" ><div align="right"></div></td>
    </tr>
    <tr>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td><strong>Basic Salary </strong></td>
      <td class="style2" style="width: 31px"><div align="right">RM</div></td>
      <td class="style2" style="width: 109px">&nbsp;<asp:Label ID="bsa" runat="server"></asp:Label></td>
      <td class="style2"><div align="left"></div>
        <div align="left"><%--<%=request.form("currentbasicsalary")%>--%></div></td>
    </tr>
    <tr>
      <td>&nbsp;</td>
      <td><p>&nbsp; </p></td>
      <td><strong>Special Increment Amount </strong></td>
      <td class="style2" style="width: 31px"><div align="right">RM </div></td>
      <td class="style2" style="width: 109px">&nbsp;<asp:Label ID="splinc" runat="server"></asp:Label></td>
      <td class="style2"><div align="left"></div>
        <div align="left"><%--<%=request.form("incrementamt")%>--%></div></td>
    </tr>
    
    <tr>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td class="style2" style="width: 31px">&nbsp;</td>
      <td class="style2" style="width: 109px">&nbsp;</td>
      <td class="style2">&nbsp;</td>
    </tr>
    <tr>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td><strong>New Basic Salary </strong></td>
      <td class="style2" style="width: 31px"><div align="right">RM </div></td>
      <td class="style2" style="width: 109px">&nbsp;<asp:Label ID="nbsa" runat="server"></asp:Label></td>
      <td class="style2"><div align="left"></div>
        <div align="left"><%--<%= request.form("newbasicsalary")%>--%></div></td>
    </tr>
    
    <tr>
	<%--<%if request.form("positionallowance")<>"" then%>--%>
      <td>&nbsp;</td>
      <td><p>&nbsp; </p></td>
      <td>
          <asp:Label ID="posallow" runat="server" Font-Bold="True"></asp:Label></td>
      <td class="style2" style="width: 31px"><div align="right" style="text-align: right">
          <asp:Label ID="curr" runat="server"></asp:Label>&nbsp;</div></td>
      <td class="style2" style="width: 109px">&nbsp;<asp:Label ID="pall" runat="server"></asp:Label></td>
      <td class="style2"><div align="left"></div>
        <div align="left"><%--<%= request.form("positionallowance")%>--%></div></td>
	  <%--<%end if%>--%>
    </tr>
    
   
    <tr>
		  <%--<%
	   if request.form("pfpallowance")<>"" then
	  %>--%>
      <td>&nbsp;</td>
      <td>&nbsp;</td>

      <td>
          <asp:Label ID="pfpallow" runat="server" Font-Bold="True"></asp:Label></td>
      <td style="width: 31px"> <div align="right" style="text-align: right">
          <asp:Label ID="curr1" runat="server"></asp:Label>&nbsp;</div></td>
      <td style="width: 109px">&nbsp;<asp:Label ID="pfpall" runat="server"></asp:Label></td>
      <td><div align="left"></div>
        <div align="left"><%--<%= request.form("pfpallowance")%>--%></div></td>
	   <%--<%end if%>--%>
    </tr>
    <tr>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td>&nbsp;</td>
      <td style="width: 31px">&nbsp;</td>
      <td style="width: 109px">&nbsp;</td>
      <td>&nbsp;</td>
    </tr>
    <tr class="style2">
      <td colspan="6"><div align="justify">We trust that you will continue to grow career towards the progress of Maruwa(M) SDN. BHD in the coming years. </div></td>
    </tr>
    <tr class="style2">
      <td colspan="6">&nbsp;</td>
    </tr>
    <tr class="style2">
      <td colspan="6">Our heartiest congratulations. </td>
    </tr>
    <tr class="style2">
      <td colspan="6">&nbsp;</td>
    </tr>
    <tr class="style2">
      <td colspan="6"><p align="justify"> Thank you. </p></td>
    </tr>
    <tr class="style2">
      <td colspan="6"><div align="justify"></div></td>
    </tr>
    <tr class="style2">
      <td colspan="6"><p align="justify"> Yours faithfully, </p>
          <p align="justify">MARUWA ( MALAYSIA ) SDN BHD </p></td>
    </tr>
    <tr>
      <td colspan="6">&nbsp;</td>
    </tr>
    <tr>
      <td colspan="6">&nbsp;</td>
    </tr>
    <tr>
      <td colspan="6">&nbsp;</td>
    </tr>
    <tr>
      <td colspan="6"><div align="justify"></div></td>
    </tr>
    <tr>
      <td colspan="6"><div align="justify"></div></td>
    </tr>
    <tr>
      <td colspan="6"><div align="justify"></div></td>
    </tr>
    <tr>
      <td height="15" colspan="3"><p align="justify">&nbsp;</p>
      </td>
      <td height="113" rowspan="7" style="width: 31px">&nbsp;</td>
      <td rowspan="7" style="width: 109px">&nbsp;</td>
      <td height="113" rowspan="7" valign="top"><img src="../../images/stamp.jpg" width="84" height="78"></td>
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
      <td height="15" colspan="3">CHIEF EXECUTIVE OFFICER</td>
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
