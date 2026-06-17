Public Partial Class ContractExtensionLetter
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        name.Text = Session("empname")
        desig.Text = Session("desig")
        dept.Text = Session("deptcode")
        empcode.Text = Session("empcode_cmg")
        ltdate.Text = Session("letdt")
        refno.Text = Session("refno")
        efffrom.Text = Session("efffrom4")
        effto.Text = Session("effto4")
        months.Text = Session("months")
        oldbsa.Text = Session("oldbsa4")
        oldbsa1.Text = Session("oldbsa4")
        newbsa.Text = Session("newbsa4")
        newbsa1.Text = Session("newbsa4")
        oldnpa.Text = Session("oldpa4")
        oldnpa1.Text = Session("oldpa4")
        newnpa.Text = Session("newpa4")
        newnpa1.Text = Session("newpa4")

    End Sub

End Class