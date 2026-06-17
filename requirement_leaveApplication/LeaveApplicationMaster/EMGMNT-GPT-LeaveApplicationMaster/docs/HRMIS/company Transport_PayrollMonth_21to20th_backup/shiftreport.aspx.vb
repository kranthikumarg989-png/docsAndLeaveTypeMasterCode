Imports System.Data
Imports System
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class shiftreport
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim rdr As SqlDataReader
    Dim ad As SqlDataAdapter
    Dim dt As New DataTable
    Dim sqltext, sample As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        con = New SqlConnection(constr)
        con.Open()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (277)
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
    Protected Sub search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles search.Click
        errmsg.Text = ""
        GridView1.DataSource = Nothing
        If grcde.SelectedValue = "-1" Then
            errmsg.Text = "Select GroupCode"
            grcde.Focus()
            Exit Sub
        End If
        If fdt.Text = "From date" Or fdt.Text.Trim = "" Then
            errmsg.Text = "Select Fromdate"
            fdt.Text = ""
            fdt.Focus()
            Exit Sub
        End If
        If tdt.Text = "To date" Or tdt.Text.Trim = "" Then
            errmsg.Text = "Select Todate"
            tdt.Text = ""
            tdt.Focus()
            Exit Sub
        End If
        Dim fd1 As String
        fd1 = fdt.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)

        Dim td1 As String
        td1 = tdt.Text.Trim
        Dim strdate2() As String = td1.Split("/"c)
        td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

        Dim td As Date
        td = CDate(td1)
        sample = "select*from trans_shiftfinal where groupcode='" & (grcde.SelectedValue) & "' and (shiftdate>= '" & fd & "' and shiftdate <='" & td & "') order by shiftdate"
        Session("sql") = sample
        ad = New SqlDataAdapter(sample, con)
        ad.Fill(dt)
        GridView1.DataSource = dt
        GridView1.DataBind()
    End Sub
    Private Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        sqltext = Session("sql")
        ad = New SqlDataAdapter(sqltext, con)
        ad.Fill(dt)
        GridView1.DataSource = dt
        GridView1.DataBind()
    End Sub
    Private Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        If Session("sql").ToString.Contains("desc") = True Then
            Session("sql") = Session("sql").ToString.Replace("desc", "")
        Else
            Session("sql") = Session("sql") & " desc"
        End If
        sqltext = Session("sql")
        ad = New SqlDataAdapter(sqltext, con)
        ad.Fill(dt)
        GridView1.DataSource = dt
        GridView1.DataBind()
    End Sub
End Class