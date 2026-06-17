Imports System.Data
Imports System
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports E_Management.emanagement.[Global]
Partial Public Class crvGpall
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '  Dim ConnInfo As New ConnectionInfo
        Dim fromd As String
        Dim tod As String

   

        'With ConnInfo
        '    .ServerName = sqlServerName
        '    .DatabaseName = sqlDBName
        '    .UserID = sqlUid
        '    .Password = sqlPwd
        'End With

        fromd = Session("gpfd")
        tod = Session("gptd")
       

        Me.CrystalReportViewer1.ParameterFieldInfo.Clear()
        Me.CrystalReportViewer1.ReportSource = Server.MapPath("rptGpall.rpt")
        Dim ParamFields As ParameterFields = Me.CrystalReportViewer1.ParameterFieldInfo

        Dim gp_gpdaterange As New ParameterField
        gp_gpdaterange.Name = "gp_gpdaterange"
        Dim p_OrderDateRange_Value As New ParameterRangeValue
        p_OrderDateRange_Value.StartValue = fromd
        p_OrderDateRange_Value.EndValue = tod
        gp_gpdaterange.CurrentValues.Add(p_OrderDateRange_Value)
        ParamFields.Add(gp_gpdaterange)
     
        'For Each cnInfo As TableLogOnInfo In Me.CrystalReportViewer1.LogOnInfo
        '    cnInfo.ConnectionInfo = ConnInfo
        'Next
        Me.CrystalReportViewer1.RefreshReport()
    End Sub


End Class