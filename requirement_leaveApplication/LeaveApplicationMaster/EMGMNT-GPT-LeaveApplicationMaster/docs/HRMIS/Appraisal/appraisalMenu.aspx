<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="appraisalMenu.aspx.vb" Inherits="E_Management.appraisalMenu" 
    title="appraisal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <asp:Menu ID="Menu1" runat="server" BackColor="#E3EAEB" DynamicHorizontalOffset="2"
        Font-Names="Verdana" Font-Size="Medium" ForeColor="#666666"
        StaticSubMenuIndent="10px">
        <StaticSelectedStyle BackColor="#1C5E55" />
        <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <DynamicHoverStyle BackColor="#666666" ForeColor="White" />
        <DynamicMenuStyle BackColor="#E3EAEB" />
        <DynamicSelectedStyle BackColor="#1C5E55" />
        <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <StaticHoverStyle BackColor="#666666" ForeColor="White" />
        <Items>
            <asp:MenuItem NavigateUrl="~/HRMIS/Appraisal/ProbContractExpList.aspx" Text="Payroll alert"
                Value="Payroll alert">
                <asp:MenuItem NavigateUrl="~/HRMIS/Appraisal/ProbContractExpList.aspx" Text="Probation Expiry List"
                    Value="Probation Expiry List"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/HRMIS/Appraisal/ConractExpListPayroll.aspx" Text="Contract Expiry List"
                    Value="Contract Expiry List"></asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/HRMIS/Appraisal/PCexpiryListHOD.aspx" Text="HOD alert"
                Value="HOD alert">
                <asp:MenuItem NavigateUrl="~/HRMIS/Appraisal/PCexpiryListHOD.aspx" Target="_blank"
                    Text="Probation Expiry List" Value="Probation Expiry List"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/HRMIS/Appraisal/contractExpListHOD.aspx" Target="_blank"
                    Text="contract Expiry List" Value="contract Expiry List"></asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/HRMIS/Appraisal/PCExpityListEA.aspx" Text="EA Approval"
                Value="EA Approval">
                <asp:MenuItem NavigateUrl="~/HRMIS/Appraisal/PCExpityListEA.aspx" Target="_blank"
                    Text="Probation Expiry List" Value="Probation Expiry List"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/HRMIS/Appraisal/contractExpiryListEA.aspx" Target="_blank"
                    Text="contract Expiry List" Value="contract Expiry List"></asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/HRMIS/Appraisal/PCExpiryListSH.aspx" Target="_blank"
                Text="SH Alert " Value="SH Alert "></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/HRMIS/Appraisal/SelfAppraisal.aspx" Text="Self appraisal"
                Value="Self appraisal"></asp:MenuItem>
        </Items>
    </asp:Menu>
</asp:Content>
