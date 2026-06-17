<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="OnlineMeeting.aspx.vb" Inherits="E_Management.OnlineMeeting" 
    title="Online Meeting and Video Conference" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<table width=80% style="text-align: center" cellpadding="2" cellspacing="5">
<tr>
<th colspan=2 style="text-align: center">
    <asp:Label ID="LblMsg" runat="server" Font-Names="Arial"></asp:Label>
</th>
</tr>
    <tr>
        <td colspan=2 style="text-align: center">
            <span style="font-family: Arial; font-size: 10pt;"><strong>Type message to send (Max. message length is
                limited to 2000 characters):</strong></span></td>
    </tr>
<tr>
<td colspan=2 style="text-align: center">
<asp:TextBox class="form-control" ID="txtboxmessage" runat="server" TextMode="MultiLine" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Font-Names="Arial" Height="150px" Width="468px" Font-Size="10pt" MaxLength="2000"></asp:TextBox>&nbsp;
</td>
</tr>
    <tr>
        <td colspan="2" style="text-align: center">
        </td>
    </tr>
</table>
    <asp:Panel ID="Panel1" runat="server" Width="100%">
    
<table width=80% style="text-align: center" cellpadding="2" cellspacing="5">
    <tr>
        <td width="50%" style="background-color: gainsboro; text-align: left">
            <strong><span style="font-family: Arial">Maruwa Meeting / Video Conference</span></strong></td>
        <td width="50%" style="background-color: gainsboro; text-align: left"><asp:CheckBox  ID="SA1" runat="server" Font-Bold="True" Text="SELECT ALL (MARUWA MEETING)" Font-Names="Arial" Font-Size="10pt" AutoPostBack="True" /></td>
    </tr>
    <tr>
        <td width=50% style="text-align: left">
            <asp:CheckBox  ID="C1" runat="server" Font-Bold="False" Text="DATUK MANIMARAN ANTHONY" Font-Names="Arial" Font-Size="10pt" /></td>
             <td width=50%>
            </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td style="text-align: left"><asp:CheckBox  ID="C2" runat="server" Font-Bold="False" Text="SATHIASEELAN A/L M.SATIAH" Font-Names="Arial" Checked="True" Font-Size="10pt" /></td>
        <td style="text-align: left"><asp:CheckBox  ID="C3" runat="server" Font-Bold="False" Text="PANG SHIN YIN" Font-Names="Arial" Checked="True" Font-Size="10pt" /></td>
    </tr>
    <tr>
        <td style="text-align: left">
            <asp:CheckBox  ID="C4" runat="server" Font-Bold="False" Text="NOOR SHAFIQAH BINTI KARIB" Font-Names="Arial" Checked="True" Font-Size="10pt" /></td>
        <td style="text-align: left">
            <asp:CheckBox  ID="C5" runat="server" Font-Bold="False" Text="JUSTIN A/L PHILOMIN RAJ" Font-Names="Arial" Checked="True" Font-Size="10pt" /></td>
    </tr>
    <tr>
        <td style="text-align: left">
        </td>
        <td style="text-align: left">
        </td>
    </tr>
    <tr>
        <td style="text-align: left">
            <asp:CheckBox  ID="C6" runat="server" Font-Bold="False" Text="THIAGARAJAN A/L KASIVISVANATHAN" Font-Names="Arial" Font-Size="10pt" /></td>
        <td style="text-align: left">
            <asp:CheckBox  ID="C7" runat="server" Font-Bold="False" Text="ERUAN BIN ALIAS" Font-Names="Arial" Font-Size="10pt" /></td>
    </tr>
    <tr>
        <td style="text-align: left">
            <asp:CheckBox  ID="C8" runat="server" Font-Bold="False" Text="PRASAN A/L AMORO" Font-Names="Arial" Font-Size="10pt" /></td>
        <td style="text-align: left">
            <asp:CheckBox  ID="C9" runat="server" Font-Bold="False" Text="SANTHIA DEVI A/P BARATHEEPAM" Font-Names="Arial" Font-Size="10pt" /></td>
    </tr>
    <tr>
        <td style="text-align: left">
            <asp:CheckBox  ID="C10" runat="server" Font-Bold="False" Text="SHAHRUDIN BIN SAAT" Font-Names="Arial" Font-Size="10pt" /></td>
        <td style="text-align: left">
            <asp:CheckBox  ID="C11" runat="server" Font-Bold="False" Text="SEENIVASALU A/L VN VENUGOPAL" Font-Names="Arial" Font-Size="10pt" /></td>
    </tr>
    <tr>
        <td style="height: 22px; text-align: left">
            <asp:CheckBox  ID="C12" runat="server" Font-Bold="False" Text="ASHVINDRA MOORTHY A/L GANASEN" Font-Names="Arial" Font-Size="10pt" /></td>
        <td style="height: 22px; text-align: left">
            <asp:CheckBox  ID="C13" runat="server" Font-Bold="False" Text="NAGARAJAN A/L M.SATIAH" Font-Names="Arial" Font-Size="10pt" /></td>
    </tr>
    <tr>
        <td style="text-align: left">
            <asp:CheckBox  ID="C14" runat="server" Font-Bold="False" Text="NOR NAZLI MAHROP" Font-Names="Arial" Font-Size="10pt" /></td>
        <td style="text-align: left">
            <asp:CheckBox  ID="C15" runat="server" Font-Bold="False" Text="M LOGASENAN A/L MANIARSU" Font-Names="Arial" Font-Size="10pt" /></td>
    </tr>
    <tr>
        <td style="height: 21px; text-align: left">
            <asp:CheckBox  ID="C16" runat="server" Font-Bold="False" Text="MUHAMMED ARIFF BIN SARIF" Font-Names="Arial" Font-Size="10pt" /></td>
        <td style="height: 21px; text-align: left">
            <asp:CheckBox  ID="C17" runat="server" Font-Bold="False" Text="HARRYDASS A/L ELLAPAN" Font-Names="Arial" Font-Size="10pt" /></td>
    </tr>
    <tr>
        <td style="height: 21px; text-align: left">
            <asp:CheckBox  ID="C18" runat="server" Font-Bold="False" Text="MUHAMAD NORAZAMUDIN BIN NOORDIN" Font-Names="Arial" Font-Size="10pt" /></td>
        <td style="height: 21px; text-align: left">
            <asp:CheckBox  ID="C19" runat="server" Font-Bold="False" Text="MOHD SALLEH BIN HAMZAH" Font-Names="Arial" Font-Size="10pt" /></td>
    </tr>
    <tr>
        <td style="height: 21px; text-align: left">
            <asp:CheckBox  ID="C20" runat="server" Font-Bold="False" Text="SINNATHAMBY A/L SUBRAMANIAN" Font-Names="Arial" Font-Size="10pt" /></td>
        <td style="height: 21px; text-align: left">
            <asp:CheckBox  ID="C21" runat="server" Font-Bold="False" Text="YASUHIRO OGAWA" Font-Names="Arial" Font-Size="10pt" /></td>
    </tr>
    <tr>
        <td style="height: 21px; text-align: left">
            <asp:CheckBox  ID="C22" runat="server" Font-Bold="False" Text="SIVA KUMAR A/L KRUSNA KANDASAMY" Font-Names="Arial" Font-Size="10pt" /></td>
        <td style="height: 21px; text-align: left">
            <asp:CheckBox  ID="C23" runat="server" Font-Bold="False" Text="FARHANA AINAA BT SHOHAIMI" Font-Names="Arial" Font-Size="10pt" /></td>
    </tr>
    <tr>
        <td style="height: 21px; text-align: left">
            <asp:CheckBox  ID="C24" runat="server" Font-Bold="False" Text="VINESH KUMAR A/L NARENDRA KUMAR" Font-Names="Arial" Font-Size="10pt" /></td>
        <td style="height: 21px; text-align: left">
        </td>
    </tr>
    <tr>
        <td style="height: 21px; text-align: left">
        </td>
        <td style="height: 21px; text-align: left">
            </td>
    </tr>
