Imports System.Data
Imports System
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class memostatusview
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (117)
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
    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'determine the value of the status field
            Dim status As String = Trim(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "status")))
            '   Dim label As Label = TryCast(e.Row.FindControl("lbl1"), Label)
            Dim print As LinkButton = TryCast(e.Row.FindControl("print"), LinkButton)
            If status = "R" Or status = "r" Then
                print.Visible = False
            End If
        End If
        For i As Integer = 0 To GridView1.Rows.Count - 1
            Dim sts = GridView1.Rows(i).Cells(7).Text
            If sts = "F" Or sts = "f" Then
                GridView1.Rows(i).Cells(7).Text = "Approved"
                GridView1.Rows(i).Cells(7).ForeColor = Drawing.Color.Green
            ElseIf sts = "R" Or sts = "r" Then
                GridView1.Rows(i).Cells(7).Text = "Rejected"
                GridView1.Rows(i).Cells(7).ForeColor = Drawing.Color.Red
            ElseIf sts = "S" Or sts = "s" Then
                GridView1.Rows(i).Cells(7).Text = "Scheduled"
                GridView1.Rows(i).Cells(7).ForeColor = Drawing.Color.Yellow
            End If
        Next
    End Sub
    Public Sub memoprint(ByVal sender As Object, ByVal e As CommandEventArgs)
        Dim slno As Integer
        Session("slno") = ""
        slno = e.CommandArgument
        Session("slno") = slno
        Server.Transfer("memoreport.aspx")
    End Sub
    '    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
    '        For i As Integer = 0 To GridView1.Rows.Count - 1
    '            Dim sts = GridView1.Rows(i).Cells(7).Text
    '            If sts = "F" Or sts = "f" Then
    '                GridView1.Rows(i).Cells(7).Text = "Approved"
    '                GridView1.Rows(i).Cells(7).ForeColor = Drawing.Color.Green
    '            ElseIf sts = "R" Or sts = "r" Then
    '                GridView1.Rows(i).Cells(7).Text = "Rejected"
    '                GridView1.Rows(i).Cells(7).ForeColor = Drawing.Color.Red
    '            ElseIf sts = "S" Or sts = "s" Then
    '                GridView1.Rows(i).Cells(7).Text = "Scheduled"
    '                GridView1.Rows(i).Cells(7).ForeColor = Drawing.Color.Yellow
    '            End If
    '        Next
    '    End Sub

End Class