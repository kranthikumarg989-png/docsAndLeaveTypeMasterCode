<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PromotionLetter.aspx.vb" Inherits="E_Management.PromotionLetter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Promotion Letter</title>
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
                      <td width="345"><a href="emp_main.asp"><img src="../../images/maruwaAnimLogo.gif" width="161" height="42" border="0"></a></td>
                     
                      <td width="62">Ref. No.:</td>
					 <%-- <%refno=day(date)&month(date)&"/"&request.form("empcode")%>--%>
                      <td width="131"><%--<%=refno%>--%>
                          <asp:Label ID="refno" runat="server"></asp:Label></td>
                    </tr>
                </table></td>
              </tr>
              <tr class="style2">
                <td><table width="609" border="0" cellspacing="0">
                    <tr>
                      <td>&nbsp;</td>
                      <td width="120">&nbsp;</td>
                      <td width="278">&nbsp;</td>
                      <td>&nbsp;</td>
                    </tr>
                    <tr>
                      <td width="44">&nbsp;</td>
                      <td colspan="2"><span class="style6">Name : 
                          <asp:Label ID="name" runat="server"></asp:Label><%--<%=request.form("empname")%>--%></span></td>
                      <td width="159"><span class="style6">Date : 
                          <asp:Label ID="ltdate" runat="server"></asp:Label><%--<%=newdate%>--%></span></td>
                    </tr>
                    <tr>
                      <td>&nbsp;</td>
                      <td colspan="2"><span class="style6">Emp. No. : 
                          <asp:Label ID="empno" runat="server"></asp:Label><%--<%=request.form("empcode")%>--%></span></td>
                      <td>&nbsp;</td>
                    </tr>
                    <tr>
                      <td height="23">&nbsp;</td>
                      <td colspan="2">Department : 
                          <asp:Label ID="dept" runat="server"></asp:Label><%--<%=olddept%>--%></td>
                      <td>&nbsp;</td>
                    </tr>
                    <tr>
                      <td style="height: 21px">&nbsp;</td>
                      <td colspan="2" style="height: 21px">Designation : 
                          <asp:Label ID="desig" runat="server" Font-Bold="False"></asp:Label><%--<%=olddesig%>--%></td>
                      <td style="height: 21px">&nbsp;</td>
                    </tr>
                </table></td>
              </tr>
              <tr class="style2">
                <td><table width="613" border="0" cellspacing="0">
                    <tr>
                      <td width="17">&nbsp;</td>
                      <td width="117">&nbsp;</td>
                      <td width="167">&nbsp;</td>
                      <td width="133">&nbsp;</td>
                      <td width="169">&nbsp;</td>
                    </tr>
                    <tr>
                      <td colspan="5"><div align="center"><strong><u>Ref : LETTER OF PROMOTION. </u></strong></div></td>
                    </tr>
                    <tr>
                      <td>&nbsp;</td>
                      <td>&nbsp;</td>
                      <td>&nbsp;</td>
                      <td>&nbsp;</td>
                      <td>&nbsp;</td>
                    </tr>
                    <tr>
                      <td>&nbsp;</td>
                      <td colspan="4"><p align="justify"> The Management would like to extend our greatest appreciation to you for being a dedicated staff and outstanding performer. </p></td>
                    </tr>
                    <tr>
                      <td>&nbsp;</td>
                      <td colspan="4"><div align="center"></div></td>
                    </tr>
                    <tr>
                      <td style="height: 40px">&nbsp;</td>
                      <td colspan="4" style="height: 40px"><p align="justify">It is with great pleasure to inform you that you had shown examplary performance and thus have developed yourself while serving the Company.</p></td>
                    </tr>
                    <tr>
                      <td>&nbsp;</td>
                      <td colspan="4">&nbsp;</td>
                    </tr>
                    <tr>
					<%--<%refno=day(date)&month(date)&"/"&request.form("empcode")%>--%>
                      <td style="height: 40px">&nbsp;</td>
                      <td colspan="4" style="height: 40px"><div align="justify">As such, effective from &nbsp;<asp:Label ID="dteff" runat="server" Font-Bold="True"></asp:Label>,the Management is pleased to promote you as a
                          <asp:Label ID="newdesig" runat="server" Font-Bold="True"></asp:Label>
                          and your monthly salary is as stipulated below <strong>: - </strong></div></td>
                    </tr>
                    <tr>
                      <td style="height: 21px">&nbsp;</td>
                      <td colspan="4" style="height: 21px">
                       
                        </td>
					</tr>
					<%--<%end if%>
					<%request.form("empcode")%>--%>
             <!--   or request.form("olddesignation")="Line Leader" or request.form("olddesignation")="Operator" or request.form("olddesignation")="Security Guard" or request.form("olddesignation")="Senior Clerk" or request.form("olddesignation")="Senior L/Leader" or request.form("olddesignation")="Technician" or request.form("olddesignation")="Cleaner" or request.form("olddesignation")="Asst Line Leader" or request.form("olddesignation")="Asst Technician" or request.form("olddesignation")="Warden" or request.form("olddesignation")="Receiptionist" or request.form("olddesignation")="Shift Leader")
				    <tr>
                      <td>&nbsp;</td>
                      <td colspan="4">As such, effective from <strong><%=refno%></strong>, the management is pleased to promote you as a </td>
                    </tr>
                    <tr>
                      <td>&nbsp;</td>
                      <td colspan="4"><strong><%=request.form("empname")%></strong> and being part of the Pay for Performance scheme. </td>
                    </tr>
                    <tr>
                      <td>&nbsp;</td>
                      <td colspan="4"><p>Your Monthly Salary is as below : </p>
                      </td>
                    </tr>-->
					<%'end if%>
                    <tr>
                      <td>&nbsp;</td>
                      <td colspan="4"><table width="454" border="0" cellspacing="0">
                        <tr>
                          <td>&nbsp;</td>
                          <td>&nbsp;</td>
                          <td>&nbsp;</td>
                          <td>&nbsp;</td>
                        </tr>
                        <tr>
                          <td height="26">&nbsp;</td>
                          <td>Old Basic Salary :</td>
                          <td>RM</td>
                          <td>&nbsp;<asp:Label ID="obs" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
						<%--<%refno=day(date)&month(date)&"/"&request.form("empcode")%>--%>
                          <td height="22">&nbsp;</td>
                          <td>Old Position Allowance :</td>
                          <td>RM</td>
                          <td>&nbsp;<asp:Label ID="opa" runat="server"></asp:Label></td>
                        </tr>  
						<%--<%end if%>    --%>                 
						 <%--<%if request.form("position")<>"" then%>--%>
						 <tr>
                          <td height="20">&nbsp;</td>
                          <td>PFP Allowance :</td>
                          <td>RM</td>
                          <td>&nbsp;<asp:Label ID="pfpall" runat="server"></asp:Label></td>
                        </tr>
						<%--<%end if%>--%>
                        <tr>
                          <td height="20">&nbsp;</td>
                          <td>&nbsp;</td>
                          <td>&nbsp;</td>
                          <td>&nbsp;</td>
                        </tr>
                        <tr>
                          <td width="127" height="26">&nbsp;</td>
                          <td width="165">New Basic Salary : </td>
                          <td width="18">RM</td>
                          <td width="92">&nbsp;<asp:Label ID="nbs" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
						<%--<%if request.form("position")<>"" then%>--%>
                          <td>&nbsp;</td>
                          <td>New Position Allowance : </td>
                          <td>RM</td>
                          <td>&nbsp;<asp:Label ID="npa" runat="server"></asp:Label></td>
                        </tr>
						<%--<%end if%>
						<%if request.form("pfp1")<>"" then%>--%>
                        <tr>
                          <td>&nbsp;</td>
                          <td>PFP Allowance :</td>
                          <td>RM</td>
                          <td>&nbsp;<asp:Label ID="npfpall" runat="server"></asp:Label></td>
                        </tr>
						<%--<%end if%>--%>
                        <tr>
                          <td>&nbsp;</td>
                          <td>&nbsp;</td>
                          <td colspan="1"><hr></hr></td>
                          <td>&nbsp;</td>
                        </tr>
                        <tr>
                          <td>&nbsp;</td>
                          <td>Total Salary : </td>
                          <td>RM</td>
                          <td>&nbsp;<asp:Label ID="totsal" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                          <td>&nbsp;</td>
                          <td>&nbsp;</td>
                          <td colspan="1"><hr></hr></td>
                          <td>&nbsp;</td>
                        </tr>
                      </table></td>
                    </tr>
					<%'if (request.form("olddesignation")="Clerk" or request.form("olddesignation")="Driver" or request.form("olddesignation")="Line Leader" or request.form("olddesignation")="Operator" or request.form("olddesignation")="Security Guard" or request.form("olddesignation")="Senior Clerk" or request.form("olddesignation")="Senior L/Leader" or request.form("olddesignation")="Technician" or request.form("olddesignation")="Cleaner" or request.form("olddesignation")="Asst Line Leader" or request.form("olddesignation")="Asst Technician" or request.form("olddesignation")="Warden" or request.form("olddesignation")="Receiptionist" or request.form("olddesignation")="Shift Leader") and (request.form("newdesignation")="Asst Engineer" or request.form("newdesignation")="Officer" or request.form("newdesignation")="Senior Technician" or request.form("newdesignation")="Asst Officer" or request.form("newdesignation")="Asst Supervisor" or request.form("newdesignation")="Supervisor" 
					 ' or request.form("newdesignation")="Senior Engineer" or request.form("newdesignation")="Senior Executive" or request.form("newdesignation")="Executive" or request.form("newdesignation")="Engineer" or request.form("newdesignation")="Senior Supervisor" or request.form("newdesignation")="Senior Officer" or request.form("newdesignation")="System Administrator" or request.form("newdesignation")="Personal Assistant" or request.form("newdesignation")="Senior Manager" or request.form("newdesignation")="Asst Manager" or request.form("newdesignation")="General Manager") then%>
					<!--or request.form("olddesignation")="Driver" or request.form("olddesignation")="Line Leader" or request.form("olddesignation")="Operator" or request.form("olddesignation")="Security Guard" or request.form("olddesignation")="Senior Clerk" or request.form("olddesignation")="Senior L/Leader" or request.form("olddesignation")="Technician" or request.form("olddesignation")="Cleaner" or request.form("olddesignation")="Asst Line Leader" or request.form("olddesignation")="Asst Technician" or request.form("olddesignation")="Warden" or request.form("olddesignation")="Receiptionist" or request.form("olddesignation")="Shift Leader"
                    <tr>
                      <td>&nbsp;</td>
                      <td colspan="4">In line with the management's effort to Pay for Performance, wa are pleased to announce that the PFP Allowance will be based on your monthly Performance achievement %, and your grading will be specify as below.</td>
                    </tr>
                    <tr>
                      <td>&nbsp;</td>
                      <td colspan="4">&nbsp;</td>
                    </tr>
                    <tr>
                      <td class="style2">&nbsp;</td>
                      <td class="style2">&nbsp;</td>
                      <td class="style2"><p align="center"><strong><u>PFP Achievement % </u></strong></p></td>
                      <td class="style2"><div align="center"><strong><u>Grade</u></strong></div></td>
                      <td class="style2">&nbsp;</td>
                    </tr>
                    <tr>
                      <td class="style2">&nbsp;</td>
                      <td class="style2">&nbsp;</td>
                      <td class="style2"><div align="center">100% ~ 95% </div></td>
                      <td class="style2"><div align="center">A</div></td>
                      <td class="style2">&nbsp;</td>
                    </tr>
                    <tr>
                      <td class="style2">&nbsp;</td>
                      <td class="style2">&nbsp;</td>
                      <td class="style2"><div align="center">94% ~ 85%</div></td>
                      <td class="style2"><div align="center">B</div></td>
                      <td class="style2">&nbsp;</td>
                    </tr>
                    <tr>
                      <td class="style2">&nbsp;</td>
                      <td class="style2">&nbsp;</td>
                      <td class="style2"><div align="center">84% ~ 75% </div></td>
                      <td class="style2"><div align="center">C</div></td>
                      <td class="style2">&nbsp;</td>
                    </tr>
                    <tr>
                      <td class="style2">&nbsp;</td>
                      <td class="style2">&nbsp;</td>
                      <td class="style2"><div align="center">74% ~ 65% </div></td>
                      <td class="style2"><div align="center">D</div></td>
                      <td class="style2">&nbsp;</td>
                    </tr>
                    <tr>
                      <td class="style2">&nbsp;</td>
                      <td class="style2">&nbsp;</td>
                      <td class="style2"><div align="center">64% ~ and below </div></td>
                      <td class="style2"><div align="center">E</div></td>
                      <td class="style2">&nbsp;</td>
                    </tr>-->
					<%'end if%>
                    <tr>
                      <td>&nbsp;</td>
                      <td colspan="4">&nbsp;</td>
                    </tr>
                    <tr>
                      <td>&nbsp;</td>
                      <td colspan="4"><p align="justify"> We trust that you will continue to grow in your career toward the progress of MARUWA (MALAYSIA) SDN. BHD. and its mutual benefit in years to come. </p></td>
                    </tr>
                    <tr>
                      <td>&nbsp;</td>
                      <td colspan="4">&nbsp;</td>
                    </tr>
                    <tr>
                      <td>&nbsp;</td>
                      <td colspan="4"><p> With our heartiest congratulation upon your promotion. </p></td>
                    </tr>
                    <tr>
                      <td style="height: 21px">&nbsp;</td>
                      <td colspan="4" style="height: 21px">&nbsp;</td>
                    </tr>
                    <tr>
                      <td>&nbsp;</td>
                      <td colspan="4">&nbsp;</td>
                    </tr>
                    <tr>
                      <td>&nbsp;</td>
                      <td colspan="4"><p> Yours Faithfully, </p></td>
                    </tr>
                    <tr>
                      <td>&nbsp;</td>
                      <td colspan="4">&nbsp;</td>
                    </tr>
                    <tr>
                      <td>&nbsp;</td>
                      <td colspan="4">&nbsp;</td>
                    </tr>
                    <tr>
                      <td>&nbsp;</td>
                      <td colspan="4">&nbsp;</td>
                    </tr>
                    <tr>
                      <td>&nbsp;</td>
                      <td colspan="4">_______________________________</td>
                    </tr>
                    <tr>
                      <td>&nbsp;</td>
                      <td colspan="4"><strong>Datuk Manimaran Anthony</strong></td>
                    </tr>
                    <tr>
                      <td>&nbsp;</td>
                      <td colspan="4">Chief Executive officer</td>
                    </tr>
                    <tr>
                      <td>&nbsp;</td>
                      <td colspan="4">&nbsp;</td>
                    </tr>
                </table></td>
              </tr>
              <tr>
                <td>&nbsp;</td>
              </tr>
            </table>			
    </form>
</body>
</html>
