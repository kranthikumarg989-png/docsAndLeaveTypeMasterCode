Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Partial Public Class WasteWaterMonitoringgridrpt
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim sqltext, yr, mn, plt As String
    Dim ds As New DataSet
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (146)
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
        '''''''''''''''''''''''''''''''
        MyGlobal.Con_Str()
        MyGlobal.Open_Con_dmis()
        year.Focus()
        gv()
    End Sub
    Protected Sub show_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles show.Click
        If year.SelectedValue = "-1" Then
            MessageBox("select Year")
            year.Focus()
            Exit Sub
        ElseIf month.SelectedValue = "-1" Then
            messagebox("select month")
            month.Focus()
            Exit Sub
        ElseIf plant.SelectedValue = "-1" Then
            messagebox("select plantno")
            plant.Focus()
            Exit Sub
        End If
        Con.Open()
        Call gv()
        'sqltext = "select*from wastewater where year1='" & (year.SelectedValue) & "' and month1='" & (month.SelectedValue) & "' and plantno='" & (plant.SelectedValue) & "' order by day1"
        'Cmd = New SqlCommand(sqltext, Con)
        'ds = GetappCharactersetting(sqltext)
        'GridView1.DataSource = ds
        'GridView1.DataBind()
        Con.Close()
    End Sub
    Function GetappCharactersetting(ByVal sqltext As String) As DataSet
        Dim ds As New DataSet()
        Dim Command As New SqlCommand
        Command = New SqlCommand(sqltext, Con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "character")
        Con.Close()
        Return ds
    End Function
    Private Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        GridView1.DataBind()
    End Sub
    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        For i As Integer = 0 To GridView1.Rows.Count - 1
            Dim mon As String = GridView1.Rows(i).Cells(2).Text
            If mon = "Y" Then
                GridView1.Rows(i).Cells(2).Text = "January"
            ElseIf mon = "F" Then
                GridView1.Rows(i).Cells(2).Text = "February"
            ElseIf mon = "R" Then
                GridView1.Rows(i).Cells(2).Text = "March"
            ElseIf mon = "P" Then
                GridView1.Rows(i).Cells(2).Text = "April"
            ElseIf mon = "M" Then
                GridView1.Rows(i).Cells(2).Text = "May"
            ElseIf mon = "U" Then
                GridView1.Rows(i).Cells(2).Text = "June"
            ElseIf mon = "J" Then
                GridView1.Rows(i).Cells(2).Text = "July"
            ElseIf mon = "A" Then
                GridView1.Rows(i).Cells(2).Text = "August"
            ElseIf mon = "S" Then
                GridView1.Rows(i).Cells(2).Text = "September"
            ElseIf mon = "O" Then
                GridView1.Rows(i).Cells(2).Text = "October"
            ElseIf mon = "N" Then
                GridView1.Rows(i).Cells(2).Text = "November"
            ElseIf mon = "D" Then
                GridView1.Rows(i).Cells(2).Text = "December"
            End If
        Next
    End Sub
    Private Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting

    End Sub
    Sub gv()
        sqltext = "select*from wastewater where year1='" & (year.SelectedValue) & "' and month1='" & (month.SelectedValue) & "' and plantno='" & (plant.SelectedValue) & "' order by ltrim(rtrim(day1))"
        Cmd = New SqlCommand(sqltext, Con)
        ds = GetappCharactersetting(sqltext)
        GridView1.DataSource = ds
        GridView1.DataBind()
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
End Class