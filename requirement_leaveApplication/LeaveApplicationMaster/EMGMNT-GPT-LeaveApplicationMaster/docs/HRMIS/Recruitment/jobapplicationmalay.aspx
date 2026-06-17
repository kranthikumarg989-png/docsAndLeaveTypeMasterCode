<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="jobapplicationmalay.aspx.vb" Inherits="E_Management.jobapplicationmalay" 
    title="Untitled Page" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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
            <td colspan="4" align="center" class="td_head" width="25%">
                PERMOHONAN PEKERJAAN</td>
        </tr>
        <tr>
            <td colspan="4" width="25%" class="td_head">Personal Details</td>
        </tr>
        <tr>
            <td bgcolor="beige"width="25%">
                No Aplikasi</td>
            <td width="25%">
                <asp:Label ID="applno" runat="server"></asp:Label></td>
            <td bgcolor="beige"width="25%">
                Tarikh Permohanan</td>
            <td width="25%">
                <asp:Label ID="datetoday" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td bgcolor="beige" width="25%">
                Jawatan Yang Dipohon:</td>
            <td width="25%">
                <asp:DropDownList ID="ddldesig" runat="server" DataSourceID="SqlDataSource1" DataTextField="designationname" DataValueField="designationname" AppendDataBoundItems="True">
                    <asp:ListItem Value="none">Select</asp:ListItem>
                </asp:DropDownList></td>
            <td bgcolor="beige" width="25%">
                Nama</td>
            <td width="25%">
                <asp:TextBox ID="name" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td bgcolor="beige" width="25%">
                No. K/P Baru</td>
            <td width="25%">
                <asp:TextBox ID="icnew" runat="server"></asp:TextBox></td>
            <td bgcolor="beige" width="25%">
                No. K/P Lama</td>
            <td width="25%">
                <asp:TextBox ID="icold" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td bgcolor="beige" width="25%">
                Alamat</td>
            <td width="25%">
                <asp:TextBox ID="address" runat="server" TextMode="MultiLine"></asp:TextBox></td>
            <td bgcolor="beige" width="25%">
                Telefon Bimbit</td>
            <td width="25%">
                <asp:TextBox ID="mobile" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="4" width="25%" class="td_head">
                Butiran Peribadi</td>
           </tr>
        <tr>
            <td bgcolor="beige" width="25%">
                Warna Kad Pengenalan</td>
            <td width="25%">
                <asp:DropDownList ID="iccolor" runat="server">
                    <asp:ListItem Value="none">---Pilih Salah Satu---</asp:ListItem>
                    <asp:ListItem>Blue</asp:ListItem>
                    <asp:ListItem>Red</asp:ListItem>
                </asp:DropDownList></td>
            <td bgcolor="beige" width="25%">
                Jantina</td>
            <td width="25%">
               <asp:DropDownList ID="sex" runat="server">
                    <asp:ListItem Value="none">---Pilih Salah Satu---</asp:ListItem>
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="sex"
                    ErrorMessage="RequiredFieldValidator" InitialValue="none">?</asp:RequiredFieldValidator></td>
        </tr>
         <tr>
            <td bgcolor="beige" width="25%">
                Telefon Rumah</td>
            <td width="25%" >
                <asp:TextBox ID="phone" runat="server"></asp:TextBox></td>
            <td bgcolor="beige" width="25%" style="height: 26px">
                Warganegara</td>
            <td width="25%" style="height: 26px">
                <asp:DropDownList ID="nationality" runat="server">
                    <asp:ListItem Value="none">---Pilih Salah Satu---</asp:ListItem>
                    <asp:ListItem Value="MAL">MALAYSIAN</asp:ListItem>
                    <asp:ListItem Value="IND">INDIAN</asp:ListItem>
                    <asp:ListItem Value="JAP">JAPANESE</asp:ListItem>
                    <asp:ListItem Value="PAK">PAKISTAN</asp:ListItem>
                    <asp:ListItem Value="INDO">INDONESIAN</asp:ListItem>
                    <asp:ListItem Value="NEPAL">NEPALESE</asp:ListItem>
                    <asp:ListItem Value="BANG">BANGLADESH</asp:ListItem>
                    <asp:ListItem>OTHERS</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="nationality"
                    ErrorMessage="RequiredFieldValidator" InitialValue="none">?</asp:RequiredFieldValidator></td>
        </tr>
         <tr>
            <td bgcolor="beige" width="25%">
                No.
                EPF</td>
            <td width="25%">
                <asp:TextBox ID="epf" runat="server"></asp:TextBox></td>
            <td bgcolor="beige" width="25%">
                No. SOCSO</td>
            <td width="25%">
                <asp:TextBox ID="socso" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
            <td bgcolor="beige" width="25%">
                No.Cukai</td>
            <td width="25%">
                <asp:TextBox ID="tax" runat="server"></asp:TextBox></td>
            <td bgcolor="beige" width="25%">
                Tarikh Lahir</td>
            <td width="25%">
                <asp:TextBox ID="dob" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
            <td bgcolor="beige" width="25%">
                Umur
            </td>
            <td width="25%">
                <asp:TextBox ID="age" runat="server" MaxLength="3"></asp:TextBox></td>
            <td bgcolor="beige" width="25%">
                Bahasa Pertuturan</td>
            <td width="25%">
                <asp:TextBox ID="lang" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
            <td bgcolor="beige" width="25%">
                Bangsa</td>
            <td width="25%">
                <asp:DropDownList ID="race" runat="server">
                    <asp:ListItem Value="none">Select Race</asp:ListItem>
                    <asp:ListItem Value="BANG">BANGLADESH</asp:ListItem>
                    <asp:ListItem Value="IND">INDIAN</asp:ListItem>
                    <asp:ListItem Value="MLY">MALAY</asp:ListItem>
                    <asp:ListItem Value="CHI">CHINESE</asp:ListItem>
                    <asp:ListItem>IBAN</asp:ListItem>
                    <asp:ListItem Value="INDO">INDONESIAN</asp:ListItem>
                    <asp:ListItem Value="NEPAL">NEPALESE</asp:ListItem>
                    <asp:ListItem Value="PAK">PAKISTAN</asp:ListItem>
                    <asp:ListItem Value="JPN">JAPANESE</asp:ListItem>
                    <asp:ListItem Value="POR">PORTUGUSE</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="race"
                    ErrorMessage="RequiredFieldValidator" InitialValue="none">?</asp:RequiredFieldValidator></td>
            <td bgcolor="beige" width="25%">
                Agama</td>
            <td width="25%">
                <asp:DropDownList ID="religion" runat="server">
                    <asp:ListItem Value="none">---Pilih Salah Satu---</asp:ListItem>
                    <asp:ListItem Value="ISL">ISLAM</asp:ListItem>
                    <asp:ListItem Value="HIN">HINDU</asp:ListItem>
                    <asp:ListItem Value="BUDD">BUDDHA</asp:ListItem>
                    <asp:ListItem Value="CHI">CHINESE</asp:ListItem>
                    <asp:ListItem Value="CHR">CHRISTINE</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="religion"
                    ErrorMessage="RequiredFieldValidator" InitialValue="none">?</asp:RequiredFieldValidator></td>
        </tr>
         <tr>
            <td bgcolor="beige" width="25%">
                Status Perkhawinan</td>
            <td width="25%">
                <asp:DropDownList ID="marital" runat="server" AutoPostBack="True">
                    <asp:ListItem Value="none">---Pilih Salah Satu---</asp:ListItem>
                    <asp:ListItem>Single</asp:ListItem>
                    <asp:ListItem>Married</asp:ListItem>
                    <asp:ListItem>Divorced</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="marital"
                    ErrorMessage="RequiredFieldValidator" InitialValue="none">?</asp:RequiredFieldValidator></td>
            <td bgcolor="beige" width="25%">
                Negara</td>
            <td width="25%">
                <asp:DropDownList ID="country" runat="server" DataSourceID="SqlDataSource2" DataTextField="countryname"
                    DataValueField="countryname" AppendDataBoundItems="True">
                    <asp:ListItem Value="none">Select country</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="country"
                    ErrorMessage="RequiredFieldValidator" InitialValue="none">?</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td bgcolor="beige" width="25%">
                Kumpulan Darah</td>
            <td width="25%">
                <asp:TextBox ID="blood" runat="server" Height="11px"></asp:TextBox></td>
            <td bgcolor="beige" width="25%">
            </td>
            <td width="25%">
            </td>
        </tr>
        <tr>
            <td bgcolor="#ffffff" colspan="4" width="25%">
                Jika Bujang</td>
           
        </tr>
        <tr>
            <td bgcolor="beige" width="25%">
                Pertalian</td>
            <td width="25%">
                <asp:DropDownList ID="relationship" runat="server">
                    <asp:ListItem Value="none">---Pilih Salah Satu---</asp:ListItem>
                    <asp:ListItem>Mother</asp:ListItem>
                    <asp:ListItem>Father</asp:ListItem>
                    <asp:ListItem>Guardian</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="relationship"
                    ErrorMessage="RequiredFieldValidator" InitialValue="none">?</asp:RequiredFieldValidator></td>
            <td bgcolor="beige" width="25%">
                Nama
            </td>
            <td width="25%">
                <asp:TextBox ID="rname" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td bgcolor="beige" width="25%">
                No. K/P Lama</td>
            <td width="25%">
                <asp:TextBox ID="ricold" runat="server"></asp:TextBox></td>
            <td bgcolor="beige" width="25%">
                No. K/P Baru</td>
            <td width="25%">
                <asp:TextBox ID="ricnew" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td bgcolor="beige" width="25%">
                Umur</td>
            <td width="25%">
                <asp:TextBox ID="rage" runat="server" MaxLength="3"></asp:TextBox></td>
            <td bgcolor="beige" width="25%">
                Pekerjaan</td>
            <td width="25%">
                <asp:TextBox ID="roccupation" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td bgcolor="beige" width="25%">
                Syarikat/Sekolah</td>
            <td width="25%">
                <asp:TextBox ID="rcompany" runat="server"></asp:TextBox></td>
            <td bgcolor="beige" width="25%">
                No. Telefon</td>
            <td width="25%">
                <asp:TextBox ID="rphone" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td bgcolor="#ffffff" colspan="4" width="25%">
                Kalau Berkahwin</td>
          
        </tr>
        <tr>
            <td bgcolor="beige" width="25%">
                Nama Suami/Isteri</td>
            <td width="25%">
                <asp:TextBox ID="hubwife" runat="server"></asp:TextBox></td>
            <td bgcolor="beige" width="25%">
                Umur</td>
            <td width="25%">
                <asp:TextBox ID="hubwifeage" runat="server" MaxLength="3"></asp:TextBox></td>
        </tr>
         <tr>
            <td bgcolor="beige" width="25%">
                No. K/P Lama</td>
            <td width="25%">
                <asp:TextBox ID="hubicold" runat="server"></asp:TextBox></td>
            <td bgcolor="beige" width="25%">
                No. K/P Baru</td>
            <td width="25%">
                <asp:TextBox ID="hubicnew" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td bgcolor="beige" width="25%">
                Nama Anak 1</td>
            <td width="25%">
                <asp:TextBox ID="child1" runat="server"></asp:TextBox></td>
            <td bgcolor="beige" width="25%">
                Umur</td>
            <td width="25%">
                <asp:TextBox ID="cage1" runat="server" MaxLength="2"></asp:TextBox></td>
        </tr>
        <tr>
            <td bgcolor="beige" width="25%">
                Nama Anak 2</td>
            <td width="25%">
                <asp:TextBox ID="child2" runat="server"></asp:TextBox></td>
            <td bgcolor="beige" width="25%">
                Umur</td>
            <td width="25%">
                <asp:TextBox ID="cage2" runat="server" MaxLength="2"></asp:TextBox></td>
        </tr>
        <tr>
            <td bgcolor="beige" width="25%">
                Nama Anak 3</td>
            <td width="25%">
                <asp:TextBox ID="child3" runat="server"></asp:TextBox></td>
            <td bgcolor="beige" width="25%">
                Umur</td>
            <td width="25%">
                <asp:TextBox ID="cage3" runat="server" MaxLength="2"></asp:TextBox></td>
        </tr>
        <tr>
            <td bgcolor="beige" width="25%">
                Nama Anak 4</td>
            <td width="25%">
                <asp:TextBox ID="child4" runat="server"></asp:TextBox></td>
            <td bgcolor="beige" width="25%">
                Umur</td>
            <td width="25%">
                <asp:TextBox ID="cage4" runat="server" MaxLength="2"></asp:TextBox></td>
        </tr>
        <tr>
            <td bgcolor="beige" width="25%">
                Nama Anak 5</td>
            <td width="25%">
                <asp:TextBox ID="child5" runat="server"></asp:TextBox></td>
            <td bgcolor="beige" width="25%">
                Umur</td>
            <td width="25%">
                <asp:TextBox ID="cage5" runat="server" MaxLength="2"></asp:TextBox></td>
        </tr>
        <tr>
         <td bgcolor="beige" width="25%"></td>
         <td bgcolor="beige" width="25%">
             </td>
         <td bgcolor="beige" width="25%">
             </td>
            <td bgcolor="beige" align="right" width="25%">
                &nbsp;<asp:Button ID="savenext" runat="server" BackColor="Beige" Text="Save & Next" Height="21px" />
                </td>          
        </tr>
    </table>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="select distinct(designationname)from designation"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
        SelectCommand="select countryname from countrymaster"></asp:SqlDataSource>
    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="dob">
    </cc1:CalendarExtender>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server"  ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
       InsertCommand="INSERT INTO jobapplication(applicationno) VALUES (@aplno)">
       </asp:SqlDataSource>
 <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
    InsertCommand="INSERT INTO jobapplication_temp(applicationno,username,positionapplied,name,address,icold,icnew,iccolour,sex,handphone,phone,bloodgroup,nationality,epfno,socsono,taxno,dob,age,languagespoken,race,religion,country,maritalstatus,relationship,parentsname,parentsicold,parentsicnew,parentsage,company,occupation,parentsphone,husbandname,husbandage,husbandicold,husbandicnew,cname1,cage1,cname2,cage2,cname3,cage3,cname4,cage4,cname5,cage5) VALUES (@applno,@un,@ddldesig,@name,@address,@icold,@icnew,@iccolor,@sex,@mobile,@phone,@blood,@nationality,@epf,@socso,@tax,@dob,@age,@lang,@race,@religion,@country,@marital,@relationship,@rname,@ricold,@ricnew,@rage,@rcompany,@roccupation,@rphone,@hubwife,@hubwifeage,@hubicold,@hubicnew,@child1,@cage1,@child2,@cage2,@child3,@cage3,@child4,@cage4,@child5,@cage5)">
    </asp:SqlDataSource>
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
