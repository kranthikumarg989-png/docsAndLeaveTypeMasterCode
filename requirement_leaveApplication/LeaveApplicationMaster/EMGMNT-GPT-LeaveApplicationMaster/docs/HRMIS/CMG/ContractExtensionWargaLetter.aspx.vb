Public Partial Class ContractExtensionWargaLetter
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        name.Text = Session("empname")
        desig.Text = Session("desig")
        empcode.Text = Session("empcode_cmg")
        ltdate.Text = Session("letdt")
        refno.Text = Session("refno")
        dteff.Text = Session("efffrom2")
        extmonths.Text = Session("prob")
        doj.Text = Session("dj")
        dtto.Text = Session("effto2")
        contperiod.Text = Session("prob")

    End Sub

End Class