Imports System
Imports System.Data
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class MMHdLeave
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim apdate

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (121)
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
        apdate = Date.Now.ToShortDateString
    End Sub
    Private Sub SqlDataSource1_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlDataSource1.Selecting
        e.Command.Parameters(0).Value = apdate
    End Sub
    Private Sub SqlDataSource2_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlDataSource2.Selecting
        e.Command.Parameters(0).Value = apdate

    End Sub
    Private Sub SqlDataSource3_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlDataSource2.Selecting
        e.Command.Parameters(0).Value = apdate
    End Sub
    Private Sub SqlDataSource4_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlDataSource4.Selecting
        e.Command.Parameters(0).Value = apdate
    End Sub
    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        For i As Integer = 0 To GridView1.Rows.Count - 1
            If GridView1.Rows(i).Cells(9).Text = "S" Then
                GridView1.Rows(i).Cells(9).Text = "SCHEDULED"
                GridView1.Rows(i).Cells(9).ForeColor = Drawing.Color.Orange
            ElseIf GridView1.Rows(i).Cells(9).Text = "APPROVED" Then
                GridView1.Rows(i).Cells(9).ForeColor = Drawing.Color.Green
            End If
        Next
    End Sub

    Private Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowDataBound
        For i As Integer = 0 To GRIDVIEW2.Rows.Count - 1
            If GRIDVIEW2.Rows(i).Cells(9).Text = "S" Then
                GRIDVIEW2.Rows(i).Cells(9).Text = "SCHEDULED"
                GRIDVIEW2.Rows(i).Cells(9).ForeColor = Drawing.Color.Orange
            ElseIf GridView2.Rows(i).Cells(9).Text = "APPROVED" Then
                GridView2.Rows(i).Cells(9).ForeColor = Drawing.Color.Green
            End If
        Next
    End Sub

    Private Sub GridView3_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView3.RowDataBound
        For i As Integer = 0 To GRIDVIEW3.Rows.Count - 1
            If GRIDVIEW3.Rows(i).Cells(9).Text = "S" Then
                GRIDVIEW3.Rows(i).Cells(9).Text = "SCHEDULED"
                GRIDVIEW3.Rows(i).Cells(9).ForeColor = Drawing.Color.Orange
            ElseIf GridView3.Rows(i).Cells(9).Text = "APPROVED" Then
                GridView3.Rows(i).Cells(9).ForeColor = Drawing.Color.Green
            End If
        Next
    End Sub

    Private Sub GridView4_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView4.RowDataBound
        For i As Integer = 0 To GridView4.Rows.Count - 1
            If GridView4.Rows(i).Cells(9).Text = "S" Then
                GridView4.Rows(i).Cells(9).Text = "SCHEDULED"
                GridView4.Rows(i).Cells(9).ForeColor = Drawing.Color.Orange
            ElseIf GridView4.Rows(i).Cells(9).Text = "APPROVED" Then
                GridView4.Rows(i).Cells(9).ForeColor = Drawing.Color.Green
            End If
        Next
    End Sub

End Class