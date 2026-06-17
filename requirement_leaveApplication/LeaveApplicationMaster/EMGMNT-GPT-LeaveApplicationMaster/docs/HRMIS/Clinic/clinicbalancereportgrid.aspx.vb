Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class clinicbalancereportgrid
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim sqltext
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
            Dim bil As String = GridView1.Rows(i).Cells(6).Text
            If bil.Contains(".0000") = True Then
                GridView1.Rows(i).Cells(6).Text = GridView1.Rows(i).Cells(6).Text.Replace(".0000", ".00")
            End If
            Dim lbalance As Label = DirectCast(GridView1.Rows(i).FindControl("label"), Label)
            If bil <> "" Then
                DirectCast(GridView1.Rows(i).FindControl("label"), Label).Text = 150 - bil
            End If
        Next
    End Sub
    Private Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        If Session("qry").ToString.Contains("desc") = True Then
            Session("qry") = Session("qry").ToString.Replace("desc", "")
        Else
            Session("qry") = Session("qry") & " desc"
        End If
    End Sub
End Class