Public Partial Class COntractExtensionPFPletter
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        name.Text = Session("empname")
        desig.Text = Session("desig")
        dept.Text = Session("deptcode")
        empcode.Text = Session("empcode_cmg")
        ltdt.Text = Session("letdt5")
        efffrom.Text = Session("efffrom5")
        effto.Text = Session("effto5")
        months.Text = Session("months5")
        doj.Text = Session("dj")
        nric.Text = Session("ic")
        posall.Text = Session("posall5")
        posall1.Text = Session("posall5")
        bassal.Text = Session("bassal5")
        splinc.Text = Session("splinc5")
        nbasicsal.Text = Session("nbasicsal5")

    End Sub

End Class