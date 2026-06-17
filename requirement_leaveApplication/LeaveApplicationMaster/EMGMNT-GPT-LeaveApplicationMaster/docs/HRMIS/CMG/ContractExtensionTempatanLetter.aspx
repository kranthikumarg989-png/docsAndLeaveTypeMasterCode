<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="COntractExtensionTempatanLetter.aspx.vb" Inherits="E_Management.COntractExtensionTempatanLetter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CONTRACT EXTENSION TEMPATAN LETTER</title>
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
              <%--<% 
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
              <td>&nbsp;</td>
              <td width="120">&nbsp;</td>
              <td width="253">&nbsp;</td>
              <td>&nbsp;</td>
            </tr>
            <tr>
              <td>&nbsp;</td>
              <td>&nbsp;</td>
              <td>&nbsp;</td>
              <td>&nbsp;</td>
            </tr>
            <tr>
              <td width="44">&nbsp;</td>
              <td colspan="2"><span class="style6">Nama : 
                  <asp:Label ID="name" runat="server"></asp:Label><%--<%=request.form("empname")%>--%></span></td>
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
              <td width="184"><span class="style6">Tarikh : 
                  <asp:Label ID="ltdate" runat="server"></asp:Label><%--<%=newdate%>--%></span></td>
            </tr>
            <tr>
              <td>&nbsp;</td>
              <td colspan="2"><span class="style6"> No. Pekerja: 
                  <asp:Label ID="empcode" runat="server"></asp:Label><%--<%=request.form("empcode")%>--%></span></td>
              <td>&nbsp;</td>
            </tr>
            <tr>
              <td>&nbsp;</td>
              <td colspan="2">Bahagian :  
                  <asp:Label ID="dept" runat="server"></asp:Label><%--<%=request.form("olddesignation")%>--%></td>
              <td>&nbsp;</td>
            </tr>
        </table></td>
      </tr>
      <tr class="style2">
        <td colspan="4"><table width="609" border="0" cellspacing="0">
            <tr>
              <td width="18">&nbsp;</td>
              <td width="281">&nbsp;</td>
              <td width="231">&nbsp;</td>
              <td width="71">&nbsp;</td>
            </tr>
            <tr>
              <td height="17" colspan="4"><div align="center"><u class="style6">Surat Lanjutan Kontrak Perkhidmatan(Tempatan)</u></div></td>
            </tr>
            <tr>
              <td>&nbsp;</td>
              <td>&nbsp;</td>
              <td>&nbsp;</td>
              <td>&nbsp;</td>
            </tr>
            <tr>
              <td style="height: 59px">&nbsp;</td>
              <td colspan="3" style="height: 59px"><p align="justify"> Seperti mana yang anda sedia maklum tempoh percubaan selama &nbsp;3
                  &nbsp;<%--<%=request.form("ayooprob")%> --%>bulan dari 
                  <asp:Label ID="doj" runat="server"></asp:Label><strong><%--<%=day((dateofjoin))&"/"&month((dateofjoin))&"/"&year((dateofjoin))%>--%>&nbsp; </strong>telah pun tamat, dengan ini sukacita dimaklumkan bahawa jawatan anda sebegai operator
                  telah disahkan berkuatkuasa mulai <span class="style7"><asp:Label ID="frmdt" runat="server"></asp:Label>.</span><%--<%=request.form("date5mal")%>--%></p></td>
            </tr>
            <tr>
              <td>&nbsp;</td>
              <td colspan="3">&nbsp;</td>
            </tr>
            <tr>
              <td>&nbsp;</td>
              <td colspan="3"><p align="justify"> Dengan ini pihak pengurusan mengucapkan tahniah dan berharap anda akan lebih berusaha dalam mencapai visi syarikat. </p></td>
            </tr>
            <tr>
              <td style="height: 21px">&nbsp;</td>
              <td colspan="3" style="height: 21px">&nbsp;</td>
            </tr>
            <tr>
              <td>&nbsp;</td>
              <td colspan="3"><p>&nbsp; </p></td>
            </tr>
            <tr>
              <td>&nbsp;</td>
              <td colspan="3">Yang benar, </td>
            </tr>
            <tr>
              <td>&nbsp;</td>
              <td>&nbsp;</td>
              <td><div align="right">
                  <br />
                  <br />
                  <br />
                  &nbsp;</div></td>
              <td>&nbsp;</td>
            </tr>
            <tr>
              <td>&nbsp;</td>
              <td colspan="3">__________________________________</td>
            </tr>
            <tr>
              <td>&nbsp;</td>
              <td colspan="3"><strong>Datuk Manimaran Anthony</strong></td>
            </tr>
            <tr>
              <td>&nbsp;</td>
              <td colspan="3">PENASIHAT EKSEKUTIF </td>
            </tr>
        </table>
    </form>
</body>
</html>
