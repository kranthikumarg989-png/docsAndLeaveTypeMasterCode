Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class OTentryCategory
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim thisdate As Date

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (73)
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
        '    Session("empcode") = "014543"
        GridView1.Visible = False
        GridView2.Visible = False
        GridView3.Visible = False
        LblMsg.Text = ""

    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    
    Protected Sub rb1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb1.SelectedIndexChanged

        If rb1.SelectedValue = "Dept" Then
            Deptddl.Enabled = True
            Secddl.Enabled = False
            code.Enabled = False
            depart.Enabled = True
            section.Enabled = False
            ecode.Enabled = False
            emptyp2.Enabled = True
            lbletype.Enabled = True

        ElseIf rb1.SelectedValue = "sect" Then
            Deptddl.Enabled = False
            Secddl.Enabled = True
            code.Enabled = False
            depart.Enabled = False
            section.Enabled = True
            ecode.Enabled = False
            emptyp2.Enabled = True
            lbletype.Enabled = True

        ElseIf rb1.SelectedValue = "ecode" Then
            Deptddl.Enabled = False
            Secddl.Enabled = False
            code.Enabled = True
            depart.Enabled = False
            section.Enabled = False
            ecode.Enabled = True
            emptyp2.Enabled = False
            lbletype.Enabled = False

        End If
        LblMsg.Text = ""


    End Sub
    Protected Sub Show1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Show1.Click

        Dim options = rb1.SelectedValue

        Dim rcount
        Dim fd1 As String
        fd1 = otdate.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)

        Dim SelDate As Date = fd

        Dim thisdate As Date
        thisdate = Format(Convert.ToDateTime(Date.Now), "MM/dd/yy")

        lbldt.Text = fd

        Dim empno = code.Text
        Dim dept = Deptddl.SelectedValue
        Dim sect = Secddl.SelectedValue
        Dim etype = emptyp2.SelectedValue
        If options = "Dept" And etype = "-1" Then
            LblMsg.Text = "Please Select EmpType For the Department!!!!"
            LblMsg.ForeColor = Drawing.Color.Red
            Exit Sub
        ElseIf options = "sect" And etype = "-1" Then
            LblMsg.Text = "Please Select EmpType For the Section!!!!"
            LblMsg.ForeColor = Drawing.Color.Red
            Exit Sub

        End If
        Dim VarDtCount
        Dim VarFromDt
        Dim VarToDt
        Dim vfd
        Dim vtd

        VarDtCount = SelDate.DayOfWeek

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

        vfd = VarFromDt
        vtd = VarToDt

        If options = "Dept" Then
            MyGlobal.Open_Con()
            MyGlobal.Con_Str()
            ''''''''''''''''''''''''''''''''''' Get shift from empmaster and chk staff elligibility
            Dim shift
            Dim dsmc As DataSet
            Dim drmc As DataRow
            Dim empcode, empsect
            Dim z = 0
            dsmc = Getshift(dept, etype)
            If dsmc.Tables(0).Rows.Count <> 0 Then

                rcount = dsmc.Tables(0).Rows.Count
                For z = 0 To rcount - 1
                    drmc = dsmc.Tables(0).Rows(z)
                    If Not drmc("shift") Is System.DBNull.Value Then
                        shift = drmc("shift")
                    Else
                        shift = "NIL"
                    End If
                    empcode = drmc("empcode").ToString
                    empsect = drmc("sectioncode").ToString

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
                    dsleave = GetLeave(SelDate, empcode)
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

                    dsRL = GetRL(SelDate, empcode)
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
                    dsOt = GetOTRec(SelDate, empcode)
                    If dsOt.Tables(0).Rows.Count <> 0 Then
                        drOt = dsOt.Tables(0).Rows(0)
                        shift = drOt("shift")
                        otyn = drOt("OT")
                        ottype = drOt("ottype")
                        othr = drOt("hrs")
                        remarks = drOt("remark")

                    Else
                        otyn = "N"
                        ottype = "-1"
                        othr = ""
                        remarks = ""
                    End If

                    '''''' find out the cur week and max week ot hrs

                    Dim dsWOT As DataSet
                    Dim drWOT As DataRow
                    Dim MyweekOT
                    dsWOT = GetWEEKOt(SelDate, VarFromDt, VarToDt, empcode)
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

                    Try
                        MyGlobal.Open_Con()
                        MyGlobal.Con_Str()
                        Call MyGlobal.dbSp_open("OT_Entry")

                        Cmd.Parameters.AddWithValue("@ecode", empcode)
                        Cmd.Parameters.AddWithValue("@shift", shift)
                        Cmd.Parameters.AddWithValue("@ot", otyn)
                        Cmd.Parameters.AddWithValue("@ottype", ottype)
                        Cmd.Parameters.AddWithValue("@hrs ", othr)
                        Cmd.Parameters.AddWithValue("@remarks", remarks)
                        Cmd.Parameters.AddWithValue("@otdate", SelDate)
                        Cmd.Parameters.AddWithValue("@aby", empcode)
                        Cmd.Parameters.AddWithValue("@aon", thisdate)
                        Cmd.Parameters.AddWithValue("@tot", MyweekOT)
                        Cmd.Parameters.AddWithValue("@vfd", VarFromDt)
                        Cmd.Parameters.AddWithValue("@vtd", VarToDt)
                        Cmd.ExecuteNonQuery()

                        Dim cmd1 As New SqlCommand
                        Dim dra, dra1 As SqlDataReader
                        Dim da As SqlDataAdapter
                        Dim recno
                        MyGlobal.Con_Str()
                        Dim con As New SqlConnection(constr)
                        con.Open()
                        cmd1 = New SqlCommand("select Max(recno) as recno from otentry where empcode = '" & empcode & "'", con)
                        dra = cmd1.ExecuteReader()
                        While (dra.Read())
                            recno = dra("recno").ToString
                        End While

                        con.Close()
                        cmd1.Dispose()

                        Call MyGlobal.dbSp_open("OT_TOTHrsTemp")

                        Cmd.Parameters.AddWithValue("@ecode", empcode)
                        Cmd.Parameters.AddWithValue("@recno", recno)
                        Cmd.Parameters.AddWithValue("@hrs", MyweekOT)
                        Cmd.Parameters.AddWithValue("@vfd", VarFromDt)
                        Cmd.Parameters.AddWithValue("@vtd", VarToDt)
                        Cmd.ExecuteNonQuery()


                    Catch ex As SqlException
                        messagebox(ex.Message)
                        Exit Sub
                    End Try
                Next
            End If
            GridView1.DataBind()
            GridView1.Visible = True

            GridView3.Visible = False
            GridView2.Visible = False

        ElseIf options = "sect" Then
            MyGlobal.Open_Con()
            MyGlobal.Con_Str()
            ''''''''''''''''''''''''''''''''''' Get shift from empmaster and chk staff elligibility
            Dim shift
            Dim dsmc As DataSet
            Dim drmc As DataRow
            Dim empcode, empsect
            Dim z = 0
            dsmc = Getsectemp(sect, etype)
            If dsmc.Tables(0).Rows.Count <> 0 Then

                For z = 0 To dsmc.Tables(0).Rows.Count - 1
                    drmc = dsmc.Tables(0).Rows(z)
                    If Not drmc("shift") Is System.DBNull.Value Then
                        shift = drmc("shift")
                    Else
                        shift = "NIL"
                    End If
                    empcode = drmc("empcode").ToString
                    empsect = drmc("sectioncode").ToString

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
                    dsleave = GetLeave(SelDate, empcode)
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

                    dsRL = GetRL(SelDate, empcode)
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
                    dsOt = GetOTRec(SelDate, empcode)
                    If dsOt.Tables(0).Rows.Count <> 0 Then
                        drOt = dsOt.Tables(0).Rows(0)
                        shift = drOt("shift")
                        otyn = drOt("OT")
                        ottype = drOt("ottype")
                        othr = drOt("hrs")
                        remarks = drOt("remark")

                    Else
                        otyn = "N"
                        ottype = "-1"
                        othr = ""
                        remarks = ""
                    End If

                    '''''' find out the cur week and max week ot hrs

                    Dim dsWOT As DataSet
                    Dim drWOT As DataRow
                    Dim MyweekOT
                    dsWOT = GetWEEKOt(SelDate, VarFromDt, VarToDt, empcode)
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



                    Try
                        MyGlobal.Open_Con()
                        MyGlobal.Con_Str()
                        Call MyGlobal.dbSp_open("OT_Entry")

                        Cmd.Parameters.AddWithValue("@ecode", empcode)
                        Cmd.Parameters.AddWithValue("@shift", shift)
                        Cmd.Parameters.AddWithValue("@ot", otyn)
                        Cmd.Parameters.AddWithValue("@ottype", ottype)
                        Cmd.Parameters.AddWithValue("@hrs ", othr)
                        Cmd.Parameters.AddWithValue("@remarks", remarks)
                        Cmd.Parameters.AddWithValue("@otdate", SelDate)
                        Cmd.Parameters.AddWithValue("@aby", empcode)
                        Cmd.Parameters.AddWithValue("@aon", thisdate)
                        Cmd.Parameters.AddWithValue("@tot", MyweekOT)
                        Cmd.Parameters.AddWithValue("@vfd", VarFromDt)
                        Cmd.Parameters.AddWithValue("@vtd", VarToDt)
                        Cmd.ExecuteNonQuery()

                        Dim cmd1 As New SqlCommand
                        Dim dra, dra1 As SqlDataReader
                        Dim da As SqlDataAdapter
                        Dim recno
                        MyGlobal.Con_Str()
                        Dim con As New SqlConnection(constr)
                        con.Open()
                        cmd1 = New SqlCommand("select Max(recno) as recno from otentry where empcode = '" & empcode & "'", con)
                        dra = cmd1.ExecuteReader()
                        While (dra.Read())
                            recno = dra("recno").ToString
                        End While

                        con.Close()
                        cmd1.Dispose()

                        Call MyGlobal.dbSp_open("OT_TOTHrsTemp")

                        Cmd.Parameters.AddWithValue("@ecode", empcode)
                        Cmd.Parameters.AddWithValue("@recno", recno)
                        Cmd.Parameters.AddWithValue("@hrs", MyweekOT)
                        Cmd.Parameters.AddWithValue("@vfd", VarFromDt)
                        Cmd.Parameters.AddWithValue("@vtd", VarToDt)
                        Cmd.ExecuteNonQuery()


                    Catch ex As SqlException
                        messagebox(ex.Message)
                        Exit Sub
                    End Try
                Next
            End If
            GridView3.Visible = True
            GridView3.DataBind()
            GridView1.Visible = False
            GridView2.Visible = False


        ElseIf options = "ecode" Then

            MyGlobal.Open_Con()
            MyGlobal.Con_Str()
            ''''''''''''''''''''''''''''''''''' Get shift from empmaster and chk staff elligibility
            Dim shift
            Dim dsmc As DataSet
            Dim drmc As DataRow
            Dim empcode, empsect
            Dim z = 0
            dsmc = Getemp(empno)
            If dsmc.Tables(0).Rows.Count <> 0 Then
                drmc = dsmc.Tables(0).Rows(0)

                If Not drmc("shift") Is System.DBNull.Value Then
                    shift = drmc("shift")
                Else
                    shift = "NIL"
                End If
                empcode = drmc("empcode").ToString
                empsect = drmc("sectioncode").ToString

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
                dsleave = GetLeave(SelDate, empcode)
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

                dsRL = GetRL(SelDate, empcode)
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
                dsOt = GetOTRec(SelDate, empcode)
                If dsOt.Tables(0).Rows.Count <> 0 Then
                    drOt = dsOt.Tables(0).Rows(0)
                    shift = drOt("shift")
                    otyn = drOt("OT")
                    ottype = drOt("ottype")
                    othr = drOt("hrs")
                    remarks = drOt("remark")

                Else
                    otyn = "N"
                    ottype = "-1"
                    othr = ""
                    remarks = ""
                End If

                '''''' find out the cur week and max week ot hrs

                Dim dsWOT As DataSet
                Dim drWOT As DataRow
                Dim MyweekOT
                dsWOT = GetWEEKOt(SelDate, VarFromDt, VarToDt, empcode)
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



                Try
                    MyGlobal.Open_Con()
                    MyGlobal.Con_Str()
                    Call MyGlobal.dbSp_open("OT_Entry")

                    Cmd.Parameters.AddWithValue("@ecode", empcode)
                    Cmd.Parameters.AddWithValue("@shift", shift)
                    Cmd.Parameters.AddWithValue("@ot", otyn)
                    Cmd.Parameters.AddWithValue("@ottype", ottype)
                    Cmd.Parameters.AddWithValue("@hrs ", othr)
                    Cmd.Parameters.AddWithValue("@remarks", remarks)
                    Cmd.Parameters.AddWithValue("@otdate", SelDate)
                    Cmd.Parameters.AddWithValue("@aby", empcode)
                    Cmd.Parameters.AddWithValue("@aon", thisdate)
                    Cmd.Parameters.AddWithValue("@tot", MyweekOT)
                    Cmd.Parameters.AddWithValue("@vfd", VarFromDt)
                    Cmd.Parameters.AddWithValue("@vtd", VarToDt)
                    Cmd.ExecuteNonQuery()

                    Dim cmd1 As New SqlCommand
                    Dim dra, dra1 As SqlDataReader
                    Dim da As SqlDataAdapter
                    Dim recno
                    MyGlobal.Con_Str()
                    Dim con As New SqlConnection(constr)
                    con.Open()
                    cmd1 = New SqlCommand("select Max(recno) as recno from otentry where empcode = '" & empcode & "'", con)
                    dra = cmd1.ExecuteReader()
                    While (dra.Read())
                        recno = dra("recno").ToString
                    End While

                    con.Close()
                    cmd1.Dispose()

                    Call MyGlobal.dbSp_open("OT_TOTHrsTemp")

                    Cmd.Parameters.AddWithValue("@ecode", empcode)
                    Cmd.Parameters.AddWithValue("@recno", recno)
                    Cmd.Parameters.AddWithValue("@hrs", MyweekOT)
                    Cmd.Parameters.AddWithValue("@vfd", VarFromDt)
                    Cmd.Parameters.AddWithValue("@vtd", VarToDt)
                    Cmd.ExecuteNonQuery()


                Catch ex As SqlException
                    messagebox(ex.Message)
                    Exit Sub
                End Try

            End If
            GridView2.DataBind()
            GridView2.Visible = True
            GridView1.Visible = False
            GridView3.Visible = False

        End If


    End Sub
    Function GetOTRec(ByVal seldate As String, ByVal empcode As String) As DataSet
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
    Function GetWEEKOt(ByVal seldate As Date, ByVal vfd As Date, ByVal vtd As Date, ByVal emp As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select sum(hrs) as totot from otentry where empcode='" & emp & "' and (otentry.status <>'R' and otentry.status <>'C') and (datecheck between '" & vfd & "' and '" & vtd & "') group by empcode", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "medicalleave")
        con.Close()
        Return ds
    End Function
    Function Getshift(ByVal dpt As String, ByVal etype As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("OT_GetOperByDept", con)
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.AddWithValue("@dept", dpt)
        Command.Parameters.AddWithValue("@operation", etype)
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "medicalleave")
        con.Close()
        Return ds
    End Function
    Function Getsectemp(ByVal dpt As String, ByVal etype As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("OT_GetOperBySect", con)
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.AddWithValue("@sect", dpt)
        Command.Parameters.AddWithValue("@operation", etype)
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "medicalleave")
        con.Close()
        Return ds
    End Function
    Function Getemp(ByVal dpt As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("OT_GetOperByEmp", con)
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.AddWithValue("@emp", dpt)
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
    Function GetmAXoThRSbYSECT(ByVal sect As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select maxhours,startdate,enddate from tbl_maxotsetting where id = (select max(id) as id from tbl_maxotsetting where sect ='" & SECT & "' and category='staff')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "medicalleave")
        con.Close()
        Return ds
    End Function
    Function GetTotmAXoThRSbYSECT(ByVal startdate As Date, ByVal enddate As Date, ByVal sect As String) As DataSet
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
    Function GetLeave(ByVal seldate As Date, ByVal empcode As String) As DataSet
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
    Function GetRL(ByVal seldate As Date, ByVal empcode As String) As DataSet
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
    Public Sub UpdateOtbyDept(ByVal sender As Object, ByVal e As EventArgs)
        Dim ds As DataSet
        For i As Integer = 0 To GridView1.Rows.Count - 1
            Dim RecNo As String = GridView1.Rows(i).Cells(0).Text
            Dim Emp As String = GridView1.Rows(i).Cells(1).Text
            Dim ottype As String = DirectCast(GridView1.Rows(i).FindControl("ddldepttype"), DropDownList).SelectedValue
            Dim shift As String = DirectCast(GridView1.Rows(i).FindControl("ddldeptshift"), DropDownList).SelectedValue
            Dim otyn As Char = DirectCast(GridView1.Rows(i).FindControl("rbdept"), RadioButtonList).SelectedValue
            Dim othrs As Decimal = DirectCast(GridView1.Rows(i).FindControl("txtdepthrs"), TextBox).Text
            Dim remarks As String = DirectCast(GridView1.Rows(i).FindControl("txtdeptremarks"), TextBox).Text
            Dim sect As String = DirectCast(GridView1.Rows(i).FindControl("lbls1"), Label).Text
            Dim totwkot As Decimal = GridView1.Rows(i).Cells(8).Text
            Dim curot As Decimal = GridView1.Rows(i).Cells(9).Text


            ' check OT dint exceed Max hrs and also Section budget

            ''''''''''''''''''''''''''''''' GET MAX OT HRS ALLOTED FOR THAT SECTION

            Dim STARTDATE, ENDDATE
            Dim MAXHRS
            Dim Takenhrs
            Dim dsmc1, dsmh As DataSet
            Dim drmc1, drmh As DataRow
            dsmc1 = GetmAXoThRSbYSECT(sect)
            If dsmc1.Tables(0).Rows.Count <> 0 Then
                drmc1 = dsmc1.Tables(0).Rows(0)
                STARTDATE = Format(Convert.ToDateTime(drmc1("startdate")), "MM/dd/yy")
                ENDDATE = Format(Convert.ToDateTime(drmc1("enddate")), "MM/dd/yy")
                MAXHRS = drmc1("maxhours")
                ''''''''''''''''''''''''''''''' GET MAX OT HRS ALLOTED utilised by THAT SECTION
                dsmh = GetTotmAXoThRSbYSECT(STARTDATE, ENDDATE, sect)
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
            End If
            ''''''''''''''''''''''''''''''' GET MAX OT HRS ALLOTED FOR week

            Dim dsweek As DataSet
            Dim drweek As DataRow
            Dim Maxwkhrs
            dsweek = GetWEEKOt()
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

            totwkot = (totwkot + othrs) - curot


            Dim emp1
            If (Takenhrs > MAXHRS) Or (totwkot > Maxwkhrs) Then
                emp1 = emp1 & "," & Emp
                LblMsg.Text = "OT Limit Exceeded for " & emp1

                Exit Sub
            Else

                MyGlobal.Open_Con()
                MyGlobal.Con_Str()
                Try
                    ds = Open_approvalOTHod(Con, DAP, 2, "update otentry set ottype = '" & ottype & "',shift ='" & shift & "',ot = '" & otyn & "' ,hrs = '" & othrs & "',remark = '" & remarks & "', modifiedby = '" & Session("empcode") & "', modifiedon = getdate()  where RecNo = '" & RecNo & "'")
                    LblMsg.Text = "Record updated"
                Catch ex As Exception
                    LblMsg.Text = ex.Message
                End Try
                MyGlobal.db_close()
            End If

        Next
        GridView1.DataBind()
        GridView1.Visible = True


    End Sub
    Public Sub UpdateOtbySect(ByVal sender As Object, ByVal e As EventArgs)

        Dim ds As DataSet
        For i As Integer = 0 To GridView3.Rows.Count - 1
            Dim RecNo As String = GridView3.Rows(i).Cells(0).Text
            Dim Emp As String = GridView3.Rows(i).Cells(1).Text
            Dim ottype As String = DirectCast(GridView3.Rows(i).FindControl("ddlsecttype"), DropDownList).SelectedValue
            Dim shift As String = DirectCast(GridView3.Rows(i).FindControl("ddlsectshift"), DropDownList).SelectedValue
            Dim otyn As Char = DirectCast(GridView3.Rows(i).FindControl("rbsect"), RadioButtonList).SelectedValue
            Dim othrs As Decimal = DirectCast(GridView3.Rows(i).FindControl("txtsecthrs"), TextBox).Text
            Dim remarks As String = DirectCast(GridView3.Rows(i).FindControl("txtsectremarks"), TextBox).Text
            Dim sect As String = DirectCast(GridView3.Rows(i).FindControl("lbls3"), Label).Text
            Dim totwkot As Decimal = GridView3.Rows(i).Cells(8).Text
            Dim curot As Decimal = GridView3.Rows(i).Cells(9).Text


            ' check OT dint exceed Max hrs and also Section budget

            ''''''''''''''''''''''''''''''' GET MAX OT HRS ALLOTED FOR THAT SECTION

            Dim STARTDATE, ENDDATE
            Dim MAXHRS
            Dim Takenhrs
            Dim dsmc1, dsmh As DataSet
            Dim drmc1, drmh As DataRow
            dsmc1 = GetmAXoThRSbYSECT(sect)
            If dsmc1.Tables(0).Rows.Count <> 0 Then
                drmc1 = dsmc1.Tables(0).Rows(0)
                STARTDATE = Format(Convert.ToDateTime(drmc1("startdate")), "MM/dd/yy")
                ENDDATE = Format(Convert.ToDateTime(drmc1("enddate")), "MM/dd/yy")
                MAXHRS = drmc1("maxhours")
                ''''''''''''''''''''''''''''''' GET MAX OT HRS ALLOTED utilised by THAT SECTION
                dsmh = GetTotmAXoThRSbYSECT(STARTDATE, ENDDATE, sect)
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
            End If
            ''''''''''''''''''''''''''''''' GET MAX OT HRS ALLOTED FOR week

            Dim dsweek As DataSet
            Dim drweek As DataRow
            Dim Maxwkhrs
            dsweek = GetWEEKOt()
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

            totwkot = (totwkot + othrs) - curot


            Dim emp1
            If (Takenhrs > MAXHRS) Or (totwkot > Maxwkhrs) Then
                emp1 = emp1 & "," & Emp
                LblMsg.Text = "OT Limit Exceeded for " & emp1

                Exit Sub
            Else

                MyGlobal.Open_Con()
                MyGlobal.Con_Str()
                Try
                    ds = Open_approvalOTHod(Con, DAP, 2, "update otentry set ottype = '" & ottype & "',shift ='" & shift & "',ot = '" & otyn & "' ,hrs = '" & othrs & "',remark = '" & remarks & "', modifiedby = '" & Session("empcode") & "', modifiedon = getdate()  where RecNo = '" & RecNo & "'")
                    LblMsg.Text = "Record updated"
                Catch ex As Exception
                    LblMsg.Text = ex.Message
                End Try
                MyGlobal.db_close()
            End If

        Next
        GridView3.DataBind()
        GridView3.Visible = True


    End Sub
    Public Sub UpdateOtbyEmp(ByVal sender As Object, ByVal e As EventArgs)
        Dim ds As DataSet
        For i As Integer = 0 To GridView2.Rows.Count - 1
            Dim RecNo As String = GridView2.Rows(i).Cells(0).Text
            Dim Emp As String = GridView2.Rows(i).Cells(1).Text
            Dim ottype As String = DirectCast(GridView2.Rows(i).FindControl("ddlemptype"), DropDownList).SelectedValue
            Dim shift As String = DirectCast(GridView2.Rows(i).FindControl("ddlempshift"), DropDownList).SelectedValue
            Dim otyn As Char = DirectCast(GridView2.Rows(i).FindControl("rbemp"), RadioButtonList).SelectedValue
            Dim othrs As Decimal = DirectCast(GridView2.Rows(i).FindControl("txtemphrs"), TextBox).Text
            Dim remarks As String = DirectCast(GridView2.Rows(i).FindControl("txtempremarks"), TextBox).Text
            Dim sect As String = DirectCast(GridView2.Rows(i).FindControl("lbls2"), Label).Text
            Dim totwkot As Decimal = GridView2.Rows(i).Cells(8).Text
            Dim curot As Decimal = GridView2.Rows(i).Cells(9).Text


            ' check OT dint exceed Max hrs and also Section budget

            ''''''''''''''''''''''''''''''' GET MAX OT HRS ALLOTED FOR THAT SECTION

            Dim STARTDATE, ENDDATE
            Dim MAXHRS
            Dim Takenhrs
            Dim dsmc1, dsmh As DataSet
            Dim drmc1, drmh As DataRow
            dsmc1 = GetmAXoThRSbYSECT(sect)
            If dsmc1.Tables(0).Rows.Count <> 0 Then
                drmc1 = dsmc1.Tables(0).Rows(0)
                STARTDATE = Format(Convert.ToDateTime(drmc1("startdate")), "MM/dd/yy")
                ENDDATE = Format(Convert.ToDateTime(drmc1("enddate")), "MM/dd/yy")
                MAXHRS = drmc1("maxhours")
                ''''''''''''''''''''''''''''''' GET MAX OT HRS ALLOTED utilised by THAT SECTION
                dsmh = GetTotmAXoThRSbYSECT(STARTDATE, ENDDATE, sect)
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
            End If
            ''''''''''''''''''''''''''''''' GET MAX OT HRS ALLOTED FOR week

            Dim dsweek As DataSet
            Dim drweek As DataRow
            Dim Maxwkhrs
            dsweek = GetWEEKOt()
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

            totwkot = (totwkot + othrs) - curot


            Dim emp1
            If (Takenhrs > MAXHRS) Or (totwkot > Maxwkhrs) Then
                emp1 = emp1 & "," & Emp
                LblMsg.Text = "OT Limit Exceeded for " & emp1

                Exit Sub
            Else

                MyGlobal.Open_Con()
                MyGlobal.Con_Str()
                Try
                    ds = Open_approvalOTHod(Con, DAP, 2, "update otentry set ottype = '" & ottype & "',shift ='" & shift & "',ot = '" & otyn & "' ,hrs = '" & othrs & "',remark = '" & remarks & "', modifiedby = '" & Session("empcode") & "', modifiedon = getdate()  where RecNo = '" & RecNo & "'")
                    LblMsg.Text = "Record updated"
                Catch ex As Exception
                    LblMsg.Text = ex.Message
                End Try
                MyGlobal.db_close()
            End If

        Next
        GridView2.DataBind()
        GridView2.Visible = True

    End Sub

    Private Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(9).Visible = False

        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
           
            e.Row.Cells(9).Visible = False
        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(9).Visible = False
           

        End If
    End Sub
 
    Private Sub GridView2_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowCreated
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(9).Visible = False

        End If
        If e.Row.RowType = DataControlRowType.DataRow Then

            e.Row.Cells(9).Visible = False
        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(9).Visible = False


        End If
    End Sub
    Private Sub GridView3_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView3.RowCreated
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(9).Visible = False

        End If
        If e.Row.RowType = DataControlRowType.DataRow Then

            e.Row.Cells(9).Visible = False
        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(9).Visible = False


        End If
    End Sub

End Class