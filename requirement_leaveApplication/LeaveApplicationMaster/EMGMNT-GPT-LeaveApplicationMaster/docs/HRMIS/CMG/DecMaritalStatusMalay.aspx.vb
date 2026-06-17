Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class DecMaritalStatusMalay
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim thisdate As Date
    Dim ecode
    Dim appno

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (208)
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
        labelmsg.Text = ""
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub Savemarstatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Savemarstatus.Click
        Dim dd1 As String
        Dim dd As String

        dd1 = letdt.Text.Trim
        Dim strdate3() As String = dd1.Split("/"c)
        dd1 = strdate3(1) & "/" & strdate3(0) & "/" & strdate3(2)

        dd = CDate(dd1)
        Session("letdet") = dd

        chkval1()
        If recstatus = True Then
            If dsdata.Tables(0).Rows.Count > 0 Then
                Try
                    MyGlobal.Open_Con()
                    MyGlobal.Con_Str()
                    MyGlobal.Con_Str()
                    Dim conn As New SqlConnection(constr)
                    conn.Open()
                    Cmd = New SqlCommand("update emp_certification set letterdate='" & dd & "' and maritalstatus='Y' where empcode='" & empno.Text & "'", conn)
                    Cmd.ExecuteNonQuery()
                    labelmsg.Text = "Details Updated"
                Catch ex As SqlException
                    labelmsg.Text = ex.Message
                    labelmsg.ForeColor = Drawing.Color.Green
                End Try
            Else
                Try
                    MyGlobal.Open_Con()
                    MyGlobal.Con_Str()
                    MyGlobal.Con_Str()
                    Dim conn As New SqlConnection(constr)
                    conn.Open()
                    Cmd = New SqlCommand("insert into emp_certification (empcode,letterdate,maritalstatus) values('" & empno.Text & "','" & dd & "','Y')", conn)
                    Cmd.ExecuteNonQuery()
                    labelmsg.Text = "Details Added"
                Catch ex As SqlException
                    labelmsg.Text = ex.Message
                    labelmsg.ForeColor = Drawing.Color.Green
                End Try
            End If
        End If
        Session("AFNname") = empno.Text.Trim
        Session("AFNwname") = empno.Text.Trim

        MyGlobal.db_close()

        Response.Redirect("DecMarStatusRpt.aspx")

    End Sub

    Protected Sub empno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles empno.TextChanged
        Appdetails()
    End Sub
    Private Sub Appdetails()
        Dim dr1 As DataRow
        ecode = empno.Text
        Getcedata(ecode)
        If recstatus = True Then
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr1 = dsdata.Tables(0).Rows(0)
                empname.Text = dr1("empname").ToString
                dept.Text = dr1("departmentcode").ToString
                desig.Text = dr1("designation").ToString
                sect.Text = dr1("sectioncode").ToString
                icno.Text = dr1("newicno").ToString
                doj.Text = Format(Convert.ToDateTime(dr1("dateofjoin")), "dd/MM/yyyy")
            Else
                MessageBox("EmployeeCode doesnot Exist!!")
            End If
        End If
    End Sub
    Private Sub chkval1()
        'Dim drp As DataRow
        Dim dd1 As String
        Dim dd As String

        dd1 = letdt.Text.Trim
        Dim strdate3() As String = dd1.Split("/"c)
        dd1 = strdate3(1) & "/" & strdate3(0) & "/" & strdate3(2)

        dd = CDate(dd1)

        ecode = empno.Text
        getchkval2(ecode, dd)
        'If recstatus = True Then
        '    If dsdata.Tables(0).Rows.Count > 0 Then
        '        drp = dsdata.Tables(0).Rows(0)
        '    Else
        '        MessageBox("Employee Passport Details doesnot Exist!!")
        '    End If
        'End If
    End Sub
End Class