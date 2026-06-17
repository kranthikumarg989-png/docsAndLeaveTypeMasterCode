Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class OperatorAppraisalFinalReport
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim empcode

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        MyApp.GetfiscalYear()

        Dim rno
        If Session("ecodee") <> "" Then
            rno = Session("ecodee")
        End If
        GetAppraisalData(rno)

    End Sub
    Private Sub GetAppraisalData(ByVal rno As String)

        '''' Get written 
        Dim dsw12 As DataSet
        Dim dra1 As DataRow
        dsw12 = GetEMp(rno)
        If dsw12.Tables(0).Rows.Count <> 0 Then
            dra1 = dsw12.Tables(0).Rows(0)
            lblemp.Text = dra1("empcode").ToString
            Dim purp = dra1("purposeofappraisal").ToString

            If purp <> "" Then
                If purp = "1/2Year" Then
                    rdpurpose.SelectedValue = "1/2 Yearly"
                ElseIf purp = "endprobation" Then
                    rdpurpose.SelectedValue = "EP"
                ElseIf purp = "extcontract" Then
                    rdpurpose.SelectedValue = "EC"
                End If
            End If

            'rdpurpose.SelectedValue = dra1("purposeofappraisal").ToString

            If dra1("purposeofappraisal").ToString = "1/2 Yearly" Then
                ddlhalf.Visible = True
                lblapp.Visible = True
                ddlhalf.SelectedValue = dra1("periodofevoluation").ToString
            Else
                ddlhalf.Visible = False
                lblapp.Visible = False
            End If
            lblcomment.Text = dra1("remarks").ToString
            lblcommentdh.Text = dra1("remarksreview").ToString
            txtea.Text = dra1("Remarksea").ToString

            '   rddh.SelectedValue = dra1("senddh").ToString

            DirectCast(GrdOpt.Rows(0).FindControl("rdprating"), RadioButtonList).SelectedValue = dra1("job").ToString
            DirectCast(GrdOpt.Rows(1).FindControl("rdprating"), RadioButtonList).SelectedValue = dra1("quality").ToString
            DirectCast(GrdOpt.Rows(2).FindControl("rdprating"), RadioButtonList).SelectedValue = dra1("quantity").ToString
            DirectCast(GrdOpt.Rows(3).FindControl("rdprating"), RadioButtonList).SelectedValue = dra1("coattitude").ToString
            DirectCast(GrdOpt.Rows(4).FindControl("rdprating"), RadioButtonList).SelectedValue = dra1("coworkersrelation").ToString
            DirectCast(GrdOpt.Rows(5).FindControl("rdprating"), RadioButtonList).SelectedValue = dra1("companyloyalty").ToString
            DirectCast(GrdOpt.Rows(6).FindControl("rdprating"), RadioButtonList).SelectedValue = dra1("attendancepunctuality").ToString
            DirectCast(GrdOpt.Rows(7).FindControl("rdprating"), RadioButtonList).SelectedValue = dra1("depend").ToString
            DirectCast(GrdOpt.Rows(8).FindControl("rdprating"), RadioButtonList).SelectedValue = dra1("safetyhabit").ToString
            DirectCast(GrdOpt.Rows(9).FindControl("rdprating"), RadioButtonList).SelectedValue = dra1("ability").ToString
            DirectCast(GrdOpt.FooterRow.FindControl("lbltotal"), Label).Text = dra1("total").ToString
            DirectCast(GrdOpt.FooterRow.FindControl("lblgrade"), Label).Text = dra1("grade").ToString


            Label1.Text = Format(Convert.ToDateTime(dra1("dateofappraisal")), "dd/MM/yy")

            Dim contract
            Dim confirm
            Dim probation

            'If Not dra1("contract") Is System.DBNull.Value Then
            '    contract = dra1("contract").ToString
            'Else
            '    contract = ""
            'End If
            'If Not dra1("confirmd") Is System.DBNull.Value Then
            '    confirm = dra1("confirmd").ToString
            'Else
            '    confirm = ""
            'End If
            'If Not dra1("probation") Is System.DBNull.Value Then
            '    probation = dra1("probation").ToString
            'Else
            '    probation = ""
            'End If

            'If contract = "Y" Then
            '    rdconfirm.SelectedValue = "N"
            'ElseIf confirm = "Y" Then
            '    rdconfirm.SelectedValue = "C"
            'ElseIf probation = "Y" Then
            '    rdconfirm.SelectedValue = "E"
            'End If

            If Not dra1("confirmd") Is System.DBNull.Value Then
                rdconfirm.SelectedValue = dra1("confirmd").ToString
            Else
                confirm = ""
            End If


        Else
            MessageBox("Record doesnot exist ")
            Exit Sub
        End If

        empcode = lblemp.Text
        GetEmpVehino(empcode)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                lblename.Text = dr("empname").ToString
                lblsect.Text = dr("sectioncode").ToString
                lbldept.Text = dr("departmentcode").ToString
                '  lbldesig.Text = dr("designation").ToString
                lblstatus.Text = dr("emptype").ToString
            Else
                '  MessageBox("EmployeeCode doesnot Exist!!")
                Exit Sub
            End If
        End If
        '''' Get Key skills of employee
        GetRevno(empcode)
        Dim revno, recno
        revno = posid - 1
        Dim i

        ''''''''''''''''''''''''''''''''''' Find emp history 
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        Dim dsmc As DataSet
        Dim drmc As DataRow
        dsmc = GetMedical(lblemp.Text.Trim)
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

        dsabs = GetAbscent(lblemp.Text.Trim)
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
        dslate = GetLAte(lblemp.Text.Trim)
        If dslate.Tables(0).Rows.Count <> 0 Then
            drlate = dslate.Tables(0).Rows(0)
            lbllate.Text = drlate("late").ToString
        Else
            lbllate.Text = 0
        End If

        ''''''''''' GET COUNSELLING
        Dim dscou As DataSet
        Dim drcou As DataRow
        dscou = GetcOUNSELLING(lblemp.Text.Trim)
        If dscou.Tables(0).Rows.Count <> 0 Then
            drcou = dscou.Tables(0).Rows(0)
            lblcoun.Text = drcou("expr2").ToString
        Else
            lblcoun.Text = 0
        End If

        '''' Get Explanation
        Dim dsexp As DataSet
        Dim drexp As DataRow
        dsexp = GetExplanation(lblemp.Text.Trim)
        If dsexp.Tables(0).Rows.Count <> 0 Then
            drexp = dsexp.Tables(0).Rows(0)
            lblexpl.Text = drexp("expr2").ToString
        Else
            lblexpl.Text = 0
        End If
        '''' Get verbal
        Dim dsv As DataSet
        Dim drv As DataRow
        dsv = Getverbal(lblemp.Text.Trim)
        If dsv.Tables(0).Rows.Count <> 0 Then
            drv = dsv.Tables(0).Rows(0)
            lblvw.Text = drv("expr2").ToString
        Else
            lblvw.Text = 0
        End If

        '''' Get written 
        Dim dsw As DataSet
        Dim drw As DataRow
        dsw = Getwritten(lblemp.Text.Trim)
        If dsw.Tables(0).Rows.Count <> 0 Then
            drw = dsw.Tables(0).Rows(0)
            lblww.Text = drw("expr2").ToString
        Else
            lblww.Text = 0
        End If

        '''' Get first
        Dim dsf As DataSet
        Dim drf As DataRow
        dsf = Getfirst(lblemp.Text.Trim)
        If dsf.Tables(0).Rows.Count <> 0 Then
            drf = dsf.Tables(0).Rows(0)
            lblfw.Text = drf("expr2").ToString
        Else
            lblfw.Text = 0
        End If

        '''' Get final
        Dim dsfi As DataSet
        Dim drfi As DataRow
        dsfi = Getfinal(lblemp.Text.Trim)
        If dsfi.Tables(0).Rows.Count <> 0 Then
            drfi = dsfi.Tables(0).Rows(0)
            lblfinw.Text = drfi("expr2").ToString
        Else
            lblfinw.Text = 0
        End If

        '''' Get suspension
        Dim dsfs As DataSet
        Dim drfs As DataRow
        dsfs = Getsuspension(lblemp.Text.Trim)
        If dsfs.Tables(0).Rows.Count <> 0 Then
            drfs = dsfs.Tables(0).Rows(0)
            lblsus.Text = drfs("expr2").ToString
        Else
            lblsus.Text = 0
        End If

        '''' Get show cause
        Dim dssc As DataSet
        Dim drsc As DataRow
        dssc = Getshowcase(lblemp.Text.Trim)
        If dssc.Tables(0).Rows.Count <> 0 Then
            drsc = dssc.Tables(0).Rows(0)
            lblsc.Text = drsc("expr2").ToString
        Else
            lblsc.Text = 0
        End If
        '''' Get Misconduct reports
        Dim dsr As DataSet
        Dim drr As DataRow
        dsr = GetMisRpt(lblemp.Text.Trim)
        If dsr.Tables(0).Rows.Count <> 0 Then
            drr = dsr.Tables(0).Rows(0)
            lblrpt.Text = drr("expr2").ToString
        Else
            lblrpt.Text = 0
        End If
        '''' Get Performance from KPI
        Dim tisyr, nxtyr, tnyr
        tisyr = Date.Now.Year
        nxtyr = tisyr + 1
        tnyr = tisyr & "-" & nxtyr


        Dim sqltext
        Dim dskpi As DataSet
        Dim drkpi As DataRow
        Dim yr = Year(Date.Now)
        ' sqltext = "select *,empmaster.empcode from kpi_grade_result,empmaster where kpi_grade_result.empcode = empmaster.empcode  and yr = '" & yr & "' and empmaster.empcode ='" & lblempcode.Text.Trim & "'"
        sqltext = "select * from performancedatainput where year1='" & tnyr & "' and empcode = '" & lblemp.Text.Trim & "'"
        Dim emp
        Dim options
        Dim tot
        Dim grd
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
                ' mth = DR("mnth").ToString.Trim
                options = DR("option1").ToString.Trim

                If options = "1stHalf" Then
                    If Not DR("point1").ToString.Trim.Trim Is System.DBNull.Value Then
                        p1 = DR("point1").ToString.Trim.Trim
                    Else
                        p1 = "0"
                    End If
                    If Not DR("grade1").ToString.Trim Is System.DBNull.Value Then
                        g1 = DR("grade1").ToString.Trim
                    Else
                        g1 = "-"
                    End If
                    If Not DR("point2").ToString.Trim Is System.DBNull.Value Then
                        p2 = DR("point2").ToString.Trim
                    Else
                        p2 = "0"
                    End If
                    If Not DR("grade2").ToString.Trim Is System.DBNull.Value Then
                        g2 = DR("grade2").ToString.Trim
                    Else
                        g2 = "-"
                    End If

                    If Not DR("point3").ToString.Trim Is System.DBNull.Value Then
                        p3 = DR("point3").ToString.Trim
                    Else
                        p3 = "0"
                    End If
                    If Not DR("grade3").ToString.Trim Is System.DBNull.Value Then
                        g3 = DR("grade3").ToString.Trim
                    Else
                        g3 = "-"
                    End If
                    If Not DR("point4").ToString.Trim Is System.DBNull.Value Then
                        p4 = DR("point4").ToString.Trim
                    Else
                        p4 = "0"
                    End If
                    If Not DR("grade4").ToString.Trim Is System.DBNull.Value Then
                        g4 = DR("grade4").ToString.Trim
                    Else
                        g4 = "-"
                    End If
                    If Not DR("point5").ToString.Trim Is System.DBNull.Value Then
                        p5 = DR("point5").ToString.Trim
                    Else
                        p5 = "0"
                    End If
                    If Not DR("grade5").ToString.Trim Is System.DBNull.Value Then
                        g5 = DR("grade5").ToString.Trim
                    Else
                        g5 = "-"
                    End If

                    If Not DR("point6").ToString.Trim Is System.DBNull.Value Then
                        p6 = DR("point6").ToString.Trim
                    Else
                        p6 = "0"
                    End If
                    If Not DR("grade6").ToString.Trim Is System.DBNull.Value Then
                        g6 = DR("grade6").ToString.Trim
                    Else
                        g6 = "-"
                    End If
                    If Not DR("avg1").ToString.Trim Is System.DBNull.Value Then
                        lbla1.Text = DR("avg1").ToString.Trim
                    Else
                        lbla1.Text = "0"
                    End If
                    If Not DR("avg1grade").ToString.Trim Is System.DBNull.Value Then
                        lblg1.Text = DR("avg1grade").ToString.Trim
                    Else
                        lblg1.Text = "-"
                    End If
                ElseIf options = "2ndHalf" Then
                    If Not DR("point7").ToString.Trim Is System.DBNull.Value Then
                        p7 = DR("point7").ToString.Trim
                    Else
                        p7 = "0"
                    End If
                    If Not DR("grade7").ToString.Trim Is System.DBNull.Value Then
                        g7 = DR("grade7").ToString.Trim
                    Else
                        g7 = "-"
                    End If
                    If Not DR("point8").ToString.Trim Is System.DBNull.Value Then
                        p8 = DR("point8").ToString.Trim
                    Else
                        p8 = "0"
                    End If
                    If Not DR("grade8").ToString.Trim Is System.DBNull.Value Then
                        g8 = DR("grade8").ToString.Trim
                    Else
                        g8 = "-"
                    End If

                    If Not DR("point9").ToString.Trim Is System.DBNull.Value Then
                        p9 = DR("point9").ToString.Trim
                    Else
                        p9 = "0"
                    End If
                    If Not DR("grade9").ToString.Trim Is System.DBNull.Value Then
                        g9 = DR("grade9").ToString.Trim
                    Else
                        g9 = "-"
                    End If
                    If Not DR("point10").ToString.Trim Is System.DBNull.Value Then
                        p10 = DR("point10").ToString.Trim
                    Else
                        p10 = "0"
                    End If
                    If Not DR("grade10").ToString.Trim Is System.DBNull.Value Then
                        g10 = DR("grade10").ToString.Trim
                    Else
                        g10 = "-"
                    End If
                    If Not DR("point11").ToString.Trim Is System.DBNull.Value Then
                        p11 = DR("point11").ToString.Trim
                    Else
                        p11 = "0"
                    End If
                    If Not DR("grade11").ToString.Trim Is System.DBNull.Value Then
                        g11 = DR("grade11").ToString.Trim
                    Else
                        g11 = "-"
                    End If
                    If Not DR("point12").ToString.Trim Is System.DBNull.Value Then
                        p12 = DR("point12").ToString.Trim
                    Else
                        p12 = "0"
                    End If
                    If Not DR("grade12").ToString.Trim Is System.DBNull.Value Then
                        g12 = DR("grade12").ToString.Trim
                    Else
                        g12 = "-"
                    End If

                    If Not DR("avg2").ToString.Trim Is System.DBNull.Value Then
                        lbla2.Text = DR("avg2").ToString.Trim
                    Else
                        lbla2.Text = "0"
                    End If
                    If Not DR("avg2grade").ToString.Trim Is System.DBNull.Value Then
                        lblg2.Text = DR("avg2grade").ToString.Trim
                    Else
                        lblg2.Text = "-"
                    End If
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

            Next
        End If


    End Sub

    ''Protected Sub txtbutton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbutton.Click
    ''    If rdpurpose.SelectedValue = "" Then
    ''        MessageBox("Key in the Purpose of appraisal")
    ''        rdpurpose.Focus()
    ''        Exit Sub
    ''    End If
    ''    'If rdpurpose.SelectedValue = "1/2half" And txtperiod.Text = "" Then
    ''    '    MessageBox("Please enter the Period of Evaluation for 1/2 yearly appraisal")
    ''    '    txtperiod.Focus()
    ''    '    Exit Sub
    ''    'End If
    ''    'If rdpurpose.SelectedValue <> "1/2half" Then
    ''    '    txtperiod.Text = "0"
    ''    'End If

    ''    If rdconfirm.SelectedValue = "" Then
    ''        MessageBox("Please Select any Remarks/Recommendations")
    ''        rdpurpose.Focus()
    ''        Exit Sub
    ''    End If

    ''    If txtea.Text = "" Then
    ''        MessageBox("Please Key in your comments")
    ''        txtea.Focus()
    ''        Exit Sub
    ''    End If

    ''    Dim probation, confirm, contract, probmth

    ''    probation = "N"
    ''    confirm = "N"
    ''    contract = "N"
    ''    probmth = "0"


    ''    If rdconfirm.SelectedValue = "C" Then
    ''        confirm = "Y"
    ''    ElseIf rdconfirm.SelectedValue = "E" Then
    ''        probation = "Y"
    ''        probmth = "1"
    ''    ElseIf rdconfirm.SelectedValue = "N" Then
    ''        contract = "Y"
    ''    End If



    ''    Dim fd1 As String
    ''    fd1 = Label1.Text.Trim
    ''    Dim strdate() As String = fd1.Split("/"c)
    ''    fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

    ''    Dim fd As Date
    ''    fd = CDate(fd1)
    ''    Dim status

    ''    Try
    ''        MyGlobal.Open_Con()
    ''        MyGlobal.Con_Str()
    ''        Call MyGlobal.dbSp_open("Hrmis_insOptappraisal_ea")

    ''        Cmd.Parameters.AddWithValue("@empcode", lblemp.Text.Trim)
    ''        Cmd.Parameters.AddWithValue("@purposeofappraisal", rdpurpose.SelectedValue)
    ''        Cmd.Parameters.AddWithValue("@status", "AE")
    ''        '  Cmd.Parameters.AddWithValue("@periodofevoluation", txtperiod.Text)

    ''        Cmd.Parameters.AddWithValue("@contract", contract)
    ''        Cmd.Parameters.AddWithValue("@confirmd", rdconfirm.SelectedValue.Trim)
    ''        Cmd.Parameters.AddWithValue("@probation", probation)
    ''        Cmd.Parameters.AddWithValue("@probmonths", probmth)
    ''        Cmd.Parameters.AddWithValue("@periodofmonths", probmth)
    ''        ' Cmd.Parameters.AddWithValue("@department", )
    ''        Cmd.Parameters.AddWithValue("@remarks", lblcomment.Text)
    ''        Cmd.Parameters.AddWithValue("@remarksEA", txtea.Text)


    ''        Dim job = DirectCast(GrdOpt.Rows(0).FindControl("rdprating"), RadioButtonList).SelectedValue
    ''        Dim quality = DirectCast(GrdOpt.Rows(1).FindControl("rdprating"), RadioButtonList).SelectedValue
    ''        Dim quantity = DirectCast(GrdOpt.Rows(2).FindControl("rdprating"), RadioButtonList).SelectedValue
    ''        Dim coattitude = DirectCast(GrdOpt.Rows(3).FindControl("rdprating"), RadioButtonList).SelectedValue
    ''        Dim coworkersrelation = DirectCast(GrdOpt.Rows(4).FindControl("rdprating"), RadioButtonList).SelectedValue
    ''        Dim companyloyalty = DirectCast(GrdOpt.Rows(5).FindControl("rdprating"), RadioButtonList).SelectedValue
    ''        Dim attendancepunctuality = DirectCast(GrdOpt.Rows(6).FindControl("rdprating"), RadioButtonList).SelectedValue
    ''        Dim depend = DirectCast(GrdOpt.Rows(7).FindControl("rdprating"), RadioButtonList).SelectedValue
    ''        Dim safetyhabit = DirectCast(GrdOpt.Rows(8).FindControl("rdprating"), RadioButtonList).SelectedValue
    ''        Dim ability = DirectCast(GrdOpt.Rows(9).FindControl("rdprating"), RadioButtonList).SelectedValue
    ''        Dim total = DirectCast(GrdOpt.FooterRow.FindControl("lbltotal"), Label).Text
    ''        Dim grade = DirectCast(GrdOpt.FooterRow.FindControl("lblgrade"), Label).Text

    ''        Cmd.Parameters.AddWithValue("@job", job)
    ''        Cmd.Parameters.AddWithValue("@quality", quality)
    ''        Cmd.Parameters.AddWithValue("@quantity", quantity)
    ''        Cmd.Parameters.AddWithValue("@coattitude", coattitude)

    ''        Cmd.Parameters.AddWithValue("@coworkersrelation", coworkersrelation)
    ''        Cmd.Parameters.AddWithValue("@companyloyalty", companyloyalty)
    ''        Cmd.Parameters.AddWithValue("@attendancepunctuality", attendancepunctuality)
    ''        Cmd.Parameters.AddWithValue("@depend", depend)
    ''        Cmd.Parameters.AddWithValue("@safetyhabit", safetyhabit)
    ''        Cmd.Parameters.AddWithValue("@ability", ability)
    ''        Cmd.Parameters.AddWithValue("@total", total)
    ''        Cmd.Parameters.AddWithValue("@grade", grade)

    ''        Cmd.Parameters.AddWithValue("@dateofappraisal", fd)

    ''        Cmd.ExecuteNonQuery()

    ''        MessageBox("Appraisal Saved Successfully")
    ''        '''''' save record to app_appraisal note table to raise alert 

    ''        Dim doj As Date
    ''        Dim desig, emp
    ''        Dim dsemp As DataSet
    ''        Dim dremp As DataRow
    ''        Dim i1
    ''        Dim con As New SqlConnection(constr)
    ''        con.Open()
    ''        Dim cmd1, cmd2 As New SqlCommand
    ''        Dim dra, dra1 As SqlDataReader
    ''        Dim da As SqlDataAdapter
    ''        Dim prob1, prob2
    ''        Dim fstat
    ''        Dim datediff As Date
    ''        Dim dateexp As Date
    ''        If Session("foreigner") = "Y" Then
    ''            Dim contract1
    ''            Dim expalert
    ''            Dim contracteffectivefrom As Date

    ''            dsemp = GetEmp1()
    ''            If dsemp.Tables(0).Rows.Count <> 0 Then
    ''                Dim lcount = dsemp.Tables(0).Rows.Count
    ''                dremp = dsemp.Tables(0).Rows(i1)
    ''                doj = dremp("dateofjoin").ToString
    ''                desig = dremp("designation").ToString
    ''                emp = dremp("empcode").ToString
    ''                contract1 = dremp("contract").ToString

    ''                If Not dremp("extendcontract") Is System.DBNull.Value Then
    ''                    If dremp("extendcontract") = "Y" Then
    ''                        If Not dremp("contracteffectivefrom") Is System.DBNull.Value Then
    ''                            contracteffectivefrom = dremp("contracteffectivefrom")
    ''                            dateexp = contracteffectivefrom.AddMonths(contract1)
    ''                        Else
    ''                            dateexp = doj.AddMonths(contract1)
    ''                        End If
    ''                    Else
    ''                        dateexp = doj.AddMonths(contract1)
    ''                    End If
    ''                Else
    ''                    dateexp = doj.AddMonths(contract1)
    ''                End If

    ''                Call MyGlobal.dbSp_open("insert_appraisal_contractexpiry")
    ''                Cmd.Parameters.AddWithValue("@empcode", emp)
    ''                Cmd.Parameters.AddWithValue("@appraisal", "Y")
    ''                Cmd.Parameters.AddWithValue("@status", "AD")
    ''                Cmd.Parameters.AddWithValue("@type", "C")
    ''                Cmd.Parameters.AddWithValue("@expiry", dateexp)
    ''                Cmd.ExecuteNonQuery()
    ''            End If


    ''        ElseIf Session("foreigner") = "N" Then
    ''            cmd1 = New SqlCommand("Select * from designation where designationname = 'Operator'", con)
    ''            dra = cmd1.ExecuteReader()
    ''            While (dra.Read())
    ''                prob1 = Double.Parse(dra("probation").ToString())
    ''                Dim dsp As DataSet
    ''                Dim drp As DataRow
    ''                dsp = GetProbation(lblemp.Text.Trim)
    ''                If dsp.Tables(0).Rows.Count <> 0 Then
    ''                    'messagebox(dsp.Tables(0).Rows.Count)
    ''                    drp = dsp.Tables(0).Rows(0)
    ''                    prob2 = Double.Parse(drp("months").ToString())
    ''                    prob1 = prob1 + prob2
    ''                    'dsg = GetExplist(prob1)
    ''                End If
    ''            End While

    ''            fstat = "P"

    ''            Call MyGlobal.dbSp_open("insert_appraisal_opt")
    ''            Cmd.Parameters.AddWithValue("@empcode", lblemp.Text.Trim)
    ''            Cmd.Parameters.AddWithValue("@appraisal", "Y")
    ''            Cmd.Parameters.AddWithValue("@status", "AD")
    ''            Cmd.Parameters.AddWithValue("@prob ", prob1)
    ''            Cmd.Parameters.AddWithValue("@atype", fstat)
    ''            Cmd.ExecuteNonQuery()
    ''        End If


    ''        ' Session("optempappEA") = ""
    ''        Response.Redirect("PCExpiryListEA.aspx")
    ''    Catch ex As Exception
    ''        MessageBox(ex.Message)
    ''        Exit Sub
    ''    End Try


    ''End Sub
    Function GetEmp1() As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from empmaster where emptype = 'Contract'  and resigned = 'N' and nationality <> 'JAP' and empcode ='" & lblemp.Text.Trim & "' order by empcode", con)
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
    Function GetEmp(ByVal passno As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from app_operatorappraisal where empcode = '" & passno & "'", con)
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
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Protected Sub chkDynamic_CheckedChanged(ByVal Sender As Object, ByVal e As System.EventArgs)
        Dim points
        Dim total As Double
        Dim totpts As Double
        Dim totgrade As Double
        Dim tgrade As Double
        Dim grades
        '  Dim RB As RadioButtonList = CType(Sender, RadioButtonList)
        For i As Integer = 0 To GrdOpt.Rows.Count - 1
            Dim passno As String = GrdOpt.Rows(i).Cells(0).Text
            Dim grade As String = DirectCast(GrdOpt.Rows(i).FindControl("rdprating"), RadioButtonList).SelectedValue
            Dim grade1 As RadioButtonList = DirectCast(GrdOpt.Rows(i).FindControl("rdprating"), RadioButtonList)


            Dim x = grade1.SelectedValue
            If (x = "") Then
                x = 0
            End If
            tgrade = Double.Parse(x)
            totgrade = Double.Parse(totgrade)
            totgrade += tgrade

            ''' just for focus
            DirectCast(GrdOpt.Rows(i).FindControl("rdprating"), RadioButtonList).Focus()
        Next

        Dim pts As Integer
        pts = totgrade
        If pts >= 50 And pts <= 45 Then
            grades = "A"
        ElseIf pts >= 40 And pts <= 44 Then
            grades = "B"
        ElseIf pts >= 35 And pts <= 39 Then
            grades = "C"
        ElseIf pts >= 30 And pts <= 34 Then
            grades = "D"
        ElseIf pts <= 29 Then
            grades = "E"
        End If
        DirectCast(GrdOpt.FooterRow.FindControl("Lbltotal"), Label).Text = totgrade
        DirectCast(GrdOpt.FooterRow.FindControl("Lblgrade"), Label).Text = grades
        'calculateGrade(totgrade)
    End Sub

    'Protected Sub rdpurpose_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdpurpose.SelectedIndexChanged
    '    If rdpurpose.SelectedValue = "1/2 Yearly" Then
    '        ddlhalf.Visible = True
    '        lblapp.Visible = True
    '    Else
    '        ddlhalf.Visible = False
    '        lblapp.Visible = False
    '    End If
    'End Sub
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

   
End Class