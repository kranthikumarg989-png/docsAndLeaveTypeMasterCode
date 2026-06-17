Public Partial Class COntractExtensionTempatanLetter
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        name.Text = Session("empname")
        dept.Text = Session("deptcode")
        empcode.Text = Session("empcode_cmg")
        ltdate.Text = Session("ltdt")
        refno.Text = Session("refno")
        frmdt.Text = Session("ctefffrom1")
        '  todt.Text = Session("cteffto1")
        doj.Text = Session("dj")
        '  prob.Text = Session("prob")

    End Sub

End Class