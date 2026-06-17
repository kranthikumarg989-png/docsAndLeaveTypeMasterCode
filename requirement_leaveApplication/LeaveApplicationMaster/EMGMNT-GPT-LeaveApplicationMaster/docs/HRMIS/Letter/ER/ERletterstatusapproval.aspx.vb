Imports System
Imports System.Data
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class ERletterstatusapproval
    Inherits System.Web.UI.Page
    Dim myglobal As New Emanagement.globalinfo
    Dim myapp As New Emanagement.EMSapplications
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        myglobal.Open_Con()
        myglobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (187)
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
    Protected Sub UpdategpApproval1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim gridview1 As GridView
        For i As Integer = 0 To GridView1.Rows.Count - 1
            Dim slno As String = GridView1.Rows(i).Cells(0).Text
            Dim stats As String = DirectCast(GridView1.Rows(i).FindControl("radiobuttonlist1"), RadioButtonList).SelectedValue
            myglobal.Open_Con()
            myglobal.Con_Str()
            If stats = "Approved" Then
                stats = "Approved"
            ElseIf stats = "Scheduled" Then
                stats = "Scheduled"
            ElseIf stats = "Rejected" Then
                stats = "Rejected"
            End If
            DS = Open_Letter(Con, DAP, 2, "update hrmis_er_master_letter set status = '" & stats & " ' where slno='" & slno & "'")
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
                stats = "Approved"
            ElseIf stats = "ES" Then
                stats = "ES"
            ElseIf stats = "Rejected" Then
                stats = "Rejected"
            End If
            DS = Open_Letter(Con, DAP, 2, "update hrmis_er_master_letter set status = '" & stats & " ' where slno='" & slno & "'")
            myglobal.db_close()
        Next
        GridView2.DataBind()
    End Sub
    Protected Sub UpdategpApproval3(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim gridview1 As GridView
        For i As Integer = 0 To GridView3.Rows.Count - 1
            Dim lname As String = GridView3.Rows(i).Cells(1).Text
            Dim slno As String = GridView3.Rows(i).Cells(0).Text
            Dim stats As String = DirectCast(GridView3.Rows(i).FindControl("radiobuttonlist3"), RadioButtonList).SelectedValue
            myglobal.Open_Con()
            myglobal.Con_Str()
      
            DS = Open_Letter(Con, DAP, 2, "update HRMIS_ER_MASTER_LETTER_SAVE set status = '" & stats & " ' where sno='" & slno & "'")
            myglobal.db_close()
        Next
        GridView3.DataBind()
    End Sub
    Private Sub GridView1_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.PageIndexChanged
        TabContainer1.ActiveTabIndex = 0
    End Sub
    Private Sub GridView2_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView2.PageIndexChanged
        TabContainer1.ActiveTabIndex = 1
    End Sub
    Private Sub GridView3_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView3.PageIndexChanged
        TabContainer1.ActiveTabIndex = 2
    End Sub
    Private Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        TabContainer1.ActiveTabIndex = 0
    End Sub
    Private Sub GridView2_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView2.Sorting
        TabContainer1.ActiveTabIndex = 1
    End Sub
    Private Sub GridView3_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView3.Sorting
        TabContainer1.ActiveTabIndex = 2
    End Sub
End Class