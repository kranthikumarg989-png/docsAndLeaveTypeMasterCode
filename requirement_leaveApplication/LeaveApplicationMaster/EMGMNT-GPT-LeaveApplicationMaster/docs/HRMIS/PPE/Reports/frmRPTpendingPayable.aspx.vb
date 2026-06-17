Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Partial Public Class frmRPTpendingPayable
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.rptcon()
        Dim crConnectionInfo As ConnectionInfo = New ConnectionInfo
        With crConnectionInfo
            .ServerName = sver
            .DatabaseName = dbname
            .UserID = uid
            .Password = pw
        End With
        Dim crystalReport As New ReportDocument()
        crystalReport.Load(Server.MapPath("rptPendingPayable.rpt"))
        crystalReport.SetDatabaseLogon("'" + uid + "'", "'" + pw + "'", "'" + sver + "'", "'" + dbname + "'")
        crystalReport.SetParameterValue("@Dept", Request.QueryString("Dept"))
        CrystalReportViewer1.ReportSource = crystalReport
    End Sub
End Class