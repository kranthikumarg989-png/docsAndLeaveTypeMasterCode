Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Partial Public Class clinicbalancereport
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        empcode.Visible = False
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (237)
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

        If rb1.SelectedValue = "D" Then
            dept.Enabled = True
            cb2.Enabled = True
            sec.Enabled = False
            cat.Enabled = False
            dept.Focus()
        End If
    End Sub
    Protected Sub cb1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb1.CheckedChanged
        If cb1.Checked = True Then
            empcode.Visible = True
            rb1.Enabled = False
            dept.Enabled = False
            sec.Enabled = False
            cat.Enabled = False
            cb2.Enabled = False
            empcode.Focus()
            cb2.Checked = False
        Else
            empcode.Visible = False
            rb1.Enabled = True
            dept.Enabled = True
            cb2.Enabled = True
            rb1.SelectedIndex = 0
        End If
    End Sub
    Protected Sub cb2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb2.CheckedChanged
        If cb2.Checked = True Then
            dept.Enabled = False
        Else
            dept.Enabled = True
        End If
    End Sub
    Protected Sub rb1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb1.SelectedIndexChanged
        If rb1.SelectedValue = "D" Then
            dept.Enabled = True
            cb2.Enabled = True
            sec.Enabled = False
            cat.Enabled = False
            dept.Focus()
        ElseIf rb1.SelectedValue = "S" Then
            dept.Enabled = False
            cb2.Enabled = False
            sec.Enabled = True
            cat.Enabled = False
            sec.Focus()
        ElseIf rb1.SelectedValue = "C" Then
            dept.Enabled = False
            cb2.Enabled = False
            sec.Enabled = False
            cat.Enabled = True
            cat.Focus()
        End If
    End Sub
    Protected Sub save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles save.Click
        If cb1.Checked = True Then
            If empcode.Text.Trim <> "" And IsNumeric(empcode.Text) = True Then
            Else
                MessageBox("Enter empcode!")
                empcode.Text = ""
                empcode.Focus()
                Exit Sub
            End If
        Else
            If rb1.SelectedValue = "D" And cb2.Checked = False Then
                If dept.SelectedValue = "-1" Then
                    MessageBox("Select Department code")
                    dept.Focus()
                    Exit Sub
                End If
            ElseIf rb1.SelectedValue = "S" Then
                If sec.SelectedValue = "-1" Then
                    MessageBox("Select Section code")
                    sec.Focus()
                    Exit Sub
                End If
            ElseIf rb1.SelectedValue = "C" Then
                If cat.SelectedValue = "-1" Then
                    MessageBox("Select category")
                    cat.Focus()
                    Exit Sub
                End If
            End If
        End If
        Dim fromdate, todate, fdt, tdt, yr, yyr As String
        If Month(Date.Now) <= 3 Then
            yr = Year(Date.Now) - 1
            yyr = Year(Date.Now)
        Else
            yr = Year(Date.Now)
            yyr = Year(Date.Now) + 1
        End If
        fromdate = "04/" & "01/" & yr
        fdt = CDate(fromdate)
        todate = "03/" & "31/" & yyr
        tdt = CDate(todate)
        If cb1.Checked = True Then
            Session("qry") = "SELECT SUM(billamount) AS Expr1,EmpNo,(select 150)as total,empmaster.empname,empmaster.departmentcode,empmaster.sectioncode FROM tblDiagnose INNER JOIN  empmaster ON tblDiagnose.EmpNo = empmaster.empcode WHERE (tblDiagnose.DateCheck >= CONVERT(DATETIME, '" & fdt & "', 102)) AND (tblDiagnose.DateCheck <= CONVERT(DATETIME, '" & tdt & "', 102))GROUP BY tblDiagnose.EmpNo,empmaster.empname,empmaster.departmentcode,empmaster.sectioncode,empmaster.empcode, empmaster.resigned HAVING (empmaster.empcode = '" & (empcode.Text) & "')ORDER BY tblDiagnose.EmpNo"
        Else
            If rb1.SelectedValue = "D" And cb2.Checked = False Then
                Session("qry") = "SELECT  SUM(billamount) AS Expr1,EmpNo,(select 150)as total,empmaster.empname,empmaster.departmentcode,empmaster.sectioncode FROM tblDiagnose INNER JOIN  empmaster ON tblDiagnose.EmpNo = empmaster.empcode WHERE (tblDiagnose.DateCheck >= CONVERT(DATETIME, '" & fdt & "', 102)) AND (tblDiagnose.DateCheck <= CONVERT(DATETIME, '" & tdt & "', 102))GROUP BY tblDiagnose.EmpNo,empmaster.empname,empmaster.departmentcode,empmaster.sectioncode,empmaster.resigned HAVING (empmaster.departmentcode = '" & (dept.SelectedValue) & "') AND (empmaster.resigned <> 'Y')ORDER BY tblDiagnose.EmpNo"
            ElseIf rb1.SelectedValue = "D" And cb2.Checked = True Then
                Session("qry") = "SELECT  SUM(billamount) AS Expr1,EmpNo,(select 150)as total,empmaster.empname,empmaster.departmentcode,empmaster.sectioncode FROM tblDiagnose INNER JOIN  empmaster ON tblDiagnose.EmpNo = empmaster.empcode WHERE (tblDiagnose.DateCheck >= CONVERT(DATETIME, '" & fdt & "', 102)) AND (tblDiagnose.DateCheck <= CONVERT(DATETIME, '" & tdt & "', 102))GROUP BY tblDiagnose.EmpNo,empmaster.empname,empmaster.departmentcode,empmaster.sectioncode,empmaster.resigned ORDER BY EmpNo"
            ElseIf rb1.SelectedValue = "S" Then
                Session("qry") = "SELECT  SUM(billamount) AS Expr1,EmpNo,(select 150)as total,empmaster.empname,empmaster.departmentcode,empmaster.sectioncode FROM tblDiagnose INNER JOIN  empmaster ON tblDiagnose.EmpNo = empmaster.empcode WHERE (tblDiagnose.DateCheck >= CONVERT(DATETIME, '" & fdt & "', 102)) AND (tblDiagnose.DateCheck <= CONVERT(DATETIME, '" & tdt & "', 102))GROUP BY tblDiagnose.EmpNo,empmaster.empname,empmaster.departmentcode,empmaster.sectioncode,empmaster.resigned HAVING (empmaster.sectioncode = '" & sec.SelectedValue & "') AND (empmaster.resigned <> 'Y')ORDER BY tblDiagnose.EmpNo"
            ElseIf rb1.SelectedValue = "C" Then
                If cat.SelectedValue = "GL" Then
                    Session("qry") = "SELECT  SUM(billamount) AS Expr1,EmpNo,(select 150)as total,empmaster.empname,empmaster.departmentcode,empmaster.sectioncode FROM tblDiagnose INNER JOIN  empmaster ON tblDiagnose.EmpNo = empmaster.empcode WHERE (tblDiagnose.DateCheck >= CONVERT(DATETIME, '" & fdt & "', 102)) AND (tblDiagnose.DateCheck <= CONVERT(DATETIME, '" & tdt & "', 102))GROUP BY tblDiagnose.EmpNo,empmaster.empname,empmaster.departmentcode,empmaster.sectioncode,empmaster.foreignemp,empmaster.resigned HAVING (empmaster.foreignemp = 'N') AND (empmaster.resigned <> 'Y')ORDER BY tblDiagnose.EmpNo"
                ElseIf cat.SelectedValue = "GF" Then
                    Session("qry") = "SELECT  SUM(billamount) AS Expr1,EmpNo,(select 150)as total,empmaster.empname,empmaster.departmentcode,empmaster.sectioncode FROM tblDiagnose INNER JOIN  empmaster ON tblDiagnose.EmpNo = empmaster.empcode WHERE (tblDiagnose.DateCheck >= CONVERT(DATETIME, '" & fdt & "', 102)) AND (tblDiagnose.DateCheck <= CONVERT(DATETIME, '" & tdt & "', 102))GROUP BY tblDiagnose.EmpNo,empmaster.empname,empmaster.departmentcode,empmaster.sectioncode,empmaster.foreignemp,empmaster.resigned HAVING (empmaster.foreignemp = 'Y') AND (empmaster.resigned <> 'Y')ORDER BY tblDiagnose.EmpNo"
                ElseIf cat.SelectedValue = "LO" Then
                    Session("qry") = "SELECT  SUM(billamount) AS Expr1,EmpNo,(select 150)as total,empmaster.empname,empmaster.departmentcode,empmaster.sectioncode FROM tblDiagnose INNER JOIN  empmaster ON tblDiagnose.EmpNo = empmaster.empcode WHERE (tblDiagnose.DateCheck >= CONVERT(DATETIME, '" & fdt & "', 102)) AND (tblDiagnose.DateCheck <= CONVERT(DATETIME, '" & tdt & "', 102))GROUP BY tblDiagnose.EmpNo,empmaster.empname,empmaster.departmentcode,empmaster.sectioncode,empmaster.foreignemp,empmaster.resigned,empmaster.designation  HAVING (empmaster.foreignemp = 'N') AND (empmaster.resigned <> 'Y') AND (empmaster.designation = 'Operator')ORDER BY tblDiagnose.EmpNo"
                ElseIf cat.SelectedValue = "FO" Then
                    Session("qry") = "SELECT  SUM(billamount) AS Expr1,EmpNo,(select 150)as total,empmaster.empname,empmaster.departmentcode,empmaster.sectioncode FROM tblDiagnose INNER JOIN  empmaster ON tblDiagnose.EmpNo = empmaster.empcode WHERE (tblDiagnose.DateCheck >= CONVERT(DATETIME, '" & fdt & "', 102)) AND (tblDiagnose.DateCheck <= CONVERT(DATETIME, '" & tdt & "', 102))GROUP BY tblDiagnose.EmpNo,empmaster.empname,empmaster.departmentcode,empmaster.sectioncode,empmaster.foreignemp,empmaster.resigned,empmaster.designation  HAVING (empmaster.foreignemp = 'Y') AND (empmaster.resigned <> 'Y') AND (empmaster.designation = 'Operator')ORDER BY tblDiagnose.EmpNo"
                ElseIf cat.SelectedValue = "ST" Then
                    Session("qry") = "SELECT  SUM(billamount) AS Expr1,EmpNo,(select 150)as total,empmaster.empname,empmaster.departmentcode,empmaster.sectioncode FROM tblDiagnose INNER JOIN  empmaster ON tblDiagnose.EmpNo = empmaster.empcode WHERE (tblDiagnose.DateCheck >= CONVERT(DATETIME, '" & fdt & "', 102)) AND (tblDiagnose.DateCheck <= CONVERT(DATETIME, '" & tdt & "', 102))GROUP BY tblDiagnose.EmpNo,empmaster.empname,empmaster.departmentcode,empmaster.sectioncode,empmaster.foreignemp,empmaster.resigned,empmaster.designation  HAVING (empmaster.resigned <> 'Y') AND (empmaster.designation <> 'Operator')ORDER BY tblDiagnose.EmpNo"
                End If
            End If
        End If
        Response.Redirect("clinicbalancereportgrid.aspx")
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
End Class