Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class HODapproval
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim doj As Date
    Dim thisdate As Date
    Dim cancfwd As String
    Dim appno As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '_eid = "014543"
        '_ename = "Sathya Vamshi Anigalla"
        '_edept = "9000"
        'Session("_edept") = "9000"
      


        thisdate = DateTime.Now

        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        MyApp.GetfiscalYear()
        Pnlhistory.Visible = False
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (35)
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

        getdesigname(Session("_edesig"))
        Dim dcode
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                dcode = dr("desigcode").ToString.Trim
                Session("dcode") = dcode
            End If
        Else
            lblmsg.Text = myerrormsg
            lblmsg.ForeColor = Drawing.Color.Red
        End If

        'Session("empcode") = "014623" Or
        If Not IsPostBack Then
            If dcode = "EA" Or UCase(dcode) = "DIRECTOR" Or dcode = "MD" Or dcode = "GM" Or dcode = "DGM" Or dcode = "PL Man" Or dcode = "SGM" Or dcode = "SPM" Then
                GridView2.Visible = False
                PGridView2.Visible = False
                BindGrid()
            Else
                GetHeadDept()
                GridView2.Visible = True
                PGridView2.Visible = True
            End If
        End If
    End Sub
    ''' <summary>
    ''' FOR hod approval
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub GetHeadDept()
        Dim dsh As DataSet
        Dim drh As DataRow
        Dim headdept, mydept

        dsh = GetHeadAssignment()
        If dsh.Tables(0).Rows.Count > 0 Then
            drh = dsh.Tables(0).Rows(0)
            mydept = drh("ldepartmentcode").ToString
            Dim hoddepts = mydept.split(",")
            For i As Integer = 0 To hoddepts.Length - 1
                headdept = headdept & "'" & hoddepts(i) & "',"
            Next
            headdept = headdept.remove(headdept.length - 1, 1)
        Else
            headdept = "'" & Session("_edept") & "'"
        End If
        '  Label1.Text = headdept
        BindGridhod(headdept)

    End Sub
    Function GetHeadAssignment() As DataSet

        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from head_assignment_emanagement where empcode ='" & Session("empcode") & "'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "KPIMajor")
        con.Close()
        Return ds
    End Function
    Private Sub BindGridhod(ByVal dept As String)
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        ' Command = New SqlCommand("SELECT kpi_grade_result.empcode ,  kpi_grade_result.slno , kpi_grade_result.yr , kpi_grade_result.mnth,kpi_grade_result.grade,ltrim(rtrim(kpi_grade_result.total)) as total,kpi_grade_result.status, empmaster.departmentcode, empmaster.sectioncode, empmaster.empname, empmaster.designation, empmaster.resigned, empmaster.IsOperator FROM kpi_grade_result INNER JOIN empmaster ON kpi_grade_result.empcode = empmaster.empcode WHERE (kpi_grade_result.yr = '" & ddlyr.SelectedValue & "') AND (kpi_grade_result.mnth = '" & ddlmon.SelectedValue & "') AND (empmaster.departmentcode in (" & dept & ") ) AND (empmaster.resigned = 'N') AND (empmaster.IsOperator <> 'Y') and status = 'Scheduled'", con)
        Command = New SqlCommand("SELECt  *,(Ltrim(rtrim(status))) as stat,* FROM Leaveform AS Leaveform INNER JOIN empmaster AS Empmaster  ON Empmaster.empcode = Leaveform.empno inner join designation as designation on empmaster.designation = designation.designationname  WHERE ((Leaveform.status = 'SCHEDULED'))  and (dlevel < '4')  AND (leaveform.department in (" & dept & ")) AND (Leaveform.empno <> '005000') and (Leaveform.empno <> '" & Session("empcode") & "') and (leaveform.backdate='N') AND ((Leaveform.leavetype = 'Annual') or (Leaveform.leavetype = 'Emergency') or (Leaveform.leavetype = 'EmergencyUP') or (Leaveform.leavetype = 'EmergencyUnpaid') or (Leaveform.leavetype = 'PlanEmergencyUP')or (Leaveform.leavetype = 'PlanEmergency') or (leaveform.leavetype = 'Unpaid')) ORDER BY Leaveform.appno DESC ", con)

        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "LVApprovalHod")

        GridView2.DataSource = ds
        GridView2.DataBind()
        GridView2.Visible = True
        PGridView2.Visible = True

        GRidEAGM.Visible = False
        PGRidEAGM.Visible = False

        con.Close()
    End Sub
    Private Sub GRidVIEW2_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView2.PageIndexChanging
        GetHeadDept()

        GridView2.PageIndex = e.NewPageIndex
        GridView2.DataBind()
        GridView2.Visible = True
        PGridView2.Visible = True

        GRidEAGM.Visible = False
        PGRidEAGM.Visible = False

    End Sub
    Protected Sub sqlHodapproval_Selecting(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles sqlHodapproval.Selecting
        ' e.Command.Parameters(1).Value = Session("empcode")
        '  e.Command.Parameters(0).Value = Session("_edept")
    End Sub
    Private Sub GridView2_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowCreated
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(0).Visible = False
            e.Row.Cells(10).Visible = False
            e.Row.Cells(11).Visible = False
            e.Row.Cells(5).Visible = False
        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(0).Visible = False
            e.Row.Cells(10).Visible = False
            e.Row.Cells(11).Visible = False
            e.Row.Cells(5).Visible = False
        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(0).Visible = False
            e.Row.Cells(10).Visible = False
            e.Row.Cells(11).Visible = False
            e.Row.Cells(5).Visible = False
        End If
    End Sub

    'Public Sub UpdateLeaveApproval(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim workfor As String
    '    workfor = ""
    '    Dim bal As Decimal
    '    bal = "0"
    '    Dim remain As Decimal
    '    remain = "0"
    '    Dim rc As Decimal
    '    rc = "0"
    '    Dim wf As Decimal
    '    wf = "0"
    '    For i As Integer = 0 To GridView2.Rows.Count - 1
    '        Dim passno As String = GridView2.Rows(i).Cells(0).Text
    '        Dim granted As String = DirectCast(GridView2.Rows(i).FindControl("txtgranted"), TextBox).Text
    '        Dim gfrom As String = DirectCast(GridView2.Rows(i).FindControl("txtgfrom"), TextBox).Text
    '        Dim gtill As String = DirectCast(GridView2.Rows(i).FindControl("txtgto"), TextBox).Text
    '        If Not GridView2.Rows(i).Cells(4).Text = "" Or GridView2.Rows(i).Cells(4).Text <> "&nbsp;" Then
    '            workfor = GridView2.Rows(i).Cells(4).Text
    '        End If
    '        Dim nocf As Decimal = GridView2.Rows(i).Cells(14).Text
    '        Dim ltype As String = GridView2.Rows(i).Cells(6).Text
    '        Dim status As String = DirectCast(GridView2.Rows(i).FindControl("rblvstatus"), RadioButtonList).SelectedValue
    '        Dim Cfwd As Char = GridView2.Rows(i).Cells(13).Text.Trim
    '        Dim typ As String
    '        If ltype = "Annual" Then
    '            typ = "AL"
    '        ElseIf ltype = "Calamity" Then
    '            typ = "CAL"
    '        ElseIf ltype = "CompanyHoliday" Then
    '            typ = "CH"
    '        ElseIf ltype = "Compassionate" Then
    '            typ = "CL"
    '        ElseIf ltype = "Marriage-Children" Then
    '            typ = "MAC"
    '        ElseIf ltype = "Maternity" Then
    '            typ = "ML"
    '        ElseIf ltype = "Paternity" Then
    '            typ = "PL"
    '        ElseIf ltype = "PlanEmergency" Then
    '            typ = "PEAL"
    '        ElseIf ltype = "PlanEmergencyUP" Then
    '            typ = "PLUP"
    '        ElseIf ltype = "Hospitalization" Then
    '            typ = "HL"
    '        ElseIf ltype = "marriage-self" Then
    '            typ = "MS"
    '        ElseIf ltype = "Emergency" Then
    '            typ = "AL"
    '        ElseIf ltype = "EmergencyUP" Then
    '            typ = "EUP"
    '        ElseIf ltype = "Unpaid" Then
    '            typ = "UP"
    '        ElseIf ltype = "Medical" Then
    '            typ = "MC"
    '        End If
    '        Dim curMth1 As Integer = Month(thisdate)
    '        Dim curyear1 As Integer = Year(thisdate)

    '        If status = "APPROVED" Then
    '            If gfrom <> "" Then
    '                Dim strdate() As String = gfrom.Split("/"c)
    '                gfrom = strdate(1) & "/" & strdate(0) & "/" & strdate(2)
    '            End If
    '            If gtill <> "" Then
    '                Dim strdate2() As String = gtill.Split("/"c)
    '                gtill = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)
    '            End If
    '            If Cfwd = "Y" Then
    '                If granted.Length > 0 Then
    '                    If granted > nocf Then
    '                        bal = granted - nocf
    '                        wf = bal
    '                    ElseIf granted <= nocf Then
    '                        bal = nocf - granted
    '                        wf = "0"
    '                        nocf = granted
    '                        GetCfwdLeave(_eid, curyear1)
    '                        If recstatus = True Then
    '                            Dim dr As DataRow
    '                            If dsdata.Tables(0).Rows.Count > 0 Then
    '                                dr = dsdata.Tables(0).Rows(0)
    '                                If dr("remain") Is System.DBNull.Value Then
    '                                    rc = 0
    '                                Else
    '                                    rc = dr("remain").ToString
    '                                End If
    '                            End If
    '                        End If
    '                        remain = bal + rc
    '                        UpdatecfwdLeave(_eid, Year(thisdate), remain)
    '                    End If ' for granted <= nocf
    '                Else ' for granted.Length > 0
    '                    granted = workfor + nocf
    '                    wf = workfor
    '                End If
    '                UpdateLVCApproval(passno, status, granted, gfrom, gtill, typ, wf, nocf)
    '            Else ' for not cfwd mth
    '                If granted.Length > 0 Then
    '                    workfor = granted
    '                    UpdateLVApproval(passno, status, granted, gfrom, gtill, typ, workfor)
    '                Else
    '                    granted = workfor
    '                    UpdateLVApproval(passno, status, granted, gfrom, gtill, typ, workfor)
    '                End If
    '            End If
    '        ElseIf status = "REJECTED" Then
    '            UpdateLVRApproval(passno, status)
    '            If Cfwd = "Y" Then
    '                GetCfwdLeave(_eid, curyear1)
    '                If recstatus = True Then
    '                    Dim dr As DataRow
    '                    If dsdata.Tables(0).Rows.Count > 0 Then
    '                        dr = dsdata.Tables(0).Rows(0)
    '                        If dr("remain") Is System.DBNull.Value Then
    '                            rc = 0
    '                        Else
    '                            rc = dr("remain").ToString
    '                        End If
    '                    End If
    '                End If
    '                remain = nocf + rc
    '                UpdatecfwdLeave(_eid, Year(thisdate), remain)
    '            End If
    '        End If
    '    Next
    '    GridView2.DataBind()
    'End Sub
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
            Dim granted As String
            ' = DirectCast(GridView2.Rows(i).FindControl("txtgranted"), TextBox).Text
            'Dim gfrom As String = DirectCast(GridView2.Rows(i).FindControl("txtgfrom"), TextBox).Text
            'Dim gtill As String = DirectCast(GridView2.Rows(i).FindControl("txtgto"), TextBox).Text
            If Not GridView2.Rows(i).Cells(5).Text <> "" Or GridView2.Rows(i).Cells(5).Text <> "&nbsp;" Then
                workfor = GridView2.Rows(i).Cells(5).Text
            Else
                workfor = "0"
            End If
            Dim remarks As String = DirectCast(GridView2.Rows(i).FindControl("txtremark"), TextBox).Text

            Dim nocf As Decimal = GridView2.Rows(i).Cells(11).Text
            Dim ltype As String = GridView2.Rows(i).Cells(7).Text
            Dim status As String = DirectCast(GridView2.Rows(i).FindControl("rblvstatus"), RadioButtonList).SelectedValue
            Dim Cfwd As Char = GridView2.Rows(i).Cells(10).Text.Trim
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
                'If gfrom <> "" Then
                '    Dim strdate() As String = gfrom.Split("/"c)
                '    gfrom = strdate(1) & "/" & strdate(0) & "/" & strdate(2)
                'End If
                'If gtill <> "" Then
                '    Dim strdate2() As String = gtill.Split("/"c)
                '    gtill = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)
                'End If
                If Cfwd = "Y" Then
                    'If granted.Length > 0 Then
                    '    If granted > nocf Then
                    '        bal = granted - nocf
                    '        wf = bal
                    '    ElseIf granted <= nocf Then
                    '        bal = nocf - granted
                    '        wf = "0"
                    '        nocf = granted
                    '        GetCfwdLeave(_eid, curyear1)
                    '        If recstatus = True Then
                    '            Dim dr As DataRow
                    '            If dsdata.Tables(0).Rows.Count > 0 Then
                    '                dr = dsdata.Tables(0).Rows(0)
                    '                If dr("remain") Is System.DBNull.Value Then
                    '                    rc = 0
                    '                Else
                    '                    rc = dr("remain").ToString
                    '                End If
                    '            End If
                    '        End If
                    '        remain = bal + rc
                    '        UpdatecfwdLeave(_eid, Year(thisdate), remain)
                    '    End If ' for granted <= nocf
                    'Else ' for granted.Length > 0
                    granted = workfor + nocf
                    wf = workfor
                    ' End If
                    UpdateLVCApproval(passno, status, granted, typ, wf, nocf, remarks, Session("empcode"))
                Else ' for not cfwd mth
                    'If granted.Length > 0 Then
                    '    workfor = granted
                    '    UpdateLVApproval(passno, status, granted, gfrom, gtill, typ, workfor)
                    'Else
                    granted = workfor
                    UpdateLVApproval(passno, status, granted, typ, workfor, remarks, Session("empcode"))
                    ' End If
                End If
            ElseIf status = "REJECTED" Then
                UpdateLVRApproval(passno, status, remarks, Session("empcode"))
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
                    Else
                        lblmsg.Text = myerrormsg
                        lblmsg.ForeColor = Drawing.Color.Red
                    End If
                    remain = nocf + rc
                    UpdatecfwdLeave(_eid, Year(thisdate), remain)
                End If
            End If
        Next
        GetHeadDept()
        GridView2.DataBind()
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
        Else
            lblmsg.Text = MyerrorMsg
            lblmsg.ForeColor = Drawing.Color.Red

        End If
        BindGridGpHistory(empid)
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
        Else
            lblmsg.Text = myerrormsg
            lblmsg.ForeColor = Drawing.Color.Red
        End If
    End Sub

    Private Sub Grdlvhistory_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles Grdlvhistory.PageIndexChanging
        BindGridGpHistory(Session("emp"))
        Grdlvhistory.PageIndex = e.NewPageIndex
        Grdlvhistory.DataBind()
        pnlapproval.Visible = True
        Pnlhistory.Visible = True
        leavempe.Show()

    End Sub
    Public Sub leavecalculation2(ByVal empid As String)
        GetEmpVehino(empid)
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
        Else
            lblmsg.Text = myerrormsg
            lblmsg.ForeColor = Drawing.Color.Red
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
        Else
            lblmsg.Text = myerrormsg
            lblmsg.ForeColor = Drawing.Color.Red
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
        Else
            lblmsg.Text = myerrormsg
            lblmsg.ForeColor = Drawing.Color.Red

        End If

        balMleave = med - mLeavetaken
        balAleave = ann - leavetaken

        Session("myannual") = ann
        Session("myannbal") = balAleave
        Session("mymedical") = med
        Session("mymedbal") = balMleave



        'lbltxtempid.Text = empID
    End Sub

    ''' <summary>
    ''' FOR EA/GM/MD APPROVAL
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Private Sub BindGrid()
      

        MyGlobal.Con_Str()

        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()

        Dim Command As New SqlCommand
        Command = New SqlCommand("LeaveApproval", con)
        Command.CommandType = CommandType.StoredProcedure
        'If Session("empcode") = "014623" Then
        '    Command.Parameters.AddWithValue("@stat", "DGM")
        'ElseIf Session("empcode") = "014191" Then
        '    Command.Parameters.AddWithValue("@stat", "SSGM")
        'Else
        Command.Parameters.AddWithValue("@stat", Session("dcode"))
        'End If


        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "HOdLEave")

        GRidEAGM.DataSource = ds
        GRidEAGM.DataBind()
        GRidEAGM.Visible = True
        PGRidEAGM.Visible = True

        con.Close()
    End Sub

    Private Sub GRidEAGM_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GRidEAGM.PageIndexChanging
        BindGrid()

        GRidEAGM.PageIndex = e.NewPageIndex
        GRidEAGM.DataBind()

        PGRidEAGM.Visible = True
        GRidEAGM.Visible = True

        GridView2.Visible = False
        PGridView2.Visible = False

    End Sub

    Public Sub UpdateLeaveApproval2(ByVal sender As Object, ByVal e As EventArgs)
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
        For i As Integer = 0 To GRidEAGM.Rows.Count - 1
            Dim passno As String = GRidEAGM.Rows(i).Cells(0).Text
            Dim granted As String
            ' = DirectCast(GRidEAGM.Rows(i).FindControl("txtgranted"), TextBox).Text
            'Dim gfrom As String = DirectCast(GRidEAGM.Rows(i).FindControl("txtgfrom"), TextBox).Text
            'Dim gtill As String = DirectCast(GRidEAGM.Rows(i).FindControl("txtgto"), TextBox).Text
            If Not GRidEAGM.Rows(i).Cells(4).Text <> "" Or GRidEAGM.Rows(i).Cells(5).Text <> "&nbsp;" Then
                workfor = GRidEAGM.Rows(i).Cells(5).Text
            Else
                workfor = "0"
            End If
            Dim remarks As String = DirectCast(GRidEAGM.Rows(i).FindControl("txtremark"), TextBox).Text

            Dim nocf As Decimal = GRidEAGM.Rows(i).Cells(11).Text
            Dim ltype As String = GRidEAGM.Rows(i).Cells(7).Text
            Dim status As String = DirectCast(GRidEAGM.Rows(i).FindControl("rblvstatus"), RadioButtonList).SelectedValue
            Dim Cfwd As Char = GRidEAGM.Rows(i).Cells(10).Text.Trim
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
                'If gfrom <> "" Then
                '    Dim strdate() As String = gfrom.Split("/"c)
                '    gfrom = strdate(1) & "/" & strdate(0) & "/" & strdate(2)
                'End If
                'If gtill <> "" Then
                '    Dim strdate2() As String = gtill.Split("/"c)
                '    gtill = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)
                'End If
                If Cfwd = "Y" Then
                    'If granted.Length > 0 Then
                    '    If granted > nocf Then
                    '        bal = granted - nocf
                    '        wf = bal
                    '    ElseIf granted <= nocf Then
                    '        bal = nocf - granted
                    '        wf = "0"
                    '        nocf = granted
                    '        GetCfwdLeave(_eid, curyear1)
                    '        If recstatus = True Then
                    '            Dim dr As DataRow
                    '            If dsdata.Tables(0).Rows.Count > 0 Then
                    '                dr = dsdata.Tables(0).Rows(0)
                    '                If dr("remain") Is System.DBNull.Value Then
                    '                    rc = 0
                    '                Else
                    '                    rc = dr("remain").ToString
                    '                End If
                    '            End If
                    '        End If
                    '        remain = bal + rc
                    '        UpdatecfwdLeave(_eid, Year(thisdate), remain)
                    '    End If ' for granted <= nocf
                    'Else ' for granted.Length > 0
                    granted = workfor + nocf
                    wf = workfor
                    ' End If
                    UpdateLVCApproval(passno, status, granted, typ, wf, nocf, remarks, Session("empcode"))
                Else ' for not cfwd mth
                    'If granted.Length > 0 Then
                    '    workfor = granted
                    '    UpdateLVApproval(passno, status, granted, gfrom, gtill, typ, workfor)
                    'Else
                    granted = workfor
                    UpdateLVApproval(passno, status, granted, typ, workfor, remarks, Session("empcode"))
                    ' End If
                End If
            ElseIf status = "REJECTED" Then
                UpdateLVRApproval(passno, status, remarks, Session("empcode"))
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
                    Else
                        lblmsg.Text = myerrormsg
                        lblmsg.ForeColor = Drawing.Color.Red
                    End If
                    remain = nocf + rc
                    UpdatecfwdLeave(_eid, Year(thisdate), remain)
                End If
            End If
        Next
        BindGrid()
        GRidEAGM.DataBind()
    End Sub

    Private Sub GRidEAGM_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GRidEAGM.RowCreated

        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(0).Visible = False
            e.Row.Cells(11).Visible = False
            e.Row.Cells(10).Visible = False
            e.Row.Cells(5).Visible = False
        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(0).Visible = False
            e.Row.Cells(11).Visible = False
            e.Row.Cells(10).Visible = False
            e.Row.Cells(5).Visible = False
        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(0).Visible = False
            e.Row.Cells(11).Visible = False
            e.Row.Cells(10).Visible = False
            e.Row.Cells(5).Visible = False
        End If

    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub searchgrid2(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        Dim str
        str = txtsearch2.Text.Trim
        If str <> "" Then
            For n As Integer = 0 To GridView2.Rows.Count - 1
                Dim lbn As String = DirectCast(GridView2.Rows(n).FindControl("linkbutton2"), LinkButton).Text
                Dim empname As String = GridView2.Rows(n).Cells(2).Text
                If lbn.ToString.ToLower.Contains(str.ToString.ToLower) = True Or empname.ToString.ToLower.Contains(str.ToString.ToLower) = True Then
                    GridView2.Rows(n).Focus()
                    GridView2.Rows(n).BackColor = Drawing.Color.Orange
                Else
                    GridView2.Rows(n).BackColor = Drawing.Color.White
                End If
            Next
        End If
    End Sub

    Protected Sub searchgridapp(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        Dim str
        str = Txtsearchapp.Text.Trim
        If str <> "" Then
            For n As Integer = 0 To GRidEAGM.Rows.Count - 1
                Dim lbn As String = DirectCast(GRidEAGM.Rows(n).FindControl("linkbutton2"), LinkButton).Text
                Dim empname As String = GRidEAGM.Rows(n).Cells(2).Text
                If lbn.ToString.ToLower.Contains(str.ToString.ToLower) = True Or empname.ToString.ToLower.Contains(str.ToString.ToLower) = True Then
                    GRidEAGM.Rows(n).Focus()
                    GRidEAGM.Rows(n).BackColor = Drawing.Color.Orange
                Else
                    GRidEAGM.Rows(n).BackColor = Drawing.Color.White
                End If
            Next
        End If
    End Sub
End Class