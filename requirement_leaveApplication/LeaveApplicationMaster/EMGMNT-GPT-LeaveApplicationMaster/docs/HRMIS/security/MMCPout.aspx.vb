Imports System
Imports System.Data
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class MMCPout
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
        'check access rights
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (124)
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
        'MsgBox(dt)
    End Sub
    Protected Sub UpdategpApproval(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For i As Integer = 0 To GridView1.Rows.Count - 1
            Dim recno As String = GridView1.Rows(i).Cells(0).Text
            Dim cbox As CheckBox = DirectCast(GridView1.Rows(i).FindControl("checkbox1"), CheckBox)
            MyGlobal.Open_Con()
            MyGlobal.Con_Str()
            If cbox.Checked = True Then
                DS = Open_customerpassout(Con, DAP, 2, "update acc_customerapplication set status = 'out', atimeout= '" & dtd & "' where recno = '" & recno & "'")
                MyGlobal.db_close()
            End If
        Next
        GridView1.DataBind()
    End Sub
    Protected Sub UpdategpApprovalmel(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For i As Integer = 0 To GridView2.Rows.Count - 1
            Dim recno As String = GridView2.Rows(i).Cells(0).Text
            Dim cbox As CheckBox = DirectCast(GridView2.Rows(i).FindControl("checkbox1"), CheckBox)
            MyGlobal.Open_Con_mel()
            MyGlobal.Con_Str()
            If cbox.Checked = True Then
                DS = Open_customerpassout(Con, DAP, 2, "update acc_customerapplication set status = 'out', atimeout= '" & dtd & "' where recno = '" & recno & "'")
                MyGlobal.db_close()
            End If
        Next
        GridView2.DataBind()
    End Sub
    Protected Sub UpdategpApprovallit(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For i As Integer = 0 To GridView3.Rows.Count - 1
            Dim recno As String = GridView3.Rows(i).Cells(0).Text
            Dim cbox As CheckBox = DirectCast(GridView3.Rows(i).FindControl("checkbox1"), CheckBox)
            MyGlobal.Open_Con_lit()
            MyGlobal.Con_Str()
            If cbox.Checked = True Then
                DS = Open_customerpassout(Con, DAP, 2, "update acc_customerapplication set status = 'out', atimeout= '" & dtd & "' where recno = '" & recno & "'")
                MyGlobal.db_close()
            End If
        Next
        GridView3.DataBind()
    End Sub
    Protected Sub UpdategpApprovalout(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For i As Integer = 0 To GridView4.Rows.Count - 1
            Dim recno As String = GridView4.Rows(i).Cells(0).Text
            Dim cbox As CheckBox = DirectCast(GridView4.Rows(i).FindControl("checkbox1"), CheckBox)
            MyGlobal.Open_Con_out()
            MyGlobal.Con_Str()
            If cbox.Checked = True Then
                DS = Open_customerpassout(Con, DAP, 2, "update acc_customerapplication set status = 'out', atimeout= '" & dtd & "' where recno = '" & recno & "'")
                MyGlobal.db_close()
            End If
        Next
        GridView4.DataBind()
    End Sub
    Private Sub SqlDataSource1_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlDataSource1.Selecting
        e.Command.Parameters(0).Value = "in"
        e.Command.Parameters(1).Value = dt
    End Sub
    Private Sub MaruwaLightings_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles MaruwaLightings.Selecting
        e.Command.Parameters(0).Value = "in"
        e.Command.Parameters(1).Value = dt
    End Sub

    Private Sub MaruwaOutsource_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles MaruwaOutsource.Selecting
        e.Command.Parameters(0).Value = "in"
        e.Command.Parameters(1).Value = dt
    End Sub
    Private Sub mARUWAmELAKA_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles mARUWAmELAKA.Selecting
        e.Command.Parameters(0).Value = "in"
        e.Command.Parameters(1).Value = dt
    End Sub

End Class