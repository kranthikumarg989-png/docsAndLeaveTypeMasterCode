Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class OTstaffEntry
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim thisdate As Date
    Dim appno, empcode, SECT As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (65)
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
        empcode = Session("empcode")
        SECT = Session("_eSECT")
        LblMsg.Text = ""

    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub applynow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles applynow.Click

        If TxtReason.Text.Length <= 5 Then
            MessageBox("Please enter valid reason for over time!")
            Exit Sub
        End If

        Dim recno

        Dim fd1 As String
        fd1 = vfdt.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)

        Dim td1 As String
        td1 = vtdt.Text.Trim
        Dim strdate2() As String = td1.Split("/"c)
        td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

        Dim td As Date
        td = CDate(td1)

        Dim thisdate As Date
        thisdate = Format(Convert.ToDateTime(Date.Now), "MM/dd/yy")


        Dim otdays As Integer
        otdays = td.Subtract(fd).Days

        If fd > td Then
            LblMsg.Text = "Please Check the date selected"
            Exit Sub
        End If

        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        ''''''''''''''''''''''''''''''' GET MAX OT HRS ALLOTED FOR THAT SECTION

        Dim STARTDATE, ENDDATE
        Dim MAXHRS
        Dim Takenhrs
        Dim dsmc1, dsmh As DataSet
        Dim drmc1, drmh As DataRow
        dsmc1 = GetmAXoThRSbYSECT()
        If dsmc1.Tables(0).Rows.Count <> 0 Then
            drmc1 = dsmc1.Tables(0).Rows(0)
            STARTDATE = Format(Convert.ToDateTime(drmc1("startdate")), "MM/dd/yy")
            ENDDATE = Format(Convert.ToDateTime(drmc1("enddate")), "MM/dd/yy")
            MAXHRS = drmc1("maxhours")
            ''''''''''''''''''''''''''''''' GET MAX OT HRS ALLOTED utilised by THAT SECTION
            dsmh = GetTotmAXoThRSbYSECT(STARTDATE, ENDDATE)
            If dsmh.Tables(0).Rows.Count <> 0 Then
                drmh = dsmh.Tables(0).Rows(0)
                If Not drmh("hrs") Is System.DBNull.Value Then
                    Takenhrs = drmh("hrs")
                Else
                    Takenhrs = 0
                End If
            Else
                Takenhrs = 0
            End If
        Else
            MAXHRS = 0
        End If
        ''''''''''''''''''''''''''''''''''' Get shift from empmaster and chk staff elligibility
        Dim shift
        Dim dsmc As DataSet
        Dim drmc As DataRow
        dsmc = Getshift(empcode)
        Dim mymaxhrs As Decimal
        If dsmc.Tables(0).Rows.Count <> 0 Then
            drmc = dsmc.Tables(0).Rows(0)
            If Not drmc("shift") Is System.DBNull.Value Then
                shift = drmc("shift")
            Else
                shift = "NIL"
            End If
            If Not drmc("maxhrs") Is System.DBNull.Value Then
                mymaxhrs = drmc("maxhrs")
            Else
                '''' Get total section maxhrs and divide by all employees elligible for OT
                Dim dsm As DataSet
                Dim drs As DataRow
                dsm = GettotPaxInSect()
                If dsm.Tables(0).Rows.Count <> 0 Then
                    drs = dsm.Tables(0).Rows(0)
                    Dim totpax = drs("totpax").ToString
                    mymaxhrs = MAXHRS / totpax
                End If
            End If
        Else
            LblMsg.Text = "YOU ARE NOT ELLIGIBLE FOR OT."
            Exit Sub
        End If

        ''''''''''''''''''''''''''''''' GET MAX OT HRS ALLOTED FOR week

        Dim dsweek As DataSet
        Dim drweek As DataRow
        Dim Maxwkhrs
        dsweek = GetWeekOt()
        If dsweek.Tables(0).Rows.Count <> 0 Then
            drweek = dsweek.Tables(0).Rows(0)
            If Not drweek("tothrs") Is System.DBNull.Value Then
                Maxwkhrs = drweek("tothrs")
            Else
                Maxwkhrs = 0
            End If
        Else
            Maxwkhrs = 0
        End If
        ''''''' 


        Dim i
        For i = 0 To otdays
            Dim SelDate As Date = fd.AddDays(i)
            Dim myday = "day" & Day(SelDate)

            Dim dsprshift As DataSet
            Dim drprshift As DataRow
            '''''''''' get shift from PR table
            dsprshift = GetPRshift(myday, empcode, SelDate)
            If dsprshift.Tables(0).Rows.Count <> 0 Then
                drprshift = dsprshift.Tables(0).Rows(0)
                If Not drprshift(0) Is System.DBNull.Value Then
                    shift = drprshift(0)
                End If
            End If
            ''''''''''' chk if the emp applied for leave /RL in the selected date
            Dim dsleave As DataSet
            Dim drleave As DataRow
            Dim leavefromdate, leavetodate, newdate As Date
            Dim leavediff
            Dim ltime
            Dim j
            '''''''''' get shift from PR table
            dsleave = GetLeave(SelDate)
            If dsleave.Tables(0).Rows.Count <> 0 Then
                drleave = dsleave.Tables(0).Rows(0)
                leavefromdate = drleave("fromdate")
                leavetodate = drleave("todate")
                leavediff = leavetodate.Subtract(leavefromdate).Days
                If leavediff = 0 Then
                    shift = drleave("leavetype")
                    ltime = drleave("grantedleave")
                Else
                    j = 0
                    For j = 0 To leavediff
                        newdate = leavefromdate.AddDays(j)
                        If SelDate = newdate Then
                            shift = drleave("leavetype")
                        End If
                    Next
                End If
            Else
                shift = shift
            End If

            Dim dsRL As DataSet
            Dim drRL As DataRow

            dsRL = GetRL(SelDate)
            If dsRL.Tables(0).Rows.Count <> 0 Then
                drRL = dsRL.Tables(0).Rows(0)
                shift = "REPLACE"
            End If

            ''''''''''''''''''''''''''''''CHECK WHETHER THE RECORD ALREADY IN OT TABLE 

            Dim dsOt As DataSet
            Dim drOt As DataRow
            Dim otyn
            Dim remarks
            Dim myrec
            Dim myot
            Dim ottype
            Dim othr
            myot = othrs.Text
            dsOt = GetOTRec(SelDate)
            If dsOt.Tables(0).Rows.Count <> 0 Then
                drOt = dsOt.Tables(0).Rows(0)
                shift = drOt("shift")
                otyn = drOt("OT")
                ' ottype = rsot.data("ottype")
                othr = drOt("hrs")
                remarks = drOt("remark")
                myrec = drOt("recno")
                myot = "0"
                'myot = drOt("hrs")
            Else
                otyn = ""
                Ottype = "OTND"
                othr = othrs.Text
                remarks = TxtReason.Text
            End If
            ottype = "OTND"
            '  remarks = "-"
            '''''' find out the cur week and max week ot hrs
            Dim VarDtCount
            Dim VarFromDt
            Dim VarToDt
            Dim vfd
            Dim vtd

            VarDtCount = SelDate.dayofweek
          
            If VarDtCount = 1 Then
                VarFromDt = SelDate
                VarToDt = SelDate.AddDays(6)
            ElseIf VarDtCount = 2 Then
                VarFromDt = SelDate.AddDays(-1)
                VarToDt = SelDate.AddDays(5)
            ElseIf VarDtCount = 3 Then
                VarFromDt = SelDate.AddDays(-2)
                VarToDt = SelDate.AddDays(4)
            ElseIf VarDtCount = 4 Then
                VarFromDt = SelDate.AddDays(-3)
                VarToDt = SelDate.AddDays(3)
            ElseIf VarDtCount = 5 Then
                VarFromDt = SelDate.AddDays(-4)
                VarToDt = SelDate.AddDays(2)
            ElseIf VarDtCount = 6 Then
                VarFromDt = SelDate.AddDays(-5)
                VarToDt = SelDate.AddDays(1)
            ElseIf VarDtCount = 0 Then
                VarFromDt = SelDate.AddDays(-6)
                VarToDt = SelDate
            End If


            'vfd = Mid(dtoc(VarFromDt), 4, 2) + "/" + Left(dtoc(VarFromDt), 2) + "/" + Right(dtoc(VarFromDt), 4)
            'vtd = Mid(dtoc(VarToDt), 4, 2) + "/" + Left(dtoc(VarToDt), 2) + "/" + Right(dtoc(VarToDt), 4)

            vfd = VarFromDt
            vtd = VarToDt

            Dim dsWOT As DataSet
            Dim drWOT As DataRow
            Dim MyweekOT
            dsWOT = GetWEEKOt(SelDate, VarFromDt, VarToDt)
            If dsWOT.Tables(0).Rows.Count <> 0 Then
                drWOT = dsWOT.Tables(0).Rows(0)
                If Not drWOT("totot") Is System.DBNull.Value Then
                    MyweekOT = drWOT("totot")
                Else
                    MyweekOT = 0
                End If
            Else
                MyweekOT = 0
            End If

            Dim totwkot
            Dim applied
            applied = 0
            totwkot = 0
            totwkot = MyweekOT + myot

            If lblpass.Text <> "0" Then

                totwkot = (totwkot + othrs.Text) - lbldbot.Text

            End If

            ' Dim startdt
            ' Dim enddt

            ' Dim cm1 As String
            ' cm1 = DateTime.Now
            ' Dim strdat() As String = td1.Split("/"c)
            ' cm1 = strdat(1) & "/" & strdat(0) & "/" & strdat(2)

            ' Dim cm As Date
            ' cm = CDate(cm1)

            ' startdt = Day(fd)
            ' enddt = Day(td)
            ' Dim startmth
            'startmth = cm.

            ' If Day(fd) < "20" Then
            '     VarFromDt = fd.Month & "/" & 20 & "/" & fd.Year
            ' Else
            '     varfromdt = 
            ' End If
            '''get my month ot...need to find out cur mth when they key in OT

            Dim dsmOT As DataSet
            Dim drmOT As DataRow
            Dim MymthOT
            dsmOT = GetmthOt(SelDate, VarFromDt, VarToDt)
            If dsmOT.Tables(0).Rows.Count <> 0 Then
                drmOT = dsmOT.Tables(0).Rows(0)
                If Not drmOT("totot") Is System.DBNull.Value Then
                    MymthOT = drmOT("totot")
                Else
                    MymthOT = 0
                End If
            Else
                MymthOT = 0
            End If


            If (Takenhrs > MAXHRS) Or (totwkot > Maxwkhrs) Or (MymthOT > mymaxhrs) Then
                LblMsg.Text = "OT Limit Exceeded"
                Exit Sub
            Else
                '''''''''' update record
                If lblpass.Text <> "0" Then

                    Try
                        MyGlobal.Open_Con()
                        MyGlobal.Con_Str()
                        Call MyGlobal.dbSp_open("OT_UPD_Entry")

                        Cmd.Parameters.AddWithValue("@recno", lblpass.Text)
                        Cmd.Parameters.AddWithValue("@hrs ", othrs.Text)
                        Cmd.Parameters.AddWithValue("@otdate", SelDate)
                        Cmd.Parameters.AddWithValue("@aby", empcode)
                        Cmd.Parameters.AddWithValue("@aon", thisdate)

                        Cmd.ExecuteNonQuery()

                        MyGlobal.Open_Con()
                        MyGlobal.Con_Str()
                        Dim dsss As DataSet
                        dsss = Open_Tempot(Con, DAP, 2, "update Ot_TempTotWeekhrs set whrs = '" & totwkot & "' where recno = '" & lblpass.Text & "'")
                        MyGlobal.db_close()

                    Catch ex As SqlException
                        messagebox(ex.Message)
                        Exit Sub
                    End Try

                Else

                    Try
                        MyGlobal.Open_Con()
                        MyGlobal.Con_Str()
                        Call MyGlobal.dbSp_open("OT_Entry")

                        Cmd.Parameters.AddWithValue("@ecode", empcode)
                        Cmd.Parameters.AddWithValue("@shift", shift)
                        Cmd.Parameters.AddWithValue("@ot", "Y")
                        Cmd.Parameters.AddWithValue("@ottype", ottype)
                        Cmd.Parameters.AddWithValue("@hrs ", othr)
                        Cmd.Parameters.AddWithValue("@remarks", remarks)
                        Cmd.Parameters.AddWithValue("@otdate", SelDate)
                        Cmd.Parameters.AddWithValue("@aby", empcode)
                        Cmd.Parameters.AddWithValue("@aon", thisdate)
                        Cmd.Parameters.AddWithValue("@tot", totwkot)
                        Cmd.Parameters.AddWithValue("@vfd", VarFromDt)
                        Cmd.Parameters.AddWithValue("@vtd", VarToDt)
                        Cmd.ExecuteNonQuery()

                        Dim cmd1 As New SqlCommand
                        Dim dra, dra1 As SqlDataReader
                        Dim da As SqlDataAdapter

                        MyGlobal.Con_Str()
                        Dim con As New SqlConnection(constr)
                        con.Open()
                        cmd1 = New SqlCommand("select Max(recno) as recno from otentry where empcode = '" & empcode & "'", con)
                        dra = cmd1.ExecuteReader()
                        recno = 0
                        While (dra.Read())
                            recno = dra("recno").ToString
                        End While

                        con.Close()
                        cmd1.Dispose()

                        Call MyGlobal.dbSp_open("OT_TOTHrsTemp")

                        Cmd.Parameters.AddWithValue("@ecode", empcode)
                        Cmd.Parameters.AddWithValue("@recno", recno)
                        Cmd.Parameters.AddWithValue("@hrs", totwkot)
                        Cmd.Parameters.AddWithValue("@vfd", VarFromDt)
                        Cmd.Parameters.AddWithValue("@vtd", VarToDt)
                        Cmd.ExecuteNonQuery()

                    Catch ex As SqlException
                        messagebox(ex.Message)
                        Exit Sub
                    End Try
                End If
                totwkot = 0
                Dim dsWOT1 As DataSet
                Dim drWOT1 As DataRow
                Dim MyweekOT1
                dsWOT1 = GetWEEKOt(SelDate, VarFromDt, VarToDt)
                If dsWOT1.Tables(0).Rows.Count <> 0 Then
                    drWOT1 = dsWOT1.Tables(0).Rows(0)
                    If Not drWOT1("totot") Is System.DBNull.Value Then
                        MyweekOT1 = drWOT1("totot")
                    Else
                        MyweekOT1 = 0
                    End If
                    MyGlobal.Open_Con()
                    MyGlobal.Con_Str()
                    Dim dss As DataSet
                    dss = Open_Tempot(Con, DAP, 2, "update Ot_TempTotWeekhrs set whrs = '" & MyweekOT1 & "' where vfd = '" & vfd & "' and vtd = '" & vtd & "' and empcode ='" & empcode & "'")
                    MyGlobal.db_close()
                Else
                    MyweekOT1 = 0
                End If
            End If

        Next

        'Dim mynet As New CRMlognetglobal
        'mynet.db_cn()
        'mynet.dbSMS_open()
        'mynet.InsertSMSLINK(mynet.sConnStringSMS, "MMSB", "OT", recno, "S", empcode, DateTime.Now)

        LblMsg.Text = "Record Inserted"
        lblfrom.Text = fd
        lblto.Text = td
        lblpass.Text = "0"
        vfdt.Text = ""
        vtdt.Text = ""
        othrs.Text = ""

        GridView2.DataBind()
        GridView1.DataBind()

    End Sub
    Function GetOTRec(ByVal seldate As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from otentry where empcode='" & empcode + "' and datecheck ='" & seldate & "' and otentry.status <>'R' and otentry.status <> 'C' and otentry.status <>'A'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "medicalleave")
        con.Close()
        Return ds
    End Function
    Function GetWEEKOt(ByVal seldate As Date, ByVal vfd As Date, ByVal vtd As Date) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select sum(hrs) as totot from otentry where empcode='" & empcode & "' and (otentry.status <>'R' and otentry.status <>'C') and (datecheck between '" & vfd & "' and '" & vtd & "') group by empcode", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "medicalleave")
        con.Close()
        Return ds
    End Function
    Function GetmthOt(ByVal seldate As Date, ByVal vfd As Date, ByVal vtd As Date) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select sum(hrs) as totot from otentry where empcode='" & empcode & "' and (otentry.status <>'R' and otentry.status <>'C') and (datecheck between '" & vfd & "' and '" & vtd & "') group by empcode", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "medicalleave")
        con.Close()
        Return ds
    End Function
    Function Getshift(ByVal passno As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("OT_GetOperByEmp", con)
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.AddWithValue("@EMP", empcode)
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "medicalleave")
        con.Close()
        Return ds
    End Function
    Function GetPRshift(ByVal myday As String, ByVal empcode As String, ByVal seldate As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("GetShiftCode", con)
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.AddWithValue("@sday", myday)
        Command.Parameters.AddWithValue("@emp", empcode)
        Command.Parameters.AddWithValue("@sdate", seldate)

        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "medicalleave")
        con.Close()
        Return ds
    End Function
    Function GetmAXoThRSbYSECT() As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select maxhours,startdate,enddate from tbl_maxotsetting where id = (select max(id) as id from tbl_maxotsetting where sect ='" & SECT & "' and category='staff' and status ='A')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "medicalleave")
        con.Close()
        Return ds
    End Function
    Function GettotPaxInSect() As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("SELECT count(*) as totpax FROM OT_ElligibleStaff INNER JOIN empmaster ON OT_ElligibleStaff.empcode = empmaster.empcode WHERE (OT_ElligibleStaff.Elligible = '-1')and empmaster.resigned='N' and empmaster.sectioncode='" & SECT & "'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "medicalleave")
        con.Close()
        Return ds
    End Function
    Function GetTotmAXoThRSbYSECT(ByVal startdate As Date, ByVal enddate As Date) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("SELECT sum(hrs) as hrs FROM otentry INNER JOIN empmaster ON otentry.empcode = empmaster.empcode WHERE (empmaster.sectioncode = '" & SECT & "') AND (otentry.status <> 'R'  and  otentry.status <> 'C') AND (empmaster.designation <> 'Operator') AND (otentry.datecheck >'" & startdate & "' AND otentry.datecheck < '" & enddate & "')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "medicalleave")
        con.Close()
        Return ds
    End Function
    Function GetWeekOt() As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select tothrs from Ot_WeekMaxHrs", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "medicalleave")
        con.Close()
        Return ds
    End Function
    Function GetLeave(ByVal seldate As Date) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from leaveform where (empno ='" & empcode & "')and (status='APPROVED') and (todate >='" & seldate & "')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "medicalleave")
        con.Close()
        Return ds
    End Function
    Function GetRL(ByVal seldate As Date) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from replacement WHERE  ((fromdate<= '" & seldate & "') and (todate >= '" & seldate & "')) and (empcode ='" & empcode & "')and (status='A')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "medicalleave")
        con.Close()
        Return ds
    End Function
    Public Sub otentryedit(ByVal sender As Object, ByVal e As EventArgs)
        Dim ds As DataSet
        For i As Integer = 0 To GridView1.Rows.Count - 1
            Dim RecNo As String = GridView1.Rows(i).Cells(0).Text
            Dim ottype As String = DirectCast(GridView1.Rows(i).FindControl("ddltype"), DropDownList).SelectedValue
            MyGlobal.Open_Con()
            MyGlobal.Con_Str()
            Try
                ds = Open_approvalOTHod(Con, DAP, 2, "update otentry set ottype = '" & ottype & "', modifiedby = '" & Session("empcode") & "', modifiedon = getdate()  where RecNo = '" & RecNo & "'")
                LblMsg.Text = "Record updated"
            Catch ex As Exception
                LblMsg.Text = ex.Message
            End Try
           MyGlobal.db_close()
        Next
        GridView1.DataBind()

    End Sub
    Public Sub getOTData(ByVal sender As Object, ByVal e As CommandEventArgs)
        appno = e.CommandArgument
        Dim ds As New DataSet
        Dim dr1 As DataRow
        ds = GetOTDetails(appno)
        If ds.Tables(0).Rows.Count <> 0 Then
            dr1 = ds.Tables(0).Rows(0)
            lblpass.Text = dr1("recno").ToString
            vfdt.Text = Format(Convert.ToDateTime(dr1("datecheck")), "dd/MM/yy")
            vtdt.Text = Format(Convert.ToDateTime(dr1("datecheck")), "dd/MM/yy")
            othrs.Text = dr1("hrs").ToString
            lbldbot.Text = dr1("hrs").ToString
        End If
    End Sub
    Function GetOTDetails(ByVal passno As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from otentry where recno = '" & passno & "'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "clinic")
        con.Close()
        Return ds
    End Function
    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'determine the value of the status field
            Dim status As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "status")).Trim
            Dim label As Label = TryCast(e.Row.FindControl("label1"), Label)
            Dim button As LinkButton = TryCast(e.Row.FindControl("LinkButton1"), LinkButton)
            If status = "S" Or status = "s" Then
                button.Visible = True
                label.Visible = False
            Else
                label.Visible = True
                button.Visible = False
            End If

            If status = "s" Or status = "S" Then
                ' color the background of the row yellow
                e.Row.Cells(5).ForeColor = Drawing.Color.Yellow
                '   e.Row.Cells(5).Text = "SCHEDULED"
                ' e.Row.Cells(0).Attributes.Add("class", "statusclass")
            ElseIf status = "A" Or status = "APPROVED" Then
                e.Row.Cells(5).ForeColor = Drawing.Color.Green
                ' e.Row.Cells(5).Text = "APPROVED"
            ElseIf status = "R" Or status = "REJECTED" Then
                e.Row.Cells(5).ForeColor = Drawing.Color.Red
                ' e.Row.Cells(5).Text = "REJECTED"
            End If
        End If
    End Sub

    Protected Sub vfdt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles vfdt.TextChanged
        vtdt.Text = vfdt.Text
    End Sub
End Class