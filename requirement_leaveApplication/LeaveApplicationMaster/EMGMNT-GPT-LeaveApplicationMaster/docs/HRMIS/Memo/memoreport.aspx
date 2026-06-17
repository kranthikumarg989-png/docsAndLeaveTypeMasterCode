<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="memoreport.aspx.vb" Inherits="E_Management.memoreport" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>MemoRising view</title>
        <script type="text/javascript">
<!--
function delayer()
{
    window.print()
}
//-->

</script>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body  onLoad="setTimeout('delayer()', 2000)">
    <form id="form1" runat="server">
    <div>
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True"
            Height="1013px" ReportSourceID="CrystalReportSource1"  Width="773px" DisplayToolbar="true" DisplayGroupTree="False" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False"  />
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="CrystalReport1.rpt">
            </Report>
        </CR:CrystalReportSource>
    
    </div>
    </form>
</body>
</html>