</table>
</asp:Panel>

  <asp:Panel ID="Panel2" runat="server" Width="100%">
    
<table width=80% style="text-align: center" cellpadding="2" cellspacing="5">
    <tr>
        <td width="50%" style="text-align: left; background-color: gainsboro;">
            <strong><span style="font-family: Arial">Sales Board Meeting</span></strong></td>
        <td width="50%" style="background-color: gainsboro; text-align: left"><asp:CheckBox  ID="SA2" runat="server" Font-Bold="True" Text="SELECT ALL (SALES BOARD MEETING)" Font-Names="Arial" Font-Size="10pt" AutoPostBack="True" /></td>
    </tr>
    <tr>
        <td width=50% style="text-align: left">
            <asp:CheckBox  ID="C25" runat="server" Font-Bold="False" Text="SASAKI" Font-Names="Arial" Font-Size="10pt" /></td>
             <td width=50% style="text-align: left">
            <asp:CheckBox  ID="C26" runat="server" Font-Bold="False" Text="KOBAYASHI" Font-Names="Arial" Font-Size="10pt" /></td>
    </tr>
    <tr>
        <td style="text-align: left">
        <asp:CheckBox  ID="C27" runat="server" Font-Bold="False" Text="TAKEDA" Font-Names="Arial" Font-Size="10pt" /></td>
        <td style="text-align: left">
        </td>
    </tr>
    <tr>
        <td style="text-align: left">
        </td>
        <td style="text-align: left">
        </td>
    </tr>
    <tr>
        <td style="text-align: left; background-color: gainsboro;">
            <strong><span style="font-family: Arial">Sales Meeting</span></strong></td>
        <td style="text-align: left; background-color: gainsboro;"><asp:CheckBox  ID="SA3" runat="server" Font-Bold="True" Text="SELECT ALL (SALES MEETING)" Font-Names="Arial" Font-Size="10pt" AutoPostBack="True" /></td>
    </tr>
    <tr>
        <td style="text-align: left">
            <asp:CheckBox  ID="C28" runat="server" Font-Bold="False" Text="TAIWAN ERIC" Font-Names="Arial" Font-Size="10pt" /></td>
        <td style="text-align: left">
            <asp:CheckBox  ID="C29" runat="server" Font-Bold="False" Text="SHANGHAI ERIC" Font-Names="Arial" Font-Size="10pt" /></td>
    </tr>
    <tr>
        <td style="text-align: left">
            <asp:CheckBox  ID="C30" runat="server" Font-Bold="False" Text="SHANGHAI RONNY" Font-Names="Arial" Font-Size="10pt" /></td>
        <td style="text-align: left">
            <asp:CheckBox  ID="C31" runat="server" Font-Bold="False" Text="WATANABE" Font-Names="Arial" Font-Size="10pt" /></td>
    </tr>
    <tr>
        <td style="text-align: left">
            <asp:CheckBox  ID="C32" runat="server" Font-Bold="False" Text="MORI" Font-Names="Arial" Font-Size="10pt" /></td>
        <td style="text-align: left">
            </td>
    </tr>
    <tr>
        <td style="text-align: left">
            <strong><span style="font-family: Arial"></span></strong>
        </td>
        <td style="text-align: left">
            </td>
    </tr>
   
