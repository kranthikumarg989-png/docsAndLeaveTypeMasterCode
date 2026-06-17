Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class ProductionRequest
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim empcode

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        ' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (101)
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
        ' Session("empcode") = "014543"
        ' Session("_edept") = "9003"
    End Sub

    Protected Sub txtempcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtempcode.TextChanged
        empcode = txtempcode.Text
        GetEmpVehino(empcode)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                lblename.Text = dr("empname").ToString
                lblsect.Text = dr("sectioncode").ToString
                lbldept.Text = dr("departmentcode").ToString
                lbldesig.Text = dr("designation").ToString
                lblstatus.Text = dr("emptype").ToString
            Else
                lblmsg.text = MyerrorMsg
                MessageBox("EmployeeCode doesnot Exist!!")
                Exit Sub
            End If
        End If
    End Sub

    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
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

        lblfrom.Text = fd
        lblto.Text = td

        Dim startdt
        Dim enddt
        startdt = Day(fd)
        enddt = Day(td)

        Dim m, y

        m = strdate(1)
        y = strdate(2)

        Dim dm = System.DateTime.DaysInMonth(y, m)


        Dim res = (fd.AddMonths(1)).AddDays(-1)

        '02.01.2013 below commented code is for Payroll Month 21 to 20
        'If (res <> td) Or (startdt <> "21" And enddt <> "20") Then
        '    MessageBox("Please check the work schedule date ")
        '    GridView2.Visible = False
        '    Exit Sub
        'End If

        '02.01.2013 below code is for Payroll Month 01 to 31
        'MessageBox(dm)
        If (res <> td) Or (startdt <> "01" And enddt <> dm) Then
            MessageBox("Please check the work schedule date ")
            GridView2.Visible = False
            Exit Sub
        End If

        If rdooptions.SelectedValue = "section" And ddlsect.SelectedValue = "-1" Then
            MessageBox("Please select section ")
            Exit Sub
        End If

        If rdooptions.SelectedValue = "emp" And txtempcode.Text = "" Then
            MessageBox("Please Key in empcode")
            Exit Sub
        End If

        'If rdooptions.SelectedValue = "section" And DropDownList1.SelectedValue = "-1" Then
        '    MessageBox("Please select Group")
        '    Exit Sub
        'End If

        If rdooptions.SelectedValue = "section" Then
            GridView2.Visible = False
            grdsection.Visible = True
        Else
            GridView2.Visible = True
            grdsection.Visible = False
        End If

    End Sub

    Public Sub UpdatePRMAster(ByVal sender As Object, ByVal e As EventArgs)

        Dim ds As DataSet
        For i As Integer = 0 To GridView2.Rows.Count - 1
            Dim Emp As String = txtempcode.Text.Trim
            Dim dept As String = lbldept.Text.Trim
            Dim sect As String = lblsect.Text.Trim
            '  Dim grp As String = DropDownList1.SelectedValue
            Dim Egrp As String = GridView2.Rows(i).Cells(3).Text
            Dim grp As String = DirectCast(GridView2.Rows(i).FindControl("ddlgridgrp"), DropDownList).SelectedValue.Trim
            Dim eegrp As String = DirectCast(GridView2.Rows(i).FindControl("lblggrp"), Label).Text

            Dim d21 As String = DirectCast(GridView2.Rows(i).FindControl("ddl21"), DropDownList).SelectedValue.Trim
            Dim d22 As String = DirectCast(GridView2.Rows(i).FindControl("ddl22"), DropDownList).SelectedValue.Trim
            Dim d23 As String = DirectCast(GridView2.Rows(i).FindControl("ddl23"), DropDownList).SelectedValue.Trim
            Dim d24 As String = DirectCast(GridView2.Rows(i).FindControl("ddl24"), DropDownList).SelectedValue.Trim
            Dim d25 As String = DirectCast(GridView2.Rows(i).FindControl("ddl25"), DropDownList).SelectedValue.Trim
            Dim d26 As String = DirectCast(GridView2.Rows(i).FindControl("ddl26"), DropDownList).SelectedValue.Trim
            Dim d27 As String = DirectCast(GridView2.Rows(i).FindControl("ddl27"), DropDownList).SelectedValue.Trim
            Dim d28 As String = DirectCast(GridView2.Rows(i).FindControl("ddl28"), DropDownList).SelectedValue.Trim
            Dim d29 As String = DirectCast(GridView2.Rows(i).FindControl("ddl29"), DropDownList).SelectedValue.Trim
            Dim d30 As String = DirectCast(GridView2.Rows(i).FindControl("ddl30"), DropDownList).SelectedValue.Trim
            Dim d31 As String = DirectCast(GridView2.Rows(i).FindControl("ddl31"), DropDownList).SelectedValue.Trim
            Dim d1 As String = DirectCast(GridView2.Rows(i).FindControl("ddl1"), DropDownList).SelectedValue.Trim
            Dim d2 As String = DirectCast(GridView2.Rows(i).FindControl("ddl2"), DropDownList).SelectedValue.Trim
            Dim d3 As String = DirectCast(GridView2.Rows(i).FindControl("ddl3"), DropDownList).SelectedValue.Trim
            Dim d4 As String = DirectCast(GridView2.Rows(i).FindControl("ddl4"), DropDownList).SelectedValue.Trim
            Dim d5 As String = DirectCast(GridView2.Rows(i).FindControl("ddl5"), DropDownList).SelectedValue.Trim
            Dim d6 As String = DirectCast(GridView2.Rows(i).FindControl("ddl6"), DropDownList).SelectedValue.Trim
            Dim d7 As String = DirectCast(GridView2.Rows(i).FindControl("ddl7"), DropDownList).SelectedValue.Trim
            Dim d8 As String = DirectCast(GridView2.Rows(i).FindControl("ddl8"), DropDownList).SelectedValue.Trim
            Dim d9 As String = DirectCast(GridView2.Rows(i).FindControl("ddl9"), DropDownList).SelectedValue.Trim
            Dim d10 As String = DirectCast(GridView2.Rows(i).FindControl("ddl10"), DropDownList).SelectedValue.Trim
            Dim d11 As String = DirectCast(GridView2.Rows(i).FindControl("ddl11"), DropDownList).SelectedValue.Trim
            Dim d12 As String = DirectCast(GridView2.Rows(i).FindControl("ddl12"), DropDownList).SelectedValue.Trim
            Dim d13 As String = DirectCast(GridView2.Rows(i).FindControl("ddl13"), DropDownList).SelectedValue.Trim
            Dim d14 As String = DirectCast(GridView2.Rows(i).FindControl("ddl14"), DropDownList).SelectedValue.Trim
            Dim d15 As String = DirectCast(GridView2.Rows(i).FindControl("ddl15"), DropDownList).SelectedValue.Trim
            Dim d16 As String = DirectCast(GridView2.Rows(i).FindControl("ddl16"), DropDownList).SelectedValue.Trim
            Dim d17 As String = DirectCast(GridView2.Rows(i).FindControl("ddl17"), DropDownList).SelectedValue.Trim
            Dim d18 As String = DirectCast(GridView2.Rows(i).FindControl("ddl18"), DropDownList).SelectedValue.Trim
            Dim d19 As String = DirectCast(GridView2.Rows(i).FindControl("ddl19"), DropDownList).SelectedValue.Trim
            Dim d20 As String = DirectCast(GridView2.Rows(i).FindControl("ddl20"), DropDownList).SelectedValue.Trim

            Try
                MyGlobal.Open_Con()
                MyGlobal.Con_Str()
                Call MyGlobal.dbSp_open("HRMIs_InsertPR")

                Cmd.Parameters.AddWithValue("@empcode", Emp)
                Cmd.Parameters.AddWithValue("@departmentcode", dept)
                Cmd.Parameters.AddWithValue("@sectioncode", sect)
                Cmd.Parameters.AddWithValue("@fromdate", lblfrom.Text)
                Cmd.Parameters.AddWithValue("@todate", lblto.Text)
                Cmd.Parameters.AddWithValue("@keyinby", Session("empcode"))
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
                Cmd.Parameters.AddWithValue("@groupcode", grp)
                Cmd.Parameters.AddWithValue("@category", "")

                Cmd.ExecuteNonQuery()

                ''''PR1

                Call MyGlobal.dbSp_open("HRMIs_InsertPR1")

                Cmd.Parameters.AddWithValue("@empcode", Emp)
                Cmd.Parameters.AddWithValue("@departmentcode", dept)
                Cmd.Parameters.AddWithValue("@sectioncode", sect)
                Cmd.Parameters.AddWithValue("@fromdate", lblfrom.Text)
                Cmd.Parameters.AddWithValue("@todate", lblto.Text)
                Cmd.Parameters.AddWithValue("@keyinby", Session("empcode"))
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
                Cmd.Parameters.AddWithValue("@groupcode", grp)
                Cmd.Parameters.AddWithValue("@category", "")

                Cmd.ExecuteNonQuery()

                MessageBox("Record Updated")
                lblmsg.Text = ""
            Catch ex As SqlException
                MessageBox(ex.Message)
                Exit Sub
            End Try
        Next

        GridView2.Visible = True
        GridView2.DataBind()
    End Sub

    Public Sub UpdatePRMAsterSect(ByVal sender As Object, ByVal e As EventArgs)

        Dim ds As DataSet

        For i As Integer = 0 To grdsection.Rows.Count - 1
            Dim Emp As String = grdsection.Rows(i).Cells(0).Text
            Dim dept As String = grdsection.Rows(i).Cells(4).Text
            Dim sect As String = ddlsect.SelectedValue.Trim
            '  Dim grp As String = DropDownList1.SelectedValue

            Dim Egrp As String = grdsection.Rows(i).Cells(3).Text
            Dim grp As String = DirectCast(grdsection.Rows(i).FindControl("ddlgridgrp"), DropDownList).SelectedValue.Trim
            Dim eegrp As String = DirectCast(grdsection.Rows(i).FindControl("lblggrp"), Label).Text


            Dim d21 As String = DirectCast(grdsection.Rows(i).FindControl("ddl21"), DropDownList).SelectedValue.Trim
            Dim d22 As String = DirectCast(grdsection.Rows(i).FindControl("ddl22"), DropDownList).SelectedValue.Trim
            Dim d23 As String = DirectCast(grdsection.Rows(i).FindControl("ddl23"), DropDownList).SelectedValue.Trim
            Dim d24 As String = DirectCast(grdsection.Rows(i).FindControl("ddl24"), DropDownList).SelectedValue.Trim
            Dim d25 As String = DirectCast(grdsection.Rows(i).FindControl("ddl25"), DropDownList).SelectedValue.Trim
            Dim d26 As String = DirectCast(grdsection.Rows(i).FindControl("ddl26"), DropDownList).SelectedValue.Trim
            Dim d27 As String = DirectCast(grdsection.Rows(i).FindControl("ddl27"), DropDownList).SelectedValue.Trim
            Dim d28 As String = DirectCast(grdsection.Rows(i).FindControl("ddl28"), DropDownList).SelectedValue.Trim
            Dim d29 As String = DirectCast(grdsection.Rows(i).FindControl("ddl29"), DropDownList).SelectedValue.Trim
            Dim d30 As String = DirectCast(grdsection.Rows(i).FindControl("ddl30"), DropDownList).SelectedValue.Trim
            Dim d31 As String = DirectCast(grdsection.Rows(i).FindControl("ddl31"), DropDownList).SelectedValue.Trim
            Dim d1 As String = DirectCast(grdsection.Rows(i).FindControl("ddl1"), DropDownList).SelectedValue.Trim
            Dim d2 As String = DirectCast(grdsection.Rows(i).FindControl("ddl2"), DropDownList).SelectedValue.Trim
            Dim d3 As String = DirectCast(grdsection.Rows(i).FindControl("ddl3"), DropDownList).SelectedValue.Trim
            Dim d4 As String = DirectCast(grdsection.Rows(i).FindControl("ddl4"), DropDownList).SelectedValue.Trim
            Dim d5 As String = DirectCast(grdsection.Rows(i).FindControl("ddl5"), DropDownList).SelectedValue.Trim
            Dim d6 As String = DirectCast(grdsection.Rows(i).FindControl("ddl6"), DropDownList).SelectedValue.Trim
            Dim d7 As String = DirectCast(grdsection.Rows(i).FindControl("ddl7"), DropDownList).SelectedValue.Trim
            Dim d8 As String = DirectCast(grdsection.Rows(i).FindControl("ddl8"), DropDownList).SelectedValue.Trim
            Dim d9 As String = DirectCast(grdsection.Rows(i).FindControl("ddl9"), DropDownList).SelectedValue.Trim
            Dim d10 As String = DirectCast(grdsection.Rows(i).FindControl("ddl10"), DropDownList).SelectedValue.Trim
            Dim d11 As String = DirectCast(grdsection.Rows(i).FindControl("ddl11"), DropDownList).SelectedValue.Trim
            Dim d12 As String = DirectCast(grdsection.Rows(i).FindControl("ddl12"), DropDownList).SelectedValue.Trim
            Dim d13 As String = DirectCast(grdsection.Rows(i).FindControl("ddl13"), DropDownList).SelectedValue.Trim
            Dim d14 As String = DirectCast(grdsection.Rows(i).FindControl("ddl14"), DropDownList).SelectedValue.Trim
            Dim d15 As String = DirectCast(grdsection.Rows(i).FindControl("ddl15"), DropDownList).SelectedValue.Trim
            Dim d16 As String = DirectCast(grdsection.Rows(i).FindControl("ddl16"), DropDownList).SelectedValue.Trim
            Dim d17 As String = DirectCast(grdsection.Rows(i).FindControl("ddl17"), DropDownList).SelectedValue.Trim
            Dim d18 As String = DirectCast(grdsection.Rows(i).FindControl("ddl18"), DropDownList).SelectedValue.Trim
            Dim d19 As String = DirectCast(grdsection.Rows(i).FindControl("ddl19"), DropDownList).SelectedValue.Trim
            Dim d20 As String = DirectCast(grdsection.Rows(i).FindControl("ddl20"), DropDownList).SelectedValue.Trim

            Try
                MyGlobal.Open_Con()
                MyGlobal.Con_Str()
                Call MyGlobal.dbSp_open("HRMIs_InsertPR")

                Cmd.Parameters.AddWithValue("@empcode", Emp)
                Cmd.Parameters.AddWithValue("@departmentcode", dept)
                Cmd.Parameters.AddWithValue("@sectioncode", sect)
                Cmd.Parameters.AddWithValue("@fromdate", lblfrom.Text)
                Cmd.Parameters.AddWithValue("@todate", lblto.Text)
                Cmd.Parameters.AddWithValue("@keyinby", Session("empcode"))
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
                Cmd.Parameters.AddWithValue("@groupcode", grp)
                Cmd.Parameters.AddWithValue("@category", "")

                Cmd.ExecuteNonQuery()

                '' to PR1

               

                Call MyGlobal.dbSp_open("HRMIs_InsertPR1")

                Cmd.Parameters.AddWithValue("@empcode", Emp)
                Cmd.Parameters.AddWithValue("@departmentcode", dept)
                Cmd.Parameters.AddWithValue("@sectioncode", sect)
                Cmd.Parameters.AddWithValue("@fromdate", lblfrom.Text)
                Cmd.Parameters.AddWithValue("@todate", lblto.Text)
                Cmd.Parameters.AddWithValue("@keyinby", Session("empcode"))
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
                Cmd.Parameters.AddWithValue("@groupcode", grp)
                Cmd.Parameters.AddWithValue("@category", "")

                Cmd.ExecuteNonQuery()

            Catch ex As SqlException
                MessageBox(ex.Message)
                Exit Sub
            End Try
        Next
        MessageBox("Record Updated")
        grdsection.Visible = True
        grdsection.DataBind()
    End Sub

    Protected Sub rdooptions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdooptions.SelectedIndexChanged
        GridView2.Visible = False
        grdsection.Visible = False

        If rdooptions.SelectedValue = "emp" Then
            txtempcode.Text = ""
            ddlsect.Enabled = False
            txtempcode.Enabled = True
            lblename.Text = ""
            lblsect.Text = ""
            lbldept.Text = ""
            lbldesig.Text = ""
            lblstatus.Text = ""
            ' DropDownList1.Enabled = False
        ElseIf rdooptions.SelectedValue = "section" Then
            txtempcode.Text = ""
            ddlsect.Enabled = True
            txtempcode.Enabled = False
            '  DropDownList1.Enabled = False

        End If

    End Sub

    Public Sub Getshiftbygroup(ByVal sender As Object, ByVal e As EventArgs)

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

        Dim dsPR As DataSet
        Dim drPR, DRPRMON As DataRow
        Dim myshift, Prday
        Dim myday As New ArrayList
        Dim j
        Dim mthdays
        Dim str

        Dim ddl As DropDownList = DirectCast(sender, DropDownList)
        Dim row As GridViewRow = TryCast(ddl.NamingContainer, GridViewRow)
        Dim grp As String = (CType(row.FindControl("ddlgridgrp"), DropDownList).SelectedValue)
        Dim Egrp As String = (CType(row.FindControl("lblggrp"), Label).Text)

        dsPR = GetShift(fd, td, grp)
        If dsPR.Tables(0).Rows.Count <> 0 Then
            For j = 0 To dsPR.Tables(0).Rows.Count - 1
                drPR = dsPR.Tables(0).Rows(j)
                If Not drPR("shiftcode") Is System.DBNull.Value Then
                    myshift = drPR("shiftcode")
                    myday.Add(myshift)
                Else
                    myshift = ""
                End If
            Next

            If myday.Count = 30 Then
                '02.01.2012 commented below 21 to 30 to display for the new payroll month as 01 to 31 & displaying at bottom
                DirectCast(row.FindControl("ddl21"), DropDownList).SelectedValue = myday(20)
                DirectCast(row.FindControl("ddl22"), DropDownList).SelectedValue = myday(21)
                DirectCast(row.FindControl("ddl23"), DropDownList).SelectedValue = myday(22)
                DirectCast(row.FindControl("ddl24"), DropDownList).SelectedValue = myday(23)
                DirectCast(row.FindControl("ddl25"), DropDownList).SelectedValue = myday(24)
                DirectCast(row.FindControl("ddl26"), DropDownList).SelectedValue = myday(25)
                DirectCast(row.FindControl("ddl27"), DropDownList).SelectedValue = myday(26)
                DirectCast(row.FindControl("ddl28"), DropDownList).SelectedValue = myday(27)
                DirectCast(row.FindControl("ddl29"), DropDownList).SelectedValue = myday(28)
                DirectCast(row.FindControl("ddl30"), DropDownList).SelectedValue = myday(29)
                DirectCast(row.FindControl("ddl31"), DropDownList).SelectedValue = "NA"
                DirectCast(row.FindControl("ddl1"), DropDownList).SelectedValue = myday(0)
                DirectCast(row.FindControl("ddl2"), DropDownList).SelectedValue = myday(1)
                DirectCast(row.FindControl("ddl3"), DropDownList).SelectedValue = myday(2)
                DirectCast(row.FindControl("ddl4"), DropDownList).SelectedValue = myday(3)
                DirectCast(row.FindControl("ddl5"), DropDownList).SelectedValue = myday(4)
                DirectCast(row.FindControl("ddl6"), DropDownList).SelectedValue = myday(5)
                DirectCast(row.FindControl("ddl7"), DropDownList).SelectedValue = myday(6)
                DirectCast(row.FindControl("ddl8"), DropDownList).SelectedValue = myday(7)
                DirectCast(row.FindControl("ddl9"), DropDownList).SelectedValue = myday(8)
                DirectCast(row.FindControl("ddl10"), DropDownList).SelectedValue = myday(9)
                DirectCast(row.FindControl("ddl11"), DropDownList).SelectedValue = myday(10)
                DirectCast(row.FindControl("ddl12"), DropDownList).SelectedValue = myday(11)
                DirectCast(row.FindControl("ddl13"), DropDownList).SelectedValue = myday(12)
                DirectCast(row.FindControl("ddl14"), DropDownList).SelectedValue = myday(13)
                DirectCast(row.FindControl("ddl15"), DropDownList).SelectedValue = myday(14)
                DirectCast(row.FindControl("ddl16"), DropDownList).SelectedValue = myday(15)
                DirectCast(row.FindControl("ddl17"), DropDownList).SelectedValue = myday(16)
                DirectCast(row.FindControl("ddl18"), DropDownList).SelectedValue = myday(17)
                DirectCast(row.FindControl("ddl19"), DropDownList).SelectedValue = myday(18)
                DirectCast(row.FindControl("ddl20"), DropDownList).SelectedValue = myday(19)
                DirectCast(row.FindControl("lblggrp"), Label).Text = grp
            ElseIf myday.Count = 29 Then
                DirectCast(row.FindControl("ddl21"), DropDownList).SelectedValue = myday(20)
                DirectCast(row.FindControl("ddl22"), DropDownList).SelectedValue = myday(21)
                DirectCast(row.FindControl("ddl23"), DropDownList).SelectedValue = myday(22)
                DirectCast(row.FindControl("ddl24"), DropDownList).SelectedValue = myday(23)
                DirectCast(row.FindControl("ddl25"), DropDownList).SelectedValue = myday(24)
                DirectCast(row.FindControl("ddl26"), DropDownList).SelectedValue = myday(25)
                DirectCast(row.FindControl("ddl27"), DropDownList).SelectedValue = myday(26)
                DirectCast(row.FindControl("ddl28"), DropDownList).SelectedValue = myday(27)
                DirectCast(row.FindControl("ddl29"), DropDownList).SelectedValue = myday(28)
                DirectCast(row.FindControl("ddl30"), DropDownList).SelectedValue = "NA"
                DirectCast(row.FindControl("ddl31"), DropDownList).SelectedValue = "NA"
                DirectCast(row.FindControl("ddl1"), DropDownList).SelectedValue = myday(0)
                DirectCast(row.FindControl("ddl2"), DropDownList).SelectedValue = myday(1)
                DirectCast(row.FindControl("ddl3"), DropDownList).SelectedValue = myday(2)
                DirectCast(row.FindControl("ddl4"), DropDownList).SelectedValue = myday(3)
                DirectCast(row.FindControl("ddl5"), DropDownList).SelectedValue = myday(4)
                DirectCast(row.FindControl("ddl6"), DropDownList).SelectedValue = myday(5)
                DirectCast(row.FindControl("ddl7"), DropDownList).SelectedValue = myday(6)
                DirectCast(row.FindControl("ddl8"), DropDownList).SelectedValue = myday(7)
                DirectCast(row.FindControl("ddl9"), DropDownList).SelectedValue = myday(8)
                DirectCast(row.FindControl("ddl10"), DropDownList).SelectedValue = myday(9)
                DirectCast(row.FindControl("ddl11"), DropDownList).SelectedValue = myday(10)
                DirectCast(row.FindControl("ddl12"), DropDownList).SelectedValue = myday(11)
                DirectCast(row.FindControl("ddl13"), DropDownList).SelectedValue = myday(12)
                DirectCast(row.FindControl("ddl14"), DropDownList).SelectedValue = myday(13)
                DirectCast(row.FindControl("ddl15"), DropDownList).SelectedValue = myday(14)
                DirectCast(row.FindControl("ddl16"), DropDownList).SelectedValue = myday(15)
                DirectCast(row.FindControl("ddl17"), DropDownList).SelectedValue = myday(16)
                DirectCast(row.FindControl("ddl18"), DropDownList).SelectedValue = myday(17)
                DirectCast(row.FindControl("ddl19"), DropDownList).SelectedValue = myday(18)
                DirectCast(row.FindControl("ddl20"), DropDownList).SelectedValue = myday(19)
                DirectCast(row.FindControl("lblggrp"), Label).Text = grp
            ElseIf myday.Count = 28 Then
                DirectCast(row.FindControl("ddl21"), DropDownList).SelectedValue = myday(20)
                DirectCast(row.FindControl("ddl22"), DropDownList).SelectedValue = myday(21)
                DirectCast(row.FindControl("ddl23"), DropDownList).SelectedValue = myday(22)
                DirectCast(row.FindControl("ddl24"), DropDownList).SelectedValue = myday(23)
                DirectCast(row.FindControl("ddl25"), DropDownList).SelectedValue = myday(24)
                DirectCast(row.FindControl("ddl26"), DropDownList).SelectedValue = myday(25)
                DirectCast(row.FindControl("ddl27"), DropDownList).SelectedValue = myday(26)
                DirectCast(row.FindControl("ddl28"), DropDownList).SelectedValue = myday(27)
                DirectCast(row.FindControl("ddl29"), DropDownList).SelectedValue = "NA"
                DirectCast(row.FindControl("ddl30"), DropDownList).SelectedValue = "NA"
                DirectCast(row.FindControl("ddl31"), DropDownList).SelectedValue = "NA"
                DirectCast(row.FindControl("ddl1"), DropDownList).SelectedValue = myday(0)
                DirectCast(row.FindControl("ddl2"), DropDownList).SelectedValue = myday(1)
                DirectCast(row.FindControl("ddl3"), DropDownList).SelectedValue = myday(2)
                DirectCast(row.FindControl("ddl4"), DropDownList).SelectedValue = myday(3)
                DirectCast(row.FindControl("ddl5"), DropDownList).SelectedValue = myday(4)
                DirectCast(row.FindControl("ddl6"), DropDownList).SelectedValue = myday(5)
                DirectCast(row.FindControl("ddl7"), DropDownList).SelectedValue = myday(6)
                DirectCast(row.FindControl("ddl8"), DropDownList).SelectedValue = myday(7)
                DirectCast(row.FindControl("ddl9"), DropDownList).SelectedValue = myday(8)
                DirectCast(row.FindControl("ddl10"), DropDownList).SelectedValue = myday(9)
                DirectCast(row.FindControl("ddl11"), DropDownList).SelectedValue = myday(10)
                DirectCast(row.FindControl("ddl12"), DropDownList).SelectedValue = myday(11)
                DirectCast(row.FindControl("ddl13"), DropDownList).SelectedValue = myday(12)
                DirectCast(row.FindControl("ddl14"), DropDownList).SelectedValue = myday(13)
                DirectCast(row.FindControl("ddl15"), DropDownList).SelectedValue = myday(14)
                DirectCast(row.FindControl("ddl16"), DropDownList).SelectedValue = myday(15)
                DirectCast(row.FindControl("ddl17"), DropDownList).SelectedValue = myday(16)
                DirectCast(row.FindControl("ddl18"), DropDownList).SelectedValue = myday(17)
                DirectCast(row.FindControl("ddl19"), DropDownList).SelectedValue = myday(18)
                DirectCast(row.FindControl("ddl20"), DropDownList).SelectedValue = myday(19)
                DirectCast(row.FindControl("lblggrp"), Label).Text = grp
            ElseIf myday.Count = 31 Then
                DirectCast(row.FindControl("ddl21"), DropDownList).SelectedValue = myday(20)
                DirectCast(row.FindControl("ddl22"), DropDownList).SelectedValue = myday(21)
                DirectCast(row.FindControl("ddl23"), DropDownList).SelectedValue = myday(22)
                DirectCast(row.FindControl("ddl24"), DropDownList).SelectedValue = myday(23)
                DirectCast(row.FindControl("ddl25"), DropDownList).SelectedValue = myday(24)
                DirectCast(row.FindControl("ddl26"), DropDownList).SelectedValue = myday(25)
                DirectCast(row.FindControl("ddl27"), DropDownList).SelectedValue = myday(26)
                DirectCast(row.FindControl("ddl28"), DropDownList).SelectedValue = myday(27)
                DirectCast(row.FindControl("ddl29"), DropDownList).SelectedValue = myday(28)
                DirectCast(row.FindControl("ddl30"), DropDownList).SelectedValue = myday(29)
                DirectCast(row.FindControl("ddl31"), DropDownList).SelectedValue = myday(30)
                DirectCast(row.FindControl("ddl1"), DropDownList).SelectedValue = myday(0)
                DirectCast(row.FindControl("ddl2"), DropDownList).SelectedValue = myday(1)
                DirectCast(row.FindControl("ddl3"), DropDownList).SelectedValue = myday(2)
                DirectCast(row.FindControl("ddl4"), DropDownList).SelectedValue = myday(3)
                DirectCast(row.FindControl("ddl5"), DropDownList).SelectedValue = myday(4)
                DirectCast(row.FindControl("ddl6"), DropDownList).SelectedValue = myday(5)
                DirectCast(row.FindControl("ddl7"), DropDownList).SelectedValue = myday(6)
                DirectCast(row.FindControl("ddl8"), DropDownList).SelectedValue = myday(7)
                DirectCast(row.FindControl("ddl9"), DropDownList).SelectedValue = myday(8)
                DirectCast(row.FindControl("ddl10"), DropDownList).SelectedValue = myday(9)
                DirectCast(row.FindControl("ddl11"), DropDownList).SelectedValue = myday(10)
                DirectCast(row.FindControl("ddl12"), DropDownList).SelectedValue = myday(11)
                DirectCast(row.FindControl("ddl13"), DropDownList).SelectedValue = myday(12)
                DirectCast(row.FindControl("ddl14"), DropDownList).SelectedValue = myday(13)
                DirectCast(row.FindControl("ddl15"), DropDownList).SelectedValue = myday(14)
                DirectCast(row.FindControl("ddl16"), DropDownList).SelectedValue = myday(15)
                DirectCast(row.FindControl("ddl17"), DropDownList).SelectedValue = myday(16)
                DirectCast(row.FindControl("ddl18"), DropDownList).SelectedValue = myday(17)
                DirectCast(row.FindControl("ddl19"), DropDownList).SelectedValue = myday(18)
                DirectCast(row.FindControl("ddl20"), DropDownList).SelectedValue = myday(19)
                DirectCast(row.FindControl("lblggrp"), Label).Text = grp
            End If
            'lblgrp.Text = grp

        Else
            lblmsg.Text = "There is no calender setting for the group " & grp & " on the selected date."
            lblmsg.ForeColor = Drawing.Color.Red
            DirectCast(row.FindControl("ddlgridgrp"), DropDownList).SelectedValue = DirectCast(row.FindControl("lblggrp"), Label).Text
        End If
    End Sub

    Function GetShift(ByVal fd As Date, ByVal td As Date, ByVal grp As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("SELECT shiftdate,shiftcode FROM trans_shiftfinal WHERE (groupcode='" & grp & "') AND (shiftdate BETWEEN '" & fd & "' and '" & td & "') order by shiftdate", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "Shift")
        con.Close()
        Return ds
    End Function

    Private Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowDataBound
        Dim keyindt = DateTime.Now.Day
        Dim y, m

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

        lblfrom.Text = fd
        lblto.Text = td
        Dim startdt
        Dim enddt
        startdt = Day(fd)
        enddt = Day(td)

        m = strdate(1)
        y = strdate(2)

        Dim dm = System.DateTime.DaysInMonth(y, m)

        If dm = "30" Then
            If e.Row.RowType = DataControlRowType.Header Then
                e.Row.Cells(35).Visible = False
            End If
            If e.Row.RowType = DataControlRowType.DataRow Then
                e.Row.Cells(35).Visible = False
            End If
            If e.Row.RowType = DataControlRowType.Footer Then
                e.Row.Cells(35).Visible = False
            End If

        ElseIf dm = "28" Then
            If e.Row.RowType = DataControlRowType.Header Then
                e.Row.Cells(35).Visible = False
                e.Row.Cells(34).Visible = False
                e.Row.Cells(33).Visible = False
            End If
            If e.Row.RowType = DataControlRowType.DataRow Then
                e.Row.Cells(35).Visible = False
                e.Row.Cells(34).Visible = False
                e.Row.Cells(33).Visible = False
            End If
            If e.Row.RowType = DataControlRowType.Footer Then
                e.Row.Cells(35).Visible = False
                e.Row.Cells(34).Visible = False
                e.Row.Cells(33).Visible = False
            End If

        ElseIf dm = "29" Then
            If e.Row.RowType = DataControlRowType.Header Then
                e.Row.Cells(35).Visible = False
                e.Row.Cells(34).Visible = False
            End If
            If e.Row.RowType = DataControlRowType.DataRow Then
                e.Row.Cells(35).Visible = False
                e.Row.Cells(34).Visible = False
            End If
            If e.Row.RowType = DataControlRowType.Footer Then
                e.Row.Cells(35).Visible = False
                e.Row.Cells(34).Visible = False
            End If

        End If
    End Sub

    Private Sub grdsection_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdsection.RowDataBound
        Dim keyindt = DateTime.Now.Day
        Dim y, m

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

        lblfrom.Text = fd
        lblto.Text = td
        Dim startdt
        Dim enddt
        startdt = Day(fd)
        enddt = Day(td)

        m = strdate(1)
        y = strdate(2)

        Dim dm = System.DateTime.DaysInMonth(y, m)

        If dm = "30" Then
            If e.Row.RowType = DataControlRowType.Header Then
                e.Row.Cells(37).Visible = False
            End If
            If e.Row.RowType = DataControlRowType.DataRow Then
                e.Row.Cells(37).Visible = False
            End If
            If e.Row.RowType = DataControlRowType.Footer Then
                e.Row.Cells(37).Visible = False
            End If

        ElseIf dm = "28" Then
            If e.Row.RowType = DataControlRowType.Header Then
                e.Row.Cells(35).Visible = False
                e.Row.Cells(37).Visible = False
                e.Row.Cells(36).Visible = False
            End If
            If e.Row.RowType = DataControlRowType.DataRow Then
                e.Row.Cells(35).Visible = False
                e.Row.Cells(37).Visible = False
                e.Row.Cells(36).Visible = False
            End If
            If e.Row.RowType = DataControlRowType.Footer Then
                e.Row.Cells(35).Visible = False
                e.Row.Cells(37).Visible = False
                e.Row.Cells(36).Visible = False
            End If

        ElseIf dm = "29" Then
            If e.Row.RowType = DataControlRowType.Header Then
                e.Row.Cells(37).Visible = False
                e.Row.Cells(36).Visible = False
            End If
            If e.Row.RowType = DataControlRowType.DataRow Then
                e.Row.Cells(37).Visible = False
                e.Row.Cells(36).Visible = False
            End If
            If e.Row.RowType = DataControlRowType.Footer Then
                e.Row.Cells(37).Visible = False
                e.Row.Cells(36).Visible = False
            End If

        End If
    End Sub

End Class