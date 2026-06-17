Imports System.Data
Imports System
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class GPform
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim thisdate As Date
    Dim passno, recno As String
    Dim id, rno As Integer
    Dim curdate, timenow As Date
    Dim gpnum As String
    Dim empID As String
    Private Sub GPform_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (37)
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
        GetGatePassID()
        rno = 0
        If posid < 0 Then
            id = 1
        Else
            id = posid + 1
        End If

        gppassnum.Text = id
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyApp.GetfiscalYear()
        'Session("empcode") = "014543"
        'Session("dept") = "9000"
        thisdate = Date.Now

        _eid = Session("empcode")
        _ename = Session("_ename ")
        _edept = Session("_edept ")

        '_eid = "014543"
        '_ename = "Sathya Vamshi Anigalla"
        '_edept = "9000"


        curdate = DateTime.Now
        GetEmpVehino(_eid)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                txtph.Text = dr("php").ToString
            End If
        Else
            lblmsg.Text = MyerrorMsg
            lblmsg.ForeColor = Drawing.Color.Red
        End If

        If Not IsPostBack Then
            txtsavegp.Visible = True
            btnupdategp.Visible = False
        End If
    End Sub
    Protected Sub txtsavegp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsavegp.Click
        Dim vehi
        Dim intime As String
        Dim outtime As String


        intime = ddlihr.Text + ":" + ddlimin.Text + " " + Convert.ToString(ddin.SelectedItem)
        outtime = ddlohr.Text + ":" + ddlomin.Text + " " + Convert.ToString(ddout.SelectedItem)

        Dim fd1 As String
        fd1 = dategp.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)

        Dim thisdt As New DateTime
        thisdt = thisdate.ToShortDateString()

        'timenow = DateTime.Now
        'Dim currtime As New DateTimeOffset
        'currtime = curdate.ToShortTimeString

        If fd < thisdt Then
            MessageBox("Key in Correct date")
            Exit Sub
        End If

        ''' for prayer type
        If ddltype.SelectedValue = "Prayers" Then
            Dim thisday As Integer
            thisday = fd.DayOfWeek
            If thisday <> 5 Then
                MessageBox("GatePass for Prayers can be use only for Friday!!")
                Exit Sub
            End If
        End If
        Dim INDATE
        Dim outdate
        INDATE = fd1 & " " & intime
        outdate = fd1 & " " & outtime

        Dim res = DateDiff(DateInterval.Minute, outdate, INDATE)

        If res < 0 Then
            MessageBox("Invalid Time")
            Exit Sub

        ElseIf res > 180 And ddltype.SelectedValue = "PERSONAL" Then
            MessageBox("Cannot apply more than 3 hours for Personal Gatepass")
            Exit Sub
        End If

        If txtvehicle.SelectedValue = "-1" Then
            vehi = txtvehicle2.Text.Trim
        Else
            vehi = txtvehicle.SelectedValue.Trim
        End If

        InsertGatePass(id, Convert.ToString(ddltype.SelectedValue), _eid, thisdate, txtlocation.Text, txtph.Text, fd, vehi, txtpurpose.Text, intime, outtime)
        If recstatus = True Then
            MessageBox("Pass has been scheduled")
            lblmsg.Text = ""
            txtpurpose.Text = ""
            txtlocation.Text = ""
            txtvehicle.Text = "-1"
            ddlihr.Text = "-"
            ddlimin.Text = "-"
            ddlohr.Text = "-"
            ddlomin.Text = "-"
            dategp.Text = ""
            txtvehicle2.Text = ""
            GetGatePassID()
            rno = 0
            If posid < 0 Then
                id = 1
            Else
                id = posid + 1
            End If
            gppassnum.Text = id
            GridView1.DataBind()
        Else
            lblmsg.Text = MyerrorMsg & " Record not saved.."
            lblmsg.ForeColor = Drawing.Color.Red

        End If

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
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Protected Sub btnupdategp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdategp.Click
        Dim vehi
        Dim id, rno As Integer
        Dim intime As String
        Dim outtime As String

        Dim fd1 As String
        fd1 = dategp.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)

        intime = ddlihr.Text + ":" + ddlimin.Text + " " + Convert.ToString(ddin.SelectedItem)
        outtime = ddlohr.Text + ":" + ddlomin.Text + " " + Convert.ToString(ddout.SelectedItem)
        rno = 0

        Dim thisdt As New DateTime
        thisdt = thisdate.ToShortDateString()

        If fd < thisdt Then
            MessageBox("Key in Correct date")
            Exit Sub
        End If

        ''' for prayer type
        If ddltype.SelectedValue = "Prayers" Then
            Dim thisday As Integer
            thisday = fd.DayOfWeek
            If thisday <> 5 Then
                MessageBox("GatePass for Prayers can be use only for Friday!!")
                Exit Sub
            End If
        End If

        Dim INDATE
        Dim outdate
        INDATE = fd1 & " " & intime
        outdate = fd1 & " " & outtime

        Dim res = DateDiff(DateInterval.Minute, outdate, INDATE)

        If res < 0 Then
            MessageBox("Invalid Time")
            Exit Sub
        ElseIf res > 180 And ddltype.SelectedValue = "PERSONAL" Then
            MessageBox("Cannot apply more than 3 hours for Personal Gatepass")
            Exit Sub
        End If


        If txtvehicle.SelectedValue.Trim = "-1" Then
            vehi = txtvehicle2.Text.Trim
        Else
            vehi = txtvehicle.SelectedValue.Trim
        End If

        UpdateGatePass(id, Convert.ToString(ddltype.SelectedValue), _eid, curdate, txtlocation.Text, txtph.Text, fd, vehi, txtpurpose.Text, intime, outtime, gppassnum.Text)

        If recstatus = True Then
            MessageBox("Pass has been updated")
            lblmsg.Text = ""
            txtpurpose.Text = ""
            txtlocation.Text = ""
            txtvehicle.Text = "-1"
            txtvehicle2.Text = ""
            gppassnum.Text = ""
            ddlihr.Text = "-"
            ddlimin.Text = "-"
            ddlohr.Text = "-"
            ddlomin.Text = "-"
            dategp.Text = ""

            btnupdategp.Visible = False
            txtsavegp.Visible = True
            GetGatePassID()
            rno = 0
            If posid < 0 Then
                id = 1
            Else
                id = posid + 1
            End If

            gppassnum.Text = id
            GridView1.DataBind()

        Else
            lblmsg.Text = MyerrorMsg & " Record not saved.."
            lblmsg.ForeColor = Drawing.Color.Red
        End If
    End Sub
    Public Sub gpcancel(ByVal sender As Object, ByVal e As CommandEventArgs)
        Try
            cancelGatePass(e.CommandArgument)
        Catch ex As Exception
            MessageBox(ex.Message)
        End Try
        GridView1.DataBind()
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
                    Dim lstItem As ListItem
                    lstItem = txtvehicle.Items.FindByText(dr("pvehicleno").ToString)

                    If IsNothing(lstItem) Then
                        txtvehicle2.Text = dr("pvehicleno").ToString
                    Else
                        txtvehicle.Text = dr("pvehicleno").ToString
                        txtvehicle2.Text = ""
                    End If

                    ddlihr.Text = Format(Convert.ToDateTime(dr("intime")), "hh")
                    ddlimin.Text = Format(Convert.ToDateTime(dr("intime")), "mm")
                    ddin.SelectedValue = Format(Convert.ToDateTime(dr("intime")), "tt")
                    ddout.SelectedValue = Format(Convert.ToDateTime(dr("outtime")), "tt")
                    ddlohr.Text = Format(Convert.ToDateTime(dr("outtime")), "hh")
                    ddlomin.Text = Format(Convert.ToDateTime(dr("outtime")), "mm")
                    dategp.Text = Format(Convert.ToDateTime(dr("outdate")), "dd/MM/yy")
                    gppassnum.Text = dr("passno").ToString

                End If
            End If

            btnupdategp.Visible = True
            txtsavegp.Visible = False

        Catch ex As Exception
            MessageBox(ex.Message)
        End Try

    End Sub
    Protected Sub sqlgatepass_Selecting(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles sqlgatepass.Selecting
        e.Command.Parameters(0).Value = _eid
        e.Command.Parameters(1).Value = _fisyrStart
        e.Command.Parameters(2).Value = _fisyrEnd
    End Sub
    Protected Sub txtvehicle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtvehicle.SelectedIndexChanged
        If txtvehicle.SelectedValue = "-1" Then
            txtvehicle2.Enabled = True
        Else
            txtvehicle2.Enabled = False
        End If
    End Sub
    Protected Sub ddltype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddltype.SelectedIndexChanged
        If ddltype.SelectedValue = "Prayers" Then

            ddlihr.SelectedValue = "02"
            ddlimin.SelectedValue = "30"
            ddin.SelectedValue = "PM"
            ddlohr.SelectedValue = "01"
            ddlomin.SelectedValue = "00"
            ddout.SelectedValue = "PM"

            ddlihr.Enabled = False
            ddlimin.Enabled = False
            ddin.Enabled = False
            ddlohr.Enabled = False
            ddlomin.Enabled = False
            ddout.Enabled = False
            txtpurpose.Text = "Prayers"
        Else
            ddlihr.Text = "-"
            ddlimin.Text = "-"
            ddlohr.Text = "-"
            ddlomin.Text = "-"
            ddlihr.Enabled = True
            ddlimin.Enabled = True
            ddin.Enabled = True
            ddlohr.Enabled = True
            ddlomin.Enabled = True
            ddout.Enabled = True
            txtpurpose.Text = ""

        End If
    End Sub
End Class