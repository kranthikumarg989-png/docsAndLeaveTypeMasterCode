<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AptLetIndoRpt.aspx.vb" Inherits="E_Management.ApptLetterforIndonesians" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Appointment Letter For Indonesians</title>
          <link rel="stylesheet" type="text/css" href="~/css/style.css" /> 
            <link rel="stylesheet" type="text/css" href="~/css/stylesheet.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width="612" border="0" cellspacing="0">
          <tr>
            <td class="style2"><div align="center"></div></td>
          </tr>
          <tr class="style2">
            <td><table border="0" cellspacing="0" style="width: 637px">
                <tr>
                  <td width="42">&nbsp;</td>
                  <td width="376"><a href="emp_main.asp"></a></td>
                  </tr>
                  </table>
                 </td>
                </tr>
          
          <tr class="style2">
            <td><table border="0" cellspacing="0" style="width: 637px">
                <tr>
                  <td style="width: 29px">&nbsp;</td>
                  <td width="93">&nbsp;</td>
                  <td width="182">&nbsp;</td>
                  <td width="132">&nbsp;</td>
                  <td>
                      <strong>Ref No. :
                          <asp:Label ID="refno" runat="server"></asp:Label></strong></td>
                </tr>
                <tr>
                  <td style="width: 29px">&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                </tr>
                <tr>
                  <td height="26" style="width: 29px">&nbsp;</td>
                  <td><span class="style6"><strong>Nama </strong> </span></td>
                  <td colspan="2" class="style6">
                      &nbsp;<strong>:</strong>
                      <asp:Label ID="empname" runat="server" Font-Bold="True"></asp:Label></td>
                  <td width="167"><strong>Tarikh &nbsp; :
                      <asp:Label ID="dt" runat="server"></asp:Label><span class="style6"></span></strong></td>
                </tr>
				
                <tr>
                  <td style="height: 25px; width: 29px;">&nbsp;</td>
                  <td style="height: 25px"><strong>Umur </strong></td>
                  <td colspan="2" class="style8" style="height: 25px">
                      &nbsp;<strong>:
                          <asp:Label ID="age" runat="server"></asp:Label></strong></td>
                  <td style="height: 25px">&nbsp;</td>
                </tr>
                <tr>
                  <td style="height: 25px; width: 29px;">&nbsp;</td>
                  <td style="height: 25px"><span class="style6"><strong>No. Pekerja&nbsp;</strong></span> </td>
                  <td colspan="2" class="style8" style="height: 25px"><span class="style8">&nbsp;<strong>:</strong>
                      <asp:Label ID="desig" runat="server" Font-Bold="True"></asp:Label></span></td>
                  <td style="height: 25px">&nbsp;</td>
                </tr>
				
                <tr>
                  <td style="height: 25px; width: 29px;">&nbsp;</td>
                  <td class="style6" style="height: 25px">
                      <strong>Alamat</strong>&nbsp;<span class="style8"> </span></td>
                  <td colspan="2" class="style8" style="height: 25px"><span class="style8"><strong>&nbsp;:
                          <asp:Label ID="addr1" runat="server"></asp:Label></strong></span></td>
                  <td style="height: 25px">&nbsp;</td>
                </tr>
                <tr>
                  <td height="27" style="width: 29px">&nbsp;</td>
                  <td>&nbsp;</td>
                  <td colspan="2" class="style8">
                      &nbsp;&nbsp;
                      <asp:Label ID="addr2" runat="server" Font-Bold="True"></asp:Label></td>
                  <td>&nbsp;</td>
                </tr>
                <tr>
                    <td height="27" style="width: 29px">
                    </td>
                    <td>
                    </td>
                    <td class="style8" colspan="2">
                        &nbsp;&nbsp;
                        <asp:Label ID="addr3" runat="server" Font-Bold="True"></asp:Label></td>
                    <td>
                    </td>
                </tr>
            </table></td>
          </tr>
          <tr class="style2">
            <td><table width="609" border="0" cellspacing="0">
              <tr>
                  <td colspan="5">&nbsp;</td>
                </tr>
                <tr>
                  <td colspan="5" style="height: 21px">&nbsp;</td>
                </tr>
                <tr>
                  <td height="24" colspan="5">&nbsp;</td>
                </tr>
                <tr>
                  <td colspan="5"><div align="center">
                      <strong><span style="font-size: 16pt">
                      <u>Sub : TAWARAN KONTRAK PERKHIDMATAN</u>
                          <br />
                      </span></strong>
                  </div></td>
                </tr>
                <tr>
                  <td colspan="5"><p align="justify">Dengan sukacitanya dimaklumkan bahawa kami menawarkan anda jawatan sebagai OPERATOR PENGELUARAN WANITA di Jabatan <strong><asp:Label ID="dept" runat="server"></asp:Label></strong> dalam kilang kami di Lot 27,28,30 & 31, Batu Berendam Industrial Estate, Phase 3, FTZ, 75350 Melaka atau di premis lain yang telah dipilih oleh kami (“KILANG”) atas syarat-syarat yang berikut:-</p></td>
                </tr>
                <tr>
                  <td colspan="5"><p>&nbsp; </p></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="left">
                    
                        <strong>1. TARIKH MULA KERJA </strong>
                      
                  </div></td>
                </tr>
                <tr>
                  <td colspan="5"><p align="justify"> Pada 
                      <asp:Label ID="doj" runat="server"></asp:Label><strong>. </strong> (Tawaran jawatan ini akan dianggap sebagai dibatalkan jika anda gagal memulai kerja pada tarikh tersebut).</p>                    </td>
                </tr>
                <tr>
                  <td colspan="5">&nbsp;</td>
                </tr>
                <tr>
                  <td colspan="5"><strong>2. TEMPOH PERKHIDMATAN</strong></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">Tempoh perkhidmatan anda adalah selama dua (2) tahun berterusan dari tarikh mulai kerja tersebut, tertakluk kepada prestasi kerja.
                                          
                  </div></td>
                </tr>
                <tr>
                  <td width="58">&nbsp;</td>
                  <td width="201"><p>&nbsp; </p></td>
                  <td width="66">&nbsp;</td>
                  <td width="189"><div align="right"></div></td>
                  <td width="85">&nbsp;</td>
                </tr>
                <tr>
                  <td colspan="5"><strong>3. TEMPOH PERCUBAAN </strong></td>
                </tr>
                <tr>
                  <td colspan="5"><p align="justify"> Tiada tempoh percubaan di kenakan. Walaubagaimanapun,Anda diperlukan menerima pemeriksaan doktor perubatan mengikut keperluan pemeriksaan perubatan pekerja asing.</p>
                  </td>
                </tr>
                <tr>
                  <td colspan="5"><p align="justify">&nbsp; </p></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify"><strong>4. WAKTU KERJA NORMAL/JADUAL </strong></div></td>
                </tr>
                <tr>
                  <td colspan="5"><p align="justify">Sila merujuk kepada kalendar syarikat dan notis-notis yang dikeluarkan dari masa ke semasa. Anda dikehendaki mengikut jadual syarikat bagi waktu kerja syif jika dikehendaki.</p>
                  </td>
                </tr>
                <tr>
                  <td colspan="5" style="height: 20px"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify"><strong>5. HARI REHAT</strong></div></td>
                </tr>
                <tr>
                  <td colspan="5">
                      <p align="justify">Walau apa pun di dalam klausa 4 dan 8, anda dapat berehat pada hari Ahad atau hari lain mengikut jadual kerja anda.</p></td>
                </tr>
               <tr>
                  <td colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify"><strong>6. HARI KELEPASAN AM </strong></div></td>
                </tr>
                <tr>
                  <td colspan="5">
                      <div align="justify">Walau apa pun didalam klausa 8 dibawah, anda berhak mendapat Hari Kelepasan Am berbayar yang diwartakan dan ditetapkan oleh Syarikat.
                        
                      </div>                      <p align="justify">Anda tidak berhak kepada Hari Perhentian Syarikat yang bergaji jika anda tidak perlu bekerja pada hari tersebut. </p>
                  </td>
                </tr>
               <tr>
                  <td height="25" colspan="5"><div align="justify">&nbsp;</div></td>
                </tr> 
                <tr>
                  <td colspan="5"><div align="justify"><strong>7.</strong> <strong>KERJA LEBIH MASA</strong></div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">Walau apa pun di dalam klausa 4 tersebut, Syarikat berhak mengkehendaki anda bekerja lebih masa disamping waktu kerja normal. Anda akan dibayar gaji lebih masa yang telah dikerjakan pada kadar yang ditetapkan oleh Syarikat mengikut kaedah yang dibenarkan.
                  </div></td>
                </tr>
                <tr>
                  <td height="24" colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify"><strong>8. BEKERJA PADA HARI REHAT, HARI PERHENTIAN KERJA SYARIKAT ATAU HARI KELEPASAN AM </strong></div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">Walau apa pun di dalam klausa 5 dan 6 tersebut, anda dikehendaki bekerja pada mana-mana Hari Rehat atau Hari Perhentian Kerja Syarikat atau Hari Kelepasan Am yang ditetapkan oleh Syarikat. Anda akan dibayar gaji dan atau elaun pada kadar yang ditetapkan oleh Syarikat mengikut kaedah yang dibenarkan.
                    
                  </div></td>
                </tr>
                <tr>
                  <td height="23" colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify"><strong>9. </strong><strong>GAJI </strong></div></td>
                </tr>
                <tr>
                  <td height="258" colspan="5">
                      <table cellspacing="0" cellpadding="0">
                        <tr>
                          <td width="34" valign="top" style="height: 19px">9.1</td>
                          <td width="190" valign="top" style="height: 19px">Gaji Pokok</td>
                          <td width="27" valign="top" style="height: 19px">=</td>
                          <td width="154" valign="top" style="height: 19px">RM 1,100.00</td>
                          <td width="24" valign="top" style="height: 19px">&nbsp;</td>
                          <td width="176" valign="top" style="height: 19px">&nbsp;</td>
                        </tr>
                        <tr>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                        </tr>
                        <tr>
                          <td height="34" valign="top">9.2</td>
                          <td valign="top">Bayaran gaji untuk kerja lebih masa</td>
                          <td valign="top">(a)</td>
                          <td valign="top">Hari Normal</td>
                          <td valign="top">=</td>
                          <td valign="top">1.5 x 1 jam gaji</td>
                        </tr>
                        <tr>
                          <td height="22" valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">(b)</td>
                          <td valign="top">Hari Rehat </td>
                          <td valign="top">=</td>
                          <td valign="top">Minimum 4 jam : 0.5 X gaji sehari <br /> = Minimum 8 jam : 1.0 X gaji sehari <br /> = Melebihi 8 jam : 2 X gaji sejam </td>
                        </tr>
                        <tr>
                          <td height="25" valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">(c)</td>
                          <td valign="top">Hari Cuti Am</td>
                          <td valign="top">=</td>
                          <td valign="top">Minimum 8 jam : 2.0 X gaji sehari <br /> = Melebihi 8 jam : 3 X gaji sejam </td>
                        </tr>
                       <!--  <tr>
                          <td height="23" valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                        </tr>
                       <tr>
                          <td height="25" valign="top">9.3</td>
                          <td valign="top">Elaun Kedatangan </td>
                          <td valign="top">(a)</td>
                          <td valign="top">Kedatangan Penuh</td>
                          <td valign="top">=</td>
                          <td valign="top">RM 40.00 sebulan </td>
                        </tr>
                        <tr>
                          <td height="24" valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">(b)</td>
                          <td valign="top">1 hari cuti tanpa gaji</td>
                          <td valign="top">=</td>
                          <td valign="top">Tidak layak</td>
                        </tr>
                        <tr>
                          <td height="22" valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">(c)</td>
                          <td valign="top">1-2 hari cuti sakit</td>
                          <td valign="top">=</td>
                          <td valign="top">RM 40.00 sebulan</td>
                        </tr>
                        <tr>
                          <td height="23" valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">(d)</td>
                          <td valign="top">cuti sakit 2 hari keatas</td>
                          <td valign="top">=</td>
                          <td valign="top">Tidak layak</td>
                        </tr>
                        <tr>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                        </tr>
                        <tr>
                          <td height="21" valign="top">9.3</td>
                          <td valign="top">Insentif kedatangan istimewa </td>
                          <td valign="top">(a)</td>
                          <td valign="top">RM 50.00 sebulan</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                        </tr>
                        <tr>
                          <td height="25" valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">(b)</td>
                          <td colspan="3" valign="top">Kedatangan penuh (100%) tanpa memohon cuti.</td>
                        </tr>
                        <tr>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                        </tr>
                        <tr>
                          <td height="18" valign="top">9.4</td>
                          <td valign="top">Elaun Syif </td>
                          <td valign="top">(a)</td>
                          <td valign="top">Syif Normal </td>
                          <td valign="top">=</td>
                          <td valign="top">RM 1.00 sehari </td>
                        </tr>
                        <tr>
                          <td height="19" valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">(b)</td>
                          <td valign="top">Syif Pertama </td>
                          <td valign="top">=</td>
                          <td valign="top">RM 1.00 sehari </td>
                        </tr>
                        <tr>
                          <td height="21" valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">(c)</td>
                          <td valign="top">Syif Kedua </td>
                          <td valign="top">=</td>
                          <td valign="top">RM 3.00 sehari </td>
                        </tr>
                        <tr>
                          <td height="19" valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">(d)</td>
                          <td valign="top">Syif Ketiga </td>
                          <td valign="top">=</td>
                          <td valign="top">RM 6.00 sehari </td>
                        </tr>
                        <tr>
                          <td valign="top" style="height: 19px">&nbsp;</td>
                          <td valign="top" style="height: 19px">&nbsp;</td>
                          <td valign="top" style="height: 19px">&nbsp;</td>
                          <td valign="top" style="height: 19px">&nbsp;</td>
                          <td valign="top" style="height: 19px">&nbsp;</td>
                          <td valign="top" style="height: 19px">&nbsp;</td>
                        </tr>
                     <!--   <tr>
                          <td height="19" valign="top">9.6</td>
                          <td valign="top">Elaun Makan </td>
                          <td valign="top">(a)</td>
                          <td valign="top">RM 50.00 sebulan </td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                        </tr>
                        <tr>
                          <td height="18" valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">(b)</td>
                          <td colspan="3" valign="top">RM 2.00 sehari ditolak sekiranya tidak hadir kerja. </td>
                        </tr>
                        <tr>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                        </tr>
                        <tr>
                          <td height="20" valign="top">9.5</td>
                          <td valign="top">Elaun Persekitaran / Panas </td>
                          <td valign="top">(a)</td>
                          <td valign="top">RM 40.00 sebulan </td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                        </tr>
                        <tr>
                          <td height="21" valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">(b)</td>
                          <td colspan="3" valign="top">RM 2.00 sehari ditolak sekiranya tidak hadir kerja.</td>
                        </tr>
                        <tr>
                          <td height="16" valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">(c)</td>
                          <td colspan="3" valign="top">Untuk seksyen Moulding dan Firing sahaja. </td>
                        </tr>
                        <tr>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                        </tr>
                        <tr>
                          <td height="20" valign="top">9.6</td>
                          <td valign="top">Elaun QC </td>
                          <td valign="top">(a)</td>
                          <td valign="top">RM 30.00 sebulan </td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                        </tr>
                        <tr>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">(b)</td>
                          <td colspan="3" valign="top">Untuk QC yang telah disahkan jawatan </td>
                        </tr>
                        <tr>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                        </tr>
                        <tr>
                          <td height="21" valign="top">9.7</td>
                          <td valign="top">Elaun Skop </td>
                          <td valign="top">(a)</td>
                          <td valign="top" colspan="3">RM 10.00 sebulan kepada yang berkenaan sahaja</td>
                        </tr>
                        <tr>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top"></td>
                          <td colspan="3" valign="top"></td>
                        </tr>
                        <tr>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                        </tr>
                        <tr>
                          <td height="21" valign="top">9.8</td>
                          <td valign="top">Kupon Kerja Lebih Masa </td>
                          <td valign="top">(a)</td>
                          <td valign="top">RM 0.40 </td>
                          <td valign="top">=</td>
                          <td valign="top">2-3 jam kerja lebih masa </td>
                        </tr>
                        <tr>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">(b) </td>
                          <td valign="top">RM 0.80 </td>
                          <td valign="top">=</td>
                          <td valign="top">3.5 jam keatas. </td>
                        </tr>
                        <tr>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                          <td valign="top">&nbsp;</td>
                        </tr>-->
                    </table></td>
                </tr>
              <!--  <tr>
                  <td height="30" colspan="5">Lain Elaun yang tidak terikat kontrak :- </td>
                </tr>
                <tr>
                  <td colspan="5">Seperti skim syarikat yang diumumkan dari masa ke semasa. </td>
                </tr>
                <tr>
                  <td colspan="5">&nbsp;</td>
                </tr>
                <tr>
                  <td colspan="5">Nota : Semua elaun yang dinyatakan di atas selain daripada gaji pokok, adalah tidak terikat kontrak ianya adalah kuasa budi bicara mutlak Syarikat dan boleh diubahkan, dikurangkan atau dimansuhkan sekira difikir sesuai oleh Syarikat pada bila masa tanpa apa - apa notis. </td>
                </tr>
                -->
                <tr>
                  <td height="24" colspan="5">&nbsp;</td>
                </tr>
                <tr>
                  <td colspan="5"><strong>10</strong><strong>.</strong> <strong>PUSINGAN GAJI DAN BAYARAN GAJI </strong></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">Anda dikehendaki membuka satu akaun di Bank CIMB  cawangan Melaka untuk tujuan bayaran atau tolakan gaji anda. Ini adalah pra-syarat bagi perkhidmatan anda seterusnya didalam Syarikat.  </div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">Tempoh pusingan gaji bermula pada setiap 21 haribulan dan berakhir pada setiap 20 haribulan bagi bulan berikutnya. Pembayaran gaji untuk setiap tempoh pusingan gaji akan dibayar pada atau sebelum 27 haribulan bagi setiap bulan melalui akaun anda di Bank Simpanan Nasional cawangan Melaka. </div></td>
                </tr>
                <tr>
                  <td colspan="5">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="5">
                        <strong>11. CARUMAN SOCSO</strong></td>
                </tr>
                <tr>
                    <td colspan="5">
                        Anda layak mencarum kepada PERKESO pada kadar yang ditetapkan oleh PERKESO mengikut
                        perubahan pemindahan terkini dari masa ke semasa. Faedah kemalangan adalah dilindungi
                        oleh PERKESO.</td>
                </tr>
                <tr>
                    <td colspan="5">
                    </td>
                </tr>
                <tr>
                  <td colspan="5"><strong>12. CUTI TAHUNAN</strong></td>
                </tr>
                <tr>
                  <td colspan="5"><p align="justify">Anda berhak mendapat 8 hari Cuti Tahunan berbayar bagi setiap tahun perkhidmatan yang anda sempurnakan. Semua cuti tahunan hanya boleh diambil dengan kebenaran terawal oleh Syarikat dan pada masa yang sama sesuai bagi Syarikat. </p></td>
                </tr>
                <tr>
                  <td height="27" colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify"><strong>13. CUTI SAKIT</strong></div></td>
                </tr>
                <tr>
                  <td colspan="5"><p align="justify">Anda berhak mendapat selepas pemeriksaan oleh Doktor Syarikat, empat belas (14) hari Cuti Sakit dalam (1) tahun.</p></td>
                </tr>
                <tr>
                  <td height="23" colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify"><strong>14. KEMUDAHAN ASRAMA DAN PENGANGKUTAN</strong></div></td>
                </tr>
                <tr>
                  <td colspan="5"><p align="justify">Syarikat akan membekalkan kemudahan asrama dan pengangkutan pergi dan balik kerja diantara kilang dan asrama. Anda dikehendaki menduduki di asrama yang ditetapkan dan mematuhi semua peraturan Syarikat berkenaan kegunaan asrama pada semua masa. Pihak syarikat akan memotong RM50 setiap bulan daripada gaji sebagai sewa tempat kediaman.</p></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">Anda dilarang mengguna atau memiliki apa-apa alat komunikasi termasuk talipon mobil atau pager dan sebagainya, untuk sebarang aktiviti anda yang salah,menyalahi undang-undang, haram atau dilarang oleh perkhidmatan anda atau peraturan yang ditetapkan oleh Syarikat dari masa ke masa. Anda dilarang pada bila-bila masa pun menduduki ditempat lain atau menggunakan pengangkutan lain tanpa kebenaran syarikat. 
                    
                  </div></td>
                </tr>
                <tr>
                  <td height="18" colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify"><strong>15. PERAWATAN DOKTOR</strong></div></td>
                </tr>
                <tr>
                  <td colspan="5"><p align="justify">Syarikat akan membekalkan perawatan doktor percuma di klinik panel yang terpilih
                      dan klinik yang anda telah mendapat kebenaran Syarikat terlebih dahulu. Anda akan diperuntukkan sebanyak RM150.00 setahun sebagai perbelanjaan perubatan. Semua fee doktor yang anda kena diluar kilang tidak boleh dituntut balik dari syarikat. Perawatan doktor tidak termasuk perawatan gigi, &ldquo;obstetrics&rdquo;, pemeriksaan am doktor atau pembedahan kosmetik.</p></td>
                </tr>
                <tr>
                  <td height="26" colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify"><strong>16. PERTANGGUNGAN JAWAPAN</strong></div></td>
                </tr>
                <tr>
                  <td colspan="5"> <div align="justify">Pertanggung jawapan anda pertama adalah memenuhi semua tugas atau tambahan tugas yang diberikan agar sempurna dan efektif. Sebagai pekerja yang bertanggungjawab dan konsisten dengan perkhidmatan anda, anda dikehendaki berusaha bersungguh-sungguh untuk membantu Syarikat untuk mencapai matlamat Syarikat iaitu mengeluarkan hasil ynag berkualiti dan efisyen. Anda diharapkan bertugas mencapai produktiviti yang tinggi dan mengelakkan pembaziran dalam semua perkara pada semua masa. Disamping itu, anda dikehendaki memberi kerjasama kepada ketua dan pihak pengurusan dalam perlaksanaan program-program keselamatan dan pencapaian matlamat-matlamat pengeluaran dan sebagainya. </div></td>
                </tr>
                <tr>
                  <td height="30" colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify"><strong>17. PENGKAJIAN</strong></div></td>
                </tr>
                <tr>
                  <td colspan="5"> <div align="justify">Berdasarkan pertugasan anda yang memuaskan hati dalam semua tugas yang diberikan kepada anda, perkhidmatan anda akan dikaji dari masa ke semasa. Akan tetapi ini adalah tertakluk kepada pihak pengurusan, segala keputusan adalah muktamad. Sebarang rayuan tidak akan dilayan. </div></td>
                </tr>
                <tr>
                  <td height="23" colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify"><strong>18. PERATURAN DAN UNDANG-UNDANG</strong></div></td>
                </tr>
                <tr>
                  <td colspan="5"> <div align="justify">Anda mesti mematuhi semua peraturan undang-undang kaedah prosidur dan kod kelakuan yang ditetapkan oleh syarikat dari masa ke semasa. Tindakan disiplin akan diambil terhadap salah laku termasuk buang kerja selepas siasatan yang sepatutnya.Sesiapa yang terlibat dalam kemalangan kriminal akan ditamatkan perkhidmatan dan dilapurkan kepada pihak polis.Semua pekerja yang terbabit akan ditamatkan perkhidmatan dan
                      tidak akan layak mendapat apa-apa faedah-faedah penamatan . </div></td>
                </tr>
                <tr>
                  <td height="24" colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify"><strong>19. PERLATIHAN DAN TUKAR TUGAS</strong></div></td>
                </tr>
                <tr>
                  <td colspan="5"><p align="justify">19.1. Apabila difikir sesuai,anda diberi perlatihan di kilang Syarikat atau tempat lain.</p></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td height="50" colspan="5"><p align="justify">19.2. Syarikat berhak menukarkan anda ke bahagian yang lain didalam Syarikat yang sama tanpa kira lokasinya dimana tugas dan tanggungjawab anda akan berubah tertakluk kepada budibicara pengurusan Syarikat.</p>
                  </td>
                </tr>
                <tr>
                  <td height="23" colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify"><strong>20. PERNYATAAN BUTIRAN</strong></div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">20.1. Perkhidmatan ini berdasarkan atas pernyataan butiran anda yang benar berlaku dan terus menerus sepanjang perkhidmatan ini adalah benar:-</div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">a. Bahawa anda bertaraf bujang,belum kahwin dan tidak mempunyai anak.</div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"> <div align="justify">b. Butir-butir anda yang dikemukakan oleh anda didalam passport atau kepada kami atau ejen anda adalah benar dan betul.</div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">20.2. 
      

      Jikalau didapati mana-mana pernyataan oleh anda adalah tidak benar atau betul,kontrak perkhidmatan anda boleh ditamatkan tanpa notis oleh Syarikat dan keputusan dalam kluasa 24 dibawah akan berlaku.</div></td>
                </tr>
                <tr>
                  <td height="22" colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify"><strong>21. KESANGGUPAN POSITIF </strong></div></td>
                </tr>
                <tr>
                  <td colspan="5"><p align="justify">Anda dikehendaki pada sepanjang masa perkhidmatan bersetuju dan bersanggup membuat sedemikian:-</p></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"> <div align="justify">21.1. Menjadi seorang pekerja yang baik, bertanggungjawab, rajin dan produktif.</div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">21.2. Mematuhi semua kaedah, peraturan, perintah, arahan dan prosedur yang berkuasa dari masa ke semasa.</div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"> <div align="justify">21.3. Bekerjasama dengan pakerja yang lain, ketua dan pengurusan Syarikat.</div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">21.4. Sanggup bekerja lebih masa bila dikehendaki oleh pengurusan Syarikat.</div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">21.5. Mematuhi semua informasi yang diperolehi oleh anda semasa kerja anda di Syarikat ini dan dalam perkhidmatan ini, sebagai sulit dan konfidensi dan tidak mengumumkannya kepada sesiapa. </div></td>
                </tr>
                <tr>
                  <td height="32" colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify"><strong>22. PERKARA YANG DILARANG</strong></div></td>
                </tr>
                <tr>
                  <td colspan="5"><p align="justify">Anda bersetuju dan mengaku mematuhi seperti berikut :-</p></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"> <div align="justify">22.1. Anda tidak akan meletak jawatan, melarikan diri atau hilang dari perkhidmatan anda dalam masa kontrak.</div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"> <div align="justify">
                      22.2. Anda tidak akan bersalahlaku, meletakkan tanggungjawab anda atau melanggar apa jua peraturan dan kaedah syarikat. </div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"> <div align="justify">
                      22.3. Anda tidak akan membuat sedemikian supaya anda tidak boleh atau menjadi tidak sesuai untuk menjalankan kerja anda termasuk anda tidak boleh minum arak atau mengambil / menghisap dadah atau ubat yang terlarang.</div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"> <div align="justify">
                      22.4. Anda tidak akan berkahwin, hamil atau menggugurkan kandungan atau melahirkan kandungan yang tidak sah atau bersahabat intimasi dengan lelaki sepanjang kontrak. </div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"> <div align="justify">
                      22.5. Anda tidak akan dituduh / didakwa atau membuat apa-apa kesalahan dibawah undang-undang. </div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"> <div align="justify">
                      22.6. Anda tidak akan bekerja bagi majikan yang lain, samada bergaji atau tidak, sepanjang masa kontrak. </div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"> <div align="justify">
                      22.7. Anda tidak akan melarang syarat-syarat kontrak perkhidmatan ini. </div></td>
                </tr>
                <tr>
                  <td height="24" colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify"><strong>23. PERBELANJAAN PRA-PERKHIDMATAN</strong></div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">23.1. Semua perbelanjaan termasuk fee paspot, kos administratif, temuduga, fee ajen dan perbelanjaan sebagainya yang dikenakan pada masa pra-perkhidmatan adalah tanggungjawab anda sahaja, kecuali perbelanjaan perawatan doktor yang ditentukan oleh Kerajaan Malaysia. </div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">
                      23.2.Syarikat akan membayar kos pengangkutan melalui satu tiket kapal terbang kelas ekonomi dari Jakarta ke Melaka. Atas kesempurnaan kontrak perkhidmatan oleh anda. Syarikat akan membayar kos pengangkutan melalui satu tiket kapal terbang kelas ekonomi dari Melaka ke Jakarta sahaja, tetapi anda bertanggung kos pengangkutan dari Jakarta Airport pulang ke kampung anda.</div></td>
                </tr>
                <tr>
                  <td height="21" colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify"><strong>24. LEVI PEKERJA ASING</strong></div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"> <div align="justify">24.1. Pihak Majikan akan menanggung keseluruhan kos Levi Pekerja Asing sepeti telah di tetapkan oleh pihak berkuasa.</div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <!-- <tr>
                  <td colspan="5"><div align="justify">23.2. Sekiranya Syarikat atau pihak lain telah dahulukan levi tersebut kepada kerajaan Malaysia, wang ini akan dikembalikan melalui potongan bulanan sebanyak RM 50.00 dari gaji anda selama dua belas (12) bulan bagi tahun pertama. </div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">23.3. Levi untuk tahun kedua akan ditolak dari bayaran gaji, elaun atau bonus atau melalui kaedah lain yang difikirkan sesuai oleh Syarikat.</div></td>
                </tr> 
                <tr>
                  <td height="38" colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>-->
                <tr>
                  <td colspan="5"><div align="justify"><strong>25.PENAMATAN PERKHIDMATAN </strong></div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">
                      25.1. Sekiranya anda melakukan apa-apa perlanggaran terhadap syarat-syarat kontrak perkhidmatan ini, Syarikat berhak menamatkan kontrak perkhidmatan tanpa notis. Anda akan dikenakan pembayaran sebagai gantirugi kepada Syarikat seperti berikut:-</div></td>
                </tr>
               <!-- <tr>
                  <td colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">&nbsp;</div></td>
                </tr> -->
                <tr>
                  <td colspan="5">
                    <div align="justify">
                      <table width="599" border="0" cellspacing="0">
                        <tr>
                          <td width="103" height="24"><div align="right">a.</div></td>
                          <td>Levi penuh atau baki yang belum dijelaskan = </td>
                          <td width="145">RM 1,850.00</td>
                        </tr>
                        <tr>
                          <td><div align="right">b.</div></td>
                          <td> Kos untuk permit kerja (PLKS) =</td>
                          <td> RM 60.00</td>
                        </tr>
                      </table>
                  </div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">
                      25.2. Apabila terjadi penamatan perkhidmatan kerana perlanggaran kontrak oleh anda, anda bertanggungjawab membayar sendiri kos penghantaran pulang ke negara anda. Sekiranya anda tidak mempunyai cukup wang untuk penghantaran pulang, Syarikat berhak membuat potongan gaji terakhir untuk penghantaran pulang tersebut.</div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">
                      25.3. Apabila terjadi penamatan perkhidmatan kerana perlanggaran kontrak oleh anda, terutamanya perlanggaran kuasa 22.1 tersebut, anda akan dilaporkan kepada pihak berkuasa seperti Polis dan Imigresan, dan kes akan diiklankan diakhbar tempatan yang mana pihak syarikat fikir sesuai. Syarikat tidak akan bertanggungjawab atas segala perkara yang berlaku selanjutan dari masa perlanggaran kontrak anda. </div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"><p align="justify">Sekiranya anda menerima semua syarat-syarat yang terkandung didalam surat tawaran ini, sila tandatangan dibahagian bawah salinan surat tawaran ini selepas anda mengaku memahami obligasi anda dan dengan sukarelanya.</p>
                      <p align="justify">Kami mengucapkan selamat datang ke MARUWA MALAYSIA SDN BHD dan percaya anda dapat memberi kerjasama dalam perkhidmatan anda dengan kami.</p></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5"><p align="justify">Terima kasih dan Selamat Datang.</p></td>
                </tr>
                <tr>
                  <td colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td height="74" colspan="5"><p align="justify">Yang benar,</p>
                      <h2 align="justify" class="style8">&nbsp;</h2></td>
                </tr>
                <tr>
              <td colspan="2"><p align="justify">________________________________</p>
                      <p align="justify"><strong> Seenivasalu A/L VN Venugopal,
