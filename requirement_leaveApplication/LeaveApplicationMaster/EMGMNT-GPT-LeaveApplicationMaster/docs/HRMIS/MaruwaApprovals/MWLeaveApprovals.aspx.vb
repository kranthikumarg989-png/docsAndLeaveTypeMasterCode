Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class MWLeaveApprovals
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim doj As Date
    Dim thisdate As Date
    Dim cancfwd As String
    Dim appno As String
    Protected comp As String

    Dim ds1 As New DataSet
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        thisdate = DateTime.Now
        MyApp.GetfiscalYear()
        ''Session("empcode") = "014543"
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (307)
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
        Con.Close()
        ''''' ******* MARUWA MALAYSIA CODING
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        Getempdetails("MMSB")
        Dim dr1 As DataRow
        If ds1.Tables(0).Rows.Count > 0 Then
            dr1 = ds1.Tables(0).Rows(0)
            Session("Udesig") = dr1("designation").ToString
            Session("Udept") = dr1("departmentcode").ToString
            getdesigname(Session("Udesig"))
            Dim dcode
            If recstatus = True Then
                Dim dr As DataRow
                If dsdata.Tables(0).Rows.Count > 0 Then
                    dr = dsdata.Tables(0).Rows(0)
                    dcode = dr("desigcode").ToString.Trim
                    Session("dcode") = dcode
                End If
            End If
            If Not IsPostBack Then
                If dcode = "EA" Or dcode = "MD" Or dcode = "GM" Or dcode = "DGM" Or dcode = "PL Man" Then
                    BindGrid("MMSB")
                Else
                    GetHeadDept("MMSB")
                End If
            End If
            GRidEAGM.Visible = True
        Else
            GRidEAGM.Visible = False
        End If
        Con.Close()
        ds1.Clear()
        ''''' ******* MARUWA MELAKA CODING
        MyGlobal.Open_Con_mel()
        MyGlobal.Con_Str()
        Getempdetails("MEL")
        If ds1.Tables(0).Rows.Count > 0 Then
            dr1 = ds1.Tables(0).Rows(0)
            Session("Udesig") = dr1("designation").ToString
            Session("Udept") = dr1("departmentcode").ToString
            '''
            getdesigname(Session("Udesig"))
            Dim dcodeMEL
            If recstatus = True Then
                Dim dr As DataRow
                If dsdata.Tables(0).Rows.Count > 0 Then
                    dr = dsdata.Tables(0).Rows(0)
                    dcodeMEL = dr("desigcode").ToString.Trim
                    Session("dcodeMEL") = dcodeMEL
                End If
            End If
            If Not IsPostBack Then
                If dcodeMEL = "EA" Or dcodeMEL = "MD" Or dcodeMEL = "GM" Or dcodeMEL = "DGM" Or dcodeMEL = "PL Man" Then
                    BindGrid("MEL")
                Else
                    GetHeadDept("MEL")
                End If
            End If
            GridMEL.Visible = True
        Else
            GridMEL.Visible = False
        End If
        Con.Close()
        ds1.Clear()
        ''''' ******* MARUWA LIGHTING CODING
        MyGlobal.Open_Con_lit()
        MyGlobal.Con_Str()
        Getempdetails("MLG")
        If ds1.Tables(0).Rows.Count > 0 Then
            dr1 = ds1.Tables(0).Rows(0)
            Session("Udesig") = dr1("designation").ToString
            Session("Udept") = dr1("departmentcode").ToString
            ''
            getdesigname(Session("Udesig"))
            Dim dcodelig
            If recstatus = True Then
                Dim dr As DataRow
                If dsdata.Tables(0).Rows.Count > 0 Then
                    dr = dsdata.Tables(0).Rows(0)
                    dcodelig = dr("desigcode").ToString.Trim
                    Session("dcodeLIG") = dcodelig
                End If
            End If
            If Not IsPostBack Then
                If dcodelig = "EA" Or dcodelig = "MD" Or dcodelig = "GM" Or dcodelig = "DGM" Or dcodelig = "PL Man" Then
                    BindGrid("MLG")
                Else
                    GetHeadDept("MLG")
                End If
            End If
            GridLig.Visible = True
        Else
            GridLig.Visible = False
        End If

        Con.Close()
        ds1.Clear()

        ''''' ******* MARUWA OUTSOURCE CODING

        MyGlobal.Open_Con_out()
        MyGlobal.Con_Str()

        Getempdetails("MOU")

        If ds1.Tables(0).Rows.Count > 0 Then
            dr1 = ds1.Tables(0).Rows(0)
            Session("Udesig") = dr1("designation").ToString
            Session("Udept") = dr1("departmentcode").ToString
            ''
            getdesigname(Session("Udesig"))
            Dim dcodeOS
            If recstatus = True Then
                Dim dr As DataRow
                If dsdata.Tables(0).Rows.Count > 0 Then
                    dr = dsdata.Tables(0).Rows(0)
                    dcodeOS = dr("desigcode").ToString.Trim
                    Session("dcodeOS") = dcodeOS
                End If
            End If

            If Not IsPostBack Then
                If dcodeOS = "EA" Or dcodeOS = "MD" Or dcodeOS = "GM" Or dcodeOS = "DGM" Or dcodeOS = "PL Man" Then
                    BindGrid("MOU")
                Else
                    GetHeadDept("MOU")
                End If
            End If
            GridOS.Visible = True
        Else
            GridOS.Visible = False
        End If
        Con.Close()
    End Sub
    ''' MARUWA MALAYSIA CODING STARTS HERE ''''
    ''' <summary>
    ''' FOR HOD approval
    Private Sub GetHeadDept(ByVal comp As String)
        Dim dsh As DataSet
        Dim drh As DataRow
        Dim headdept, mydept
        dsh = GetHeadAssignment(comp)
        If dsh.Tables(0).Rows.Count > 0 Then
            drh = dsh.Tables(0).Rows(0)
            mydept = drh("ldepartmentcode").ToString
            Dim hoddepts = mydept.split(",")
            For i As Integer = 0 To hoddepts.Length - 1
                headdept = headdept & "'" & hoddepts(i) & "',"
            Next
            headdept = headdept.remove(headdept.length - 1, 1)
        Else
            headdept = "'" & Session("Udept") & "'"
        End If
        BindGridhod(headdept, comp)
    End Sub
    Function GetHeadAssignment(ByVal comp As String) As DataSet
        Dim conn
        Dim con
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        If comp = "MMSB" Then
            con = New SqlConnection(constr)
        ElseIf comp = "MEL" Then
            con = New SqlConnection(con_mel)
        ElseIf comp = "MLG" Then
            con = New SqlConnection(con_lig)
        ElseIf comp = "MOU" Then
            con = New SqlConnection(con_os)
        End If
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from head_assignment_emanagement where empcode ='" & Session("empcode") & "'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "KPIMajor")
        con.Close()
        Return ds
    End Function
    Private Sub BindGridhod(ByVal dept As String, ByVal comp As String)
        Dim conn
        Dim con
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        If comp = "MMSB" Then
            con = New SqlConnection(constr)
        ElseIf comp = "MEL" Then
            con = New SqlConnection(con_mel)
        ElseIf comp = "MLG" Then
            con = New SqlConnection(con_lig)
        ElseIf comp = "MOU" Then
            con = New SqlConnection(con_os)
        End If
        con.Open()
        Dim Command As New SqlCommand
        ' Command = New SqlCommand("SELECT kpi_grade_result.empcode ,  kpi_grade_result.slno , kpi_grade_result.yr , kpi_grade_result.mnth,kpi_grade_result.grade,ltrim(rtrim(kpi_grade_result.total)) as total,kpi_grade_result.status, empmaster.departmentcode, empmaster.sectioncode, empmaster.empname, empmaster.designation, empmaster.resigned, empmaster.IsOperator FROM kpi_grade_result INNER JOIN empmaster ON kpi_grade_result.empcode = empmaster.empcode WHERE (kpi_grade_result.yr = '" & ddlyr.SelectedValue & "') AND (kpi_grade_result.mnth = '" & ddlmon.SelectedValue & "') AND (empmaster.departmentcode in (" & dept & ") ) AND (empmaster.resigned = 'N') AND (empmaster.IsOperator <> 'Y') and status = 'Scheduled'", con)
        Command = New SqlCommand("SELECt  *,(Ltrim(rtrim(status))) as stat,* FROM Leaveform AS Leaveform INNER JOIN empmaster AS Empmaster  ON Empmaster.empcode = Leaveform.empno inner join designation as designation on empmaster.designation = designation.designationname  WHERE ((Leaveform.status = 'SCHEDULED'))  and (dlevel < '4')  AND (leaveform.department in (" & dept & ")) AND (Leaveform.empno <> '005000') and (Leaveform.empno <> '" & Session("empcode") & "') and (leaveform.backdate='N') AND ((Leaveform.leavetype = 'Annual') or (Leaveform.leavetype = 'Emergency') or (Leaveform.leavetype = 'EmergencyUP') or (Leaveform.leavetype = 'EmergencyUnpaid') or (Leaveform.leavetype = 'PlanEmergencyUP')or (Leaveform.leavetype = 'PlanEmergency') or (leaveform.leavetype = 'Unpaid')) ORDER BY Leaveform.appno DESC ", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "LVApprovalHod")
        If comp = "MEL" Then
            GridMEL.DataSource = ds
            GridMEL.DataBind()
        ElseIf comp = "MLG" Then
            GridLig.DataSource = ds
            GridLig.DataBind()
        ElseIf comp = "MOU" Then
            GridOS.DataSource = ds
            GridOS.DataBind()
        ElseIf comp = "MMSB" Then
            GRidEAGM.DataSource = ds
            GRidEAGM.DataBind()
        End If
        con.Close()
    End Sub
    ''' <summary>
    ''' FOR EA/GM/MD APPROVAL
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub BindGrid(ByVal comp As String)

        Dim conn
        Dim con
        Dim ddcode
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        If comp = "MMSB" Then
            con = New SqlConnection(constr)
            ddcode = Session("dcode")
        ElseIf comp = "MEL" Then
            con = New SqlConnection(con_mel)
            ddcode = Session("dcodeMel")
        ElseIf comp = "MLG" Then
            con = New SqlConnection(con_lig)
            ddcode = Session("dcodelig")
        ElseIf comp = "MOU" Then
            con = New SqlConnection(con_os)
            ddcode = Session("dcodeos")
        End If
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("LeaveApproval", con)
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.AddWithValue("@stat", ddcode)
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "HOdLEave")
        If comp = "MEL" Then
            GridMEL.DataSource = ds
            GridMEL.DataBind()
        ElseIf comp = "MLG" Then
            GridLig.DataSource = ds
            GridLig.DataBind()
        ElseIf comp = "MOU" Then
            GridOS.DataSource = ds
            GridOS.DataBind()
        ElseIf comp = "MMSB" Then
            GRidEAGM.DataSource = ds
            GRidEAGM.DataBind()
        End If
        con.Close()
    End Sub
    Function Getempdetails(ByVal comp As String) As DataSet
        Dim conn
        Dim con
        MyGlobal.Con_Str()

        If comp = "MMSB" Then
            con = New SqlConnection(constr)
        ElseIf comp = "MEL" Then
            con = New SqlConnection(con_mel)
        ElseIf comp = "MLG" Then
            con = New SqlConnection(con_lig)
        ElseIf comp = "MOU" Then
            con = New SqlConnection(con_os)
        End If
        Con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from empmaster where empcode ='" & Session("empcode") & "' and resigned = 'N'", Con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds1, "emp")
        Con.Close()
        Return ds1

    End Function
    Private Sub GRidEAGM_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GRidEAGM.PageIndexChanging
        If Session("dcode") = "EA" Or Session("dcode") = "MD" Or Session("dcode") = "GM" Or Session("dcode") = "DGM" Or Session("dcode") = "PL Man" Then
            BindGrid("MMSB")
        Else
            GetHeadDept("MMSB")
        End If
        GRidEAGM.PageIndex = e.NewPageIndex
        GRidEAGM.DataBind()
    End Sub

    Private Sub GridMEL_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridMEL.PageIndexChanging
        If Session("dcodemel") = "EA" Or Session("dcodemel") = "MD" Or Session("dcodemel") = "GM" Or Session("dcodemel") = "DGM" Or Session("dcodemel") = "PL Man" Then
            BindGrid("MEL")
        Else
            GetHeadDept("MEL")
        End If
        GridMEL.PageIndex = e.NewPageIndex
        GridMEL.DataBind()
    End Sub

    Private Sub GridLig_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridLig.PageIndexChanging
        If Session("dcodeLIG") = "EA" Or Session("dcodeLIG") = "MD" Or Session("dcodeLIG") = "GM" Or Session("dcodeLIG") = "DGM" Or Session("dcodeLIG") = "PL Man" Then
            BindGrid("MLG")
        Else
            GetHeadDept("MLG")
        End If
        GridLig.PageIndex = e.NewPageIndex
        GridLig.DataBind()
    End Sub

    Private Sub GridOS_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridOS.PageIndexChanging
        If Session("dcodeOS") = "EA" Or Session("dcodeOS") = "MD" Or Session("dcodeOS") = "GM" Or Session("dcodeOS") = "DGM" Or Session("dcodeOS") = "PL Man" Then
            BindGrid("MOU")
        Else
            GetHeadDept("MOU")
        End If
        GridOS.PageIndex = e.NewPageIndex
        GridOS.DataBind()
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
                If Cfwd = "Y" Then
                    granted = workfor + nocf
                    wf = workfor
                    UpdateLVCApproval(passno, status, granted, typ, wf, nocf, remarks, Session("empcode"))
                Else ' for not cfwd mth
                    granted = workfor
                    UpdateLVApproval(passno, status, granted, typ, workfor, remarks, Session("empcode"))

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
                    End If
                    remain = nocf + rc
                    UpdatecfwdLeave(_eid, Year(thisdate), remain)
                End If
            End If
        Next
        If Session("dcode") = "EA" Or Session("dcode") = "MD" Or Session("dcode") = "GM" Or Session("dcode") = "DGM" Or Session("dcode") = "PL Man" Then
            BindGrid("MMSB")
        Else
            GetHeadDept("MMSB")
        End If
        GRidEAGM.DataBind()
    End Sub

    Public Sub UpdateLeaveApprovalMelaka(ByVal sender As Object, ByVal e As EventArgs)
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

        For i As Integer = 0 To GridMEL.Rows.Count - 1
            Dim passno As String = GridMEL.Rows(i).Cells(0).Text
            Dim granted As String
            If Not GridMEL.Rows(i).Cells(4).Text <> "" Or GridMEL.Rows(i).Cells(5).Text <> "&nbsp;" Then
                workfor = GridMEL.Rows(i).Cells(5).Text
            Else
                workfor = "0"
            End If
            Dim remarks As String = DirectCast(GridMEL.Rows(i).FindControl("txtremark"), TextBox).Text

            Dim nocf As Decimal = GridMEL.Rows(i).Cells(11).Text
            Dim ltype As String = GridMEL.Rows(i).Cells(7).Text
            Dim status As String = DirectCast(GridMEL.Rows(i).FindControl("rblvstatus"), RadioButtonList).SelectedValue
            Dim Cfwd As Char = GridMEL.Rows(i).Cells(10).Text.Trim
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
                If Cfwd = "Y" Then
                    granted = workfor + nocf
                    wf = workfor
                    UpdateLVCApprovalMel(passno, status, granted, typ, wf, nocf, remarks, Session("empcode"))
                Else ' for not cfwd mth
                    granted = workfor
                    UpdateLVApprovalMel(passno, status, granted, typ, workfor, remarks, Session("empcode"))

                End If
            ElseIf status = "REJECTED" Then
                UpdateLVRApprovalMel(passno, status, remarks, Session("empcode"))
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
                    UpdatecfwdLeaveMel(_eid, Year(thisdate), remain)
                End If
            End If
        Next
        If Session("dcodemel") = "EA" Or Session("dcodemel") = "MD" Or Session("dcodemel") = "GM" Or Session("dcodemel") = "DGM" Or Session("dcodemel") = "PL Man" Then
            BindGrid("MEL")
        Else
            GetHeadDept("MEL")
        End If
        GridMEL.DataBind()
    End Sub

    Public Sub UpdateLeaveApprovalLIG(ByVal sender As Object, ByVal e As EventArgs)
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

        For i As Integer = 0 To GridLig.Rows.Count - 1
            Dim passno As String = GridLig.Rows(i).Cells(0).Text
            Dim granted As String
            If Not GridLig.Rows(i).Cells(4).Text <> "" Or GridLig.Rows(i).Cells(5).Text <> "&nbsp;" Then
                workfor = GridLig.Rows(i).Cells(5).Text
            Else
                workfor = "0"
            End If
            Dim remarks As String = DirectCast(GridLig.Rows(i).FindControl("txtremark"), TextBox).Text

            Dim nocf As Decimal = GridLig.Rows(i).Cells(11).Text
            Dim ltype As String = GridLig.Rows(i).Cells(7).Text
            Dim status As String = DirectCast(GridLig.Rows(i).FindControl("rblvstatus"), RadioButtonList).SelectedValue
            Dim Cfwd As Char = GridLig.Rows(i).Cells(10).Text.Trim
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
                If Cfwd = "Y" Then
                    granted = workfor + nocf
                    wf = workfor
                    UpdateLVCApprovallig(passno, status, granted, typ, wf, nocf, remarks, Session("empcode"))
                Else ' for not cfwd mth
                    granted = workfor
                    UpdateLVApprovallig(passno, status, granted, typ, workfor, remarks, Session("empcode"))

                End If
            ElseIf status = "REJECTED" Then
                UpdateLVRApprovallig(passno, status, remarks, Session("empcode"))
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
                    UpdatecfwdLeavelig(_eid, Year(thisdate), remain)
                End If
            End If
        Next
        If Session("dcodeLIG") = "EA" Or Session("dcodeLIG") = "MD" Or Session("dcodeLIG") = "GM" Or Session("dcodeLIG") = "DGM" Or Session("dcodeLIG") = "PL Man" Then
            BindGrid("MLG")
        Else
            GetHeadDept("MLG")
        End If
        GridLig.DataBind()
    End Sub
    Public Sub UpdateLeaveApprovalOS(ByVal sender As Object, ByVal e As EventArgs)
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

        For i As Integer = 0 To GridOS.Rows.Count - 1
            Dim passno As String = GridOS.Rows(i).Cells(0).Text
            Dim granted As String
            If Not GridOS.Rows(i).Cells(4).Text <> "" Or GridOS.Rows(i).Cells(5).Text <> "&nbsp;" Then
                workfor = GridOS.Rows(i).Cells(5).Text
            Else
                workfor = "0"
            End If
            Dim remarks As String = DirectCast(GridOS.Rows(i).FindControl("txtremark"), TextBox).Text

            Dim nocf As Decimal = GridOS.Rows(i).Cells(11).Text
            Dim ltype As String = GridOS.Rows(i).Cells(7).Text
            Dim status As String = DirectCast(GridOS.Rows(i).FindControl("rblvstatus"), RadioButtonList).SelectedValue
            Dim Cfwd As Char = GridOS.Rows(i).Cells(10).Text.Trim
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
                If Cfwd = "Y" Then
                    granted = workfor + nocf
                    wf = workfor
                    UpdateLVCApprovalos(passno, status, granted, typ, wf, nocf, remarks, Session("empcode"))
                Else ' for not cfwd mth
                    granted = workfor
                    UpdateLVApprovalos(passno, status, granted, typ, workfor, remarks, Session("empcode"))

                End If
            ElseIf status = "REJECTED" Then
                UpdateLVRApprovalos(passno, status, remarks, Session("empcode"))
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
                    UpdatecfwdLeaveos(_eid, Year(thisdate), remain)
                End If
            End If
        Next
        If Session("dcodeOS") = "EA" Or Session("dcodeOS") = "MD" Or Session("dcodeOS") = "GM" Or Session("dcodeOS") = "DGM" Or Session("dcodeOS") = "PL Man" Then
            BindGrid("MOU")
        Else
            GetHeadDept("MOU")
        End If
        GridOS.DataBind()
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
    Private Sub GridLig_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridLig.RowCreated
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

    Private Sub GridMEL_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridMEL.RowCreated
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

    Private Sub GridOS_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridOS.RowCreated
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

    Protected Sub searchgridapp(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click, ImageButton2.Click
        Dim str
        str = Txtsearchapp.Text.Trim
        If str <> "" Then
            For n As Integer = 0 To GRidEAGM.Rows.Count - 1
                Dim lbn As String = GRidEAGM.Rows(n).Cells(1).Text
                Dim empname As String = GRidEAGM.Rows(n).Cells(2).Text
                If lbn.ToString.ToLower.Contains(str.ToString.ToLower) = True Or empname.ToString.ToLower.Contains(str.ToString.ToLower) = True Then
                    GRidEAGM.Rows(n).Focus()
                    GRidEAGM.Rows(n).BackColor = Drawing.Color.Orange
                Else
                    GRidEAGM.Rows(n).BackColor = Drawing.Color.White
                End If
            Next
            For n As Integer = 0 To GridMEL.Rows.Count - 1
                Dim lbn As String = GridMEL.Rows(n).Cells(1).Text
                Dim empname As String = GridMEL.Rows(n).Cells(2).Text
                If lbn.ToString.ToLower.Contains(str.ToString.ToLower) = True Or empname.ToString.ToLower.Contains(str.ToString.ToLower) = True Then
                    GridMEL.Rows(n).Focus()
                    GridMEL.Rows(n).BackColor = Drawing.Color.Orange
                Else
                    GridMEL.Rows(n).BackColor = Drawing.Color.White
                End If
            Next

            For n As Integer = 0 To GridLig.Rows.Count - 1
                Dim lbn As String = GridLig.Rows(n).Cells(1).Text
                Dim empname As String = GridLig.Rows(n).Cells(2).Text
                If lbn.ToString.ToLower.Contains(str.ToString.ToLower) = True Or empname.ToString.ToLower.Contains(str.ToString.ToLower) = True Then
                    GridLig.Rows(n).Focus()
                    GridLig.Rows(n).BackColor = Drawing.Color.Orange
                Else
                    GridLig.Rows(n).BackColor = Drawing.Color.White
                End If
            Next

            For n As Integer = 0 To GridOS.Rows.Count - 1
                Dim lbn As String = GridOS.Rows(n).Cells(1).Text
                Dim empname As String = GridOS.Rows(n).Cells(2).Text
                If lbn.ToString.ToLower.Contains(str.ToString.ToLower) = True Or empname.ToString.ToLower.Contains(str.ToString.ToLower) = True Then
                    GridOS.Rows(n).Focus()
                    GridOS.Rows(n).BackColor = Drawing.Color.Orange
                Else
                    GridOS.Rows(n).BackColor = Drawing.Color.White
                End If
            Next
        End If
    End Sub

    Protected Sub GRidEAGM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GRidEAGM.SelectedIndexChanged

    End Sub

    Protected Sub rbOption_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbOption.SelectedIndexChanged
        If rbOption.SelectedValue = "HA" Then
            PNLMMSB.Visible = True
            PNLMEL.Visible = False
            PNLLIG.Visible = False
            PNLOS.Visible = False
        ElseIf rbOption.SelectedValue = "LA" Then
            PNLMMSB.Visible = False
            PNLMEL.Visible = False
            PNLLIG.Visible = True
            PNLOS.Visible = False
        ElseIf rbOption.SelectedValue = "OA" Then
            PNLMMSB.Visible = False
            PNLMEL.Visible = False
            PNLLIG.Visible = False
            PNLOS.Visible = True
        ElseIf rbOption.SelectedValue = "MA" Then
            PNLMMSB.Visible = False
            PNLMEL.Visible = True
            PNLLIG.Visible = False
            PNLOS.Visible = False
        Else
            PNLMMSB.Visible = True
            PNLMEL.Visible = True
            PNLLIG.Visible = True
            PNLOS.Visible = True
        End If
    End Sub
End Class