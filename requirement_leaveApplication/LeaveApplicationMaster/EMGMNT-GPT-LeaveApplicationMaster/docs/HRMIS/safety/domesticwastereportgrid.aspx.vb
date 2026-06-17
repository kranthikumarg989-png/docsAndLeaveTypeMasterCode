Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class domesticwastereportgrid
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim sqltext, lbl As String
    Dim rdr As SqlDataReader
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        con = New SqlConnection(constr)
        con.Open()
        sqltext = Session("msr")
        cmd = New SqlCommand(sqltext, con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            lbl = rdr(0) & ""
        End While
        rdr.Close()
        sqltext = Session("items")
        cmd = New SqlCommand(sqltext, con)
        DS = GetappCharactersetting(sqltext)
        GridView1.DataSource = DS
        GridView1.DataBind()
        Session("msr") = ""
        Session("items") = ""
        If lbl.ToString.Trim = "" Or lbl.Contains("select") = True Then
            'GridView1.HeaderRow.Cells(3).Text = "weight"
        Else
            If total.Text <> "" Then
                GridView1.HeaderRow.Cells(3).Text = "Weight(" & lbl & ")"
            End If
        End If
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
    Private Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("Onload", "this.style.cursor = 'hand';")
            'e.Row.Cells[0].Controls.Add(selectButton)

        End If
    End Sub
    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        For n As Integer = 0 To GridView1.Rows.Count - 1
            Dim lbl As String = DirectCast(GridView1.Rows(n).FindControl("label1"), Label).Text
            'Dim i = Val(GridView1.Rows(n).Cells(3).Text) + Val(i) + 0
            Dim i = Val(lbl) + Val(i) + 0
            'GridView1.FooterRow.Cells(3).FindControl("addtotal") = i
            'DirectCast(GridView1.FooterRow.Cells(3).FindControl("addtotal"), Label).Text = ll
            total.Text = "Total Weight =" & i + 0
        Next

    End Sub
End Class