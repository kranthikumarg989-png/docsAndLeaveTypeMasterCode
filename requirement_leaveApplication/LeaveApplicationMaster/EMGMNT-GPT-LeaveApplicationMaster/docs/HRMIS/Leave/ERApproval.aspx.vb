Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class ERApproval
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

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (36)
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

        Pnlhistory.Visible = False

        If Not IsPostBack Then
            GrdERapproval.DataBind()
        End If

    End Sub
    Protected Sub SqlERApproval_Selecting(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlERApproval.Selecting
        e.Command.Parameters(0).Value = Session("empcode")
    End Sub

    Private Sub GrdERapproval_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrdERapproval.RowCreated
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(0).Visible = False
            e.Row.Cells(12).Visible = False
            e.Row.Cells(11).Visible = False
            e.Row.Cells(4).Visible = False
        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(0).Visible = False
            e.Row.Cells(12).Visible = False
            e.Row.Cells(11).Visible = False
            e.Row.Cells(4).Visible = False
        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(0).Visible = False
            e.Row.Cells(12).Visible = False
            e.Row.Cells(11).Visible = False
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
            'If Not GrdERapproval.Rows(i).Cells(5).Text = "" Or GrdERapproval.Rows(i).Cells(5).Text <> "" Then
            '    workfor = GrdERapproval.Rows(i).Cells(5).Text
            'End If
            Dim nocf As Decimal = GrdERapproval.Rows(i).Cells(12).Text
            Dim ltype As String = GrdERapproval.Rows(i).Cells(7).Text
            Dim status As String = DirectCast(GrdERapproval.Rows(i).FindControl("rblvestatus"), RadioButtonList).SelectedValue
            Dim Cfwd As Char = GrdERapproval.Rows(i).Cells(11).Text.Trim
            Dim bd As Char = GrdERapproval.Rows(i).Cells(13).Text.Trim
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
                UpdateLVERApproval(passno, status, typ, Session("empcode"))
            ElseIf status = "REJECTED" Then
                UpdateLVRERApproval(passno, status, sreason, Session("empcode"))
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
        GrdERapproval.DataBind()
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
            lblmsg.Text = myerrormsg
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
            lblmsg.Text = myerrormsg
            lblmsg.ForeColor = Drawing.Color.Red
        End If
        BindGridGpHistory(empid)
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
        Pnlhistory.Visible = True
        leavempe.Show()
    End Sub

    Protected Sub searchgrid2(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click

        Dim str
        str = txtsearchapp.Text.Trim
        If str <> "" Then
            For n As Integer = 0 To GrdERapproval.Rows.Count - 1
                Dim lbn As String = DirectCast(GrdERapproval.Rows(n).FindControl("linkbutton2"), LinkButton).Text
                Dim empname As String = GrdERapproval.Rows(n).Cells(2).Text
                If lbn.ToString.ToLower.Contains(str.ToString.ToLower) = True Or empname.ToString.ToLower.Contains(str.ToString.ToLower) = True Then
                    GrdERapproval.Rows(n).Focus()
                    GrdERapproval.Rows(n).BackColor = Drawing.Color.Orange
                Else
                    GrdERapproval.Rows(n).BackColor = Drawing.Color.White
                End If
            Next
        End If

    End Sub
End Class