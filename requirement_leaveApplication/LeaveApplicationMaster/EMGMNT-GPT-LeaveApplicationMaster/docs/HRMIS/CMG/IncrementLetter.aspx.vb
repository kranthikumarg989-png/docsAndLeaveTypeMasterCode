Public Partial Class IncrementLetter
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        name.Text = Session("empname")
        dept.Text = Session("deptcode")
        empno.Text = Session("empcode")
        desig.Text = Session("desig")
        ltdate.Text = Session("letdt")
        refno.Text = Session("refno")
        bsa.Text = Session("bsa")
        nbsa.Text = Session("nbsa")
        pall.Text = Session("pall")
        splinc.Text = Session("splinc")
        pfpall.Text = Session("pfpall")
        effdate.Text = Session("effdt")
        curr.Text = Session("curr")
        curr1.Text = Session("curr1")
        posallow.Text = Session("posallow")
        pfpallow.Text = Session("pfpallow")

    End Sub

End Class