Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Public Class manresignjoinrptviewer
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim final As String
    Dim rp As New manresignjoin
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CrystalReportViewer1.ReportSource = rp
        CrystalReportViewer1.DataBind()
        CrystalReportSource1.ReportDocument.Refresh()
        CrystalReportViewer1.RefreshReport()
        final = Session("final")
        CrystalReportSource1.ReportDocument.RecordSelectionFormula = final
    End Sub
End Class