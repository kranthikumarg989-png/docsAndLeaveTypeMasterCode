Imports System.Data
Imports System.Web.Security
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class AdminBt
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
            MyScreenId = (56)
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
    Public Sub UpdateBTADMIN(ByVal sender As Object, ByVal e As EventArgs)
        For i As Integer = 0 To GridView1.Rows.Count - 1
            Dim recno As String = DirectCast(GridView1.Rows(i).FindControl("linkbutton1"), LinkButton).Text
            Dim status As String = DirectCast(GridView1.Rows(i).FindControl("rbstatus"), RadioButtonList).SelectedValue.Trim
            Dim car As String = DirectCast(GridView1.Rows(i).FindControl("dropdownlist1"), DropDownList).SelectedValue.Trim
            MyGlobal.Open_Con()
            MyGlobal.Con_Str()
            DS = Open_BT(Con, DAP, 2, "update acc_businesstrip set ADMINstatus = '" & status & "' ,companycar = '" & car & "'  where recno = '" & recno & "'")
            MyGlobal.db_close()
        Next
        GridView1.DataBind()
    End Sub
End Class