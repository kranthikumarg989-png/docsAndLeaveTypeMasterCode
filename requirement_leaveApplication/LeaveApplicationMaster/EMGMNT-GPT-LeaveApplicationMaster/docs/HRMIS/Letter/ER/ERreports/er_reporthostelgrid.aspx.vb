Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class er_reporthostelgrid
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim sqltext As String
    Dim cmd As New SqlCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        Con = New SqlConnection(constr)
        Con.Open()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (192)
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

        If Session("sql") <> "" Then
            sqltext = Session("sql")
            title.Text = Session("tblname").ToString.ToUpper
            title.Font.Bold = True
            title.ForeColor = Drawing.Color.Blue
        Else

        End If
        cmd = New SqlCommand(sqltext, Con)
        DS = GetappCharactersetting(sqltext)
        GridView1.DataSource = DS
        GridView1.DataBind()
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
    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        For i As Integer = 0 To GridView1.Rows.Count - 1
            For n As Integer = 0 To e.Row.Cells.Count - 1
                If GridView1.Rows(i).Cells(n).Text.Contains("12:00:00 AM") = True Then
                    GridView1.Rows(i).Cells(n).Text = GridView1.Rows(i).Cells(n).Text.Replace("12:00:00 AM", "")
                End If
            Next
        Next
        For h As Integer = 1 To GridView1.Columns.Count - 1
            GridView1.Columns(h).HeaderText = GridView1.Columns(h).HeaderText.ToString.ToUpper
        Next
    End Sub
    Private Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        GridView1.DataBind()
    End Sub
End Class