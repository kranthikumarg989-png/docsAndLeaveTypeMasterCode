Imports System.Data
Imports System.Web.Security
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class BTFMDView
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim doj As Date
    Dim thisdate As Date
    Dim btnum As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (53)
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

    Public Sub UpdateBTFMD(ByVal sender As Object, ByVal e As EventArgs)
        For i As Integer = 0 To GridView1.Rows.Count - 1
            Dim recno As String = GridView1.Rows(i).Cells(1).Text
            Dim view As String = GridView1.Rows(i).Cells(2).Text.Trim
            Dim advance = GridView1.Rows(i).Cells(7).Text.Trim
            Dim status As String = DirectCast(GridView1.Rows(i).FindControl("rbstatus"), RadioButtonList).SelectedValue.Trim

            If status = "Closed" Or status = "CLOSED" Then
                If view = "N" Then
                    MyGlobal.Open_Con()
                    MyGlobal.Con_Str()
                    DS = Open_BT(Con, DAP, 2, "update acc_businesstrip set sanctioned = '" & advance & "' , accountsview = '" & status & "',accountsviewdate = '" & thisdate & "' where recno = '" & recno & "'")
                    MyGlobal.db_close()
                ElseIf view = "Y" Then
                    MyGlobal.Open_Con()
                    MyGlobal.Con_Str()
                    DS = Open_BT(Con, DAP, 2, "update acc_businesstrip set accountsview = '" & status & "' ,accountsviewdate = '" & thisdate & "' where recno = '" & recno & "'")
                    MyGlobal.db_close()
                End If
            End If
            If status = "Y" Then
                If view = "N" Then
                    MyGlobal.Open_Con()
                    MyGlobal.Con_Str()
                    DS = Open_BT(Con, DAP, 2, "update acc_businesstrip set sanctioned = '" & advance & "' , accountsview = '" & status & "',accountsviewdate = '" & thisdate & "' where recno = '" & recno & "'")
                    MyGlobal.db_close()
                ElseIf view = "Y" Then
                    MyGlobal.Open_Con()
                    MyGlobal.Con_Str()
                    DS = Open_BT(Con, DAP, 2, "update acc_businesstrip set accountsview = '" & status & "' ,accountsviewdate = '" & thisdate & "' where recno = '" & recno & "'")
                    MyGlobal.db_close()
                End If
            End If
           
        Next
        GridView1.DataBind()
    End Sub

    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'determine the value of the status field
            Dim status As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "BTstatus")).Trim
        
            If status = "scheduled" Or status = "SCHEDULED" Then
                e.Row.Cells(11).ForeColor = Drawing.Color.Yellow
                e.Row.Cells(11).Text = "SCHEDULED"
                e.Row.Cells(12).Enabled = False
            ElseIf status = "AEA" Then
                e.Row.Cells(11).ForeColor = Drawing.Color.Green
                e.Row.Cells(11).Text = "APPROVED"
                e.Row.Cells(12).Enabled = True
            End If
        End If
    End Sub
    Protected Sub searchgridapp(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click, ImageButton2.Click
        Dim str
        str = txtsearchapp.Text.Trim
        If str <> "" Then
            For n As Integer = 0 To GridView1.Rows.Count - 1
                Dim lbn As String = DirectCast(GridView1.Rows(n).FindControl("Label1"), Label).Text
                Dim empname As String = DirectCast(GridView1.Rows(n).FindControl("Label4"), Label).Text
                Dim btno As String = GridView1.Rows(n).Cells(1).Text
                If lbn.ToString.ToLower.Contains(str.ToString.ToLower) = True Or empname.ToString.ToLower.Contains(str.ToString.ToLower) = True Or btno.ToString.ToLower.Contains(str.ToString.ToLower) = True Then
                    GridView1.Rows(n).Focus()
                    GridView1.Rows(n).BackColor = Drawing.Color.Orange
                Else
                    GridView1.Rows(n).BackColor = Drawing.Color.White
                End If
            Next
        End If
    End Sub
End Class