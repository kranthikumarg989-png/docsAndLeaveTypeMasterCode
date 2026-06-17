<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="crvCsall.aspx.vb" Inherits="E_Management.crvCsall" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>CS Reports</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid">
        <tr>
        <td>
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True"
            Height="1055px" ReportSourceID="CrystalReportSource1" Width="901px"
             EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" 
             ReuseParameterValuesOnRefresh="True" DisplayGroupTree="false"  
        />
         </td>
        </tr>
        </table>
        <br />
        
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="rptcspass.rpt">
            </Report>
        </CR:CrystalReportSource>
    
    </div>
    </form>
</body>
</html>