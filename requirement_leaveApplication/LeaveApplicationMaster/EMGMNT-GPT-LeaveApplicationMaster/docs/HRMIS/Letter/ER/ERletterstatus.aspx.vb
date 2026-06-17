Imports System.Data
Imports System
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class ERletterstatus
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TabContainer1.ActiveTabIndex = 0
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (186)
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
    Private Sub Gridview1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'determine the value of the status field
            Dim status As String = Trim(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "status")))
            Dim label As Label = TryCast(e.Row.FindControl("lbl1"), Label)
            Dim lbprint As LinkButton = TryCast(e.Row.FindControl("lbprint"), LinkButton)
            '   Dim lbshow As LinkButton = TryCast(e.Row.FindControl("lbshow"), LinkButton)

            'If label.Text = "a" Or status = "A" Or status = "Approved" Then
            '    'lbprint.Visible = False
            '    lbshow.Visible = True
            'Else
            '    'lbprint.Visible = False
            '    lbshow.Visible = True
            'End If
        End If
    End Sub
    Private Sub Gridview2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'determine the value of the status field
            Dim status As String = Trim(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "status")))
            Dim label As Label = TryCast(e.Row.FindControl("lbl1"), Label)
            Dim lbprint As LinkButton = TryCast(e.Row.FindControl("lbprint"), LinkButton)
            '  Dim lbshow As LinkButton = TryCast(e.Row.FindControl("lbshow"), LinkButton)

            'If label.Text = "a" Or status = "A" Or status = "Approved" Then
            '    'lbprint.Visible = False
            '    lbshow.Visible = True
            'Else
            '    'lbprint.Visible = False
            '    lbshow.Visible = True
            'End If
        End If
    End Sub
    Private Sub Gridview3_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView3.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'determine the value of the status field
            Dim status As String = Trim(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "status")))
            '   Dim label As Label = TryCast(e.Row.FindControl("lbl1"), Label)
            Dim lbprint As LinkButton = TryCast(e.Row.FindControl("lbprint"), LinkButton)
            Dim lbshow As LinkButton = TryCast(e.Row.FindControl("lbshow"), LinkButton)

            If status = "a" Or status = "A" Or status = "Approved" Then
                lbprint.Visible = True
                lbprint.ForeColor = Drawing.Color.Blue
                lbprint.Font.Underline = True
                lbshow.Visible = False

            Else
                lbprint.Visible = False
                'lbshow.Visible = True   'show visible chaged
                lbshow.Visible = False
            End If
        End If
    End Sub
    Private Sub GridView1_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.PageIndexChanged
        TabContainer1.ActiveTabIndex = 0
    End Sub
    Private Sub GridView2_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView2.PageIndexChanged
        TabContainer1.ActiveTabIndex = 1
    End Sub
    Private Sub GridView3_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView3.PageIndexChanged
        TabContainer1.ActiveTabIndex = 2
    End Sub
    Private Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        TabContainer1.ActiveTabIndex = 0
    End Sub
    Private Sub GridView2_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView2.Sorting
        TabContainer1.ActiveTabIndex = 1
    End Sub
    Private Sub GridView3_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView3.Sorting
        TabContainer1.ActiveTabIndex = 2
    End Sub
    Public Sub Fncshow(ByVal sender As Object, ByVal e As CommandEventArgs)
        Dim ln
        ln = e.CommandArgument
        Session("letterprint") = "show"
        Session("Lettername") = ln
        Response.Redirect("letterissueview.aspx")
    End Sub
    Public Sub makprint(ByVal sender As Object, ByVal e As CommandEventArgs)
        Dim ln
        ln = e.CommandArgument
        Session("Lettername") = ln
        Session("letterprint") = "print"
        Response.Redirect("letterissueview.aspx")
    End Sub
End Class