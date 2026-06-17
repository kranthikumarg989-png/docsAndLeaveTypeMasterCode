Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Public Class RptMajForIndiv
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim kpiyr, dept, emp As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CrystalReportViewer1.DataBind()
        CrystalReportViewer1.RefreshReport()

        kpiyr = Session("kpiyr")
        emp = Session("kpiemp")

        CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{KPI_MajorSetting.KPI_Year} = " & kpiyr & " and {KPI_MajorSetting.Employee_Code} = '" & emp & "' "

    End Sub

End Class