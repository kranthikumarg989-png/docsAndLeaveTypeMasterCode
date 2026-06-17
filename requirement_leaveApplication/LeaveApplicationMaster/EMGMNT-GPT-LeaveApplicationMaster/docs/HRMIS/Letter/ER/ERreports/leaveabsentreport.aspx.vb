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
    Dim MyApp As New emanagement.EMSapplications
    Dim dep, reas As String
    Dim latedet
    Dim latehrs
    Dim latemins
    Dim ltfromtime
    Dim lttotime
    Dim datekey

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        'Session("empcode") = "014543"

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (191)
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
        'If cb.Checked = True Then
        '    Session("lrep") = "O"
        '    leavetype.Visible = False
        '    TextBox1.Visible = False
        '    dept.Visible = False
        'End If
    End Sub

    Protected Sub showtTrainingReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles showtTrainingReport.Click

        Session("lleavetype") = leavetype.SelectedValue.Trim

        If rdoptions.SelectedValue = "O" Then
            delLdetails()
            LoadRecordstorpt1()
            txtfrom.Text = ""
            txtto.Text = ""

        ElseIf rdoptions.SelectedValue = "dept" Then

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

            Session("ldept") = dept.SelectedValue.Trim

            'Session("lleavetype") = ""

            Session("lemp") = ""

            Response.Redirect("leavereportsbyselection.aspx")


        ElseIf rdoptions.SelectedValue = "emp" Then

            delLdetails()
            LoadRecordstorpt2()

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

            Session("lemp") = textbox1.Text.Trim

            Session("ldept") = ""
            'Session("lleavetype") = ""

            Response.Redirect("leavereportsbyselection.aspx")
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
                'Dim datekey
                Dim frmdt
                Dim todt
                Dim reason
                Dim status
                Dim recno
                'Dim empname
                Dim empno
                'Dim dept
                'Dim sect
                'Dim latedet
                'Dim latehrs
                'Dim latemins
                'Dim ltfromtime
                'Dim lttotime
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
                Appdetails(empno)

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

                If dep = dept.SelectedValue.Trim Then

                    If leavetype = "Absent" Then
                        If (fdate1 >= fd) And (td >= tdate1) Then

                            frmdt = drl("abfromdate").ToString
                            todt = drl("abtodate").ToString
                            'reason = drl("abreason").ToString
                            reas = drl("abreason").ToString
                            reason = Replace(reas, "'", "")
                            datekey = drl("datekeyin").ToString
                            latedet = "---"

                            MyGlobal.Con_Str()
                            Dim conn As New SqlConnection(constr)
                            conn.Open()
                            Cmd = New SqlCommand("insert into leaveabsentism_rpt (recordno,empno,dept,fromdate,todate,leavetype,reason,latehours,latemins,latefrom,lateto,status,datekeyin) values('" & recno & "', '" & empno & "','" & dep & "','" & frmdt & "','" & todt & "','" & leavetype & "','" & reason & "', '" & latehrs & "','" & latemins & "','" & ltfromtime & "','" & lttotime & "','" & status & "','" & datekey & "') ", conn)
                            Cmd.ExecuteNonQuery()
                        End If

                    ElseIf leavetype = "Abscond" Then
                        If (fdate2 >= fd) And (td >= tdate2) Then

                            frmdt = drl("absfromdate").ToString
                            todt = drl("abstodate").ToString
                            'reason = drl("absreason").ToString
                            reas = drl("absreason").ToString
                            reason = Replace(reas, "'", "")

                            datekey = drl("datekeyin").ToString
                            latedet = "---"

                            MyGlobal.Con_Str()
                            Dim conn As New SqlConnection(constr)
                            conn.Open()
                            Cmd = New SqlCommand("insert into leaveabsentism_rpt (recordno,empno,dept,fromdate,todate,leavetype,reason,latehours,latemins,latefrom,lateto,status,datekeyin) values('" & recno & "', '" & empno & "','" & dep & "','" & frmdt & "','" & todt & "','" & leavetype & "','" & reason & "', '" & latehrs & "','" & latemins & "','" & ltfromtime & "','" & lttotime & "','" & status & "','" & datekey & "') ", conn)
                            Cmd.ExecuteNonQuery()
                        End If

                    ElseIf leavetype = "LateComing" Then
                        If (fdate3 >= fd) And (td >= tdate3) Then

                            frmdt = drl("latedate").ToString
                            todt = drl("latedate").ToString
                            'reason = drl("latereason").ToString
                            reas = drl("latereason").ToString
                            reason = Replace(reas, "'", "")
                            latehrs = drl("latehours").ToString
                            latemins = drl("latemin").ToString
                            ltfromtime = drl("timefrom").ToString
                            lttotime = drl("timeto").ToString
                            datekey = drl("datekeyin").ToString

                            MyGlobal.Con_Str()
                            Dim conn As New SqlConnection(constr)
                            conn.Open()
                            Cmd = New SqlCommand("insert into leaveabsentism_rpt (recordno,empno,dept,fromdate,todate,leavetype,reason,latehours,latemins,latefrom,lateto,status,datekeyin) values('" & recno & "', '" & empno & "','" & dep & "','" & frmdt & "','" & todt & "','" & leavetype & "','" & reason & "', '" & latehrs & "','" & latemins & "','" & ltfromtime & "','" & lttotime & "','" & status & "','" & datekey & "') ", conn)
                            Cmd.ExecuteNonQuery()
                        End If

                    ElseIf leavetype = "OverNight" Then

                        If (fdate4 >= fd) And (td >= tdate4) Then

                            frmdt = drl("overnightdate").ToString
                            todt = drl("overnightdate").ToString
                            'reason = drl("overnight").ToString
                            reas = drl("overnight").ToString
                            reason = Replace(reas, "'", "")
                            latedet = "---"
                            datekey = drl("datekeyin").ToString

                            MyGlobal.Con_Str()
                            Dim conn As New SqlConnection(constr)
                            conn.Open()
                            Cmd = New SqlCommand("insert into leaveabsentism_rpt (recordno,empno,dept,fromdate,todate,leavetype,reason,latehours,latemins,latefrom,lateto,status,datekeyin) values('" & recno & "', '" & empno & "','" & dep & "','" & frmdt & "','" & todt & "','" & leavetype & "','" & reason & "', '" & latehrs & "','" & latemins & "','" & ltfromtime & "','" & lttotime & "','" & status & "','" & datekey & "') ", conn)
                            Cmd.ExecuteNonQuery()
                        End If

                    ElseIf leavetype = "LateReturn" Then
                        If (fdate5 >= fd) And (td >= tdate5) Then

                            frmdt = drl("latereturndate").ToString
                            todt = drl("latereturndate").ToString
                            'reason = drl("latereturn").ToString
                            reas = drl("latereturn").ToString
                            reason = Replace(reas, "'", "")
                            latedet = "---"
                            datekey = drl("datekeyin").ToString

                            MyGlobal.Con_Str()
                            Dim conn As New SqlConnection(constr)
                            conn.Open()
                            Cmd = New SqlCommand("insert into leaveabsentism_rpt (recordno,empno,dept,fromdate,todate,leavetype,reason,latehours,latemins,latefrom,lateto,status,datekeyin) values('" & recno & "', '" & empno & "','" & dep & "','" & frmdt & "','" & todt & "','" & leavetype & "','" & reason & "', '" & latehrs & "','" & latemins & "','" & ltfromtime & "','" & lttotime & "','" & status & "','" & datekey & "') ", conn)
                            Cmd.ExecuteNonQuery()
                        End If

                    ElseIf leavetype = "Misconduct" Then
                        If (fdate6 >= fd) And (td >= tdate6) Then

                            frmdt = drl("misconductdate").ToString
                            todt = drl("misconductdate").ToString
                            'reason = drl("misconduct").ToString
                            reas = drl("misconduct").ToString
                            reason = Replace(reas, "'", "")
                            latedet = "---"
                            datekey = drl("datekeyin").ToString

                            MyGlobal.Con_Str()
                            Dim conn As New SqlConnection(constr)
                            conn.Open()
                            Cmd = New SqlCommand("insert into leaveabsentism_rpt (recordno,empno,dept,fromdate,todate,leavetype,reason,latehours,latemins,latefrom,lateto,status,datekeyin) values('" & recno & "', '" & empno & "','" & dep & "','" & frmdt & "','" & todt & "','" & leavetype & "','" & reason & "', '" & latehrs & "','" & latemins & "','" & ltfromtime & "','" & lttotime & "','" & status & "','" & datekey & "') ", conn)
                            Cmd.ExecuteNonQuery()
                        End If
                    ElseIf leavetype = "RanAway" Then
                        If (fdate7 >= fd) And (td >= tdate7) Then

                            frmdt = drl("ranawaydate").ToString
                            todt = drl("ranawaydate").ToString
                            'reason = drl("ranaway").ToString
                            reas = drl("ranaway").ToString
                            reason = Replace(reas, "'", "")
                            latedet = "---"
                            datekey = drl("datekeyin").ToString

                            MyGlobal.Con_Str()
                            Dim conn As New SqlConnection(constr)
                            conn.Open()
                            Cmd = New SqlCommand("insert into leaveabsentism_rpt (recordno,empno,dept,fromdate,todate,leavetype,reason,latehours,latemins,latefrom,lateto,status,datekeyin) values('" & recno & "', '" & empno & "','" & dep & "','" & frmdt & "','" & todt & "','" & leavetype & "','" & reason & "', '" & latehrs & "','" & latemins & "','" & ltfromtime & "','" & lttotime & "','" & status & "','" & datekey & "') ", conn)
                            Cmd.ExecuteNonQuery()
                        End If

                    End If
                Else
                End If

            Next

        End If
    End Sub
    Private Sub LoadRecordstorpt4()

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
        Dim latedet
        Dim latehrs
        Dim latemins
        Dim ltfromtime
        Dim lttotime
        Dim dsl As DataSet
        Dim drl As DataRow
        Dim j As Integer
        dsl = getLdetails3()
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
                Appdetails(empno)
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
                    If (fdate1 >= fd) And (td >= tdate1) Then

                        frmdt = drl("abfromdate").ToString
                        todt = drl("abtodate").ToString
                        'reason = drl("abreason").ToString
                        reas = drl("abreason").ToString
                        reason = Replace(reas, "'", "")
                        datekey = drl("datekeyin").ToString
                        latedet = "---"

                        MyGlobal.Con_Str()
                        Dim conn As New SqlConnection(constr)
                        conn.Open()
                        Cmd = New SqlCommand("insert into leaveabsentism_rpt (recordno,empno,dept,fromdate,todate,leavetype,reason,latehours,latemins,latefrom,lateto,status,datekeyin) values('" & recno & "', '" & empno & "','" & dep & "','" & frmdt & "','" & todt & "','" & leavetype & "','" & reason & "', '" & latehrs & "','" & latemins & "','" & ltfromtime & "','" & lttotime & "','" & status & "','" & datekey & "') ", conn)
                        Cmd.ExecuteNonQuery()
                    End If

                ElseIf leavetype = "Abscond" Then
                    If (fdate2 >= fd) And (td >= tdate2) Then

                        frmdt = drl("absfromdate").ToString
                        todt = drl("abstodate").ToString
                        'reason = drl("absreason").ToString
                        reas = drl("absreason").ToString
                        reason = Replace(reas, "'", "")
                        datekey = drl("datekeyin").ToString
                        latedet = "---"

                        MyGlobal.Con_Str()
                        Dim conn As New SqlConnection(constr)
                        conn.Open()
                        Cmd = New SqlCommand("insert into leaveabsentism_rpt (recordno,empno,dept,fromdate,todate,leavetype,reason,latehours,latemins,latefrom,lateto,status,datekeyin) values('" & recno & "', '" & empno & "','" & dep & "','" & frmdt & "','" & todt & "','" & leavetype & "','" & reason & "', '" & latehrs & "','" & latemins & "','" & ltfromtime & "','" & lttotime & "','" & status & "','" & datekey & "') ", conn)
                        Cmd.ExecuteNonQuery()
                    End If

                ElseIf leavetype = "LateComing" Then
                    If (fdate3 >= fd) And (td >= tdate3) Then

                        frmdt = drl("latedate").ToString
                        todt = drl("latedate").ToString
                        'reason = drl("latereason").ToString
                        reas = drl("latereason").ToString
                        reason = Replace(reas, "'", "")
                        latehrs = drl("latehours").ToString
                        latemins = drl("latemin").ToString
                        ltfromtime = drl("timefrom").ToString
                        lttotime = drl("timeto").ToString
                        datekey = drl("datekeyin").ToString

                        MyGlobal.Con_Str()
                        Dim conn As New SqlConnection(constr)
                        conn.Open()
                        Cmd = New SqlCommand("insert into leaveabsentism_rpt (recordno,empno,dept,fromdate,todate,leavetype,reason,latehours,latemins,latefrom,lateto,status,datekeyin) values('" & recno & "', '" & empno & "','" & dep & "','" & frmdt & "','" & todt & "','" & leavetype & "','" & reason & "', '" & latehrs & "','" & latemins & "','" & ltfromtime & "','" & lttotime & "','" & status & "','" & datekey & "') ", conn)
                        Cmd.ExecuteNonQuery()
                    End If

                ElseIf leavetype = "OverNight" Then

                    If (fdate4 >= fd) And (td >= tdate4) Then

                        frmdt = drl("overnightdate").ToString
                        todt = drl("overnightdate").ToString
                        'reason = drl("overnight").ToString
                        reas = drl("overnight").ToString
                        reason = Replace(reas, "'", "")
                        latedet = "---"
                        datekey = drl("datekeyin").ToString

                        MyGlobal.Con_Str()
                        Dim conn As New SqlConnection(constr)
                        conn.Open()
                        Cmd = New SqlCommand("insert into leaveabsentism_rpt (recordno,empno,dept,fromdate,todate,leavetype,reason,latehours,latemins,latefrom,lateto,status,datekeyin) values('" & recno & "', '" & empno & "','" & dep & "','" & frmdt & "','" & todt & "','" & leavetype & "','" & reason & "', '" & latehrs & "','" & latemins & "','" & ltfromtime & "','" & lttotime & "','" & status & "','" & datekey & "') ", conn)
                        Cmd.ExecuteNonQuery()
                    End If

                ElseIf leavetype = "LateReturn" Then
                    If (fdate5 >= fd) And (td >= tdate5) Then

                        frmdt = drl("latereturndate").ToString
                        todt = drl("latereturndate").ToString
                        'reason = drl("latereturn").ToString
                        reas = drl("latereturn").ToString
                        reason = Replace(reas, "'", "")
                        latedet = "---"
                        datekey = drl("datekeyin").ToString

                        MyGlobal.Con_Str()
                        Dim conn As New SqlConnection(constr)
                        conn.Open()
                        Cmd = New SqlCommand("insert into leaveabsentism_rpt (recordno,empno,dept,fromdate,todate,leavetype,reason,latehours,latemins,latefrom,lateto,status,datekeyin) values('" & recno & "', '" & empno & "','" & dep & "','" & frmdt & "','" & todt & "','" & leavetype & "','" & reason & "', '" & latehrs & "','" & latemins & "','" & ltfromtime & "','" & lttotime & "','" & status & "','" & datekey & "') ", conn)
                        Cmd.ExecuteNonQuery()
                    End If

                ElseIf leavetype = "Misconduct" Then
                    If (fdate6 >= fd) And (td >= tdate6) Then

                        frmdt = drl("misconductdate").ToString
                        todt = drl("misconductdate").ToString
                        'reason = drl("misconduct").ToString
                        reas = drl("misconduct").ToString
                        reason = Replace(reas, "'", "")
                        'MsgBox(reason)
                        latedet = "---"
                        datekey = drl("datekeyin").ToString

                        MyGlobal.Con_Str()
                        Dim conn As New SqlConnection(constr)
                        conn.Open()
                        Cmd = New SqlCommand("insert into leaveabsentism_rpt (recordno,empno,dept,fromdate,todate,leavetype,reason,latehours,latemins,latefrom,lateto,status,datekeyin) values('" & recno & "', '" & empno & "','" & dep & "','" & frmdt & "','" & todt & "','" & leavetype & "','" & reason & "', '" & latehrs & "','" & latemins & "','" & ltfromtime & "','" & lttotime & "','" & status & "','" & datekey & "') ", conn)
                        Cmd.ExecuteNonQuery()
                    End If
                ElseIf leavetype = "RanAway" Then
                    If (fdate7 >= fd) And (td >= tdate7) Then

                        frmdt = drl("ranawaydate").ToString
                        todt = drl("ranawaydate").ToString
                        'reason = drl("ranaway").ToString
                        reas = drl("ranaway").ToString
                        reason = Replace(reas, "'", "")
                        latedet = "---"
                        datekey = drl("datekeyin").ToString

                        MyGlobal.Con_Str()
                        Dim conn As New SqlConnection(constr)
                        conn.Open()
                        Cmd = New SqlCommand("insert into leaveabsentism_rpt (recordno,empno,dept,fromdate,todate,leavetype,reason,latehours,latemins,latefrom,lateto,status,datekeyin) values('" & recno & "', '" & empno & "','" & dep & "','" & frmdt & "','" & todt & "','" & leavetype & "','" & reason & "', '" & latehrs & "','" & latemins & "','" & ltfromtime & "','" & lttotime & "','" & status & "','" & datekey & "') ", conn)
                        Cmd.ExecuteNonQuery()
                    End If

                End If
            Next

        End If
    End Sub
    Private Sub LoadRecordstorpt2()

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
        dsl = getLdetails1()
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
                Appdetails(empno)
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
                    If (fdate1 >= fd) And (td >= tdate1) Then

                        frmdt = drl("abfromdate").ToString
                        todt = drl("abtodate").ToString
                        'reason = drl("abreason").ToString
                        reas = drl("abreason").ToString
                        reason = Replace(reas, "'", "")
                        datekey = drl("datekeyin").ToString
                        latedet = "---"

                        MyGlobal.Con_Str()
                        Dim conn As New SqlConnection(constr)
                        conn.Open()
                        Cmd = New SqlCommand("insert into leaveabsentism_rpt (recordno,empno,dept,fromdate,todate,leavetype,reason,latehours,latemins,latefrom,lateto,status,datekeyin) values('" & recno & "', '" & empno & "','" & dep & "','" & frmdt & "','" & todt & "','" & leavetype & "','" & reason & "', '" & latehrs & "','" & latemins & "','" & ltfromtime & "','" & lttotime & "','" & status & "','" & datekey & "') ", conn)
                        Cmd.ExecuteNonQuery()
                    End If

                ElseIf leavetype = "Abscond" Then
                    If (fdate2 >= fd) And (td >= tdate2) Then

                        frmdt = drl("absfromdate").ToString
                        todt = drl("abstodate").ToString
                        'reason = drl("absreason").ToString
                        reas = drl("absreason").ToString
                        reason = Replace(reas, "'", "")
                        datekey = drl("datekeyin").ToString
                        latedet = "---"

                        MyGlobal.Con_Str()
                        Dim conn As New SqlConnection(constr)
                        conn.Open()
                        Cmd = New SqlCommand("insert into leaveabsentism_rpt (recordno,empno,dept,fromdate,todate,leavetype,reason,latehours,latemins,latefrom,lateto,status,datekeyin) values('" & recno & "', '" & empno & "','" & dep & "','" & frmdt & "','" & todt & "','" & leavetype & "','" & reason & "', '" & latehrs & "','" & latemins & "','" & ltfromtime & "','" & lttotime & "','" & status & "','" & datekey & "') ", conn)
                        Cmd.ExecuteNonQuery()
                    End If

                ElseIf leavetype = "LateComing" Then
                    If (fdate3 >= fd) And (td >= tdate3) Then

                        frmdt = drl("latedate").ToString
                        todt = drl("latedate").ToString
                        'reason = drl("latereason").ToString
                        reas = drl("latereason").ToString
                        reason = Replace(reas, "'", "")
                        latehrs = drl("latehours").ToString
                        latemins = drl("latemin").ToString
                        ltfromtime = drl("timefrom").ToString
                        lttotime = drl("timeto").ToString
                        datekey = drl("datekeyin").ToString

                        MyGlobal.Con_Str()
                        Dim conn As New SqlConnection(constr)
                        conn.Open()
                        Cmd = New SqlCommand("insert into leaveabsentism_rpt (recordno,empno,dept,fromdate,todate,leavetype,reason,latehours,latemins,latefrom,lateto,status,datekeyin) values('" & recno & "', '" & empno & "','" & dep & "','" & frmdt & "','" & todt & "','" & leavetype & "','" & reason & "', '" & latehrs & "','" & latemins & "','" & ltfromtime & "','" & lttotime & "','" & status & "','" & datekey & "') ", conn)
                        Cmd.ExecuteNonQuery()
                    End If

                ElseIf leavetype = "OverNight" Then

                    If (fdate4 >= fd) And (td >= tdate4) Then

                        frmdt = drl("overnightdate").ToString
                        todt = drl("overnightdate").ToString
                        'reason = drl("overnight").ToString
                        reas = drl("overnight").ToString
                        reason = Replace(reas, "'", "")
                        latedet = "---"
                        datekey = drl("datekeyin").ToString

                        MyGlobal.Con_Str()
                        Dim conn As New SqlConnection(constr)
                        conn.Open()
                        Cmd = New SqlCommand("insert into leaveabsentism_rpt (recordno,empno,dept,fromdate,todate,leavetype,reason,latehours,latemins,latefrom,lateto,status,datekeyin) values('" & recno & "', '" & empno & "','" & dep & "','" & frmdt & "','" & todt & "','" & leavetype & "','" & reason & "', '" & latehrs & "','" & latemins & "','" & ltfromtime & "','" & lttotime & "','" & status & "','" & datekey & "') ", conn)
                        Cmd.ExecuteNonQuery()
                    End If

                ElseIf leavetype = "LateReturn" Then
                    If (fdate5 >= fd) And (td >= tdate5) Then

                        frmdt = drl("latereturndate").ToString
                        todt = drl("latereturndate").ToString
                        'reason = drl("latereturn").ToString
                        reas = drl("latereturn").ToString
                        reason = Replace(reas, "'", "")
                        latedet = "---"
                        datekey = drl("datekeyin").ToString

                        MyGlobal.Con_Str()
                        Dim conn As New SqlConnection(constr)
                        conn.Open()
                        Cmd = New SqlCommand("insert into leaveabsentism_rpt (recordno,empno,dept,fromdate,todate,leavetype,reason,latehours,latemins,latefrom,lateto,status,datekeyin) values('" & recno & "', '" & empno & "','" & dep & "','" & frmdt & "','" & todt & "','" & leavetype & "','" & reason & "', '" & latehrs & "','" & latemins & "','" & ltfromtime & "','" & lttotime & "','" & status & "','" & datekey & "') ", conn)
                        Cmd.ExecuteNonQuery()
                    End If

                ElseIf leavetype = "Misconduct" Then
                    If (fdate6 >= fd) And (td >= tdate6) Then

                        frmdt = drl("misconductdate").ToString
                        todt = drl("misconductdate").ToString
                        'reason = drl("misconduct").ToString
                        reas = drl("misconduct").ToString
                        reason = Replace(reas, "'", "")
                        latedet = "---"
                        datekey = drl("datekeyin").ToString

                        MyGlobal.Con_Str()
                        Dim conn As New SqlConnection(constr)
                        conn.Open()
                        Cmd = New SqlCommand("insert into leaveabsentism_rpt (recordno,empno,dept,fromdate,todate,leavetype,reason,latehours,latemins,latefrom,lateto,status,datekeyin) values('" & recno & "', '" & empno & "','" & dep & "','" & frmdt & "','" & todt & "','" & leavetype & "','" & reason & "', '" & latehrs & "','" & latemins & "','" & ltfromtime & "','" & lttotime & "','" & status & "','" & datekey & "') ", conn)
                        Cmd.ExecuteNonQuery()
                    End If
                ElseIf leavetype = "RanAway" Then
                    If (fdate7 >= fd) And (td >= tdate7) Then

                        frmdt = drl("ranawaydate").ToString
                        todt = drl("ranawaydate").ToString
                        'reason = drl("ranaway").ToString
                        reas = drl("ranaway").ToString
                        reason = Replace(reas, "'", "")
                        latedet = "---"
                        datekey = drl("datekeyin").ToString

                        MyGlobal.Con_Str()
                        Dim conn As New SqlConnection(constr)
                        conn.Open()
                        Cmd = New SqlCommand("insert into leaveabsentism_rpt (recordno,empno,dept,fromdate,todate,leavetype,reason,latehours,latemins,latefrom,lateto,status,datekeyin) values('" & recno & "', '" & empno & "','" & dep & "','" & frmdt & "','" & todt & "','" & leavetype & "','" & reason & "', '" & latehrs & "','" & latemins & "','" & ltfromtime & "','" & lttotime & "','" & status & "','" & datekey & "') ", conn)
                        Cmd.ExecuteNonQuery()
                    End If

                End If
            Next

        End If
    End Sub
    Private Sub Appdetails(ByVal empno)
        Dim dr1 As DataRow
        Dim ecode = empno
        Getcedata(ecode)
        If recstatus = True Then
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr1 = dsdata.Tables(0).Rows(0)
                dep = dr1("departmentcode").ToString
            Else
                'MessageBox("EmployeeCode doesnot Exist!!")
            End If
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
                    If (fdate1 >= fd) And (td >= tdate1) Then
                        frmdt = drl("abfromdate").ToString
                        todt = drl("abtodate").ToString
                        'reason = drl("abreason").ToString
                        reas = drl("abreason").ToString
                        reason = Replace(reas, "'", "")
                        MyGlobal.Con_Str()
                        Dim conn As New SqlConnection(constr)
                        conn.Open()
                        Cmd = New SqlCommand("insert into leaveabsentism_rpt (recordno,empno,fromdate,todate,leavetype,reason,status) values('" & recno & "', '" & empno & "','" & frmdt & "','" & todt & "','" & leavetype & "','" & reason & "', '" & status & "')", conn)
                        Cmd.ExecuteNonQuery()
                    End If

                ElseIf leavetype = "Abscond" Then
                    'If (fdate2 > fd) And (tdate2 < td) Then
                    If (fdate2 >= fd) And (td >= tdate2) Then

                        frmdt = drl("absfromdate").ToString
                        todt = drl("abstodate").ToString
                        'reason = drl("absreason").ToString
                        reas = drl("absreason").ToString
                        reason = Replace(reas, "'", "")
                        MyGlobal.Con_Str()
                        Dim conn As New SqlConnection(constr)
                        conn.Open()
                        Cmd = New SqlCommand("insert into leaveabsentism_rpt (recordno,empno,fromdate,todate,leavetype,reason,status) values('" & recno & "', '" & empno & "','" & frmdt & "','" & todt & "','" & leavetype & "','" & reason & "', '" & status & "')", conn)
                        Cmd.ExecuteNonQuery()
                    End If

                ElseIf leavetype = "LateComing" Or leavetype = "Latecoming" Then
                    If (fdate3 >= fd) And (td >= tdate3) Then

                        frmdt = drl("latedate").ToString
                        todt = drl("latedate").ToString
                        'reason = drl("latereason").ToString
                        reas = drl("latereason").ToString
                        reason = Replace(reas, "'", "")
                        latehrs = drl("latehours").ToString
                        latemins = drl("latemin").ToString
                        ltfromtime = drl("timefrom").ToString
                        lttotime = drl("timeto").ToString
                        datekey = drl("datekeyin").ToString

                        MyGlobal.Con_Str()
                        Dim conn As New SqlConnection(constr)
                        conn.Open()
                        Cmd = New SqlCommand("insert into leaveabsentism_rpt (recordno,empno,dept,fromdate,todate,leavetype,reason,latehours,latemins,latefrom,lateto,status,datekeyin) values('" & recno & "', '" & empno & "','" & dep & "','" & frmdt & "','" & todt & "','" & leavetype & "','" & reason & "', '" & latehrs & "','" & latemins & "','" & ltfromtime & "','" & lttotime & "','" & status & "','" & datekey & "') ", conn)
                        Cmd.ExecuteNonQuery()
                    End If

                ElseIf leavetype = "OverNight" Then

                    If (fdate4 >= fd) And (td >= tdate4) Then

                        frmdt = drl("overnightdate").ToString
                        todt = drl("overnightdate").ToString
                        'reason = drl("overnight").ToString
                        reas = drl("overnight").ToString
                        reason = Replace(reas, "'", "")
                        MyGlobal.Con_Str()
                        Dim conn As New SqlConnection(constr)
                        conn.Open()
                        Cmd = New SqlCommand("insert into leaveabsentism_rpt (recordno,empno,fromdate,todate,leavetype,reason,status) values('" & recno & "', '" & empno & "','" & frmdt & "','" & todt & "','" & leavetype & "','" & reason & "', '" & status & "')", conn)
                        Cmd.ExecuteNonQuery()
                    End If

                ElseIf leavetype = "LateReturn" Then
                    If (fdate5 >= fd) And (td >= tdate5) Then

                        frmdt = drl("latereturndate").ToString
                        todt = drl("latereturndate").ToString
                        'reason = drl("latereturn").ToString
                        reas = drl("latereturn").ToString
                        reason = Replace(reas, "'", "")
                        MyGlobal.Con_Str()
                        Dim conn As New SqlConnection(constr)
                        conn.Open()
                        Cmd = New SqlCommand("insert into leaveabsentism_rpt (recordno,empno,fromdate,todate,leavetype,reason,status) values('" & recno & "', '" & empno & "','" & frmdt & "','" & todt & "','" & leavetype & "','" & reason & "', '" & status & "')", conn)
                        Cmd.ExecuteNonQuery()
                    End If

                ElseIf leavetype = "Misconduct" Then
                    If (fdate6 >= fd) And (td >= tdate6) Then

                        frmdt = drl("misconductdate").ToString
                        todt = drl("misconductdate").ToString
                        'reason = drl("misconduct").ToString
                        reas = drl("misconduct").ToString
                        reason = Replace(reas, "'", "")
                        MyGlobal.Con_Str()
                        Dim conn As New SqlConnection(constr)
                        conn.Open()
                        Cmd = New SqlCommand("insert into leaveabsentism_rpt (recordno,empno,fromdate,todate,leavetype,reason,status) values('" & recno & "', '" & empno & "','" & frmdt & "','" & todt & "','" & leavetype & "','" & reason & "', '" & status & "')", conn)
                        Cmd.ExecuteNonQuery()
                    End If

                ElseIf leavetype = "RanAway" Then
                    If (fdate7 >= fd) And (td >= tdate7) Then
                        frmdt = drl("ranawaydate").ToString
                        todt = drl("ranawaydate").ToString
                        'reason = drl("ranaway").ToString
                        reas = drl("ranaway").ToString
                        reason = Replace(reas, "'", "")
                        MyGlobal.Con_Str()
                        Dim conn As New SqlConnection(constr)
                        conn.Open()
                        Cmd = New SqlCommand("insert into leaveabsentism_rpt (recordno,empno,fromdate,todate,leavetype,reason,status) values('" & recno & "', '" & empno & "','" & frmdt & "','" & todt & "','" & leavetype & "','" & reason & "', '" & status & "')", conn)
                        Cmd.ExecuteNonQuery()
                    End If
                End If
            Next
        End If

        Response.Redirect("leavereportsbyselection.aspx")

    End Sub
    Function getLdetails() As DataSet
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from leaveabsentism where leavetype = '" & leavetype.SelectedValue.Trim & "'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "RLA")
        con.Close()
        Return ds
    End Function
    Function getLdetails1() As DataSet
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from leaveabsentism where empcode = '" & textbox1.Text.Trim & "' and leavetype = '" & leavetype.SelectedValue.Trim & "'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "RLA")
        con.Close()
        Return ds
    End Function
    Function getLdetails3() As DataSet
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from leaveabsentism where leavetype = '" & leavetype.SelectedValue.Trim & "'", con)
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
        Command = New SqlCommand("select * from leaveabsentism where leavetype = '" & leavetype.SelectedValue.Trim & "'", con)
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


    Protected Sub rdoptions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoptions.SelectedIndexChanged
        dept.SelectedValue = "-1"
        textbox1.Text = ""
        If rdoptions.SelectedValue = "dept" Then
            dept.Enabled = True
            textbox1.Enabled = False
        ElseIf rdoptions.SelectedValue = "emp" Then
            textbox1.Enabled = True
            dept.Enabled = False
        ElseIf rdoptions.SelectedValue = "O" Then
            textbox1.Enabled = False
            dept.Enabled = False
        End If
    End Sub
End Class