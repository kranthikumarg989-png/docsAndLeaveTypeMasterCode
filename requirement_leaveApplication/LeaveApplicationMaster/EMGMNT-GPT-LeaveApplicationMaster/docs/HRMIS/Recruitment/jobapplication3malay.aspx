<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="jobapplication3malay.aspx.vb" Inherits="E_Management.jobapplication3malay" 
    title="Untitled Page" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td style="width: 16px">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" height="16">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 25px">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif" style="width: 16px; height: 372px">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" style="height: 372px" valign="top">
<table>
        <tr>
            <td colspan="4" align="center" class="td_head" width="25%" style="height: 21px">
                &nbsp;PERMOHONAN PEKERJAAN</td>
        </tr>
        <tr>
            <td colspan="4" width="25%" class="td_head">
                Maklumat Tambahan</td>
        </tr>
     <tr><td bgcolor="beige" width="25%">
         Ada Masalah Kesihatan Yang Serius Untuk 5 Tahun Yang Lepas?</td>
     <td bgcolor="beige" width="25%">
         <asp:DropDownList ID="illness" runat="server" AutoPostBack="True">
             <asp:ListItem Value="none">--Pilih--</asp:ListItem>
             <asp:ListItem>No</asp:ListItem>
             <asp:ListItem>Yes</asp:ListItem>
         </asp:DropDownList>
         </td>
     <td bgcolor="beige" width="25%">
         Jikalau Ya,Sila Nyatakan</td>
     <td bgcolor="beige" width="25%">
         <asp:TextBox ID="sillness" runat="server"></asp:TextBox></td></tr>
     <tr><td bgcolor="beige" width="25%">
         Adakah Anda Memakai Cermin Mata?</td>
     <td bgcolor="beige" width="25%">
         <asp:DropDownList ID="glasses" runat="server" AutoPostBack="True">
           <asp:ListItem Value="none">--Pilih--</asp:ListItem>
             <asp:ListItem>No</asp:ListItem>
             <asp:ListItem>Yes</asp:ListItem>
         </asp:DropDownList>
         </td>
     <td bgcolor="beige" width="25%">
         Penglihatan</td>
     <td bgcolor="beige" width="25%">
         <asp:DropDownList ID="vision" runat="server">
             <asp:ListItem>Normal</asp:ListItem>
             <asp:ListItem>Near Sighted</asp:ListItem>
             <asp:ListItem>Far Sighted</asp:ListItem>
             <asp:ListItem>Colour Blind</asp:ListItem>
         </asp:DropDownList></td></tr>
     <tr><td bgcolor="beige" width="25%">
         Adakah Anda Setuju Bekerja Shift?</td>
     <td bgcolor="beige" width="25%">
         <asp:DropDownList ID="shift" runat="server">
         <asp:ListItem Value="none">--Pilih--</asp:ListItem>
             <asp:ListItem>No</asp:ListItem>
             <asp:ListItem>Yes</asp:ListItem>
         </asp:DropDownList>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="shift"
             ErrorMessage="RequiredFieldValidator" InitialValue="none" ValidationGroup="a">*</asp:RequiredFieldValidator></td>
     <td bgcolor="beige" width="25%">
         Adakah Anda Mengandung?</td>
     <td bgcolor="beige" width="25%">
         <asp:DropDownList ID="pregnant" runat="server">
         <asp:ListItem Value="none">--Pilih--</asp:ListItem>
             <asp:ListItem>No</asp:ListItem>
             <asp:ListItem>Yes</asp:ListItem>
         </asp:DropDownList>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="pregnant"
             ErrorMessage="RequiredFieldValidator" InitialValue="none" ValidationGroup="a">*</asp:RequiredFieldValidator></td></tr>
     <tr><td bgcolor="beige" width="25%">
         Adakah Anda Mempunyai Kenderaan Sendiri?</td>
     <td bgcolor="beige" width="25%">
         <asp:DropDownList ID="transport" runat="server" AutoPostBack="True">
         <asp:ListItem Value="none">--Pilih--</asp:ListItem>
             <asp:ListItem>No</asp:ListItem>
             <asp:ListItem>Yes</asp:ListItem>
         </asp:DropDownList></td>
     <td bgcolor="beige" width="25%">
         Jika Ya?</td>
     <td bgcolor="beige" width="25%">
         <asp:DropDownList ID="stransport" runat="server">
             <asp:ListItem Value="none">--Pilih--</asp:ListItem>
             <asp:ListItem>Motorbike</asp:ListItem>
             <asp:ListItem>Car</asp:ListItem>
         </asp:DropDownList></td></tr>
     <tr><td bgcolor="beige" width="25%">
         Adakah Anda Pernah Digantung/Dibuang Kerja Sebelum Ini?</td>
     <td bgcolor="beige" width="25%">
         <asp:DropDownList ID="dismissed" runat="server" AutoPostBack="True">
         <asp:ListItem Value="none">--Pilih--</asp:ListItem>
             <asp:ListItem>No</asp:ListItem>
             <asp:ListItem>Yes</asp:ListItem>
         </asp:DropDownList></td>
     <td bgcolor="beige" width="25%">
         Jika Ya,Sila Nyatakan</td>
     <td bgcolor="beige" width="25%">
         <asp:TextBox ID="sdismissed" runat="server"></asp:TextBox></td></tr>
     <tr><td bgcolor="beige" width="25%">
         Pernahkah Anda DiDakwa Di Mahkamah?</td>
     <td bgcolor="beige" width="25%">
         <asp:DropDownList ID="court" runat="server" AutoPostBack="True">
         <asp:ListItem Value="none">--Pilih--</asp:ListItem>
             <asp:ListItem>No</asp:ListItem>
             <asp:ListItem>Yes</asp:ListItem>
         </asp:DropDownList></td>
     <td bgcolor="beige" width="25%">
         Jika Ya, Sila Nyatakan</td>
     <td bgcolor="beige" width="25%">
         <asp:TextBox ID="scourt" runat="server"></asp:TextBox></td></tr>
     <tr><td bgcolor="beige" width="25%">
         Pernahkah Anda Memohon Kerja Di Maruwa Sebelum Ini?</td>
     <td bgcolor="beige" width="25%">
         <asp:DropDownList ID="before" runat="server">
         <asp:ListItem Value="none">--Pilih--</asp:ListItem>
             <asp:ListItem>No</asp:ListItem>
             <asp:ListItem>Yes</asp:ListItem>
         </asp:DropDownList></td>
     <td bgcolor="beige" width="25%">
         Adakah Anda mempunyai Saudara/Kawan Yang bekerja Di Maruwa?</td>
     <td bgcolor="beige" width="25%">
         <asp:DropDownList ID="relfriend" runat="server" AutoPostBack="True">
         <asp:ListItem Value="none">--Pilih--</asp:ListItem>
             <asp:ListItem>No</asp:ListItem>
             <asp:ListItem>Yes</asp:ListItem>
         </asp:DropDownList></td></tr>
     <tr><td bgcolor="beige" width="25%">
         Nama</td>
     <td bgcolor="beige" width="25%">
         <asp:TextBox ID="friendname" runat="server"></asp:TextBox></td>
     <td bgcolor="beige" width="25%">
         Jabatan</td>
     <td bgcolor="beige" width="25%">
         <asp:TextBox ID="frienddepartment" runat="server"></asp:TextBox></td></tr>
     <tr><td bgcolor="beige" width="25%">
         Adakah anda Mempunyai Untuk Diperkenalkan Di Maruwa?</td>
     <td bgcolor="beige" width="25%">
         <asp:DropDownList ID="introduce" runat="server">
             <asp:ListItem Value="none">--Pilih--</asp:ListItem>
             <asp:ListItem>Yes</asp:ListItem>
             <asp:ListItem>No</asp:ListItem>
         </asp:DropDownList>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="introduce"
             ErrorMessage="RequiredFieldValidator" InitialValue="none" ValidationGroup="a">*</asp:RequiredFieldValidator></td>
     <td bgcolor="beige" width="25%">
         Bagaiamana Anda Mengetahui Terdapat Kekosongan Di MARUWA?</td>
     <td bgcolor="beige" width="25%">
         <asp:DropDownList ID="vacancies" runat="server">
             <asp:ListItem Value="none">--Pilih--</asp:ListItem>
             <asp:ListItem>Banner</asp:ListItem>
             <asp:ListItem>Friend</asp:ListItem>
             <asp:ListItem>Poster</asp:ListItem>
             <asp:ListItem>BusDriver</asp:ListItem>
             <asp:ListItem>MaruwaEmployee</asp:ListItem>
             <asp:ListItem>Others</asp:ListItem>
         </asp:DropDownList>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="vacancies"
             ErrorMessage="RequiredFieldValidator" InitialValue="none" ValidationGroup="a">*</asp:RequiredFieldValidator></td></tr>
     <tr><td bgcolor="beige" width="25%">
         Uniform Saiz</td>
     <td bgcolor="beige" width="25%">
         Baju
         <asp:DropDownList ID="shirt" runat="server">
             <asp:ListItem>S</asp:ListItem>
             <asp:ListItem>M</asp:ListItem>
             <asp:ListItem>L</asp:ListItem>
             <asp:ListItem>XL</asp:ListItem>
             <asp:ListItem>XXL</asp:ListItem>
             <asp:ListItem>XXl</asp:ListItem>
         </asp:DropDownList>
         &nbsp; &nbsp; Seluar<asp:DropDownList ID="trouser" runat="server">
             <asp:ListItem>S</asp:ListItem>
             <asp:ListItem>M</asp:ListItem>
             <asp:ListItem>L</asp:ListItem>
             <asp:ListItem>XL</asp:ListItem>
             <asp:ListItem>XXL</asp:ListItem>
             <asp:ListItem>XXXL</asp:ListItem>
         </asp:DropDownList>&nbsp; Kasut
         <asp:DropDownList ID="shoe" runat="server">
             <asp:ListItem>32</asp:ListItem>
             <asp:ListItem>33</asp:ListItem>
             <asp:ListItem>34</asp:ListItem>
             <asp:ListItem>35</asp:ListItem>
             <asp:ListItem>36</asp:ListItem>
             <asp:ListItem>37</asp:ListItem>
             <asp:ListItem>38</asp:ListItem>
             <asp:ListItem>39</asp:ListItem>
             <asp:ListItem>40</asp:ListItem>
             <asp:ListItem>41</asp:ListItem>
             <asp:ListItem>42</asp:ListItem>
             <asp:ListItem>43</asp:ListItem>
             <asp:ListItem>44</asp:ListItem>
         </asp:DropDownList></td>
     <td bgcolor="beige" width="25%">
         Adakah Anda Terlibat Dalam Pengambilan Dadah?</td>
     <td bgcolor="beige" width="25%">
         <asp:DropDownList ID="drugs" runat="server">
         <asp:ListItem Value="none">--Pilih--</asp:ListItem>
             <asp:ListItem>No</asp:ListItem>
             <asp:ListItem>Yes</asp:ListItem>
         </asp:DropDownList>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="drugs"
             ErrorMessage="RequiredFieldValidator" InitialValue="none" ValidationGroup="a">*</asp:RequiredFieldValidator></td></tr>
     <tr><td bgcolor="beige" width="25%">
         Adakah Anda Merokok?</td>
     <td bgcolor="beige" width="25%">
         <asp:DropDownList ID="smoke" runat="server" AutoPostBack="True">
         <asp:ListItem Value="none">--Pilih--</asp:ListItem>
             <asp:ListItem>No</asp:ListItem>
             <asp:ListItem>Yes</asp:ListItem>
         </asp:DropDownList></td>
     <td bgcolor="beige" width="25%">
         Berapa banyak?</td>
     <td bgcolor="beige" width="25%">
         <asp:TextBox ID="smokecount" runat="server"></asp:TextBox></td></tr>
     <tr>
         <td colspan="4" width="25%" class="td_head">
             REFERENCE 1</td>
         
     </tr>
     <tr>
         <td bgcolor="beige" width="25%">
             Name</td>
         <td bgcolor="beige" width="25%">
             <asp:TextBox ID="crossname" runat="server"></asp:TextBox></td>
         <td bgcolor="beige" width="25%">
             Company</td>
         <td bgcolor="beige" width="25%">
             <asp:TextBox ID="crosscompany" runat="server"></asp:TextBox></td>
     </tr>
      <tr>
         <td bgcolor="beige" width="25%">
             Designation</td>
         <td bgcolor="beige" width="25%">
             <asp:TextBox ID="crossposition" runat="server"></asp:TextBox></td>
         <td bgcolor="beige" width="25%">
             Telephone No1.</td>
         <td bgcolor="beige" width="25%">
             <asp:TextBox ID="crossphone" runat="server"></asp:TextBox></td>
     </tr>
      <tr>
         <td bgcolor="beige" width="25%">
             Address</td>
         <td bgcolor="beige" colspan="3" width="25%">
             <asp:TextBox ID="crossaddress" runat="server" TextMode="MultiLine" Width="240px"></asp:TextBox></td>
         
     </tr>
      <tr>
         <td width="25%" colspan="4" class="td_head">
             REFERENCE 2</td>
      </tr>
      <tr>
         <td bgcolor="beige" width="25%">
             Name</td>
         <td bgcolor="beige" width="25%">
             <asp:TextBox ID="crossname1" runat="server"></asp:TextBox></td>
         <td bgcolor="beige" width="25%">
             Company</td>
         <td bgcolor="beige" width="25%">
             <asp:TextBox ID="crosscompany1" runat="server"></asp:TextBox></td>
     </tr>
      <tr>
         <td bgcolor="beige" width="25%">
             Designation</td>
         <td bgcolor="beige" width="25%">
             <asp:TextBox ID="crossposition1" runat="server"></asp:TextBox></td>
         <td bgcolor="beige" width="25%">
             Telephone No2.</td>
         <td bgcolor="beige" width="25%">
             <asp:TextBox ID="crossphone1" runat="server"></asp:TextBox></td>
     </tr>
     <tr>
         <td bgcolor="beige" width="25%">
             Address</td>
        <td bgcolor="beige" colspan="3" width="25%">
            <asp:TextBox ID="crossaddress1" runat="server" TextMode="MultiLine" Width="240px"></asp:TextBox></td>
     </tr>
     <tr>
         <td colspan="4" width="25%" class="td_head">
             PENGAKUAN</td>
         
     </tr>
     <tr>
         <td bgcolor="#ffffff" colspan="4" width="25%">
             Saya mengaku bahawa segala informasi adalah benar dan betul dan jikalau terdapat
             pengakuan yang salah yang dilakukan oleh saya maka perkhidmatan saya akan ditamatkan
             tanpa notis.Jika saya diambil bekerja,saya akan melapor diri pada tarikh yang ditentukan.Saya
             akan memaklumkan terlebih dahulu jikalau saya tak dapat mula pada tarikh tersebut.</td>
     </tr>
     <tr>
         <td bgcolor="beige" align="right" width="25%">
             Tandatangan Pemohon :&nbsp;
         </td>
           <td bgcolor="beige" width="25%">
               <asp:TextBox ID="sign" runat="server"></asp:TextBox>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="sign"
                   ErrorMessage="RequiredFieldValidator" ValidationGroup="a">?</asp:RequiredFieldValidator></td>
             <td bgcolor="beige" align="right" width="25%">
                 Tarikh</td>
               <td bgcolor="beige" width="25%">
                   <asp:Label ID="datenow" runat="server"></asp:Label></td>
     </tr>
     <tr>
     <td align="right" bgcolor="beige" width="25%"></td>
     <td bgcolor="beige" width="25%" >
         </td>
     <td align="right" bgcolor="beige" width="25%"></td>
     <td bgcolor="beige" width="25%" ><%--<INPUT TYPE="button" VALUE="<<Back" onClick="top.history.go(-1);" style="background-color: beige">--%>
         <asp:Button ID="Button1" ValidationGroup="b" runat="server" Text="<< Back" BackColor="Beige" />
         <asp:Button ID="Saveend" ValidationGroup="a" runat="server" Text="Save" BackColor="Beige" Width="78px" /></td>
     </tr>
        </table>
        </td>
            <td background="../../images/cen_rig.gif" style="width: 25px; height: 372px">
                <img height="11" src="../../images/cen_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td height="16" style="width: 16px">
                <img height="16" src="../../images/bot_lef.gif" width="16" /></td>
            <td background="../../images/bot_mid.gif" height="16">
                <img height="16" src="../../images/bot_mid.gif" width="16" /></td>
            <td height="16" style="width: 25px">
                <img height="16" src="../../images/bot_rig.gif" width="24" /></td>
        </tr>
    </table>
</asp:Content>
