Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Public Class rptkpimajorsublist
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim rptby, status As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CrystalReportViewer1.DataBind()
        CrystalReportViewer1.RefreshReport()

        rptby = Session("KpiRptby")
        status = Session("Kpimthnday")
        Dim chk = "-1"

        If status = "yr" Then
            If rptby = "E" Then ' Then
                CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{KPI_IndividualSetting.KPI_Year} = " & Session("kpiyr") & "  And {KPI_IndividualSetting.checked} = " & chk & "  and {empmaster.Empcode} =  '" & Session("kpiemp") & "'"
            ElseIf rptby = "D" Then ' Then
                CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{KPI_IndividualSetting.KPI_Year} = " & Session("kpiyr") & "  And {KPI_IndividualSetting.checked} = " & chk & "  and {empmaster.departmentcode} =  '" & Session("kpidept") & "'"
            ElseIf rptby = "Desi" Then ' Then
                CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{KPI_IndividualSetting.KPI_Year} = " & Session("kpiyr") & "  And {KPI_IndividualSetting.checked} = " & chk & " and {empmaster.designation} =  '" & Session("kpidesig") & "'"
            ElseIf rptby = "S" Then ' Then
                CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{KPI_IndividualSetting.KPI_Year} = " & Session("kpiyr") & "  And {KPI_IndividualSetting.checked} = " & chk & "  and {empmaster.sectioncode} =  '" & Session("kpisect") & "'"
            ElseIf rptby = "O" Then ' Then
                CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{KPI_IndividualSetting.KPI_Year} = " & Session("kpiyr") & "  And {KPI_IndividualSetting.checked} = " & chk & " "
            End If
        ElseIf status = "mth" Then
            If rptby = "E" Then ' Then
                CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{KPI_IndividualSetting.KPI_Year} = " & Session("kpiyr") & " and {KPI_IndividualSetting.KPI_month} = " & Session("kpimon") & "  And {KPI_IndividualSetting.checked} = " & chk & "  and {empmaster.Empcode} =  '" & Session("kpiemp") & "'"
            ElseIf rptby = "D" Then ' Then
                CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{KPI_IndividualSetting.KPI_Year} = " & Session("kpiyr") & " and {KPI_IndividualSetting.KPI_month} =  " & Session("kpimon") & " And {KPI_IndividualSetting.checked} = " & chk & "  and {empmaster.departmentcode} =  '" & Session("kpidept") & "'"
            ElseIf rptby = "Desi" Then ' Then
                CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{KPI_IndividualSetting.KPI_Year} = " & Session("kpiyr") & " and {KPI_IndividualSetting.KPI_month} = " & Session("kpimon") & " And {KPI_IndividualSetting.checked} = " & chk & " and {empmaster.designation} =  '" & Session("kpidesig") & "'"
            ElseIf rptby = "S" Then ' Then
                CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{KPI_IndividualSetting.KPI_Year} = " & Session("kpiyr") & " and {KPI_IndividualSetting.KPI_month} = " & Session("kpimon") & " And {KPI_IndividualSetting.checked} =" & chk & "  and {empmaster.sectioncode} =  '" & Session("kpisect") & "'"
            ElseIf rptby = "O" Then ' Then
                CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{KPI_IndividualSetting.KPI_Year} = " & Session("kpiyr") & " and {KPI_IndividualSetting.KPI_month} = " & Session("kpimon") & " And {KPI_IndividualSetting.checked} = " & chk & " "
            End If
        End If
      
    End Sub

End Class