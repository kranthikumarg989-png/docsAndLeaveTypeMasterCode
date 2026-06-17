Imports System
Imports System.Data
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class letterfinalstatus
    Inherits System.Web.UI.Page
    Dim myglobal As New Emanagement.globalinfo
    Dim myapp As New Emanagement.EMSapplications
    Dim sts, ests, ists As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'session=("_edept")="9000"
        myglobal.Open_Con()
        myglobal.Con_Str()
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
            Else
                stats = "Scheduled"
            End If
            DS = Open_Letter(Con, DAP, 2, "update HRMIS_CMG_MASTER_LETTER set status = '" & stats & " ' where slno='" & slno & "'")
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
            Else
                stats = "ES"
            End If
            DS = Open_Letter(Con, DAP, 2, "update HRMIS_CMG_MASTER_LETTER set status= '" & stats & "' where slno='" & slno & "'")
            myglobal.db_close()
        Next
        GridView2.DataBind()
    End Sub
    Protected Sub UpdategpApproval3(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim gridview1 As GridView
        For i As Integer = 0 To GridView3.Rows.Count - 1
            Dim slno As String = GridView3.Rows(i).Cells(0).Text
            Dim stats As String = DirectCast(GridView3.Rows(i).FindControl("radiobuttonlist3"), RadioButtonList).SelectedValue
            myglobal.Open_Con()
            myglobal.Con_Str()
            If stats = "Approved" Then
                stats = "Approved"
            Else
                stats = "Scheduled"
            End If
            DS = Open_Letter(Con, DAP, 2, "update HRMIS_CMG_MASTER_LETTER set status = '" & stats & " ' where slno='" & slno & "'")
            myglobal.db_close()
        Next
        GridView3.DataBind()
    End Sub
    'Protected Sub SqlDataSource1_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs)
    '    sts = "Scheduled"
    '    e.Command.Parameters(0).Value = sts
    'End Sub
    'Protected Sub SqlDataSource2_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs)
    '    ests = "Approved"
    '    e.Command.Parameters(0).Value = ests
    'End Sub
    'Protected Sub SqlDataSource3_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs)
    '    ists = "Approved"
    '    e.Command.Parameters(0).Value = ists
    'End Sub
End Class