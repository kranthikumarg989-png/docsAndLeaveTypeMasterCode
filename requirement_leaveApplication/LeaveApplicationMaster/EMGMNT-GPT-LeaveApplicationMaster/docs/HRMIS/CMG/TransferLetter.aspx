<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TransferLetter.aspx.vb" Inherits="E_Management.TransferLetter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Transfer Letter</title>
</head>
<body style="font-size: 12pt">
    <form id="form1" runat="server">
    <table width="612" border="0" cellspacing="0">
  <tr>
    <td colspan="4" class="style2"><div align="center"></div></td>
  </tr>
  <tr class="style2">
    <td colspan="4"><table width="610" border="0" cellspacing="0">
      <tr>
        <td style="width: 17px">&nbsp;</td>
        <td width="351"><a href="emp_main.asp"><img src="../../images/maruwaAnimLogo.gif" alt="Click Me to Exit" width="171" height="45" border="0"></a></td>
		
        <td style="width: 80px">
        </td>
		
        <td width="150">
            Ref.No.:
            <asp:Label ID="refno" runat="server"></asp:Label></tr>
    </table></td>
  </tr>
  <tr class="style2">
    <td colspan="4"><table width="609" border="0" cellspacing="0">
      <tr>
        <td style="width: 18px">&nbsp;</td>
        <td style="width: 32px" colspan="2" rowspan="1">&nbsp; &nbsp;&nbsp;</td>
          <td>
          </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td style="height: 20px; width: 18px;">&nbsp;</td>
        <td colspan="2" style="width: 32px;"><span class="style6">Name&nbsp;</span></td>
          <td colspan="1">
              :
            <asp:Label ID="name" runat="server"></asp:Label></td>
        <td width="149"><span class="style6">Date :</span><span class="style7"> 
            <asp:Label ID="letdt" runat="server"></asp:Label></span></td>
      </tr>
        <tr>
            <td style="width: 18px; height: 20px">
            </td>
            <td colspan="2" style="width: 32px">
                Emp.No.</td>
            <td colspan="1">
              :
            <asp:Label ID="empno" runat="server"></asp:Label></td>
            <td>
            </td>
        </tr>
      <tr>
        <td style="width: 18px; height: 20px">&nbsp;</td>
        <td colspan="2" style="width: 32px">Department</td>
          <td colspan="1">
              :
            <asp:Label ID="dept" runat="server"></asp:Label></td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td style="width: 18px; height: 20px">&nbsp;</td>
        <td colspan="2" style="width: 32px">Designation</td>
          <td colspan="1">
              :
            <asp:Label ID="desig" runat="server"></asp:Label></td>
        <td>&nbsp;</td>
      </tr>
    </table> </td>
  </tr>
  <tr class="style2">
    <td colspan="4"><table width="609" border="0" cellspacing="0">
      <tr>
        <td colspan="4">&nbsp;</td>
      </tr>
      <tr>
        <td colspan="4" style="height: 21px"><div align="center"><strong><U>Transfer to
            <asp:Label ID="deptname1" runat="server"></asp:Label>
            effective from
            <asp:Label ID="efffrom" runat="server"></asp:Label></u></strong></div></td>
        </tr>
      <tr>
        <td style="width: 1px">&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td style="width: 1px">&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td style="width: 1px; height: 40px;">&nbsp;</td>
        <td colspan="3" style="height: 40px">We wish to inform you that our discussion with your goodself, the management has decided to transfer you from :</td>
        </tr>
      <tr>
        <td style="width: 1px">&nbsp;</td>
        <td colspan="3">&nbsp;</td>
      </tr>
      <tr>
        <td style="height: 21px; width: 1px;">&nbsp;</td>
        <td colspan="3" style="height: 21px; text-align: center;"> 
            <strong></strong><asp:Label ID="dept1" runat="server" Font-Bold="True"></asp:Label><strong>
                - </strong>
            <asp:Label ID="deptname" runat="server"></asp:Label>
            (<span style="font-size: 10pt">Sect :<strong>
            </strong></span>
            <asp:Label ID="sect" runat="server" Font-Bold="False" Font-Size="12px"></asp:Label><span
                style="font-size: 10pt"><strong> </strong></span>)<strong>&nbsp; <span style="font-size: 11pt">
                    TO</span> &nbsp;</strong><asp:Label
                ID="newdeptcode1" runat="server" Font-Bold="True"></asp:Label><strong> - &nbsp;</strong><asp:Label
                    ID="newdeptname1" runat="server"></asp:Label><strong> </strong>(<span style="font-size: 10pt">Sect
                        : </span>
            <asp:Label ID="newsect" runat="server" Font-Bold="False" Font-Size="12px"></asp:Label>)</td>
      </tr>
      <tr style="font-size: 12pt">
        <td style="height: 21px; width: 1px;">&nbsp;</td>
        <td colspan="3" style="height: 21px">&nbsp;</td>
      </tr>
      <tr style="font-size: 12pt">
        <td style="width: 1px">&nbsp;</td>
        <td colspan="3">There will be no changes in your terms and condition of employment. </td>
      </tr>
      <tr style="font-size: 12pt">
        <td style="width: 1px">&nbsp;</td>
        <td colspan="3">&nbsp;</td>
      </tr>
      <tr style="font-size: 12pt">
        <td style="width: 1px">&nbsp;</td>
        <td colspan="3"><div align="justify">Our decision of your transfer was based on your experience to support 
            <asp:Label ID="newdeptname" runat="server" Font-Bold="True"></asp:Label>
            -
            <asp:Label ID="newdeptcode" runat="server" Font-Bold="True"></asp:Label><%--<%=request.form("newdepartmentcode")%>)--%>
            department. This is also in line with our mission to put the &quot;Right Employee In The Right Place".</div></td>
      </tr>
      <tr style="font-size: 12pt">
        <td style="width: 1px">&nbsp;</td>
        <td colspan="3">&nbsp;</td>
      </tr>
      <tr style="font-size: 12pt">
        <td style="height: 21px; width: 1px;">&nbsp;</td>
        <td colspan="3" style="height: 21px">We can count on you to give your continued support to MARUWA. </td>
      </tr>
      <tr style="font-size: 12pt">
        <td style="width: 1px">&nbsp;</td>
        <td colspan="3">&nbsp;</td>
      </tr>
      <tr style="font-size: 12pt">
        <td style="width: 1px">&nbsp;</td>
        <td colspan="3">Thank you</td>
      </tr>
      <tr style="font-size: 12pt">
        <td style="width: 1px">&nbsp;</td>
        <td colspan="3">&nbsp;</td>
      </tr>
      <tr style="font-size: 12pt">
        <td style="width: 1px">&nbsp;</td>
        <td colspan="3">&nbsp;</td>
      </tr>
      <tr style="font-size: 12pt">
        <td style="width: 1px">&nbsp;</td>
        <td colspan="3">_______________________________</td>
      </tr>
      <tr style="font-size: 12pt">
        <td style="width: 1px">&nbsp;</td>
        <td colspan="3">
            <strong>SATHIASEELAN A/L M.SATIAH</strong></td>
      </tr>
      <tr style="font-size: 12pt">
        <td style="height: 21px; width: 1px;">&nbsp;</td>
        <td colspan="3" style="height: 21px">
            Director</td>
      </tr>
      <tr style="font-size: 12pt">
        <td style="width: 1px">&nbsp;</td>
        <td colspan="3">&nbsp;</td>
      </tr>
      <tr style="font-size: 12pt">
        <td style="width: 1px">&nbsp;</td>
        <td colspan="3"><hr align=left width=510></td>
      </tr>
      <tr style="font-size: 12pt">
        <td style="width: 1px">&nbsp;</td>
        <td colspan="3" rowspan="2"><div align="justify">I 
            <asp:Label ID="empname1" runat="server"></asp:Label>
          
            (NRIC /Passport No.<asp:Label ID="ppno" runat="server"></asp:Label>)
          hereby agree for the above transfer. </div></td>
      </tr>
      <tr style="font-size: 12pt">
        <td style="height: 21px; width: 1px;">&nbsp;</td>
        </tr>
      <tr style="font-size: 12pt">
        <td style="height: 21px; width: 1px;">&nbsp;</td>
        <td colspan="3" style="height: 21px">&nbsp;</td>
      </tr>
      <tr style="font-size: 12pt">
        <td style="width: 1px">&nbsp;</td>
        <td colspan="3">&nbsp;</td>
      </tr>
      <tr style="font-size: 12pt">
        <td style="width: 1px">&nbsp;</td>
        <td colspan="3">Signature : ___________________________</td>
      </tr>
      <tr style="font-size: 12pt">
        <td style="width: 1px">&nbsp;</td>
        <td colspan="3">&nbsp;</td>
      </tr>
      <tr style="font-size: 12pt">
        <td style="width: 1px">&nbsp;</td>
        <td colspan="3">Date &nbsp; &nbsp; &nbsp;&nbsp; : ___________________________</td>
      </tr>
    </table></td>
    </tr>
  <tr class="style2" style="font-size: 12pt">
    <td colspan="4">&nbsp;</td>
    </tr>
  <tr style="font-size: 12pt">
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td width="455">&nbsp;</td>
    <td width="455">&nbsp;</td>
  </tr>
</table>
    </form>
</body>
</html>
