Public Partial Class PromotionLetter
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        name.Text = Session("empname")
        dept.Text = Session("deptcode")
        desig.Text = Session("desig")
        empno.Text = Session("empcode_cmg")
        ltdate.Text = Session("letdt1")
        refno.Text = Session("refno")
        newdesig.Text = Session("newdesig")
        dteff.Text = Session("efffrom1")
        obs.Text = Session("oldbsa1")
        opa.Text = Session("oldpa1")
        nbs.Text = Session("newbsa1")
        npa.Text = Session("newpa1")
        pfpall.Text = Session("oldpfp1")
        npfpall.Text = Session("newpfp1")
        totsal.Text = Session("totsal1")

    End Sub

End Class