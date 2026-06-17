Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Public Class indtrainingrpt
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim ic
    Dim ltdt

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ic = Session("tdicno")
        ltdt = Session("tdldate")


        CrystalReportSource1.ReportDocument.RecordSelectionFormula = "{td_industrialtraining.td_icno} = '" & ic & "' and {td_industrialtraining.td_letterdate}= datetime('" & ltdt & "')"
    End Sub
End Class