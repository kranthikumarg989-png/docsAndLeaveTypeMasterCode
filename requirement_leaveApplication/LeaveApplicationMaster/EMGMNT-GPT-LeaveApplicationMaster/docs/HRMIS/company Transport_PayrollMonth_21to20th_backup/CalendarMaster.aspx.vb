Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class CalendarMaster
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim empcode As String
    Dim rno As Integer
    Dim noi As Integer
    Dim d1, d2, d3, d4, d5, d6, d7, d8, d9, i, counter As Integer
    Dim scode As String
    Dim gcode As String
    Dim sdate As Date
    Dim sd, ed As Date
    Dim a1, a2, a3, a4, a5, a6, a7, a8, a9 As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (99)
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
        MyApp.GetfiscalYear()
    End Sub

    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub BTNSHOW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNSHOW.Click

        DelshiftTemp()

        Dim fd1 As String
        fd1 = txtfrom.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)

        Dim td1 As String
        td1 = txtto.Text.Trim
        Dim strdate2() As String = td1.Split("/"c)
        td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

        Dim td As Date
        td = CDate(td1)


        Dim thisdt As New DateTime
        thisdt = Date.Now.ToShortDateString()

        If fd < thisdt Then
            MessageBox("You cannot do calender setting for PreviousDate")
            Exit Sub
        End If

        If td < fd Then
            MessageBox("Enter Todate greater than from date")
            Exit Sub
        End If

        noi = td.Subtract(fd).Days
        noi = noi + 1
        counter = 0

        Dim strdays As New ArrayList(9)

        If txtd2.Text = "" Then
            txtd2.Text = 0
        End If
        If txtd3.Text = "" Then
            txtd3.Text = 0
        End If
        If txtd4.Text = "" Then
            txtd4.Text = 0
        End If
        If txtd5.Text = "" Then
            txtd5.Text = 0
        End If
        If txtd6.Text = "" Then
            txtd6.Text = 0
        End If
        If txtd7.Text = "" Then
            txtd7.Text = 0
        End If
        If txtd8.Text = "" Then
            txtd8.Text = 0
        End If
        If txtd9.Text = "" Then
            txtd9.Text = 0
        End If
        If txtd1.Text = "" Then
            txtd1.Text = 0
        End If

        d1 = txtd1.Text.Trim
        d2 = txtd2.Text.Trim
        d3 = txtd3.Text.Trim
        d4 = txtd4.Text.Trim
        d5 = txtd5.Text.Trim
        d6 = txtd6.Text.Trim
        d7 = txtd7.Text.Trim
        d8 = txtd8.Text.Trim
        d9 = txtd9.Text.Trim
        ''''''''''###### DAY1

        While counter <= noi

            For a1 = 1 To d1
                If counter >= noi Then
                    GridView1.DataBind()
                    Exit Sub
                Else
                    InsertTempShift(ddlgroup.SelectedValue.Trim, fd, ddls1.SelectedValue.Trim)
                    fd = fd.AddDays(1)
                    counter = counter + 1
                End If
            Next

            ''''''''''###### DAY2
            For a2 = 1 To d2
                If counter >= noi Then
                    GridView1.DataBind()
                    Exit Sub
                Else
                    InsertTempShift(ddlgroup.SelectedValue.Trim, fd, ddls2.SelectedValue.Trim)
                    fd = fd.AddDays(1)
                    counter = counter + 1
                End If
            Next

            ''''''''''###### DAY3
            For a3 = 1 To d3
                If counter >= noi Then
                    GridView1.DataBind()
                    Exit Sub
                Else
                    InsertTempShift(ddlgroup.SelectedValue.Trim, fd, ddls3.SelectedValue.Trim)
                    fd = fd.AddDays(1)
                    counter = counter + 1
                End If
            Next

            ''''''''''###### DAY4
            For a4 = 1 To d4
                If counter >= noi Then
                    GridView1.DataBind()
                    Exit Sub
                Else
                    InsertTempShift(ddlgroup.SelectedValue.Trim, fd, ddls4.SelectedValue.Trim)
                    fd = fd.AddDays(1)
                    counter = counter + 1
                End If
            Next

            ''''''''''###### DAY5
            For a5 = 1 To d5
                If counter >= noi Then
                    GridView1.DataBind()
                    Exit Sub
                Else
                    InsertTempShift(ddlgroup.SelectedValue.Trim, fd, ddls5.SelectedValue.Trim)
                    fd = fd.AddDays(1)
                    counter = counter + 1
                End If
            Next

            ''''''''''###### DAY6
            For a6 = 1 To d6
                If counter >= noi Then
                    GridView1.DataBind()
                    Exit Sub
                Else
                    InsertTempShift(ddlgroup.SelectedValue.Trim, fd, ddls6.SelectedValue.Trim)
                    fd = fd.AddDays(1)
                    counter = counter + 1
                End If
            Next

            ''''''''''###### DAY7
            For a7 = 1 To d7
                If counter >= noi Then
                    GridView1.DataBind()
                    Exit Sub
                Else
                    InsertTempShift(ddlgroup.SelectedValue.Trim, fd, ddls7.SelectedValue.Trim)
                    fd = fd.AddDays(1)
                    counter = counter + 1
                End If
            Next

            ''''''''''###### DAY8
            For a8 = 1 To d8
                If counter >= noi Then
                    GridView1.DataBind()
                    Exit Sub
                Else
                    InsertTempShift(ddlgroup.SelectedValue.Trim, fd, ddls8.SelectedValue.Trim)
                    fd = fd.AddDays(1)
                    counter = counter + 1
                End If
            Next

            ''''''''''###### DAY9
            For a9 = 1 To d9
                If counter >= noi Then
                    GridView1.DataBind()
                    Exit Sub
                Else
                    InsertTempShift(ddlgroup.SelectedValue.Trim, fd, ddls9.SelectedValue.Trim)
                    fd = fd.AddDays(1)
                    counter = counter + 1
                End If
            Next
        End While

        GridView1.DataBind()
    End Sub


    Public Sub InsertShiftDetails(ByVal sender As Object, ByVal e As EventArgs)
        Dim rcount As Integer
        GetTempShift()
        If recstatus = True Then

            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                rcount = dsdata.Tables(0).Rows.Count
                lblmsg.Visible = True
                lblmsg.Text = "Please Wait Till your Data Process"
                For i = 0 To rcount - 1
                    If i = rcount - 1 Then
                        MessageBox("Record Saved")
                    End If
                    dr = dsdata.Tables(0).Rows(i)
                    scode = dr("shiftcode").ToString
                    gcode = dr("groupcode").ToString
                    sdate = dr("shiftdate1").ToString
                    InsertCalender(gcode, sdate, scode)
                Next
            End If
        Else
            lblmsg.Text = MyerrorMsg
        End If
        lblmsg.Text = ""
        lblmsg.Visible = False
        DelshiftTemp()
        GridView1.DataBind()
    End Sub
    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.Footer Then
            Dim btn As Button
            btn = e.Row.FindControl("button1")
            btn.Attributes.Add("onclick", "this.disabled=true;")
        End If
    End Sub
End Class