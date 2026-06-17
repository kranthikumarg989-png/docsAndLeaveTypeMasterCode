Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class EmpDetailsChange
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim mynet As New emanagement.netglobal
    Dim thisdate As Date
    Dim ecode
    Dim appno

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        ' '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (218)
            If GlobalDsRights.Tables(0).Rows.Count > 0 Then
                For Each row As DataRow In GlobalDsRights.Tables(0).Select("scrid = '" & MyScreenId & "'")
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

    Protected Sub Edetsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Edetsave.Click
        Dim dd1 As String
        Dim dd As String

        dd1 = resigdt.Text.Trim
        Dim strdate3() As String = dd1.Split("/"c)
        dd1 = strdate3(1) & "/" & strdate3(0) & "/" & strdate3(2)

        dd = CDate(dd1)
        Session("rdt") = dd

        Dim td1 As String
        td1 = lastdt.Text.Trim
        Dim strdate2() As String = td1.Split("/"c)
        td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

        Dim td As Date
        td = CDate(td1)
        Session("ldt") = td

        Dim ecode
        Session("EDname") = empno.Text.Trim
        ecode = empno.Text.Trim

        getchkval0(ecode)
        If recstatus = True Then
            If dsdata.Tables(0).Rows.Count > 0 Then
                Try
                    MyGlobal.Open_Con()
                    MyGlobal.Con_Str()
                    MyGlobal.Con_Str()
                    Dim conn As New SqlConnection(constr)
                    conn.Open()
                    Cmd = New SqlCommand("update emp_modified set dateeffective = '" & dd & "',lastworkingday = '" & td & "',letterdate = getdate() where empcode = '" & empno.Text & "'", conn)
                    Cmd.ExecuteNonQuery()
                    labelmsg.Text = "Details Added"
                    labelmsg.ForeColor = Drawing.Color.Green

                    Dim cmd1, cmd2 As New SqlCommand
                    cmd1 = New SqlCommand("update empmaster set resigned = 'Y',dateoftermination = '" & Session("ldt") & "'  where empcode = '" & empno.Text & "'", conn)
                    cmd2 = New SqlCommand("delete from normaluser where empcode = '" & empno.Text & "'", conn)

                    cmd1.ExecuteNonQuery()
                    cmd2.ExecuteNonQuery()

                    '' store SMS Detail in history table
                    Dim con As New SqlConnection(conSMSstr)
                    Cmd = New SqlCommand("SELECT cat FROM  tbl_SMSAssignment  where head='" & empno.Text & "'", con)
                    If Cmd.Connection.State = ConnectionState.Closed Then
                        Cmd.Connection.Open()
                    End If
                    Dim cat = Cmd.ExecuteScalar()
                    Cmd.Connection.Close()

                    Dim con1 As New SqlConnection(conSMSstr)
                    Dim CmdS As New SqlCommand
                    CmdS = New SqlCommand("SELECT cat FROM  tbl_group_sms  where empcode='" & empno.Text & "'", con1)
                    If CmdS.Connection.State = ConnectionState.Closed Then
                        CmdS.Connection.Open()
                    End If
                    Dim drs As SqlDataReader
                    drs = CmdS.ExecuteReader()
                    Dim grp As String = ""
                    While drs.Read
                        grp = grp & "," & drs("groupname")
                    End While
                    grp = grp.TrimEnd(",")
                    Cmd.Connection.Close()


                    mynet.db_cn()
                    mynet.dbSMS_open()
                    Call mynet.dbSpSMS_open("SMS_resignedHistory")
                    command.Parameters.AddWithValue("@empcode", empno.Text)
                    command.Parameters.AddWithValue("@category", cat)
                    command.Parameters.AddWithValue("@smsgroup", grp)
                    command.Parameters.AddWithValue("@resignedon", td)
                    command.ExecuteNonQuery()

                    '' Delete record from sms tables

                    Dim Cmdd As New SqlCommand
                    Cmdd = New SqlCommand("delete FROM tbl_group_sms where empcode='" & empno.Text & "'", con1)
                    If Cmdd.Connection.State = ConnectionState.Closed Then
                        Cmdd.Connection.Open()
                    End If
                    Cmdd.ExecuteNonQuery()

                    Dim Cmddd As New SqlCommand
                    Cmddd = New SqlCommand("delete FROM tbl_smsassignment where head='" & empno.Text & "' and companycode  = 'MMSB'", con1)
                    If Cmddd.Connection.State = ConnectionState.Closed Then
                        Cmddd.Connection.Open()
                    End If
                    Cmddd.ExecuteNonQuery()

                Catch ex As SqlException
                    labelmsg.Text = ex.Message
                End Try
            Else
                Try
                    MyGlobal.Open_Con()
                    MyGlobal.Con_Str()
                    Dim conn As New SqlConnection(constr)
                    conn.Open()
                    Cmd = New SqlCommand("insert into emp_modified (empcode,dateeffective,lastworkingday,letterdate,resign) values('" & empno.Text & "','" & dd & "','" & td & "',getdate(),'Y')", conn)
                    Cmd.ExecuteNonQuery()
                    labelmsg.Text = "Details Added"
                    labelmsg.ForeColor = Drawing.Color.Green

                    Dim cmd1, cmd2 As New SqlCommand
                    cmd1 = New SqlCommand("update empmaster set resigned = 'Y',dateoftermination = '" & Session("ldt") & "'  where empcode = '" & empno.Text & "'", conn)
                    cmd1.ExecuteNonQuery()
                    cmd2 = New SqlCommand("delete from normaluser where empcode = '" & empno.Text & "'", conn)
                    cmd2.ExecuteNonQuery()

                    '' store SMS Detail in history table
                    Dim con As New SqlConnection(conSMSstr)
                    Cmd = New SqlCommand("SELECT cat FROM  tbl_SMSAssignment  where head='" & empno.Text & "'", con)
                    If Cmd.Connection.State = ConnectionState.Closed Then
                        Cmd.Connection.Open()
                    End If
                    Dim cat = Cmd.ExecuteScalar()
                    Cmd.Connection.Close()

                    Dim con1 As New SqlConnection(conSMSstr)
                    Dim CmdS As New SqlCommand
                    CmdS = New SqlCommand("SELECT * FROM  tbl_group_sms  where empcode='" & empno.Text & "' ", con1)
                    If CmdS.Connection.State = ConnectionState.Closed Then
                        CmdS.Connection.Open()
                    End If
                    Dim drs As SqlDataReader
                    drs = CmdS.ExecuteReader()
                    Dim grp As String = ""
                    While drs.Read
                        grp = grp & drs("groupname") & ","
                    End While
                    grp = grp.TrimEnd(",")
                    CmdS.Connection.Close()


                    mynet.db_cn()
                    mynet.dbSMS_open()
                    Call mynet.dbSpSMS_open("SMS_resignedHistory")
                    command.Parameters.AddWithValue("@empcode", empno.Text)
                    command.Parameters.AddWithValue("@category", cat)
                    command.Parameters.AddWithValue("@smsgroup", grp)
                    command.Parameters.AddWithValue("@resignedon", dd)
                    command.ExecuteNonQuery()

                    '' Delete record from sms tables

                    Dim Cmdd As New SqlCommand
                    Cmdd = New SqlCommand("delete FROM tbl_group_sms where empcode='" & empno.Text & "'", con1)
                    If Cmdd.Connection.State = ConnectionState.Closed Then
                        Cmdd.Connection.Open()
                    End If
                    Cmdd.ExecuteNonQuery()
                    Cmdd.Connection.Close()

                    Dim Cmddd As New SqlCommand
                    Cmddd = New SqlCommand("delete FROM tbl_smsassignment where head='" & empno.Text & "' and companycode  = 'MMSB'", con1)
                    If Cmddd.Connection.State = ConnectionState.Closed Then
                        Cmddd.Connection.Open()
                    End If
                    Cmddd.ExecuteNonQuery()
                    Cmddd.Connection.Close()
                Catch ex As SqlException
                    labelmsg.Text = ex.Message
                End Try
            End If
        End If
        Response.Redirect("EmpChangeRpt.aspx")
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
                name.Text = dr1("empname").ToString
                dept.Text = dr1("departmentcode").ToString
                sect.Text = dr1("sectioncode").ToString
                
            Else
                MessageBox("EmployeeCode doesnot Exist!!")
            End If
        End If
    End Sub
End Class

   