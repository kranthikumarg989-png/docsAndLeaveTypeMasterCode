Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class jobapplicationgridreport
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
        sqltext = Session("qry")
        cmd = New SqlCommand(sqltext, Con)
        DS = GetappCharactersetting(sqltext)
        GridView1.DataSource = DS
        GridView1.DataBind()
    End Sub
    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        Dim r As Integer
        r = e.Row.Cells.Count - 1
        For i As Integer = 0 To GridView1.Rows.Count - 1
            If  GridView1.Rows(i).Cells(2).Text.Contains("12:00:00 AM") = True Then
                GridView1.Rows(i).Cells(2).Text = GridView1.Rows(i).Cells(2).Text.Replace("12:00:00 AM", "")
            ElseIf GridView1.Rows(i).Cells(8).Text.Contains("12:00:00 AM") = True Then
                GridView1.Rows(i).Cells(8).Text = GridView1.Rows(i).Cells(8).Text.Replace("12:00:00 AM", "")
            End If
        Next
    End Sub
    Private Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        GridView1.DataBind()
    End Sub
    Function GetappCharactersetting(ByVal sqltext As String) As DataSet
        Dim ds As New DataSet()
        Dim Command As New SqlCommand
        Command = New SqlCommand(sqltext, con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "character")
        con.Close()
        Return ds
    End Function
    Public Sub printz(ByVal sender As Object, ByVal e As CommandEventArgs)
        Session("apno") = e.CommandArgument
        Session("letterprint") = "print"
        Response.Redirect("jobapplicationprinting.aspx")
    End Sub
    Private Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        If Session("qry").ToString.Contains("desc") = True Then
            Session("qry") = Session("qry").ToString.Replace("desc", "")
        Else
            Session("qry") = Session("qry") & " desc"
        End If
    End Sub
End Class