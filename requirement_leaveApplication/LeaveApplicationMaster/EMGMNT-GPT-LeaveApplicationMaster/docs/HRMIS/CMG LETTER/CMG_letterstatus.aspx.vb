Public Partial Class CMG_letterstatus
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub
    Private Sub GridView1_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.PageIndexChanged
        TabContainer1.ActiveTabIndex = 0
    End Sub
    Private Sub GridView2_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView2.PageIndexChanged
        TabContainer1.ActiveTabIndex = 1
    End Sub
End Class