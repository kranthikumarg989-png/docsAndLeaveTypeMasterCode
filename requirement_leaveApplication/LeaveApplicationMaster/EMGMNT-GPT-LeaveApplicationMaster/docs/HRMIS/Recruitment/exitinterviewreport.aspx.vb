Public Partial Class exitinterviewreport
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        empcode.Visible = False
    End Sub
    Protected Sub cb1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb1.CheckedChanged
        If cb1.Checked = True Then
            empcode.Visible = True
            empcode.Focus()
            txtfrom.Text = ""
            txtto.Text = ""
            txtfrom.Enabled = False
            txtto.Enabled = False
        Else
            empcode.Text = ""
            empcode.Visible = False
            txtfrom.Enabled = True
            txtto.Enabled = True
        End If
    End Sub
    Protected Sub showrepOT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles showrepOT.Click
        If empcode.Text <> "" Then
            'Session("ecod") = empcode.Text
            Session("ecod") = "SELECT emp_exitinterview.Empcode, empmaster.Empname, empmaster.Designation, empmaster.Sectioncode, empmaster.Departmentcode, empmaster.Dateofjoin, emp_exitinterview.Reason, emp_exitinterview.others FROM emp_exitinterview INNER JOIN empmaster ON emp_exitinterview.empcode = empmaster.empcode WHERE (empmaster.empcode='" & empcode.Text & "')"
        Else
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
            'Session("allfromd") = fd

            Dim td1 As String
            td1 = txtto.Text.Trim
            Dim strdate2() As String = td1.Split("/"c)
            td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

            Dim td As Date
            td = CDate(td1)
            'Session("alltod") = td
            Session("ecod") = "SELECT emp_exitinterview.Empcode,empmaster.Empname, empmaster.Designation, empmaster.Sectioncode, empmaster.Departmentcode, empmaster.Dateofjoin, emp_exitinterview.Reason, emp_exitinterview.Others FROM emp_exitinterview INNER JOIN empmaster ON emp_exitinterview.empcode = empmaster.empcode WHERE (emp_exitinterview.datekeyin >= '" & fd & "' AND emp_exitinterview.datekeyin <= '" & td & "') order by empmaster.empcode"
        End If
        Response.Redirect("exitinterviewgridreport.aspx")
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
End Class