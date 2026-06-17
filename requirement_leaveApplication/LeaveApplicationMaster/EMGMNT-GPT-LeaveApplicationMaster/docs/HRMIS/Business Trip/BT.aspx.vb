Public Partial Class BT
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Redirect("~\logout.aspx")
    End Sub

    Protected Sub Menu1_MenuItemClick(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles Menu1.MenuItemClick

    End Sub
End Class