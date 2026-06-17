Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Public Class Reports
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim stat As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        stat = Session("MCStat")
        Dim fromd As String = Session("MCfromd")
        Dim tod As String = Session("MCtod")
        Dim mc = "Y"

        If stat = "E" Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{tbldiagnose.fromdate} >= datetime('" & fromd & "')  And {tbldiagnose.todate} <= datetime('" & tod & "') and {empmaster.Empcode} =  '" & Session("MCemp") & "' and  {tbldiagnose.mcissued} = '" & mc & "'"
        ElseIf stat = "D" Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{tbldiagnose.fromdate} >= datetime('" & fromd & "')  And {tbldiagnose.todate} <= datetime('" & tod & "') and {empmaster.departmentcode} =  '" & Session("MCdept") & "' and  {tbldiagnose.mcissued} = '" & mc & "'"
        ElseIf stat = "Desi" Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{tbldiagnose.fromdate} >= datetime('" & fromd & "')  And {tbldiagnose.todate} <= datetime('" & tod & "') and {empmaster.designation} =  '" & Session("MCdesig") & "' and  {tbldiagnose.mcissued} = '" & mc & "'"
        ElseIf stat = "S" Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{tbldiagnose.fromdate} >= datetime('" & fromd & "')  And {tbldiagnose.todate} <= datetime('" & tod & "') and {empmaster.sectioncode} =  '" & Session("MCsect") & "' and  {tbldiagnose.mcissued} = '" & mc & "'"
        ElseIf stat = "O" Then
            CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{tbldiagnose.fromdate} >= datetime('" & fromd & "')  And {tbldiagnose.todate} <= datetime('" & tod & "')"
        End If

    End Sub

End Class