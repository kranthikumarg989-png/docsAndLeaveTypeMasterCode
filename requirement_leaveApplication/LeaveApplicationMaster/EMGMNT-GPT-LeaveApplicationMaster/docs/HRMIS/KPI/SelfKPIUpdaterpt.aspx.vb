Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class SelfKPIUpdaterpt
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim rno
    Dim mon
    Dim yr
    Dim i, j, k, l
    Dim mytot

    Private Sub SelfKPIUpdaterpt_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (78)
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
        getDetails()
        loadDDL()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
    
        ' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (78)
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

        mon = ddlmonth.SelectedValue.Trim
        yr = Date.Now.Year
        lblyr.Text = yr
        lblmon.Text = mon

   
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
        yr = Date.Now.Year

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
        yr = Date.Now.Year
        lblmon.Text = mon
        'If Not IsPostBack Then

        If mon = "04" Or mon = "05" Or mon = "06" Then
            qtr = "q1"
        ElseIf mon = "07" Or mon = "08" Or mon = "09" Then
            qtr = "Q2"
        ElseIf mon = "10" Or mon = "11" Or mon = "12" Then
            qtr = "q3"
        ElseIf mon = "01" Or mon = "02" Or mon = "03" Then
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
        yr = Date.Now.Year
        lblmon.Text = mon
        ' If Not IsPostBack Then

        If mon = "04" Or mon = "05" Or mon = "06" Then
            qtr = "q1"
        ElseIf mon = "07" Or mon = "08" Or mon = "09" Then
            qtr = "Q2"
        ElseIf mon = "10" Or mon = "11" Or mon = "12" Then
            qtr = "q3"
        ElseIf mon = "01" Or mon = "02" Or mon = "03" Then
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
        lblstatus.Text = status

        Panel1.Visible = True
        Panel2.Visible = True
        Panel3.Visible = True
        LoadGrid()

    End Sub

    Protected Sub ddlmonth_SelectedIndexChanged(ByVal sended As System.Object, ByVal e As System.EventArgs) Handles ddlmonth.SelectedIndexChanged
        LoadGrid()
    End Sub

End Class
