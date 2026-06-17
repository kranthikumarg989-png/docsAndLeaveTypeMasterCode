Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Public Class leavereportsbyselection
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim stat, dept, lt, emp As String
    Dim rpt As New lvreport

    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CrystalReportViewer1.ReportSource = rpt


        stat = LTrim(RTrim(Session("lrep")))  'overall
        Dim fromd As String = Session("lfromd")
        Dim tod As String = Session("ltod")
        dept = LTrim(RTrim(Session("ldept")))
        lt = LTrim(RTrim(Session("lleavetype")))
        emp = LTrim(RTrim(Session("lemp")))

        'MsgBox(stat & dept & lt & emp)
        'MsgBox(fromd & tod) 


        'If lt <> "-1" Or lt <> "" Then
        '    CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{leaveabsentism_rpt.fromdate} >= datetime('" & fromd & "')  and {leaveabsentism_rpt.todate} <= datetime('" & tod & "')"

        'Else

        'End If


        'If stat = "O" Then

        '    CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{leaveabsentism_rpt.fromdate} >= datetime('" & fromd & "')  and {leaveabsentism_rpt.todate} <= datetime('" & tod & "')"

        'Else

        'End If


    End Sub

End Class
