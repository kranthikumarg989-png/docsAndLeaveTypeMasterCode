Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class mcabnrpt
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'txtto.Text = Date.Now.ToShortDateString
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (194)
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
            Session("pass") = "SELECT  Leaveform.Empno, SUM(Leaveform.workfor) as Totcount, empmaster.Empname, empmaster.Designation, empmaster.Departmentcode, empmaster.Sectioncode,empmaster.Dateofjoin  FROM   Leaveform INNER JOIN  empmaster ON Leaveform.empno = empmaster.empcode WHERE  (Leaveform.leavetype = 'Medical') AND (empmaster.empcode='" & (empcode.Text) & "') GROUP BY Leaveform.empno, empmaster.empname, empmaster.designation, empmaster.departmentcode, empmaster.sectioncode,empmaster.dateofjoin  ORDER BY SUM(Leaveform.workfor) DESC"
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
                Session("pass") = "SELECT Leaveform.Empno,SUM(Leaveform.workfor) as Totcount,empmaster.Empname,empmaster.Designation,empmaster.Departmentcode,empmaster.Sectioncode,empmaster.Dateofjoin FROM Leaveform INNER JOIN  empmaster ON Leaveform.empno = empmaster.empcode WHERE (Leaveform.leavetype = 'Medical') AND (Leaveform.fromdate >= ('" & fd & "') AND Leaveform.fromdate <= ('" & td & "')) GROUP BY Leaveform.Empno, empmaster.Empname, empmaster.Designation, empmaster.Departmentcode, empmaster.Sectioncode,empmaster.Dateofjoin  ORDER BY SUM(Leaveform.workfor) DESC"
            Else
                Session("pass") = "SELECT Leaveform.Empno,SUM(Leaveform.workfor) as Totcount,empmaster.Empname,empmaster.Designation,empmaster.Departmentcode,empmaster.Sectioncode,empmaster.Dateofjoin FROM Leaveform INNER JOIN  empmaster ON Leaveform.empno = empmaster.empcode WHERE (Leaveform.leavetype = 'Medical') AND (empmaster.departmentcode='" & (dept.SelectedValue) & "') AND (Leaveform.fromdate >= ('" & fd & "') AND Leaveform.fromdate <= ('" & td & "')) GROUP BY Leaveform.Empno, empmaster.Empname, empmaster.Designation, empmaster.Departmentcode, empmaster.sectioncode,empmaster.dateofjoin  ORDER BY SUM(Leaveform.workfor) DESC"
            End If
        End If
        Response.Redirect("mcabnrptgrid.aspx")
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