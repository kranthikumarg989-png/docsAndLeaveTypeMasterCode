Imports System
Imports System.Data
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class MMBT
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim appldate

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (122)
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
        appldate = Date.Now.ToShortDateString
        'MsgBox(appldate)
    End Sub
    Protected Sub SqlDataSource1_Selecting(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlDataSource1.Selecting
        e.Command.Parameters(0).Value = appldate
    End Sub
    Protected Sub SqlDataSource2_Selecting(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlDataSource2.Selecting
        e.Command.Parameters(0).Value = appldate
    End Sub
    Protected Sub SqlDataSource3_Selecting(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlDataSource3.Selecting
        e.Command.Parameters(0).Value = appldate
    End Sub
    Protected Sub SqlDataSource4_Selecting(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlDataSource4.Selecting
        e.Command.Parameters(0).Value = appldate
    End Sub

End Class