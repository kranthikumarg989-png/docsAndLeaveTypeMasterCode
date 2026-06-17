Public Partial Class OptAppraisalDH
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub Appraisal_view(ByVal sender As Object, ByVal e As CommandEventArgs)
        'Dim empid As String
        'Dim lb As LinkButton = TryCast(sender, LinkButton)
        Session("optempapp") = e.CommandArgument
        Response.Redirect("OperatorAppraisalViewaspx.aspx")
    End Sub

End Class