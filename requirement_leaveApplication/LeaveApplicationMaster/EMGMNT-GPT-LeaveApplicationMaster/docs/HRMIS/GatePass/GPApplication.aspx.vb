Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications

Partial Public Class GPApplication
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection
    Dim com, com1 As New SqlCommand
    Dim status As Boolean
    Dim hdlstatus As Boolean
    Dim thisdate As Date
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim passno, recno As String
    Dim id, rno As Integer
    Dim curdate As Date
    Dim empID As String

    ' Dim gppass As String

    Public Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        MyApp.GetfiscalYear()

        thisdate = DateTime.Now
        '_eid = "014543"
        '_ename = "Sathya Vamshi Anigalla"
        '_edept = "9000"

        Session("empcode") = "014543"
        Session("_edept ") = "9000"
        Session("dept") = "9000"

        '_eid = Session("empcode")
        '_ename = Session("_ename ")
        '_edept = Session("_edept ")


        curdate = DateTime.Now

        Session("pnl") = ""

        If Not IsPostBack Then
            If Session("pnl") = "" Then
                gpstatus.Visible = True
                pGform.Visible = False
                gpapproval.Visible = False
                pnlgphistory.Visible = False
                pnlCsPass.Visible = False
                pnlGPreports.Visible = False
                pnlcvrpt.Visible = False
            ElseIf Session("pnl") = "gpapplication" Then
                gpstatus.Visible = False
                pGform.Visible = True
                gpapproval.Visible = False
                pnlgphistory.Visible = False
                pnlCsPass.Visible = False
                pnlGPreports.Visible = True
                pnlcvrpt.Visible = False
            ElseIf Session("pnl") = "approvals" Then
                gpstatus.Visible = False
                pGform.Visible = False
                gpapproval.Visible = True
                pnlgphistory.Visible = False
                pnlCsPass.Visible = False
                pnlGPreports.Visible = False
                pnlcvrpt.Visible = False
            ElseIf Session("pnl") = "gprpt" Then
                gpstatus.Visible = False
                pGform.Visible = False
                gpapproval.Visible = False
                pnlgphistory.Visible = False
                pnlCsPass.Visible = False
                pnlGPreports.Visible = True
                pnlcvrpt.Visible = False
            ElseIf Session("pnl") = "csform" Then
                gpstatus.Visible = False
                pGform.Visible = False
                gpapproval.Visible = False
                pnlgphistory.Visible = False
                pnlCsPass.Visible = True
                pnlGPreports.Visible = False
                pnlcvrpt.Visible = False
            ElseIf Session("pnl") = "cvrpt" Then
                gpstatus.Visible = False
                pGform.Visible = False
                gpapproval.Visible = False
                pnlgphistory.Visible = False
                pnlCsPass.Visible = False
                pnlGPreports.Visible = False
                pnlcvrpt.Visible = True
            End If
        End If

        ''''''''''''''new'''''''''''''''


        'pGform.Visible = False
        'gpstatus.Visible = False
        'gpapproval.Visible = False
        'pnlCsPass.Visible = True
        'pnlGPreports.Visible = False
        'pnlcvrpt.Visible = False

        'cstxthotel.Visible = False
        'lblhotel.Visible = False
        'lblhotelname.Visible = False
        'ccddlhotel.Visible = False

        'csddltaxi.Visible = False
        'lbltaxi.Visible = False
        'cslblstatus.Visible = False
        'csrdstatus.Visible = False
        'csbtnupd.Visible = False

        'cstxtpic.Text = ""
        'cstxtnop.Text = ""
        'cstxtcontact.Text = ""
        'cstxtarrival.Text = ""
        'cstxtpurpose.Text = ""
        'cstxtrecp.Text = ""
        'cstxtvname.Text = ""
        'cstxthotel.Text = ""
        'csrdtaxi.SelectedValue = "N"
        'csrdhotel.SelectedValue = "N"
        'csddltaxi.SelectedValue = "select"
        'ccddlhotel.SelectedValue = "select"
        'csddlvtype.SelectedValue = "select"

        '  cslstvdept.Items.Insert(0, New ListItem("-- Select Item --", "-1"))
        ' cslstvdept.SelectedValue = "-1"
        cslstvdept.DataBind()
        '''''''''''''''''''''''''''''''''''


        If Not IsPostBack Then
            Gridgpapp.DataBind()
            GrdCVApproval.DataBind()
            GridView1.DataBind()
            GrdCVPassStatus.DataBind()
        End If



    End Sub
    ''' <summary>
    ''' 'Gp APPLICATIONS,APPROVALS,SELFSTATUS
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    'Private Sub Lbform_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lbform.Click

    '''' panel
    'pGform.Visible = True
    'gpstatus.Visible = False
    'gpapproval.Visible = False
    'pnlGPreports.Visible = False
    'pnlCsPass.Visible = False
    'pnlcvrpt.Visible = False
    ''  pnlcsstatus.Visible = False
    '''''controls
    'lblstatus.Visible = False
    'Scheduled.Visible = False

    'Cancel.Visible = False
    'btnupdategp.Visible = False
    'txtsavegp.Visible = True
    'txtpurpose.Text = ""
    'txtlocation.Text = ""
    'txtvehicle.Text = ""
    'txtinhr.Text = ""
    'txtinmin.Text = ""
    'txtOuthr.Text = ""
    'Txtoutmin.Text = ""
    'GridView1.DataBind()

    'GetGatePassID()
    'rno = 0
    'If posid < 0 Then
    '    id = 1
    'Else
    '    id = posid + 1
    'End If

    'GetEmpVehino(_eid)
    'If recstatus = True Then
    '    Dim dr As DataRow
    '    If dsdata.Tables(0).Rows.Count > 0 Then
    '        dr = dsdata.Tables(0).Rows(0)
    '        txtph.Text = dr("php").ToString
    '    End If
    'End If
    'End Sub

    'Private Sub lbselfstatus_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbselfstatus.Click
    '    pGform.Visible = False
    '    gpstatus.Visible = True
    '    gpapproval.Visible = False
    '    pnlCsPass.Visible = False
    '    pnlGPreports.Visible = False
    '    pnlcvrpt.Visible = False
    '    GridView1.DataBind()
    '    GrdCVPassStatus.DataBind()
    '    '  pnlcsstatus.Visible = False
    'End Sub
    'Private Sub lbgpapprovals_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbgpapprovals.Click
    '    pGform.Visible = False
    '    gpstatus.Visible = False
    '    gpapproval.Visible = True
    '    pnlCsPass.Visible = False
    '    pnlGPreports.Visible = False
    '    pnlcvrpt.Visible = False
    '    '  If Not IsPostBack Then
    '    Gridgpapp.DataBind()
    '    'End If
    '    ' If Not IsPostBack Then
    '    GrdCVApproval.DataBind()
    '    ' End If
    '    '  pnlcsstatus.Visible = False
    'End Sub

    Protected Sub txtsavegp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsavegp.Click

        Dim intime As String
        Dim outtime As String

        GetGatePassID()
        rno = 0
        If posid < 0 Then
            id = 1
        Else
            id = posid + 1
        End If
        intime = txtinhr.Text + ":" + txtinmin.Text + " " + Convert.ToString(ddout.SelectedItem)
        outtime = txtOuthr.Text + ":" + Txtoutmin.Text + " " + Convert.ToString(ddin.SelectedItem)

        Dim fd1 As String
        fd1 = dategp.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)




        InsertGatePass(id, Convert.ToString(ddltype.SelectedValue), _eid, thisdate, txtlocation.Text, txtph.Text, fd, txtvehicle.Text, txtpurpose.Text, intime, outtime)
        If recstatus = True Then
            MessageBox("Pass has been scheduled")
            txtpurpose.Text = ""
            txtlocation.Text = ""
            txtvehicle.Text = ""
            txtinhr.Text = ""
            txtinmin.Text = ""
            txtOuthr.Text = ""
            Txtoutmin.Text = ""
            GridView1.DataBind()
            pGform.Visible = False
            gpstatus.Visible = True
        Else
            MessageBox("Record not saved..Try again")
            pGform.Visible = True
        End If


    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub sqlgatepass_Selecting(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles sqlgatepass.Selecting
        e.Command.Parameters(0).Value = _eid
        e.Command.Parameters(1).Value = _fisyrStart
        e.Command.Parameters(2).Value = _fisyrEnd
    End Sub
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'determine the value of the status field
            Dim status As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "status"))
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
                '  color the background of the row yellow
                e.Row.Cells(7).ForeColor = Drawing.Color.Yellow
                ' e.Row.Cells(0).Attributes.Add("class", "statusclass")
            ElseIf status = "RETURNED" Or status = "Approved" Or status = "Out" Or status = "APPROVED" Then
                e.Row.Cells(7).ForeColor = Drawing.Color.Green
            ElseIf status = "Rejected" Or status = "REJECTED" Then
                e.Row.Cells(7).ForeColor = Drawing.Color.Red
            End If
        End If
    End Sub

    Public Sub mpop(ByVal sender As Object, ByVal e As CommandEventArgs)
        passno = e.CommandArgument
        Try
            GetGatePassDetails(e.CommandArgument)
            If recstatus = True Then
                Dim dr As DataRow
                If dsdata.Tables(0).Rows.Count > 0 Then
                    dr = dsdata.Tables(0).Rows(0)
                    ddltype.Text = dr("gatepasstype").ToString
                    txtpurpose.Text = dr("purpose").ToString
                    txtlocation.Text = dr("location").ToString
                    txtph.Text = dr("mobile").ToString
                    txtvehicle.Text = dr("pvehicleno").ToString
                    txtinhr.Text = Format(Convert.ToDateTime(dr("intime")), "hh")
                    txtinmin.Text = Format(Convert.ToDateTime(dr("intime")), "mm")
                    ddout.SelectedValue = Format(Convert.ToDateTime(dr("outtime")), "tt")
                    txtOuthr.Text = Format(Convert.ToDateTime(dr("outtime")), "hh")
                    Txtoutmin.Text = Format(Convert.ToDateTime(dr("outtime")), "mm")
                    ddin.SelectedValue = Format(Convert.ToDateTime(dr("intime")), "tt")
                    dategp.Text = Format(Convert.ToDateTime(dr("outdate")), "dd/MM/yy")
                    If dr("status") = "SCHEDULED" Then
                        Scheduled.Checked = True
                    Else
                        Scheduled.Checked = False
                        Cancel.Checked = False
                    End If
                    gppassnum.Text = dr("passno").ToString
                End If
            End If
            pGform.Visible = True
            gpstatus.Visible = False
            gpapproval.Visible = False
            btnupdategp.Visible = True
            txtsavegp.Visible = False
            lblstatus.Visible = True
            Scheduled.Visible = True
            Cancel.Visible = True
            pnlGPreports.Visible = False

        Catch ex As Exception
            MessageBox(ex.Message)
        End Try

    End Sub
    Public Sub gpcancel(ByVal sender As Object, ByVal e As CommandEventArgs)

        passno = e.CommandArgument
        Try
            cancelGatePass(e.CommandArgument)
            pGform.Visible = False
            gpstatus.Visible = True
            gpapproval.Visible = False

        Catch ex As Exception
            MessageBox(ex.Message)
        End Try
        GridView1.DataBind()
    End Sub
    Protected Sub btnupdategp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdategp.Click
        Dim id, rno As Integer
        Dim intime As String
        Dim outtime As String
        Dim stat As String
        Dim stDate As Date


        ' curdate = Format(DateTime.Now, "MM/dd/yyyy")
        ' curdate = DateTime.Parse(curdate, Globalization.CultureInfo.CreateSpecificCulture("en-US"))
        '  Dim odate As Date
        ' odate = dategp.Text

        Dim fd1 As String
        fd1 = dategp.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)



        intime = txtinhr.Text + ":" + txtinmin.Text + " " + Convert.ToString(ddout.SelectedItem)
        outtime = txtOuthr.Text + ":" + Txtoutmin.Text + " " + Convert.ToString(ddin.SelectedItem)

        rno = 0

        If Scheduled.Checked = True Then
            stat = "SCHEDULED"
        ElseIf Cancel.Checked = True Then
            stat = "CANCEL"
        End If

        UpdateGatePass(id, Convert.ToString(ddltype.SelectedValue), _eid, curdate, txtlocation.Text, txtph.Text, fd, txtvehicle.Text, txtpurpose.Text, intime, outtime, gppassnum.Text)

        If recstatus = True Then
            MessageBox("Pass has been updated")
            txtpurpose.Text = ""
            txtlocation.Text = ""
            txtvehicle.Text = ""
            txtinhr.Text = ""
            txtinmin.Text = ""
            gppassnum.Text = ""
            txtOuthr.Text = ""
            Txtoutmin.Text = ""

        Else
            MessageBox("Record not saved..Try again")
        End If
        GridView1.DataBind()
        pGform.Visible = False
        gpstatus.Visible = True
        gpapproval.Visible = False
        pnlCsPass.Visible = False
        pnlGPreports.Visible = False
        ' pnlcsstatus.Visible = False

    End Sub

    Private Sub dategp_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles dategp.Load
        '  dategp.Text = DateTime.Now.ToString("dd/MM/yy")
    End Sub

    Public Sub UpdateGpApproval(ByVal sender As Object, ByVal e As EventArgs)
        For i As Integer = 0 To Gridgpapp.Rows.Count - 1
            Dim passno As String = Gridgpapp.Rows(i).Cells(0).Text
            Dim status As String = DirectCast(Gridgpapp.Rows(i).FindControl("rbgpstatus"), RadioButtonList).SelectedValue
            ' Dim remark As String = DirectCast(Gridgpapp.Rows(i).FindControl("txtremarks"), TextBox).Text
            'Dim rbgpstatus As RadioButtonList = TryCast(Gridgpapp.FindControl("rbgpstatus"), RadioButtonList)
            UpdateApproval(passno, status)
        Next
        Gridgpapp.DataBind()
        '   GridView1.DataBind()
        gpapproval.Visible = True
        pGform.Visible = False
        gpstatus.Visible = False
    End Sub

    ''' <summary>
    ''' cUSTOMER pASS cODE sTARTS hERE
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    'Private Sub lbcsform_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbcsform.Click
    '    pGform.Visible = False
    '    gpstatus.Visible = False
    '    gpapproval.Visible = False
    '    pnlCsPass.Visible = True
    '    pnlGPreports.Visible = False
    '    pnlcvrpt.Visible = False

    '    cstxthotel.Visible = False
    '    lblhotel.Visible = False
    '    lblhotelname.Visible = False
    '    ccddlhotel.Visible = False

    '    csddltaxi.Visible = False
    '    lbltaxi.Visible = False
    '    cslblstatus.Visible = False
    '    csrdstatus.Visible = False
    '    csbtnupd.Visible = False

    '    cstxtpic.Text = ""
    '    cstxtnop.Text = ""
    '    cstxtcontact.Text = ""
    '    cstxtarrival.Text = ""
    '    cstxtpurpose.Text = ""
    '    cstxtrecp.Text = ""
    '    cstxtvname.Text = ""
    '    cstxthotel.Text = ""
    '    csrdtaxi.SelectedValue = "N"
    '    csrdhotel.SelectedValue = "N"
    '    csddltaxi.SelectedValue = "select"
    '    ccddlhotel.SelectedValue = "select"
    '    csddlvtype.SelectedValue = "select"

    '    '  cslstvdept.Items.Insert(0, New ListItem("-- Select Item --", "-1"))
    '    ' cslstvdept.SelectedValue = "-1"
    '    cslstvdept.DataBind()
    'End Sub
    Public Sub cvcancel(ByVal sender As Object, ByVal e As CommandEventArgs)
        passno = e.CommandArgument
        Try
            cancelcsPass(e.CommandArgument)
            pGform.Visible = False
            gpstatus.Visible = True
            gpapproval.Visible = False
            pnlCsPass.Visible = False

        Catch ex As Exception
            MessageBox(ex.Message)
        End Try
        GrdCVPassStatus.DataBind()
    End Sub

    Protected Sub csbtnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles csbtnsave.Click
        Dim arrtime As String
        Dim i As Integer
        i = 0
        arrtime = csddlhr.SelectedValue + ":" + csddlmin.SelectedValue + " " + Convert.ToString(csddlam.SelectedValue)
        Dim csseldept As String = ""

        For i = 0 To cslstvdept.Items.Count - 1
            If cslstvdept.Items(i).Selected Then
                csseldept = csseldept & cslstvdept.Items(i).Value & ","
            End If
        Next
        If cslstvdept.SelectedValue = "-1" Then
            MessageBox("Select Visitor Department")
            Exit Sub
        End If

        Dim fd1 As String
        fd1 = cstxtarrival.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)



        InsertCustomerPass(_eid, csddlvtype.SelectedValue, cstxtcompname.Text, cstxtpic.Text, cstxtnop.Text, cstxtcontact.Text, fd, arrtime, cstxtpurpose.Text, cstxtrecp.Text, curdate, _edept, csseldept, cstxtvname.Text, csrdtaxi.SelectedValue, csddltaxi.SelectedValue, csrdhotel.SelectedValue, ccddlhotel.SelectedValue, cstxthotel.Text)
        If recstatus = True Then
            cstxtpic.Text = ""
            cstxtnop.Text = ""
            cstxtcontact.Text = ""
            cstxtarrival.Text = ""
            cstxtpurpose.Text = ""
            cstxtrecp.Text = ""
            cstxtvname.Text = ""
            cstxthotel.Text = ""
            csrdtaxi.SelectedValue = "N"
            csrdhotel.SelectedValue = "N"
            csddltaxi.SelectedValue = "select"
            ccddlhotel.SelectedValue = "select"
            csddlvtype.SelectedValue = "select"
            MessageBox("Pass has been Scheduled....")
            ' pnlcsstatus.Visible = True
            pnlCsPass.Visible = False
            GrdCVPassStatus.DataBind()

        Else
            pGform.Visible = False
            gpstatus.Visible = False
            gpapproval.Visible = False
            pnlCsPass.Visible = True
            pnlGPreports.Visible = False
            pnlcvrpt.Visible = False
            ' pnlcsstatus.Visible = False
            MessageBox("Record Not saved....Try again !!")

        End If

    End Sub


    Protected Sub csrdtaxi_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles csrdtaxi.SelectedIndexChanged
        If csrdtaxi.SelectedValue = "Y" Then
            csddltaxi.Visible = True
            lbltaxi.Visible = True
            pGform.Visible = False
            gpstatus.Visible = False
            gpapproval.Visible = False
            pnlCsPass.Visible = True
        Else
            csddltaxi.Visible = False
            lbltaxi.Visible = False
            pGform.Visible = False
            gpstatus.Visible = False
            gpapproval.Visible = False
            pnlCsPass.Visible = True
        End If
    End Sub
    Protected Sub csrdhotel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles csrdhotel.SelectedIndexChanged
        If csrdhotel.SelectedValue = "Y" Then
            cstxthotel.Visible = True
            lblhotel.Visible = True
            lblhotelname.Visible = True
            ccddlhotel.Visible = True
            pGform.Visible = False
            gpstatus.Visible = False
            gpapproval.Visible = False
            pnlCsPass.Visible = True
        Else
            cstxthotel.Visible = False
            lblhotel.Visible = False
            lblhotelname.Visible = False
            ccddlhotel.Visible = False
            pGform.Visible = False
            gpstatus.Visible = False
            gpapproval.Visible = False
            pnlCsPass.Visible = True
        End If
    End Sub
    Protected Sub sqlcvpass_Selecting(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles sqlcvpass.Selecting
        e.Command.Parameters(0).Value = _edept
        e.Command.Parameters(1).Value = _eid
    End Sub
    Public Sub FncRetreivecpass(ByVal sender As Object, ByVal e As CommandEventArgs)
        recno = e.CommandArgument
        Dim deldepts As String
        Try
            GetCustPassDetails(e.CommandArgument)
            If recstatus = True Then
                Dim dr As DataRow
                If dsdata.Tables(0).Rows.Count > 0 Then
                    dr = dsdata.Tables(0).Rows(0)
                    csddlvtype.SelectedValue = dr("visitortype").ToString
                    cstxtpic.Text = dr("companypersonincharge").ToString
                    cstxtcompname.Text = dr("companyname").ToString
                    cstxtvname.Text = dr("personincharge").ToString
                    cstxtnop.Text = dr("noofperson").ToString
                    cstxtcontact.Text = dr("contactno").ToString
                    cstxtarrival.Text = Format(Convert.ToDateTime(dr("arrivaldate")), "dd/MM/yy")
                    'csddlhr.SelectedItem.Text = Format(Convert.ToDateTime(dr("arrivaltime")), "hh")
                    csddlmin.SelectedValue = Format(Convert.ToDateTime(dr("arrivaltime")), "mm")
                    csddlam.SelectedValue = Format(Convert.ToDateTime(dr("arrivaltime")), "tt")
                    cstxtpurpose.Text = dr("purpose").ToString
                    cstxtrecp.Text = dr("receptionarea").ToString

                    If Trim(dr("taxibooking")).ToString = "Y" Then
                        csrdtaxi.SelectedValue = Trim(dr("taxibooking")).ToString
                        csddltaxi.SelectedValue = dr("taxicost").ToString
                        csddltaxi.Visible = True
                        lbltaxi.Visible = True
                    Else
                        csrdtaxi.SelectedValue = Trim(dr("taxibooking")).ToString
                        csddltaxi.Visible = False
                        lbltaxi.Visible = False
                    End If
                    If Trim(dr("hotelarrangement")).ToString = "Y" Then
                        cstxthotel.Visible = True
                        lblhotel.Visible = True
                        lblhotelname.Visible = True
                        ccddlhotel.Visible = True
                        csrdhotel.SelectedValue = Trim(dr("hotelarrangement")).ToString
                        ccddlhotel.SelectedValue = dr("hotelcost").ToString
                        cstxthotel.Text = dr("hotelname").ToString
                    Else
                        csrdhotel.SelectedValue = Trim(dr("hotelarrangement")).ToString
                        cstxthotel.Visible = False
                        lblhotel.Visible = False
                        lblhotelname.Visible = False
                        ccddlhotel.Visible = False
                    End If

                    If Trim(dr("status")).ToString = "S" Then
                        csrdstatus.SelectedValue = Trim(dr("status")).ToString
                    End If
                    hidrno.Value = dr("recno").ToString
                    '  deldepts = dr("visitdepartment").ToString
                End If
            End If
            pGform.Visible = False
            gpstatus.Visible = False
            gpapproval.Visible = False
            pnlCsPass.Visible = True
            '  pnlcsstatus.Visible = False
            csbtnupd.Visible = True
            csbtnsave.Visible = False
        Catch ex As Exception
            MessageBox(ex.Message)
        End Try
    End Sub
    Private Sub GrdCVPassStatus_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrdCVPassStatus.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'determine the value of the status field
            Dim status As String = Trim(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "status")))
            Dim label As Label = TryCast(e.Row.FindControl("lblcv"), Label)
            Dim button As LinkButton = TryCast(e.Row.FindControl("lbcv"), LinkButton)
            Dim button2 As LinkButton = TryCast(e.Row.FindControl("lbcancecv"), LinkButton)
            If status = "s" Or status = "S" Or status = "SCHEDULED" Then
                button.Visible = True
                label.Visible = False
                button2.Visible = True
            Else
                label.Visible = True
                button.Visible = False
                button2.Visible = False
            End If

            If status = "s" Or status = "S" Then
                e.Row.Cells(8).ForeColor = Drawing.Color.Yellow
                ' e.Row.Cells(0).Text = "SCHEDULED"
            ElseIf status = "A" Then
                e.Row.Cells(8).ForeColor = Drawing.Color.Green
                '  e.Row.Cells(0).Text = "APPROVED"
            ElseIf status = "R" Then
                e.Row.Cells(8).ForeColor = Drawing.Color.Red
                '  e.Row.Cells(0).Text = "REJECTED"
            End If
        End If
    End Sub
    Protected Sub csbtnupd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles csbtnupd.Click
        Dim arrtime As String
        Dim i As Integer
        i = 0
        arrtime = csddlhr.SelectedValue + ":" + csddlmin.SelectedValue + " " + Convert.ToString(csddlam.SelectedValue)

        Dim fd1 As String
        fd1 = cstxtarrival.Text.Trim()
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)

        Dim csseldept As String
        For i = 0 To cslstvdept.Items.Count - 1
            If cslstvdept.Items(i).Selected Then
                csseldept = csseldept & cslstvdept.Items(i).Value & ","
            End If
        Next
        If cstxtrecp.Text = "" Then
            cstxtrecp.Text = "-"
        End If
        If cstxtpurpose.Text = "" Then
            cstxtpurpose.Text = "-"
        End If

        UpdateCustomerPass(_eid, csddlvtype.SelectedValue, cstxtcompname.Text, cstxtpic.Text, cstxtnop.Text, cstxtcontact.Text, fd, arrtime, cstxtpurpose.Text, cstxtrecp.Text, curdate, _edept, csseldept, cstxtvname.Text, csrdtaxi.SelectedValue, csddltaxi.SelectedValue, csrdhotel.SelectedValue, ccddlhotel.SelectedValue, cstxthotel.Text, hidrno.Value, csrdstatus.SelectedValue)
        If recstatus = True Then
            cstxtpic.Text = ""
            cstxtnop.Text = ""
            cstxtcontact.Text = ""
            cstxtarrival.Text = ""
            cstxtpurpose.Text = ""
            cstxtrecp.Text = ""
            cstxtvname.Text = ""
            cstxthotel.Text = ""
            csrdtaxi.SelectedValue = "N"
            csrdhotel.SelectedValue = "N"
            csddltaxi.SelectedValue = "select"
            ccddlhotel.SelectedValue = "select"
            csddlvtype.SelectedValue = "select"
            MessageBox("Pass has been Updated....")
            pnlCsPass.Visible = False
            ' pnlcsstatus.Visible = True
            csbtnupd.Visible = False
            csbtnsave.Visible = True
            GrdCVPassStatus.DataBind()
        Else
            pGform.Visible = False
            gpstatus.Visible = False
            gpapproval.Visible = False
            pnlCsPass.Visible = True
            pnlGPreports.Visible = False
            pnlcvrpt.Visible = False
            csbtnupd.Visible = True
            csbtnsave.Visible = False
            MessageBox("Record Not saved....Try again !!")
        End If
    End Sub
    ''' <summary>
    '''  aPPROVALS
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub sqlCvapproval_Selecting(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles sqlCvapproval.Selecting
        e.Command.Parameters(0).Value = _edept
    End Sub
    Public Sub UpdateCVApproval(ByVal sender As Object, ByVal e As EventArgs)
        For i As Integer = 0 To GrdCVApproval.Rows.Count - 1
            Dim passno As String = GrdCVApproval.Rows(i).Cells(0).Text
            Dim status As String = DirectCast(GrdCVApproval.Rows(i).FindControl("rbcvstatus"), RadioButtonList).SelectedValue
            'Dim rbgpstatus As RadioButtonList = TryCast(Gridgpapp.FindControl("rbgpstatus"), RadioButtonList)
            UpdatefncCVApproval(passno, status)
        Next
        GrdCVApproval.DataBind()
        gpapproval.Visible = True
        pGform.Visible = False
        gpstatus.Visible = False
        pnlGPreports.Visible = False
    End Sub
    ''' <summary>
    ''' MPE CODES
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Fetch the customer id      
        Dim lb As LinkButton = TryCast(sender, LinkButton)
        Session("emp") = lb.Text
        empID = lb.Text

        GetTotPerGp(empID)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                lbltotpergp.Text = dr("PersonalGP").ToString
            End If
        End If
        GetTotOffGp(empID)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                lbltotOffGp.Text = dr("OfficialGP").ToString
            End If
        End If
        GetTotPending(empID)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                lblgppending.Text = dr("PersonalGP").ToString
            End If
        End If
        'lbltxtempid.Text = empID
        GetEmpVehino(empID)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                lbltxtempid.Text = dr("empname").ToString
                txtdept2.Text = dr("departmentcode").ToString + "-" + dr("sectioncode").ToString
                Label15.Text = dr("designation")
            End If
        End If
        BindGridGpHistory(empID)
        gpapproval.Visible = True
        gpstatus.Visible = False
        pnlgphistory.Visible = True
        pnlGPreports.Visible = False
        pnlcvrpt.Visible = False
        rathimpe.Show()
    End Sub
    Public Sub BindGridGpHistory(ByVal empid As String)
        GetGpHistory(empid, _fisyrStart, _fisyrEnd)
        If recstatus = True Then
            GrdGphistory.DataSource = dsdata.Tables(0).DefaultView
            'GrdGphistory.AllowPaging = True
            GrdGphistory.HeaderStyle.ForeColor = Drawing.Color.Red
            GrdGphistory.HeaderStyle.VerticalAlign = VerticalAlign.Middle
            GrdGphistory.DataBind()
        End If
    End Sub

    ''' <summary>
    ''' rEPORTS
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    'Private Sub LbGpReports_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LbGpReports.Click
    '    pGform.Visible = False
    '    gpstatus.Visible = False
    '    gpapproval.Visible = False
    '    pnlCsPass.Visible = False
    '    pnlGPreports.Visible = True
    '    pnlcvrpt.Visible = False

    '    lbldeptr.Enabled = False
    '    lblsectr.Enabled = False
    '    lbldesigr.Enabled = False
    '    lblempr.Enabled = False

    '    ddldeptr.Enabled = False
    '    ddlsectr.Enabled = False
    '    ddldesigr.Enabled = False
    '    txtempidr.Enabled = False

    'End Sub
    'Private Sub LbCvReports_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LbCvReports.Click
    '    pGform.Visible = False
    '    gpstatus.Visible = False
    '    gpapproval.Visible = False
    '    pnlCsPass.Visible = False
    '    pnlGPreports.Visible = False
    '    pnlcvrpt.Visible = True
    '    '  pnlcsstatus.Visible = False

    'End Sub
    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim rdvalue As String
        rdvalue = rdoptions.SelectedValue

        Session("gpdesi") = Trim(ddldesigr.SelectedValue)
        Session("gpemp") = Trim(txtempidr.Text)
        Session("gpdept") = ddldeptr.SelectedValue.Trim
        Session("gpsect") = ddlsectr.SelectedValue.Trim
        Dim fd1 As String
        fd1 = txtfrom.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)
        Session("gpfd") = fd

        Dim td1 As String
        td1 = txtto.Text.Trim
        Dim strdate2() As String = td1.Split("/"c)
        td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

        Dim td As Date
        td = CDate(td1)
        Session("gptd") = td

        If rdvalue = "Dept" And ddldeptr.SelectedValue <> "" Then
            '  Button1.Attributes.Add("onclick", String.Format("window.open('/Reports/Hrmis/CrvGpdept.aspx?fromd={0}&tod={1}&dep={2}','_blank','fullscreen=no,popup,scrollbars=yes,menubar=yes')", fd, td, ddldeptr.SelectedValue))
            Response.Redirect("/Reports/Hrmis/CrvGpdept.aspx")
        ElseIf rdvalue = "Sect" And ddlsectr.SelectedValue <> "" Then
            'Button1.Attributes.Add("onclick", String.Format("window.open('/Reports/Hrmis/CvGpSect.aspx?fromd={0}&tod={1}&sec={2}','_blank','fullscreen=no,popup,scrollbars=yes,menubar=yes')", fd, td, ddlsectr.SelectedValue))
            Response.Redirect("/Reports/Hrmis/CvGpSect.aspx")
        ElseIf rdvalue = "Desig" And ddldesigr.SelectedValue <> "" Then
            ' Button1.Attributes.Add("onclick", String.Format("window.open('/Reports/Hrmis/CrvGpdesig.aspx?fromd={0}&tod={1}&desi={2}','_blank','fullscreen=no,popup,scrollbars=yes,menubar=yes')", fd, td, designation))
            Response.Redirect("/Reports/Hrmis/CrvGpdesig.aspx")
        ElseIf rdvalue = "Emp" And txtempidr.Text <> "" Then
            'Button1.Attributes.Add("onclick", String.Format("window.open('/Reports/Hrmis/CrvGpemp.aspx?fromd={0}&tod={1}&emp={2}','_blank','fullscreen=no,popup,scrollbars=yes,menubar=yes')", fd, td, empid))
            Response.Redirect("/Reports/Hrmis/CrvGpemp.aspx")
        Else
            ' Button1.Attributes.Add("onclick", String.Format("window.open('/Reports/Hrmis/CrvGpall.aspx?fromd={0}&tod={1}','_blank','fullscreen=no,popup,scrollbars=yes,menubar=yes')", fd, td))
            Response.Redirect("/Reports/Hrmis/CrvGpall.aspx")
        End If

        gpstatus.Visible = False
        gpapproval.Visible = False
        pnlCsPass.Visible = False
        pnlGPreports.Visible = True
        pnlcvrpt.Visible = False

    End Sub
    Private Sub btnCvReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCvReport.Click
        '  Response.Redirect("~\Reports\Hrmis\CrvCSall.aspx?fromd=" + txtfrom.Text + " &tod=" + txtto.Text + "")
        Dim fd1 As String
        fd1 = Txtcsf.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)
        Session("cvfd") = fd

        Dim td1 As String
        td1 = txtcst.Text.Trim
        Dim strdate2() As String = td1.Split("/"c)
        td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

        Dim td As Date
        td = CDate(td1)
        Session("cvtd") = td

        ' btnCvReport.Attributes.Add("onclick", String.Format("window.open('/Reports/Hrmis/Crvcsall.aspx?fromd={0}&tod={1}','_blank','fullscreen=yes,scrollbars=yes,menubar=yes')", fd, td))
        Response.Redirect("/Reports/Hrmis/Crvcsall.aspx")

    End Sub
    Protected Sub rdoptions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoptions.SelectedIndexChanged
        If rdoptions.SelectedValue = "Dept" Then
            ddldeptr.Enabled = True
            lbldeptr.Enabled = True
        ElseIf rdoptions.SelectedValue = "Sect" Then
            lblsectr.Enabled = True
            ddlsectr.Enabled = True
        ElseIf rdoptions.SelectedValue = "Desig" Then
            lbldesigr.Enabled = True
            ddldesigr.Enabled = True
        ElseIf rdoptions.SelectedValue = "Emp" Then
            lblempr.Enabled = True
            txtempidr.Enabled = True
        End If

        gpstatus.Visible = False
        gpapproval.Visible = False
        pnlCsPass.Visible = False
        pnlGPreports.Visible = True
    End Sub
    Private Sub GrdGphistory_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GrdGphistory.PageIndexChanging
        BindGridGpHistory(Session("emp"))
        GrdGphistory.PageIndex = e.NewPageIndex
        GrdGphistory.DataBind()
        gpapproval.Visible = True
        gpstatus.Visible = False
        pnlgphistory.Visible = True
        pnlGPreports.Visible = False
        rathimpe.Show()
    End Sub
    Private Sub GrdCVApproval_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GrdCVApproval.PageIndexChanging
        gpapproval.Visible = True
        gpstatus.Visible = False
        pnlgphistory.Visible = True
        pnlGPreports.Visible = False
    End Sub
    Private Sub GrdCVApproval_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdCVApproval.Sorted
        gpapproval.Visible = True
        gpstatus.Visible = False
        pnlgphistory.Visible = True
        pnlGPreports.Visible = False
    End Sub
    Private Sub Gridgpapp_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles Gridgpapp.PageIndexChanging
        gpapproval.Visible = True
        gpstatus.Visible = False
        pnlgphistory.Visible = True
        pnlGPreports.Visible = False
    End Sub
    Private Sub Gridgpapp_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles Gridgpapp.Sorting
        gpapproval.Visible = True
        gpstatus.Visible = False
        pnlgphistory.Visible = True
        pnlGPreports.Visible = False
    End Sub
    Protected Sub txtgpclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtgpclear.Click
        pGform.Visible = True
        gpstatus.Visible = False
        gpapproval.Visible = False
        pnlGPreports.Visible = False
        pnlCsPass.Visible = False

        txtsavegp.Visible = True
        txtpurpose.Text = ""
        txtlocation.Text = ""

        txtvehicle.Text = ""
        txtinhr.Text = ""
        txtinmin.Text = ""
        txtOuthr.Text = ""
        Txtoutmin.Text = ""
    End Sub
    Protected Sub BtnGpexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGpexit.Click
        pGform.Visible = False
        gpstatus.Visible = True
        gpapproval.Visible = False
        pnlGPreports.Visible = False
        pnlCsPass.Visible = False
    End Sub
    Protected Sub btnCsexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCsexit.Click
        pGform.Visible = False
        gpstatus.Visible = True
        gpapproval.Visible = False
        pnlGPreports.Visible = False
        pnlCsPass.Visible = False
    End Sub
    Protected Sub btncsclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncsclear.Click
        pGform.Visible = False
        gpstatus.Visible = False
        gpapproval.Visible = False
        pnlCsPass.Visible = True
        pnlGPreports.Visible = False
        cstxtpic.Text = ""
        cstxtnop.Text = ""
        cstxtcontact.Text = ""
        cstxtarrival.Text = ""
        cstxtpurpose.Text = ""
        cstxtrecp.Text = ""
        cstxtvname.Text = ""
        cstxthotel.Text = ""
        cstxtcompname.Text = ""
        csrdtaxi.SelectedValue = "N"
        csrdhotel.SelectedValue = "N"
        csddltaxi.SelectedValue = "select"
        ccddlhotel.SelectedValue = "select"
        csddlvtype.SelectedValue = "select"
    End Sub
    Protected Sub ddldeptr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddldeptr.SelectedIndexChanged
        gpstatus.Visible = False
        gpapproval.Visible = False
        pnlCsPass.Visible = False
        pnlGPreports.Visible = True
        ddldeptr.Enabled = True
    End Sub
    Protected Sub ddlsectr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlsectr.SelectedIndexChanged
        gpstatus.Visible = False
        gpapproval.Visible = False
        pnlCsPass.Visible = False
        pnlGPreports.Visible = True
        ddlsectr.Enabled = True
    End Sub
    Protected Sub ddldesigr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddldesigr.SelectedIndexChanged
        gpstatus.Visible = False
        gpapproval.Visible = False
        pnlCsPass.Visible = False
        pnlGPreports.Visible = True
        ddldesigr.Enabled = True
    End Sub
    Protected Sub txtempidr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtempidr.TextChanged
        gpstatus.Visible = False
        gpapproval.Visible = False
        pnlCsPass.Visible = False
        pnlGPreports.Visible = True
        txtempidr.Enabled = True
    End Sub

    Protected Sub cslstvdept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cslstvdept.SelectedIndexChanged

    End Sub
End Class