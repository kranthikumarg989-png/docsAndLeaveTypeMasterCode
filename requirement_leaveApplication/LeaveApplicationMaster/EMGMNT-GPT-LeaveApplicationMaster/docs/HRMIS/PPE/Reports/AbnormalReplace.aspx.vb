Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Partial Public Class AbnormalReplace1
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'connection = ConfigurationManager.ConnectionStrings("Sqlcon1").ConnectionString
        If IsPostBack = False Then
            '------------- Check Access Rights ------------
            If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
                MyScreenId = (371)
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
            '---------- End ---------------------------
        End If
    End Sub
    Protected Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim strScreenId As String
        If rbAbnormal.SelectedValue = "AR" Then
            strScreenId = "AR"
        ElseIf rbAbnormal.SelectedValue = "AL" Then
            strScreenId = "AL"
        End If
        Response.Redirect(String.Format("Income_Stock_Viewer.aspx?EmpId={0}&ScreenId={1}", txtEmp.Text, strScreenId))
    End Sub
End Class