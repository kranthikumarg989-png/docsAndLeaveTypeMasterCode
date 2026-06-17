Imports System.Data
Imports System.Web.Security
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class TcFMDapproval
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
            MyScreenId = (275)
            If GlobalDsRights.Tables(0).Rows.Count > 0 Then
                For Each row As DataRow In GlobalDsRights.Tables(0).Select("scrid = '" & MyScreenId & "'")
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

    Public Sub UpdateTC(ByVal sender As Object, ByVal e As EventArgs)
        For i As Integer = 0 To GridView1.Rows.Count - 1
            Dim recno As String = GridView1.Rows(i).Cells(0).Text
            Dim status As String = DirectCast(GridView1.Rows(i).FindControl("rbstatus"), RadioButtonList).SelectedValue.Trim
            Dim remarks As String = DirectCast(GridView1.Rows(i).FindControl("txtremarks"), TextBox).Text

            If status = "FMDAPPROVED" Then
                MyGlobal.Open_Con()
                MyGlobal.Con_Str()
                DS = Open_TC(Con, DAP, 2, "update HRMIS_TC_Travellingclaimnew set status = '" & status & "' , fmdapproved = '" & Session("empcode") & "' ,fapprovedtime = getdate(),fmdremarks = '" & remarks & "' where rno = '" & recno & "'")
                MyGlobal.db_close()
            ElseIf status = "FMDREJECTED" Then
                MyGlobal.Open_Con()
                MyGlobal.Con_Str()
                DS = Open_TC(Con, DAP, 2, "update HRMIS_TC_Travellingclaimnew set status = '" & status & "' , fmdremarks = '" & remarks & "' where rno = '" & recno & "'")
                MyGlobal.db_close()
            End If

        Next
        GridView1.DataBind()
    End Sub
    Protected Sub searchgrid2(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim str
        str = txtsearch2.Text.Trim
        If str <> "" Then
            For n As Integer = 0 To GridView1.Rows.Count - 1
                Dim lbn As String = GridView1.Rows(n).Cells(2).Text
                Dim empname As String = GridView1.Rows(n).Cells(3).Text
                Dim dept As String = GridView1.Rows(n).Cells(4).Text
                Dim btno As String = GridView1.Rows(n).Cells(1).Text
                If lbn.ToString.ToLower.Contains(str.ToString.ToLower) = True Or empname.ToString.ToLower.Contains(str.ToString.ToLower) = True Or dept.ToString.ToLower.Contains(str.ToString.ToLower) = True Or btno.ToString.ToLower.Contains(str.ToString.ToLower) = True Then
                    GridView1.Rows(n).Focus()
                    GridView1.Rows(n).BackColor = Drawing.Color.Orange
                Else
                    GridView1.Rows(n).BackColor = Drawing.Color.White
                End If
            Next
        End If
    End Sub

End Class