Public Partial Class er_reportshostel
    Inherits System.Web.UI.Page
    Dim tempstr As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'txtto.Text = Date.Now.ToShortDateString
        If rb1.SelectedValue = "al" Then
            empcode.Text = ""
            empcode.Enabled = False
            dept.Enabled = False
            sect.Enabled = False
        End If
        If IsPostBack = False Then
            lettername.Items.Add(New ListItem("---------Select Letter Name---------", "-1"))
            lettername.Items.Add(New ListItem("Verbal Warning Late Less Than 30 Min", "1"))
            lettername.Items.Add(New ListItem("Verbal Warning Late More Than 30 Min", "2"))
            lettername.Items.Add(New ListItem("Verbal Warning Late More Than 1 Hour", "3"))
            lettername.Items.Add(New ListItem("Late More than 24 Reports", "4"))
            lettername.Items.Add(New ListItem("First warning Late Less Than 30 Min", "5"))
            lettername.Items.Add(New ListItem("First warning Late More Than 30 Min", "6"))
            lettername.Items.Add(New ListItem("First warning Late More than 1 Hour", "7"))
            lettername.Items.Add(New ListItem("Final warning Late Less Than 30 Min", "8"))
            lettername.Items.Add(New ListItem("Final warning Late More Than 30 Min", "9"))
            lettername.Items.Add(New ListItem("Final warning Late More Than 1 Hr", "10"))
            lettername.Items.Add(New ListItem("Final Warning Over Night Stay", "11"))
        End If
    End Sub
    Protected Sub showrepOT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles showrepOT.Click
        If txtfrom.Text.Trim <> "" And txtto.Text.Trim <> "" Then
        Else
            MessageBox("Enter Date Field")
            Exit Sub
        End If
        If lettername.SelectedValue = "-1" Then
            MessageBox("Select Letter Type")
            lettername.Focus()
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
        Call ddlsql()
        If rb1.SelectedValue = "al" Then
            'tempstr = "SELECT Empcode,latecomingtime as Latetime,Latecomingdate,LetterDate FROM what WHERE latecomingdate >='" & fd & "' AND latecomingdate <=  '" & td & "'"
            tempstr = "SELECT * FROM what WHERE latecomingdate >='" & fd & "' AND latecomingdate <=  '" & td & "'"
            If tempstr.ToString.Contains("what") = True Then
                tempstr = tempstr.ToString.Replace("what", Session("tblname").ToString)
                If lettername.SelectedValue = 11 Then
                    tempstr = "SELECT * FROM er_finalwarninghostel WHERE letterdate >='" & fd & "' AND letterdate <= '" & td & "'"
                End If
                Session("sql") = tempstr
            End If
        ElseIf rb1.SelectedValue = "emp" Then
            tempstr = "SELECT * FROM what WHERE latecomingdate >='" & fd & "' AND latecomingdate <=  '" & td & "' and empcode='" & empcode.Text & "'"
            If tempstr.ToString.Contains("what") = True Then
                tempstr = tempstr.ToString.Replace("what", Session("tblname").ToString)
                If lettername.SelectedValue = 11 Then
                    tempstr = "SELECT * FROM er_finalwarninghostel WHERE letterdate >='" & fd & "' AND letterdate <= '" & td & "'and empcode='" & empcode.Text & "'"
                End If
                Session("sql") = tempstr
            End If
        ElseIf rb1.SelectedValue = "dpt" Then
            tempstr = "SELECT empmaster.Departmentcode,what.* from what INNER JOIN empmaster ON what.empcode = empmaster.empcode WHERE (empmaster.departmentcode = '" & (dept.SelectedValue) & "' and (empmaster.resigned <>'Y') and ((what.latecomingdate >= '" & fd & "') and  (what.latecomingdate <= '" & td & "')))"
            If tempstr.ToString.Contains("what") = True Then
                tempstr = tempstr.ToString.Replace("what", Session("tblname").ToString)
                If lettername.SelectedValue = 11 Then
                    tempstr = "SELECT empmaster.Departmentcode,er_finalwarninghostel.* from  er_finalwarninghostel INNER JOIN  empmaster ON er_finalwarninghostel.empcode = empmaster.empcode WHERE (empmaster.departmentcode = '" & dept.SelectedValue & "') and (empmaster.resigned <>'Y') and (er_finalwarninghostel.letterdate >= '" & fd & "' and  er_finalwarninghostel.letterdate <= '" & td & "')"
                End If
                Session("sql") = tempstr
            End If
        ElseIf rb1.SelectedValue = "sec" Then
            tempstr = "SELECT empmaster.Sectioncode,what.* from what INNER JOIN empmaster ON what.empcode = empmaster.empcode WHERE (empmaster.sectioncode = '" & (sect.SelectedValue) & "' and (empmaster.resigned <>'Y') and ((what.latecomingdate >= '" & fd & "') and  (what.latecomingdate <= '" & td & "')))"
            If tempstr.ToString.Contains("what") = True Then
                tempstr = tempstr.ToString.Replace("what", Session("tblname").ToString)
                If lettername.SelectedValue = 11 Then
                    tempstr = "SELECT empmaster.Sectioncode,er_finalwarninghostel.* from  er_finalwarninghostel INNER JOIN  empmaster ON er_finalwarninghostel.empcode = empmaster.empcode WHERE (empmaster.sectioncode = '" & sect.SelectedValue & "') and (empmaster.resigned <>'Y') and (er_finalwarninghostel.letterdate >= '" & fd & "' and  er_finalwarninghostel.letterdate <= '" & td & "')"
                End If
                Session("sql") = tempstr
            End If
        End If
        Response.Redirect("er_reporthostelgrid.aspx")
    End Sub
    Protected Sub rb1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb1.SelectedIndexChanged
        If rb1.SelectedValue = "emp" Then
            empcode.Text = ""
            empcode.Enabled = True
            empcode.Focus()
            dept.Enabled = False
            sect.Enabled = False
        ElseIf rb1.SelectedValue = "dpt" Then
            empcode.Enabled = False
            dept.Enabled = True
            dept.Focus()
            sect.Enabled = False
        ElseIf rb1.SelectedValue = "sec" Then
            empcode.Enabled = False
            dept.Enabled = False
            sect.Enabled = True
            sect.Focus()
            empcode.Enabled = False
        Else
        End If
    End Sub
    Sub ddlsql()
        If lettername.SelectedValue = 1 Then
            Session("tblname") = "er_verbalwarningbelow30min"
        ElseIf lettername.SelectedValue = 2 Then
            Session("tblname") = "er_verbalwarningabove30min"
        ElseIf lettername.SelectedValue = 3 Then
            Session("tblname") = "er_verbalwarningmorethan1hour"
        ElseIf lettername.SelectedValue = 4 Then
            Session("tblname") = "er_latemorethan24hrs"
        ElseIf lettername.SelectedValue = 5 Then
            Session("tblname") = "er_firstwarningbelow30min"
        ElseIf lettername.SelectedValue = 6 Then
            Session("tblname") = "er_firstwarningabove30min"
        ElseIf lettername.SelectedValue = 7 Then
            Session("tblname") = "er_firstwarningmorethan1hour"
        ElseIf lettername.SelectedValue = 8 Then
            Session("tblname") = "er_finalwarningless30"
        ElseIf lettername.SelectedValue = 9 Then
            Session("tblname") = "er_finalwarningabove30"
        ElseIf lettername.SelectedValue = 10 Then
            Session("tblname") = "er_finalwarningmore1"
        ElseIf lettername.SelectedValue = 11 Then
            Session("tblname") = "er_finalwarninghostel"
        End If
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
End Class