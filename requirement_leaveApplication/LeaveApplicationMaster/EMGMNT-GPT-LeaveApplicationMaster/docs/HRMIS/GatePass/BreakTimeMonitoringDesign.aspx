<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BreakTimeMonitoringDesign.aspx.vb" Inherits="E_Management.BreakTimeMonitoringDesign" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <span style="font-size: 9pt"><strong><a href="BreakTimeMonitoring.aspx">Home<br />
        </a></strong></span>
        <br />
        <cr:crystalreportviewer id="CrystalReportViewer1" runat="server" autodatabind="true"
            displaygrouptree="False" displaytoolbar="False" Height="50px" SeparatePages="False" Width="350px"></cr:crystalreportviewer>
    
    </div>
    </form>
</body>
</html>
