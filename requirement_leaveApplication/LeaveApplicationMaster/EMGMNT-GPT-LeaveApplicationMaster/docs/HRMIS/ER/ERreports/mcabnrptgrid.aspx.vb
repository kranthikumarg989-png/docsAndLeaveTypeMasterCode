Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class mcabnrptgrid
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
        If Session("pass") <> "" Then
            sqltext = Session("pass")
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
                ElseIf GridView1.Rows(i).Cells(n).Text.Contains(":00") = True Then
                    GridView1.Rows(i).Cells(n).Text = GridView1.Rows(i).Cells(n).Text.Replace(":00", "")
                ElseIf GridView1.Rows(i).Cells(n).Text.Contains("Jan  1 1900") = True Then
                    GridView1.Rows(i).Cells(n).Text = GridView1.Rows(i).Cells(n).Text.Replace("Jan  1 1900", "")
                End If
            Next
        Next
    End Sub
    Private Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        GridView1.DataBind()
    End Sub
End Class