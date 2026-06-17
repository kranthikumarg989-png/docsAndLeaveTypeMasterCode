<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="jobapplicationprinting.aspx.vb" Inherits="E_Management.jobapplicationprinting" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
   <script type="text/javascript">
<!--
function delayer()
{
    window.print()
}
//-->

</script>
    <title>Letter create</title>
    <link rel="stylesheet" type="text/css" href="~/css/style.css" /> 
            <link rel="stylesheet" type="text/css" href="~/css/stylesheet.css" />
</head>
<body  onLoad="setTimeout('delayer()', 2000)">
    <form id="form1" runat="server">
    <div>
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True" Height="1013px" Width="901px" ReportSourceID="CrystalReportSource1" />
    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        <Report FileName="CrystalReport3.rpt">
        </Report>
    </CR:CrystalReportSource>
   </div> 
   </form>
</body>
</html>
