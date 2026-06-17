Imports System
Imports System.Data
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.Emanagement.globalinfo
Imports E_Management.Emanagement.EMSapplications

Partial Public Class MMClinicPass
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim dt As Date
    Dim mydate
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        MyGlobal.Open_Con_mel()
        MyGlobal.Open_Con_lit()
        MyGlobal.Open_Con_out()


        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (120)
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
        Dim ds As New DataSet
        dt = Date.Now
        mydate = dt.ToShortDateString
        For i As Integer = 0 To GridView2.Rows.Count - 1
            Dim sts As String = GridView2.Rows(i).Cells(8).Text.Trim
            If sts = "F" Then
                GridView2.Rows(i).Cells(8).Text = "Approved"
                GridView2.Rows(i).Cells(8).ForeColor = Drawing.Color.Green
            ElseIf sts = "S" Or sts = "S" Then
                GridView2.Rows(i).Cells(8).Text = "Scheduled"
                GridView2.Rows(i).Cells(8).ForeColor = Drawing.Color.Red
            End If

        Next
        For i As Integer = 0 To GridView1.Rows.Count - 1
            Dim sts As String = GridView1.Rows(i).Cells(8).Text.Trim
            If sts = "F" Then
                GridView1.Rows(i).Cells(8).Text = "Approved"
                GridView1.Rows(i).Cells(8).ForeColor = Drawing.Color.Green
            ElseIf sts = "S" Or sts = "S" Then
                GridView1.Rows(i).Cells(8).Text = "Scheduled"
                GridView1.Rows(i).Cells(8).ForeColor = Drawing.Color.Red
            End If

        Next
        For i As Integer = 0 To GridView3.Rows.Count - 1
            Dim sts As String = GridView3.Rows(i).Cells(8).Text.Trim
            If sts = "F" Then
                GridView3.Rows(i).Cells(8).Text = "Approved"
                GridView3.Rows(i).Cells(8).ForeColor = Drawing.Color.Green
            ElseIf sts = "S" Or sts = "S" Then
                GridView3.Rows(i).Cells(8).Text = "Scheduled"
                GridView3.Rows(i).Cells(8).ForeColor = Drawing.Color.Red
            End If

        Next
        For i As Integer = 0 To GridView4.Rows.Count - 1
            Dim sts As String = GridView4.Rows(i).Cells(8).Text.Trim
            If sts = "F" Then
                GridView4.Rows(i).Cells(8).Text = "Approved"
                GridView4.Rows(i).Cells(8).ForeColor = Drawing.Color.Green
            ElseIf sts = "S" Or sts = "S" Then
                GridView4.Rows(i).Cells(8).Text = "Scheduled"
                GridView4.Rows(i).Cells(8).ForeColor = Drawing.Color.Red
            End If

        Next

    End Sub
    Protected Sub SqlDataSource1_Selecting(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlDataSource1.Selecting
        e.Command.Parameters(0).Value = mydate
    End Sub
    Protected Sub MaruwaMelaka_Selecting(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles MaruwaMelaka.Selecting
        e.Command.Parameters(0).Value = mydate
    End Sub
    Protected Sub MaruwaLightings_Selecting(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles MaruwaLightings.Selecting
        e.Command.Parameters(0).Value = mydate
    End Sub
    Protected Sub MaruwaOutsource_Selecting(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles MaruwaOutsource.Selecting
        e.Command.Parameters(0).Value = mydate
    End Sub
    Private Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowDataBound
        For i As Integer = 0 To GridView2.Rows.Count - 1
            If GridView2.Rows(i).Cells(6).Text.Contains("12/30/1899") = True Then
                GridView2.Rows(i).Cells(6).Text = GridView2.Rows(i).Cells(6).Text.Replace("12/30/1899", "")
            ElseIf GridView2.Rows(i).Cells(7).Text.Contains("12/30/1899") = True Then
                GridView2.Rows(i).Cells(7).Text = GridView2.Rows(i).Cells(7).Text.Replace("12/30/1899", "")
            End If
        Next
    End Sub
    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        For i As Integer = 0 To GridView1.Rows.Count - 1
            If GridView1.Rows(i).Cells(6).Text.Contains("12/30/1899") = True Then
                GridView1.Rows(i).Cells(6).Text = GridView1.Rows(i).Cells(6).Text.Replace("12/30/1899", "")
            ElseIf GridView1.Rows(i).Cells(7).Text.Contains("12/30/1899") = True Then
                GridView1.Rows(i).Cells(7).Text = GridView1.Rows(i).Cells(7).Text.Replace("12/30/1899", "")
            End If
        Next
    End Sub
    Private Sub GridView3_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView3.RowDataBound
        For i As Integer = 0 To GridView3.Rows.Count - 1
            If GridView3.Rows(i).Cells(6).Text.Contains("12/30/1899") = True Then
                GridView3.Rows(i).Cells(6).Text = GridView3.Rows(i).Cells(6).Text.Replace("12/30/1899", "")
            ElseIf GridView3.Rows(i).Cells(7).Text.Contains("12/30/1899") = True Then
                GridView3.Rows(i).Cells(7).Text = GridView3.Rows(i).Cells(7).Text.Replace("12/30/1899", "")
            End If
        Next
    End Sub
    Private Sub GridView4_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView4.RowDataBound
        For i As Integer = 0 To GridView4.Rows.Count - 1
            If GridView4.Rows(i).Cells(6).Text.Contains("12/30/1899") = True Then
                GridView4.Rows(i).Cells(6).Text = GridView4.Rows(i).Cells(6).Text.Replace("12/30/1899", "")
            ElseIf GridView4.Rows(i).Cells(7).Text.Contains("12/30/1899") = True Then
                GridView4.Rows(i).Cells(7).Text = GridView4.Rows(i).Cells(7).Text.Replace("12/30/1899", "")
            End If
        Next
    End Sub
End Class