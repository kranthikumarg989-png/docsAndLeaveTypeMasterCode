<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="sectrpt.aspx.vb" Inherits="E_Management.sectrpt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
    
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SECTION REPORT</title>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 16px; height: 16px">
                    <img height="16" src="../../images/top_lef.gif" width="16" /></td>
                <td background="../../images/top_mid.gif" style="width: 725px; height: 16px">
                    <img height="16" src="../../images/top_mid.gif" width="16" /></td>
                <td style="width: 25px; height: 16px">
                    <img height="16" src="../../images/top_rig.gif" width="24" /></td>
            </tr>
            <tr>
                <td background="../../images/cen_lef.gif" style="width: 16px; height: 248px">
                    <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
                <td bgcolor="#ffffff" style="width: 725px" valign="top">
                    <CR:CrystalReportViewer ID="CrystalReportViewer3" runat="server" AutoDataBind="True"
                        EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" Height="1055px"
                        ReportSourceID="CrystalReportSource3" Width="773px" />
                    <CR:CrystalReportSource ID="CrystalReportSource3" runat="server">
                        <Report FileName="section.rpt">
                        </Report>
                    </CR:CrystalReportSource>
                </td>
                <td background="../../images/cen_rig.gif" style="width: 25px; height: 248px">
                    <img height="11" src="../../images/cen_rig.gif" width="24" /></td>
            </tr>
            <tr>
                <td height="16" width="16">
                    <img height="16" src="../../images/bot_lef.gif" width="16" /></td>
                <td background="../../images/bot_mid.gif" height="16" style="width: 725px">
                    <img height="16" src="../../images/bot_mid.gif" width="16" /></td>
                <td height="16" style="width: 25px">
                    <img height="16" src="../../images/bot_rig.gif" width="24" /></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
