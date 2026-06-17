Imports System
Imports System.Data
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications

Partial Public Class MMCPreturn
    Inherits System.Web.UI.Page
    Dim dt
    Dim dtd
    Dim status
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Session("_edept") = "9000"
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        MyGlobal.Open_Con_mel()
        MyGlobal.Open_Con_lit()
        MyGlobal.Open_Con_out()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (123)
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
        dt = Date.Now.ToShortDateString
        dtd = DateTime.Now.ToShortTimeString
    End Sub
    Protected Sub UpdategpApproval(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For i As Integer = 0 To GridView1.Rows.Count - 1
            Dim recno As String = GridView1.Rows(i).Cells(0).Text
            Dim cbox As CheckBox = DirectCast(GridView1.Rows(i).FindControl("cb1"), CheckBox)
            Dim status As String = GridView1.Rows(i).Cells(10).Text
            If GridView1.Rows(i).Cells(10).Text = "S" Or GridView1.Rows(i).Cells(10).Text = "Scheduled" Then
                DirectCast(GridView1.Rows(i).FindControl("cb1"), CheckBox).Enabled = False
            End If
            If (cbox.Checked = True And status = "A") Then
                MyGlobal.Open_Con()
                MyGlobal.Con_Str()
                DS = Open_customerpassin(Con, DAP, 2, "update acc_customerapplication set status = 'in' ,atimein='" & dtd & "' where recno = '" & recno & "'")
                MyGlobal.db_close()
            End If
        Next
        GridView1.DataBind()
    End Sub
    Private Sub SqlDataSource1_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlDataSource1.Selecting
        e.Command.Parameters(0).Value = "A"
        e.Command.Parameters(1).Value = dt
    End Sub
    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        'For i As Integer = 0 To GridView1.Rows.Count - 1
        '    Dim cbox As CheckBox = DirectCast(GridView1.Rows(i).FindControl("cb1"), CheckBox)
        '    Dim stscell As String = GridView1.Rows(i).Cells(10).Text
        '    If stscell = "S" Or stscell = "Scheduled" Then
        '        DirectCast(GridView1.Rows(i).FindControl("cb1"), CheckBox).Enabled = False
        '        GridView1.Rows(i).Cells(10).ForeColor = Drawing.Color.Orange
        '    ElseIf stscell = "APPROVED" Or stscell = "A" Then
        '        GridView1.Rows(i).Cells(10).ForeColor = Drawing.Color.Green
        '    End If
        'Next
        'If e.Row.RowType = DataControlRowType.DataRow Then
        '    Dim sts As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "status")).Trim
        '    If sts = "A" Or sts = "APPROVED" Or sts = "Approved" Then
        '        'gridview2.Rows(i).Cells(8).ForeColor = Drawing.Color.Green
        '        Dim cb As CheckBox = DirectCast(e.Row.FindControl("checkbox1"), CheckBox)
        '        cb.Enabled = True
        '    ElseIf sts = "S" Or sts = "SCHEDULED" Or sts = "Scheduled" Or sts = "Rejected" Or sts = "REJECTED" Or sts = "R" Then
        '        Dim cb As CheckBox = DirectCast(e.Row.FindControl("checkbox1"), CheckBox)
        '        cb.Enabled = False
        '    End If
        'End If
    End Sub
    Protected Sub UpdategpApprovalmel(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For i As Integer = 0 To GridView2.Rows.Count - 1
            Dim recno As String = GridView2.Rows(i).Cells(0).Text
            Dim cbox As CheckBox = DirectCast(GridView2.Rows(i).FindControl("cb1"), CheckBox)
            Dim status As String = GridView2.Rows(i).Cells(10).Text
            If GridView2.Rows(i).Cells(10).Text = "S" Or GridView2.Rows(i).Cells(10).Text = "Scheduled" Then
                DirectCast(GridView2.Rows(i).FindControl("cb1"), CheckBox).Enabled = False
            End If
            If (cbox.Checked = True And status = "A") Then
                MyGlobal.Open_Con_mel()
                MyGlobal.Con_Str()
                DS = Open_customerpassin(Con, DAP, 2, "update acc_customerapplication set status = 'in' ,atimein='" & dtd & "' where recno = '" & recno & "'")
                MyGlobal.db_close()
            End If
        Next
        GridView2.DataBind()
    End Sub
    Private Sub MaruwaMelaka_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles MaruwaMelaka.Selecting
        e.Command.Parameters(0).Value = "A"
        e.Command.Parameters(1).Value = dt
    End Sub
    Private Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowDataBound
        'For i As Integer = 0 To GridView2.Rows.Count - 1
        '    Dim cbox As CheckBox = DirectCast(GridView2.Rows(i).FindControl("cb1"), CheckBox)
        '    Dim stscell As String = GridView2.Rows(i).Cells(10).Text
        '    If stscell = "S" Or stscell = "Scheduled" Then
        '        DirectCast(GridView2.Rows(i).FindControl("cb1"), CheckBox).Enabled = False
        '        GridView2.Rows(i).Cells(10).ForeColor = Drawing.Color.Orange
        '    ElseIf stscell = "APPROVED" Or stscell = "A" Then
        '        GridView2.Rows(i).Cells(10).ForeColor = Drawing.Color.Green
        '    End If
        'Next
        'If e.Row.RowType = DataControlRowType.DataRow Then
        '    Dim sts As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "status")).Trim
        '    If sts = "A" Or sts = "APPROVED" Or sts = "Approved" Then
        '        'gridview2.Rows(i).Cells(8).ForeColor = Drawing.Color.Green
        '        Dim cb As CheckBox = DirectCast(e.Row.FindControl("checkbox1"), CheckBox)
        '        cb.Enabled = True
        '    ElseIf sts = "S" Or sts = "SCHEDULED" Or sts = "Scheduled" Or sts = "Rejected" Or sts = "REJECTED" Or sts = "R" Then
        '        Dim cb As CheckBox = DirectCast(e.Row.FindControl("checkbox1"), CheckBox)
        '        cb.Enabled = False
        '    End If
        'End If
    End Sub
    Protected Sub UpdategpApprovallit(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For i As Integer = 0 To GridView3.Rows.Count - 1
            Dim recno As String = GridView3.Rows(i).Cells(0).Text
            Dim cbox As CheckBox = DirectCast(GridView3.Rows(i).FindControl("cb1"), CheckBox)
            Dim status As String = GridView3.Rows(i).Cells(10).Text
            If GridView3.Rows(i).Cells(10).Text = "S" Or GridView3.Rows(i).Cells(10).Text = "Scheduled" Then
                DirectCast(GridView3.Rows(i).FindControl("cb1"), CheckBox).Enabled = False
            End If
            If (cbox.Checked = True And status = "A") Then
                MyGlobal.Open_Con_lit()
                MyGlobal.Con_Str()
                DS = Open_customerpassin(Con, DAP, 2, "update acc_customerapplication set status = 'in' ,atimein='" & dtd & "' where recno = '" & recno & "'")
                MyGlobal.db_close()
            End If
        Next
        GridView3.DataBind()
    End Sub
    Private Sub MaruwaLightings_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles MaruwaLightings.Selecting
        e.Command.Parameters(0).Value = "A"
        e.Command.Parameters(1).Value = dt
    End Sub
    Private Sub GridView3_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView3.RowDataBound
        'For i As Integer = 0 To GridView3.Rows.Count - 1
        '    Dim cbox As CheckBox = DirectCast(GridView3.Rows(i).FindControl("cb1"), CheckBox)
        '    Dim stscell As String = GridView3.Rows(i).Cells(10).Text
        '    If stscell = "S" Or stscell = "Scheduled" Then
        '        DirectCast(GridView3.Rows(i).FindControl("cb1"), CheckBox).Enabled = False
        '        GridView3.Rows(i).Cells(10).ForeColor = Drawing.Color.Orange
        '    ElseIf stscell = "APPROVED" Or stscell = "A" Then
        '        GridView3.Rows(i).Cells(10).ForeColor = Drawing.Color.Green
        '    End If
        'Next
        'If e.Row.RowType = DataControlRowType.DataRow Then
        '    Dim sts As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "status")).Trim
        '    If sts = "A" Or sts = "APPROVED" Or sts = "Approved" Then
        '        'GridView3.Rows(i).Cells(8).ForeColor = Drawing.Color.Green
        '        Dim cb As CheckBox = DirectCast(e.Row.FindControl("checkbox1"), CheckBox)
        '        cb.Enabled = True
        '    ElseIf sts = "S" Or sts = "SCHEDULED" Or sts = "Scheduled" Or sts = "Rejected" Or sts = "REJECTED" Or sts = "R" Then
        '        Dim cb As CheckBox = DirectCast(e.Row.FindControl("checkbox1"), CheckBox)
        '        cb.Enabled = False
        '    End If
        'End If
    End Sub
    Protected Sub UpdategpApprovalout(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For i As Integer = 0 To GridView4.Rows.Count - 1
            Dim recno As String = GridView4.Rows(i).Cells(0).Text
            Dim cbox As CheckBox = DirectCast(GridView4.Rows(i).FindControl("cb1"), CheckBox)
            Dim status As String = GridView4.Rows(i).Cells(10).Text
            If GridView4.Rows(i).Cells(10).Text = "S" Or GridView4.Rows(i).Cells(10).Text = "Scheduled" Then
                DirectCast(GridView4.Rows(i).FindControl("cb1"), CheckBox).Enabled = False
            End If
            If (cbox.Checked = True And status = "A") Then
                MyGlobal.Open_Con_out()
                MyGlobal.Con_Str()
                DS = Open_customerpassin(Con, DAP, 2, "update acc_customerapplication set status = 'in' ,atimein='" & dtd & "' where recno = '" & recno & "'")
                MyGlobal.db_close()
            End If
        Next
        GridView4.DataBind()
    End Sub
    Private Sub MaruwaOutsource_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles MaruwaLightings.Selecting
        e.Command.Parameters(0).Value = "A"
        e.Command.Parameters(1).Value = dt
    End Sub
    Private Sub GridView4_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView4.RowDataBound
        'For i As Integer = 0 To GridView4.Rows.Count - 1
        '    Dim cbox As CheckBox = DirectCast(GridView4.Rows(i).FindControl("cb1"), CheckBox)
        '    Dim stscell As String = GridView4.Rows(i).Cells(10).Text
        '    If stscell = "S" Or stscell = "Scheduled" Then
        '        DirectCast(GridView4.Rows(i).FindControl("cb1"), CheckBox).Enabled = False
        '        GridView4.Rows(i).Cells(10).ForeColor = Drawing.Color.Orange
        '    ElseIf stscell = "APPROVED" Or stscell = "A" Then
        '        GridView4.Rows(i).Cells(10).ForeColor = Drawing.Color.Green
        '    End If
        'Next
        'If e.Row.RowType = DataControlRowType.DataRow Then
        '    Dim sts As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "status")).Trim
        '    If sts = "A" Or sts = "APPROVED" Or sts = "Approved" Then
        '        'GridView4.Rows(i).Cells(8).ForeColor = Drawing.Color.Green
        '        Dim cb As CheckBox = DirectCast(e.Row.FindControl("checkbox1"), CheckBox)
        '        cb.Enabled = True
        '    ElseIf sts = "S" Or sts = "SCHEDULED" Or sts = "Scheduled" Or sts = "Rejected" Or sts = "REJECTED" Or sts = "R" Then
        '        Dim cb As CheckBox = DirectCast(e.Row.FindControl("checkbox1"), CheckBox)
        '        cb.Enabled = False
        '    End If
        'End If
    End Sub
End Class