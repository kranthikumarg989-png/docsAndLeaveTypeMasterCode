
Partial Public Class RptOTquery
    Inherits System.Web.UI.Page
    Protected Sub rdoptions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoptions.SelectedIndexChanged
        If rdoptions.SelectedValue = "Dept" Then
            ddldeptr.Enabled = True
            ddlsectrpt.Enabled = False
            ddldesigr.Enabled = False
            txtempidr.Enabled = False
        ElseIf rdoptions.SelectedValue = "Sect" Then
            ddldeptr.Enabled = False
            ddlsectrpt.Enabled = True
            ddldesigr.Enabled = False
            txtempidr.Enabled = False
        ElseIf rdoptions.SelectedValue = "Desig" Then
            ddldeptr.Enabled = False
            ddlsectrpt.Enabled = False
            ddldesigr.Enabled = True
            txtempidr.Enabled = False
        ElseIf rdoptions.SelectedValue = "Emp" Then
            ddldeptr.Enabled = False
            ddlsectrpt.Enabled = False
            ddldesigr.Enabled = False
            txtempidr.Enabled = True
        Else
            ddldeptr.Enabled = False
            ddlsectrpt.Enabled = False
            ddldesigr.Enabled = False
            txtempidr.Enabled = False
        End If

    End Sub
    Protected Sub showrep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles showrep.Click
        Dim rdvalue As String
        rdvalue = rdoptions.SelectedValue

        Session("otdesig") = Trim(ddldesigr.SelectedValue)
        Session("otemp") = Trim(txtempidr.Text)
        Session("otsect") = Trim(ddlsectrpt.SelectedValue)
        Session("otdept") = ddldeptr.SelectedValue.Trim
        Session("Otstatus") = RadioButtonList1.SelectedValue

        Dim fd1 As String
        fd1 = txtfrom.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)
        Session("allfromd") = fd

        Dim td1 As String
        td1 = txtto.Text.Trim
        Dim strdate2() As String = td1.Split("/"c)
        td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

        Dim td As Date
        td = CDate(td1)
        Session("alltod") = td


        If rdvalue = "Dept" And ddldeptr.SelectedValue <> "" Then
            Session("otstat") = "D"
        ElseIf rdvalue = "Sect" And ddlsectrpt.SelectedValue <> "" Then
            Session("otstat") = "S"
        ElseIf rdvalue = "Desig" And ddldesigr.SelectedValue <> "" Then
            Session("otstat") = "Desi"
        ElseIf rdvalue = "Emp" And txtempidr.Text <> "" Then
            Session("otstat") = "E"
        Else
            Session("otstat") = "O"
        End If

        Response.Redirect("OTreportsbyselection.aspx")
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

End Class