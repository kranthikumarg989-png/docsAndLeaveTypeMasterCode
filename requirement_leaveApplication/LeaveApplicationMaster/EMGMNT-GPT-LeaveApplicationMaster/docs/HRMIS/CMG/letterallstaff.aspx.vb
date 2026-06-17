Public Partial Class letterallstaff
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        name.Text = Session("name")
        dept.Text = Session("dept")
        desig.Text = Session("desig")
        empcode.Text = Session("empcode")
        vdate.Text = Session("vdate")
        edate.Text = Session("edate")
        edate1.Text = edate.Text
        edate2.Text = edate.Text
        pfp.Text = Session("pfp")
    End Sub

End Class