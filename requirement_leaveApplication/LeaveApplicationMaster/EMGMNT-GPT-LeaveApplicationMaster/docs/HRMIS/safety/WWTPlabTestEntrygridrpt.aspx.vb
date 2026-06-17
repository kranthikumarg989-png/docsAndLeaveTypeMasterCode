Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Partial Public Class WWTPlabTestEntrygridrpt
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim sqltext, sqltext1, textsql, yr, mn, plt As String
    Dim ds As New DataSet
    Dim ct As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (145)
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
        MyGlobal.Open_Con_dMIS()
        year.Focus()

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
    Protected Sub show_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles show.Click
        Con.Open()
        textsql = "select No,Paramters,Method,Stdb,january,february,march,april,may,june,july,august,september,october,novomber,december,Year from wwtplabtesttemp"
        If year.SelectedValue = "-1" Then
            MessageBox("Select year")
            year.Focus()
            Exit Sub
        End If
        'Session("wwtpno") = wwtpno.Text
        'sqltext = "select*from wwtplabtesttemp where year='" & year.SelectedValue & "'"
        For n As Integer = 1 To 12
            If n = 1 Then
                mn = "january"
                sqltext = "select count(wjanuary) from wwtplabtesttemp where year='" & (year.SelectedValue) & "' and wjanuary='" & (wwtpno.Text) & "'"
            ElseIf n = 2 Then
                mn = "february"
                sqltext = "select count(wfebruary) from wwtplabtesttemp where year='" & (year.SelectedValue) & "' and wfebruary='" & (wwtpno.Text) & "'"
            ElseIf n = 3 Then
                mn = "march"
                sqltext = "select count(wmarch) from wwtplabtesttemp where year='" & (year.SelectedValue) & "' and wmarch='" & (wwtpno.Text) & "'"
            ElseIf n = 4 Then
                mn = "april"
                sqltext = "select count(wapril) from wwtplabtesttemp where year='" & (year.SelectedValue) & "' and wapril='" & (wwtpno.Text) & "'"
            ElseIf n = 5 Then
                mn = "may"
                sqltext = "select count(wmay) from wwtplabtesttemp where year='" & (year.SelectedValue) & "' and wmay='" & (wwtpno.Text) & "'"
            ElseIf n = 6 Then
                mn = "june"
                sqltext = "select count(wjune) from wwtplabtesttemp where year='" & (year.SelectedValue) & "' and wjune='" & (wwtpno.Text) & "'"
            ElseIf n = 7 Then
                mn = "july"
                sqltext = "select count(wjuly) from wwtplabtesttemp where year='" & (year.SelectedValue) & "' and wjuly='" & (wwtpno.Text) & "'"
            ElseIf n = 8 Then
                mn = "august"
                sqltext = "select count(waugust) from wwtplabtesttemp where year='" & (year.SelectedValue) & "' and waugust='" & (wwtpno.Text) & "'"
            ElseIf n = 9 Then
                mn = "september"
                sqltext = "select count(wseptember) from wwtplabtesttemp where year='" & (year.SelectedValue) & "' and wseptember='" & (wwtpno.Text) & "'"
            ElseIf n = 10 Then
                mn = "october"
                sqltext = "select count(woctober) from wwtplabtesttemp where year='" & (year.SelectedValue) & "' and woctober='" & (wwtpno.Text) & "'"
            ElseIf n = 11 Then
                mn = "novomber"
                sqltext = "select count(wnovomber) from wwtplabtesttemp where year='" & (year.SelectedValue) & "' and wnovomber='" & (wwtpno.Text) & "'"
            ElseIf n = 12 Then
                mn = "december"
                sqltext = "select count(wdecember) from wwtplabtesttemp where year='" & (year.SelectedValue) & "' and wdecember='" & (wwtpno.Text) & "'"
            End If
            Cmd = New SqlCommand(sqltext, Con)
            ct = Cmd.ExecuteScalar
            If ct = 0 Then
                'textsql = "select No,Paramters,Method,Stdb,january,february,march,april,may,june,july,august,september,october,novomber,december,Year from wwtplabtesttemp"
                If textsql.Contains(mn) = True Then
                    textsql = textsql.Replace(mn, "")
                    textsql = textsql.Replace(",,", ",")

                End If
            End If
        Next
        'sqltext1 = " where year='" & (year.SelectedValue) & "' and (wjanuary='" & (wwtpno.Text) & "' or wfebruary='" & (wwtpno.Text) & "'  or wmarch='" & (wwtpno.Text) & "'  or wapril='" & (wwtpno.Text) & "' or wmay='" & (wwtpno.Text) & "'  or wjune='" & (wwtpno.Text) & "'  or wjuly='" & (wwtpno.Text) & "'  or waugust='" & (wwtpno.Text) & "'  or wseptember='" & (wwtpno.Text) & "'  or woctober='" & (wwtpno.Text) & "'  or wnovomber='" & (wwtpno.Text) & "'  or wdecember='" & (wwtpno.Text) & "')"
        'sqltext = textsql & sqltext1        'this is for particulaur month selection where wwtpno is match
        sqltext = "select No,Paramters,Method,Stdb,january,february,march,april,may,june,july,august,september,october,novomber,december,year from wwtplabtesttemp where year='" & (year.SelectedValue) & "' and (wjanuary='" & (wwtpno.Text) & "' or wfebruary='" & (wwtpno.Text) & "'  or wmarch='" & (wwtpno.Text) & "'  or wapril='" & (wwtpno.Text) & "' or wmay='" & (wwtpno.Text) & "'  or wjune='" & (wwtpno.Text) & "'  or wjuly='" & (wwtpno.Text) & "'  or waugust='" & (wwtpno.Text) & "'  or wseptember='" & (wwtpno.Text) & "'  or woctober='" & (wwtpno.Text) & "'  or wnovomber='" & (wwtpno.Text) & "'  or wdecember='" & (wwtpno.Text) & "')"
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
    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        For i As Integer = 0 To GridView1.Columns.Count - 1
            'If GridView1.Columns(i).c Then
        Next

    End Sub
End Class