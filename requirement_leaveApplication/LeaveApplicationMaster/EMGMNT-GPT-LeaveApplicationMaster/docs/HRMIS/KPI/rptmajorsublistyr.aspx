<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="rptmajorsublistyr.aspx.vb" Inherits="E_Management.rptmajorsublistyr" 
    title="KPI MAJOR SUB LIST BY YEAR" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <cr:crystalreportviewer id="CrystalReportViewer1" runat="server" autodatabind="True"
        displaygrouptree="False" enabledatabaselogonprompt="False" enableparameterprompt="False"
        height="1055px" reportsourceid="CrystalReportSource1" width="773px"></cr:crystalreportviewer>
    <cr:crystalreportsource id="CrystalReportSource1" runat="server">
<Report FileName="KPIMajorSubMon.rpt"></Report>
</cr:crystalreportsource>

</asp:Content>
