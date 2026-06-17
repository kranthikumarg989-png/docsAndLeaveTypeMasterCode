<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="memoreportapp.aspx.vb" Inherits="E_Management.memoreportapp" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>MemoApproval report</title>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True" EnableDatabaseLogonPrompt=false EnableParameterPrompt=false 
        Height="1039px" ReportSourceID="CrystalReportSource1" Style="z-index: 134; left: 0px;
        position: absolute; top: 0px" Width="901px" DisplayToolbar="true" />
    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        <Report FileName="CrystalReport2.rpt">
        </Report>
    </CR:CrystalReportSource>
 </div>
    </form>
</body>
</html>