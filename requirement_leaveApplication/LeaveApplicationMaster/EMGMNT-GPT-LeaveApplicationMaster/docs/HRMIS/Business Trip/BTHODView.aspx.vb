Imports System.Data
Imports System.Web.Security
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications

Partial Public Class BTHODView
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Protected Sub SqlBTFMD_Selecting(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlBTFMD.Selecting

    End Sub

    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' Determine the value of the status field
            Dim status As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "btstatus")).Trim
            If status = "scheduled" Or status = "SCHEDULED" Then
                ' color the background of the row yellow
                e.Row.Cells(8).BackColor = Drawing.Color.Orange
                e.Row.Cells(8).Text = "PENDING FOR APPROVAL"
                e.Row.Cells(8).ForeColor = Drawing.Color.Yellow
            ElseIf status = "AEA" Or status = "A" Then
                e.Row.Cells(8).BackColor = Drawing.Color.Orange
                e.Row.Cells(8).Text = "APPROVED"
                e.Row.Cells(8).ForeColor = Drawing.Color.Green
            ElseIf status = "REA" Or status = "R" Then
                e.Row.Cells(8).Text = "REJECTED"
                e.Row.Cells(8).BackColor = Drawing.Color.Orange
                e.Row.Cells(8).ForeColor = Drawing.Color.Red
            End If
        End If
    End Sub
    Public Sub getHistory(ByVal sender As Object, ByVal e As CommandEventArgs)
        Dim recno
        recno = e.CommandArgument
        Response.Redirect("bthistory.aspx?empcode=" & recno & "")
    End Sub

    Private Sub BTHODView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (50)
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
    End Sub
End Class