Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Public Class SchedDomWasteByDeptWeightRpt
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim ename, eicno As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim fromd As String = Session("allfromd")
        Dim tod As String = Session("alltod")

        'CrystalReportViewer1.RefreshReport()

        'CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{sdw_rptbyweight_temp.fromdate} >= '" & fromd & "' and {sdw_rptbyweight_temp.todate} <= '" & tod & "'"


    End Sub

End Class