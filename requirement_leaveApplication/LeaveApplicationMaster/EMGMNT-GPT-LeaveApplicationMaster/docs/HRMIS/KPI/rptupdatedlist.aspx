<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="rptupdatedlist.aspx.vb" Inherits="E_Management.rptupdatedlist" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>KPI UPDATED LIST</title>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <cr:crystalreportviewer id="CrystalReportViewer1" runat="server" autodatabind="True"
            displaygrouptree="False" enabledatabaselogonprompt="False" enableparameterprompt="False"
            height="1055px" reportsourceid="CrystalReportSource1" width="773px"></cr:crystalreportviewer>
        <cr:crystalreportsource id="CrystalReportSource1" runat="server">
<Report FileName="RptKPIUpdated.rpt"></Report>
</cr:crystalreportsource>
    
    </div>
    </form>
</body>
</html>
