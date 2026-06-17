Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Public Class rptupdatedlist
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim rptby, status As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CrystalReportViewer1.DataBind()
        CrystalReportViewer1.RefreshReport()

        rptby = Session("KpiRptbyU")

        If rptby = "E" Then ' Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{kpi_grade_result.yr} = '" & Session("kpiyru") & "' and {kpi_grade_result.mnth} = '" & Session("kpimonu") & "'   and {empmaster.Empcode} =  '" & Session("kpiempu") & "'"
        ElseIf rptby = "D" Then ' Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{kpi_grade_result.yr} = '" & Session("kpiyru") & "' and {kpi_grade_result.mnth} =  '" & Session("kpimonu") & "'  and {empmaster.departmentcode} =  '" & Session("kpideptu") & "'"
        ElseIf rptby = "Desi" Then ' Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{kpi_grade_result.yr} = '" & Session("kpiyru") & "' and {kpi_grade_result.mnth} = '" & Session("kpimonu") & "' and {empmaster.designation} =  '" & Session("kpidesigu") & "'"
        ElseIf rptby = "S" Then ' Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{kpi_grade_result.yr} = '" & Session("kpiyru") & "' and {kpi_grade_result.mnth} = '" & Session("kpimonu") & "' and {empmaster.sectioncode} =  '" & Session("kpisectu") & "'"
        ElseIf rptby = "O" Then ' Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{kpi_grade_result.yr} = '" & Session("kpiyru") & "' and {kpi_grade_result.mnth} = '" & Session("kpimonu") & "'"
        End If

    End Sub

End Class