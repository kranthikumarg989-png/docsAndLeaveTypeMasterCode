<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ContractExtensionWargaLetter.aspx.vb" Inherits="E_Management.ContractExtensionWargaLetter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Contract Extension (Warga Asing) Letter</title>
</head>
<body>
    <form id="form1" runat="server">
   <table width="612" border="0" cellspacing="0" class="style2">
          <tr>
            <td width="5">&nbsp;</td>
            <td width="194"><a href="emp_main.asp"><img src="../../images/maruwaAnimLogo.gif" width="161" height="42" border="0"></a></td>
            <td width="196">&nbsp;</td>
            <td width="209">&nbsp;Ref No :
                <asp:Label ID="refno" runat="server"></asp:Label></td>
          </tr>
          <tr>
            <td height="17" colspan="4"><table width="609" border="0" cellspacing="0">
              <tr>
                <td style="height: 22px">&nbsp;</td>
                <td width="120" style="height: 22px">&nbsp;</td>
                <td style="width: 175px; height: 22px">&nbsp;</td>
                <td style="height: 22px">&nbsp;</td>
              </tr>
              <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td style="width: 175px">&nbsp;</td>
                <td>&nbsp;</td>
              </tr>
              <tr>
                <td width="44">&nbsp;</td>
                <td colspan="2"><span class="style6">Nama : 
                    <asp:Label ID="name" runat="server"></asp:Label><%--<%=request.form("empname")%>--%></span></td>
                <%--<% 
         
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
                <td style="height: 21px">&nbsp;</td>
                <td colspan="2" style="height: 21px"><span class="style6"> No. Pekerja: 
                    <asp:Label ID="empcode" runat="server"></asp:Label><%--<%=request.form("empcode")%>--%></span></td>
                <td style="height: 21px">&nbsp;</td>
              </tr>
              <tr>
                <td style="height: 21px">&nbsp;</td>
                <td colspan="2" style="height: 21px">Bahagian : 
                    <asp:Label ID="desig" runat="server"></asp:Label>
                    </td>
                <td style="height: 21px">&nbsp;</td>
              </tr>
            </table></td>
          </tr>
          <tr>
            <td height="17" colspan="4">&nbsp;</td>
          </tr>
          <tr>
            <td height="17" colspan="4"><div align="center"><u class="style6 style8">Surat Lanjutan Kontrak Perkhidmatan(Warga Asing)</u></div></td>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td style="height: 59px">&nbsp;</td>
            <td colspan="3" style="height: 59px"><p align="justify"> Seperti mana yang anda sedia maklum tempoh Kontrak Perkhidmatan selama 
                <asp:Label ID="contperiod" runat="server"></asp:Label>&nbsp;<%--<%=contractpre%>--%> bulan dari
                <%--<%=day((dateofjoin))&"/"&month((dateofjoin))&"/"&year((dateofjoin))%>--%>
                <asp:Label ID="doj" runat="server"></asp:Label>&nbsp;hingga
                <asp:Label ID="dteff" runat="server"></asp:Label><strong>
                    <%--<%=request.form("date7mal")%>--%> </strong>telah pun tamat, dengan ini sukacita dimaklumkan bahawa kontrak perkhidmatan anda akan dilanjutkan selama 
                <asp:Label ID="extmonths" runat="server"></asp:Label>
                <strong><%--<%=request.form("extendmonth")%>--%></strong> bulan dari<strong> &nbsp;<asp:Label ID="dtfrom" runat="server"></asp:Label><%--<%=request.form("date7mal")%>--%>&nbsp;</strong>sehingga<strong>
                </strong>
                <asp:Label
                    ID="dtto" runat="server"></asp:Label>.<%--<%=request.form("date8mal")%>--%></p></td>
          </tr>
          <tr>
            <td style="height: 21px">&nbsp;</td>
            <td colspan="3" style="height: 21px">&nbsp;</td>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td colspan="3"><p align="justify"> Syarat-syarat kontrak perkhidmatan yang baru dilampirkan bersama-sama surat ini. </p></td>
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
            <td>&nbsp;</td>
            <td colspan="3">&nbsp;</td>
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
            <td><div align="right"></div></td>
            <td>
                <br />
                <br />
            </td>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td colspan="3">________________________________</td>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td colspan="3"><strong>Datuk Manimaran Anthony</strong></td>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td colspan="3">PENASIHAT EKSEKUTIF </td>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td colspan="3">&nbsp;</td>
          </tr>
        </table>
    </form>
</body>
</html>
