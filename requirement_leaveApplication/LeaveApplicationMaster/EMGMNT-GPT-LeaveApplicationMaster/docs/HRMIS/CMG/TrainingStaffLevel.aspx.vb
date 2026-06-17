Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class TrainingStaffLevel
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
            MyScreenId = (217)
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
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub Savetrstaff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Savetrstaff.Click
        Dim dd1 As String
        Dim dd As String

        dd1 = letdt.Text.Trim
        Dim strdate3() As String = dd1.Split("/"c)
        dd1 = strdate3(1) & "/" & strdate3(0) & "/" & strdate3(2)

        dd = CDate(dd1)
        Session("letdet") = dd

        Dim td1 As String
        td1 = eff_to.Text.Trim
        Dim strdate2() As String = td1.Split("/"c)
        td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

        Dim td As Date
        td = CDate(td1)
        Session("effto") = td

        Dim fd1 As String
        fd1 = eff_frm.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)
        Session("efffrom") = fd


        chkval3()
        If recstatus = True Then
            If dsdata.Tables(0).Rows.Count > 0 Then
                Try
                    MyGlobal.Open_Con()
                    MyGlobal.Con_Str()
                    MyGlobal.Con_Str()
                    Dim conn As New SqlConnection(constr)
                    conn.Open()
                    Cmd = New SqlCommand("update emp_3daytrainingletter set tfromdate='" & fd & "',ttodate='" & td & "',letterdate ='" & dd & "', tposition='" & desig.SelectedValue & "', department='" & dept.SelectedValue & "' where name='" & empname.Text & "'", conn)
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
                    Cmd = New SqlCommand("insert into emp_3daytrainingletter (name,tfromdate,ttodate,letterdate,tposition,department,icno) values('" & empname.Text & "','" & fd & "','" & td & "','" & dd & "','" & desig.SelectedValue & "','" & dept.SelectedValue & "', '" & icno.Text & "')", conn)
                    Cmd.ExecuteNonQuery()
                    labelmsg.Text = "Details Added"
                Catch ex As SqlException
                    labelmsg.Text = ex.Message
                    labelmsg.ForeColor = Drawing.Color.Green
                End Try
            End If
        End If
        Session("AFNname") = empname.Text.Trim

        MyGlobal.db_close()

        Response.Redirect("TrStaffLevelRpt.aspx")

    End Sub
    Private Sub chkval3()
        Dim dd1 As String
        Dim dd As String

        dd1 = letdt.Text.Trim
        Dim strdate3() As String = dd1.Split("/"c)
        dd1 = strdate3(1) & "/" & strdate3(0) & "/" & strdate3(2)

        dd = CDate(dd1)
        'Dim drp As DataRow
        ecode = empname.Text

        getchkval3(ecode, dd)
        'If recstatus = True Then
        '    If dsdata.Tables(0).Rows.Count > 0 Then
        '        drp = dsdata.Tables(0).Rows(0)
        '    Else
        '        MessageBox("Employee Passport Details doesnot Exist!!")
        '    End If
        'End If
    End Sub
End Class