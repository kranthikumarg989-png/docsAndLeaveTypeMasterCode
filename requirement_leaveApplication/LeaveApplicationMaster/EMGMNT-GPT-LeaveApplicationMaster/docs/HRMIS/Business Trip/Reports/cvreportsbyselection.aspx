<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="cvreportsbyselection.aspx.vb" Inherits="E_Management.cvreportsbyselection" 
    title="Customer Visit Report" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <cr:crystalreportviewer id="CrystalReportViewer1" runat="server" autodatabind="True"
        displaygrouptree="False" displaytoolbar="False" enabledatabaselogonprompt="False"
        enableparameterprompt="False" height="789px" reportsourceid="CrystalReportSource1"
        width="1022px"></cr:crystalreportviewer>
    <cr:crystalreportsource id="CrystalReportSource1" runat="server">
<Report FileName="F:\E-Management\HRMIS\Business Trip\Reports\CVoverall.rpt"></Report>
</cr:crystalreportsource>

</asp:Content>
