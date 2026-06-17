Public Partial Class Promotion_PFPLetter
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        name.Text = Session("empname")
        dept.Text = Session("deptcode")
        empno.Text = Session("empcode_cmg")
        ltdate.Text = Session("ltdate")
        refno.Text = Session("refno")
        newdesig.Text = Session("pnewdesig")
        dteff.Text = Session("prodteff")
        obs.Text = Session("obs")
        opa.Text = Session("opa")
        nbs.Text = Session("nbs")
        npa.Text = Session("npa")
        npfpall.Text = Session("npfpall")
        totsal.Text = Session("totsal")


    End Sub

End Class