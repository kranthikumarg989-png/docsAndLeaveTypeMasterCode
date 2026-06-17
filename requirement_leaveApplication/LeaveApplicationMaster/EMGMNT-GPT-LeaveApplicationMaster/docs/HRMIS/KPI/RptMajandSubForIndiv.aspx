<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RptMajandSubForIndiv.aspx.vb" Inherits="E_Management.RptMajandSubForIndiv" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>KPI Report For Major and Sub KPI for Individuals</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True"
        DisplayGroupTree="False" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False"
        Height="815px" ReportSourceID="CrystalReportSource1" Width="1022px" />
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="KpiSubByIndiv.rpt">
            </Report>
        </CR:CrystalReportSource>

    </div>
    </form>
</body>
</html>