</strong></p>
                      <p align="justify"> Plant Manager  </p></td>
                  <td>&nbsp;</td>
                  <td><img src="../../images/stamp.jpg" width="90" height="78"></td>
                  <td>&nbsp;</td>
                </tr>
                <tr>
                  <td colspan="5"><p align="justify">&nbsp;</p></td>
                </tr>
                <tr>
                  <td height="36" colspan="5"><hr align="JUSTIFY"></td>
                </tr>
               <!-- <tr>
                  <td height="56" colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                 <tr>
                 <td colspan="5"><h4 align="justify" class="style8">PENGAKUAN DARI PEKERJA </h2></td> 
                </tr>-->
                <tr>
                  <td height="61" colspan="5"><p align="justify">Saya<strong>
                      <asp:Label ID="empname1" runat="server"></asp:Label>
                  </strong> Paspot No.:<strong> 
                      <asp:Label ID="ppno" runat="server"></asp:Label>
                  </strong> mengaku faham dan menerima segala syarat-syarat yang terkandung didalam surat tawaran ini.</p></td>
                </tr>
                <tr>
                  <td height="27" colspan="5"><div align="justify">&nbsp;</div></td>
                </tr>
                <tr>
                  <td colspan="5">
                    <div align="justify">
                      <table width="605" border="0" cellspacing="0">
                        <tr>
                          <td>&nbsp;</td>
                          <td>&nbsp;</td>
                          <td>&nbsp;</td>
                          <td>&nbsp;</td>
                        </tr>
                        <tr>
                          <td width="86">&nbsp;</td>
                          <td width="199"><strong>____________________</strong></td>
                          <td width="101">&nbsp;</td>
                          <td width="211">_______________________</td>
                        </tr>
                        <tr>
                          <td height="29"><strong>Saksi Nama: </strong></td>
                          <td class="style8"></td>
                          <td><div align="left"><strong>Nama Pekerja:</strong></div></td>
                          <td class="style8"><asp:Label ID="emp" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                          <td style="height: 21px"><strong>Tarikh :</strong></td>
                          <td style="height: 21px">_______________________</td>
                          <td style="height: 21px"><div align="left"><strong>Tarikh:</strong></div></td>
                          <td style="height: 21px">_______________________</td>
                        </tr>
                      </table>
                  </div></td>
                </tr>
                <tr>
                  <td colspan="5"><p>&nbsp; </p>
                  </td>
                </tr>
                 <tr>
                  <td colspan="5"><p>&nbsp; </p>
                  </td>
                </tr>
                <tr>
                <td colspan="5" align=center>
                Maruwa (Malaysia) Sdn.Bhd.<br />
(191424-X)<br />
Lot 27, 28, 30 & 31 Batu Berendam, FTZ Phase 3, Industrial Estate, 75350 Melaka, Malaysia.<br />                             
Tel: 06-2883302 Fax: 06-2883341<br />

                </td>
                </tr>
            </table></td>
          </tr>
          <tr class="style2">
            <td>&nbsp;</td>
          </tr>
        
		 <tr><td>
				&nbsp; &nbsp; &nbsp;<img src="../../images/maruwaAnimLogo.gif" width="161" height="42" border="0" />
        &nbsp; &nbsp;&nbsp; &nbsp; 
        </td></tr>
            </table>
    
      
        
 
            
        
</div>         
        
        
    </form>
</body>
</html>
