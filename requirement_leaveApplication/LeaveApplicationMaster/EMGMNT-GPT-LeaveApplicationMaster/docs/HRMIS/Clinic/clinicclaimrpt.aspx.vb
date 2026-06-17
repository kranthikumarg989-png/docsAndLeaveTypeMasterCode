Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class clinicclaimrpt
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim sqltext As String
    Dim cmd As New SqlCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        Con = New SqlConnection(constr)
        Con.Open()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (236)
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
    End Sub
    Protected Sub save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles save.Click
        If fromdt.Text = "From date" Or fromdt.Text = "" Then
            fromdt.Text = ""
            fromdt.Focus()
            MessageBox("select From Date")
            Exit Sub
        ElseIf todt.Text = "To date" Or todt.Text = "" Then
            todt.Text = ""
            todt.Focus()
            MessageBox("select To Date")
            Exit Sub
        End If
        If cb2.Checked = False Then
            If empcode.Text.Trim <> "" Then
                If IsNumeric(empcode.Text) = False Then
                    empcode.Text = ""
                    MessageBox("Enter Employee No only")
                    empcode.Focus()
                    Exit Sub
                End If
            Else
                MessageBox("Enter Employee code !")
                empcode.Focus()
                Exit Sub
            End If
        End If
        Dim fd1 As String
        fd1 = fromdt.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)
        Dim fd As Date
        fd = CDate(fd1)
        Dim td1 As String
        td1 = todt.Text.Trim
        Dim strdate2() As String = td1.Split("/"c)
        td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)
        Dim td As Date
        td = CDate(td1)
        If cb1.Checked = True And cb2.Checked = True Then
            Session("dt") = "select empmaster.empcode,empmaster.empname,empmaster.departmentcode,empmaster.sectioncode,tbldiagnose.clinicname,tblDiagnose.datecheck,tblDiagnose.billamount,tblDiagnose.claim from tblDiagnose inner join empmaster on tblDiagnose.empno=empmaster.empcode where (datecheck >= '" & fd & "') and (datecheck <= '" & td & "') order by empcode"
            Session("count") = "select sum(billamount) from tblDiagnose  where ((datecheck >= '" & fd & "') and (datecheck <= '" & td & "'))"
        ElseIf cb1.Checked = False And cb2.Checked = True Then
            Session("dt") = "select empmaster.empcode,empmaster.empname,empmaster.departmentcode,empmaster.sectioncode,tbldiagnose.clinicname,tblDiagnose.datecheck,tblDiagnose.billamount,tblDiagnose.claim from tblDiagnose inner join empmaster on tblDiagnose.empno=empmaster.empcode where ((DateCheck >= '" & fd & "') and (DateCheck <='" & td & "') and (claim ='" & claim.SelectedValue.Trim & "'))order by empcode"
            Session("count") = "select sum(billamount) from tblDiagnose  where ((DateCheck >= '" & fd & "') and (DateCheck <='" & td & "') and (claim ='" & claim.SelectedValue.Trim & "'))"
        ElseIf cb1.Checked = True And cb2.Checked = False Then
            Session("dt") = "select empmaster.empcode,empmaster.empname,empmaster.departmentcode,empmaster.sectioncode,tbldiagnose.clinicname,tblDiagnose.datecheck,tblDiagnose.billamount,tblDiagnose.claim from tblDiagnose inner join empmaster on tblDiagnose.empno=empmaster.empcode where ((DateCheck >= '" & fd & "') and (DateCheck <='" & td & "')) and (empcode ='" & empcode.Text & "')order by empname"
            Session("count") = "select sum(billamount) from tblDiagnose where ((DateCheck >= '" & fd & "') and (DateCheck <='" & td & "')) and (empno ='" & empcode.Text & "')"
        ElseIf cb1.Checked = False And cb2.Checked = False Then
            Session("dt") = "select empmaster.empcode,empmaster.empname,empmaster.departmentcode,empmaster.sectioncode,tbldiagnose.clinicname,tblDiagnose.datecheck,tblDiagnose.billamount,tblDiagnose.claim from tblDiagnose inner join empmaster on tblDiagnose.empno=empmaster.empcode where(((DateCheck >= '" & fd & "') and (DateCheck <='" & td & "')) and (EmpNo ='" & empcode.Text & "') and (claim ='" & claim.SelectedValue.Trim & "'))order by empcode"
            Session("count") = "select sum(billamount) from tblDiagnose  where (((DateCheck >= '" & fd & "') and (DateCheck <='" & td & "')) and (EmpNo ='" & empcode.Text & "') and (claim ='" & claim.SelectedValue.Trim & "'))"
        End If
        Response.Redirect("clinicclaimrptgrid.aspx")
    End Sub
    Protected Sub cb1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb1.CheckedChanged
        If cb1.Checked = True Then
            claim.Enabled = False
        Else
            claim.Enabled = True
            claim.Focus()
        End If
    End Sub
    Protected Sub cb2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb2.CheckedChanged
        If cb2.Checked = True Then
            empcode.Text = ""
            empcode.Enabled = False
        Else
            empcode.Enabled = True
            empcode.Focus()
        End If
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
End Class