</table>
</asp:Panel>

<asp:Panel ID="Panel3" runat="server" Width="100%">
<table width=80% style="text-align: center" cellpadding="2" cellspacing="5">
    <tr>
        <td width="50%" style="background-color: gainsboro; text-align: left">
            <strong><span style="font-family: Arial">SHOMEI Meeting</span></strong></td>
        <td width="50%" style="background-color: gainsboro; text-align: left"><asp:CheckBox  ID="SA4" runat="server" Font-Bold="True" Text="SELECT ALL (SHOMEI MEETING)" Font-Names="Arial" Font-Size="10pt" AutoPostBack="True" /></td>
    </tr>
    <tr>
        <td style="text-align: left"><asp:CheckBox  ID="C33" runat="server" Font-Bold="False" Text="YOH KATO" Font-Names="Arial" Font-Size="10pt" /></td>
        <td style="text-align: left"><asp:CheckBox  ID="C34" runat="server" Font-Bold="False" Text="MASAYA FURUTA" Font-Names="Arial" Font-Size="10pt" /></td>
    </tr>
    <tr>
        <td style="text-align: left">
            <asp:CheckBox  ID="C35" runat="server" Font-Bold="False" Text="MORIYASU IWAMOTO" Font-Names="Arial" Font-Size="10pt" /></td>
        <td style="text-align: left">
            <asp:CheckBox  ID="C36" runat="server" Font-Bold="False" Text="AKIRA KITAMURA" Font-Names="Arial" Font-Size="10pt" /></td>
    </tr>
    <tr>
        <td style="text-align: left">
            <asp:CheckBox  ID="C37" runat="server" Font-Bold="False" Text="ETSUYA ISHII" Font-Names="Arial" Font-Size="10pt" /></td>
        <td style="text-align: left">
            <asp:CheckBox  ID="C38" runat="server" Font-Bold="False" Text="HIROYUKI HONDA" Font-Names="Arial" Font-Size="10pt" /></td>
    </tr>
    <tr>
        <td style="text-align: left">
            <asp:CheckBox  ID="C39" runat="server" Font-Bold="False" Text="MASARU MIYASHITA" Font-Names="Arial" Font-Size="10pt" /></td>
        <td style="text-align: left">
            <asp:CheckBox  ID="C40" runat="server" Font-Bold="False" Text="KEN MURAKAMI" Font-Names="Arial" Font-Size="10pt" /></td>
    </tr>
    <tr>
        <td style="text-align: left">
            <asp:CheckBox  ID="C41" runat="server" Font-Bold="False" Text="TAKASHI YAZAWA" Font-Names="Arial" Font-Size="10pt" /></td>
        <td style="text-align: left">
            <asp:CheckBox  ID="C42" runat="server" Font-Bold="False" Text="TETSUHIRO MORIOKA" Font-Names="Arial" Font-Size="10pt" /></td>
    </tr>
    <tr>
        <td style="height: 22px; text-align: left">
            <asp:CheckBox  ID="C43" runat="server" Font-Bold="False" Text="YUICHIRO YASUI" Font-Names="Arial" Font-Size="10pt" /></td>
        <td style="height: 22px; text-align: left">
            <asp:CheckBox  ID="C44" runat="server" Font-Bold="False" Text="YOSHIAKI BANNO" Font-Names="Arial" Font-Size="10pt" /></td>
    </tr>
    <tr>
        <td style="text-align: left">
            <asp:CheckBox  ID="C45" runat="server" Font-Bold="False" Text="KAZUHIRO KUZUYA" Font-Names="Arial" Font-Size="10pt" /></td>
        <td style="text-align: left">
            <asp:CheckBox  ID="C46" runat="server" Font-Bold="False" Text="SHOUJI SAKAI" Font-Names="Arial" Font-Size="10pt" /></td>
    </tr>
    <tr>
        <td style="height: 21px; text-align: left">
            <asp:CheckBox  ID="C47" runat="server" Font-Bold="False" Text="TAKESHI JIN" Font-Names="Arial" Font-Size="10pt" /></td>
        <td style="height: 21px; text-align: left">
            <asp:CheckBox  ID="C48" runat="server" Font-Bold="False" Text="SATOSHI HONGO" Font-Names="Arial" Font-Size="10pt" /></td>
    </tr>
    <tr>
        <td style="height: 21px; text-align: left">
            <asp:CheckBox  ID="C49" runat="server" Font-Bold="False" Text="YUUKI INDEN" Font-Names="Arial" Font-Size="10pt" /></td>
        <td style="height: 21px; text-align: left">
            <asp:CheckBox  ID="C50" runat="server" Font-Bold="False" Text="HIROYUKI SASAKI" Font-Names="Arial" Font-Size="10pt" /></td>
    </tr>
    <tr>
        <td style="height: 21px; text-align: left">
        </td>
        <td style="height: 21px; text-align: left">
        </td>
    </tr>
    <tr>
        <td style="height: 21px; background-color: gainsboro; text-align: left">
        </td>
        <td style="height: 21px; background-color: gainsboro; text-align: left">
            <asp:Button ID="Button1" runat="server" Font-Bold="True" Text="Send SMS" /></td>
    </tr>
    </table>
</asp:Panel>


</asp:Content>
