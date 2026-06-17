Public Partial Class RptbudgetOverall
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LBLFROM.Text = Session("budgetfrom")
        LBLTO.Text = Session("budgetTO")
    End Sub

End Class