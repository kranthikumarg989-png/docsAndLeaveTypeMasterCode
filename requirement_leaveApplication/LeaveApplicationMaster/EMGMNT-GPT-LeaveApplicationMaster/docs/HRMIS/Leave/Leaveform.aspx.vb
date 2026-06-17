Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports E_Management.emanagement.netglobal
Partial Public Class Leaveform
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim Mynet As New emanagement.netglobal
    Dim doj As Date
    Dim thisdate As Date
    Dim cancfwd As String
    Dim appno As String
    Dim rnoo As Integer
    Dim tmpann

    Private Sub Leaveform_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        ' Get Leave appno

        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (27)
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

        If Not IsPostBack Then
            GetLeaveID()
            rnoo = 0
            If posid < 0 Then
                ID = 1
            Else
                ID = posid + 1
            End If
            gppassnum.Text = ID
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        _eid = Session("empcode")
        _ename = Session("_ename")
        _edept = Session("_edept")

        ' Session("_edept") = "9000"
        '_eid = "014543"
        'Session("empcode") = "014543"



        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        
        thisdate = DateTime.Now.ToShortDateString()

        If Date.Today.Year = 2019 Then
            MyApp.GetfiscalYear()
            MyApp.GetfiscalYearforLeave()
        Else
            MyApp.GetfiscalYearforLeave()
            _fisyrStart = _fisyrStart1
            _fisyrEnd = _fisyrEnd1
        End If


        If Not IsPostBack Then

            Leavecalculation()
            btnUpdate.Visible = False
            btnlsave.Visible = True
            ddlltime.Enabled = False
        End If


        Dim leavenum As String
        If Not IsPostBack Then
            If Session("leaveeditnum") <> "" Then
                leavenum = Session("leaveeditnum")
                EditLeave(leavenum)
                btnlsave.Visible = False
                btnUpdate.Visible = True
            Else
                leavenum = ""
                btnlsave.Visible = True
                btnUpdate.Visible = False
            End If
        End If

        If IsPostBack = False Then
            Dim TmpDs As New DataSet
            TmpDs = New DataSet()
            TmpDs = SP_Fun1("EmpCode", DateTime.Now, DateTime.Now, "-", "-", "-")
            'Lbl1.Text = TmpDs.Tables(0).Rows.Count
            CmbEmployeeCode.DataSource = TmpDs.Tables(0)
            CmbEmployeeCode.DataValueField = "EmpCode"
            CmbEmployeeCode.DataTextField = "EmpName"
            CmbEmployeeCode.DataBind()
            CmbEmployeeCode.Items.Insert(0, "-Select-")

            CmbEmployeeCode2.DataSource = TmpDs.Tables(0)
            CmbEmployeeCode2.DataValueField = "EmpCode"
            CmbEmployeeCode2.DataTextField = "EmpName"
            CmbEmployeeCode2.DataBind()
            CmbEmployeeCode2.Items.Insert(0, "-Select-")
        End If


    End Sub

    Public Function SP_Fun1(ByVal Options As String, ByVal Date1 As DateTime, ByVal Date2 As DateTime, ByVal DCode As String, ByVal SCode As String, ByVal Ecode As String) As DataSet

        Dim strCon As String = "Data Source=192.168.0.241;Initial Catalog=hrmis;uid=sa;"
        Dim sqlCon As SqlConnection
        Dim sqlCmd As SqlCommand
        Dim SqlAd As New SqlDataAdapter
        Dim Sqlds As New DataSet()
        Dim ClsObj As New CRMlognetglobal
        Dim TmpDs As New DataSet

        ClsObj.db_cn()
        sqlCon = New SqlConnection(CRMlognetglobal.sConnString2 & "; Connect Timeout=6000000")
        'Lbl1.Text = CRMlognetglobal.sConnString2
        sqlCon.Open()
        sqlCmd = New SqlCommand
        sqlCmd.CommandType = CommandType.StoredProcedure
        sqlCmd.CommandText = "SP_CanteenData"
        sqlCmd.Parameters.Clear()
        sqlCmd.Parameters.AddWithValue("@Options", Options)
        sqlCmd.Parameters.AddWithValue("@Date1", Date1)
        sqlCmd.Parameters.AddWithValue("@Date2", Date2)
        sqlCmd.Parameters.AddWithValue("@DCode", DCode)
        sqlCmd.Parameters.AddWithValue("@SCode", SCode)
        sqlCmd.Parameters.AddWithValue("@Ecode", Ecode)

        sqlCmd.Connection = sqlCon

        SqlAd = New SqlDataAdapter(sqlCmd)

        Sqlds = New DataSet

        SqlAd.Fill(Sqlds, "Details")

        Return Sqlds

    End Function


    Public Sub Leavecalculation()

        Try
            GetMedicalReason()
            If recstatus = True Then
                If dsdata.Tables(0).Rows.Count > 0 Then
                    CmbReason.DataSource = dsdata.Tables(0)
                    CmbReason.DataTextField = "Reason"
                    CmbReason.DataValueField = "Reason"
                    CmbReason.DataBind()
                    CmbReason.Items.Insert(0, "-Select-")
                End If
            End If
        Catch ex As Exception
            MessageBox(ex.ToString)

        End Try
        ' Get the date of join of emp 
        GetEmpVehino(_eid)
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
            lblmsg.Text = MyerrorMsg
            lblmsg.ForeColor = Drawing.Color.Red

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
                tmpann = ann
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
            lblmsg.Text = MyerrorMsg
            lblmsg.ForeColor = Drawing.Color.Red
        End If
        lbllannual.Text = ann
        lbllmedical.Text = med

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
                    leavetaken = Val(dr("annual").ToString & "")
                End If
            End If
        Else
            lblmsg.Text = MyerrorMsg
            lblmsg.ForeColor = Drawing.Color.Red
        End If
        balAleave = ann - leavetaken
        lbllbannual.Text = balAleave

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
            lblmsg.Text = MyerrorMsg
            lblmsg.ForeColor = Drawing.Color.Red
        End If

        balMleave = med - mLeavetaken
        lbllbmedical.Text = balMleave
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
                    GetCfwdLeave(_eid, curyear - 1)
                Else
                    GetCfwdLeave(_eid, curyear)
                End If
            Else
                GetCfwdLeave(_eid, curyear)
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

                    If rcfwd < 0 Then
                        rcfwd = 0
                    End If
                    If cfwd < 0 Then
                        cfwd = 0
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
                    GetLeaveLevel(_eid, expr)
                    If recstatus = True Then
                        Dim dr As DataRow
                        If dsdata.Tables(0).Rows.Count > 0 Then
                            dr = dsdata.Tables(0).Rows(0)
                            'doj = dr("dateofjoin").ToString
                            LyannLeave = dr("annual").ToString
                            LyannLeave1 = dr("annual1").ToString

                        End If
                    Else
                        lblmsg.Text = MyerrorMsg
                        lblmsg.ForeColor = Drawing.Color.Red
                    End If
                    ' Insert carryforwardrecord

                    SetCfwdLeave(_eid, startdate, enddate)

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
                        lblmsg.Text = MyerrorMsg & " Record not saved..Try again"
                        lblmsg.ForeColor = Drawing.Color.Red
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
                        InsertcfwdLeave(_eid, 0, curyear, 0, 0)
                        LyBalLeave = 0
                        rcfwd = 0
                        cfwd = 0

                    Else
                        If rcfwd < 0 Then
                            rcfwd = 0
                        End If
                        If cfwd < 0 Then
                            cfwd = 0
                        End If
                        InsertcfwdLeave(_eid, LyBalLeave, curyear, rcfwd, cfwd)

                    End If
                End If
                lbllcfwd.Text = cfwd
                lbllbcfwd.Text = rcfwd
            End If
        Else
            Session(cancfwd) = "N"
            lbllcfwd.Text = 0
            lbllbcfwd.Text = 0
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
                prorate = Val(Math.Round(ann - leavetaken, 1)) + Val(lbllbcfwd.Text)
            Else
                If Date.Today.Year = 2019 Then
                    workeddays = thisdate.Subtract(_fisyrStart1).Days
                Else
                    workeddays = thisdate.Subtract(_fisyrStart).Days
                End If

                prorate = (workeddays / 365) * ann
                'prorate = Math.Round(prorate, 1)
                ''prorate = Math.Round(prorate - leavetaken, 1)
                prorate = Val(Math.Round(ann - leavetaken, 1)) + Val(lbllbcfwd.Text)

            End If
        Else
            'MessageBox("experience is less than probation period - Exp: " & expmth & ", Probation Period - " & probation)
            prorate = 0
            lbllcfwd.Text = 0
            lbllbcfwd.Text = 0
        End If
        lbllprorate.Text = prorate

        LblAU.Text = Val(lbllannual.Text) - Val(lbllbannual.Text)
        LblCFU.Text = Val(lbllcfwd.Text) - Val(lbllbcfwd.Text)
        LblMU.Text = Val(lbllmedical.Text) - Val(lbllbmedical.Text)


        Try
            If Month(DateTime.Now) = 12 Then
                NL1.Visible = True
                NL2.Visible = True
                NL3.Visible = True
                NL4.Visible = True
                NL5.Visible = True
                NL3.Text = lbllbannual.Text
                NL5.Text = Val(lbllannual.Text) + ((Val(lbllannual.Text) / 9) * 3)

                If NL5.Text = 0 Then
                    Dim tmpdate
                    tmpdate = _fisyrStart.AddYears(1)

                    If tmpdate.Subtract(doj).Days < 365 Then
                        tmpann = Math.Round((tmpdate.Subtract(doj).Days / 365) * tmpann, 0)
                        NL5.Text = tmpann
                    End If
                End If

            Else
                NL3.Text = lbllbannual.Text
                NL5.Text = Val(lbllannual.Text) + ((Val(lbllannual.Text) / 9) * 3)
                NL1.Visible = False
                NL2.Visible = False
                NL3.Visible = False
                NL4.Visible = False
                NL5.Visible = False
            End If
            


        Catch ex As Exception
            NL3.Text = lbllbannual.Text
            NL5.Text = Val(lbllannual.Text) + ((Val(lbllannual.Text) / 9) * 3)
        End Try
    End Sub
    Private Sub cbltype_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbltype.CheckedChanged
        If cbltype.Checked = True Then
            ddlltime.Enabled = True
            txtlDays.Text = "0.5"
        Else
            ddlltime.Enabled = False
            txtlDays.Text = ""
        End If
    End Sub
    Protected Sub btnlsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlsave.Click

        Dim Pic1 As String

        Dim Pic2 As String

        Dim Pic11 As String

        Dim Pic22 As String

        If Session("desgtmp") <> "Operator" Then

            If CmbEmployeeCode.SelectedItem.Text = "-Select-" Then
                MessageBox("Please Select Person in Charge When You are in Leave!")
                Exit Sub
            Else
                Pic1 = CmbEmployeeCode.SelectedValue
                Pic11 = CmbEmployeeCode.SelectedItem.Text
            End If

            If CmbEmployeeCode2.SelectedItem.Text = "-Select-" Then
                Pic2 = "-"
                Pic22 = "-"
            Else
                Pic2 = CmbEmployeeCode2.SelectedValue
                Pic22 = CmbEmployeeCode2.SelectedItem.Text
            End If
        Else
            Pic1 = "-"
            Pic11 = "-"
            Pic2 = "-"
            Pic22 = "-"
        End If


        If DropDownList1.SelectedItem.Text = "- Select Leave type -" Then
            MessageBox("Please Select Valid Leave Type!")
            Exit Sub
        End If


        If DropDownList1.SelectedItem.Text = "Medical" Or DropDownList1.SelectedIndex = 9 Then
            If CmbReason.SelectedItem.Text = "-Select-" Then
                MessageBox("Please Select Correct Reason From the List!")
                Exit Sub
            End If
        End If

        If txtlfrom.Text.Trim.Equals("") Then
            MessageBox("Please Select Leave (From)Date!")
            Exit Sub
        End If

        If txtlto.Text.Trim.Equals("") Then
            MessageBox("Please Select Leave (To)Date!")
            txtlto.Focus()
            Exit Sub
        End If

        If txtreason.Text.Trim.Equals("") Then
            MessageBox("Please Enter Valid Leave Reason!")
            Exit Sub
        End If

        If txtlDays.Text.Trim.Equals("") Then
            MessageBox("Please Enter Leave Days!")
            txtlDays.Focus()
            Exit Sub
        End If

        If cbltype.Checked = True Then
            If ddlltime.SelectedItem.Text = "-Select Half Day Leave Time -" Then
                MessageBox("Please select half day leave time!")
                Exit Sub
            End If
        End If


        Dim backdate As String
        Dim leavetype As String
        Dim rno As Integer

        Dim fd1 As String
        fd1 = txtlfrom.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)

        Dim td1 As String
        td1 = txtlto.Text.Trim
        Dim strdate2() As String = td1.Split("/"c)
        td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

        Dim td As Date
        td = CDate(td1)

        If Year(fd1) = 2019 Then
            If Year(td1) = 2020 Then
                MessageBox("Please apply leave seperately, If any leave after december 31 2019")
                Exit Sub
            End If
        End If

        ' Dim fd As Date = txtlfrom.Text
        ' Dim td As Date = txtlto.Text

        If fd > td Then
            MessageBox("Please Check the date selected")
            Exit Sub
        End If

        Dim applieddays As Decimal
        applieddays = Trim(txtlDays.Text)

        ''071911

        If applieddays = "0.5" Then
            If fd <> td Then
                MessageBox("Half Day Leave Date cannot be more than one day")
                Exit Sub
            End If
        End If

        '' to ensure after decimal it sudnt allow any value other than .5
        Dim noofdays As String
        noofdays = txtlDays.Text.Trim
        Dim mydays() As String = noofdays.Split("."c)

        If mydays.Length >= 2 Then
            If mydays(1) > "5" Or mydays(1) < "5" Then
                MessageBox("Pls. Check No. Of days applied")
                Exit Sub
            End If
        End If
        ''071911

        Dim bannual As Decimal
        bannual = lbllbannual.Text
        Dim bmedical As Decimal
        bmedical = lbllbmedical.Text
        Dim prorate As Decimal
        prorate = lbllprorate.Text
        Dim timeline As Decimal
        Dim mycfwd As Decimal
        mycfwd = "0"
        Dim cancarry As String
        cancarry = "N"
        Dim leavetime As String
        leavetime = ddlltime.SelectedValue
        Dim anndeduction As Decimal
        Dim balfwd As Decimal

        If fd < thisdate Then
            backdate = "Y"
        Else
            backdate = "N"
            timeline = fd.Subtract(thisdate).Days
        End If

        leavetype = DropDownList1.SelectedValue.Trim
        ' Get Leave appno
        GetLeaveID()
        rno = 0
        If posid < 0 Then
            ID = 1
        Else
            ID = posid + 1
        End If

        Dim curMth As Integer = Month(thisdate)
        '***********************************************
        '************* INSERT ANNUAL LEAVE *************
        '***********************************************
        'If 1 = 1 Then
        If Year(DateTime.Now) = Year(fd1) Then

            If leavetype = "Annual" Then
                ''If applieddays > bannual Or applieddays > lbllannual.Text Then
                ''    MessageBox("Cannot Apply!!Leave Applied is more than available Anuual Leave")
                ''    Exit Sub
                ''End If

                If curMth <> 0 Then
                    'If curMth = "4" Or curMth = "5" Or curMth = "6" Then
                    ''    If lbllcfwd.Text = "0" Or lbllbcfwd.Text = "0" Then
                    ''        If applieddays > prorate Then
                    ''            MessageBox("No.of Days applied is greater than Prorated Leave Allocated")
                    ''            Exit Sub
                    ''        End If
                    ''    Else
                    ''        If (applieddays - lbllbcfwd.Text) > prorate Then
                    ''            MessageBox("No.of Days applied is greater than Prorated/Carry Fwd Leave Allocated")
                    ''            Exit Sub
                    ''        End If
                    ''    End If
                    ''Else
                    If applieddays > prorate Then
                        MessageBox("No.of Days applied is greater than total entitlement balance")
                        Exit Sub
                    End If
                End If


                If applieddays < 0.5 Then
                    MessageBox("Leave should not apply below half day")

                    Exit Sub
                End If
                If applieddays >= 0.5 And applieddays < 1 And timeline < 1 Then
                    MessageBox("Leave should apply before one day")

                    Exit Sub
                End If
                If applieddays = 1 And timeline < 3 Then
                    MessageBox("Leave should apply before three day")

                    Exit Sub
                End If
                If applieddays > 1 And timeline < 7 Then
                    MessageBox("Leave should apply before seven day")

                    Exit Sub
                End If
                ' check if it is carry forward month or not       

                If applieddays = "0.5" Then
                    If leavetime = "-1" Then
                        MessageBox("Please Select Leave timing")

                        Exit Sub
                    End If
                Else
                    leavetime = ""
                End If

                If Session(cancfwd) = "Y" Then
                    If applieddays >= lbllbcfwd.Text Then
                        anndeduction = applieddays - lbllbcfwd.Text
                        balfwd = 0
                        mycfwd = lbllbcfwd.Text
                    Else
                        balfwd = lbllbcfwd.Text - applieddays
                        anndeduction = 0
                        mycfwd = applieddays
                    End If
                    InsertLeave(_eid, thisdate, applieddays, anndeduction, fd, td, leavetype, txtreason.Text, leavetime, Session(cancfwd), mycfwd, backdate, ID, Pic1, Pic11, Pic2, Pic22, lbllbannual.Text, lbllbmedical.Text)
                    If recstatus = True Then
                        '  'insertsms(ID, _eid)
                        MessageBox("Annual Leave has been Updated")
                        UpdatecfwdLeave(_eid, Year(thisdate), balfwd)
                        CLearLControl()

                    Else

                        lblmsg.Text = MyerrorMsg & " Record not saved..Try again"
                        lblmsg.ForeColor = Drawing.Color.Red
                    End If
                Else
                    InsertLeave(_eid, thisdate, applieddays, applieddays, fd, td, leavetype, txtreason.Text, leavetime, Session(cancfwd), mycfwd, backdate, ID, Pic1, Pic11, Pic2, Pic22, lbllbannual.Text, lbllbmedical.Text)
                    If recstatus = True Then
                        MessageBox("Annual Leave has been Updated")
                        'insertsms(ID, _eid)
                        CLearLControl()
                    Else
                        lblmsg.Text = MyerrorMsg & " Record not saved..Try again"
                        lblmsg.ForeColor = Drawing.Color.Red

                    End If
                End If
                '***********************************************
                '************* INSERT MEDICAL LEAVE ************
                '***********************************************
            ElseIf leavetype = "Medical" Then
                If applieddays = "0.5" Then
                    If leavetime = "-1" Then
                        MessageBox("Please Select Leave timing")

                        Exit Sub
                    End If
                Else
                    leavetime = ""
                End If
                If applieddays > bmedical Or applieddays > lbllmedical.Text Then
                    MessageBox("Cannot Apply!!Leave Applied is more than available Medical Leave")
                    Exit Sub
                End If

                InsertLeave(_eid, thisdate, applieddays, applieddays, fd, td, leavetype, txtreason.Text, leavetime, cancarry, mycfwd, backdate, ID, Pic1, Pic11, Pic2, Pic22, lbllbannual.Text, lbllbmedical.Text)
                If recstatus = True Then
                    'insertsms(ID, _eid)
                    MessageBox("Medical Leave has been scheduled")
                    CLearLControl()
                Else
                    lblmsg.Text = MyerrorMsg & " Record not saved..Try again"
                    lblmsg.ForeColor = Drawing.Color.Red

                End If
                '********************************************************************
                '************* INSERT EMERGENCY AND PLAN EMERGENCY LEAVE ************
                '********************************************************************
            ElseIf leavetype = "Emergency" Or leavetype = "PlanEmergency" Then


                If curMth <> 0 Then
                    If applieddays > prorate Then
                        MessageBox("No.of Days applied is greater than  total entitlement balance")
                        Exit Sub
                    End If
                End If


                If applieddays < 0.5 Then
                    MessageBox("Leave should not below half day")

                    Exit Sub
                End If

                If applieddays = "0.5" Then
                    If leavetime = "-1" Then
                        MessageBox("Please Select Leave timing")

                        Exit Sub
                    End If
                Else
                    leavetime = ""
                End If

                If Session(cancfwd) = "Y" Then
                    If applieddays >= lbllbcfwd.Text Then
                        anndeduction = applieddays - lbllbcfwd.Text
                        balfwd = 0
                        mycfwd = lbllbcfwd.Text
                    Else
                        balfwd = lbllbcfwd.Text - applieddays
                        anndeduction = 0
                        mycfwd = applieddays
                    End If
                    InsertLeave(_eid, thisdate, applieddays, anndeduction, fd, td, leavetype, txtreason.Text, leavetime, Session(cancfwd), mycfwd, backdate, ID, Pic1, Pic11, Pic2, Pic22, lbllbannual.Text, lbllbmedical.Text)
                    If recstatus = True Then
                        MessageBox("Leave has been scheduled")
                        UpdatecfwdLeave(_eid, Year(thisdate), balfwd)
                        'insertsms(ID, _eid)
                        CLearLControl()
                    Else
                        lblmsg.Text = MyerrorMsg & " Record not saved..Try again"
                        lblmsg.ForeColor = Drawing.Color.Red

                    End If
                Else
                    InsertLeave(_eid, thisdate, applieddays, applieddays, fd, td, leavetype, txtreason.Text, leavetime, Session(cancfwd), mycfwd, backdate, ID, Pic1, Pic11, Pic2, Pic22, lbllbannual.Text, lbllbmedical.Text)
                    If recstatus = True Then
                        MessageBox("Leave has been scheduled")
                        'insertsms(ID, _eid)
                        CLearLControl()
                    Else
                        lblmsg.Text = MyerrorMsg & " Record not saved..Try again"
                        lblmsg.ForeColor = Drawing.Color.Red
                    End If
                End If

                '***********************************************
                '************* INSERT OTHER LEAVE ************
                '***********************************************
            ElseIf leavetype <> "annual" And leavetype <> "Medical" And leavetype <> "Emergency" And leavetype <> "PlanEmergency" Then


                If applieddays = "0.5" Then
                    If leavetime = "-1" Then
                        MessageBox("Please Select Leave timing")

                        Exit Sub
                    End If
                Else
                    leavetime = ""
                End If
                InsertLeave(_eid, thisdate, applieddays, applieddays, fd, td, leavetype, txtreason.Text, leavetime, cancarry, mycfwd, backdate, ID, Pic1, Pic11, Pic2, Pic22, lbllbannual.Text, lbllbmedical.Text)
                If recstatus = True Then
                    MessageBox("Leave has been scheduled")
                    'insertsms(ID, _eid)
                    CLearLControl()
                    Response.Redirect("selfstatus.aspx")
                Else
                    lblmsg.Text = MyerrorMsg & " Record not saved..Try again"
                    lblmsg.ForeColor = Drawing.Color.Red
                End If

            End If
        ElseIf Month(DateTime.Now) = 12 Then
            bannual = NL5.Text
            prorate = NL5.Text
            mycfwd = "0"
            cancarry = "N"
            leavetime = ddlltime.SelectedValue


            If leavetype <> "Unpaid" Then
                If applieddays > bannual Then
                    MessageBox("No.of Days applied is greater than total entitlement balance")
                    Exit Sub
                End If
            End If

            If applieddays < 0.5 Then
                MessageBox("Leave should not below half day")
                Exit Sub
            End If

            If leavetype = "Unpaid" Or leavetype = "Annual" Or leavetype = "Emergency" Or leavetype = "PlanEmergency" Then
                If applieddays = "0.5" Then
                    If leavetime = "-1" Then
                        MessageBox("Please Select Leave timing")
                        Exit Sub
                    End If
                Else
                    leavetime = ""
                End If
                InsertLeave(_eid, thisdate, applieddays, applieddays, fd, td, leavetype, txtreason.Text, leavetime, Session(cancfwd), mycfwd, backdate, ID, Pic1, Pic11, Pic2, Pic22, NL5.Text, "-")
            Else
                MessageBox("For the following year you can only apply Annual, Emergency and Plan Emergency leave!")
                Exit Sub
            End If
        Else
            MessageBox("Leave applying for next year?, please apply on december month!")
            Exit Sub
        End If

        Leavecalculation()

        Dim ipaddress As String
        ipaddress = Request.ServerVariables("HTTP_X_FORWARDED_FOR")
        If ipaddress = "" Or ipaddress Is Nothing Then
            ipaddress = Request.ServerVariables("REMOTE_ADDR")
        End If

        If (ipaddress.Equals("192.168.4.90")) Then

            System.Threading.Thread.Sleep(4000)

            FormsAuthentication.RedirectFromLoginPage(Session("empcode"), True)
            Session.Abandon()
            Response.Redirect("http://mmsbsql1/emgmt/hrmis/login.aspx")
        End If

    End Sub
    Private Sub CLearLControl()
        Leavecalculation()
        DropDownList1.SelectedValue = "-1"
        txtlfrom.Text = ""
        txtlto.Text = ""
        ddlltime.SelectedValue = "-1"
        txtlDays.Text = ""
        txtreason.Text = ""
        ddlltime.Enabled = False
        btnUpdate.Visible = False
        btnlsave.Visible = True
        Response.Redirect("selfstatus.aspx")
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Protected Sub txtlto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtlto.TextChanged

    End Sub

    Protected Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

 

        If DropDownList1.SelectedItem.Text = "- Select Leave type -" Then
            MessageBox("Please Select Valid Leave Type!")
            Exit Sub
        End If


        If DropDownList1.SelectedItem.Text = "Medical" Or DropDownList1.SelectedIndex = 9 Then
            If CmbReason.SelectedItem.Text = "-Select-" Then
                MessageBox("Please Select Correct Reason From the List!")
                Exit Sub
            End If
        End If

        If txtlfrom.Text.Trim.Equals("") Then
            MessageBox("Please Select Leave (From)Date!")
            Exit Sub
        End If

        If txtlto.Text.Trim.Equals("") Then
            MessageBox("Please Select Leave (To)Date!")
            txtlto.Focus()
            Exit Sub
        End If

        If txtreason.Text.Trim.Equals("") Then
            MessageBox("Please Enter Valid Leave Reason!")
            Exit Sub
        End If

        If txtlDays.Text.Trim.Equals("") Then
            MessageBox("Please Enter Leave Days!")
            txtlDays.Focus()
            Exit Sub
        End If

        If cbltype.Checked = True Then
            If ddlltime.SelectedItem.Text = "-Select Half Day Leave Time -" Then
                MessageBox("Please select half day leave time!")
                Exit Sub
            End If
        End If

        Dim backdate As String
        Dim leavetype As String
        Dim rno As Integer

        Dim fd1 As String
        fd1 = txtlfrom.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)

        Dim td1 As String
        td1 = txtlto.Text.Trim
        Dim strdate2() As String = td1.Split("/"c)
        td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

        Dim td As Date
        td = CDate(td1)
        Dim curMth As Integer = Month(thisdate)

        ' Dim fd As Date = txtlfrom.Text
        ' Dim td As Date = txtlto.Text

        If fd > td Then
            MessageBox("Please Check your date")
            Exit Sub
        End If

        Dim applieddays As Decimal
        applieddays = Trim(txtlDays.Text)


        ''071911

        If applieddays = "0.5" Then
            If fd <> td Then
                MessageBox("Half Day Leave Date cannot be more than one day")
                Exit Sub
            End If
        End If

        '' to ensure after decimal it sudnt allow any value other than .5
        Dim noofdays As String
        noofdays = txtlDays.Text.Trim
        Dim mydays() As String = noofdays.Split("."c)

        If mydays.Length >= 2 Then
            If mydays(1) > "5" Or mydays(1) < "5" Then
                MessageBox("Pls. Check No. Of days applied")
                Exit Sub
            End If
        End If


        ''071911

        Dim bannual As Decimal
        bannual = lbllbannual.Text
        Dim bmedical As Decimal
        bmedical = lbllbmedical.Text
        Dim prorate As Decimal
        prorate = lbllprorate.Text
        Dim timeline As Decimal
        Dim mycfwd As Decimal
        mycfwd = "0"
        Dim cancarry As String
        cancarry = "N"
        Dim leavetime As String
        leavetime = ddlltime.SelectedValue
        Dim anndeduction As Decimal
        Dim balfwd As Decimal

        If fd < thisdate Then
            backdate = "Y"
        Else
            backdate = "N"
            timeline = fd.Subtract(thisdate).Days
        End If
        leavetype = DropDownList1.SelectedValue.Trim
        ' Get Leave appno
        rno = gppassnum.Text

        '***********************************************
        '************* UPDATE ANNUAL LEAVE ************
        '***********************************************
        If leavetype = "Annual" Then
            If applieddays > bannual Or applieddays > lbllannual.Text Then
                MessageBox("Cannot Apply!!Leave Applied is more than available Anuual Leave")

                Exit Sub
            End If
            If curMth <> 0 Then
                'If curMth = "4" Or curMth = "5" Or curMth = "6" Then
                If lbllcfwd.Text = "0" Or lbllbcfwd.Text = "0" Then
                    If applieddays > prorate Then
                        MessageBox("No.of Days applied is greater than Prorated Leave Allocated")
                        Exit Sub
                    End If
                Else
                    If (applieddays - lbllbcfwd.Text) > prorate Then
                        MessageBox("No.of Days applied is greater than Prorated/Carry Fwd Leave Allocated")
                        Exit Sub
                    End If
                End If
            Else
                If applieddays > prorate Then
                    MessageBox("No.of Days applied is greater than Prorated Leave Allocated")
                    Exit Sub
                End If
            End If



            If applieddays < 0.5 Then
                MessageBox("Leave should not below half day")

                Exit Sub
            End If
            If applieddays >= 0.5 And applieddays < 1 And timeline < 1 Then
                MessageBox("Leave should apply before one day")

                Exit Sub
            End If
            If applieddays = 1 And timeline < 3 Then
                MessageBox("Leave should apply before three day")

                Exit Sub
            End If
            If applieddays > 1 And timeline < 7 Then
                MessageBox("Leave should apply before seven day")

                Exit Sub
            End If
            ' check if it is carry forward month or not       

            If applieddays = "0.5" Then
                If leavetime = "-1" Then
                    MessageBox("Please Select Leave timing")

                    Exit Sub
                End If
            Else
                leavetime = ""
            End If

            If Session(cancfwd) = "Y" Then
                If applieddays >= lbllbcfwd.Text Then
                    anndeduction = applieddays - lbllbcfwd.Text
                    balfwd = 0
                    mycfwd = lbllbcfwd.Text
                Else
                    balfwd = lbllbcfwd.Text - applieddays
                    anndeduction = 0
                    mycfwd = applieddays
                End If
                ' InsertLeave(_eid, thisdate, applieddays, anndeduction, fd, td, leavetype, txtreason.Text, leavetime, Session(cancfwd), mycfwd, backdate, ID)
                UpdateLeave(rno, _eid, thisdate, applieddays, anndeduction, fd, td, leavetype, txtreason.Text, leavetime, Session(cancfwd), mycfwd, backdate)
                If recstatus = True Then
                    MessageBox("Annual Leave has been Updated")
                    UpdatecfwdLeave(_eid, Year(thisdate), balfwd)
                    CLearLControl()
                Else
                    lblmsg.Text = MyerrorMsg & " Record not saved..Try again"
                    lblmsg.ForeColor = Drawing.Color.Red

                End If
            Else
                UpdateLeave(rno, _eid, thisdate, applieddays, applieddays, fd, td, leavetype, txtreason.Text, leavetime, Session(cancfwd), mycfwd, backdate)
                If recstatus = True Then
                    MessageBox("Annual Leave has been Updated")
                    CLearLControl()
                Else
                    lblmsg.Text = MyerrorMsg & " Record not saved..Try again"
                    lblmsg.ForeColor = Drawing.Color.Red

                End If
            End If
            '***********************************************
            '************* INSERT MEDICAL LEAVE ************
            '***********************************************
        ElseIf leavetype = "Medical" Then
            If applieddays = "0.5" Then
                If leavetime = "-1" Then
                    MessageBox("Please Select Leave timing")

                    Exit Sub
                End If
            Else
                leavetime = ""
            End If
            If applieddays > bmedical Or applieddays > lbllmedical.Text Then
                MessageBox("Cannot Apply!!Leave Applied is more than available Medical Leave")

                Exit Sub

            End If
            UpdateLeave(rno, _eid, thisdate, applieddays, applieddays, fd, td, leavetype, txtreason.Text, leavetime, cancarry, mycfwd, backdate)
            If recstatus = True Then
                MessageBox("Medical Leave has been Updated")

                CLearLControl()
            Else
                lblmsg.Text = MyerrorMsg & " Record not saved..Try again"
                lblmsg.ForeColor = Drawing.Color.Red

            End If
            '********************************************************************
            '************* INSERT EMERGENCY AND PLAN EMERGENCY LEAVE ************
            '********************************************************************
        ElseIf leavetype = "Emergency" Or leavetype = "PlanEmergency" Then
            If applieddays > bannual Or applieddays > lbllannual.Text Then
                MessageBox("Cannot Apply!!Leave Applied is more than available Anuual Leave")

                Exit Sub
            End If
            If curMth <> 0 Then
                'If curMth = "4" Or curMth = "5" Or curMth = "6" Then
                If lbllcfwd.Text = "0" Or lbllbcfwd.Text = "0" Then
                    If applieddays > prorate Then
                        MessageBox("No.of Days applied is greater than Prorated Leave Allocated")
                        Exit Sub
                    End If
                Else
                    If (applieddays - lbllbcfwd.Text) > prorate Then
                        MessageBox("No.of Days applied is greater than Prorated/Carry Fwd Leave Allocated")
                        Exit Sub
                    End If
                End If
            Else
                If applieddays > prorate Then
                    MessageBox("No.of Days applied is greater than Prorated Leave Allocated")
                    Exit Sub
                End If
            End If


            If applieddays < 0.5 Then
                MessageBox("Leave should not below half day")

                Exit Sub
            End If

            If applieddays = "0.5" Then
                If leavetime = "-1" Then
                    MessageBox("Please Select Leave timing")

                    Exit Sub
                End If
            Else
                leavetime = ""
            End If

            If Session(cancfwd) = "Y" Then
                If applieddays >= lbllbcfwd.Text Then
                    anndeduction = applieddays - lbllbcfwd.Text
                    balfwd = 0
                    mycfwd = lbllbcfwd.Text
                Else
                    balfwd = lbllbcfwd.Text - applieddays
                    anndeduction = 0
                    mycfwd = applieddays
                End If
                UpdateLeave(rno, _eid, thisdate, applieddays, anndeduction, fd, td, leavetype, txtreason.Text, leavetime, Session(cancfwd), mycfwd, backdate)
                If recstatus = True Then
                    MessageBox("Leave Updated")
                    UpdatecfwdLeave(_eid, Year(thisdate), balfwd)
                    CLearLControl()
                Else
                    lblmsg.Text = MyerrorMsg & " Record not saved..Try again"
                    lblmsg.ForeColor = Drawing.Color.Red
                End If
            Else
                UpdateLeave(rno, _eid, thisdate, applieddays, applieddays, fd, td, leavetype, txtreason.Text, leavetime, Session(cancfwd), mycfwd, backdate)
                If recstatus = True Then
                    MessageBox("Leave Updated")
                    CLearLControl()
                Else
                    lblmsg.Text = MyerrorMsg & " Record not saved..Try again"
                    lblmsg.ForeColor = Drawing.Color.Red
                End If
            End If
            '***********************************************
            '************* INSERT OTHER LEAVE ************
            '***********************************************
        ElseIf leavetype <> "annual" And leavetype <> "Medical" And leavetype <> "Emergency" And leavetype <> "PlanEmergency" Then
            If applieddays = "0.5" Then
                If leavetime = "-1" Then
                    MessageBox("Please Select Leave timing")
                    Exit Sub
                End If
            Else
                leavetime = ""
            End If
            UpdateLeave(rno, _eid, thisdate, applieddays, applieddays, fd, td, leavetype, txtreason.Text, leavetime, cancarry, mycfwd, backdate)
            If recstatus = True Then
                MessageBox("Leave has been Updated")
                Response.Redirect("selfstatus.aspx")
                CLearLControl()

            Else
                lblmsg.Text = MyerrorMsg & " Record not saved..Try again"
                lblmsg.ForeColor = Drawing.Color.Red
            End If
        End If
        Leavecalculation()

    End Sub
    Public Sub EditLeave(ByVal leavenum As String)

        Dim workfor As Decimal
        Dim nocf As Decimal
        Dim leavetype As String

        Try
            getLeaveDetails(leavenum)
            If recstatus = True Then
                Dim dr As DataRow
                If dsdata.Tables(0).Rows.Count > 0 Then
                    dr = dsdata.Tables(0).Rows(0)
                    DropDownList1.SelectedValue = dr("leavetype").ToString
                    leavetype = dr("leavetype").ToString
                    txtreason.Text = dr("reason").ToString
                    txtlDays.Text = dr("days").ToString
                    txtlfrom.Text = Format(Convert.ToDateTime(dr("fromdate")), "dd/MM/yy")
                    txtlto.Text = Format(Convert.ToDateTime(dr("todate")), "dd/MM/yy")
                    gppassnum.Text = dr("appno").ToString
                    If Not dr("workfor") Is System.DBNull.Value Then
                        workfor = dr("workfor").ToString
                    End If
                    If Not dr("nocf") Is System.DBNull.Value Then
                        nocf = dr("nocf").ToString
                    End If
                    If dr("days").ToString = "0.5" Then
                        ddlltime.Enabled = True
                        cbltype.Checked = True
                        ddlltime.SelectedValue = dr("leavetime").ToString
                    Else
                        ddlltime.Enabled = False
                        cbltype.Checked = False
                        ddlltime.SelectedValue = "-1"
                    End If
                End If
            Else
                lblmsg.Text = MyerrorMsg & " Record not saved..Try again"
                lblmsg.ForeColor = Drawing.Color.Red
            End If
            Leavecalculation()
            If (leavetype = "Annual" Or leavetype = "Planemergency" Or leavetype = "Emergency") Then
                lbllbannual.Text = lbllbannual.Text + workfor
                lbllbcfwd.Text = lbllbcfwd.Text + nocf
                lbllprorate.Text = lbllprorate.Text + workfor
            ElseIf leavetype = "Medical" Then
                lbllbmedical.Text = lbllbmedical.Text + workfor
            End If

            btnlsave.Visible = False
            btnUpdate.Visible = True

        Catch ex As Exception
            MessageBox(ex.Message)
        End Try

    End Sub

    Private Sub Leaveform_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Session("leaveeditnum") = ""
    End Sub

    
    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged


        If DropDownList1.SelectedItem.Text = "Medical" Or DropDownList1.SelectedIndex = 9 Then
            CmbReason.SelectedIndex = 0
            CmbReason.Enabled = True
            txtreason.Text = ""
            txtreason.Enabled = False
        Else
            CmbReason.SelectedIndex = 0
            CmbReason.Enabled = False
            txtreason.Text = ""
            txtreason.Enabled = True
        End If
        DropDownList1.AutoPostBack = True
    End Sub

     
   
    Protected Sub CmbReason_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbReason.SelectedIndexChanged
        If CmbReason.SelectedItem.Text = "-Select-" Then
            txtreason.Text = ""
            txtreason.Enabled = True
        ElseIf CmbReason.SelectedItem.Text = "Others" Then
            txtreason.Text = ""
            txtreason.Enabled = True
        Else
            txtreason.Text = CmbReason.SelectedItem.Text
            txtreason.Enabled = False
        End If
    End Sub

    Protected Sub txtlfrom_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtlfrom.TextChanged

    End Sub

    'Protected Sub LinkButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
    '    Response.Redirect("http://mmsbsql1/emgmt/hrmis/leave/Selfstatus.aspx")
    'End Sub
End Class