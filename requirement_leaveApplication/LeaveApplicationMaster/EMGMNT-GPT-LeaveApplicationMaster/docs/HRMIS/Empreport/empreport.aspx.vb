Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class empreport
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim empno, sqltext
    Dim rdr As SqlDataReader
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim doj, thisdate As Date
    Dim cancfwd, appno As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cmd As New SqlCommand
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        MyApp.GetfiscalYear()
        con = New SqlConnection(constr)
        con.Open()
        If IsPostBack = False Then
            empcode.Focus()
        End If

        thisdate = DateTime.Now.ToShortDateString()
    End Sub
    Protected Sub empcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles empcode.TextChanged

        Dim txtempcode = empcode.Text
        Dim _eid = empcode.Text
        GetEmpVehinoall(txtempcode)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                empname.Text = dr("empname").ToString
                dob.Text = Format(Convert.ToDateTime(dr("dateofbirth")), "dd/MM/yyyy")
                oldicno.Text = dr("icno").ToString
                If Not dr("newicno") Is System.DBNull.Value Then
                    newicno.Text = dr("newicno").ToString
                Else
                    newicno.Text = "-"
                End If
                If Not dr("passportno") Is System.DBNull.Value Then
                    Passportno.Text = dr("passportno").ToString
                Else
                    Passportno.Text = "-"
                End If

                gender.Text = dr("sex").ToString
                race.Text = dr("race").ToString
                religion.Text = dr("religion").ToString
                maritalstatus.Text = dr("maritalStatus").ToString
                nationality.Text = dr("nationality").ToString
                qualification.Text = dr("edulevel").ToString
                address.Text = dr("address1").ToString
                If Not dr("email") Is System.DBNull.Value Then
                    email.Text = dr("email").ToString
                Else
                    email.Text = "-"
                End If

                If Not dr("php") Is System.DBNull.Value Then
                    telephone.Text = dr("php").ToString
                Else
                    telephone.Text = "-"
                End If
                If Not dr("pphone") Is System.DBNull.Value Then
                    mobile.Text = dr("pphone").ToString
                Else
                    mobile.Text = "-"
                End If

                route.Text = dr("route").ToString
                area.Text = dr("area").ToString
                dojemp.Text = Format(Convert.ToDateTime(dr("dateofjoin")), "dd/MM/yyyy")
                designation.Text = dr("designation").ToString
                foreignworker.Text = dr("foreignemp").ToString
                deptcode.Text = dr("departmentcode").ToString
                deptname.Text = dr("departmentname").ToString
                If Not dr("epf") Is System.DBNull.Value Then
                    epfno.Text = dr("epf").ToString
                Else
                    epfno.Text = "-"
                End If
                sectioncode.Text = dr("sectioncode").ToString
                sectionname.Text = dr("sectionname").ToString
                '  experience.Text = dr("yearofexp").ToString
                employmentstatus.Text = dr("emptype").ToString

                If Not dr("contracteffectivefrom") Is System.DBNull.Value Then
                    contracteffectivefrom.Text = Format(Convert.ToDateTime(dr("contracteffectivefrom")), "dd/MM/yyyy")
                Else
                    contracteffectivefrom.Text = "-"
                End If
                contractperiod.Text = dr("contract").ToString
                category.Text = dr("category").ToString
                resigned.Text = dr("resigned").ToString
                If Not dr("dateoftermination") Is System.DBNull.Value Then
                    dateofresign.Text = Format(Convert.ToDateTime(dr("dateoftermination")), "dd/MM/yyyy")
                Else
                    dateofresign.Text = "-"
                End If
                If mobile.Text = "0" Then
                    mobile.Text = "-"
                End If
            Else
                MessageBox("EmployeeCode doesnot Exist!!")
                empcode.Text = ""
                empcode.Focus()
                Exit Sub
            End If
        End If
        If dob.Text.Contains("12:00:00 AM") = True Then
            dob.Text = dob.Text.Replace("12:00:00 AM", "")
        End If
        If dojemp.Text.Contains("12:00:00 AM") = True Then
            dojemp.Text = dojemp.Text.Replace("12:00:00 AM", "")
        End If
        If contracteffectivefrom.Text.Contains("12:00:00 AM") = True Then
            contracteffectivefrom.Text = contracteffectivefrom.Text.Replace("12:00:00 AM", "")
        End If

        GridView1.DataBind()
        cliniccalculation()
        GridView2.DataBind()
        GridView3.DataBind()
        GridView4.DataBind()
        loadgridexp()
        loadgridverb()
        loadgridfirstwarning()
        loadgridfinalwarning()
        loadgridcounselling()
        loadgridmisfirst()
        loadgridmisfinal()
        loadgridshowcause()
        loadgridformaladvice()
        loadgridwrittenwarning()
        loadgridanytypeofletter()
        Leavecalculation()
    End Sub
    Public Sub Leavecalculation()
        thisdate = DateTime.Now.ToShortDateString()

        If Date.Today.Year = 2019 Then
            MyApp.GetfiscalYear()
            MyApp.GetfiscalYearforLeave()
        Else
            MyApp.GetfiscalYearforLeave()
            _fisyrStart = _fisyrStart1
            _fisyrEnd = _fisyrEnd1
        End If

        ' Get the date of join of emp 
        GetEmpVehino(empcode.Text)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                If Not dr("dateofservice") Is System.DBNull.Value Then
                    doj = dr("dateofservice").ToString
                Else
                    doj = dr("dateofjoin").ToString
                End If
            End If
        Else
            ''lblmsg.Text = MyerrorMsg
            ''lblmsg.ForeColor = Drawing.Color.Red

        End If
        ' find the experience of employee
        Dim exp As String
        Dim ann As Decimal
        Dim med As Decimal
        Dim probation As Decimal
        Dim expr As Integer
        Dim expmth As Integer
        Dim expdays As Integer ' 11-02-2014
        expr = 0
        ann = 0
        med = 0
        probation = 0

        exp = thisdate.Subtract(doj).Days
        expdays = exp ' 11-02-2014
        expmth = exp / 30
        exp = Math.Round(expmth / 12, 1)

        If exp < 2 Then
            expr = 2
        ElseIf exp >= 2 And exp < 5 Then
            expr = 3
        ElseIf exp >= 5 Then
            expr = 5
        End If

        ' Get the leave entitilement of the employee
        GetLeaveLevel(empcode.Text, expr)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                'doj = dr("dateofjoin").ToString
                ann = dr("annual").ToString
                med = dr("medical").ToString
                probation = dr("probation").ToString

                If CheckDate(_fisyrStart, doj) = 1 Then
                    If _fisyrStart.Subtract(doj).Days < 365 Then
                        ann = Math.Round((_fisyrStart.Subtract(doj).Days / 365) * ann, 0)
                    End If
                Else
                    ann = 0
                End If
                ''11-02-2014##END##
            End If
        Else
            ''lblmsg.Text = MyerrorMsg
            ''lblmsg.ForeColor = Drawing.Color.Red
        End If

        '########

       

        '########
        annleave.Text = ann
        medleave.Text = med

        ' Get the balance annual and Medical leave
        Dim leavetaken As Decimal
        leavetaken = 0
        Dim mLeavetaken As Decimal
        mLeavetaken = 0
        Dim balAleave As Decimal
        balAleave = 0
        Dim balMleave As Decimal
        balMleave = 0

        CountAnnualLeaveTaken(empcode.Text, _fisyrStart, _fisyrEnd)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                If dr("annual") Is System.DBNull.Value Then
                    leavetaken = 0
                Else
                    leavetaken = Val(dr("annual").ToString & "")
                End If
            End If
        Else
            ''lblmsg.Text = MyerrorMsg
            ''lblmsg.ForeColor = Drawing.Color.Red
        End If
        balAleave = ann - leavetaken
        balann.Text = balAleave

        CountMedicalLeaveTaken(empcode.Text, _fisyrStart, _fisyrEnd)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                If dr("medical") Is System.DBNull.Value Then
                    mLeavetaken = 0
                Else
                    mLeavetaken = dr("medical").ToString
                End If
            End If
        Else
            ''lblmsg.Text = MyerrorMsg
            ''lblmsg.ForeColor = Drawing.Color.Red
        End If

        balMleave = med - mLeavetaken
        balmed.Text = balMleave
        '  carry forward Calculation
        Dim curMth As Integer = Month(thisdate)
        Dim curyear As Integer = Year(thisdate)

        Dim cfwd As Decimal
        Dim rcfwd As Decimal
        Dim startdate As Date
        Dim enddate As Date
        Dim LyutilisedLeave As Decimal
        Dim LyBalLeave As Decimal
        Dim LyannLeave As Decimal
        Dim LyannLeave1 As Decimal
        If curMth <> 0 Then
            'If curMth = 4 Or curMth = 5 Or curMth = 6 Then
            Session(cancfwd) = "Y"

            If Date.Today.Year = 2019 Then
                If curMth = 1 Or curMth = 2 Or curMth = 3 Then
                    GetCfwdLeave(empcode.Text, curyear - 1)
                Else
                    GetCfwdLeave(empcode.Text, curyear)
                End If
            Else
                GetCfwdLeave(empcode.Text, curyear)
            End If

            If recstatus = True Then
                Dim drx As DataRow
                If dsdata.Tables(0).Rows.Count > 0 Then
                    drx = dsdata.Tables(0).Rows(0)
                    If drx("cfwd") Is System.DBNull.Value Then
                        cfwd = 0
                    Else
                        cfwd = drx("cfwd").ToString
                    End If
                    'End If
                    'If dsdata.Tables(0).Rows.Count > 0 Then
                    '    dr = dsdata.Tables(0).Rows(0)
                    If drx("remain") Is System.DBNull.Value Then
                        cfwd = 0
                    Else
                        rcfwd = drx("remain").ToString
                    End If

                Else
                    'CHECK STORED PROCEDURE

                    startdate = _fisyrStart.AddYears(-1)
                    enddate = _fisyrEnd.AddYears(-1)
                    'Get Annual entitilement levae for last year
                    exp = enddate.Subtract(doj).Days
                    exp = exp / 30
                    exp = Math.Round(exp / 12, 1)

                    If exp < 2 Then
                        expr = 2
                    ElseIf exp >= 2 And exp < 5 Then
                        expr = 3
                    ElseIf exp >= 5 Then
                        expr = 5
                    End If
                    'Get Annual entitilement levae for last year
                    GetLeaveLevel(empcode.Text, expr)
                    If recstatus = True Then
                        Dim dr As DataRow
                        If dsdata.Tables(0).Rows.Count > 0 Then
                            dr = dsdata.Tables(0).Rows(0)
                            'doj = dr("dateofjoin").ToString
                            LyannLeave = dr("annual").ToString
                            LyannLeave1 = dr("annual1").ToString
                        End If
                    Else
                        ''lblmsg.Text = MyerrorMsg
                        ''lblmsg.ForeColor = Drawing.Color.Red
                    End If
                    ' Insert carryforwardrecord

                    SetCfwdLeave(empcode.Text, startdate, enddate)

                    'MessageBox((recstatus & "-" & dsdata.Tables(0).Rows.Count))

                    If recstatus = True Then
                        Dim dr As DataRow
                        If dsdata.Tables(0).Rows.Count > 0 Then
                            dr = dsdata.Tables(0).Rows(0)
                            If dr("leavetaken") Is System.DBNull.Value Then
                                LyutilisedLeave = LyannLeave1
                                cfwd = LyannLeave1
                                rcfwd = LyannLeave1
                            Else
                                LyutilisedLeave = dr("leavetaken").ToString
                            End If
                        Else
                            LyutilisedLeave = 0 '- 11042014
                        End If
                    Else
                        LyutilisedLeave = 0 '- 11042014
                        ''lblmsg.Text = MyerrorMsg & " Record not saved..Try again"
                        ''lblmsg.ForeColor = Drawing.Color.Red
                    End If
                    LyBalLeave = LyannLeave1 - LyutilisedLeave
                    'MessageBox(LyBalLeave & "-" & LyannLeave & "-" & LyutilisedLeave & "-")
                    If LyBalLeave <= 0 Then
                        cfwd = 0
                        rcfwd = 0
                        LyBalLeave = 0
                    ElseIf LyBalLeave >= 3 Then
                        cfwd = LyBalLeave
                        rcfwd = LyBalLeave
                    ElseIf LyBalLeave > 0 And LyBalLeave < 3 Then
                        cfwd = LyBalLeave
                        rcfwd = LyBalLeave
                    End If

                    If enddate.Subtract(doj).Days < 365 Then
                        InsertcfwdLeave(empcode.Text, 0, curyear, 0, 0)
                        LyBalLeave = 0
                        rcfwd = 0
                        cfwd = 0

                    Else
                        InsertcfwdLeave(empcode.Text, LyBalLeave, curyear, rcfwd, cfwd)
                    End If
                End If
                cryfwdleave.Text = cfwd
                balcryfwd.Text = rcfwd
            End If
        Else
            Session(cancfwd) = "N"
            cryfwdleave.Text = 0
            balcryfwd.Text = 0
        End If
        ' Prorate Calculation
        Dim prorate As Decimal
        Dim workeddays As Decimal

        prorate = 0
        workeddays = 0
        If expmth >= probation Then
            If doj > _fisyrStart Then
                workeddays = thisdate.Subtract(doj).Days
                prorate = (workeddays / 365) * ann
                prorate = Val(Math.Round(ann - leavetaken, 1)) + Val(balcryfwd.Text)
            Else
                If Date.Today.Year = 2019 Then
                    workeddays = thisdate.Subtract(_fisyrStart1).Days
                Else
                    workeddays = thisdate.Subtract(_fisyrStart).Days
                End If

                prorate = (workeddays / 365) * ann
                'prorate = Math.Round(prorate, 1)
                ''prorate = Math.Round(prorate - leavetaken, 1)
                prorate = Val(Math.Round(ann - leavetaken, 1)) + Val(balcryfwd.Text)

            End If
        Else
            'MessageBox("experience is less than probation period - Exp: " & expmth & ", Probation Period - " & probation)
            prorate = 0
            cryfwdleave.Text = 0
            balcryfwd.Text = 0
        End If
        eligibleleave.Text = prorate

        LblAU.Text = Val(annleave.Text) - Val(balann.Text)
        LblCFU.Text = Val(cryfwdleave.Text) - Val(balcryfwd.Text)
        LblMU.Text = Val(medleave.Text) - Val(balmed.Text)


    End Sub

    Public Sub Leavecalculation1()
        ' Get the date of join of emp 
        _eid = empcode.Text
        GetEmpVehinoall(_eid)
        Dim dor As Date

        'If recstatus = True Then
        '    Dim dr As DataRow
        '    If dsdata.Tables(0).Rows.Count > 0 Then
        '        dr = dsdata.Tables(0).Rows(0)
        '        'doj = dr("dateofjoin").ToString
        '        If Not dr("dateofservice") Is System.DBNull.Value Then
        '            doj = dr("dateofservice").ToString
        '        Else
        '            doj = dr("dateofjoin").ToString
        '        End If
        '        If Not dr("dateoftermination") Is System.DBNull.Value Then
        '            dor = dr("dateoftermination").ToString
        '        End If
        '    End If
        'End If

        ''find the experience of employee
        'Dim exp As String
        'Dim ann As Decimal
        'Dim med As Decimal
        'Dim probation As Decimal
        'Dim expr As Integer
        'Dim expmth As Integer
        'expr = 0
        'ann = 0
        'med = 0
        'probation = 0
        'If resigned.Text = "N" Then
        '    exp = thisdate.Subtract(doj).Days
        '    expmth = exp / 30
        '    exp = Math.Round(expmth / 12, 1)
        'ElseIf resigned.Text = "Y" Then
        '    exp = dor.Subtract(doj).Days
        '    expmth = exp / 30
        '    exp = Math.Round(expmth / 12, 1)

        'End If

        'If exp < 2 Then
        '    expr = 2
        'ElseIf exp >= 2 And exp < 5 Then
        '    expr = 3
        'ElseIf exp >= 5 Then
        '    expr = 5
        'End If

        'experience.Text = exp

        '' Get the leave entitilement of the employee
        'GetLeaveLevel(_eid, expr)
        'If recstatus = True Then
        '    Dim dr As DataRow
        '    If dsdata.Tables(0).Rows.Count > 0 Then
        '        dr = dsdata.Tables(0).Rows(0)
        '        'doj = dr("dateofjoin").ToString
        '        ann = dr("annual").ToString
        '        med = dr("medical").ToString
        '        probation = dr("probation").ToString
        '    End If
        'End If
        'annleave.Text = ann
        'medleave.Text = med

        '' Get the balance annual and Medical leave
        'Dim leavetaken As Decimal
        'leavetaken = 0
        'Dim mLeavetaken As Decimal
        'mLeavetaken = 0
        'Dim balAleave As Decimal
        'balAleave = 0
        'Dim balMleave As Decimal
        'balMleave = 0

        'CountAnnualLeaveTaken(_eid, _fisyrStart, _fisyrEnd)
        'If recstatus = True Then
        '    Dim dr As DataRow
        '    If dsdata.Tables(0).Rows.Count > 0 Then
        '        dr = dsdata.Tables(0).Rows(0)
        '        If dr("annual") Is System.DBNull.Value Then
        '            leavetaken = 0
        '        Else
        '            leavetaken = dr("annual").ToString
        '        End If
        '    End If
        'End If
        'balAleave = ann - leavetaken
        'balann.Text = balAleave

        'CountMedicalLeaveTaken(_eid, _fisyrStart, _fisyrEnd)
        'If recstatus = True Then
        '    Dim dr As DataRow
        '    If dsdata.Tables(0).Rows.Count > 0 Then
        '        dr = dsdata.Tables(0).Rows(0)
        '        If dr("medical") Is System.DBNull.Value Then
        '            mLeavetaken = 0
        '        Else
        '            mLeavetaken = dr("medical").ToString
        '        End If
        '    End If
        'End If

        'balMleave = med - mLeavetaken
        'balmed.Text = balMleave
        ''  carry forward Calculation
        'Dim curMth As Integer = Month(thisdate)
        'Dim curyear As Integer = Year(thisdate)

        'Dim cfwd As Decimal
        'Dim rcfwd As Decimal
        'Dim startdate As Date
        'Dim enddate As Date
        'Dim LyutilisedLeave As Decimal
        'Dim LyBalLeave As Decimal
        'Dim LyannLeave As Decimal

        'If curMth = 4 Or curMth = 5 Or curMth = 6 Then
        '    Session(cancfwd) = "Y"
        '    GetCfwdLeave(_eid, curyear)
        '    If recstatus = True Then
        '        Dim drx As DataRow
        '        If dsdata.Tables(0).Rows.Count > 0 Then
        '            drx = dsdata.Tables(0).Rows(0)
        '            If drx("cfwd") Is System.DBNull.Value Then
        '                cfwd = 0
        '            Else
        '                cfwd = drx("cfwd").ToString
        '            End If
        '            'End If
        '            'If dsdata.Tables(0).Rows.Count > 0 Then
        '            '    dr = dsdata.Tables(0).Rows(0)
        '            If drx("remain") Is System.DBNull.Value Then
        '                cfwd = 0
        '            Else
        '                rcfwd = drx("remain").ToString
        '            End If

        '        Else
        '            startdate = _fisyrStart.AddYears(-1)
        '            enddate = _fisyrEnd.AddYears(-1)
        '            'Get Annual entitilement levae for last year
        '            exp = enddate.Subtract(doj).Days
        '            exp = exp / 30
        '            exp = Math.Round(exp / 12, 1)

        '            If exp < 2 Then
        '                expr = 2
        '            ElseIf exp >= 2 And exp < 5 Then
        '                expr = 3
        '            ElseIf exp >= 5 Then
        '                expr = 5
        '            End If
        '            'Get Annual entitilement levae for last year
        '            GetLeaveLevel(_eid, expr)
        '            If recstatus = True Then
        '                Dim dr As DataRow
        '                If dsdata.Tables(0).Rows.Count > 0 Then
        '                    dr = dsdata.Tables(0).Rows(0)
        '                    'doj = dr("dateofjoin").ToString
        '                    LyannLeave = dr("annual").ToString
        '                End If
        '            Else
        '                '  lblmsg.Text = MyerrorMsg
        '                'lblmsg.ForeColor = Drawing.Color.Red
        '            End If
        '            ' Insert carryforwardrecord
        '            SetCfwdLeave(_eid, startdate, enddate)
        '            If recstatus = True Then
        '                Dim dr As DataRow
        '                If dsdata.Tables(0).Rows.Count > 0 Then
        '                    dr = dsdata.Tables(0).Rows(0)
        '                    If dr("leavetaken") Is System.DBNull.Value Then
        '                        LyutilisedLeave = LyannLeave
        '                        cfwd = 3
        '                        rcfwd = 3
        '                    Else
        '                        LyutilisedLeave = dr("leavetaken").ToString
        '                    End If
        '                End If
        '            Else
        '                'lblmsg.Text = MyerrorMsg & " Record not saved..Try again"
        '                ' lblmsg.ForeColor = Drawing.Color.Red
        '            End If
        '            LyBalLeave = LyannLeave - LyutilisedLeave
        '            If LyBalLeave <= 0 Then
        '                cfwd = 0
        '                rcfwd = 0
        '                LyBalLeave = 0
        '            ElseIf LyBalLeave >= 3 Then
        '                cfwd = 3
        '                rcfwd = 3
        '            ElseIf LyBalLeave > 0 And LyBalLeave < 3 Then
        '                cfwd = LyBalLeave
        '                rcfwd = LyBalLeave
        '            End If
        '            InsertcfwdLeave(_eid, LyBalLeave, curyear, rcfwd, cfwd)
        '        End If
        '        cryfwdleave.Text = 0
        '        balcryfwd.Text = 0
        '    End If
        'Else
        '    Session(cancfwd) = "N"
        '    cryfwdleave.Text = 0
        '    balcryfwd.Text = 0
        'End If
        '' Prorate Calculation
        'Dim prorate As Decimal
        'Dim workeddays As Decimal

        'prorate = 0
        'workeddays = 0
        'If expmth >= probation Then
        '    If doj > _fisyrStart Then
        '        workeddays = thisdate.Subtract(doj).Days
        '        prorate = (workeddays / 365) * ann
        '        prorate = Math.Round(prorate - leavetaken, 1)
        '    Else
        '        workeddays = thisdate.Subtract(_fisyrStart).Days
        '        prorate = (workeddays / 365) * ann
        '        'prorate = Math.Round(prorate, 1)
        '        prorate = Math.Round(prorate - leavetaken, 1)
        '    End If
        'Else
        '    prorate = 0
        'End If
        'eligibleleave.Text = prorate
        'ElseIf resigned.Text = "Y" Then
        '    exp = dor.Subtract(doj).Days
        '    expmth = exp / 30
        '    exp = Math.Round(expmth / 12, 1)
        '    experience.Text = exp

        '    annleave.Text = "-"
        '    medleave.Text = "-"
        '    balann.Text = "-"
        '    balmed.Text = "-"
        '    eligibleleave.Text = "-"
        '    cryfwdleave.Text = "-"
        '    balcryfwd.Text = "-"

        'End If

        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                If Not dr("dateofservice") Is System.DBNull.Value Then
                    doj = dr("dateofservice").ToString
                Else
                    doj = dr("dateofjoin").ToString
                End If
            End If
        Else
            ' lblmsg.Text = MyerrorMsg
            ' lblmsg.ForeColor = Drawing.Color.Red

        End If
        ' find the experience of employee
        Dim exp As String
        Dim ann As Decimal
        Dim med As Decimal
        Dim probation As Decimal
        Dim expr As Integer
        Dim expmth As Integer
        Dim expdays As Integer ' 11-02-2014
        expr = 0
        ann = 0
        med = 0
        probation = 0

        exp = thisdate.Subtract(doj).Days
        expdays = exp ' 11-02-2014
        expmth = exp / 30
        exp = Math.Round(expmth / 12, 1)

        If exp < 2 Then
            expr = 2
        ElseIf exp >= 2 And exp < 5 Then
            expr = 3
        ElseIf exp >= 5 Then
            expr = 5
        End If

        ' Get the leave entitilement of the employee
        GetLeaveLevel(_eid, expr)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                'doj = dr("dateofjoin").ToString
                ann = dr("annual").ToString
                med = dr("medical").ToString
                probation = dr("probation").ToString
                ''11-02-2014 to show exact annual leave / medical leave of those who joined in the middle '''
                If expdays < 365 Then
                    expdays = DateDiff(DateInterval.Day, doj, _fisyrEnd)
                    If expdays < 365 Then
                        ann = Math.Round((expdays / 365) * ann, 0)
                        med = Math.Round((expdays / 365) * med, 0)
                    Else

                    End If
                End If
                ''11-02-2014##END##
            End If
        Else
            ' lblmsg.Text = MyerrorMsg
            '  lblmsg.ForeColor = Drawing.Color.Red
        End If
        annleave.Text = ann
        medleave.Text = med

        ' Get the balance annual and Medical leave
        Dim leavetaken As Decimal
        leavetaken = 0
        Dim mLeavetaken As Decimal
        mLeavetaken = 0
        Dim balAleave As Decimal
        balAleave = 0
        Dim balMleave As Decimal
        balMleave = 0

        CountAnnualLeaveTaken(_eid, _fisyrStart, _fisyrEnd)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                If dr("annual") Is System.DBNull.Value Then
                    leavetaken = 0
                Else
                    leavetaken = dr("annual").ToString
                End If
            End If
        Else
            ' lblmsg.Text = MyerrorMsg
            'lblmsg.ForeColor = Drawing.Color.Red
        End If
        balAleave = ann - leavetaken
        balann.Text = balAleave

        CountMedicalLeaveTaken(_eid, _fisyrStart, _fisyrEnd)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                If dr("medical") Is System.DBNull.Value Then
                    mLeavetaken = 0
                Else
                    mLeavetaken = dr("medical").ToString
                End If
            End If
        Else
            'lblmsg.Text = MyerrorMsg
            '      lblmsg.ForeColor = Drawing.Color.Red
        End If

        balMleave = med - mLeavetaken
        balmed.Text = balMleave
        '  carry forward Calculation
        Dim curMth As Integer = Month(thisdate)
        Dim curyear As Integer = Year(thisdate)

        Dim cfwd As Decimal
        Dim rcfwd As Decimal
        Dim startdate As Date
        Dim enddate As Date
        Dim LyutilisedLeave As Decimal
        Dim LyBalLeave As Decimal
        Dim LyannLeave As Decimal

        If curMth = 4 Or curMth = 5 Or curMth = 6 Then
            Session(cancfwd) = "Y"
            GetCfwdLeave(_eid, curyear)
            If recstatus = True Then
                Dim drx As DataRow
                If dsdata.Tables(0).Rows.Count > 0 Then
                    drx = dsdata.Tables(0).Rows(0)
                    If drx("cfwd") Is System.DBNull.Value Then
                        cfwd = 0
                    Else
                        cfwd = drx("cfwd").ToString
                    End If
                    'End If
                    'If dsdata.Tables(0).Rows.Count > 0 Then
                    '    dr = dsdata.Tables(0).Rows(0)
                    If drx("remain") Is System.DBNull.Value Then
                        cfwd = 0
                    Else
                        rcfwd = drx("remain").ToString
                    End If

                Else
                    startdate = _fisyrStart.AddYears(-1)
                    enddate = _fisyrEnd.AddYears(-1)
                    'Get Annual entitilement levae for last year
                    exp = enddate.Subtract(doj).Days
                    exp = exp / 30
                    exp = Math.Round(exp / 12, 1)

                    If exp < 2 Then
                        expr = 2
                    ElseIf exp >= 2 And exp < 5 Then
                        expr = 3
                    ElseIf exp >= 5 Then
                        expr = 5
                    End If
                    'Get Annual entitilement levae for last year
                    GetLeaveLevel(_eid, expr)
                    If recstatus = True Then
                        Dim dr As DataRow
                        If dsdata.Tables(0).Rows.Count > 0 Then
                            dr = dsdata.Tables(0).Rows(0)
                            'doj = dr("dateofjoin").ToString
                            LyannLeave = dr("annual").ToString
                        End If
                    Else
                        ' lblmsg.Text = MyerrorMsg
                        ' lblmsg.ForeColor = Drawing.Color.Red
                    End If
                    ' Insert carryforwardrecord
                    SetCfwdLeave(_eid, startdate, enddate)
                    If recstatus = True Then
                        Dim dr As DataRow
                        If dsdata.Tables(0).Rows.Count > 0 Then
                            dr = dsdata.Tables(0).Rows(0)
                            If dr("leavetaken") Is System.DBNull.Value Then
                                LyutilisedLeave = LyannLeave
                                cfwd = 3
                                rcfwd = 3
                            Else
                                LyutilisedLeave = dr("leavetaken").ToString
                            End If
                        End If
                    Else
                        '  lblmsg.Text = MyerrorMsg & " Record not saved..Try again"
                        '  lblmsg.ForeColor = Drawing.Color.Red
                    End If
                    LyBalLeave = LyannLeave - LyutilisedLeave
                    If LyBalLeave <= 0 Then
                        cfwd = 0
                        rcfwd = 0
                        LyBalLeave = 0
                    ElseIf LyBalLeave >= 3 Then
                        cfwd = 3
                        rcfwd = 3
                    ElseIf LyBalLeave > 0 And LyBalLeave < 3 Then
                        cfwd = LyBalLeave
                        rcfwd = LyBalLeave
                    End If
                    InsertcfwdLeave(_eid, LyBalLeave, curyear, rcfwd, cfwd)
                End If
                cryfwdleave.Text = cfwd
                balcryfwd.Text = rcfwd
            End If
        Else
            Session(cancfwd) = "N"
            cryfwdleave.Text = 0
            balcryfwd.Text = 0
        End If
        ' Prorate Calculation
        Dim prorate As Decimal
        Dim workeddays As Decimal

        prorate = 0
        workeddays = 0
        If expmth >= probation Then
            If doj > _fisyrStart Then
                workeddays = thisdate.Subtract(doj).Days
                prorate = (workeddays / 365) * ann
                prorate = Math.Round(prorate - leavetaken, 1)
            Else
                workeddays = thisdate.Subtract(_fisyrStart).Days
                prorate = (workeddays / 365) * ann
                'prorate = Math.Round(prorate, 1)
                prorate = Math.Round(prorate - leavetaken, 1)
            End If
        Else
            prorate = 0
        End If
        eligibleleave.Text = prorate

    End Sub

    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        For i As Integer = 0 To GridView1.Rows.Count - 1
            Dim sts = GridView1.Rows(i).Cells(5).Text
            If sts = "s" Or sts = "S" Or sts = "scheduled" Or sts = "Scheduled" Then
                GridView1.Rows(i).Cells(5).Text = "SCHEDULED"
                GridView1.Rows(i).Cells(5).ForeColor = Drawing.Color.Orange
            ElseIf sts = "A" Or sts = "a" Or sts = "APPROVED" Or sts = "approved" Then
                GridView1.Rows(i).Cells(5).Text = "APPROVED"
                GridView1.Rows(i).Cells(5).ForeColor = Drawing.Color.Green
            ElseIf sts = "c" Or sts = "C" Or sts = "CANCELLED" Or sts = "cancelled" Then
                GridView1.Rows(i).Cells(5).Text = "CANCELLED"
                GridView1.Rows(i).Cells(5).ForeColor = Drawing.Color.Red
            End If
        Next
    End Sub
    Sub cliniccalculation()
        'Dim rdr As SqlDataReader
        Dim total, amount, result As Double
        Dim yr = Year(Date.Now)
        total = 150
        Dim con As New SqlConnection(constr)
        con.Open()
        sqltext = "select sum(billamount) from tbldiagnose where empno='" & (empcode.Text) & "'"
        cmd = New SqlCommand(sqltext, con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            amount = rdr(0) & "0"   'if null occurs so  adding (& "-")
        End While
        rdr.Close()
        If total >= amount Then
            result = total - amount
            balance.Text = result
        Else
            result = amount - total
            personalpayment.Text = result
        End If
    End Sub
    Private Sub SqlDataSource1_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlDataSource1.Selecting
        Dim curyear, eid
        eid = empcode.Text
        curyear = Year(Date.Now)
        e.Command.Parameters(0).Value = eid
    End Sub
    Protected Sub SqlDataSource2_Selecting(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlDataSource2.Selecting
        Dim empcod = empcode.Text
        e.Command.Parameters(0).Value = empcod
    End Sub
    Protected Sub SqlDataSource3_Selecting(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlDataSource3.Selecting
        Dim empcod = empcode.Text
        e.Command.Parameters(0).Value = empcod
    End Sub
    Private Sub SqlDataSource4_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlDataSource4.Selecting
        Dim empcod = empcode.Text
        e.Command.Parameters(0).Value = empcod
    End Sub
    Private Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowDataBound
        For i As Integer = 0 To GridView2.Rows.Count - 1
            If GridView2.Rows(i).Cells(2).Text.Contains("12/30/1899") = True Then
                GridView2.Rows(i).Cells(2).Text = GridView2.Rows(i).Cells(2).Text.Replace("12/30/1899", "")
            ElseIf GridView2.Rows(i).Cells(3).Text.Contains("12/30/1899") = True Then
                GridView2.Rows(i).Cells(3).Text = GridView2.Rows(i).Cells(3).Text.Replace("12/30/1899", "")
            End If
        Next
    End Sub
    Public Sub loadgridexp()
        'Dim rdr As SqlDataReader
        'con = New SqlConnection(constr)
        ''con.open()
        sqltext = "select count(empcode) from er_explanation where empcode='" & (empcode.Text) & "'"
        cmd = New SqlCommand(sqltext, con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            expcount.Text = rdr(0)
        End While
        rdr.Close()
        If Val(expcount.Text) > 0 Then
            sqltext = "select (vdate)as LetterDate,(subjectrefer)as SubjectReference,(fdate)as FollowingDatesReference from er_explanation where empcode='" & (empcode.Text) & "'"
            DS = GetappCharactersetting(sqltext)
            GridView5.DataSource = DS
            GridView5.DataBind()
            For i As Integer = 0 To GridView5.Rows.Count - 1
                If GridView5.Rows(i).Cells(0).Text.Contains("12:00:00 AM") = True Then
                    GridView5.Rows(i).Cells(0).Text = GridView5.Rows(i).Cells(0).Text.Replace("12:00:00 AM", "")
                End If
            Next
        End If
    End Sub
    Sub loadgridverb()
        'Dim rdr As SqlDataReader
        'con = New SqlConnection(constr)
        'con.open()
        sqltext = "select count(empcode) from er_verbalwarning where empcode='" & (empcode.Text) & "'"
        cmd = New SqlCommand(sqltext, con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            verbcount.Text = rdr(0)
        End While
        rdr.Close()
        If Val(verbcount.Text) > 0 Then
            sqltext = "select (vdate)as LetterDate,(desmisconduct)as Description,ActionTaken,(sempcode)as Superior from er_verbalwarning where empcode= '" & (empcode.Text) & "'"
            DS = GetappCharactersetting(sqltext)
            GridView6.DataSource = DS
            GridView6.DataBind()
            For i As Integer = 0 To GridView6.Rows.Count - 1
                If GridView6.Rows(i).Cells(0).Text.Contains("12:00:00 AM") = True Then
                    GridView6.Rows(i).Cells(0).Text = GridView6.Rows(i).Cells(0).Text.Replace("12:00:00 AM", "")
                End If
            Next
        End If
    End Sub
    Sub loadgridfirstwarning()
        'con.open()
        sqltext = "select count(empcode) from er_misfirstwarning where empcode='" & (empcode.Text) & "' and  year(vdate)=year(getdate())"
        cmd = New SqlCommand(sqltext, con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            countfirstwarning.Text = rdr(0)
        End While
        rdr.Close()
        If countfirstwarning.Text > 0 Then
            sqltext = "select (vdate)as LettetDate,(desmisconduct)as SummaryOfTopic,(verbalwdate)as CounselingDate  from er_misfirstwarning where empcode='" & (empcode.Text) & "'"
            DS = GetappCharactersetting(sqltext)
            GridView7.DataSource = DS
            GridView7.DataBind()
            For i As Integer = 0 To GridView7.Rows.Count - 1
                If GridView7.Rows(i).Cells(0).Text.Contains("12:00:00 AM") = True Then
                    GridView7.Rows(i).Cells(0).Text = GridView7.Rows(i).Cells(0).Text.Replace("12:00:00 AM", "")
                End If
            Next
        End If
    End Sub
    Sub loadgridfinalwarning()
        'con.open()
        sqltext = "select count(empcode) from er_misfinalwarning where empcode='" & (empcode.Text) & "'"
        cmd = New SqlCommand(sqltext, con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            countfinalwarning.Text = rdr(0)
        End While
        rdr.Close()
        If countfinalwarning.Text > 0 Then
            sqltext = "select vdate as LetterDate,misconduct as SummaryOfTopic from er_misfinalwarning where empcode='" & (empcode.Text) & "'"
            DS = GetappCharactersetting(sqltext)
            GridView8.DataSource = DS
            GridView8.DataBind()
            For i As Integer = 0 To GridView8.Rows.Count - 1
                If GridView8.Rows(i).Cells(0).Text.Contains("12:00:00 AM") = True Then
                    GridView8.Rows(i).Cells(0).Text = GridView8.Rows(i).Cells(0).Text.Replace("12:00:00 AM", "")
                End If
            Next
        End If
    End Sub
    Sub loadgridcounselling()
        'con.open()
        sqltext = "select count(empcode) from er_employeecounseling where empcode='" & (empcode.Text) & "'"
        cmd = New SqlCommand(sqltext, con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            countcounselling.Text = rdr(0)
        End While
        rdr.Close()
        If countcounselling.Text > 0 Then
            sqltext = "select cudate as LetterDate,discussion as SummaryOfTopic,Recomments,orcomments as PanelReport,atfollowup as ActiontakenFollowup,ersection as ReferrendToEr,cname as Counsellor from er_employeecounseling where empcode='" & (empcode.Text) & "'"
            DS = GetappCharactersetting(sqltext)
            GridView9.DataSource = DS
            GridView9.DataBind()
            For i As Integer = 0 To GridView9.Rows.Count - 1
                If GridView9.Rows(i).Cells(0).Text.Contains("12:00:00 AM") = True Then
                    GridView9.Rows(i).Cells(0).Text = GridView9.Rows(i).Cells(0).Text.Replace("12:00:00 AM", "")
                End If
            Next
        End If
    End Sub
    Sub loadgridmisfirst()
        'con.open()
        sqltext = "select count(empcode) from er_misfirstwarning where empcode='" & (empcode.Text) & "'"
        cmd = New SqlCommand(sqltext, con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            countmisfirst.Text = rdr(0)
        End While
        rdr.Close()
        If countmisfirst.Text > 0 Then
            sqltext = "select vdate as LetterDate,desmisconduct as SummaryOfTopic,TimeDateOffence,verbalwdate as VerbalWarningDate,sempcode as CounsellorEmpNo from er_misfirstwarning where empcode='" & (empcode.Text) & "'"
            DS = GetappCharactersetting(sqltext)
            GridView10.DataSource = DS
            GridView10.DataBind()
            For i As Integer = 0 To GridView10.Rows.Count - 1
                If GridView10.Rows(i).Cells(0).Text.Contains("12:00:00 AM") = True Then
                    GridView10.Rows(i).Cells(0).Text = GridView10.Rows(i).Cells(0).Text.Replace("12:00:00 AM", "")
                End If
            Next
        End If
    End Sub
    Sub loadgridmisfinal()
        'con.open()
        sqltext = "select count(empcode) from er_misfinalwarning where empcode='" & (empcode.Text) & "'"
        cmd = New SqlCommand(sqltext, con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            countmisfinal.Text = rdr(0)
        End While
        rdr.Close()
        If countmisfinal.Text > 0 Then
            sqltext = "select vdate as LetterDate,misconduct as SummaryOfTopic,TimeDateOffence,verbalwdate as VerbalWarningDate,finalwdate as FirstWarningDate,sempcode as CounsellorEmpNo from er_misfinalwarning where empcode='" & (empcode.Text) & "'"
            DS = GetappCharactersetting(sqltext)
            GridView11.DataSource = DS
            GridView11.DataBind()
            For i As Integer = 0 To GridView11.Rows.Count - 1
                If GridView11.Rows(i).Cells(0).Text.Contains("12:00:00 AM") = True Then
                    GridView11.Rows(i).Cells(0).Text = GridView11.Rows(i).Cells(0).Text.Replace("12:00:00 AM", "")
                End If
                If GridView11.Rows(i).Cells(3).Text.Contains("12:00:00 AM") = True Then
                    GridView11.Rows(i).Cells(3).Text = GridView11.Rows(i).Cells(3).Text.Replace("12:00:00 AM", "")
                End If
                If GridView11.Rows(i).Cells(4).Text.Contains("12:00:00 AM") = True Then
                    GridView11.Rows(i).Cells(4).Text = GridView11.Rows(i).Cells(4).Text.Replace("12:00:00 AM", "")
                End If
            Next
        End If
    End Sub
    Sub loadgridshowcause()
        'con.open()
        sqltext = "select count(empcode) from er_showcauseletter where empcode='" & (empcode.Text) & "'"
        cmd = New SqlCommand(sqltext, con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            countshowcause.Text = rdr(0)
        End While
        rdr.Close()
        If countshowcause.Text > 0 Then
            sqltext = "select vdate as LetterDate,misconduct as SummaryOfTopic,ReportDate,ReportHours,mdate as MisConductDate from er_showcauseletter where empcode='" & (empcode.Text) & "'"
            DS = GetappCharactersetting(sqltext)
            GridView12.DataSource = DS
            GridView12.DataBind()
            For i As Integer = 0 To GridView12.Rows.Count - 1
                If GridView12.Rows(i).Cells(0).Text.Contains("12:00:00 AM") = True Then
                    GridView12.Rows(i).Cells(0).Text = GridView12.Rows(i).Cells(0).Text.Replace("12:00:00 AM", "")
                End If
                If GridView12.Rows(i).Cells(2).Text.Contains("12:00:00 AM") = True Then
                    GridView12.Rows(i).Cells(2).Text = GridView12.Rows(i).Cells(2).Text.Replace("12:00:00 AM", "")
                End If
            Next
        End If
    End Sub
    Sub loadgridformaladvice()
        'con.open()
        sqltext = "select count(empcode) from er_formaladvice where empcode='" & (empcode.Text) & "'"
        cmd = New SqlCommand(sqltext, con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            countformal.Text = rdr(0)
        End While
        rdr.Close()
        If countformal.Text > 0 Then
            sqltext = "select LetterDate,misconductdetails as SummaryOfTopic,DiscussionDate,NatureofAdvice,FormalPlan,erempcode as CounsellorEmpNo  from er_formaladvice where empcode='" & (empcode.Text) & "'"
            DS = GetappCharactersetting(sqltext)
            GridView13.DataSource = DS
            GridView13.DataBind()
            For i As Integer = 0 To GridView13.Rows.Count - 1
                If GridView13.Rows(i).Cells(0).Text.Contains("12:00:00 AM") = True Then
                    GridView13.Rows(i).Cells(0).Text = GridView13.Rows(i).Cells(0).Text.Replace("12:00:00 AM", "")
                End If
                If GridView13.Rows(i).Cells(2).Text.Contains("12:00:00 AM") = True Then
                    GridView13.Rows(i).Cells(2).Text = GridView13.Rows(i).Cells(2).Text.Replace("12:00:00 AM", "")
                End If
            Next
        End If
    End Sub
    Sub loadgridwrittenwarning()
        'con.open()
        sqltext = "select count(empcode) from er_writtenwarning where empcode='" & (empcode.Text) & "'"
        cmd = New SqlCommand(sqltext, con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            countwarning.Text = rdr(0)
        End While
        rdr.Close()
        If countwarning.Text > 0 Then
            sqltext = "select wwdate as WrittenWarningDate,warningdetails as SummaryOfTopic,sempcode as CounsellorEmpNo from er_writtenwarning where empcode='" & (empcode.Text) & "'"
            DS = GetappCharactersetting(sqltext)
            GridView14.DataSource = DS
            GridView14.DataBind()
            For i As Integer = 0 To GridView14.Rows.Count - 1
                If GridView14.Rows(i).Cells(0).Text.Contains("12:00:00 AM") = True Then
                    GridView14.Rows(i).Cells(0).Text = GridView14.Rows(i).Cells(0).Text.Replace("12:00:00 AM", "")
                End If
            Next
        End If
    End Sub
    Sub loadgridanytypeofletter()
        'con.open()
        sqltext = "select count(empcode) from er_directfinalwarning where empcode='" & (empcode.Text) & "'"
        cmd = New SqlCommand(sqltext, con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            countanytypeletter.Text = rdr(0)
        End While
        rdr.Close()
        If countanytypeletter.Text > 0 Then
            sqltext = "select vdate as LetterDate,desmisconduct as SummaryofTopic,Reference from er_directfinalwarning where empcode='" & (empcode.Text) & "'"
            DS = GetappCharactersetting(sqltext)
            GridView15.DataSource = DS
            GridView15.DataBind()
            For i As Integer = 0 To GridView15.Rows.Count - 1
                If GridView15.Rows(i).Cells(0).Text.Contains("12:00:00 AM") = True Then
                    GridView15.Rows(i).Cells(0).Text = GridView15.Rows(i).Cells(0).Text.Replace("12:00:00 AM", "")
                End If
            Next
        End If
    End Sub
    Function GetappCharactersetting(ByVal sqltext As String) As DataSet
        'MyGlobal.Con_Str()
        'MyGlobal.Open_Con()
        Dim ds As New DataSet()
        'Dim con As New SqlConnection(constr)
        ''con.open()
        Dim Command As New SqlCommand
        Command = New SqlCommand(sqltext, con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "character")
        'con.Close()
        Return ds
    End Function
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Response.Redirect("~/hrmis/js/printjs.aspx")
        Session("jsemp") = empcode.Text
    End Sub
End Class