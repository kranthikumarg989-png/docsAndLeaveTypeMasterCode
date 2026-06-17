Partial Public Class leaveentitilement1
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CrystalReportViewer1.DataBind()
        CrystalReportViewer1.RefreshReport()
    End Sub
End Class