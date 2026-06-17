Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class exitinterview
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim sqltext, keyinby As String
    Dim rdr As SqlDataReader
    Dim cmd As New SqlCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        Con = New SqlConnection(constr)
        Con.Open()
        If IsPostBack = False Then
            empcode.Focus()
        End If
        'Session("_ename") = "IT"         'for implement purpose hotcode removed
        keyinby = Session("empname")
        datetoday.Text = Date.Now.ToShortDateString
    End Sub
    Protected Sub empcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles empcode.TextChanged
        If IsNumeric(empcode.Text) Then
            empname.Text = ""
            section.Text = ""
            department.Text = ""
            sqltext = "select empname,sectioncode,departmentcode from empmaster where empcode='" & (empcode.Text) & "'"
            cmd = New SqlCommand(sqltext, Con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                empname.Text = rdr(0)
                section.Text = rdr(1)
                department.Text = rdr(2)
            End While
            rdr.Close()
            If empname.Text = "" Then
                MessageBox("Enter Correct Empcode")
                empcode.Text = ""
                empcode.Focus()
            End If
        Else
            MessageBox("Empcode Not Exist in The Database Re-enter correct Empcode")
            empname.Text = ""
            section.Text = ""
            department.Text = ""
            empcode.Text = ""
            empcode.Focus()
        End If
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Protected Sub save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles save.Click
        Dim reason, cma As String
        keyinby = Session("empname")
        cma = ","
        reason = cma
        If cb1.Checked = False And cb2.Checked = False And cb3.Checked = False And cb4.Checked = False And cb5.Checked = False And cb6.Checked = False And cb7.Checked = False And cb8.Checked = False And cb9.Checked = False And cb10.Checked = False And cb11.Checked = False Then
            MessageBox("Check Reason for leaving ")
            Exit Sub
        End If
        If cb1.Checked = True Then
            reason = cma & cb1.Text & cma
        End If
        If cb2.Checked = True Then
            reason = reason & cma & cb2.Text & cma
        End If
        If cb3.Checked = True Then
            reason = reason & cma & cb3.Text & cma
        End If
        If cb4.Checked = True Then
            reason = reason & cma & cb4.Text & cma
        End If
        If cb5.Checked = True Then
            reason = reason & cma & cb5.Text & cma
        End If
        If cb6.Checked = True Then
            reason = reason & cma & cb6.Text & cma
        End If
        If cb7.Checked = True Then
            reason = reason & cma & cb7.Text & cma
        End If
        If cb8.Checked = True Then
            reason = reason & cma & cb8.Text & cma
        End If
        If cb9.Checked = True Then
            reason = reason & cma & cb9.Text & cma
        End If
        If cb10.Checked = True Then
            reason = reason & cma & cb10.Text & cma
        End If
        If cb11.Checked = True Then
            reason = reason & cma & cb11.Text & cma
        End If
        If reason.Contains(",,") = True Then
            reason = reason.Replace(",,", ",")
        End If
        reason = Right(reason, Len(reason) - 1)
        reason = Left(reason, Len(reason) - 1)
        sqltext = "insert into emp_exitinterview values('" & (empcode.Text) & "','" & reason & "','" & (others.Text) & "','" & (likeleast.Text) & "','" & (deptenv.Text) & "','" & (barriers.Text) & "','" & (supervisor.Text) & "','" & (peers.Text) & "','" & (subordinates.Text) & "','" & (comments.Text) & "','" & (rb1.SelectedValue) & "','" & (uniformdate.Text) & "','" & (datetoday.Text) & "','" & keyinby & "')"
        cmd = New SqlCommand(sqltext, Con)
        cmd.ExecuteNonQuery()
        MessageBox("Record Saved Sucessfully")
        empcode.Text = ""
        others.Text = ""
        likeleast.Text = ""
        deptenv.Text = ""
        barriers.Text = ""
        supervisor.Text = ""
        peers.Text = ""
        subordinates.Text = ""
        comments.Text = ""
        uniformdate.Text = ""
        datetoday.Text = ""
        rb1.Items(0).Selected = False
        rb1.Items(1).Selected = False
        cb1.Checked = False
        cb2.Checked = False
        cb3.Checked = False
        cb4.Checked = False
        cb5.Checked = False
        cb6.Checked = False
        cb7.Checked = False
        cb8.Checked = False
        cb9.Checked = False
        cb10.Checked = False
        cb11.Checked = False
        empname.Text = ""
        section.Text = ""
        department.Text = ""
    End Sub
End Class