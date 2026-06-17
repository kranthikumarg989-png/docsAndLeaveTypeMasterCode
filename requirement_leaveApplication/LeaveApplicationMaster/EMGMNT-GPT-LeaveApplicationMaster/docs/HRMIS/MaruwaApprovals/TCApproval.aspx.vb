Imports System.Data
Imports System.Web.Security
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class TCApproval
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
        Session("empcode") = "014543"
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (59)
            'For Each row As DataRow In GlobalDSRights.Tables(0).Select("scrid = '" & MyScreenId & "'")
            '        MyScreenStat = row("scrstatus").ToString
            '    Next
            'Else
            '    MyScreenStat = 0
            'End If

            'If MyScreenStat = 0 Then
            '    ' MessageBox("Sorry!!! You are not having Access to this screen")
            '    Response.Redirect("~\hrmis\default.aspx")
            'End If
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
            MyGlobal.Open_Con()
            MyGlobal.Con_Str()
            If status = "EAAPPROVED" Then
                DS = Open_TC(Con, DAP, 2, "update HRMIS_TC_Travellingclaimnew set status = '" & status & "' ,paid = 'PAID', eaapproved = '" & Session("empcode") & "' ,eaapprovedtime = getdate(),mdremarks = '" & remarks & "' where rno = '" & recno & "'")
            Else
                DS = Open_TC(Con, DAP, 2, "update HRMIS_TC_Travellingclaimnew set status = '" & status & "' , eaapproved = '" & Session("empcode") & "' ,eaapprovedtime = getdate(),mdremarks = '" & remarks & "' where rno = '" & recno & "'")
            End If
            MyGlobal.db_close()

        Next
        GridView1.DataBind()
    End Sub
    Protected Sub SearchGrid2(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim str
        str = txtsearch2.Text.Trim
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
        End If
    End Sub
    Public Sub UpdateTCLighting(ByVal sender As Object, ByVal e As EventArgs)
        For i As Integer = 0 To dgvLighting.Rows.Count - 1
            Dim recno As String = dgvLighting.Rows(i).Cells(0).Text
            Dim status As String = DirectCast(dgvLighting.Rows(i).FindControl("rbstatus"), RadioButtonList).SelectedValue.Trim
            Dim remarks As String = DirectCast(dgvLighting.Rows(i).FindControl("txtremarks"), TextBox).Text
            MyGlobal.Open_Con_lit()
            MyGlobal.Con_Str()
            If status = "EAAPPROVED" Then
                DS = Open_TC(Con, DAP, 2, "update HRMIS_TC_Travellingclaimnew set status = '" & status & "' ,paid = 'PAID', eaapproved = '" & Session("empcode") & "' ,eaapprovedtime = getdate(),mdremarks = '" & remarks & "' where rno = '" & recno & "'")
            Else
                DS = Open_TC(Con, DAP, 2, "update HRMIS_TC_Travellingclaimnew set status = '" & status & "' , eaapproved = '" & Session("empcode") & "' ,eaapprovedtime = getdate(),mdremarks = '" & remarks & "' where rno = '" & recno & "'")
            End If
            MyGlobal.db_close()

        Next
        dgvLighting.DataBind()
    End Sub
    Protected Sub SearchLighting(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim str
        str = txtLighting.Text.Trim
        If str <> "" Then
            For n As Integer = 0 To dgvLighting.Rows.Count - 1
                Dim lbn As String = dgvLighting.Rows(n).Cells(1).Text
                Dim empname As String = dgvLighting.Rows(n).Cells(2).Text
                If lbn.ToString.ToLower.Contains(str.ToString.ToLower) = True Or empname.ToString.ToLower.Contains(str.ToString.ToLower) = True Then
                    dgvLighting.Rows(n).Focus()
                    dgvLighting.Rows(n).BackColor = Drawing.Color.Orange
                Else
                    dgvLighting.Rows(n).BackColor = Drawing.Color.White
                End If
            Next
        End If
    End Sub
    Public Sub UpdateTCMelaka(ByVal sender As Object, ByVal e As EventArgs)
        For i As Integer = 0 To dgvmelaka.Rows.Count - 1
            Dim recno As String = dgvmelaka.Rows(i).Cells(0).Text
            Dim status As String = DirectCast(dgvmelaka.Rows(i).FindControl("rbstatus"), RadioButtonList).SelectedValue.Trim
            Dim remarks As String = DirectCast(dgvmelaka.Rows(i).FindControl("txtremarks"), TextBox).Text
            MyGlobal.Open_Con_mel()
            MyGlobal.Con_Str()
            If status = "EAAPPROVED" Then
                DS = Open_TC(Con, DAP, 2, "update HRMIS_TC_Travellingclaimnew set status = '" & status & "' ,paid = 'PAID', eaapproved = '" & Session("empcode") & "' ,eaapprovedtime = getdate(),mdremarks = '" & remarks & "' where rno = '" & recno & "'")
            Else
                DS = Open_TC(Con, DAP, 2, "update HRMIS_TC_Travellingclaimnew set status = '" & status & "' , eaapproved = '" & Session("empcode") & "' ,eaapprovedtime = getdate(),mdremarks = '" & remarks & "' where rno = '" & recno & "'")
            End If
            MyGlobal.db_close()

        Next
        dgvmelaka.DataBind()
    End Sub
    Protected Sub SearchMelaka(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim str
        str = txtMelaka.Text.Trim
        If str <> "" Then
            For n As Integer = 0 To dgvmelaka.Rows.Count - 1
                Dim lbn As String = dgvmelaka.Rows(n).Cells(1).Text
                Dim empname As String = dgvmelaka.Rows(n).Cells(2).Text
                If lbn.ToString.ToLower.Contains(str.ToString.ToLower) = True Or empname.ToString.ToLower.Contains(str.ToString.ToLower) = True Then
                    dgvmelaka.Rows(n).Focus()
                    dgvmelaka.Rows(n).BackColor = Drawing.Color.Orange
                Else
                    dgvmelaka.Rows(n).BackColor = Drawing.Color.White
                End If
            Next
        End If
    End Sub
    Protected Sub rbOption_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbOption.SelectedIndexChanged
        If rbOption.SelectedValue = "HA" Then
            tdHrmis.Visible = True
            tdLighting.Visible = False
            tdMelaka.Visible = False
        ElseIf rbOption.SelectedValue = "LA" Then
            tdHrmis.Visible = False
            tdLighting.Visible = True
            tdMelaka.Visible = False
        ElseIf rbOption.SelectedValue = "OA" Then
            tdHrmis.Visible = False
            tdLighting.Visible = False
        ElseIf rbOption.SelectedValue = "MA" Then
            tdHrmis.Visible = False
            tdLighting.Visible = False
            tdMelaka.Visible = True
        Else
            tdHrmis.Visible = True
            tdLighting.Visible = True
            tdMelaka.Visible = True
        End If
    End Sub
End Class