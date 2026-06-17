Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class PayrollLeaveCancel
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim doj As Date
    Dim thisdate As Date
    Dim cancfwd As String
    Dim appno As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        MyApp.GetfiscalYear()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (33)
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


        _eid = Session("empcode")
        _ename = Session("_ename")
        _edept = Session("_edept")
        ' Session("_edept") = "9000"

        thisdate = DateTime.Now

       
        If Not IsPostBack Then
            GrdLeaveCancel.DataBind()
        End If
    End Sub

    Protected Sub SqlLeavecancel_Selecting(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlLeavecancel.Selecting
        e.Command.Parameters(0).Value = _fisyrStart
        e.Command.Parameters(1).Value = _fisyrEnd
    End Sub

    Private Sub GrdLeaveCancel_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrdLeaveCancel.RowCreated
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(0).Visible = False
            e.Row.Cells(9).Visible = False
            e.Row.Cells(10).Visible = False
        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(0).Visible = False
            e.Row.Cells(9).Visible = False
            e.Row.Cells(10).Visible = False
        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(0).Visible = False
            e.Row.Cells(9).Visible = False
            e.Row.Cells(10).Visible = False
        End If
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Public Sub UpdateLeavePRApproval(ByVal sender As Object, ByVal e As EventArgs)

        Dim remain As Decimal
        remain = "0"
        Dim rc As Decimal
        rc = "0"
        Dim nocf As Decimal
        nocf = "0"

        For i As Integer = 0 To GrdLeaveCancel.Rows.Count - 1
            Dim passno As String = GrdLeaveCancel.Rows(i).Cells(0).Text
            '; Dim nocf As Decimal = GrdLeaveCancel.Rows(i).Cells(9).Text
            Dim status As String = DirectCast(GrdLeaveCancel.Rows(i).FindControl("rbprstatus"), RadioButtonList).SelectedValue
            Dim Cfwd As Char = GrdLeaveCancel.Rows(i).Cells(10).Text.Trim
            If Len(Trim(GrdLeaveCancel.Rows(i).Cells(9).Text.Trim)) <> 0 Then
                If Trim(GrdLeaveCancel.Rows(i).Cells(9).Text.Trim) <> "&nbsp;" Then
                    nocf = GrdLeaveCancel.Rows(i).Cells(9).Text
                Else
                    nocf = 0
                End If
            Else
                nocf = 0
            End If
            Dim curMth1 As Integer = Month(thisdate)
            Dim curyear1 As Integer = Year(thisdate)
            If status = "CANCELLED" Then
                UpdateLVRCancel(passno, status)
                If Cfwd = "Y" Then
                    GetCfwdLeave(_eid, curyear1)
                    If recstatus = True Then
                        Dim dr As DataRow
                        If dsdata.Tables(0).Rows.Count > 0 Then
                            dr = dsdata.Tables(0).Rows(0)
                            If dr("remain") Is System.DBNull.Value Then
                                rc = 0
                            Else
                                rc = dr("remain").ToString
                            End If
                        End If
                    Else
                        lblmsg.Text = myerrormsg & " Record not saved..Try again"
                        lblmsg.ForeColor = Drawing.Color.Red
                    End If
                    remain = nocf + rc
                    UpdatecfwdLeave(_eid, Year(thisdate), remain)
                End If
            End If
        Next
        GrdLeaveCancel.Visible = False
        GrdLeaveCancel.DataBind()
    End Sub
    Protected Sub searchgridapp(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click

        Dim str
        str = txtsearchapp.Text.Trim
        If str <> "" Then
            For n As Integer = 0 To GrdLeaveCancel.Rows.Count - 1
                Dim lbn As String = DirectCast(GrdLeaveCancel.Rows(n).FindControl("Labeloremp"), Label).Text
                Dim empname As String = DirectCast(GrdLeaveCancel.Rows(n).FindControl("Labelprname"), Label).Text
                If lbn.ToString.ToLower.Contains(str.ToString.ToLower) = True Or empname.ToString.ToLower.Contains(str.ToString.ToLower) = True Then
                    GrdLeaveCancel.Visible = True
                    GrdLeaveCancel.Rows(n).Visible = True
                    '  GrdLeaveCancel.Rows(n).BackColor = Drawing.Color.Orange
                Else
                    GrdLeaveCancel.Rows(n).Visible = False
                    '  GrdLeaveCancel.Rows(n).BackColor = Drawing.Color.White
                End If
            Next
        End If
    End Sub

    Protected Sub txtsearchapp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearchapp.TextChanged

        Dim str
        str = txtsearchapp.Text.Trim
        If str <> "" Then
            For n As Integer = 0 To GrdLeaveCancel.Rows.Count - 1
                Dim lbn As String = DirectCast(GrdLeaveCancel.Rows(n).FindControl("Labeloremp"), Label).Text
                Dim empname As String = DirectCast(GrdLeaveCancel.Rows(n).FindControl("Labelprname"), Label).Text
                If lbn.ToString.ToLower.Contains(str.ToString.ToLower) = True Or empname.ToString.ToLower.Contains(str.ToString.ToLower) = True Then
                    GrdLeaveCancel.Visible = True
                    GrdLeaveCancel.Rows(n).Visible = True
                    '  GrdLeaveCancel.Rows(n).BackColor = Drawing.Color.Orange
                Else
                    GrdLeaveCancel.Rows(n).Visible = False
                    '  GrdLeaveCancel.Rows(n).BackColor = Drawing.Color.White
                End If
            Next
        End If
    End Sub
End Class