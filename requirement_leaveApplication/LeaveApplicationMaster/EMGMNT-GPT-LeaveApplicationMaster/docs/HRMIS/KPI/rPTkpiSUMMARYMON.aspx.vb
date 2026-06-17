Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Public Class rPTkpiSUMMARYMON
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim rptby, status As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        rptby = Session("kpiRptbys")

        If rptby = "E" Then ' Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{kpi_grade_result.yr} = '" & Session("kpiyrs") & "' and {kpi_grade_result.mnth} = '" & Session("kpimons") & "'   and {empmaster.Empcode} =  '" & Session("kpiemps") & "'"
        ElseIf rptby = "D" Then ' Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{kpi_grade_result.yr} = '" & Session("kpiyrs") & "' and {kpi_grade_result.mnth} =  '" & Session("kpimons") & "'  and {empmaster.departmentcode} =  '" & Session("kpidepts") & "'"
        ElseIf rptby = "Desi" Then ' Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{kpi_grade_result.yr} = '" & Session("kpiyrs") & "' and {kpi_grade_result.mnth} = '" & Session("kpimons") & "' and {empmaster.designation} =  '" & Session("kpidesigs") & "'"
        ElseIf rptby = "S" Then ' Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{kpi_grade_result.yr} = '" & Session("kpiyrs") & "' and {kpi_grade_result.mnth} = '" & Session("kpimons") & "' and {empmaster.sectioncode} =  '" & Session("kpisects") & "'"
        ElseIf rptby = "O" Then ' Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{kpi_grade_result.yr} = '" & Session("kpiyrs") & "' and {kpi_grade_result.mnth} = '" & Session("kpimons") & "'"
        End If

    End Sub

End Class