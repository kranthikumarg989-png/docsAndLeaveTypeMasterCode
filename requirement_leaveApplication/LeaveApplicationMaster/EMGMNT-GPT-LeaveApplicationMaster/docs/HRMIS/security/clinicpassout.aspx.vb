Imports System
Imports System.Data
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.Emanagement.globalinfo
Imports E_Management.Emanagement.EMSapplications
Partial Public Class WebForm1
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim dt As Date
    Dim mydate
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

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

    End Sub
    Protected Sub SqlDataSource1_Selecting(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlDataSource1.Selecting
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
End Class