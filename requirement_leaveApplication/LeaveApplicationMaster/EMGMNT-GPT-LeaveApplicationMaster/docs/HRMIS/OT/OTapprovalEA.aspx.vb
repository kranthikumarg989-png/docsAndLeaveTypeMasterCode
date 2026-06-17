Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications

Partial Public Class OTapprovalEA
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim thisdate As Date
    Dim appno As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (64)
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

    Protected Sub EAOTapproval_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class