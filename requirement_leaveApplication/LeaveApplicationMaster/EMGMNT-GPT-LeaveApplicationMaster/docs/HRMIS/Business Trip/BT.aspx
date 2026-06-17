<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="BT.aspx.vb" Inherits="E_Management.BT" 
    title="MENU Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <br />
    <asp:Menu ID="Menu1" runat="server" BackColor="#F7F6F3" DynamicHorizontalOffset="2"
        Font-Names="Verdana" Font-Size="Medium" ForeColor="#7C6F57" Orientation="Horizontal"
        StaticSubMenuIndent="10px">
        <StaticSelectedStyle BackColor="#5D7B9D" />
        <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <DynamicHoverStyle BackColor="#7C6F57" ForeColor="White" />
        <DynamicMenuStyle BackColor="#F7F6F3" />
        <DynamicItemTemplate>
            <%# Eval("Text") %>
        </DynamicItemTemplate>
        <DynamicSelectedStyle BackColor="#5D7B9D" />
        <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <StaticHoverStyle BackColor="#7C6F57" ForeColor="White" />
        <Items>
            <asp:MenuItem Text="Business Trip" Value="Business Trip">
                <asp:MenuItem Text="Applications" Value="Applications">
                    <asp:MenuItem NavigateUrl="~/HRMIS/Business Trip/BTform.aspx" Target="_blank" Text="BT Form"
                        Value="BT Form"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/Business Trip/TCform.aspx" Target="_blank" Text="TC form"
                        Value="TC form"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/Business Trip/BTCVform.aspx" Target="_blank" Text="CV Form"
                        Value="CV Form"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/Business Trip/BTSelfstatus.aspx" Target="_blank"
                        Text="Self Status" Value="Self Status"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="EAApprovals" Value="EAApprovals">
                    <asp:MenuItem NavigateUrl="~/HRMIS/Business Trip/BTEAViewaspx.aspx" Target="_blank"
                        Text="BT approval" Value="BT approval"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/Business Trip/TCEAApproval.aspx" Target="_blank"
                        Text="TC approval" Value="TC approval"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="HOD Approvals" Value="HOD Approvals">
                    <asp:MenuItem NavigateUrl="~/HRMIS/Business Trip/BTHODView.aspx" Target="_blank"
                        Text="BT View" Value="BT View"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/Business Trip/TCHodApproval.aspx" Target="_blank"
                        Text="TC approval" Value="TC approval"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Finance" Value="Finance">
                    <asp:MenuItem NavigateUrl="~/HRMIS/Business Trip/BTFMDView.aspx" Target="_blank"
                        Text="BT View" Value="BT View"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/Business Trip/TCfinance.aspx" Target="_blank"
                        Text="TC finance" Value="TC finance"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/Business Trip/TcFMDapproval.aspx" Target="_blank"
                        Text="TC FMD" Value="TC FMD"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Admin" Value="Admin">
                    <asp:MenuItem NavigateUrl="~/HRMIS/Business Trip/AdminBt.aspx" Target="_blank" Text="BT View"
                        Value="BT View"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/Business Trip/adminbtfareentry.aspx" Target="_blank"
                        Text="EDIT cost" Value="EDIT cost"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Reports" Value="Reports">
                    <asp:MenuItem NavigateUrl="~/HRMIS/Business Trip/Reports/ReportBT.aspx" Target="_blank"
                        Text="BT Reports" Value="BT Reports"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/Business Trip/Reports/ReportCV.aspx" Target="_blank"
                        Text="CV Reports" Value="CV Reports"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/Business Trip/Reports/ReportTC.aspx" Target="_blank"
                        Text="TC Reports" Value="TC Reports"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Master" Value="Master">
                    <asp:MenuItem NavigateUrl="~/HRMIS/Business Trip/Master_USDLimit.aspx" Target="_blank"
                        Text="USD Master" Value="USD Master"></asp:MenuItem>
                </asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem Text="LEAVE" Value="LEAVE">
                <asp:MenuItem Text="Leave Form" Value="Leave Form" NavigateUrl="~/HRMIS/Leave/Leaveform.aspx" Target="_blank"></asp:MenuItem>
                <asp:MenuItem Text="Self status" Value="Self status" NavigateUrl="~/HRMIS/Leave/Selfstatus.aspx" Target="_blank"></asp:MenuItem>
                <asp:MenuItem Text="Approvals" Value="Approvals">
                    <asp:MenuItem Text="HOD Approval" Value="HOD Approval" NavigateUrl="~/HRMIS/Leave/HODapproval.aspx" Target="_blank"></asp:MenuItem>
                    <asp:MenuItem Text="ER approval" Value="ER approval" NavigateUrl="~/HRMIS/Leave/ERApproval.aspx" Target="_blank"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Reports" Value="Reports">
                    <asp:MenuItem Text="Leave Entitilement" Value="Leave Entitilement" NavigateUrl="~/HRMIS/Leave/RptLeaveEntitilement.aspx" Target="_blank"></asp:MenuItem>
                    <asp:MenuItem Text="Leave Summary" Value="Leave Summary" NavigateUrl="~/HRMIS/Leave/rPTlEAVEoVERALLSUMMARY.aspx" Target="_blank"></asp:MenuItem>
                    <asp:MenuItem Text="HOD ALL Leave" Value="HOD ALL Leave" NavigateUrl="~/HRMIS/Leave/RPThod.aspx" Target="_blank"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/Leave/Rptleaveoverall.aspx" Target="_blank" Text="LeaveOverall"
                        Value="LeaveOverall"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/HRMIS/Leave/PayrollLeaveCancel.aspx" Target="_blank"
                    Text="Payroll Leave Cancel" Value="Payroll Leave Cancel"></asp:MenuItem>
            </asp:MenuItem>
              <asp:MenuItem Text="LETTER" Value="Letter " >
                <asp:MenuItem Text="ER" Value="ER"></asp:MenuItem>
                <asp:MenuItem Text="CMG" Value="CMG">
                    <asp:MenuItem NavigateUrl="~/HRMIS/CMG LETTER/WebForm3.aspx" Target="_blank" Text="New Letter"
                        Value="New Letter"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/CMG LETTER/Letterpage.aspx" Target="_blank" Text="Issue Letter"
                        Value="Issue Letter"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/CMG LETTER/CMG_letterstatus.aspx" Target="_blank"
                        Text="Status" Value="Status"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/CMG LETTER/CMG_letterstatusapprovasl.aspx" Target="_blank"
                        Text="Approval" Value="Approval"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/CMG LETTER/CMG_LetterModify.aspx" Target="_blank"
                        Text="Edit Letter" Value="Edit Letter"></asp:MenuItem>
                </asp:MenuItem> 
            </asp:MenuItem> 
        </Items>
    </asp:Menu>
</asp:Content>
