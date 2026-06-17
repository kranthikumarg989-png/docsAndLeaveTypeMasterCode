Public Partial Class BT_Print
    Inherits System.Web.UI.Page
    Dim _from, _to

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empcode") <> "" Then
            Response.Redirect("~\hrmis\default.aspx")
        Else
            Response.Redirect("~\logout.aspx")
        End If

        _from = DateTime.Now.AddMonths(-1)
        Dim days = System.DateTime.DaysInMonth(Year(_from), Month(_from))
        _from = Month(_from) & "/01/" & Year(_from)
        _to = DateTime.Now
    End Sub


    Protected Sub SqlBTFMD_Selecting(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlBTFMD.Selecting
        e.Command.Parameters(0).Value = _from
        e.Command.Parameters(1).Value = _to
    End Sub
End Class