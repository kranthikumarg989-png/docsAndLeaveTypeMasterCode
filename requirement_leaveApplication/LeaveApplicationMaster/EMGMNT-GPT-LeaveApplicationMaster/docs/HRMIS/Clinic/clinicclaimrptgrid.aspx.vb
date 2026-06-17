Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class clinicclaimrptgrid
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim sqltext, lbl As String
    Dim rslt
    Dim rdr As SqlDataReader
    Dim cmd As New SqlCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        Con = New SqlConnection(constr)
        Con.Open()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (236)
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

        sqltext = Session("dt")
        cmd = New SqlCommand(sqltext, Con)
        DS = GetappCharactersetting(sqltext)
        GridView1.DataSource = DS
        GridView1.DataBind()
        sqltext = Session("count")
        Con.Open()
        cmd = New SqlCommand(sqltext, Con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            If IsNumeric(rdr(0)) = False Then

            Else
                lbl = rdr(0)
            End If
        End While
        rdr.Close()
        If lbl.Contains(".0000") = True Then
            lbl = lbl.ToString.Replace(".0000", ".00")
        End If
        If lbl <> "" Then
            DirectCast(GridView1.FooterRow.FindControl("lbl2"), Label).Text = lbl
            GridView1.FooterRow.DataBind()
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
    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        For i As Integer = 0 To GridView1.Rows.Count - 1
            Dim zero As String = DirectCast(GridView1.Rows(i).FindControl("label2"), Label).Text
            If zero.Contains(".0000") = True Then
                DirectCast(GridView1.Rows(i).FindControl("label2"), Label).Text = DirectCast(GridView1.Rows(i).FindControl("label2"), Label).Text.Replace(".0000", ".00")
            End If
        Next
        If lbl <> "" Then
            DirectCast(GridView1.FooterRow.FindControl("lbl2"), Label).Text = lbl
        End If
    End Sub
    Private Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        If Session("dt").ToString.Contains("desc") = True Then
            Session("dt") = Session("dt").ToString.Replace("desc", "")
        Else
            Session("dt") = Session("dt") & " desc"
        End If
    End Sub
End Class