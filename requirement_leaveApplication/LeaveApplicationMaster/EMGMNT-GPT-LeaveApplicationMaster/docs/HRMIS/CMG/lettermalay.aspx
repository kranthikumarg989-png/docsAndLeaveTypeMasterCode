<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="lettermalay.aspx.vb" Inherits="E_Management.lettermalay" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>PFP Letter (Malay) Operator</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width="642" border="0" cellspacing="0">
     <tr>
      <td colspan="2"><img src="../../images/maruwaAnimLogo.gif" width="158" height="39"></td>
      <td width="18">&nbsp;</td>
      <td width="104">&nbsp;</td>
      <td width="183">&nbsp;</td>
    </tr>
     <tr>
       <td colspan="4">&nbsp;</td>
       <td>&nbsp;</td>
     </tr>
     <tr>
      <td colspan="2"><p align="justify"><strong>Nama :</strong> 
          <asp:Label ID="name" runat="server"></asp:Label><span class="style2"></span></p></td>
      <td>&nbsp;</td>
      <td><div align="right"><strong>Tarikh :</strong></div></td>
      <td><span class="style2">
          <asp:Label ID="vdate" runat="server"></asp:Label></span></td>
    </tr>
    <tr>
      <td height="24" colspan="5"><strong>No. Pekerja  : 
          <asp:Label ID="empcode" runat="server"></asp:Label></strong><span class="style2"></span></td>
    </tr>
    <tr>
      <td height="22" colspan="5"><strong>Jabatan :</strong> 
          <asp:Label ID="dept" runat="server"></asp:Label><span class="style2"></span></td>
    </tr>
    <tr>
      <td height="21" colspan="5"><strong>Jawatan :</strong> 
          <asp:Label ID="desig" runat="server"></asp:Label><span class="style2"></span></td>
    </tr>
    <tr>
      <td height="16" colspan="5">&nbsp;</td>
    </tr>
    <tr>
      <td colspan="5"><strong>SURAT MAKLUMAN 'PAY FOR PERFORMANCE' (OPERATOR) </strong></td>
    </tr>
    <tr>
      <td colspan="5">&nbsp;</td>
    </tr>
    
    <tr class="style2">
      <td colspan="5"><div align="justify">Pihak Pengurusan amat menghargai penglibatan anda di dalam skim 'Pay For Performance' (PFP) berkuat kuasa 
          <asp:Label ID="edate" runat="server"></asp:Label>.</div>      </td>
    </tr>
   
    <tr class="style2">
      <td colspan="5">&nbsp;</td>
    </tr>
    <tr class="style2">
      <td height="23" colspan="5"><div align="justify">Sebagai operator pengeluaran di syarikat ini anda dikehendaki menunjukkan contoh yang baik di dalam pencapaian pretasi kerja dan meneruskan uasaha memajukan syarikat.</div></td>
    </tr>
    <tr class="style2">
      <td colspan="5">&nbsp;</td>
    </tr>
    <tr class="style2">
      <td height="23" colspan="5"><p align="justify" class="style2">Disini kami ingin memaklumkan bahawa pembayaran elaun prestasi bulanan akan berdasarkan kepada pencapaian prestasi kerja anda berkuat kuasa  
          <asp:Label ID="edate1" runat="server"></asp:Label>. </p></td>
    </tr>
    <tr class="style2">
      <td  colspan="5">&nbsp;</td>
    </tr>
    <tr class="style2">
      <td height="47" colspan="5"><div align="justify">Sehubungan dengan ini, pihak pengurusan telah menetapkan  RM   
          <asp:Label ID="pfp" runat="server"></asp:Label>sebagai elaun pencapaian untuk tahun 2011/2012 berasaskan kepada polisi 'Pay For Performance&quot; (PFP) syarikat. Gred pencapaian kerja anda dinilaikan berdasarkan kepada berikut:- </div></td>
    </tr>
    <tr class="style2">
      <td colspan="5"><div align="justify"></div></td>
    </tr>
    <tr class="style2">
      <td colspan="5"><div align="justify">
        <table width="100%" border="0" cellspacing="1" cellpadding="1">
            <tr>
              <td width="50%"><div align="center"><strong>GRED</strong></div></td>
              <td width="50%"><div align="center"><strong> PENCAPAIAN PFP</strong></div></td>
            </tr>
            <tr>
              <td><div align="center">A</div></td>
              <td><div align="center">50</div></td>
            </tr>
            <tr>
              <td><div align="center">B</div></td>
              <td><div align="center">40</div></td>
            </tr>
            <tr>
              <td><div align="center">C</div></td>
              <td><div align="center">30</div></td>
            </tr>
            <tr>
              <td><div align="center">D/E</div></td>
              <td><div align="center">0</div></td>
            </tr>
              </table>
      </div></td>
    </tr>
    <tr class="style2">
      <td colspan="5">&nbsp;</td>
    </tr>
    
    <tr class="style2">
      <td colspan="5">&nbsp;</td>
    </tr>
    <tr class="style2">
      <td colspan="5"><div align="justify">Kami yakin dan percaya anda akan terus menerus meningkatkan prestasi kerja anda di syarikat ini pada masa akan datang. </div></td>
    </tr>
    <tr class="style2">
      <td colspan="5">&nbsp;</td>
    </tr>
    <tr class="style2">
      <td colspan="5">&nbsp;</td>
    </tr>
    <tr class="style2">
      <td colspan="5">&nbsp;</td>
    </tr>
    <tr class="style2">
      <td colspan="5"><p align="justify">Terima Kasih. </p></td>
    </tr>
    <tr class="style2">
      <td colspan="5">&nbsp;</td>
    </tr>
    <tr class="style2">
      <td colspan="5"><p align="justify">Yang Benar, </p>
          <p align="justify">MARUWA ( MALAYSIA ) SDN BHD </p></td>
    </tr>
    <tr>
      <td colspan="5">&nbsp;</td>
    </tr>
    <tr>
      <td colspan="5">&nbsp;</td>
    </tr>
    <tr>
      <td colspan="5"><div align="justify"></div></td>
    </tr>
    <tr>
      <td colspan="5"><div align="justify"></div></td>
    </tr>
    <tr>
      <td colspan="5"><div align="justify"></div></td>
    </tr>
    <tr>
      <td width="302" height="15"><p align="justify">&nbsp;</p>      </td>
      <td width="21" height="113" colspan="-1" rowspan="7">&nbsp;</td>
      <td rowspan="7">&nbsp;</td>
      <td height="113" rowspan="7" valign="top"><img src="../../images/stamp.jpg" width="84" height="78"></td>
      <td height="113" rowspan="7">&nbsp;</td>
    </tr>
    <tr>
      <td height="15">&nbsp;</td>
    </tr>
    <tr>
      <td height="15"><img src="../../images/anthony.jpg" alt="EA" width="83" height="64"></td>
    </tr>
    <tr>
      <td height="15"><strong>DATUK MANIMARAN ANTHONY</strong></td>
    </tr>
    <tr>
      <td height="15">CHIEF EXECUTIVE OFFICER</td>
    </tr>
    <tr>
      <td height="15">&nbsp;</td>
    </tr>
    <tr>
      <td height="15">&nbsp;</td>
    </tr>
    <tr>
      <td height="72">&nbsp;</td>
      <td height="72" colspan="-1">&nbsp;</td>
      <td>&nbsp;</td>
      <td height="72" valign="top">&nbsp;</td>
      <td height="72">&nbsp;</td>
    </tr>
    <tr>
      <td height="15">&nbsp;</td>
      <td height="113" colspan="-1">&nbsp;</td>
      <td>&nbsp;</td>
      <td height="113" valign="top">&nbsp;</td>
      <td height="113">&nbsp;</td>
    </tr>
  </table>
    </div>
    </form>
</body>
</html>
