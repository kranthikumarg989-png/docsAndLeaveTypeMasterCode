<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="COntractExtensionPFPletter.aspx.vb" Inherits="E_Management.COntractExtensionPFPletter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Contract Extension PFP Letter</title>
</head>
<body>
    <form id="form1" runat="server">
   <table width="628" border="0" cellspacing="0">
      <tr class="style2">
        <td width="31">&nbsp;</td>
        <td width="607"><table width="586" border="0" cellspacing="0">
            <tr>
              <td width="206"><img src="../../images/maruwaAnimLogo.gif" height="37"></td>
              <td width="144"><div align="right"> </div></td>
              <td width="216"><div align="center"></div></td>
              <td width="12">&nbsp;</td>
            </tr>
        </table></td>
      </tr>
      <tr class="style2">
        <td>&nbsp;</td>
        <td><table width="589" border="0" cellspacing="0">
            <tr>
              <td colspan="2" class="style2"><div align="center" class="style10"><strong>TO WHOM IT MAY CONCERN </strong></div></td>
            </tr>
            <tr>
              <td class="style2">&nbsp;</td>
              <td style="width: 256px">    
          </tr>
            <tr>
              <td width="364" class="style2">&nbsp;</td>
              <td style="width: 256px"><span class="style12"><strong>Date</strong></span><strong>: 
                  <asp:Label ID="ltdt" runat="server" Font-Bold="False"></asp:Label></strong><%--<%=request.Form("vdate")%>--%></tr>
        </table></td>
      </tr>
      <tr class="style2">
        <td>&nbsp;</td>
        <td><table width="686" border="0" cellspacing="0">
            <tr>
              <td colspan="5"><p class="style2"> Dear Sir/Madam,</p></td>
            </tr>
            <tr>
              <td colspan="5" class="style2"><p>&nbsp; </p></td>
            </tr>
            <tr>
              <td colspan="5" class="style2"><div align="justify" style="text-align: center">Re:<strong>LETTER OF EXTENSION CONTRACT EMPLOYMENT </strong></div></td>
            </tr>
            <tr>
              <td colspan="5" class="style2">&nbsp;</td>
            </tr>
            <tr>
              <td colspan="3" class="style2" style="height: 21px"><strong>Name :</strong> 
                  <asp:Label ID="name" runat="server" Font-Bold="False"></asp:Label><%--<%=request.form("empname")%>--%></td>
              <td colspan="2" class="style2" style="height: 21px">&nbsp;</td>
            </tr>
            <tr>
              <td colspan="5" class="style2" style="height: 21px"><strong>Emp. No : 
                  <asp:Label ID="empcode" runat="server" Font-Bold="False"></asp:Label></strong><%--<%=request.form("empcode")%>--%></td>
            </tr>
            <tr>
              <td colspan="5" class="style2"><strong>Department :</strong> 
                  <asp:Label ID="dept" runat="server" Font-Bold="False"></asp:Label><%--<%=olddept%>--%></td>
            </tr>
            <tr>
              <td colspan="5" class="style2"><strong>Designation : 
                  <asp:Label ID="desig" runat="server" Font-Bold="False"></asp:Label></strong><%--<%=desig%>--%></td>
            </tr>
            <tr>
              <td colspan="5" class="style2" style="height: 21px"><strong>Date Hired : 
                  <asp:Label ID="doj" runat="server" Font-Bold="False"></asp:Label></strong><%--<%=dateofjoin%>--%></td>
            </tr>
            <tr>
              <td colspan="5" class="style2"><strong>NRIC NO : 
                  <asp:Label ID="nric" runat="server" Font-Bold="False"></asp:Label></strong><%--<%=request.form ("nricno")%>--%></td>
            </tr>
            <tr>
              <td colspan="5" class="style2"></td>
            </tr>
            <tr>
              <td colspan="5" class="style2"></td>
            </tr>
            <tr>
              <td colspan="5" class="style2" style="height: 21px"><div align="justify">We are pleased to inform that your Contract Employment is extended for
                  <asp:Label ID="months" runat="server"></asp:Label>
                 <%-- <%=request.form("extended")%> --%>month (s) effective from 
                  <asp:Label ID="efffrom" runat="server"></asp:Label>
                 <%-- <%=request.Form("FromDate")%>--%>
                  to
                  <asp:Label ID="effto" runat="server"></asp:Label><%--<%=request.Form("ToDate")%>--%>. </div></td>
            </tr>
            <tr>
              <td colspan="5" class="style2"><div align="justify">&nbsp;</div></td>
            </tr>
            <tr>
              <td colspan="5" class="style2"><div align="justify">The management also would like to extend it's greatest appreciation to you for being part of the Pay for Performance scheme and will be given a provisional allowance of RM 
                  <asp:Label ID="posall1" runat="server"></asp:Label>
                 <%-- <%=request.form("Amount")%>--%> with effect from <%--<%=request.Form("FromDate")%>--%> which will be based on your performance achievement. </div></td>
            </tr>
            <tr>
              <td colspan="5" class="style2">&nbsp;</td>
            </tr>
            <tr>
              <td width="85" class="style2">&nbsp;</td>
              <td width="191" class="style2"><p align="center"><strong><u>Performance</u></strong></p></td>
              <td width="113" class="style2"><div align="center"><strong><u>Grade</u></strong></div></td>
              <td colspan="2" class="style2"><strong><u>PFP Achievement % </u></strong></td>
            </tr>
            <tr>
              <td class="style2">&nbsp;</td>
              <td class="style2"><div align="center">100</div></td>
              <td class="style2"><div align="center">A</div></td>
              <td width="135" class="style2"><div align="center">100%</div></td>
              <td width="152" class="style2">&nbsp;</td>
            </tr>
            <tr>
              <td class="style2">&nbsp;</td>
              <td class="style2"><div align="center">80 ~ 99</div></td>
              <td class="style2"><div align="center">B</div></td>
              <td class="style2"><div align="center">80%</div></td>
              <td class="style2">&nbsp;</td>
            </tr>
            <tr>
              <td class="style2">&nbsp;</td>
              <td class="style2"><div align="center">79 ~ 60</div></td>
              <td class="style2"><div align="center">C</div></td>
              <td class="style2"><div align="center">60%</div></td>
              <td class="style2">&nbsp;</td>
            </tr>
            <tr>
              <td class="style2">&nbsp;</td>
              <td class="style2"><div align="center">59 ~ 40 </div></td>
              <td class="style2"><div align="center">D</div></td>
              <td class="style2"><div align="center">5%</div></td>
              <td class="style2">&nbsp;</td>
            </tr>
            <tr>
              <td class="style2">&nbsp;</td>
              <td class="style2"><div align="center">39 ~ and below </div></td>
              <td class="style2"><div align="center">E</div></td>
              <td class="style2"><div align="center">5%</div></td>
              <td class="style2">&nbsp;</td>
            </tr>
            <tr>
              <td class="style2">&nbsp;</td>
              <td class="style2"><div align="center"></div></td>
              <td class="style2"><div align="center"></div></td>
              <td class="style2"><div align="center"></div></td>
              <td class="style2">&nbsp;</td>
            </tr>
            <tr>
				 <%-- <% if request.form("salary")<>"" and request.form("increment")<>"" and request.form("newsalary")<>"" and request.form("pallowance")<>"" then %>--%>
              <td colspan="5" class="style2">We will also like to inform you that with effect from <%--<%=request.Form("FromDate")%>--%>, your salary will be adjusted as follow : </td>
            </tr>
            <tr>
              <td colspan="5" class="style2">&nbsp;</td>
            </tr>
            <tr>
              <td class="style2">&nbsp;</td>
              <td class="style2">Basic Salary </td>
              <td class="style2"> <div align="left">RM
                  <asp:Label ID="bassal" runat="server"></asp:Label><%--<%=request.form("salary")%>--%></div></td>
              <td colspan="2" class="style2">&nbsp; </td>
            </tr>
            <tr>
              <td class="style2">&nbsp;</td>
              <td class="style2">Special Increment Amount </td>
              <td class="style2"> <div align="left">RM
                  <asp:Label ID="splinc" runat="server"></asp:Label><%--<%=request.form("increment")%>--%></div></td>
              <td colspan="2" class="style2">&nbsp; </td>
            </tr>
            <tr>
              <td class="style2">&nbsp;</td>
              <td class="style2">New Basic Salary </td>
              <td class="style2"> <div align="left">RM
                  <asp:Label ID="nbasicsal" runat="server"></asp:Label><%--<%=request.form("newsalary")%>--%></div></td>
              <td colspan="2" class="style2">&nbsp; </td>
            </tr>
            <tr>
              <td class="style2">&nbsp;</td>
              <td class="style2">Position Allowance </td>
              <td class="style2"> <div align="left">RM
                  <asp:Label ID="posall" runat="server"></asp:Label><%--<%=request.form("pallowance")%>--%></div></td>
              <td colspan="2" class="style2">&nbsp; </td>
            </tr>
			<%--<%end if%>--%>
            <tr>
              <td colspan="5" class="style2">&nbsp;</td>
            </tr>
            <tr>
              <td colspan="5" class="style2">&nbsp;</td>
            </tr>
            <tr>
              <td colspan="5" class="style2"><div align="justify">All terms and conditions of service as conveyed to you in your formal letter of appointment will continue to be effective. </div></td>
            </tr>
            <tr>
              <td colspan="5" class="style2"><div align="justify">&nbsp;</div></td>
            </tr>
            <tr>
              <td colspan="5" class="style2"><div align="justify">We trust that you will continue to grow your career towards the progress of Maruwa ( Malaysia ) Sdn Bhd and mutually benefit in years to come. </div></td>
            </tr>
            <tr>
              <td colspan="5" class="style2"><div align="justify">&nbsp;</div></td>
            </tr>
            <tr>
              <td colspan="5" class="style2">Our heartiest congratulation. </td>
            </tr>
            <tr>
              <td colspan="5" class="style2">&nbsp;</td>
            </tr>
            <tr>
              <td colspan="5" class="style2">Thank you. </td>
            </tr>
            <tr>
              <td colspan="5" class="style2">&nbsp;</td>
            </tr>
            <tr>
              <td colspan="5" class="style2">Yours faithfully, </td>
            </tr>
            <tr>
              <td colspan="5" class="style2"><p>&nbsp; </p></td>
            </tr>
            <tr>
              <td colspan="5" class="style2"><p><em> </em><strong>MARUWA ( MALAYSIA) SDN BHD </strong></p>
                  <strong> </strong></td>
            </tr>
            <tr>
              <td colspan="5" class="style2">&nbsp;</td>
            </tr>
            <tr>
              <td colspan="5" class="style2">&nbsp;</td>
            </tr>
            <tr>
              <td colspan="5" class="style2"><p> ________________________________</p></td>
            </tr>
            <tr>
              <td colspan="5" class="style2"><strong>DATUK MANIMARAN ANTHONY </strong></td>
            </tr>
            <tr>
              <td colspan="5" class="style2"><p><strong>EXECUTIVE ADVISOR </strong></p></td>
            </tr>
            <tr>
              <td colspan="5" class="style2">&nbsp;</td>
            </tr>
            <tr>
              <td colspan="5" class="style2"><p align="center"><strong>MARUWA( MALAYSIA) SDN.BHD</strong> </p></td>
            </tr>
            <tr>
              <td colspan="5" class="style2"><p align="center">(191424-X) </p></td>
            </tr>
            <tr>
              <td colspan="5" class="style2"><p align="center">Lot 27&amp;28 Kawasan Perindustrian Batu Berendam, Phase 3, 75350 Melaka </p></td>
            </tr>
            <tr>
              <td colspan="5" class="style2"><div align="center">Tel : 06-2848977 Fax : 06-2814194 </div></td>
            </tr>
        </table>
    </form>
</body>
</html>
