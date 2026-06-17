<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FrmLeaveFormView.aspx.vb" Inherits="E_Management.FrmLeaveFormView" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>LeaveReport by Employee</title>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="padding-left:2px;padding-top:10px;padding-top:20px;">
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"  DisplayGroupTree="false" DisplayToolbar="false" />
    </div>
    </form>
</body>
</html>
