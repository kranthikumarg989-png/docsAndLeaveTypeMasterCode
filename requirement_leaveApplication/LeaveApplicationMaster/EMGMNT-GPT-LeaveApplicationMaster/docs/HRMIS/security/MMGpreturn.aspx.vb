Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports E_Management.Emanagement.globalinfo
Imports E_Management.Emanagement.EMSapplications
Partial Public Class MMGpreturn
    Inherits System.Web.UI.Page
    Dim myglobal As New emanagement.globalinfo
    Dim myapp As New emanagement.EMSapplications
    Dim doj, thisdate As Date
    Dim appno, cancfwd As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Session("_edept") = "9000"
        myglobal.Open_Con()
        myglobal.Con_Str()
        myglobal.Open_Con_mel()
        myglobal.Open_Con_lit()
        myglobal.Open_Con_out()


        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (119)
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
        For i As Integer = 0 To GridView1.Rows.Count - 1
            Dim passno As String = GridView1.Rows(i).Cells(0).Text
            Dim cbox As CheckBox = DirectCast(GridView1.Rows(i).FindControl("cb1"), CheckBox)
            Dim speed As String = DirectCast(GridView1.Rows(i).FindControl("textbox1"), TextBox).Text
            Dim hrs As DropDownList = DirectCast(GridView1.Rows(i).FindControl("hrs1"), DropDownList)
            Dim mints As DropDownList = DirectCast(GridView1.Rows(i).FindControl("mints1"), DropDownList)
            Dim ampm As DropDownList = DirectCast(GridView1.Rows(i).FindControl("ampm1"), DropDownList)
            Dim tin As String = hrs.SelectedValue.Trim & ":" & mints.SelectedValue.Trim & ampm.SelectedValue.Trim
            myglobal.Open_Con()
            myglobal.Con_Str()
            If cbox.Checked = True Then
                DS = Open_gatepass(Con, DAP, 2, "update staffgatepass set status = 'RETURNED', speedofmeterin='" & speed & "', atimein = '" & tin & "' where passno = '" & passno & "'")
            End If
            myglobal.db_close()
        Next
        gridview1.DataBind()
    End Sub
    Protected Sub UpdategpApprovalmel(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For i As Integer = 0 To GridView2.Rows.Count - 1
            Dim passno As String = GridView2.Rows(i).Cells(0).Text
            Dim cbox As CheckBox = DirectCast(GridView2.Rows(i).FindControl("cb1"), CheckBox)
            Dim speed As String = DirectCast(GridView2.Rows(i).FindControl("textbox1"), TextBox).Text
            Dim hrs As DropDownList = DirectCast(GridView2.Rows(i).FindControl("hrs1"), DropDownList)
            Dim mints As DropDownList = DirectCast(GridView2.Rows(i).FindControl("mints1"), DropDownList)
            Dim ampm As DropDownList = DirectCast(GridView2.Rows(i).FindControl("ampm1"), DropDownList)
            Dim tin As String = hrs.SelectedValue.Trim & ":" & mints.SelectedValue.Trim & ampm.SelectedValue.Trim
            myglobal.Open_Con_mel()
            myglobal.Con_Str()
            If cbox.Checked = True Then
                DS = Open_gatepass(Con, DAP, 2, "update staffgatepass set status = 'RETURNED', speedofmeterin='" & speed & "', atimein = '" & tin & "' where passno = '" & passno & "'")
            End If
            myglobal.db_close()
        Next
        GridView2.DataBind()
    End Sub
    Protected Sub UpdategpApprovallit(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For i As Integer = 0 To GridView3.Rows.Count - 1
            Dim passno As String = GridView3.Rows(i).Cells(0).Text
            Dim cbox As CheckBox = DirectCast(GridView3.Rows(i).FindControl("cb1"), CheckBox)
            Dim speed As String = DirectCast(GridView3.Rows(i).FindControl("textbox1"), TextBox).Text
            Dim hrs As DropDownList = DirectCast(GridView3.Rows(i).FindControl("hrs1"), DropDownList)
            Dim mints As DropDownList = DirectCast(GridView3.Rows(i).FindControl("mints1"), DropDownList)
            Dim ampm As DropDownList = DirectCast(GridView3.Rows(i).FindControl("ampm1"), DropDownList)
            Dim tin As String = hrs.SelectedValue.Trim & ":" & mints.SelectedValue.Trim & ampm.SelectedValue.Trim
            myglobal.Open_Con_lit()
            myglobal.Con_Str()
            If cbox.Checked = True Then
                DS = Open_gatepass(Con, DAP, 2, "update staffgatepass set status = 'RETURNED', speedofmeterin='" & speed & "', atimein = '" & tin & "' where passno = '" & passno & "'")
            End If
            myglobal.db_close()
        Next
        GridView3.DataBind()
    End Sub
    Protected Sub UpdategpApprovalout(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For i As Integer = 0 To GridView4.Rows.Count - 1
            Dim passno As String = GridView4.Rows(i).Cells(0).Text
            Dim cbox As CheckBox = DirectCast(GridView4.Rows(i).FindControl("cb1"), CheckBox)
            Dim speed As String = DirectCast(GridView4.Rows(i).FindControl("textbox1"), TextBox).Text
            Dim hrs As DropDownList = DirectCast(GridView4.Rows(i).FindControl("hrs1"), DropDownList)
            Dim mints As DropDownList = DirectCast(GridView4.Rows(i).FindControl("mints1"), DropDownList)
            Dim ampm As DropDownList = DirectCast(GridView4.Rows(i).FindControl("ampm1"), DropDownList)
            Dim tin As String = hrs.SelectedValue.Trim & ":" & mints.SelectedValue.Trim & ampm.SelectedValue.Trim
            myglobal.Open_Con_out()
            myglobal.Con_Str()
            If cbox.Checked = True Then
                DS = Open_gatepass(Con, DAP, 2, "update staffgatepass set status = 'RETURNED', speedofmeterin='" & speed & "', atimein = '" & tin & "' where passno = '" & passno & "'")
            End If
            myglobal.db_close()
        Next
        GridView4.DataBind()
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        For i As Integer = 0 To GridView1.Rows.Count - 1
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
    End Sub

End Class