Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class DailyUpdateKPI
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim rno
    Dim mon
    Dim yr
    Dim i, j, k, l
    Dim mytot

    Private Sub DailyUpdateKPI_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (278)
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
        getDetails()
        loadDDL()
    End Sub
    Protected Sub getDetails()

        GetEmpVehino(Session("empcode"))
        If recstatus = True Then
            Dim dr1 As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr1 = dsdata.Tables(0).Rows(0)
                lblename.Text = dr1("empname").ToString
                lblsect.Text = dr1("sectioncode").ToString + "-" + dr1("sectionname").ToString
                lbldept.Text = dr1("departmentcode").ToString + "-" + dr1("departmentname").ToString
                lbldesig.Text = dr1("designation").ToString
                lblempcode.Text = Session("empcode")
            Else
                MessageBox("EmployeeCode doesnot Exist!!")
                Exit Sub
            End If
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        MyApp.GetfiscalYear()
        yr = _fisyrStart.Year
        lblyr.Text = yr

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (78)
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

        mon = ddlmonth.SelectedValue.Trim
        lblmon.Text = mon
        If mon = "3" Then
            lblyr.Text = yr - 1
        End If

        'If mon = "1" Or mon = "2" Or mon = "3" Then
        '    yr = Date.Now.Year
        '    yr = yr - 1
        '    lblyr.Text = yr
        '    lblmon.Text = mon
        'Else
        '    yr = Date.Now.Year
        '    lblyr.Text = yr
        '    lblmon.Text = mon
        'End If

    End Sub
    Private Sub loadDDL()
        Dim curmth = Date.Now.Month
        Dim prevmth = Date.Now.AddMonths(-1).Month

        'If curmth = "1" Then
        '    curmth = "01"
        'ElseIf curmth = "2" Then
        '    curmth = "02"
        'ElseIf curmth = "3" Then
        '    curmth = "03"
        'ElseIf curmth = "4" Then
        '    curmth = "04"
        'ElseIf curmth = "5" Then
        '    curmth = "05"
        'ElseIf curmth = "6" Then
        '    curmth = "06"
        'ElseIf curmth = "7" Then
        '    curmth = "07"
        'ElseIf curmth = "8" Then
        '    curmth = "08"
        'ElseIf curmth = "9" Then
        '    curmth = "09"
        'End If

        'If prevmth = "1" Then
        '    prevmth = "01"
        'ElseIf prevmth = "2" Then
        '    prevmth = "02"
        'ElseIf prevmth = "3" Then
        '    prevmth = "03"
        'ElseIf prevmth = "4" Then
        '    prevmth = "04"
        'ElseIf prevmth = "5" Then
        '    prevmth = "05"
        'ElseIf prevmth = "6" Then
        '    prevmth = "06"
        'ElseIf prevmth = "7" Then
        '    prevmth = "07"
        'ElseIf prevmth = "8" Then
        '    prevmth = "08"
        'ElseIf prevmth = "9" Then
        '    prevmth = "09"
        'End If

        ddlmonth.Items.Add(curmth)
        ddlmonth.Items.Add(prevmth)
        ddlmonth.DataBind()


    End Sub
    Private Sub LoadGrid()
        mon = ddlmonth.SelectedValue.Trim

        If mon = "3" Then
            yr = Date.Now.Year
            yr = yr - 1
        End If

        Dim dsrev As DataSet
        Dim drrev As DataRow
        Dim priority

        dsrev = GetRevno()

        If dsrev.Tables(0).Rows.Count > 0 Then
            drrev = dsrev.Tables(0).Rows(0)
            lblrev.Text = drrev("rev").ToString
        End If

        '''' find if the employee is HOD

        Dim dshod As DataSet
        Dim drhod As DataRow
        Dim lvl
        dshod = Getdlevel()
        If dshod.Tables(0).Rows.Count > 0 Then
            drhod = dshod.Tables(0).Rows(0)
            lvl = drhod("dlevel").ToString
        End If

        If lvl >= 4 Then
            priority = "1"
        Else
            priority = "0"
        End If

        '''''' get KPI records for HOD


        Dim dskpi As DataSet
        Dim drkpi As DataRow
        Dim mjr, subkpi
        Dim mjrno, subno
        Dim q1, q2, q3, q4
        Dim cur, tar, weight
        Dim uom
        Dim indi

        Dim A, B, C, D As Boolean


        dskpi = GetKPIRecords()
        If dskpi.Tables(0).Rows.Count > 0 Then
            For i = 0 To dskpi.Tables(0).Rows.Count - 1
                drkpi = dskpi.Tables(0).Rows(i)

                Try
                    MyGlobal.Open_Con()
                    MyGlobal.Con_Str()
                    Call MyGlobal.dbSp_open("hrmis_kpi_daily_update_new")

                    Cmd.Parameters.AddWithValue("@Major_KPINO", drkpi("Major_KPINO").ToString)
                    Cmd.Parameters.AddWithValue("@MajorKPI_Details", drkpi("Majorkpi_details").ToString)
                    Cmd.Parameters.AddWithValue("@SubKPI_Details", drkpi("subKPI_details").ToString)
                    Cmd.Parameters.AddWithValue("@Sub_KPINO", drkpi("sub_KPIno").ToString)
                    Cmd.Parameters.AddWithValue("@Subweightage", drkpi("subweightage").ToString)

                    Cmd.Parameters.AddWithValue("@q1", drkpi("q1").ToString)
                    Cmd.Parameters.AddWithValue("@q2", drkpi("q2").ToString)
                    Cmd.Parameters.AddWithValue("@q3", drkpi("q3").ToString)
                    Cmd.Parameters.AddWithValue("@q4", drkpi("q4").ToString)

                    Cmd.Parameters.AddWithValue("@uom", drkpi("uom").ToString)
                    Cmd.Parameters.AddWithValue("@curent", drkpi("curent").ToString)
                    Cmd.Parameters.AddWithValue("@target", drkpi("target").ToString)
                    Cmd.Parameters.AddWithValue("@individual", drkpi("individual").ToString)

                    Cmd.Parameters.AddWithValue("@Employee_Code", Session("empcode"))
                    Cmd.Parameters.AddWithValue("@Department_Code", Session("_edept"))

                    Dim d1 As String
                    Dim d2 As String
                    Dim d3 As String
                    Dim d4 As String
                    Dim d5 As String
                    Dim d6 As String
                    Dim d7 As String
                    Dim d8 As String
                    Dim d9 As String
                    Dim d10 As String
                    Dim d11 As String
                    Dim d12 As String
                    Dim d13 As String
                    Dim d14 As String
                    Dim d15 As String
                    Dim d16 As String
                    Dim d17 As String
                    Dim d18 As String
                    Dim d19 As String
                    Dim d20 As String
                    Dim d21 As String
                    Dim d22 As String
                    Dim d23 As String
                    Dim d24 As String
                    Dim d25 As String
                    Dim d26 As String
                    Dim d27 As String
                    Dim d28 As String
                    Dim d29 As String
                    Dim d30 As String
                    Dim d31 As String


                    If Not drkpi("day1") Is System.DBNull.Value Then
                        d1 = drkpi("day1").ToString
                    Else
                        d1 = ""
                    End If
                    If Not drkpi("day2") Is System.DBNull.Value Then
                        d2 = drkpi("day2").ToString
                    Else
                        d2 = ""
                    End If
                    If Not drkpi("day3") Is System.DBNull.Value Then
                        d3 = drkpi("day3").ToString
                    Else
                        d3 = ""
                    End If
                    If Not drkpi("day4") Is System.DBNull.Value Then
                        d4 = drkpi("day4").ToString
                    Else
                        d4 = ""
                    End If
                    If Not drkpi("day5") Is System.DBNull.Value Then
                        d5 = drkpi("day5").ToString
                    Else
                        d5 = ""
                    End If
                    If Not drkpi("day6") Is System.DBNull.Value Then
                        d6 = drkpi("day6").ToString
                    Else
                        d6 = ""
                    End If
                    If Not drkpi("day7") Is System.DBNull.Value Then
                        d7 = drkpi("day7").ToString
                    Else
                        d7 = ""
                    End If
                    If Not drkpi("day8") Is System.DBNull.Value Then
                        d8 = drkpi("day8").ToString
                    Else
                        d8 = ""
                    End If
                    If Not drkpi("day9") Is System.DBNull.Value Then
                        d9 = drkpi("day9").ToString
                    Else
                        d9 = ""
                    End If
                    If Not drkpi("day10") Is System.DBNull.Value Then
                        d10 = drkpi("day10").ToString
                    Else
                        d10 = ""
                    End If

                    If Not drkpi("day11") Is System.DBNull.Value Then
                        d11 = drkpi("day11").ToString
                    Else
                        d11 = ""
                    End If
                    If Not drkpi("day12") Is System.DBNull.Value Then
                        d12 = drkpi("day12").ToString
                    Else
                        d12 = ""
                    End If
                    If Not drkpi("day13") Is System.DBNull.Value Then
                        d13 = drkpi("day13").ToString
                    Else
                        d13 = ""
                    End If
                    If Not drkpi("day14") Is System.DBNull.Value Then
                        d14 = drkpi("day14").ToString
                    Else
                        d14 = ""
                    End If
                    If Not drkpi("day15") Is System.DBNull.Value Then
                        d15 = drkpi("day15").ToString
                    Else
                        d15 = ""
                    End If
                    If Not drkpi("day16") Is System.DBNull.Value Then
                        d16 = drkpi("day16").ToString
                    Else
                        d16 = ""
                    End If
                    If Not drkpi("day17") Is System.DBNull.Value Then
                        d17 = drkpi("day17").ToString
                    Else
                        d17 = ""
                    End If
                    If Not drkpi("day18") Is System.DBNull.Value Then
                        d18 = drkpi("day18").ToString
                    Else
                        d18 = ""
                    End If
                    If Not drkpi("day19") Is System.DBNull.Value Then
                        d19 = drkpi("day19").ToString
                    Else
                        d19 = ""
                    End If
                    If Not drkpi("day20") Is System.DBNull.Value Then
                        d20 = drkpi("day20").ToString
                    Else
                        d20 = ""
                    End If


                    If Not drkpi("day21") Is System.DBNull.Value Then
                        d21 = drkpi("day21").ToString
                    Else
                        d21 = ""
                    End If
                    If Not drkpi("day22") Is System.DBNull.Value Then
                        d22 = drkpi("day22").ToString
                    Else
                        d22 = ""
                    End If
                    If Not drkpi("day23") Is System.DBNull.Value Then
                        d23 = drkpi("day23").ToString
                    Else
                        d23 = ""
                    End If
                    If Not drkpi("day24") Is System.DBNull.Value Then
                        d24 = drkpi("day24").ToString
                    Else
                        d24 = ""
                    End If
                    If Not drkpi("day25") Is System.DBNull.Value Then
                        d25 = drkpi("day25").ToString
                    Else
                        d25 = ""
                    End If
                    If Not drkpi("day26") Is System.DBNull.Value Then
                        d26 = drkpi("day26").ToString
                    Else
                        d26 = ""
                    End If
                    If Not drkpi("day27") Is System.DBNull.Value Then
                        d27 = drkpi("day27").ToString
                    Else
                        d27 = ""
                    End If
                    If Not drkpi("day28") Is System.DBNull.Value Then
                        d28 = drkpi("day28").ToString
                    Else
                        d28 = ""
                    End If
                    If Not drkpi("day29") Is System.DBNull.Value Then
                        d29 = drkpi("day29").ToString
                    Else
                        d29 = ""
                    End If
                    If Not drkpi("day30") Is System.DBNull.Value Then
                        d30 = drkpi("day30").ToString
                    Else
                        d30 = ""
                    End If
                    If Not drkpi("day31") Is System.DBNull.Value Then
                        d31 = drkpi("day31").ToString
                    Else
                        d31 = ""
                    End If




                    Cmd.Parameters.AddWithValue("@day1", d1)
                    Cmd.Parameters.AddWithValue("@day2", d2)
                    Cmd.Parameters.AddWithValue("@day3", d3)
                    Cmd.Parameters.AddWithValue("@day4", d4)
                    Cmd.Parameters.AddWithValue("@day5", d5)
                    Cmd.Parameters.AddWithValue("@day6", d6)
                    Cmd.Parameters.AddWithValue("@day7", d7)
                    Cmd.Parameters.AddWithValue("@day8", d8)
                    Cmd.Parameters.AddWithValue("@day9", d9)
                    Cmd.Parameters.AddWithValue("@day10", d10)
                    Cmd.Parameters.AddWithValue("@day11", d11)
                    Cmd.Parameters.AddWithValue("@day12", d12)
                    Cmd.Parameters.AddWithValue("@day13", d13)
                    Cmd.Parameters.AddWithValue("@day14", d14)
                    Cmd.Parameters.AddWithValue("@day15", d15)
                    Cmd.Parameters.AddWithValue("@day16", d16)
                    Cmd.Parameters.AddWithValue("@day17", d17)
                    Cmd.Parameters.AddWithValue("@day18", d18)
                    Cmd.Parameters.AddWithValue("@day19", d19)
                    Cmd.Parameters.AddWithValue("@day20", d20)
                    Cmd.Parameters.AddWithValue("@day21", d21)
                    Cmd.Parameters.AddWithValue("@day22", d22)
                    Cmd.Parameters.AddWithValue("@day23", d23)
                    Cmd.Parameters.AddWithValue("@day24", d24)
                    Cmd.Parameters.AddWithValue("@day25", d25)
                    Cmd.Parameters.AddWithValue("@day26", d26)
                    Cmd.Parameters.AddWithValue("@day27", d27)
                    Cmd.Parameters.AddWithValue("@day28", d28)
                    Cmd.Parameters.AddWithValue("@day29", d29)
                    Cmd.Parameters.AddWithValue("@day30", d30)
                    Cmd.Parameters.AddWithValue("@day31", d31)

                    Cmd.Parameters.AddWithValue("@KPI_Year", drkpi("kpi_year"))
                    Cmd.Parameters.AddWithValue("@mn", mon)
                    Cmd.Parameters.AddWithValue("@revision", lblrev.Text)

                    Cmd.Parameters.AddWithValue("@prio", priority)
                    Cmd.Parameters.AddWithValue("@chk", drkpi("checked"))
                    Cmd.Parameters.AddWithValue("@rpt", drkpi("repeat"))
                    Cmd.Parameters.AddWithValue("@rno", drkpi("slno"))

                    Cmd.ExecuteNonQuery()

                Catch ex As SqlException
                    MessageBox(ex.Message)
                End Try
            Next
        End If


        GridView1.DataBind()
        GridView2.DataBind()
        GridView3.DataBind()

    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)


    End Sub
    Function GetRevno() As DataSet
        Dim qtr

        mon = ddlmonth.SelectedValue.Trim
        lblmon.Text = mon

        'If mon = "3" Then
        '    yr = Date.Now.Year
        '    yr = yr - 1
        'End If

        'If Not IsPostBack Then

        If mon = "4" Or mon = "5" Or mon = "6" Then
            qtr = "q1"
        ElseIf mon = "7" Or mon = "8" Or mon = "9" Then
            qtr = "Q2"
        ElseIf mon = "10" Or mon = "11" Or mon = "12" Then
            qtr = "q3"
        ElseIf mon = "1" Or mon = "2" Or mon = "3" Then
            qtr = "Q4"
        End If
        'End If


        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select isnull(max(revision),0) as rev from KPI_IndividualSetting where employee_code='" & Session("empcode") & "' and quarter='" & qtr & "' and kpi_year='" & yr & "' and checked='-1'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "KPIMajor")
        con.Close()
        Return ds
    End Function

    Function Getdlevel() As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select dlevel from designation where designationname=(select designation from empmaster where empcode='" & Session("empcode") & "')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "KPIlvl")
        con.Close()
        Return ds
    End Function
    Function GettotGrade() As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("SELECT * FROM kpi_grade_result WHERE empcode = '" & Session("empcode") & "' and yr = '" & lblyr.Text & "' and  mnth = '" & ddlmonth.SelectedValue.Trim & "'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "KPIlvl")
        con.Close()
        Return ds
    End Function
    Function GetKPIRecords() As DataSet
        Dim qtr

        mon = ddlmonth.SelectedValue.Trim
        lblmon.Text = mon
        If mon = "3" Then
            yr = Date.Now.Year
            yr = yr - 1
        End If

        ' If Not IsPostBack Then

        If mon = "4" Or mon = "5" Or mon = "6" Then
            qtr = "Q1"
        ElseIf mon = "7" Or mon = "8" Or mon = "9" Then
            qtr = "Q2"
        ElseIf mon = "10" Or mon = "11" Or mon = "12" Then
            qtr = "Q3"
        ElseIf mon = "1" Or mon = "2" Or mon = "3" Then
            qtr = "Q4"
        End If

        ' End If
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("HRMIs_KPI_GETRecordeForDailyupdate", con)
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.AddWithValue("@emp", Session("empcode"))
        Command.Parameters.AddWithValue("@yr", yr)
        Command.Parameters.AddWithValue("@qtr", qtr)
        Command.Parameters.AddWithValue("@dept", Session("_edept"))


        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "KPIRec")
        con.Close()
        Return ds

    End Function

    Protected Sub calculateTotal(ByVal Sender As Object, ByVal e As System.EventArgs)

        Dim TXTweight As TextBox

        Dim weight As Double
        Dim total As Double
        Dim txtVal As Double
        Dim actual As TextBox
        Dim current, targetval, actualval As Double
        Dim target As Label
        Dim rno
        Dim j
        Dim t, r, a

        Dim totDaysOfKPIMonth
        totDaysOfKPIMonth = Date.DaysInMonth(Now.Year, mon)

        For i As Integer = 0 To GridView1.Rows.Count - 1
            'weight = DirectCast(GridView1.Rows(i).FindControl("pweight"), TextBox)
            rno = GridView1.Rows(i).Cells(0).Text
            weight = GridView1.Rows(i).Cells(5).Text
            current = GridView1.Rows(i).Cells(3).Text
            ' target = DirectCast(GridView1.Rows(i).FindControl(t), Label)
            Dim rowtot = 0
            Dim result = 0
            For j = 1 To 31
                t = "t" & j
                r = "r" & j
                a = "a" & j


                actual = DirectCast(GridView1.Rows(i).FindControl(a), TextBox)
                target = DirectCast(GridView1.Rows(i).FindControl(t), Label)

                If actual.Text <> "" Then
                    actualval = Double.Parse(actual.Text.Trim)
                    If target.Text <> "" Then
                        targetval = Double.Parse(target.Text.Trim)
                        ''forward calculation
                        If targetval > current Then
                            If actualval >= targetval Then
                                result = weight
                            ElseIf actualval <= current Then
                                result = "0"
                            Else
                                result = ((actualval - current) / (targetval - current)) * weight
                            End If
                            ''Reverse calculation
                        ElseIf current > targetval Then
                            If actualval <= targetval Then
                                result = weight
                            ElseIf actualval >= current Then
                                result = "0"
                            Else
                                result = ((current - actualval) / (current - targetval)) * weight
                            End If
                            ''
                        ElseIf current = targetval Then
                            If actualval >= targetval Then
                                result = weight
                            ElseIf actualval < targetval Then
                                result = "0"
                            End If

                        End If
                        result = Math.Round(Double.Parse(result), 2)
                        DirectCast(GridView1.Rows(i).FindControl(r), Label).Text = result
                        '  rowtot = rowtot + result
                        mytot = result + mytot
                    End If
                End If

            Next
            rowtot = Math.Round(rowtot / totDaysOfKPIMonth)
            DirectCast(GridView1.Rows(i).FindControl("finaltotal"), Label).Text = rowtot
        Next

        Dim DAYRES
        DAYRES = Math.Round(mytot / totDaysOfKPIMonth)
        Label1.Text = DAYRES
        DirectCast(GridView1.FooterRow.FindControl("fintotalavg"), Label).Text = DAYRES

        lbltotal.Text = Math.Round(Double.Parse(Label1.Text) + Double.Parse(Label2.Text) + Double.Parse(Label3.Text), 1)
        getgrade(lbltotal.Text)

        Panel1.Visible = True
        Panel2.Visible = True
        Panel3.Visible = True
        btnsave.Visible = True
    End Sub
    Protected Sub calculateTotal2(ByVal Sender As Object, ByVal e As System.EventArgs)
        'Dim weight As TextBox
        Dim weight As Double
        Dim total As Double
        Dim txtVal As Double
        Dim actual As TextBox
        Dim current, targetval, actualval As Double
        Dim target As Label
        Dim rno
        Dim j
        Dim t, r, a

        Label2.Text = "0"
        For i As Integer = 0 To GridView2.Rows.Count - 1
            Dim rowtot = 0
            Dim result = 0

            'weight = DirectCast(GridView1.Rows(i).FindControl("pweight"), TextBox)
            rno = GridView2.Rows(i).Cells(0).Text
            weight = GridView2.Rows(i).Cells(5).Text
            current = GridView2.Rows(i).Cells(3).Text

            For j = 1 To 4
                t = "t" & j
                r = "r" & j
                a = "a" & j

                target = DirectCast(GridView2.Rows(i).FindControl(t), Label)
                actual = DirectCast(GridView2.Rows(i).FindControl(a), TextBox)

                If actual.Text <> "" Then
                    actualval = Double.Parse(actual.Text.Trim)
                    If target.Text <> "" Then
                        targetval = Double.Parse(target.Text.Trim)
                        ''forward calculation
                        If targetval > current Then
                            If actualval >= targetval Then
                                result = weight
                            ElseIf actualval <= current Then
                                result = "0"
                            Else
                                result = ((actualval - current) / (targetval - current)) * weight
                            End If
                            ''Reverse calculation
                        ElseIf current > targetval Then
                            If actualval <= targetval Then
                                result = weight
                            ElseIf actualval >= current Then
                                result = "0"
                            Else
                                result = ((current - actualval) / (current - targetval)) * weight
                            End If
                            ''
                        ElseIf current = targetval Then
                            If actualval >= targetval Then
                                result = weight
                            ElseIf actualval < targetval Then
                                result = "0"
                            End If
                        End If
                        result = Math.Round(Double.Parse(result), 2)
                        DirectCast(GridView2.Rows(i).FindControl(r), Label).Text = result
                        mytot = result + mytot
                        rowtot = rowtot + result
                    End If
                End If
            Next
            rowtot = Math.Round(rowtot / 4)
            DirectCast(GridView2.Rows(i).FindControl("finaltotal1"), Label).Text = rowtot
        Next
        Dim weekres
        weekres = mytot / 4

        Label2.Text = weekres
        DirectCast(GridView2.FooterRow.FindControl("fintotalavg1"), Label).Text = weekres

        lbltotal.Text = Math.Round(Double.Parse(Label1.Text) + Double.Parse(Label2.Text) + Double.Parse(Label3.Text), 1)
        getgrade(lbltotal.Text)

        Panel1.Visible = True
        Panel2.Visible = True
        Panel3.Visible = True
        btnsave.Visible = True
    End Sub
    Protected Sub calculateTotal3(ByVal Sender As Object, ByVal e As System.EventArgs)
        'Dim weight As TextBox
        Dim weight As Double
        Dim total As Double
        Dim txtVal As Double
        Dim actual As TextBox
        Dim current, targetval, actualval, result As Double
        Dim target As Label
        Dim rno
        Dim j
        Dim t, r, a

        Label3.Text = "0"
        For i As Integer = 0 To GridView3.Rows.Count - 1
            Dim rowtot = "0"
            'weight = DirectCast(GridView1.Rows(i).FindControl("pweight"), TextBox)
            rno = GridView3.Rows(i).Cells(0).Text
            weight = GridView3.Rows(i).Cells(5).Text
            current = GridView3.Rows(i).Cells(3).Text



            target = DirectCast(GridView3.Rows(i).FindControl("t1"), Label)
            actual = DirectCast(GridView3.Rows(i).FindControl("a1"), TextBox)

            If actual.Text <> "" Then
                actualval = Double.Parse(actual.Text.Trim)
                If target.Text <> "" Then
                    targetval = Double.Parse(target.Text.Trim)
                    ''forward calculation
                    If targetval > current Then
                        If actualval >= targetval Then
                            result = weight
                        ElseIf actualval <= current Then
                            result = "0"
                        Else
                            result = ((actualval - current) / (targetval - current)) * weight
                        End If
                        ''Reverse calculation
                    ElseIf current > targetval Then
                        If actualval <= targetval Then
                            result = weight
                        ElseIf actualval >= current Then
                            result = "0"
                        Else
                            result = ((current - actualval) / (current - targetval)) * weight
                        End If

                    ElseIf current = targetval Then
                        If actualval >= targetval Then
                            result = weight
                        ElseIf actualval < targetval Then
                            result = "0"
                        End If
                    End If

                    result = Math.Round(Double.Parse(result), 2)
                    DirectCast(GridView3.Rows(i).FindControl("r1"), Label).Text = result
                    mytot = mytot + result

                    DirectCast(GridView3.Rows(i).FindControl("finaltotal2"), Label).Text = result
                End If
            End If
        Next


        Label3.Text = mytot
        DirectCast(GridView3.FooterRow.FindControl("fintotalavg2"), Label).Text = mytot

        lbltotal.Text = Math.Round(Double.Parse(Label1.Text) + Double.Parse(Label2.Text) + Double.Parse(Label3.Text), 1)
        getgrade(lbltotal.Text)
        Panel1.Visible = True
        Panel2.Visible = True
        Panel3.Visible = True
        btnsave.Visible = True
    End Sub

    Protected Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Dim ds As DataSet
        Dim daily, weekly, monthly As Decimal
        Dim totDaysOfKPIMonth
        Dim total
        totDaysOfKPIMonth = Date.DaysInMonth(Now.Year, mon)
        Dim val
        For i As Integer = 0 To GridView1.Rows.Count - 1
            Dim sno As String = GridView1.Rows(i).Cells(0).Text




            Dim d1 As String = DirectCast(GridView1.Rows(i).FindControl("r1"), Label).Text
            Dim d2 As String = DirectCast(GridView1.Rows(i).FindControl("r2"), Label).Text
            Dim d3 As String = DirectCast(GridView1.Rows(i).FindControl("r3"), Label).Text
            Dim d4 As String = DirectCast(GridView1.Rows(i).FindControl("r4"), Label).Text
            Dim d5 As String = DirectCast(GridView1.Rows(i).FindControl("r5"), Label).Text
            Dim d6 As String = DirectCast(GridView1.Rows(i).FindControl("r6"), Label).Text
            Dim d7 As String = DirectCast(GridView1.Rows(i).FindControl("r7"), Label).Text
            Dim d8 As String = DirectCast(GridView1.Rows(i).FindControl("r8"), Label).Text
            Dim d9 As String = DirectCast(GridView1.Rows(i).FindControl("r9"), Label).Text
            Dim d10 As String = DirectCast(GridView1.Rows(i).FindControl("r10"), Label).Text
            Dim d11 As String = DirectCast(GridView1.Rows(i).FindControl("r11"), Label).Text
            Dim d12 As String = DirectCast(GridView1.Rows(i).FindControl("r12"), Label).Text
            Dim d13 As String = DirectCast(GridView1.Rows(i).FindControl("r13"), Label).Text
            Dim d14 As String = DirectCast(GridView1.Rows(i).FindControl("r14"), Label).Text
            Dim d15 As String = DirectCast(GridView1.Rows(i).FindControl("r15"), Label).Text
            Dim d16 As String = DirectCast(GridView1.Rows(i).FindControl("r16"), Label).Text
            Dim d17 As String = DirectCast(GridView1.Rows(i).FindControl("r17"), Label).Text
            Dim d18 As String = DirectCast(GridView1.Rows(i).FindControl("r18"), Label).Text
            Dim d19 As String = DirectCast(GridView1.Rows(i).FindControl("r19"), Label).Text
            Dim d20 As String = DirectCast(GridView1.Rows(i).FindControl("r20"), Label).Text
            Dim d21 As String = DirectCast(GridView1.Rows(i).FindControl("r21"), Label).Text
            Dim d22 As String = DirectCast(GridView1.Rows(i).FindControl("r22"), Label).Text
            Dim d23 As String = DirectCast(GridView1.Rows(i).FindControl("r23"), Label).Text
            Dim d24 As String = DirectCast(GridView1.Rows(i).FindControl("r24"), Label).Text
            Dim d25 As String = DirectCast(GridView1.Rows(i).FindControl("r25"), Label).Text
            Dim d26 As String = DirectCast(GridView1.Rows(i).FindControl("r26"), Label).Text
            Dim d27 As String = DirectCast(GridView1.Rows(i).FindControl("r27"), Label).Text
            Dim d28 As String = DirectCast(GridView1.Rows(i).FindControl("r28"), Label).Text
            Dim d29 As String = DirectCast(GridView1.Rows(i).FindControl("r29"), Label).Text
            Dim d30 As String = DirectCast(GridView1.Rows(i).FindControl("r30"), Label).Text
            Dim d31 As String = DirectCast(GridView1.Rows(i).FindControl("r31"), Label).Text

            Dim a1 As String = DirectCast(GridView1.Rows(i).FindControl("a1"), TextBox).Text
            Dim a2 As String = DirectCast(GridView1.Rows(i).FindControl("a2"), TextBox).Text
            Dim a3 As String = DirectCast(GridView1.Rows(i).FindControl("a3"), TextBox).Text
            Dim a4 As String = DirectCast(GridView1.Rows(i).FindControl("a4"), TextBox).Text
            Dim a5 As String = DirectCast(GridView1.Rows(i).FindControl("a5"), TextBox).Text
            Dim a6 As String = DirectCast(GridView1.Rows(i).FindControl("a6"), TextBox).Text
            Dim a7 As String = DirectCast(GridView1.Rows(i).FindControl("a7"), TextBox).Text
            Dim a8 As String = DirectCast(GridView1.Rows(i).FindControl("a8"), TextBox).Text
            Dim a9 As String = DirectCast(GridView1.Rows(i).FindControl("a9"), TextBox).Text
            Dim a10 As String = DirectCast(GridView1.Rows(i).FindControl("a10"), TextBox).Text
            Dim a11 As String = DirectCast(GridView1.Rows(i).FindControl("a11"), TextBox).Text
            Dim a12 As String = DirectCast(GridView1.Rows(i).FindControl("a12"), TextBox).Text
            Dim a13 As String = DirectCast(GridView1.Rows(i).FindControl("a13"), TextBox).Text
            Dim a14 As String = DirectCast(GridView1.Rows(i).FindControl("a14"), TextBox).Text
            Dim a15 As String = DirectCast(GridView1.Rows(i).FindControl("a15"), TextBox).Text
            Dim a16 As String = DirectCast(GridView1.Rows(i).FindControl("a16"), TextBox).Text
            Dim a17 As String = DirectCast(GridView1.Rows(i).FindControl("a17"), TextBox).Text
            Dim a18 As String = DirectCast(GridView1.Rows(i).FindControl("a18"), TextBox).Text
            Dim a19 As String = DirectCast(GridView1.Rows(i).FindControl("a19"), TextBox).Text
            Dim a20 As String = DirectCast(GridView1.Rows(i).FindControl("a20"), TextBox).Text
            Dim a21 As String = DirectCast(GridView1.Rows(i).FindControl("a21"), TextBox).Text
            Dim a22 As String = DirectCast(GridView1.Rows(i).FindControl("a22"), TextBox).Text
            Dim a23 As String = DirectCast(GridView1.Rows(i).FindControl("a23"), TextBox).Text
            Dim a24 As String = DirectCast(GridView1.Rows(i).FindControl("a24"), TextBox).Text
            Dim a25 As String = DirectCast(GridView1.Rows(i).FindControl("a25"), TextBox).Text
            Dim a26 As String = DirectCast(GridView1.Rows(i).FindControl("a26"), TextBox).Text
            Dim a27 As String = DirectCast(GridView1.Rows(i).FindControl("a27"), TextBox).Text
            Dim a28 As String = DirectCast(GridView1.Rows(i).FindControl("a28"), TextBox).Text
            Dim a29 As String = DirectCast(GridView1.Rows(i).FindControl("a29"), TextBox).Text
            Dim a30 As String = DirectCast(GridView1.Rows(i).FindControl("a30"), TextBox).Text
            Dim a31 As String = DirectCast(GridView1.Rows(i).FindControl("a31"), TextBox).Text

            Dim r1 As Decimal
            Dim r2 As Decimal
            Dim r3 As Decimal
            Dim r4 As Decimal
            Dim r5 As String
            Dim r6 As String
            Dim r7 As String
            Dim r8 As String
            Dim r9 As String
            Dim r10 As String
            Dim r11 As String
            Dim r12 As String
            Dim r13 As String
            Dim r14 As String
            Dim r15 As String
            Dim r16 As String
            Dim r17 As String
            Dim r18 As String
            Dim r19 As String
            Dim r20 As String
            Dim r21 As String
            Dim r22 As String
            Dim r23 As String
            Dim r24 As String
            Dim r25 As String
            Dim r26 As String
            Dim r27 As String
            Dim r28 As String
            Dim r29 As String
            Dim r30 As String
            Dim r31 As String

            If d1.ToString = "" Then
                r1 = "0"
            Else
                r1 = Decimal.Parse(d1.ToString)
            End If


            If d2.ToString = "" Then
                r2 = "0"
            Else
                r2 = Decimal.Parse(d2.ToString)
            End If

            If d3.ToString = "" Then
                r3 = "0"
            Else
                r3 = Decimal.Parse(d3.ToString)
            End If

            If d4.ToString = "" Then
                r4 = "0"
            Else
                r4 = Decimal.Parse(d4.ToString)
            End If

            If d5.ToString = "" Then
                r5 = "0"
            Else
                r5 = Decimal.Parse(d5.ToString)
            End If

            If d6.ToString = "" Then
                r6 = "0"
            Else
                r6 = Decimal.Parse(d6.ToString)
            End If

            If d7.ToString = "" Then
                r7 = "0"
            Else
                r7 = Decimal.Parse(d7.ToString)
            End If

            If d8.ToString = "" Then
                r8 = "0"
            Else
                r8 = Decimal.Parse(d8.ToString)
            End If

            If d9.ToString = "" Then
                r9 = "0"
            Else
                r9 = Decimal.Parse(d9.ToString)
            End If

            If d10.ToString = "" Then
                r10 = "0"
            Else
                r10 = Decimal.Parse(d10.ToString)
            End If

            If d11.ToString = "" Then
                r11 = "0"
            Else
                r11 = Decimal.Parse(d11.ToString)
            End If

            If d12.ToString = "" Then
                r12 = "0"
            Else
                r12 = Decimal.Parse(d12.ToString)
            End If

            If d13.ToString = "" Then
                r13 = "0"
            Else
                r13 = Decimal.Parse(d13.ToString)
            End If

            If d14.ToString = "" Then
                r14 = "0"
            Else
                r14 = Decimal.Parse(d14.ToString)
            End If

            If d15.ToString = "" Then
                r15 = "0"
            Else
                r15 = Decimal.Parse(d15.ToString)
            End If

            If d16.ToString = "" Then
                r16 = "0"
            Else
                r16 = Decimal.Parse(d16.ToString)
            End If

            If d17.ToString = "" Then
                r17 = "0"
            Else
                r17 = Decimal.Parse(d17.ToString)
            End If

            If d18.ToString = "" Then
                r18 = "0"
            Else
                r18 = Decimal.Parse(d18.ToString)
            End If

            If d19.ToString = "" Then
                r19 = "0"
            Else
                r19 = Decimal.Parse(d19.ToString)
            End If

            If d20.ToString = "" Then
                r20 = "0"
            Else
                r20 = Decimal.Parse(d20.ToString)
            End If

            If d21.ToString = "" Then
                r21 = "0"
            Else
                r21 = Decimal.Parse(d21.ToString)
            End If

            If d22.ToString = "" Then
                r22 = "0"
            Else
                r22 = Decimal.Parse(d22.ToString)
            End If
            If d23.ToString = "" Then
                r23 = "0"
            Else
                r23 = Decimal.Parse(d23.ToString)
            End If

            If d24.ToString = "" Then
                r24 = "0"
            Else
                r24 = Decimal.Parse(d24.ToString)
            End If
            If d25.ToString = "" Then
                r25 = "0"
            Else
                r25 = Decimal.Parse(d25.ToString)
            End If

            If d26.ToString = "" Then
                r26 = "0"
            Else
                r26 = Decimal.Parse(d26.ToString)
            End If

            If d27.ToString = "" Then
                r27 = "0"
            Else
                r27 = Decimal.Parse(d27.ToString)
            End If
            If d28.ToString = "" Then
                r28 = "0"
            Else
                r28 = Decimal.Parse(d28.ToString)
            End If

            If d29.ToString = "" Then
                r29 = "0"
            Else
                r29 = Decimal.Parse(d29.ToString)
            End If

            If d30.ToString = "" Then
                r30 = "0"
            Else
                r30 = Decimal.Parse(d30.ToString)
            End If

            If d31.ToString = "" Then
                r31 = "0"
            Else
                r31 = Decimal.Parse(d31.ToString)
            End If
            Try

                MyGlobal.Open_Con()
                MyGlobal.Con_Str()
                Call MyGlobal.dbSp_open("hrmis_kpi_dailyupdate")

                Cmd.Parameters.AddWithValue("@sno", sno)

                Cmd.Parameters.AddWithValue("@res1", d1)
                Cmd.Parameters.AddWithValue("@res2", d2)
                Cmd.Parameters.AddWithValue("@res3", d3)
                Cmd.Parameters.AddWithValue("@res4", d4)
                Cmd.Parameters.AddWithValue("@res5", d5)
                Cmd.Parameters.AddWithValue("@res6", d6)
                Cmd.Parameters.AddWithValue("@res7", d7)
                Cmd.Parameters.AddWithValue("@res8", d8)
                Cmd.Parameters.AddWithValue("@res9", d9)
                Cmd.Parameters.AddWithValue("@res10", d10)
                Cmd.Parameters.AddWithValue("@res11", d11)
                Cmd.Parameters.AddWithValue("@res12", d12)
                Cmd.Parameters.AddWithValue("@res13", d13)
                Cmd.Parameters.AddWithValue("@res14", d14)
                Cmd.Parameters.AddWithValue("@res15", d15)
                Cmd.Parameters.AddWithValue("@res16", d16)
                Cmd.Parameters.AddWithValue("@res17", d17)
                Cmd.Parameters.AddWithValue("@res18", d18)
                Cmd.Parameters.AddWithValue("@res19", d19)
                Cmd.Parameters.AddWithValue("@res20", d20)
                Cmd.Parameters.AddWithValue("@res21", d21)
                Cmd.Parameters.AddWithValue("@res22", d22)
                Cmd.Parameters.AddWithValue("@res23", d23)
                Cmd.Parameters.AddWithValue("@res24", d24)
                Cmd.Parameters.AddWithValue("@res25", d25)
                Cmd.Parameters.AddWithValue("@res26", d26)
                Cmd.Parameters.AddWithValue("@res27", d27)
                Cmd.Parameters.AddWithValue("@res28", d28)
                Cmd.Parameters.AddWithValue("@res29", d29)
                Cmd.Parameters.AddWithValue("@res30", d30)
                Cmd.Parameters.AddWithValue("@res31", d31)

                Cmd.Parameters.AddWithValue("@act1", a1)
                Cmd.Parameters.AddWithValue("@act2", a2)
                Cmd.Parameters.AddWithValue("@act3", a3)
                Cmd.Parameters.AddWithValue("@act4", a4)
                Cmd.Parameters.AddWithValue("@act5", a5)
                Cmd.Parameters.AddWithValue("@act6", a6)
                Cmd.Parameters.AddWithValue("@act7", a7)
                Cmd.Parameters.AddWithValue("@act8", a8)
                Cmd.Parameters.AddWithValue("@act9", a9)
                Cmd.Parameters.AddWithValue("@act10", a10)
                Cmd.Parameters.AddWithValue("@act11", a11)
                Cmd.Parameters.AddWithValue("@act12", a12)
                Cmd.Parameters.AddWithValue("@act13", a13)
                Cmd.Parameters.AddWithValue("@act14", a14)
                Cmd.Parameters.AddWithValue("@act15", a15)
                Cmd.Parameters.AddWithValue("@act16", a16)
                Cmd.Parameters.AddWithValue("@act17", a17)
                Cmd.Parameters.AddWithValue("@act18", a18)
                Cmd.Parameters.AddWithValue("@act19", a19)
                Cmd.Parameters.AddWithValue("@act20", a20)
                Cmd.Parameters.AddWithValue("@act21", a21)
                Cmd.Parameters.AddWithValue("@act22", a22)
                Cmd.Parameters.AddWithValue("@act23", a23)
                Cmd.Parameters.AddWithValue("@act24", a24)
                Cmd.Parameters.AddWithValue("@act25", a25)
                Cmd.Parameters.AddWithValue("@act26", a26)
                Cmd.Parameters.AddWithValue("@act27", a27)
                Cmd.Parameters.AddWithValue("@act28", a28)
                Cmd.Parameters.AddWithValue("@act29", a29)
                Cmd.Parameters.AddWithValue("@act30", a30)
                Cmd.Parameters.AddWithValue("@act31", a31)

                Cmd.ExecuteNonQuery()

                daily = daily + r1 + r2 + r3 + r4 + r5 + r6 + r7 + r8 + r9 + r10 + r11 + r12 + r13 + r14 + r15 + r16 + r17 + r18 + r19 + r20 + r21 + r22 + r23 + r24 + r25 + r26 + r27 + r28 + r29 + r30 + r31

            Catch ex As SqlException
                MessageBox(ex.Message)
                Exit Sub
            End Try
        Next
        '''' do weekly update
        For i As Integer = 0 To GridView2.Rows.Count - 1
            Dim sno As String = GridView2.Rows(i).Cells(0).Text

            Dim d1 As String = DirectCast(GridView2.Rows(i).FindControl("r1"), Label).Text
            Dim d2 As String = DirectCast(GridView2.Rows(i).FindControl("r2"), Label).Text
            Dim d3 As String = DirectCast(GridView2.Rows(i).FindControl("r3"), Label).Text
            Dim d4 As String = DirectCast(GridView2.Rows(i).FindControl("r4"), Label).Text

            Dim a1 As String = DirectCast(GridView2.Rows(i).FindControl("a1"), TextBox).Text
            Dim a2 As String = DirectCast(GridView2.Rows(i).FindControl("a2"), TextBox).Text
            Dim a3 As String = DirectCast(GridView2.Rows(i).FindControl("a3"), TextBox).Text
            Dim a4 As String = DirectCast(GridView2.Rows(i).FindControl("a4"), TextBox).Text

            Dim r1 As Decimal = Decimal.Parse(d1.ToString)
            Dim r2 As Decimal = Decimal.Parse(d2.ToString)
            Dim r3 As Decimal = Decimal.Parse(d3.ToString)
            Dim r4 As Decimal = Decimal.Parse(d4.ToString)

            Try
                MyGlobal.Open_Con()
                MyGlobal.Con_Str()
                Call MyGlobal.dbSp_open("hrmis_kpi_weekupdate")

                Cmd.Parameters.AddWithValue("@sno", sno)
                Cmd.Parameters.AddWithValue("@res1", d1)
                Cmd.Parameters.AddWithValue("@res2", d2)
                Cmd.Parameters.AddWithValue("@res3", d3)
                Cmd.Parameters.AddWithValue("@res4", d4)

                Cmd.Parameters.AddWithValue("@act1", a1)
                Cmd.Parameters.AddWithValue("@act2", a2)
                Cmd.Parameters.AddWithValue("@act3", a3)
                Cmd.Parameters.AddWithValue("@act4", a4)

                Cmd.ExecuteNonQuery()

                weekly = weekly + r1 + r2 + r3 + r4
            Catch ex As SqlException
                MessageBox(ex.Message)
                Exit Sub
            End Try
        Next

        '''' do Monthly update
        For i As Integer = 0 To GridView3.Rows.Count - 1
            Dim sno As String = GridView3.Rows(i).Cells(0).Text
            Dim d1 As String = DirectCast(GridView3.Rows(i).FindControl("r1"), Label).Text
            Dim a1 As String = DirectCast(GridView3.Rows(i).FindControl("a1"), TextBox).Text
            Dim r1 As Decimal = Decimal.Parse(d1.ToString)

            Try
                MyGlobal.Open_Con()
                MyGlobal.Con_Str()
                Call MyGlobal.dbSp_open("hrmis_kpi_monupdate")
                Cmd.Parameters.AddWithValue("@sno", sno)
                Cmd.Parameters.AddWithValue("@res1", d1)
                Cmd.Parameters.AddWithValue("@act1", a1)
                Cmd.ExecuteNonQuery()
                monthly = monthly + r1

            Catch ex As SqlException
                MessageBox(ex.Message)
                Exit Sub
            End Try
        Next

        daily = daily / totDaysOfKPIMonth
        weekly = weekly / 4

        total = daily + weekly + monthly
        total = Math.Round(total, 1)

        getgrade(total)
        If mon = "3" Then
            yr = Date.Now.Year
            yr = yr - 1
        End If


        Try
            MyGlobal.Open_Con()
            MyGlobal.Con_Str()
            Call MyGlobal.dbSp_open("kpi_grade_insert")
            Cmd.Parameters.AddWithValue("@empcode", Session("empcode"))
            Cmd.Parameters.AddWithValue("@yr", yr)
            Cmd.Parameters.AddWithValue("@mnth", mon)
            Cmd.Parameters.AddWithValue("@total", total)
            Cmd.Parameters.AddWithValue("@grade ", lblgrade.Text)
            Cmd.ExecuteNonQuery()
        Catch ex As SqlException
            MessageBox(ex.Message)
            Exit Sub
        End Try
        lbltotal.Text = total
        MessageBox("Data Saved Successfully")

    End Sub

    Function getgrade(ByVal total As String)
        Dim grade
        If total > 0 And total < 51 Then
            grade = "E"
        ElseIf total > 50 And total < 61 Then
            grade = "D"
        ElseIf total > 60 And total < 71 Then
            grade = "C"
        ElseIf total > 70 And total < 86 Then
            grade = "B"
        ElseIf total > 85 And total < 101 Then
            grade = "A"
        ElseIf total >= 100 Then
            grade = "A"
        ElseIf total <= 0 Then
            grade = "E"
        End If
        lblgrade.text = grade
    End Function

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim ds As DataSet
        Dim dr As DataRow
        Dim status

        GettotGrade()
        ds = GettotGrade()

        If ds.Tables(0).Rows.Count > 0 Then
            dr = ds.Tables(0).Rows(0)
            If Not dr("total").ToString Is System.DBNull.Value Then
                lbltotal.Text = dr("total").ToString
            Else
                lbltotal.Text = 0
            End If
            If Not dr("grade").ToString Is System.DBNull.Value Then
                lblgrade.Text = dr("grade").ToString
            Else
                lblgrade.Text = 0
            End If
            If Not dr("status").ToString Is System.DBNull.Value Then
                status = dr("status").ToString
            Else
                status = "Scheduled"
            End If
        Else
            status = "Scheduled"
        End If

        Panel1.Visible = True
        Panel2.Visible = True
        Panel3.Visible = True

        If status = "Scheduled" Then
            btnsave.Visible = True
            Panel1.Visible = True
            Panel2.Visible = True
            Panel3.Visible = True
            LoadGrid()
        Else
            MessageBox("Your KPI for current month is already approved.You cannot Update your KPI")
            btnsave.Visible = False
            Panel1.Visible = True
            Panel2.Visible = True
            Panel3.Visible = True
            LoadGrid()
        End If

    End Sub

    Protected Sub ddlmonth_SelectedIndexChanged(ByVal sended As System.Object, ByVal e As System.EventArgs) Handles ddlmonth.SelectedIndexChanged
        LoadGrid()
    End Sub

End Class
