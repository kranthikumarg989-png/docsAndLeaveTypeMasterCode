Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Partial Public Class ProbTrialExtRpt
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim ename, eicno, wename, wit As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim fromd As String = Session("efffrom")
        Dim tod As String = Session("effto")
        Dim ldate As String = Session("letdet")
        ename = LTrim(RTrim(Session("AFNname")))
        wename = LTrim(RTrim(Session("AFNwname")))


        CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{emp_probationextend.empcode} = '" & ename & "'"

    End Sub

End Class