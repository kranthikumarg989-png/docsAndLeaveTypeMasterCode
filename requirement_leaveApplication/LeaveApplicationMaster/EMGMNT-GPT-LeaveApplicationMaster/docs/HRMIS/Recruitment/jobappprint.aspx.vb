Public Partial Class jobappprint
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ddlapplno.Focus()
    End Sub
    Protected Sub view_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles View.Click
        Session("appln") = Val(ddlapplno.SelectedValue.Trim).ToString
        Response.Redirect("jobapplicationprinting.aspx")
    End Sub
    Protected Sub ddlapplno_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlapplno.SelectedIndexChanged
        For i As Integer = 0 To ddlapplno.Items.Count - 1
            If ddlapplno.Items(i).Selected = True Then
                ddlapplno.Items(i).Text = Val(ddlapplno.SelectedValue)
            End If
        Next
    End Sub
End Class