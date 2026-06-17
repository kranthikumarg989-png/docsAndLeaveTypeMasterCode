Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class StaffAppraisalFinalReport
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim empcode, rno

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        MyApp.GetfiscalYear()

        '  lblempcode.Text = Session("empcode") & "-" & Session("_ename")
        If Not IsPostBack Then
            If Session("empappl") <> "" Then
                txtempcode.Text = Session("empappl")
                txtempcode.Enabled = False
                appdetails()
            Else
                txtempcode.Enabled = True
                Label1.Text = Day(Date.Now) & "/" & Month(Date.Now) & "/" & Year(Date.Now)
            End If
        End If
        'rno = Session("rno")
        txtempcode.Text = Session("employeecode")
        appdetails()
        eadetails()
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    'Protected Sub txtempcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtempcode.TextChanged
    '    appdetails()
    'End Sub
    Private Sub appdetails()

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
                If Not dr("foreignemp").ToString Is System.DBNull.Value Then
                    Session("foreigner") = dr("foreignemp").ToString
                Else
                    Session("foreigner") = "N"
                End If

            Else
                MessageBox("EmployeeCode doesnot Exist!!")
                Exit Sub
            End If
        End If
        '''' Get Key skills of employee
        GetRevno(empcode)
        Dim revno, recno
        revno = posid - 1

        '''''''''''''''''''''''' Get Js Key skills
        GetJS(empcode, revno)
        If recstatus = True Then
            Dim dr1 As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr1 = dsdata.Tables(0).Rows(0)
                recno = dr1("recordno").ToString
                lbljskey.Text = recno
            End If
        Else
            lbljskey.Text = 0
        End If
        grdJg.DataBind()
        grdJg.Visible = True

        ''''' Get Perfomance from app_character setting table
        DelTempChar()
        Dim ds As DataSet
        Dim dr2 As DataRow
        Dim sqltext
        sqltext = "select * from app_charactersetting  where currentyear='Y' and setby='empno' and accesscode='" & txtempcode.Text.Trim & "'"
        ds = GetappCharactersetting(sqltext)
        If ds.Tables(0).Rows.Count = 0 Then
            sqltext = "select *  from app_charactersetting  where currentyear='Y' and setby='sect' and accesscode='" & lblsect.Text & "'"
            ds = GetappCharactersetting(sqltext)
            If ds.Tables(0).Rows.Count = 0 Then
                sqltext = "select * from app_charactersetting  where currentyear='Y' and setby='dept' and accesscode='" & lbldept.Text & "'"
                ds = GetappCharactersetting(sqltext)
                If ds.Tables(0).Rows.Count = 0 Then
                    sqltext = "select *  from app_charactersetting  where currentyear='Y' and setby='all'"
                    ds = GetappCharactersetting(sqltext)
                End If
            End If
        End If
        Dim i
        Dim perf
        Dim per1, per2, per3, per4, per5
        If ds.Tables(0).Rows.Count <> 0 Then
            dr2 = ds.Tables(0).Rows(0)
            per1 = dr2("cbtitle1") & "-" & dr2("cbdescription1")
            per2 = dr2("cbtitle2") & "-" & dr2("cbdescription2")
            per3 = dr2("cbtitle3") & "-" & dr2("cbdescription3")
            per4 = dr2("cbtitle4") & "-" & dr2("cbdescription4")
            per5 = dr2("cbtitle5") & "-" & dr2("cbdescription5")

            MyGlobal.Open_Con()
            MyGlobal.Con_Str()

            For i = 1 To 5
                Call MyGlobal.dbSp_open("hrmis_ins_appchartemp")
                Cmd.Parameters.AddWithValue("sno", i)
                If i = 1 Then
                    Cmd.Parameters.AddWithValue("@per1", per1)
                    Cmd.Parameters.AddWithValue("@title", dr2("cbtitle1"))
                ElseIf i = 2 Then
                    Cmd.Parameters.AddWithValue("@per1", per2)
                    Cmd.Parameters.AddWithValue("@title", dr2("cbtitle2"))
                ElseIf i = 3 Then
                    Cmd.Parameters.AddWithValue("@per1", per3)
                    Cmd.Parameters.AddWithValue("@title", dr2("cbtitle3"))
                ElseIf i = 4 Then
                    Cmd.Parameters.AddWithValue("@per1", per4)
                    Cmd.Parameters.AddWithValue("@title", dr2("cbtitle4"))
                ElseIf i = 5 Then
                    Cmd.Parameters.AddWithValue("@per1", per5)
                    Cmd.Parameters.AddWithValue("@title", dr2("cbtitle5"))
                End If

                Cmd.ExecuteNonQuery()
            Next
        End If
        GrdPerformance.DataBind()
        ''''''''''''''''''''''''''''''''''' Find emp history 
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        Dim dsmc As DataSet
        Dim drmc As DataRow
        dsmc = GetMedical(txtempcode.Text.Trim)
        If dsmc.Tables(0).Rows.Count <> 0 Then
            drmc = dsmc.Tables(0).Rows(0)
            lblmedical.Text = drmc("mc").ToString
        Else
            lblmedical.Text = 0
        End If

        ''''''''''''''''''''''''''''' GET ABSENTISM 
        Dim dsabs As DataSet
        Dim drabs As DataRow
        Dim abs, days
        Dim from As Date
        Dim tod As Date
        Dim l

        dsabs = GetAbscent(txtempcode.Text.Trim)
        If dsabs.Tables(0).Rows.Count <> 0 Then
            l = dsabs.Tables(0).Rows.Count
            For i = 0 To l - 1
                drabs = dsabs.Tables(0).Rows(i)
                from = drabs("abfromdate")
                tod = drabs("abtodate")
                abs = from.Subtract(tod).Days
                If abs = 0 Then
                    abs = 1
                End If
                days = days + abs
            Next
            lblabs.Text = abs
        Else
            lblabs.Text = 0
        End If

        '''''''''''''''''''''''''''''' GET LATE
        Dim dslate As DataSet
        Dim drlate As DataRow
        dslate = GetLAte(txtempcode.Text.Trim)
        If dslate.Tables(0).Rows.Count <> 0 Then
            drlate = dslate.Tables(0).Rows(0)
            lbllate.Text = drlate("late").ToString
        Else
            lbllate.Text = 0
        End If

        ''''''''''' GET COUNSELLING
        Dim dscou As DataSet
        Dim drcou As DataRow
        dscou = GetcOUNSELLING(txtempcode.Text.Trim)
        If dscou.Tables(0).Rows.Count <> 0 Then
            drcou = dscou.Tables(0).Rows(0)
            lblcoun.Text = drcou("expr2").ToString
        Else
            lblcoun.Text = 0
        End If

        '''' Get Explanation
        Dim dsexp As DataSet
        Dim drexp As DataRow
        dsexp = GetExplanation(txtempcode.Text.Trim)
        If dsexp.Tables(0).Rows.Count <> 0 Then
            drexp = dsexp.Tables(0).Rows(0)
            lblexpl.Text = drexp("expr2").ToString
        Else
            lblexpl.Text = 0
        End If
        '''' Get verbal
        Dim dsv As DataSet
        Dim drv As DataRow
        dsv = Getverbal(txtempcode.Text.Trim)
        If dsv.Tables(0).Rows.Count <> 0 Then
            drv = dsv.Tables(0).Rows(0)
            lblvw.Text = drv("expr2").ToString
        Else
            lblvw.Text = 0
        End If

        '''' Get written 
        Dim dsw As DataSet
        Dim drw As DataRow
        dsw = Getwritten(txtempcode.Text.Trim)
        If dsw.Tables(0).Rows.Count <> 0 Then
            drw = dsw.Tables(0).Rows(0)
            lblww.Text = drw("expr2").ToString
        Else
            lblww.Text = 0
        End If

        '''' Get first
        Dim dsf As DataSet
        Dim drf As DataRow
        dsf = Getfirst(txtempcode.Text.Trim)
        If dsf.Tables(0).Rows.Count <> 0 Then
            drf = dsf.Tables(0).Rows(0)
            lblfw.Text = drf("expr2").ToString
        Else
            lblfw.Text = 0
        End If

        '''' Get final
        Dim dsfi As DataSet
        Dim drfi As DataRow
        dsfi = Getfinal(txtempcode.Text.Trim)
        If dsfi.Tables(0).Rows.Count <> 0 Then
            drfi = dsfi.Tables(0).Rows(0)
            lblfinw.Text = drfi("expr2").ToString
        Else
            lblfinw.Text = 0
        End If

        '''' Get suspension
        Dim dsfs As DataSet
        Dim drfs As DataRow
        dsfs = Getsuspension(txtempcode.Text.Trim)
        If dsfs.Tables(0).Rows.Count <> 0 Then
            drfs = dsfs.Tables(0).Rows(0)
            lblsus.Text = drfs("expr2").ToString
        Else
            lblsus.Text = 0
        End If

        '''' Get show cause
        Dim dssc As DataSet
        Dim drsc As DataRow
        dssc = Getshowcase(txtempcode.Text.Trim)
        If dssc.Tables(0).Rows.Count <> 0 Then
            drsc = dssc.Tables(0).Rows(0)
            lblsc.Text = drsc("expr2").ToString
        Else
            lblsc.Text = 0
        End If
        '''' Get Misconduct reports
        Dim dsr As DataSet
        Dim drr As DataRow
        dsr = GetMisRpt(txtempcode.Text.Trim)
        If dsr.Tables(0).Rows.Count <> 0 Then
            drr = dsr.Tables(0).Rows(0)
            lblrpt.Text = drr("expr2").ToString
        Else
            lblrpt.Text = 0
        End If

        '''' check appraisal done by self 

        Dim cmd1 As New SqlCommand
        Dim dra, dra1 As SqlDataReader
        Dim da As SqlDataAdapter
        Dim fd
        MyGlobal.Con_Str()
        Dim con As New SqlConnection(constr)
        con.Open()
        cmd1 = New SqlCommand("select max(CONVERT(varchar(10), dateappraisal, 101)) as dt from app_staffappraisal where empcode = '" & txtempcode.Text & "'", con)
        dra = cmd1.ExecuteReader()
        While (dra.Read())
            fd = dra("dt").ToString()
        End While
        con.Close()
        cmd1.Dispose()

        MyGlobal.Con_Str()

        con.Open()
        cmd1 = New SqlCommand("select * from app_staffappraisal where empcode = '" & txtempcode.Text & "' and dateappraisal = '" & fd & "'", con)
        dra1 = cmd1.ExecuteReader()
        Dim len
        Label1.Text = Day(Date.Now) & "/" & Month(Date.Now) & "/" & Year(Date.Now)
        While (dra1.Read())
            rdpurpose.SelectedValue = dra1("purposeofappraisal").ToString
            If dra1("purposeofappraisal").ToString = "1/2 Yearly" Then
                ddlhalf.Visible = True
                lblapp.Visible = True
                ddlhalf.SelectedValue = dra1("periodofevoluation").ToString
            Else
                ddlhalf.Visible = False
                lblapp.Visible = False
            End If
            For grd As Integer = 0 To grdJg.Rows.Count - 1
                If grd <> 5 Then
                    Dim keyv, weightv, pointv, markv
                    keyv = "key" & grd + 1
                    weightv = keyv & "weight"
                    pointv = keyv & "points"
                    markv = keyv & "mark"

                    DirectCast(grdJg.Rows(grd).FindControl("pweight"), TextBox).Text = dra1(weightv).ToString
                    DirectCast(grdJg.Rows(grd).FindControl("ppoint"), Label).Text = dra1(pointv).ToString
                    DirectCast(grdJg.Rows(grd).FindControl("rdprating"), RadioButtonList).SelectedValue = dra1(markv).ToString
                End If
            Next
            DirectCast(grdJg.FooterRow.FindControl("lblweit"), Label).Text = dra1("totalkeyweight").ToString
            DirectCast(grdJg.FooterRow.FindControl("lblpts"), Label).Text = dra1("totalKeypoints").ToString


            For grd2 As Integer = 0 To GrdPerformance.Rows.Count - 1


                Dim keyv1, weightv1, pointv1, markv1, strenv1, impv1, titlev1, keys

                keyv1 = "behavoiur" & grd2 + 1
                weightv1 = keyv1 & "weight"
                pointv1 = keyv1 & "points"
                markv1 = keyv1 & "mark"
                strenv1 = keyv1 & "strength"
                impv1 = keyv1 & "improve"


                DirectCast(GrdPerformance.Rows(grd2).FindControl("rdbutton"), RadioButtonList).SelectedValue = dra1(markv1).ToString
                DirectCast(GrdPerformance.Rows(grd2).FindControl("txtbweit"), TextBox).Text = dra1(weightv1).ToString
                DirectCast(GrdPerformance.Rows(grd2).FindControl("lblbpoints"), Label).Text = dra1(pointv1).ToString
                DirectCast(GrdPerformance.Rows(grd2).FindControl("txtstrength"), TextBox).Text = dra1(strenv1).ToString
                DirectCast(GrdPerformance.Rows(grd2).FindControl("txtimpt"), TextBox).Text = dra1(impv1).ToString

            Next

            DirectCast(GrdPerformance.FooterRow.FindControl("lblbweit"), Label).Text = dra1("totalbehaviourweight").ToString
            DirectCast(GrdPerformance.FooterRow.FindControl("lblbpts"), Label).Text = dra1("totalbehaviourpoints").ToString

            lblfingrade.Text = dra1("finalgrade").ToString
            lbldhgrade.Text = dra1("finalgrade").ToString
            lblfinpoints.Text = dra1("finalpoints").ToString
            lblfinalweit.Text = dra1("finalweightage").ToString
            Label1.Text = Format(Convert.ToDateTime(dra1("dateappraisal")), "dd/MM/yy")

            txtperformance.Text = dra1("challenges").ToString
            txttarget.Text = dra1("targetmissed").ToString
            txtarea.Text = dra1("areaimprove").ToString
            rdconfirm.selectedvalue = dra1("confirmed").ToString.Trim


            'rdincrement.SelectedValue = dra1("increment").ToString.Trim

        End While

        '''' Get Performance from KPI
        Dim dskpi As DataSet
        Dim drkpi As DataRow
        Dim yr = Year(Date.Now)

        sqltext = "select *,empmaster.empcode from kpi_grade_result,empmaster where kpi_grade_result.empcode = empmaster.empcode  and yr = '" & yr & "' and empmaster.empcode ='" & txtempcode.Text.Trim & "'"

        Dim emp
        Dim tot
        Dim mth

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

        Dim j
        dskpi = GetEmpList(sqltext)
        If dskpi.Tables(0).Rows.Count <> 0 Then
            For j = 0 To dskpi.Tables(0).Rows.Count - 1
                DR = dskpi.Tables(0).Rows(j)
                emp = DR("empcode").ToString.Trim
                mth = DR("mnth").ToString.Trim

                If mth = "01" Then
                    If Not DR("total").ToString.Trim.Trim Is System.DBNull.Value Then
                        p1 = DR("total").ToString.Trim.Trim
                    Else
                        p1 = "0"
                    End If
                    If Not DR("grade").ToString.Trim Is System.DBNull.Value Then
                        g1 = DR("grade").ToString.Trim
                    Else
                        g1 = "-"
                    End If
                ElseIf mth = "02" Then
                    If Not DR("total").ToString.Trim Is System.DBNull.Value Then
                        p2 = DR("total").ToString.Trim
                    Else
                        p2 = "0"
                    End If
                    If Not DR("grade").ToString.Trim Is System.DBNull.Value Then
                        g2 = DR("grade").ToString.Trim
                    Else
                        g2 = "-"
                    End If
                ElseIf mth = "03" Then
                    If Not DR("total").ToString.Trim Is System.DBNull.Value Then
                        p3 = DR("total").ToString.Trim
                    Else
                        p3 = "0"
                    End If
                    If Not DR("grade").ToString.Trim Is System.DBNull.Value Then
                        g3 = DR("grade").ToString.Trim
                    Else
                        g3 = "-"
                    End If
                ElseIf mth = "04" Then
                    If Not DR("total").ToString.Trim Is System.DBNull.Value Then
                        p4 = DR("total").ToString.Trim
                    Else
                        p4 = "0"
                    End If
                    If Not DR("grade").ToString.Trim Is System.DBNull.Value Then
                        g4 = DR("grade").ToString.Trim
                    Else
                        g4 = "-"
                    End If
                ElseIf mth = "05" Then
                    If Not DR("total").ToString.Trim Is System.DBNull.Value Then
                        p5 = DR("total").ToString.Trim
                    Else
                        p5 = "0"
                    End If
                    If Not DR("grade").ToString.Trim Is System.DBNull.Value Then
                        g5 = DR("grade").ToString.Trim
                    Else
                        g5 = "-"
                    End If
                ElseIf mth = "06" Then
                    If Not DR("total").ToString.Trim Is System.DBNull.Value Then
                        p6 = DR("total").ToString.Trim
                    Else
                        p6 = "0"
                    End If
                    If Not DR("grade").ToString.Trim Is System.DBNull.Value Then
                        g6 = DR("grade").ToString.Trim
                    Else
                        g6 = "-"
                    End If
                ElseIf mth = "07" Then
                    If Not DR("total").ToString.Trim Is System.DBNull.Value Then
                        p7 = DR("total").ToString.Trim
                    Else
                        p7 = "0"
                    End If
                    If Not DR("grade").ToString.Trim Is System.DBNull.Value Then
                        g7 = DR("grade").ToString.Trim
                    Else
                        g7 = "-"
                    End If
                ElseIf mth = "08" Then
                    If Not DR("total").ToString.Trim Is System.DBNull.Value Then
                        p8 = DR("total").ToString.Trim
                    Else
                        p8 = "0"
                    End If
                    If Not DR("grade").ToString.Trim Is System.DBNull.Value Then
                        g8 = DR("grade").ToString.Trim
                    Else
                        g8 = "-"
                    End If
                ElseIf mth = "09" Then
                    If Not DR("total").ToString.Trim Is System.DBNull.Value Then
                        p9 = DR("total").ToString.Trim
                    Else
                        p9 = "0"
                    End If
                    If Not DR("grade").ToString.Trim Is System.DBNull.Value Then
                        g9 = DR("grade").ToString.Trim
                    Else
                        g9 = "-"
                    End If
                ElseIf mth = "10" Then
                    If Not DR("total").ToString.Trim Is System.DBNull.Value Then
                        p10 = DR("total").ToString.Trim
                    Else
                        p10 = "0"
                    End If
                    If Not DR("grade").ToString.Trim Is System.DBNull.Value Then
                        g10 = DR("grade").ToString.Trim
                    Else
                        g10 = "-"
                    End If
                ElseIf mth = "11" Then
                    If Not DR("total").ToString.Trim Is System.DBNull.Value Then
                        p11 = DR("total").ToString.Trim
                    Else
                        p11 = "0"
                    End If
                    If Not DR("grade").ToString.Trim Is System.DBNull.Value Then
                        g11 = DR("grade").ToString.Trim
                    Else
                        g11 = "-"
                    End If
                ElseIf mth = "12" Then
                    If Not DR("total").ToString.Trim Is System.DBNull.Value Then
                        p12 = DR("total").ToString.Trim
                    Else
                        p12 = "0"
                    End If
                    If Not DR("grade").ToString.Trim Is System.DBNull.Value Then
                        g12 = DR("grade").ToString.Trim
                    Else
                        g12 = "-"
                    End If
                End If
                Dim grade
                Dim avg = Double.Parse(p1) + Double.Parse(p2) + Double.Parse(p3) + Double.Parse(p4) + Double.Parse(p5) + Double.Parse(p6) + Double.Parse(p7) + Double.Parse(p8) + Double.Parse(p9) + Double.Parse(p10) + Double.Parse(p11) + Double.Parse(p12)

                avg = Math.Round(avg / 12)

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

                lbl1.Text = p1
                Label2.Text = p2
                Label3.Text = p3
                Label4.Text = p4
                Label5.Text = p5
                Label6.Text = p6
                Label7.Text = p7
                Label8.Text = p8
                Label9.Text = p9
                Label10.Text = p10
                Label11.Text = p11
                Label12.Text = p12

                Label13.Text = g1
                Label14.Text = g2
                Label15.Text = g3
                Label16.Text = g4
                Label17.Text = g5
                Label18.Text = g6
                Label19.Text = g7
                Label20.Text = g8
                Label21.Text = g9
                Label22.Text = g10
                Label23.Text = g11
                Label24.Text = g12

                lblavg.Text = avg
                lblgrd.Text = grade
            Next
        End If
    End Sub
    Private Sub eadetails()
        ''''''''//////////////////////////////////////////'''''''''''''
        Dim dsy As DataSet
        Dim dry As DataRow
        'MsgBox(Label1.Text)

        Dim fd1 As String
        fd1 = Label1.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)

        dsy = GetEAappraisaldet(txtempcode.Text.Trim, fd)
        If dsy.Tables(0).Rows.Count <> 0 Then
            dry = dsy.Tables(0).Rows(0)
            txtEA.Text = dry("commentsbyea").ToString
            rdEarating.text = dry("finalgradeea").ToString.Trim
            eapoints.Text = dry("finalpointsea").ToString
        Else
            lblrpt.Text = 0
        End If

    End Sub
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


    Function GetappCharactersetting(ByVal sqltext As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand(sqltext, con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "character")
        con.Close()
        Return ds
    End Function
    Function GetMedical(ByVal passno As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select leavetype,sum(grantedleave) as mc from leaveform where (leavetype = 'Medical') and empno ='" & passno & "' and (status='APPROVED') and (fromdate between '" & _fisyrStart & "' and '" & _fisyrEnd & "') group by leavetype ", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "medicalleave")
        con.Close()
        Return ds
    End Function
    Function GetEAappraisaldet(ByVal enumber As String, ByVal bl As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from app_staffappraisal where empcode ='" & enumber & "' and dateappraisal ='" & bl & "' ", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "eadet")
        con.Close()
        Return ds
    End Function
    Function GetAbscent(ByVal passno As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from leaveabsentism where (leavetype = 'Absent') and empcode ='" & passno & "' and (abfromdate between '" & _fisyrStart & "' and '" & _fisyrEnd & "')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "leaveabs")
        con.Close()
        Return ds
    End Function
    Function GetLAte(ByVal passno As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select count(*) as late from leaveabsentism where (leavetype = 'Latecoming') and empcode ='" & passno & "' and (latedate between '" & _fisyrStart & "' and '" & _fisyrEnd & "')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "late")
        con.Close()
        Return ds
    End Function
    Function GetcOUNSELLING(ByVal passno As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("SELECT COUNT(*) AS Expr2, empcode AS Expr1 FROM er_employeecounseling GROUP BY empcode HAVING (empcode ='" & passno & "')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "counseling")
        con.Close()
        Return ds
    End Function
    Function GetExplanation(ByVal passno As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("SELECT COUNT(*) AS Expr2, empcode AS Expr1 FROM  er_explanation GROUP BY empcode HAVING (empcode ='" & passno & "')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "Explanation")
        con.Close()
        Return ds
    End Function
    Function Getverbal(ByVal passno As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("SELECT COUNT(*) AS Expr2, empcode AS Expr1 FROM  er_verbalwarning GROUP BY empcode HAVING (empcode ='" & passno & "')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "varbal")
        con.Close()
        Return ds
    End Function
    Function Getwritten(ByVal passno As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("SELECT COUNT(*) AS Expr2, empcode AS Expr1 FROM  er_writtenwarning GROUP BY empcode HAVING (empcode ='" & passno & "')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "written")
        con.Close()
        Return ds
    End Function
    Function Getfirst(ByVal passno As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("SELECT COUNT(*) AS Expr2, empcode AS Expr1 FROM er_misfirstwarning GROUP BY empcode HAVING (empcode ='" & passno & "')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "first")
        con.Close()
        Return ds
    End Function
    Function Getfinal(ByVal passno As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("SELECT COUNT(*) AS Expr2, empcode AS Expr1 FROM er_misfinalwarning  GROUP BY empcode HAVING (empcode ='" & passno & "')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "final")
        con.Close()
        Return ds
    End Function
    Function Getsuspension(ByVal passno As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("SELECT COUNT(*) AS Expr2, empcode AS Expr1 FROM er_suspension GROUP BY empcode HAVING (empcode ='" & passno & "')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "suspension")
        con.Close()
        Return ds
    End Function
    Function Getshowcase(ByVal passno As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("SELECT COUNT(*) AS Expr2, empcode AS Expr1 FROM er_showcauseletter GROUP BY empcode HAVING (empcode ='" & passno & "')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "showcase")
        con.Close()
        Return ds
    End Function
    Function GetMisRpt(ByVal passno As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("SELECT COUNT(*) AS Expr2, empcode AS Expr1 FROM er_misconductreport GROUP BY empcode HAVING (empcode ='" & passno & "')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "report")
        con.Close()
        Return ds
    End Function
    Protected Sub Sqljs_Selecting(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles Sqljs.Selecting
        Dim emp
        If txtempcode.Text.Length <> 0 Then
            emp = txtempcode.Text
        Else
            emp = 0
        End If
        e.Command.Parameters(0).Value = emp
        e.Command.Parameters(1).Value = lbljskey.Text
    End Sub
    Protected Sub chkDynamic_CheckedChanged(ByVal Sender As Object, ByVal e As System.EventArgs)
        Dim points
        Dim total As Double
        Dim totpts As Double
        Dim totgrade As Double
        Dim tgrade As Double
        '  Dim RB As RadioButtonList = CType(Sender, RadioButtonList)
        For i As Integer = 0 To grdJg.Rows.Count - 1
            Dim passno As String = grdJg.Rows(i).Cells(0).Text
            Dim grade As String = DirectCast(grdJg.Rows(i).FindControl("rdprating"), RadioButtonList).SelectedValue
            Dim weight As String = DirectCast(grdJg.Rows(i).FindControl("pweight"), TextBox).Text
            Dim point As Label = DirectCast(grdJg.Rows(i).FindControl("ppoint"), Label)
            Dim grade1 As RadioButtonList = DirectCast(grdJg.Rows(i).FindControl("rdprating"), RadioButtonList)

            If weight = "" Or weight.Length = "0" Then
                MessageBox("Please enter Weightage before grading")
                DirectCast(grdJg.Rows(i).FindControl("pweight"), TextBox).Focus()
                Exit Sub
            End If

            If grade = "5" Then
                points = (5 / 5) * weight
            ElseIf grade = "4" Then
                points = (4 / 5) * weight
            ElseIf grade = "3" Then
                points = (3 / 5) * weight
            ElseIf grade = "2" Then
                points = (2 / 5) * weight
            ElseIf grade = "1" Then
                points = (1 / 5) * weight
            End If

            point.Text = points
            points = ""
            If point.Text = "" Then
                point.Text = 0
            End If
            totpts = Double.Parse(point.Text.ToString)
            total = Double.Parse(total)
            total += totpts

            Dim x = grade1.SelectedValue
            If (x = "" Or weight = "0") Then
                x = 0
            End If
            tgrade = Double.Parse(x)
            totgrade = Double.Parse(totgrade)
            totgrade += tgrade

            ''' just for focus
            DirectCast(grdJg.Rows(i).FindControl("rdprating"), RadioButtonList).Focus()
        Next
        DirectCast(grdJg.FooterRow.FindControl("lblpts"), Label).Text = total
        DirectCast(grdJg.FooterRow.FindControl("Lblmarks"), Label).Text = totgrade
        Dim lbl As Label = DirectCast(GrdPerformance.FooterRow.FindControl("Lblbweit"), Label)
        If lbl.Text = "" Then
            lbl.Text = 0
        End If
        lblfinpoints.Text = total + lbl.Text
        calculateGrade(lblfinpoints.Text)
    End Sub
    Protected Sub calculateTotal(ByVal Sender As Object, ByVal e As System.EventArgs)
        Dim weight As TextBox
        Dim total As Double
        Dim txtVal As Double
        For i As Integer = 0 To grdJg.Rows.Count - 1
            weight = DirectCast(grdJg.Rows(i).FindControl("pweight"), TextBox)
            If weight.Text = "" Then
                weight.Text = 0
            End If
            txtVal = Double.Parse(weight.Text.ToString)
            total = Double.Parse(total)
            total += txtVal
            weight.Focus()
        Next
        If total > 80 Then
            MessageBox("weightage cannot exceeds 80%")
            Exit Sub
        End If
        DirectCast(grdJg.FooterRow.FindControl("lblweit"), Label).Text = total

    End Sub
    Protected Sub chkDynamic2_CheckedChanged(ByVal Sender As Object, ByVal e As System.EventArgs)
        Dim points
        Dim total As Double
        Dim totpts As Double
        Dim totgrade As Double
        Dim tgrade As Double
        '  Dim RB As RadioButtonList = CType(Sender, RadioButtonList)
        For i As Integer = 0 To GrdPerformance.Rows.Count - 1
            Dim passno As String = GrdPerformance.Rows(i).Cells(0).Text
            Dim grade As String = DirectCast(GrdPerformance.Rows(i).FindControl("rdbutton"), RadioButtonList).SelectedValue
            Dim weight As String = DirectCast(GrdPerformance.Rows(i).FindControl("txtbweit"), TextBox).Text
            Dim point As Label = DirectCast(GrdPerformance.Rows(i).FindControl("lblbpoints"), Label)
            Dim grade1 As RadioButtonList = DirectCast(GrdPerformance.Rows(i).FindControl("rdbutton"), RadioButtonList)

            If weight = "" Or weight.Length = "0" Then
                MessageBox("Please enter Weightage before grading")
                DirectCast(GrdPerformance.Rows(i).FindControl("txtbweit"), TextBox).Focus()
                Exit Sub
            End If

            If grade = "5" Then
                points = (5 / 5) * weight
            ElseIf grade = "4" Then
                points = (4 / 5) * weight
            ElseIf grade = "3" Then
                points = (3 / 5) * weight
            ElseIf grade = "2" Then
                points = (2 / 5) * weight
            ElseIf grade = "1" Then
                points = (1 / 5) * weight
            End If

            point.Text = points
            points = ""
            If point.Text = "" Then
                point.Text = 0
            End If
            totpts = Double.Parse(point.Text.ToString)
            total = Double.Parse(total)
            total += totpts

            Dim x = grade1.SelectedValue
            If (x = "" Or weight = "0") Then
                x = 0
            End If
            tgrade = Double.Parse(x)
            totgrade = Double.Parse(totgrade)
            totgrade += tgrade

            ''''' jus for focus
            DirectCast(GrdPerformance.Rows(i).FindControl("rdbutton"), RadioButtonList).Focus()

        Next
        DirectCast(GrdPerformance.FooterRow.FindControl("Lblbpts"), Label).Text = total
        Dim lbl As Label = DirectCast(grdJg.FooterRow.FindControl("Lblweit"), Label)
        If lbl.Text = "" Then
            lbl.Text = 0
        End If
        lblfinpoints.Text = total + lbl.Text
        calculateGrade(lblfinpoints.Text)

        DirectCast(GrdPerformance.FooterRow.FindControl("Lblbmarks"), Label).Text = totgrade

    End Sub

    Protected Sub calculateTotal2(ByVal Sender As Object, ByVal e As System.EventArgs)
        Dim weight As TextBox
        Dim total As Double
        Dim txtVal As Double
        For i As Integer = 0 To GrdPerformance.Rows.Count - 1
            weight = DirectCast(GrdPerformance.Rows(i).FindControl("txtbweit"), TextBox)
            If weight.Text = "" Then
                weight.Text = 0
            End If
            txtVal = Double.Parse(weight.Text.ToString)
            total = Double.Parse(total)
            total += txtVal
            weight.Focus()

        Next
        If total > 20 Then
            MessageBox("weightage cannot exceeds 20%")
            Exit Sub
        End If
        DirectCast(GrdPerformance.FooterRow.FindControl("Lblbweit"), Label).Text = total

    End Sub
    Private Sub calculateGrade(ByVal pts As Decimal)
        If pts >= 100 Then
            lblfingrade.Text = "A"
        ElseIf pts >= 80 And pts <= 99 Then
            lblfingrade.Text = "B"
        ElseIf pts >= 79 And pts <= 60 Then
            lblfingrade.Text = "C"
        ElseIf pts >= 59 And pts <= 40 Then
            lblfingrade.Text = "D"
        ElseIf pts <= 39 Then
            lblfingrade.Text = "E"
        End If
    End Sub

    '' ''Protected Sub txtbutton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbutton.Click
    '' ''    If rdpurpose.SelectedValue = "" Then
    '' ''        MessageBox("Key in the Purpose of appraisal")
    '' ''        rdpurpose.Focus()
    '' ''        Exit Sub
    '' ''    End If
    '' ''    If lblfinpoints.Text = "" Then
    '' ''        MessageBox("Key in Section1 & Section2")
    '' ''        Exit Sub
    '' ''    End If
    '' ''    'If rdincrement.SelectedValue = "" Or rdconfirm.SelectedValue = "" Then
    '' ''    '    MessageBox("Select HOD Remarks/Recommendations")
    '' ''    '    rdpurpose.Focus()
    '' ''    '    Exit Sub
    '' ''    'End If
    '' ''    If rdpurpose.SelectedValue = "1/2half" And ddlhalf.SelectedValue = "-" Then
    '' ''        MessageBox("Please select the value for 1/2 yearly appraisal")
    '' ''        ddlhalf.Focus()
    '' ''        Exit Sub
    '' ''    End If

    '' ''    If rdEarating.SelectedValue = "" Then
    '' ''        MessageBox("Please Grade the staff")
    '' ''        rdEarating.Focus()
    '' ''        Exit Sub
    '' ''    End If

    '' ''    Dim fd1 As String
    '' ''    fd1 = Label1.Text.Trim
    '' ''    Dim strdate() As String = fd1.Split("/"c)
    '' ''    fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

    '' ''    Dim fd As Date
    '' ''    fd = CDate(fd1)

    '' ''    Try
    '' ''        MyGlobal.Open_Con()
    '' ''        MyGlobal.Con_Str()
    '' ''        Call MyGlobal.dbSp_open("hrmis_insAppraisal_ea")

    '' ''        Cmd.Parameters.AddWithValue("@empcode", txtempcode.Text.Trim)
    '' ''        Cmd.Parameters.AddWithValue("@purposeofappraisal", rdpurpose.SelectedValue)
    '' ''        Cmd.Parameters.AddWithValue("@hod", Session("empcode"))
    '' ''        Cmd.Parameters.AddWithValue("@section1", 80)
    '' ''        Cmd.Parameters.AddWithValue("@section2", 20)

    '' ''        Cmd.Parameters.AddWithValue("@finalgrade", lblfingrade.Text.Trim)
    '' ''        Cmd.Parameters.AddWithValue("@finalpoints", lblfinpoints.Text)
    '' ''        Cmd.Parameters.AddWithValue("@finalweightage", lblfinalweit.Text)
    '' ''        Cmd.Parameters.AddWithValue("@challenges", txtperformance.Text)
    '' ''        Cmd.Parameters.AddWithValue("@targetmissed", txttarget.Text)
    '' ''        Cmd.Parameters.AddWithValue("@areaimprove", txtarea.Text)
    '' ''        Cmd.Parameters.AddWithValue("@confirmed", rdconfirm.SelectedValue)
    '' ''        ' Cmd.Parameters.AddWithValue("@increment", rdincrement.SelectedValue)
    '' ''        Cmd.Parameters.AddWithValue("@status", "A")
    '' ''        ' Cmd.Parameters.AddWithValue("@department", )
    '' ''        Cmd.Parameters.AddWithValue("@date", fd)


    '' ''        For i As Integer = 0 To grdJg.Rows.Count - 1
    '' ''            If i <> 5 Then
    '' ''                Dim key As String = DirectCast(grdJg.Rows(i).FindControl("lblman"), Label).Text
    '' ''                Dim mark As String = DirectCast(grdJg.Rows(i).FindControl("rdprating"), RadioButtonList).SelectedValue
    '' ''                Dim weight As String = DirectCast(grdJg.Rows(i).FindControl("pweight"), TextBox).Text
    '' ''                Dim point As Label = DirectCast(grdJg.Rows(i).FindControl("ppoint"), Label)

    '' ''                Dim keyv, weightv, pointv, markv
    '' ''                keyv = "@key" & i + 1
    '' ''                weightv = keyv & "weight"
    '' ''                pointv = keyv & "points"
    '' ''                markv = keyv & "mark"
    '' ''                Cmd.Parameters.AddWithValue(keyv, key)
    '' ''                Cmd.Parameters.AddWithValue(weightv, weight)
    '' ''                Cmd.Parameters.AddWithValue(pointv, point.Text)
    '' ''                Cmd.Parameters.AddWithValue(markv, mark)
    '' ''            End If
    '' ''        Next
    '' ''        Dim l = grdJg.Rows.Count
    '' ''        Dim etc

    '' ''        If l < 5 Then
    '' ''            For etc = l To 5 - 1

    '' ''                Dim keyv, weightv, pointv, markv
    '' ''                keyv = "@key" & etc + 1
    '' ''                weightv = keyv & "weight"
    '' ''                pointv = keyv & "points"
    '' ''                markv = keyv & "mark"

    '' ''                Cmd.Parameters.AddWithValue(keyv, "-")
    '' ''                Cmd.Parameters.AddWithValue(weightv, 0)
    '' ''                Cmd.Parameters.AddWithValue(pointv, 0)
    '' ''                Cmd.Parameters.AddWithValue(markv, 0)
    '' ''            Next
    '' ''        End If

    '' ''        Dim totalkeyweight = DirectCast(grdJg.FooterRow.FindControl("lblweit"), Label).Text
    '' ''        Dim totalkeymarks = DirectCast(grdJg.FooterRow.FindControl("lblpts"), Label).Text
    '' ''        Dim totmarks = DirectCast(grdJg.FooterRow.FindControl("lblmarks"), Label).Text
    '' ''        Cmd.Parameters.AddWithValue("@totalkeyweight", totalkeyweight)
    '' ''        Cmd.Parameters.AddWithValue("@totalkeypoints", totalkeymarks)
    '' ''        Cmd.Parameters.AddWithValue("@totalkeymarks", totmarks)

    '' ''        For i As Integer = 0 To GrdPerformance.Rows.Count - 1
    '' ''            Dim behaviour As String = GrdPerformance.Rows(i).Cells(2).Text
    '' ''            Dim title As String = GrdPerformance.Rows(i).Cells(1).Text
    '' ''            Dim mark As String = DirectCast(GrdPerformance.Rows(i).FindControl("rdbutton"), RadioButtonList).SelectedValue
    '' ''            Dim weight As String = DirectCast(GrdPerformance.Rows(i).FindControl("txtbweit"), TextBox).Text
    '' ''            Dim point As Label = DirectCast(GrdPerformance.Rows(i).FindControl("lblbpoints"), Label)
    '' ''            Dim strength As String = DirectCast(GrdPerformance.Rows(i).FindControl("txtstrength"), TextBox).Text
    '' ''            Dim imp As String = DirectCast(GrdPerformance.Rows(i).FindControl("txtimpt"), TextBox).Text

    '' ''            Dim keyv, weightv, pointv, markv, strenv, impv, titlev, keys
    '' ''            keys = "@behaviour" & i + 1
    '' ''            keyv = "@behavoiur" & i + 1
    '' ''            weightv = keyv & "weight"
    '' ''            pointv = keyv & "points"
    '' ''            markv = keyv & "mark"
    '' ''            strenv = keyv & "strength"
    '' ''            impv = keyv & "improve"
    '' ''            titlev = keyv & "title"

    '' ''            Cmd.Parameters.AddWithValue(keys, behaviour)
    '' ''            Cmd.Parameters.AddWithValue(weightv, weight)
    '' ''            Cmd.Parameters.AddWithValue(pointv, point.Text)
    '' ''            Cmd.Parameters.AddWithValue(markv, mark)
    '' ''            Cmd.Parameters.AddWithValue(strenv, strength)
    '' ''            Cmd.Parameters.AddWithValue(impv, imp)
    '' ''            Cmd.Parameters.AddWithValue(titlev, title)
    '' ''        Next

    '' ''        Dim totalbweight = DirectCast(GrdPerformance.FooterRow.FindControl("lblbweit"), Label).Text
    '' ''        Dim totalbpoints = DirectCast(GrdPerformance.FooterRow.FindControl("lblbpts"), Label).Text
    '' ''        Dim totalbmarks = DirectCast(GrdPerformance.FooterRow.FindControl("lblbmarks"), Label).Text
    '' ''        Cmd.Parameters.AddWithValue("@totalbehaviourweight", totalbweight)
    '' ''        Cmd.Parameters.AddWithValue("@totalbehaviourpoints", totalbpoints)
    '' ''        Cmd.Parameters.AddWithValue("@totalbehaviourmarks", totalbmarks)
    '' ''        Cmd.Parameters.AddWithValue("@periodofevoluation", ddlhalf.SelectedValue)
    '' ''        Cmd.Parameters.AddWithValue("@halfyear", lblhalf.Text)

    '' ''        Cmd.Parameters.AddWithValue("@finalpointsEA", eapoints.Text)
    '' ''        Cmd.Parameters.AddWithValue("@finalgradeEA", rdEarating.SelectedValue)
    '' ''        Cmd.Parameters.AddWithValue("@commentsbyea", txtEA.Text)
    '' ''        Cmd.Parameters.AddWithValue("@remarksoffice", offremarks.Text)
    '' ''        Cmd.Parameters.AddWithValue("@promotion", DDLDESIG.SelectedValue)
    '' ''        Cmd.ExecuteNonQuery()
    '' ''        MessageBox("Appraisal Saved Successfully")

    '' ''        '''''' save record to app_appraisal note table to raise alert 
    '' ''        Dim doj As Date
    '' ''        Dim desig, emp
    '' ''        Dim dsemp As DataSet
    '' ''        Dim dremp As DataRow
    '' ''        Dim i1
    '' ''        Dim con As New SqlConnection(constr)
    '' ''        con.Open()
    '' ''        Dim cmd1, cmd2 As New SqlCommand
    '' ''        Dim dra, dra1 As SqlDataReader
    '' ''        Dim da As SqlDataAdapter
    '' ''        Dim prob1, prob2
    '' ''        Dim fstat
    '' ''        Dim datediff As Date
    '' ''        Dim dateexp As Date
    '' ''        'If Session("foreigner") = "Y" Then
    '' ''        '    Dim contract
    '' ''        '    Dim expalert
    '' ''        '    Dim contracteffectivefrom As Date

    '' ''        '    dsemp = GetEmp1()
    '' ''        '    If dsemp.Tables(0).Rows.Count <> 0 Then
    '' ''        '        Dim lcount = dsemp.Tables(0).Rows.Count
    '' ''        '        '      For i1 = 0 To lcount - 1

    '' ''        '        dremp = dsemp.Tables(0).Rows(i1)
    '' ''        '        doj = dremp("dateofjoin").ToString
    '' ''        '        desig = dremp("designation").ToString
    '' ''        '        emp = dremp("empcode").ToString
    '' ''        '        contract = dremp("contract").ToString
    '' ''        '        'contract = "24"

    '' ''        '        If Not dremp("extendcontract") Is System.DBNull.Value Then
    '' ''        '            If dremp("extendcontract") = "Y" Then
    '' ''        '                If Not dremp("contracteffectivefrom") Is System.DBNull.Value Then
    '' ''        '                    contracteffectivefrom = dremp("contracteffectivefrom")
    '' ''        '                    dateexp = contracteffectivefrom.AddMonths(contract)
    '' ''        '                Else
    '' ''        '                    dateexp = doj.AddMonths(contract)
    '' ''        '                End If
    '' ''        '            Else
    '' ''        '                dateexp = doj.AddMonths(contract)
    '' ''        '            End If
    '' ''        '        Else
    '' ''        '            dateexp = doj.AddMonths(contract)
    '' ''        '        End If


    '' ''        '        'Call MyGlobal.dbSp_open("insert_appraisal_payroll_exp")
    '' ''        '        'Cmd.Parameters.AddWithValue("@empcode", emp)
    '' ''        '        'Cmd.Parameters.AddWithValue("@appraisal", "Y")
    '' ''        '        'Cmd.Parameters.AddWithValue("@status", "S")
    '' ''        '        'Cmd.Parameters.AddWithValue("@type", "C")
    '' ''        '        'Cmd.Parameters.AddWithValue("@expiry", dateexp)
    '' ''        '        Call MyGlobal.dbSp_open("insert_appraisal_ea")
    '' ''        '        Cmd.Parameters.AddWithValue("@empcode", txtempcode.Text.Trim)
    '' ''        '        Cmd.Parameters.AddWithValue("@appraisal", "Y")
    '' ''        '        Cmd.Parameters.AddWithValue("@status", "EA")
    '' ''        '        Cmd.Parameters.AddWithValue("@prob ", prob1)
    '' ''        '        Cmd.Parameters.AddWithValue("@atype", fstat)
    '' ''        '        Cmd.Parameters.AddWithValue("@confirm", rdconfirm.SelectedValue)
    '' ''        '        Cmd.ExecuteNonQuery()
    '' ''        '        '  Next
    '' ''        '        'GrdContract.DataBind()
    '' ''        '    End If
    '' ''        'ElseIf Session("foreigner") = "N" Then
    '' ''        '    cmd1 = New SqlCommand("Select * from designation where designationname = '" & lbldesig.Text & "'", con)
    '' ''        '    dra = cmd1.ExecuteReader()
    '' ''        '    While (dra.Read())
    '' ''        '        prob1 = Double.Parse(dra("probation").ToString())
    '' ''        '        Dim dsp As DataSet
    '' ''        '        Dim drp As DataRow
    '' ''        '        dsp = GetProbation(txtempcode.Text.Trim)
    '' ''        '        If dsp.Tables(0).Rows.Count <> 0 Then
    '' ''        '            ' messagebox(dsp.Tables(0).Rows.Count)
    '' ''        '            drp = dsp.Tables(0).Rows(0)
    '' ''        '            prob2 = Double.Parse(drp("months").ToString())
    '' ''        '            prob1 = prob1 + prob2
    '' ''        '            'dsg = GetExplist(prob1)
    '' ''        '        End If
    '' ''        '    End While
    '' ''        '    fstat = "P"
    '' ''        Call MyGlobal.dbSp_open("insert_appraisal_ea")
    '' ''        Cmd.Parameters.AddWithValue("@empcode", txtempcode.Text.Trim)
    '' ''        Cmd.Parameters.AddWithValue("@appraisal", "Y")
    '' ''        Cmd.Parameters.AddWithValue("@status", "EA")
    '' ''        Cmd.Parameters.AddWithValue("@prob ", "")
    '' ''        Cmd.Parameters.AddWithValue("@atype", "")
    '' ''        Cmd.Parameters.AddWithValue("@confirm", rdconfirm.SelectedValue)
    '' ''        Cmd.ExecuteNonQuery()

    '' ''        'End If
    '' ''        ' DS = emanagement.globalinfo.Open_appraisalnote(con, DAP, 2, "update emp_appraisalnote set confirmd = '" & rdconfirm.SelectedValue & "'  where empcode ='" & txtempcode.Text.Trim & "'")

    '' ''    Catch ex As Exception
    '' ''        MessageBox(ex.Message)
    '' ''        Exit Sub
    '' ''    End Try


    '' ''End Sub
    Function GetEmp1() As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from empmaster where emptype = 'Contract'  and resigned = 'N' and nationality <> 'JAP' and empcode ='" & txtempcode.Text.Trim & "' order by empcode", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "emp")
        con.Close()
        Return ds
    End Function
    Function GetProbation(ByVal empcode As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from emp_probationextend where empcode = '" & empcode & "'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "empprob")
        con.Close()
        Return ds
    End Function
    Protected Sub rdpurpose_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdpurpose.SelectedIndexChanged
        If rdpurpose.SelectedValue = "1/2Year" Then
            ddlhalf.Visible = True
            lblhalf.Text = Year(_fisyrStart) & "-" & Year(_fisyrEnd)
        Else
            ddlhalf.Visible = False
            lblhalf.Text = "-"
        End If
    End Sub


    Protected Sub txtbutton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbutton.Click

    End Sub
End Class