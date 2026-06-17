<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="MissingPersonEdit.aspx.vb" Inherits="E_Management.MissingPersonEdit" %>
<%@Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@Import Namespace="System" %>
<%@Import Namespace="System.Data" %>
<%@Import Namespace="System.Data.Common" %>
<%@Import Namespace="System.Diagnostics" %>
<%@import Namespace="System.Data.SqlClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table style="width: 758px">
        <tr>
            <td class="td_head" colspan="6">
                MISSING PERSON DETAILS</td>
        </tr>
        <tr>
            <td style="width: 100px; height: 5px">
                Empcode</td>
            <td style="width: 150px; height: 5px">
                <asp:TextBox ID="txtecode" runat="server" AutoPostBack="True" BackColor="#FFFF80"
                    Width="88px"></asp:TextBox></td>
            <td style="width: 97px; height: 5px">
                Empname</td>
            <td style="width: 91px; height: 5px">
                <asp:Label ID="lblename" runat="server" ForeColor="#C00000"></asp:Label></td>
            <td style="width: 125px; color: #000000; height: 5px">
                Passport No.</td>
            <td style="width: 100px; height: 5px">
                <asp:Label ID="lblppno" runat="server" ForeColor="#C00000"></asp:Label></td>
        </tr>
        <tr style="color: #000000">
            <td style="width: 100px; height: 18px">
                Section</td>
            <td style="width: 150px; height: 18px">
                <asp:Label ID="lblsect" runat="server" ForeColor="#C00000"></asp:Label></td>
            <td style="width: 97px; color: #000000; height: 18px">
                Designation</td>
            <td style="width: 91px; height: 18px">
                <asp:Label ID="lbldesig" runat="server" ForeColor="#C00000"></asp:Label></td>
            <td style="width: 125px; color: #000000; height: 18px">
                Visa Ref.No</td>
            <td style="width: 100px; height: 18px">
                <asp:Label ID="lblvisa" runat="server" ForeColor="#C00000"></asp:Label></td>
        </tr>
        <tr style="color: #000000">
            <td style="width: 100px; height: 17px">
                Country</td>
            <td style="width: 150px; height: 17px">
                <asp:Label ID="lblcountry" runat="server" ForeColor="#C00000"></asp:Label></td>
            <td style="width: 97px; color: #000000; height: 17px">
                Group</td>
            <td style="width: 91px; height: 17px">
                <asp:Label ID="lblgroup" runat="server" ForeColor="#C00000"></asp:Label></td>
            <td style="width: 125px; color: #000000; height: 17px">
                Address</td>
            <td style="width: 100px; height: 17px">
                <asp:Label ID="lbladrs" runat="server" ForeColor="#C00000"></asp:Label></td>
        </tr>
        <tr style="color: #000000">
            <td style="width: 100px">
                Missing Date</td>
            <td colspan="5">
                <asp:TextBox ID="txtmissing" runat="server" Width="111px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtmissing"
                    ErrorMessage="*"></asp:RequiredFieldValidator></td>
        </tr>
        <tr style="color: #000000">
            <td class="td_head" colspan="6" style="height: 17px">
                POLICE DETAILS</td>
        </tr>
        <tr>
            <td style="width: 100px">
                Police No.</td>
            <td style="width: 150px">
                <asp:TextBox ID="txtpoliceno" runat="server" Width="112px"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtpoliceno" ErrorMessage="*"></asp:RequiredFieldValidator></td>
            <td style="width: 97px; color: #000000">
                Station Name</td>
            <td style="width: 91px">
                <asp:TextBox ID="txtstation" runat="server" Width="120px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtstation"
                    ErrorMessage="*"></asp:RequiredFieldValidator></td>
            <td style="width: 125px; color: #000000">
                Place
            </td>
            <td style="width: 100px">
                <asp:TextBox ID="txtpplace" runat="server" Width="128px"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtpplace" ErrorMessage="*"></asp:RequiredFieldValidator></td>
        </tr>
        <tr style="color: #000000">
            <td style="width: 100px; height: 19px">
                Officer Name</td>
            <td style="width: 150px; height: 19px">
                <asp:TextBox ID="txtpofficer" runat="server" Width="110px"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtpofficer" ErrorMessage="*"></asp:RequiredFieldValidator></td>
            <td style="width: 97px; color: #000000; height: 19px">
                Complaint Date</td>
            <td style="width: 91px; height: 19px">
                <asp:TextBox ID="txtcdate" runat="server" Width="122px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtcdate"
                    ErrorMessage="*"></asp:RequiredFieldValidator></td>
            <td style="width: 125px; color: #000000; height: 19px">
                File No.</td>
            <td style="width: 100px; height: 19px">
                <asp:TextBox ID="txtfile" runat="server" Width="128px"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtfile" ErrorMessage="*"></asp:RequiredFieldValidator></td>
        </tr>
        <tr style="color: #000000">
            <td style="width: 100px; height: 16px">
                Fine Amount</td>
            <td colspan="5" style="height: 16px">
                <asp:TextBox ID="txtpamt" runat="server" Width="108px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtpamt"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtpamt"
                    ErrorMessage="!" ValidationExpression="^\d*$" ValidationGroup="a">Only Numbers </asp:RegularExpressionValidator></td>
        </tr>
        <tr style="color: #000000">
            <td class="td_head" colspan="6">
                IMMIGRATION DETAILS</td>
        </tr>
        <tr>
            <td style="width: 100px; height: 23px">
                Immigration No.</td>
            <td style="width: 150px; height: 23px">
                <asp:TextBox ID="txtimm" runat="server" Width="112px"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtimm" ErrorMessage="*"></asp:RequiredFieldValidator></td>
            <td style="width: 97px; color: #000000; height: 23px">
                Place</td>
            <td style="width: 91px; height: 23px">
                <asp:TextBox ID="txtiplace" runat="server" Width="118px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtiplace"
                    ErrorMessage="*"></asp:RequiredFieldValidator></td>
            <td style="width: 125px; height: 23px">
                Officer Name</td>
            <td style="width: 100px; height: 23px">
                <asp:TextBox ID="txtiofficer" runat="server" Width="130px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtiofficer"
                    ErrorMessage="*"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 21px">
                Date</td>
            <td style="width: 150px; height: 21px">
                <asp:TextBox ID="txtidate" runat="server" Width="111px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtidate"
                    ErrorMessage="*"></asp:RequiredFieldValidator></td>
            <td style="width: 97px; height: 21px">
                ER Officer Name</td>
            <td colspan="3" style="height: 21px">
                <asp:TextBox ID="txtierofficer" runat="server" Width="116px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtierofficer"
                    ErrorMessage="*"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td class="td_head" colspan="6">
                EMBASSY DETAILS</td>
        </tr>
        <tr>
            <td style="width: 100px">
                Embassy No.</td>
            <td style="width: 150px">
                <asp:TextBox ID="txtembasssy" runat="server" Width="108px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtembasssy"
                    ErrorMessage="*"></asp:RequiredFieldValidator></td>
            <td style="width: 97px">
                Place</td>
            <td style="width: 91px">
                <asp:TextBox ID="txteplace" runat="server" Width="120px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txteplace"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            <td style="width: 125px">
                Officer Name</td>
            <td style="width: 100px">
                <asp:TextBox ID="txteofficer" runat="server" Width="136px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txteofficer"
                    ErrorMessage="*"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 18px">
                Date</td>
            <td style="width: 150px; height: 18px">
                <asp:TextBox ID="txtedate" runat="server" Width="110px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtedate"
                    ErrorMessage="*" Width="15px"></asp:RequiredFieldValidator></td>
            <td style="width: 97px; height: 18px">
                ER officer Name</td>
            <td style="width: 91px; height: 18px">
                <asp:TextBox ID="txteerofficer" runat="server" Width="125px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txteerofficer"
                    ErrorMessage="*"></asp:RequiredFieldValidator></td>
            <td style="width: 125px; height: 18px">
                Fine Amount</td>
            <td style="width: 100px; height: 18px">
                <asp:TextBox ID="txteamt" runat="server" Width="135px"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator19" runat="server" ControlToValidate="txteamt" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txteamt"
                    ErrorMessage="!" ValidationExpression="^\d*$" ValidationGroup="a">Only Numbers </asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td align="right" colspan="6">
                <asp:Button ID="txtbtnsave" runat="server" SkinID="buttonskin1" Text="SAVE" /></td>
        </tr>
    </table>
    <br />
    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="cal_Theme1"
        Format="dd/MM/yy" PopupButtonID="txtmissing" TargetControlID="txtmissing">
    </cc1:CalendarExtender>
    <cc1:CalendarExtender ID="Calendarextender2" runat="server" CssClass="cal_Theme1"
        Format="dd/MM/yy" PopupButtonID="txtcdate" TargetControlID="txtcdate">
    </cc1:CalendarExtender>
    <cc1:CalendarExtender ID="Calendarextender3" runat="server" CssClass="cal_Theme1"
        Format="dd/MM/yy" PopupButtonID="txtidate" TargetControlID="txtidate">
    </cc1:CalendarExtender>
    <cc1:CalendarExtender ID="Calendarextender4" runat="server" CssClass="cal_Theme1"
        Format="dd/MM/yy" PopupButtonID="txtedate" TargetControlID="txtedate">
    </cc1:CalendarExtender>

</asp:Content>
