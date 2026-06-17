<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SchedDomWasteOverallRpt.aspx.vb" Inherits="E_Management.SchedDomWasteOverallRpt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Schedule/ Domestic Waste Overall Report</title>
</head>
<body>
        <form id="form2" runat="server">
   <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True"
        DisplayGroupTree="False" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False"
        Height="1039px" ReportSourceID="CrystalReportSource1" Width="773px" />
    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        <Report FileName="WasteConsignmentOverall.rpt">
        </Report>
    </CR:CrystalReportSource>
       </form>
</body>
</html>
