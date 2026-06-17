<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="RptSMSgrpFrm.aspx.vb" Inherits="E_Management.RptSMSgrpFrm" 
    title="SMS Groups" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <cr:crystalreportviewer id="CrystalReportViewer1" runat="server" autodatabind="True"
        enabledatabaselogonprompt="False" enableparameterprompt="False" height="1115px"
        reportsourceid="CrystalReportSource1" width="886px" ToolbarImagesFolderUrl="../images/toolbar/" GroupTreeImagesFolderUrl="../images/tree/" ></cr:crystalreportviewer>
    <cr:crystalreportsource id="CrystalReportSource1" runat="server">
<Report FileName="G:\E-Management\SMS\RptSMSgroups.rpt"></Report>
</cr:crystalreportsource>
</asp:Content>
