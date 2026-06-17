Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class leaveabsentreport
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        'Session("empcode") = "014543"
        'If Not IsPostBack Then
        '    delLdetails()
        '    'LoadRecordstorpt()
        'End If
        If cb.Checked = True Then
            Session("lrep") = "O"
            leavetype.Visible = False
            TextBox1.Visible = False
            dept.Visible = False
        End If
    End Sub

    Protected Sub showtTrainingReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles showtTrainingReport.Click
        If cb.Checked = True Then
            delLdetails()
            LoadRecordstorpt1()
            txtfrom.Text = ""
            txtto.Text = ""

        ElseIf cb.Checked = False Then

            delLdetails()
            LoadRecordstorpt()

            Dim fd1 As String
            fd1 = txtfrom.Text.Trim
            Dim strdate() As String = fd1.Split("/"c)
            fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

            Dim fd As Date
            fd = CDate(fd1)
            Session("lfromd") = fd

            Dim td1 As String
            td1 = txtto.Text.Trim
            Dim strdate2() As String = td1.Split("/"c)
            td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

            Dim td As Date
            td = CDate(td1)
            Session("ltod") = td


            Dim lt
            Dim dep
            lt = leavetype.SelectedValue
            dep = dept.SelectedValue

            Session("ldept") = dep
            Session("lleavetype") = lt
            Session("lemp") = TextBox1.Text.Trim

            Response.Redirect("~/hrmis/Letter/ER/ERreports/leavereportsbyselection.aspx")
        End If
       
    End Sub
    Private Sub LoadRecordstorpt()

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



        Dim dsl As DataSet
        Dim drl As DataRow
        Dim j As Integer
        dsl = getLdetails()
        If dsl.Tables(0).Rows.Count <> 0 Then
            For j = 0 To dsl.Tables(0).Rows.Count - 1
                drl = dsl.Tables(0).Rows(j)
                Dim leavetype
                Dim datekey
                Dim frmdt
                Dim todt
                Dim reason
                Dim status
                Dim recno
                'Dim empname
                Dim empno
                'Dim dept
                'Dim sect
                Dim latedet
                Dim latehrs
                Dim latemins
                Dim ltfromtime
                Dim lttotime
                Dim fdate1 As Date
                Dim tdate1 As Date
                Dim fdate2 As Date
                Dim fdate3 As Date
                Dim fdate4 As Date
                Dim fdate5 As Date
                Dim fdate6 As Date
                Dim fdate7 As Date
                Dim tdate2 As Date
                Dim tdate3 As Date
                Dim tdate4 As Date
                Dim tdate5 As Date
                Dim tdate6 As Date
                Dim tdate7 As Date

                recno = drl("recordno").ToString
                empno = drl("empcode").ToString
                leavetype = drl("leavetype").ToString
                status = drl("status").ToString

                If Not drl("abfromdate") Is System.DBNull.Value Then
                    fdate1 = drl("abfromdate").ToString
                End If
                If Not drl("abtodate") Is System.DBNull.Value Then
                    tdate1 = drl("abtodate").ToString
                End If
                If Not drl("absfromdate") Is System.DBNull.Value Then
                    fdate2 = drl("absfromdate").ToString
                End If
                If Not drl("abstodate") Is System.DBNull.Value Then
                    tdate2 = drl("abstodate").ToString
                End If
                If Not drl("latedate") Is System.DBNull.Value Then
                    fdate3 = drl("latedate").ToString
                End If
                If Not drl("latedate") Is System.DBNull.Value Then
                    tdate3 = drl("latedate").ToString
                End If
                If Not drl("overnightdate") Is System.DBNull.Value Then
                    fdate4 = drl("overnightdate").ToString
                End If
                If Not drl("overnightdate") Is System.DBNull.Value Then
                    tdate4 = drl("overnightdate").ToString
                End If
                If Not drl("latereturndate") Is System.DBNull.Value Then
                    fdate5 = drl("latereturndate").ToString
                End If
                If Not drl("latereturndate") Is System.DBNull.Value Then
                    tdate5 = drl("latereturndate").ToString
                End If
                If Not drl("misconductdate") Is System.DBNull.Value Then
                    fdate6 = drl("misconductdate").ToString
                End If
                If Not drl("misconductdate") Is System.DBNull.Value Then
                    tdate6 = drl("misconductdate").ToString
                End If
                If Not drl("ranawaydate") Is System.DBNull.Value Then
                    fdate7 = drl("ranawaydate").ToString
                End If
                If Not drl("ranawaydate") Is System.DBNull.Value Then
                    tdate7 = drl("ranawaydate").ToString
                End If

                Session("f1") = fdate1
                Session("f2") = fdate2
                Session("f3") = fdate3
                Session("f4") = fdate4
                Session("f5") = fdate5
                Session("f6") = fdate6
                Session("f7") = fdate7
                Session("t1") = tdate1
                Session("t1") = tdate2
                Session("t1") = tdate3
                Session("t1") = tdate4
                Session("t1") = tdate5
                Session("t1") = tdate6
                Session("t1") = tdate7

                If leavetype = "Absent" Then
                    If (fdate1 > fd) And (td > tdate1) Then

                        frmdt = drl("abfromdate").ToString
                        todt = drl("abtodate").ToString
                        reason = drl("abreason").ToString
                        datekey = drl("datekeyin").ToString
                        latedet = "---"

                        MyGlobal.Con_Str()
                        Dim conn As New SqlConnection(constr)
                        conn.Open()
                        Cmd = New SqlCommand("insert into leaveabsentism_rpt (recordno,empno,fromdate,todate,leavetype,reason,latehours,latemins,latefrom,lateto,status,datekeyin) values('" & recno & "', '" & empno & "','" & frmdt & "','" & todt & "','" & leavetype & "','" & reason & "', '" & latehrs & "','" & latemins & "','" & ltfromtime & "','" & lttotime & "','" & status & "','" & datekey & "') ", conn)
                        Cmd.ExecuteNonQuery()
                    End If

                ElseIf leavetype = "Abscond" Then
                    If (fdate2 > fd) And (td > tdate2) Then

                        frmdt = drl("absfromdate").ToString
                        todt = drl("abstodate").ToString
                        reason = drl("absreason").ToString
                        datekey = drl("datekeyin").ToString
                        latedet = "---"

                        MyGlobal.Con_Str()
                        Dim conn As New SqlConnection(constr)
                        conn.Open()
                        Cmd = New SqlCommand("insert into leaveabsentism_rpt (recordno,empno,fromdate,todate,leavetype,reason,latehours,latemins,latefrom,lateto,status,datekeyin) values('" & recno & "', '" & empno & "','" & frmdt & "','" & todt & "','" & leavetype & "','" & reason & "', '" & latehrs & "','" & latemins & "','" & ltfromtime & "','" & lttotime & "','" & status & "','" & datekey & "') ", conn)
                        Cmd.ExecuteNonQuery()
                    End If

                ElseIf leavetype = "LateComing" Then
                    If (fdate3 > fd) And (td > tdate3) Then

                        frmdt = drl("latedate").ToString
                        todt = drl("latedate").ToString
                        reason = drl("latereason").ToString
                        latehrs = drl("latehours").ToString
                        latemins = drl("latemin").ToString
                        ltfromtime = drl("timefrom").ToString
                        lttotime = drl("timeto").ToString
                        datekey = drl("datekeyin").ToString

                        MyGlobal.Con_Str()
                        Dim conn As New SqlConnection(constr)
                        conn.Open()
                        Cmd = New SqlCommand("insert into leaveabsentism_rpt (recordno,empno,fromdate,todate,leavetype,reason,latehours,latemins,latefrom,lateto,status,datekeyin) values('" & recno & "', '" & empno & "','" & frmdt & "','" & todt & "','" & leavetype & "','" & reason & "', '" & latehrs & "','" & latemins & "','" & ltfromtime & "','" & lttotime & "','" & status & "','" & datekey & "') ", conn)
                        Cmd.ExecuteNonQuery()
                    End If

                ElseIf leavetype = "OverNight" Then

                    If (fdate4 > fd) And (td > tdate4) Then

                        frmdt = drl("overnightdate").ToString
                        todt = drl("overnightdate").ToString
                        reason = drl("overnight").ToString
                        latedet = "---"
                        datekey = drl("datekeyin").ToString

                        MyGlobal.Con_Str()
                        Dim conn As New SqlConnection(constr)
                        conn.Open()
                        Cmd = New SqlCommand("insert into leaveabsentism_rpt (recordno,empno,fromdate,todate,leavetype,reason,latehours,latemins,latefrom,lateto,status,datekeyin) values('" & recno & "', '" & empno & "','" & frmdt & "','" & todt & "','" & leavetype & "','" & reason & "', '" & latehrs & "','" & latemins & "','" & ltfromtime & "','" & lttotime & "','" & status & "','" & datekey & "') ", conn)
                        Cmd.ExecuteNonQuery()
                    End If

                ElseIf leavetype = "LateReturn" Then
                    If (fdate5 > fd) And (td > tdate5) Then

                        frmdt = drl("latereturndate").ToString
                        todt = drl("latereturndate").ToString
                        reason = drl("latereturn").ToString
                        latedet = "---"
                        datekey = drl("datekeyin").ToString

                        MyGlobal.Con_Str()
                        Dim conn As New SqlConnection(constr)
                        conn.Open()
                        Cmd = New SqlCommand("insert into leaveabsentism_rpt (recordno,empno,fromdate,todate,leavetype,reason,latehours,latemins,latefrom,lateto,status,datekeyin) values('" & recno & "', '" & empno & "','" & frmdt & "','" & todt & "','" & leavetype & "','" & reason & "', '" & latehrs & "','" & latemins & "','" & ltfromtime & "','" & lttotime & "','" & status & "','" & datekey & "') ", conn)
                        Cmd.ExecuteNonQuery()
                    End If

                ElseIf leavetype = "Misconduct" Then
                    If (fdate6 > fd) And (td > tdate6) Then

                        frmdt = drl("misconductdate").ToString
                        todt = drl("misconductdate").ToString
                        reason = drl("misconduct").ToString
                        latedet = "---"
                        datekey = drl("datekeyin").ToString

                        MyGlobal.Con_Str()
                        Dim conn As New SqlConnection(constr)
                        conn.Open()
                        Cmd = New SqlCommand("insert into leaveabsentism_rpt (recordno,empno,fromdate,todate,leavetype,reason,latehours,latemins,latefrom,lateto,status,datekeyin) values('" & recno & "', '" & empno & "','" & frmdt & "','" & todt & "','" & leavetype & "','" & reason & "', '" & latehrs & "','" & latemins & "','" & ltfromtime & "','" & lttotime & "','" & status & "','" & datekey & "') ", conn)
                        Cmd.ExecuteNonQuery()
                    End If
                ElseIf leavetype = "RanAway" Then
                    If (fdate7 > fd) And (td > tdate7) Then

                        frmdt = drl("ranawaydate").ToString
                        todt = drl("ranawaydate").ToString
                        reason = drl("ranaway").ToString
                        latedet = "---"
                        datekey = drl("datekeyin").ToString

                        MyGlobal.Con_Str()
                        Dim conn As New SqlConnection(constr)
                        conn.Open()
                        Cmd = New SqlCommand("insert into leaveabsentism_rpt (recordno,empno,fromdate,todate,leavetype,reason,latehours,latemins,latefrom,lateto,status,datekeyin) values('" & recno & "', '" & empno & "','" & frmdt & "','" & todt & "','" & leavetype & "','" & reason & "', '" & latehrs & "','" & latemins & "','" & ltfromtime & "','" & lttotime & "','" & status & "','" & datekey & "') ", conn)
                        Cmd.ExecuteNonQuery()
                    End If

                End If

          

            Next

        End If
    End Sub
    Private Sub LoadRecordstorpt1()

        Dim fd1 As String
        fd1 = txtfrom.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)
        Session("lfromd") = fd

        Dim td1 As String
        td1 = txtto.Text.Trim
        Dim strdate2() As String = td1.Split("/"c)
        td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

        Dim td As Date
        td = CDate(td1)
        Session("ltod") = td


        Dim dsl As DataSet
        Dim drl As DataRow
        Dim j As Integer
        dsl = getOLdetails()
        If dsl.Tables(0).Rows.Count <> 0 Then
            For j = 0 To dsl.Tables(0).Rows.Count - 1
                drl = dsl.Tables(0).Rows(j)
                Dim leavetype
                Dim recno
                Dim empno
                Dim status
                Dim reason
                Dim frmdt
                Dim todt
                Dim fdate1 As Date
                Dim tdate1 As Date
                Dim fdate2 As Date
                Dim fdate3 As Date
                Dim fdate4 As Date
                Dim fdate5 As Date
                Dim fdate6 As Date
                Dim fdate7 As Date
                Dim tdate2 As Date
                Dim tdate3 As Date
                Dim tdate4 As Date
                Dim tdate5 As Date
                Dim tdate6 As Date
                Dim tdate7 As Date

                If Not drl("abfromdate") Is System.DBNull.Value Then
                    fdate1 = drl("abfromdate").ToString
                End If
                If Not drl("abtodate") Is System.DBNull.Value Then
                    tdate1 = drl("abtodate").ToString
                End If
                If Not drl("absfromdate") Is System.DBNull.Value Then
                    fdate2 = drl("absfromdate").ToString
                End If
                If Not drl("abstodate") Is System.DBNull.Value Then
                    tdate2 = drl("abstodate").ToString
                End If
                If Not drl("latedate") Is System.DBNull.Value Then
                    fdate3 = drl("latedate").ToString
                End If
                If Not drl("latedate") Is System.DBNull.Value Then
                    tdate3 = drl("latedate").ToString
                End If
                If Not drl("overnightdate") Is System.DBNull.Value Then
                    fdate4 = drl("overnightdate").ToString
                End If
                If Not drl("overnightdate") Is System.DBNull.Value Then
                    tdate4 = drl("overnightdate").ToString
                End If
                If Not drl("latereturndate") Is System.DBNull.Value Then
                    fdate5 = drl("latereturndate").ToString
                End If
                If Not drl("latereturndate") Is System.DBNull.Value Then
                    tdate5 = drl("latereturndate").ToString
                End If
                If Not drl("misconductdate") Is System.DBNull.Value Then
                    fdate6 = drl("misconductdate").ToString
                End If
                If Not drl("misconductdate") Is System.DBNull.Value Then
                    tdate6 = drl("misconductdate").ToString
                End If
                If Not drl("ranawaydate") Is System.DBNull.Value Then
                    fdate7 = drl("ranawaydate").ToString
                End If
                If Not drl("ranawaydate") Is System.DBNull.Value Then
                    tdate7 = drl("ranawaydate").ToString
                End If

                recno = drl("recordno").ToString
                empno = drl("empcode").ToString
                leavetype = drl("leavetype").ToString
                status = drl("status").ToString

                If leavetype = "Absent" Then
                    If (fdate1 > fd) And (td > tdate1) Then
                        frmdt = drl("abfromdate").ToString
                        todt = drl("abtodate").ToString
                        reason = drl("abreason").ToString
                        MyGlobal.Con_Str()
                        Dim conn As New SqlConnection(constr)
                        conn.Open()
                        Cmd = New SqlCommand("insert into leaveabsentism_rpt (recordno,empno,fromdate,todate,leavetype,reason,status) values('" & recno & "', '" & empno & "','" & frmdt & "','" & todt & "','" & leavetype & "','" & reason & "', '" & status & "')", conn)
                        Cmd.ExecuteNonQuery()
                    End If

                ElseIf leavetype = "Abscond" Then
                    'If (fdate2 > fd) And (tdate2 < td) Then
                    If (fdate2 > fd) And (td > tdate2) Then

                        frmdt = drl("absfromdate").ToString
                        todt = drl("abstodate").ToString
                        reason = drl("absreason").ToString
                        MyGlobal.Con_Str()
                        Dim conn As New SqlConnection(constr)
                        conn.Open()
                        Cmd = New SqlCommand("insert into leaveabsentism_rpt (recordno,empno,fromdate,todate,leavetype,reason,status) values('" & recno & "', '" & empno & "','" & frmdt & "','" & todt & "','" & leavetype & "','" & reason & "', '" & status & "')", conn)
                        Cmd.ExecuteNonQuery()
                    End If

                ElseIf leavetype = "LateComing" Or leavetype = "Latecoming" Then
                    If (fdate3 > fd) And (td > tdate3) Then

                        frmdt = drl("latedate").ToString
                        todt = drl("latedate").ToString
                        reason = drl("latereason").ToString
                        MyGlobal.Con_Str()
                        Dim conn As New SqlConnection(constr)
                        conn.Open()
                        Cmd = New SqlCommand("insert into leaveabsentism_rpt (recordno,empno,fromdate,todate,leavetype,reason,status) values('" & recno & "', '" & empno & "','" & frmdt & "','" & todt & "','" & leavetype & "','" & reason & "', '" & status & "')", conn)
                        Cmd.ExecuteNonQuery()
                    End If

                ElseIf leavetype = "OverNight" Then

                    If (fdate4 > fd) And (td > tdate4) Then

                        frmdt = drl("overnightdate").ToString
                        todt = drl("overnightdate").ToString
                        reason = drl("overnight").ToString
                        MyGlobal.Con_Str()
                        Dim conn As New SqlConnection(constr)
                        conn.Open()
                        Cmd = New SqlCommand("insert into leaveabsentism_rpt (recordno,empno,fromdate,todate,leavetype,reason,status) values('" & recno & "', '" & empno & "','" & frmdt & "','" & todt & "','" & leavetype & "','" & reason & "', '" & status & "')", conn)
                        Cmd.ExecuteNonQuery()
                    End If

                ElseIf leavetype = "LateReturn" Then
                    If (fdate5 > fd) And (td > tdate5) Then

                        frmdt = drl("latereturndate").ToString
                        todt = drl("latereturndate").ToString
                        reason = drl("latereturn").ToString
                        MyGlobal.Con_Str()
                        Dim conn As New SqlConnection(constr)
                        conn.Open()
                        Cmd = New SqlCommand("insert into leaveabsentism_rpt (recordno,empno,fromdate,todate,leavetype,reason,status) values('" & recno & "', '" & empno & "','" & frmdt & "','" & todt & "','" & leavetype & "','" & reason & "', '" & status & "')", conn)
                        Cmd.ExecuteNonQuery()
                    End If

                ElseIf leavetype = "Misconduct" Then
                    If (fdate6 > fd) And (td > tdate6) Then

                        frmdt = drl("misconductdate").ToString
                        todt = drl("misconductdate").ToString
                        reason = drl("misconduct").ToString
                        MyGlobal.Con_Str()
                        Dim conn As New SqlConnection(constr)
                        conn.Open()
                        Cmd = New SqlCommand("insert into leaveabsentism_rpt (recordno,empno,fromdate,todate,leavetype,reason,status) values('" & recno & "', '" & empno & "','" & frmdt & "','" & todt & "','" & leavetype & "','" & reason & "', '" & status & "')", conn)
                        Cmd.ExecuteNonQuery()
                    End If

                ElseIf leavetype = "RanAway" Then
                    If (fdate7 > fd) And (td > tdate7) Then
                        frmdt = drl("ranawaydate").ToString
                        todt = drl("ranawaydate").ToString
                        reason = drl("ranaway").ToString
                        MyGlobal.Con_Str()
                        Dim conn As New SqlConnection(constr)
                        conn.Open()
                        Cmd = New SqlCommand("insert into leaveabsentism_rpt (recordno,empno,fromdate,todate,leavetype,reason,status) values('" & recno & "', '" & empno & "','" & frmdt & "','" & todt & "','" & leavetype & "','" & reason & "', '" & status & "')", conn)
                        Cmd.ExecuteNonQuery()
                    End If
                End If
            Next
        End If

        Response.Redirect("/hrmis/Letter/ER/ERreports/leavereportsbyselection.aspx")

    End Sub
    Function getLdetails() As DataSet
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from leaveabsentism where empcode = '" & TextBox1.Text & "' and leavetype = '" & leavetype.SelectedValue & "'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "RLA")
        con.Close()
        Return ds
    End Function
    Function getOLdetails() As DataSet
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from leaveabsentism", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "RLA")
        con.Close()
        Return ds
    End Function
    Function delLdetails() As DataSet
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("delete from leaveabsentism_rpt ", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "LAR")
        con.Close()
        Return ds
    End Function

    Protected Sub cb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb.CheckedChanged
        If cb.Checked = True Then
            leavetype.Visible = False
            TextBox1.Visible = False
            dept.Visible = False
        Else
            leavetype.Visible = True
            TextBox1.Visible = True
            dept.Visible = True
        End If
    End Sub
End Class