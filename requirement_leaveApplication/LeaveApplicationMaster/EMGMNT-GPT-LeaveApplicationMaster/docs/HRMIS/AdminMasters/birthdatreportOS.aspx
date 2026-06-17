<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="birthdatreportOS.aspx.vb" Inherits="E_Management.birthdatreportOS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<head id="Head1" runat="server">
    <title>Birthday Reports</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True"
        DisplayGroupTree="False" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False"
        Height="1039px" ReportSourceID="CrystalReportSource1" Width="773px" />
 <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
<Report FileName="birthdaycalenderOS.rpt">
</Report>
    </CR:CrystalReportSource>
    </div>
    </form>
</body>
</html>
