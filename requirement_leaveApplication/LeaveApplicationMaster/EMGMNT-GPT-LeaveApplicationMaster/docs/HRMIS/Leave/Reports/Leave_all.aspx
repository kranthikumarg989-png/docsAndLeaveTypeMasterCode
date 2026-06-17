<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="Leave_all.aspx.vb" Inherits="E_Management.Leave_all1" 
    title="Untitled Page" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table style="width: 100%; height: 100%">
        <tr>
            <td style="width: 100px" valign="top">
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True"
                    Height="1055px" ReportSourceID="CrystalReportSource1" Width="901px" EnableDatabaseLogonPrompt =false  
                    EnableParameterPrompt=false  />
                <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                    <Report FileName="Leave_all.rpt">
                    </Report>
                </CR:CrystalReportSource>
            </td>
        </tr>
    </table>

</asp:Content>
