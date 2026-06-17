Public Partial Class manpowerdetails
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub rb1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb1.SelectedIndexChanged
        If rb1.SelectedValue = "D" Then
            desig.Enabled = False
            dept.Enabled = True
            sect.Enabled = False
            opr.Enabled = False
        ElseIf rb1.SelectedValue = "DSG" Then
            desig.Enabled = True
            dept.Enabled = False
            sect.Enabled = False
            opr.Enabled = False
        ElseIf rb1.SelectedValue = "S" Then
            desig.Enabled = False
            dept.Enabled = False
            sect.Enabled = True
            opr.Enabled = False
        ElseIf rb1.SelectedValue = "OP" Then
            opr.Enabled = True
            desig.Enabled = False
            dept.Enabled = False
            sect.Enabled = False
        ElseIf rb1.SelectedValue = "OF" Then
            opr.Enabled = False
            desig.Enabled = False
            dept.Enabled = False
            sect.Enabled = False
        ElseIf rb1.SelectedValue = "OA" Then
            opr.Enabled = False
            desig.Enabled = False
            dept.Enabled = False
            sect.Enabled = False
        End If
    End Sub
    Protected Sub showrepOT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles showrepOT.Click
        If rb1.SelectedValue = "DSG" And desig.SelectedValue = "-1" Then
            desig.Focus()
            MessageBox("Select Designation")
            Exit Sub
        ElseIf rb1.SelectedValue = "D" And dept.SelectedValue = "-1" Then
            dept.Focus()
            MessageBox("Select Designation")
            Exit Sub
        ElseIf rb1.SelectedValue = "S" And sect.SelectedValue = "-1" Then
            sect.Focus()
            MessageBox("Select Designation")
            Exit Sub
        End If
        If rb1.SelectedValue = "DSG" Then
            Session("qry") = "{empmaster.designation} =  '" & (desig.SelectedValue) & "' And {empmaster.resigned} =  'N'"
            Response.Redirect("manpowerdetailsrpt.aspx")             'by desig
        ElseIf rb1.SelectedValue = "D" Then
            Session("qry") = "{empmaster.departmentcode} =  '" & (dept.SelectedValue) & "' And {empmaster.resigned} =  'N'"
            Response.Redirect("manpowerdetailsrpt.aspx")
        ElseIf rb1.SelectedValue = "S" Then
            Session("qry") = "{empmaster.sectioncode} =  '" & (sect.SelectedValue) & "' And {empmaster.resigned} =  'N'"
            Response.Redirect("manpowerdetailsrpt.aspx")
        ElseIf rb1.SelectedValue = "ALL" Then
            Session("qry") = "{empmaster.resigned} =  'N'"
            Response.Redirect("manpowerdetailsrpt.aspx")

        ElseIf rb1.SelectedValue = "OP" Then
            If opr.SelectedValue = "LO" Then
                Session("qry") = "{empmaster.designation} =  'operator' And {empmaster.foreignemp} =  'N' And {empmaster.resigned} =  'N'"
            ElseIf opr.SelectedValue = "FO" Then
                Session("qry") = "{empmaster.designation} =  'operator' And {empmaster.foreignemp} =  'Y' And {empmaster.resigned} =  'N'"
            End If
            Response.Redirect("manpoweroprpt.aspx")                  'by operator
        ElseIf rb1.SelectedValue = "OA" Then
            Response.Redirect("OverallManpowersummary.aspx")

        End If
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
End Class