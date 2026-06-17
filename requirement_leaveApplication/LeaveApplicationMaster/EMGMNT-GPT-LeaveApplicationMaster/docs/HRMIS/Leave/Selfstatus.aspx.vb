Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class Selfstatus
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications

    Dim doj As Date
    Dim thisdate As Date
    Dim cancfwd As String
    Dim appno As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyApp.GetfiscalYearforLeave()
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (28)
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

        _eid = Session("empcode")
        _ename = Session("_ename")
        _edept = Session("_edept")

        'Session("_edept") = "9000"
        thisdate = Date.Now

    End Sub
    Protected Sub sqlLeave_Selecting(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles Sqlleave.Selecting
        e.Command.Parameters(0).Value = _eid
        e.Command.Parameters(1).Value = _fisyrStart1
        e.Command.Parameters(2).Value = _fisyrEnd1
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
                e.Row.Cells(7).ForeColor = Drawing.Color.Yellow
                ' e.Row.Cells(0).Attributes.Add("class", "statusclass")
            ElseIf status = "Approved" Or status = "APPROVED" Then
                e.Row.Cells(7).ForeColor = Drawing.Color.Green
            ElseIf status = "Rejected" Or status = "REJECTED" Then
                e.Row.Cells(7).ForeColor = Drawing.Color.Red
            ElseIf status = "CANCELLED" Or status = "C" Then
                e.Row.Cells(7).ForeColor = Drawing.Color.Red
            End If
        End If
    End Sub
    Public Sub getLeaveData(ByVal sender As Object, ByVal e As CommandEventArgs)

        appno = e.CommandArgument
        Session("leaveeditnum") = appno
        Response.Redirect("leaveform.aspx")

    End Sub

    Public Sub leaveprint(ByVal sender As Object, ByVal e As CommandEventArgs)

        appno = e.CommandArgument
        Session("appnumber") = appno
        Response.Redirect("FrmLeaveFormView.aspx")

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
        Else
            lblmsg.Text = MyerrorMsg
            lblmsg.ForeColor = Drawing.Color.Red
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
                Else
                    lblmsg.Text = MyerrorMsg
                    lblmsg.ForeColor = Drawing.Color.Red
                End If

                REMAIN = NOCF + rc
                UpdatecfwdLeave(_eid, Year(thisdate), REMAIN)
            End If

        Catch ex As Exception
            MessageBox(ex.Message)
        End Try
        GridView1.DataBind()


    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
End Class