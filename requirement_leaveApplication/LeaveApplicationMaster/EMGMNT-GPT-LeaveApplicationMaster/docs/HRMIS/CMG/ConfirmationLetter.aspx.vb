Public Partial Class ConfirmationLetter
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        name.Text = Session("empname")
        desig.Text = Session("desig")
        desig1.Text = Session("desig")
        dept.Text = Session("deptcode")
        empcode.Text = Session("empcode_cmg")
        ltdate.Text = Session("letdt")
        refno.Text = Session("refno")
        effdt.Text = Session("efffrom3")
        prob.Text = Session("prob3")
        bsa.Text = Session("bsa3")
        ltdate1.Text = Session("letdt")

    End Sub

End Class