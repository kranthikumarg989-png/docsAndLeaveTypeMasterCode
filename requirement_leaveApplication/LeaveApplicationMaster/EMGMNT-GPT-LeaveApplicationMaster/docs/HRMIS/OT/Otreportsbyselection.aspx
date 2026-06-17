<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile ="~/ems.Master" CodeBehind="Otreportsbyselection.aspx.vb" Inherits="E_Management.Otreportsbyselection" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    &nbsp;<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True"
        DisplayGroupTree="False" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False"
        Height="815px" ReportSourceID="CrystalReportSource1" Width="1022px" />
    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        <Report FileName="OTOverallReport.rpt">
        </Report>
    </CR:CrystalReportSource>

</asp:Content>