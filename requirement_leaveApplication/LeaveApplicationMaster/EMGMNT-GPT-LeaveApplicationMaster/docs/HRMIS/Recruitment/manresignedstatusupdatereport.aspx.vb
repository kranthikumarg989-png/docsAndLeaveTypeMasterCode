Public Partial Class manresignedstatusupdatereport
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        status.Visible = False
        If rdoptions.SelectedValue = "A" Then
            ddldeptr.Enabled = False
            ddlsectrpt.Enabled = False
            ddldesigr.Enabled = False
        End If
    End Sub
    Protected Sub rdoptions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoptions.SelectedIndexChanged
        If rdoptions.SelectedValue = "Dept" Then
            ddldeptr.Enabled = True
            ddlsectrpt.Enabled = False
            ddldesigr.Enabled = False
        ElseIf rdoptions.SelectedValue = "Sect" Then
            ddldeptr.Enabled = False
            ddlsectrpt.Enabled = True
            ddldesigr.Enabled = False
        ElseIf rdoptions.SelectedValue = "Desig" Then
            ddldeptr.Enabled = False
            ddlsectrpt.Enabled = False
            ddldesigr.Enabled = True
        ElseIf rdoptions.SelectedValue = "DD" Then
            ddldeptr.Enabled = True
            ddlsectrpt.Enabled = False
            ddldesigr.Enabled = True
        Else
            ddldeptr.Enabled = False
            ddlsectrpt.Enabled = False
            ddldesigr.Enabled = False
        End If
    End Sub
    Protected Sub cb1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb1.CheckedChanged
        If cb1.Checked = True Then
            status.Visible = True
            ddldeptr.Enabled = False
            ddlsectrpt.Enabled = False
            ddldesigr.Enabled = False
            txtfrom.Text = ""
            txtto.Text = ""
            txtfrom.Enabled = False
            txtto.Enabled = False
            rdoptions.Enabled = False
            stscommon.Enabled = False

        Else
            txtfrom.Enabled = True
            txtto.Enabled = True
            rdoptions.Enabled = True
            status.Visible = False
            ddldeptr.Enabled = True
            ddlsectrpt.Enabled = True
            ddldesigr.Enabled = True
            stscommon.Enabled = True
            If rdoptions.SelectedValue = "A" Then
                ddldeptr.Enabled = False
                ddldesigr.Enabled = False
            End If
        End If
    End Sub
    Protected Sub showrepOT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles showrepOT.Click

        If cb1.Checked = True Then
            Session("sts") = status.SelectedValue
        Else
            Session("rb") = rdoptions.SelectedValue
            If txtfrom.Text.Trim <> "" And txtto.Text.Trim <> "" Then
            Else
                MessageBox("Enter Date Field")
                Exit Sub
            End If
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
            If rdoptions.SelectedValue = "Dept" And ddldeptr.SelectedValue <> "-1" Then
                Session("common") = ddldeptr.SelectedValue
            ElseIf rdoptions.SelectedValue = "Sect" And ddlsectrpt.SelectedValue <> "-1" Then
                Session("common") = ddlsectrpt.SelectedValue
            ElseIf rdoptions.SelectedValue.Trim = "Desig" And ddldesigr.SelectedValue <> "-1" Then
                Session("common") = ddldesigr.SelectedValue.ToString.Trim
            ElseIf rdoptions.SelectedValue = "DD" Then
                Session("common") = ddldeptr.SelectedValue.ToString.Trim
                Session("desigu") = ddldesigr.SelectedValue.ToString.Trim
            ElseIf rdoptions.SelectedValue = "A" Then
                Session("common") = "a"
            End If
        End If
        Session("stscommon") = stscommon.SelectedValue.Trim
        Response.Redirect("replacementgridreport.aspx")
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
End Class