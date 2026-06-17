Public Partial Class ContractTermination
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        name.Text = Session("empname")
        dept.Text = Session("deptcode")
        empno.Text = Session("empcode_cmg")
        ltdate.Text = Session("letdt")
        refno.Text = Session("refno")
        desig.text = session("desig")
        efffrom.Text = Session("cteffdt")


    End Sub

End Class