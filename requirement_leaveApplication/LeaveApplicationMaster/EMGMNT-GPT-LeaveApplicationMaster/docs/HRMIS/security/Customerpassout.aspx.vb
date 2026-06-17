Imports System
Imports System.Data
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class Customerpassout
    Inherits System.Web.UI.Page
    Dim dt
    Dim dtd
    Dim status
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Session("_edept") = "9000"
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

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
    Private Sub SqlDataSource1_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlDataSource1.Selecting
        e.Command.Parameters(0).Value = "in"
        e.Command.Parameters(1).Value = dt
    End Sub
   

End Class