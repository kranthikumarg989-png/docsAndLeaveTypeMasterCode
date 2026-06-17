Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class jobinterviewstatus
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim sqltext, keyinby As String
    Dim rdr As SqlDataReader
    Dim cmd As New SqlCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        datetoday.Text = Date.Now.ToShortDateString
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        Con = New SqlConnection(constr)
        Con.Open()
    End Sub
    Protected Sub ddlapplno_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlapplno.SelectedIndexChanged
        For i As Integer = 0 To ddlapplno.Items.Count - 1
            If ddlapplno.Items(i).Selected = True Then
                ddlapplno.Items(i).Text = Val(ddlapplno.SelectedValue)
                'MsgBox(ddlapplno.Items(i).Text)
            End If
        Next
        sqltext = "select name,positionapplied,applieddate,status from jobapplication where applicationno='" & Val(ddlapplno.SelectedValue) & "'"
        cmd = New SqlCommand(sqltext, Con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            name.Text = rdr(0)
            position.Text = rdr(1)
            dateapplied.Text = rdr(2)
            status.SelectedItem.Text = rdr(3)
        End While
        rdr.Close()
        If status.SelectedItem.Text = "S" Or status.SelectedItem.Text = "s" Then
            status.SelectedItem.Text = "Scheduled"
        End If
    End Sub
    Protected Sub status_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles status.SelectedIndexChanged
        If status.SelectedItem.Text.Contains("SEL") = True Then
            status.SelectedItem.Text = status.SelectedItem.Text.Replace("SEL", "Selected")
        ElseIf status.SelectedItem.Text.Contains("REJ") = True Then
            status.SelectedItem.Text = status.SelectedItem.Text.Replace("REJ", "Rejected")
        End If
    End Sub
    Protected Sub save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles save.Click
        If intby.Text.Trim = "" Then
            MessageBox("Enter EmpNo in Interview By")
            intby.Focus()
            Exit Sub
        End If
        If status.SelectedItem.Text = "Scheduled" Then
            status.SelectedIndex = 4
        End If
        sqltext = "update jobapplication set status='" & (status.SelectedValue) & "',statusdate='" & (datetoday.Text) & "',interviewby='" & (intby.Text) & "' where applicationno='" & Val(ddlapplno.SelectedValue) & "'"
        cmd = New SqlCommand(sqltext, Con)
        cmd.ExecuteNonQuery()
        MessageBox("Record Saved")
        ddlapplno.SelectedValue = "-1"
        intby.Text = ""
        status.SelectedValue = "-1"
        position.Text = ""
        dateapplied.Text = ""
        name.Text = ""
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Protected Sub lnkbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkbtn.Click
        Session("noap") = Val(ddlapplno.SelectedValue.Trim)
        Response.Redirect("jobapplicationprinting.aspx")
    End Sub
End Class