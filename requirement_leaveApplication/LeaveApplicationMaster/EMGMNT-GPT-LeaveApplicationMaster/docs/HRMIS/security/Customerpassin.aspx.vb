Imports System
Imports System.Data
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class Customerpassin
    Inherits System.Web.UI.Page
    Dim dt
    Dim dtd
    Dim status
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Session("_edept") = "9000"
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

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
            'If GridView1.Rows(i).Cells(10).Text = "S" Or GridView1.Rows(i).Cells(10).Text = "Scheduled" Then
            '    DirectCast(GridView1.Rows(i).FindControl("cb1"), CheckBox).Enabled = False
            'End If
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
    End Sub
End Class