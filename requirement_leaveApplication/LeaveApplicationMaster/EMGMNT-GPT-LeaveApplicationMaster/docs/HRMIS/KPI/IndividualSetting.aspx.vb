Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class IndividualSetting
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim rno
    Dim mon
    Dim yr
    Dim i, j, k, l
    Private Sub IndividualSetting_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        getDetails()
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
            MyScreenId = (76)
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
      

        mon = Date.Now.Month


        lblmon.Text = mon
        If Not IsPostBack Then

            If mon = "4" Or mon = "5" Or mon = "6" Then
                DropDownList1.SelectedValue = "Q1"
                q1.Text = "true"
                Q2.Text = "false"
                q3.Text = "false"
                q4.Text = "false"
            ElseIf mon = "7" Or mon = "8" Or mon = "9" Then
                DropDownList1.SelectedValue = "Q2"
                q1.Text = "false"
                Q2.Text = "true"
                q3.Text = "false"
                q4.Text = "false"
            ElseIf mon = "10" Or mon = "11" Or mon = "12" Then
                DropDownList1.SelectedValue = "Q3"
                q1.Text = "false"
                Q2.Text = "false"
                q3.Text = "true"
                q4.Text = "false"
            ElseIf mon = "1" Or mon = "2" Or mon = "3" Then
                DropDownList1.SelectedValue = "Q4"
                q1.Text = "false"
                Q2.Text = "false"
                q3.Text = "false"
                q4.Text = "true"
            End If
        End If

        If Not IsPostBack Then

            Dim dsrev As DataSet
            Dim drrev As DataRow

            dsrev = GetRevno()

            If dsrev.Tables(0).Rows.Count > 0 Then
                drrev = dsrev.Tables(0).Rows(0)
                If Not drrev("revi") Is System.DBNull.Value Then
                    lblrev.Text = drrev("revi").ToString
                    lblrev1.Text = drrev("revi").ToString
                    btnRevise.Enabled = True
                    btnsave.Visible = False
                Else
                    lblrev.Text = "-1"
                    lblrev1.Text = "0"
                    btnRevise.Enabled = False
                    btnsave.Visible = True
                End If
            End If
            If lblrev.Text = "-1" Then
                btnRevise.Enabled = False
                btnsave.Visible = True
            End If
            LoadGrid()
        End If



    End Sub
    Private Sub LoadGrid()
        mon = Date.Now.Month
        'yr = Date.Now.Year
        Dim qtr = DropDownList1.SelectedValue.Trim
        If qtr = "q4" Or qtr = "Q4" Then
            yr = _fisyrStart.Year
        Else
            yr = Date.Now.Year
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

        '''''' get KPI records for HOD

        If lvl >= 4 Then
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

                    mjrno = drkpi("Major_KPINO").ToString
                    mjr = drkpi("Major_kpidetails").ToString
                    weight = drkpi("weightage")

                    Try
                        MyGlobal.Open_Con()
                        MyGlobal.Con_Str()
                        Call MyGlobal.dbSp_open("hrmis_kpi_individual_initialise_hod_new")

                        Cmd.Parameters.AddWithValue("@Major_KPINO", mjrno)
                        Cmd.Parameters.AddWithValue("@MajorKPI_Details", mjr)
                        Cmd.Parameters.AddWithValue("@SubKPI_Details", "")
                        Cmd.Parameters.AddWithValue("@Sub_KPINO", "")

                        Cmd.Parameters.AddWithValue("@q1", "True")
                        Cmd.Parameters.AddWithValue("@q2", "True")
                        Cmd.Parameters.AddWithValue("@q3", "True")
                        Cmd.Parameters.AddWithValue("@q4", "True")

                        Cmd.Parameters.AddWithValue("@uom", "%")
                        Cmd.Parameters.AddWithValue("@curent", "0")
                        Cmd.Parameters.AddWithValue("@target", drkpi("weightage"))
                        Cmd.Parameters.AddWithValue("@individual", drkpi("individual"))


                        Cmd.Parameters.AddWithValue("@Employee_Code", Session("empcode"))
                        Cmd.Parameters.AddWithValue("@Department_Code", Session("_edept"))
                        Cmd.Parameters.AddWithValue("@KPI_Year", yr)
                        Cmd.Parameters.AddWithValue("@qtr", qtr)
                        Cmd.Parameters.AddWithValue("@revision", lblrev.Text)
                        Cmd.Parameters.AddWithValue("@KPI_month", mon)
                        Cmd.Parameters.AddWithValue("@upd", drkpi("updbasis"))

                        Cmd.ExecuteNonQuery()
                    Catch ex As SqlException
                        MessageBox(ex.Message)
                    End Try
                Next
            End If
        Else
            Dim dskpi As DataSet
            Dim drkpi As DataRow
            Dim mjr, subkpi
            Dim mjrno, subno
            Dim q1, q2, q3, q4
            Dim cur, tar, weight
            Dim uom
            Dim indi
            Dim A, B, C, D As Boolean

            dskpi = GetKPIRecords2()
            If dskpi.Tables(0).Rows.Count > 0 Then
                For j = 0 To dskpi.Tables(0).Rows.Count - 1

                    drkpi = dskpi.Tables(0).Rows(j)

                    Try
                        MyGlobal.Open_Con()
                        MyGlobal.Con_Str()
                        Call MyGlobal.dbSp_open("hrmis_kpi_individual_initialise_new")

                        Cmd.Parameters.AddWithValue("@Major_KPINO", drkpi("Major_KPINO").ToString)
                        Cmd.Parameters.AddWithValue("@MajorKPI_Details", drkpi("Majorkpi_details").ToString)
                        Cmd.Parameters.AddWithValue("@SubKPI_Details", drkpi("subKPI_details").ToString)
                        Cmd.Parameters.AddWithValue("@Sub_KPINO", drkpi("sub_KPIno").ToString)

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
                        Cmd.Parameters.AddWithValue("@KPI_Year", yr)
                        Cmd.Parameters.AddWithValue("@KPI_month", mon)
                        Cmd.Parameters.AddWithValue("@revision", lblrev.Text)
                        Cmd.Parameters.AddWithValue("@qtr", qtr)
                        Cmd.Parameters.AddWithValue("@upd", drkpi("updbasis"))

                        Cmd.ExecuteNonQuery()

                    Catch ex As SqlException
                        MessageBox(ex.Message)
                    End Try
                Next
            End If
        End If
        grddaily.DataBind()
        grdmonthly.DataBind()
        grdweekly.DataBind()

    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Function GetRevno() As DataSet

        Dim qtr = DropDownList1.SelectedValue.Trim
   

        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select max(revision) as revi from KPI_IndividualSetting where employee_code='" & Session("empcode") & "' and quarter='" & DropDownList1.SelectedValue.Trim & "' and kpi_year='" & yr & "'", con)
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

    Function GetKPIRecords() As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from dbo.KPI_MajorSetting where individual='yes' and department_code='" & Session("_edept") & "' and employee_code='" & Session("empcode") & "'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "KPIRec")
        con.Close()
        Return ds
    End Function
    Function GetKPIRecords2() As DataSet
        Dim sqltext
        mon = Date.Now.Month
        ' yr = Date.Now.Year
        Dim qtr = DropDownList1.SelectedValue.Trim
       

        'If mon = "4" Or mon = "5" Or mon = "6" Then
        if qtr = "Q1"
            sqltext = "select * from dbo.KPI_SubSetting where department_code='" & Session("_edept") & "' and employee_code='" & Session("empcode") & "' and (status = 'A' or status = 'a') and q1 ='True'"
        ElseIf qtr = "Q2" Then
            sqltext = "select * from dbo.KPI_SubSetting where department_code='" & Session("_edept") & "' and employee_code='" & Session("empcode") & "' and (status = 'A' or status = 'a') and q2 ='True'"
        ElseIf qtr = "Q3" Then
            sqltext = "select * from dbo.KPI_SubSetting where department_code='" & Session("_edept") & "' and employee_code='" & Session("empcode") & "' and (status = 'A' or status = 'a') and q3 ='True'"
        ElseIf qtr = "Q4" Then
            sqltext = "select * from dbo.KPI_SubSetting where department_code='" & Session("_edept") & "' and employee_code='" & Session("empcode") & "' and (status = 'A' or status = 'a') and q4 ='True'"
        End If

        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand(sqltext, con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "KPIRec")
        con.Close()
        Return ds
    End Function

    Protected Sub btnRevise_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRevise.Click
        Dim dsrev As DataSet
        Dim drrev As DataRow
        Dim qtr = DropDownList1.SelectedValue.Trim
        Dim rev

        dsrev = GetRevno()

        If dsrev.Tables(0).Rows.Count > 0 Then
            drrev = dsrev.Tables(0).Rows(0)
            rev = drrev("revi").ToString
            lblrev.Text = rev + 1
            lblrev1.Text = rev + 1
        End If
        LoadGrid()
        btnRevise.Enabled = False
        btnsave.Visible = True
    End Sub
    Protected Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Dim ds As DataSet
        Dim val

        Dim rev

        If lblrev1.Text = "-1" Then
            rev = "0"
        Else
            rev = lblrev1.Text
        End If

        If lbltot.Text > 100 Then
            MessageBox("Your total weightage should not exceed 100")
            Exit Sub
        ElseIf lbltot.Text < 100 Then
            MessageBox("Your total weightage should not be less than 100")
            Exit Sub
        End If

        For i As Integer = 0 To grddaily.Rows.Count - 1
            Dim sno As String = grddaily.Rows(i).Cells(0).Text
            Dim weightage As String = DirectCast(grddaily.Rows(i).FindControl("txtweight1"), TextBox).Text
            Dim eligible As CheckBox = DirectCast(grddaily.Rows(i).FindControl("CheckBox1"), CheckBox)
            Dim target As String = grddaily.Rows(i).Cells(4).Text

            If eligible.Checked = True Then
                val = "-1"
            Else
                val = "0"
                weightage = "0"
            End If

            'Dim d1 As String = DirectCast(grddaily.Rows(i).FindControl("txt1"), TextBox).Text
            'Dim d2 As String = DirectCast(grddaily.Rows(i).FindControl("txt2"), TextBox).Text
            'Dim d3 As String = DirectCast(grddaily.Rows(i).FindControl("txt3"), TextBox).Text
            'Dim d4 As String = DirectCast(grddaily.Rows(i).FindControl("txt4"), TextBox).Text
            'Dim d5 As String = DirectCast(grddaily.Rows(i).FindControl("txt5"), TextBox).Text
            'Dim d6 As String = DirectCast(grddaily.Rows(i).FindControl("txt6"), TextBox).Text
            'Dim d7 As String = DirectCast(grddaily.Rows(i).FindControl("txt7"), TextBox).Text
            'Dim d8 As String = DirectCast(grddaily.Rows(i).FindControl("txt8"), TextBox).Text
            'Dim d9 As String = DirectCast(grddaily.Rows(i).FindControl("txt9"), TextBox).Text
            'Dim d10 As String = DirectCast(grddaily.Rows(i).FindControl("txt10"), TextBox).Text
            'Dim d11 As String = DirectCast(grddaily.Rows(i).FindControl("txt11"), TextBox).Text
            'Dim d12 As String = DirectCast(grddaily.Rows(i).FindControl("txt12"), TextBox).Text
            'Dim d13 As String = DirectCast(grddaily.Rows(i).FindControl("txt13"), TextBox).Text
            'Dim d14 As String = DirectCast(grddaily.Rows(i).FindControl("txt14"), TextBox).Text
            'Dim d15 As String = DirectCast(grddaily.Rows(i).FindControl("txt15"), TextBox).Text
            'Dim d16 As String = DirectCast(grddaily.Rows(i).FindControl("txt16"), TextBox).Text
            'Dim d17 As String = DirectCast(grddaily.Rows(i).FindControl("txt17"), TextBox).Text
            'Dim d18 As String = DirectCast(grddaily.Rows(i).FindControl("txt18"), TextBox).Text
            'Dim d19 As String = DirectCast(grddaily.Rows(i).FindControl("txt19"), TextBox).Text
            'Dim d20 As String = DirectCast(grddaily.Rows(i).FindControl("txt20"), TextBox).Text
            'Dim d21 As String = DirectCast(grddaily.Rows(i).FindControl("txt21"), TextBox).Text
            'Dim d22 As String = DirectCast(grddaily.Rows(i).FindControl("txt22"), TextBox).Text
            'Dim d23 As String = DirectCast(grddaily.Rows(i).FindControl("txt23"), TextBox).Text
            'Dim d24 As String = DirectCast(grddaily.Rows(i).FindControl("txt24"), TextBox).Text
            'Dim d25 As String = DirectCast(grddaily.Rows(i).FindControl("txt25"), TextBox).Text
            'Dim d26 As String = DirectCast(grddaily.Rows(i).FindControl("txt26"), TextBox).Text
            'Dim d27 As String = DirectCast(grddaily.Rows(i).FindControl("txt27"), TextBox).Text
            'Dim d28 As String = DirectCast(grddaily.Rows(i).FindControl("txt28"), TextBox).Text
            'Dim d29 As String = DirectCast(grddaily.Rows(i).FindControl("txt29"), TextBox).Text
            'Dim d30 As String = DirectCast(grddaily.Rows(i).FindControl("txt30"), TextBox).Text
            'Dim d31 As String = DirectCast(grddaily.Rows(i).FindControl("txt31"), TextBox).Text

      

            Try
                MyGlobal.Open_Con()
                MyGlobal.Con_Str()
                Call MyGlobal.dbSp_open("HRMIs_Update_DailyKPI")

                Cmd.Parameters.AddWithValue("@rno", sno)
                Cmd.Parameters.AddWithValue("@weight", weightage)
                Cmd.Parameters.AddWithValue("@eligible", val)
                Cmd.Parameters.AddWithValue("@day1", target)
                Cmd.Parameters.AddWithValue("@day2", target)
                Cmd.Parameters.AddWithValue("@day3", target)
                Cmd.Parameters.AddWithValue("@day4", target)
                Cmd.Parameters.AddWithValue("@day5", target)
                Cmd.Parameters.AddWithValue("@day6", target)
                Cmd.Parameters.AddWithValue("@day7", target)
                Cmd.Parameters.AddWithValue("@day8", target)
                Cmd.Parameters.AddWithValue("@day9", target)
                Cmd.Parameters.AddWithValue("@day10", target)
                Cmd.Parameters.AddWithValue("@day11", target)
                Cmd.Parameters.AddWithValue("@day12", target)
                Cmd.Parameters.AddWithValue("@day13", target)
                Cmd.Parameters.AddWithValue("@day14", target)
                Cmd.Parameters.AddWithValue("@day15", target)
                Cmd.Parameters.AddWithValue("@day16", target)
                Cmd.Parameters.AddWithValue("@day17", target)
                Cmd.Parameters.AddWithValue("@day18", target)
                Cmd.Parameters.AddWithValue("@day19", target)
                Cmd.Parameters.AddWithValue("@day20", target)
                Cmd.Parameters.AddWithValue("@day21", target)
                Cmd.Parameters.AddWithValue("@day22", target)
                Cmd.Parameters.AddWithValue("@day23", target)
                Cmd.Parameters.AddWithValue("@day24", target)
                Cmd.Parameters.AddWithValue("@day25", target)
                Cmd.Parameters.AddWithValue("@day26", target)
                Cmd.Parameters.AddWithValue("@day27", target)
                Cmd.Parameters.AddWithValue("@day28", target)
                Cmd.Parameters.AddWithValue("@day29", target)
                Cmd.Parameters.AddWithValue("@day30", target)
                Cmd.Parameters.AddWithValue("@day31", target)

                Cmd.Parameters.AddWithValue("@rev", rev)
                Cmd.ExecuteNonQuery()

            Catch ex As SqlException
                MessageBox(ex.Message)
                Exit Sub
            End Try
        Next
        '''' do weekly update
        For i As Integer = 0 To grdweekly.Rows.Count - 1
            Dim sno As String = grdweekly.Rows(i).Cells(0).Text
            Dim weightage As String = DirectCast(grdweekly.Rows(i).FindControl("txtweight2"), TextBox).Text
            Dim eligible As CheckBox = DirectCast(grdweekly.Rows(i).FindControl("CheckBox1"), CheckBox)
            Dim target As String = grdweekly.Rows(i).Cells(4).Text

            If eligible.Checked = True Then
                val = "-1"
            Else
                val = "0"
                weightage = "0"
            End If

            'Dim d1 As String = DirectCast(grdweekly.Rows(i).FindControl("txt1"), TextBox).Text
            'Dim d2 As String = DirectCast(grdweekly.Rows(i).FindControl("txt2"), TextBox).Text
            'Dim d3 As String = DirectCast(grdweekly.Rows(i).FindControl("txt3"), TextBox).Text
            'Dim d4 As String = DirectCast(grdweekly.Rows(i).FindControl("txt4"), TextBox).Text

            Try
                MyGlobal.Open_Con()
                MyGlobal.Con_Str()
                Call MyGlobal.dbSp_open("HRMIs_Update_weekKPI")

                Cmd.Parameters.AddWithValue("@rno", sno)
                Cmd.Parameters.AddWithValue("@weight", weightage)
                Cmd.Parameters.AddWithValue("@eligible", val)
                Cmd.Parameters.AddWithValue("@day1", target)
                Cmd.Parameters.AddWithValue("@day2", target)
                Cmd.Parameters.AddWithValue("@day3", target)
                Cmd.Parameters.AddWithValue("@day4", target)
                Cmd.Parameters.AddWithValue("@rev", lblrev1.Text)

                Cmd.ExecuteNonQuery()
            Catch ex As SqlException
                MessageBox(ex.Message)
                Exit Sub
            End Try
        Next

        '''' do Monthly update
        For i As Integer = 0 To grdmonthly.Rows.Count - 1
            Dim sno As String = grdmonthly.Rows(i).Cells(0).Text
            Dim weightage As String = DirectCast(grdmonthly.Rows(i).FindControl("txtweight3"), TextBox).Text
            Dim eligible As CheckBox = DirectCast(grdmonthly.Rows(i).FindControl("CheckBox1"), CheckBox)
            Dim target As String = grdmonthly.Rows(i).Cells(4).Text
            If eligible.Checked = True Then
                val = "-1"
            Else
                val = "0"
                weightage = "0"
            End If
            ' Dim d1 As String = DirectCast(grdmonthly.Rows(i).FindControl("txt1"), TextBox).Text
            Try
                MyGlobal.Open_Con()
                MyGlobal.Con_Str()
                Call MyGlobal.dbSp_open("HRMIs_Update_monthKPI")
                Cmd.Parameters.AddWithValue("@rno", sno)
                Cmd.Parameters.AddWithValue("@weight", weightage)
                Cmd.Parameters.AddWithValue("@eligible", val)
                Cmd.Parameters.AddWithValue("@day1", target)
                Cmd.Parameters.AddWithValue("@rev", lblrev1.Text)
                Cmd.ExecuteNonQuery()
            Catch ex As SqlException
                MessageBox(ex.Message)
                Exit Sub
            End Try
        Next

        MessageBox("Data Saved Successfully")
        btnsave.Visible = False
        btnRevise.Enabled = True
        grddaily.DataBind()
      
    End Sub

 
    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        If DropDownList1.SelectedValue = "Q1" Then
            q1.Text = "true"
            Q2.Text = "false"
            q3.Text = "false"
            q4.Text = "false"

        ElseIf DropDownList1.SelectedValue = "Q2" Then
            q1.Text = "false"
            Q2.Text = "true"
            q3.Text = "false"
            q4.Text = "false"

        ElseIf DropDownList1.SelectedValue = "Q3" Then
            q1.Text = "false"
            Q2.Text = "false"
            q3.Text = "true"
            q4.Text = "false"

        ElseIf DropDownList1.SelectedValue = "Q4" Then
            q1.Text = "false"
            Q2.Text = "false"
            q3.Text = "false"
            q4.Text = "true"
        End If

        Label2.Text = "0"
        Label3.Text = "0"
        Label4.Text = "0"
        lbltot.Text = "0"

       

        Dim dsrev As DataSet
        Dim drrev As DataRow

        dsrev = GetRevno()

        If dsrev.Tables(0).Rows.Count > 0 Then
            drrev = dsrev.Tables(0).Rows(0)
            If Not drrev("revi") Is System.DBNull.Value Then
                If drrev("revi").ToString = "-1" Then
                    lblrev.Text = drrev("revi").ToString
                    lblrev1.Text = 0
                    btnRevise.Enabled = False
                    btnsave.Visible = True
                Else
                    lblrev.Text = drrev("revi").ToString
                    lblrev1.Text = drrev("revi").ToString
                    btnRevise.Enabled = True
                    btnsave.Visible = False
                End If
            Else
                lblrev.Text = "-1"
                lblrev1.Text = "0"
                btnRevise.Enabled = False
                btnsave.Visible = True
            End If
        End If

        LoadGrid()
    End Sub
    Protected Sub calculateTotal1(ByVal Sender As Object, ByVal e As System.EventArgs)
        'Dim weight As TextBox
        Dim weight As Double
        Dim total As Double
        Dim result As Double

        For i As Integer = 0 To grddaily.Rows.Count - 1
            'weight = DirectCast(GridView1.Rows(i).FindControl("pweight"), TextBox)
            Dim sno As String = grddaily.Rows(i).Cells(0).Text
            Dim weightage As TextBox = DirectCast(grddaily.Rows(i).FindControl("txtweight1"), TextBox)
            'Dim eligible As CheckBox = DirectCast(grddaily.Rows(i).FindControl("CheckBox1"), CheckBox)
            'If eligible.Checked = False Then
            '    weightage.Text = "0"
            'End If
            If weightage.Text = "" Then
                weightage.Text = "0"
            End If
            result = result + Double.Parse(weightage.Text)
            result = Math.Round(Double.Parse(result), 2)
          Next
        DirectCast(grddaily.FooterRow.FindControl("lblweight1"), Label).Text = result
        Label2.Text = result
        lbltot.Text = result + Double.Parse(Label3.Text) + Double.Parse(Label4.Text)
    End Sub
    Protected Sub calculateTotal2(ByVal Sender As Object, ByVal e As System.EventArgs)
        'Dim weight As TextBox
        Dim weight As Double
        Dim total As Double
        Dim result As Double


        For i As Integer = 0 To grdweekly.Rows.Count - 1
            'weight = DirectCast(GridView1.Rows(i).FindControl("pweight"), TextBox)
            Dim sno As String = grdweekly.Rows(i).Cells(0).Text
            Dim weightage As TextBox = DirectCast(grdweekly.Rows(i).FindControl("txtweight2"), TextBox)
            If weightage.Text = "" Then
                weightage.Text = "0"
            End If
            result = result + Double.Parse(weightage.Text)
            result = Math.Round(Double.Parse(result), 2)

        Next
        DirectCast(grdweekly.FooterRow.FindControl("lblweight2"), Label).Text = result
        Label3.Text = result
        lbltot.Text = result + Double.Parse(Label2.Text) + Double.Parse(Label4.Text)
    End Sub
    Protected Sub calculateTotal3(ByVal Sender As Object, ByVal e As System.EventArgs)
        'Dim weight As TextBox
        Dim weight As Double
        Dim total As Double
        Dim result As Double
        For i As Integer = 0 To grdmonthly.Rows.Count - 1
            'weight = DirectCast(GridView1.Rows(i).FindControl("pweight"), TextBox)
            Dim sno As String = grdmonthly.Rows(i).Cells(0).Text
            Dim weightage As TextBox = DirectCast(grdmonthly.Rows(i).FindControl("txtweight3"), TextBox)
            If weightage.Text = "" Then
                weightage.Text = "0"
            End If
            result = result + Double.Parse(weightage.Text)
            result = Math.Round(Double.Parse(result), 2)
        Next
        DirectCast(grdmonthly.FooterRow.FindControl("lblweight3"), Label).Text = result

        Label4.Text = result
        lbltot.Text = result + Label3.Text + Label2.Text
    End Sub

    Protected Sub enabletb(ByVal Sender As Object, ByVal e As System.EventArgs)

        Dim result
        For i As Integer = 0 To grddaily.Rows.Count - 1
            Dim eligible As CheckBox = DirectCast(grddaily.Rows(i).FindControl("CheckBox1"), CheckBox)
            Dim weightage As TextBox = DirectCast(grddaily.Rows(i).FindControl("txtweight1"), TextBox)
            If weightage.Text = "" Then
                weightage.Text = "0"
            End If
            If eligible.Checked = True Then
                DirectCast(grddaily.Rows(i).FindControl("txtweight1"), TextBox).Enabled = True
            Else
                DirectCast(grddaily.Rows(i).FindControl("txtweight1"), TextBox).Enabled = False
                Label2.Text = Double.Parse(Label2.Text) - Double.Parse(weightage.Text)
                If Label2.Text < 0 Then
                    Label2.Text = 0
                End If
                weightage.Text = "0"
            End If
            result = result + Double.Parse(weightage.Text)
            result = Math.Round(Double.Parse(result), 2)
            DirectCast(grddaily.FooterRow.FindControl("lblweight1"), Label).Text = result
            Label2.Text = result

        Next
        lbltot.Text = result + Double.Parse(Label3.Text) + Double.Parse(Label4.Text)
    End Sub

    Protected Sub enabletb2(ByVal Sender As Object, ByVal e As System.EventArgs)
        Dim result
        For i As Integer = 0 To grdweekly.Rows.Count - 1
            Dim eligible As CheckBox = DirectCast(grdweekly.Rows(i).FindControl("CheckBox1"), CheckBox)
            Dim weightage As TextBox = DirectCast(grdweekly.Rows(i).FindControl("txtweight2"), TextBox)
            If weightage.Text = "" Then
                weightage.Text = "0"
            End If
            If eligible.Checked = True Then
                DirectCast(grdweekly.Rows(i).FindControl("txtweight2"), TextBox).Enabled = True
            Else
                DirectCast(grdweekly.Rows(i).FindControl("txtweight2"), TextBox).Enabled = False
                Label3.Text = Double.Parse(Label3.Text) - Double.Parse(weightage.Text)
                If Label3.Text < 0 Then
                    Label3.Text = 0
                End If
                weightage.Text = "0"
            End If
            result = result + Double.Parse(weightage.Text)
            result = Math.Round(Double.Parse(result), 2)
            DirectCast(grdweekly.FooterRow.FindControl("lblweight2"), Label).Text = result
            Label3.Text = result
        Next
        lbltot.Text = result + Double.Parse(Label2.Text) + Double.Parse(Label4.Text)
    End Sub

    Protected Sub enabletb3(ByVal Sender As Object, ByVal e As System.EventArgs)
        Dim result
        For i As Integer = 0 To grdmonthly.Rows.Count - 1
            Dim eligible As CheckBox = DirectCast(grdmonthly.Rows(i).FindControl("CheckBox1"), CheckBox)
            Dim weightage As TextBox = DirectCast(grdmonthly.Rows(i).FindControl("txtweight3"), TextBox)
            If weightage.Text = "" Then
                weightage.Text = "0"
            End If
            If eligible.Checked = True Then
                DirectCast(grdmonthly.Rows(i).FindControl("txtweight3"), TextBox).Enabled = True
            Else
                DirectCast(grdmonthly.Rows(i).FindControl("txtweight3"), TextBox).Enabled = False
                Label4.Text = Double.Parse(Label4.Text) - Double.Parse(weightage.Text)
                If Label4.Text < 0 Then
                    Label4.Text = 0
                End If
                weightage.Text = "0"
            End If
         
            result = result + Double.Parse(weightage.Text)
            result = Math.Round(Double.Parse(result), 2)
            DirectCast(grdmonthly.FooterRow.FindControl("lblweight3"), Label).Text = result
            Label4.Text = result
        Next
        lbltot.Text = result + Double.Parse(Label3.Text) + Double.Parse(Label2.Text)
    End Sub

    Protected Sub Sqlweekly_Selecting(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles Sqlweekly.Selecting

    End Sub
End Class