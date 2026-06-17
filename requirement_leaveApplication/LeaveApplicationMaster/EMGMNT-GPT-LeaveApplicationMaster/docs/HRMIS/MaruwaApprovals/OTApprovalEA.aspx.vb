Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class OTApprovalEA1
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim thisdate As Date
    Dim appno As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        ' Session("empcode") = "014543"
    End Sub

    Public Sub UpdateOTapproval(ByVal sender As Object, ByVal e As EventArgs)
        For i As Integer = 0 To EAOTapproval.Rows.Count - 1
            Dim id As String = EAOTapproval.Rows(i).Cells(0).Text
            Dim status As String = DirectCast(EAOTapproval.Rows(i).FindControl("OTapprovalStat"), RadioButtonList).SelectedValue
            MyGlobal.Open_Con()
            MyGlobal.Con_Str()
            DS = Open_MaxOTsettings(Con, DAP, 2, "update tbl_MaxOTSetting set status = '" & status & "', approvedby = '" & Session("empcode") & "' ,approvedon = getdate()  where id = '" & id & "'")
            MyGlobal.db_close()
        Next
        EAOTapproval.DataBind()
    End Sub


    Public Sub UpdateOTLighting(ByVal sender As Object, ByVal e As EventArgs)
        For i As Integer = 0 To dgvLighting.Rows.Count - 1
            Dim id As String = dgvLighting.Rows(i).Cells(0).Text
            Dim status As String = DirectCast(dgvLighting.Rows(i).FindControl("OTapprovalStat"), RadioButtonList).SelectedValue
            MyGlobal.Open_Con_lit()
            MyGlobal.Con_Str()
            DS = Open_MaxOTsettings(Con, DAP, 2, "update tbl_MaxOTSetting set status = '" & status & "', approvedby = '" & Session("empcode") & "' ,approvedon = getdate()  where id = '" & id & "'")
            MyGlobal.db_close()
        Next
        dgvLighting.DataBind()
    End Sub

    Public Sub UpdateOTOutSource(ByVal sender As Object, ByVal e As EventArgs)
        For i As Integer = 0 To dgvOutSource.Rows.Count - 1
            Dim id As String = dgvOutSource.Rows(i).Cells(0).Text
            Dim status As String = DirectCast(dgvOutSource.Rows(i).FindControl("OTapprovalStat"), RadioButtonList).SelectedValue
            MyGlobal.Open_Con_out()
            MyGlobal.Con_Str()
            DS = Open_MaxOTsettings(Con, DAP, 2, "update tbl_MaxOTSetting set status = '" & status & "', approvedby = '" & Session("empcode") & "' ,approvedon = getdate()  where id = '" & id & "'")
            MyGlobal.db_close()
        Next
        dgvOutSource.DataBind()
    End Sub


    Public Sub UpdateOTMelaka(ByVal sender As Object, ByVal e As EventArgs)
        For i As Integer = 0 To dgvMelakaMain.Rows.Count - 1
            Dim id As String = dgvMelakaMain.Rows(i).Cells(0).Text
            Dim status As String = DirectCast(dgvMelakaMain.Rows(i).FindControl("OTapprovalStat"), RadioButtonList).SelectedValue
            MyGlobal.Open_Con_mel()
            MyGlobal.Con_Str()
            DS = Open_MaxOTsettings(Con, DAP, 2, "update tbl_MaxOTSetting set status = '" & status & "', approvedby = '" & Session("empcode") & "' ,approvedon = getdate()  where id = '" & id & "'")
            MyGlobal.db_close()
        Next
        dgvMelakaMain.DataBind()
    End Sub

   
    Protected Sub rbOption_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbOption.SelectedIndexChanged
        If rbOption.SelectedValue = "HA" Then
            tdHrmis.Visible = True
            tdLighting.Visible = False
            tdOutSource.Visible = False
            tdMelaka.Visible = False
        ElseIf rbOption.SelectedValue = "LA" Then
            tdHrmis.Visible = False
            tdLighting.Visible = True
            tdOutSource.Visible = False
            tdMelaka.Visible = False
        ElseIf rbOption.SelectedValue = "OA" Then
            tdHrmis.Visible = False
            tdLighting.Visible = False
            tdOutSource.Visible = True
            tdMelaka.Visible = False
        ElseIf rbOption.SelectedValue = "MA" Then
            tdHrmis.Visible = False
            tdLighting.Visible = False
            tdOutSource.Visible = False
            tdMelaka.Visible = True
        Else
            tdHrmis.Visible = True
            tdLighting.Visible = True
            tdOutSource.Visible = True
            tdMelaka.Visible = True
        End If

    End Sub
End Class