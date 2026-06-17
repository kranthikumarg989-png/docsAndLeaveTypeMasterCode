Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Public Class RptMajorKPIforDept
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim kpiyr, dept As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CrystalReportViewer1.DataBind()
        CrystalReportViewer1.RefreshReport()

        kpiyr = Session("kpiyr")
        dept = Session("kpidept")

        CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{KPI_MajorSetting.KPI_Year} = " & kpiyr & "  And {KPI_MajorSetting.Department_Code} = '" & dept & "'"

    End Sub


End Class