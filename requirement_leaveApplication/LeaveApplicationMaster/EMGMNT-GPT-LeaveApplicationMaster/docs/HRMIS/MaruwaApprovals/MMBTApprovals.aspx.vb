Imports System.Data
Imports System.Web.Security
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class MMBTApprovals
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim doj As Date
    Dim thisdate As Date
    Dim btnum As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (309)
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
        thisdate = DateTime.Now
        thisdate = Month(DateTime.Now) & "/" & Day(DateTime.Now) & "/" & Year(DateTime.Now)
    End Sub
    Public Sub UpdateBTEA(ByVal sender As Object, ByVal e As EventArgs)
        For i As Integer = 0 To GridView1.Rows.Count - 1
            Dim recno As String = DirectCast(GridView1.Rows(i).FindControl("linkbutton1"), LinkButton).Text
            Dim status As String = DirectCast(GridView1.Rows(i).FindControl("rbstatus"), RadioButtonList).SelectedValue.Trim
            MyGlobal.Open_Con()
            MyGlobal.Con_Str()
            DS = Open_BT(Con, DAP, 2, "update acc_businesstrip set btstatus = '" & status & "'  where recno = '" & recno & "'")
            MyGlobal.db_close()
        Next
        GridView1.DataBind()
    End Sub
    Protected Sub searchgridapp(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton5.Click
        Dim str
        str = txtsearchapp.Text.Trim
        If str <> "" Then
            For n As Integer = 0 To GridView1.Rows.Count - 1
                Dim lbn As String = GridView1.Rows(n).Cells(1).Text
                Dim empname As String = GridView1.Rows(n).Cells(2).Text
                If lbn.ToString.ToLower.Contains(str.ToString.ToLower) = True Or empname.ToString.ToLower.Contains(str.ToString.ToLower) = True Then
                    GridView1.Rows(n).Focus()
                    GridView1.Rows(n).BackColor = Drawing.Color.Orange
                Else
                    GridView1.Rows(n).BackColor = Drawing.Color.White
                End If
            Next

            For n As Integer = 0 To dgvLightingMainGrid.Rows.Count - 1
                Dim lbn As String = dgvLightingMainGrid.Rows(n).Cells(1).Text
                Dim empname As String = dgvLightingMainGrid.Rows(n).Cells(2).Text
                If lbn.ToString.ToLower.Contains(str.ToString.ToLower) = True Or empname.ToString.ToLower.Contains(str.ToString.ToLower) = True Then
                    dgvLightingMainGrid.Rows(n).Focus()
                    dgvLightingMainGrid.Rows(n).BackColor = Drawing.Color.Orange
                Else
                    dgvLightingMainGrid.Rows(n).BackColor = Drawing.Color.White
                End If
            Next

            For n As Integer = 0 To dgvMalakaMainGrid.Rows.Count - 1
                Dim lbn As String = dgvOutSourceMainGrid.Rows(n).Cells(1).Text
                Dim empname As String = dgvMalakaMainGrid.Rows(n).Cells(2).Text
                If lbn.ToString.ToLower.Contains(str.ToString.ToLower) = True Or empname.ToString.ToLower.Contains(str.ToString.ToLower) = True Then
                    dgvMalakaMainGrid.Rows(n).Focus()
                    dgvMalakaMainGrid.Rows(n).BackColor = Drawing.Color.Orange
                Else
                    dgvMalakaMainGrid.Rows(n).BackColor = Drawing.Color.White
                End If
            Next
        End If
    End Sub
    Public Sub UpdateBTLighting(ByVal sender As Object, ByVal e As EventArgs)
        For i As Integer = 0 To dgvLightingMainGrid.Rows.Count - 1
            Dim recno As String = DirectCast(dgvLightingMainGrid.Rows(i).FindControl("linkbutton1"), LinkButton).Text
            Dim status As String = DirectCast(dgvLightingMainGrid.Rows(i).FindControl("rbstatus"), RadioButtonList).SelectedValue.Trim
            MyGlobal.Open_Con_lit()
            MyGlobal.Con_Str()
            DS = Open_BT(Con, DAP, 2, "update acc_businesstrip set btstatus = '" & status & "'  where recno = '" & recno & "'")
            MyGlobal.db_close()
        Next
        dgvLightingMainGrid.DataBind()
    End Sub
    Public Sub UpdateBTOutSourceing(ByVal sender As Object, ByVal e As EventArgs)
        For i As Integer = 0 To dgvOutSourceMainGrid.Rows.Count - 1
            Dim recno As String = DirectCast(dgvOutSourceMainGrid.Rows(i).FindControl("linkbutton1"), LinkButton).Text
            Dim status As String = DirectCast(dgvOutSourceMainGrid.Rows(i).FindControl("rbstatus"), RadioButtonList).SelectedValue.Trim
            MyGlobal.Open_Con_out()
            MyGlobal.Con_Str()
            DS = Open_BT(Con, DAP, 2, "update acc_businesstrip set btstatus = '" & status & "'  where recno = '" & recno & "'")
            MyGlobal.db_close()
        Next
        dgvOutSourceMainGrid.DataBind()
    End Sub
    'Protected Sub SearchOutSourceGridapp(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton3.Click, ImageButton3.Click
    '    Dim str
    '    str = txtOutSourceSearch.Text.Trim
    '    If str <> "" Then
    '        For n As Integer = 0 To dgvOutSourceMainGrid.Rows.Count - 1
    '            Dim lbn As String = dgvOutSourceMainGrid.Rows(n).Cells(1).Text
    '            Dim empname As String = dgvOutSourceMainGrid.Rows(n).Cells(2).Text
    '            If lbn.ToString.ToLower.Contains(str.ToString.ToLower) = True Or empname.ToString.ToLower.Contains(str.ToString.ToLower) = True Then
    '                dgvOutSourceMainGrid.Rows(n).Focus()
    '                dgvOutSourceMainGrid.Rows(n).BackColor = Drawing.Color.Orange
    '            Else
    '                dgvOutSourceMainGrid.Rows(n).BackColor = Drawing.Color.White
    '            End If
    '        Next
    '    End If
    ' End Sub

    Public Sub UpdateBTMelaka(ByVal sender As Object, ByVal e As EventArgs)
        For i As Integer = 0 To dgvMalakaMainGrid.Rows.Count - 1
            Dim recno As String = DirectCast(dgvMalakaMainGrid.Rows(i).FindControl("linkbutton1"), LinkButton).Text
            Dim status As String = DirectCast(dgvMalakaMainGrid.Rows(i).FindControl("rbstatus"), RadioButtonList).SelectedValue.Trim
            MyGlobal.Open_Con_mel()
            MyGlobal.Con_Str()
            DS = Open_BT(Con, DAP, 2, "update acc_businesstrip set btstatus = '" & status & "'  where recno = '" & recno & "'")
            MyGlobal.db_close()
        Next
        dgvMalakaMainGrid.DataBind()
    End Sub

    Protected Sub rbMainOption_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbMainOption.SelectedIndexChanged
        If rbMainOption.SelectedValue = "HA" Then
            Panel1.Visible = True
            PanelLighting.Visible = False
            PanelMelaka.Visible = False
        ElseIf rbMainOption.SelectedValue = "LA" Then
            Panel1.Visible = False
            PanelLighting.Visible = True
            PanelOutSource.Visible = False
            PanelMelaka.Visible = False
        ElseIf rbMainOption.SelectedValue = "OA" Then
            Panel1.Visible = False
            PanelLighting.Visible = False
            PanelMelaka.Visible = False
        ElseIf rbMainOption.SelectedValue = "MA" Then
            Panel1.Visible = False
            PanelLighting.Visible = False
            PanelMelaka.Visible = True
        Else
            Panel1.Visible = True
            PanelLighting.Visible = True
            PanelMelaka.Visible = True
        End If
    End Sub
End Class

