<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="rptkpimajorsublist.aspx.vb" Inherits="E_Management.rptkpimajorsublist" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>KPI Major /Sub List Report</title>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <cr:crystalreportviewer id="CrystalReportViewer1" runat="server" autodatabind="True"
            displaygrouptree="False" enabledatabaselogonprompt="False" enableparameterprompt="False"
            height="815px" reportsourceid="CrystalReportSource1" width="1022px"></cr:crystalreportviewer>
        <cr:crystalreportsource id="CrystalReportSource1" runat="server">
<Report FileName="KpiMajorSub.rpt"></Report>
</cr:crystalreportsource>
    
    </div>
    </form>
</body>
</html>
