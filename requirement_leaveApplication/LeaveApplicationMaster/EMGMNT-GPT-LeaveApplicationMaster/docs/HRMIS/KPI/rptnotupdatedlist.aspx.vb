Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Public Class rptnotupdatedlist
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CrystalReportSource1.Report.FileName = "rptKPINotUplatedlist.rpt"
        CrystalReportViewer1.ReportSourceID = CrystalReportSource1.ID
        CrystalReportViewer1.DataBind()
        CrystalReportViewer1.RefreshReport()

    End Sub

End Class