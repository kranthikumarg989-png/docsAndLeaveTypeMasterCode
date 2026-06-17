Imports System.Data
Imports System
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class CVselfstatus
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim thisdate As Date
    Dim appno As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        'Session("empcode") = "014543"
        'Session("_edept ") = "9000"
        'Session("dept") = "9000"
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (38)
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
        _ename = Session("_ename ")
        _edept = Session("_edept ")

        '_eid = "014543"
        '_ename = "Sathya Vamshi Anigalla"
        '_edept = "9000"

    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Public Sub cvcancel(ByVal sender As Object, ByVal e As CommandEventArgs)
        appno = e.CommandArgument
        Try
            cancelcsPass(e.CommandArgument)
        Catch ex As Exception
            MessageBox(ex.Message)
        End Try
        GrdCVPassStatus.DataBind()
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
                'e.Row.Cells(8).Text = "SCHEDULED"
            ElseIf status = "A" Then
                e.Row.Cells(8).ForeColor = Drawing.Color.Green
                ' e.Row.Cells(8).Text = "APPROVED"
            ElseIf status = "R" Then
                e.Row.Cells(8).ForeColor = Drawing.Color.Red
                ' e.Row.Cells(8).Text = "REJECTED"
            End If
        End If
    End Sub
    Public Sub FncRetreivecpass(ByVal sender As Object, ByVal e As CommandEventArgs)
        appno = e.CommandArgument
        Session("CPeditnum") = appno
        Response.Redirect("CVPASS.aspx")
    End Sub
    Protected Sub sqlcvpass_Selecting(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles sqlcvpass.Selecting
        e.Command.Parameters(0).Value = _eid
    End Sub
End Class