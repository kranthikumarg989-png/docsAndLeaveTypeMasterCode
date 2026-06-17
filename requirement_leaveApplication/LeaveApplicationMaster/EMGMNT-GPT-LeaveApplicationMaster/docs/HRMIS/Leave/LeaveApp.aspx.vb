Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class LeaveApp
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim doj As Date
    Dim thisdate As Date
    Dim cancfwd As String
    Dim appno As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        _eid = Session("empcode")
        _ename = Session("_ename")
        _edept = Session("_edept")
        'Session("_edept") = "9000"

        thisdate = DateTime.Now

        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        MyApp.GetfiscalYear()

        If Not IsPostBack Then
            GridView2.DataBind()
            GrdERapproval.DataBind()
            GridView1.DataBind()
            GrdLeaveCancel.DataBind()
            grdleavelevel.DataBind()
        End If
        '  If Not IsPostBack Then
        If Session("pnl") = "" Then
            pnlleaveform.Visible = False
            pnlstatus.Visible = False
            pnlapproval.Visible = False
            PnlERApproval.Visible = False
            Pnlhistory.Visible = False
            Pnllcancel.Visible = True
            pnlreport.Visible = False
            Pnllsetting.Visible = False
            pnlHODreports.Visible = False
            Pnlleavesummary.Visible = False
            pnlentitilement.Visible = False
            pnloverall.Visible = False

        ElseIf Session("pnl") = "pnllform" Then
            pnlleaveform.Visible = True
            pnlstatus.Visible = False
            pnlapproval.Visible = False
            PnlERApproval.Visible = False
            Pnlhistory.Visible = False
            Pnllcancel.Visible = False
            pnlreport.Visible = False
            Pnllsetting.Visible = False
            pnlHODreports.Visible = False
            Pnlleavesummary.Visible = False
            pnlentitilement.Visible = False
            pnloverall.Visible = False

        ElseIf Session("pnl") = "pnllapproval" Then
            pnlleaveform.Visible = False
            pnlstatus.Visible = False
            pnlapproval.Visible = True
            PnlERApproval.Visible = False
            Pnlhistory.Visible = False
            Pnllcancel.Visible = False
            Pnllsetting.Visible = False
            pnlreport.Visible = False
            pnlHODreports.Visible = False
            Pnlleavesummary.Visible = False
            pnlentitilement.Visible = False
            pnloverall.Visible = False

        ElseIf Session("pnl") = "pnlerapproval" Then
            pnlleaveform.Visible = False
            pnlstatus.Visible = False
            pnlapproval.Visible = False
            PnlERApproval.Visible = True
            Pnlhistory.Visible = False
            Pnllcancel.Visible = False
            Pnllsetting.Visible = False
            pnlreport.Visible = False
            pnlHODreports.Visible = False
            Pnlleavesummary.Visible = False
            pnlentitilement.Visible = False
            pnloverall.Visible = False

        ElseIf Session("pnl") = "pnllcancel" Then
            pnlleaveform.Visible = False
            pnlstatus.Visible = False
            pnlapproval.Visible = False
            PnlERApproval.Visible = False
            Pnlhistory.Visible = False
            Pnllcancel.Visible = True
            Pnllsetting.Visible = False
            pnlreport.Visible = False
            pnlHODreports.Visible = False
            Pnlleavesummary.Visible = False
            pnlentitilement.Visible = False
            pnloverall.Visible = False

        ElseIf Session("pnl") = "pnllsetting" Then
            pnlleaveform.Visible = False
            pnlstatus.Visible = False
            pnlapproval.Visible = False
            PnlERApproval.Visible = False
            Pnlhistory.Visible = False
            Pnllcancel.Visible = False
            Pnllsetting.Visible = True
            pnlreport.Visible = False
            pnlHODreports.Visible = False
            Pnlleavesummary.Visible = False
            pnlentitilement.Visible = False
            pnloverall.Visible = False

        ElseIf Session("pnl") = "pnllrpt" Then
            pnlleaveform.Visible = False
            pnlstatus.Visible = False
            pnlapproval.Visible = False
            PnlERApproval.Visible = False
            Pnlhistory.Visible = False
            Pnllcancel.Visible = False
            Pnllsetting.Visible = False
            pnlreport.Visible = True
            pnlHODreports.Visible = False
            Pnlleavesummary.Visible = False
            pnlentitilement.Visible = False
            pnloverall.Visible = False

        ElseIf Session("pnl") = "pnlhodrpt" Then
            pnlleaveform.Visible = False
            pnlstatus.Visible = False
            pnlapproval.Visible = False
            PnlERApproval.Visible = False
            Pnlhistory.Visible = False
            Pnllcancel.Visible = False
            Pnllsetting.Visible = False
            pnlreport.Visible = False
            pnlHODreports.Visible = True
            Pnlleavesummary.Visible = False
            pnlentitilement.Visible = False
            pnloverall.Visible = False

        ElseIf Session("pnl") = "pnllsummary" Then
            pnlleaveform.Visible = False
            pnlstatus.Visible = False
            pnlapproval.Visible = False
            PnlERApproval.Visible = False
            Pnlhistory.Visible = False
            Pnllcancel.Visible = False
            Pnllsetting.Visible = False
            pnlreport.Visible = False
            pnlHODreports.Visible = False
            Pnlleavesummary.Visible = True
            pnlentitilement.Visible = False
            pnloverall.Visible = False

        ElseIf Session("pnl") = "pnllentitile" Then
            pnlleaveform.Visible = False
            pnlstatus.Visible = False
            pnlapproval.Visible = False
            PnlERApproval.Visible = False
            Pnlhistory.Visible = False
            Pnllcancel.Visible = False
            Pnllsetting.Visible = False
            pnlreport.Visible = False
            pnlHODreports.Visible = False
            Pnlleavesummary.Visible = False
            pnlentitilement.Visible = True
            pnloverall.Visible = False
        ElseIf Session("pnl") = "pnlloverall" Then
            pnlleaveform.Visible = False
            pnlstatus.Visible = False
            pnlapproval.Visible = False
            PnlERApproval.Visible = False
            Pnlhistory.Visible = False
            Pnllcancel.Visible = False
            Pnllsetting.Visible = False
            pnlreport.Visible = False
            pnlHODreports.Visible = False
            Pnlleavesummary.Visible = False
            pnlentitilement.Visible = False
            pnloverall.Visible = True
        End If
        ' End If
        '''''''''''''''''''''''''''
        ' gppassnum.Text = ""
        btnUpdate.Visible = False
        btnlsave.Visible = True
        Leavecalculation()
        '  DropDownList1.SelectedValue = "-1"
        'txtlfrom.Text = ""
        ' txtlto.Text = ""
        ' ddlltime.SelectedValue = "-1"
        ' txtlDays.Text = ""
        ' txtreason.Text = ""
        ddlltime.Enabled = False
        'pnlstatus.Visible = True
        ' pnlstatus.Visible = False
        ddlltime.Enabled = False
        '''''''''''''''''''''''''''
    End Sub
    Public Sub Leavecalculation()
        ' Get the date of join of emp 
        GetEmpVehino(_eid)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                doj = dr("dateofjoin").ToString
            End If
        End If
        ' find the experience of employee
        Dim exp As String
        Dim ann As Decimal
        Dim med As Decimal
        Dim probation As Decimal
        Dim expr As Integer
        Dim expmth As Integer
        expr = 0
        ann = 0
        med = 0
        probation = 0

        exp = thisdate.Subtract(doj).Days
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
            End If
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
                    leavetaken = dr("annual").ToString
                End If
            End If
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

        If curMth = 10 Or curMth = 5 Or curMth = 6 Then
            Session(cancfwd) = "Y"
            GetCfwdLeave(_eid, curyear)
            If recstatus = True Then
                Dim dr As DataRow
                If dsdata.Tables(0).Rows.Count > 0 Then
                    dr = dsdata.Tables(0).Rows(0)
                    If dr("cfwd") Is System.DBNull.Value Then
                        cfwd = 0
                    Else
                        cfwd = dr("cfwd").ToString
                    End If
                End If

                If dsdata.Tables(0).Rows.Count > 0 Then
                    dr = dsdata.Tables(0).Rows(0)
                    If dr("remain") Is System.DBNull.Value Then
                        cfwd = 0
                    Else
                        rcfwd = dr("remain").ToString
                    End If
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
                End If
                LyBalLeave = LyannLeave - LyutilisedLeave
                If LyBalLeave <= 0 Then
                    cfwd = 0
                    rcfwd = 0
                    LyBalLeave = 0
                ElseIf LyBalLeave >= 3 Then
                    cfwd = 3
                    rcfwd = 3
                ElseIf LyBalLeave < 3 And LyBalLeave > 0 Then
                    cfwd = LyBalLeave
                    rcfwd = LyBalLeave
                End If
                InsertcfwdLeave(_eid, LyBalLeave, curyear, rcfwd, cfwd)
            End If
            lbllcfwd.Text = cfwd
            lbllbcfwd.Text = rcfwd
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
        If expmth > probation Then
            If doj > _fisyrStart Then
                workeddays = thisdate.Subtract(doj).Days
                prorate = (workeddays / 365) * ann
            Else
                workeddays = thisdate.Subtract(_fisyrStart).Days
                prorate = (workeddays / 365) * ann
                'prorate = Math.Round(prorate, 1)
                prorate = Math.Round(prorate - leavetaken, 1)
            End If
        Else
            prorate = 0
        End If
        lbllprorate.Text = prorate
    End Sub
    Private Sub cbltype_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbltype.CheckedChanged
        If cbltype.Checked = True Then
            ddlltime.Enabled = True
            txtlDays.Text = "0.5"
        Else
            ddlltime.Enabled = False
            txtlDays.Text = ""
        End If
        pnlleaveform.Visible = True
        pnlstatus.Visible = False
    End Sub
    Protected Sub btnlsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlsave.Click

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

        ' Dim fd As Date = txtlfrom.Text
        ' Dim td As Date = txtlto.Text

        If fd > td Then
            MessageBox("Please Check the date selected")
            pnlstatus.Visible = False
            pnlleaveform.Visible = True
            pnlapproval.Visible = False
            Exit Sub
        End If

        Dim applieddays As Decimal
        applieddays = Trim(txtlDays.Text)
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


        '***********************************************
        '************* INSERT ANNUAL LEAVE *************
        '***********************************************

        If leavetype = "Annual" Then
            If applieddays > bannual Or applieddays > lbllannual.Text Then
                MessageBox("Cannot Apply!!Leave Applied is more than available Anuual Leave")
                pnlstatus.Visible = False
                pnlleaveform.Visible = True
                pnlapproval.Visible = False
                Exit Sub
            End If
            If applieddays > prorate Then
                MessageBox("No.of Days applied is greater than Prorated Leave Allocated")
                pnlstatus.Visible = False
                pnlleaveform.Visible = True
                pnlapproval.Visible = False
                Exit Sub
            End If
            If applieddays < 0.5 Then
                MessageBox("Leave should not below half day")

                pnlstatus.Visible = False
                pnlleaveform.Visible = True
                pnlapproval.Visible = False
                Exit Sub
            End If
            If applieddays >= 0.5 And applieddays < 1 And timeline < 1 Then
                MessageBox("Leave should apply before one day")
                pnlapproval.Visible = False
                pnlstatus.Visible = False
                pnlleaveform.Visible = True
                Exit Sub
            End If
            If applieddays = 1 And timeline < 3 Then
                MessageBox("Leave should apply before three day")
                pnlapproval.Visible = False
                pnlstatus.Visible = False
                pnlleaveform.Visible = True
                Exit Sub
            End If
            If applieddays > 1 And timeline < 7 Then
                MessageBox("Leave should apply before seven day")
                pnlapproval.Visible = False
                pnlstatus.Visible = False
                pnlleaveform.Visible = True
                Exit Sub
            End If
            ' check if it is carry forward month or not       
         
            If applieddays = "0.5" Then
                If leavetime = "-1" Then
                    MessageBox("Please Select Leave timing")
                    pnlstatus.Visible = False
                    pnlleaveform.Visible = True
                    pnlapproval.Visible = False
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
                InsertLeave(_eid, thisdate, applieddays, anndeduction, fd, td, leavetype, txtreason.Text, leavetime, Session(cancfwd), mycfwd, backdate, ID)
                If recstatus = True Then
                    MessageBox("Annual Leave has been Updated")
                    UpdatecfwdLeave(_eid, Year(thisdate), balfwd)
                    CLearLControl()
                    pnlstatus.Visible = True
                    pnlleaveform.Visible = False
                    pnlapproval.Visible = False

                Else
                    MessageBox("Record not saved..Try again")
                    pnlstatus.Visible = False
                    pnlleaveform.Visible = True
                    pnlapproval.Visible = False
                End If
            Else
                InsertLeave(_eid, thisdate, applieddays, applieddays, fd, td, leavetype, txtreason.Text, leavetime, Session(cancfwd), mycfwd, backdate, ID)
                If recstatus = True Then
                    MessageBox("Annual Leave has been Updated")
                    pnlstatus.Visible = True
                    pnlleaveform.Visible = False
                    pnlapproval.Visible = False
                    ClearLControl()
                Else
                    MessageBox("Record not saved..Try again")
                    pnlstatus.Visible = False
                    pnlleaveform.Visible = True
                    pnlapproval.Visible = False
                End If
            End If
            '***********************************************
            '************* INSERT MEDICAL LEAVE ************
            '***********************************************
        ElseIf leavetype = "Medical" Then
            If applieddays = "0.5" Then
                If leavetime = "-1" Then
                    MessageBox("Please Select Leave timing")
                    pnlstatus.Visible = False
                    pnlleaveform.Visible = True
                    pnlapproval.Visible = False
                    Exit Sub
                End If
            Else
                leavetime = ""
            End If
            If applieddays > bmedical Or applieddays > lbllmedical.Text Then
                MessageBox("Cannot Apply!!Leave Applied is more than available Medical Leave")
                pnlstatus.Visible = False
                pnlleaveform.Visible = True
                pnlapproval.Visible = False
                Exit Sub

            End If
            InsertLeave(_eid, thisdate, applieddays, applieddays, fd, td, leavetype, txtreason.Text, leavetime, cancarry, mycfwd, backdate, ID)
            If recstatus = True Then
                MessageBox("Medical Leave has been scheduled")
                pnlstatus.Visible = True
                pnlleaveform.Visible = False
                pnlapproval.Visible = False
                ClearLControl()
            Else
                MessageBox("Record not saved..Try again")
                pnlstatus.Visible = False
                pnlleaveform.Visible = True
                pnlapproval.Visible = False
            End If
            '********************************************************************
            '************* INSERT EMERGENCY AND PLAN EMERGENCY LEAVE ************
            '********************************************************************
        ElseIf leavetype = "Emergency" Or leavetype = "PlanEmergency" Then
            If applieddays > bannual Or applieddays > lbllannual.Text Then
                MessageBox("Cannot Apply!!Leave Applied is more than available Anuual Leave")
                pnlstatus.Visible = False
                pnlleaveform.Visible = True
                pnlapproval.Visible = False
                Exit Sub

            End If
            If applieddays > prorate Then
                MessageBox("No.of Days applied is greater than Prorated Leave Allocated")
                pnlapproval.Visible = False
                pnlstatus.Visible = False
                pnlleaveform.Visible = True
                Exit Sub
            End If
            If applieddays < 0.5 Then
                MessageBox("Leave should not below half day")
                pnlstatus.Visible = False
                pnlleaveform.Visible = True
                pnlapproval.Visible = False
                Exit Sub
            End If

            If applieddays = "0.5" Then
                If leavetime = "-1" Then
                    MessageBox("Please Select Leave timing")
                    pnlstatus.Visible = False
                    pnlleaveform.Visible = True
                    pnlapproval.Visible = False
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
                InsertLeave(_eid, thisdate, applieddays, anndeduction, fd, td, leavetype, txtreason.Text, leavetime, Session(cancfwd), mycfwd, backdate, ID)
                If recstatus = True Then
                    MessageBox("Leave has been scheduled")
                    UpdatecfwdLeave(_eid, Year(thisdate), balfwd)
                    pnlstatus.Visible = True
                    pnlleaveform.Visible = False
                    ClearLControl()
                Else
                    MessageBox("Record not saved..Try again")
                    pnlstatus.Visible = False
                    pnlleaveform.Visible = True
                    pnlapproval.Visible = False

                End If
            Else
                InsertLeave(_eid, thisdate, applieddays, applieddays, fd, td, leavetype, txtreason.Text, leavetime, Session(cancfwd), mycfwd, backdate, ID)
                If recstatus = True Then
                    MessageBox("Leave has been scheduled")
                    pnlstatus.Visible = True
                    pnlleaveform.Visible = False
                    pnlapproval.Visible = False
                    ClearLControl()
                Else
                    MessageBox("Record not saved..Try again")
                    pnlstatus.Visible = False
                    pnlleaveform.Visible = True
                    pnlapproval.Visible = False
                End If
            End If

            '***********************************************
            '************* INSERT OTHER LEAVE ************
            '***********************************************
        ElseIf leavetype <> "annual" And leavetype <> "Medical" And leavetype <> "Emergency" And leavetype <> "PlanEmergency" Then
            If applieddays = "0.5" Then
                If leavetime = "-1" Then
                    MessageBox("Please Select Leave timing")
                    pnlstatus.Visible = False
                    pnlleaveform.Visible = True
                    pnlapproval.Visible = False
                    Exit Sub
                End If
            Else
                leavetime = ""
            End If
            InsertLeave(_eid, thisdate, applieddays, applieddays, fd, td, leavetype, txtreason.Text, leavetime, cancarry, mycfwd, backdate, ID)
            If recstatus = True Then
                MessageBox("Leave has been scheduled")
                pnlstatus.Visible = True
                pnlleaveform.Visible = False
                clearlcontrol()
            Else
                MessageBox("Record not saved..Try again")
                pnlstatus.Visible = False
                pnlleaveform.Visible = True
                pnlapproval.Visible = False
            End If

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
        pnlstatus.Visible = True
        btnlsave.Visible = True
        pnlapproval.Visible = False
        pnlleaveform.Visible = False
        GridView1.DataBind()

    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Protected Sub txtlto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtlto.TextChanged

        'Dim fd1 As String
        'fd1 = txtlfrom.Text.Trim
        'Dim strdate() As String = fd1.Split("/"c)
        'fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        'Dim fd As Date
        'fd = CDate(fd1)

        'Dim td1 As String
        'td1 = txtlto.Text.Trim
        'Dim strdate2() As String = td1.Split("/"c)
        'td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

        'Dim td As Date
        'td = CDate(td1)

        'If txtlfrom.Text = "" Or txtlto.Text = "" Then
        '    txtlDays.Text = "0"
        'Else
        '    txtlDays.Text = td.Subtract(fd).Days
        'End If

    End Sub

    Protected Sub sqlLeave_Selecting(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles Sqlleave.Selecting
        e.Command.Parameters(0).Value = _eid
        e.Command.Parameters(1).Value = _fisyrStart
        e.Command.Parameters(2).Value = _fisyrEnd
    End Sub

    Protected Sub sqlHodapproval_Selecting(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles sqlHodapproval.Selecting
        e.Command.Parameters(1).Value = _eid
        e.Command.Parameters(0).Value = _edept
    End Sub


    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'determine the value of the status field
            Dim status As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "status")).Trim
            Dim label As Label = TryCast(e.Row.FindControl("label1"), Label)
            Dim button As LinkButton = TryCast(e.Row.FindControl("LinkButton1"), LinkButton)
            Dim button2 As LinkButton = TryCast(e.Row.FindControl("LinkButton5"), LinkButton)
            If status = "scheduled" Or status = "SCHEDULED" Then
                button.Visible = True
                label.Visible = False
                button2.Visible = True
            Else
                label.Visible = True
                button.Visible = False
                button2.Visible = False
            End If

            If status = "scheduled" Or status = "SCHEDULED" Then
                ' color the background of the row yellow
                e.Row.Cells(9).ForeColor = Drawing.Color.Yellow
                ' e.Row.Cells(0).Attributes.Add("class", "statusclass")
            ElseIf status = "Approved" Or status = "APPROVED" Then
                e.Row.Cells(9).ForeColor = Drawing.Color.Green
            ElseIf status = "Rejected" Or status = "REJECTED" Then
                e.Row.Cells(9).ForeColor = Drawing.Color.Red
            End If
        End If
    End Sub
    Public Sub getLeaveData(ByVal sender As Object, ByVal e As CommandEventArgs)
        Dim workfor As Decimal
        Dim nocf As Decimal
        Dim leavetype As String
        appno = e.CommandArgument
        Try
            getLeaveDetails(e.CommandArgument)
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
            End If
            Leavecalculation()
            If (leavetype = "Annual" Or leavetype = "Planemergency" Or leavetype = "Emergency") Then
                lbllbannual.Text = lbllbannual.Text + workfor
                lbllbcfwd.Text = lbllbcfwd.Text + nocf
                lbllprorate.Text = lbllprorate.Text + workfor
            ElseIf leavetype = "Medical" Then
                lbllbmedical.Text = lbllbmedical.Text + workfor
            End If
            pnlstatus.Visible = False
            pnlleaveform.Visible = True
            pnlapproval.Visible = False
            btnlsave.Visible = False
            btnUpdate.Visible = True

        Catch ex As Exception
            MessageBox(ex.Message)
        End Try

    End Sub

    Public Sub Leavecancel(ByVal sender As Object, ByVal e As CommandEventArgs)
        appno = e.CommandArgument
        Dim REMAIN As Decimal
        Dim NOCF As Decimal
        Dim cfd As Char
        Dim rc As Decimal
        Dim curyear1 As Integer = Year(thisdate)

        getLeaveDetails(appno)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                If Not dr("nocf") Is System.DBNull.Value Then
                    NOCF = dr("nocf").ToString
                End If
                cfd = dr("carryfwd").ToString
            End If
        End If


        Try
            cancelLeave(e.CommandArgument)
            If cfd = "Y" Then
                GetCfwdLeave(_eid, curyear1)
                If recstatus = True Then
                    Dim dr As DataRow
                    If dsdata.Tables(0).Rows.Count > 0 Then
                        dr = dsdata.Tables(0).Rows(0)
                        If dr("remain") Is System.DBNull.Value Then
                            rc = 0
                        Else
                            rc = dr("remain").ToString
                        End If
                    End If
                End If
                REMAIN = NOCF + rc
                UpdatecfwdLeave(_eid, Year(thisdate), REMAIN)
            End If

        Catch ex As Exception
            MessageBox(ex.Message)
        End Try
        GridView1.DataBind()
        pnlstatus.Visible = True
        pnlleaveform.Visible = False

    End Sub

    Protected Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

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

        ' Dim fd As Date = txtlfrom.Text
        ' Dim td As Date = txtlto.Text

        If fd > td Then
            MessageBox("Please Check your date")
            pnlstatus.Visible = False
            pnlleaveform.Visible = True
            pnlapproval.Visible = False
            Exit Sub
        End If

        Dim applieddays As Decimal
        applieddays = Trim(txtlDays.Text)

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
                pnlstatus.Visible = False
                pnlleaveform.Visible = True
                pnlapproval.Visible = False
                Exit Sub
            End If
            If applieddays > prorate Then
                MessageBox("No.of Days applied is greater than Prorated Leave Allocated")
                pnlstatus.Visible = False
                pnlleaveform.Visible = True
                pnlapproval.Visible = False
                Exit Sub
            End If
            If applieddays < 0.5 Then
                MessageBox("Leave should not below half day")
                pnlstatus.Visible = False
                pnlleaveform.Visible = True
                pnlapproval.Visible = False
                Exit Sub
            End If
            If applieddays >= 0.5 And applieddays < 1 And timeline < 1 Then
                MessageBox("Leave should apply before one day")
                pnlstatus.Visible = False
                pnlleaveform.Visible = True
                pnlapproval.Visible = False
                Exit Sub
            End If
            If applieddays = 1 And timeline < 3 Then
                MessageBox("Leave should apply before three day")
                pnlstatus.Visible = False
                pnlleaveform.Visible = True
                pnlapproval.Visible = False
                Exit Sub
            End If
            If applieddays > 1 And timeline < 7 Then
                MessageBox("Leave should apply before seven day")
                pnlstatus.Visible = False
                pnlleaveform.Visible = True
                pnlapproval.Visible = False
                Exit Sub
            End If
            ' check if it is carry forward month or not       

            If applieddays = "0.5" Then
                If leavetime = "-1" Then
                    MessageBox("Please Select Leave timing")
                    pnlstatus.Visible = False
                    pnlleaveform.Visible = True
                    pnlapproval.Visible = False
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
                    pnlleaveform.Visible = False
                    pnlstatus.Visible = True
                    pnlapproval.Visible = False
                    CLearLControl()
                Else
                    MessageBox("Record not saved..Try again")
                    pnlleaveform.Visible = True
                    pnlstatus.Visible = False
                    pnlapproval.Visible = False
                End If
            Else
                UpdateLeave(rno, _eid, thisdate, applieddays, applieddays, fd, td, leavetype, txtreason.Text, leavetime, Session(cancfwd), mycfwd, backdate)
                If recstatus = True Then
                    MessageBox("Annual Leave has been Updated")
                    pnlleaveform.Visible = False
                    pnlstatus.Visible = True
                    GridView1.DataBind()
                    CLearLControl()
                Else
                    MessageBox("Record not saved..Try again")
                    pnlleaveform.Visible = True
                    pnlstatus.Visible = False
                    pnlapproval.Visible = False
                End If
            End If
            '***********************************************
            '************* INSERT MEDICAL LEAVE ************
            '***********************************************
        ElseIf leavetype = "Medical" Then
            If applieddays = "0.5" Then
                If leavetime = "-1" Then
                    MessageBox("Please Select Leave timing")
                    pnlleaveform.Visible = True
                    pnlstatus.Visible = False
                    pnlapproval.Visible = False
                    Exit Sub
                End If
            Else
                leavetime = ""
            End If
            If applieddays > bmedical Or applieddays > lbllmedical.Text Then
                MessageBox("Cannot Apply!!Leave Applied is more than available Medical Leave")
                pnlleaveform.Visible = True
                pnlstatus.Visible = False
                pnlapproval.Visible = False
                Exit Sub
             
            End If
            UpdateLeave(rno, _eid, thisdate, applieddays, applieddays, fd, td, leavetype, txtreason.Text, leavetime, cancarry, mycfwd, backdate)
            If recstatus = True Then
                MessageBox("Medical Leave has been Updated")
                pnlleaveform.Visible = False
                pnlstatus.Visible = True
                GridView1.DataBind()
                CLearLControl()
            Else
                MessageBox("Record not saved..Try again")
                pnlleaveform.Visible = True
                pnlstatus.Visible = False
                pnlapproval.Visible = False
            End If
            '********************************************************************
            '************* INSERT EMERGENCY AND PLAN EMERGENCY LEAVE ************
            '********************************************************************
        ElseIf leavetype = "Emergency" Or leavetype = "PlanEmergency" Then
            If applieddays > bannual Or applieddays > lbllannual.Text Then
                MessageBox("Cannot Apply!!Leave Applied is more than available Anuual Leave")
                pnlleaveform.Visible = True
                pnlstatus.Visible = False
                pnlapproval.Visible = False
                Exit Sub
            End If
            If applieddays > prorate Then
                MessageBox("No.of Days applied is greater than Prorated Leave Allocated")
                pnlleaveform.Visible = True
                pnlstatus.Visible = False
                pnlapproval.Visible = False
                Exit Sub
            End If
            If applieddays < 0.5 Then
                MessageBox("Leave should not below half day")
                pnlleaveform.Visible = True
                pnlstatus.Visible = False
                pnlapproval.Visible = False
                Exit Sub
            End If

            If applieddays = "0.5" Then
                If leavetime = "-1" Then
                    MessageBox("Please Select Leave timing")
                    pnlleaveform.Visible = True
                    pnlstatus.Visible = False
                    pnlapproval.Visible = False
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
                    pnlleaveform.Visible = False
                    pnlstatus.Visible = True
                    GridView1.DataBind()
                    CLearLControl()
                Else
                    MessageBox("Record not saved..Try again")
                    pnlleaveform.Visible = True
                    pnlstatus.Visible = False
                    pnlapproval.Visible = False
                End If
            Else
                UpdateLeave(rno, _eid, thisdate, applieddays, applieddays, fd, td, leavetype, txtreason.Text, leavetime, Session(cancfwd), mycfwd, backdate)
                If recstatus = True Then
                    MessageBox("Leave Updated")
                    CLearLControl()
                Else
                    MessageBox("Record not saved..Try again")
                    pnlleaveform.Visible = True
                    pnlstatus.Visible = False
                    pnlapproval.Visible = False
                End If
            End If
            '***********************************************
            '************* INSERT OTHER LEAVE ************
            '***********************************************
        ElseIf leavetype <> "annual" And leavetype <> "Medical" And leavetype <> "Emergency" And leavetype <> "PlanEmergency" Then
            If applieddays = "0.5" Then
                If leavetime = "-1" Then
                    MessageBox("Please Select Leave timing")
                    pnlleaveform.Visible = True
                    pnlstatus.Visible = False
                    pnlapproval.Visible = False
                    Exit Sub
                End If
            Else
                leavetime = ""
            End If
            UpdateLeave(rno, _eid, thisdate, applieddays, applieddays, fd, td, leavetype, txtreason.Text, leavetime, cancarry, mycfwd, backdate)
            If recstatus = True Then
                MessageBox("Leave has been Updated")
                pnlleaveform.Visible = False
                pnlstatus.Visible = True
                CLearLControl()

            Else
                MessageBox("Record not saved..Try again")
                pnlleaveform.Visible = True
                pnlstatus.Visible = False
                pnlapproval.Visible = False
            End If
        End If
    End Sub
    'Private Sub LbLform_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LbLform.Click
    '    gppassnum.Text = ""
    '    btnUpdate.Visible = False
    '    btnlsave.Visible = True
    '    Leavecalculation()
    '    DropDownList1.SelectedValue = "-1"
    '    txtlfrom.Text = ""
    '    txtlto.Text = ""
    '    ddlltime.SelectedValue = "-1"
    '    txtlDays.Text = ""
    '    txtreason.Text = ""
    '    ddlltime.Enabled = False
    '    pnlleaveform.Visible = True
    '    pnlstatus.Visible = False
    '    ddlltime.Enabled = False

    'End Sub
    'Private Sub lbselfstatus_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbselfstatus.Click
    '    pnlstatus.Visible = True
    '    GridView1.DataBind()
    'End Sub
    'Private Sub lblapproval_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblapproval.Click
    '    pnlstatus.Visible = False
    '    pnlapproval.Visible = True
    '    GridView2.DataBind()
    'End Sub
    'Private Sub lblERapproval_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblERapproval.Click

    '    pnlstatus.Visible = False
    '    PnlERApproval.Visible = True
    '    GrdERapproval.DataBind()
    'End Sub
    'Private Sub lblPRcancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblPRcancel.Click
    '    Pnllcancel.Visible = True
    '    pnlstatus.Visible = False
    '    GrdLeaveCancel.DataBind()
    'End Sub
    Private Sub GridView2_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowCreated
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(0).Visible = False
            e.Row.Cells(13).Visible = False
            e.Row.Cells(14).Visible = False
            e.Row.Cells(4).Visible = False
        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(0).Visible = False
            e.Row.Cells(14).Visible = False
            e.Row.Cells(13).Visible = False
            e.Row.Cells(4).Visible = False
        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(0).Visible = False
            e.Row.Cells(14).Visible = False
            e.Row.Cells(13).Visible = False
            e.Row.Cells(4).Visible = False
        End If
    End Sub
    Public Sub UpdateLeaveApproval(ByVal sender As Object, ByVal e As EventArgs)
        Dim workfor As String
        workfor = ""
        Dim bal As Decimal
        bal = "0"
        Dim remain As Decimal
        remain = "0"
        Dim rc As Decimal
        rc = "0"
        Dim wf As Decimal
        wf = "0"
        For i As Integer = 0 To GridView2.Rows.Count - 1
            Dim passno As String = GridView2.Rows(i).Cells(0).Text
            Dim granted As String = DirectCast(GridView2.Rows(i).FindControl("txtgranted"), TextBox).Text
            Dim gfrom As String = DirectCast(GridView2.Rows(i).FindControl("txtgfrom"), TextBox).Text
            Dim gtill As String = DirectCast(GridView2.Rows(i).FindControl("txtgto"), TextBox).Text
            If Not GridView2.Rows(i).Cells(4).Text = "" Or GridView2.Rows(i).Cells(4).Text <> "&nbsp;" Then
                workfor = GridView2.Rows(i).Cells(4).Text
            End If
            Dim nocf As Decimal = GridView2.Rows(i).Cells(14).Text
            Dim ltype As String = GridView2.Rows(i).Cells(6).Text
            Dim status As String = DirectCast(GridView2.Rows(i).FindControl("rblvstatus"), RadioButtonList).SelectedValue
            Dim Cfwd As Char = GridView2.Rows(i).Cells(13).Text.Trim
            Dim typ As String
            If ltype = "Annual" Then
                typ = "AL"
            ElseIf ltype = "Calamity" Then
                typ = "CAL"
            ElseIf ltype = "CompanyHoliday" Then
                typ = "CH"
            ElseIf ltype = "Compassionate" Then
                typ = "CL"
            ElseIf ltype = "Marriage-Children" Then
                typ = "MAC"
            ElseIf ltype = "Maternity" Then
                typ = "ML"
            ElseIf ltype = "Paternity" Then
                typ = "PL"
            ElseIf ltype = "PlanEmergency" Then
                typ = "PEAL"
            ElseIf ltype = "PlanEmergencyUP" Then
                typ = "PLUP"
            ElseIf ltype = "Hospitalization" Then
                typ = "HL"
            ElseIf ltype = "marriage-self" Then
                typ = "MS"
            ElseIf ltype = "Emergency" Then
                typ = "AL"
            ElseIf ltype = "EmergencyUP" Then
                typ = "EUP"
            ElseIf ltype = "Unpaid" Then
                typ = "UP"
            ElseIf ltype = "Medical" Then
                typ = "MC"
            End If
            Dim curMth1 As Integer = Month(thisdate)
            Dim curyear1 As Integer = Year(thisdate)

            If status = "APPROVED" Then
                If gfrom <> "" Then
                    Dim strdate() As String = gfrom.Split("/"c)
                    gfrom = strdate(1) & "/" & strdate(0) & "/" & strdate(2)
                End If
                If gtill <> "" Then
                    Dim strdate2() As String = gtill.Split("/"c)
                    gtill = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)
                End If
                If Cfwd = "Y" Then
                    If granted.Length > 0 Then
                        If granted > nocf Then
                            bal = granted - nocf
                            wf = bal
                        ElseIf granted <= nocf Then
                            bal = nocf - granted
                            wf = "0"
                            nocf = granted
                            GetCfwdLeave(_eid, curyear1)
                            If recstatus = True Then
                                Dim dr As DataRow
                                If dsdata.Tables(0).Rows.Count > 0 Then
                                    dr = dsdata.Tables(0).Rows(0)
                                    If dr("remain") Is System.DBNull.Value Then
                                        rc = 0
                                    Else
                                        rc = dr("remain").ToString
                                    End If
                                End If
                            End If
                            remain = bal + rc
                            UpdatecfwdLeave(_eid, Year(thisdate), remain)
                        End If ' for granted <= nocf
                    Else ' for granted.Length > 0
                        granted = workfor + nocf
                        wf = workfor
                    End If
                    UpdateLVCApproval(passno, status, granted, gfrom, gtill, typ, wf, nocf)
                Else ' for not cfwd mth
                    If granted.Length > 0 Then
                        workfor = granted
                        UpdateLVApproval(passno, status, granted, gfrom, gtill, typ, workfor)
                    Else
                        granted = workfor
                        UpdateLVApproval(passno, status, granted, gfrom, gtill, typ, workfor)
                    End If
                End If
            ElseIf status = "REJECTED" Then
                UpdateLVRApproval(passno, status)
                If Cfwd = "Y" Then
                    GetCfwdLeave(_eid, curyear1)
                    If recstatus = True Then
                        Dim dr As DataRow
                        If dsdata.Tables(0).Rows.Count > 0 Then
                            dr = dsdata.Tables(0).Rows(0)
                            If dr("remain") Is System.DBNull.Value Then
                                rc = 0
                            Else
                                rc = dr("remain").ToString
                            End If
                        End If
                    End If
                    remain = nocf + rc
                    UpdatecfwdLeave(_eid, Year(thisdate), remain)
                End If
            End If
        Next
        GridView2.DataBind()
        GridView1.DataBind()
    End Sub

    Protected Sub SqlERApproval_Selecting(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlERApproval.Selecting
        e.Command.Parameters(0).Value = "014542"
    End Sub

    Private Sub GrdERapproval_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrdERapproval.RowCreated
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(0).Visible = False
            e.Row.Cells(11).Visible = False
            e.Row.Cells(10).Visible = False
            e.Row.Cells(4).Visible = False
        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(0).Visible = False
            e.Row.Cells(11).Visible = False
            e.Row.Cells(10).Visible = False
            e.Row.Cells(4).Visible = False
        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(0).Visible = False
            e.Row.Cells(11).Visible = False
            e.Row.Cells(10).Visible = False
            e.Row.Cells(4).Visible = False
        End If
    End Sub
    Public Sub UpdateLeaveERApproval(ByVal sender As Object, ByVal e As EventArgs)
        Dim workfor As String
        workfor = ""
        Dim bal As Decimal
        bal = "0"
        Dim remain As Decimal
        remain = "0"
        Dim rc As Decimal
        rc = "0"
        Dim wf As Decimal
        wf = "0"
        For i As Integer = 0 To GrdERapproval.Rows.Count - 1
            Dim passno As String = GrdERapproval.Rows(i).Cells(0).Text
            If Not GrdERapproval.Rows(i).Cells(4).Text = "" Or GrdERapproval.Rows(i).Cells(4).Text <> "&nbsp;" Then
                workfor = GrdERapproval.Rows(i).Cells(4).Text
            End If
            Dim nocf As Decimal = GrdERapproval.Rows(i).Cells(11).Text
            Dim ltype As String = GrdERapproval.Rows(i).Cells(6).Text
            Dim status As String = DirectCast(GrdERapproval.Rows(i).FindControl("rblvestatus"), RadioButtonList).SelectedValue
            Dim Cfwd As Char = GrdERapproval.Rows(i).Cells(10).Text.Trim
            Dim bd As Char = GrdERapproval.Rows(i).Cells(12).Text.Trim
            Dim sreason As String = DirectCast(GrdERapproval.Rows(i).FindControl("txtsreason"), TextBox).Text

            Dim typ As String
            If ltype = "Annual" Then
                typ = "AL"
            ElseIf ltype = "Calamity" Then
                typ = "CAL"
            ElseIf ltype = "CompanyHoliday" Then
                typ = "CH"
            ElseIf ltype = "Compassionate" Then
                typ = "CL"
            ElseIf ltype = "Marriage-Children" Then
                typ = "MAC"
            ElseIf ltype = "Maternity" Then
                typ = "ML"
            ElseIf ltype = "Paternity" Then
                typ = "PL"
            ElseIf ltype = "PlanEmergency" Then
                typ = "PEAL"
            ElseIf ltype = "PlanEmergencyUP" Then
                typ = "PLUP"
            ElseIf ltype = "Hospitalization" Then
                typ = "HL"
            ElseIf ltype = "marriage-self" Then
                typ = "MS"
            ElseIf ltype = "Emergency" Then
                typ = "AL"
            ElseIf ltype = "EmergencyUP" Then
                typ = "EUP"
            ElseIf ltype = "Unpaid" Then
                typ = "UP"
            ElseIf ltype = "Medical" Then
                typ = "MC"
            End If
            Dim curMth1 As Integer = Month(thisdate)
            Dim curyear1 As Integer = Year(thisdate)

            If status = "APPROVED" Then
                UpdateLVERApproval(passno, status, typ)
            ElseIf status = "REJECTED" Then
                UpdateLVRERApproval(passno, status, sreason)
                If Cfwd = "Y" Then
                    GetCfwdLeave(_eid, curyear1)
                    If recstatus = True Then
                        Dim dr As DataRow
                        If dsdata.Tables(0).Rows.Count > 0 Then
                            dr = dsdata.Tables(0).Rows(0)
                            If dr("remain") Is System.DBNull.Value Then
                                rc = 0
                            Else
                                rc = dr("remain").ToString
                            End If
                        End If
                    End If
                    remain = nocf + rc
                    UpdatecfwdLeave(_eid, Year(thisdate), remain)
                End If
            End If
        Next
        GrdERapproval.DataBind()
        GridView1.DataBind()
    End Sub
    Public Sub leavecalculation2(ByVal empid As String)
        GetEmpVehino(empid)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                doj = dr("dateofjoin").ToString
            End If
        End If
        ' find the experience of employee
        Dim exp As String
        Dim ann As Decimal
        Dim med As Decimal
        Dim probation As Decimal
        Dim expr As Integer
        Dim expmth As Integer
        expr = 0
        ann = 0
        med = 0
        probation = 0

        exp = thisdate.Subtract(doj).Days
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
        GetLeaveLevel(empid, expr)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                'doj = dr("dateofjoin").ToString
                ann = dr("annual").ToString
                med = dr("medical").ToString
                probation = dr("probation").ToString
            End If
        End If
        ' Get the balance annual and Medical leave
        Dim leavetaken As Decimal
        leavetaken = 0
        Dim mLeavetaken As Decimal
        mLeavetaken = 0
        Dim balAleave As Decimal
        balAleave = 0
        Dim balMleave As Decimal
        balMleave = 0

        CountAnnualLeaveTaken(empid, _fisyrStart, _fisyrEnd)
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
        End If


        CountMedicalLeaveTaken(empid, _fisyrStart, _fisyrEnd)
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
        End If

        balMleave = med - mLeavetaken
        balAleave = ann - leavetaken
    
        Session("myannual") = ann
        Session("myannbal") = balAleave
        Session("mymedical") = med
        Session("mymedbal") = balMleave

        'prorate calculation
        Dim prorate As Decimal
        Dim workeddays As Decimal

        prorate = 0
        workeddays = 0
        If expmth > probation Then
            If doj > _fisyrStart Then
                workeddays = thisdate.Subtract(doj).Days
                prorate = (workeddays / 365) * ann
            Else
                workeddays = thisdate.Subtract(_fisyrStart).Days
                prorate = (workeddays / 365) * ann
                'prorate = Math.Round(prorate, 1)
                prorate = Math.Round(prorate - leavetaken, 1)
            End If
        Else
            prorate = 0
        End If
        Session("myprorate") = prorate


        'lbltxtempid.Text = empID
    End Sub
    Protected Sub emphistory_click(ByVal sender As Object, ByVal e As EventArgs)
        ' Fetch the emp id     
        Dim empid As String
        Dim lb As LinkButton = TryCast(sender, LinkButton)
        Session("emp") = lb.Text
        empid = lb.Text
        ' Get the date of join of emp 
        leavecalculation2(empid)
        lbltotannual.Text = Session("myannbal")
        lbltotMedical.Text = Session("mymedbal")
        GetEmpVehino(empid)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                lbltxtempid.Text = dr("empname").ToString
                txtdept2.Text = dr("departmentcode").ToString + "-" + dr("sectioncode").ToString
                Label15.Text = dr("designation")
            End If
        End If
        BindGridGpHistory(empid)
        pnlstatus.Visible = False
        pnlapproval.Visible = True
        Pnlhistory.Visible = True
        leavempe.Show()
    End Sub
    Public Sub BindGridGpHistory(ByVal empid As String)
        GetLVHistory(empid, _fisyrStart, _fisyrEnd)
        If recstatus = True Then
            Grdlvhistory.DataSource = dsdata.Tables(0).DefaultView
            'GrdGphistory.AllowPaging = True
            Grdlvhistory.HeaderStyle.ForeColor = Drawing.Color.Red
            Grdlvhistory.HeaderStyle.VerticalAlign = VerticalAlign.Middle
            Grdlvhistory.DataBind()
        End If
    End Sub

    Private Sub Grdlvhistory_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles Grdlvhistory.PageIndexChanging
        BindGridGpHistory(Session("emp"))
        Grdlvhistory.PageIndex = e.NewPageIndex
        Grdlvhistory.DataBind()
        pnlstatus.Visible = False
        pnlapproval.Visible = True
        Pnlhistory.Visible = True
        leavempe.Show()

    End Sub

    Protected Sub SqlLeavecancel_Selecting(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlLeavecancel.Selecting
        e.Command.Parameters(0).Value = _fisyrStart
        e.Command.Parameters(1).Value = _fisyrEnd
    End Sub

    Private Sub GrdLeaveCancel_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrdLeaveCancel.RowCreated
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(0).Visible = False
            e.Row.Cells(9).Visible = False
            e.Row.Cells(10).Visible = False
        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(0).Visible = False
            e.Row.Cells(9).Visible = False
            e.Row.Cells(10).Visible = False
        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(0).Visible = False
            e.Row.Cells(9).Visible = False
            e.Row.Cells(10).Visible = False
        End If
    End Sub

    Public Sub UpdateLeavePRApproval(ByVal sender As Object, ByVal e As EventArgs)

        Dim remain As Decimal
        remain = "0"
        Dim rc As Decimal
        rc = "0"

        For i As Integer = 0 To GrdLeaveCancel.Rows.Count - 1
            Dim passno As String = GrdLeaveCancel.Rows(i).Cells(0).Text
            Dim nocf As Decimal = GrdLeaveCancel.Rows(i).Cells(9).Text
            Dim status As String = DirectCast(GrdLeaveCancel.Rows(i).FindControl("rbprstatus"), RadioButtonList).SelectedValue
            Dim Cfwd As Char = GrdLeaveCancel.Rows(i).Cells(10).Text.Trim

            Dim curMth1 As Integer = Month(thisdate)
            Dim curyear1 As Integer = Year(thisdate)

            If status = "CANCELLED" Then
                UpdateLVRCancel(passno, status)
                If Cfwd = "Y" Then
                    GetCfwdLeave(_eid, curyear1)
                    If recstatus = True Then
                        Dim dr As DataRow
                        If dsdata.Tables(0).Rows.Count > 0 Then
                            dr = dsdata.Tables(0).Rows(0)
                            If dr("remain") Is System.DBNull.Value Then
                                rc = 0
                            Else
                                rc = dr("remain").ToString
                            End If
                        End If
                    End If
                    remain = nocf + rc
                    UpdatecfwdLeave(_eid, Year(thisdate), remain)
                End If
            End If
        Next
        GrdLeaveCancel.DataBind()
    End Sub

    Protected Sub Btnsetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnsetting.Click
         Try
            InsertLeaveLevel(txtllevel.Text.Trim, Ddlexperience.SelectedValue, txtprobation.Text.Trim, txtaentitile.Text.Trim, txtmentitile.Text.Trim)
            If recstatus = True Then
                lblmsg.Text = "New LeaveLevel Added Successfully"
                grdleavelevel.DataBind()
                txtllevel.Text = ""
                Ddlexperience.SelectedValue = "-1"
                txtprobation.Text = ""
                txtaentitile.Text = ""
                txtmentitile.Text = ""
            Else
                lblmsg.Text = "Cannot Save new LeaveLevel"
            End If
        Catch ex As Exception
            MessageBox(ex.Message)
        End Try
        Pnllsetting.Visible = True
        pnlstatus.Visible = False
    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim rdvalue As String
        rdvalue = rdoptions.SelectedValue
      
        Session("alldesig") = Trim(ddldesigr.SelectedValue)
        Session("allemp") = Trim(txtempidr.Text)
        Session("allstatus") = RadioButtonList1.SelectedValue.Trim
        Session("allsect") = Trim(ddlsectrpt.SelectedValue)
        Session("alldept") = ddldeptr.SelectedValue.Trim


        Dim fd1 As String
        fd1 = txtfrom.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)
        Session("allfromd") = fd

        Dim td1 As String
        td1 = txtto.Text.Trim
        Dim strdate2() As String = td1.Split("/"c)
        td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

        Dim td As Date
        td = CDate(td1)
        Session("alltod") = td

     
        If rdvalue = "Dept" And ddldeptr.SelectedValue <> "" Then
            ' Button1.Attributes.Add("onclick", String.Format("window.open('/Reports/Hrmis/leave_all.aspx?fromd={0}&tod={1}&dep={2}&status={3}','_blank','fullscreen=yes,popup,scrollbars=yes,menubar=yes')", fd, td, ddldeptr.SelectedValue, status))
            Response.Redirect("/Reports/Hrmis/leave_all.aspx")
        ElseIf rdvalue = "Sect" And ddlsectrpt.SelectedValue <> "" Then
            'Button1.Attributes.Add("onclick", String.Format("window.open('/Reports/Hrmis/leave_sectall.aspx?fromd={0}&tod={1}&dep={2}&status={3}','_blank','fullscreen=yes,scrollbars=yes,menubar=yes')", fd, td, sectrpt, status))
            Response.Redirect("/Reports/Hrmis/leave_sectall.aspx")
        ElseIf rdvalue = "Desig" And ddldesigr.SelectedValue <> "" Then
            ' Button1.Attributes.Add("onclick", String.Format("window.open('/Reports/Hrmis/leave_designation.aspx?fromd={0}&tod={1}&desig={2}&status={3}','_blank','fullscreen=yes,scrollbars=yes,menubar=yes')", fd, td, designation, status))
            Response.Redirect("/Reports/Hrmis/leave_designation.aspx")
        ElseIf rdvalue = "Emp" And txtempidr.Text <> "" Then
            'Button1.Attributes.Add("onclick", String.Format("window.open('/Reports/Hrmis/leave_empr.aspx?fromd={0}&tod={1}&desig={2}&status={3}','_blank','fullscreen=no,popup,scrollbars=yes,menubar=yes')", fd, td, empid, status))
            Response.Redirect("/Reports/Hrmis/leave_empr.aspx")
        Else
            ' Button1.Attributes.Add("onclick", String.Format("window.open('/Reports/Hrmis/leave_overall.aspx?fromd={0}&tod={1}&status={2}','_blank','fullscreen=yes,popup,scrollbars=yes,menubar=yes')", fd, td, status))
            Response.Redirect("/Reports/Hrmis/leave_overall.aspx")
        End If

        pnlreport.Visible = True
        pnlstatus.Visible = False
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
        pnlreport.Visible = True
        pnlstatus.Visible = False
    End Sub

    Protected Sub hodbtnrpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hodbtnrpt.Click

        pnlHODreports.Visible = True
        pnlreport.Visible = False
        pnlstatus.Visible = False

        Session("hodstatus") = hodrdooptions.SelectedValue.Trim
        Session("hodrptby") = hodrdorpt.SelectedValue.Trim
        Session("hodemp") = hodtxtemp.Text.Trim
        Session("hodsect") = hodddlsect.SelectedValue.Trim
        Dim rdvalue As String = Session("hodrptby")
        Dim empid As String = Session("hodemp")
        Dim status As String = Session("hodstatus")


        Dim fd1 As String
        fd1 = hodtxtfrom.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        Session("hodfromd") = CDate(fd1)

        Dim td1 As String
        td1 = hodtxtto.Text.Trim
        Dim strdate2() As String = td1.Split("/"c)
        td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

        Dim td As Date
        Session("hodtod") = CDate(td1)

        If rdvalue = "Sect" And hodddlsect.SelectedValue <> "" Then
            Response.Redirect("/Reports/Hrmis/leave_hod_sect.aspx")
        ElseIf rdvalue = "Emp" And hodtxtemp.Text <> "" Then
            CheckEmpDetails(_edept, empid)
            If recstatus = "true" Then
                Response.Redirect("/Reports/Hrmis/leave_hod_emp.aspx")
            Else
                MessageBox("Employee Does not belongs to your department")
            End If

        Else
            Response.Redirect("/Reports/Hrmis/leave_hod_all.aspx")
        End If

    End Sub

    Protected Sub btnrptsummary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrptsummary.Click
        Pnlleavesummary.Visible = True
        pnlstatus.Visible = False

        Session("rpttype") = rptddlltype.SelectedValue.Trim
        Dim ltype As String = Session("rpttype")

        Dim fd1 As String
        fd1 = rpttxtfrom.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        Session("lfromd") = CDate(fd1)

        Dim td1 As String
        td1 = rpttxtto.Text.Trim
        Dim strdate2() As String = td1.Split("/"c)
        td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

        Dim td As Date
        Session("ltod") = CDate(td1)

        If fd1 <> "" And td1 <> "" And ltype <> "-1" Then
            Response.Redirect("/Reports/Hrmis/leavesummary.aspx")
        Else
            MessageBox("Select all Required fields")
        End If
    End Sub

    Protected Sub btnentrpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnentrpt.Click
        pnlentitilement.Visible = True
        pnlstatus.Visible = False
        Dim rptselection As String = rdoentby.SelectedValue.Trim
        Dim seldept As String = ddlentdept.SelectedValue.Trim
        Dim seldesig As String = ddlentdesig.SelectedValue.Trim
        Dim i As Integer = 0
        Dim selemp As String
        Dim lintRowCount As Integer = 0
        If rptselection = "dept" Then
            DeleteTempTab()
            GetEmpByDept(seldept)
            If recstatus = True Then
                Dim dr1 As DataRow
                If dsdata1.Tables(0).Rows.Count > 0 Then
                    lintRowCount = dsdata1.Tables(0).Rows.Count
                    For i = 0 To lintRowCount - 1
                        DR = dsdata1.Tables(0).Rows(i)
                        selemp = DR("empcode").ToString
                        leavecalculation2(selemp)
                        InsertTempTable(selemp, Session("myannual"), Session("myannbal"), Session("mymedical"), Session("mymedbal"), Session("myprorate"))
                    Next
                End If
            Else
                MessageBox("No Records Found")
            End If
            Response.Redirect("/reports/hrmis/leaveentitilement.aspx")
        ElseIf rptselection = "Desig" Then
            DeleteTempTab()
            GetEmpByDesig(seldesig)
            If recstatus = True Then
                Dim dr1 As DataRow
                If dsdata1.Tables(0).Rows.Count > 0 Then
                    lintRowCount = dsdata1.Tables(0).Rows.Count
                    For i = 0 To lintRowCount - 1
                        DR = dsdata1.Tables(0).Rows(i)
                        selemp = DR("empcode").ToString
                        leavecalculation2(selemp)
                        InsertTempTable(selemp, Session("myannual"), Session("myannbal"), Session("mymedical"), Session("mymedbal"), Session("myprorate"))
                    Next
                End If
            Else
                MessageBox("No Records Found")
            End If
            Response.Redirect("/reports/hrmis/leaveentitilement.aspx")
        End If
    End Sub

    Protected Sub rdoentby_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoentby.SelectedIndexChanged
        pnlentitilement.Visible = True
        pnlstatus.Visible = False
        If rdoentby.SelectedValue.Trim = "dept" Then
            ddlentdesig.Enabled = False
            ddlentdept.Enabled = True
        ElseIf rdoentby.SelectedValue.Trim = "Desig" Then
            ddlentdesig.Enabled = True
            ddlentdept.Enabled = False
        End If
    End Sub
  

    Protected Sub btnsumrpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsumrpt.Click
        pnloverall.Visible = True
        pnlstatus.Visible = False

        Dim sect As String = ddlsumsect.SelectedValue.Trim
        Dim dept As String = ddlsumdept.SelectedValue.Trim
        Dim desig As String = ddlsumdesig.SelectedValue.Trim
        Dim emp As String = txtsumemp.Text.Trim
        Dim rdvalue As String = rdosumby.SelectedValue.Trim

        Dim fd1 As String
        fd1 = txtsumfrom.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)

        Dim td1 As String
        td1 = txtsumto.Text.Trim
        Dim strdate2() As String = td1.Split("/"c)
        td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

        Dim td As Date
        td = CDate(td1)

        Dim lintRowCount As Integer = 0
        Dim i As Integer = 0
        Dim selemp As String

        If rdvalue = "Dept" And dept <> "" Then
            DeleteTempleave()
            GetEmpByDept(dept)
            If recstatus = True Then
                Dim dr1 As DataRow
                If dsdata1.Tables(0).Rows.Count > 0 Then
                    lintRowCount = dsdata1.Tables(0).Rows.Count
                    For i = 0 To lintRowCount - 1
                        DR = dsdata1.Tables(0).Rows(i)
                        selemp = DR("empcode").ToString
                        leavesummarycalc(selemp, fd, td)
                    Next
                End If
                Response.Redirect("/reports/hrmis/overallleavesummary.aspx")
            End If
        ElseIf rdvalue = "Sect" And sect <> "" Then
            DeleteTempleave()
            GetEmpBysect(sect)
            If recstatus = True Then
                Dim dr1 As DataRow
                If dsdata1.Tables(0).Rows.Count > 0 Then
                    lintRowCount = dsdata1.Tables(0).Rows.Count
                    For i = 0 To lintRowCount - 1
                        DR = dsdata1.Tables(0).Rows(i)
                        selemp = DR("empcode").ToString
                        leavesummarycalc(selemp, fd, td)
                    Next
                End If
                Response.Redirect("/reports/hrmis/overallleavesummary.aspx")
            End If

        ElseIf rdvalue = "Desig" And desig <> "" Then
            DeleteTempleave()
            GetEmpByDesig(desig)
            If recstatus = True Then
                Dim dr1 As DataRow
                If dsdata1.Tables(0).Rows.Count > 0 Then
                    lintRowCount = dsdata1.Tables(0).Rows.Count
                    For i = 0 To lintRowCount - 1
                        DR = dsdata1.Tables(0).Rows(i)
                        selemp = DR("empcode").ToString
                        leavesummarycalc(selemp, fd, td)
                    Next
                End If
                Response.Redirect("/reports/hrmis/overallleavesummary.aspx")
            End If
        ElseIf rdvalue = "Emp" And emp <> "" Then
            DeleteTempleave()
            leavesummarycalc(emp, fd, td)
            Response.Redirect("/reports/hrmis/overallleavesummary.aspx")
        End If
    End Sub
    Private Sub leavesummarycalc(ByVal emp As String, ByVal fd As Date, ByVal td As Date)

        GetEmpVehino(emp)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                doj = dr("dateofjoin").ToString
            End If
        End If
        ' find the experience of employee
        Dim exp As String
        Dim ann As Decimal
        Dim med As Decimal
        Dim probation As Decimal
        Dim expr As Integer
        Dim expmth As Integer
        expr = 0
        ann = 0
        med = 0
        probation = 0

        exp = thisdate.Subtract(doj).Days
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
        GetLeaveLevel(emp, expr)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                'doj = dr("dateofjoin").ToString
                ann = dr("annual").ToString
                med = dr("medical").ToString
                probation = dr("probation").ToString
            End If
        End If
        ' Get the balance annual and Medical leave
        Dim leavetaken As Decimal
        leavetaken = 0
        Dim mLeavetaken As Decimal
        mLeavetaken = 0
        Dim eleavetaken As Decimal
        eleavetaken = 0
        Dim eupleavetaken As Decimal
        eupleavetaken = 0
        Dim peupleavetaken As Decimal
        peupleavetaken = 0
        Dim peleavetaken As Decimal
        peleavetaken = 0
        Dim upleavetaken As Decimal
        upleavetaken = 0

        ' find ann leave taken
        Countallleave(emp, fd, td, "annual")
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                If dr("leavetaken") Is System.DBNull.Value Then
                    leavetaken = 0
                Else
                    leavetaken = dr("leavetaken").ToString
                End If
            End If
        End If

        ' find medical leave taken
        Countallleave(emp, fd, td, "medical")
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                If dr("leavetaken") Is System.DBNull.Value Then
                    mLeavetaken = 0
                Else
                    mLeavetaken = dr("leavetaken").ToString
                End If
            End If
        End If

        ' find emergency leave taken
        Countallleave(emp, fd, td, "emergency")
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                If dr("leavetaken") Is System.DBNull.Value Then
                    eleavetaken = 0
                Else
                    eleavetaken = dr("leavetaken").ToString
                End If
            End If
        End If

        ' find emergencyup leave taken
        Countallleave(emp, fd, td, "emergencyUP")
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                If dr("leavetaken") Is System.DBNull.Value Then
                    eupleavetaken = 0
                Else
                    eupleavetaken = dr("leavetaken").ToString
                End If
            End If
        End If

        ' find plan emergency leave taken
        Countallleave(emp, fd, td, "Planemergency")
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                If dr("leavetaken") Is System.DBNull.Value Then
                    peleavetaken = 0
                Else
                    peleavetaken = dr("leavetaken").ToString
                End If
            End If
        End If

        ' find plan emergencyUP leave taken
        Countallleave(emp, fd, td, "PlanemergencyUP")
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                If dr("leavetaken") Is System.DBNull.Value Then
                    peupleavetaken = 0
                Else
                    peupleavetaken = dr("leavetaken").ToString
                End If
            End If
        End If

        ' find plan emergencyUP leave taken
        Countallleave(emp, fd, td, "unpaid")
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                If dr("leavetaken") Is System.DBNull.Value Then
                    upleavetaken = 0
                Else
                    upleavetaken = dr("leavetaken").ToString
                End If
            End If
        End If

        ' find compassionate leave taken
        Dim other As Integer
        other = 0
        Countotherleave(emp, fd, td)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                If dr("leavetaken") Is System.DBNull.Value Then
                    other = 0
                Else
                    other = other + dr("leavetaken").ToString
                End If
            End If
        End If
        ' Insertallleave(emp, ann, med, leavetaken, mLeavetaken, eleavetaken, peleavetaken, eupleavetaken, peupleavetaken, upleavetaken, other)
    End Sub

    Protected Sub rdosumby_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdosumby.SelectedIndexChanged
        pnloverall.Visible = True
        pnlstatus.Visible = False
        If rdosumby.SelectedValue = "Dept" Then
            ddlsumdept.Enabled = True
            ddlsumsect.Enabled = False
            ddlsumdesig.Enabled = False
            txtsumemp.Enabled = False
        ElseIf rdosumby.SelectedValue = "Sect" Then

            ddlsumdept.Enabled = False
            ddlsumsect.Enabled = True
            ddlsumdesig.Enabled = False
            txtsumemp.Enabled = False
        ElseIf rdosumby.SelectedValue = "Desig" Then

            ddlsumdept.Enabled = False
            ddlsumsect.Enabled = False
            ddlsumdesig.Enabled = True
            txtsumemp.Enabled = False
        ElseIf rdosumby.SelectedValue = "Emp" Then

            ddlsumdept.Enabled = False
            ddlsumsect.Enabled = False
            ddlsumdesig.Enabled = False
            txtsumemp.Enabled = True
        End If
    End Sub

    Protected Sub hodrdorpt_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hodrdorpt.SelectedIndexChanged
        If hodrdorpt.SelectedValue = "Sect" Then
            hodddlsect.Enabled = True
            hodtxtemp.Text = ""
            hodtxtemp.Enabled = False
        ElseIf hodrdorpt.SelectedValue = "Emp" Then
            hodtxtemp.Enabled = True
            hodddlsect.Enabled = False
        Else
            hodtxtemp.Enabled = False
            hodddlsect.Enabled = False
        End If
        pnlHODreports.Visible = True
        pnlreport.Visible = False
        pnlstatus.Visible = False
    End Sub


End Class