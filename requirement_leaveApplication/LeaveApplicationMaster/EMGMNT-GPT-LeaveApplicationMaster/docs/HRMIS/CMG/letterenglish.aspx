<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="letterenglish.aspx.vb" Inherits="E_Management.letterenglish" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>PFP Letter Operator</title>
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
      <td colspan="2"><p align="justify"><strong>Name :</strong> 
          <asp:Label ID="name" runat="server"></asp:Label><span class="style2"></span></p></td>
      <td>&nbsp;</td>
      <td><div align="right"><span class="style12"><strong>Date</strong></span><strong>:</strong></div></td>
      <td><span class="style2">
          <asp:Label ID="vdate" runat="server"></asp:Label></span></td>
    </tr>
    <tr>
      <td height="24" colspan="5"><strong>Emp No : 
          <asp:Label ID="empcode" runat="server"></asp:Label></strong><span class="style2"></span></td>
    </tr>
    <tr>
      <td height="22" colspan="5"><strong>Department :</strong> 
          <asp:Label ID="dept" runat="server"></asp:Label><span class="style2"></span></td>
    </tr>
    <tr>
      <td height="21" colspan="5"><strong>Designation :</strong> 
          <asp:Label ID="desig" runat="server"></asp:Label><span class="style2"></span></td>
    </tr>
    <tr>
      <td height="16" colspan="5">&nbsp;</td>
    </tr>
    <tr>
      <td colspan="5"><div align="center"><strong>NOTIFICATION LETTER ON PAY FOR PERFORMANCE ALLOWANCE (OPERATOR) </strong></div></td>
    </tr>
    <tr>
      <td colspan="5">&nbsp;</td>
    </tr>
    
    <tr class="style2">
      <td colspan="5"><div align="justify"><span class="style2">The Management would like to extend it's greatest appreciation to you for being part of the pay for performance scheme as of
          <asp:Label ID="edate" runat="server"></asp:Label>.</span></div></td>
    </tr>
     <tr class="style2">
      <td colspan="5">&nbsp;</td>
    </tr>
    <tr class="style2">
      <td height="23" colspan="5"><div align="justify">As a staff of the company, you are required to show examplary performance and put continuous effort towards the growth of the company. </div></td>
    </tr>
    <tr class="style2">
      <td height="23" colspan="5">&nbsp;</td>
    </tr>
    <tr class="style2">
      <td height="23" colspan="5"><p align="justify" class="style2">We are pleased to announce that the payment of monthly performance allowance will be based on your monthly performance achievement with effect from 
          <asp:Label ID="edate1" runat="server"></asp:Label>. </p></td>
    </tr>
    <tr class="style2">
      <td height="47" colspan="5"><div align="justify">Pursuant to this, your provisional allowance of amount of RM   
          <asp:Label ID="pfp" runat="server"></asp:Label>
          for the fiscal year 2011/2012 is subject to the company's policy of pay for performance. </div></td>
    </tr>
    <tr class="style2">
      <td colspan="5"><div align="justify"></div></td>
    </tr>
    <tr class="style2">
      <td colspan="5"><div align="justify">
        <table width="100%" border="0" cellspacing="1" cellpadding="1">
            <tr>
              <td width="50%"><div align="center"><strong>GRADE</strong></div></td>
              <td width="50%"><div align="center"><strong>PFP ACHIEVEMENT </strong></div></td>
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
      <td colspan="5"><div align="justify">We trust that you will continue to grow career towards the progress of Maruwa(M) SDN. BHD in the coming years. </div></td>
    </tr>
    <tr class="style2">
      <td colspan="5">&nbsp;</td>
    </tr>
    <tr class="style2">
      <td colspan="5">Our heartiest congratulations. </td>
    </tr>
    <tr class="style2">
      <td colspan="5">&nbsp;</td>
    </tr>
    <tr class="style2">
      <td colspan="5"><p align="justify"> Thank you. </p></td>
    </tr>
    <tr class="style2">
      <td colspan="5">&nbsp;</td>
    </tr>
    <tr class="style2">
      <td colspan="5"><p align="justify"> Yours faithfully, </p>
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
      <td width="302"><img src="../../images/anthony.jpg" width="79" height="64"></td>
      <td width="21" height="113" colspan="-1" rowspan="5">&nbsp;</td>
      <td rowspan="5">&nbsp;</td>
      <td height="113" rowspan="5" valign="top"><img src="../../images/stamp.jpg" width="84" height="78"></td>
      <td height="113" rowspan="5">&nbsp;</td>
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
