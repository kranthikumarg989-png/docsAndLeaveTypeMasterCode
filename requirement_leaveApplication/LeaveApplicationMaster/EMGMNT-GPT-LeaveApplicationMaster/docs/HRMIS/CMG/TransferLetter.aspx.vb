Public Partial Class TransferLetter
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        name.Text = Session("empname")
        desig.Text = Session("desig")
        dept.Text = Session("deptcode")
        sect.Text = Session("sect")
        newsect.Text = Session("newsect")
        dept1.Text = Session("deptcode")
        deptname.Text = Session("deptname")
        deptname1.Text = Session("newdeptname")
        empno.Text = Session("empcode_cmg")
        letdt.Text = Session("letdt")
        refno.Text = Session("refno")
        'trfrto.Text = Session("name1")
        efffrom.Text = Session("dteff1")
        newdeptname.Text = Session("newdeptname")
        newdeptcode.Text = Session("newdept")
        newdeptname1.Text = Session("newdeptname")
        newdeptcode1.Text = Session("newdept")
        empname1.Text = Session("empname")
        ppno.Text = Session("ppic")




    End Sub

End Class