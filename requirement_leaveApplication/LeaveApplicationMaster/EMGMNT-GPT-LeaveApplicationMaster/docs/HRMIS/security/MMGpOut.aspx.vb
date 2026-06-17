Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications

Partial Public Class MMGpOut
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim doj As Date
    Dim thisdate As Date
    Dim cancfwd As String
    Dim appno As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        MyGlobal.Open_Con_mel()
        MyGlobal.Open_Con_lit()
        MyGlobal.Open_Con_out()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (118)
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
    Protected Sub UpdategpApproval(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'thisdate = DateTime.Now.ToShortTimeString
        For i As Integer = 0 To GridView1.Rows.Count - 1
            Dim passno As String = GridView1.Rows(i).Cells(0).Text
            'Dim sts As String = GridView1.Rows(i).Cells(9).Text
            Dim cb As CheckBox = DirectCast(GridView1.Rows(i).FindControl("checkbox1"), CheckBox)
            Dim speed As String = DirectCast(GridView1.Rows(i).FindControl("textbox1"), TextBox).Text
            Dim hrs As DropDownList = DirectCast(GridView1.Rows(i).FindControl("hrs1"), DropDownList)
            Dim mints As DropDownList = DirectCast(GridView1.Rows(i).FindControl("mints1"), DropDownList)
            Dim ampm As DropDownList = DirectCast(GridView1.Rows(i).FindControl("ampm1"), DropDownList)
            Dim stat = DirectCast(GridView1.Rows(i).FindControl("lbl1"), Label)


            Dim tin As String = hrs.SelectedValue.Trim & ":" & mints.SelectedValue.Trim & ampm.SelectedValue.Trim
            MyGlobal.Open_Con()
            MyGlobal.Con_Str()
            If cb.checked = True Then
                DS = Open_gatepassreturn(Con, DAP, 2, "update staffgatepass set status = 'OUT', atimeout = '" & tin & "',speedofmeter='" & speed & "' where passno = '" & passno & "'")
                MyGlobal.db_close()
            End If
        Next
        GridView1.DataBind()
    End Sub
    Protected Sub UpdategpApprovalMelaka(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'thisdate = DateTime.Now.ToShortTimeString
        For i As Integer = 0 To GridView4.Rows.Count - 1
            Dim passno As String = GridView4.Rows(i).Cells(0).Text
            'Dim sts As String = GridView1.Rows(i).Cells(9).Text
            Dim cb As CheckBox = DirectCast(GridView4.Rows(i).FindControl("checkbox1"), CheckBox)
            Dim speed As String = DirectCast(GridView4.Rows(i).FindControl("textbox1"), TextBox).Text
            Dim hrs As DropDownList = DirectCast(GridView4.Rows(i).FindControl("hrs1"), DropDownList)
            Dim mints As DropDownList = DirectCast(GridView4.Rows(i).FindControl("mints1"), DropDownList)
            Dim ampm As DropDownList = DirectCast(GridView4.Rows(i).FindControl("ampm1"), DropDownList)

            Dim tin As String = hrs.SelectedValue.Trim & ":" & mints.SelectedValue.Trim & ampm.SelectedValue.Trim
            MyGlobal.Open_Con_mel()
            MyGlobal.Con_Str()
            If cb.Checked = True Then
                DS = Open_gatepassreturn(Con, DAP, 2, "update staffgatepass set status = 'OUT', atimeout = '" & tin & "',speedofmeter='" & speed & "' where passno = '" & passno & "'")
                MyGlobal.db_close()
            End If
        Next
        GridView4.DataBind()
    End Sub
    Protected Sub UpdategpApprovalLightings(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'thisdate = DateTime.Now.ToShortTimeString
        For i As Integer = 0 To GridView3.Rows.Count - 1
            Dim passno As String = GridView3.Rows(i).Cells(0).Text
            'Dim sts As String = GridView1.Rows(i).Cells(9).Text
            Dim cb As CheckBox = DirectCast(GridView3.Rows(i).FindControl("checkbox1"), CheckBox)
            Dim speed As String = DirectCast(GridView3.Rows(i).FindControl("textbox1"), TextBox).Text
            Dim hrs As DropDownList = DirectCast(GridView3.Rows(i).FindControl("hrs1"), DropDownList)
            Dim mints As DropDownList = DirectCast(GridView3.Rows(i).FindControl("mints1"), DropDownList)
            Dim ampm As DropDownList = DirectCast(GridView3.Rows(i).FindControl("ampm1"), DropDownList)

            Dim tin As String = hrs.SelectedValue.Trim & ":" & mints.SelectedValue.Trim & ampm.SelectedValue.Trim
            MyGlobal.Open_Con_lit()
            MyGlobal.Con_Str()
            If cb.Checked = True Then
                DS = Open_gatepassreturn(Con, DAP, 2, "update staffgatepass set status = 'OUT', atimeout = '" & tin & "',speedofmeter='" & speed & "' where passno = '" & passno & "'")
                MyGlobal.db_close()
            End If
        Next
        GridView3.DataBind()
    End Sub
    Protected Sub UpdategpApprovalOutsource(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'thisdate = DateTime.Now.ToShortTimeString
        For i As Integer = 0 To GridView2.Rows.Count - 1
            Dim passno As String = GridView2.Rows(i).Cells(0).Text
            'Dim sts As String = GridView1.Rows(i).Cells(9).Text
            Dim cb As CheckBox = DirectCast(GridView2.Rows(i).FindControl("checkbox1"), CheckBox)
            Dim speed As String = DirectCast(GridView2.Rows(i).FindControl("textbox1"), TextBox).Text
            Dim hrs As DropDownList = DirectCast(GridView2.Rows(i).FindControl("hrs1"), DropDownList)
            Dim mints As DropDownList = DirectCast(GridView2.Rows(i).FindControl("mints1"), DropDownList)
            Dim ampm As DropDownList = DirectCast(GridView2.Rows(i).FindControl("ampm1"), DropDownList)

            Dim tin As String = hrs.SelectedValue.Trim & ":" & mints.SelectedValue.Trim & ampm.SelectedValue.Trim
            MyGlobal.Open_Con_out()
            MyGlobal.Con_Str()
            If cb.Checked = True Then
                DS = Open_gatepassreturn(Con, DAP, 2, "update staffgatepass set status = 'OUT', atimeout = '" & tin & "',speedofmeter='" & speed & "' where passno = '" & passno & "'")
                MyGlobal.db_close()
            End If
        Next
        GridView2.DataBind()
    End Sub

    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        Dim i As Integer
        For i = 0 To GridView1.Rows.Count - 1
            Dim sts As String = GridView1.Rows(i).Cells(10).Text
            Dim ab As String = GridView1.Rows(i).Cells(10).Text
            Dim rt = GridView1.Rows(i).Cells(8).Text
            Dim rts = GridView1.Rows(i).Cells(11).Text
            Dim rts1 = GridView1.Rows(i).Cells(7).Text

            'If e.Row.RowType = DataControlRowType.DataRow AndAlso e.Row.RowState = DataControlRowState.Normal Then
            '    Dim LinkButton1 = DirectCast(e.Row.FindControl("LinkButton1"), LinkButton)
            '    'Or some other logic, like converting to a boolean
            '    LinkButton1.Enabled = GridView1.DataKeys(e.Row.RowIndex).Value = "SomeValue"
            'End If

            If sts = "A" Or sts = "APPROVED" Or sts = "Approved" Then
                GridView1.Rows(i).Cells(8).ForeColor = Drawing.Color.Green
                'Dim cb As CheckBox = DirectCast(e.Row.FindControl("checkbox1"), CheckBox)
                'cb.Enabled = True
            ElseIf sts = "S" Or sts = "SCHEDULED" Or sts = "Scheduled" Or sts = "Rejected" Or sts = "REJECTED" Or sts = "R" Then
                'Dim cb As CheckBox = DirectCast(e.Row.FindControl("checkbox1"), CheckBox)
                'cb.Enabled = False
            End If

            If DateTime.Now.Hour > 12 And DateTime.Now.Hour < 24 Then
                Dim hr As String = DateTime.Now.Hour - 12
                DirectCast(GridView1.Rows(i).FindControl("hrs1"), DropDownList).SelectedValue = hr
            Else
                DirectCast(GridView1.Rows(i).FindControl("hrs1"), DropDownList).SelectedValue = DateTime.Now.Hour
            End If
            DirectCast(GridView1.Rows(i).FindControl("mints1"), DropDownList).SelectedValue = DateTime.Now.Minute
            If DateTime.Now.ToShortTimeString.Contains("AM") = True Then
                DirectCast(GridView1.Rows(i).FindControl("ampm1"), DropDownList).SelectedValue = "AM"
            Else
                DirectCast(GridView1.Rows(i).FindControl("ampm1"), DropDownList).SelectedValue = "PM"
            End If
        Next
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim sts As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "status")).Trim
            If sts = "A" Or sts = "APPROVED" Or sts = "Approved" Then
                'GridView1.Rows(i).Cells(8).ForeColor = Drawing.Color.Green
                Dim cb As CheckBox = DirectCast(e.Row.FindControl("checkbox1"), CheckBox)
                cb.Enabled = True
            ElseIf sts = "S" Or sts = "SCHEDULED" Or sts = "Scheduled" Or sts = "Rejected" Or sts = "REJECTED" Or sts = "R" Then
                Dim cb As CheckBox = DirectCast(e.Row.FindControl("checkbox1"), CheckBox)
                cb.Enabled = False
            End If
        End If
    End Sub
    Private Sub GridView3_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView3.RowDataBound
        Dim i As Integer
        For i = 0 To GridView3.Rows.Count - 1
            Dim sts As String = GridView3.Rows(i).Cells(10).Text
            Dim ab As String = GridView3.Rows(i).Cells(10).Text
            Dim rt = GridView3.Rows(i).Cells(8).Text
            Dim rts = GridView3.Rows(i).Cells(11).Text
            Dim rts1 = GridView3.Rows(i).Cells(7).Text

            'If e.Row.RowType = DataControlRowType.DataRow AndAlso e.Row.RowState = DataControlRowState.Normal Then
            '    Dim LinkButton1 = DirectCast(e.Row.FindControl("LinkButton1"), LinkButton)
            '    'Or some other logic, like converting to a boolean
            '    LinkButton1.Enabled = gridview3.DataKeys(e.Row.RowIndex).Value = "SomeValue"
            'End If

            If sts = "A" Or sts = "APPROVED" Or sts = "Approved" Then
                GridView3.Rows(i).Cells(8).ForeColor = Drawing.Color.Green
                'Dim cb As CheckBox = DirectCast(e.Row.FindControl("checkbox1"), CheckBox)
                'cb.Enabled = True
            ElseIf sts = "S" Or sts = "SCHEDULED" Or sts = "Scheduled" Or sts = "Rejected" Or sts = "REJECTED" Or sts = "R" Then
                'Dim cb As CheckBox = DirectCast(e.Row.FindControl("checkbox1"), CheckBox)
                'cb.Enabled = False
            End If

            If DateTime.Now.Hour > 12 And DateTime.Now.Hour < 24 Then
                Dim hr As String = DateTime.Now.Hour - 12
                DirectCast(GridView3.Rows(i).FindControl("hrs1"), DropDownList).SelectedValue = hr
            Else
                DirectCast(GridView3.Rows(i).FindControl("hrs1"), DropDownList).SelectedValue = DateTime.Now.Hour
            End If
            DirectCast(GridView3.Rows(i).FindControl("mints1"), DropDownList).SelectedValue = DateTime.Now.Minute
            If DateTime.Now.ToShortTimeString.Contains("AM") = True Then
                DirectCast(GridView3.Rows(i).FindControl("ampm1"), DropDownList).SelectedValue = "AM"
            Else
                DirectCast(GridView3.Rows(i).FindControl("ampm1"), DropDownList).SelectedValue = "PM"
            End If
        Next
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim sts As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "status")).Trim
            If sts = "A" Or sts = "APPROVED" Or sts = "Approved" Then
                'GridView3.Rows(i).Cells(8).ForeColor = Drawing.Color.Green
                Dim cb As CheckBox = DirectCast(e.Row.FindControl("checkbox1"), CheckBox)
                cb.Enabled = True
            ElseIf sts = "S" Or sts = "SCHEDULED" Or sts = "Scheduled" Or sts = "Rejected" Or sts = "REJECTED" Or sts = "R" Then
                Dim cb As CheckBox = DirectCast(e.Row.FindControl("checkbox1"), CheckBox)
                cb.Enabled = False
            End If
        End If
    End Sub
    Private Sub gridview4_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView4.RowDataBound
        Dim i As Integer
        For i = 0 To GridView4.Rows.Count - 1
            Dim sts As String = GridView4.Rows(i).Cells(10).Text
            Dim ab As String = GridView4.Rows(i).Cells(10).Text
            Dim rt = GridView4.Rows(i).Cells(8).Text
            Dim rts = GridView4.Rows(i).Cells(11).Text
            Dim rts1 = GridView4.Rows(i).Cells(7).Text

            'If e.Row.RowType = DataControlRowType.DataRow AndAlso e.Row.RowState = DataControlRowState.Normal Then
            '    Dim LinkButton1 = DirectCast(e.Row.FindControl("LinkButton1"), LinkButton)
            '    'Or some other logic, like converting to a boolean
            '    LinkButton1.Enabled = gridview4.DataKeys(e.Row.RowIndex).Value = "SomeValue"
            'End If

            If sts = "A" Or sts = "APPROVED" Or sts = "Approved" Then
                GridView4.Rows(i).Cells(8).ForeColor = Drawing.Color.Green
                'Dim cb As CheckBox = DirectCast(e.Row.FindControl("checkbox1"), CheckBox)
                'cb.Enabled = True
            ElseIf sts = "S" Or sts = "SCHEDULED" Or sts = "Scheduled" Or sts = "Rejected" Or sts = "REJECTED" Or sts = "R" Then
                'Dim cb As CheckBox = DirectCast(e.Row.FindControl("checkbox1"), CheckBox)
                'cb.Enabled = False
            End If

            If DateTime.Now.Hour > 12 And DateTime.Now.Hour < 24 Then
                Dim hr As String = DateTime.Now.Hour - 12
                DirectCast(GridView4.Rows(i).FindControl("hrs1"), DropDownList).SelectedValue = hr
            Else
                DirectCast(GridView4.Rows(i).FindControl("hrs1"), DropDownList).SelectedValue = DateTime.Now.Hour
            End If
            DirectCast(GridView4.Rows(i).FindControl("mints1"), DropDownList).SelectedValue = DateTime.Now.Minute
            If DateTime.Now.ToShortTimeString.Contains("AM") = True Then
                DirectCast(GridView4.Rows(i).FindControl("ampm1"), DropDownList).SelectedValue = "AM"
            Else
                DirectCast(GridView4.Rows(i).FindControl("ampm1"), DropDownList).SelectedValue = "PM"
            End If
        Next
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim sts As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "status")).Trim
            If sts = "A" Or sts = "APPROVED" Or sts = "Approved" Then
                'GridView4.Rows(i).Cells(8).ForeColor = Drawing.Color.Green
                Dim cb As CheckBox = DirectCast(e.Row.FindControl("checkbox1"), CheckBox)
                cb.Enabled = True
            ElseIf sts = "S" Or sts = "SCHEDULED" Or sts = "Scheduled" Or sts = "Rejected" Or sts = "REJECTED" Or sts = "R" Then
                Dim cb As CheckBox = DirectCast(e.Row.FindControl("checkbox1"), CheckBox)
                cb.Enabled = False
            End If
        End If
    End Sub
    Private Sub gridview2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowDataBound
        Dim i As Integer
        For i = 0 To GridView2.Rows.Count - 1
            Dim sts As String = GridView2.Rows(i).Cells(10).Text
            Dim ab As String = GridView2.Rows(i).Cells(10).Text
            Dim rt = GridView2.Rows(i).Cells(8).Text
            Dim rts = GridView2.Rows(i).Cells(11).Text
            Dim rts1 = GridView2.Rows(i).Cells(7).Text

            'If e.Row.RowType = DataControlRowType.DataRow AndAlso e.Row.RowState = DataControlRowState.Normal Then
            '    Dim LinkButton1 = DirectCast(e.Row.FindControl("LinkButton1"), LinkButton)
            '    'Or some other logic, like converting to a boolean
            '    LinkButton1.Enabled = gridview2.DataKeys(e.Row.RowIndex).Value = "SomeValue"
            'End If

            If sts = "A" Or sts = "APPROVED" Or sts = "Approved" Then
                GridView2.Rows(i).Cells(8).ForeColor = Drawing.Color.Green
                'Dim cb As CheckBox = DirectCast(e.Row.FindControl("checkbox1"), CheckBox)
                'cb.Enabled = True
            ElseIf sts = "S" Or sts = "SCHEDULED" Or sts = "Scheduled" Or sts = "Rejected" Or sts = "REJECTED" Or sts = "R" Then
                'Dim cb As CheckBox = DirectCast(e.Row.FindControl("checkbox1"), CheckBox)
                'cb.Enabled = False
            End If

            If DateTime.Now.Hour > 12 And DateTime.Now.Hour < 24 Then
                Dim hr As String = DateTime.Now.Hour - 12
                DirectCast(GridView2.Rows(i).FindControl("hrs1"), DropDownList).SelectedValue = hr
            Else
                DirectCast(GridView2.Rows(i).FindControl("hrs1"), DropDownList).SelectedValue = DateTime.Now.Hour
            End If
            DirectCast(GridView2.Rows(i).FindControl("mints1"), DropDownList).SelectedValue = DateTime.Now.Minute
            If DateTime.Now.ToShortTimeString.Contains("AM") = True Then
                DirectCast(GridView2.Rows(i).FindControl("ampm1"), DropDownList).SelectedValue = "AM"
            Else
                DirectCast(GridView2.Rows(i).FindControl("ampm1"), DropDownList).SelectedValue = "PM"
            End If
        Next
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim sts As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "status")).Trim
            If sts = "A" Or sts = "APPROVED" Or sts = "Approved" Then
                'gridview2.Rows(i).Cells(8).ForeColor = Drawing.Color.Green
                Dim cb As CheckBox = DirectCast(e.Row.FindControl("checkbox1"), CheckBox)
                cb.Enabled = True
            ElseIf sts = "S" Or sts = "SCHEDULED" Or sts = "Scheduled" Or sts = "Rejected" Or sts = "REJECTED" Or sts = "R" Then
                Dim cb As CheckBox = DirectCast(e.Row.FindControl("checkbox1"), CheckBox)
                cb.Enabled = False
            End If
        End If
    End Sub
End Class