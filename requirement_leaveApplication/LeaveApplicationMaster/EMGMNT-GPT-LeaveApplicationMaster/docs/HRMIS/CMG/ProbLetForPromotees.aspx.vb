Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class ProbLetForPromotees
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
            MyScreenId = (213)
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
        'Session("empcode") = "014543"
        labelmsg.Text = ""
    End Sub

    Protected Sub Saveprobpromo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Saveprobpromo.Click
        Dim dd1 As String
        Dim dd As String

        dd1 = letdt.Text.Trim
        Dim strdate3() As String = dd1.Split("/"c)
        dd1 = strdate3(1) & "/" & strdate3(0) & "/" & strdate3(2)

        dd = CDate(dd1)
        Session("letdet") = dd


        Dim fd1 As String
        fd1 = eff_frm.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)
        Session("efffrom") = fd


        chkval4()
        If recstatus = True Then
            If dsdata.Tables(0).Rows.Count > 0 Then
                Try
                    MyGlobal.Open_Con()
                    MyGlobal.Con_Str()
                    MyGlobal.Con_Str()
                    Dim conn As New SqlConnection(constr)
                    conn.Open()
                    Cmd = New SqlCommand("update emp_probationpromotees set efffromdate='" & fd & "',newdesignation='" & newdesig.selectedvalue & "',letterdate='" & dd & "' where empcode='" & empno.Text & "'", conn)
                    Cmd.ExecuteNonQuery()
                    labelmsg.Text = "Details updated"
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
                    Cmd = New SqlCommand("insert into emp_probationpromotees (empcode,efffromdate,newdesignation,letterdate) values('" & empno.Text & "','" & fd & "','" & newdesig.SelectedValue & "','" & dd & "')", conn)
                    Cmd.ExecuteNonQuery()
                    labelmsg.Text = "Details Added"
                Catch ex As SqlException
                    labelmsg.Text = ex.Message
                    labelmsg.ForeColor = Drawing.Color.Green
                End Try
            End If
        End If
        Session("AFNname") = empno.Text.Trim


        MyGlobal.db_close()

        Response.Redirect("ProbPromoteesRpt.aspx")

    End Sub

    Protected Sub empno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles empno.TextChanged
        Appdetails()
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
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
            Else
                MessageBox("EmployeeCode doesnot Exist!!")
            End If
        End If
    End Sub
    Private Sub chkval4()
        Dim dd1 As String
        Dim dd As String

        dd1 = letdt.Text.Trim
        Dim strdate3() As String = dd1.Split("/"c)
        dd1 = strdate3(1) & "/" & strdate3(0) & "/" & strdate3(2)

        dd = CDate(dd1)

        ecode = empno.Text

        getchkval4(ecode, dd)
       
    End Sub
End Class
