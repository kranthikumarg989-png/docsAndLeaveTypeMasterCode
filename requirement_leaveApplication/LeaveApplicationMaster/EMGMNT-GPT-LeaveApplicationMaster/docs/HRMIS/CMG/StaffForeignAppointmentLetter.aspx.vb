Public Partial Class StaffForeignAppointmentLetter
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        empname.Text = Session("empname")
        empname1.Text = Session("empname")
        desig.Text = Session("desig")
        age.Text = Session("cmg_age")
        deptname.Text = Session("deptname")
        desig.Text = Session("desig")
        doc.Text = Session("doc")
        ldate.Text = Session("letdt")
        refno.Text = Session("refno")
        prob.Text = Session("extprob")
        bsa.Text = Session("bsa")
        pall.Text = Session("pall")
        tot.Text = Session("tot")
        targ.Text = Session("target")
        nric.Text = Session("nric")
        curr.Text = Session("curr")
        allow.Text = Session("allow")

    End Sub

End Class