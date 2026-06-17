Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Public Class rptmajorsublistyr
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim rptby, status As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CrystalReportViewer1.DataBind()
        CrystalReportViewer1.RefreshReport()

        rptby = Session("KpiRptby")
        status = Session("Kpimthnday")

        If rptby = "E" Then ' Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{KPI_SubSetting.KPI_year} = " & Session("kpiyr") & "   and {empmaster.Empcode} =  '" & Session("kpiemp") & "'"
        ElseIf rptby = "D" Then ' Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{KPI_SubSetting.KPI_year} = " & Session("kpiyr") & "    and {empmaster.departmentcode} =  '" & Session("kpidept") & "'"
        ElseIf rptby = "Desi" Then ' Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{KPI_SubSetting.KPI_year} = " & Session("kpiyr") & "   and {empmaster.designation} =  '" & Session("kpidesig") & "'"
        ElseIf rptby = "S" Then ' Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{KPI_SubSetting.KPI_year} = " & Session("kpiyr") & "    and {empmaster.sectioncode} =  '" & Session("kpisect") & "'"
        ElseIf rptby = "O" Then ' Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{KPI_SubSetting.KPI_year} = " & Session("kpiyr") & ""
        End If
    End Sub

End Class