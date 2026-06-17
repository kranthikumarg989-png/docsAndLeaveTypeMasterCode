Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Public Class Cpreports
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim stat As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        stat = Session("CPStat")
        Dim fromd As String = Session("CPfromd")
        Dim tod As String = Session("CPtod")


        If stat = "E" Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{clinicstaffgatepass.dateapplied} >= datetime('" & fromd & "')  And {clinicstaffgatepass.dateapplied} <= datetime('" & tod & "') and {empmaster.Empcode} =  '" & Session("CPemp") & "'"
        ElseIf stat = "D" Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{clinicstaffgatepass.dateapplied} >= datetime('" & fromd & "')  And {clinicstaffgatepass.dateapplied} <= datetime('" & tod & "') and {empmaster.departmentcode} =  '" & Session("CPdept") & "'"
        ElseIf stat = "Desi" Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{clinicstaffgatepass.dateapplied} >= datetime('" & fromd & "')  And {clinicstaffgatepass.dateapplied} <= datetime('" & tod & "') and {empmaster.designation} =  '" & Session("CPdesig") & "'"
        ElseIf stat = "S" Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{clinicstaffgatepass.dateapplied} >= datetime('" & fromd & "')  And {clinicstaffgatepass.dateapplied} <= datetime('" & tod & "') and {empmaster.sectioncode} =  '" & Session("CPsect") & "'"
        ElseIf stat = "O" Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{clinicstaffgatepass.dateapplied} >= datetime('" & fromd & "')  And {clinicstaffgatepass.dateapplied} <= datetime('" & tod & "')"
        End If

    End Sub

End Class