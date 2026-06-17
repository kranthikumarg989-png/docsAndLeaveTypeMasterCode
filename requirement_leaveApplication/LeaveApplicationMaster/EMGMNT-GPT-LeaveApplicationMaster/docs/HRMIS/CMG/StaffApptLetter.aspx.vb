Public Partial Class StaffApptLetter
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        empname.Text = Session("empname")
        empname1.Text = Session("empname")
        desig.Text = Session("desig")
        age.Text = Session("cmg_age")
        deptname.Text = Session("deptname")
        desig.Text = Session("desig")
        doj.Text = Session("dateofjoin")
        ldate.Text = Session("letdt")
        refno.Text = Session("refno")
        prob.Text = Session("contract")
        extprob.Text = Session("extprob")
        bsa.Text = Session("bsa")
        pall.Text = Session("pall")
        all1.Text = Session("all1")
        all2.Text = Session("all2")
        allow1.Text = Session("allow1")
        a1colon.Text = Session("a1colon")
        a2colon.Text = Session("a2colon")
        
        allow2.Text = Session("allow12")
        tot.Text = Session("tot")
        targ.Text = Session("target")
        nric.Text = Session("nric")
        icno.Text = Session("nric")
        curr.text = Session("curr")
        curr1.Text = Session("curr1")

    End Sub

End Class