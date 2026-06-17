Imports System
Imports System.Web
Imports System.Data
Imports System.Data.SqlClient
Partial Class InRequest
    Inherits System.Web.UI.Page
    Public strCon As String = "Data Source=192.168.0.241;Initial Catalog=hrmis;uid=sa;"
    Dim sqlCon As SqlConnection()
    Dim sqlCmd As SqlCommand()
    Dim sqladapter As New SqlDataAdapter()
    Dim ds As New DataSet()
    Dim ds2 As New DataSet()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("EmpCode") = Nothing) Then
            Response.Redirect("Login.aspx")
        End If
        lblMsg.Text = ""
        If (Not IsPostBack()) Then
            BindGrid()
        End If
    End Sub
    Sub BindGrid()
        ds = New DataSet()
        Using sqlCon As New SqlConnection(strCon)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("sp_WorkPermit_in", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@Type", "InRequest")
                sqladapter = New SqlDataAdapter(sqlCmd)
                sqladapter.Fill(ds)
            End Using
        End Using
        gv.DataSource = ds
        gv.DataBind()
    End Sub
    Protected Sub gv_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv.RowCommand
        Dim dt As New DataTable()
        If (e.CommandName = "Remove") Then
            Using sqlCon As New SqlConnection(strCon)
                sqlCon.Open()
                Using sqlCmd As New SqlCommand("sp_WorkPermit_in", sqlCon)
                    sqlCmd.CommandType = CommandType.StoredProcedure
                    sqlCmd.Parameters.AddWithValue("@Type", "CancelRequest")
                    sqlCmd.Parameters.AddWithValue("@UIDs", e.CommandArgument.ToString())
                    sqlCmd.ExecuteNonQuery()
                End Using
            End Using
        End If
        BindGrid()
        lblMsg.Text = "Request has been removed"
    End Sub
End Class
