Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class ReportKPIPerformance
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        ' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (84)
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

        MyApp.GetfiscalYear()
    End Sub
    Protected Sub btnshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnshow.Click

        '''' Delete from Temp table before entering new record
        MyGlobal.Con_Str()

        Dim con As New SqlConnection(constr)
        con.Open()
        Cmd = New SqlCommand("delete from kpi_summaryrpt_temp", con)
        Cmd.ExecuteNonQuery()

        Dim rdvalue As String
        rdvalue = rdoptions.SelectedValue
        Dim opt
        opt = RadioButtonList1.SelectedValue
        Dim sqltext

        Session("kpidesigs") = Trim(ddldesigr.SelectedValue)
        Session("kpiemps") = Trim(txtempidr.Text)
        Session("kpisects") = Trim(ddlsectrpt.SelectedValue)
        Session("kpidepts") = ddldeptr.SelectedValue.Trim
        Session("kpiyrs") = ddlyr.SelectedValue.Trim
        Session("kpimons") = ddlmon.SelectedValue.Trim
        Session("Kpimthndays") = opt
        Dim sqlmain

        If (opt = "yr" Or opt = "hyr") Then
            If rdvalue = "Dept" And ddldeptr.SelectedValue <> "" Then
                Session("kpiRptbys") = "D"
                ' sqltext = "select *,departmentcode from kpi_grade_result,empmaster where kpi_grade_result.empcode = empmaster.empcode  and yr = '" & ddlyr.SelectedValue.Trim & "' and empmaster.departmentcode ='" & ddldeptr.SelectedValue & "'"
                sqlmain = "select distinct empmaster.empcode from kpi_grade_result,empmaster where kpi_grade_result.empcode = empmaster.empcode  and yr = '" & ddlyr.SelectedValue.Trim & "' and empmaster.departmentcode ='" & ddldeptr.SelectedValue & "'"
            ElseIf rdvalue = "Sect" And ddlsectrpt.SelectedValue <> "" Then
                Session("kpiRptbys") = "S"
                'sqltext = "select *,sectioncode from kpi_grade_result,empmaster where kpi_grade_result.empcode = empmaster.empcode  and yr = '" & ddlyr.SelectedValue.Trim & "' and empmaster.sectioncode ='" & ddlsectrpt.SelectedValue & "'"
                sqlmain = "select distinct empmaster.empcode from kpi_grade_result,empmaster where kpi_grade_result.empcode = empmaster.empcode  and yr = '" & ddlyr.SelectedValue.Trim & "' and empmaster.sectioncode ='" & ddlsectrpt.SelectedValue & "'"
            ElseIf rdvalue = "Desig" And ddldesigr.SelectedValue <> "" Then
                Session("kpiRptbys") = "Desi"
                'sqltext = "select *,designation from kpi_grade_result,empmaster where kpi_grade_result.empcode = empmaster.empcode  and yr = '" & ddlyr.SelectedValue.Trim & "' and empmaster.designation ='" & ddldesigr.SelectedValue & "'"
                sqlmain = "select distinct empmaster.empcode from kpi_grade_result,empmaster where kpi_grade_result.empcode = empmaster.empcode  and yr = '" & ddlyr.SelectedValue.Trim & "' and empmaster.designation ='" & ddldesigr.SelectedValue & "'"
            ElseIf rdvalue = "Emp" And txtempidr.Text <> "" Then
                Session("kpiRptbys") = "E"
                'sqltext = "select *,empmaster.empcode from kpi_grade_result,empmaster where kpi_grade_result.empcode = empmaster.empcode  and yr = '" & ddlyr.SelectedValue.Trim & "' and empmaster.empcode ='" & txtempidr.Text.Trim & "'"
                sqlmain = "select distinct empmaster.empcode from kpi_grade_result,empmaster where kpi_grade_result.empcode = empmaster.empcode  and yr = '" & ddlyr.SelectedValue.Trim & "' and empmaster.empcode ='" & txtempidr.Text.Trim & "'"
            Else
                Session("kpiRptbys") = "O"
                'sqltext = "select *,empmaster.empcode from kpi_grade_result,empmaster where kpi_grade_result.empcode = empmaster.empcode  and yr = '" & ddlyr.SelectedValue.Trim & "'"
                sqlmain = "select distinct empmaster.empcode from kpi_grade_result,empmaster where kpi_grade_result.empcode = empmaster.empcode  and yr = '" & ddlyr.SelectedValue.Trim & "'"

            End If


            Dim ds1 As DataSet
            Dim dr, dr1 As DataRow
            Dim i
            Dim emp
            Dim tot
            Dim grd
            Dim mth


            Dim disemp
            ds1 = GetEmpcode(sqlmain)
            If ds1.Tables(0).Rows.Count <> 0 Then
                For s As Integer = 0 To ds1.Tables(0).Rows.Count - 1
                    dr1 = ds1.Tables(0).Rows(s)
                    disemp = dr1("empcode").ToString
                    Dim p1 = 0
                    Dim p2 = 0
                    Dim p3 = 0
                    Dim p4 = 0
                    Dim p5 = 0
                    Dim p6 = 0
                    Dim p7 = 0
                    Dim p8 = 0
                    Dim p9 = 0
                    Dim p10 = 0
                    Dim p11 = 0
                    Dim p12 = 0

                    Dim g1 = "-"
                    Dim g2 = "-"
                    Dim g3 = "-"
                    Dim g4 = "-"
                    Dim g5 = "-"
                    Dim g6 = "-"
                    Dim g7 = "-"
                    Dim g8 = "-"
                    Dim g9 = "-"
                    Dim g10 = "-"
                    Dim g11 = "-"
                    Dim g12 = "-"
                    sqltext = "select *,empmaster.empcode from kpi_grade_result,empmaster where kpi_grade_result.empcode = empmaster.empcode  and yr = '" & ddlyr.SelectedValue.Trim & "' and empmaster.empcode ='" & disemp & "'"
                    DS = GetEmpList(sqltext)
                    If DS.Tables(0).Rows.Count <> 0 Then
                        For i = 0 To DS.Tables(0).Rows.Count - 1
                            dr = DS.Tables(0).Rows(i)
                            emp = dr("empcode").ToString.Trim
                            mth = dr("mnth").ToString.Trim

                            If mth = "1" Then
                                If Not dr("total").ToString.Trim.Trim Is System.DBNull.Value Then
                                    p1 = dr("total").ToString.Trim.Trim
                                Else
                                    p1 = "0"
                                End If
                                If Not dr("grade").ToString.Trim Is System.DBNull.Value Then
                                    g1 = dr("grade").ToString.Trim
                                Else
                                    g1 = "-"
                                End If
                            ElseIf mth = "2" Then
                                If Not dr("total").ToString.Trim Is System.DBNull.Value Then
                                    p2 = dr("total").ToString.Trim
                                Else
                                    p2 = "0"
                                End If
                                If Not dr("grade").ToString.Trim Is System.DBNull.Value Then
                                    g2 = dr("grade").ToString.Trim
                                Else
                                    g2 = "-"
                                End If
                            ElseIf mth = "3" Then
                                If Not dr("total").ToString.Trim Is System.DBNull.Value Then
                                    p3 = dr("total").ToString.Trim
                                Else
                                    p3 = "0"
                                End If
                                If Not dr("grade").ToString.Trim Is System.DBNull.Value Then
                                    g3 = dr("grade").ToString.Trim
                                Else
                                    g3 = "-"
                                End If
                            ElseIf mth = "4" Then
                                If Not dr("total").ToString.Trim Is System.DBNull.Value Then
                                    p4 = dr("total").ToString.Trim
                                Else
                                    p4 = "0"
                                End If
                                If Not dr("grade").ToString.Trim Is System.DBNull.Value Then
                                    g4 = dr("grade").ToString.Trim
                                Else
                                    g4 = "-"
                                End If
                            ElseIf mth = "5" Then
                                If Not dr("total").ToString.Trim Is System.DBNull.Value Then
                                    p5 = dr("total").ToString.Trim
                                Else
                                    p5 = "0"
                                End If
                                If Not dr("grade").ToString.Trim Is System.DBNull.Value Then
                                    g5 = dr("grade").ToString.Trim
                                Else
                                    g5 = "-"
                                End If
                            ElseIf mth = "6" Then
                                If Not dr("total").ToString.Trim Is System.DBNull.Value Then
                                    p6 = dr("total").ToString.Trim
                                Else
                                    p6 = "0"
                                End If
                                If Not dr("grade").ToString.Trim Is System.DBNull.Value Then
                                    g6 = dr("grade").ToString.Trim
                                Else
                                    g6 = "-"
                                End If
                            ElseIf mth = "7" Then
                                If Not dr("total").ToString.Trim Is System.DBNull.Value Then
                                    p7 = dr("total").ToString.Trim
                                Else
                                    p7 = "0"
                                End If
                                If Not dr("grade").ToString.Trim Is System.DBNull.Value Then
                                    g7 = dr("grade").ToString.Trim
                                Else
                                    g7 = "-"
                                End If
                            ElseIf mth = "8" Then
                                If Not dr("total").ToString.Trim Is System.DBNull.Value Then
                                    p8 = dr("total").ToString.Trim
                                Else
                                    p8 = "0"
                                End If
                                If Not dr("grade").ToString.Trim Is System.DBNull.Value Then
                                    g8 = dr("grade").ToString.Trim
                                Else
                                    g8 = "-"
                                End If
                            ElseIf mth = "9" Then
                                If Not dr("total").ToString.Trim Is System.DBNull.Value Then
                                    p9 = dr("total").ToString.Trim
                                Else
                                    p9 = "0"
                                End If
                                If Not dr("grade").ToString.Trim Is System.DBNull.Value Then
                                    g9 = dr("grade").ToString.Trim
                                Else
                                    g9 = "-"
                                End If
                            ElseIf mth = "10" Then
                                If Not dr("total").ToString.Trim Is System.DBNull.Value Then
                                    p10 = dr("total").ToString.Trim
                                Else
                                    p10 = "0"
                                End If
                                If Not dr("grade").ToString.Trim Is System.DBNull.Value Then
                                    g10 = dr("grade").ToString.Trim
                                Else
                                    g10 = "-"
                                End If
                            ElseIf mth = "11" Then
                                If Not dr("total").ToString.Trim Is System.DBNull.Value Then
                                    p11 = dr("total").ToString.Trim
                                Else
                                    p11 = "0"
                                End If
                                If Not dr("grade").ToString.Trim Is System.DBNull.Value Then
                                    g11 = dr("grade").ToString.Trim
                                Else
                                    g11 = "-"
                                End If
                            ElseIf mth = "12" Then
                                If Not dr("total").ToString.Trim Is System.DBNull.Value Then
                                    p12 = dr("total").ToString.Trim
                                Else
                                    p12 = "0"
                                End If
                                If Not dr("grade").ToString.Trim Is System.DBNull.Value Then
                                    g12 = dr("grade").ToString.Trim
                                Else
                                    g12 = "-"
                                End If
                            End If
                            Dim grade
                            Dim avg
                            If opt = "hyr" Then
                                If ddlhalf.SelectedValue = "1h" Then
                                    avg = Double.Parse(p4) + Double.Parse(p5) + Double.Parse(p6) + Double.Parse(p7) + Double.Parse(p8) + Double.Parse(p9)
                                ElseIf ddlhalf.SelectedValue = "2h" Then
                                    avg = Double.Parse(p1) + Double.Parse(p2) + Double.Parse(p3) + Double.Parse(p10) + Double.Parse(p11) + Double.Parse(p12)
                                End If
                                avg = Math.Round(avg / 6)
                            Else
                                avg = Double.Parse(p1) + Double.Parse(p2) + Double.Parse(p3) + Double.Parse(p4) + Double.Parse(p5) + Double.Parse(p6) + Double.Parse(p7) + Double.Parse(p8) + Double.Parse(p9) + Double.Parse(p10) + Double.Parse(p11) + Double.Parse(p12)
                                avg = Math.Round(avg / 12)
                            End If



                            If avg > 0 And avg < 51 Then
                                grade = "E"
                            ElseIf avg > 50 And avg < 61 Then
                                grade = "D"
                            ElseIf avg > 60 And avg < 71 Then
                                grade = "C"
                            ElseIf avg > 70 And avg < 86 Then
                                grade = "B"
                            ElseIf avg > 85 And avg < 101 Then
                                grade = "A"
                            ElseIf avg >= 100 Then
                                grade = "A"
                            ElseIf avg <= 0 Then
                                grade = "E"
                            End If

                            Try
                                MyGlobal.Open_Con()
                                MyGlobal.Con_Str()
                                Call MyGlobal.dbSp_open("kpi_summary_temp")
                                Cmd.Parameters.AddWithValue("@empcode", emp)
                                Cmd.Parameters.AddWithValue("yr", ddlyr.SelectedValue.Trim)
                                Cmd.Parameters.AddWithValue("@p1", p1)
                                Cmd.Parameters.AddWithValue("@p2", p2)
                                Cmd.Parameters.AddWithValue("@p3", p3)
                                Cmd.Parameters.AddWithValue("@p4", p4)
                                Cmd.Parameters.AddWithValue("@p5", p5)
                                Cmd.Parameters.AddWithValue("@p6", p6)
                                Cmd.Parameters.AddWithValue("@p7", p7)
                                Cmd.Parameters.AddWithValue("@p8", p8)
                                Cmd.Parameters.AddWithValue("@p9", p9)
                                Cmd.Parameters.AddWithValue("@p10", p10)
                                Cmd.Parameters.AddWithValue("@p11", p11)
                                Cmd.Parameters.AddWithValue("@p12", p12)

                                Cmd.Parameters.AddWithValue("@g1", g1)
                                Cmd.Parameters.AddWithValue("@g2", g2)
                                Cmd.Parameters.AddWithValue("@g3", g3)
                                Cmd.Parameters.AddWithValue("@g4", g4)
                                Cmd.Parameters.AddWithValue("@g5", g5)
                                Cmd.Parameters.AddWithValue("@g6", g6)
                                Cmd.Parameters.AddWithValue("@g7", g7)
                                Cmd.Parameters.AddWithValue("@g8", g8)
                                Cmd.Parameters.AddWithValue("@g9", g9)
                                Cmd.Parameters.AddWithValue("@g10", g10)
                                Cmd.Parameters.AddWithValue("@g11", g11)
                                Cmd.Parameters.AddWithValue("@g12", g12)

                                Cmd.Parameters.AddWithValue("@avg", avg)
                                Cmd.Parameters.AddWithValue("@gradeavg", grade)
                                '   Cmd.Parameters.AddWithValue("@mth", mth)

                                Cmd.ExecuteNonQuery()
                            Catch ex As Exception
                                MessageBox(ex.Message)
                                Exit Sub
                            End Try
                        Next
                    End If
                Next
            End If
            Session("xkpiopt") = opt
            Session("xkp") = ddlhalf.SelectedValue

            Response.Redirect("RptKPISujmmaryMonrpt.aspx")
        ElseIf opt = "mth" Then
            If rdvalue = "Dept" And ddldeptr.SelectedValue <> "" Then
                Session("kpiRptbys") = "D"
            ElseIf rdvalue = "Sect" And ddlsectrpt.SelectedValue <> "" Then
                Session("kpiRptbys") = "S"
            ElseIf rdvalue = "Desig" And ddldesigr.SelectedValue <> "" Then
                Session("kpiRptbys") = "Desi"
            ElseIf rdvalue = "Emp" And txtempidr.Text <> "" Then
                Session("kpiRptbys") = "E"
            Else
                Session("kpiRptbys") = "O"
            End If

            Response.Redirect("RptKPISummaryMon.aspx")
        End If

    End Sub
    Function getgrade(ByVal total As String)
        Dim grade

    End Function

    Function GetEmpList(ByVal sqltext As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand(sqltext, con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "emp")
        con.Close()
        Return ds
    End Function
    Function GetEmpcode(ByVal sqlmain As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand(sqlmain, con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "emp1")
        con.Close()
        Return ds
    End Function

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        Dim opt
        opt = RadioButtonList1.SelectedValue
        If opt = "mth" Then
            ddlmon.Enabled = True
            ddlyr.Enabled = True
            ddlhalf.Enabled = False

        ElseIf opt = "yr" Then
            ddlmon.Enabled = False
            ddlyr.Enabled = True
            ddlhalf.Enabled = False

        ElseIf opt = "hyr" Then
            ddlmon.Enabled = False
            ddlyr.Enabled = True
            ddlhalf.Enabled = True


        End If
    End Sub
    Protected Sub rdoptions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoptions.SelectedIndexChanged

        If rdoptions.SelectedValue = "Dept" Then
            ddldeptr.Enabled = True
            ddlsectrpt.Enabled = False
            ddldesigr.Enabled = False
            txtempidr.Enabled = False
        ElseIf rdoptions.SelectedValue = "Sect" Then
            ddldeptr.Enabled = False
            ddlsectrpt.Enabled = True
            ddldesigr.Enabled = False
            txtempidr.Enabled = False
        ElseIf rdoptions.SelectedValue = "Desig" Then
            ddldeptr.Enabled = False
            ddlsectrpt.Enabled = False
            ddldesigr.Enabled = True
            txtempidr.Enabled = False
        ElseIf rdoptions.SelectedValue = "Emp" Then
            ddldeptr.Enabled = False
            ddlsectrpt.Enabled = False
            ddldesigr.Enabled = False
            txtempidr.Enabled = True
        Else
            ddldeptr.Enabled = False
            ddlsectrpt.Enabled = False
            ddldesigr.Enabled = False
            txtempidr.Enabled = False
        End If
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
End Class