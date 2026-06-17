<%@ Page Language="vb" AutoEventWireup="false" Codebehind="frmRptIssueDetails.aspx.vb"
    Inherits="E_Management.frmRptIssueDetails" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td align="left">
                        <div>
                            <cr:crystalreportviewer id="CrystalReportViewer1" runat="server" autodatabind="True"
                                reportsourceid="CrystalReportSource1" displaygrouptree="false" />
                            <cr:crystalreportsource id="CrystalReportSource1" runat="server">
                             <%--   <Report FileName="RptPOreport.rpt">
                                </Report>--%>
                            </cr:crystalreportsource>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
