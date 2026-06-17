Imports System
Imports System.Data
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class CMG_letterstatusapprovasl
    Inherits System.Web.UI.Page
    Dim myglobal As New emanagement.globalinfo
    Dim myapp As New emanagement.EMSapplications
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        myglobal.Open_Con()
        myglobal.Con_Str()
    End Sub
    Private Sub GridView1_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.PageIndexChanged
        TabContainer1.ActiveTabIndex = 0
    End Sub
    Private Sub GridView2_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView2.PageIndexChanged
        TabContainer1.ActiveTabIndex = 1
    End Sub
    Protected Sub UpdategpApproval1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim gridview1 As GridView
        For i As Integer = 0 To GridView1.Rows.Count - 1
            Dim slno As String = GridView1.Rows(i).Cells(0).Text
            Dim stats As String = DirectCast(GridView1.Rows(i).FindControl("radiobuttonlist1"), RadioButtonList).SelectedValue
            myglobal.Open_Con()
            myglobal.Con_Str()
            If stats = "Approved" Then
                stats = "Approve"
            ElseIf stats = "Reject" Then
                stats = "Rejected"
            ElseIf stats = "Scheduled" Then
                stats = "Scheduled"
            End If
            DS = Open_Letter(Con, DAP, 2, "update hrmis_cmg_master_letter set status = '" & stats & " ' where slno='" & slno & "'")
            myglobal.db_close()
        Next
        GridView1.DataBind()
    End Sub
    Protected Sub UpdategpApproval2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim gridview1 As GridView
        For i As Integer = 0 To GridView2.Rows.Count - 1
            Dim slno As String = GridView2.Rows(i).Cells(0).Text
            Dim stats As String = DirectCast(GridView2.Rows(i).FindControl("radiobuttonlist2"), RadioButtonList).SelectedValue
            myglobal.Open_Con()
            myglobal.Con_Str()
            If stats = "Approved" Then
                stats = "Approve"
            ElseIf stats = "Reject" Then
                stats = "Rejected"
            ElseIf stats = "ES" Then
                stats = "ES"
            End If
            DS = Open_Letter(Con, DAP, 2, "update hrmis_cmg_master_letter set status = '" & stats & " ' where slno='" & slno & "'")
            myglobal.db_close()
        Next
        GridView2.DataBind()
    End Sub


    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
     
    End Sub
End Class