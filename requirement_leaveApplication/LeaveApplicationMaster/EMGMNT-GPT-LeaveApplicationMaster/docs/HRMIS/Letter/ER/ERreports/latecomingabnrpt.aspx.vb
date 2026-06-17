Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class latecomingabnrpt
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' txtto.Text = Date.Now.ToShortDateString
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (193)
            If GlobalDSRights.Tables(0).Rows.Count > 0 Then
                For Each row As DataRow In GlobalDSRights.Tables(0).Select("scrid = '" & MyScreenId & "'")
                    MyScreenStat = row("scrstatus").ToString
                Next
            Else
                MyScreenStat = 0
            End If

            If MyScreenStat = 0 Then
                ' MessageBox("Sorry!!! You are not having Access to this screen")
                Response.Redirect("~\hrmis\default.aspx")
            End If
        Else
            Response.Redirect("~\logout.aspx")
        End If
        empcode.Visible = False
        dept.Enabled = False
    End Sub
    Protected Sub cb1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb1.CheckedChanged
        If cb1.Checked = True Then
            empcode.Visible = True
            empcode.Focus()
            txtfrom.Enabled = False
            txtto.Enabled = False
            dept.Enabled = False
            cb2.Enabled = False
        Else
            empcode.Text = ""
            empcode.Visible = False
            txtfrom.Enabled = True
            txtto.Enabled = True
            cb2.Enabled = True
            cb2.Checked = False
        End If
    End Sub
    Protected Sub showrepOT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles showrepOT.Click
        If cb1.Checked = True Then
            If empcode.Text.Trim = "" Then
                MessageBox("Enter Empcode")
                empcode.Focus()
                Exit Sub
            End If
            Session("pass") = "SELECT TMS_ATTENDANCERESULT.Empcode,empmaster.Empname,empmaster.Designation,empmaster.Departmentcode as Department,empmaster.Sectioncode as Section,TMS_ATTENDANCERESULT.Checkdate as Latecomindate,TMS_ATTENDANCERESULT.TimeException as Category,TMS_ATTENDANCERESULT.Intime +'--'+ TMS_ATTENDANCERESULT.Outtime as Time,TMS_ATTENDANCERESULT.Shift,TMS_ATTENDANCERESULT.Timeexceptionin,TMS_ATTENDANCERESULT.Timeexceptionout as Duration FROM TMS_ATTENDANCERESULT INNER JOIN empmaster ON TMS_ATTENDANCERESULT.empcode = empmaster.empcode WHERE (TMS_ATTENDANCERESULT.TimeException <> '') AND (TMS_ATTENDANCERESULT.ScanningExInOut = '') AND (empmaster.empcode = '" & (empcode.Text) & "')"
        Else
            If txtfrom.Text.Trim = "" Or txtto.Text.Trim = "" Then
                MessageBox("Enter Date Field")
                Exit Sub
            End If
            Dim fd1 As String
            fd1 = txtfrom.Text.Trim
            Dim strdate() As String = fd1.Split("/"c)
            fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)
            Dim fd As Date
            fd = CDate(fd1)
            Dim td1 As String
            td1 = txtto.Text.Trim
            Dim strdate2() As String = td1.Split("/"c)
            td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)
            Dim td As Date
            td = CDate(td1)
            If cb2.Checked = False Then
                Session("pass") = "SELECT  TMS_ATTENDANCERESULT.Empcode,empmaster.Empname as Name,empmaster.Designation,empmaster.Departmentcode as Department,empmaster.Sectioncode as Section,TMS_ATTENDANCERESULT.Checkdate as Latecomindate,TMS_ATTENDANCERESULT.TimeException as Category,TMS_ATTENDANCERESULT.Intime+'--'+TMS_ATTENDANCERESULT.Outtime as TIme,TMS_ATTENDANCERESULT.Shift,TMS_ATTENDANCERESULT.Timeexceptionin,TMS_ATTENDANCERESULT.Timeexceptionout as Duration FROM TMS_ATTENDANCERESULT INNER JOIN empmaster ON TMS_ATTENDANCERESULT.empcode = empmaster.empcode WHERE (TMS_ATTENDANCERESULT.TimeException <> '') AND (TMS_ATTENDANCERESULT.ScanningExInOut = '') AND (TMS_ATTENDANCERESULT.checkdate >= ('" & fd & "') AND TMS_ATTENDANCERESULT.checkdate <= ('" & td & "'))"
            Else
                Session("pass") = "SELECT TMS_ATTENDANCERESULT.Empcode,empmaster.empname,empmaster.Designation,empmaster.Departmentcode as Department,empmaster.Sectioncode as Section,TMS_ATTENDANCERESULT.Checkdate as Latecomindate,TMS_ATTENDANCERESULT.TimeException as Category,TMS_ATTENDANCERESULT.Intime+'--'+TMS_ATTENDANCERESULT.Outtime as Time,TMS_ATTENDANCERESULT.Shift,TMS_ATTENDANCERESULT.Timeexceptionin,TMS_ATTENDANCERESULT.Timeexceptionout as Duration FROM TMS_ATTENDANCERESULT INNER JOIN   empmaster ON TMS_ATTENDANCERESULT.empcode = empmaster.empcode WHERE (TMS_ATTENDANCERESULT.TimeException <> '') AND (TMS_ATTENDANCERESULT.ScanningExInOut = '') AND (TMS_ATTENDANCERESULT.checkdate >= ('" & fd & "') AND TMS_ATTENDANCERESULT.checkdate <= ('" & td & "')) and (empmaster.departmentcode = '" & (dept.SelectedValue) & "')"
            End If
        End If
        Response.Redirect("latecomingabnrptgrid.aspx")
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Protected Sub cb2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb2.CheckedChanged
        If cb2.Checked = True Then
            dept.Enabled = True
            dept.Focus()
        Else
            dept.Enabled = False
        End If
    End Sub
End Class